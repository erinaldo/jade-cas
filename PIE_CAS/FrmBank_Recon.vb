Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.Net.NetworkInformation
Public Class FrmBank_Recon
    Dim SQL As New SQLControl
    Dim adjustedCash As Decimal = 0
    Dim disableEvent As Boolean = False
    Dim bank As String
    Dim bankID As String

    Private Sub FrmBank_Recon_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadBank()
    End Sub

    Public Sub LoadBank()
        Dim query As String
        query = " SELECT    Bank_ID, Bank, Branch, Account_Code, AccountTitle, Account_No" & _
                " FROM      tblMasterfile_Bank INNER JOIN tblCOA_Master  " & _
                " ON        Account_Code = AccountCode " & _
                " ORDER BY  Bank, Branch"
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            bank = SQL.SQLDR("Bank_ID").ToString & "-" & SQL.SQLDR("Bank").ToString & " " & SQL.SQLDR("Branch").ToString & " " & SQL.SQLDR("Account_No").ToString
            txtBank.Items.Add(bank)
        End While
    End Sub

    Public Sub Trialbal(bank As String)
        Dim query As String
        query = " SELECT   SUM(Debit) - SUM(Credit) AS CashInBank " & _
                " FROM     dbo.View_GL " & _
                " WHERE    (MONTH(AppDate) <= " & dtpDocDate.Value.Month & ") AND (YEAR(AppDate) =  " & dtpDocDate.Value.Year & ") " & _
                " AND      AccntCode = '" & txtBankAccountCode.Text & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtTrialBalanceAmount.Text = Format(SQL.SQLDR("CashInBank"), "###,###,###.##").ToString()
        Else
            txtTrialBalanceAmount.Text = 0
        End If
    End Sub

    Private Sub txtBank_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtBank.SelectedIndexChanged
        Try
            If disableEvent = False Then
                LoadBankDetail(txtBank.Text)
                RefreshData()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RefreshData()
        Trialbal(txtBank.Text)
        DepositInTransit()
        LoadOutstandingCheck()
        LoadBankReconJV()
        LoadAdjustedBookBalance()
        UpdateAdjustmentBank()
    End Sub

    Public Sub DepositInTransit()
        Try
            Dim query As String
            query = " SELECT    Deposit_Date, TransID,  Deposit_Type, Total_Amount " & _
                    " FROM      tblBankDeposit " & _
                    " WHERE     Cleared = 0 AND Bank_ID = '" & bankID & "' AND Deposit_Date <='" & dtpDocDate.Value.Date & "' "
            SQL.ReadQuery(query)
            dgvDIT.Rows.Clear()
            Dim total As Decimal = 0
            If SQL.SQLDR.HasRows Then
                While SQL.SQLDR.Read
                    dgvDIT.Rows.Add(False, SQL.SQLDR("Deposit_Date"), SQL.SQLDR("TransID"), SQL.SQLDR("Deposit_Type").ToString, CDec(SQL.SQLDR("Total_Amount")).ToString("N2"))
                    total += SQL.SQLDR("Total_Amount")
                End While
                TxtTotalDIT.Text = total.ToString("N2")
                txtInTransit.Text = total.ToString("N2")
            Else
                dgvDIT.Rows.Clear()
                TxtTotalDIT.Text = 0
                txtInTransit.Text = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub LoadOutstandingCheck()
        Try
            Dim query As String
            query = " SELECT    RefDate, tblCV.TransID, tblCV.CV_No, RefNo, VCEName, RefAmount " & _
                    " FROM      tblCV_BankRef INNER JOIN tblCV " & _
                    " ON	    tbLCV.CV_No = tblCV.TransID " & _
                    " INNER JOIN tblVCE_Master " & _
                    " ON        tblCV.VCECode = tblVCE_Master.VCECode " & _
                    " WHERE     tblCV_BankRef.Status ='Released' AND BankID = '" & bankID & "' AND RefDate <='" & dtpDocDate.Value.Date & "' " & _
                    " AND       tblCV.Status ='Active' "
            SQL.ReadQuery(query)
            dgvOC.Rows.Clear()
            Dim total As Decimal = 0
            If SQL.SQLDR.HasRows Then
                While SQL.SQLDR.Read
                    dgvOC.Rows.Add(False, SQL.SQLDR("RefDate"), SQL.SQLDR("TransID"), SQL.SQLDR("CV_No"), SQL.SQLDR("RefNo"), SQL.SQLDR("VCEName").ToString, CDec(SQL.SQLDR("RefAmount")).ToString("N2"))
                    total += SQL.SQLDR("RefAmount")
                End While
                txtOutstandingCheck.Text = total.ToString("N2")
                TxtTotalOutstanding.Text = total.ToString("N2")
            Else
                dgvOC.Rows.Clear()
                txtOutstandingCheck.Text = 0
                TxtTotalOutstanding.Text = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Public Sub LoadBankDetail(bank As String)
        Dim query As String
        Dim bank1() As String = Strings.Split(bank, "-")
        bankID = bank1(0)
        query = " SELECT   Bank, Branch, AccountCode, AccountTitle,  Account_No" & _
                " FROM     tblMasterfile_Bank LEFT JOIN tblCOA_Master " & _
                " ON tblMasterfile_Bank.Account_Code = tblCOA_Master.AccountCode " & _
                " WHERE    Bank = '" & bank1(1) & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtBankAccountCode.Text = SQL.SQLDR("AccountCode")
            txtBankAccountTitle.Text = SQL.SQLDR("AccountTitle")
            txtBankAccountNo.Text = SQL.SQLDR("Account_No")
        End If
    End Sub

    Private Sub LoadBankRecon(ByVal ID As Integer)
        Dim query As String
        query = " SELECT Bank, BankReconDate, Trial_Balace_Amount, Cash_In_Bank, Deposit_In_Transit, OutstandingCheck " & _
                " FROM   ABank_Recon WHERE TransID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read() Then
            disableEvent = True
            txtBank.Text = SQL.SQLDR("Bank").ToString
            txtTrialBalanceAmount.Text = SQL.SQLDR("Trial_Balace_Amount")
            txtCashInBank.Text = SQL.SQLDR("Cash_In_Bank")
            If dtpDocDate.Value <> SQL.SQLDR("BankReconDate") Then
                dtpDocDate.Value = SQL.SQLDR("BankReconDate")
            End If
            disableEvent = False
        End If
        LoadBankDetail(txtBank.Text)
    End Sub

    Private Sub LoadBankReconJV()

        Dim debit, credit As Decimal
        debit = 0
        credit = 0
        Dim query As String
        query = " SELECT RefTransID, AccntCode, AccntTitle, Debit, Credit, Particulars, AppDate, Status " & _
                " FROM   view_GL " & _
                " WHERE  RefType ='JV' " & _
                " AND    MONTH(AppDate) = " & dtpDocDate.Value.Month & _
                " AND    YEAR(AppDate) = " & dtpDocDate.Value.Year & _
                " AND    RefTransID IN (SELECT DISTINCT RefTransID FROM view_GL WHERE RefNo LIKE 'BR%' AND AccntCode ='" & txtBankAccountCode.Text & "') "
        SQL.ReadQuery(query)
        adjustedCash = 0
        lvAccntingEntries.Items.Clear()
        While SQL.SQLDR.Read
            lvAccntingEntries.Items.Add(SQL.SQLDR("RefTransID").ToString)
            lvAccntingEntries.Items(lvAccntingEntries.Items.Count - 1).SubItems.Add(SQL.SQLDR("AccntCode").ToString)
            lvAccntingEntries.Items(lvAccntingEntries.Items.Count - 1).SubItems.Add(SQL.SQLDR("AccntTitle").ToString)
            lvAccntingEntries.Items(lvAccntingEntries.Items.Count - 1).SubItems.Add(SQL.SQLDR("Debit"))
            lvAccntingEntries.Items(lvAccntingEntries.Items.Count - 1).SubItems.Add(SQL.SQLDR("Credit"))
            lvAccntingEntries.Items(lvAccntingEntries.Items.Count - 1).SubItems.Add(SQL.SQLDR("Particulars").ToString)
            lvAccntingEntries.Items(lvAccntingEntries.Items.Count - 1).SubItems.Add(SQL.SQLDR("AppDate"))
            lvAccntingEntries.Items(lvAccntingEntries.Items.Count - 1).SubItems.Add(SQL.SQLDR("Status").ToString)
            If SQL.SQLDR("AccntCode").ToString = txtBankAccountCode.Text And SQL.SQLDR("Status").ToString = "Saved" Then
                adjustedCash += (SQL.SQLDR("Debit") - SQL.SQLDR("Credit"))
            End If
            debit += SQL.SQLDR("Debit")
            credit += SQL.SQLDR("Credit")
        End While
        If debit > 0 Or credit > 0 Then
            txtDebitA.Text = Format(debit, "###,###,###.##").ToString()
            txtCreditA.Text = Format(credit, "###,###,###.##").ToString()
            txtDiffA.Text = Format(Math.Abs(debit - credit), "###,###,###.##").ToString()
        End If
    End Sub

    Private Sub LoadAdjustedBookBalance()
        txtAdjustedBookBal.Text = Format(CDec(IIf(txtTrialBalanceAmount.Text = "", 0, txtTrialBalanceAmount.Text)) + CDec(IIf(Not IsNumeric(adjustedCash), 0, adjustedCash)), "###,###,###.##").ToString
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Dim CommandPopulate As New SqlCommand
        'Dim DR As SqlDataReader
        'Dim DebitAccountCode, DebitAccountTitle, CreditAccountCode, CreditAccountTitle As String
        'CreditAccountCode = ""
        'CreditAccountTitle = ""
        'DebitAccountTitle = ""
        'DebitAccountCode = ""
        'CommandPopulate = conn.CreateCommand
        'CommandPopulate.CommandText = " SELECT        Bank, BankReconType, Debit_Account_Code, Debit_Account_Title, Credit_Account_Code, Credit_Account_Title " & _
        '" FROM            dbo.ABankReconTypeMaintenance " & _
        '" WHERE        (Bank = N'" & txtBank.Text & "') AND (BankReconType = N'" & cbBankReconType.Text & "') "

        'DR = CommandPopulate.ExecuteReader
        ''TxtBankReconType.Items.Clear()
        'If DR.Read Then
        '    DebitAccountCode = DR("Debit_Account_Code")
        '    DebitAccountTitle = DR("Debit_Account_Title")
        '    CreditAccountCode = DR("Credit_Account_Code")
        '    CreditAccountTitle = DR("Credit_Account_Title")
        'End If
        'DR.Close()
        'conn.Close()

        'dgvProducts.Rows.Add(New String() {
        '                                                      DebitAccountCode.ToString, _
        '                                                       DebitAccountTitle.ToString, _
        '                                                    0, _
        '                                                     0, _
        '                                                    cbBankReconType.SelectedItem, _
        '                                                      "", _
        '                                                     "", _
        '                                                          "",
        '                                                           "",
        '                                                           "",
        '                                                          "",
        '                                                          "",
        '                                                          "",
        '                                                          "",
        '                                                          "", _
        '                                                        "",
        '                                                        "", _
        '                                                    ""})
        'dgvProducts.Rows.Add(New String() {
        '                                                  CreditAccountCode,
        '                                                    CreditAccountTitle, _
        '                                                  0, _
        '                                                 0, _
        '                                                      cbBankReconType.SelectedItem, _
        '                                                  "", _
        '                                                 "", _
        '                                                       "",
        '                                                        "",
        '                                                        "",
        '                                                       "",
        '                                                       "",
        '                                                       "",
        '                                                       "",
        '                                                       "", _
        '                                                     "",
        '                                                     "", _
        '                                                 ""})
    End Sub

    Private Sub dgvProducts_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProducts.CellContentClick

    End Sub

    Private Sub dgvProducts_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProducts.CellEndEdit
        Dim rowIndex As Integer = dgvProducts.CurrentCell.RowIndex
        Dim colIndex As Integer = dgvProducts.CurrentCell.ColumnIndex
        Dim Accountcode As String
        Try
            Select Case colIndex
                Case 3
                    Dim totoalprice = Double.Parse(dgvProducts.Item(3, e.RowIndex).Value)
                    dgvProducts.Item(3, e.RowIndex).Value = Format(totoalprice, "#,###,###,###.00").ToString()
                Case 2
                    Dim totoalprice = Double.Parse(dgvProducts.Item(2, e.RowIndex).Value)
                    dgvProducts.Item(2, e.RowIndex).Value = Format(totoalprice, "#,###,###,###.00").ToString()



                Case 0
                    dgvProducts.Item(1, e.RowIndex).Value = GetAccntTitle((dgvProducts.Item(0, e.RowIndex).Value))
                    dgvProducts.Item(4, e.RowIndex).Value = txtRemarks.Text




                Case 1
                    '  If dgvProducts.Item(1, e.RowIndex).Value <> "" And dgvProducts.Item(0, e.RowIndex).Value = "" Then
                    Accountcode = dgvProducts.Item(1, e.RowIndex).Value


                    Dim f As New frmCOA_Search
                    f.accttile = Accountcode


                    f.ShowDialog("AccntTitle", Accountcode)

                    dgvProducts.Rows.RemoveAt(rowIndex) 'delete active row
                    dgvProducts.Item(0, e.RowIndex).Value = f.accountcode
                    dgvProducts.Item(1, e.RowIndex).Value = f.accttile

                    'txtItemCode.Text = f.accountcode
                    'LoadDgvProducts()
                    f.Dispose()
                    dgvProducts.Item(4, e.RowIndex).Value = txtRemarks.Text
                    'ElseIf dgvProducts.Item(4, e.RowIndex).Value <> "" Then
                    '    Dim totoalprice = Double.Parse(dgvProducts.Item(5, e.RowIndex).Value) * Double.Parse(dgvProducts.Item(6, e.RowIndex).Value)

                    '    dgvProducts.Item(8, e.RowIndex).Value = Format(totoalprice, "#,###,###,###.00").ToString()
                    '    ' TotalAmt()
                    'End If
                Case 5
                    If dgvProducts.Item(5, e.RowIndex).Value <> "" Then

                        Dim f As New frmVCE_Search
                        f.txtFilter.Text = dgvProducts.Item(5, e.RowIndex).Value
                        f.ShowDialog()
                        dgvProducts.Item(5, e.RowIndex).Value = f.VCECode
                        dgvProducts.Item(6, e.RowIndex).Value = f.VCEName
                    End If
                Case 6
                    If dgvProducts.Item(6, e.RowIndex).Value <> "" Then
                        Dim f As New frmVCE_Search
                        f.txtFilter.Text = dgvProducts.Item(6, e.RowIndex).Value
                        f.ShowDialog()
                        dgvProducts.Item(5, e.RowIndex).Value = f.VCECode
                        dgvProducts.Item(6, e.RowIndex).Value = f.VCEName
                    End If

            End Select
            'rowIndex = dgvCVRR.CurrentCell.RowIndex 'current row for accnt code and accnt title
            'rowIndex1 = dgvCVRR.CurrentCell.RowIndex + 1 'to be able to insert to the next row for accnt code and accnt title

            'If frmRR = 1 Then ' put values in datagrid view for credit and the default account code and title
            '    If dgvCVRR.Item(0, 1).Value = "" And dgvCVRR.Item(1, 1).Value = "" Then
            '        '  DebitCreditDefault()
            '    End If
            'End If
            'If dgvCVRR.Item(0, rowIndex).Value = "" And dgvCVRR.Item(1, rowIndex).Value <> "" Then
            '    LoaddgvCVRRAC()
            'ElseIf dgvCVRR.Item(1, rowIndex).Value = "" And dgvCVRR.Item(0, rowIndex).Value <> "" Then
            '    LoaddgvCVRRAT()
            'End If

            TotalRR()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TotalRR()

        'debit compute & print in textbox
        Dim a As Double = 0

        For i As Integer = 0 To dgvProducts.Rows.Count - 1
            If Val(dgvProducts.Item(2, i).Value) <> 0 Then
                a = a + Double.Parse(dgvProducts.Item(2, i).Value).ToString("N2")
            End If
        Next
        txtTotalDebit.Text = a.ToString("N2")

        'credit compute & print in textbox
        Dim b As Double = 0

        For i As Integer = 0 To dgvProducts.Rows.Count - 1
            If Val(dgvProducts.Item(3, i).Value) <> 0 Then
                b = b + Double.Parse(dgvProducts.Item(3, i).Value).ToString("N2")
            End If
        Next
        txtTotalCredit.Text = b.ToString("N2")

        If txtTotalCredit.Text = txtTotalDebit.Text Then
            txtTotalAmount.Text = txtTotalCredit.Text
        End If
        txtDifference.Text = txtTotalDebit.Text - txtTotalCredit.Text
    End Sub

    Private Sub TabPage3_Click(sender As System.Object, e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim a As Double = 0

        For i As Integer = 0 To dgvOC.Rows.Count - 1

            dgvOC.Item(0, i).Value = 1

        Next
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim CV_ID As String
        Dim withcheck As Boolean
        Dim updateSQL As String
        Try
            withcheck = False
            For i As Integer = 0 To dgvOC.Rows.Count - 1
                Dim Post As Boolean
                Post = dgvOC.Item(0, i).Value
                If Post Then
                    withcheck = True
                End If
            Next
            If withcheck = False Then
                MsgBox("No selected transaction to be posted,  pls mark check for those items to be posted", vbCritical, "Transaction Message")
            Else
                Dim a As Double = 0

                For i As Integer = 0 To dgvOC.Rows.Count - 1
                    Dim Post As Boolean
                    Post = dgvOC.Item(0, i).Value
                    If Post Then

                        CV_ID = dgvOC.Item(chCV_ID.Index, i).Value
                        updateSQL = " UPDATE tblCV_BankRef " & _
                                   " SET    ClearDate = '" & dtpDocDate.Value.Date & "' , " & _
                                   "        Status ='Cleared' " & _
                                   " WHERE  CV_No = '" & CV_ID & "' "
                        SQL.ExecNonQuery(updateSQL)

                    End If
                Next
            End If
            RefreshData()
        Catch exs As SqlException
            MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnComputeAdjusted.Click
        UpdateAdjustmentBank()
    End Sub

    Private Sub UpdateAdjustmentBank()
        Dim tb, cib As Decimal
        If Decimal.TryParse(txtTrialBalanceAmount.Text, tb) AndAlso Decimal.TryParse(txtCashInBank.Text, cib) Then
            Dim intransit, cashinbank, outstanding, adjustedBalance As Double
            intransit = txtInTransit.Text.Replace(",", "")
            cashinbank = txtCashInBank.Text.Replace(",", "")
            outstanding = txtOutstandingCheck.Text.Replace(",", "")
            adjustedBalance = cashinbank + intransit - outstanding
            txtAdjustedBalance.Text = Format(adjustedBalance, "#,###,###,###.00").ToString()
            txtDiff.Text = Format(txtTrialBalanceAmount.Text.Replace(",", "") - txtCashInBank.Text.Replace(",", ""), "#,###,###,###.00").ToString()
        End If
    End Sub

    Private Sub btnSaveJV_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveJV.Click
        Dim TRANSNOCV As Integer
        Try
            If txtTotalDebit.Text = txtTotalCredit.Text Then
                Dim CVNum As String
                CVNum = Now.ToString("yyMM") & "-0" & TRANSNOCV
                If txtTotalDebit.Text <> txtTotalCredit.Text Then
                    MsgBox("Please Check the Debit and Credit Amount")
                Else
                    SaveJV()
                    SaveJVDetails(TRANSNOCV, 0)
                    SaveAJE(TRANSNOCV, "JV")
                    SaveJE1ManualEntry("", TRANSNOCV)
                    txtJVNO.Text = TRANSNOCV
                    MsgBox("Saved Successfully!", MsgBoxStyle.Information)
                    LoadBankReconJV()
                    LoadAdjustedBookBalance()
                    txtJVNO.Text = ""
                    dgvProducts.Rows.Clear()
                    txtTotalDebit.Text = ""
                    txtTotalCredit.Text = ""
                    txtDifference.Text = ""
                    txtTotalAmount.Text = ""
                    TabControl1.SelectedTab = TabPage4
                End If
            Else
                MsgBox("Debit Credit amount is not balance", vbCritical)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Sub SaveAJE(ByVal TRANSNOCV As Integer, BaseType As String) ' save details in AJE or header of Journal Entry


        'Dim Command As New SqlCommand
        'Dim SQL As String

        'SQL = "INSERT INTO AJE (Type, JETransId, BaseTransId,   VCECode,VCEName,TotalAmount) " & _
        '      "VALUES ( '" & BaseType & "'," & TRANSNOJE & "," & TRANSNOCV & ",'" & "JV" & "','" & "JV" & "'," & txtTotalAmount.Text.Trim.Replace(",", "") & ")"

        'Command.Connection = conn
        'Command.CommandText = SQL
        'Command.ExecuteNonQuery()

        'conn.Close()

    End Sub
    Private Sub SaveJV() ' save details in AJE or header of Journal Entry
        'If txtJVNO.Text = "" Then
        '    TRANSNOJE = ""
        'Else
        '    TRANSNOJE = txtJVNO.Text
        'End If
        '' to get the transaction no. of JE
        'Dim Command As New SqlCommand
        'Dim SQL As String
        'Dim JENum As String

        'JENum = Now.ToString("yyMM") & "-0" & Convert.ToString(TRANSNOJE)
        'If txtJVNO.Text = "" Then
        '    SQL = "INSERT INTO AJV (JVTransId, ApplyDate,Remarks) " & _
        '          " VALUES ( " & TRANSNOJE & ", '" & dtpDocDate.Value & "','" & txtRemarks.Text & "')"
        '    Command.Connection = conn
        'Else
        '    SQL = "UPDATE AJV SET  ApplyDate = '" & dtpDocDate.Value & "',Remarks = '" & txtRemarks.Text & "' " & _
        '          " WHERE JVTransId = " & TRANSNOJE
        '    Command.Connection = conn
        'End If


        'Command.CommandText = SQL
        'Command.ExecuteNonQuery()

        'conn.Close()
        ''  SaveJE1(TRANSNOJE, TRANSNOCV)
    End Sub
    Private Sub SaveJVDetails(ByVal TRANSNOJE As Integer, ByVal TRANSNOCV As Integer)

        'Dim Command As New SqlCommand
        'Dim SQL As String
        'SQL = "delete from JV1 where    JVTransId = " & TRANSNOCV
        'Command.Connection = conn
        'Command.CommandText = SQL
        'Command.ExecuteNonQuery()

        'Dim NoRows = dgvProducts.Rows.Count - 2
        'Dim JVTransId,
        'VendorCode,
        'VendorName,
        'AccntCode,
        'AccntTitle,
        'Particulars,
        'PeriodCovered As String
        'Dim DebitAmnt,
        'CreditAmnt As Double


        'For i As Integer = 0 To NoRows
        '    ' If CreditAmnt = dgvProducts.Item(3, i).Value > "" Then


        '    JVTransId = TRANSNOJE

        '    AccntCode = dgvProducts.Item(0, i).Value
        '    AccntTitle = dgvProducts.Item(1, i).Value
        '    DebitAmnt = dgvProducts.Item(2, i).Value 'Double.Parse(dgvCVRR.Item(2, i).Value)
        '    CreditAmnt = dgvProducts.Item(3, i).Value
        '    Particulars = "Bank Recon Adjustment"
        '    VendorCode = dgvProducts.Item(5, i).Value
        '    VendorName = dgvProducts.Item(6, i).Value
        '    PeriodCovered = dgvProducts.Item(7, i).Value
        '    If AccntTitle.ToString.Replace("'", "") > "" Then
        '        SQL = "INSERT INTO JV1  (  JVTransId, VCECode, VCEName, AccntCode, AccntTitle, Particulars, PeriodCovered, DebitAmnt, CreditAmnt) " & _
        '   "VALUES (  " & JVTransId & ", N'" & VendorCode & "', '" & VendorName & "', '" & AccntCode & "', '" & AccntTitle.ToString.Replace("'", "") & "', '" & Particulars & " ', '" & PeriodCovered & "', " & DebitAmnt & ", " & CreditAmnt & ")"
        '        Command.Connection = conn
        '        Command.CommandText = SQL
        '        Command.ExecuteNonQuery()
        '    End If
        '    '  End If

        'Next
        'conn.Close()
        ''  MsgBox("saved successfully")
    End Sub
    Private Sub SaveJE1ManualEntry(ByVal TRANSNOJE As Integer, ByVal TRANSNOCV As Integer)
        'Dim Command As New SqlCommand
        'Dim SQL As String
        'Dim Particulars As String
        'Try

        '    '     If MessageBox.Show("Are you sure you want to Post this document?" & vbNewLine & vbNewLine & " Edit is not allwed once Posted...", "Message Alert", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

        '    Dim GLACCOUNTTITILE, GLAccount As String
        '    Dim DebitAmount, CreditAmount As Double

        '    SQL = "delete from JE1 where    BaseRefTransId  = " & TRANSNOCV & " AND (Book = N'Journal Voucher') AND (JETransId = " & TRANSNOJE & ")"
        '    Command.Connection = conn
        '    Command.CommandText = SQL
        '    Command.ExecuteNonQuery()

        '    For i As Integer = 0 To dgvProducts.RowCount - 2

        '        GLAccount = dgvProducts.Item(0, i).Value
        '        GLACCOUNTTITILE = dgvProducts.Item(1, i).Value
        '        Particulars = dgvProducts.Item(4, i).Value
        '        If IsNumeric(dgvProducts.Item(2, i).Value) Then
        '            DebitAmount = dgvProducts.Item(2, i).Value.Replace(",", "")
        '        Else
        '            DebitAmount = 0
        '        End If
        '        If IsNumeric(dgvProducts.Item(3, i).Value) Then
        '            CreditAmount = dgvProducts.Item(3, i).Value.Replace(",", "")
        '        Else
        '            CreditAmount = 0
        '        End If
        '        SQL = "INSERT INTO JE1 (LineNumber,  Book,  JETransId,               BaseRefType,                BaseRefTransId, AccntCode,            AccntTitle,                        VCECode,                  VCEName,   DebitAmnt, CreditAmnt,Particulars,ApplicationDate )" & _
        '              " VALUES (" & i & ",'Journal Voucher'," & TRANSNOJE & ", 'JV', '" & TRANSNOCV & "', '" & GLAccount & "', '" & GLACCOUNTTITILE.ToString.Replace("'", "") & "','" & dgvProducts.Item(5, i).Value & "','" & dgvProducts.Item(6, i).Value & "', " & DebitAmount & "," & CreditAmount & ",'" & Particulars.ToString.Replace("'", "") & "','" & dtpDocDate.Text & "'  )"
        '        Command.Connection = conn
        '        Command.CommandText = SQL
        '        Command.ExecuteNonQuery()
        '        conn.Close()
        '    Next
        'Catch exs As SqlException
        '    MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        '    CN.Close()
        '    CN2.Close()
        '    CN3.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        '    CN.Close()
        '    CN2.Close()
        '    CN3.Close()
        'End Try
    End Sub

    Private Sub dgvDIT_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try

        Catch exs As SqlException
            'MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            'CN.Close()
            'CN2.Close()
            'CN3.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            'CN.Close()
            'CN2.Close()
            'CN3.Close()
        End Try
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Try
            Dim a As Double = 0

            For i As Integer = 0 To dgvDIT.Rows.Count - 1

                dgvDIT.Item(0, i).Value = CheckBox3.Checked

            Next
            computeTotal()
        Catch exs As SqlException
            '  MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    Private Sub dgridOC_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOC.CellContentClick
        Try
            If e.ColumnIndex = chSearchCV.Index Then
                Dim DocID As String = dgvOC.Item(chCV_ID.Index, e.RowIndex).Value
                Dim f As New frmCV
                f.ShowDialog(DocID)
                f.Dispose()
            Else
                Dim rowIndex As Integer = dgvOC.CurrentCell.RowIndex
                Dim colIndex As Integer = dgvOC.CurrentCell.ColumnIndex
                If dgvOC.Item(0, rowIndex).Value Then
                    dgvOC.Item(0, rowIndex).Value = 0
                Else
                    dgvOC.Item(0, rowIndex).Value = 1
                End If
            End If

        Catch exs As SqlException
            '  MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    Private Sub dgvDIT_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDIT.CellContentClick
        Try
            If e.ColumnIndex = chSearch.Index Then
                Dim DocID As Integer = dgvDIT.Item(chDepID.Index, e.RowIndex).Value
                Dim f As New frmdeposit  'LoadingScreen 'ParentMenu '
                f.ShowDialog(DocID)
                f.Dispose()
            Else
                Dim rowIndex As Integer = dgvDIT.CurrentCell.RowIndex
                Dim colIndex As Integer = dgvDIT.CurrentCell.ColumnIndex
                If dgvDIT.Item(0, rowIndex).Value Then
                    dgvDIT.Item(0, rowIndex).Value = False
                Else
                    dgvDIT.Item(0, rowIndex).Value = True
                End If
                computeTotal()
            End If

        Catch exs As SqlException
            '  MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    Private Sub computeTotal()
        Dim subtotal As Decimal
        Try
            subtotal = 0
            For i As Integer = 0 To dgvDIT.Rows.Count - 1
                Dim checked As Boolean
                checked = dgvDIT.Item(0, i).Value
                If checked AndAlso IsNumeric(dgvDIT.Item(DataGridViewTextBoxColumn14.Index, i).Value) Then
                    subtotal = CDec(dgvDIT.Item(DataGridViewTextBoxColumn14.Index, i).Value) + subtotal
                End If
            Next
            TxtSubTotal.Text = Format(subtotal, "#,###,###,###.00").ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnSaveBankRecon_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles btnSaveBankRecon.Click
        'Try

        '    Dim ApplicationDAte As Date
        '    Dim JETransId As Integer
        '    Dim DocNum As String
        '    Dim BPCode As String
        '    Dim BPName As String
        '    Dim Amount As Double
        '    Dim RefType As String
        '    Dim Documentype As String

        '    Dim Command As New SqlCommand
        '    Dim query As String
        '    Dim TransID As Integer
        '    query = " INSERT INTO [dbo].[ABank_Recon] " & _
        '        "            ([Bank] " & _
        '        "            ,[Cash_In_Bank] " & _
        '        "            ,[Deposit_In_Transit] " & _
        '        "            ,[OutstandingCheck] " & _
        '        "            ,[TransID] " & _
        '        "            ,[AccntCode] " & _
        '        "            ,[AccntTitle] " & _
        '        "            ,[BankReconMonth] " & _
        '        "            ,[BankReconYear] " & _
        '        "            ,[BankReconDate] " & _
        '        "            ,[Trial_Balace_Amount], [Remarks]) " & _
        '        "      VALUES " & _
        '        "            ('" & txtBank.Text & "'," & _
        '        "            '" & txtCashInBank.Text.Replace(",", "") & "', " & _
        '        "            '" & txtInTransit.Text.Replace(",", "") & "', " & _
        '        "            " & txtOutstandingCheck.Text.Replace(",", "") & ", " & _
        '        "            " & TransID & ", " & _
        '        "            '" & txtBankAccountCode.Text & "', " & _
        '        "            '" & txtBankAccountTitle.Text.Replace("'", "") & "'," & _
        '        "            " & dtpDocDate.Value.Month & "," & _
        '        "            " & dtpDocDate.Value.Year & "," & _
        '        "            '" & dtpDocDate.Text & "'," & _
        '        "            " & txtTrialBalanceAmount.Text.Replace(",", "") & ", " & _
        '        "            '" & txtRemarks.Text & "') "
        '    Command.Connection = conn
        '    Command.CommandText = query
        '    Command.ExecuteNonQuery()
        '    conn.Close()
        '    Dim updateSQL As String
        '    updateSQL = " UPDATE  JV1 " & _
        '                " SET     Particulars ='Bank Recon Adjustment:" & TransID & "' " & _
        '                " WHERE   Particulars ='Bank Recon Adjustment' " & _
        '                " AND     JVTransID IN (SELECT JVTransID FROM AJV WHERE ApplyDate ='" & dtpDocDate.Value.Date & "') "
        '    SQL.ExecNonQuery(updateSQL)
        '    For i As Integer = 0 To dgvDIT.RowCount - 1
        '        ApplicationDAte = dgvDIT.Item(1, i).Value()
        '        JETransId = dgvDIT.Item(2, i).Value()
        '        DocNum = dgvDIT.Item(3, i).Value()
        '        BPCode = dgvDIT.Item(4, i).Value()
        '        BPName = dgvDIT.Item(5, i).Value()
        '        Amount = dgvDIT.Item(6, i).Value()

        '        Documentype = "Deposit In Transit"
        '        query = " INSERT INTO [dbo].[Bank_Recon_Details] " & _
        '            "            ([ApplicationDate] " & _
        '            "            ,[TransId] " & _
        '            "            ,[JETransId] " & _
        '            "            ,[DocNum] " & _
        '            "            ,[VCECode] " & _
        '            "            ,[VCEName] " & _
        '            "            ,[Currency] " & _
        '            "            ,[Amount] " & _
        '             "            ,[Bank] " & _
        '            "            ,[AccntCode] " & _
        '            "            ,[AccntTitle] " & _
        '            "            ,[BankReconMonth] " & _
        '            "            ,[BankReconYear] " & _
        '            "            ,[BankReconDate] " & _
        '            "            ,[DocumentType]) " & _
        '            "      VALUES " & _
        '            "            ('" & ApplicationDAte & "'," & _
        '            "            " & TransID & "," & _
        '            "            " & JETransId & "," & _
        '            "            '" & DocNum & "'," & _
        '            "            '" & BPCode & "'," & _
        '            "            '" & BPName & "'," & _
        '            "            'PHP'," & _
        '            "            " & Amount & "," & _
        '            "            '" & txtBank.Text & "'," & _
        '            "            '" & txtBankAccountCode.Text & "'," & _
        '            "            '" & txtBankAccountTitle.Text & "'," & _
        '            "            " & dtpDocDate.Value.Month & "," & _
        '            "            " & dtpDocDate.Value.Year & "," & _
        '            "            '" & dtpDocDate.Text & "'," & _
        '            "            '" & Documentype & "')"
        '        Command.Connection = conn
        '        Command.CommandText = query
        '        Command.ExecuteNonQuery()
        '        conn.Close()

        '    Next

        '    Documentype = "Outstanding Check"
        '    For i As Integer = 0 To dgvOC.RowCount - 1
        '        ApplicationDAte = dgvOC.Item(1, i).Value()
        '        JETransId = dgvOC.Item(2, i).Value()
        '        DocNum = dgvOC.Item(3, i).Value()
        '        RefType = dgvOC.Item(4, i).Value()
        '        BPCode = dgvOC.Item(5, i).Value()
        '        BPName = dgvOC.Item(6, i).Value()
        '        Amount = dgvOC.Item(7, i).Value()
        '        query = " INSERT INTO [dbo].[Bank_Recon_Details] " & _
        '           "            ([ApplicationDate] " & _
        '            "            ,[JETransId] " & _
        '            "            ,[TransId] " & _
        '            "            ,[DocNum] " & _
        '            "            ,[RefType] " & _
        '            "            ,[VCECode] " & _
        '            "            ,[VCEName] " & _
        '            "            ,[Currency] " & _
        '            "            ,[Amount] " & _
        '            "            ,[Bank] " & _
        '            "            ,[AccntCode] " & _
        '            "            ,[AccntTitle] " & _
        '            "            ,[BankReconMonth] " & _
        '            "            ,[BankReconYear] " & _
        '            "            ,[BankReconDate] " & _
        '            "            ,[DocumentType]) " & _
        '            "      VALUES " & _
        '            "            ('" & ApplicationDAte & "'," & _
        '            "            " & JETransId & "," & _
        '            "            '" & TransID & "'," & _
        '            "            '" & DocNum & "'," & _
        '            "            '" & RefType & "'," & _
        '            "            '" & BPCode & "'," & _
        '            "            '" & BPName & "'," & _
        '            "            'PHP'," & _
        '            "            " & Amount & "," & _
        '            "            '" & txtBank.Text & "'," & _
        '            "            '" & txtBankAccountCode.Text & "'," & _
        '            "            '" & txtBankAccountTitle.Text & "'," & _
        '            "            " & dtpDocDate.Value.Month & "," & _
        '            "            " & dtpDocDate.Value.Year & "," & _
        '            "            '" & dtpDocDate.Text & "'," & _
        '            "            '" & Documentype & "')"
        '        Command.Connection = conn
        '        Command.CommandText = query
        '        Command.ExecuteNonQuery()
        '        conn.Close()
        '    Next

        '    MsgBox("Bank Recon Saved Successfully!", MsgBoxStyle.Information)
        '    If SearchBankRecon() = True Then
        '        LoadBankRecon(txtBRID.Text)
        '    End If
        'Catch exs As SqlException
        '    MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        'End Try
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox4.CheckedChanged
       Dim updateSQL As String
        Dim withcheck As Boolean
        Try
            withcheck = False
            For i As Integer = 0 To dgvDIT.Rows.Count - 1
                Dim Post As Boolean
                Post = dgvDIT.Item(0, i).Value
                If Post Then
                    withcheck = True
                End If
            Next
            If withcheck = False Then
                MsgBox("No selected transaction to be posted,  pls mark check for those items to be posted", vbCritical, "Transaction Message")
            Else
                For i As Integer = 0 To dgvDIT.Rows.Count - 1
                    Dim Post As Boolean
                    Post = dgvDIT.Item(0, i).Value
                    If Post Then
                        updateSQL = " UPDATE tblBankDeposit " & _
                                    " SET    ClearDate = '" & dtpDocDate.Value.Date & "' , " & _
                                    "        Cleared = 1 " & _
                                    " WHERE  TransId = '" & dgvDIT.Item(chDepID.Index, i).Value & "'  "
                        SQL.ExecNonQuery(updateSQL)
                    End If
                Next
            End If
            RefreshData()
        Catch exs As SqlException
            MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    Private Sub txtAdjustedBookBal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAdjustedBookBal.TextChanged, txtAdjustedBalance.TextChanged
        If IsNumeric(txtAdjustedBalance.Text) And IsNumeric(txtAdjustedBookBal.Text).ToString Then
            If txtAdjustedBalance.Text = txtAdjustedBookBal.Text Then
                txtAdjustedDiff.Text = "0.00"
            Else
                txtAdjustedDiff.Text = Format(Math.Abs(CDec(txtAdjustedBalance.Text) - CDec(txtAdjustedBookBal.Text)), "###,###,###.##").ToString
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            If IsNumeric(txtBRID.Text) Then
                LoadBankRecon(txtBRID.Text)
            Else
                Trialbal(txtBank.Text)
            End If
            DepositInTransit()
            LoadOutstandingCheck()
            LoadBankReconJV()
            LoadAdjustedBookBalance()
            UpdateAdjustmentBank()
            SearchBankRecon()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function SearchBankRecon() As Boolean
        If txtBank.Text <> "" AndAlso txtBankAccountCode.Text <> "" Then
            Dim query As String
            query = " SELECT MAX(TransID) AS TransID FROM ABank_Recon " & _
                    " WHERE  BankReconDate = '" & dtpDocDate.Value.Date & "' AND AccntCode = '" & txtBankAccountCode.Text & "'"
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("TransID")) Then
                txtBRID.Text = SQL.SQLDR("TransID")
                btnBankReconReport.Enabled = True
                Return True
            Else
                txtBRID.Text = ""
                btnBankReconReport.Enabled = False
                txtCashInBank.Text = ""
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub btnBankReconReport_Click(sender As System.Object, e As System.EventArgs) Handles btnBankReconReport.Click
        Dim f As New frmReport_Display
        f.ShowDialog("BR", txtBRID.Text)
        f.Dispose()
    End Sub


    Private Sub dtpDocDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDocDate.ValueChanged
        Try
            If disableEvent = False Then
                RefreshData()
            End If
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As System.Object, e As System.EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub
End Class
