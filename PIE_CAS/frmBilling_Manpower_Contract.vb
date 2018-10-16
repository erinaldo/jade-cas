Public Class frmBilling_Manpower_Contract
    Dim category As String
    Dim contractNo As Integer

    Private Sub frmBilling_Manpower_Contract_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        RefreshForm()
    End Sub

    Private Sub RefreshForm()
        LoadCategory()
        LoadLedgerList()
        LoadContractList()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        frmBilling_Manpower_Charges.ShowDialog()
    End Sub

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtCode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
        End If
    End Sub

    Private Sub LoadCategory()
        Dim query As String
        query = " SELECT DISTINCT Category FROM tblManpower_Charges WHERE Status='Active'"
        SQL.ReadQuery(query)
        cbCategory.Items.Clear()
        While SQL.SQLDR.Read
            cbCategory.Items.Add(SQL.SQLDR("Category").ToString)
        End While
        For Each item As ListViewItem In lvCategory.Items
            If cbCategory.Items.Contains(item.SubItems(chCategory.Index).Text) Then
                cbCategory.Items.Remove(item.SubItems(chCategory.Index).Text)
            End If
        Next
    End Sub

    Private Sub LoadCharges(ByVal Category As String)
        Dim query As String
        query = " SELECT DISTINCT Charge_Code FROM tblManpower_Charges WHERE Status='Active' AND Category ='" & Category & "'"
        SQL.ReadQuery(query)
        lvCharges.Items.Clear()
        While SQL.SQLDR.Read
            lvCharges.Items.Add(SQL.SQLDR("Charge_Code"))
        End While
        dgvCharges.Rows.Clear()
        For Each row As DataGridViewRow In dgvChargesAll.Rows
            For Each item As ListViewItem In lvCharges.Items
                If row.Cells(dcAllCode.Index).Value = item.SubItems(chCharges.Index).Text Then
                    dgvCharges.Rows.Add({row.Cells(dcAllCode.Index).Value, row.Cells(dcAllMethod.Index).Value, row.Cells(dcAllRate.Index).Value, row.Cells(dcAllAdmin.Index).Value})
                    item.Remove()
                End If
            Next
        Next
        RefreshGroup()
    End Sub

    Private Sub RefeshCharges()
        dgvCharges.Rows.Clear()
        For Each row As DataGridViewRow In dgvChargesAll.Rows
            If row.Cells(dcAllCategory.Index).Value = category Then
                dgvCharges.Rows.Add({row.Cells(dcAllCode.Index).Value, row.Cells(dcAllMethod.Index).Value, row.Cells(dcAllRate.Index).Value, row.Cells(dcAllAdmin.Index).Value})
             End If
        Next
        RefreshGroup()
    End Sub

    Private Sub LoadLedgerList()
        SQL.CloseCon()
        SetPayrollDatabase()
        Dim query As String
        query = " SELECT Description FROM tblOrg_CostHeader WHERE Status ='Active' "
        SQL_RUBY.ReadQuery(query)
        cbGroup.Items.Clear()
        While SQL_RUBY.SQLDR.Read
            cbGroup.Items.Add(SQL_RUBY.SQLDR("Description").ToString)
        End While
        SQL_RUBY.CloseCon()
        SetDatabase()
    End Sub

    
    Private Sub lvCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCategory.SelectedIndexChanged, lvCategory.Click
        If lvCategory.SelectedItems.Count = 1 Then
            category = lvCategory.SelectedItems(0).SubItems(chCategory.Index).Text
            LoadCharges(category)
        End If
    End Sub

    Private Sub btnCatAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnCatAdd.Click
        If cbCategory.SelectedIndex <> -1 Then
            category = cbCategory.SelectedItem
            lvCategory.Items.Add(category)
            LoadCharges(category)
            LoadCategory()
        End If
    End Sub

    Private Sub btnCatRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnCatRemove.Click
        If lvCategory.SelectedItems.Count = 1 Then
            lvCategory.SelectedItems(0).Remove()
            LoadCharges("")
            LoadCategory()
        End If
    End Sub

    Private Sub btnAddAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAll.Click
        If lvCharges.Items.Count > 0 Then
            For Each item As ListViewItem In lvCharges.Items
                dgvChargesAll.Rows.Add({category, item.SubItems(chCharges.Index).Text, "(Default)", "", True})
            Next
            LoadCharges(category)
        End If
    End Sub

    Private Sub btnAddSpecific_Click(sender As System.Object, e As System.EventArgs) Handles btnAddSpecific.Click
        If lvCharges.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In lvCharges.SelectedItems
                dgvChargesAll.Rows.Add({category, item.SubItems(chCharges.Index).Text, "(Default)", "", True})
            Next
            LoadCharges(category)
        End If
    End Sub


    Private Sub btnRemSpecific_Click(sender As System.Object, e As System.EventArgs) Handles btnRemSpecific.Click
        If dgvCharges.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvCharges.SelectedRows
                For Each row2 As DataGridViewRow In dgvChargesAll.Rows
                    If row.Cells(dcCode.Index).Value = row2.Cells(dcAllCode.Index).Value Then
                        dgvChargesAll.Rows.RemoveAt(row2.Index)
                    End If
                Next
            Next
            LoadCharges(category)
        End If
    End Sub

    Private Sub btnRemAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRemAll.Click
        If dgvCharges.Rows.Count > 0 Then
            For i As Integer = dgvChargesAll.Rows.Count - 1 To 0 Step -1
                If dgvChargesAll.Rows(i).Cells(dcAllCategory.Index).Value = category Then
                    dgvChargesAll.Rows.RemoveAt(i)
                End If
            Next
            LoadCharges(category)
        End If
    End Sub

    Private Sub RefreshGroup()
        For Each item As DataGridViewRow In dgvCharges.Rows
            Dim dgvCB As DataGridViewComboBoxCell
            dgvCB = dgvCharges.Item(dcCalcMethod.Index, item.Index)
            dgvCB.Items.Clear()
            dgvCB.Items.Add("(Default)")
            dgvCB.Items.Add("Per Hour")
            dgvCB.Items.Add("Per Day")
            dgvCB.Items.Add("Fixed Amount")
            dgvCB.Items.Add("Percent")
        Next
        For Each item As DataGridViewRow In dgvChargesAll.Rows
            Dim dgvCB As DataGridViewComboBoxCell
            dgvCB = dgvChargesAll.Item(dcAllMethod.Index, item.Index)
            dgvCB.Items.Clear()
            dgvCB.Items.Add("(Default)")
            dgvCB.Items.Add("Per Hour")
            dgvCB.Items.Add("Per Day")
            dgvCB.Items.Add("Fixed Amount")
            dgvCB.Items.Add("Percent")
        Next
    End Sub

    Private Sub dgvCharges_Click1(sender As Object, e As System.EventArgs) Handles dgvCharges.Click
        If dgvCharges.SelectedCells.Count > 0 Then
            For Each cell As DataGridViewCell In dgvCharges.SelectedCells
                If cell.ColumnIndex = dcCode.Index Then
                    dgvCharges.Rows(cell.RowIndex).Selected = True
                End If
            Next
        End If
    End Sub

    Private Sub lvCharges_Click(sender As System.Object, e As System.EventArgs) Handles lvCharges.Click
        For Each cell As DataGridViewCell In dgvCharges.SelectedCells
            cell.Selected = False
        Next
    End Sub

    Private Sub btnCatUp_Click(sender As System.Object, e As System.EventArgs) Handles btnCatUp.Click
        Dim ID As String
        If lvCategory.SelectedItems.Count = 1 Then
            If lvCategory.SelectedItems(0).Index <> 0 Then
                ID = lvCategory.Items(lvCategory.SelectedItems(0).Index - 1).SubItems(0).Text
                lvCategory.Items(lvCategory.SelectedItems(0).Index - 1).SubItems(0).Text = lvCategory.Items(lvCategory.SelectedItems(0).Index).SubItems(0).Text
                lvCategory.Items(lvCategory.SelectedItems(0).Index).SubItems(0).Text = ID
                lvCategory.Items(lvCategory.SelectedItems(0).Index - 1).Selected = True
                lvCategory.Items(lvCategory.SelectedItems(0).Index).Focused = True
                lvCategory.Focus()
            Else
                lvCategory.Items(0).Selected = True
                lvCategory.Items(lvCategory.SelectedItems(0).Index).Focused = True
                lvCategory.Focus()
            End If

        End If
    End Sub

    Private Sub btnCatDown_Click(sender As System.Object, e As System.EventArgs) Handles btnCatDown.Click
        Dim ID As String
        If lvCategory.SelectedItems.Count = 1 Then
            If lvCategory.SelectedItems(0).Index <> lvCategory.Items.Count - 1 Then
                ID = lvCategory.Items(lvCategory.SelectedItems(0).Index + 1).SubItems(0).Text
                lvCategory.Items(lvCategory.SelectedItems(0).Index + 1).SubItems(0).Text = lvCategory.Items(lvCategory.SelectedItems(0).Index).SubItems(0).Text
                lvCategory.Items(lvCategory.SelectedItems(0).Index).SubItems(0).Text = ID
                lvCategory.Items(lvCategory.SelectedItems(0).Index + 1).Selected = True
                lvCategory.Items(lvCategory.SelectedItems(0).Index).Focused = True
                lvCategory.Focus()
            Else
                lvCategory.Items(lvCategory.Items.Count - 1).Selected = True
                lvCategory.Items(lvCategory.SelectedItems(0).Index).Focused = True
                lvCategory.Focus()
            End If
        End If
    End Sub

    Private Sub btnChargeUp_Click(sender As System.Object, e As System.EventArgs) Handles btnChargeUp.Click
        Dim Code, Method, Rate, Code2 As String
        Dim index As Integer
        Dim Admin As Boolean
        If dgvCharges.SelectedRows.Count = 1 Then
            If dgvCharges.SelectedRows(0).Index <> 0 Then
                Code = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index - 1).Cells(dcCode.Index).Value
                Method = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index - 1).Cells(dcCalcMethod.Index).Value
                Rate = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index - 1).Cells(dcRate.Index).Value
                Admin = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index - 1).Cells(dcAdminFee.Index).Value
                Code2 = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcCode.Index).Value
                For Each row As DataGridViewRow In dgvChargesAll.Rows
                    If row.Cells(dcAllCode.Index).Value = Code AndAlso row.Cells(dcAllCategory.Index).Value = category Then
                        row.Cells(dcAllCode.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcCode.Index).Value
                        row.Cells(dcAllMethod.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcCalcMethod.Index).Value
                        row.Cells(dcAllRate.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcRate.Index).Value
                        row.Cells(dcAllAdmin.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcAdminFee.Index).Value
                        index = row.Index
                    End If
                    If row.Index <> index Then
                        If row.Cells(dcAllCode.Index).Value = Code2 AndAlso row.Cells(dcAllCategory.Index).Value = category Then
                            row.Cells(dcAllCode.Index).Value = Code
                            row.Cells(dcAllMethod.Index).Value = Method
                            row.Cells(dcAllRate.Index).Value = Rate
                            row.Cells(dcAllAdmin.Index).Value = Admin
                            Exit For
                        End If
                    End If
                Next
                RefeshCharges()
                For Each row As DataGridViewRow In dgvCharges.Rows
                    If row.Cells(dcCode.Index).Value = Code2 Then
                        row.Selected = True
                        dgvCharges.Focus()
                        index = row.Index
                        Exit For
                    End If
                Next
                For Each cell As DataGridViewCell In dgvCharges.SelectedCells
                    If cell.RowIndex <> index Then
                        cell.Selected = False
                    End If
                Next
            Else
                dgvCharges.Rows(0).Selected = True
                dgvCharges.Focus()
            End If
        End If
    End Sub

   
    Private Sub btnChargeDown_Click(sender As System.Object, e As System.EventArgs) Handles btnChargeDown.Click
        Dim Code, Method, Rate, Code2 As String
        Dim index As Integer
        Dim Admin As Boolean
        If dgvCharges.SelectedRows.Count = 1 Then
            If dgvCharges.SelectedRows(0).Index <> dgvCharges.Rows.Count - 1 Then
                Code = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcCode.Index).Value
                Method = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcCalcMethod.Index).Value
                Rate = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcRate.Index).Value
                Admin = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index).Cells(dcAdminFee.Index).Value
                Code2 = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index + 1).Cells(dcCode.Index).Value
                For Each row As DataGridViewRow In dgvChargesAll.Rows
                    If row.Cells(dcAllCode.Index).Value = Code AndAlso row.Cells(dcAllCategory.Index).Value = category Then
                        row.Cells(dcAllCode.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index + 1).Cells(dcCode.Index).Value
                        row.Cells(dcAllMethod.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index + 1).Cells(dcCalcMethod.Index).Value
                        row.Cells(dcAllRate.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index + 1).Cells(dcRate.Index).Value
                        row.Cells(dcAllAdmin.Index).Value = dgvCharges.Rows(dgvCharges.SelectedRows(0).Index + 1).Cells(dcAdminFee.Index).Value
                        index = row.Index
                    End If
                    If row.Index <> index Then
                        If row.Cells(dcAllCode.Index).Value = Code2 AndAlso row.Cells(dcAllCategory.Index).Value = category Then
                            row.Cells(dcAllCode.Index).Value = Code
                            row.Cells(dcAllMethod.Index).Value = Method
                            row.Cells(dcAllRate.Index).Value = Rate
                            row.Cells(dcAllAdmin.Index).Value = Admin
                            Exit For
                        End If
                    End If
                Next
                RefeshCharges()
                For Each row As DataGridViewRow In dgvCharges.Rows
                    If row.Cells(dcCode.Index).Value = Code Then
                        row.Selected = True
                        dgvCharges.Focus()
                        index = row.Index
                        Exit For
                    End If
                Next
                For Each cell As DataGridViewCell In dgvCharges.SelectedCells
                    If cell.RowIndex <> index Then
                        cell.Selected = False
                    End If
                Next
            Else
                dgvCharges.Rows(dgvCharges.Rows.Count - 1).Selected = True
                dgvCharges.Focus()
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtVCEName.Text = "" Then
            MsgBox("Please enter VCE Name!", MsgBoxStyle.Exclamation)
        ElseIf txtAdminFee.Text <> "" AndAlso Not IsNumeric(txtAdminFee.Text) Then
            MsgBox("Admin fee should be numeric!", MsgBoxStyle.Exclamation)
        ElseIf MsgBox("Are you sure you want to save this contract?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If btnSave.Text = "Save" Then
                SaveContract()
                MsgBox("Contract saved succesfully!", MsgBoxStyle.Information)
            Else
                UpdateContract()
                MsgBox("Contract updated succesfully!", MsgBoxStyle.Information)
            End If
            ClearText()
            LoadContractList()
        End If
    End Sub

    Private Sub SaveContract()
        Try
            Dim contract_ID As Integer = GetContractID()
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblManpower_Contract(Contract_No, VCECode, Contract_Start_Date, Default_Group, Admin_Fee, Status) " & _
                        " VALUES(@Contract_No, @VCECode, @Contract_Start_Date, @Default_Group, @Admin_Fee, @Status) "
            SQL.FlushParams()
            SQL.AddParam("@Contract_No", contract_ID)
            SQL.AddParam("@VCECode", txtCode.Text)
            SQL.AddParam("@Contract_Start_Date", dtpContractDate.Value.Date)
            If cbGroup.SelectedIndex = -1 Then
                SQL.AddParam("@Default_Group", "")
            Else
                SQL.AddParam("@Default_Group", cbGroup.SelectedItem)
            End If
            SQL.AddParam("@Admin_Fee", CDec(txtAdminFee.Text))
            SQL.AddParam("@Status", "Active")
            SQL.ExecNonQuery(insertSQL)
            SaveContractDetail(contract_ID)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
            SQL.CloseCon()
        End Try
    End Sub

    Private Sub UpdateContract()
        Try
            Dim insertSQL As String
            insertSQL = " UPDATE tblManpower_Contract " & _
                        " SET    VCECode = @VCECode, Contract_Start_Date = @Contract_Start_Date, " & _
                        "        Default_Group = @Default_Group, Admin_Fee = @Admin_Fee  " & _
                        " WHERE  Contract_No = @Contract_No  "
            SQL.FlushParams()
            SQL.AddParam("@Contract_No", contractNo)
            SQL.AddParam("@VCECode", txtCode.Text)
            SQL.AddParam("@Contract_Start_Date", dtpContractDate.Value.Date)
            If cbGroup.SelectedIndex = -1 Then
                SQL.AddParam("@Default_Group", "")
            Else
                SQL.AddParam("@Default_Group", cbGroup.SelectedItem)
            End If
            SQL.AddParam("@Admin_Fee", CDec(txtAdminFee.Text))
            SQL.ExecNonQuery(insertSQL)
            SaveContractDetail(contractNo)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
            SQL.CloseCon()
        End Try
    End Sub

    Private Sub SaveContractDetail(ByVal Contract_ID As Integer)
        Dim sort_No As Integer = 1
        Dim charge_ID As Integer = 0
        Dim updateSQL As String
        updateSQL = " UPDATE tblManpower_ContractDetails " & _
                    " SET    Status ='Inactive', Date_Modified = GETDATE() " & _
                    " WHERE  Contract_No = @Contract_No "
        SQL.FlushParams()
        SQL.AddParam("@Contract_No", Contract_ID)
        SQL.ExecNonQuery(updateSQL)
        For Each item As ListViewItem In lvCategory.Items
            For Each row As DataGridViewRow In dgvChargesAll.Rows
                If row.Cells(dcAllCategory.Index).Value.ToString = item.SubItems(chCategory.Index).Text Then
                    charge_ID = GetChargeID(row.Cells(dcAllCode.Index).Value.ToString)
                    Dim insertSQL As String
                    insertSQL = " INSERT INTO " & _
                                " tblManpower_ContractDetails(Contract_No, Charge_ID, Method, Rate, Admin_Fee, Sort_No, Status) " & _
                                " VALUES(@Contract_No, @Charge_ID, @Method, @Rate, @Admin_Fee, @Sort_No, @Status) "
                    SQL.FlushParams()
                    SQL.AddParam("@Contract_No", Contract_ID)
                    SQL.AddParam("@Charge_ID", charge_ID)
                    SQL.AddParam("@Method", row.Cells(dcAllMethod.Index).Value.ToString)
                    If IsNumeric(row.Cells(dcAllRate.Index).Value) Then
                        SQL.AddParam("@Rate", CDec(row.Cells(dcAllRate.Index).Value))
                    Else
                        SQL.AddParam("@Rate", 0)
                    End If
                    SQL.AddParam("@Admin_Fee", row.Cells(dcAllAdmin.Index).Value)
                    SQL.AddParam("@Sort_No", sort_No)
                    SQL.AddParam("@Status", "Active")
                    SQL.ExecNonQuery(insertSQL)
                    sort_No += 1
                End If
            Next
        Next
    End Sub

    Private Function GetContractID() As Integer
        Dim query As String
        query = " SELECT MAX(Contract_No) + 1 AS Contract_No FROM tblManpower_Contract"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("Contract_No")) Then
            Return SQL.SQLDR("Contract_No")
        Else
            Return 1
        End If
    End Function

    Private Function GetChargeID(Code As String) As Integer
        Dim query As String
        query = " SELECT Charge_ID FROM tblManpower_Charges WHERE Charge_Code ='" & Code & "' AND Status ='Active' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("Charge_ID")) Then
            Return SQL.SQLDR("Charge_ID")
        Else
            Return 0
        End If
    End Function

    Private Sub LoadContractList()
        Dim query As String
        query = " SELECT  Contract_No, viewVCE_Master.VCECode, VCEName " & _
                " FROM	  tblManpower_Contract INNER JOIN viewVCE_Master " & _
                " ON	  tblManpower_Contract.VCECode = viewVCE_Master.VCECode " & _
                " AND	  viewVCE_Master.Status ='Active' " & _
                " WHERE	  tblManpower_Contract.Status ='Active' "
        SQL.ReadQuery(query)
        lvContract.Items.Clear()
        While SQL.SQLDR.Read
            lvContract.Items.Add(SQL.SQLDR("Contract_No").ToString)
            lvContract.Items(lvContract.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCECode").ToString)
            lvContract.Items(lvContract.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
        End While
    End Sub

    Private Sub LoadContract(ByVal Contract_No As Integer)
        Dim query As String
        query = " SELECT  Contract_No, viewVCE_Master.VCECode, VCEName, Contract_Start_Date, " & _
                "         Default_Group, Admin_Fee, Contract_End_Date, tblManpower_Contract.Status " & _
                " FROM	  tblManpower_Contract INNER JOIN viewVCE_Master " & _
                " ON	  tblManpower_Contract.VCECode = viewVCE_Master.VCECode " & _
                " AND	  viewVCE_Master.Status ='Active' " & _
                " WHERE	  tblManpower_Contract.Contract_No ='" & Contract_No & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            contractNo = SQL.SQLDR("Contract_No").ToString
            txtCode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            dtpContractDate.Value = SQL.SQLDR("Contract_Start_Date")
            cbGroup.SelectedItem = SQL.SQLDR("Default_Group").ToString
            txtAdminFee.Text = SQL.SQLDR("Admin_Fee").ToString
            If IsDBNull(SQL.SQLDR("Contract_End_Date")) Then
                dtpContractEnd.Visible = False
                lblContractEnd.Visible = False
            Else
                dtpContractEnd.Value = SQL.SQLDR("Contract_End_Date")
                dtpContractEnd.Visible = True
                lblContractEnd.Visible = True
            End If
            txtStatus.Text = SQL.SQLDR("Status").ToString
            LoadContractDetails(lvContract.SelectedItems(0).SubItems(chContractNo.Index).Text)
            If lvCategory.Items.Count >= 1 Then
                category = lvCategory.Items(0).SubItems(chCategory.Index).Text
                LoadCharges(category)
            End If
            LoadCategory()
            btnSave.Text = "Update"
        Else
            ClearText()
        End If
    End Sub

    Private Sub ClearText()
        contractNo = 0
        txtCode.Clear()
        txtVCEName.Clear()
        cbGroup.SelectedIndex = -1
        txtAdminFee.Clear()
        txtStatus.Clear()
        dtpContractEnd.Visible = False
        lblContractEnd.Visible = False
        dgvChargesAll.Rows.Clear()
        dgvCharges.Rows.Clear()
        lvCategory.Items.Clear()
        lvCharges.Items.Clear()
        lvContract.SelectedItems.Clear()
        btnSave.Text = "Save"
        RefreshForm()
    End Sub

    Private Sub LoadContractDetails(ByVal Contract_No As Integer)
        Dim query As String
        query = " SELECT  DISTINCT Category,  MAX(Sort_No) OVER (PARTITION BY Category ) AS A " & _
                " FROM	  tblManpower_ContractDetails INNER JOIN tblManpower_Charges " & _
                " ON	  tblManpower_ContractDetails.Charge_ID = tblManpower_Charges.Charge_ID " & _
                " AND	  tblManpower_Charges.Status = 'Active' " & _
                " WHERE   tblManpower_ContractDetails.Status = 'Active' " & _
                " AND     tblManpower_ContractDetails.Contract_No ='" & Contract_No & "' " & _
                " ORDER BY A "
        SQL.ReadQuery(query)
        lvCategory.Items.Clear()
        While SQL.SQLDR.Read
            lvCategory.Items.Add(SQL.SQLDR("Category").ToString)
        End While
        query = " SELECT  Category, Charge_Code, Method, CASE WHEN Rate = 0 THEN '' ELSE CAST(Rate AS nvarchar) END AS Rate , Admin_Fee, Sort_No " & _
                " FROM	  tblManpower_ContractDetails INNER JOIN tblManpower_Charges " & _
                " ON	  tblManpower_ContractDetails.Charge_ID = tblManpower_Charges.Charge_ID " & _
                " AND	  tblManpower_Charges.Status = 'Active' " & _
                " WHERE   tblManpower_ContractDetails.Status = 'Active' " & _
                " AND     tblManpower_ContractDetails.Contract_No ='" & Contract_No & "' "
        SQL.ReadQuery(query)
        dgvChargesAll.Rows.Clear()
        While SQL.SQLDR.Read
            dgvChargesAll.Rows.Add({SQL.SQLDR("Category").ToString, SQL.SQLDR("Charge_Code").ToString, SQL.SQLDR("Method").ToString, _
                                    SQL.SQLDR("Rate").ToString, SQL.SQLDR("Admin_Fee"), SQL.SQLDR("Sort_No")})
        End While
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        ClearText()
    End Sub

    Private Sub lvContract_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvContract.SelectedIndexChanged
        If lvContract.SelectedItems.Count = 1 Then
            LoadContract(lvContract.SelectedItems(0).SubItems(chContractNo.Index).Text)
        End If
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            If lvContract.SelectedItems.Count = 1 Then
                If MsgBox("Are you sure you want to remove this contract?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim updateSQL As String
                    updateSQL = " UPDATE tblManpower_Contract " & _
                                " SET    Status='Inactive', Contract_End_Date = CAST(GETDATE() AS Date)  " & _
                                " WHERE  Contract_No = @Contract_No  "
                    SQL.FlushParams()
                    SQL.AddParam("@Contract_No", contractNo)
                    SQL.ExecNonQuery(updateSQL)
                    MsgBox("Contract removed succesfully", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
            SQL.CloseCon()
        End Try
    End Sub

    Private Sub dgvCharges_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCharges.CellEndEdit
        If e.RowIndex <> -1 And e.ColumnIndex <> -1 Then
            For Each row As DataGridViewRow In dgvChargesAll.Rows
                If row.Cells(dcAllCode.Index).Value = dgvCharges.Item(dcCode.Index, e.RowIndex).Value Then
                    row.Cells(dcAllMethod.Index).Value = dgvCharges.Item(dcCalcMethod.Index, e.RowIndex).Value
                    row.Cells(dcAllRate.Index).Value = dgvCharges.Item(dcRate.Index, e.RowIndex).Value
                    row.Cells(dcAllAdmin.Index).Value = dgvCharges.Item(dcAdminFee.Index, e.RowIndex).Value
                End If
            Next
        End If
    End Sub
End Class