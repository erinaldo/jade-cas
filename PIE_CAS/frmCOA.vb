Public Class frmCOA
    Dim lastNodeIndex As Integer = -1
    Dim rowIndexFromMouseDown As Integer
    Dim rw As DataGridViewRow
    Dim moveItem As Boolean = False

    Private Sub frmCOA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbType.SelectedItem = "Balance Sheet"
    End Sub

    Private Function GetHierarchy(ByVal Account As String) As Integer
        Dim query As String
        query = " SELECT Hierarchy FROM tblCOA_AccountGroup WHERE AccountGroup ='" & Account & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Hierarchy").ToString
        Else
            Return 0
        End If
    End Function

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        frmCOA_Add.cbType.SelectedItem = cbType.SelectedItem
        If dgvPreview.SelectedRows.Count = 1 Then
            frmCOA_Add.ShowDialog("", dgvPreview.SelectedRows(0).Cells(chGroup.Index).Value.ToString)
        Else
            frmCOA_Add.ShowDialog()
        End If

    End Sub

    Private Sub cbType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbType.SelectedIndexChanged
        If cbType.SelectedIndex <> -1 Then
            LoadAccounts()
        End If
    End Sub

    Public Sub LoadAccounts()
        If cbType.SelectedIndex <> -1 Then
            Dim query As String
            query = " SELECT	AccountCode, AccountTitle,  AccountNature, Hierarchy, ReportAlias, tblCOA_Master.AccountGroup " & _
                    " FROM	    tblCOA_Master INNER JOIN tblCOA_AccountGroup " & _
                    " ON		tblCOA_Master.AccountGroup = tblCOA_AccountGroup.AccountGroup " & _
                    " WHERE     AccountType ='" & cbType.SelectedItem & "' " & _
                    " ORDER BY  OrderNo "
            SQL.GetQuery(query)
            dgvPreview.Rows.Clear()
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                dgvPreview.Rows.Clear()
                Dim code, title, nature, group As String
                Dim tabCount As Integer = 0
                For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                    code = row.Item(0).ToString
                    title = row.Item(1).ToString
                    nature = row.Item(2).ToString
                    group = row.Item(5).ToString
                    tabCount = row.Item(3) - 1
                    If tabCount > 0 Then
                        For i As Integer = 1 To tabCount
                            title = "   " & title
                        Next
                    End If
                    If nature <> "" Then
                        If nature = "Debit" Then
                            title = title & "                                                                                                 "
                            title = Strings.Left(title, 95)
                            title = title & "####.##"
                        Else
                            title = title & "                                                                                                                "
                            title = Strings.Left(title, 105)
                            title = title & "####.##"
                        End If
                    End If
                    dgvPreview.Rows.Add({code, title, group})
                Next
            End If
        End If
    End Sub

    Private Sub btnUp_Click(sender As System.Object, e As System.EventArgs) Handles btnUp.Click
        MoveAccount("UP")
    End Sub

    Private Sub btnDown_Click(sender As System.Object, e As System.EventArgs) Handles btnDown.Click
        MoveAccount("DOWN")
    End Sub

    Private Sub MoveAccount(ByVal Type As String)
        If dgvPreview.SelectedRows.Count = 1 Then
            lastNodeIndex = -1
            Dim rowIndexOfItemUnderMouseToDrop As Integer
            lastNodeIndex = dgvPreview.SelectedRows(0).Index
            rw = dgvPreview.SelectedRows(0)
            rowIndexFromMouseDown = dgvPreview.SelectedRows(0).Index
            If Type = "UP" Then
                rowIndexOfItemUnderMouseToDrop = dgvPreview.SelectedRows(0).Index - 1
            Else
                rowIndexOfItemUnderMouseToDrop = dgvPreview.SelectedRows(0).Index + 1
            End If
            If rowIndexOfItemUnderMouseToDrop <> -1 AndAlso rowIndexOfItemUnderMouseToDrop < dgvPreview.Rows.Count Then
                dgvPreview.Rows.RemoveAt(rowIndexFromMouseDown)
                dgvPreview.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rw)
                dgvUndo.Rows.Add(rowIndexFromMouseDown, rowIndexOfItemUnderMouseToDrop)
                If lastNodeIndex <> -1 Then
                    If Type = "UP" Then
                        dgvPreview.Rows(lastNodeIndex - 1).Selected = True
                    Else
                        dgvPreview.Rows(lastNodeIndex + 1).Selected = True
                        dgvPreview.Focus()

                    End If
                Else
                    dgvPreview.SelectedRows(0).Selected = False
                End If
            End If
        End If
    End Sub

    Private Sub dgvPreview_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles dgvPreview.DragDrop
        Dim rowIndexOfItemUnderMouseToDrop As Integer
        Dim clientPoint As Point = dgvPreview.PointToClient(New Point(e.X, e.Y))
        rowIndexOfItemUnderMouseToDrop = dgvPreview.HitTest(clientPoint.X, clientPoint.Y).RowIndex
        If (e.Effect = DragDropEffects.Move) AndAlso rowIndexOfItemUnderMouseToDrop <> rowIndexFromMouseDown _
            AndAlso rowIndexOfItemUnderMouseToDrop <> -1 AndAlso rowIndexFromMouseDown <> -1 Then
            dgvPreview.Rows.RemoveAt(rowIndexFromMouseDown)
            dgvPreview.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rw)
            dgvUndo.Rows.Add(rowIndexFromMouseDown, rowIndexOfItemUnderMouseToDrop)
            dgvPreview.Rows(rowIndexOfItemUnderMouseToDrop).Selected = True
        End If
    End Sub

    Private Sub dgvPreview_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles dgvPreview.DragEnter
        If dgvPreview.SelectedRows.Count > 0 Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub dgvPreview_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvPreview.MouseDown
        If dgvPreview.SelectedRows.Count = 1 Then
            If e.Button = MouseButtons.Left Then
                   moveItem = True
            End If
        End If
    End Sub

    Private Sub dgvPreview_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvPreview.MouseUp
        If moveItem = True Then
            rw = dgvPreview.SelectedRows(0)
            rowIndexFromMouseDown = dgvPreview.SelectedRows(0).Index
            dgvPreview.DoDragDrop(rw, DragDropEffects.Move)
        End If
        moveItem = False
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim sortNo As Integer = 1
        Dim updateSQL As String
        For Each row As DataGridViewRow In dgvPreview.Rows
            updateSQL = " UPDATE tblCOA_Master SET OrderNo ='" & sortNo & "' WHERE AccountCode ='" & row.Cells(0).Value.ToString & "'"
            SQL.ExecNonQuery(updateSQL)
            sortNo += 1
        Next
        Msg("Records Saved Successfully!", MsgBoxStyle.Information)
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dgvPreview.SelectedRows.Count = 1 Then
            frmCOA_Add.ShowDialog(dgvPreview.SelectedRows(0).Cells(0).Value.ToString)
            LoadAccounts()
        End If

    End Sub

    Private Sub btnUndo_Click(sender As System.Object, e As System.EventArgs) Handles btnUndo.Click
        undoChanges()
    End Sub

    Private Sub undoChanges()
        If dgvUndo.Rows.Count > 0 Then
            rw = dgvPreview.Rows(dgvUndo.Rows(dgvUndo.Rows.Count - 1).Cells(1).Value.ToString())
            dgvPreview.Rows.RemoveAt(dgvUndo.Rows(dgvUndo.Rows.Count - 1).Cells(1).Value.ToString())
            dgvPreview.Rows.Insert(dgvUndo.Rows(dgvUndo.Rows.Count - 1).Cells(0).Value, rw)
            dgvPreview.Rows(dgvUndo.Rows(dgvUndo.Rows.Count - 1).Cells(0).Value).Selected = True
            dgvUndo.Rows.RemoveAt(dgvUndo.Rows.Count - 1)
        End If
    End Sub

    Private Sub dgvPreview_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvPreview.KeyDown
        If e.Shift = True AndAlso (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) Then
            If e.KeyCode = Keys.Down Then
                btnDown.PerformClick()
                e.SuppressKeyPress = True
            Else
                btnUp.PerformClick()
                e.SuppressKeyPress = True
            End If
        ElseIf e.Control = True Then
            If e.KeyCode = Keys.Z Then
                btnUndo.PerformClick()
            ElseIf e.KeyCode = Keys.S Then
                btnSave.PerformClick()
            ElseIf e.KeyCode = Keys.A Then
                btnAdd.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                btnEdit.PerformClick()
            End If

        End If
    End Sub
End Class