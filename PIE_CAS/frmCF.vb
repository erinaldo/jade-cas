Public Class frmCF
    Dim TransID As String
    Dim CFNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "CF"
    Dim ColumnPK As String = "CF_No"
    Dim DBTable As String = "tblCF"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim PR_ID As Integer
    Public supA, supB, supC, supD As String
    Dim rowId As Integer

#Region "Verified"
    Private Sub frmPR_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID) ' SET TRANSACTION IF MANUAL OR AUTO-GENERATED
            dtpDocDate.Value = Date.Today.Date
            dtpDelivery.Value = Date.Today.Date
            dgvList.Font = New Font("Microsoft Sans Serif", 8)
            LoadCostCenter()
            If CFNo <> "" Then
                LoadCF(CFNo)
            End If
            tsbSearch.Enabled = True
            tsbNew.Enabled = True
            tsbEdit.Enabled = False
            tsbSave.Enabled = False
            tsbCancel.Enabled = False
            tsbClose.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = True
            tsbPrint.Enabled = False
            tsbCopy.Enabled = False
            EnableControl(False)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadCostCenter()
        Dim query As String
        query = " SELECT Description FROM tblCC WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbCostCenter.Items.Clear()
        While SQL.SQLDR.Read
            cbCostCenter.Items.Add(SQL.SQLDR("Description").ToString)
        End While
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        dgvList.AllowUserToAddRows = Value
        dgvList.AllowUserToDeleteRows = Value
        If Value = True Then
            dgvList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            dgvVATdetail.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvList.EditMode = DataGridViewEditMode.EditProgrammatically
            dgvVATdetail.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        cbDeliverTo.Enabled = Value
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        dtpDelivery.Enabled = Value
        cbPurchType.Enabled = Value
        txtPRNo.Enabled = Value
        cbCostCenter.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub ClearText()
        txtTransNum.Text = ""
        dgvList.Rows.Clear()
        dgvVATdetail.Rows.Clear()
        cbDeliverTo.Text = ""
        cbCostCenter.Text = ""
        txtRemarks.Text = ""
        txtGross.Text = "0.00"
        txtNet.Text = "0.00"
        txtVAT.Text = "0.00"
        txtPRNo.Text = ""
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        dtpDelivery.Value = Date.Today.Date
        cbPurchType.SelectedItem = "Goods"
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("CF_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            CFNo = ""

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbCancel.Enabled = False
            tsbClose.Enabled = True
            tsbCopy.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
            tsbPrint.Enabled = False
            EnableControl(True)

            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub

#End Region


    Private Sub LoadCF(ByVal TransNum As String)
        Dim CC As String = ""
        Dim query As String
        query = " SELECT   TransID, CF_No, DateCF, PR_Ref, GrossAmount, VATAmount, CostCenter, PR_Ref, TotalAmount, PurchaseType, Remarks, DateNeeded, RequestedBy, Status " & _
                " FROM     tblCF " & _
                " WHERE    TransID = '" & TransNum & "' " & _
                " ORDER BY TransID "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            txtTransNum.Text = SQL.SQLDR("CF_No").ToString
            CFNo = SQL.SQLDR("CF_No").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtPRNo.Text = SQL.SQLDR("PR_Ref").ToString
            txtGross.Text = SQL.SQLDR("GrossAmount").ToString
            txtVAT.Text = SQL.SQLDR("VATAmount").ToString
            CC = SQL.SQLDR("CostCenter").ToString
            txtNet.Text = SQL.SQLDR("TotalAmount").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            dtpDocDate.Text = SQL.SQLDR("DateCF").ToString
            dtpDelivery.Text = SQL.SQLDR("DateNeeded").ToString
            cbDeliverTo.Text = SQL.SQLDR("RequestedBy").ToString
            PR_ID = SQL.SQLDR("PR_Ref").ToString
            If Not IsDBNull(SQL.SQLDR("PurchaseType")) Then
                cbPurchType.SelectedItem = SQL.SQLDR("PurchaseType").ToString
            Else
                cbPurchType.SelectedIndex = -1
            End If
            cbCostCenter.SelectedItem = GetCCName(CC)
            txtPRNo.Text = LoadPRNo(PR_ID)
            LoadCFDetails(TransID)
            LoadSelectedSupplier()
            ' TOOLSTRIP BUTTONS
            If txtStatus.Text = "Cancelled" Then
                tsbEdit.Enabled = False
                tsbCancel.Enabled = False
            Else
                tsbEdit.Enabled = True
                tsbCancel.Enabled = True
            End If
            tsbPrint.Enabled = True
            tsbClose.Enabled = False
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbPrint.Enabled = True
            tsbSave.Enabled = False
            tsbNew.Enabled = True
            tsbSearch.Enabled = True
            tsbExit.Enabled = True
            EnableControl(False)
        Else
            ClearText()
        End If
    End Sub

    Private Sub LoadSelectedSupplier()
        For Each row As DataGridViewRow In dgvList.Rows
            For i As Integer = 0 To dgvList.ColumnCount - 1
                dgvList.Rows(row.Index).Cells(i).Style.BackColor = Color.White
            Next
            If dgvList.Item(chApprovedSupplier.Index, row.Index).Value = "Supplier 1" Then
                dgvList.Rows(row.Index).Cells(chSupplier1.Index).Style.BackColor = Color.Yellow
                dgvList.Rows(row.Index).Cells(chUnitCost1.Index).Style.BackColor = Color.Yellow
            ElseIf dgvList.Item(chApprovedSupplier.Index, row.Index).Value = "Supplier 2" Then
                dgvList.Rows(row.Index).Cells(chSupplier2.Index).Style.BackColor = Color.Yellow
                dgvList.Rows(row.Index).Cells(chUnitCost2.Index).Style.BackColor = Color.Yellow
            ElseIf dgvList.Item(chApprovedSupplier.Index, row.Index).Value = "Supplier 3" Then
                dgvList.Rows(row.Index).Cells(chSupplier3.Index).Style.BackColor = Color.Yellow
                dgvList.Rows(row.Index).Cells(chUnitCost3.Index).Style.BackColor = Color.Yellow
            ElseIf dgvList.Item(chApprovedSupplier.Index, row.Index).Value = "Supplier 4" Then
                dgvList.Rows(row.Index).Cells(chSupplier4.Index).Style.BackColor = Color.Yellow
                dgvList.Rows(row.Index).Cells(chUnitCost4.Index).Style.BackColor = Color.Yellow
            End If
        Next
        
    End Sub

    Private Function LoadPRNo(ID As Integer) As String
        Dim query As String
        query = " SELECT PR_No FROM tblPR WHERE TransID = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("PR_No")
        Else
            Return ""
        End If
    End Function

    Protected Sub LoadCFDetails(ByVal TransID As String)
        Dim query As String

        query = " SELECT    TransID, ItemGroup, ItemCode, Description,  UOM, QTY, S1code, S1price, S1vat, S1vatInc, S2code, S2price, S2vat, S2vatInc, " & _
                "           S3code, S3price, S3vat, S3vatInc, S4code, S4price, S4vat, S4vatInc, ApproveSP, GrossAmount, VATAmount, TotalAmount " & _
                " FROM      tblCF_Details " & _
                " WHERE     TransID = '" & TransID & "' "
        dgvList.Rows.Clear()
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            Dim ctr As Integer = 0
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvList.Rows.Add(row(1).ToString, row(2).ToString, row(3).ToString, row(4).ToString, row(5).ToString, _
                                 row(6).ToString, GetVCEName(row(6).ToString), row(7).ToString, row(8).ToString, row(9).ToString, _
                                 row(10).ToString, GetVCEName(row(10).ToString), row(11).ToString, row(12).ToString, row(13).ToString, _
                                 row(14).ToString, GetVCEName(row(14).ToString), row(15).ToString, row(16).ToString, row(17).ToString, _
                                 row(18).ToString, GetVCEName(row(18).ToString), row(19).ToString, row(20).ToString, row(21).ToString, _
                                 row(22).ToString, row(23).ToString, row(24).ToString, row(25).ToString)
                LoadSupplier(row(1).ToString, row(2).ToString, chSupplier1.Index, ctr)
                LoadSupplier(row(1).ToString, row(2).ToString, chSupplier2.Index, ctr)
                LoadSupplier(row(1).ToString, row(2).ToString, chSupplier3.Index, ctr)
                LoadSupplier(row(1).ToString, row(2).ToString, chSupplier4.Index, ctr)
                LoadSupplierSelection(ctr)
                ctr += 1
            Next

        End If
    End Sub

    Private Sub ComputeTotal()
        Dim b As Decimal = 0
        Dim a As Decimal = 0
        Dim c As Decimal = 0
        ' COMPUTE BASE
        For i As Integer = 0 To dgvList.Rows.Count - 1
            If Val(dgvList.Item(dgcGross.Index, i).Value) <> 0 Then
                If IsNumeric(dgvList.Item(dgcGross.Index, i).Value) Then
                    a = a + Double.Parse(dgvList.Item(dgcGross.Index, i).Value).ToString
                End If
            End If
        Next
        txtGross.Text = a.ToString("N2")


        ' COMPUTE VAT 
        For i As Integer = 0 To dgvList.Rows.Count - 1
            If Val(dgvList.Item(chVAT.Index, i).Value) <> 0 Then
                If IsNumeric(dgvList.Item(chVAT.Index, i).Value) Then
                    b = b + Double.Parse(dgvList.Item(chVAT.Index, i).Value).ToString
                End If
            End If
        Next
        txtVAT.Text = b.ToString("N2")

        ' COMPUTE NET
        For i As Integer = 0 To dgvList.Rows.Count - 1
            If Val(dgvList.Item(chTotalPrice.Index, i).Value) <> 0 Then
                If IsNumeric(dgvList.Item(chTotalPrice.Index, i).Value) Then
                    c = c + Double.Parse(dgvList.Item(chTotalPrice.Index, i).Value).ToString
                End If
            End If
        Next
        txtNet.Text = c.ToString("N2")
    End Sub

    Private Sub Recompute(ByVal RowID As Integer, ByVal ColID As Integer)
        Dim up1, up2, up3, up4, qty, gross, base, VAT, Total As Decimal
        Dim VATable, VATinc As Boolean

        If RowID <> -1 Then
            If IsNumeric(dgvList.Item(chUnitCost1.Index, RowID).Value) Or IsNumeric(dgvList.Item(chUnitCost2.Index, RowID).Value) Or IsNumeric(dgvList.Item(chUnitCost3.Index, RowID).Value) Or IsNumeric(dgvList.Item(chUnitCost4.Index, RowID).Value) Then
                ' GET GROSS AMOUNT (VAT INCLUSIVE)

                qty = CDec(dgvList.Item(chQTY.Index, RowID).Value)
                up1 = CDec(dgvList.Item(chUnitCost1.Index, RowID).Value)
                up2 = CDec(dgvList.Item(chUnitCost2.Index, RowID).Value)
                up3 = CDec(dgvList.Item(chUnitCost3.Index, RowID).Value)
                up4 = CDec(dgvList.Item(chUnitCost4.Index, RowID).Value)
                If dgvList.Item(chApprovedSupplier.Index, RowID).Value = "Supplier 1" Then
                    gross = up1 * qty
                    VATable = dgvList.Item(chVAT1.Index, RowID).Value
                    VATinc = dgvList.Item(chVATInc1.Index, RowID).Value
                ElseIf dgvList.Item(chApprovedSupplier.Index, RowID).Value = "Supplier 2" Then
                    gross = up2 * qty
                    VATable = dgvList.Item(chVAT2.Index, RowID).Value
                    VATinc = dgvList.Item(chVATInc2.Index, RowID).Value
                ElseIf dgvList.Item(chApprovedSupplier.Index, RowID).Value = "Supplier 3" Then
                    gross = up3 * qty
                    VATable = dgvList.Item(chVAT3.Index, RowID).Value
                    VATinc = dgvList.Item(chVATInc3.Index, RowID).Value
                ElseIf dgvList.Item(chApprovedSupplier.Index, RowID).Value = "Supplier 4" Then
                    gross = up4 * qty
                    VATable = dgvList.Item(chVAT4.Index, RowID).Value
                    VATinc = dgvList.Item(chVATInc4.Index, RowID).Value
                End If

                ' COMPUTE VAT
                If VATable Then
                    If VATinc Then
                        base = gross / 1.12
                    Else
                        base = gross
                    End If
                    VAT = base * 0.12
                Else
                    base = gross
                    VAT = 0
                End If

                Total = base + VAT
                dgvList.Item(dgcGross.Index, RowID).Value = Format(gross, "#,###,###,###.00").ToString()
                dgvList.Item(chVAT.Index, RowID).Value = Format(VAT, "#,###,###,###.00").ToString()
                dgvList.Item(chTotalPrice.Index, RowID).Value = Format(Total, "#,###,###,###.00").ToString()
                ComputeTotal()
            End If
        End If

    End Sub


    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("CF_EDIT") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbCancel.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
            tsbPrint.Enabled = False
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If cbPurchType.SelectedIndex = -1 Then
            Msg("Please select purchase type!", MsgBoxStyle.Exclamation)
        ElseIf RecordsValidated() Then
            If TransID = "" Then
                If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    TransID = GenerateTransID(ColumnPK, DBTable)
                    CFNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                    txtTransNum.Text = CFNo
                    SaveCF()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    CFNo = txtTransNum.Text
                    LoadCF(CFNo)
                End If
            Else
                If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdateCF()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    CFNo = txtTransNum.Text
                    LoadCF(CFNo)
                End If
            End If
        End If
    End Sub

    Private Function RecordsValidated() As Boolean
        Dim ctr As Integer = 0
        Dim valid As Boolean = True
        For Each row As DataGridViewRow In dgvList.Rows
            If cbPurchType.SelectedItem = "Goods" Then
                If row.Cells(chItemCode.Index).Value <> Nothing AndAlso row.Cells(chItemCode.Index).Value <> "" _
                    AndAlso (row.Cells(chQTY.Index).Value = Nothing OrElse Not IsNumeric(row.Cells(chQTY.Index).Value)) Then
                    Msg("Please input quantity for this item!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemCode.Index).Value <> Nothing AndAlso row.Cells(chQTY.Index).Value = Nothing Then
                    Msg("No Item Selected for this quantity!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemCode.Index).Value <> Nothing AndAlso row.Cells(chQTY.Index).Value <> Nothing Then
                    ctr += 1
                End If
            ElseIf cbPurchType.SelectedItem = "Services" Then
                If row.Cells(chItemDesc.Index).Value <> Nothing AndAlso row.Cells(chQTY.Index).Value = Nothing Then
                    Msg("Please input quantity for this item!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemDesc.Index).Value <> Nothing AndAlso row.Cells(chQTY.Index).Value = Nothing Then
                    Msg("No Item Selected for this quantity!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemDesc.Index).Value <> Nothing AndAlso row.Cells(chQTY.Index).Value <> Nothing Then
                    ctr += 1
                End If
            End If
        Next
        If ctr = 0 Then
            Msg("Please enter item/services to purchase", MsgBoxStyle.Exclamation)
            valid = False
        End If
        Return valid
    End Function

    Private Sub SaveCF()
        Try
            activityStatus = True
            Dim CC As String = ""
            If cbCostCenter.SelectedIndex <> -1 Then
                CC = GetCCCode(cbCostCenter.SelectedItem)
            End If
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                         " tblCF(TransID, CF_No, BranchCode, BusinessCode, DateCF, PR_Ref, CostCenter, GrossAmount, VATAmount, TotalAmount, PurchaseType, Remarks, DateNeeded, RequestedBy, WhoCreated) " & _
                         " VALUES(@TransID, @CF_No, @BranchCode, @BusinessCode, @DateCF, @PR_Ref, @CostCenter, @GrossAmount, @VATAmount, @TotalAmount, @PurchaseType, @Remarks, @DateNeeded, @RequestedBy, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@CF_No", CFNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateCF", dtpDocDate.Value.Date)
            SQL.AddParam("@PR_Ref", PR_ID)
            SQL.AddParam("@CostCenter", CC)
            SQL.AddParam("@GrossAmount", CDec(IIf(IsNumeric(txtGross.Text), txtGross.Text, 0)))
            SQL.AddParam("@VATAmount", CDec(IIf(IsNumeric(txtVAT.Text), txtVAT.Text, 0)))
            SQL.AddParam("@TotalAmount", CDec(IIf(IsNumeric(txtNet.Text), txtNet.Text, 0)))
            SQL.AddParam("@PurchaseType", cbPurchType.SelectedItem)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@DateNeeded", dtpDelivery.Value.Date)
            SQL.AddParam("@RequestedBy", cbDeliverTo.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvList.Rows
                If item.Cells(chQTY.Index).Value <> Nothing Then
                    insertSQL = " INSERT INTO " & _
                       " tblCF_Details(TransID, ItemGroup, ItemCode, Description, QTY, UOM, S1code, S1price, S1vat, S1vatInc, S2code, S2price, S2vat, S2vatInc, " & _
                       "               S3code, S3price, S3vat, S3vatInc, S4code, S4price, S4vat, S4vatInc, ApproveSP, GrossAmount, VATAmount, TotalAmount, LineNum, WhoCreated) " & _
                       " VALUES(@TransID, @ItemGroup, @ItemCode, @Description, @QTY, @UOM, @S1code, @S1price, @S1vat, @S1vatInc, @S2code, @S2price, @S2vat, @S2vatInc, " & _
                       "               @S3code, @S3price, @S3vat, @S3vatInc, @S4code, @S4price, @S4vat, @S4vatInc, @ApproveSP, @GrossAmount, @VATAmount, @TotalAmount, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    If IsNothing(item.Cells(dgcBOMgroup.Index).Value) Then SQL.AddParam("@ItemGroup", "") Else SQL.AddParam("@ItemGroup", item.Cells(dgcBOMgroup.Index).Value)
                    If cbPurchType.SelectedItem = "Goods" Then SQL.AddParam("@ItemCode", item.Cells(chItemCode.Index).Value) Else SQL.AddParam("@ItemCode", "")
                    If cbPurchType.SelectedItem = "Goods" Then SQL.AddParam("@UOM", item.Cells(chUOM.Index).Value) Else SQL.AddParam("@UOM", "")
                    SQL.AddParam("@Description", item.Cells(chItemDesc.Index).Value)
                    SQL.AddParam("@QTY", item.Cells(chQTY.Index).Value)

                    ' SUPPLIER 1
                    If (item.Cells(chCode1.Index).Value) Is Nothing Then SQL.AddParam("@S1code", "") Else SQL.AddParam("@S1code", item.Cells(chCode1.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost1.Index).Value) Then SQL.AddParam("@S1price", CDec(item.Cells(chUnitCost1.Index).Value)) Else SQL.AddParam("@S1price", 0)
                    If (item.Cells(chVAT1.Index).Value) Is Nothing Then SQL.AddParam("@S1vat", "") Else SQL.AddParam("@S1vat", item.Cells(chVAT1.Index).Value)
                    If (item.Cells(chVATInc1.Index).Value) Is Nothing Then SQL.AddParam("@S1vatInc", "") Else SQL.AddParam("@S1vatInc", item.Cells(chVATInc1.Index).Value)

                    ' SUPPLIER 2
                    If (item.Cells(chCode2.Index).Value) Is Nothing Then SQL.AddParam("@S2code", "") Else SQL.AddParam("@S2code", item.Cells(chCode2.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost2.Index).Value) Then SQL.AddParam("@S2price", CDec(item.Cells(chUnitCost2.Index).Value)) Else SQL.AddParam("@S2price", 0)
                    If (item.Cells(chVAT2.Index).Value) Is Nothing Then SQL.AddParam("@S2vat", "") Else SQL.AddParam("@S2vat", item.Cells(chVAT2.Index).Value)
                    If (item.Cells(chVATInc2.Index).Value) Is Nothing Then SQL.AddParam("@S2vatInc", "") Else SQL.AddParam("@S2vatInc", item.Cells(chVATInc2.Index).Value)

                    ' SUPPLIER 3
                    If (item.Cells(chCode3.Index).Value) Is Nothing Then SQL.AddParam("@S3code", "") Else SQL.AddParam("@S3code", item.Cells(chCode3.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost3.Index).Value) Then SQL.AddParam("@S3price", CDec(item.Cells(chUnitCost3.Index).Value)) Else SQL.AddParam("@S3price", 0)
                    If (item.Cells(chVAT3.Index).Value) Is Nothing Then SQL.AddParam("@S3vat", "") Else SQL.AddParam("@S3vat", item.Cells(chVAT3.Index).Value)
                    If (item.Cells(chVATInc3.Index).Value) Is Nothing Then SQL.AddParam("@S3vatInc", "") Else SQL.AddParam("@S3vatInc", item.Cells(chVATInc3.Index).Value)

                    ' SUPPLIER 4
                    If (item.Cells(chCode4.Index).Value) Is Nothing Then SQL.AddParam("@S4code", "") Else SQL.AddParam("@S4code", item.Cells(chCode4.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost4.Index).Value) Then SQL.AddParam("@S4price", CDec(item.Cells(chUnitCost4.Index).Value)) Else SQL.AddParam("@S4price", 0)
                    If (item.Cells(chVAT4.Index).Value) Is Nothing Then SQL.AddParam("@S4vat", "") Else SQL.AddParam("@S4vat", item.Cells(chVAT4.Index).Value)
                    If (item.Cells(chVATInc4.Index).Value) Is Nothing Then SQL.AddParam("@S4vatInc", "") Else SQL.AddParam("@S4vatInc", item.Cells(chVATInc4.Index).Value)

                    If IsNothing(item.Cells(chApprovedSupplier.Index).Value) Then SQL.AddParam("@ApproveSP", "") Else SQL.AddParam("@ApproveSP", item.Cells(chApprovedSupplier.Index).Value)
                    If IsNumeric(item.Cells(dgcGross.Index).Value) Then SQL.AddParam("@GrossAmount", CDec(item.Cells(dgcGross.Index).Value)) Else SQL.AddParam("@GrossAmount", 0)
                    If IsNumeric(item.Cells(chVAT.Index).Value) Then SQL.AddParam("@VATAmount", CDec(item.Cells(chVAT.Index).Value)) Else SQL.AddParam("@VATAmount", 0)
                    If IsNumeric(item.Cells(chTotalPrice.Index).Value) Then SQL.AddParam("@TotalAmount", CDec(item.Cells(chTotalPrice.Index).Value)) Else SQL.AddParam("@TotalAmount", 0)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                End If
                line += 1
            Next

            Dim updateSQL As String
            updateSQL = "UPDATE tblPR SET Status ='Closed' WHERE TransID = '" & PR_ID & "' "
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "CF_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdateCF()
        Try
            activityStatus = True

            Dim CC As String = ""
            If cbCostCenter.SelectedIndex <> -1 Then
                CC = GetCCCode(cbCostCenter.SelectedItem)
            End If
            ' UPDATE PR HEADER
            Dim updateSQL, deleteSQL, insertSQL As String
            updateSQL = " UPDATE tblCF " & _
                        " SET    CF_No = @CF_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, CostCenter = @CostCenter, " & _
                        "        GrossAmount = @GrossAmount, VATAmount = @VATAmount, TotalAmount = @TotalAmount, " & _
                        "        DateCF = @DateCF, PurchaseType = @PurchaseType, Remarks = @Remarks, " & _
                        "        DateNeeded = @DateNeeded, RequestedBy = @RequestedBy, " & _
                        "        DateModified = GETDATE(), WhoModified = @WhoModified " & _
                        " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@CF_No", txtTransNum.Text)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateCF", dtpDocDate.Value.Date)
            SQL.AddParam("@GrossAmount", CDec(IIf(IsNumeric(txtGross.Text), txtGross.Text, 0)))
            SQL.AddParam("@VATAmount", CDec(IIf(IsNumeric(txtVAT.Text), txtVAT.Text, 0)))
            SQL.AddParam("@TotalAmount", CDec(IIf(IsNumeric(txtNet.Text), txtNet.Text, 0)))
            SQL.AddParam("@CostCenter", CC)
            SQL.AddParam("@PurchaseType", cbPurchType.SelectedItem)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@DateNeeded", dtpDelivery.Value.Date)
            SQL.AddParam("@RequestedBy", cbDeliverTo.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            ' DELETE CF DETAILS
            deleteSQL = " DELETE FROM tblCF_Details WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            ' INSERT CF DETAILS
            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvList.Rows
                If item.Cells(chQTY.Index).Value <> Nothing Then
                    insertSQL = " INSERT INTO " & _
                       " tblCF_Details(TransID, ItemGroup, ItemCode, Description, QTY, UOM, S1code, S1price, S1vat, S1vatInc, S2code, S2price, S2vat, S2vatInc, " & _
                       "               S3code, S3price, S3vat, S3vatInc, S4code, S4price, S4vat, S4vatInc, ApproveSP, GrossAmount, VATAmount, TotalAmount, LineNum, WhoCreated) " & _
                       " VALUES(@TransID, @ItemGroup, @ItemCode, @Description, @QTY, @UOM, @S1code, @S1price, @S1vat, @S1vatInc, @S2code, @S2price, @S2vat, @S2vatInc, " & _
                       "               @S3code, @S3price, @S3vat, @S3vatInc, @S4code, @S4price, @S4vat, @S4vatInc, @ApproveSP, @GrossAmount, @VATAmount, @TotalAmount, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    If IsNothing(item.Cells(dgcBOMgroup.Index).Value) Then SQL.AddParam("@ItemGroup", "") Else SQL.AddParam("@ItemGroup", item.Cells(dgcBOMgroup.Index).Value)
                    If cbPurchType.SelectedItem = "Goods" Then SQL.AddParam("@ItemCode", item.Cells(chItemCode.Index).Value) Else SQL.AddParam("@ItemCode", "")
                    If cbPurchType.SelectedItem = "Goods" Then SQL.AddParam("@UOM", item.Cells(chUOM.Index).Value) Else SQL.AddParam("@UOM", "")
                    SQL.AddParam("@Description", item.Cells(chItemDesc.Index).Value)
                    SQL.AddParam("@QTY", item.Cells(chQTY.Index).Value)

                    ' SUPPLIER 1
                    If (item.Cells(chCode1.Index).Value) Is Nothing Then SQL.AddParam("@S1code", "") Else SQL.AddParam("@S1code", item.Cells(chCode1.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost1.Index).Value) Then SQL.AddParam("@S1price", CDec(item.Cells(chUnitCost1.Index).Value)) Else SQL.AddParam("@S1price", 0)
                    If (item.Cells(chVAT1.Index).Value) Is Nothing Then SQL.AddParam("@S1vat", "") Else SQL.AddParam("@S1vat", item.Cells(chVAT1.Index).Value)
                    If (item.Cells(chVATInc1.Index).Value) Is Nothing Then SQL.AddParam("@S1vatInc", "") Else SQL.AddParam("@S1vatInc", item.Cells(chVATInc1.Index).Value)

                    ' SUPPLIER 2
                    If (item.Cells(chCode2.Index).Value) Is Nothing Then SQL.AddParam("@S2code", "") Else SQL.AddParam("@S2code", item.Cells(chCode2.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost2.Index).Value) Then SQL.AddParam("@S2price", CDec(item.Cells(chUnitCost2.Index).Value)) Else SQL.AddParam("@S2price", 0)
                    If (item.Cells(chVAT2.Index).Value) Is Nothing Then SQL.AddParam("@S2vat", "") Else SQL.AddParam("@S2vat", item.Cells(chVAT2.Index).Value)
                    If (item.Cells(chVATInc2.Index).Value) Is Nothing Then SQL.AddParam("@S2vatInc", "") Else SQL.AddParam("@S2vatInc", item.Cells(chVATInc2.Index).Value)

                    ' SUPPLIER 3
                    If (item.Cells(chCode3.Index).Value) Is Nothing Then SQL.AddParam("@S3code", "") Else SQL.AddParam("@S3code", item.Cells(chCode3.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost3.Index).Value) Then SQL.AddParam("@S3price", CDec(item.Cells(chUnitCost3.Index).Value)) Else SQL.AddParam("@S3price", 0)
                    If (item.Cells(chVAT3.Index).Value) Is Nothing Then SQL.AddParam("@S3vat", "") Else SQL.AddParam("@S3vat", item.Cells(chVAT3.Index).Value)
                    If (item.Cells(chVATInc3.Index).Value) Is Nothing Then SQL.AddParam("@S3vatInc", "") Else SQL.AddParam("@S3vatInc", item.Cells(chVATInc3.Index).Value)

                    ' SUPPLIER 4
                    If (item.Cells(chCode4.Index).Value) Is Nothing Then SQL.AddParam("@S4code", "") Else SQL.AddParam("@S4code", item.Cells(chCode4.Index).Value)
                    If IsNumeric(item.Cells(chUnitCost4.Index).Value) Then SQL.AddParam("@S4price", CDec(item.Cells(chUnitCost4.Index).Value)) Else SQL.AddParam("@S4price", 0)
                    If (item.Cells(chVAT4.Index).Value) Is Nothing Then SQL.AddParam("@S4vat", "") Else SQL.AddParam("@S4vat", item.Cells(chVAT4.Index).Value)
                    If (item.Cells(chVATInc4.Index).Value) Is Nothing Then SQL.AddParam("@S4vatInc", "") Else SQL.AddParam("@S4vatInc", item.Cells(chVATInc4.Index).Value)

                    If IsNothing(item.Cells(chApprovedSupplier.Index).Value) Then SQL.AddParam("@ApproveSP", "") Else SQL.AddParam("@ApproveSP", item.Cells(chApprovedSupplier.Index).Value)
                    If IsNumeric(item.Cells(dgcGross.Index).Value) Then SQL.AddParam("@GrossAmount", CDec(item.Cells(dgcGross.Index).Value)) Else SQL.AddParam("@GrossAmount", 0)
                    If IsNumeric(item.Cells(chVAT.Index).Value) Then SQL.AddParam("@VATAmount", CDec(item.Cells(chVAT.Index).Value)) Else SQL.AddParam("@VATAmount", 0)
                    If IsNumeric(item.Cells(chTotalPrice.Index).Value) Then SQL.AddParam("@TotalAmount", CDec(item.Cells(chTotalPrice.Index).Value)) Else SQL.AddParam("@TotalAmount", 0)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                End If
                line += 1
            Next
            updateSQL = "UPDATE tblPR SET Status ='Closed' WHERE TransID = '" & PR_ID & "' "
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "CF_No", CFNo, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub


    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("CF_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("CF")
            If f.transID <> "" Then
                TransID = f.transID
            End If
            LoadCF(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("CF_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblCF SET Status ='Cancelled' WHERE PR_No = @PR_No "
                        SQL.FlushParams()
                        CFNo = txtTransNum.Text
                        SQL.AddParam("@PR_No", CFNo)
                        SQL.ExecNonQuery(deleteSQL)
                        Msg("Record cancelled successfully", MsgBoxStyle.Information)

                        tsbSearch.Enabled = True
                        tsbNew.Enabled = True
                        tsbEdit.Enabled = False
                        tsbSave.Enabled = False
                        tsbCancel.Enabled = False
                        tsbClose.Enabled = False
                        tsbPrevious.Enabled = False
                        tsbNext.Enabled = False
                        tsbExit.Enabled = True
                        tsbPrint.Enabled = True
                        EnableControl(False)

                        CFNo = txtTransNum.Text
                        LoadPR(CFNo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "CF_No", CFNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If CFNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadCF(CFNo)
            tsbEdit.Enabled = True
            tsbCancel.Enabled = True
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbPrint.Enabled = True
        End If
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If CFNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 CF_No FROM tblCF  WHERE CF_No < '" & CFNo & "' ORDER BY CF_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                CFNo = SQL.SQLDR("CF_No").ToString
                LoadCF(CFNo)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If CFNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 CF_No FROM tblCF  WHERE CF_No > '" & CFNo & "' ORDER BY CF_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                CFNo = SQL.SQLDR("CF_No").ToString
                LoadCF(CFNo)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub frmPR_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.S Then
                If tsbSave.Enabled = True Then tsbSave.PerformClick()
            ElseIf e.KeyCode = Keys.F Then
                If tsbSearch.Enabled = True Then tsbSearch.PerformClick()
            ElseIf e.KeyCode = Keys.N Then
                If tsbNew.Enabled = True Then tsbNew.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                If tsbEdit.Enabled = True Then tsbEdit.PerformClick()
            ElseIf e.KeyCode = Keys.D Then
                If tsbCancel.Enabled = True Then tsbCancel.PerformClick()
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.P Then
                If tsbPrint.Enabled = True Then tsbPrint.PerformClick()
            ElseIf e.KeyCode = Keys.R Then
                If tsbReports.Enabled = True Then tsbReports.PerformClick()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbExit.Enabled = True Then
                    tsbExit.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.Shift = True Then
            If e.KeyCode = Keys.Escape Then
                If tsbClose.Enabled = True Then tsbClose.PerformClick()
            End If
        End If
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrint.Click
        Dim f As New frmReport_Display
        f.ShowDialog("PR", TransID)
        f.Dispose()
    End Sub

    Private Sub TestToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TestToolStripMenuItem1.Click
        Dim f As New frmReport_Filter
        f.Report = "PR List"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub cbPurchType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPurchType.SelectedIndexChanged
        If disableEvent = False Then
            If cbPurchType.SelectedIndex <> -1 Then
                If cbPurchType.SelectedItem = "Goods" Then
                    dgvList.Columns(chItemCode.Index).Visible = True
                    dgvList.Columns(chUOM.Index).Visible = True
                    dgvList.Columns(chQTY.Index).Visible = True
                Else
                    dgvList.Columns(chItemCode.Index).Visible = False
                    dgvList.Columns(chUOM.Index).Visible = False
                    dgvList.Columns(chQTY.Index).Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub cbPurchType_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbPurchType.KeyPress
        e.Handled = True
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        If dgvList.CurrentCell.ColumnIndex = chQTY.Index Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        Else
            RemoveHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If

    End Sub

    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If ControlChars.Back <> e.KeyChar Then
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub PRWithoutPOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PRWithoutPOToolStripMenuItem.Click
        Dim f As New frmReport_Display
        f.ShowDialog("PR_WithoutPO", "", "Summary")
        f.Dispose()
    End Sub


    Private Sub LoadPR(ByVal TransNum As String)
        Dim query As String
        query = " SELECT   TransID, PR_No, DatePR, VCECode, ISNULL(PurchaseType,'Goods') AS PurchaseType, Remarks, DateNeeded, RequestedBy, Status, AccntCode " & _
                " FROM     tblPR " & _
                " WHERE    TransID = '" & TransNum & "' " & _
                " ORDER BY TransID "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            PR_ID = SQL.SQLDR("TransID")
            txtPRNo.Text = SQL.SQLDR("PR_No").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = "Open"
            dtpDocDate.Text = SQL.SQLDR("DatePR").ToString
            cbDeliverTo.Text = SQL.SQLDR("RequestedBy").ToString

            query = " SELECT    ItemGroup, ItemCode, Description, UOM, QTY  " & _
                    " FROM      tblPR_Details " & _
                    " WHERE     tblPR_Details.TransID = '" & PR_ID & "' " & _
                    " ORDER BY  LineNum "
            dgvList.Rows.Clear()
            SQL.GetQuery(query)
            Dim ctr As Integer = 0
            Dim itemGroup, itemCode, desc, UOM As String
            Dim QTY As Decimal = 0
            Dim dt As New DataTable
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                dt = SQL.SQLDS.Tables(0)
            End If
            For Each row As DataRow In dt.Rows
                itemGroup = row.Item(0).ToString
                itemCode = row.Item(1).ToString
                desc = row.Item(2).ToString
                UOM = row.Item(3).ToString
                QTY = row.Item(4).ToString

                dgvList.Rows.Add(New String() {itemGroup, itemCode, desc, UOM, QTY})

                LoadLastSupplier(itemGroup, itemCode, chSupplier1.Index, ctr)
                LoadSupplier(itemGroup, itemCode, chSupplier2.Index, ctr)
                LoadSupplier(itemGroup, itemCode, chSupplier3.Index, ctr)
                LoadSupplier(itemGroup, itemCode, chSupplier4.Index, ctr)
                ctr += 1
            Next
            While SQL.SQLDR.Read

            End While
            ComputeTotal()

        Else
            ClearText()
        End If
    End Sub
    Dim eColIndex As Integer = 0
    Private Sub dgvList_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvList.CellBeginEdit
        eColIndex = e.ColumnIndex
    End Sub


    Private Sub dgvList_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellEndEdit
        Try
            Dim itemCode As String
            Dim rowIndex As Integer = dgvList.CurrentCell.RowIndex
            Dim colindex As Integer = dgvList.CurrentCell.ColumnIndex
            resetRow = True
            currentRow = e.RowIndex
            currentCell = e.ColumnIndex
            Select Case colindex

                Case chItemCode.Index
                    If dgvList.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvList.Item(chItemCode.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("ItemMaster", itemCode, "Selling")
                        If f.TransID <> "" Then
                            itemCode = f.ItemCode
                        End If
                        dgvList.Rows.RemoveAt(e.RowIndex)
                        f.Dispose()
                    End If
                Case chItemDesc.Index
                    If dgvList.Item(chItemDesc.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvList.Item(chItemDesc.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("ItemMaster", itemCode, "Selling")
                        If f.TransID <> "" Then
                            itemCode = f.ItemCode
                            dgvList.Rows.RemoveAt(e.RowIndex)
                        End If
                        f.Dispose()
                    End If
                Case chSupplier1.Index
                    LoadSupplierList(e.RowIndex, e.ColumnIndex)
                Case chSupplier2.Index
                    LoadSupplierList(e.RowIndex, e.ColumnIndex)
                Case chSupplier3.Index
                    LoadSupplierList(e.RowIndex, e.ColumnIndex)
                Case chSupplier4.Index
                    LoadSupplierList(e.RowIndex, e.ColumnIndex)
                Case chQTY.Index
                    If IsNumeric(dgvList.Item(chUnitCost1.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvList.Item(chQTY.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chUnitCost1.Index
                    If IsNumeric(dgvList.Item(e.ColumnIndex, e.RowIndex).Value) AndAlso IsNumeric(dgvList.Item(chQTY.Index, e.RowIndex).Value) Then
                        dgvList.Item(chUnitCost1.Index, e.RowIndex).Value = CDec(dgvList.Item(chUnitCost1.Index, e.RowIndex).Value).ToString("N2")
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chUnitCost2.Index
                    If IsNumeric(dgvList.Item(e.ColumnIndex, e.RowIndex).Value) AndAlso IsNumeric(dgvList.Item(chQTY.Index, e.RowIndex).Value) Then
                        dgvList.Item(chUnitCost2.Index, e.RowIndex).Value = CDec(dgvList.Item(chUnitCost2.Index, e.RowIndex).Value).ToString("N2")
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chUnitCost3.Index
                    If IsNumeric(dgvList.Item(e.ColumnIndex, e.RowIndex).Value) AndAlso IsNumeric(dgvList.Item(chQTY.Index, e.RowIndex).Value) Then
                        dgvList.Item(chUnitCost3.Index, e.RowIndex).Value = CDec(dgvList.Item(chUnitCost3.Index, e.RowIndex).Value).ToString("N2")
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chUnitCost4.Index
                    If IsNumeric(dgvList.Item(e.ColumnIndex, e.RowIndex).Value) AndAlso IsNumeric(dgvList.Item(chQTY.Index, e.RowIndex).Value) Then
                        dgvList.Item(chUnitCost4.Index, e.RowIndex).Value = CDec(dgvList.Item(chUnitCost4.Index, e.RowIndex).Value).ToString("N2")
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chApprovedSupplier.Index
                    'Make cells color white
                    For i As Integer = 0 To dgvList.ColumnCount - 1
                        dgvList.Rows(e.RowIndex).Cells(i).Style.BackColor = Color.White
                    Next
                    If dgvList.Item(chApprovedSupplier.Index, e.RowIndex).Value = "Supplier 1" Then
                        dgvList.Rows(e.RowIndex).Cells(chSupplier1.Index).Style.BackColor = Color.Yellow
                        dgvList.Rows(e.RowIndex).Cells(chUnitCost1.Index).Style.BackColor = Color.Yellow
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    ElseIf dgvList.Item(chApprovedSupplier.Index, e.RowIndex).Value = "Supplier 2" Then
                        dgvList.Rows(e.RowIndex).Cells(chSupplier2.Index).Style.BackColor = Color.Yellow
                        dgvList.Rows(e.RowIndex).Cells(chUnitCost2.Index).Style.BackColor = Color.Yellow
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    ElseIf dgvList.Item(chApprovedSupplier.Index, e.RowIndex).Value = "Supplier 3" Then
                        dgvList.Rows(e.RowIndex).Cells(chSupplier3.Index).Style.BackColor = Color.Yellow
                        dgvList.Rows(e.RowIndex).Cells(chUnitCost3.Index).Style.BackColor = Color.Yellow
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    ElseIf dgvList.Item(chApprovedSupplier.Index, e.RowIndex).Value = "Supplier 4" Then
                        dgvList.Rows(e.RowIndex).Cells(chSupplier4.Index).Style.BackColor = Color.Yellow
                        dgvList.Rows(e.RowIndex).Cells(chUnitCost4.Index).Style.BackColor = Color.Yellow
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
            End Select
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadSupplierList(Row As Integer, Column As Integer)
        If TypeOf (dgvList.Rows(Row).Cells(Column)) Is DataGridViewTextBoxCell Then
            If dgvList.Rows(Row).Cells(chCode1.Index).Value = Nothing Or Column = chSupplier1.Index Then supA = "" Else supA = dgvList.Rows(Row).Cells(chCode1.Index).Value
            If dgvList.Rows(Row).Cells(chCode2.Index).Value = Nothing Or Column = chSupplier2.Index Then supB = "" Else supB = dgvList.Rows(Row).Cells(chCode2.Index).Value
            If dgvList.Rows(Row).Cells(chCode3.Index).Value = Nothing Or Column = chSupplier3.Index Then supC = "" Else supC = dgvList.Rows(Row).Cells(chCode3.Index).Value
            If dgvList.Rows(Row).Cells(chCode4.Index).Value = Nothing Or Column = chSupplier4.Index Then supD = "" Else supD = dgvList.Rows(Row).Cells(chCode4.Index).Value
            ' IF NEW SUPPLIER, SEARCH FROM VENDOR MASTER
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.Type = "Vendor"
            f.ModFrom = "CF"
            f.txtFilter.Text = dgvList.Rows(Row).Cells(Column).Value
            f.ShowDialog()
            dgvList.Rows(Row).Cells(Column - 1).Value = f.VCECode
            dgvList.Rows(Row).Cells(Column).Value = f.VCEName
            If Not IsNothing(f.VCECode) AndAlso f.VCECode <> "" Then
                dgvList.Rows(Row).Cells(Column + 1).ReadOnly = False
            Else
                dgvList.Rows(Row).Cells(Column + 1).ReadOnly = True
            End If
            f.Dispose()
        ElseIf TypeOf (dgvList.Rows(Row).Cells(Column)) Is DataGridViewComboBoxCell Then
            If dgvList.Rows(Row).Cells(Column).Value = "New Supplier" Then
                Dim dtSupplier As New DataGridViewTextBoxCell
                dgvList.Rows(Row).Cells(Column) = dtSupplier
                dgvList.Rows(Row).Cells(Column - 1).Value = ""
                dgvList.Rows(Row).Cells(Column + 1).Value = 0
            Else
                dgvList.Rows(Row).Cells(Column - 1).Value = GetVCECode(dgvList.Rows(Row).Cells(Column).Value)
            End If
       
        End If
        LoadSupplierSelection(Row)
    End Sub

    Private Sub LoadSupplierSelection(Optional ByVal row As Integer = -1)
        Try
            Dim dgvCB As New DataGridViewComboBoxCell
            dgvCB = dgvList.Item(chApprovedSupplier.Index, row)
            Dim temp As String
            If dgvCB.Value = Nothing Then
                temp = ""
            Else
                temp = dgvCB.Value
            End If
            dgvCB.Value = Nothing
            ' ADD ALL WHSEc 
            dgvCB.Items.Clear()
            If Not IsNothing(dgvList.Rows(row).Cells(chCode1.Index).Value) AndAlso dgvList.Rows(row).Cells(chCode1.Index).Value <> "" Then dgvCB.Items.Add("Supplier 1")
            If Not IsNothing(dgvList.Rows(row).Cells(chCode2.Index).Value) AndAlso dgvList.Rows(row).Cells(chCode2.Index).Value <> "" Then dgvCB.Items.Add("Supplier 2")
            If Not IsNothing(dgvList.Rows(row).Cells(chCode3.Index).Value) AndAlso dgvList.Rows(row).Cells(chCode3.Index).Value <> "" Then dgvCB.Items.Add("Supplier 3")
            If Not IsNothing(dgvList.Rows(row).Cells(chCode4.Index).Value) AndAlso dgvList.Rows(row).Cells(chCode4.Index).Value <> "" Then dgvCB.Items.Add("Supplier 4")

            dgvCB.Value = temp
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadLastSupplier(Optional ByVal ItemGroup As String = "", Optional ByVal ItemCode As String = "", _
                                 Optional ByVal SelectedColumn As Integer = -1, Optional ByVal SelectedRow As Integer = -1)
        Try
            Dim dgvCB As New DataGridViewComboBoxCell
            dgvCB = dgvList.Item(SelectedColumn, SelectedRow)
            Dim temp As String
            If dgvCB.Value = Nothing Then
                temp = ""
            Else
                temp = dgvCB.Value
            End If

            dgvCB.Value = Nothing
            ' ADD ALL WHSEc 
            Dim query As String
            query = " SELECT     DISTINCT VCEName " & _
                    " FROM       tblItem_Master INNER JOIN tblPO_Details " & _
                    " ON         tblItem_Master.ItemCode = tblPO_Details.ItemCode " & _
                    " INNER JOIN tblPO " & _
                    " ON         tblPO_Details.TransID = tblPO.TransID " & _
                    " INNER JOIN tblVCE_Master " & _
                    " ON         tblVCE_Master.VCECode = tblPO.VCECode " & _
                    " WHERE      tblItem_Master.ItemCode = '" & ItemCode & "' OR tblPO_Details.ItemGroup = '" & ItemGroup & "' " & _
                    " ORDER BY   VCEName  "
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            If SQL.SQLDR.HasRows Then
                While SQL.SQLDR.Read
                    dgvCB.Items.Add(SQL.SQLDR("VCEName").ToString)
                End While
            Else
                Dim dtSupplier As New DataGridViewTextBoxCell
                dgvList.Rows(SelectedRow).Cells(SelectedColumn) = dtSupplier
                dgvList.Rows(SelectedRow).Cells(SelectedColumn - 1).Value = ""
                dgvList.Rows(SelectedRow).Cells(SelectedColumn + 1).Value = 0
                dgvList.Rows(SelectedRow).Cells(SelectedColumn + 1).ReadOnly = True
            End If
            dgvCB.Value = temp
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadSupplier(Optional ByVal ItemGroup As String = "", Optional ByVal ItemCode As String = "", _
                                 Optional ByVal SelectedColumn As Integer = -1, Optional ByVal SelectedRow As Integer = -1)
        Try
            If TypeOf (dgvList.Rows(SelectedRow).Cells(SelectedColumn)) Is DataGridViewComboBoxCell Then
                Dim dgvCB As New DataGridViewComboBoxCell
                dgvCB = dgvList.Item(SelectedColumn, SelectedRow)
                Dim temp As String
                If dgvCB.Value = Nothing Then
                    temp = ""
                Else
                    temp = dgvCB.Value
                End If

                dgvCB.Value = Nothing
                ' ADD ALL WHSEc 
                Dim query As String
                query = " SELECT DISTINCT VCEName " & _
                        " FROM " & _
                        " ( " & _
                        "       SELECT     DISTINCT VCEName " & _
                        "       FROM       tblItem_Master INNER JOIN tblPO_Details " & _
                        "       ON         tblItem_Master.ItemCode = tblPO_Details.ItemCode " & _
                        "       INNER JOIN tblPO " & _
                        "       ON         tblPO_Details.TransID = tblPO.TransID " & _
                        "       INNER JOIN tblVCE_Master " & _
                        "       ON         tblVCE_Master.VCECode = tblPO.VCECode " & _
                        "       WHERE      tblItem_Master.ItemCode = '" & ItemCode & "' OR tblPO_Details.ItemGroup = '" & ItemGroup & "' " & _
                        "    UNION ALL " & _
                        "       SELECT VCEName FROM tblVCE_Master WHERE VCECode IN (SELECT S1Code FROM tblCF_Details WHERE ItemCode = '" & ItemCode & "' OR ItemGroup = '" & ItemGroup & "') " & _
                        "    UNION ALL " & _
                        "       SELECT VCEName FROM tblVCE_Master WHERE VCECode IN (SELECT S2Code FROM tblCF_Details WHERE ItemCode = '" & ItemCode & "' OR ItemGroup = '" & ItemGroup & "')  " & _
                        "    UNION ALL " & _
                        "       SELECT VCEName FROM tblVCE_Master WHERE VCECode IN (SELECT S3Code FROM tblCF_Details WHERE ItemCode = '" & ItemCode & "' OR ItemGroup = '" & ItemGroup & "')  " & _
                        "    UNION ALL " & _
                        "       SELECT VCEName FROM tblVCE_Master WHERE VCECode IN (SELECT S4Code FROM tblCF_Details WHERE ItemCode = '" & ItemCode & "' OR ItemGroup = '" & ItemGroup & "')  " & _
                        " ) AS List  "
                SQL.ReadQuery(query)
                dgvCB.Items.Clear()
                If SQL.SQLDR.HasRows Then
                    While SQL.SQLDR.Read
                        dgvCB.Items.Add(SQL.SQLDR("VCEName").ToString)
                    End While
                Else
                    Dim dtSupplier As New DataGridViewTextBoxCell
                    dgvList.Rows(SelectedRow).Cells(SelectedColumn) = dtSupplier
                    dgvList.Rows(SelectedRow).Cells(SelectedColumn - 1).Value = ""
                    dgvList.Rows(SelectedRow).Cells(SelectedColumn + 1).Value = 0
                End If
                dgvCB.Value = temp
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvList_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvList.CurrentCellDirtyStateChanged
        If dgvList.SelectedCells.Count > 0 AndAlso dgvList.SelectedCells(0).ColumnIndex = chVAT1.Index Then
            If dgvList.SelectedCells(0).RowIndex <> -1 Then
                Recompute(dgvList.SelectedCells(0).RowIndex, dgvList.SelectedCells(0).ColumnIndex)
                dgvList.SelectedCells(0).Selected = False
                dgvList.EndEdit()
            End If
        ElseIf eColIndex = chSupplier1.Index And TypeOf (dgvList.CurrentRow.Cells(chSupplier1.Index)) Is DataGridViewComboBoxCell Then
            dgvList.EndEdit()
        ElseIf eColIndex = chSupplier2.Index And TypeOf (dgvList.CurrentRow.Cells(chSupplier2.Index)) Is DataGridViewComboBoxCell Then
            dgvList.EndEdit()
        ElseIf eColIndex = chSupplier3.Index And TypeOf (dgvList.CurrentRow.Cells(chSupplier3.Index)) Is DataGridViewComboBoxCell Then
            dgvList.EndEdit()
        ElseIf eColIndex = chSupplier4.Index And TypeOf (dgvList.CurrentRow.Cells(chSupplier4.Index)) Is DataGridViewComboBoxCell Then
            dgvList.EndEdit()
        ElseIf eColIndex = chApprovedSupplier.Index And TypeOf (dgvList.CurrentRow.Cells(chApprovedSupplier.Index)) Is DataGridViewComboBoxCell Then
            dgvList.EndEdit()
        End If

    End Sub

    Private Sub tsbCopyPR_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyPR.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("PR")
        LoadPR(f.transID)
        f.Dispose()
    End Sub

    Private Sub dgvList_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex = chSupplier1.Index AndAlso TypeOf (dgvList.Rows(e.RowIndex).Cells(e.ColumnIndex)) Is DataGridViewComboBoxCell Then
                If e.RowIndex <> -1 AndAlso dgvList.Rows.Count > 0 Then
                    LoadSupplier(dgvList.Item(dgcBOMgroup.Index, e.RowIndex).Value, dgvList.Item(chItemCode.Index, e.RowIndex).Value, e.ColumnIndex, e.RowIndex)
                    Dim dgvCol As DataGridViewComboBoxColumn
                    dgvCol = dgvList.Columns.Item(e.ColumnIndex)
                    dgvList.BeginEdit(True)
                    dgvCol.Selected = True
                    DirectCast(dgvList.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                    Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)

                End If
            End If
            If e.RowIndex >= 0 Then
                If Not IsNothing(dgvList.Item(chItemCode.Index, e.RowIndex).Value) AndAlso dgvList.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
                    lblItem.Text = dgvList.Item(chItemDesc.Index, e.RowIndex).Value
                Else
                    lblItem.Text = dgvList.Item(dgcBOMgroup.Index, e.RowIndex).Value
                End If
                rowId = e.RowIndex
                loadSupplierVAT(rowId)
            End If
        Catch ex As NullReferenceException
            If dgvList.ReadOnly = False Then
                SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
            End If
        End Try
    End Sub

    Private Sub loadSupplierVAT(ByVal RowIndex As String)
        dgvVATdetail.Rows.Clear()
        Dim VATable, VATinc As Boolean
        If RowIndex >= 0 Then
            ' SUPPLIER 1
            If dgvList.Rows(RowIndex).Cells(chCode1.Index).Value <> "" Then
                VATable = dgvList.Rows(RowIndex).Cells(chVAT1.Index).Value
                VATinc = dgvList.Rows(RowIndex).Cells(chVATInc1.Index).Value
                dgvVATdetail.Rows.Add("Supplier 1", VATable, VATinc)
            End If

            ' SUPPLIER 2
            If dgvList.Rows(RowIndex).Cells(chCode2.Index).Value <> "" Then
                VATable = dgvList.Rows(RowIndex).Cells(chVAT2.Index).Value
                VATinc = dgvList.Rows(RowIndex).Cells(chVATInc2.Index).Value
                dgvVATdetail.Rows.Add("Supplier 2", VATable, VATinc)
            End If

            ' SUPPLIER 3
            If dgvList.Rows(RowIndex).Cells(chCode3.Index).Value <> "" Then
                VATable = dgvList.Rows(RowIndex).Cells(chVAT3.Index).Value
                VATinc = dgvList.Rows(RowIndex).Cells(chVATInc3.Index).Value
                dgvVATdetail.Rows.Add("Supplier 3", VATable, VATinc)
            End If

            ' SUPPLIER 4
            If dgvList.Rows(RowIndex).Cells(chCode4.Index).Value <> "" Then
                VATable = dgvList.Rows(RowIndex).Cells(chVAT4.Index).Value
                VATinc = dgvList.Rows(RowIndex).Cells(chVATInc4.Index).Value
                dgvVATdetail.Rows.Add("Supplier 4", VATable, VATinc)
            End If
        End If
    End Sub

    Private Sub dgvList_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvList.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim numCols As Integer = dgvList.ColumnCount
            Dim numRows As Integer = dgvList.RowCount
            Dim nextCol As Integer
            Dim currCell As DataGridViewCell = dgvList.CurrentCell
            nextCol = currCell.ColumnIndex
            If currCell.ColumnIndex = numCols - 1 Then
                If currCell.RowIndex < numRows - 1 Then
                    dgvList.CurrentCell = dgvList.Item(0, currCell.RowIndex + 1)
                End If
            Else
                Do While dgvList.Item(nextCol + 1, currCell.RowIndex).Visible = False
                    nextCol += 1
                Loop
                dgvList.CurrentCell = dgvList.Item(nextCol + 1, currCell.RowIndex)

            End If
            e.Handled = True
        End If
    End Sub
    Dim resetRow As Boolean = False
    Dim currentRow As Int32
    Dim currentCell As Int32

    Private Sub dgvList_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvList.SelectionChanged
        Dim nextCol As Integer
        nextCol = currentCell
        If resetRow Then
            resetRow = False
            If dgvList.CurrentCell.ColumnIndex = dgvList.Columns.Count - 1 Then
                dgvList.CurrentCell = dgvList.Item(0, currentRow + 1)
            Else
                Do While dgvList.Item(nextCol + 1, currentRow).Visible = False
                    nextCol += 1
                Loop
                dgvList.CurrentCell = dgvList.Item(nextCol + 1, currentRow)
            End If
        End If
    End Sub

    Private Sub dgvList_CellValidating(sender As System.Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvList.CellValidating
        If e.ColumnIndex = chUnitCost1.Index Or e.ColumnIndex = chUnitCost2.Index Or e.ColumnIndex = chUnitCost3.Index Or e.ColumnIndex = chUnitCost4.Index Then
            Dim dc As Decimal
            If e.FormattedValue.ToString <> String.Empty AndAlso Not Decimal.TryParse(e.FormattedValue.ToString, dc) Then
                Msg("Invalid Amount!", vbExclamation)
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub dgvList_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        Try

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvVATdetail_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgvVATdetail.CurrentCellDirtyStateChanged
        Dim rowInd As Integer = -1
        If dgvVATdetail.SelectedCells.Count > 0 AndAlso (dgvVATdetail.SelectedCells(0).ColumnIndex = dgcVAT.Index OrElse dgvVATdetail.SelectedCells(0).ColumnIndex = dgcVATInc.Index) Then
            If dgvVATdetail.SelectedCells(0).RowIndex <> -1 Then
                rowInd = dgvVATdetail.SelectedCells(0).RowIndex
                If dgvVATdetail.SelectedCells(0).ColumnIndex = dgcVAT.Index Then
                    If dgvVATdetail.Item(dgcVAT.Index, rowInd).Value = True Then
                        dgvVATdetail.Item(dgcVAT.Index, rowInd).Value = False
                    Else
                        dgvVATdetail.Item(dgcVAT.Index, rowInd).Value = True
                    End If
                ElseIf dgvVATdetail.SelectedCells(0).ColumnIndex = dgcVATInc.Index Then
                    If dgvVATdetail.Item(dgcVATInc.Index, rowInd).Value = True Then
                        dgvVATdetail.Item(dgcVATInc.Index, rowInd).Value = False
                    Else
                        dgvVATdetail.Item(dgcVATInc.Index, rowInd).Value = True
                    End If
                End If

                ' CHANGE VAT & VATINCH CHECKBOX VALUE IN DGVLIST 
                If dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcSupplier.Index).Value = "Supplier 1" Then
                    dgvList.Rows(rowId).Cells(chVAT1.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVAT.Index).Value
                    dgvList.Rows(rowId).Cells(chVATInc1.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVATInc.Index).Value
                ElseIf dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcSupplier.Index).Value = "Supplier 2" Then
                    dgvList.Rows(rowId).Cells(chVAT2.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVAT.Index).Value
                    dgvList.Rows(rowId).Cells(chVATInc2.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVATInc.Index).Value
                ElseIf dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcSupplier.Index).Value = "Supplier 3" Then
                    dgvList.Rows(rowId).Cells(chVAT3.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVAT.Index).Value
                    dgvList.Rows(rowId).Cells(chVATInc3.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVATInc.Index).Value
                ElseIf dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcSupplier.Index).Value = "Supplier 4" Then
                    dgvList.Rows(rowId).Cells(chVAT4.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVAT.Index).Value
                    dgvList.Rows(rowId).Cells(chVATInc4.Index).Value = dgvVATdetail.Rows(dgvVATdetail.SelectedCells(0).RowIndex).Cells(dgcVATInc.Index).Value
                End If
                Recompute(rowId, chItemCode.Index)
                dgvVATdetail.SelectedCells(0).Selected = False
                dgvVATdetail.EndEdit()
            End If
        End If
    End Sub

   
End Class