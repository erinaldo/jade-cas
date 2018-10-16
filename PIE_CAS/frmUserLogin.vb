Imports System.IO
Imports System.Data.SqlClient

Public Class frmUserLogin
    Inherits MetroFramework.Forms.MetroForm
    Dim moduleID As String = "UL"
    Dim counter As Integer = 1
    Dim masterCon As SqlConnection
    Dim masterCmd As SqlCommand
    Dim masterReader As SqlDataReader

    Private Sub FrmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadDefaultServer()
        Me.FocusMe()
        txtUsername.Select()
    End Sub

    Private Sub LoadDefaultServer()
        Try
            Dim query As String
            query = "SELECT  Server, UserName, Password, DefaultDB FROM Database_Info  "
            cbServer.Items.Clear()
            AlphaQuery(query)
            If AlphaReader.Read Then
                cbServer.Text = AlphaReader("Server").ToString
                txtUser.Text = AlphaReader("UserName").ToString
                txtPass.Text = AlphaReader("Password").ToString
                cbDatabase.SelectedItem = AlphaReader("DefaultDB").ToString

                If HasConnection() Then
                    LoadDatabase()
                End If
                ShowSettings(False)
            Else
                Msg("No default server, please select server to connect or contact your system administrator", MsgBoxStyle.Exclamation)
                ShowSettings(True)
            End If
        Catch ex As Exception
            Msg(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function HasConnection() As Boolean
        Try
            Dim valid As Boolean = True

            ' IF IP ADDRESS OR HOSTNAME, PING FIRST
            If cbServer.Text.Contains(".") Then
                If Not My.Computer.Network.Ping(cbServer.Text, 2000) Then
                    valid = False
                End If
            End If

            If valid Then
                masterCon = New SqlConnection With {.ConnectionString = ("Server=" & cbServer.Text & ";Database=master;integrated security=sspi;Uid=" & txtUser.Text & ";Pwd=" & txtPass.Text & ";Trusted_Connection=no;MultipleActiveResultSets=True;Max Pool Size=200;")}
                If masterCon.State = ConnectionState.Open Then
                    masterCon.Close()
                Else
                End If
                masterCon.Open()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            Msg(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub LoadDatabase()
        SetDatabase()
        Dim query As String
        query = " SELECT REPLACE(name,'JADE_','') AS DBName  " & _
                " FROM   sys.databases  " & _
                " WHERE  name LIKE 'JADE%' "
        SQL.ReadQuery(query)
        cbDatabase.Items.Clear()
        While SQL.SQLDR.Read
            cbDatabase.Items.Add(SQL.SQLDR("DBName").ToString)
        End While
        If cbDatabase.Items.Count > 0 Then
            cbDatabase.SelectedIndex = 0
        End If
    End Sub

    Private Function PatchUpdated() As Boolean
        Dim App_Path As String
        App_Path = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
        If FileVersionInfo.GetVersionInfo(App_Path & "\jade.exe").FileVersion <> FindVersion() Then
            Return False
        Else
            Return True
        End If

        Return True
    End Function

    Private Function getBusinessType() As String
        Dim query As String
        SetDatabase()
        query = " SELECT BusinessCode FROM tblBusinessType WHERE Status ='Active' "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count = 1 Then
            Return SQL.SQLDS.Tables(0).Rows(0).Item(0).ToString
        Else
            Return ""
        End If
    End Function

    Private Function getBranchCode() As String
        Dim query As String
        SetDatabase()
        query = " SELECT BranchCode FROM tblBranch WHERE Status ='Active' "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count = 1 Then
            Return SQL.SQLDS.Tables(0).Rows(0).Item(0).ToString
        Else
            Return ""
        End If
    End Function

    Private Function FindVersion() As String
        Dim query As String
        query = " SELECT Version FROM tblSystemVersion WHERE Status ='Active' "
        SQL.ReadQuery(query)
        SQL.SQLDR.Read()
        Return SQL.SQLDR("Version").ToString
    End Function

    Protected Sub UpdateLastLogin(ByVal UserID As String)
        Dim updateSQL As String
        updateSQL = " UPDATE tblUser SET DateLastLogin = GETDATE()  WHERE UserID = '" & UserID & "' "
        SQL.ExecNonQuery(updateSQL)
    End Sub

    Private Sub ShowSettings(ByVal Show As Boolean)
        If Show = True Then
            Me.Width = 688
            Me.Height = 409
            btnOption.Text = "Options <<"
            txtUser.TabStop = True
            txtPass.TabStop = True
            btnConnect.TabStop = True
            cbServer.TabStop = True
        Else
            Me.Width = 273
            Me.Height = 409
            btnOption.Text = "Options >>"
            txtUser.TabStop = False
            txtPass.TabStop = False
            btnConnect.TabStop = False
            cbServer.TabStop = False
        End If
    End Sub

    Private Sub SaveServer()
        Dim deleteSQL, insertSQL As String
        deleteSQL = "  DELETE FROM Database_Info "
        AlphaExecute(deleteSQL)
        insertSQL = " INSERT INTO " & _
                    " Database_Info([Server], [Username], [Password]) " & _
                    " VALUES('" & cbServer.Text & "','" & txtUser.Text & "','" & txtPass.Text & "')"
        AlphaExecute(insertSQL)
    End Sub

    Private Sub UpdateDefaultDB()
        Dim updateSQL As String
        updateSQL = "  UPDATE Database_Info SET DefaultDB = '" & cbDatabase.SelectedItem & "' "
        AlphaExecute(updateSQL)
    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Try
            If cbDatabase.SelectedIndex = -1 Then
                Msg("Please select database!", MsgBoxStyle.Exclamation)
            Else
                activityStatus = True
                database = "JADE_" & cbDatabase.SelectedItem
                Dim query As String
                SetDatabase()
                If txtUsername.Text = "" Or txtPassword.Text = "" Then
                    MsgBox("Enter your username or password!", MsgBoxStyle.Exclamation)
                    txtUsername.Focus()
                Else
                    query = " SELECT  UserID, LoginName, Password, UserLevel, Status, FirstLogin, " & _
                            "         UserName AS Name " & _
                            " FROM    tblUser " & _
                            " WHERE   LoginName = '" & txtUsername.Text & "' " & _
                            " AND     Password = '" & txtPassword.Text & "'"
                    SQL.ReadQuery(query)
                    If SQL.SQLDR.Read Then
                        If SQL.SQLDR("Status").ToString = "Locked" Then
                            MsgBox("Account locked, Please try again or contact the administrator", MsgBoxStyle.Information)
                            activityStatus = False
                        Else
                            If SQL.SQLDR("FirstLogin") = True Then
                                MsgBox("Welcome! This is your first login, Please change your password", MsgBoxStyle.Information)
                                frmUserChange.lblPassword.Text = SQL.SQLDR("Password").ToString
                                frmUserChange.lblUserID.Text = SQL.SQLDR("UserID").ToString
                                frmUserChange.txtUsername.Text = SQL.SQLDR("LoginName").ToString
                                frmUserChange.ShowDialog()
                            Else
                                UserID = SQL.SQLDR("UserID").ToString
                                UserName = SQL.SQLDR("LoginName").ToString
                                Password = SQL.SQLDR("Password").ToString
                                UserLevel = SQL.SQLDR("UserLevel").ToString
                                Name = SQL.SQLDR("Name").ToString
                                UpdateLastLogin(UserID)
                                UpdateDefaultDB()
                                If PatchUpdated() Then
                                    BusinessType = getBusinessType()
                                    BranchCode = getBranchCode()
                                    If BusinessType = "" Then
                                        frmOption.Show()
                                    ElseIf BranchCode = "" Then
                                        frmOption.Show()
                                    Else
                                        Main_JADE.Show()
                                    End If
                                    Me.Hide()
                                Else
                                    System.Diagnostics.Process.Start(App_Path & "\FTPUpdate.exe")
                                End If
                            End If
                        End If
                    Else
                        If counter = 3 Then
                            Msg("Invalid Username or password. This is your 3rd attempt to login " & vbNewLine & "Kindly contact your system administrator. The program will now close.", MsgBoxStyle.Exclamation)
                            Application.Exit()
                        End If
                        Msg("Invalid Username or Password!", MsgBoxStyle.Information)
                        txtUsername.Text = ""
                        txtPassword.Text = ""
                        txtUsername.Focus()
                        activityStatus = False
                        counter += 1
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "Message Alert")
            activityStatus = False
        Finally
            If BusinessType <> "" Then
                RecordActivity(UserID, moduleID, Me.Name.ToString, "Login", "UserID", UserName, BusinessType, BranchCode, "", activityStatus)
            End If
        End Try
    End Sub

    Private Sub btnOption_Click(sender As System.Object, e As System.EventArgs) Handles btnOption.Click
        If btnOption.Text = "Options >>" Then
            ShowSettings(True)
        Else
            ShowSettings(False)
        End If
    End Sub

    Private Sub btnConnect_Click(sender As System.Object, e As System.EventArgs) Handles btnConnect.Click
        If HasConnection() Then
            SaveServer()
            Msg("Connected Succesfully!" & vbNewLine & "Please select your database", MsgBoxStyle.Information)
            LoadDatabase()
            ShowSettings(False)
        Else
            Msg("Can't connect to server!" & vbNewLine & "Please check your database connection or contact your network administrator", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles pbLogo.Click
        frmModuleSelect.Show()
    End Sub

    Private Sub lnkModuleSelect_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModuleSelect.LinkClicked
        Me.Dispose()
        frmModuleSelect.Show()
        lsJADE.Dispose()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        End
    End Sub
End Class