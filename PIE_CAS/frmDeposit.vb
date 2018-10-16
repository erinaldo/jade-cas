Public Class frmdeposit
    Dim PDir As String
    Public cnno As String
    Dim dsL As New DataSet
    Public mdulefnc As Integer
    Public row As Integer
    Public DepoositDate As String
    Public TransId As Integer
    Public bank
    Public bankID As String
    Dim SQL As New SQLControl
    Dim disableEvent As Boolean = False
    Dim activityResult As Boolean = True
    Dim moduleID As Integer = 1
    Public Overloads Function ShowDialog(ByVal mdulefunc As String) As Boolean
        txtDepositNo.Text = mdulefunc
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmdeposit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If txtDepositNo.Text = "" Then
            cbDepositType.SelectedItem = "Cash"
            PopulateDenomination()
            LoadBankList()
            nupDepositYear.Value = Date.Today.Year
            cbDepositMonth.SelectedIndex = Date.Today.Month - 1
            PendingList()
        End If
    End Sub

    Private Sub LoadListDeposit()
        If cbDepositMonth.SelectedIndex <> -1 Then
            Dim total As Decimal = 0
            Dim query As String
            query = " SELECT  DISTINCT  TransId, Total_Amount, Bank + ' ' + Branch + ' '+ Account_No AS BankName, Deposit_Date " & _
                    " FROM    tblBankDeposit INNER JOIN tblMasterfile_Bank " & _
                    " ON      tblBankDeposit.Bank_ID = tblMasterfile_Bank.Bank_ID " & _
                    " WHERE   MONTH(Deposit_Date) = '" & cbDepositMonth.SelectedIndex + 1 & "' AND YEAR(Deposit_Date) = '" & nupDepositYear.Value & "' " & _
                    " ORDER BY TransId DESC "
            SQL.ReadQuery(query)
            dgvTransid.Rows.Clear()
            While SQL.SQLDR.Read
                dgvTransid.Rows.Add(New String() {SQL.SQLDR("TransId").ToString, SQL.SQLDR("Total_Amount"), SQL.SQLDR("Deposit_Date").Date, SQL.SQLDR("BankName").ToString})
                total += SQL.SQLDR("Total_Amount")
            End While
            txtTotalDeposit.Text = total.ToString("N2")
        End If
    End Sub

    Public Sub LoadBankList()
        Dim query As String
        query = " SELECT    CAST(Bank_ID AS nvarchar) + '-' + Bank + ' ' + Branch + ' ' + Account_No AS Bank" & _
                " FROM      tblMasterfile_Bank WHERE Status ='Active'  " & _
                " ORDER BY  Branch"
        SQL.ReadQuery(query)
        cbBank.Items.Clear()
        While SQL.SQLDR.Read
            cbBank.Items.Add(SQL.SQLDR("Bank").ToString)
        End While
    End Sub

    Private Sub PendingList()
        Dim query As String
        Try
            
                If cbDepositType.Text = "Cash" Then
                query = " SELECT CAST(0 AS BIT) AS [Dep], Collection_ID AS [Collection ID], " & _
                        "        Base_Type + ':' + RIGHT('000000' + CAST(Base_ID AS nvarchar),6) AS [Ref No], " & _
                        "        Base_Date AS [CV Date], VCEName, Amount, Remarks " & _
                        " FROM   tblCollection LEFT JOIn tblVCE_Master " & _
                        " ON	 tblCollection.VCECode = tblVCE_Master.VCECode " & _
                        " WHERE  Deposit_ID = 0 AND Payment_Type ='Cash' " & _
                        " AND    Base_Date BETWEEN '" & dtpFrom.Value.Date & "' AND '" & dtpTo.Value.Date & "' "
                SQL.GetQuery(query)
                dgvPendingList.DataSource = SQL.SQLDS.Tables(0)
                dgvPendingList.Refresh()
                dgvPendingList.Columns(0).Width = 40
                dgvPendingList.Columns(1).Width = 70
                dgvPendingList.Columns(2).Width = 70
                dgvPendingList.Columns(3).Width = 80
                dgvPendingList.Columns(4).Width = 180
                dgvPendingList.Columns(5).Width = 80
                dgvPendingList.Columns(6).Width = 300
            Else
                query = " SELECT  CAST(0 AS BIT) AS [Dep], Collection_ID AS [Collection ID], " & _
                        "        Base_Type + ':' + RIGHT('000000' + CAST(Base_ID AS nvarchar),6) AS [Ref No],  " & _
                        "        Base_Date AS [CV Date], VCEName, Amount, Check_Ref AS [Check], Bank_Ref AS [Bank],  " & _
                        "        CASE WHEN Bank_Ref <> '' THEN Check_Date ELSE NULL END AS Check_Date, Remarks " & _
                        " FROM   tblCollection LEFT JOIn tblVCE_Master " & _
                        " ON	 tblCollection.VCECode = tblVCE_Master.VCECode " & _
                        " WHERE  Deposit_ID = 0 AND Payment_Type ='Check' " & _
                        " AND    Base_Date BETWEEN '" & dtpFrom.Value.Date & "' AND '" & dtpTo.Value.Date & "' "
                SQL.GetQuery(query)
                dgvPendingList.DataSource = SQL.SQLDS.Tables(0)
                dgvPendingList.Refresh()
                dgvPendingList.Columns(0).Width = 40
                dgvPendingList.Columns(1).Width = 70
                dgvPendingList.Columns(2).Width = 70
                dgvPendingList.Columns(3).Width = 80
                dgvPendingList.Columns(4).Width = 180
                dgvPendingList.Columns(5).Width = 80
                dgvPendingList.Columns(6).Width = 80
                dgvPendingList.Columns(7).Width = 80
                dgvPendingList.Columns(8).Width = 80
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDepSlip.Click
        Dim f As New frmReport_Display
        f.ShowDialog("DS", txtDepositNo.Text)
        f.Dispose()
    End Sub

    Private Function ComputeTotal() As Decimal
        Dim amount As Decimal = 0
        For Each row As DataGridViewRow In dgvPendingList.Rows
            If row.Cells(0).Value = True Then
                amount += row.Cells(5).Value
            End If
        Next
        Return amount
    End Function



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "New Deposit" Then
                EnableText(True)
                btnSave.Text = "Save Deposit"
                cbDepositType.SelectedItem = "Cash"
                PopulateDenomination()
                LoadBankList()
                nupDepositYear.Value = Date.Today.Year
                cbDepositMonth.SelectedIndex = Date.Today.Month - 1
                txtDepositNo.Text = ""
                PendingList()
                cbBank.Text = ""
            Else
                If cbBank.SelectedIndex <> -1 Then
                    If MsgBox("Saving Deposit records" & vbNewLine & "Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim depositID As Integer = getmaxDeposit()
                        bank = Split(cbBank.Text, "-")
                        bankID = bank(0)
                        UpdateCollection(depositID, bankID)
                        DepositEntry(depositID, bankID)
                        LoadListDeposit()
                        PendingList()
                    End If
                Else
                    MsgBox("Please select bank!", MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UpdateCollection(ByVal DepositID As Integer, bankID As Integer)
        Dim updateSQL, insertSQL As String
        For Each row As DataGridViewRow In dgvPendingList.Rows
            If row.Cells(0).Value = True Then
                updateSQL = " UPDATE  tblCollection " & _
                        " SET     Deposit_ID = @Deposit_ID " & _
                        " WHERE   Collection_ID= @Collection_ID "
                SQL.FlushParams()
                SQL.AddParam("@Deposit_ID", DepositID)
                SQL.AddParam("@Collection_ID", row.Cells(1).Value)
                SQL.ExecNonQuery(updateSQL)
            End If
        Next
        insertSQL = " INSERT INTO  " & _
                    " tblBankDeposit(TransID, Deposit_Date, Deposit_Type, Bank_ID, Total_Amount) " & _
                    " VALUES(@TransID, @Deposit_Date, @Deposit_Type, @Bank_ID, @Total_Amount) "
        SQL.FlushParams()
        SQL.AddParam("TransID", DepositID)
        SQL.AddParam("@Deposit_Date", dtpDepositDate.Value.Date)
        SQL.AddParam("@Deposit_Type", cbDepositType.SelectedItem)
        SQL.AddParam("@Bank_ID", bankID)
        SQL.AddParam("@Total_Amount", CDec(txtTotalAmount.Text))
        SQL.ExecNonQuery(insertSQL)
        SaveDenomination(DepositID)
    End Sub

    Private Sub DepositEntry(ByVal RefID As Integer, BankID As String)
        Dim JENo As Integer
        SaveJE_Header(RefID)
        JENo = LoadJE("DS", RefID)
        SaveJE_Details(JENo, BankID)
    End Sub

    Private Sub SaveJE_Header(ByVal Ref_ID As String)
        Try
            activityResult = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblJE_Header (AppDate, RefType, RefTransID, Book, TotalDBCR, Remarks) " & _
                        " VALUES(@AppDate, @RefType, @RefTransID, @Book, @TotalDBCR, @Remarks)"
            SQL.FlushParams()
            SQL.AddParam("@AppDate", dtpDepositDate.Value.Date)
            SQL.AddParam("@RefType", "DS")
            SQL.AddParam("@RefTransID", Ref_ID)
            SQL.AddParam("@Book", "Cash Receipts")
            SQL.AddParam("@TotalDBCR", CDec(txtTotalAmount.Text))
            SQL.AddParam("@Remarks", "")
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            MsgBox(ex.Message)
            activityResult = False
        End Try
    End Sub

    Private Sub SaveJE_Details(ByVal JENo As String, BankID As String)
        Try
            activityResult = True
            Dim line As Integer = 1
            Dim DBAccount, CRAccount As String
            DBAccount = LoadBankAccount(BankID)
            CRAccount = LoadDefaultAccount(cbDepositType.SelectedItem)
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber) " & _
                        " VALUES(@JE_No, @AccntCode, @VCECode, @Debit, @Credit, @Particulars, @RefNo, @LineNumber)"
            ' DEBIT
            SQL.FlushParams()
            SQL.AddParam("@JE_No", JENo)
            SQL.AddParam("@AccntCode", DBAccount)
            SQL.AddParam("@VCECode", "")
            SQL.AddParam("@Debit", CDec(txtTotalAmount.Text))
            SQL.AddParam("@Credit", 0)
            SQL.AddParam("@Particulars", "")
            SQL.AddParam("@RefNo", "")
            SQL.AddParam("@LineNumber", 1)
            SQL.ExecNonQuery(insertSQL)
            ' CREDIT
            SQL.FlushParams()
            SQL.AddParam("@JE_No", JENo)
            SQL.AddParam("@AccntCode", CRAccount)
            SQL.AddParam("@VCECode", "")
            SQL.AddParam("@Debit", 0)
            SQL.AddParam("@Credit", CDec(txtTotalAmount.Text))
            SQL.AddParam("@Particulars", "")
            SQL.AddParam("@RefNo", "")
            SQL.AddParam("@LineNumber", 1)
            SQL.ExecNonQuery(insertSQL)

        Catch ex As Exception
            MsgBox(ex.Message)
            activityResult = False
        Finally
            '     RecordActivity(UserID, moduleID, "INSERT", "DS" & JENo, activityResult)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClose.LinkClicked
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        SelectAll(True)
    End Sub

    Private Sub SelectAll(ByVal Value As Boolean)
        For Each row As DataGridViewRow In dgvPendingList.Rows
            row.Cells(0).Value = Value
        Next
    End Sub

    Private Sub btnUnselect_Click(sender As System.Object, e As System.EventArgs) Handles btnUnselect.Click
        SelectAll(False)
    End Sub

    Private Function getmaxDeposit() As Integer
        Dim query As String
        query = " SELECT MAX(TransId) AS MaxID FROM tblBankDeposit"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("MaxID")) Then
            Return SQL.SQLDR("MaxID") + 1
        Else
            Return 1
        End If
    End Function

    Private Sub PopulateDenomination()
        Dim query As String
        query = " SELECT    TOP (100) PERCENT Denomination, Description " & _
                " FROM      tblDenomination " & _
                " ORDER BY  Denomination DESC "
        SQL.ReadQuery(query)
        dgvDenomination.Rows.Clear()
        While SQL.SQLDR.Read
            dgvDenomination.Rows.Add(New String() {SQL.SQLDR("Denomination").ToString, "0", "0"})
        End While
    End Sub

    Private Sub dgvDenomination_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDenomination.CellEndEdit
        dgvDenomination.Item(2, e.RowIndex).Value = Double.Parse(dgvDenomination.Item(1, e.RowIndex).Value) * Double.Parse(dgvDenomination.Item(0, e.RowIndex).Value)
        TotalAmt()
    End Sub

    Private Sub TotalAmt()
        Dim a As Double = 0
        For i As Integer = 0 To dgvDenomination.Rows.Count - 1
            a = a + Double.Parse(dgvDenomination.Item(2, i).Value)
        Next
        txtGrandTotal.Text = a.ToString("N2")
    End Sub

    Private Sub SaveDenomination(ByVal TransId As Integer)
        Dim insertSQL As String
        Dim Denomination, PCS, Amount As String
        For i As Integer = 0 To dgvDenomination.Rows.Count - 1
            Denomination = dgvDenomination.Item(0, i).Value
            PCS = dgvDenomination.Item(1, i).Value
            Amount = dgvDenomination.Item(2, i).Value
            If dgvDenomination.Item(1, i).Value > 0 Then
                insertSQL = " INSERT INTO  " & _
                            " tblBankDeposit_Denomination(Deposit_ID, Denomination, Quantity, Amount) " & _
                            " VALUES(@Deposit_ID, @Denomination, @Quantity, @Amount) "
                SQL.FlushParams()
                SQL.AddParam("@Deposit_ID", TransId)
                SQL.AddParam("@Denomination", Denomination)
                SQL.AddParam("@Quantity", PCS)
                SQL.AddParam("@Amount", Amount)
                SQL.ExecNonQuery(insertSQL)
            End If
        Next
    End Sub

    Private Sub CmbCollectionType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbDepositType.SelectedIndexChanged
        If disableEvent = False Then
            PendingList()
            txtTotalAmount.Text = "0.00"
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged, dtpTo.ValueChanged
        PendingList()
    End Sub

    Private Sub cbDepositMonth_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbDepositMonth.SelectedIndexChanged, nupDepositYear.ValueChanged
        LoadListDeposit()
    End Sub

    Private Sub txtDepositNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDepositNo.TextChanged
        If txtDepositNo.Text <> "" AndAlso IsNumeric(txtDepositNo.Text) Then
            disableEvent = True
            LoadDepositHeader(txtDepositNo.Text)
            LoadDepositDetails(txtDepositNo.Text)
            LoadDenomination(txtDepositNo.Text)
            btnSave.Text = "New Deposit"
            EnableText(False)
            disableEvent = False
        End If
    End Sub

    Private Sub LoadDepositHeader(ByVal DepositID As Integer)
        Dim query As String
        query = " SELECT TransID, Deposit_Date, Deposit_Type, CAST(tblBankDeposit.Bank_ID AS nvarchar) + '-' + Bank + ' ' + Branch + ' ' + Account_No AS Bank, Total_Amount " & _
                " FROM   tblBankDeposit INNER JOIN tblMasterfile_Bank " & _
                " ON     tblBankDeposit.Bank_ID = tblMasterfile_Bank.Bank_ID " & _
                " WHERE  TransID ='" & DepositID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtDepositNo.Text = SQL.SQLDR("TransID").ToString
            dtpDepositDate.Value = SQL.SQLDR("Deposit_Date").ToString
            cbDepositType.SelectedItem = SQL.SQLDR("Deposit_Type").ToString
            cbBank.SelectedItem = SQL.SQLDR("Bank").ToString
            txtTotalAmount.Text = SQL.SQLDR("Total_Amount").ToString
        End If
    End Sub

    Private Sub EnableText(ByVal Value As Boolean)
        btnSelect.Enabled = Value
        btnUnselect.Enabled = Value
        dtpFrom.Enabled = Value
        dtpTo.Enabled = Value
        dtpDepositDate.Enabled = Value
        cbBank.Enabled = Value
        cbDepositType.Enabled = Value
    End Sub

    Private Sub LoadDepositDetails(ByVal DepositID As Integer)
        Dim query As String

        query = " SELECT Collection_ID AS [Collection ID], " & _
                "        Base_Type + ':' + RIGHT('000000' + CAST(Base_ID AS nvarchar),6) AS [Ref No],  " & _
                "        Base_Date AS [CV Date], VCEName, Amount, Check_Ref AS [Check], Bank_Ref AS [Bank],  " & _
                "        CASE WHEN Bank_Ref <> '' THEN Check_Date ELSE NULL END AS [Check Date], Remarks " & _
                " FROM   tblCollection LEFT JOIn tblVCE_Master " & _
                " ON	 tblCollection.VCECode = tblVCE_Master.VCECode " & _
                " WHERE  Deposit_ID = " & DepositID & " "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            dgvPendingList.DataSource = SQL.SQLDS.Tables(0)
            dgvPendingList.Columns(0).Width = 70
            dgvPendingList.Columns(1).Width = 70
            dgvPendingList.Columns(2).Width = 80
            dgvPendingList.Columns(3).Width = 180
            dgvPendingList.Columns(4).Width = 80
            dgvPendingList.Columns(5).Width = 80
            dgvPendingList.Columns(6).Width = 180
            btnSave.Text = "New Deposit"
        Else
            dgvPendingList.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadDenomination(ByVal DepositID As Integer)
        Dim query As String
        query = " SELECT Denomination, Quantity, Amount FROM tblBankDeposit_Denomination WHERE Deposit_ID = " & DepositID & " "
        SQL.ReadQuery(query)
        dgvDenomination.Rows.Clear()
        While SQL.SQLDR.Read
            dgvDenomination.Rows.Add(New String() {SQL.SQLDR("Denomination").ToString, SQL.SQLDR("Quantity"), SQL.SQLDR("Amount")})
        End While
        TotalAmt()
    End Sub

    Private Sub dgvTransid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransid.CellClick
        If dgvTransid.SelectedRows.Count > 0 Then
            txtDepositNo.Text = dgvTransid.SelectedRows(0).Cells(0).Value
        End If
    End Sub

    Private Sub dgvTransid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransid.CellContentClick

    End Sub

    Private Sub dgvPendingList_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingList.CellClick
        If dgvPendingList.SelectedRows.Count = 1 Then
            dgvPendingList.SelectedRows(0).Cells(0).Value = Not dgvPendingList.SelectedRows(0).Cells(0).Value
            If btnSave.Text <> "New Deposit" Then
                txtTotalAmount.Text = (ComputeTotal()).ToString("N2")
            End If

        End If
    End Sub
End Class