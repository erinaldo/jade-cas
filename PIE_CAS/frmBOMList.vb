Public Class frmBOMList
    Dim Code As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "BOM"
    Dim TransAuto As Boolean

    Private Sub frmBOM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadItem()
        Clear()
        EnableControl(False)
    End Sub

    Private Sub LoadItem()
        Dim query As String
        query = " SELECT BOM_Code, tblBOM_Maintenance_Header.ItemCode, ItemName, tblBOM_Maintenance_Header.UOM, tblBOM_Maintenance_Header.QTY " & _
                " FROM   tblBOM_Maintenance_Header INNER JOIN tblItem_Master " & _
                " ON     tblBOM_Maintenance_Header.ItemCode = tblItem_Master.ItemCode " & _
                " AND    tblItem_Master.Status ='Active' " & _
                " WHERE  tblBOM_Maintenance_Header.Status ='Active'"
        SQL.ReadQuery(query)
        lvList.Items.Clear()
        While SQl.SQLDR.Read()
            lvList.Items.Add(SQL.SQLDR("BOM_Code").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("ItemCode").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("ItemName").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("UOM").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("QTY").ToString)
        End While
    End Sub

    Private Sub Clear()
        txtCode.Clear()
        txtItemCode.Clear()
        txtItemName.Clear()
        txtDescription.Clear()
        txtQTY.Clear()
        cbUOM.SelectedIndex = -1
        dgvItemMaster.Rows.Clear()
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtItemName.Enabled = Value
        txtQTY.Enabled = Value
        txtDescription.Enabled = Value
        cbUOM.Enabled = Value
        dgvItemMaster.Enabled = Value
    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmCopyFrom
            f.ShowDialog("All Item", txtItemName.Text)
            txtItemCode.Text = f.TransID
            txtItemName.Text = GetItemName(txtItemCode.Text)
            LoadUOM(txtItemCode.Text)
            txtQTY.Select()
            f.Dispose()
        End If
    End Sub

    Private Sub LoadUOM(ByVal ItemCode As String)
        Dim query As String
        query = " SELECT viewItem_UOM.UnitCode " & _
                " FROM   tblItem_Master INNER JOIN viewItem_UOM " & _
                " ON     tblItem_Master.ItemUOMGroup = viewItem_UOM.GroupCode OR tblItem_Master.ItemCode = viewItem_UOM.GroupCode   " & _
                " WHERE  ItemCode ='" & ItemCode & "' "
        SQL.ReadQuery(query)
        cbUOM.Items.Clear()
        While SQL.SQLDR.Read
            cbUOM.Items.Add(SQL.SQLDR("UnitCode").ToString)
        End While
        If cbUOM.Items.Count > 0 Then
            cbUOM.SelectedIndex = 0
        End If
    End Sub


    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Clear()
        EnableControl(True)
        txtCode.Text = GenerateCode()
        btnSave.Text = "Save"
        txtCode.Focus()
    End Sub

    Private Sub LoadItemDetails(ByVal ItemCode As String)
        Dim query As String
        query = " SELECT    ItemCategory, ItemGroup, ItemCode, ItemName, ItemUOM, 1 " & _
                " FROM      tblItem_Master " & _
                " WHERE     ItemCode = @ItemCode"
        SQL.FlushParams()
        SQL.AddParam("@ItemCode", IIf(ItemCode = Nothing, "", ItemCode))
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            If dgvItemMaster.SelectedCells.Count > 0 Then
                dgvItemMaster.Item(0, dgvItemMaster.SelectedCells(0).RowIndex).Value = ""
                dgvItemMaster.Item(1, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemCategory").ToString
                dgvItemMaster.Item(2, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemGroup").ToString
                dgvItemMaster.Item(3, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemCode").ToString
                dgvItemMaster.Item(4, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemName").ToString
                dgvItemMaster.Item(5, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemUOM").ToString
                dgvItemMaster.Item(6, dgvItemMaster.SelectedCells(0).RowIndex).Value = 1
                LoadUOM(SQL.SQLDR("ItemCode").ToString, dgvItemMaster.SelectedCells(0).RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvItemMaster_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemMaster.CellEndEdit
        Dim itemCode As String
        Dim rowIndex As Integer = dgvItemMaster.CurrentCell.RowIndex
        Dim colindex As Integer = dgvItemMaster.CurrentCell.ColumnIndex
        Select Case colindex
            Case chBOMItemCode.Index
                If dgvItemMaster.Item(chBOMItemCode.Index, e.RowIndex).Value <> "" Then
                    itemCode = dgvItemMaster.Item(chBOMItemCode.Index, e.RowIndex).Value
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
            Case chBOMItemName.Index
                If dgvItemMaster.Item(chBOMItemName.Index, e.RowIndex).Value <> "" Then
                    itemCode = dgvItemMaster.Item(chBOMItemName.Index, e.RowIndex).Value
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
            Case dgcItemGroup.Index
                If dgvItemMaster.Item(dgcItemGroup.Index, e.RowIndex).Value <> "" Then
                    itemCode = dgvItemMaster.Item(dgcItemGroup.Index, e.RowIndex).Value
                    Dim f As New frmCopyFrom
                    f.ShowDialog("ItemGroup", itemCode)
                    If f.TransID <> "" Then
                        itemCode = f.TransID
                        dgvItemMaster.Item(0, dgvItemMaster.SelectedCells(0).RowIndex).Value = ""
                        dgvItemMaster.Item(1, dgvItemMaster.SelectedCells(0).RowIndex).Value = ""
                        dgvItemMaster.Item(2, dgvItemMaster.SelectedCells(0).RowIndex).Value = itemCode
                        dgvItemMaster.Item(3, dgvItemMaster.SelectedCells(0).RowIndex).Value = ""
                        dgvItemMaster.Item(4, dgvItemMaster.SelectedCells(0).RowIndex).Value = ""
                        dgvItemMaster.Item(5, dgvItemMaster.SelectedCells(0).RowIndex).Value = f.ItemCode
                        dgvItemMaster.Item(6, dgvItemMaster.SelectedCells(0).RowIndex).Value = 1
                        LoadUOM("", dgvItemMaster.SelectedCells(0).RowIndex, itemCode)
                    Else
                        dgvItemMaster.Rows.RemoveAt(e.RowIndex)
                    End If
                    f.Dispose()
                End If
        End Select
    End Sub

    Public Sub SaveHeader(ByVal Code As String)
        Try
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblBOM_Maintenance_Header (BOM_Code, ItemCode, UOM, QTY, Remarks, WhoCreated) " & _
                        " VALUES (@BOM_Code,  @ItemCode,  @UOM, @QTY, @Remarks, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@BOM_Code", Code)
            SQL.AddParam("@ItemCode", txtItemCode.Text)
            SQL.AddParam("@UOM", cbUOM.SelectedItem)
            SQL.AddParam("@QTY", IIf(Not IsNumeric(txtQTY.Text), 0, CDec(txtQTY.Text)))
            SQL.AddParam("@Remarks", txtDescription.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
            SaveDetails(Code)
            SaveLabor(Code)
            SaveOverhead(Code)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "BOM_Code", Code, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Public Sub UpdateHeader(ByVal Code As String)
        Try
            Dim insertSQL As String
            insertSQL = " UPDATE tblBOM_Maintenance_Header " & _
                        " SET    ItemCode = @ItemCode, UOM = @UOM, QTY = @QTY, Remarks = @Remarks, WhoModified = @WhoModified " & _
                        " WHERE  BOM_Code = @BOM_Code "
            SQL.FlushParams()
            SQL.AddParam("@BOM_Code", Code)
            SQL.AddParam("@ItemCode", txtItemCode.Text)
            SQL.AddParam("@UOM", cbUOM.SelectedItem)
            SQL.AddParam("@QTY", IIf(Not IsNumeric(txtQTY.Text), 0, CDec(txtQTY.Text)))
            SQL.AddParam("@Remarks", txtDescription.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(insertSQL)

            SaveDetails(Code)
            SaveLabor(Code)
            SaveOverhead(Code)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "BOM_Code", Code, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub SaveDetails(ByVal Code As String)
        Dim deleteSQL As String
        deleteSQL = " DELETE FROM tblBOM_Maintenance_Details WHERE BOM_Code = '" & Code & "' "
        SQL.ExecNonQuery(deleteSQL)

        Dim insertSQL As String
        Dim line As Integer = 1
        For Each row As DataGridViewRow In dgvItemMaster.Rows
            If Not row.Cells(chBOMItemCode.Index).Value = Nothing Or Not row.Cells(dgcItemGroup.Index).Value = Nothing Then

                insertSQL = " INSERT INTO " & _
                            " tblBOM_Maintenance_Details(BOM_Code, BOM_Group, MaterialCode, UOM, QTY, LineNumber) " & _
                            " VALUES (@BOM_Code, @BOM_Group, @MaterialCode, @UOM, @QTY, @LineNumber) "
                SQL.FlushParams()
                SQL.AddParam("@BOM_Code", Code)
                SQL.AddParam("@BOM_Group", IIf(row.Cells(dgcItemGroup.Index).Value = Nothing, "", row.Cells(dgcItemGroup.Index).Value))
                SQL.AddParam("@MaterialCode", IIf(row.Cells(chBOMItemCode.Index).Value = Nothing, "", row.Cells(chBOMItemCode.Index).Value))
                SQL.AddParam("@UOM", IIf(row.Cells(chBOMUOM.Index).Value = Nothing, "", row.Cells(chBOMUOM.Index).Value))
                SQL.AddParam("@QTY", IIf(row.Cells(chBOMQTY.Index).Value = Nothing, 0, row.Cells(chBOMQTY.Index).Value))
                SQL.AddParam("@LineNumber", line)
                SQL.ExecNonQuery(insertSQL)
                line += 1
            End If
        Next
    End Sub

    Private Sub SaveLabor(ByVal Code As String)
        Dim deleteSQL As String
        deleteSQL = " DELETE FROM tblBOM_Labor WHERE BOMCode = '" & Code & "' "
        SQL.ExecNonQuery(deleteSQL)

        Dim insertSQL As String
        Dim line As Integer = 1
        For Each row As DataGridViewRow In dgvLabor.Rows
            If Not row.Cells(dgcDLactivity.Index).Value = Nothing Then

                insertSQL = " INSERT INTO " & _
                            " tblBOM_Labor(BOMCode, Activity, RatePerHour, CrewNum, TimeMins, TotalMins, TotalCost, WhoCreated, LineNumber) " & _
                            " VALUES (@BOMCode, @Activity, @RatePerHour, @CrewNum, @TimeMins, @TotalMins, @TotalCost, @WhoCreated, @LineNumber) "
                SQL.FlushParams()
                SQL.AddParam("@BOMCode", Code)
                SQL.AddParam("@Activity", IIf(row.Cells(dgcDLactivity.Index).Value = Nothing, "", row.Cells(dgcDLactivity.Index).Value))
                SQL.AddParam("@RatePerHour", IIf(row.Cells(dgcDLrate.Index).Value = Nothing, 0, row.Cells(dgcDLrate.Index).Value))
                SQL.AddParam("@CrewNum", IIf(row.Cells(dgcDLcrewNo.Index).Value = Nothing, 0, row.Cells(dgcDLcrewNo.Index).Value))
                SQL.AddParam("@TimeMins", IIf(row.Cells(dgcDLtime.Index).Value = Nothing, 0, row.Cells(dgcDLtime.Index).Value))
                SQL.AddParam("@TotalMins", IIf(row.Cells(dgcDLTotalMins.Index).Value = Nothing, 0, row.Cells(dgcDLTotalMins.Index).Value))
                SQL.AddParam("@TotalCost", IIf(row.Cells(dgcDLtotalCost.Index).Value = Nothing, 0, row.Cells(dgcDLtotalCost.Index).Value))
                SQL.AddParam("@WhoCreated", UserID)
                SQL.AddParam("@LineNumber", line)
                SQL.ExecNonQuery(insertSQL)
                line += 1
            End If
        Next
    End Sub

    Private Sub SaveOverhead(ByVal Code As String)
        Dim deleteSQL As String
        deleteSQL = " DELETE FROM tblBOM_Overhead WHERE BOMCode = '" & Code & "' "
        SQL.ExecNonQuery(deleteSQL)

        Dim insertSQL As String
        Dim line As Integer = 1
        For Each row As DataGridViewRow In dgvOverhead.Rows
            If Not row.Cells(dgcFOactivity.Index).Value = Nothing Then
                insertSQL = " INSERT INTO " & _
                            " tblBOM_Overhead(BOMCode, Activity, Machine, RatePerHour, KW, NumHours, TotalKWH, TotalCost, WhoCreated, LineNumber) " & _
                            " VALUES (@BOMCode, @Activity, @Machine, @RatePerHour, @KW, @NumHours, @TotalKWH, @TotalCost, @WhoCreated, @LineNumber) "
                SQL.FlushParams()
                SQL.AddParam("@BOMCode", Code)
                SQL.AddParam("@Activity", IIf(row.Cells(dgcFOactivity.Index).Value = Nothing, "", row.Cells(dgcFOactivity.Index).Value))
                SQL.AddParam("@Machine", IIf(row.Cells(dgcFOmachine.Index).Value = Nothing, "", row.Cells(dgcFOmachine.Index).Value))
                SQL.AddParam("@RatePerHour", IIf(row.Cells(dgcFOrate.Index).Value = Nothing, 0, row.Cells(dgcFOrate.Index).Value))
                SQL.AddParam("@KW", IIf(row.Cells(dgcFOKW.Index).Value = Nothing, 0, row.Cells(dgcFOKW.Index).Value))
                SQL.AddParam("@NumHours", IIf(row.Cells(dgcFOhrs.Index).Value = Nothing, 0, row.Cells(dgcFOhrs.Index).Value))
                SQL.AddParam("@TotalKWH", IIf(row.Cells(dgcFOtotalKWH.Index).Value = Nothing, 0, row.Cells(dgcFOtotalKWH.Index).Value))
                SQL.AddParam("@TotalCost", IIf(row.Cells(dgcFOcost.Index).Value = Nothing, 0, row.Cells(dgcFOcost.Index).Value))
                SQL.AddParam("@WhoCreated", UserID)
                SQL.AddParam("@LineNumber", line)
                SQL.ExecNonQuery(insertSQL)
                line += 1
            End If
        Next
    End Sub

    Private Function GenerateCode() As String
        Dim query As String
        query = " SELECT   LEFT('BOM',3) + Cast(Max(Cast(REPLACE(BOM_Code, LEFT(BOM_Code,3), '')as int)+1) as nvarchar) AS BOM_Code " & _
                " FROM     tblBOM_Maintenance_Header "
        SQL.FlushParams()
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("BOM_Code")) Then
            Return SQL.SQLDR("BOM_Code").ToString
        Else
            Return "BOM1"
        End If
    End Function

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtItemCode.Text = "" Or txtItemName.Text = "" Or txtQTY.Text = "" Or txtCode.Text = "" Then
            MsgBox("Fill up required fieilds!", MsgBoxStyle.Information)
        Else
            If btnSave.Text = "Save" Then
                SaveHeader(txtCode.Text)
                Clear()
                EnableControl(False)
                LoadItem()
                MsgBox("Saved Successfully!", MsgBoxStyle.Information)
            ElseIf btnSave.Text = "Update" Then
                UpdateHeader(txtCode.Text)
                Clear()
                EnableControl(False)
                LoadItem()
                MsgBox("Update Successfully!", MsgBoxStyle.Information)
            End If
        End If
    End Sub



    Private Sub lvList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvList.SelectedIndexChanged
        If lvList.SelectedItems.Count > 0 Then
            txtCode.Text = lvList.SelectedItems(0).SubItems(0).Text
            LoadHeader(txtCode.Text)
            LoadDetails(txtCode.Text)
            LoadLabor(txtCode.Text)
            LoadOverhead(txtCode.Text)
            EnableControl(True)
            btnSave.Text = "Update"
            txtCode.Focus()
        End If
    End Sub

    Public Sub LoadHeader(ByVal Code As String)
        Dim query As String
        query = " SELECT BOM_Code, tblBOM_Maintenance_Header.ItemCode, ItemName, tblBOM_Maintenance_Header.UOM, tblBOM_Maintenance_Header.QTY, tblBOM_Maintenance_Header.Remarks " & _
                " FROM   tblBOM_Maintenance_Header INNER JOIN tblItem_Master " & _
                " ON     tblBOM_Maintenance_Header.ItemCode = tblItem_Master.ItemCode " & _
                " AND    tblItem_Master.Status ='Active' " & _
                " WHERE  tblBOM_Maintenance_Header.Status ='Active'" & _
                " AND    BOM_Code = '" & Code & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read() Then
            Dim uom As String
            txtCode.Text = SQL.SQLDR("BOM_Code").ToString
            txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
            txtItemName.Text = SQL.SQLDR("ItemName").ToString
            uom = SQL.SQLDR("UOM").ToString
            txtQTY.Text = SQL.SQLDR("QTY").ToString
            txtDescription.Text = SQL.SQLDR("Remarks").ToString
            LoadUOM(txtItemCode.Text)
            cbUOM.SelectedItem = uom
        End If
    End Sub

    Public Sub LoadDetails(ByVal Code As String)
        Dim query As String
        Dim ctr As Integer = 0
        query = " SELECT   RecordID, ItemCategory, BOM_Group, MaterialCode, ItemName, UOM, QTY" & _
                " FROM     tblBOM_Maintenance_Details LEFT JOIN tblItem_Master " & _
                " ON       tblBOM_Maintenance_Details.MaterialCode = tblItem_Master.ItemCode " & _
                " AND      tblItem_Master.Status ='Active' " & _
                " WHERE    BOM_Code = '" & Code & "'" & _
                " ORDER BY LineNumber "
        SQL.GetQuery(query)
        dgvItemMaster.Rows.Clear()
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvItemMaster.Rows.Add(New String() {row(0).ToString, _
                                             row(1).ToString, _
                                             row(2).ToString, _
                                             row(3).ToString, _
                                             row(4).ToString, row(5).ToString, row(6).ToString})
                LoadUOM(row(3).ToString, ctr, row(2).ToString)
                ctr += 1
            Next

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

    Private Sub dgvItemMaster_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemMaster.CellClick
        If e.ColumnIndex = chBOMUOM.Index Then
            If e.RowIndex <> -1 AndAlso dgvItemMaster.Rows.Count > 0 Then
                If dgvItemMaster.Item(chBOMItemCode.Index, e.RowIndex).Value <> Nothing Then
                    LoadUOM(dgvItemMaster.Item(chBOMItemCode.Index, e.RowIndex).Value.ToString, e.RowIndex)
                ElseIf dgvItemMaster.Item(dgcItemGroup.Index, e.RowIndex).Value <> Nothing Then
                    LoadUOM("", e.RowIndex, dgvItemMaster.Item(dgcItemGroup.Index, e.RowIndex).Value.ToString)
                End If

                Dim dgvCol As DataGridViewComboBoxColumn
                dgvCol = dgvItemMaster.Columns.Item(e.ColumnIndex)
                dgvItemMaster.BeginEdit(True)
                dgvCol.Selected = True
                DirectCast(dgvItemMaster.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)

            End If
        End If
    End Sub

    Private Sub dgvItemMaster_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvItemMaster.EditingControlShowing
        'Get the Editing Control. I personally prefer Trycast for this as it will not throw an error
        Dim editingComboBox As ComboBox = TryCast(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            ' Remove an existing event-handler, if present, to avoid 
            ' adding multiple handlers when the editing control is reused.
            RemoveHandler editingComboBox.SelectionChangeCommitted, New EventHandler(AddressOf editingComboBox_SelectionChangeCommitted)

            ' Add the event handler. 
            AddHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted
        End If

        'Prevent this event from firing twice, as is normally the case.
        RemoveHandler dgvItemMaster.EditingControlShowing, AddressOf dgvItemMaster_EditingControlShowing
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

    Private Sub LoadUOM(ItemCode As String, ByVal SelectedIndex As Integer, Optional ByVal Group As String = "")
        Try
            Dim dgvCB As New DataGridViewComboBoxCell
            dgvCB = dgvItemMaster.Item(chBOMUOM.Index, SelectedIndex)
            dgvCB.Items.Clear()
            ' ADD ITEM UOM
            Dim query As String
            If ItemCode <> "" Then
                query = " SELECT    DISTINCT viewItem_UOM.UnitCode " & _
                  " FROM      tblItem_Master INNER JOIN viewItem_UOM " & _
                  " ON        tblItem_Master.ItemUOMGroup = viewItem_UOM.GroupCode " & _
                  " OR        tblItem_Master.ItemCode = viewItem_UOM.GroupCode " & _
                  " WHERE     ItemCode ='" & ItemCode & "'  "
            Else
                query = " SELECT    UOM AS UnitCode " & _
                        " FROM      tblBOM_Group " & _
                        " WHERE     BOMGroup ='" & Group & "'  "
            End If
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            While SQL.SQLDR.Read
                dgvCB.Items.Add(SQL.SQLDR("UnitCode").ToString)
            End While
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvItemMaster_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvItemMaster.DataError
        Try

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvLabor_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabor.CellEndEdit
        Dim rowIndex As Integer = dgvLabor.CurrentCell.RowIndex
        ComputeTotalmins(rowIndex)
        ComputeDLCost(rowIndex)
    End Sub

    Private Sub ComputeTotalmins(ByVal rowID As Integer)
        If rowID >= 0 Then
            With dgvLabor.Rows(rowID)
                If IsNumeric(.Cells(dgcDLcrewNo.Index).Value) AndAlso IsNumeric(.Cells(dgcDLtime.Index).Value) Then
                    .Cells(dgcDLTotalMins.Index).Value = CDec(.Cells(dgcDLcrewNo.Index).Value) * CDec(.Cells(dgcDLtime.Index).Value)
                End If
            End With
        End If
    End Sub

    Private Sub ComputeDLCost(ByVal rowID As Integer)
        If rowID >= 0 Then
            With dgvLabor.Rows(rowID)
                If IsNumeric(.Cells(dgcDLrate.Index).Value) AndAlso IsNumeric(.Cells(dgcDLTotalMins.Index).Value) Then
                    .Cells(dgcDLtotalCost.Index).Value = CDec(.Cells(dgcDLrate.Index).Value) * CDec(.Cells(dgcDLTotalMins.Index).Value)
                End If
            End With
        End If
    End Sub

    Private Sub ComputeKWH(ByVal rowID As Integer)
        If rowID >= 0 Then
            With dgvOverhead.Rows(rowID)
                If IsNumeric(.Cells(dgcFOhrs.Index).Value) AndAlso IsNumeric(.Cells(dgcFOKW.Index).Value) Then
                    .Cells(dgcFOtotalKWH.Index).Value = CDec(.Cells(dgcFOhrs.Index).Value) * CDec(.Cells(dgcFOKW.Index).Value)
                End If
            End With
        End If
    End Sub

    Private Sub ComputeFOCost(ByVal rowID As Integer)
        If rowID >= 0 Then
            With dgvOverhead.Rows(rowID)
                If IsNumeric(.Cells(dgcFOtotalKWH.Index).Value) AndAlso IsNumeric(.Cells(dgcFOrate.Index).Value) Then
                    .Cells(dgcFOcost.Index).Value = CDec(.Cells(dgcFOtotalKWH.Index).Value) * CDec(.Cells(dgcFOrate.Index).Value)
                End If
            End With
        End If
    End Sub

    Private Sub dgvOverhead_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOverhead.CellEndEdit
        Dim rowIndex As Integer = dgvOverhead.CurrentCell.RowIndex
        ComputeKWH(rowIndex)
        ComputeFOCost(rowIndex)
    End Sub

End Class