Public Class frmIT
    Dim TransID, RefID As String
    Dim ITNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "IT"
    Dim ColumnPK As String = "IT_No"
    Dim DBTable As String = "tblIT"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim tempFrom, tempTo As Integer

    Public Overloads Function ShowDialog(ByVal docnumber As String) As Boolean
        TransID = docnumber
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmIT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            LoadWarehouse()
            If TransID <> "" Then
                LoadIT(TransID)
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

    Private Sub LoadWarehouse()
        Dim query As String
        query = " SELECT Description FROM tblWarehouse WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbWHSEFrom.Items.Clear()
        cbWHSEto.Items.Clear()
        While SQL.SQLDR.Read
            cbWHSEFrom.Items.Add(SQL.SQLDR("Description"))
            cbWHSEto.Items.Add(SQL.SQLDR("Description"))
        End While
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        cbWHSEFrom.Enabled = Value
        cbWHSEto.Enabled = Value
        dgvItemMaster.AllowUserToAddRows = Value
        dgvItemMaster.AllowUserToDeleteRows = Value
        dgvItemMaster.ReadOnly = Not Value
        If Value = True Then
            dgvItemMaster.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvItemMaster.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        cbTransType.Enabled = Value
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("IT_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("IT")
            TransID = f.transID
            LoadIT(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub LoadIT(ByVal ID As String)
        Dim query As String
        Dim WHSEfrom, WHSEto As String
        query = " SELECT   TransID, IT_No, DateIT, Type, WHSE_From, WHSE_To, Remarks, Status " & _
                " FROM     tblIT " & _
                " WHERE    TransId = '" & ID & "' " & _
                " ORDER BY TransId "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            disableEvent = True
            TransID = SQL.SQLDR("TransID").ToString
            ITNo = SQL.SQLDR("IT_No").ToString
            txtTransNum.Text = ITNo
            dtpDocDate.Text = SQL.SQLDR("DateIT").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            WHSEfrom = SQL.SQLDR("WHSE_From").ToString
            WHSEto = SQL.SQLDR("WHSE_To").ToString
            cbTransType.SelectedItem = SQL.SQLDR("Type").ToString
            cbWHSEFrom.SelectedItem = GetWHSEDesc(WHSEfrom)
            cbWHSEto.SelectedItem = GetWHSEDesc(WHSEto)
            disableEvent = False
            LoadITDetails(TransID)

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
            Cleartext()
        End If
    End Sub

    Private Sub LoadITDetails(ByVal TransID As String)
        Dim ctr As Integer = 0
        Dim query As String
        query = " SELECT	tblIT_Details.ItemCode, tblIT_Details.Description, tblIT_Details.UOM, tblIT_Details.QTY  AS QTY, " & _
                "           tblIT_Details.WHSE_From, tblIT_Details.WHSE_To " & _
                " FROM	    tblIT INNER JOIN tblIT_Details " & _
                " ON		tblIT.TransID = tblIT_Details.TransID " & _
                " WHERE     tblIT_Details.TransId = " & TransID & " " & _
                " ORDER BY  tblIT_Details.LineNum "
        disableEvent = True
        dgvItemMaster.Rows.Clear()
        disableEvent = False
        SQL.ReadQuery(query)
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvItemMaster.Rows.Add(row(0).ToString, row(1).ToString, row(2).ToString, _
                                     row(3).ToString, GetWHSEDesc(row(4).ToString), GetWHSEDesc(row(5).ToString))
                LoadUOM(row(0).ToString, ctr)
                LoadWHSE(ctr)
                ctr += 1
            Next
        End If
    End Sub

    Private Sub LoadWHSE(Optional ByVal SelectedIndex As Integer = -1)
        Try
            Dim dgvCBFrom, dgvCBTo As New DataGridViewComboBoxCell
            dgvCBFrom = dgvItemMaster.Item(chWHSEFrom.Index, SelectedIndex)
            dgvCBTo = dgvItemMaster.Item(chWHSEto.Index, SelectedIndex)
            dgvCBFrom.Items.Clear()
            dgvCBTo.Items.Clear()
            ' ADD ALL WHSEc
            Dim query As String
            query = " SELECT Description FROM tblWarehouse WHERE Status ='Active'"
            SQL.ReadQuery(query)
            dgvCBFrom.Items.Clear()
            dgvCBTo.Items.Clear()
            While SQL.SQLDR.Read
                dgvCBFrom.Items.Add(SQL.SQLDR("Description").ToString)
                dgvCBTo.Items.Add(SQL.SQLDR("Description").ToString)
            End While
            dgvCBFrom.Items.Add("")
            dgvCBTo.Items.Add("")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub Cleartext()
        disableEvent = True
        cbWHSEto.SelectedIndex = -1
        cbWHSEFrom.SelectedIndex = -1
        cbTransType.SelectedIndex = -1
        dgvItemMaster.Rows.Clear()
        txtRemarks.Clear()
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        disableEvent = False
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("IT_ADD") Then
            msgRestricted()
        Else
            Cleartext()
            TransID = ""
            ITNo = ""

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
        If Not AllowAccess("IT_EDIT") Then
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
        If cbWHSEFrom.SelectedIndex = -1 Then
            Msg("Please select source warehouse!", MsgBoxStyle.Exclamation)
        ElseIf cbWHSEto.SelectedIndex = -1 Then
            Msg("Please select destination warehouse!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                ITNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = ITNo
                SaveIT()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                ITNo = txtTransNum.Text
                LoadIT(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateIT()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                ITNo = txtTransNum.Text
                LoadIT(TransID)
            End If
        End If
    End Sub

    Private Sub SaveIT()
        Try
            Dim MainWHSEfrom, MainWHSEto, Type As String
            Type = IIf(cbTransType.SelectedIndex = -1, "", cbTransType.SelectedItem)
            MainWHSEfrom = GetWHSECode(cbWHSEFrom.SelectedItem)
            MainWHSEto = GetWHSECode(cbWHSEto.SelectedItem)
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblIT(TransID, IT_No, BranchCode, BusinessCode, DateIT, WHSE_From, WHSE_To, Type, Remarks, WhoCreated) " & _
                        " VALUES (@TransID, @IT_No, @BranchCode, @BusinessCode, @DateIT, @WHSE_From, @WHSE_To, @Type, @Remarks, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@IT_No", ITNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateIT", dtpDocDate.Value.Date)
            SQL.AddParam("@WHSE_From", MainWHSEfrom)
            SQL.AddParam("@WHSE_To", MainWHSEto)
            SQL.AddParam("@Type", Type)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            Dim ItemCode, Description, UOM, WHSEfrom, WHSEto As String
            Dim QTY, UnitCost As Decimal
            For Each row As DataGridViewRow In dgvItemMaster.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    ItemCode = IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value)
                    Description = IIf(row.Cells(chItemName.Index).Value = Nothing, "", row.Cells(chItemName.Index).Value)
                    UOM = IIf(row.Cells(chUOM.Index).Value = Nothing, "", row.Cells(chUOM.Index).Value)
                    UnitCost = GetAverageCost(ItemCode)
                    If IsNumeric(row.Cells(chQTY.Index).Value) Then
                        QTY = CDec(row.Cells(chQTY.Index).Value)
                    Else
                        QTY = 1
                    End If
                    WHSEfrom = IIf(row.Cells(chWHSEFrom.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSEFrom.Index).Value))
                    WHSEto = IIf(row.Cells(chWHSEto.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSEto.Index).Value))
                    insertSQL = " INSERT INTO " & _
                         " tblIT_Details(TransId, ItemCode, Description, UOM, QTY, WHSE_From, WHSE_To, LineNum, WhoCreated) " & _
                         " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @WHSE_From, @WHSE_To, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", ItemCode)
                    SQL.AddParam("@Description", Description)
                    SQL.AddParam("@UOM", UOM)
                    SQL.AddParam("@QTY", QTY)
                    SQL.AddParam("@WHSE_From", WHSEfrom)
                    SQL.AddParam("@WHSE_To", WHSEto)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1

                    SaveINVTY("OUT", ModuleID, "IT", TransID, dtpDocDate.Value.Date, ItemCode, WHSEfrom, QTY, UOM, UnitCost)
                    SaveINVTY("IN", ModuleID, "IT", TransID, dtpDocDate.Value.Date, ItemCode, WHSEto, QTY, UOM, UnitCost)
                End If
            Next

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "IT_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateIT()
        Try
            Dim MainWHSEfrom, MainWHSEto, Type As String
            Type = IIf(cbTransType.SelectedIndex = -1, "", cbTransType.SelectedItem)
            MainWHSEfrom = GetWHSECode(cbWHSEFrom.SelectedItem)
            MainWHSEto = GetWHSECode(cbWHSEto.SelectedItem)
            activityStatus = True
            Dim insertSQL, updateSQL, deleteSQL As String
            updateSQL = " UPDATE    tblIT " & _
                        " SET       IT_No = @IT_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, DateIT = @DateIT, " & _
                        "           VCECode = @VCECode, WHSE_From = @WHSE_From, WHSE_To = @WHSE_To, Type = @Type, Remarks = @Remarks, " & _
                        "           WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE     TransID = @TransID  "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@IT_No", ITNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateIT", dtpDocDate.Value.Date)
            SQL.AddParam("@WHSE_From", MainWHSEfrom)
            SQL.AddParam("@WHSE_To", MainWHSEto)
            SQL.AddParam("@Type", Type)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            deleteSQL = " DELETE FROM tblIT_Details WHERE TransID =@TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            Dim line As Integer = 1
            Dim ItemCode, Description, UOM, WHSEfrom, WHSEto As String
            Dim QTY, UnitCost As Decimal
            For Each row As DataGridViewRow In dgvItemMaster.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    ItemCode = IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value)
                    Description = IIf(row.Cells(chItemName.Index).Value = Nothing, "", row.Cells(chItemName.Index).Value)
                    UOM = IIf(row.Cells(chUOM.Index).Value = Nothing, "", row.Cells(chUOM.Index).Value)
                    UnitCost = GetAverageCost(ItemCode)
                    If IsNumeric(row.Cells(chQTY.Index).Value) Then
                        QTY = CDec(row.Cells(chQTY.Index).Value)
                    Else
                        QTY = 1
                    End If
                    WHSEfrom = IIf(row.Cells(chWHSEFrom.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSEFrom.Index).Value))
                    WHSEto = IIf(row.Cells(chWHSEto.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSEto.Index).Value))
                    insertSQL = " INSERT INTO " & _
                         " tblIT_Details(TransId, ItemCode, Description, UOM, QTY, WHSE_From, WHSE_To , LineNum, WhoCreated) " & _
                         " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @WHSE_From, @WHSE_To, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", ItemCode)
                    SQL.AddParam("@Description", Description)
                    SQL.AddParam("@UOM", UOM)
                    SQL.AddParam("@QTY", QTY)
                    SQL.AddParam("@WHSE_From", chWHSEFrom)
                    SQL.AddParam("@WHSE_To", chWHSEto)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1

                    UpdateINVTY("OUT", ModuleID, "IT", TransID, dtpDocDate.Value.Date, ItemCode, WHSEfrom, QTY, UOM, UnitCost)
                    UpdateINVTY("IN", ModuleID, "IT", TransID, dtpDocDate.Value.Date, ItemCode, WHSEto, QTY, UOM, UnitCost)
                End If
            Next

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "IT_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("IT_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblIT SET Status ='Cancelled' WHERE IT_No = @IT_No "
                        SQL.FlushParams()
                        ITNo = txtTransNum.Text
                        SQL.AddParam("@IT_No", ITNo)
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

                        ITNo = txtTransNum.Text
                        LoadIT(ITNo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "IT_No", ITNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If ITNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 IT_No FROM tblIT  WHERE IT_No < '" & ITNo & "' ORDER BY IT_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                ITNo = SQL.SQLDR("IT_No").ToString
                LoadIT(ITNo)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If ITNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 IT_No FROM tblIT  WHERE IT_No > '" & ITNo & "' ORDER BY IT_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                ITNo = SQL.SQLDR("IT_No").ToString
                LoadIT(ITNo)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If ITNo = "" Then
            Cleartext()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadIT(ITNo)
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

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmIT_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                        f.ShowDialog("All Item", itemCode)
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItemDetails(itemCode)
                        Else
                            dgvItemMaster.Rows.RemoveAt(e.RowIndex)
                        End If
                        f.Dispose()
                    End If
                Case chItemName.Index
                    If dgvItemMaster.Item(chItemName.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemMaster.Item(chItemName.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("All Item", itemCode)
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItemDetails(itemCode)
                        Else
                            dgvItemMaster.Rows.RemoveAt(e.RowIndex)
                        End If
                        f.Dispose()
                    End If
            End Select
        Catch ex1 As InvalidOperationException

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try

    End Sub

    Private Sub LoadItemDetails(ByVal ItemCode As String)
        Dim query As String
        query = " SELECT    ItemCode, ItemName, 1 " & _
                " FROM       tblItem_Master " & _
                " WHERE     ItemCode = @ItemCode"
        SQL.FlushParams()
        SQL.AddParam("@ItemCode", IIf(ItemCode = Nothing, "", ItemCode))
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            If dgvItemMaster.SelectedCells.Count > 0 Then

                dgvItemMaster.Item(0, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemCode").ToString
                dgvItemMaster.Item(1, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemName").ToString
                dgvItemMaster.Item(2, dgvItemMaster.SelectedCells(0).RowIndex).Value = ""
                dgvItemMaster.Item(3, dgvItemMaster.SelectedCells(0).RowIndex).Value = 1
                dgvItemMaster.Item(4, dgvItemMaster.SelectedCells(0).RowIndex).Value = IIf(cbWHSEFrom.SelectedIndex = -1, "", cbWHSEFrom.SelectedItem)
                dgvItemMaster.Item(5, dgvItemMaster.SelectedCells(0).RowIndex).Value = IIf(cbWHSEto.SelectedIndex = -1, "", cbWHSEto.SelectedItem)
                LoadWHSE(dgvItemMaster.SelectedCells(0).RowIndex)
                LoadUOM(ItemCode, dgvItemMaster.SelectedCells(0).RowIndex)
            End If
        End If
    End Sub


    Private Sub LoadUOM(ItemCode As String, ByVal SelectedIndex As Integer)
        Try
            Dim dgvCB As New DataGridViewComboBoxCell
            dgvCB = dgvItemMaster.Item(chUOM.Index, SelectedIndex)
            dgvCB.Items.Clear()
            ' ADD ALL WHSEc
            Dim query As String

            query = " SELECT UOM.UnitCode FROM tblItem_Master INNER JOIN  " & _
               " ( " & _
               " SELECT GroupCode, UnitCode FROM tblUOM_Group WHERE Status ='Active' " & _
               " UNION ALL " & _
               " SELECT GroupCode, UnitCode FROM tblUOM_GroupDetails " & _
               " ) AS UOM " & _
               " ON tblItem_Master.ItemUOMGroup = UOM.GroupCode " & _
               " WHERE ItemCode ='" & ItemCode & "' "
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            While SQL.SQLDR.Read
                dgvCB.Items.Add(SQL.SQLDR("UnitCode").ToString)
            End While
            dgvCB.Items.Add("")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvItemMaster_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemMaster.CellClick
        Try
            If e.ColumnIndex = chUOM.Index Then
                If e.RowIndex <> -1 AndAlso dgvItemMaster.Rows.Count > 0 AndAlso dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value <> Nothing Then

                    LoadUOM(dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value.ToString, e.RowIndex)
                    Dim dgvCol As New DataGridViewComboBoxColumn
                    dgvCol = dgvItemMaster.Columns.Item(e.ColumnIndex)
                    dgvItemMaster.BeginEdit(True)
                    dgvCol.Selected = True
                    DirectCast(dgvItemMaster.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                    Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)

                End If
            ElseIf e.ColumnIndex = chWHSEFrom.Index Or e.ColumnIndex = chWHSEto.Index Then
                If e.RowIndex <> -1 AndAlso dgvItemMaster.Rows.Count > 0 AndAlso dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value <> Nothing Then
                    LoadWHSE(e.RowIndex)
                    Dim dgvCol As DataGridViewComboBoxColumn
                    dgvCol = dgvItemMaster.Columns.Item(e.ColumnIndex)
                    dgvItemMaster.BeginEdit(True)
                    dgvCol.Selected = True
                    DirectCast(dgvItemMaster.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                    Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)

                End If
            End If

        Catch ex As NullReferenceException
            If dgvItemMaster.ReadOnly = False Then
                SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvItemMaster_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvItemMaster.EditingControlShowing
        ' GET THE EDITING CONTROL
        Dim editingComboBox As ComboBox = TryCast(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            ' REMOVE AN EXISTING EVENT-HANDLER TO AVOID ADDING MULTIPLE HANDLERS WHEN THE EDITING CONTROL IS REUSED
            RemoveHandler editingComboBox.SelectionChangeCommitted, New EventHandler(AddressOf editingComboBox_SelectionChangeCommitted)

            ' ADD THE EVENT HANDLER
            AddHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted

            ' PREVENT THIS HANDLER FROM FIRING TWICE
            RemoveHandler dgvItemMaster.EditingControlShowing, AddressOf dgvItemMaster_EditingControlShowing
        End If
    End Sub

    Private Sub editingComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rowIndex, columnIndex As Integer
        'Get the editing control
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        If editingComboBox Is Nothing Then Exit Sub
        'Show your Message Boxes
        If editingComboBox.SelectedIndex <> -1 Then
            rowIndex = dgvItemMaster.SelectedCells(0).RowIndex
            columnIndex = dgvItemMaster.SelectedCells(0).ColumnIndex
            If dgvItemMaster.SelectedCells.Count > 0 Then
                Dim tempCell As DataGridViewComboBoxCell = dgvItemMaster.Item(columnIndex, rowIndex)
                Dim temp As String = editingComboBox.Text
                dgvItemMaster.Item(columnIndex, rowIndex).Selected = False
                dgvItemMaster.EndEdit(True)
                tempCell.Value = temp
            End If
        End If

        'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
        RemoveHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted
        'Re-enable the EditingControlShowing event so the above can take place.
        AddHandler dgvItemMaster.EditingControlShowing, AddressOf dgvItemMaster_EditingControlShowing
    End Sub

    Private Sub dgvItemMaster_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvItemMaster.DataError
        Try

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub WHSE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbWHSEFrom.SelectedIndexChanged, cbWHSEto.SelectedIndexChanged
        If disableEvent = False Then
            If cbWHSEFrom.SelectedItem = cbWHSEto.SelectedItem Then
                disableEvent = True
                cbWHSEFrom.SelectedIndex = tempTo
                cbWHSEto.SelectedIndex = tempFrom
                disableEvent = False
            End If
            tempFrom = cbWHSEFrom.SelectedIndex
            tempTo = cbWHSEto.SelectedIndex

        End If
    End Sub
End Class
