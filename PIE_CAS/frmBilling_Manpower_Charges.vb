Public Class frmBilling_Manpower_Charges
    Dim charge_ID As Integer = 0
    Dim charge_Code As String

    Private Sub frmBilling_Manpower_Charges_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RefreshForm()
    End Sub

    Private Sub LoadCategory()
        Dim query As String
        query = " SELECT DISTINCT Category FROM tblManpower_Charges WHERE Status='Active'"
        SQL.ReadQuery(query)
        cbCategory.Items.Clear()
        While SQL.SQLDR.Read
            cbCategory.Items.Add(SQL.SQLDR("Category").ToString)
        End While
    End Sub

    Private Sub LoadCharges()
        Dim query As String
        query = " SELECT Charge_ID, Charge_Code, Description, Category, Ledger_Code FROM tblManpower_Charges WHERE Status='Active'"
        SQL.ReadQuery(query)
        lvCharges.Items.Clear()
        While SQL.SQLDR.Read
            lvCharges.Items.Add(SQL.SQLDR("Charge_ID"))
            lvCharges.Items(lvCharges.Items.Count - 1).SubItems.Add(SQL.SQLDR("Charge_Code").ToString)
            lvCharges.Items(lvCharges.Items.Count - 1).SubItems.Add(SQL.SQLDR("Description").ToString)
            lvCharges.Items(lvCharges.Items.Count - 1).SubItems.Add(SQL.SQLDR("Category").ToString)
            lvCharges.Items(lvCharges.Items.Count - 1).SubItems.Add(SQL.SQLDR("Ledger_Code").ToString)
        End While
    End Sub

    Private Sub LoadLedgerList()
        SQL.CloseCon()
        SetPayrollDatabase()
        Dim query As String
        query = " SELECT Ledger_Name FROM viewLedger_Type WHERE Status ='Active' "
        SQL_RUBY.ReadQuery(query)
        cbLedger.Items.Clear()
        While SQL_RUBY.SQLDR.Read
            cbLedger.Items.Add(SQL_RUBY.SQLDR("Ledger_Name").ToString)
        End While
        For Each item As ListViewItem In lvCharges.Items
            If cbLedger.Items.Contains(item.SubItems(chPayrollCode.Index).Text) Then
                cbLedger.Items.Remove(item.SubItems(chPayrollCode.Index).Text)
            End If
        Next
        SQL_RUBY.CloseCon()
        SetDatabase()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        ClearText()
    End Sub

    Private Sub ClearText()
        txtCode.Clear()
        txtDescription.Clear()
        cbLedger.Text = ""
        btnSave.Text = "Save"
    End Sub

    Private Sub lvCharges_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCharges.SelectedIndexChanged, lvCharges.Click
        If lvCharges.SelectedItems.Count = 1 Then
            charge_ID = lvCharges.SelectedItems(0).SubItems(chID.Index).Text
            txtCode.Text = lvCharges.SelectedItems(0).SubItems(chCode.Index).Text
            txtDescription.Text = lvCharges.SelectedItems(0).SubItems(chDescription.Index).Text
            cbLedger.Text = lvCharges.SelectedItems(0).SubItems(chPayrollCode.Index).Text
            cbCategory.Text = lvCharges.SelectedItems(0).SubItems(chCategory.Index).Text
            charge_Code = lvCharges.SelectedItems(0).SubItems(chCode.Index).Text
            btnSave.Text = "Update"
        Else
            ClearText()
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtCode.Text = "" Then
            MsgBox("Please enter code for this charge!", MsgBoxStyle.Exclamation)
        ElseIf txtDescription.Text = "" Then
            MsgBox("Please enter description for this code!", MsgBoxStyle.Exclamation)
        ElseIf cbLedger.Text <> "" AndAlso Not cbLedger.Items.Contains(cbLedger.Text) Then
            MsgBox("Invalid payroll ledger code!", MsgBoxStyle.Exclamation)
        Else
            If btnSave.Text = "Save" Then
                If CodeExist(txtCode.Text) Then
                    MsgBox("This charge code already exist! Please enter differenct charge code", MsgBoxStyle.Exclamation)
                    txtCode.Select()
                ElseIf MsgBox("Are you sure you want to save this charge?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    SaveCharge()
                    MsgBox("Record saved succesfully!", MsgBoxStyle.Information)
                    RefreshForm()
                    ClearText()
                End If
            ElseIf btnSave.Text = "Update" Then
                If txtCode.Text <> charge_Code AndAlso CodeExist(txtCode.Text) Then
                    MsgBox("This charge code already exist! Please enter differenct charge code", MsgBoxStyle.Exclamation)
                    txtCode.Select()
                ElseIf MsgBox("Are you sure you want to update this charge?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    UpdateCharge()
                    MsgBox("Record saved succesfully!", MsgBoxStyle.Information)
                    RefreshForm()
                    ClearText()
                End If
            End If

        End If
    End Sub

    Private Function CodeExist(Code As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblManpower_Charges WHERE Charge_Code ='" & Code & "' AND Status ='Active'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SaveCharge()
        Try
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblManpower_Charges(Charge_Code, Description, Ledger_Code, Category) " & _
                        " VALUES(@Charge_Code, @Description, @Ledger_Code, @Category)"
            SQL.FlushParams()
            SQL.AddParam("@Charge_Code", txtCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@Ledger_Code", cbLedger.Text)
            SQL.AddParam("@Category", cbCategory.Text)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.CloseCon()
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateCharge()
        Try
            Dim updateSQL As String
            updateSQL = " UPDATE tblManpower_Charges " & _
                        " SET    Charge_Code = @Charge_Code, Description = @Description, Ledger_Code = @Ledger_Code, Category = @Category " & _
                        " WHERE  Charge_ID = @Charge_ID "
            SQL.FlushParams()
            SQL.AddParam("@Charge_ID", charge_ID)
            SQL.AddParam("@Charge_Code", txtCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@Ledger_Code", cbLedger.Text)
            SQL.AddParam("@Category", cbCategory.Text)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.CloseCon()
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            If lvCharges.SelectedItems.Count = 1 Then
                If MsgBox("Are you sure you want to remove this charge? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim updateSQL As String
                    updateSQL = " UPDATE tblManpower_Charges " & _
                                " SET    Status ='Inactive' " & _
                                " WHERE  Charge_ID = @Charge_ID "
                    SQL.FlushParams()
                    SQL.AddParam("@Charge_ID", charge_ID)
                    SQL.ExecNonQuery(updateSQL)
                    MsgBox("Record removed succesfully!", MsgBoxStyle.Information)
                    RefreshForm()
                    ClearText()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.CloseCon()
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        RefreshForm()
    End Sub

    Private Sub RefreshForm()
        LoadCategory()
        LoadCharges()
        LoadLedgerList()
    End Sub
End Class