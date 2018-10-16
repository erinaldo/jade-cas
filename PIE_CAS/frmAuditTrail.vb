Public Class frmAuditTrail
    Dim SQL As New SQLControl

    Private Sub frmAuditTrail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFrom.Value = dtpFrom.Value.Date
        LoadUser()
        LoadActivity()
    End Sub

    Private Sub LoadUser()
        Dim query As String
        query = "SELECT DISTINCT ISNULL(Last_Name + ', ','') + ISNULL(First_Name,'') + ISNULL(' ' + LEFT(Middle_Name,1),'') AS Name FROM tblUser "
        SQL.ReadQuery(query)
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("All")
        While SQL.SQLDR.Read
            ComboBox1.Items.Add(SQL.SQLDR("Name").ToString)
        End While
        ComboBox1.SelectedItem = "All"
    End Sub

    Private Sub LoadActivity()
        Dim user As String = GetUserID()
        Dim query As String
        query = " SELECT Datetime_Stamp, ISNULL(Last_Name + ', ','') + ISNULL(First_Name,'') + ISNULL(' ' + LEFT(Middle_Name,1),'') AS Name, Module_Name, Activity_Type, Activity_Description  " & _
                " FROM tblUser_Activity LEFT JOIN tblUser " & _
                " ON     tblUser_Activity.UserID = tblUser.UserID " & _
                " LEFT JOIN tblModule " & _
                " ON     tblUser_Activity.ModuleID = tblModule.Module_ID " & _
                " WHERE  Datetime_Stamp BETWEEN '" & dtpFrom.Value & "' AND '" & dtpTo.Value & "' " & _
                IIf(user = "", "", " AND    tblUser.UserID = '" & user & "' ") & _
                " ORDER BY Datetime_Stamp "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            dgvUserActivity.DataSource = SQL.SQLDS.Tables(0)
        Else
            dgvUserActivity.DataSource = Nothing
        End If
    End Sub

    Private Function GetUserID() As String
        Dim query As String
        query = " SELECT UserID FROM tblUser WHERE UserName ='" & ComboBox1.SelectedItem & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("UserID").ToString
        Else
            Return ""
        End If
    End Function

    Private Sub dtpFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged, dtpTo.ValueChanged, ComboBox1.SelectedIndexChanged
        LoadActivity()
    End Sub
End Class