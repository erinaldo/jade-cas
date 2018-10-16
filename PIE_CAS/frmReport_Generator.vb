Public Class frmReport_Generator
    Public Type As String
    Dim branch As String

    Private Sub frmReports_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbReport.Items.Clear()
        cbReport.Items.Add("Trial Balance")
        cbReport.Items.Add("Subsidiary Ledger Schedule")
        cbReport.Items.Add("Account Schedule")
        cbReport.Items.Add("Book of Accounts")
        nupYear.Value = Date.Today.Year
        cbMonth.SelectedIndex = Date.Today.Month - 1
        LoadBranches()
    End Sub

    Private Sub LoadBranches()
        Dim query As String
        query = " SELECT BranchCode + ' - ' + Description AS BranchCode FROM tblBranch WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbBranch.Items.Clear()
        cbBranch.Items.Add("ALL - ALL BRANCHES")
        While SQL.SQLDR.Read
            cbBranch.Items.Add(SQL.SQLDR("BranchCode").ToString)
        End While
        cbBranch.SelectedItem = "ALL - ALL BRANCHES"
    End Sub
    Private Sub cbReport_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbReport.SelectedIndexChanged
        If cbReport.SelectedItem = "Trial Balance" Then
            Reset()
            gbType.Enabled = True
            cbMonth.SelectedIndex = Date.Today.Month - 1
            gbPeriodYM.Visible = True
        ElseIf cbReport.SelectedItem = "Book of Accounts" Then
            gbType.Enabled = True
            Reset()
            cbPeriod.Enabled = True
            cbPeriod.SelectedIndex = 0
            gbPeriodYM.Visible = True
            lvFilter.Items.Add("General Ledger")
            lvFilter.Items.Add("Cash Receipt")
            lvFilter.Items.Add("Cash Disbursement")
            lvFilter.Items.Add("Sales")
            lvFilter.Items.Add("Purchases")
            lvFilter.Items.Add("Journal Voucher")
            lvFilter.Items(0).Checked = True
        ElseIf cbReport.SelectedItem = "Balance Sheet" Or cbReport.SelectedItem = "Income Statement" Then
            Reset()
            cbPeriod.Enabled = False
            gbPeriodYM.Visible = True
            gbType.Enabled = False
        ElseIf cbReport.SelectedItem = "Subsidiary Ledger Schedule" Then
            Reset()
            cbPeriod.Enabled = False
            gbPeriodFT.Visible = True
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "As Of :"
            gbType.Enabled = False
            LoadSubsidiary()
        ElseIf cbReport.SelectedItem = "Daily Cash Position" Then
            Reset()
            cbPeriod.Enabled = False
            gbPeriodFT.Visible = True
            gbPeriodYM.Visible = False
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "As Of :"
            gbType.Enabled = False
        ElseIf cbReport.SelectedItem = "Account Schedule" Then
            Reset()
            cbPeriod.Enabled = True
            gbPeriodFT.Visible = False
            gbPeriodYM.Visible = True
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "As Of :"
            gbType.Enabled = False
            cbPeriod.SelectedIndex = 0
            LoadAccounts()
        ElseIf cbReport.SelectedItem = "Loan Aging Report" Then
            Reset()
            cbPeriod.Enabled = False
            gbPeriodFT.Visible = True
            gbPeriodYM.Visible = False
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "As Of :"
            gbType.Enabled = False
        ElseIf cbReport.SelectedItem = "BIR Tax 2550" Then
            Reset()
            cbPeriod.Enabled = True
            gbPeriodFT.Visible = False
            gbPeriodYM.Visible = True
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "From :"
            gbType.Enabled = False
            cbPeriod.Items.Clear()
            cbPeriod.Items.Add("Quarterly")
            cbPeriod.Items.Add("Monthly")
        ElseIf cbReport.SelectedItem = "Loan Release" Then
            Reset()
            cbPeriod.Enabled = True
            gbPeriodFT.Visible = False
            gbPeriodYM.Visible = True
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "From :"
            gbType.Enabled = False
            cbPeriod.SelectedIndex = 1
        End If
    End Sub

    Private Sub LoadSubsidiary()
        Dim query As String
        query = " SELECT   DISTINCT tblCOA_Master.AccountTitle " & _
                " FROM     tblCOA_Master " & _
                " WHERE    withSubsidiary = 1 " & _
                " ORDER BY AccountTitle "
        SQL.ReadQuery(query)
        lvFilter.Items.Clear()
        While SQL.SQLDR.Read
            lvFilter.Items.Add(SQL.SQLDR("AccountTitle").ToString)
        End While
    End Sub

    Private Sub LoadPeriod()
        If cbMonth.SelectedIndex <> -1 Then
            Dim period As String = (cbMonth.SelectedIndex + 1).ToString & "-1-" & nupYear.Value.ToString
            If chkYTD.Checked Then
                dtpFrom.Value = Date.Parse("1-1-" & nupYear.Value.ToString)
                dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Date.Parse(period)))
            Else
                dtpFrom.Value = Date.Parse(period)
                dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Date.Parse(period)))
            End If
        End If
    End Sub

    Private Sub Reset()
        cbMonth.Enabled = True
        lvFilter.Items.Clear()
        gbPeriodYM.Visible = True
        gbPeriodFT.Visible = False
        cbPeriod.Enabled = False
        lblFrom.Text = "From :"
        lblTo.Visible = True
        dtpTo.Visible = True
        cbPeriod.Items.Clear()
        cbPeriod.Items.Add("Yearly")
        cbPeriod.Items.Add("Monthly")
        cbPeriod.Items.Add("Daily")
        cbPeriod.Items.Add("Date Range")
        cbPeriod.SelectedIndex = -1

        cbMonth.Items.Clear()
        cbMonth.Items.Add("January")
        cbMonth.Items.Add("February")
        cbMonth.Items.Add("March")
        cbMonth.Items.Add("April")
        cbMonth.Items.Add("May")
        cbMonth.Items.Add("June")
        cbMonth.Items.Add("July")
        cbMonth.Items.Add("August")
        cbMonth.Items.Add("September")
        cbMonth.Items.Add("October")
        cbMonth.Items.Add("November")
        cbMonth.Items.Add("December")
        lblMonth.Text = "Month :"
    End Sub

    Private Sub btnPreview_Click(sender As System.Object, e As System.EventArgs) Handles btnPreview.Click
        If cbBranch.SelectedIndex = -1 Then
            Msg("Select Branch First!", MsgBoxStyle.Exclamation)
        Else

            branch = Strings.Left(cbBranch.SelectedItem, cbBranch.SelectedItem.ToString.IndexOf(" - "))
            If cbReport.SelectedItem = "Trial Balance" Then
                GenerateTB(IIf(rbSummary.Checked = True, "Summary", "Detailed"), dtpFrom.Value.Date, dtpTo.Value.Date)
            ElseIf cbReport.SelectedItem = "Book of Accounts" Then
                Dim index As Integer = -1
                For Each item As ListViewItem In lvFilter.Items
                    If item.Checked = True Then
                        index = item.Index
                    End If
                Next
                If index <> -1 Then
                    If cbPeriod.SelectedItem = "Daily" Then
                        GenerateTB("By Book", dtpFrom.Value.Date, dtpFrom.Value.Date, lvFilter.Items(index).SubItems(0).Text)
                    Else
                        GenerateTB("By Book", dtpFrom.Value.Date, dtpTo.Value.Date, lvFilter.Items(index).SubItems(0).Text)
                    End If
                Else
                    MsgBox("Please select book first!", MsgBoxStyle.Exclamation)
                End If
            ElseIf cbReport.SelectedItem = "Balance Sheet" Then
                Dim f As New frmReport_Display
                f.ShowDialog("FSBALS", "", dtpTo.Value.Date)
                f.Dispose()
            ElseIf cbReport.SelectedItem = "Income Statement" Then
                Dim f As New frmReport_Display

                f.ShowDialog("FSINCS", "", dtpFrom.Value.Date, dtpTo.Value.Date)
                f.Dispose()
            ElseIf cbReport.SelectedItem = "Subsidiary Ledger Schedule" Then
                GenerateSL()
            ElseIf cbReport.SelectedItem = "Daily Cash Position" Then
                GenerateDCPR("Daily", dtpFrom.Value.Date, dtpFrom.Value.Date)
            ElseIf cbReport.SelectedItem = "Account Schedule" Then
                GenerateGL()
            ElseIf cbReport.SelectedItem = "Loan Aging Report" Then
                Dim f As New frmReport_Display
                f.ShowDialog("AGINGL", "", dtpFrom.Value.Date)
                f.Dispose()
            ElseIf cbReport.SelectedItem = "Loan Release" Then
                Dim f As New frmReport_Display
                If cbPeriod.SelectedItem = "Yearly" Then
                    f.ShowDialog("LOANRLSY", "", nupYear.Value)
                ElseIf cbPeriod.SelectedItem = "Monthly" Then
                    f.ShowDialog("LOANRLSM", "", nupYear.Value, cbMonth.SelectedIndex + 1)
                ElseIf cbPeriod.SelectedItem = "Daily" Then
                    f.ShowDialog("LOANRLSD", "", dtpFrom.Value.Date)
                ElseIf cbPeriod.SelectedItem = "Date Range" Then
                    f.ShowDialog("LOANRLSR", "", dtpFrom.Value.Date, dtpTo.Value.Date)
                End If
                f.Dispose()
            End If
        End If
        
    End Sub

    Private Sub GenerateSL()
        Dim i As Integer = 1
        Dim insertSQl As String
        Dim deleteSQL As String
        deleteSQL = " DELETE FROM tblSL_PrintH  "
        SQL.ExecNonQuery(deleteSQL)
        deleteSQL = " DELETE FROM tblSL_Print "
        SQL.ExecNonQuery(deleteSQL)
        insertSQl = " INSERT INTO tblSL_Print(VCECode) " & _
                    " SELECT DISTINCT VCECode " & _
                    " FROM   view_GL INNER JOIN tblCOA_Master " & _
                    " ON     view_GL.AccntCode = tblCOA_Master.AccountCode " & _
                    " WHERE  AppDate BETWEEN CAST('01-01-" & dtpFrom.Value.Year & "' AS DATE) AND '" & dtpTo.Value.Date & "'  " & _
                    " AND    WithSubsidiary = 1 " & _
                    " ORDER BY VCECode "
        SQL.ExecNonQuery(insertSQl)
        For Each item As ListViewItem In lvFilter.Items
            If item.Checked = True And i < 10 Then
                insertSQl = " INSERT INTO " & _
                            " tblSL_PrintH(Type, Description) " & _
                            " VALUES ('C" & i & "',@Description)"
                SQL.FlushParams()
                SQL.AddParam("@Description", item.SubItems(0).Text)
                SQL.ExecNonQuery(insertSQl)
                Dim updateSQL As String
                updateSQL = " UPDATE tblSL_Print " & _
                            " SET    C" & i & " = ISNULL(Balance,0) " & _
                            " FROM  " & _
                            " ( " & _
                            "      SELECT VCECode, SUM(ISNULL(CASE WHEN AccountNature ='Debit' " & _
                            " 		     THEN Debit -Credit                           " & _
                            " 			ELSE Credit - Debit  " & _
                            " 	   END,0)) AS Balance " & _
                            " FROM view_GL INNER JOIN tblCOA_Master " & _
                            " ON view_GL.AccntCode = tblCOA_Master.AccountCode " & _
                            " WHERE AppDate BETWEEN CAST('01-01-" & dtpFrom.Value.Year & "' AS DATE) AND '" & dtpTo.Value.Date & "' " & _
                            " AND WithSubsidiary = 1 AND tblCOA_Master.AccountTitle = @Description AND AccountNature IN ('Debit','Credit') " & _
                            " GROUP BY VCECode " & _
                            " ) AS A " & _
                            " WHERE  tblSL_Print.VCECode = A.VCECode "
                SQL.FlushParams()
                SQL.AddParam("@Description", item.SubItems(0).Text)
                SQL.ExecNonQuery(updateSQL)
                i += 1
            End If
        Next

        Dim f As New frmReport_Display
        f.ShowDialog("SUBLGRS", UserName, dtpFrom.Value.Date, dtpTo.Value.Date)
        f.Dispose()
    End Sub

    Private Sub LoadAccounts()
        Dim query As String
        query = " SELECT DISTINCT AccountTitle FROM tblCOA_Master ORDER BY AccountTitle "
        SQL.ReadQuery(query)
        lvFilter.Items.Clear()
        While SQL.SQLDR.Read
            lvFilter.Items.Add(SQL.SQLDR("AccountTitle").ToString)
        End While
    End Sub

    Private Sub GenerateGL()
        Dim i As Integer = 1
        Dim insertSQl As String
        Dim deleteSQL As String
        deleteSQL = " DELETE FROM tblPrint_TB  "
        SQL.ExecNonQuery(deleteSQL)
        For Each item As ListViewItem In lvFilter.Items
            If item.Checked = True Then
                insertSQl = " INSERT INTO tblPrint_TB(Code) " & _
                            " VALUES (@Code) "
                SQL.FlushParams()
                SQL.AddParam("@Code", GetAccntCode(item.SubItems(0).Text))
                SQL.ExecNonQuery(insertSQl)
            End If
        Next

        If cbPeriod.SelectedItem = "Yearly" Then
            Dim f As New frmReport_Display
            f.ShowDialog("GENLGRY", "", nupYear.Value)
            f.Dispose()
        ElseIf cbPeriod.SelectedItem = "Monthly" Then
            Dim f As New frmReport_Display
            f.ShowDialog("GENLGRM", "", nupYear.Value, cbMonth.SelectedIndex + 1)
            f.Dispose()
        ElseIf cbPeriod.SelectedItem = "Daily" Then
            Dim f As New frmReport_Display
            f.ShowDialog("GENLGRD", "", dtpTo.Value.Date)
            f.Dispose()
        ElseIf cbPeriod.SelectedItem = "Date Range" Then
            Dim f As New frmReport_Display
            f.ShowDialog("GENLGRR", "", dtpFrom.Value.Date, dtpTo.Value.Date)
            f.Dispose()
        End If
    End Sub

    Private Sub GenerateTB(ByVal Type As String, ByVal DateFrom As Date, ByVal DateTo As Date, Optional ByVal Filter As String = "")
        Dim insertSQL, deleteSQL As String
        deleteSQL = " DELETE FROM tblPRint_TB "
        SQL.ExecNonQuery(deleteSQL)
        If Type = "Detailed" Then
            insertSQL = " INSERT INTO tblPRint_TB(Code, Title, BBDR, BBCR, CRDR, CRCR, CDDR, CDCR, SBDR, SBCR, PBDR, PBCR, JVDR, JVCR, TBDR, TBCR) " & _
                    " SELECT  AccountCode, AccountTitle,  " & _
                    " 		  CASE WHEN SUM(BBDR) > SUM(BBCR) THEN SUM(BBDR) - SUM(BBCR) ELSE 0 END AS BBDR, " & _
                    " 		  CASE WHEN SUM(BBCR) > SUM(BBDR) THEN SUM(BBCR) - SUM(BBDR) ELSE 0 END AS BBDR, " & _
                    " 		  SUM(CRDR) AS CRDR, " & _
                    " 		  SUM(CRCR) AS CRCR, " & _
                    " 		  SUM(CDDR) AS CDDR, " & _
                    " 		  SUM(CDCR) AS CDCR, " & _
                    " 		  SUM(SBDR) AS SBDR, " & _
                    " 		  SUM(SBCR) AS SBCR, " & _
                    " 		  SUM(PBDR) AS PBDR, " & _
                    " 		  SUM(PBCR) AS PBCR, " & _
                    " 		  SUM(JVDR) AS JVDR, " & _
                    " 		  SUM(JVCR) AS JVCR, " & _
                    " 		  CASE WHEN SUM(TBDR) > SUM(TBCR) THEN SUM(TBDR) - SUM(TBCR) ELSE 0 END AS TBDR, " & _
                    " 		  CASE WHEN SUM(TBCR) > SUM(TBDR) THEN SUM(TBCR) - SUM(TBDR) ELSE 0 END AS TBCR " & _
                    " FROM " & _
                    " ( " & _
                    " 	SELECT tblCOA_Master.AccountCode, tblCOA_Master.AccountTitle,  " & _
                    " 		   CASE WHEN AppDate <'" & DateFrom & "' OR Book ='BB' THEN Debit ELSE 0 END AS BBDR, " & _
                    " 		   CASE WHEN AppDate < '" & DateFrom & "' OR Book ='BB' THEN Credit ELSE 0 END AS BBCR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' THEN Debit ELSE 0 END AS CRDR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' THEN Credit ELSE 0 END AS CRCR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Disbursements' THEN Debit ELSE 0 END AS CDDR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Disbursements' THEN Credit ELSE 0 END AS CDCR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Sales' THEN Debit ELSE 0 END AS SBDR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Sales' THEN Credit ELSE 0 END AS SBCR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Purchases' THEN Debit ELSE 0 END AS PBDR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Purchases' THEN Credit ELSE 0 END AS PBCR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='General Journal' THEN Debit ELSE 0 END AS JVDR, " & _
                    " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='General Journal' THEN Credit ELSE 0 END AS JVCR, " & _
                    " 		   Debit AS TBDR, " & _
                    " 		   Credit AS TBCR " & _
                    " 	FROM view_GL INNER JOIN tblCOA_Master " & _
                    " 	ON view_GL.AccntCode = tblCOA_Master.AccountCode " & _
                    " 	WHERE AppDate BETWEEN '01-01-" & DateFrom.Year & "' AND '" & DateTo & "' " & IIf(branch = "ALL", "", " AND BranchCode = '" & branch & "' ") & _
                    " ) AS A " & _
                    " GROUP BY AccountCode, AccountTitle "
            SQL.ExecNonQuery(insertSQL)
            Dim f As New frmReport_Display
            f.ShowDialog("FS_TB_Detailed", "", DateTo, branch)
            f.Dispose()
        ElseIf Type = "Summary" Then
            insertSQL = " INSERT INTO tblPRint_TB(Code, Title, BBDR, BBCR, CRDR, CRCR, TBDR, TBCR) " & _
                 " SELECT  AccountCode, AccountTitle,  " & _
                 " 		  CASE WHEN SUM(BBDR) > SUM(BBCR) THEN SUM(BBDR) - SUM(BBCR) ELSE 0 END AS BBDR, " & _
                 " 		  CASE WHEN SUM(BBCR) > SUM(BBDR) THEN SUM(BBCR) - SUM(BBDR) ELSE 0 END AS BBDR, " & _
                 " 		  CASE WHEN SUM(CRDR + CDDR + JVDR + PBDR + SBDR + IBDR) > SUM(CRCR + CDCR + JVCR + PBCR + SBCR + IBCR) THEN SUM(CRDR + CDDR + JVDR + PBDR + SBDR + IBDR) - SUM(CRCR + CDCR + JVCR + PBCR + SBCR + IBCR) ELSE 0 END AS CRDR, " & _
                 " 		  CASE WHEN SUM(CRCR + CDCR + JVCR + PBCR + SBCR + IBCR) > SUM(CRDR + CDDR + JVDR + PBDR + SBDR + IBDR) THEN SUM(CRCR + CDCR + JVCR + PBCR + SBCR + IBCR) - SUM(CRDR + CDDR + JVDR + PBDR + SBDR + IBDR) ELSE 0 END AS CRCR, " & _
                 " 		  CASE WHEN SUM(TBDR) > SUM(TBCR) THEN SUM(TBDR) - SUM(TBCR) ELSE 0 END AS TBDR, " & _
                 " 		  CASE WHEN SUM(TBCR) > SUM(TBDR) THEN SUM(TBCR) - SUM(TBDR) ELSE 0 END AS TBCR " & _
                 " FROM " & _
                 " ( " & _
                 " 	SELECT tblCOA_Master.AccountCode, tblCOA_Master.AccountTitle,  " & _
                 " 		   CASE WHEN AppDate <'" & DateFrom & "' OR Book ='BB' THEN Debit ELSE 0 END AS BBDR, " & _
                 " 		   CASE WHEN AppDate < '" & DateFrom & "' OR Book ='BB' THEN Credit ELSE 0 END AS BBCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' THEN Debit ELSE 0 END AS CRDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' THEN Credit ELSE 0 END AS CRCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Disbursements' THEN Debit ELSE 0 END AS CDDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Disbursements' THEN Credit ELSE 0 END AS CDCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='General Journal' THEN Debit ELSE 0 END AS JVDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='General Journal' THEN Credit ELSE 0 END AS JVCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Purchases' THEN Debit ELSE 0 END AS PBDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Purchases' THEN Credit ELSE 0 END AS PBCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Sales' THEN Debit ELSE 0 END AS SBDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Sales' THEN Credit ELSE 0 END AS SBCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Inventory' THEN Debit ELSE 0 END AS IBDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Inventory' THEN Credit ELSE 0 END AS IBCR, " & _
                 " 		   Debit AS TBDR, " & _
                 " 		   Credit AS TBCR " & _
                 " 	FROM View_GL JOIN tblCOA_Master " & _
                 " 	ON View_GL.AccntCode = tblCOA_Master.AccountCode " & _
                 " 	WHERE AppDate BETWEEN '01-01-" & DateFrom.Year & "' AND '" & DateTo & "' " & IIf(branch = "ALL", "", " AND BranchCode = '" & branch & "' ") & _
                 " ) AS A " & _
                 " GROUP BY AccountCode, AccountTitle "
            SQL.ExecNonQuery(insertSQL)
            Dim f As New frmReport_Display
            f.ShowDialog("FS_TB_Summary", "", DateTo, branch)
            f.Dispose()
        ElseIf Type = "By Book" Then
            If rbDetailed.Checked = True Then
                insertSQL = " INSERT INTO tblPRint_TB(Code, Title, BBDR, BBCR, CRDR, CRCR, CDDR, CDCR, JVDR, JVCR, PBDR, PBCR, SBDR, SBCR, IBDR, IBCR, TBDR, TBCR) " & _
             " SELECT  AccountCode, AccountTitle,  " & _
             " 		  SUM(BBDR) AS BBDR, " & _
             " 		  SUM(BBDR) AS BBDR, " & _
             " 		  SUM(CRDR) AS CRDR, " & _
             " 		  SUM(CRCR) AS CRCR, " & _
             " 		  SUM(CDDR) AS CDDR, " & _
             " 		  SUM(CDCR) AS CDCR, " & _
             " 		  SUM(JVDR) AS JVDR, " & _
             " 		  SUM(JVCR) AS JVCR, " & _
             " 		  SUM(PBDR) AS PBDR, " & _
             " 		  SUM(PBCR) AS PBCR, " & _
             " 		  SUM(SBDR) AS SBDR, " & _
             " 		  SUM(SBCR) AS SBCR, " & _
             " 		  SUM(IBDR) AS IBDR, " & _
             " 		  SUM(IBCR) AS IBCR, " & _
             " 		  CASE WHEN SUM(TBDR) > SUM(TBCR) THEN SUM(TBDR) - SUM(TBCR) ELSE 0 END AS TBDR, " & _
             " 		  CASE WHEN SUM(TBCR) > SUM(TBDR) THEN SUM(TBCR) - SUM(TBDR) ELSE 0 END AS TBCR " & _
             " FROM " & _
             " ( " & _
             " 	SELECT tblCOA_Master.AccountCode, tblCOA_Master.AccountTitle,  " & _
             " 		   CASE WHEN AppDate <'" & DateFrom & "' OR Book ='BB' THEN Debit ELSE 0 END AS BBDR, " & _
             " 		   CASE WHEN AppDate < '" & DateFrom & "' OR Book ='BB' THEN Credit ELSE 0 END AS BBCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' THEN Debit ELSE 0 END AS CRDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' THEN Credit ELSE 0 END AS CRCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Disbursements' THEN Debit ELSE 0 END AS CDDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Disbursements' THEN Credit ELSE 0 END AS CDCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='General Journal' THEN Debit ELSE 0 END AS JVDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='General Journal' THEN Credit ELSE 0 END AS JVCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Purchases' THEN Debit ELSE 0 END AS PBDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Purchases' THEN Credit ELSE 0 END AS PBCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Sales' THEN Debit ELSE 0 END AS SBDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Sales' THEN Credit ELSE 0 END AS SBCR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Inventory' THEN Debit ELSE 0 END AS IBDR, " & _
                 " 		   CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Inventory' THEN Credit ELSE 0 END AS IBCR, " & _
             " 		   Debit AS TBDR, " & _
             " 		   Credit AS TBCR " & _
             " 	FROM View_GL INNER JOIN tblCOA_Master " & _
             " 	ON View_GL.AccntCode = tblCOA_Master.AccountCode " & _
             " 	WHERE AppDate BETWEEN '" & DateFrom & "' AND '" & DateTo & "' " & _
             " ) AS A " & _
             " GROUP BY AccountCode, AccountTitle "
                SQL.ExecNonQuery(insertSQL)
                If cbPeriod.SelectedItem = "Yearly" Then
                    Dim f As New frmReport_Display
                    f.ShowDialog("BOASUMY", "", nupYear.Value, Filter)
                    f.Dispose()
                ElseIf cbPeriod.SelectedItem = "Monthly" Then
                    Dim f As New frmReport_Display
                    f.ShowDialog("BOASUMM", "", cbMonth.SelectedIndex + 1, nupYear.Value, Filter)
                    f.Dispose()
                ElseIf cbPeriod.SelectedItem = "Daily" Then
                    Dim f As New frmReport_Display
                    f.ShowDialog("BOASUMD", "", dtpFrom.Value.Date, Filter)
                    f.Dispose()
                ElseIf cbPeriod.SelectedItem = "Date Range" Then
                    Dim f As New frmReport_Display
                    f.ShowDialog("BOASUMR", "", dtpFrom.Value.Date, dtpTo.Value.Date, Filter)
                    f.Dispose()
                End If
            Else
                If Filter = "General Ledger" Then
                    If cbPeriod.SelectedItem = "Yearly" Then
                        dtpFrom.Value = CDate("1-1-" + nupYear.Value.ToString)
                        dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, CDate("1-1-" + nupYear.Value.ToString)))
                    ElseIf cbPeriod.SelectedItem = "Monthly" Then
                        dtpFrom.Value = CDate((cbMonth.SelectedIndex + 1).ToString + "-1-" + nupYear.Value.ToString)
                        dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate((cbMonth.SelectedIndex + 1).ToString + "-1-" + nupYear.Value.ToString)))
                    ElseIf cbPeriod.SelectedItem = "Daily" Then
                        dtpTo.Value = dtpFrom.Value.Date
                    End If
                    Dim f As New frmReport_Display
                    f.ShowDialog("Book_GL", "", dtpFrom.Value.Date, dtpTo.Value.Date)
                    f.Dispose()
                End If
            End If

        End If
    End Sub

    Private Sub GenerateDCPR(ByVal Type As String, ByVal DateFrom As Date, ByVal DateTo As Date, Optional ByVal Filter As String = "")
        Dim insertSQL, deleteSQL As String
        deleteSQL = " DELETE FROM tblPRint_DCPR "
        SQL.ExecNonQuery(deleteSQL)
        If Type = "Daily" Then
            insertSQL = " INSERT INTO tblPRint_DCPR(Code, Title, BB, CR, DEP, CD, JV, Row_ID) " & _
                        "  SELECT  AccountCode, AccountTitle,   		   " & _
                        " 		SUM(BB) AS BB,  		   " & _
                        " 		SUM(CR) AS CR,  		   " & _
                        " 		SUM(DEP) AS DEP,  		   " & _
                        " 		SUM(CD) AS CD,  		   " & _
                        " 		SUM(JV) AS JV,           " & _
                        " 		ROW_NUMBER() OVER (ORDER BY AccountCode) AS Row_ID   " & _
                        " FROM   " & _
                        " (  	 " & _
                        " 		SELECT  AccountCode, AccountTitle,   		    " & _
                        " 				CASE WHEN AppDate <'" & DateFrom & "' OR Book ='BB' THEN Debit - Credit ELSE 0 END AS BB,  		    " & _
                        " 				CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' AND RefType <> 'DS' THEN Debit - Credit ELSE 0 END AS CR,   " & _
                        " 			    CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Receipts' AND RefType ='DS' THEN Debit - Credit ELSE 0 END AS DEP,   " & _
                        " 				CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='Cash Disbursements' THEN Credit - Debit ELSE 0 END AS CD,  		   " & _
                        " 				CASE WHEN AppDate >= '" & DateFrom & "' AND Book ='General Journal' THEN Debit - Credit ELSE 0 END AS JV  	 " & _
                        " 		FROM view_GL RIGHT JOIN tblCOA_Master  	 " & _
                        " 		ON   view_GL.AccntCode = tblCOA_Master.AccountCode  	 " & _
                        " 		WHERE (AppDate BETWEEN '01-01-" & DateFrom.Year & "' AND '" & DateFrom & "'  OR view_GL.AccntCode IS NULL)    " & _
                        " 		AND   (tblCOA_Master.AccountCode IN (SELECT Account_Code FROM tblMasterfile_Bank))   " & _
                        " ) AS A  GROUP BY AccountCode, AccountTitle "
            SQL.ExecNonQuery(insertSQL)
            Dim f As New frmReport_Display
            f.ShowDialog("DCPR", DateTo)
            f.Dispose()
        End If
    End Sub



    Private Sub nupYear_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nupYear.ValueChanged, cbMonth.SelectedIndexChanged, chkYTD.CheckedChanged
        LoadPeriod()
    End Sub

    Private Sub lvFilter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvFilter.SelectedIndexChanged
        If cbReport.SelectedItem = "Book of Accounts" Then
            For Each item As ListViewItem In lvFilter.Items
                item.Checked = False
            Next
        End If
        If lvFilter.SelectedItems.Count = 1 Then
            If lvFilter.SelectedItems(0).Checked = False Then
                lvFilter.SelectedItems(0).Checked = True
            Else
                lvFilter.SelectedItems(0).Checked = False
            End If
        End If
        rbSpecific.Checked = True
    End Sub

    Private Sub cbPeriod_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPeriod.SelectedIndexChanged
        If cbPeriod.SelectedItem = "Monthly" Then
            gbPeriodYM.Visible = True
            gbPeriodFT.Visible = False
            chkYTD.Visible = False
            cbMonth.Enabled = True
            cbMonth.Items.Clear()
            cbMonth.Items.Add("January")
            cbMonth.Items.Add("February")
            cbMonth.Items.Add("March")
            cbMonth.Items.Add("April")
            cbMonth.Items.Add("May")
            cbMonth.Items.Add("June")
            cbMonth.Items.Add("July")
            cbMonth.Items.Add("August")
            cbMonth.Items.Add("September")
            cbMonth.Items.Add("October")
            cbMonth.Items.Add("November")
            cbMonth.Items.Add("December")
            lblMonth.Text = "Month :"
        ElseIf cbPeriod.SelectedItem = "Daily" Then
            gbPeriodYM.Visible = False
            gbPeriodFT.Visible = True
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "Date :"
        ElseIf cbPeriod.SelectedItem = "Date Range" Then
            lblFrom.Text = "From :"
            lblTo.Visible = True
            dtpTo.Visible = True
            gbPeriodYM.Visible = False
            gbPeriodFT.Visible = True '
        ElseIf cbPeriod.SelectedItem = "Yearly" Then
            chkYTD.Checked = True
            LoadPeriod()
            lblFrom.Text = "From :"
            lblTo.Visible = True
            dtpTo.Visible = True
            gbPeriodYM.Visible = True
            gbPeriodFT.Visible = False
            cbMonth.Enabled = False
        ElseIf cbPeriod.SelectedItem = "Quarterly" Then
            chkYTD.Checked = True
            LoadPeriod()
            cbMonth.Items.Clear()
            cbMonth.Items.Add("1st Quarter")
            cbMonth.Items.Add("2nd Quarter")
            cbMonth.Items.Add("3rd Quarter")
            cbMonth.Items.Add("4th Quarter")
            lblMonth.Text = "Quarter :"
            lblFrom.Text = "From :"
            lblTo.Visible = True
            dtpTo.Visible = True
            gbPeriodYM.Visible = True
            gbPeriodFT.Visible = False
            cbMonth.Enabled = True
        End If
    End Sub


    Private Sub rbAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAll.CheckedChanged, rbNone.CheckedChanged, rbSpecific.CheckedChanged
        If rbAll.Checked = True Then
            For Each item As ListViewItem In lvFilter.Items
                item.Checked = True
            Next
        ElseIf rbNone.Checked = True Then
            For Each item As ListViewItem In lvFilter.Items
                item.Checked = False
            Next
        End If
    End Sub

    Private Sub GroupBox6_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox6.Enter

    End Sub
End Class