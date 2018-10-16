Public Class frmDR
    Dim TransID, RefID As String
    Dim DRNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "DR"
    Dim ColumnPK As String = "DR_No"
    Dim DBTable As String = "tblDR"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim SO_ID As Integer


    Public Overloads Function ShowDialog(ByVal docnumber As String) As Boolean
        TransID = docnumber
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmDR_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            dtpActual.Value = Date.Today.Date
            If TransID <> "" Then
                LoadDR(TransID)
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

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCEName.Enabled = Value
        btnSearchVCE.Enabled = Value
        dgvItemList.AllowUserToAddRows = Value
        dgvItemList.AllowUserToDeleteRows = Value
        dgvItemList.ReadOnly = Not Value
        If Value = True Then
            dgvItemList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvItemList.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        dtpActual.Enabled = Value
        txtSORef.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub


    Private Sub LoadDR(ByVal ID As String)
        Dim query As String
        query = " SELECT   TransID, DR_No, VCECode, DateDR, DateDeliver, Remarks, Status, SO_Ref " & _
                " FROM     tblDR " & _
                " WHERE    TransId = '" & ID & "' " & _
                " ORDER BY TransId "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            DRNo = SQL.SQLDR("DR_No").ToString
            txtTransNum.Text = DRNo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            dtpDocDate.Text = SQL.SQLDR("DateDR").ToString
            dtpActual.Value = IIf(IsDate(SQL.SQLDR("DateDeliver")), SQL.SQLDR("DateDeliver"), Date.Today)
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            SO_ID = SQL.SQLDR("SO_Ref").ToString
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            txtSORef.Text = LoadSONo(SO_ID)
            LoadDRDetails(TransID)

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

    Private Function LoadSONo(SO_ID As Integer) As String
        Dim query As String
        query = " SELECT SO_No FROM tblSO WHERE TransID = '" & SO_ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("SO_No")
        Else
            Return 0
        End If
    End Function

    Protected Sub LoadDRDetails(ByVal TransID As String)
        dgvItemList.Rows.Clear()
        Dim ctr As Integer = 0
        Dim query As String
        query = " SELECT	tblDR_Details.ItemCode, tblDR_Details.Description, tblDR_Details.UOM,  tblDR_Details.QTY AS QTY, " & _
                "           tblDR_Details.WHSE, ISNULL(tblSO_Details.UnitPrice,0) AS UnitPrice " & _
                " FROM	    tblDR INNER JOIN tblDR_Details " & _
                " ON		tblDR.TransID = tblDR_Details.TransID " & _
                " LEFT JOIN tblSO " & _
                " ON		tblSO.TransID = tblDR.SO_Ref  " & _
                " LEFT JOIN tblSO_Details " & _
                " ON		tblSO.TransID = tblSO_Details.TransID " & _
                " AND		tblSO_Details.ItemCode = tblDR_Details.ItemCode " & _
                " WHERE     tblDR_Details.TransId = " & TransID & " " & _
                " ORDER BY  tblDR_Details.LineNum "
        dgvItemList.Rows.Clear()
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvItemList.Rows.Add(row(0).ToString, row(1).ToString, row(2).ToString, _
                                                row(3).ToString, GetWHSEDesc(row(4).ToString), row(5).ToString)
                LoadWHSE(ctr)
                ctr += 1
            Next
        End If
    End Sub

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
        End If
    End Sub

    Private Sub ClearText()
        txtTransNum.Clear()
        txtVCECode.Clear()
        txtVCEName.Clear()
        dgvItemList.Rows.Clear()
        txtRemarks.Clear()
        txtSORef.Clear()
        txtStatus.Text = "Open"
        dtpActual.Value = Date.Today.Date
        dtpDocDate.Value = Date.Today.Date
    End Sub


    Private Sub dgvItemList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellEndEdit
        Try
            Dim itemCode As String
            Dim rowIndex As Integer = dgvItemList.CurrentCell.RowIndex
            Dim colindex As Integer = dgvItemList.CurrentCell.ColumnIndex
            Select Case colindex
                Case chItemCode.Index
                    If dgvItemList.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemList.Item(chItemCode.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("All Item", itemCode)
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItem(itemCode)
                        End If
                        f.Dispose()
                    End If
                Case chItemDesc.Index
                    If dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("All Item", itemCode)
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItem(itemCode)
                        End If
                        dgvItemList.Rows.RemoveAt(e.RowIndex)
                        f.Dispose()
                    End If
            End Select
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Public Sub LoadItem(ByVal ItemCode As String, Optional UOM As String = "", Optional QTY As Integer = 1)
        Try
            Dim query As String
            Dim netPrice As Decimal
            query = " SELECT  ItemCode,  ItemName, UOM,  " & _
                    "         CASE WHEN VATable = 1 " & _
                    "              THEN (CASE WHEN VATInclusive = 1 THEN UnitPrice ELSE UnitPrice*1.12 END)  " & _
                    "              ELSE UnitPrice " & _
                    "         END AS Net_Price, WHSE " & _
                    " FROM    viewItem_Price " & _
                    " WHERE   ItemCode = @ItemCode "
            SQL.FlushParams()
            SQL.AddParam("@ItemCode", ItemCode)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                If UOM = "" Then
                    UOM = SQL.SQLDR("UOM").ToString
                End If
                netPrice = SQL.SQLDR("Net_Price")
                dgvItemList.Rows.Add(New String() {SQL.SQLDR("ItemCode").ToString, _
                                              SQL.SQLDR("ItemName").ToString, _
                                             UOM, _
                                              QTY, _
                                              GetWHSEDesc(SQL.SQLDR("WHSE").ToString), _
                                              Format(netPrice, "#,###,###,###.00").ToString})
                LoadWHSE(dgvItemList.Rows.Count - 2)
            End If

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub SaveDRDetails(ByVal TransID As Integer)
        Dim insertSQL As String
        Dim line As Integer = 1
        For Each row As DataGridViewRow In dgvItemList.Rows
            If row.Cells(chItemCode.Index).Value <> Nothing Then
                insertSQL = " INSERT INTO " & _
                            " tblDR_Details(TransID, ItemCode, Description, UOM, QTY, LineNum) " & _
                            " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @LineNum) "
                SQL.FlushParams()
                SQL.AddParam("TransID", TransID)
                SQL.AddParam("ItemCode", IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value))
                SQL.AddParam("Description", row.Cells(chItemDesc.Index).Value.ToString)
                SQL.AddParam("UOM", row.Cells(chUOM.Index).Value.ToString)
                SQL.AddParam("QTY", CDec(row.Cells(chQTY.Index).Value))
                SQL.AddParam("LineNum", line)
                SQL.ExecNonQuery(insertSQL)
                line += 1
            End If
        Next
    End Sub

    Private Sub SaveDR()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                                " tblDR(TransID, DR_No, BranchCode, BusinessCode, VCECode, DateDR, DateDeliver, Remarks, SO_Ref, WhoCreated) " & _
                                " VALUES (@TransID, @DR_No, @BranchCode, @BusinessCode, @VCECode,  @DateDR, @DateDeliver, @Remarks, @SO_Ref, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@DR_No", DRNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateDR", dtpDocDate.Value.Date)
            SQL.AddParam("@DateDeliver", dtpActual.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@SO_Ref", txtSORef.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            Dim ItemCode, Description, UOM, WHSE As String
            Dim QTY, UnitCost As Decimal
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    ItemCode = IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value)
                    Description = IIf(row.Cells(chItemDesc.Index).Value = Nothing, "", row.Cells(chItemDesc.Index).Value)
                    UOM = IIf(row.Cells(chUOM.Index).Value = Nothing, "", row.Cells(chUOM.Index).Value)
                    UnitCost = GetAverageCost(ItemCode)
                    If IsNumeric(row.Cells(chQTY.Index).Value) Then
                        QTY = CDec(row.Cells(chQTY.Index).Value)
                    Else
                        QTY = 1
                    End If
                    WHSE = IIf(row.Cells(chWHSE.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSE.Index).Value))
                    insertSQL = " INSERT INTO " & _
                         " tblDR_Details(TransId, ItemCode, Description, UOM, QTY, WHSE, LineNum, WhoCreated) " & _
                         " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @WHSE, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", ItemCode)
                    SQL.AddParam("@Description", Description)
                    SQL.AddParam("@UOM", UOM)
                    SQL.AddParam("@QTY", QTY)
                    SQL.AddParam("@WHSE", WHSE)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1

                    SaveINVTY("OUT", ModuleID, "DR", TransID, dtpDocDate.Value.Date, ItemCode, WHSE, QTY, UOM, UnitCost)
                End If
            Next

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "DR_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateDR()
        Try

            activityStatus = True
            Dim insertSQL, updateSQL, deleteSQL As String
            updateSQL = " UPDATE    tblDR " & _
                        " SET       DR_No = @DR_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, DateDR = @DateDR, " & _
                        "           VCECode = @VCECode, DateDeliver = @DateDeliver, Remarks = @Remarks, " & _
                        "           SO_Ref = @SO_Ref, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE     TransID = @TransID  "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@RR_No", DRNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateDR", dtpDocDate.Value.Date)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateDeliver", dtpActual.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@SO_Ref", SO_ID)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            deleteSQL = " DELETE FROM tblDR_Details WHERE TransID =@TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            Dim line As Integer = 1
            Dim ItemCode, Description, UOM, WHSE As String
            Dim QTY, UnitCost As Decimal
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    ItemCode = IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value)
                    Description = IIf(row.Cells(chItemDesc.Index).Value = Nothing, "", row.Cells(chItemDesc.Index).Value)
                    UOM = IIf(row.Cells(chUOM.Index).Value = Nothing, "", row.Cells(chUOM.Index).Value)
                    UnitCost = GetAverageCost(ItemCode)
                    If IsNumeric(row.Cells(chQTY.Index).Value) Then
                        QTY = CDec(row.Cells(chQTY.Index).Value)
                    Else
                        QTY = 1
                    End If
                    WHSE = IIf(row.Cells(chWHSE.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSE.Index).Value))
                    insertSQL = " INSERT INTO " & _
                         " tblDR_Details(TransId, ItemCode, Description, UOM, QTY, WHSE, LineNum, WhoCreated) " & _
                         " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @WHSE, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", ItemCode)
                    SQL.AddParam("@Description", Description)
                    SQL.AddParam("@UOM", UOM)
                    SQL.AddParam("@QTY", QTY)
                    SQL.AddParam("@WHSE", WHSE)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1

                    ' NEGATIVE QUANTITY FOR OUTGOING ITEMS
                    QTY = QTY * -1
                    Dim baseQTY As Decimal = QTY * ConvertUOM(UOM, ItemCode)
                    Dim baseValue As Decimal = QTY * UnitCost

                    UpdateINVTY("OUT", ModuleID, "DR", TransID, dtpDocDate.Value.Date, ItemCode, WHSE, QTY, UOM, UnitCost)
                End If
            Next

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "DR_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub


    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        txtVCEName.Text = f.VCEName
    End Sub

    Private Sub LoadSO(ByVal SO As String)
        Dim query As String
        query = " SELECT  TransID, DateSO AS Date, tblSO.VCECode, VCEName, Remarks " & _
                " FROM   tblSO INNER JOIN tblVCE_Master " & _
                " ON     tblSO.VCECode = tblVCE_Master.VCECode " & _
                " WHERE  tblSO.Status ='Active' AND TransID ='" & SO & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtSORef.Text = SQL.SQLDR("TransID")
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString


            query = " SELECT tblSO_Details.ItemCode, Description, UOM, Unserved AS QTY , ISNULL(UnitPrice,0) AS UnitPrice, viewSO_Unserved.WHSE " & _
                    " FROM   tblSO_Details INNER JOIN viewSO_Unserved " & _
                    " ON     tblSO_Details.TransID = viewSO_Unserved.TransID " & _
                    " AND    tblSO_Details.ItemCode = viewSO_Unserved.ItemCode " & _
                    " WHERE  tblSO_Details.TransID ='" & SO & "' "
            dgvItemList.Rows.Clear()
            SQL.GetQuery(query)
            Dim ctr As Integer = 0
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                    dgvItemList.Rows.Add(row(0).ToString, row(1).ToString, row(2).ToString, _
                                         CDec(row(3)).ToString("N2"), GetWHSEDesc(row(5).ToString), row(4).ToString)
                    LoadWHSE(ctr)
                    ctr += 1
                Next
            End If
        Else
            ClearText()
        End If
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("DR_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("DR")
            TransID = f.transID
            LoadDR(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("DR_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            DRNo = ""

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

    Private Sub dgvItemList_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellClick
        If e.ColumnIndex = chWHSE.Index Then
            If e.RowIndex <> -1 AndAlso dgvItemList.Rows.Count > 0 Then
                Try
                    LoadWHSE(e.RowIndex)
                    Dim dgvCol As DataGridViewComboBoxColumn
                    dgvCol = dgvItemList.Columns.Item(e.ColumnIndex)
                    dgvItemList.BeginEdit(True)
                    dgvCol.Selected = True
                    DirectCast(dgvItemList.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                    Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
                Catch ex As NullReferenceException
                Catch ex As Exception
                    SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                End Try
           
            End If
        End If
    End Sub

    Private Sub dgvItemList_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvItemList.EditingControlShowing
          ' GET THE EDITING CONTROL
        Dim editingComboBox As ComboBox = TryCast(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            ' REMOVE AN EXISTING EVENT-HANDLER TO AVOID ADDING MULTIPLE HANDLERS WHEN THE EDITING CONTROL IS REUSED
            RemoveHandler editingComboBox.SelectionChangeCommitted, New EventHandler(AddressOf editingComboBox_SelectionChangeCommitted)

            ' ADD THE EVENT HANDLER
            AddHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted

            ' PREVENT THIS HANDLER FROM FIRING TWICE
            RemoveHandler dgvItemList.EditingControlShowing, AddressOf dgvItemList_EditingControlShowing
        End If
    End Sub

    Private Sub editingComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rowIndex, columnIndex As Integer
        'Get the editing control
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        If editingComboBox Is Nothing Then Exit Sub
        'Show your Message Boxes
        If editingComboBox.SelectedIndex <> -1 Then
            rowIndex = dgvItemList.SelectedCells(0).RowIndex
            columnIndex = dgvItemList.SelectedCells(0).ColumnIndex
            If dgvItemList.SelectedCells.Count > 0 Then
                Dim tempCell As DataGridViewComboBoxCell = dgvItemList.Item(columnIndex, rowIndex)
                Dim temp As String = editingComboBox.Text
                dgvItemList.Item(columnIndex, rowIndex).Selected = False
                dgvItemList.EndEdit(True)
                tempCell.Value = temp
            End If
        End If

        'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
        RemoveHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted
        'Re-enable the EditingControlShowing event so the above can take place.
        AddHandler dgvItemList.EditingControlShowing, AddressOf dgvItemList_EditingControlShowing
    End Sub

    Private Sub LoadWHSE(Optional ByVal SelectedIndex As Integer = -1)
        Try
            Dim dgvCB As New DataGridViewComboBoxCell
            dgvCB = dgvItemList.Item(chWHSE.Index, SelectedIndex)
            dgvCB.Items.Clear()
            ' ADD ALL WHSEc
            Dim query As String
            query = " SELECT Description FROM tblWarehouse WHERE Status ='Active' "
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            While SQL.SQLDR.Read
                dgvCB.Items.Add(SQL.SQLDR("Description").ToString)
            End While
            If dgvCB.Value <> Nothing AndAlso Not dgvCB.Items.Contains(dgvCB.Value) Then
                dgvCB.Items.Add(dgvCB.Value)
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("DR_EDIT") Then
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

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If DRNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblDR  WHERE DR_No < '" & DRNo & "' ORDER BY DR_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadDR(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If DRNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblDR  WHERE DR_No > '" & DRNo & "' ORDER BY DR_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadDR(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub


    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If DRNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadDR(TransID)
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

    Private Sub tsbCopyPO_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyPO.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("SO")
        LoadSO(f.transID)
        f.Dispose()
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("DR_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblDR SET Status ='Cancelled' WHERE TransID = @TransID "
                        SQL.FlushParams()
                        DRNo = txtTransNum.Text
                        SQL.AddParam("@TransID", TransID)
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

                        DRNo = txtTransNum.Text
                        LoadDR(TransID)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "DR_No", DRNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub frmDR_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode = Keys.C Then
                If tsbCopy.Enabled = True Then tsbCopy.ShowDropDown()
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

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If txtVCECode.Text = "" Then
            Msg("Please enter VCECode!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                DRNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = DRNo
                SaveDR()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                DRNo = txtTransNum.Text
                LoadDR(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateDR()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                DRNo = txtTransNum.Text
                LoadDR(TransID)
            End If
        End If
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrint.Click
        Dim f As New frmReport_Display
        f.ShowDialog("DR", TransID)
        f.Dispose()
    End Sub

    Private Sub dgvItemList_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvItemList.DataError
        Try

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub
End Class