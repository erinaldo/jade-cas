Public Class frmUser_Add
    Public User_ID As Integer
    Public Type As String
    Public password As String
    Dim ModuleID As String = "UAR"


    Private Sub frmUser_Add_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadUserLevel()
        If Type = "ADD" Then
            txtOldPass.Visible = False
            lblOldPass.Visible = False
        ElseIf Type = "CHANGE PASS" Then
            txtOldPass.Visible = True
            lblOldPass.Visible = True
        Else
            txtOldPass.Visible = False
            lblOldPass.Visible = False
        End If
    End Sub

    Private Sub LoadUserLevel()
        Dim query As String
        query = " SELECT DISTINCT UserLevel FROM tblUser_Level WHERE UserLevel <> 'Master Admin' "
        SQL.ReadQuery(query)
        cbUserLevel.Items.Clear()
        While SQL.SQLDR.Read
            cbUserLevel.Items.Add(SQL.SQLDR("UserLevel").ToString)
        End While
        If cbUserLevel.Items.Count > 0 Then
            cbUserLevel.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Type = "ADD" Then
                If MessageBox.Show("Are you sure you want to Save this User?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If txtName.Text = "" Or txtPassword.Text = "" Or txtUsername.Text = "" Then
                        msgRequired()
                    ElseIf txtPassword.Text <> txtConfirmPass.Text Then
                        MsgBox("Password confirmation doesn't match!", MsgBoxStyle.Exclamation)
                    ElseIf UserExist() Then
                        MsgBox("Username already exist! Please choose another.", MsgBoxStyle.Exclamation)
                        txtUsername.Focus()
                    ElseIf txtPassword.TextLength < 6 Then
                        MsgBox("Password with less than 6 character is not acceptable, it is considered a weak Password.", vbInformation)
                    Else
                        SaveUser()
                        msgsave()
                        Me.Close()
                    End If
                End If
            ElseIf Type = "CHANGE PASS" Then
                If MessageBox.Show("Are you sure you want to Update this User?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If txtPassword.Text = "" Then
                        msgRequired()
                    ElseIf txtPassword.Text <> txtConfirmPass.Text Then
                        MsgBox("Password confirmation doesn't match!", MsgBoxStyle.Exclamation)
                        txtUsername.Focus()
                    ElseIf txtOldPass.Text <> password Then
                        MsgBox("Old password is invalid!", MsgBoxStyle.Exclamation)
                        txtUsername.Focus()
                    ElseIf txtPassword.TextLength < 6 Then
                        MsgBox("Password with less than 6 character is not acceptable, it is considered a weak Password.", vbInformation)
                    Else
                        UpdateUser()
                        msgupdated()
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub SaveUser()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                  " tblUser (UserName, LoginName, Password, UserLevel, RefID, EmailAddress, ContactNo, WhoCreated) " & _
                  " VALUES (@UserName, @LoginName, @Password, @UserLevel, @RefID, @EmailAddress, @ContactNo, @WhoCreated)"
            SQL.AddParam("@UserName", txtName.Text)
            SQL.AddParam("@LoginName", txtUsername.Text)
            SQL.AddParam("@Password", txtPassword.Text)
            SQL.AddParam("@UserLevel", cbUserLevel.SelectedItem)
            SQL.AddParam("@RefID", txtID.Text)
            SQL.AddParam("@EmailAddress", txtEmail.Text)
            SQL.AddParam("@ContactNo", txtContact.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "UserID", User_ID, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Protected Sub UpdateUser()
        Try
            activityStatus = True
            Dim updateSQL As String
            updateSQL = " UPDATE tblUser " & _
                        " SET    UserName = @UserName, LoginName = @LoginName, Password = @Password, " & _
                        "        UserLevel = @UserLevel, RefID = @RefID, EmailAddress = @EmailAddress, ContactNo = @ContactNo " & _
                        "        WhoModified = @WhoModified " & _
                        " WHERE  UserID = @UserID "
            SQL.AddParam("@UserID", User_ID)
            SQL.AddParam("@UserName", txtName.Text)
            SQL.AddParam("@LoginName", txtUsername.Text)
            SQL.AddParam("@Password", password)
            SQL.AddParam("@UserLevel", cbUserLevel.SelectedItem)
            SQL.AddParam("@RefID", txtID.Text)
            SQL.AddParam("@EmailAddress", txtEmail.Text)
            SQL.AddParam("@ContactNo", txtContact.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "UserID", User_ID, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub txtUsername_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus
        txtUsername.SelectionStart = 0
        txtUsername.SelectionLength = Len(txtUsername.Text)
    End Sub

    Private Function UserExist() As Boolean
        Dim query As String
        Try
            query = "SELECT LoginName FROM tblUser WHERE LoginName = @LoginName "
            SQL.FlushParams()
            SQL.AddParam("@LoginName", txtUsername.Text)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
            Return False
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.ShowDialog()
        LoadUserInfo(f.VCECode)
        f.Dispose()
    End Sub

    Private Sub LoadUserInfo(ByVal ID As String)
        Dim query As String
        query = " SELECT    VCECode, VCEName, Contact_Cellphone, Contact_Email  " & _
                " FROM      tblVCE_Master " & _
                " WHERE     VCECode ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtID.Text = SQL.SQLDR("VCECode").ToString
            txtName.Text = SQL.SQLDR("VCEName").ToString
            txtEmail.Text = SQL.SQLDR("Contact_Cellphone").ToString
            txtContact.Text = SQL.SQLDR("Contact_Email").ToString
        Else

            txtID.Clear()
            txtName.Clear()
            txtEmail.Clear()
            txtContact.Clear()
        End If
    End Sub

End Class