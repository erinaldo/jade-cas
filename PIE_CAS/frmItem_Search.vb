Public Class frmItem_Search
    Public ItemCode As String

    Private Sub frmItem_List_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbFilter.SelectedIndex = 0
        LoadStatus()
        LoadList()
    End Sub

    Private Sub LoadStatus()
        Dim query As String
        query = " SELECT DISTINCT Status FROM tblItem_Master WHERE Status <> 'Deleted' "
        SQL.ReadQuery(query)
        cbStatus.Items.Clear()
        cbStatus.Items.Add("All")
        While SQL.SQLDR.Read
            cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
        End While
        If cbStatus.Items.Count = 2 Then
            cbStatus.Items.Remove("All")
        End If
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadList()
        If cbStatus.SelectedIndex <> -1 Then
            Dim query As String
            query = " SELECT ItemCode, ItemName FROM tblItem_Master WHERE  " & cbFilter.SelectedItem & " LIKE '%" & txtFilter.Text & "%' " & _
                       IIf(cbStatus.SelectedItem = "All", "", " AND Status ='" & cbStatus.SelectedItem & "' ")
            SQL.ReadQuery(query)
            lvList.Items.Clear()
            While SQL.SQLDR.Read
                lvList.Items.Add(SQL.SQLDR("ItemCode").ToString)
                lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("ItemName").ToString)
            End While
        End If
    End Sub

    Private Sub lvList_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvList.DoubleClick
        If lvList.SelectedItems.Count = 1 Then
            ItemCode = lvList.SelectedItems(0).SubItems(chItemCode.Index).Text
            Me.Close()
        End If
    End Sub

    Private Sub cbStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbStatus.SelectedIndexChanged
        LoadList()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        LoadList()
    End Sub
End Class