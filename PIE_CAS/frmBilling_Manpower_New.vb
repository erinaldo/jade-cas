Public Class frmBilling_Manpower_New
    Dim paydate As Date
    Dim disableEvent As Boolean = False
    Dim charges, detailed, detailed2, detailedHrs As New DataTable
    Dim adminOther As Decimal = 0
    Dim transID As String


    Public Overloads Function ShowDialog(ByVal Trans As String) As Boolean
        transID = Trans
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmBilling_Payroll_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadContractClient()
        LoadPeriodList()
        cbEmpType.SelectedIndex = 0
        btnSave.Text = "Save"
        If transID <> "" Then
            LoadBillingDetails(transID)
        End If
    End Sub

    Private Sub LoadBillingDetails(ByRef TransID As Integer)
        Dim query As String
        Dim group As String
        query = " SELECT  tblManpower_Billing.VCECode, VCEName, BS_Date, Due_Date, BS_Period, Remarks,  " & _
                "         Filter_Group, Filter_Data, Emp_Type, Total_Amount, Admin_Fee, " & _
                "         Total_Amount + Admin_Fee AS Gross, VAT, EWT, Total_Amount + Admin_Fee + VAT - EWT AS Net " & _
                " FROM	  tblManpower_Billing INNER JOIN viewVCE_Master " & _
                " ON      tblManpower_Billing.VCECode = viewVCE_Master.VCECode " & _
                " WHERE	  TransID ='" & TransID & "' "
        SQL.ReadQuery(query)
        dgvCharges.Rows.Clear()
        If SQL.SQLDR.Read Then
            disableEvent = True
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            cbVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtBSNo.Text = TransID
            dtpBSDate.Value = SQL.SQLDR("BS_Date").ToString
            dtpDueDate.Value = SQL.SQLDR("Due_Date").ToString
            cbCutoff.SelectedItem = SQL.SQLDR("BS_Period").ToString
            cbFilter.SelectedItem = SQL.SQLDR("Filter_Group").ToString
            group = SQL.SQLDR("Filter_Data").ToString
            cbEmpType.SelectedItem = SQL.SQLDR("Emp_Type").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtAmount.Text = CDec(SQL.SQLDR("Total_Amount")).ToString("N2")
            txtAdmin.Text = CDec(SQL.SQLDR("Admin_Fee")).ToString("N2")
            txtGross.Text = CDec(SQL.SQLDR("Admin_Fee")).ToString("N2")
            txtVAT.Text = CDec(SQL.SQLDR("VAT")).ToString("N2")
            txtEWT.Text = CDec(SQL.SQLDR("EWT")).ToString("N2")
            txtAmountDue.Text = CDec(SQL.SQLDR("Net")).ToString("N2")
            LoadFilter()
            cbFilter2.SelectedItem = group
            LoadEmp()
            LoadBillingCharges(TransID)
            btnSave.Text = "Update"
            disableEvent = False
        End If

    End Sub

    Private Sub LoadBillingCharges(ByRef TransID As Integer)
        Dim query As String
        Dim daysHrs, Amount, GrandTotal As Decimal
        daysHrs = 0
        Amount = 0
        GrandTotal = 0
        query = " SELECT Category, Type, SUM(Days_Hours) AS Days_Hours, SUM(Amount) AS Amount,  " & _
                " 		ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Sort_No) AS RowNum, " & _
                " 		COUNT(Category) OVER (PARTITION BY Category ) AS MaxRow, Sort_No " & _
                "  FROM   tblManpower_Billing INNER JOIN tblManpower_BillingDetails   " & _
                "  ON	   tblManpower_Billing.TransID = tblManpower_BillingDetails.BS_Ref  " & _
                "  INNER JOIN   " & _
                "  (  " & _
                "  	SELECT	VCECode, Charge_Code, Sort_No  " & _
                "  	FROM	tblManpower_Contract INNER JOIN tblManpower_ContractDetails   " & _
                "  	ON		tblManpower_Contract.Contract_No = tblManpower_ContractDetails.Contract_No  " & _
                "  	AND		tblManpower_ContractDetails.Status = 'Active'  " & _
                "  	INNER JOIN tblManpower_Charges  " & _
                "  	ON		tblManpower_ContractDetails.Charge_ID = tblManpower_Charges.Charge_ID  " & _
                "  	AND		tblManpower_Charges.Status = 'Active'  " & _
                "  )  AS A  " & _
                "  ON A.Charge_Code = tblManpower_BillingDetails.Type  " & _
                "  AND A.VCECode = tblManpower_Billing.VCECode  " & _
                "  WHERE     TransID ='" & TransID & "'  " & _
                "  GROUP BY Category, Type, Sort_No  " & _
                "  HAVING SUM(Amount) <> 0  " & _
                "  ORDER BY Sort_No "
        SQL.ReadQuery(query)
        dgvCharges.Rows.Clear()
        While SQL.SQLDR.Read
            If SQL.SQLDR("RowNum") = 1 Then
                If SQL.SQLDR("Days_Hours") = 0 Then
                    dgvCharges.Rows.Add({SQL.SQLDR("Category").ToString, SQL.SQLDR("Type").ToString, "", CDec(SQL.SQLDR("Amount")).ToString("N2")})
                Else
                    dgvCharges.Rows.Add({SQL.SQLDR("Category").ToString, SQL.SQLDR("Type").ToString, CDec(SQL.SQLDR("Days_Hours")).ToString, CDec(SQL.SQLDR("Amount")).ToString("N2")})
                End If
            Else
                If SQL.SQLDR("Days_Hours") = 0 Then
                    dgvCharges.Rows.Add({"", SQL.SQLDR("Type").ToString, "", CDec(SQL.SQLDR("Amount")).ToString("N2")})
                Else
                    dgvCharges.Rows.Add({"", SQL.SQLDR("Type").ToString, CDec(SQL.SQLDR("Days_Hours")).ToString, CDec(SQL.SQLDR("Amount")).ToString("N2")})
                End If
            End If
            daysHrs += SQL.SQLDR("Days_Hours")
            Amount += SQL.SQLDR("Amount")
            GrandTotal += SQL.SQLDR("Amount")
            If SQL.SQLDR("RowNum") = SQL.SQLDR("MaxRow") And SQL.SQLDR("RowNum") <> 1 Then
                If daysHrs = 0 Then
                    dgvCharges.Rows.Add({SQL.SQLDR("Category").ToString & " Total", "", "", CDec(Amount).ToString("N2")})
                Else
                    dgvCharges.Rows.Add({SQL.SQLDR("Category").ToString & " Total", "", CDec(daysHrs).ToString("N2"), CDec(Amount).ToString("N2")})
                End If
                dgvCharges.Rows(dgvCharges.Rows.Count - 1).DefaultCellStyle.Font = New Font(dgvCharges.Font, FontStyle.Bold)
                daysHrs = 0
                Amount = 0
            End If
        End While
        dgvCharges.Rows.Add({"Grand Total", "", "", CDec(GrandTotal).ToString("N2")})
        dgvCharges.Rows(dgvCharges.Rows.Count - 1).DefaultCellStyle.Font = New Font(dgvCharges.Font, FontStyle.Bold)
    End Sub

    Private Sub LoadEmp()
        Dim query As String
        query = " SELECT DISTINCT Emp_ID, Emp_Name, Emp_Status, Payroll_Period " & _
                " FROM tblManpower_BillingDetails " & _
                " WHERE BS_Ref ='" & txtBSNo.Text & "' AND Emp_ID <> '' "
        SQL.ReadQuery(query)
        lvSelected.Items.Clear()
        While SQL.SQLDR.Read
            lvSelected.Items.Add(SQL.SQLDR("Emp_ID").ToString)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(SQL.SQLDR("Emp_Name").ToString)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(SQL.SQLDR("Emp_Status").ToString)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(SQL.SQLDR("Payroll_Period").ToString)
        End While
        RefreshEmpList()
    End Sub

    Private Sub LoadPeriodList()
        Dim query As String
        SQL.CloseCon()
        SetPayrollDatabase()
        query = " SELECT	Payroll_Period " & _
             " FROM	    tblPayroll_Period " & _
             " WHERE     Status ='Locked'  " & _
             " ORDER BY  Paydate DESC "
        SQL_RUBY.ReadQuery(query)
        cbCutoff.Items.Clear()
        While SQL_RUBY.SQLDR.Read
            cbCutoff.Items.Add(SQL_RUBY.SQLDR("Payroll_Period").ToString)
        End While
        SQL_RUBY.CloseCon()
        SetDatabase()
        If cbCutoff.Items.Count > 0 Then
            cbCutoff.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbCutoff_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCutoff.SelectedIndexChanged
        If disableEvent = False Then
            SQL.CloseCon()
            SetPayrollDatabase()
            Dim query As String
            query = " SELECT	DateFrom, DateTo, Paydate " & _
                    " FROM	    tblPayroll_Period " & _
                    " WHERE     Payroll_Period ='" & cbCutoff.SelectedItem & "' " & _
                    " AND       Status ='Locked'  " & _
                    " ORDER BY  Paydate "
            SQL_RUBY.ReadQuery(query)
            If SQL_RUBY.SQLDR.Read Then
                dtpFrom.Value = SQL_RUBY.SQLDR("DateFrom")
                dtpTo.Value = SQL_RUBY.SQLDR("DateTo")
            End If
            SQL_RUBY.CloseCon()
            SetDatabase()
            LoadFilter()
            LoadDefaultFilter()
            LoadFilter2()
        End If
    End Sub

    Private Sub LoadContractClient()
        Dim query As String
        query = " SELECT DISTINCT VCEName " & _
                " FROM   tblManpower_Contract INNER JOIN viewVCE_Master " & _
                " ON     tblManpower_Contract.VCECode = viewVCE_Master.VCECode " & _
                " WHERE  tblManpower_Contract.Status ='Active' " & _
                " ORDER BY VCEName "
        cbVCEName.Items.Clear()
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            cbVCEName.Items.Add(SQL.SQLDR("VCEName").ToString)
        End While
    End Sub

    Private Sub cbVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbVCEName.KeyDown
        If disableEvent = False Then
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmVCE_Search
                'f.Mod_Used = "Manpower"
                'f.Vendor = cbVCEName.Text
                f.ShowDialog()
                txtVCECode.Text = f.VCECode
                cbVCEName.Text = f.VCEName
                LoadPeriodList()
            Else
                txtVCECode.Text = ""
            End If
        End If
    End Sub

    Private Sub cbVCEName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbVCEName.SelectedIndexChanged
        If disableEvent = False Then
            If cbVCEName.SelectedIndex <> -1 Then
                Dim f As New frmVCE_Search
                'f.Mod_Used = "Manpower"
                'f.Vendor = cbVCEName.Text
                f.ShowDialog()
                txtVCECode.Text = f.VCECode
                cbVCEName.Text = f.VCEName
                LoadPeriodList()
                LoadFilter()
                LoadDefaultFilter()
                LoadFilter2()
            End If
        End If
    End Sub

    Private Sub cbFilter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbFilter.SelectedIndexChanged
        If disableEvent = False Then
            LoadFilter()
        End If
    End Sub

    Private Sub LoadDefaultFilter()
        Dim query, group As String
        query = " SELECT Default_Group FROM tblManpower_Contract WHERE VCECode ='" & txtVCECode.Text & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("Default_Group")) Then
            disableEvent = True
            cbFilter.SelectedItem = "Group"
            group = SQL.SQLDR("Default_Group").ToString
            LoadFilter()
            cbFilter2.SelectedItem = group
            disableEvent = False
        Else
            cbFilter.SelectedItem = "Employee"
        End If
    End Sub

    Private Sub LoadFilter()
        SQL.CloseCon()
        SetPayrollDatabase()
        Dim query As String
        If cbFilter.SelectedItem = "Group" Then
            query = " SELECT  DISTINCT Org_Name " & _
                    " FROM    viewEmployee_Info INNER JOIN viewPayroll_Details " & _
                    " ON      viewEmployee_Info.Emp_ID = viewPayroll_Details.Emp_ID " & _
                    " WHERE   Payroll_Period ='" & cbCutoff.SelectedItem & "' "
            SQL_RUBY.FlushParams()
            SQL_RUBY.AddParam("@Filter", cbFilter2.Text)
            SQL_RUBY.ReadQuery(query)
            cbFilter2.Items.Clear()
            While SQL_RUBY.SQLDR.Read
                cbFilter2.Items.Add(SQL_RUBY.SQLDR("Org_Name").ToString)
            End While
            cbFilter2.DropDownStyle = ComboBoxStyle.DropDownList
        Else
            cbFilter2.DropDownStyle = ComboBoxStyle.Simple
            cbFilter2.Text = ""
        End If
        SQL_RUBY.CloseCon()
        SetDatabase()
    End Sub

    Private Sub LoadFilter2()
        SQL.CloseCon()
        SetPayrollDatabase()
        Dim query As String
        Dim filterStatus, filterGroup As String

        If cbEmpType.SelectedItem = "Active" Or cbEmpType.SelectedItem = "Inactive" Then
            filterStatus = " AND tblPayroll_Header.Employee_Status ='" & cbEmpType.SelectedItem & "'"
        Else
            filterStatus = ""
        End If

        If cbFilter.SelectedItem = "Employee" Then
            query = " SELECT    viewEmployee_Info.Emp_ID, Emp_Name, tblPayroll_Header.Employee_Status " & _
                    " FROM      viewEmployee_Info INNER JOIN tblPayroll_Header " & _
                    " ON        viewEmployee_Info.Emp_ID = tblPayroll_Header.Emp_ID " & _
                    " WHERE     Payroll_Period ='" & cbCutoff.SelectedItem & "' AND Emp_Name LIKE ('%' + @Filter + '%') " & filterStatus & _
                    " ORDER BY  Emp_Name"
            SQL_RUBY.FlushParams()
            SQL_RUBY.AddParam("@Filter", cbFilter2.Text)
        Else
            If cbFilter2.SelectedItem = "All" Then
                filterGroup = ""
            Else
                filterGroup = " AND Org_Name ='" & cbFilter2.SelectedItem & "' "
            End If
            query = " SELECT    viewEmployee_Info.Emp_ID, Emp_Name, tblPayroll_Header.Employee_Status " & _
                    " FROM      viewEmployee_Info INNER JOIN tblPayroll_Header " & _
                    " ON        viewEmployee_Info.Emp_ID = tblPayroll_Header.Emp_ID " & _
                    " WHERE     Payroll_Period ='" & cbCutoff.SelectedItem & "' " & filterGroup & filterStatus & _
                    " ORDER BY  Emp_Name "
        End If
        SQL_RUBY.ReadQuery(query)
        lvEmp.Items.Clear()
        While SQL_RUBY.SQLDR.Read
            lvEmp.Items.Add(SQL_RUBY.SQLDR("Emp_ID").ToString)
            lvEmp.Items(lvEmp.Items.Count - 1).SubItems.Add(SQL_RUBY.SQLDR("Emp_Name").ToString)
            lvEmp.Items(lvEmp.Items.Count - 1).SubItems.Add(SQL_RUBY.SQLDR("Employee_Status").ToString)
        End While
        For i As Integer = lvEmp.Items.Count - 1 To 0 Step -1
            For j As Integer = 0 To lvSelected.Items.Count - 1
                If lvEmp.Items(i).SubItems(0).Text = lvSelected.Items(j).Text And cbCutoff.SelectedItem = lvSelected.Items(j).SubItems(chPeriod.Index).Text Then
                    lvEmp.Items(i).Remove()
                    Exit For
                End If
            Next
        Next
        SQL_RUBY.CloseCon()
        SetDatabase()
        GetCharges()
        ComputeBilling()
    End Sub

    Private Sub RefreshEmpList()
        SQL.CloseCon()
        SetPayrollDatabase()
        Dim query As String
        Dim filterStatus, filterGroup As String

        If cbEmpType.SelectedItem = "Active" Or cbEmpType.SelectedItem = "Inactive" Then
            filterStatus = " AND tblPayroll_Header.Employee_Status ='" & cbEmpType.SelectedItem & "'"
        Else
            filterStatus = ""
        End If

        If cbFilter.SelectedItem = "Employee" Then
            query = " SELECT    viewEmployee_Info.Emp_ID, Emp_Name, tblPayroll_Header.Employee_Status " & _
                    " FROM      viewEmployee_Info INNER JOIN tblPayroll_Header " & _
                    " ON        viewEmployee_Info.Emp_ID = tblPayroll_Header.Emp_ID " & _
                    " WHERE     Payroll_Period ='" & cbCutoff.SelectedItem & "' AND Emp_Name LIKE ('%' + @Filter + '%') " & filterStatus & _
                    " ORDER BY  Emp_Name"
            SQL_RUBY.FlushParams()
            SQL_RUBY.AddParam("@Filter", cbFilter2.Text)
        Else
            If cbFilter2.SelectedItem = "All" Then
                filterGroup = ""
            Else
                filterGroup = " AND Org_Name ='" & cbFilter2.SelectedItem & "' "
            End If
            query = " SELECT    viewEmployee_Info.Emp_ID, Emp_Name, tblPayroll_Header.Employee_Status " & _
                    " FROM      viewEmployee_Info INNER JOIN tblPayroll_Header " & _
                    " ON        viewEmployee_Info.Emp_ID = tblPayroll_Header.Emp_ID " & _
                    " WHERE     Payroll_Period ='" & cbCutoff.SelectedItem & "' " & filterGroup & filterStatus & _
                    " ORDER BY  Emp_Name "
        End If
        SQL_RUBY.ReadQuery(query)
        lvEmp.Items.Clear()
        While SQL_RUBY.SQLDR.Read
            lvEmp.Items.Add(SQL_RUBY.SQLDR("Emp_ID").ToString)
            lvEmp.Items(lvEmp.Items.Count - 1).SubItems.Add(SQL_RUBY.SQLDR("Emp_Name").ToString)
            lvEmp.Items(lvEmp.Items.Count - 1).SubItems.Add(SQL_RUBY.SQLDR("Employee_Status").ToString)
        End While
        For i As Integer = lvEmp.Items.Count - 1 To 0 Step -1
            For j As Integer = 0 To lvSelected.Items.Count - 1
                If lvEmp.Items(i).SubItems(0).Text = lvSelected.Items(j).Text And cbCutoff.SelectedItem = lvSelected.Items(j).SubItems(chPeriod.Index).Text Then
                    lvEmp.Items(i).Remove()
                    Exit For
                End If
            Next
        Next
        SQL_RUBY.CloseCon()
        SetDatabase()
    End Sub

    Private Sub cbFilter2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbEmpType.SelectedIndexChanged, cbFilter2.SelectedIndexChanged, cbFilter2.TextChanged
        If disableEvent = False Then
            LoadFilter2()
        End If
    End Sub

    Private Sub btnAddAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAll.Click
        For Each item As ListViewItem In lvEmp.Items
            lvSelected.Items.Add(item.SubItems(chAvailEmpID.Index).Text)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(item.SubItems(chAvailEmpName.Index).Text)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(item.SubItems(chAvailStatus.Index).Text)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(cbCutoff.SelectedItem)
        Next
        LoadFilter2()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        For Each item As ListViewItem In lvEmp.SelectedItems
            lvSelected.Items.Add(item.SubItems(chAvailEmpID.Index).Text)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(item.SubItems(chAvailEmpName.Index).Text)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(item.SubItems(chAvailStatus.Index).Text)
            lvSelected.Items(lvSelected.Items.Count - 1).SubItems.Add(cbCutoff.SelectedItem)
        Next
        LoadFilter2()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        For i As Integer = lvSelected.SelectedItems.Count - 1 To 0 Step -1
            lvSelected.SelectedItems(i).Remove()
        Next
        LoadFilter2()
    End Sub

    Private Sub btnRemoveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveAll.Click
        For i As Integer = lvSelected.Items.Count - 1 To 0 Step -1
            lvSelected.Items(i).Remove()
        Next
        LoadFilter2()
    End Sub

    Private Sub GetCharges()
        Dim query As String
        query = "  SELECT   Category, Ledger_Code, Method, Rate, tblManpower_ContractDetails.Admin_Fee AS [with_Admin], tblManpower_Contract.Admin_Fee, Charge_Code " & _
                "  FROM	    tblManpower_Contract INNER JOIN tblManpower_ContractDetails " & _
                "  ON		tblManpower_Contract.Contract_No = tblManpower_ContractDetails.Contract_No " & _
                "  AND	    tblManpower_Contract.Status = 'Active' AND tblManpower_ContractDetails.Status ='Active' " & _
                "  INNER JOIN tblManpower_Charges " & _
                "  ON		tblManpower_ContractDetails.Charge_ID = tblManpower_Charges.Charge_ID " & _
                "  AND	    tblManpower_Charges.Status ='Active' " & _
                "  WHERE    tblManpower_Contract.VCECode = '" & txtVCECode.Text & "' " & _
                "  ORDER BY Sort_No "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            charges = SQL.SQLDS.Tables(0)
        End If
    End Sub

    Private Sub ComputeBilling()
        If lvSelected.Items.Count > 0 Then
            Dim subcount As Integer = 0
            Dim start As Boolean = True
            Dim typeCount As Integer = 1
            Dim addSub As Boolean = True
            Dim prevCat As String = ""
            Dim subhrs As Decimal = 0
            Dim hrs As Decimal = 0
            Dim grandhrs As Decimal = 0
            Dim subtotal As Decimal = 0
            Dim total As Decimal = 0
            Dim grandtotal As Decimal = 0
            Dim col As Integer = 5
            Dim days As Decimal = 0
            Dim adminFee As Decimal = 0
            Dim adminRate As Decimal = 0
            detailed.Rows.Clear()
            detailed.Columns.Clear()
            detailed.Columns.Add("Emp. ID")
            detailed.Columns.Add("Emp. Name")
            detailed.Columns.Add("Status")
            detailed.Columns.Add("Period")
            detailed.Columns.Add("adminFee")
            detailedHrs.Rows.Clear()
            detailedHrs.Columns.Clear()
            detailedHrs.Columns.Add("Emp. ID")
            detailedHrs.Columns.Add("Emp. Name")
            detailedHrs.Columns.Add("Status")
            detailedHrs.Columns.Add("Period")
            detailedHrs.Columns.Add("adminFee")
            detailed2.Rows.Clear()
            detailed2.Columns.Clear()
            detailed2.Columns.Add("Emp. ID")
            detailed2.Columns.Add("Emp. Name")
            detailed2.Columns.Add("Status")
            detailed2.Columns.Add("Period")
            detailed2.Columns.Add("Category")
            detailed2.Columns.Add("Type")
            detailed2.Columns.Add("Days_Hrs")
            detailed2.Columns.Add("Amount")
            dgvCharges.Rows.Clear()
            pbRecords.Value = 0
            pbRecords.Maximum = lvSelected.Items.Count * charges.Rows.Count
            For Each item As ListViewItem In lvSelected.Items
                detailed.Rows.Add({item.SubItems(chEmpID.Index).Text, item.SubItems(chEmpName.Index).Text, item.SubItems(chStatus.Index).Text, item.SubItems(chPeriod.Index).Text, 0})
                detailedHrs.Rows.Add({item.SubItems(chEmpID.Index).Text, item.SubItems(chEmpName.Index).Text, item.SubItems(chStatus.Index).Text, item.SubItems(chPeriod.Index).Text, 0})
            Next
            For Each row As DataRow In charges.Rows
                detailed.Columns.Add(row(1).ToString)
                detailedHrs.Columns.Add(row(1).ToString)
                adminRate = row(5) / 100
                If prevCat <> row(0).ToString Then
                    If start = True Then
                        start = False
                    Else
                        If addSub = True Then
                            If typeCount > 1 Then
                                If row(1).ToString = "BASIC" Then
                                    subhrs = Math.Abs(subhrs) / 8
                                End If
                                If subhrs = 0 Then
                                    dgvCharges.Rows.Add(prevCat & " Subtotal", "", "", CDec(subtotal).ToString("N2"))
                                Else
                                    dgvCharges.Rows.Add(prevCat & " Subtotal", "", CDec(Math.Abs(subhrs)).ToString("N2"), CDec(subtotal).ToString("N2"))
                                End If
                                dgvCharges.Rows(dgvCharges.Rows.Count - 1).DefaultCellStyle.Font = New Font(dgvCharges.Font, FontStyle.Bold)
                                typeCount = 1
                                subcount += 1
                            End If
                            subtotal = 0
                            subhrs = 0
                            addSub = False
                        End If
                    End If
                End If
                Dim ind As Integer = 0
                For Each row2 As DataRow In detailed.Rows
                    pbRecords.Value += 1
                    If row(2).ToString = "(Default)" Then
                        Dim query As String
                        query = " SELECT	ISNULL(SUM(CASE WHEN Category ='Income' THEN Days_Hours ELSE Days_Hours * -1 END),0) AS DaysHrs, " & _
                                "           ISNULL(SUM(CASE WHEN Category ='Income' THEN Amount ELSE Amount * -1 END),0) AS Amount " & _
                                " FROM	    viewPayroll_Details  " & _
                                " WHERE	    Emp_ID ='" & row2(0).ToString & "' " & _
                                " AND		Payroll_Period ='" & row2(3).ToString & "' " & _
                                " AND		Ledger_Name ='" & row(1).ToString & "' "
                        SQL_RUBY.ReadQuery(query)
                        If SQL_RUBY.SQLDR.Read Then
                            row2(col) = SQL_RUBY.SQLDR("Amount")
                            detailedHrs.Rows(ind).Item(col) = SQL_RUBY.SQLDR("DaysHrs")
                            grandtotal += SQL_RUBY.SQLDR("Amount")
                            subtotal += SQL_RUBY.SQLDR("Amount")
                            total += SQL_RUBY.SQLDR("Amount")
                            grandhrs += SQL_RUBY.SQLDR("DaysHrs")
                            subhrs += SQL_RUBY.SQLDR("DaysHrs")
                            hrs += SQL_RUBY.SQLDR("DaysHrs")
                            If row(4) Then
                                row2(4) += (SQL_RUBY.SQLDR("Amount") * adminRate)
                                adminFee += SQL_RUBY.SQLDR("Amount")
                            End If
                            If row(1).ToString = "BASIC" Then
                                detailed2.Rows.Add({row2(0).ToString, row2(1).ToString, row2(2).ToString, row2(3).ToString, row(0).ToString, row(6).ToString, SQL_RUBY.SQLDR("DaysHrs") / 8, SQL_RUBY.SQLDR("Amount")})
                            Else
                                detailed2.Rows.Add({row2(0).ToString, row2(1).ToString, row2(2).ToString, row2(3).ToString, row(0).ToString, row(6).ToString, SQL_RUBY.SQLDR("DaysHrs"), SQL_RUBY.SQLDR("Amount")})
                            End If

                        End If
                    ElseIf row(2).ToString = "Fixed Amount" Then
                        row2(col) = row(3).ToString
                        total += row(3).ToString
                        grandtotal += row(3).ToString
                        subtotal += row(3).ToString
                        If row(4) Then
                            adminFee += row(3)
                            adminOther += (row(3) * adminRate)
                        End If
                        detailed2.Rows.Add({"", "", "", cbCutoff.SelectedItem, row(0).ToString, row(6).ToString, 0, row(3).ToString})
                        Exit For
                    ElseIf row(2).ToString = "Per Day" Then
                        row2(col) = row(3) * detailedHrs.Rows(ind).Item(5)
                        total += row(3) * detailedHrs.Rows(ind).Item(5) / 8.0
                        grandtotal += row(3) * detailedHrs.Rows(ind).Item(5) / 8.0
                        subtotal += row(3) * detailedHrs.Rows(ind).Item(5) / 8.0
                        detailed2.Rows.Add({row2(0).ToString, row2(1).ToString, row2(2).ToString, row2(3).ToString, row(0).ToString, row(6).ToString, 0, row(3) * detailedHrs.Rows(ind).Item(5) / 8.0})
                        If row(4) Then
                            adminFee += row(3) * detailedHrs.Rows(ind).Item(5) / 8.0
                            row2(4) += (row(3) * detailedHrs.Rows(ind).Item(5) / 8.0 * adminRate)
                        End If
                    End If
                    ind += 1
                Next
                If prevCat <> row(0).ToString Then
                    If total <> 0 Then
                        If row(1).ToString = "BASIC" Then
                            days = Math.Abs(hrs) / 8
                            hrs = Math.Abs(hrs) / 8
                        End If
                        If hrs = 0 Then
                            dgvCharges.Rows.Add(row(0).ToString.ToUpper, row(6).ToString, "", CDec(total).ToString("N2"))
                        Else
                            dgvCharges.Rows.Add(row(0).ToString.ToUpper, row(6).ToString, CDec(Math.Abs(hrs)).ToString("N2"), CDec(total).ToString("N2"))
                        End If
                        total = 0
                        hrs = 0
                        prevCat = row(0).ToString
                    End If
                Else
                    addSub = True
                    If total <> 0 Then
                        If row(1).ToString = "BASIC" Then
                            days = Math.Abs(hrs) / 8
                            hrs = Math.Abs(hrs) / 8
                        End If
                        typeCount += 1
                        If hrs = 0 Then
                            dgvCharges.Rows.Add("", row(6).ToString, "", CDec(total).ToString("N2"))
                        Else
                            dgvCharges.Rows.Add("", row(6).ToString, CDec(Math.Abs(hrs)).ToString("N2"), CDec(total).ToString("N2"))
                        End If
                        total = 0
                        hrs = 0
                    End If
                    prevCat = row(0).ToString
                End If
                col += 1

            Next
            For Each row2 As DataRow In detailed.Rows
                detailed2.Rows.Add({row2(0).ToString, row2(1).ToString, row2(2).ToString, row2(3).ToString, "ADMIN FEE", "ADMIN FEE", 0, row2(4)})
            Next
            If typeCount > 1 Then
                If subhrs = 0 Then
                    dgvCharges.Rows.Add(prevCat.ToUpper & " SUBTOTAL", "", "", CDec(subtotal).ToString("N2"))
                Else
                    dgvCharges.Rows.Add(prevCat.ToUpper & " SUBTOTAL", "", CDec(Math.Abs(subhrs)).ToString("N2"), CDec(subtotal).ToString("N2"))
                End If
                dgvCharges.Rows(dgvCharges.Rows.Count - 1).DefaultCellStyle.Font = New Font(dgvCharges.Font, FontStyle.Bold)
            End If
            If subcount > 1 Then
                dgvCharges.Rows.Add("GRAND TOTAL", "", "", CDec(grandtotal).ToString("N2"))
                dgvCharges.Rows(dgvCharges.Rows.Count - 1).DefaultCellStyle.Font = New Font(dgvCharges.Font, FontStyle.Bold)
            End If
            Dim vat, ewt As Decimal
            adminFee = adminFee * (adminRate)
            vat = (adminFee + grandtotal) * 0.12
            ewt = (adminFee + grandtotal) * 0.02
            txtAmount.Text = CDec(grandtotal).ToString("N2")
            txtAdmin.Text = CDec(adminFee).ToString("N2")
            txtGross.Text = CDec(adminFee + grandtotal).ToString("N2")
            txtVAT.Text = CDec(vat).ToString("N2")
            txtEWT.Text = CDec(ewt).ToString("N2")
            txtAmountDue.Text = CDec(adminFee + grandtotal + vat - ewt).ToString("N2")
            pbRecords.Value = pbRecords.Maximum
            pbRecords.Value = 0
        Else
            dgvCharges.Rows.Clear()
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtVCECode.Text = "" Then
            MsgBox("Please select VCE first!", MsgBoxStyle.Exclamation)
        ElseIf lvSelected.Items.Count = 0 Then
            MsgBox("There are no employees included in the list, please check!", MsgBoxStyle.Exclamation)
        ElseIf btnSave.Text = "Save" Then
            If MsgBox("Are you sure you want to save this billing?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim transID As Integer = GetTransID()
                SaveHeader(transID)
                MsgBox("Record Saved Succesfully!", MsgBoxStyle.Information)
                Me.Close()
                Me.Dispose()
            End If
        ElseIf btnSave.Text = "Update" Then
            If MsgBox("Are you sure you want to update this billing?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                UpdateHeader(txtBSNo.Text)
                MsgBox("Record Updated Succesfully!", MsgBoxStyle.Information)
                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub

    Private Function GetTransID() As Integer
        Dim query As String
        query = " SELECT MAX(TransID) + 1 AS TransID FROM tblManpower_Billing "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("TransID")) Then
            Return SQL.SQLDR("TransID")
        Else
            Return 1
        End If

    End Function


    Private Sub UpdateHeader(ByVal TransID As Integer)
        Dim updateSQL As String
        updateSQL = " UPDATE tblManpower_Billing " & _
                    " SET    VCECode = @VCECode, BS_Date = @BS_Date, Due_Date = @Due_Date, BS_Period = @BS_Period, Remarks = @Remarks,  " & _
                    "        Filter_Group = @Filter_Group, Filter_Data = @Filter_Data, Emp_Type = @Emp_Type, " & _
                    "        Total_Amount = @Total_Amount, Admin_Fee = @Admin_Fee, VAT = @VAT, EWT = @EWT, " & _
                    "        Who_Modified = @Who_Modified, Date_Modified = GETDATE()" & _
                    " WHERE TransID = @TransID "
        SQL.FlushParams()
        SQL.AddParam("@TransID", TransID)
        SQL.AddParam("@VCECode", txtVCECode.Text)
        SQL.AddParam("@BS_Date", dtpBSDate.Value.Date)
        SQL.AddParam("@Due_Date", dtpDueDate.Value.Date)
        SQL.AddParam("@BS_Period", cbCutoff.SelectedItem)
        SQL.AddParam("@Remarks", txtRemarks.Text)
        SQL.AddParam("@Filter_Group", cbFilter.SelectedItem)
        SQL.AddParam("@Filter_Data", IIf(cbFilter.SelectedItem = "Group", cbFilter2.SelectedItem, cbFilter2.Text))
        SQL.AddParam("@Emp_Type", cbEmpType.SelectedItem)
        If IsNumeric(txtAmount.Text) Then SQL.AddParam("@Total_Amount", CDec(txtAmount.Text)) Else SQL.AddParam("@Total_Amount", 0)
        If IsNumeric(txtAdmin.Text) Then SQL.AddParam("@Admin_Fee", CDec(txtAdmin.Text)) Else SQL.AddParam("@Admin_Fee", 0)
        If IsNumeric(txtVAT.Text) Then SQL.AddParam("@VAT", CDec(txtVAT.Text)) Else SQL.AddParam("@VAT", 0)
        If IsNumeric(txtEWT.Text) Then SQL.AddParam("@EWT", CDec(txtEWT.Text)) Else SQL.AddParam("@EWT", 0)
        SQL.AddParam("@Who_Modified", "")
        SQL.ExecNonQuery(updateSQL)
        SaveDetails(TransID)
    End Sub

    Private Sub SaveHeader(ByVal TransID As Integer)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblManpower_Billing(TransID, VCECode, BS_Date, Due_Date, BS_Period, Remarks, Filter_Group, " & _
                    "                     Filter_Data, Emp_Type, Total_Amount, Admin_Fee, VAT, EWT, Who_Created) " & _
                    " VALUES(@TransID, @VCECode, @BS_Date, @Due_Date, @BS_Period, @Remarks, @Filter_Group, " & _
                    "                     @Filter_Data, @Emp_Type, @Total_Amount, @Admin_Fee, @VAT, @EWT, @Who_Created) "
        SQL.FlushParams()
        SQL.AddParam("@TransID", TransID)
        SQL.AddParam("@VCECode", txtVCECode.Text)
        SQL.AddParam("@BS_Date", dtpBSDate.Value.Date)
        SQL.AddParam("@Due_Date", dtpDueDate.Value.Date)
        SQL.AddParam("@BS_Period", cbCutoff.SelectedItem)
        SQL.AddParam("@Remarks", txtRemarks.Text)
        SQL.AddParam("@Filter_Group", cbFilter.SelectedItem)
        SQL.AddParam("@Filter_Data", IIf(cbFilter.SelectedItem = "Group", cbFilter2.SelectedItem, cbFilter2.Text))
        SQL.AddParam("@Emp_Type", cbEmpType.SelectedItem)
        If IsNumeric(txtAmount.Text) Then SQL.AddParam("@Total_Amount", CDec(txtAmount.Text)) Else SQL.AddParam("@Total_Amount", 0)
        If IsNumeric(txtAdmin.Text) Then SQL.AddParam("@Admin_Fee", CDec(txtAdmin.Text)) Else SQL.AddParam("@Admin_Fee", 0)
        If IsNumeric(txtVAT.Text) Then SQL.AddParam("@VAT", CDec(txtVAT.Text)) Else SQL.AddParam("@VAT", 0)
        If IsNumeric(txtEWT.Text) Then SQL.AddParam("@EWT", CDec(txtEWT.Text)) Else SQL.AddParam("@EWT", 0)
        SQL.AddParam("@Who_Created", "")
        SQL.ExecNonQuery(insertSQL)
        SaveDetails(TransID)
        Dim BS As Integer
        Dim JE As Integer
        BS = LoadTransID("tblSales", "Sales_ID", "Sales_Ref", "BS")
        InsertToSB(BS, "BS", "Billing Statement", CDec(txtGross.Text), CDec(txtVAT.Text), CDec(txtEWT.Text), 0)
        InsertHeader("Reimbursible", BS)
        JE = LoadJE("RE", BS)
        InsertDetails(JE)
    End Sub

    Private Sub InsertDetails(ByVal JE As Integer)
        Dim accnt As String
        accnt = LoadDefaultAccnt("Manpower", "Debit")
        SaveEntry(JE, accnt, txtVCECode.Text, CDec(txtAmountDue.Text), 0, cbCutoff.SelectedItem, txtBSNo.Text, 1)
        accnt = LoadDefaultAccnt("Tax", "EWT")
        SaveEntry(JE, accnt, txtVCECode.Text, CDec(txtEWT.Text), 0, cbCutoff.SelectedItem, txtBSNo.Text, 2)
        accnt = LoadDefaultAccnt("Tax", "VAT")
        SaveEntry(JE, accnt, txtVCECode.Text, 0, CDec(txtVAT.Text), cbCutoff.SelectedItem, txtBSNo.Text, 3)
        accnt = LoadDefaultAccnt("Manpower", "Credit")
        SaveEntry(JE, accnt, txtVCECode.Text, 0, CDec(txtGross.Text), cbCutoff.SelectedItem, txtBSNo.Text, 4)
    End Sub

    Private Sub InsertHeader(ByVal Type As String, SN As Integer)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblJE_Header(App_Date, Ref_Type, Ref_TransID, Book, Total_DBCR, Remarks, Who_Created) " & _
                    " VALUES(@App_Date, @Ref_Type, @Ref_TransID, @Book, @Total_DBCR, @Remarks, @Who_Created)"
        SQl.FlushParams()
        SQL.AddParam("@App_Date", dtpBSDate.Value.Date)
        SQL.AddParam("@Ref_Type", "RE")
        SQL.AddParam("@Ref_TransID", SN)
        SQL.AddParam("@Book", "Sales")
        SQL.AddParam("@Total_DBCR", CDec(txtGross.Text))
        SQL.AddParam("@Remarks", txtRemarks.Text)
        SQL.AddParam("@Who_Created", UserID)
        SQl.ExecNonQuery(insertSQL)
    End Sub

    Private Sub InsertToSB(SN As Integer, Ref As String, Type As String, Amount As Decimal, VAT As Integer, EWT As Integer, Discount As Integer)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblSales (Sales_ID, Sales_Type, Sales_Ref, Ref_TransID, BS_Date, VCECode, Amount, " & _
                    "           Input_VAT, EWT, Discount, Net_Sales, Due_Date, Ref_No, Remarks, Who_Created)" & _
                    " VALUES(@Sales_ID, @Sales_Type, @Sales_Ref, @Ref_TransID, @BS_Date, @VCECode, @Amount, " & _
                    "        @Input_VAT, @EWT, @Discount, @Net_Sales, @Due_Date, @Ref_No, @Remarks, @Who_Created) "
        SQL.FlushParams()
        SQL.AddParam("@Sales_ID", SN)
        SQL.AddParam("@Sales_Type", Type)
        SQL.AddParam("@Sales_Ref", Ref)
        SQL.AddParam("@Ref_TransID", txtBSNo.Text)
        SQL.AddParam("@BS_Date", dtpBSDate.Value.Date)
        SQL.AddParam("@VCECode", txtVCECode.Text)
        SQL.AddParam("@Amount", Amount)
        SQL.AddParam("@Input_VAT", VAT)
        SQL.AddParam("@EWT", EWT)
        SQL.AddParam("@Discount", Discount)
        SQL.AddParam("@Net_Sales", Amount - Discount + VAT - EWT)
        SQL.AddParam("@Due_Date", dtpDueDate.Value.Date)
        SQL.AddParam("@Ref_No", "")
        SQL.AddParam("@Remarks", txtRemarks.Text)
        SQL.AddParam("@Who_Created", UserID)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub SaveDetails(ByVal TransID As Integer)
        Dim deleteSQL As String
        deleteSQL = "DELETE FROM tblManpower_BillingDetails WHERE BS_Ref ='" & TransID & "'"
        SQL.ExecNonQuery(deleteSQL)
        pbRecords.Maximum = detailed2.Rows.Count + 1
        Dim insertSQL As String
        For Each row As DataRow In detailed2.Rows
            insertSQL = " INSERT INTO " & _
                        " tblManpower_BillingDetails(BS_Ref, Emp_ID, Emp_Name, Emp_Status, Payroll_Period, Category, Type, Days_Hours, Amount) " & _
                        " VALUES(@BS_Ref, @Emp_ID, @Emp_Name, @Emp_Status, @Payroll_Period, @Category, @Type, @Days_Hours, @Amount) "
            SQL.FlushParams()
            SQL.AddParam("@BS_Ref", TransID)
            SQL.AddParam("@Emp_ID", row(0).ToString)
            SQL.AddParam("@Emp_Name", row(1).ToString)
            SQL.AddParam("@Emp_Status", row(2).ToString)
            SQL.AddParam("@Payroll_Period", row(3).ToString)
            SQL.AddParam("@Category", row(4).ToString)
            SQL.AddParam("@Type", row(5).ToString)
            If IsNumeric(row(6)) Then SQL.AddParam("@Days_Hours", CDec(row(6))) Else SQL.AddParam("@Days_Hours", 0)
            If IsNumeric(row(7)) Then SQL.AddParam("@Amount", CDec(row(7))) Else SQL.AddParam("@Amount", 0)
            SQL.ExecNonQuery(insertSQL)
            pbRecords.Value += 1
        Next
        insertSQL = " INSERT INTO " & _
                    " tblManpower_BillingDetails(BS_Ref, Emp_ID, Emp_Name, Emp_Status, Payroll_Period, Category, Type, Days_Hours, Amount) " & _
                    " VALUES(@BS_Ref, @Emp_ID, @Emp_Name, @Emp_Status, @Payroll_Period, @Category, @Type, @Days_Hours, @Amount) "
        SQL.FlushParams()
        SQL.AddParam("@BS_Ref", TransID)
        SQL.AddParam("@Emp_ID", "")
        SQL.AddParam("@Emp_Name", "")
        SQL.AddParam("@Emp_Status", "")
        SQL.AddParam("@Payroll_Period", cbCutoff.SelectedItem)
        SQL.AddParam("@Category", "ADMIN FEE")
        SQL.AddParam("@Type", "ADMIN FEE")
        SQL.AddParam("@Days_Hours", 0)
        SQL.AddParam("@Amount", adminOther)
        SQL.ExecNonQuery(insertSQL)
        pbRecords.Value += 1
        pbRecords.Value = 0
    End Sub


End Class