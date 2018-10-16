Public Class frmMember_Search
    Public MemberID, FullName, TIN, Type As String
    Public rowInd As Integer
    Public ModType As String = "Member"
    Private Sub frmMember_Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cbFilter.SelectedIndex = -1 Then
            cbFilter.SelectedIndex = 0
        End If
        If ModType = "Member" Then
            LoadStatus()
            LoadList()
            cbStatus.Enabled = True
        ElseIf ModType = "RFP" Then
            cbStatus.Items.Clear()
            cbStatus.Enabled = False

            LoadList()
        End If
        listViewAlternateColor(lvList)
    End Sub
    Public Sub listViewAlternateColor(listView As ListView)
        Dim iView As Integer = listView.Items.Count - 1
        For i = 0 To iView Step 2
            listView.Items(i).UseItemStyleForSubItems = True
            listView.Items(i).BackColor = Drawing.Color.WhiteSmoke
        Next i
    End Sub
    Private Sub LoadStatus()
        Dim query As String
        query = " SELECT DISTINCT Status FROM tblMember_Master WHERE Status <> 'Deleted' "
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
        listViewAlternateColor(lvList)
    End Sub
    Private Sub LoadList()
        If ModType = "Member" Then
            If cbStatus.SelectedIndex <> -1 Then
                Dim query As String
                query = " SELECT Member_ID, Full_Name FROM tblMember_Master WHERE " & cbFilter.SelectedItem & " LIKE '%" & txtFilter.Text & "%'  " & _
                IIf(cbStatus.SelectedItem = "All", "", " AND Status ='" & cbStatus.SelectedItem & "' ")
               
                SQL.ReadQuery(query)
                lvList.Items.Clear()
                While SQL.SQLDR.Read
                    lvList.Items.Add(SQL.SQLDR("Member_ID").ToString)
                    lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Full_Name").ToString)
                End While
                If lvList.Items.Count > 0 Then
                    lvList.Items(0).Selected = True
                End If
                lvList.Columns(0).Width = 160
            End If
        Else
        End If
        listViewAlternateColor(lvList)
    End Sub

    Private Sub lvList_DoubleClick(sender As Object, e As EventArgs) Handles lvList.DoubleClick
        If lvList.SelectedItems.Count = 1 Then
            MemberID = lvList.SelectedItems(0).SubItems(chMemberCode.Index).Text
            FullName = lvList.SelectedItems(0).SubItems(chMemberName.Index).Text
            Me.Close()
        End If
    End Sub
    
    Private Sub lvList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvList.SelectedIndexChanged

    End Sub
End Class