Public Class frmBilling_Manpower

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        frmBilling_Manpower_Contract.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmBilling_Manpower_New.ShowDialog()
        frmBilling_Manpower_New.Dispose()
        LoadBillingList()
    End Sub

    Private Sub LoadStatus()
        Dim query As String
        query = " SELECT DISTINCT Status FROM tblManpower_Billing ORDER BY Status "
        SQL.ReadQuery(query)
        cbStatus.Items.Clear()
        cbStatus.Items.Add("All")
        While SQL.SQLDR.Read
            cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
        End While
        If cbStatus.Items.Count > 0 Then
            cbStatus.SelectedIndex = 0
        End If
    End Sub

    Private Sub frmBilling_Manpower_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadStatus()
    End Sub

    Private Sub LoadBillingList()
        Dim filter As String
        If cbStatus.SelectedIndex = -1 Or cbStatus.SelectedItem = "All" Then
            filter = ""
        Else
            filter = " WHERE   tblManpower_Billing.Status ='" & cbStatus.SelectedItem & "' "
        End If
        Dim query As String
        query = " SELECT    TransID, VCEName, BS_Period, Total_Amount + Admin_Fee + VAT - EWT AS Amount " & _
                " FROM	    tblManpower_Billing INNER JOIN viewVCE_Master " & _
                " ON		tblManpower_Billing.VCECode = viewVCE_Master.VCECode " & filter
        SQL.ReadQuery(query)
        lvContract.Items.Clear()
        While SQL.SQLDR.Read
            lvContract.Items.Add(SQL.SQLDR("TransID").ToString)
            lvContract.Items(lvContract.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
            lvContract.Items(lvContract.Items.Count - 1).SubItems.Add(SQL.SQLDR("BS_Period").ToString)
            lvContract.Items(lvContract.Items.Count - 1).SubItems.Add(CDec(SQL.SQLDR("Amount")).ToString("N2"))
        End While
    End Sub

    Private Sub cbStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbStatus.SelectedIndexChanged
        LoadBillingList()
    End Sub

    Private Sub LoadBillingDetails(ByRef TransID As Integer)
        Dim query As String
        query = " SELECT  tblManpower_Billing.VCECode, VCEName, BS_Date, Due_Date, BS_Period, Remarks, tblManpower_Billing.Status, " & _
                "         Total_Amount, Admin_Fee, Total_Amount + Admin_Fee AS Gross, VAT, EWT, Total_Amount + Admin_Fee + VAT - EWT AS Net " & _
                " FROM	  tblManpower_Billing INNER JOIN viewVCE_Master " & _
                " ON      tblManpower_Billing.VCECode = viewVCE_Master.VCECode " & _
                " WHERE	  TransID ='" & TransID & "' "
        SQL.ReadQuery(query)
        dgvCharges.Rows.Clear()
        If SQL.SQLDR.Read Then
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtBSNo.Text = TransID
            dtpBSDate.Value = SQL.SQLDR("BS_Date").ToString
            dtpDueDate.Value = SQL.SQLDR("Due_Date").ToString
            txtPeriod.Text = SQL.SQLDR("BS_Period").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            txtAmount.Text = CDec(SQL.SQLDR("Total_Amount")).ToString("N2")
            txtAdmin.Text = CDec(SQL.SQLDR("Admin_Fee")).ToString("N2")
            txtGross.Text = CDec(SQL.SQLDR("Admin_Fee")).ToString("N2")
            txtVAT.Text = CDec(SQL.SQLDR("VAT")).ToString("N2")
            txtEWT.Text = CDec(SQL.SQLDR("EWT")).ToString("N2")
            txtAmountDue.Text = CDec(SQL.SQLDR("Net")).ToString("N2")
            LoadBillingCharges(TransID)
            If txtStatus.Text = "Cancelled" Then
                btnEdit.Enabled = False
                btnCancel.Enabled = False
                btnPrintDTR.Enabled = False
                btnPrintDetails.Enabled = False
                btnPrintOT.Enabled = False
                btnPrintSummary.Enabled = False
            Else
                btnEdit.Enabled = True
                btnCancel.Enabled = True
                btnPrintDTR.Enabled = True
                btnPrintDetails.Enabled = True
                btnPrintOT.Enabled = True
                btnPrintSummary.Enabled = True
            End If
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

    Private Sub lvContract_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvContract.SelectedIndexChanged
        If lvContract.SelectedItems.Count = 1 Then
            LoadBillingDetails(lvContract.SelectedItems(0).SubItems(chBSNo.Index).Text)
        End If
    End Sub

    Private Sub btnPrintSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSummary.Click
        If txtBSNo.Text <> "" Then
            frmReport_Display.ShowDialog("TRANS_BS_MP_SUMMARY", txtBSNo.Text)
            frmReport_Display.Dispose()
        End If
    End Sub

    Private Sub btnPrintDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintDetails.Click
        If txtBSNo.Text <> "" Then
            frmReport_Display.ShowDialog("TRANS_BS_MP_DETAILED", txtBSNo.Text)
            frmReport_Display.Dispose()
        End If
    End Sub

    Private Sub btnPrintDTR_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintDTR.Click
        If txtBSNo.Text <> "" Then
            Dim query As String
            Dim dt As New DataTable
            query = " SELECT DISTINCT Emp_ID, Subgroup FROM tblManpower_BillingDetails WHERE BS_Ref = '" & txtBSNo.Text & "' "
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                dt = SQL.SQLDS.Tables(0)
            End If
            SQL.CloseCon()
            SetPayrollDatabase()
            Dim deleteSQL As String
            deleteSQL = " DELETE FROM tblFilter_Group "
            SQL_RUBY.ExecNonQuery(deleteSQL)
            Dim insertSQL As String
            For Each row As DataRow In dt.Rows
                insertSQL = " INSERT INTO tblFilter_Group(Emp_ID, F1) VALUES (@Emp_ID, @F1) "
                SQL_RUBY.FlushParams()
                SQL_RUBY.AddParam("@Emp_ID", row(0).ToString)
                SQL_RUBY.AddParam("@F1", row(1).ToString)
                SQL_RUBY.ExecNonQuery(insertSQL)
            Next
            SQL_RUBY.CloseCon()
            SetDatabase()
            frmReport_Display.ShowDialog("TRANS_BS_MP_DTR", txtPeriod.Text)
            frmReport_Display.Dispose()
        End If
    End Sub

    Private Sub btnPrintOT_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintOT.Click
        If txtBSNo.Text <> "" Then
            Dim query As String
            Dim dt, dt2 As New DataTable
            query = " SELECT DISTINCT Emp_ID, Subgroup FROM tblManpower_BillingDetails WHERE BS_Ref = '" & txtBSNo.Text & "' "
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                dt = SQL.SQLDS.Tables(0)
            End If
            query = " SELECT DISTINCT Type FROM tblManpower_BillingDetails WHERE Category ='Overtime' AND BS_Ref ='" & txtBSNo.Text & "' "
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                dt2 = SQL.SQLDS.Tables(0)
            End If
            SQL.CloseCon()
            SetPayrollDatabase()
            Dim deleteSQL As String
            deleteSQL = " DELETE FROM tblReport_Filter "
            SQL_RUBY.ExecNonQuery(deleteSQL)
            deleteSQL = " DELETE FROM tblFilter_PrintH "
            SQL_RUBY.ExecNonQuery(deleteSQL)
            Dim insertSQL As String
            For Each row As DataRow In dt.Rows
                insertSQL = " INSERT INTO tblReport_Filter(Filter) VALUES (@Filter) "
                SQL_RUBY.FlushParams()
                SQL_RUBY.AddParam("@Filter", row(0).ToString)
                SQL_RUBY.ExecNonQuery(insertSQL)
            Next
            For Each row As DataRow In dt2.Rows
                insertSQL = " INSERT INTO tblFilter_PrintH(Description) VALUES (@Description) "
                SQL_RUBY.FlushParams()
                SQL_RUBY.AddParam("@Description", row(0).ToString)
                SQL_RUBY.ExecNonQuery(insertSQL)
            Next
            insertSQL = " INSERT INTO tblFilter_PrintH(Description) VALUES ('TOTAL') "
            SQL_RUBY.ExecNonQuery(insertSQL)
            SQL_RUBY.CloseCon()
            SetDatabase()

            frmReport_Display.ShowDialog("TRANS_BS_MP_OT", txtPeriod.Text)
            frmReport_Display.Dispose()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If txtBSNo.Text <> "" Then
            If MsgBox("Are you sure you want to cancel this billing? This action can't be undone", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim updateSQL As String
                updateSQL = " UPDATE tblManpower_Billing " & _
                            " SET    Status ='Cancelled' " & _
                            " WHERE  TransID = '" & txtBSNo.Text & "'"
                SQL.ExecNonQuery(updateSQL)
                MsgBox("Billing cancelled successfully!", MsgBoxStyle.Information)
                LoadBillingDetails(lvContract.SelectedItems(0).SubItems(chBSNo.Index).Text)
                LoadStatus()
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If IsNumeric(txtBSNo.Text) Then
            frmBilling_Manpower_New.ShowDialog(txtBSNo.Text)
            frmBilling_Manpower_New.Dispose()
            LoadBillingList()
        End If
      
    End Sub
End Class