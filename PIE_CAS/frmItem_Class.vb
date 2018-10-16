Public Class frmItem_Class
    Dim SQL As New SQLControl

    Private Sub frmOrgLevel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadLevel()
    End Sub

    Private Sub LoadLevel()
        Dim query As String
        query = " SELECT Level_ID, Description, Group_Level FROM tblItem_Level WHERE Status ='Active' ORDER BY Group_Level "
        SQL.ReadQuery(query)
        lvLevel.Items.Clear()
        While SQL.SQLDR.Read
            lvLevel.Items.Add(SQL.SQLDR("Level_ID").ToString)
            lvLevel.Items(lvLevel.Items.Count - 1).SubItems.Add(SQL.SQLDR("Group_Level").ToString)
            lvLevel.Items(lvLevel.Items.Count - 1).SubItems.Add(SQL.SQLDR("Description").ToString)
        End While
        If lvLevel.Items.Count > 0 Then
            lvLevel.Items(0).Selected = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If txtDescription.Text <> "" Then
            Dim exist As Boolean = False
            For Each item As ListViewItem In lvLevel.Items
                If item.SubItems(chDescription.Index).Text = txtDescription.Text Then
                    exist = True
                End If
            Next
            If exist = True Then
                MsgBox("Description already exist!", MsgBoxStyle.Exclamation)
            Else
                lvLevel.Items.Add("")
                lvLevel.Items(lvLevel.Items.Count - 1).SubItems.Add(lvLevel.Items.Count)
                lvLevel.Items(lvLevel.Items.Count - 1).SubItems.Add(txtDescription.Text)
                lvLevel.Items(lvLevel.Items.Count - 1).Selected = True
                lvLevel.Items(lvLevel.Items.Count - 1).Focused = True
                lvLevel.Focus()
            End If
            txtDescription.Clear()
        End If
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        If lvLevel.SelectedItems.Count = 1 Then
            lvLevel.SelectedItems(0).Remove()
            SortLevel()
            If lvLevel.Items.Count > 0 Then
                lvLevel.Items(0).Selected = True
                lvLevel.Items(0).Focused = True
                lvLevel.Focus()
            End If
        End If
    End Sub

    Private Sub SortLevel()
        For i As Integer = 1 To lvLevel.Items.Count
            lvLevel.Items(i - 1).SubItems(1).Text = i
        Next
    End Sub

    Private Sub btnUp_Click(sender As System.Object, e As System.EventArgs) Handles btnUp.Click
        Dim ID As String
        Dim description As String
        If lvLevel.SelectedItems.Count = 1 Then
            If lvLevel.SelectedItems(0).Index <> 0 Then
                ID = lvLevel.Items(lvLevel.SelectedItems(0).Index - 1).SubItems(0).Text
                description = lvLevel.Items(lvLevel.SelectedItems(0).Index - 1).SubItems(2).Text
                lvLevel.Items(lvLevel.SelectedItems(0).Index - 1).SubItems(0).Text = lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(0).Text
                lvLevel.Items(lvLevel.SelectedItems(0).Index - 1).SubItems(2).Text = lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(2).Text
                lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(0).Text = ID
                lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(2).Text = description
                lvLevel.Items(lvLevel.SelectedItems(0).Index - 1).Selected = True
                lvLevel.Items(lvLevel.SelectedItems(0).Index).Focused = True
                lvLevel.Focus()
            Else
                lvLevel.Items(0).Selected = True
                lvLevel.Items(lvLevel.SelectedItems(0).Index).Focused = True
                lvLevel.Focus()
            End If

        End If
    End Sub

    Private Sub btnDown_Click(sender As System.Object, e As System.EventArgs) Handles btnDown.Click
        Dim ID As String
        Dim description As String
        If lvLevel.SelectedItems.Count = 1 Then
            If lvLevel.SelectedItems(0).Index <> lvLevel.Items.Count - 1 Then
                ID = lvLevel.Items(lvLevel.SelectedItems(0).Index + 1).SubItems(0).Text
                description = lvLevel.Items(lvLevel.SelectedItems(0).Index + 1).SubItems(2).Text
                lvLevel.Items(lvLevel.SelectedItems(0).Index + 1).SubItems(0).Text = lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(0).Text
                lvLevel.Items(lvLevel.SelectedItems(0).Index + 1).SubItems(2).Text = lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(2).Text
                lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(0).Text = ID
                lvLevel.Items(lvLevel.SelectedItems(0).Index).SubItems(2).Text = description
                lvLevel.Items(lvLevel.SelectedItems(0).Index + 1).Selected = True
                lvLevel.Items(lvLevel.SelectedItems(0).Index).Focused = True
                lvLevel.Focus()
            Else
                lvLevel.Items(lvLevel.Items.Count - 1).Selected = True
                lvLevel.Items(lvLevel.SelectedItems(0).Index).Focused = True
                lvLevel.Focus()
            End If
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If MsgBox("Are you sure you want to save changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblItem_Level " & _
                        " SET    Status ='Inactive' "
            SQL.ExecNonQuery(updateSQL)
            For Each item As ListViewItem In lvLevel.Items
                If IsNumeric(item.SubItems(0).Text) Then
                    updateSQL = " UPDATE tblItem_Level " & _
                                " SET    Group_Level = @Level, Status ='Active' " & _
                                " WHERE  Level_ID = @ID "
                    SQL.FlushParams()
                    SQL.AddParam("@Level", item.SubItems(chLevel.Index).Text)
                    SQL.AddParam("@ID", item.SubItems(chID.Index).Text)
                    SQL.ExecNonQuery(updateSQL)
                Else
                    updateSQL = " INSERT INTO tblItem_Level (Description, Group_Level, Status) " & _
                                " VALUES(@Description,   @Group_Level , @Status) "
                    SQL.FlushParams()
                    SQL.AddParam("@Description", item.SubItems(chDescription.Index).Text)
                    SQL.AddParam("@Group_Level", item.SubItems(chLevel.Index).Text)
                    SQL.AddParam("@Status", "Active")
                    SQL.ExecNonQuery(updateSQL)
                End If
            Next
            MsgBox("Changes has been succesfully saved!", MsgBoxStyle.Information)
            Me.Close()
            Me.Dispose()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class