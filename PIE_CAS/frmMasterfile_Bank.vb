Public Class frmMasterfile_Bank
    Public a As Integer
    Dim idx As Integer

    Private Sub frmBanklist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetDatabase()
        EnableControl(False)
        txtBank.Enabled = False
        LoadItem()
        btnEdit.Enabled = False
        btnRemove.Enabled = False
    End Sub

    Protected Sub LoadItem()
        Dim query As String
        query = " SELECT	Bank_ID, Bank, Branch, Account_No, Account_Code, AccountTitle, SeriesFrom, SeriesTo, Status  " & _
                " FROM	    tblMasterfile_Bank LEFT JOIN tblCOA_Master " & _
                " ON		Account_Code = AccountCode " & _
                " WHERE     Status = 'Active' "
        SQL.ReadQuery(query)
        lvBank.Items.Clear()
        While SQL.SQLDR.Read
            lvBank.Items.Add(SQL.SQLDR("Bank_ID"))
            lvBank.Items(lvBank.Items.Count - 1).SubItems.Add(SQL.SQLDR("Bank").ToString)
            lvBank.Items(lvBank.Items.Count - 1).SubItems.Add(SQL.SQLDR("Branch").ToString)
            lvBank.Items(lvBank.Items.Count - 1).SubItems.Add(SQL.SQLDR("Account_Code").ToString)
            lvBank.Items(lvBank.Items.Count - 1).SubItems.Add(SQL.SQLDR("AccountTitle").ToString)
            lvBank.Items(lvBank.Items.Count - 1).SubItems.Add(SQL.SQLDR("Account_No").ToString)
            lvBank.Items(lvBank.Items.Count - 1).SubItems.Add(SQL.SQLDR("SeriesFrom").ToString)
            lvBank.Items(lvBank.Items.Count - 1).SubItems.Add(SQL.SQLDR("SeriesTo").ToString)
        End While
    End Sub

    Protected Sub ClearText()
        txtBank.Text = ""
        txtBranch.Text = ""
        txtAccntCode.Text = ""
        txtAccntTitle.Text = ""
        txtBankAccntNo.Text = ""
        txtSeriesFr.Text = ""
        txtSeriesTo.Text = ""
    End Sub

    Protected Sub EnableControl(ByVal Value As Boolean)
        txtBank.ReadOnly = Not Value
        txtBranch.ReadOnly = Not Value
        txtAccntTitle.ReadOnly = Not Value
        txtBankAccntNo.ReadOnly = Not Value
        txtSeriesFr.ReadOnly = Not Value
        txtSeriesTo.ReadOnly = Not Value
    End Sub

    Private Sub lstBank_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvBank.MouseClick
        If lvBank.SelectedItems.Count > 0 Then
            txtBank.Text = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chBank.Index).Text()
            txtBranch.Text = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chBranch.Index).Text()
            txtAccntCode.Text = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chAccntCode.Index).Text()
            txtAccntTitle.Text = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chAccntTitle.Index).Text()
            txtBankAccntNo.Text = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chBank.Index).Text()
            txtSeriesFr.Text = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chCheckSeriesFrom.Index).Text()
            txtSeriesTo.Text = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chCheckSeriesTo.Index).Text()
            idx = lvBank.Items(lvBank.SelectedItems(0).Index).SubItems(chIDX.Index).Text()
            EnableControl(False)
            btnEdit.Text = "Edit"
            btnAdd.Text = "New"
            btnRemove.Text = "Remove"
            btnEdit.Enabled = True
            btnRemove.Enabled = True
        Else
            btnEdit.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "New" Then
            ClearText()
            EnableControl(True)
            txtBank.Enabled = True
            btnRemove.Enabled = True
            btnAdd.Text = "Save"
            btnEdit.Text = "Edit"
            btnRemove.Text = "Cancel"
            btnEdit.Enabled = False
        ElseIf btnAdd.Text = "Save" Then
            If txtBank.Text = "" Then
                MsgBox("Please enter bank name!", MsgBoxStyle.Exclamation)
            ElseIf txtAccntCode.Text = "" Then
                MsgBox("Please enter default account title!", MsgBoxStyle.Exclamation)
            ElseIf MsgBox("Are you sure you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim insertSQL As String
                insertSQL = " INSERT INTO " & _
                            " tblMasterfile_Bank(Bank, Branch, Account_Code, Account_No, SeriesFrom, SeriesTo)" & _
                            " VALUES (@Bank, @Branch, @Account_Code, @Account_No, @SeriesFrom, @SeriesTo)"
                SQL.AddParam("@Bank", txtBank.Text)
                SQL.AddParam("@Branch", txtBranch.Text)
                SQL.AddParam("@Account_Code", txtAccntCode.Text)
                SQL.AddParam("@Account_No", txtBankAccntNo.Text)
                SQL.AddParam("@SeriesFrom", txtSeriesFr.Text)
                SQL.AddParam("@SeriesTo", txtSeriesTo.Text)
                SQL.ExecNonQuery(insertSQL)
                MsgBox("Saved successfully", MsgBoxStyle.Information)
                LoadItem()
                ClearText()
                EnableControl(False)
                txtBank.Enabled = False
                btnAdd.Text = "New"
                btnEdit.Text = "Edit"
                btnRemove.Text = "Remove"
                btnEdit.Enabled = False
                btnRemove.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            EnableControl(True)
            btnAdd.Text = "New"
            btnEdit.Text = "Update"
            btnRemove.Text = "Cancel"
            btnRemove.Enabled = True
        ElseIf btnEdit.Text = "Update" Then
            Dim updateSQL As String
            updateSQL = " UPDATE   tblMasterfile_Bank " & _
                        " SET      Branch = @Branch, " & _
                        "          Account_Code = @Account_Code,  " & _
                        "          Account_No = @Account_No, " & _
                        "          SeriesFrom = @SeriesFrom, " & _
                        "          SeriesTo = @SeriesTo " & _
                        " WHERE    Bank_ID = @Bank_ID "
            SQL.AddParam("@Bank", txtBank.Text)
            SQL.AddParam("@Branch", txtBranch.Text)
            SQL.AddParam("@Account_Code", txtAccntCode.Text)
            SQL.AddParam("@Account_No", txtBankAccntNo.Text)
            SQL.AddParam("@SeriesFrom", txtSeriesFr.Text)
            SQL.AddParam("@SeriesTo", txtSeriesTo.Text)
            SQL.AddParam("@Bank_ID", idx)
            SQL.ExecNonQuery(updateSQL)
            MsgBox("Updated successfully", MsgBoxStyle.Information)
            LoadItem()
            EnableControl(False)
            txtBank.Enabled = False
            ClearText()
            btnAdd.Text = "New"
            btnEdit.Text = "Edit"
            btnRemove.Text = "Remove"
            btnEdit.Enabled = False
            btnRemove.Enabled = False
        End If

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If btnRemove.Text = "Cancel" Then
            If txtAccntCode.Text <> "" Then
                btnEdit.Enabled = True
                btnRemove.Enabled = True
            Else
                btnEdit.Enabled = False
                btnRemove.Enabled = False
            End If
            btnAdd.Text = "New"
            btnEdit.Text = "Edit"
            btnRemove.Text = "Remove"
            EnableControl(False)
            txtBank.Enabled = False
        Else
            If MsgBox("Are you sure you want to remove this bank from the list?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim updateSQL As String
                updateSQL = " UPDATE   tblMasterfile_Bank " & _
                            " SET      Status = 'Inactive' " & _
                            " WHERE    Bank_ID = @Bank_ID "
                SQL.AddParam("@Bank_ID", idx)
                SQL.ExecNonQuery(updateSQL)
                MsgBox("Removed Succesfully", MsgBoxStyle.Information)
                LoadItem()
                EnableControl(False)
                txtBank.Enabled = False
                ClearText()
                btnAdd.Text = "New"
                btnEdit.Text = "Edit"
                btnRemove.Text = "Remove"
                btnEdit.Enabled = False
                btnRemove.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtAccntTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAccntTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtAccntTitle.Text)
                txtAccntCode.Text = f.accountcode
                txtAccntTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtSeriesFr_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeriesFr.KeyPress, txtSeriesTo.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class