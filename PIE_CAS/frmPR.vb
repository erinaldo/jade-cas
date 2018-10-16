Public Class frmPR
    Dim TransID As String
    Dim PRNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "PR"
    Dim ColumnPK As String = "PR_No"
    Dim DBTable As String = "tblPR"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim BOM_ID As Integer

    Private Sub frmPR_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            LoadSetup()
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            dtpDelivery.Value = Date.Today.Date
            LoadChartOfAccount()
            If PRNo <> "" Then
                LoadPR(PRNo)
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
            EnableControl(False)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadSetup()
        Dim PRstock As String
        Dim query As String
        query = " SELECT  ISNULL(PR_StockLevel,0) AS PR_StockLevel FROM tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            PRstock = SQL.SQLDR("PR_StockLevel").ToString

            LoadWHlevel(PRstock)
        End If
    End Sub

    Private Sub LoadWHlevel(ByVal GroupID As String)
        Dim query As String
        query = " SELECT DISTINCT  " & GroupID & " AS GroupID FROM tblWarehouse WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbStock.Items.Clear()
        While SQL.SQLDR.Read
            cbStock.Items.Add(SQL.SQLDR("GroupID").ToString)
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

    Private Sub EnableControl(ByVal Value As Boolean)
        cbGLAccount.Enabled = Value
        dgvItemMaster.AllowUserToAddRows = Value
        dgvItemMaster.AllowUserToDeleteRows = Value
        If Value = True Then
            dgvItemMaster.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvItemMaster.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        cbDeliverTo.Enabled = Value
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        dtpDelivery.Enabled = Value
        cbPurchType.Enabled = Value
        cbStock.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadPR(ByVal TransNum As String)
        Dim query As String
        query = " SELECT   TransID, PR_No, DatePR, AccntCode, PurchaseType, Remarks, DateNeeded, RequestedBy, BOM_Ref, Status " & _
                " FROM     tblPR " & _
                " WHERE    TransID = '" & TransNum & "' " & _
                " ORDER BY TransID "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            txtTransNum.Text = SQL.SQLDR("PR_No").ToString
            PRNo = SQL.SQLDR("PR_No").ToString
            cbGLAccount.SelectedItem = SQL.SQLDR("AccntCode").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            dtpDocDate.Text = SQL.SQLDR("DatePR").ToString
            dtpDelivery.Text = SQL.SQLDR("DateNeeded").ToString
            cbDeliverTo.Text = SQL.SQLDR("RequestedBy").ToString
            BOM_ID = SQL.SQLDR("BOM_Ref").ToString
            If Not IsDBNull(SQL.SQLDR("PurchaseType")) Then
                cbPurchType.SelectedItem = SQL.SQLDR("PurchaseType").ToString
            Else
                cbPurchType.SelectedIndex = -1
            End If
            txtBOMRef.Text = LoadBOMNo(BOM_ID)
            LoadPRDetails(TransID)

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

    Private Function LoadBOMNo(ID As Integer) As String
        Dim query As String
        query = " SELECT BOM_No FROM tblBOM WHERE TransID = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("BOM_No")
        Else
            Return 0
        End If
    End Function

    Protected Sub LoadPRDetails(ByVal TransID As String)
        Dim query As String
        query = " SELECT    ItemGroup, ItemCode, Description, UOM, ISNULL(BOMQTY,0) AS BOMQTY, ISNULL(InStock,0) AS InStock, QTY  " & _
                " FROM      tblPR_Details " & _
                " WHERE     tblPR_Details.TransID = " & TransID & " " & _
                " ORDER BY  LineNum "
        dgvItemMaster.Rows.Clear()
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            dgvItemMaster.Rows.Add(SQL.SQLDR("ItemGroup").ToString, SQL.SQLDR("ItemCode").ToString, SQL.SQLDR("Description").ToString, SQL.SQLDR("UOM").ToString, SQL.SQLDR("BOMQTY").ToString, SQL.SQLDR("InStock").ToString, SQL.SQLDR("QTY").ToString)
        End While
    End Sub

    Private Sub ClearText()
        txtTransNum.Text = ""
        cbGLAccount.SelectedIndex = -1
        dgvItemMaster.Rows.Clear()
        cbDeliverTo.Text = ""
        txtRemarks.Text = ""
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        dtpDelivery.Value = Date.Today.Date
        cbPurchType.SelectedItem = "Goods"
        dgvItemMaster.Columns(chBOMQTY.Index).Visible = False
        dgvItemMaster.Columns(dgcStock.Index).Visible = False
    End Sub

    Private Sub dgvItemMaster_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemMaster.CellEndEdit
        Try
          
            Dim itemCode As String
            Dim rowIndex As Integer = dgvItemMaster.CurrentCell.RowIndex
            Dim colindex As Integer = dgvItemMaster.CurrentCell.ColumnIndex
            Select Case colindex
                Case chItemCode.Index
                    If dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("ItemListPR", itemCode, "Purchase")
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItem(itemCode)
                        Else
                            dgvItemMaster.Rows.RemoveAt(e.RowIndex)
                        End If
                        f.Dispose()
                    End If
                Case chItemDesc.Index
                    If dgvItemMaster.Item(chItemDesc.Index, e.RowIndex).Value <> "" Then
                        If cbPurchType.SelectedItem = "Goods" Then
                            itemCode = dgvItemMaster.Item(chItemDesc.Index, e.RowIndex).Value
                            Dim f As New frmCopyFrom
                            f.ShowDialog("ItemListPR", itemCode, "Purchase")
                            If f.TransID <> "" Then
                                itemCode = f.TransID
                                LoadItem(itemCode)
                            End If
                            dgvItemMaster.Rows.RemoveAt(e.RowIndex)
                            f.Dispose()
                        Else
                            dgvItemMaster.Item(chPRQTY.Index, e.RowIndex).Value = 1
                        End If
                    End If

            End Select
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Public Sub LoadItem(ByVal ItemCode As String)
        Dim query As String
        query = " SELECT  ItemGroup, ItemCode, ItemName, PD_UOM  " & _
                " FROM    tblItem_Master " & _
                " WHERE   ItemCode ='" & ItemCode & "'"
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            dgvItemMaster.Rows.Add(New String() {SQL.SQLDR("ItemGroup").ToString, _
                                                 SQL.SQLDR("ItemCode").ToString, _
                                               SQL.SQLDR("ItemName").ToString, _
                                               SQL.SQLDR("PD_UOM").ToString, 1})

        End While
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("PR_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            PRNo = ""

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
            EnableControl(True)

            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub


    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("PR_EDIT") Then
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
        ElseIf cbPurchType.SelectedItem <> "Goods" AndAlso cbGLAccount.SelectedIndex = -1 Then
            Msg("Please Select GL Account!", MsgBoxStyle.Exclamation)
        ElseIf RecordsValidated() Then
            If TransID = "" Then
                If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    TransID = GenerateTransID(ColumnPK, DBTable)
                    PRNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                    txtTransNum.Text = PRNo
                    SavePR()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    PRNo = txtTransNum.Text
                    LoadPR(PRNo)
                End If
            Else
                If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdatePR()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    PRNo = txtTransNum.Text
                    LoadPR(PRNo)
                End If
            End If
        End If
    End Sub

    Private Function RecordsValidated() As Boolean
        Dim ctr As Integer = 0
        Dim valid As Boolean = True
        For Each row As DataGridViewRow In dgvItemMaster.Rows
            If cbPurchType.SelectedItem = "Goods" Then
                If row.Cells(chItemCode.Index).Value <> Nothing AndAlso row.Cells(chItemCode.Index).Value <> "" _
                    AndAlso (row.Cells(chPRQTY.Index).Value = Nothing OrElse Not IsNumeric(row.Cells(chPRQTY.Index).Value)) Then
                    Msg("Please input quantity for this item!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemCode.Index).Value <> Nothing AndAlso row.Cells(chPRQTY.Index).Value = Nothing Then
                    Msg("No Item Selected for this quantity!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemCode.Index).Value <> Nothing AndAlso row.Cells(chPRQTY.Index).Value <> Nothing Then
                    ctr += 1
                End If
            ElseIf cbPurchType.SelectedItem = "Services" Then
                If row.Cells(chItemDesc.Index).Value <> Nothing AndAlso row.Cells(chPRQTY.Index).Value = Nothing Then
                    Msg("Please input quantity for this item!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemDesc.Index).Value <> Nothing AndAlso row.Cells(chPRQTY.Index).Value = Nothing Then
                    Msg("No Item Selected for this quantity!", MsgBoxStyle.Exclamation)
                    valid = False
                    Exit For
                ElseIf row.Cells(chItemDesc.Index).Value <> Nothing AndAlso row.Cells(chPRQTY.Index).Value <> Nothing Then
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

    Private Sub SavePR()
        Try
            If cbGLAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbGLAccount.SelectedItem)
            End If
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                         " tblPR(TransID, PR_No, BranchCode, BusinessCode, DatePR, AccntCode, PurchaseType, Remarks, DateNeeded, RequestedBy, BOM_Ref, WhoCreated) " & _
                         " VALUES(@TransID, @PR_No, @BranchCode, @BusinessCode, @DatePR, @AccntCode, @PurchaseType, @Remarks, @DateNeeded, @RequestedBy, @BOM_Ref, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@PR_No", PRNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DatePR", dtpDocDate.Value.Date)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@PurchaseType", cbPurchType.SelectedItem)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@DateNeeded", dtpDelivery.Value.Date)
            SQL.AddParam("@RequestedBy", cbDeliverTo.Text)
            SQL.AddParam("@BOM_Ref", BOM_ID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvItemMaster.Rows
                If item.Cells(chPRQTY.Index).Value <> Nothing Then
                    insertSQL = " INSERT INTO " & _
                       " tblPR_Details(TransID, ItemGroup, ItemCode, Description, BOMQTY, InStock, QTY, UOM, LineNum, WhoCreated) " & _
                       " VALUES(@TransID, @ItemGroup, @ItemCode, @Description, @BOMQTY, @InStock, @QTY, @UOM, @LineNum, @WhoCreated)"
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    If IsNothing(item.Cells(chItemGroup.Index).Value) Then
                        SQL.AddParam("@ItemGroup", "")
                    Else
                        SQL.AddParam("@ItemGroup", item.Cells(chItemGroup.Index).Value)
                    End If
                    If cbPurchType.SelectedItem = "Goods" Then
                        SQL.AddParam("@ItemCode", item.Cells(chItemCode.Index).Value)
                        SQL.AddParam("@UOM", item.Cells(chUOM.Index).Value)
                    Else
                        SQL.AddParam("@ItemCode", "")
                        SQL.AddParam("@UOM", "")
                    End If
                    SQL.AddParam("@Description", item.Cells(chItemDesc.Index).Value)
                    If IsNumeric(item.Cells(chBOMQTY.Index).Value) Then
                        SQL.AddParam("@BOMQTY", item.Cells(chBOMQTY.Index).Value)
                    Else
                        SQL.AddParam("@BOMQTY", 0)
                    End If

                    If IsNumeric(item.Cells(dgcStock.Index).Value) Then
                        SQL.AddParam("@InStock", item.Cells(dgcStock.Index).Value)
                    Else
                        SQL.AddParam("@InStock", 0)
                    End If
                    SQL.AddParam("@QTY", item.Cells(chPRQTY.Index).Value)

                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                End If
            Next

            Dim updateSQL As String
            updateSQL = " UPDATE tblBOM SET Status ='Closed' WHERE TransID = '" & BOM_ID & "' "
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "PR_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdatePR()
        Try
            If cbGLAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbGLAccount.SelectedItem)
            End If
            activityStatus = True

            ' UPDATE PR HEADER
            Dim updateSQL, deleteSQL, insertSQL As String
            updateSQL = " UPDATE tblPR " & _
                        " SET    PR_No = @PR_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, " & _
                        "        DatePR = @DatePR, AccntCode = @AccntCode, PurchaseType = @PurchaseType, Remarks = @Remarks, " & _
                        "        DateNeeded = @DateNeeded, RequestedBy = @RequestedBy, BOM_Ref = @BOM_Ref, " & _
                        "        DateModified = GETDATE(), WhoModified = @WhoModified " & _
                        " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@PR_No", txtTransNum.Text)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DatePR", dtpDocDate.Value.Date)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@PurchaseType", cbPurchType.SelectedItem)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@DateNeeded", dtpDelivery.Value.Date)
            SQL.AddParam("@RequestedBy", cbDeliverTo.Text)
            SQL.AddParam("@BOM_Ref", BOM_ID)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            ' DELETE PR DETAILS
            deleteSQL = " DELETE FROM tblPR_Details WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            ' INSERT PR DETAILS
            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvItemMaster.Rows
                If item.Cells(chPRQTY.Index).Value <> Nothing Then

                    insertSQL = " INSERT INTO " & _
                       " tblPR_Details(TransID, ItemGroup, ItemCode, Description,BOMQTY, InStock, QTY, UOM, LineNum, WhoCreated) " & _
                       " VALUES(@TransID, @ItemGroup, @ItemCode, @Description, @BOMQTY, @InStock, @QTY, @UOM, @LineNum, @WhoCreated)"
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    If IsNothing(item.Cells(chItemGroup.Index).Value) Then
                        SQL.AddParam("@ItemGroup", "")
                    Else
                        SQL.AddParam("@ItemGroup", item.Cells(chItemGroup.Index).Value)
                    End If
                    If cbPurchType.SelectedItem = "Goods" Then
                        SQL.AddParam("@ItemCode", item.Cells(chItemCode.Index).Value)
                        SQL.AddParam("@UOM", item.Cells(chUOM.Index).Value)
                    Else
                        SQL.AddParam("@ItemCode", "")
                        SQL.AddParam("@UOM", "")
                    End If
                    If IsNumeric(item.Cells(chBOMQTY.Index).Value) Then
                        SQL.AddParam("@BOMQTY", item.Cells(chBOMQTY.Index).Value)
                    Else
                        SQL.AddParam("@BOMQTY", 0)
                    End If
                    If IsNumeric(item.Cells(dgcStock.Index).Value) Then
                        SQL.AddParam("@InStock", item.Cells(dgcStock.Index).Value)
                    Else
                        SQL.AddParam("@InStock", 0)
                    End If
                    SQL.AddParam("@Description", item.Cells(chItemDesc.Index).Value)
                    SQL.AddParam("@QTY", item.Cells(chPRQTY.Index).Value)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next

            updateSQL = " UPDATE tblBOM SET Status ='Closed' WHERE TransID = '" & BOM_ID & "' "
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "PR_No", PRNo, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub


    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("PR_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("PR")
            If f.transID <> "" Then
                TransID = f.transID
            End If
            LoadPR(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("PR_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblPR SET Status ='Cancelled' WHERE PR_No = @PR_No "
                        SQL.FlushParams()
                        PRNo = txtTransNum.Text
                        SQL.AddParam("@PR_No", PRNo)
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

                        PRNo = txtTransNum.Text
                        LoadPR(PRNo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "PR_No", PRNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If PRNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadPR(PRNo)
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
        If PRNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 PR_No FROM tblPR  WHERE PR_No < '" & PRNo & "' ORDER BY PR_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                PRNo = SQL.SQLDR("PR_No").ToString
                LoadPR(PRNo)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If PRNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 PR_No FROM tblPR  WHERE PR_No > '" & PRNo & "' ORDER BY PR_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                PRNo = SQL.SQLDR("PR_No").ToString
                LoadPR(PRNo)
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
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
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
                    dgvItemMaster.Columns(chItemCode.Index).Visible = True
                    dgvItemMaster.Columns(chUOM.Index).Visible = True
                    dgvItemMaster.Columns(chPRQTY.Index).Visible = True
                    lblGL.Visible = False
                    cbGLAccount.Visible = False
                Else
                    dgvItemMaster.Columns(chItemCode.Index).Visible = False
                    dgvItemMaster.Columns(chUOM.Index).Visible = True
                    dgvItemMaster.Columns(chPRQTY.Index).Visible = True
                    lblGL.Visible = True
                    cbGLAccount.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub cbPurchType_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbPurchType.KeyPress
        e.Handled = True
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvItemMaster.EditingControlShowing
        If dgvItemMaster.CurrentCell.ColumnIndex = chPRQTY.Index Then
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

    Private Sub tsbCopyPR_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyPR.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("BOM")
        LoadBOM(f.transID)
        f.Dispose()
    End Sub

    Private Sub LoadBOM(ByVal ID As String)
        Dim query As String
        query = " SELECT    TransID, BOM_No " & _
                 " FROM     tblBOM " & _
                 " WHERE    TransId = '" & ID & "' "
        SQL.FlushParams()
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            BOM_ID = ID
            txtBOMRef.Text = SQL.SQLDR("BOM_No").ToString
            query = " SELECT    ItemGroup, tblBOM_Details.ItemCode, Description, UOM, GrossQTY, ISNULL(QTY,0) AS Stock  " & _
                    " FROM      tblBOM_Details  " & _
                    " LEFT JOIN " & _
                    " ( " & _
                    "       SELECT	    ItemCode, SUM(QTY) AS QTY " & _
                    "       FROM		viewItem_Stock " & _
                    "       WHERE		G1 ='MOFELS' " & _
                    "       GROUP BY	ItemCode " & _
                    " ) AS Stocks " & _
                    " ON        tblBOM_Details.ItemCode  = Stocks.ItemCode " & _
                    " WHERE     tblBOM_Details.TransID = '" & ID & "' " & _
                    " ORDER BY  LineNum "
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                Dim GrossQTY As Decimal = 0
                For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                    Dim MOQ As Decimal = GetMOQ(row(1).ToString)
                    GrossQTY = row(4) - row(5)
                    If MOQ = 0 OrElse GrossQTY > MOQ Then
                        GrossQTY = Math.Ceiling(GrossQTY)
                        dgvItemMaster.Rows.Add({row(0).ToString, row(1).ToString, row(2).ToString, row(3).ToString, row(4).ToString, row(5).ToString, GrossQTY})
                    Else
                        dgvItemMaster.Rows.Add({row(0).ToString, row(1).ToString, row(2).ToString, row(3).ToString, row(4).ToString, row(5).ToString, MOQ})
                    End If
                Next
            End If


            dgvItemMaster.Columns(chBOMQTY.Index).Visible = True
            dgvItemMaster.Columns(dgcStock.Index).Visible = True
        Else
            ClearText()
        End If
    End Sub

    Private Function GetMOQ(ItemCode As String) As Decimal
        Dim query As String
        query = " SELECT PD_ReorderQTY FROM tblItem_Master WHERE ItemCode = '" & ItemCode & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("PD_ReorderQTY")
        Else
            Return 0
        End If
    End Function

    Private Sub cbGLAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbGLAccount.SelectedIndexChanged

    End Sub
End Class