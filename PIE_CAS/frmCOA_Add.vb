Public Class frmCOA_Add
    Dim ModuleID As String = "COA"
    Dim EntryAllowed As Boolean = False
    Dim disableEvent As Boolean = False
    Dim autoGen As Boolean
    Dim AccntFormat As String
    Dim AccountCode, AccountGroup As String

    Public Overloads Function ShowDialog(ByVal AccntCode As String, Optional ByVal Group As String = "") As Boolean
        AccountCode = AccntCode
        AccountGroup = Group
        MyBase.ShowDialog()
        Return True
    End Function


    Private Sub frmCOA_Add_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSettings()
        LoadAccountType()
        txtAccntCode.ReadOnly = autoGen
        If AccountCode <> "" Then
            LoadAccount(AccountCode)
            btnSaveNew.Text = "Update && Create &New"
            btnSaveClose.Text = "&Update && Close"
        Else
            LoadAccountCode()
            btnSaveNew.Text = "Save && Create &New"
            btnSaveClose.Text = "&Save && Close"
        End If

    End Sub

    Private Sub LoadAccount(ByVal Account As String)
        Dim query As String
        query = " SELECT AccountType, AccountTitle, AccountGroup, AccountNature, ReportAlias, withSubsidiary  " & _
                " FROM tblCOA_Master  " & _
                " WHERE AccountCode = '" & Account & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            disableEvent = True
            cbType.SelectedItem = SQL.SQLDR("AccountType").ToString
            txtAccntCode.Text = Account
            txtAccntTitle.Text = SQL.SQLDR("AccountTitle").ToString
            txtAlias.Text = SQL.SQLDR("ReportAlias").ToString
            If SQL.SQLDR("AccountNature").ToString = "" Then
                chkAllow.Checked = False
            ElseIf SQL.SQLDR("AccountNature").ToString = "Debit" Then
                chkAllow.Checked = True
                rbDebit.Checked = True
            ElseIf SQL.SQLDR("AccountNature").ToString = "Credit" Then
                chkAllow.Checked = True
                rbCredit.Checked = True
            End If
            chkSubsidiary.Checked = SQL.SQLDR("withSubsidiary")
            disableEvent = False
            cbGroup.SelectedItem = SQL.SQLDR("AccountGroup").ToString
        End If
    End Sub

    Private Sub LoadAccountCode()
        If autoGen Then
            If AccntFormat = "Auto Increment" Then
                txtAccntCode.Text = LoadIncrement()
                txtAccntTitle.Focus()
                txtAccntTitle.Select()
            End If
        End If
    End Sub

    Private Function LoadIncrement() As Integer
        Dim query As String
        query = " SELECT ISNULL(MAX(CAST(AccountCode AS Numeric)),0) + 1 AS AccountCode  FROM tblCOA_Master WHERE ISNUMERIC(AccountCode) =1 "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AccountCode")
        Else
            Return 1
        End If
    End Function

    Private Sub LoadSettings()
        Dim query As String
        query = " SELECT COA_Auto, COA_AccntFormat FROM tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            autoGen = SQL.SQLDR("COA_Auto")
            If autoGen Then
                AccntFormat = SQL.SQLDR("COA_AccntFormat").ToString
            Else
                AccntFormat = ""
            End If
        End If
    End Sub

    Private Sub LoadAccountType()
        Dim query As String
        query = " SELECT AccountGroup FROM tblCOA_AccountGroup ORDER BY Hierarchy "
        SQL.ReadQuery(query)
        cbGroup.Items.Clear()
        While SQL.SQLDR.Read
            cbGroup.Items.Add(SQL.SQLDR("AccountGroup").ToString)
        End While
        If cbGroup.Items.Count > 0 Then
            If AccountGroup <> "" Then
                cbGroup.SelectedItem = AccountGroup
            Else
                cbGroup.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveClose.Click
        If btnSaveClose.Text = "&Save && Close" Then
            SaveAccount()
        Else
            UpdateAccount()
        End If

        Me.Close()
    End Sub

    Private Sub SaveAccount()
        Try
            Dim nextOrder As Integer = GetNextOrder()
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblCOA_Master(AccountCode, AccountTitle, AccountGroup, AccountType, AccountNature, ReportAlias, withSubsidiary, OrderNo) " & _
                        " VALUES (@AccountCode, @AccountTitle, @AccountGroup, @AccountType, @AccountNature, @ReportAlias, @withSubsidiary, @OrderNo) "
            SQL.FlushParams()
            SQL.AddParam("@AccountCode", txtAccntCode.Text)
            SQL.AddParam("@AccountTitle", txtAccntTitle.Text)
            SQL.AddParam("@AccountGroup", cbGroup.SelectedItem)
            SQL.AddParam("@AccountType", cbType.SelectedItem)
            If panelAccount.Visible = True AndAlso chkAllow.Checked = True Then
                If rbDebit.Checked = True Then
                    SQL.AddParam("@AccountNature", "Debit")
                Else
                    SQL.AddParam("@AccountNature", "Credit")
                End If
            Else
                SQL.AddParam("@AccountNature", "")
            End If
            SQL.AddParam("@ReportAlias", txtAlias.Text)
            SQL.AddParam("@withSubsidiary", chkSubsidiary.Checked)
            SQL.AddParam("@OrderNo", nextOrder)
            SQL.ExecNonQuery(insertSQL)
            Msg("Record Saved Successfully!", MsgBoxStyle.Information)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateAccount()
        Try
            Dim insertSQL As String
            insertSQL = " UPDATE tblCOA_Master " & _
                        " SET    AccountTitle = @AccountTitle, AccountGroup = @AccountGroup, AccountType = @AccountType, " & _
                        "        AccountNature = @AccountNature, ReportAlias = @ReportAlias, withSubsidiary = @withSubsidiary, " & _
                        "        WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE  AccountCode = @AccountCode  "
            SQL.FlushParams()
            SQL.AddParam("@AccountCode", txtAccntCode.Text)
            SQL.AddParam("@AccountTitle", txtAccntTitle.Text)
            SQL.AddParam("@AccountGroup", cbGroup.SelectedItem)
            SQL.AddParam("@AccountType", cbType.SelectedItem)
            If panelAccount.Visible = True AndAlso chkAllow.Checked = True Then
                If rbDebit.Checked = True Then
                    SQL.AddParam("@AccountNature", "Debit")
                Else
                    SQL.AddParam("@AccountNature", "Credit")
                End If
            Else
                SQL.AddParam("@AccountNature", "")
            End If
            SQL.AddParam("@ReportAlias", txtAlias.Text)
            SQL.AddParam("@withSubsidiary", chkSubsidiary.Checked)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(insertSQL)
            Msg("Record Updated Successfully!", MsgBoxStyle.Information)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Function GetNextOrder() As Integer
        Dim query As String
        query = " SELECT Max(OrderNo) + 1 AS NextOrder FROM tblCOA_Master "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("NextOrder").ToString
        Else
            Return 1
        End If
    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cbGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbGroup.SelectedIndexChanged
        If disableEvent = False Then
            If cbGroup.SelectedIndex <> -1 Then
                Dim query As String
                query = " SELECT AllowEntry FROM tblCOA_AccountGroup WHERE AccountGroup ='" & cbGroup.SelectedItem & "' "
                SQL.ReadQuery(query)
                disableEvent = True
                If SQL.SQLDR.Read AndAlso SQL.SQLDR("AllowEntry") = True Then
                    panelAccount.Visible = True
                    chkAllow.Checked = True
                Else
                    panelAccount.Visible = False
                    chkAllow.Checked = False
                End If
                disableEvent = False
            End If
        End If
    End Sub

    Private Sub chkAllow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAllow.CheckedChanged
        If disableEvent = False Then
            If chkAllow.Checked = True Then
                rbDebit.Checked = True
                rbCredit.Checked = False
                chkSubsidiary.Checked = False
                rbDebit.Enabled = True
                rbCredit.Enabled = True
                chkSubsidiary.Enabled = True
            Else
                rbDebit.Checked = False
                rbCredit.Checked = False
                chkSubsidiary.Checked = False
                rbDebit.Enabled = False
                rbCredit.Enabled = False
                chkSubsidiary.Enabled = False
            End If
        End If

    End Sub

    Private Sub btnSaveNew_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveNew.Click
        If btnSaveNew.Text = "Save && Create &New" Then
            SaveAccount()
        Else
            UpdateAccount()
        End If
        LoadAccountCode()
        txtAccntTitle.Clear()
        txtAlias.Clear()
        txtAccntTitle.Focus()
        btnSaveNew.Text = "Save && Create &New"
        btnSaveClose.Text = "&Save && Close"
        frmCOA.LoadAccounts()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        frmCOA_AccountType.ShowDialog()
        LoadAccountType()
    End Sub

End Class