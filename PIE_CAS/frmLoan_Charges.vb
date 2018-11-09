Public Class frmLoan_Charges
    Dim ModuleID As String = "LC"
   
#Region "SUBS"
    Private Sub LoadRecords()
        Dim query As String
        query = " SELECT    Description, Method, ISNULL(Value,0) AS Value,  Amortize, DefaultAccount " & _
                " FROM      tblLoan_ChargesDefault " & _
                " WHERE     Status ='Active' " & _
                " ORDER BY  SortNum "
        SQL.GetQuery(query)
        dgvRecords.Rows.Clear()
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvRecords.Rows.Add(row.Item(0).ToString, row.Item(1), row.Item(2).ToString, row.Item(3), row.Item(4).ToString, GetAccntTitle(row.Item(4).ToString))
            Next
        End If
    End Sub

    Private Sub LoadMethod()
        Try
            Dim dgvCB As New DataGridViewComboBoxColumn
            dgvCB = dgvRecords.Columns(dgcMethod.Index)
            dgvCB.Items.Clear()
            dgvCB.Items.Add("Amount")
            dgvCB.Items.Add("Percentage")
            dgvCB.Items.Add("Range Table")
            dgvCB.Items.Add("Formula")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Function HasEmptyRecord() As Boolean
        Dim rowInd As Integer = -1
        For Each row As DataGridViewRow In dgvRecords.Rows
            If IsNothing(row.Cells(dgcDesc.Index).Value) OrElse row.Cells(dgcDesc.Index).Value = "" Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 150)
                rowInd = row.Index
                Exit For
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
        If rowInd <> -1 Then
            If dgvRecords.SelectedCells.Count > 0 Then
                dgvRecords.SelectedCells(0).Selected = False
            End If
            dgvRecords.Item(dgcDesc.Index, rowInd).Selected = True
            dgvRecords.BeginEdit(True)
        End If
        If rowInd = -1 Then Return True Else Return False
    End Function
#End Region

#Region "CONTROL EVENTS"
    Private Sub frmLoan_Charges_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dgvRecords.ReadOnly = False
        LoadMethod()
        LoadRecords()
        HasEmptyRecord()
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If HasEmptyRecord() Then
            dgvRecords.Rows.Add()
            HasEmptyRecord
        End If
    End Sub

    Private Sub dgvRecords_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRecords.DataError
        Try
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvRecords_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecords.CellEndEdit
        With dgvRecords
            If e.ColumnIndex = dgcDesc.Index Then
                If .Item(e.ColumnIndex, e.RowIndex).Value <> "" Then
                    .Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                Else
                    .Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 150)
                End If
            ElseIf e.ColumnIndex = dgcTitle.Index Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", .Item(e.ColumnIndex, e.RowIndex).Value)
                .Item(dgcCode.Index, e.RowIndex).Value = f.accountcode
                .Item(dgcTitle.Index, e.RowIndex).Value = f.accttile
                f.Dispose()
            End If
        End With
    End Sub

    Private Sub dgvRecords_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRecords.EditingControlShowing
        ' GET THE EDITING CONTROL
        Dim editingComboBox As ComboBox = TryCast(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            ' REMOVE AN EXISTING EVENT-HANDLER TO AVOID ADDING MULTIPLE HANDLERS WHEN THE EDITING CONTROL IS REUSED
            RemoveHandler editingComboBox.SelectionChangeCommitted, New EventHandler(AddressOf editingComboBox_SelectionChangeCommitted)

            ' ADD THE EVENT HANDLER
            AddHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted

            ' PREVENT THIS HANDLER FROM FIRING TWICE
            RemoveHandler dgvRecords.EditingControlShowing, AddressOf dgvRecords_EditingControlShowing
        End If
    End Sub

    Private Sub editingComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rowIndex, columnIndex As Integer
        'Get the editing control
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        If editingComboBox Is Nothing Then Exit Sub
        'Show your Message Boxes
        If editingComboBox.SelectedIndex <> -1 Then
            rowIndex = dgvRecords.SelectedCells(0).RowIndex
            columnIndex = dgvRecords.SelectedCells(0).ColumnIndex
            If dgvRecords.SelectedCells.Count > 0 Then
                Dim tempCell As DataGridViewComboBoxCell = dgvRecords.Item(columnIndex, rowIndex)
                Dim temp As String = editingComboBox.Text
                dgvRecords.Item(columnIndex, rowIndex).Selected = False
                dgvRecords.EndEdit(True)
                tempCell.Value = temp
                If tempCell.Value = "Range Table" Then
                    dgvRecords.Rows(rowIndex).Cells(dgcValue.Index) = New DataGridViewButtonCell
                Else
                    dgvRecords.Rows(rowIndex).Cells(dgcValue.Index) = New DataGridViewTextBoxCell
                End If
            End If
        End If

        'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
        RemoveHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted
        'Re-enable the EditingControlShowing event so the above can take place.
        AddHandler dgvRecords.EditingControlShowing, AddressOf dgvRecords_EditingControlShowing
    End Sub


    Private Sub dgvRecords_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRecords.RowHeaderMouseClick
        If dgvRecords.SelectedRows.Count > 0 Then
            tsbDelete.Enabled = True
        Else
            tsbDelete.Enabled = False
        End If
    End Sub

    Private Sub dgvRecords_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecords.CellClick
        If dgvRecords.SelectedRows.Count > 0 Then
            tsbDelete.Enabled = True
        Else
            tsbDelete.Enabled = False
        End If
    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click
        If dgvRecords.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvRecords.SelectedRows
                dgvRecords.Rows.Remove(row)
            Next
        End If
    End Sub

    Private Sub dgvRecords_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecords.CellContentClick
        If e.ColumnIndex = dgcValue.Index AndAlso dgvRecords.Item(dgcMethod.Index, e.RowIndex).Value = "Range Table" Then
            frmLoan_ChargesRangeDef.ShowDialog()
            frmLoan_ChargesRangeDef.Dispose()
        End If
    End Sub
#End Region

   
   
End Class