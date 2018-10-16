Public Class frmUOMConversion
    Dim moduleID As String = "UOM"
    Dim disableEvent As Boolean = False
    Public LoadItem As Boolean = False
    Public itemCode, group As String

    Private Sub frmUOMConversion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If group = Nothing Then
            group = frmItem_Master.cbUoMGroup.Text
            itemCode = frmItem_Master.itemCode
        End If
        If group = "(Manual)" Then
            cbUoMGroup.Visible = False
            Label2.Visible = False
            cbUoMGroup.DropDownStyle = ComboBoxStyle.Simple
            cbUoMGroup.Enabled = False
            Label2.Text = "ItemCode:"
            btnNew.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False
            cbUoMGroup.DropDownStyle = ComboBoxStyle.Simple
            dgvAltUOM.Size = New Size(522, 240)
            dgvAltUOM.Location = New Point(3, 34)
            btnUOMBase.Location = New Point(500, 3)
            ClearData()
            ' Toolstrip Buttons
            dgvAltUOM.AllowUserToDeleteRows = True
            dgvAltUOM.Rows.Add()
            LoadAltUnits(0)
            dgvAltUOM.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            cbBaseUnit.Enabled = True
            cbUoMGroup.Select()
        Else
            cbUoMGroup.DropDownStyle = ComboBoxStyle.DropDown
            cbUoMGroup.Enabled = True
            cbUoMGroup.Visible = True
            Label2.Visible = True
            LoadGroupUOM()
            Label2.Text = "Group Code :"
            btnNew.Visible = True
            btnEdit.Visible = True
            btnDelete.Visible = True
            dgvAltUOM.Size = New Size(522, 177)
            dgvAltUOM.Location = New Point(3, 66)
            btnUOMBase.Location = New Point(258, 35)
            cbBaseUnit.Enabled = False
            dgvAltUOM.AllowUserToAddRows = False
            dgvAltUOM.AllowUserToDeleteRows = False
            dgvAltUOM.EditMode = DataGridViewEditMode.EditProgrammatically
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnUOMBase.Enabled = False
        End If
        LoadBaseUOM()
        cbUoMGroup.SelectedItem = group
        If LoadItem = True Then
            LoadUOM()
            LoadItem = False
        End If
    End Sub

    Private Sub LoadUOM()
        Dim query As String
        query = " SELECT UnitCodeFrom, '=' AS Equals, QTY, UnitCodeTo FROM tblUOM_GroupDetails WHERE  GroupCode ='" & itemCode & "' "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            disableEvent = True
            dgvAltUOM.Rows.Clear()
            Dim rowIndex As Integer = 0
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvAltUOM.Rows.Add({row.Item(0), row.Item(1), row.Item(2), row.Item(3)})
                LoadAltUnits(rowIndex)
                rowIndex += 1
            Next
            disableEvent = False
        Else
            dgvAltUOM.Rows.Clear()
        End If
    End Sub

    Private Sub LoadGroupUOM()
        Try
            Dim query As String
            query = " SELECT    GroupCode FROM tblUOM_Group " & _
                    " WHERE     Status = 'Active' AND Manual = 0 "
            SQL.ReadQuery(query)
            cbUoMGroup.Items.Clear()
            While SQL.SQLDR.Read
                cbUoMGroup.Items.Add(SQL.SQLDR("GroupCode").ToString)
            End While
            If cbUoMGroup.Items.Count > 0 AndAlso cbUoMGroup.Text <> "" Then
                cbUoMGroup.SelectedItem = cbUoMGroup.Text
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try
    End Sub

    Private Sub LoadBaseUOM()
        Try
            Dim query As String
            query = " SELECT    UnitCode, Description FROM tblUOM " & _
                    " WHERE     Status = 'Active' AND BaseUnit = 1 " 
            SQL.ReadQuery(query)
            cbBaseUnit.Items.Clear()
            While SQL.SQLDR.Read
                cbBaseUnit.Items.Add(SQL.SQLDR("UnitCode").ToString)
            End While
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try
    End Sub

    Private Sub ClearData()
        dgvAltUOM.Rows.Clear()
        cbUoMGroup.Text = ""
        cbBaseUnit.SelectedIndex = -1
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "New" Then
            cbUoMGroup.DropDownStyle = ComboBoxStyle.Simple
            ClearData()
            ' Toolstrip Buttons
            dgvAltUOM.AllowUserToAddRows = True
            dgvAltUOM.AllowUserToDeleteRows = True
            dgvAltUOM.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            cbBaseUnit.Enabled = True
            btnUOMBase.Enabled = True
            btnDelete.Enabled = True
            btnEdit.Enabled = False
            btnNew.Text = "Save"
            btnEdit.Text = "Edit"
            btnDelete.Text = "Cancel"
            btnEdit.Enabled = False
            cbUoMGroup.Select()
        Else
            If cbUoMGroup.Text = "" Then
                Msg("Please enter Group Code!", MsgBoxStyle.Exclamation)
            ElseIf cbBaseUnit.SelectedIndex = -1 Then
                Msg("Please select base unit for this group", MsgBoxStyle.Exclamation)
            Else
                If MsgBox("Saving New Group, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    SaveUOM()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)


                    LoadGroupUOM()
                    ' CONTROL PROPERTIES
                    dgvAltUOM.AllowUserToAddRows = False
                    dgvAltUOM.AllowUserToDeleteRows = False
                    dgvAltUOM.EditMode = DataGridViewEditMode.EditProgrammatically
                    cbBaseUnit.Enabled = False
                    cbUoMGroup.DropDownStyle = ComboBoxStyle.DropDownList
                    btnUOMBase.Enabled = False
                    btnDelete.Enabled = True
                    btnEdit.Enabled = True
                    btnNew.Text = "New"
                    btnEdit.Text = "Edit"
                    btnDelete.Text = "Delete"

                End If
            End If
            
        End If
        
    End Sub

    Private Sub SaveUOM()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = "  INSERT INTO " & _
                        "  tblUOM_Group (GroupCode, UnitCode, Manual, WhoCreated) " & _
                        "  VALUES(@GroupCode, @UnitCode, @Manual, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@GroupCode", cbUoMGroup.Text)
            SQL.AddParam("@UnitCode", cbBaseUnit.SelectedItem)
            If group = "Manual" Then
                SQL.AddParam("@Manual", True)
            Else
                SQL.AddParam("@Manual", False)
            End If
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "GroupCode", cbUoMGroup.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateUOM()
        Try
            activityStatus = True
            Dim updateSQL As String
            updateSQL = "  UPDATE tblUOM_Group " & _
                        "  SET    UnitCode = @UnitCode, WhoModified = @WhoModified, Manual = @Manual " & _
                        "  WHERE  GroupCode = @GroupCode     "
            SQL.FlushParams()
            SQL.AddParam("@GroupCode", cbUoMGroup.Text)
            SQL.AddParam("@UnitCode", cbBaseUnit.SelectedItem)
            If group = "Manual" Then
                SQL.AddParam("@Manual", True)
            Else
                SQL.AddParam("@Manual", False)
            End If

            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            Dim deleteSQL As String
            deleteSQL = " DELETE FROM tblUOM_GroupDetails WHERE GroupCode = @GroupCode "
            SQL.FlushParams()
            SQL.AddParam("@GroupCode", cbUoMGroup.Text)
            SQL.ExecNonQuery(deleteSQL)

            For Each row As DataGridViewRow In dgvAltUOM.Rows
                If row.Cells(chFromUoM.Index).Value <> Nothing Then
                    Dim insertSQL As String
                    insertSQL = " INSERT INTO " & _
                                " tblUOM_GroupDetails(GroupCode, UnitCodeFrom, QTY, UnitCodeTo, WhoCreated) " & _
                                " VALUES(@GroupCode, @UnitCodeFrom, @QTY, @UnitCodeTo, @WhoCreated)"
                    SQL.FlushParams()
                    SQL.AddParam("@GroupCode", cbUoMGroup.Text)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.AddParam("@UnitCodeFrom", row.Cells(chFromUoM.Index).Value.ToString)
                    If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso IsNumeric(row.Cells(chQTY.Index).Value) Then
                        SQL.AddParam("@QTY", row.Cells(chQTY.Index).Value)
                    Else
                        SQL.AddParam("@QTY", "1")
                    End If
                    SQL.AddParam("@UnitCodeTo", row.Cells(dgcToUOM.Index).Value.ToString)
                    SQL.ExecNonQuery(insertSQL)
                End If
            Next

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "GroupCode", cbUoMGroup.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub btnUOMBase_Click(sender As System.Object, e As System.EventArgs) Handles btnUOMBase.Click
        frmItem_UOM.ShowDialog()
        LoadBaseUOM()
        frmItem_UOM.Dispose()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If btnDelete.Text = "Cancel" Then

            LoadGroupUOM()

            ' CONTROL PROPERTIES
            dgvAltUOM.AllowUserToAddRows = False
            dgvAltUOM.AllowUserToDeleteRows = False
            dgvAltUOM.EditMode = DataGridViewEditMode.EditProgrammatically
            cbBaseUnit.Enabled = False
            cbUoMGroup.DropDownStyle = ComboBoxStyle.DropDownList
            cbBaseUnit.SelectedIndex = -1
            btnUOMBase.Enabled = False
            btnDelete.Enabled = False
            btnEdit.Enabled = False
            btnNew.Text = "New"
            btnEdit.Text = "Edit"
            btnDelete.Text = "Delete"
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            ' CONTROL PROPERTIES
            dgvAltUOM.AllowUserToAddRows = True
            dgvAltUOM.AllowUserToDeleteRows = True
            dgvAltUOM.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            cbBaseUnit.Enabled = True
            cbUoMGroup.DropDownStyle = ComboBoxStyle.DropDownList
            btnUOMBase.Enabled = True
            btnDelete.Enabled = True
            btnEdit.Enabled = True
            btnNew.Text = "New"
            btnEdit.Text = "Update"
            btnDelete.Text = "Cancel"
            LoadAltUnits()
        Else
            If MsgBox("Updating Item Information, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateUOM()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)


                LoadGroupUOM()
                ' CONTROL PROPERTIES
                dgvAltUOM.AllowUserToAddRows = False
                dgvAltUOM.AllowUserToDeleteRows = False
                dgvAltUOM.EditMode = DataGridViewEditMode.EditProgrammatically
                cbBaseUnit.Enabled = False
                cbUoMGroup.DropDownStyle = ComboBoxStyle.DropDownList
                btnUOMBase.Enabled = False
                btnDelete.Enabled = True
                btnEdit.Enabled = True
                btnNew.Text = "New"
                btnEdit.Text = "Edit"
                btnDelete.Text = "Delete"
            End If
        End If
    End Sub

    Private Sub LoadAltUnits(Optional ByVal SelectedIndex As Integer = -1)
        Try
            Dim toUOM(dgvAltUOM.Rows.Count) As String
            Dim dgvCBFrom, dgvCBTo As New DataGridViewComboBoxCell

            ' STORE  SELECTED UOM TO STRING
            Dim UOMfrom As String = dgvAltUOM.Item(chFromUoM.Index, SelectedIndex).Value

            ' MOVE USED FROM_UOM TO A STRING
            For Each item1 As DataGridViewRow In dgvAltUOM.Rows
                If dgvAltUOM.Item(chFromUoM.Index, item1.Index).Value <> Nothing Then
                    If dgvAltUOM.Item(chFromUoM.Index, item1.Index).Value = UOMfrom AndAlso item1.Index <> SelectedIndex Then
                        toUOM(item1.Index) = dgvAltUOM.Item(dgcToUOM.Index, item1.Index).Value
                    Else
                        toUOM(item1.Index) = ""
                    End If
                End If
            Next

            ' CLEAR SELECTED VALUES
            If SelectedIndex <> -1 Then
                dgvCBFrom = dgvAltUOM.Item(chFromUoM.Index, SelectedIndex)
                dgvCBTo = dgvAltUOM.Item(dgcToUOM.Index, SelectedIndex)
                dgvAltUOM.Item(chFromUoM.Index, SelectedIndex).Value = Nothing
            End If

            ' ADD ALL ALT UOM
            Dim query As String
            query = " SELECT    UnitCode FROM tblUOM " & _
                    " WHERE     Status = 'Active'  "
            SQL.ReadQuery(query)
            dgvCBFrom.Items.Clear()
            dgvCBTo.Items.Clear()
            While SQL.SQLDR.Read
                dgvCBFrom.Items.Add(SQL.SQLDR("UnitCode").ToString)
                dgvCBTo.Items.Add(SQL.SQLDR("UnitCode").ToString)
            End While

            ' MOVE STRING VALUE TO CELL
            If SelectedIndex <> -1 Then
                dgvAltUOM.Item(chFromUoM.Index, SelectedIndex).Value = UOMfrom
            End If

            ' REMOVE EXISTING VALUES
            'For i As Integer = dgvAltUOM.Rows.Count - 1 To 0 Step -1
            '    If UOMfrom <> Nothing AndAlso dgvCBTo.Items.Contains(UOMfrom) AndAlso SelectedIndex <> -1 AndAlso UOMfrom <> dgvCBTo.Items(i) Then
            '        dgvCBTo.Items.Remove(UOMfrom)
            '    End If
            'Next
            For i As Integer = dgvAltUOM.Rows.Count - 1 To 0 Step -1
                If UOMfrom <> Nothing AndAlso SelectedIndex <> -1 Then
                    If dgvCBTo.Items.Contains(UOMfrom) Then
                        dgvCBTo.Items.Remove(UOMfrom)
                    End If
                    If toUOM(i) <> "" Then
                        dgvCBTo.Items.Remove(toUOM(i))
                    End If

                End If

            Next
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try

    End Sub

    Private Sub dgvAltUOM_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAltUOM.CellClick
        If e.ColumnIndex = chFromUoM.Index Or e.ColumnIndex = dgcToUOM.Index Then
            If e.RowIndex <> -1 AndAlso dgvAltUOM.Rows.Count > 0 Then
                LoadAltUnits(e.RowIndex)
                Dim dgvCol As DataGridViewComboBoxColumn
                dgvCol = dgvAltUOM.Columns.Item(e.ColumnIndex)
                dgvAltUOM.BeginEdit(True)
                dgvCol.Selected = True
                DirectCast(dgvAltUOM.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)

            End If
        End If
    End Sub

    Private Sub dgvAltUOM_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvAltUOM.EditingControlShowing

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
        RemoveHandler dgvAltUOM.EditingControlShowing, AddressOf dgvAltUOM_EditingControlShowing
    End Sub

    Private Sub editingComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rowIndex, columnIndex As Integer
        'Get the editing control
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        If editingComboBox Is Nothing Then Exit Sub
        'Show your Message Boxes
        If editingComboBox.SelectedIndex <> -1 Then
            rowIndex = dgvAltUOM.SelectedCells(0).RowIndex
            columnIndex = dgvAltUOM.SelectedCells(0).ColumnIndex
            dgvAltUOM.Item(chQTY.Index, rowIndex).Value = 1
            dgvAltUOM.Item(chQTY.Index, rowIndex).Selected = True
            If dgvAltUOM.SelectedCells.Count > 0 Then
                Dim tempCell As DataGridViewComboBoxCell = dgvAltUOM.Item(columnIndex, rowIndex)
                Dim temp As String = editingComboBox.Text
                dgvAltUOM.Item(columnIndex, rowIndex).Selected = False
                dgvAltUOM.EndEdit(True)
                tempCell.Value = temp
                If rowIndex = dgvAltUOM.Rows.Count - 1 Then
                    If Not IsNothing(dgvAltUOM.Item(chFromUoM.Index, rowIndex).Value) AndAlso Not IsNothing(dgvAltUOM.Item(dgcToUOM.Index, rowIndex).Value) Then
                        dgvAltUOM.Rows.Add()
                    End If
                End If
                
            End If
        End If

        'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
        RemoveHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted
        'Re-enable the EditingControlShowing event so the above can take place.
        AddHandler dgvAltUOM.EditingControlShowing, AddressOf dgvAltUOM_EditingControlShowing
    End Sub


    Private Sub cbUoMGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbUoMGroup.SelectedIndexChanged
        If cbUoMGroup.SelectedIndex <> -1 Then
            LoadGroupDetails(cbUoMGroup.SelectedItem)
        End If
    End Sub

    Private Sub LoadGroupDetails(ByVal GroupCode As String)

        LoadBaseUOM()
        Dim query As String
        ' LOAD BASE UNIT
        query = "SELECT UnitCode FROM tblUOM_Group WHERE  GroupCode ='" & GroupCode & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            cbBaseUnit.SelectedItem = SQL.SQLDR("UnitCode").ToString
        End If

        ' LOAD ALT UNIT
        query = " SELECT UnitCodeFrom, '=' AS Equals, QTY, UnitCodeTo FROM tblUOM_GroupDetails WHERE GroupCode ='" & GroupCode & "' "
        SQL.GetQuery(query)
        disableEvent = True
        dgvAltUOM.Rows.Clear()
        disableEvent = False
        Dim rowIndex As Integer = 0
        For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
            dgvAltUOM.Rows.Add({row.Item(0), row.Item(1), row.Item(2), row.Item(3)})
            LoadAltUnits(rowIndex)
            rowIndex += 1
        Next
        If GroupCode = "(Manual)" Then
            If dgvAltUOM.Rows.Count = 0 Then
                dgvAltUOM.Rows.Add()
            End If
        End If

      

        ' CONTROL PROPERTIES
        dgvAltUOM.AllowUserToAddRows = False
        dgvAltUOM.AllowUserToDeleteRows = False
        dgvAltUOM.EditMode = DataGridViewEditMode.EditProgrammatically
        cbBaseUnit.Enabled = False
        cbUoMGroup.DropDownStyle = ComboBoxStyle.DropDownList
        btnUOMBase.Enabled = False
        btnDelete.Enabled = True
        btnEdit.Enabled = True
        btnNew.Text = "New"
        btnEdit.Text = "Edit"
        btnDelete.Text = "Delete"
    End Sub

    Private Sub frmUOMConversion_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If group = "(Manual)" Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub dgvAltUOM_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvAltUOM.DataError
        Try

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try
    End Sub

    Private Sub dgvAltUOM_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvAltUOM.RowsRemoved
        If disableEvent = False Then
            If dgvAltUOM.Rows.Count = 0 Then
                dgvAltUOM.Rows.Add()
            End If
        End If
      
    End Sub
End Class