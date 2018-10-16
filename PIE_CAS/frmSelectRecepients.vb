Public Class frmSelectRecipients
    Dim SQL As New SQLControl
    Public MemNo, MemName As String

    Private Sub LoadMember()
        Dim query, filter As String
        If txtFilter.Text = "" Then
            filter = ""
        Else
            filter = "AND (MemName LIKE '%' + @Filter + '%' OR MEmNo = @Filter) "
            SQL.AddParam("@Filter", txtFilter.Text)
        End If
        query = " SELECT MemNo, MemName FROM Cooplist	WHERE Status ='Active'  " & filter & _
                " ORDER BY MemName "
        SQL.ReadQuery(query)
        SQL.FlushParams()
        lvMember.Items.Clear()
        While SQL.SQLDR.Read
            lvMember.Items.Add(SQL.SQLDR("MemNo").ToString)
            lvMember.Items(lvMember.Items.Count - 1).SubItems.Add(SQL.SQLDR("MemName").ToString)
        End While
    End Sub

    Private Sub frmSelectRecipients_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadMember()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub lvMember_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvMember.DoubleClick
        If lvMember.SelectedItems.Count = 1 Then
            MemNo = lvMember.SelectedItems(0).SubItems(0).Text
            MemName = lvMember.SelectedItems(0).SubItems(1).Text
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFilter.TextChanged
        LoadMember()
    End Sub

    Private Sub lvMember_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvMember.SelectedIndexChanged

    End Sub
End Class