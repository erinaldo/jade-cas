Public Class frmDisbursement_Type
    Dim SQL As New SQLControl
    Dim ID As Integer
    Dim moduleID As Integer = 6
    Dim activityResult As Boolean = True

    Private Sub frmDisbursement_Type_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadType(txtSearch.Text)
            LoadCategory()
            EnableControl(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadCategory()
        Dim query As String
        query = " SELECT  DISTINCT Expense_Category " & _
                " FROM    tblCV_ExpenseType " & _
                " WHERE   Status = 'Active'"
        SQL.ReadQuery(query)
        cbCategory.Items.Clear()
        While SQL.SQLDR.Read
            cbCategory.Items.Add(SQL.SQLDR("Expense_Category").ToString)
        End While
    End Sub

    Private Sub LoadType(ByVal Type As String)
        Dim query As String
        query = " SELECT  Expense_ID, Expense_Category, Expense_Description, ISNULL(Amount, 0) AS Amount, Account_Code, AccntTitle " & _
                " FROM    tblCV_ExpenseType INNER JOIN ChartOfAccount " & _
                " ON      tblCV_ExpenseType.Account_Code = ChartOfAccount.AccntCode " & _
                " WHERE   Expense_Description LIKE '" & Type & "%' " & _
                " ORDER BY Expense_Category, Expense_Description  "
        SQL.ReadQuery(query)
        lvType.Items.Clear()
        While SQL.SQLDR.Read
            lvType.Items.Add(SQL.SQLDR("Expense_ID").ToString)
            lvType.Items(lvType.Items.Count - 1).SubItems.Add(SQL.SQLDR("Expense_Category").ToString)
            lvType.Items(lvType.Items.Count - 1).SubItems.Add(SQL.SQLDR("Expense_Description").ToString)
            lvType.Items(lvType.Items.Count - 1).SubItems.Add(CDec(SQL.SQLDR("Amount")).ToString("N2"))
            lvType.Items(lvType.Items.Count - 1).SubItems.Add(SQL.SQLDR("Account_Code").ToString)
            lvType.Items(lvType.Items.Count - 1).SubItems.Add(SQL.SQLDR("AccntTitle").ToString)
        End While
    End Sub

    Protected Sub ClearText()
        txtType.Text = ""
        cbCategory.Text = ""
        txtAmount.Text = ""
        txtAccntCode.Text = ""
        txtAccntTitle.Text = ""
        txtSearch.Text = ""
        LoadCategory()
    End Sub

    Protected Sub EnableControl(ByVal Value As Boolean)
        cbCategory.Enabled = Value
        txtType.ReadOnly = Not Value
        txtAmount.ReadOnly = Not Value
        txtAccntTitle.ReadOnly = Not Value
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            Dim updateSQL As String
            updateSQL = " UPDATE tblCV_ExpenseType " & _
                        " SET    Status = 'Inactive' " & _
                        " WHERE  Expense_ID = '" & ID & "' "
            SQL.ExecNonQuery(updateSQL)
            MsgBox("Record removed successfully!", MsgBoxStyle.Information)
            ClearText()
            EnableControl(False)
            LoadType(txtSearch.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
            activityResult = False
        Finally
            '    RecordActivity(UserID, moduleID, "REMOVE", ID, activityResult)
            activityResult = True
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearText()
        EnableControl(True)
        btnSave.Text = "Save"
        btnSave.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EnableControl(True)
        btnSave.Text = "Update"
        btnSave.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim type As String = txtType.Text
        If cbCategory.Text = "" And cbCategory.SelectedIndex = -1 Then
            MsgBox("Please enter category for this type", MsgBoxStyle.Exclamation)
        ElseIf txtType.Text = "" Then
            MsgBox("Please enter type of disbursement", MsgBoxStyle.Exclamation)
        ElseIf txtAccntCode.Text = "" Then
            MsgBox("Please enter debit default entry for this disbursement type", MsgBoxStyle.Exclamation)
        ElseIf btnSave.Text = "Save" Then
            Try
                Dim insertSQL As String
                insertSQL = " INSERT INTO " & _
                            " tblCV_ExpenseType(Expense_Category, Expense_Description, Account_Code, Amount, Who_Created) " & _
                            " VALUES(@Expense_Category, @Expense_Description, @Account_Code, @Amount, @Who_Created) "
                SQL.FlushParams()
                SQL.AddParam("@Expense_Category", cbCategory.Text)
                SQL.AddParam("@Expense_Description", txtType.Text)
                SQL.AddParam("@Account_Code", txtAccntCode.Text)
                SQL.AddParam("@Amount", CDec(txtAmount.Text))
                SQL.AddParam("@Who_Created", UserID)
                SQL.ExecNonQuery(insertSQL)
                MsgBox("New type saved Successfully!", MsgBoxStyle.Information)
                ClearText()
                EnableControl(False)
                LoadType(txtSearch.Text)
                btnSave.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
                activityResult = False
            Finally
                '   RecordActivity(UserID, moduleID, "INSERT", type, activityResult)
                activityResult = True
            End Try
        ElseIf btnSave.Text = "Update" Then
            Try
                Dim updateSQL As String
                updateSQL = " UPDATE tblCV_ExpenseType " & _
                            " SET    Expense_Category = @Expense_Category, Expense_Description = @Expense_Description, Account_Code = @Account_Code, " & _
                            "        Amount = @Amount, Date_Modified = GETDATE(), Who_Modified = @Who_Modified " & _
                            " WHERE  Expense_ID = @Expense_ID "
                SQL.FlushParams()
                SQL.AddParam("@Expense_Category", cbCategory.Text)
                SQL.AddParam("@Expense_Description", txtType.Text)
                SQL.AddParam("@Account_Code", txtAccntCode.Text)
                SQL.AddParam("@Amount", CDec(txtAmount.Text))
                SQL.AddParam("@Who_Modified", UserID)
                SQL.AddParam("@Expense_ID", ID)
                SQL.ExecNonQuery(updateSQL)
                EnableControl(False)
                LoadType(txtSearch.Text)
                MsgBox("Record Updated Successfully!", MsgBoxStyle.Information)
                btnSave.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
                activityResult = False
            Finally
                '     RecordActivity(UserID, moduleID, "UPDATE", type, activityResult)
            End Try
        End If
    End Sub

    Private Sub lvType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvType.Click
        If lvType.SelectedItems.Count > 0 Then
            ID = lvType.Items(lvType.SelectedItems(0).Index).SubItems(chID.Index).Text()
            cbCategory.Text = lvType.Items(lvType.SelectedItems(0).Index).SubItems(chCategory.Index).Text()
            txtType.Text = lvType.Items(lvType.SelectedItems(0).Index).SubItems(chType.Index).Text()
            txtAmount.Text = lvType.Items(lvType.SelectedItems(0).Index).SubItems(chAmount.Index).Text()
            txtAccntCode.Text = lvType.Items(lvType.SelectedItems(0).Index).SubItems(chAccntCode.Index).Text()
            txtAccntTitle.Text = lvType.Items(lvType.SelectedItems(0).Index).SubItems(chAccntTitle.Index).Text()
            EnableControl(False)
        End If
    End Sub

    Private Sub txtAccntTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccntTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmCOA_Search
            f.ShowDialog("AccntTitle", txtAccntTitle.Text)
            txtAccntTitle.Text = f.accttile
            txtAccntCode.Text = f.accountcode
            f.Dispose()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        LoadType(txtSearch.Text)
    End Sub

    Private Sub txtAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class