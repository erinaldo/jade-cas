Public Class frmRF
    Dim TransID, RefID, JETransiD As String
    Dim RFNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "RFP"
    Dim ColumnPK As String = "RFP_No"
    Dim DBTable As String = "tblRFP"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim APV_ID, ADV_ID As Integer
    Dim bankID As Integer

    Public Overloads Function ShowDialog(ByVal DocNumber As String) As Boolean
        TransID = DocNumber
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub Disbursement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            LoadPaymentType()
            LoadBankList()
            If cbPaymentType.Items.Count > 0 Then
                cbPaymentType.SelectedIndex = 0
            End If
            dtpDocDate.Value = Date.Today.Date
            If TransID <> "" Then
                LoadRF(TransID)
            End If
            tsbSearch.Enabled = True
            tsbNew.Enabled = True
            tsbEdit.Enabled = False
            tsbSave.Enabled = False
            tsbCancel.Enabled = False
            tsbClose.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = True
            tsbPrint.Enabled = False
            tsbCopy.Enabled = False
            EnableControl(False)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCEName.Enabled = Value
        btnSearchVCE.Enabled = Value
        dgvEntry.AllowUserToAddRows = Value
        dgvEntry.AllowUserToDeleteRows = Value
        If Value = True Then
            dgvEntry.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvEntry.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        txtRemarks.Enabled = Value
        txtAmount.Enabled = Value
        txtORNo.Enabled = Value
        cbPaymentType.Enabled = Value
        cbDisburseType.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub


    Private Sub LoadRF(ByVal ID As String)
        Dim query, payment_type As String
        query = " SELECT  TransID, RF_No, PaymentType, tblRF.VCECode, VCEName, DateRF, TotalAmount, Remarks, " & _
                "         APV_Ref, OR_Ref, tblRF.Status " & _
                " FROM    tblRF LEFT JOIN tblVCE_Master " & _
                " ON      tblRF.VCECode = tblVCE_Master.VCECode " & _
                " WHERE   TransID = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            RFNo = SQL.SQLDR("RF_No").ToString
            txtTransNum.Text = RFNo
            payment_type = SQL.SQLDR("PaymentType").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            dtpDocDate.Value = SQL.SQLDR("DateRF")
            txtAmount.Text = CDec(SQL.SQLDR("TotalAmount")).ToString("N2")
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtAPVRef.Text = SQL.SQLDR("APV_Ref").ToString
            txtORNo.Text = SQL.SQLDR("OR_Ref").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            cbPaymentType.SelectedItem = payment_type
            LoadRFRef(TransID)
            LoadEntry(TransID)

            ' TOOLSTRIP BUTTONS
            If txtStatus.Text = "Cancelled" Then
                tsbEdit.Enabled = False
                tsbCancel.Enabled = False
            Else
                tsbEdit.Enabled = True
                tsbCancel.Enabled = True
            End If
            tsbPrint.Enabled = True
            tsbClose.Enabled = False
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbPrint.Enabled = True
            tsbSave.Enabled = False
            tsbNew.Enabled = True
            tsbSearch.Enabled = True
            tsbExit.Enabled = True
            tsbCopy.Enabled = False
            EnableControl(False)
        Else
            ClearText()
        End If
    End Sub

    Private Sub LoadRFRef(ByVal RFNo As Integer)
        Dim query As String
        query = " SELECT CAST(tblMasterfile_Bank.Bank_ID AS nvarchar) + '-' + Bank + ' ' + Branch + CASE WHEN Account_No <> '' THEN ' (' + Account_No  +  ')' ELSE '' END AS Bank, " & _
                " 	     RefNo, RefDate, RefAmount, tblRF_BankRef.Status " & _
                " FROM   tblRF_BankRef INNER JOIN tblMasterfile_Bank " & _
                " ON     tblRF_BankRef.BankID = tblMasterfile_Bank.Bank_ID " & _
                " WHERE  RF_No ='" & RFNo & "' AND tblRF_BankRef.Status <> 'Cancelled' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            disableEvent = True
            gbBank.Visible = True
            txtBankRef.Text = SQL.SQLDR("RefNo").ToString
            dtpBankRefDate.Value = SQL.SQLDR("RefDate")
            txtBankRefAmount.Text = CDec(SQL.SQLDR("RefAmount")).ToString("N2")
            cbBank.SelectedItem = SQL.SQLDR("Bank").ToString
            txtRefStatus.Text = SQL.SQLDR("Status").ToString
            If txtRefStatus.Text = "Unreleased" Then
                tsmUnreleased.Enabled = True
            Else
                tsmUnreleased.Enabled = False
            End If
            disableEvent = False
        ElseIf cbPaymentType.SelectedItem = "Check" Then
            gbBank.Visible = True
            txtBankRef.Text = ""
            dtpBankRefDate.Value = dtpDocDate.Value.Date
            txtBankRefAmount.Text = CDec(txtAmount.Text)
            cbBank.SelectedIndex = -1
            tsmUnreleased.Enabled = False
        Else
            gbBank.Visible = False
            tsmUnreleased.Enabled = False
        End If
    End Sub

    Private Sub LoadEntry(ByVal RFNo As Integer)
        Dim query As String
        query = " SELECT ID, JE_No, tblJE_Details.AccntCode, AccountTitle, tblJE_Details.VCECode, VCEName, Debit, Credit, Particulars, RefNo " & _
                " FROM  tblJE_Details LEFT JOIN tblVCE_Master " & _
                " ON     tblJE_Details.VCECode = tblVCE_Master.VCECode " & _
                " INNER JOIN tblCOA_Master " & _
                " ON     tblJE_Details.AccntCode = tblCOA_Master.AccountCode " & _
                " WHERE JE_No = (SELECT  JE_No FROM tblJE_Header WHERE RefType = 'RF' AND RefTransID = " & RFNo & ") " & _
                " ORDER BY LineNumber "
        SQL.ReadQuery(query)
        dgvEntry.Rows.Clear()
        While SQL.SQLDR.Read
            JETransiD = SQL.SQLDR("JE_No")
            dgvEntry.Rows.Add(SQL.SQLDR("AccntCode").ToString, SQL.SQLDR("AccountTitle").ToString, CDec(SQL.SQLDR("Debit")).ToString("N2"), _
                               CDec(SQL.SQLDR("Credit")).ToString("N2"), SQL.SQLDR("VCECode").ToString, SQL.SQLDR("VCEName").ToString, _
                               SQL.SQLDR("Particulars").ToString, SQL.SQLDR("RefNo").ToString)
        End While
        TotalDBCR()
    End Sub

    Private Sub LoadPaymentType()
        Dim query As String
        query = " SELECT Payment_Type FROM tblRF_PaymentType "
        SQL.ReadQuery(query)
        cbPaymentType.Items.Clear()
        While SQL.SQLDR.Read
            cbPaymentType.Items.Add(SQL.SQLDR("Payment_Type").ToString)
        End While
    End Sub

    Private Sub LoadBankList()
        Dim query As String
        query = " SELECT  CAST(Bank_ID AS nvarchar) + '-' + Bank + ' ' + Branch + " & _
                "         CASE WHEN Account_No <> '' THEN ' (' + Account_No  +  ')' ELSE '' END AS Bank " & _
                " FROM    tblMasterfile_Bank " & _
                " WHERE   Status ='Active'"
        SQL.ReadQuery(query)
        cbBank.Items.Clear()
        While SQL.SQLDR.Read
            cbBank.Items.Add(SQL.SQLDR("Bank").ToString)
        End While
    End Sub

    Private Sub LoadDisburseType()
        Dim query As String
        query = " SELECT  DISTINCT ISNULL(Expense_Description,'') AS Expense_Description " & _
                " FROM    tblRF_ExpenseType " & _
                " WHERE   Status ='Active' "
        SQL.ReadQuery(query)
        cbDisburseType.Items.Clear()
        While SQL.SQLDR.Read
            cbDisburseType.Items.Add(SQL.SQLDR("Expense_Description").ToString)
        End While
    End Sub


    Private Sub cbPaymentType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPaymentType.SelectedIndexChanged
        Try
            bankID = 0
            LoadBankDetails()
            If cbBank.Items.Count = 1 Then
                cbBank.SelectedIndex = 0
                bankID = GetBankID(cbBank.SelectedItem)
                If cbPaymentType.SelectedItem = "Check" Then
                    txtBankRef.Text = GetCheckNo(bankID)
                End If
            End If
        Catch ex As Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            MsgBox(ex.Message & st.GetFrame(0).GetFileLineNumber.ToString)
        End Try

    End Sub

    Private Sub LoadBankDetails()
        txtBankRef.Text = ""
        Dim query, prefix As String
        query = " SELECT  Payment_Type, WithBank, WithCheck, RefNo_Prefix, Account_Code " & _
                " FROM    tblRF_PaymentType " & _
                " WHERE   Payment_Type = @Payment_Type "
        SQL.FlushParams()
        SQL.AddParam("Payment_Type", cbPaymentType.SelectedItem)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            AccntCode = SQL.SQLDR("Account_Code").ToString
            gbBank.Visible = SQL.SQLDR("WithBank")
            If SQL.SQLDR("WithBank") Then
                prefix = SQL.SQLDR("RefNo_Prefix").ToString
                If Not SQL.SQLDR("WithCheck") Then
                    txtBankRef.Text = GetBankRef(prefix)
                End If
            End If
        End If
    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            LoadDisburseType()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetBankRef(ByVal Prefix As String) As String
        Dim query As String
        query = " SELECT  (ISNULL(MAX(CAST(REPLACE(RefNo,'" & Prefix & "','') AS int)),0) + 1) AS RefNo " & _
                " FROM    tblRF_Bankref " & _
                " WHERE   RefNo LIKE '" & Prefix & "%' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return Prefix + SQL.SQLDR("RefNo").ToString
        Else
            Return Prefix + "1"
        End If
    End Function

    Private Sub cbBank_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBank.SelectedIndexChanged
        Try
            If disableEvent = False Then
                If cbBank.SelectedIndex <> -1 Then
                    bankID = GetBankID(cbBank.SelectedItem)
                    If cbPaymentType.SelectedItem = "Check" Then
                        txtBankRef.Text = GetCheckNo(bankID)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetCheckNo(ByVal Bank_ID As String) As String
        Dim query As String
        query = " SELECT  RIGHT('000000000000' + CAST((CAST(MAX(RefNo) AS bigint) + 1) AS nvarchar), LEN(SeriesFrom)) AS RefNo, SeriesFrom " & _
                " FROM    tblRF_BankRef RIGHT JOIN tblMasterfile_Bank " & _
                " ON      tblRF_BankRef.BankID = tblMasterfile_Bank.Bank_ID " & _
                " AND     tblRF_BankRef.RefNo BETWEEN SeriesFrom AND SeriesTo " & _
                " WHERE   tblMasterfile_Bank.Bank_ID = '" & Bank_ID & "'   " & _
                " GROUP BY LEN(SeriesFrom), SeriesFrom  "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("RefNo")) Then
            Return SQL.SQLDR("RefNo").ToString
        Else
            Return SQL.SQLDR("SeriesFrom").ToString
        End If
    End Function

    Private Function GetBankID(ByVal Bank As String) As Integer
        Dim query As String
        query = " SELECT Bank_ID FROM tblMasterfile_Bank WHERE Bank_ID = LEFT('" & Bank & "',CHARINDEX('-','" & Bank & "',1)-1) "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Bank_ID")
        Else
            Return 0
        End If
    End Function

    Public Sub TotalDBCR()
        Try
            'debit compute & print in textbox
            Dim a As Double = 0
            For i As Integer = 0 To dgvEntry.Rows.Count - 1
                If dgvEntry.Item(chAccntCode.Index, i).Value <> "" AndAlso Val(dgvEntry.Item(chDebit.Index, i).Value) <> 0 Then
                    a = a + Double.Parse(dgvEntry.Item(chDebit.Index, i).Value).ToString("N2")
                End If
            Next
            txtTotalDebit.Text = a.ToString("N2")
            'credit compute & print in textbox
            Dim b As Double = 0
            For i As Integer = 0 To dgvEntry.Rows.Count - 1
                If dgvEntry.Item(chAccntCode.Index, i).Value <> "" AndAlso Val(dgvEntry.Item(chCredit.Index, i).Value) <> 0 Then
                    b = b + Double.Parse(dgvEntry.Item(chCredit.Index, i).Value).ToString("N2")
                End If
            Next
            txtTotalCredit.Text = b.ToString("N2")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtpRFDate_ValueChanged(sender As System.Object, e As System.EventArgs)
        dtpBankRefDate.Value = dtpDocDate.Value
    End Sub

    Private Sub txtAmount_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtAmount.Text = "" Then
                    MsgBox("Please enter an amount", MsgBoxStyle.Exclamation)
                Else
                    txtAmount.Text = CDec(txtAmount.Text).ToString("N2")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvManual_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvEntry.RowsRemoved
        Try
            TotalDBCR()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ClearText()
        txtVCECode.Text = ""
        txtVCEName.Text = ""
        txtAmount.Text = ""
        txtRemarks.Text = ""
        cbPaymentType.SelectedIndex = 0
        cbBank.SelectedIndex = -1
        txtBankRef.Text = ""
        txtBankRefAmount.Text = ""
        txtTransNum.Text = ""
        txtAPVRef.Text = ""
        txtORNo.Text = ""
        txtStatus.Text = ""
        dgvEntry.Rows.Clear()
        txtTotalDebit.Text = "0.00"
        txtTotalCredit.Text = "0.00"
    End Sub

    Private Sub SaveRF()
        Try
            Dim insertSQL As String
            activityStatus = True
            insertSQL = " INSERT INTO " & _
                        " tblRF (TransID, RF_No, PaymentType, VCECode, DateRF, TotalAmount, Remarks, APV_Ref, ADV_Ref, OR_Ref, WhoCreated ) " & _
                        " VALUES(@TransID, @RF_No, @PaymentType, @VCECode, @DateRF, @TotalAmount, @Remarks, @APV_Ref, @APV_Ref, @OR_Ref, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@RF_No", RFNo)
            SQL.AddParam("@PaymentType", cbPaymentType.SelectedItem)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateRF", dtpDocDate.Value.Date)
            SQL.AddParam("@TotalAmount", CDec(txtAmount.Text))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@APV_Ref", IIf(txtAPVRef.Text = "", DBNull.Value, APV_ID))
            SQL.AddParam("@ADV_Ref", IIf(txtADVRef.Text = "", DBNull.Value, ADV_ID))
            SQL.AddParam("@OR_Ref", txtORNo.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            If ADV_ID > 0 Then
                Dim updateSQL As String
                updateSQL = " UPDATE tblADV SET Status ='Closed' WHERE TransID = '" & ADV_ID & "'"
                SQL.ExecNonQuery(updateSQL)

            End If
            If gbBank.Visible Then
                SaveRFRef(TransID)
            End If

            insertSQL = " INSERT INTO " & _
                        " tblJE_Header (AppDate, BranchCode, BusinessCode, RefType, RefTransID, Book, TotalDBCR, Remarks, WhoCreated) " & _
                        " VALUES(@AppDate, @BranchCode, @BusinessCode, @RefType, @RefTransID, @Book, @TotalDBCR, @Remarks, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@AppDate", dtpDocDate.Value.Date)
            SQL.AddParam("@RefType", "RF")
            SQL.AddParam("@RefTransID", TransID)
            SQL.AddParam("@Book", "Cash Disbursements")
            SQL.AddParam("@TotalDBCR", CDec(txtTotalCredit.Text))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@WhoCreated", "")
            SQL.ExecNonQuery(insertSQL)

            JETransiD = LoadJE("RF", TransID)

            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvEntry.Rows
                If item.Cells(chAccntCode.Index).Value <> Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber) " & _
                                " VALUES(@JE_No, @AccntCode, @VCECode, @Debit, @Credit, @Particulars, @RefNo, @LineNumber)"
                    SQL.FlushParams()
                    SQL.AddParam("@JE_No", JETransiD)
                    SQL.AddParam("@AccntCode", item.Cells(chAccntCode.Index).Value.ToString)
                    If item.Cells(chVCECode.Index).Value <> Nothing AndAlso item.Cells(chVCECode.Index).Value <> "" Then
                        SQL.AddParam("@VCECode", item.Cells(chVCECode.Index).Value.ToString)
                    Else
                        SQL.AddParam("@VCECode", txtVCECode.Text)
                    End If
                    If item.Cells(chDebit.Index).Value AndAlso IsNumeric(item.Cells(chDebit.Index).Value) Then
                        SQL.AddParam("@Debit", CDec(item.Cells(chDebit.Index).Value))
                    Else
                        SQL.AddParam("@Debit", 0)
                    End If
                    If item.Cells(chCredit.Index).Value <> Nothing AndAlso IsNumeric(item.Cells(chCredit.Index).Value) Then
                        SQL.AddParam("@Credit", CDec(item.Cells(chCredit.Index).Value))
                    Else
                        SQL.AddParam("@Credit", 0)
                    End If
                    If item.Cells(chParticulars.Index).Value <> Nothing AndAlso item.Cells(chParticulars.Index).Value <> "" Then
                        SQL.AddParam("@Particulars", item.Cells(chParticulars.Index).Value.ToString)
                    Else
                        SQL.AddParam("@Particulars", "")
                    End If
                    If item.Cells(chRef.Index).Value <> Nothing AndAlso item.Cells(chRef.Index).Value <> "" Then
                        SQL.AddParam("@RefNo", item.Cells(chRef.Index).Value.ToString)
                    Else
                        SQL.AddParam("@RefNo", "")
                    End If
                    SQL.AddParam("@LineNumber", line)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "RF_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub


    Private Sub UpdateRF()
        Try
            Dim insertSQL, updateSQL, deleteSQL As String
            activityStatus = True
            updateSQL = " UPDATE tblRF  " & _
                        " SET    RF_No = @RF_No, PaymentType = @PaymentType, VCECode = @VCECode, DateRF = @DateRF, " & _
                        "        TotalAmount = @TotalAmount, Remarks = @Remarks, APV_Ref = @APV_Ref, ADV_Ref = @ADV_Ref, OR_Ref = @OR_Ref, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@RF_No", RFNo)
            SQL.AddParam("@PaymentType", cbPaymentType.SelectedItem)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateRF", dtpDocDate.Value.Date)
            SQL.AddParam("@TotalAmount", CDec(txtAmount.Text))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@APV_Ref", IIf(txtAPVRef.Text = "", DBNull.Value, APV_ID))
            SQL.AddParam("@ADV_Ref", IIf(txtADVRef.Text = "", DBNull.Value, ADV_ID))
            SQL.AddParam("@OR_Ref", txtORNo.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            If gbBank.Visible Then
                SaveRFRef(TransID)
            End If
            JETransiD = LoadJE("RF", TransID)
            If JETransiD = 0 Then
                insertSQL = " INSERT INTO " & _
                       " tblJE_Header (AppDate, BranchCode, BusinessCode, RefType, RefTransID, Book, TotalDBCR, Remarks, WhoCreated) " & _
                       " VALUES(@AppDate, @BranchCode, @BusinessCode, @RefType, @RefTransID, @Book, @TotalDBCR, @Remarks, @WhoCreated)"
                SQL.FlushParams()
                SQL.AddParam("@AppDate", dtpDocDate.Value.Date)
                SQL.AddParam("@RefType", "RF")
                SQL.AddParam("@RefTransID", TransID)
                SQL.AddParam("@Book", "Cash Disbursements")
                SQL.AddParam("@TotalDBCR", CDec(txtTotalCredit.Text))
                SQL.AddParam("@Remarks", txtRemarks.Text)
                SQL.AddParam("@BranchCode", BranchCode)
                SQL.AddParam("@BusinessCode", BusinessType)
                SQL.AddParam("@WhoCreated", "")
                SQL.ExecNonQuery(insertSQL)

                JETransiD = LoadJE("RF", TransID)
            Else
                updateSQL = " UPDATE tblJE_Header " & _
                           " SET    AppDate = @AppDate, BranchCode = @BranchCode, BusinessCode = @BusinessCode, " & _
                           "        RefType = @RefType, RefTransID = @RefTransID, Book = @Book, TotalDBCR = @TotalDBCR, " & _
                           "        Remarks = @Remarks, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                           " WHERE  JE_No = @JE_No "
                SQL.FlushParams()
                SQL.AddParam("@JE_No", JETransiD)
                SQL.AddParam("@AppDate", dtpDocDate.Value.Date)
                SQL.AddParam("@RefType", "RF")
                SQL.AddParam("@RefTransID", TransID)
                SQL.AddParam("@Book", "Cash Disbursements")
                SQL.AddParam("@TotalDBCR", CDec(txtTotalCredit.Text))
                SQL.AddParam("@Remarks", txtRemarks.Text)
                SQL.AddParam("@BranchCode", BranchCode)
                SQL.AddParam("@BusinessCode", BusinessType)
                SQL.AddParam("@WhoModified", UserID)
                SQL.ExecNonQuery(updateSQL)
            End If


            ' DELETE ACCOUNTING ENTRIES
            deleteSQL = " DELETE FROM tblJE_Details  WHERE  JE_No = @JE_No "
            SQL.FlushParams()
            SQL.AddParam("@JE_No", JETransiD)
            SQL.ExecNonQuery(deleteSQL)

            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvEntry.Rows
                If item.Cells(chAccntCode.Index).Value <> Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber) " & _
                                " VALUES(@JE_No, @AccntCode, @VCECode, @Debit, @Credit, @Particulars, @RefNo, @LineNumber)"
                    SQL.FlushParams()
                    SQL.AddParam("@JE_No", JETransiD)
                    SQL.AddParam("@AccntCode", item.Cells(chAccntCode.Index).Value.ToString)
                    If item.Cells(chVCECode.Index).Value <> Nothing AndAlso item.Cells(chVCECode.Index).Value <> "" Then
                        SQL.AddParam("@VCECode", item.Cells(chVCECode.Index).Value.ToString)
                    Else
                        SQL.AddParam("@VCECode", txtVCECode.Text)
                    End If
                    If item.Cells(chDebit.Index).Value AndAlso IsNumeric(item.Cells(chDebit.Index).Value) Then
                        SQL.AddParam("@Debit", CDec(item.Cells(chDebit.Index).Value))
                    Else
                        SQL.AddParam("@Debit", 0)
                    End If
                    If item.Cells(chCredit.Index).Value <> Nothing AndAlso IsNumeric(item.Cells(chCredit.Index).Value) Then
                        SQL.AddParam("@Credit", CDec(item.Cells(chCredit.Index).Value))
                    Else
                        SQL.AddParam("@Credit", 0)
                    End If
                    If item.Cells(chParticulars.Index).Value <> Nothing AndAlso item.Cells(chParticulars.Index).Value <> "" Then
                        SQL.AddParam("@Particulars", item.Cells(chParticulars.Index).Value.ToString)
                    Else
                        SQL.AddParam("@Particulars", "")
                    End If
                    If item.Cells(chRef.Index).Value <> Nothing AndAlso item.Cells(chRef.Index).Value <> "" Then
                        SQL.AddParam("@RefNo", item.Cells(chRef.Index).Value.ToString)
                    Else
                        SQL.AddParam("@RefNo", "")
                    End If
                    SQL.AddParam("@LineNumber", line)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "RF_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub


    Private Sub SaveRFRef(ByVal RFNo As Integer)
        Dim deleteSQL As String
        deleteSQL = "DELETE FROM tblRF_BankRef WHERE RF_No ='" & RFNo & "'"
        SQL.ExecNonQuery(deleteSQL)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblRF_BankRef (RF_No, BankID, RefNo, RefDate, RefAmount) " & _
                    " VALUES(@RF_No, @BankID, @RefNo, @RefDate, @RefAmount)"
        SQL.FlushParams()
        SQL.AddParam("@RF_No", RFNo)
        SQL.AddParam("@BankID", bankID)
        SQL.AddParam("@RefNo", txtBankRef.Text)
        SQL.AddParam("@RefDate", dtpBankRefDate.Value.Date)
        SQL.AddParam("@RefAmount", CDec(txtAmount.Text))
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub UpdateRFRef(ByVal RFNo As Integer)
        Dim insertSQL As String
        insertSQL = " UPDATE tblRF_BankRef " & _
                    " SET    Bank_ID = @Bank_ID, Ref_No = @Ref_No, Ref_Date = @Ref_Date, Ref_Amount = @Ref_Amount " & _
                    " WHERE  RF_No = @RF_No "
        SQL.FlushParams()
        SQL.AddParam("@RF_No", RFNo)
        SQL.AddParam("@Bank_ID", bankID)
        SQL.AddParam("@Ref_No", txtBankRef.Text)
        SQL.AddParam("@Ref_Date", dtpBankRefDate.Value.Date)
        SQL.AddParam("@Ref_Amount", CDec(txtAmount.Text))
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub cbDisburseType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbDisburseType.SelectedIndexChanged
        Try
            If disableEvent = False Then
                If cbDisburseType.SelectedIndex <> -1 Then
                    Dim query As String
                    Dim amount As Decimal
                    query = " SELECT  Account_Code, AccntTitle, Amount  " & _
                            " FROM    tblRF_ExpenseType INNER JOIN ChartOfAccount " & _
                            " ON      tblRF_ExpenseType.Account_Code = ChartOfAccount.AccntCode " & _
                            " WHERE   Status ='Active' AND Expense_Description = @Expense_Description "
                    SQL.FlushParams()
                    SQL.AddParam("@Expense_Description", cbDisburseType.SelectedItem)
                    SQL.ReadQuery(query)
                    If SQL.SQLDR.Read Then
                        If txtAmount.Text = "" Then
                            amount = CDec(SQL.SQLDR("Amount"))
                        Else
                            amount = CDec(txtAmount.Text) - IIf(txtTotalDebit.Text = "", 0, txtTotalDebit.Text)
                        End If
                        dgvEntry.Rows.Add(SQL.SQLDR("Account_Code").ToString, SQL.SQLDR("AccntTitle").ToString, CDec(amount).ToString("N2"), "0.00", "", "", cbDisburseType.SelectedItem)
                        TotalDBCR()
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub dgvManual_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntry.CellContentClick
        Try
            If e.ColumnIndex = 8 Then
                Dim query As String
                query = " SELECT  WithBank, Account_Code " & _
                        " FROM    tblRF_PaymentType LEFT JOIN tblCOA_Master " & _
                        " ON      tblRF_PaymentType.Account_Code = tblCOA_Master.AccountCode " & _
                        " WHERE   Payment_Type ='" & cbPaymentType.SelectedItem & "' "
                SQL.ReadQuery(query)
                If SQL.SQLDR.Read Then
                    If SQL.SQLDR("WithBank") Then
                        If cbBank.SelectedIndex <> -1 Then
                            query = " SELECT Account_Code, AccountTitle FROM tblMasterfile_Bank " & _
                                    "        INNER JOIN tblCOA_Master " & _
                                    " ON tblMasterfile_Bank.Account_Code = tblCOA_Master.AccountCode " & _
                                    " WHERE Bank_ID ='" & bankID & "' "
                            SQL.ReadQuery(query)
                            If SQL.SQLDR.Read Then
                                dgvEntry.Rows.Add(SQL.SQLDR("Account_Code").ToString, SQL.SQLDR("AccountTitle").ToString, "0.00", CDec(CDec(txtTotalDebit.Text) - CDec(txtTotalCredit.Text)).ToString("N2"), "", "", "", "")
                            End If
                            txtAmount.Text = CDec(CDec(txtTotalDebit.Text) - CDec(txtTotalCredit.Text)).ToString("N2")
                            TotalDBCR()
                        End If
                    Else
                        Dim code As String = SQL.SQLDR("Account_Code").ToString
                        dgvEntry.Rows.Add(code, GetAccntTitle(code), "0.00", CDec(CDec(txtTotalDebit.Text) - CDec(txtTotalCredit.Text)).ToString("N2"), "", "", "", "")
                        txtAmount.Text = CDec(CDec(txtTotalDebit.Text) - CDec(txtTotalCredit.Text)).ToString("N2")
                        TotalDBCR()
                    End If

                    TotalDBCR()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub dgvManual_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntry.CellEndEdit
        If e.ColumnIndex = chDebit.Index Or e.ColumnIndex = chCredit.Index Then
            If IsNumeric(dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value) Then
                dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value = CDec(dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value).ToString("N2")
            End If
            TotalDBCR()
        ElseIf e.ColumnIndex = chAccntCode.Index Or e.ColumnIndex = chAccntTitle.Index Then
            If dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value <> Nothing Then
                Dim f As New frmCOA_Search
                Dim filter As String
                If e.ColumnIndex = 0 Then
                    filter = "AccntCode"
                Else
                    filter = "AccntTitle"
                End If
                f.ShowDialog(filter, dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value.ToString)
                If f.accountcode <> "" And f.accttile <> "" Then
                    dgvEntry.Item(chAccntCode.Index, e.RowIndex).Value = f.accountcode
                    dgvEntry.Item(chAccntTitle.Index, e.RowIndex).Value = f.accttile
                    dgvEntry.SelectedCells(0).Selected = False
                    dgvEntry.Item(chDebit.Index, e.RowIndex).Selected = True
                End If

                f.Dispose()
            End If

        ElseIf e.ColumnIndex = chVCECode.Index Or e.ColumnIndex = chVCEName.Index Then
            Dim f As New frmVCE_Search
            f.txtFilter.Text = dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value.ToString
            f.ShowDialog()
            dgvEntry.Item(chVCECode.Index, e.RowIndex).Value = f.VCECode
            dgvEntry.Item(chVCEName.Index, e.RowIndex).Value = f.VCEName
            f.Dispose()
        End If
    End Sub



    Private Sub btnPrintCheck_Click(sender As System.Object, e As System.EventArgs)
        If txtBankRef.Text <> "" Then
            frmCheckPrinting.CVTransID = txtTransNum.Text
            frmCheckPrinting.ShowDialog()
            frmCheckPrinting.Dispose()
        Else
            MsgBox("No Check No. to print!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub LoadAPV(ByVal APV As String)
        Try
            Dim query As String
            query = " SELECT Ref_TransID AS TransID, VCECode, Supplier AS  VCEName, Date AS Date_APV, Amount AS Net_Purchase, Amount/1.12 * 0.12 AS Input_VAT, Amount/1.12 * 0.02 AS EWT, Remarks, Reference AS Reference_Other, AccntCode, AccountTitle " & _
                    " FROM View_APV_Balance " & _
                    " WHERE  Ref_TransID ='" & APV & "' "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                txtVCECode.Text = SQL.SQLDR("VCECode").ToString
                txtVCEName.Text = SQL.SQLDR("VCEName").ToString
                APV_ID = SQL.SQLDR("TransID")
                txtAPVRef.Text = SQL.SQLDR("TransID")
                dgvEntry.Rows.Add(SQL.SQLDR("AccntCode").ToString, SQL.SQLDR("AccountTitle").ToString, CDec(SQL.SQLDR("Net_Purchase")).ToString("N2"), "0.00", "", "", "", "APV:" & txtAPVRef.Text)

            End If
            TotalDBCR()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadADV(ByVal ADV As String)
        Try
            Dim query As String
            query = " SELECT TransID,  tblADV.VCECode, VCEName, DateADV AS DateADV, ADV_Amount AS Net_Purchase, Remarks,  AccntCode, AccountTitle " & _
                    " FROM   tblADV INNER JOIN tblVCE_Master " & _
                    " ON     tblADV.VCECode = tblVCE_Master.VCECode " & _
                    " INNER JOIN tblCOA_Master " & _
                    " ON     tblADV.AccntCode = tblCOA_Master.AccountCode " & _
                    " WHERE  TransID ='" & ADV & "' "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                txtVCECode.Text = SQL.SQLDR("VCECode").ToString
                txtVCEName.Text = SQL.SQLDR("VCEName").ToString
                txtADVRef.Text = SQL.SQLDR("TransID")
                ADV_ID = SQL.SQLDR("TransID")
                dgvEntry.Rows.Add(SQL.SQLDR("AccntCode").ToString, SQL.SQLDR("AccountTitle").ToString, CDec(SQL.SQLDR("Net_Purchase")).ToString("N2"), "0.00", "", "", "", "ADV:" & txtAPVRef.Text)
            End If
            TotalDBCR()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        Dim f As New frmLoadTransactions
        f.ShowDialog("RF")
        TransID = f.transID
        LoadRF(TransID)
        f.Dispose()
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        ClearText()
        TransID = ""
        RFNo = ""

        ' Toolstrip Buttons
        tsbSearch.Enabled = False
        tsbNew.Enabled = False
        tsbEdit.Enabled = False
        tsbSave.Enabled = True
        tsbCancel.Enabled = False
        tsbClose.Enabled = True
        tsbPrevious.Enabled = False
        tsbNext.Enabled = False
        tsbExit.Enabled = False
        tsbPrint.Enabled = False
        tsbCopy.Enabled = True
        tsbOption.Enabled = False
        txtStatus.Text = "Open"
        EnableControl(True)

        txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        txtVCEName.Select()
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        EnableControl(True)

        ' Toolstrip Buttons
        tsbSearch.Enabled = False
        tsbNew.Enabled = False
        tsbEdit.Enabled = False
        tsbSave.Enabled = True
        tsbCancel.Enabled = False
        tsbClose.Enabled = True
        tsbPrevious.Enabled = False
        tsbNext.Enabled = False
        tsbExit.Enabled = False
        tsbPrint.Enabled = False
        tsbCopy.Enabled = False
        tsbOption.Enabled = True
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If txtTransNum.Text <> "" Then
            If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                Try
                    activityStatus = True
                    Dim deleteSQL As String
                    deleteSQL = " UPDATE  tblRF SET Status ='Cancelled' WHERE RF_No = @APV_No "
                    SQL.FlushParams()
                    RFNo = txtTransNum.Text
                    SQL.AddParam("@RF_No", RFNo)
                    SQL.ExecNonQuery(deleteSQL)
                    Msg("Record cancelled successfully", MsgBoxStyle.Information)

                    tsbSearch.Enabled = True
                    tsbNew.Enabled = True
                    tsbEdit.Enabled = False
                    tsbSave.Enabled = False
                    tsbCancel.Enabled = False
                    tsbClose.Enabled = False
                    tsbPrevious.Enabled = False
                    tsbNext.Enabled = False
                    tsbExit.Enabled = True
                    tsbPrint.Enabled = True
                    tsbCopy.Enabled = False
                    EnableControl(False)

                    RFNo = txtTransNum.Text
                    LoadRF(TransID)
                Catch ex As Exception
                    activityStatus = True
                    SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                Finally
                    RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "RF_No", RFNo, BusinessType, BranchCode, "", activityStatus)
                    SQL.FlushParams()
                End Try
            End If
        End If
    End Sub

    Private Sub tsbCopy_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopy.Click

    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs)
        Dim f As New frmReport_Display
        f.ShowDialog("RF", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If RFNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblRF  WHERE RF_No < '" & RFNo & "' ORDER BY RF_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                RFNo = SQL.SQLDR("TransID").ToString
                LoadRF(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If RFNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblRF  WHERE RF_No > '" & RFNo & "' ORDER BY RF_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                RFNo = SQL.SQLDR("TransID").ToString
                LoadRF(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If RFNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadRF(TransID)
            tsbEdit.Enabled = True
            tsbCancel.Enabled = True
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbPrint.Enabled = True
        End If
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
        tsbCopy.Enabled = False
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click

        If txtVCECode.Text = "" Then
            Msg("Please enter VCECode!", MsgBoxStyle.Exclamation)
        ElseIf txtRemarks.Text = "" Then
            MsgBox("Please enter a remark/short explanation", MsgBoxStyle.Exclamation)
        ElseIf txtTotalDebit.Text <> txtTotalCredit.Text Then
            MsgBox("Please check the Debit and Credit Amount!", MsgBoxStyle.Exclamation)
        ElseIf txtAmount.Text = "" Then
            MsgBox("Please check amount!", MsgBoxStyle.Exclamation)
        ElseIf dgvEntry.Rows.Count = 0 Then
            MsgBox("No entries, Please check!", MsgBoxStyle.Exclamation)
        ElseIf gbBank.Visible = True And cbBank.SelectedIndex = -1 Then
            MsgBox("No bank selected, Please check!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                '      RFNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                RFNo = txtTransNum.Text
                SaveRF()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                LoadRF(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                RFNo = txtTransNum.Text
                UpdateRF()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                RFNo = txtTransNum.Text
                LoadRF(TransID)
            End If
        End If
    End Sub

    Private Sub TestToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        txtVCEName.Text = f.VCEName
    End Sub

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
            f.Dispose()
        End If
    End Sub

    Private Sub frmRF_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.Control = True Then
            If e.KeyCode = Keys.S Then
                If tsbSave.Enabled = True Then tsbSave.PerformClick()
            ElseIf e.KeyCode = Keys.F Then
                If tsbSearch.Enabled = True Then tsbSearch.PerformClick()
            ElseIf e.KeyCode = Keys.N Then
                If tsbNew.Enabled = True Then tsbNew.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                If tsbEdit.Enabled = True Then tsbEdit.PerformClick()
            ElseIf e.KeyCode = Keys.D Then
                If tsbCancel.Enabled = True Then tsbCancel.PerformClick()
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.P Then
                If tsbPrint.Enabled = True Then tsbPrint.ShowDropDown()
            ElseIf e.KeyCode = Keys.R Then
                If tsbReports.Enabled = True Then tsbReports.PerformClick()
            ElseIf e.KeyCode = Keys.C Then
                If tsbCopy.Enabled = True Then tsbCopy.ShowDropDown()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbExit.Enabled = True Then
                    tsbExit.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
        End If
    End Sub

    Private Sub tsbCopyAPV_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyAPV.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False

        f.ShowDialog("APV")
        LoadAPV(f.transID)
        f.Dispose()
    End Sub

    Private Sub FromAdvancesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyADV.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("ADV")
        LoadADV(f.transID)
        f.Dispose()
    End Sub

    Private Sub PrintRFToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim f As New frmReport_Display
        f.ShowDialog("RF", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbPrint_ButtonClick(sender As System.Object, e As System.EventArgs) Handles tsbPrint.ButtonClick
        Dim f As New frmReport_Display
        f.ShowDialog("RF", TransID)
        f.Dispose()
    End Sub

    Private Sub ChequieToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChequieToolStripMenuItem.Click
        Dim f As New frmCheckPrinting
        f.CVTransID = TransID
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub BIR2307ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BIR2307ToolStripMenuItem.Click
        Dim f As New frmReport_Display
        f.ShowDialog("BIR_2307", TransID)
        f.Dispose()
    End Sub

    Private Sub tsmUnreleased_Click(sender As System.Object, e As System.EventArgs) Handles tsmUnreleased.Click
        If MsgBox("Tagging cheque as released" & vbNewLine & "Click Yes to Confirm", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "JADE Message Alert") = MsgBoxResult.Yes Then
            Dim updateSQl As String
            updateSQl = " UPDATE tblRF_BankRef " & _
                        " SET   Status ='Released' WHERE RF_No ='" & TransID & "' AND BankID = '" & bankID & "' AND RefNo ='" & txtBankRef.Text & "' "
            SQL.ExecNonQuery(updateSQl)
            txtRefStatus.Text = "Released"
            tsmUnreleased.Enabled = False
        End If
    End Sub

    Private Sub CancelCheckToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelCheckToolStripMenuItem.Click
        If MsgBox("Tagging cheque as cancelled" & vbNewLine & "Click Yes to Confirm", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            Dim updateSQl As String
            updateSQl = " UPDATE tblRF_BankRef " & _
                        " SET   Status ='Cancelled' WHERE RF_No ='" & TransID & "' AND BankID = '" & bankID & "' AND RefNo ='" & txtBankRef.Text & "' "
            SQL.ExecNonQuery(updateSQl)
            MsgBox("Please enter new cheque")
            txtBankRef.Select()
        End If
    End Sub

    Private Sub dgvEntry_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvEntry.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub
End Class