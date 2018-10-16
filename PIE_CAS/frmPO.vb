Public Class frmPO
    Dim TransID As String
    Dim PONo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "PO"
    Dim ColumnPK As String = "PO_No"
    Dim DBTable As String = "tblPO"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim CF_ID, PR_ID As Integer
    Dim PO_App As Boolean = False

    Public Overloads Function ShowDialog(ByVal docnumber As String) As Boolean
        PONo = docnumber
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadSetup()
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            dtpDelivery.Value = Date.Today.Date
            dgvItemList.Font = New Font("Microsoft Sans Serif", 8)
            If PONo <> "" Then
                LoadPO(PONo)
            End If

            LoadCostCenter()
            LoadChartOfAccount()
            LoadTerms()

            tsbSearch.Enabled = True
            tsbNew.Enabled = True
            tsbEdit.Enabled = False
            tsbSave.Enabled = False
            tsbCancel.Enabled = False
            tsbApprove.Enabled = False
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


    Private Sub LoadSetup()
        Dim query As String
        query = " SELECT  ISNULL(PO_Approval,0) AS PO_Approval  FROM tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            PO_App = SQL.SQLDR("PO_Approval")
        End If
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCEName.Enabled = Value
        btnSearchVCE.Enabled = Value
        dgvItemList.AllowUserToAddRows = Value
        dgvItemList.AllowUserToDeleteRows = Value
        If Value = True Then
            dgvItemList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvItemList.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        cbCostCenter.Enabled = Value
        cbPurchaseType.Enabled = Value
        cbGLAccount.Enabled = Value
        cbTerms.Enabled = Value
        cbDeliverTo.Enabled = Value
        txtRemarks.Enabled = Value
        txtDiscountRate.Enabled = Value
        btnApplyRate.Enabled = Value
        dtpDocDate.Enabled = Value
        dtpDelivery.Enabled = Value
        chkVAT.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadTerms()
        Dim query As String
        query = " SELECT  DISTINCT Terms " & _
                " FROM    tblVCE_Master " & _
                " ORDER BY Terms "
        SQL.ReadQuery(query)
        cbTerms.Items.Clear()
        While SQL.SQLDR.Read
            cbTerms.Items.Add(SQL.SQLDR("Terms"))
        End While
    End Sub

    Private Sub LoadChartOfAccount()
        Dim query As String
        query = " SELECT  AccountCode, AccountTitle " & _
                " FROM    tblCOA_Master " & _
                " WHERE   AccountNature = 'Debit' " & _
                " ORDER BY AccountTitle "
        SQL.ReadQuery(query)
        cbGLAccount.Items.Clear()
        While SQL.SQLDR.Read
            cbGLAccount.Items.Add(SQL.SQLDR("AccountTitle"))
        End While
    End Sub

    Private Sub LoadPO(ByVal ID As String)
        Dim query, CC As String
        query = " SELECT   tblPO.TransID, tblPO.PO_No, VCECode, PurchaseType, DatePO, DateDeliver, Remarks, CostCenter, " & _
                "          GrossAmount, Discount, VATAmount, NetAmount, VATable, ISNULL(VATInclusive,'True') AS VATInclusive, " & _
                "          viewPO_Status.Status, AccntCode, DeliverTo, PR_Ref, CF_Ref, Terms " & _
                " FROM     tblPO INNER JOIN viewPO_Status " & _
                " ON       tblPO.TransID = viewPO_Status.TransID " & _
                " WHERE    tblPO.TransID = '" & ID & "' " & _
                " ORDER BY TransID "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            PONo = SQL.SQLDR("PO_No").ToString
            txtTransNum.Text = PONo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            If IsDBNull(SQL.SQLDR("PurchaseType")) Then
                cbPurchaseType.SelectedIndex = -1
            Else
                cbPurchaseType.SelectedItem = SQL.SQLDR("PurchaseType").ToString
            End If
            If IsDBNull(SQL.SQLDR("Terms")) Then
                cbTerms.SelectedIndex = -1
            Else
                cbTerms.SelectedItem = SQL.SQLDR("Terms").ToString
            End If
            CC = SQL.SQLDR("CostCenter").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            dtpDocDate.Text = SQL.SQLDR("DatePO").ToString
            dtpDelivery.Text = SQL.SQLDR("DateDeliver").ToString
            txtGross.Text = SQL.SQLDR("GrossAmount").ToString
            txtDiscount.Text = SQL.SQLDR("Discount").ToString
            txtVAT.Text = SQL.SQLDR("VATAmount").ToString
            txtNet.Text = SQL.SQLDR("NetAmount").ToString
            cbDeliverTo.Text = SQL.SQLDR("DeliverTo").ToString
            Dim code As String = SQL.SQLDR("AccntCode").ToString
            chkVAT.Checked = SQL.SQLDR("VATable")
            chkVATInc.Checked = SQL.SQLDR("VATInclusive")
            PR_ID = SQL.SQLDR("PR_Ref").ToString
            CF_ID = SQL.SQLDR("CF_Ref").ToString
            cbCostCenter.SelectedItem = GetCCName(CC)
            txtPRNo.Text = LoadPRNo(PR_ID)
            txtCFNo.Text = LoadCFNo(CF_ID)
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            cbGLAccount.Text = GetAccntTitle(code)
            LoadVCE_Info(txtVCECode.Text)
            LoadPODetails(TransID)
            ComputeTotal()

            ' TOOLSTRIP BUTTONS
            If txtStatus.Text = "Cancelled" Then
                tsbEdit.Enabled = False
                tsbCancel.Enabled = False
                tsbApprove.Enabled = False
            ElseIf txtStatus.Text = "Closed" Then
                tsbEdit.Enabled = False
                tsbCancel.Enabled = False
                tsbApprove.Enabled = False
            ElseIf txtStatus.Text = "For Approval" Then
                tsbEdit.Enabled = True
                tsbCancel.Enabled = True
                tsbApprove.Enabled = True
            Else
                tsbEdit.Enabled = False
                tsbCancel.Enabled = True
                tsbApprove.Enabled = False
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
            tsbCopy.Enabled = False
            EnableControl(False)
        Else
            ClearText()
        End If
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

    Private Function LoadCFNo(ID As Integer) As String
        Dim query As String
        query = " SELECT CF_No FROM tblCF WHERE TransID = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("CF_No")
        Else
            Return ""
        End If
    End Function

    Protected Sub LoadPODetails(ByVal TransID As String)
        Dim query As String
        query = " SELECT    ItemGroup, ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, VATAmount, DiscountRate, Discount, NetAmount, VATable, VATInc, WHSE " & _
                " FROM      tblPO_Details " & _
                " WHERE     tblPO_Details.TransId = " & TransID & " " & _
                " ORDER BY  LineNum "
        disableEvent = True
        dgvItemList.Rows.Clear()
        disableEvent = False
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            dgvItemList.Rows.Add(SQL.SQLDR("ItemGroup").ToString, SQL.SQLDR("ItemCode").ToString, SQL.SQLDR("Description").ToString, _
                                   SQL.SQLDR("UOM").ToString, SQL.SQLDR("QTY").ToString, CDec(SQL.SQLDR("UnitPrice")).ToString("N2"), _
                                   CDec(SQL.SQLDR("GrossAmount")).ToString("N2"), _
                                   CDec(SQL.SQLDR("VATAmount")).ToString("N2"), _
                                   CDec(SQL.SQLDR("DiscountRate")).ToString("N2"), _
                                   CDec(SQL.SQLDR("Discount")).ToString("N2"), _
                                   CDec(SQL.SQLDR("NetAmount")).ToString("N2"), _
                                   SQL.SQLDR("VATable").ToString, SQL.SQLDR("VATInc").ToString, SQL.SQLDR("WHSE").ToString)
        End While
    End Sub

    Private Sub ClearText()
        txtTransNum.Text = ""
        txtVCECode.Text = ""
        txtVCEName.Text = ""
        dgvItemList.Rows.Clear()
        cbDeliverTo.Text = ""
        cbPurchaseType.SelectedItem = "Goods"
        cbTerms.SelectedItem = -1
        cbGLAccount.SelectedIndex = -1
        txtRemarks.Text = ""
        txtGross.Text = "0.00"
        txtNet.Text = "0.00"
        txtDiscount.Text = "0.00"
        txtVAT.Text = "0.00"
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        dtpDelivery.Value = Date.Today.Date
        txtPRNo.Clear()

        LoadChartOfAccount()
        LoadTerms()
    End Sub

    Private Sub dgvProducts_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellEndEdit
        Try
            Dim itemCode As String
            Dim rowIndex As Integer = dgvItemList.CurrentCell.RowIndex
            Dim colindex As Integer = dgvItemList.CurrentCell.ColumnIndex
            Select Case colindex
                Case chItemCode.Index
                    If dgvItemList.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemList.Item(chItemCode.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("ItemListPO", itemCode, "Purchase")
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItem(itemCode)
                        Else
                            dgvItemList.Rows.RemoveAt(e.RowIndex)
                        End If
                        f.Dispose()
                    End If
                Case chItemDesc.Index
                    If dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("ItemListPO", itemCode, "Purchase")
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItem(itemCode)
                        End If
                        dgvItemList.Rows.RemoveAt(e.RowIndex)
                        f.Dispose()
                    End If
                Case chQTY.Index
                    If dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = "" OrElse IsNothing(dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    ElseIf IsNumeric(dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chQTY.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chUnitPrice.Index
                    If dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = "" OrElse IsNothing(dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    ElseIf IsNumeric(dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chQTY.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                        dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value = CDec(dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value).ToString("N2")
                    End If
                Case chDiscountRate.Index
                    If IsNumeric(dgvItemList.Item(chGross.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chDiscountRate.Index, e.RowIndex).Value) Then
                        txtDiscountRate.Text = ""
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chDiscount.Index
                    dgvItemList.Item(chDiscountRate.Index, e.RowIndex).Value = Nothing
                    If IsNumeric(dgvItemList.Item(chGross.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chDiscount.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chUnitPrice.Index
                    If IsNumeric(dgvItemList.Item(chGross.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chDiscount.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
            End Select
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub Recompute(ByVal RowID As Integer, ByVal ColID As Integer)
        Dim gross, VAT, discount, net, baseVAT As Decimal
        If RowID <> -1 Then
            If IsNumeric(dgvItemList.Item(chGross.Index, RowID).Value) Then
                ' GET GROSS AMOUNT (VAT INCLUSIVE)
                gross = CDec(dgvItemList.Item(chUnitPrice.Index, RowID).Value) * CDec(dgvItemList.Item(chQTY.Index, RowID).Value)
                baseVAT = gross
                ' COMPUTE VAT IF VATABLE
                If ColID = chVAT.Index Then
                    If dgvItemList.Item(chVAT.Index, RowID).Value = True Then
                        dgvItemList.Item(chVAT.Index, RowID).Value = False

                        dgvItemList.Item(chVATinc.Index, RowID).Value = False
                        VAT = 0
                        dgvItemList.Item(chVATinc.Index, RowID).ReadOnly = True
                    Else
                        dgvItemList.Item(chVAT.Index, RowID).Value = True

                        dgvItemList.Item(chVATinc.Index, RowID).ReadOnly = False
                        If dgvItemList.Item(chVATinc.Index, RowID).Value = False Then
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        Else
                            baseVAT = (gross / 1.12)
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        End If

                    End If
                ElseIf ColID = chVATinc.Index Then
                    If dgvItemList.Item(chVAT.Index, RowID).Value = False Then
                        VAT = 0
                    Else
                        If dgvItemList.Item(chVATinc.Index, RowID).Value = True Then
                            dgvItemList.Item(chVATinc.Index, RowID).Value = False
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        Else
                            dgvItemList.Item(chVATinc.Index, RowID).Value = True
                            baseVAT = (gross / 1.12)
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        End If

                    End If
                Else
                    If dgvItemList.Item(chVAT.Index, RowID).Value = False Then
                        VAT = 0
                        dgvItemList.Item(chVATinc.Index, RowID).ReadOnly = True
                    Else
                        dgvItemList.Item(chVATinc.Index, RowID).ReadOnly = False
                        If dgvItemList.Item(chVATinc.Index, RowID).Value = True Then ' IF VAT INCLUSIVE, BASE AMOUNT WILL BE GROSS / 1.12
                            baseVAT = (gross / 1.12)
                        End If
                        VAT = CDec(baseVAT * 0.12).ToString("N2")
                    End If
                End If


                ' COMPUTE DISCOUNT
                If IsNumeric(dgvItemList.Item(chDiscountRate.Index, RowID).Value) Then
                    discount = CDec(baseVAT * (CDec(dgvItemList.Item(chDiscountRate.Index, RowID).Value) / 100.0)).ToString("N2")
                ElseIf IsNumeric(dgvItemList.Item(chDiscount.Index, RowID).Value) Then
                    discount = CDec(dgvItemList.Item(chDiscount.Index, RowID).Value)
                Else
                    discount = 0
                End If

                net = baseVAT - discount + VAT
                dgvItemList.Item(chGross.Index, RowID).Value = Format(gross, "#,###,###,###.00").ToString()
                dgvItemList.Item(chDiscount.Index, RowID).Value = Format(discount, "#,###,###,###.00").ToString()
                dgvItemList.Item(chVATAmt.Index, RowID).Value = Format(VAT, "#,###,###,###.00").ToString()
                dgvItemList.Item(chNetAmount.Index, RowID).Value = Format(net, "#,###,###,###.00").ToString()
                ComputeTotal()
            End If
        End If

    End Sub

    Public Sub LoadItem(ByVal ItemCode As String, Optional UOM As String = "", Optional QTY As Integer = 1)
        Try
            Dim query As String
            Dim VAT As Boolean
            Dim Price, VATAmt As Decimal
            query = " SELECT  ItemCode,  ItemName, PD_UOM,  " & _
                    "         CASE WHEN VATable = 1 " & _
                    "              THEN (CASE WHEN PD_VATinc = 1 THEN PD_UnitCost ELSE PD_UnitCost*1.12 END)  " & _
                    "              ELSE PD_UnitCost " & _
                    "         END AS Net_Price, WHSE, VATable " & _
                    " FROM    viewItem_Cost " & _
                    " WHERE   ItemCode = @ItemCode "
            SQL.FlushParams()
            SQL.AddParam("@ItemCode", ItemCode)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                If UOM = "" Then
                    UOM = SQL.SQLDR("PD_UOM").ToString
                End If
                VAT = SQL.SQLDR("VATable").ToString
                Price = SQL.SQLDR("Net_Price")
                If VAT = True Then
                    VATAmt = (Price / 1.12) * 0.12
                Else
                    VATAmt = 0
                End If
                dgvItemList.Rows.Add(New String() {SQL.SQLDR("ItemCode").ToString, _
                                              SQL.SQLDR("ItemName").ToString, _
                                             UOM, _
                                              QTY, _
                                              Format(Price, "#,###,###,###.00").ToString, _
                                              Format(Price * QTY, "#,###,###,###.00").ToString, _
                                              Format(VATAmt * QTY, "#,###,###,###.00").ToString, _
                                              "0.00", _
                                              Format((Price) * QTY, "#,###,###,###.00").ToString, _
                                              SQL.SQLDR("VATable").ToString, _
                                              SQL.SQLDR("WHSE").ToString})

            End If

            ComputeTotal()

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub ComputeTotal()
        Dim b As Decimal = 0
        Dim a As Decimal = 0
        Dim c As Decimal = 0
        Dim d As Decimal = 0
        ' COMPUTE GROSS
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chGross.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chGross.Index, i).Value) Then
                    a = a + Double.Parse(dgvItemList.Item(chGross.Index, i).Value).ToString
                End If
            End If
        Next
        txtGross.Text = a.ToString("N2")

        ' COMPUTE DISCOUNT
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chDiscount.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chDiscount.Index, i).Value) Then
                    b = b + Double.Parse(dgvItemList.Item(chDiscount.Index, i).Value)
                End If
            End If
        Next
        txtDiscount.Text = b.ToString("N2")


        ' COMPUTE VAT
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chVATAmt.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chVATAmt.Index, i).Value) Then
                    c = c + Double.Parse(dgvItemList.Item(chVATAmt.Index, i).Value).ToString
                End If
            End If
        Next
        txtVAT.Text = c.ToString("N2")

        ' COMPUTE NET
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chNetAmount.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chNetAmount.Index, i).Value) Then
                    d = d + Double.Parse(dgvItemList.Item(chNetAmount.Index, i).Value).ToString
                End If
            End If
        Next
        txtNet.Text = d.ToString("N2")
    End Sub

    Private Sub dgvItemMaster_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvItemList.RowsRemoved
        If disableEvent = False Then
            ComputeTotal()
        End If
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("PO_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("PO")
            If f.transID <> "" Then
                TransID = f.transID
            End If

            LoadPO(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("PO_ADD") Then
            msgRestricted()
        Else
            ' CLEAR TRANSACTION RECORDS
            ClearText()
            TransID = ""
            PONo = ""

            ' SET REFERENCE ID TO 0
            CF_ID = 0
            PR_ID = 0

            ' LOAD MAINTENANCE VALUES
            LoadCostCenter()
            LoadChartOfAccount()
            LoadTerms()

            ' SET TOOLSTRIP BUTTONS
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbCancel.Enabled = False
            tsbApprove.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
            tsbPrint.Enabled = False
            tsbCopy.Enabled = True
            EnableControl(True)

            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub

    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.Type = "Vendor"
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        LoadVCE_Info(f.VCECode)
        f.Dispose()
    End Sub

    Private Sub LoadVCE_Info(ByVal VCECode As String)
        Dim query As String
        query = " SELECT    VCECode, VCEName, TIN_No, Address, ContactNo, Contact_Person, Terms " & _
                " FROM      ViewVCE_Details " & _
                " WHERE     VCECode ='" & VCECode & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtTIN.Text = SQL.SQLDR("TIN_No").ToString
            txtAddress.Text = SQL.SQLDR("Address").ToString
            txtContact.Text = SQL.SQLDR("ContactNo").ToString
            txtPerson.Text = SQL.SQLDR("Contact_Person").ToString
            cbTerms.SelectedItem = SQL.SQLDR("Terms").ToString
        End If
    End Sub

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.Type = "Vendor"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            LoadVCE_Info(f.VCECode)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("PO_EDIT") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbCancel.Enabled = False
            tsbApprove.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
            tsbPrint.Enabled = False
            tsbCopy.Enabled = False
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        ' VALIDATE DATA INPUTS
        If DataValidated() Then
            If TransID = "" Then
                If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    TransID = GenerateTransID(ColumnPK, DBTable)
                    PONo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                    txtTransNum.Text = PONo
                    SavePO()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    PONo = txtTransNum.Text
                    LoadPO(PONo)
                End If
            Else
                If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdatePO()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    PONo = txtTransNum.Text
                    LoadPO(PONo)
                End If
            End If
        End If
    End Sub

    Private Function DataValidated() As Boolean
        If txtVCECode.Text = "" Then
            Msg("Please enter VCECode!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf cbPurchaseType.SelectedItem <> "Goods" AndAlso cbGLAccount.SelectedIndex = -1 Then
            Msg("Please select default GL Account", MsgBoxStyle.Exclamation)
            Return False
        ElseIf dgvItemList.Rows.Count <= 1 Then
            Msg("There are no items on the list!", MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("PO_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblPO SET Status ='Cancelled' WHERE PO_No = @PO_No "
                        SQL.FlushParams()
                        PONo = txtTransNum.Text
                        SQL.AddParam("@PO_No", PONo)
                        SQL.ExecNonQuery(deleteSQL)
                        Msg("Record cancelled successfully", MsgBoxStyle.Information)

                        tsbSearch.Enabled = True
                        tsbNew.Enabled = True
                        tsbEdit.Enabled = False
                        tsbSave.Enabled = False
                        tsbCancel.Enabled = False
                        tsbApprove.Enabled = False
                        tsbClose.Enabled = False
                        tsbPrevious.Enabled = False
                        tsbNext.Enabled = False
                        tsbExit.Enabled = True
                        tsbPrint.Enabled = True
                        tsbCopy.Enabled = False
                        EnableControl(False)

                        PONo = txtTransNum.Text
                        LoadPO(PONo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "PO_No", PONo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub SavePO()
        Try
            If cbGLAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbGLAccount.SelectedItem)
            End If
            Dim CC As String = ""
            If cbCostCenter.SelectedIndex <> -1 Then
                CC = GetCCCode(cbCostCenter.SelectedItem)
            End If
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblPO(TransID, PO_No, BranchCode, BusinessCode, DatePO, VCECode, PurchaseType, DateDeliver, Terms, Remarks, " & _
                        "           CostCenter, GrossAmount, Discount, VATAmount, NetAmount, VATable, VATInclusive, PR_Ref, CF_Ref, " & _
                        "           AccntCode, DeliverTo, WhoCreated, Status) " & _
                        " VALUES (@TransID, @PO_No, @BranchCode, @BusinessCode, @DatePO,  @VCECode, @PurchaseType, @DateDeliver, @Terms, @Remarks, " & _
                        "           @CostCenter, @GrossAmount, @Discount, @VATAmount, @NetAmount, @Vatable, @VATInclusive, @PR_Ref, @CF_Ref, " & _
                        "           @AccntCode, @DeliverTo, @WhoCreated, @Status) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@PO_No", PONo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DatePO", dtpDocDate.Value.Date)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@CostCenter", CC)
            SQL.AddParam("@Terms", IIf(cbTerms.SelectedIndex = -1, DBNull.Value, cbTerms.SelectedItem))
            SQL.AddParam("@PurchaseType", IIf(cbPurchaseType.SelectedIndex = -1, DBNull.Value, cbPurchaseType.SelectedItem))
            SQL.AddParam("@DateDeliver", dtpDelivery.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@GrossAmount", CDec(txtGross.Text))
            SQL.AddParam("@Discount", CDec(txtDiscount.Text))
            SQL.AddParam("@VATAmount", CDec(txtVAT.Text))
            SQL.AddParam("@NetAmount", CDec(txtNet.Text))
            SQL.AddParam("@VATable", chkVAT.Checked)
            SQL.AddParam("@VATInclusive", chkVATInc.Checked)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@DeliverTo", cbDeliverTo.Text)
            SQL.AddParam("@PR_Ref", PR_ID)
            SQL.AddParam("@CF_Ref", CF_ID)
            SQL.AddParam("@WhoCreated", UserID)
            If PO_App = True Then SQL.AddParam("@Status", "For Approval") Else SQL.AddParam("@Status", "Active")
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            Dim WHSE As String
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(chNetAmount.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    WHSE = GetWHSECode(row.Cells(chWHSE.Index).Value.ToString)

                    ' INSERT QUERY
                    insertSQL = " INSERT INTO " & _
                                " tblPO_Details(TransId, ItemGroup, ItemCode, Description, UOM, QTY, UnitPrice, " & _
                                "               GrossAmount, VATAmount, DiscountRate, Discount, NetAmount, VATable, VATinc, WHSE, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @ItemGroup, @ItemCode, @Description, @UOM, @QTY, @UnitPrice, " & _
                                "          @GrossAmount, @VATAmount, @DiscountRate, @Discount, @NetAmount, @VATable, @VATinc, @WHSE, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    If cbPurchaseType.SelectedItem = "Goods" Then
                        SQL.AddParam("@ItemGroup", row.Cells(chItemGroup.Index).Value)
                        SQL.AddParam("@ItemCode", row.Cells(chItemCode.Index).Value)
                        SQL.AddParam("@UOM", row.Cells(chUOM.Index).Value)
                        If IsNumeric(row.Cells(chUnitPrice.Index).Value) Then
                            SQL.AddParam("@UnitPrice", CDec(row.Cells(chUnitPrice.Index).Value))
                        Else
                            SQL.AddParam("@UnitPrice", 0)
                        End If
                    Else
                        SQL.AddParam("@ItemGroup", "")
                        SQL.AddParam("@ItemCode", "")
                        SQL.AddParam("@UOM", "")
                        If IsNumeric(row.Cells(chGross.Index).Value) Then
                            SQL.AddParam("@UnitCost", CDec(row.Cells(chGross.Index).Value))
                        Else
                            SQL.AddParam("@UnitCost", 0)
                        End If
                    End If
                    SQL.AddParam("@Description", row.Cells(chItemDesc.Index).Value.ToString)
                    SQL.AddParam("@QTY", CDec(row.Cells(chQTY.Index).Value))
                    If IsNumeric(row.Cells(chGross.Index).Value) Then SQL.AddParam("@GrossAmount", CDec(row.Cells(chGross.Index).Value)) Else SQL.AddParam("@GrossAmount", 0)
                    If IsNumeric(row.Cells(chDiscountRate.Index).Value) Then SQL.AddParam("@DiscountRate", CDec(row.Cells(chDiscountRate.Index).Value)) Else SQL.AddParam("@DiscountRate", 0)
                    If IsNumeric(row.Cells(chDiscount.Index).Value) Then SQL.AddParam("@Discount", CDec(row.Cells(chDiscount.Index).Value)) Else SQL.AddParam("@Discount", 0)
                    If IsNumeric(row.Cells(chVATAmt.Index).Value) Then SQL.AddParam("@VATAmount", CDec(row.Cells(chVATAmt.Index).Value)) Else SQL.AddParam("@VATAmount", 0)
                    If IsNumeric(row.Cells(chNetAmount.Index).Value) Then SQL.AddParam("@NetAmount", CDec(row.Cells(chNetAmount.Index).Value)) Else SQL.AddParam("@NetAmount", 0)
                    If IsNothing(row.Cells(chVAT.Index).Value) Then SQL.AddParam("@VATable", False) Else SQL.AddParam("@VATable", row.Cells(chVAT.Index).Value)
                    If IsNothing(row.Cells(chVATinc.Index).Value) Then SQL.AddParam("@VATinc", False) Else SQL.AddParam("@VATinc", row.Cells(chVATinc.Index).Value)
                    SQL.AddParam("@WHSE", WHSE)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next

            UpdatePR(PR_ID)  ' UPDATE PR STATUS
            UpdateCF(CF_ID, txtVCECode.Text)  ' UPDATE CF DETAILS STATUS
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "PO_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdatePR(ByVal ID As Integer)
        If ID <> 0 Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblPR SET Status = 'Closed'  WHERE TransID = '" & ID & "' "
            SQL.ExecNonQuery(updateSQL)
        End If
    End Sub

    Private Sub UpdateCF(ByVal ID As Integer, ByVal Code As String)
        If ID <> 0 Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblCF_Details SET Status = 'Closed'  " & _
                        " WHERE TransID = '" & ID & "' " & _
                        " AND     (CASE WHEN ApproveSP = 'Supplier 1' THEN S1code " & _
                        "              WHEN ApproveSP = 'Supplier 2' THEN S2code " & _
                        "              WHEN ApproveSP = 'Supplier 3' THEN S3code " & _
                        "              WHEN ApproveSP = 'Supplier 4' THEN S4code " & _
                        "         END)  ='" & Code & "' "
            SQL.ExecNonQuery(updateSQL)
        End If
    End Sub

    Private Sub UpdatePO()
        Try
            activityStatus = True
            If cbGLAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbGLAccount.SelectedItem)
            End If
            Dim CC As String = ""
            If cbCostCenter.SelectedIndex <> -1 Then
                CC = GetCCCode(cbCostCenter.SelectedItem)
            End If
            ' UPDATE PR HEADER
            Dim updateSQL, deleteSQL, insertSQL As String
            updateSQL = " UPDATE tblPO " & _
                        " SET    PO_No = @PO_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, DatePO = @DatePO, Terms = @Terms, " & _
                        "        VCECode = @VCECode, PurchaseType = @PurchaseType, DateDeliver = @DateDeliver, Remarks = @Remarks, CostCenter = @CostCenter, " & _
                        "        GrossAmount = @GrossAmount, Discount = @Discount, VATAmount = @VATAmount, NetAmount = @NetAmount, " & _
                        "        VATable = @VATable, VATInclusive = @VATInclusive, AccntCode = @AccntCode, DeliverTo = @DeliverTo, " & _
                        "        PR_Ref = @PR_Ref, CF_Ref = @CF_Ref, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@PO_No", PONo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DatePO", dtpDocDate.Value.Date)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@CostCenter", CC)
            SQL.AddParam("@Terms", IIf(cbTerms.SelectedIndex = -1, DBNull.Value, cbTerms.SelectedItem))
            SQL.AddParam("@PurchaseType", IIf(cbPurchaseType.SelectedIndex = -1, DBNull.Value, cbPurchaseType.SelectedItem))
            SQL.AddParam("@DateDeliver", dtpDelivery.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@GrossAmount", CDec(txtGross.Text))
            SQL.AddParam("@Discount", CDec(txtDiscount.Text))
            SQL.AddParam("@VATAmount", CDec(txtVAT.Text))
            SQL.AddParam("@NetAmount", CDec(txtNet.Text))
            SQL.AddParam("@VATable", chkVAT.Checked)
            SQL.AddParam("@VATInclusive", chkVATInc.Checked)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@DeliverTo", cbDeliverTo.Text)
            SQL.AddParam("@PR_Ref", PR_ID)
            SQL.AddParam("@CF_Ref", CF_ID)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)


            ' DELETE PR DETAILS
            deleteSQL = " DELETE FROM tblPO_Details WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            ' INSERT PR DETAILS
            Dim line As Integer = 1
            Dim WHSE As String
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(chNetAmount.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    WHSE = GetWHSECode(row.Cells(chWHSE.Index).Value.ToString)

                    ' INSERT QUERY
                    insertSQL = " INSERT INTO " & _
                                " tblPO_Details(TransId, ItemGroup, ItemCode, Description, UOM, QTY, UnitCost, " & _
                                "               GrossAmount, VATAmount, DiscountRate, Discount, NetAmount, VATable, VATinc, WHSE, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @ItemGroup, @ItemCode, @Description, @UOM, @QTY, @UnitCost, " & _
                                "          @GrossAmount, @VATAmount, @DiscountRate, @Discount, @NetAmount, @VATable, @VATinc, @WHSE, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    If cbPurchaseType.SelectedItem = "Goods" Then
                        SQL.AddParam("@ItemGroup", row.Cells(chItemGroup.Index).Value)
                        SQL.AddParam("@ItemCode", row.Cells(chItemCode.Index).Value)
                        SQL.AddParam("@UOM", row.Cells(chUOM.Index).Value)
                        If IsNumeric(row.Cells(chUnitPrice.Index).Value) Then
                            SQL.AddParam("@UnitCost", CDec(row.Cells(chUnitPrice.Index).Value))
                        Else
                            SQL.AddParam("@UnitCost", 0)
                        End If
                    Else
                        SQL.AddParam("@ItemGroup", "")
                        SQL.AddParam("@ItemCode", "")
                        SQL.AddParam("@UOM", "")
                        If IsNumeric(row.Cells(chGross.Index).Value) Then
                            SQL.AddParam("@UnitCost", CDec(row.Cells(chGross.Index).Value))
                        Else
                            SQL.AddParam("@UnitCost", 0)
                        End If
                    End If
                    SQL.AddParam("@Description", row.Cells(chItemDesc.Index).Value.ToString)
                    SQL.AddParam("@QTY", CDec(row.Cells(chQTY.Index).Value))
                    If IsNumeric(row.Cells(chGross.Index).Value) Then SQL.AddParam("@GrossAmount", CDec(row.Cells(chGross.Index).Value)) Else SQL.AddParam("@GrossAmount", 0)
                    If IsNumeric(row.Cells(chDiscountRate.Index).Value) Then SQL.AddParam("@DiscountRate", CDec(row.Cells(chDiscountRate.Index).Value)) Else SQL.AddParam("@DiscountRate", 0)
                    If IsNumeric(row.Cells(chDiscount.Index).Value) Then SQL.AddParam("@Discount", CDec(row.Cells(chDiscount.Index).Value)) Else SQL.AddParam("@Discount", 0)
                    If IsNumeric(row.Cells(chVATAmt.Index).Value) Then SQL.AddParam("@VATAmount", CDec(row.Cells(chVATAmt.Index).Value)) Else SQL.AddParam("@VATAmount", 0)
                    If IsNumeric(row.Cells(chNetAmount.Index).Value) Then SQL.AddParam("@NetAmount", CDec(row.Cells(chNetAmount.Index).Value)) Else SQL.AddParam("@NetAmount", 0)
                    If IsNothing(row.Cells(chVAT.Index).Value) Then SQL.AddParam("@VATable", False) Else SQL.AddParam("@VATable", row.Cells(chVAT.Index).Value)
                    If IsNothing(row.Cells(chVATinc.Index).Value) Then SQL.AddParam("@VATinc", False) Else SQL.AddParam("@VATinc", row.Cells(chVATinc.Index).Value)
                    SQL.AddParam("@WHSE", WHSE)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "PO_No", PONo, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrint.Click
        Dim f As New frmReport_Display
        f.ShowDialog("PO", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If PONo <> "" Then
            Dim query As String
            query = " SELECT Top 1 PO_No FROM tblPO  WHERE PO_No < '" & PONo & "' ORDER BY PO_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                PONo = SQL.SQLDR("PO_No").ToString
                LoadPO(PONo)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If PONo <> "" Then
            Dim query As String
            query = " SELECT Top 1 PO_No FROM tblPO  WHERE PO_No > '" & PONo & "' ORDER BY PO_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                PONo = SQL.SQLDR("PO_No").ToString
                LoadPO(PONo)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If PONo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbApprove.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadPO(PONo)
            tsbEdit.Enabled = True
            tsbCancel.Enabled = True
            tsbApprove.Enabled = True
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbPrint.Enabled = True
        End If
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
        tsbCopy.Enabled = False
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
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
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            cbPurchaseType.SelectedItem = SQL.SQLDR("PurchaseType").ToString
            txtStatus.Text = "Open"
            dtpDocDate.Text = SQL.SQLDR("DatePR").ToString
            cbDeliverTo.Text = SQL.SQLDR("RequestedBy").ToString
            cbGLAccount.SelectedItem = GetAccntTitle(SQL.SQLDR("AccntCode").ToString)
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            query = " SELECT    ItemCode, Description, UOM, QTY  " & _
                    " FROM      tblPR_Details " & _
                    " WHERE     tblPR_Details.TransID = '" & PR_ID & "' " & _
                    " ORDER BY  LineNum "
            dgvItemList.Rows.Clear()
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                    LoadItem(row.Item(0), row.Item(2), row.Item(3))
                Next
            End If

        Else
            ClearText()
        End If
    End Sub

    Private Sub LoadCostCenter()
        Dim query As String
        query = " SELECT Description FROM tblCC "
        SQL.ReadQuery(query)
        cbCostCenter.Items.Clear()
        While SQL.SQLDR.Read
            cbCostCenter.Items.Add(SQL.SQLDR("Description").ToString)
        End While
    End Sub

    Private Sub LoadCF(ByVal TransNum As String, ByVal SupplierCode As String)
        Dim query As String
        query = " SELECT   tblCF.TransID, CF_No, PurchaseType, CostCenter, Requestedby, tblCF.Remarks,  tblCF.Status  " & _
                " FROM     tblCF " & _
                " WHERE     TransID = @TransID  "
        SQL.FlushParams()
        SQL.AddParam("@TransID", TransNum)
        SQL.ReadQuery(query)
        SQL.FlushParams()
        If SQL.SQLDR.Read Then
            CF_ID = SQL.SQLDR("TransID")
            txtCFNo.Text = SQL.SQLDR("CF_No").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            cbPurchaseType.SelectedItem = SQL.SQLDR("PurchaseType").ToString
            txtStatus.Text = "Open"
            cbDeliverTo.Text = SQL.SQLDR("RequestedBy").ToString
            cbCostCenter.SelectedItem = GetCCName(SQL.SQLDR("CostCenter").ToString)
            query = " SELECT TransID, ItemGroup, ItemCode, Description, UOM, QTY, SupplierCode, UnitPrice, VAT, VATInc, GrossAmount, VATAmount, TotalAmount " & _
                    " FROM " & _
                    " ( " & _
                    "   SELECT    TransID, ItemGroup, ItemCode, Description, UOM, QTY, " & _
                    "           CASE WHEN ApproveSP ='Supplier 1' THEN S1code " & _
                    "                           WHEN ApproveSP ='Supplier 2' THEN S2code " & _
                    "                           WHEN ApproveSP ='Supplier 3' THEN S3code " & _
                    "                           WHEN ApproveSP ='Supplier 4' THEN S4code " & _
                    "                      END AS SupplierCode, " & _
                    "               CASE WHEN ApproveSP ='Supplier 1' THEN S1price " & _
                    "                           WHEN ApproveSP ='Supplier 2' THEN S2price " & _
                    "                           WHEN ApproveSP ='Supplier 3' THEN S3price " & _
                    "                           WHEN ApproveSP ='Supplier 4' THEN S4price " & _
                    "               END AS UnitPrice, " & _
                    "               CASE WHEN ApproveSP ='Supplier 1' THEN S1vat " & _
                    "                           WHEN ApproveSP ='Supplier 2' THEN S2vat " & _
                    "                           WHEN ApproveSP ='Supplier 3' THEN S3vat " & _
                    "                           WHEN ApproveSP ='Supplier 4' THEN S4vat " & _
                    "               END AS VAT, " & _
                    "               CASE WHEN ApproveSP ='Supplier 1' THEN S1vatInc " & _
                    "                           WHEN ApproveSP ='Supplier 2' THEN S2vatInc " & _
                    "                           WHEN ApproveSP ='Supplier 3' THEN S3vatInc " & _
                    "                           WHEN ApproveSP ='Supplier 4' THEN S4vatInc " & _
                    "               END AS VATInc, GrossAmount, VATAmount, TotalAmount " & _
                    "   FROM tblCF_Details " & _
                    " ) AS CFdetails " & _
                    " LEFT JOIN tblVCE_Master " & _
                    " ON        tblVCE_Master.VCECode = CFdetails.SupplierCode " & _
                    " WHERE     CFdetails.TransID = @TransID AND SupplierCode = @SupplierCode AND Status ='Active' "
            dgvItemList.Rows.Clear()
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransNum)
            SQL.AddParam("@SupplierCode", SupplierCode)
            SQL.ReadQuery(query)
            While SQL.SQLDR.Read
                dgvItemList.Rows.Add(New String() {SQL.SQLDR("ItemGroup").ToString, SQL.SQLDR("ItemCode").ToString, _
                                                            SQL.SQLDR("Description").ToString, SQL.SQLDR("UOM").ToString, SQL.SQLDR("QTY").ToString, _
                                                             CDec(SQL.SQLDR("UnitPrice")).ToString("N2"), CDec(SQL.SQLDR("GrossAmount")).ToString("N2"), "0", ".00", _
                                                            CDec(SQL.SQLDR("VATAmount")).ToString("N2"), CDec(SQL.SQLDR("TotalAmount")).ToString("N2"), SQL.SQLDR("VAT").ToString, _
                                                            SQL.SQLDR("VATInc").ToString, ""})
            End While
            SQL.FlushParams()
            ComputeTotal()
        Else
            ClearText()
        End If
    End Sub

    Private Sub frmPO_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
            ElseIf e.KeyCode = Keys.P Then
                If tsbPrint.Enabled = True Then tsbPrint.PerformClick()
            ElseIf e.KeyCode = Keys.R Then
                If tsbReports.Enabled = True Then tsbReports.PerformClick()
            ElseIf e.KeyCode = Keys.C Then
                If tsbReports.Enabled = True Then tsbCopy.ShowDropDown()
            ElseIf e.KeyCode = Keys.A Then
                If tsbApprove.Enabled = True Then tsbApprove.PerformClick()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbExit.Enabled = True Then
                    tsbExit.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
        End If
    End Sub

    Private Sub TestToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TestToolStripMenuItem1.Click
        Dim f As New frmReport_Filter
        f.Report = "PO List"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub cbPurchaseType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPurchaseType.SelectedIndexChanged
        If disableEvent = False Then
            If cbPurchaseType.SelectedIndex <> -1 Then
                If cbPurchaseType.SelectedItem = "Goods" Then
                    dgvItemList.Columns(chItemCode.Index).Visible = True
                    dgvItemList.Columns(chUOM.Index).Visible = True
                    dgvItemList.Columns(chUnitPrice.Index).Visible = True
                    dgvItemList.Columns(chQTY.Index).Visible = True
                    lblGL.Visible = False
                    cbGLAccount.Visible = False
                Else
                    dgvItemList.Columns(chItemCode.Index).Visible = False
                    dgvItemList.Columns(chUOM.Index).Visible = False
                    dgvItemList.Columns(chUnitPrice.Index).Visible = False
                    dgvItemList.Columns(chQTY.Index).Visible = False
                    lblGL.Visible = False
                    cbGLAccount.Visible = False
                End If
            End If
        End If
    End Sub

    Private Control As Boolean = False

    Private Sub cb_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbGLAccount.KeyDown, cbPurchaseType.KeyDown
        Control = False
        If e.KeyCode = Keys.ControlKey Then
            Control = True
        End If
    End Sub

    Private Sub cbGLAccount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbGLAccount.KeyPress, cbPurchaseType.KeyPress
        If Control = True Then
            e.Handled = True
        End If
    End Sub

    Private Sub chkVAT_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVAT.CheckedChanged
        For Each row As DataGridViewRow In dgvItemList.Rows
            If Not row.Cells(chGross.Index).Value Is Nothing Then
                If chkVAT.CheckState = CheckState.Checked Then
                    row.Cells(chVAT.Index).Value = True
                Else
                    row.Cells(chVAT.Index).Value = False
                End If
            End If
          

            Recompute(row.Index, chQTY.Index)
        Next
        ComputeTotal()
    End Sub

    Private Sub PRWithoutPOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PRWithoutPOToolStripMenuItem.Click
        Dim f As New frmReport_Display
        f.ShowDialog("PO_Unserved", "", "Summary")
        f.Dispose()
    End Sub

    Private Sub tsbApprove_Click(sender As System.Object, e As System.EventArgs) Handles tsbApprove.Click
        If txtTransNum.Text <> "" Then
            If MsgBox("Are you sure you want to approve this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                Try
                    activityStatus = True
                    Dim updateSQL As String
                    updateSQL = " UPDATE  tblPO SET Status ='Active' WHERE PO_No = @PO_No "
                    SQL.FlushParams()
                    PONo = txtTransNum.Text
                    SQL.AddParam("@PO_No", PONo)
                    SQL.ExecNonQuery(updateSQL)
                    Msg("Record Approved successfully", MsgBoxStyle.Information)

                    tsbSearch.Enabled = True
                    tsbNew.Enabled = True
                    tsbEdit.Enabled = False
                    tsbSave.Enabled = False
                    tsbCancel.Enabled = False
                    tsbApprove.Enabled = False
                    tsbClose.Enabled = False
                    tsbPrevious.Enabled = False
                    tsbNext.Enabled = False
                    tsbExit.Enabled = True
                    tsbPrint.Enabled = True
                    tsbCopy.Enabled = False
                    EnableControl(False)

                    PONo = txtTransNum.Text
                    LoadPO(PONo)
                Catch ex As Exception
                    activityStatus = True
                    SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                Finally
                    RecordActivity(UserID, ModuleID, Me.Name.ToString, "APPROVE", "PO_No", PONo, BusinessType, BranchCode, "", activityStatus)
                    SQL.FlushParams()
                End Try
            End If
        End If
    End Sub

    Private Sub tsbCopyCF_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyCF.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("Sub CF")
        LoadCF(f.transID, f.itemCode)
        LoadVCE_Info(f.itemCode)
        f.Dispose()
    End Sub

    Private Sub dgvItemList_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgvItemList.CurrentCellDirtyStateChanged
          If dgvItemList.SelectedCells.Count > 0 AndAlso (dgvItemList.SelectedCells(0).ColumnIndex = chVAT.Index OrElse dgvItemList.SelectedCells(0).ColumnIndex = chVATInc.Index) Then
            If dgvItemList.SelectedCells(0).RowIndex <> -1 Then
                Recompute(dgvItemList.SelectedCells(0).RowIndex, dgvItemList.SelectedCells(0).ColumnIndex)
                dgvItemList.SelectedCells(0).Selected = False
                dgvItemList.EndEdit()
            End If
        End If
    End Sub

    Private Sub btnApplyRate_Click(sender As System.Object, e As System.EventArgs) Handles btnApplyRate.Click
        If IsNumeric(txtDiscount.Text) Then
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not IsNothing(row.Cells(chItemCode.Index).Value) Then
                    row.Cells(chDiscountRate.Index).Value = txtDiscountRate.Text
                    Recompute(row.Index, chDiscountRate.Index)
                End If
            Next
        End If
    End Sub
End Class
