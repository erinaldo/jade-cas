Public Class frmBOM
    Dim TransID, RefID As String
    Dim BOMNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "BOM"
    Dim ColumnPK As String = "BOM_No"
    Dim DBTable As String = "tblBOM"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim JO_ID As Integer

    Public Overloads Function ShowDialog(ByVal DocID As String) As Boolean
        TransID = DocID
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmSO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            If TransID <> "" Then
                LoadBOM(TransID)
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
            txtVCEName.Focus()
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
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
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadBOM(ByVal ID As String)
        Dim BomCode As String
        Dim query As String
        query = " SELECT     TransID, BOM_No, VCECode, DateBOM, ItemCode, Description, QTY, LotSize, BOMCode, Remarks, JO_Ref, " & _
                "            Status " & _
                " FROM       tblBOM " & _
                " WHERE      TransId = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            BOMNo = SQL.SQLDR("BOM_No").ToString
            txtTransNum.Text = BOMNo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            dtpDocDate.Text = SQL.SQLDR("DateBOM").ToString
            txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
            txtDescription.Text = SQL.SQLDR("Description").ToString
            txtQTY.Text = SQL.SQLDR("QTY").ToString
            txtLotSize.Text = SQL.SQLDR("LotSize").ToString
            BomCode = SQL.SQLDR("BOMCode").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            JO_ID = SQL.SQLDR("JO_Ref").ToString
            txtJORef.Text = LoadJONo(JO_ID)
            LoadBOMType(txtItemCode.Text)
            cbBOM.SelectedItem = BomCode
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            LoadBOMDetails(TransID)
            'ComputeTotal()

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
            tsbCopy.Enabled = False
            EnableControl(False)
        Else
            ClearText()
        End If

    End Sub

    Private Function LoadJONo(JOID As Integer) As String
        Dim query As String
        query = " SELECT JO_No FROM tblJO WHERE TransID = '" & JOID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("JO_No")
        Else
            Return 0
        End If
    End Function

    Protected Sub LoadBOMDetails(ByVal TransID As String)
        Dim query As String
        query = " SELECT    TransID, ItemGroup, ItemCode, Description, UOM, QTY_Per_BOM, GrossQTY, UnitCost, TotalCost " & _
                " FROM      tblBOM_Details " & _
                " WHERE     tblBOM_Details.TransId = " & TransID & " " & _
                " ORDER BY  LineNum "
        dgvItemList.Rows.Clear()
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            dgvItemList.Rows.Add(SQL.SQLDR("ItemGroup").ToString, _
                                 SQL.SQLDR("ItemCode").ToString, _
                                 SQL.SQLDR("Description").ToString, _
                                 SQL.SQLDR("UOM").ToString, _
                                 SQL.SQLDR("QTY_Per_BOM").ToString, _
                                 CDec(SQL.SQLDR("GrossQTY")).ToString("N2"), _
                                 CDec(SQL.SQLDR("UnitCost")).ToString("N2"), _
                                 CDec(SQL.SQLDR("TotalCost")).ToString("N2"))
        End While
    End Sub

    Private Sub LoadJO(ByVal ID As String)
        Dim query As String
        query = " SELECT    TransID, JO_No, DateJO, VCECode, ItemCode, Description, UOM, QTY, Remarks, DateNeeded, ProdLine, SO_Ref, SO_Ref_LineNum, Status " & _
                 " FROM       tblJO " & _
                 " WHERE      TransId = '" & ID & "' "
        SQL.FlushParams()
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            JO_ID = SQL.SQLDR("TransID").ToString
            txtJORef.Text = SQL.SQLDR("JO_No").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
            txtDescription.Text = SQL.SQLDR("Description").ToString
            txtUOM.Text = SQL.SQLDR("UOM").ToString
            txtQTY.Text = SQL.SQLDR("QTY").ToString
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            LoadBOMType(txtItemCode.Text)

        Else
            ClearText()
        End If
    End Sub

    Private Sub LoadBOMType(ByVal ItemCode As String)
        Dim query As String
        query = " SELECT BOM_Code FROm tblBOM_Maintenance_Header WHERE ItemCode ='" & ItemCode & "' "
        SQL.ReadQuery(query)
        cbBOM.Items.Clear()
        While SQL.SQLDR.Read
            cbBOM.Items.Add(SQL.SQLDR("BOM_Code").ToString)
        End While
    End Sub


    Public Function GetItemName(ByVal ItemCode As String) As String
        Dim query As String
        query = " SELECT ItemName FROM tblItem_Master WHERE ItemCode ='" & ItemCode & "'"
        SQL.ReadQuery(query, 2)
        If SQL.SQLDR2.Read Then
            Return SQL.SQLDR2("ItemName").ToString
        Else
            Return ""
        End If
    End Function

    Private Sub ClearText()
        txtTransNum.Text = ""
        txtVCECode.Text = ""
        txtVCEName.Text = ""
        dgvItemList.Rows.Clear()
        txtRemarks.Text = ""
        txtGross.Text = "0.00"
        txtVAT.Text = "0.00"
        txtDiscount.Text = "0.00"
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Are you sure you want to cancel Purchase Order No. " & txtTransNum.Text & "? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblBOM_No SET Status ='Cancelled' WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", txtTransNum.Text)
            SQL.ExecNonQuery(updateSQL)
            MsgBox("BOM No. " & txtTransNum.Text & " has been cancelled", MsgBoxStyle.Information)
        End If
    End Sub

    Public Function GetTransID() As Integer
        Dim query As String
        query = " SELECT MAX(TransID) + 1 AS TransID FROM tblBOM_Header"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read() And Not IsDBNull(SQL.SQLDR("TransID")) Then
            Return SQL.SQLDR("TransID")
        Else
            Return 1
        End If
    End Function

    Private Sub DisableColumn()
        dgvItemList.Columns("Column6").ReadOnly = True
        dgvItemList.Columns("Column7").ReadOnly = True
    End Sub

    Private Sub dgvProducts_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Try
        '    Dim itemCode As String
        '    Dim rowIndex As Integer = dgvItemList.CurrentCell.RowIndex
        '    Dim colindex As Integer = dgvItemList.CurrentCell.ColumnIndex
        '    Select Case colindex
        '        Case chItemCode.Index
        '            If dgvItemList.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
        '                itemCode = dgvItemList.Item(chItemCode.Index, e.RowIndex).Value
        '                Dim f As New frmCopyFrom
        '                f.ShowDialog("ItemListSO", itemCode, "Selling")
        '                If f.TransID <> "" Then
        '                    itemCode = f.TransID
        '                    LoadItem(itemCode)
        '                Else
        '                    dgvItemList.Rows.RemoveAt(e.RowIndex)
        '                End If
        '                f.Dispose()
        '            End If
        '        Case chItemDesc.Index
        '            If dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value <> "" Then
        '                itemCode = dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value
        '                Dim f As New frmCopyFrom
        '                f.ShowDialog("ItemListSO", itemCode, "Selling")
        '                If f.TransID <> "" Then
        '                    itemCode = f.TransID
        '                    LoadItem(itemCode)
        '                End If
        '                dgvItemList.Rows.RemoveAt(e.RowIndex)
        '                f.Dispose()
        '            End If
        '        Case chQTY.Index
        '            If IsNumeric(dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chQTY.Index, e.RowIndex).Value) Then
        '                Recompute(e.RowIndex, e.ColumnIndex)
        '                ComputeTotal()
        '            End If
        '        Case chDiscountRate.Index
        '            If IsNumeric(dgvItemList.Item(chGross.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chDiscountRate.Index, e.RowIndex).Value) Then
        '                Recompute(e.RowIndex, e.ColumnIndex)
        '                ComputeTotal()
        '            End If
        '        Case chDiscount.Index
        '            If IsNumeric(dgvItemList.Item(chGross.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chDiscount.Index, e.RowIndex).Value) Then
        '                Recompute(e.RowIndex, e.ColumnIndex)
        '                ComputeTotal()
        '            End If
        '    End Select
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub Recompute(ByVal RowID As Integer, ByVal ColID As Integer)
        'Dim gross, VAT, discount, net As Decimal
        'If RowID <> -1 Then
        '    If IsNumeric(dgvItemList.Item(chGross.Index, RowID).Value) Then
        '        ' GET GROSS AMOUNT (VAT INCLUSIVE)
        '        gross = CDec(dgvItemList.Item(chUnitPrice.Index, RowID).Value) * CDec(dgvItemList.Item(chQTY.Index, RowID).Value)

        '        ' COMPUTE VAT IF VATABLE
        '        If ColID = chVAT.Index Then
        '            If chkVATInc.Checked = True AndAlso dgvItemList.Item(chVAT.Index, RowID).Value = True Then
        '                dgvItemList.Item(chVAT.Index, RowID).Value = False
        '                VAT = 0
        '            Else
        '                dgvItemList.Item(chVAT.Index, RowID).Value = True
        '                VAT = CDec(gross * 0.12).ToString("N2")
        '            End If
        '        Else
        '            If chkVATInc.Checked = True AndAlso dgvItemList.Item(chVAT.Index, RowID).Value = True Then
        '                VAT = CDec(gross * 0.12).ToString("N2")
        '            Else
        '                VAT = 0
        '            End If
        '        End If


        '        ' COMPUTE DISCOUNT
        '        If IsNumeric(dgvItemList.Item(chDiscountRate.Index, RowID).Value) Then
        '            discount = CDec((gross - VAT) * (CDec(dgvItemList.Item(chDiscountRate.Index, RowID).Value) / 100.0)).ToString("N2")
        '        ElseIf IsNumeric(dgvItemList.Item(chDiscount.Index, RowID).Value) Then
        '            discount = CDec(dgvItemList.Item(chDiscount.Index, RowID).Value)
        '        Else
        '            discount = 0
        '        End If
        '        net = gross - discount + VAT
        '        dgvItemList.Item(chGross.Index, RowID).Value = Format(gross, "#,###,###,###.00").ToString()
        '        dgvItemList.Item(chDiscount.Index, RowID).Value = Format(discount, "#,###,###,###.00").ToString()
        '        dgvItemList.Item(chVATAmount.Index, RowID).Value = Format(VAT, "#,###,###,###.00").ToString()
        '        dgvItemList.Item(chNetAmount.Index, RowID).Value = Format(net, "#,###,###,###.00").ToString()
        '        ComputeTotal()
        '    End If
        'End If

    End Sub

    Public Sub LoadItem(ByVal ID As String)
        Dim query As String
        query = " SELECT  ItemCode, ItemName, PD_UOM  " & _
                " FROM    tblItem_Master " & _
                " WHERE   ItemCode ='" & ID & "'"
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            dgvItemList.Rows.Add(New String() {"", _
                                               "", _
                                               "", _
                                 SQL.SQLDR("ItemCode").ToString, _
                                               SQL.SQLDR("ItemName").ToString})

        End While
    End Sub

    Private Sub SaveBOM()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                                " tblBOM  (TransID, BOM_No, VCECode, DateBOM,  ItemCode, Description, QTY, UOM, LotSize, BOMCode, JO_Ref, Remarks, WhoCreated) " & _
                                " VALUES (@TransID, @BOM_No, @VCECode, @DateBOM,  @ItemCode, @Description, @QTY,  @UOM, @LotSize, @BOMCode, @JO_Ref, @Remarks, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@BOM_No", BOMNo)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateBOM", dtpDocDate.Value.Date)
            SQL.AddParam("@ItemCode", txtItemCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@UOM", txtUOM.Text)
            If IsNumeric(txtQTY.Text) Then
                SQL.AddParam("@QTY", CDec(txtQTY.Text))
            Else
                SQL.AddParam("@QTY", 0)
            End If
            If IsNumeric(txtLotSize.Text) Then
                SQL.AddParam("@LotSize", CDec(txtLotSize.Text))
            Else
                SQL.AddParam("@LotSize", 0)
            End If
            SQL.AddParam("@BOMCode", cbBOM.Text)
            SQL.AddParam("@JO_Ref", JO_ID)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(dgcBOM_ItemCode.Index).Value Is Nothing AndAlso Not row.Cells(dgcQTY_Per_BOM.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblBOM_Details(TransId, ItemGroup, ItemCode, Description, QTY_Per_BOM, UOM, GrossQTY, UnitCost, TotalCost, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @ItemGroup, @ItemCode, @Description, @QTY_Per_BOM, @UOM, @GrossQTY, @UnitCost, @TotalCost, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemGroup", row.Cells(dgcBOMgroup.Index).Value.ToString)
                    SQL.AddParam("@ItemCode", row.Cells(dgcBOM_ItemCode.Index).Value)
                    SQL.AddParam("@Description", row.Cells(dgcBOM_ItemDesc.Index).Value.ToString)
                    SQL.AddParam("@QTY_Per_BOM", row.Cells(dgcQTY_Per_BOM.Index).Value.ToString)
                    SQL.AddParam("@UOM", row.Cells(dgcUOM.Index).Value.ToString)
                    SQL.AddParam("@GrossQTY", row.Cells(dgcPR.Index).Value.ToString)
                    SQL.AddParam("@UnitCost", row.Cells(dgcUC.Index).Value.ToString)
                    SQL.AddParam("@TotalCost", row.Cells(dgcTC.Index).Value.ToString)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
            Dim updateSQL As String
            updateSQL = " UPDATE tblJO SET Status ='Closed' WHERE TransID = '" & JO_ID & "' "
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "BOM_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdateBOM()
        Try
            activityStatus = True
            Dim insertSQL, updateSQL As String
            updateSQL = " UPDATE tblBOM " & _
                         " SET    BOM_No = @BOM_No, VCECode = @VCECode, DateBOM = @DateBOM,  ItemCode = @ItemCode, Description = @Description, " & _
                         "        QTY = @QTY, LotSize = @LotSize, BOMCode = @BOMCode, Remarks = @Remarks, JO_Ref = @JO_Ref, " & _
                          "        DateModified = GETDATE(), WhoModified = @WhoModified " & _
                          " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@BOM_No", BOMNo)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateBOM", dtpDocDate.Value.Date)
            SQL.AddParam("@ItemCode", txtItemCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            If IsNumeric(txtQTY.Text) Then
                SQL.AddParam("@QTY", CDec(txtQTY.Text))
            Else
                SQL.AddParam("@QTY", 0)
            End If
            If IsNumeric(txtLotSize.Text) Then
                SQL.AddParam("@LotSize", CDec(txtLotSize.Text))
            Else
                SQL.AddParam("@LotSize", 0)
            End If
            SQL.AddParam("@BOMCode", cbBOM.Text)
            SQL.AddParam("@JO_Ref", JO_ID)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            Dim deleteSQL As String
            deleteSQL = " DELETE FROM tblBOM_Details WHERE TransID = '" & TransID & "' "
            SQL.ExecNonQuery(deleteSQL)

             Dim line As Integer = 1
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(dgcBOM_ItemCode.Index).Value Is Nothing AndAlso Not row.Cells(dgcQTY_Per_BOM.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                  " tblBOM_Details(TransId, ItemGroup, ItemCode, Description, QTY_Per_BOM, UOM, GrossQTY, UnitCost, TotalCost, LineNum, WhoCreated) " & _
                                  " VALUES(@TransId, @ItemGroup, @ItemCode, @Description, @QTY_Per_BOM, @UOM, @GrossQTY, @UnitCost, @TotalCost, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemGroup", row.Cells(dgcBOMgroup.Index).Value.ToString)
                    SQL.AddParam("@ItemCode", row.Cells(dgcBOM_ItemCode.Index).Value)
                    SQL.AddParam("@Description", row.Cells(dgcBOM_ItemDesc.Index).Value.ToString)
                    SQL.AddParam("@QTY_Per_BOM", row.Cells(dgcQTY_Per_BOM.Index).Value.ToString)
                    SQL.AddParam("@UOM", row.Cells(dgcUOM.Index).Value.ToString)
                    SQL.AddParam("@GrossQTY", row.Cells(dgcPR.Index).Value.ToString)
                    SQL.AddParam("@UnitCost", row.Cells(dgcUC.Index).Value.ToString)
                    SQL.AddParam("@TotalCost", row.Cells(dgcTC.Index).Value.ToString)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
            updateSQL = " UPDATE tblJO SET Status ='Closed' WHERE TransID = '" & JO_ID & "' "
            SQL.ExecNonQuery(updateSQL)

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "SO_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub ComputeTotal()
        Dim b As Decimal = 0
        Dim a As Decimal = 0
        Dim c As Decimal = 0
        Dim d As Decimal = 0
        ' COMPUTE GROSS
        'For i As Integer = 0 To dgvItemList.Rows.Count - 1
        '    If Val(dgvItemList.Item(chGross.Index, i).Value) <> 0 Then
        '        If IsNumeric(dgvItemList.Item(chGross.Index, i).Value) Then
        '            a = a + Double.Parse(dgvItemList.Item(chGross.Index, i).Value).ToString
        '        End If
        '    End If
        'Next
        txtGross.Text = a.ToString("N2")

        ' COMPUTE DISCOUNT
        'For i As Integer = 0 To dgvItemList.Rows.Count - 1
        '    If Val(dgvItemList.Item(chDiscount.Index, i).Value) <> 0 Then
        '        If IsNumeric(dgvItemList.Item(chDiscount.Index, i).Value) Then
        '            b = b + Double.Parse(dgvItemList.Item(chDiscount.Index, i).Value)
        '        End If
        '    End If
        'Next
        txtDiscount.Text = b.ToString("N2")


        ' COMPUTE VAT
        'For i As Integer = 0 To dgvItemList.Rows.Count - 1
        '    If Val(dgvItemList.Item(chVATAmount.Index, i).Value) <> 0 Then
        '        If IsNumeric(dgvItemList.Item(chVATAmount.Index, i).Value) Then
        '            c = c + Double.Parse(dgvItemList.Item(chVATAmount.Index, i).Value).ToString
        '        End If
        '    End If
        'Next
        txtVAT.Text = c.ToString("N2")

    End Sub

    Private Sub dgvItemMaster_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        ComputeTotal()
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("SO_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("BOM")
            If f.transID <> "" Then
                TransID = f.transID
            End If
            LoadBOM(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("SO_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            BOMNo = ""

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
            tsbCopy.Enabled = True
            EnableControl(True)

            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("SO_EDIT") Then
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
            tsbCopy.Enabled = False
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If txtVCECode.Text = "" Then
            Msg("Please enter VCECode!", MsgBoxStyle.Exclamation)
        ElseIf dgvItemList.Rows.Count = 1 Then
            MsgBox("Please enter an item/services to purchase!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                BOMNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = BOMNo
                SaveBOM()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                BOMNo = txtTransNum.Text
                LoadBOM(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateBOM()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                BOMNo = txtTransNum.Text
                LoadBOM(TransID)
            End If
        End If
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrint.Click
        Dim f As New frmReport_Display
        f.ShowDialog("SO", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If BOMNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblBOM  WHERE BOM_No < '" & BOMNo & "' ORDER BY BOM_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadBOM(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If BOMNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblBOM  WHERE BOM_No > '" & BOMNo & "' ORDER BY BOM_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadBOM(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("SO_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblBOM SET Status ='Cancelled', WhoModified = @WhoModified WHERE BOM_No = @BOM_No "
                        SQL.FlushParams()
                        BOMNo = txtTransNum.Text
                        SQL.AddParam("@BOM_No", BOMNo)
                        SQL.AddParam("@WhoModified", UserID)
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
                        tsbCopy.Enabled = False
                        EnableControl(False)

                        BOMNo = txtTransNum.Text
                        LoadBOM(BOMNo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "BOM_No", BOMNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.Type = "Customer"
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        txtVCEName.Text = f.VCEName
    End Sub


    Private Sub frmAPV_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
                If tsbCopy.Enabled = True Then tsbCopy.ShowDropDown()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbPrint.Enabled = True Then
                    tsbPrint.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If BOMNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadBOM(BOMNo)
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
        tsbCopy.Enabled = False
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbCopySQ_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyPR.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("JO")
        LoadJO(f.transID)
        f.Dispose()
    End Sub


    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.Type = "Customer"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
        End If
    End Sub

    Private Sub dgvItemList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellContentClick

    End Sub

    Private Sub txtCaseOrder_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCaseOrder_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cbBOM_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBOM.SelectedIndexChanged
        If cbBOM.SelectedIndex <> -1 Then
            txtLotSize.Text = GetLotSize(cbBOM.SelectedItem)
        End If
    End Sub

    Private Function GetLotSize(ByVal Code As String) As Decimal
        Dim query As String
        query = " SELECT QTY FROM tblBOM_Maintenance_Header WHERE BOM_Code ='" & Code & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("QTY").ToString
        Else
            Return 0
        End If
    End Function

    Private Sub btnExpload_Click(sender As System.Object, e As System.EventArgs) Handles btnExpload.Click
        dgvItemList.Rows.Clear()
        Dim query As String
        query = " SELECT    BOM_Group, tblBOM_Maintenance_Details.MaterialCode, ItemName, tblBOM_Maintenance_Details.UOM, tblBOM_Maintenance_Details.QTY, ISNULL(tblItem_Master.ID_SC,tblBOM_Group.StandardCost) AS ID_SC  " & _
                " FROM      tblBOM_Maintenance_Header INNER JOIN tblBOM_Maintenance_Details " & _
                " ON        tblBOM_Maintenance_Header.BOM_Code = tblBOM_Maintenance_Details.BOM_Code " & _
                " LEFT JOIn tblItem_Master " & _
                " ON        tblBOM_Maintenance_Details.MaterialCode = tblItem_Master.ItemCode " & _
                " AND       tblItem_Master.Status ='Active' " & _
                " LEFT JOIN tblBOM_Group " & _
                " ON        tblBOM_Group.BOMGroup = tblBOM_Maintenance_Details.BOM_Group " & _
                " AND       tblBOM_Group.Status ='Active' " & _
                " WHERE     tblBOM_Maintenance_Header.Status ='Active' " & _
                " AND       tblBOM_Maintenance_Header.BOM_Code = '" & cbBOM.SelectedItem & "' " & _
                " ORDER BY  LineNumber "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            Dim cycle As Decimal = (CDec(txtQTY.Text) / CDec(txtLotSize.Text))
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                If row(1).ToString = "" Then
                    'query = " SELECT    BOM_Group, tblItem_Master.ItemCode, ItemName, tblBOM_Maintenance_Details.UOM, tblBOM_Maintenance_Details.QTY, ISNULL(Stock,0) AS Stock  " & _
                    '     " FROM      tblBOM_Maintenance_Header INNER JOIN tblBOM_Maintenance_Details " & _
                    '     " ON        tblBOM_Maintenance_Header.BOM_Code = tblBOM_Maintenance_Details.BOM_Code " & _
                    '     " INNER JOIn tblItem_Master " & _
                    '     " ON        tblBOM_Maintenance_Details.BOM_Group = tblItem_Master.ItemGroup " & _
                    '     " AND       tblItem_Master.Status ='Active' " & _
                    '     "  LEFT JOIN  " & _
                    '     " ( " & _
                    '     "  		SELECT		tblInventory.ItemCode, ISNULL(SUM(QTY),0) AS Stock " & _
                    '     "  		FROM		tblInventory INNER JOIN tblItem_Master " & _
                    '     "  		ON			tblInventory.ItemCode = tblItem_Master.ItemCode " & _
                    '     "  		GROUP BY	tblInventory.ItemCode " & _
                    '     " )  AS Stock " & _
                    '     " ON		    tblItem_Master.ItemCode = Stock.ItemCode " & _
                    '     " WHERE     tblBOM_Maintenance_Header.Status ='Active' " & _
                    '     " AND       tblBOM_Maintenance_Header.BOM_Code = '" & cbBOM.SelectedItem & "' " & _
                    '     " AND       tblBOM_Maintenance_Details.BOM_Group = '" & row(0).ToString & "' " & _
                    '     " ORDER BY  LineNumber "
                    'SQL.ReadQuery(query)
                    'Dim OrderBalance As Decimal = 0
                    'While SQL.SQLDR.Read
                    '    Dim OrderedQTY As Decimal = SQL.SQLDR("QTY").ToString
                    '    OrderBalance = OrderedQTY
                    '    Dim Stock As Decimal = SQL.SQLDR("Stock").ToString
                    '    If Stock > OrderBalance Then
                    '        dgvItemList.Rows.Add({row(0).ToString, SQL.SQLDR("ItemCode").ToString, SQL.SQLDR("ItemName").ToString, row(3).ToString, OrderBalance, OrderBalance * txtQTY.Text})
                    '        Exit While
                    '    ElseIf Stock > 0 Then
                    '        dgvItemList.Rows.Add({row(0).ToString, SQL.SQLDR("ItemCode").ToString, SQL.SQLDR("ItemName").ToString, row(3).ToString, Stock, Stock * txtQTY.Text})
                    '        OrderBalance = OrderBalance - Stock
                    '    End If

                    'End While
                    dgvItemList.Rows.Add({row(0).ToString, "", "", row(3).ToString, row(4), row(4) * cycle, row(5), row(5) * (row(4) * cycle)})
                Else
                    dgvItemList.Rows.Add({row(0).ToString, row(1).ToString, row(2).ToString, row(3).ToString, row(4), row(4) * cycle, row(5), row(5) * (row(4) * cycle)})
                End If

            Next
            LoadLabor(cbBOM.SelectedItem)
            LoadOverhead(cbBOM.SelectedItem)
            ComputeTotals()
        End If
    End Sub

    Public Sub LoadOverhead(ByVal Code As String)
        Dim query As String
        Dim ctr As Integer = 0
        query = " SELECT   Activity, Machine, RatePerHour, KW, NumHours, TotalKWH, TotalCost " & _
                " FROM     tblBOM_Overhead " & _
                " WHERE    BOMCode = '" & Code & "'" & _
                " ORDER BY LineNumber "
        SQL.GetQuery(query)
        dgvOverhead.Rows.Clear()
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvOverhead.Rows.Add(New String() {row(0).ToString, _
                                             row(1).ToString, _
                                             row(2).ToString, _
                                             row(3).ToString, _
                                             row(4).ToString, row(5).ToString, row(6).ToString})
                ctr += 1
            Next

        End If
    End Sub

    Public Sub LoadLabor(ByVal Code As String)
        Dim query As String
        Dim ctr As Integer = 0
        query = " SELECT   Activity, RatePerHour, CrewNum, TimeMins, TotalMins, TotalCost " & _
                " FROM     tblBOM_Labor " & _
                " WHERE    BOMCode = '" & Code & "'" & _
                " ORDER BY LineNumber "
        SQL.GetQuery(query)
        dgvLabor.Rows.Clear()
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvLabor.Rows.Add(New String() {row(0).ToString, _
                                             row(1).ToString, _
                                             row(2).ToString, _
                                             row(3).ToString, _
                                             row(4).ToString, row(5).ToString})
                ctr += 1
            Next

        End If
    End Sub

    Private Function GetINVTY(ItemCode As String) As Decimal
        Dim query As String
        query = " SELECT    ISNULL(SUM(QTY),0) AS Stock " & _
                " FROM		tblInventory INNER JOIN tblItem_Master " & _
                " ON		tblInventory.ItemCode = tblItem_Master.ItemCode " & _
                " WHERE  	tblInventory.ItemCode = '" & ItemCode & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Stock")
        Else
            Return 0
        End If
    End Function

    Private Sub txtLotSize_TextChanged(sender As System.Object, e As System.EventArgs)
        If IsNumeric(txtLotSize.Text) Then
            ComputeTotals()
        End If
    End Sub

    Private Sub ComputeTotals()
        Dim A, B, C As Decimal
        A = 0
        For Each row As DataGridViewRow In dgvItemList.Rows
            If Not row.Cells(dgcQTY_Per_BOM.Index).Value Is Nothing AndAlso IsNumeric(row.Cells(dgcQTY_Per_BOM.Index).Value) Then
                row.Cells(dgcPR.Index).Value = CDec(row.Cells(dgcQTY_Per_BOM.Index).Value) / CDec(txtLotSize.Text)
            End If
            A += row.Cells(dgcTC.Index).Value
        Next
        txtDMcost.Text = A.ToString("N2")

        B = 0
        For Each row As DataGridViewRow In dgvLabor.Rows
            B += row.Cells(dgcDLtotalCost.Index).Value
        Next
        txtDLcost.Text = B.ToString("N2")

        C = 0
        For Each row As DataGridViewRow In dgvOverhead.Rows
            C += row.Cells(dgcFOcost.Index).Value
        Next
        txtFOcost.Text = C.ToString("N2")

        txtTotalCost.Text = (A + B + C).ToString("N2")
    End Sub

End Class