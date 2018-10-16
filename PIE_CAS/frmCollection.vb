Public Class frmCollection
    Public TransType As String
    Dim TransID, RefID, JETransiD, DBAccount As String
    Dim TransNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "CRB"
    Dim ColumnPK As String = "TransNo"
    Dim DBTable As String = "tblCollection"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim bankID As Integer


    'Dim DBAccount, DBTitle As String
    'Public VCECode, VCEName, CashPayment, CheckNO, BankName, Amount, DocNum, BSNO, PRNO, ORNO, WithholdingTax As String
    'Public CheckDate, DocDate, ApplicationDate, TaxDate As Date
    'Public billing_Period As String
    'Public BankAccountNo, Bank, BankBranch, BankAccountCode, BankAccountTitle As String
    'Dim EnableEvent As Boolean = True
    'Dim a As String
    'Dim activityResult As Boolean = True
    'Dim allowEdit As Boolean = True
    'Dim allowEvent As Boolean = True

    Public Overloads Function ShowDialog(ByVal DocNumber As String) As Boolean
        TransID = DocNumber
        MyBase.ShowDialog()
        Return True
    End Function


    Private Sub frmCollection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Text = "Collection - " & TransType
            Label5.Text = TransType & " No. :"
            TransAuto = GetTransSetup(ModuleID)
            LoadPaymentType()
            LoadCollectionType()
            If cbPaymentType.Items.Count > 0 Then
                cbPaymentType.SelectedIndex = 0
            End If
            dtpDate.Value = Date.Today.Date
            If TransID <> "" Then
                LoadCollection(TransID)
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
        cbPaymentType.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadCollection(ByVal ID As String)
        Dim query, PaymentType As String
        query = " SELECT  TransID, TransNo, DateTrans, PaymentType, tblCollection.VCECode, VCEName, Amount, CheckRef, BankRef, CheckDate, Remarks, tblCollection.Status " & _
                " FROM    tblCollection LEFT JOIN tblVCE_Master " & _
                " ON      tblCollection.VCECode = tblVCE_Master.VCECode " & _
                " WHERE   TransID = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            TransNo = SQL.SQLDR("TransNo").ToString
            txtTransNum.Text = TransNo
            PaymentType = SQL.SQLDR("PaymentType").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            dtpDate.Value = SQL.SQLDR("DateTrans")
            txtAmount.Text = CDec(SQL.SQLDR("Amount")).ToString("N2")
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtBankRef.Text = SQL.SQLDR("CheckRef").ToString
            cbBank.Text = SQL.SQLDR("BankRef").ToString
            If IsDate(SQL.SQLDR("CheckDate")) Then
                dtpBankRefDate.Value = SQL.SQLDR("CheckDate")
            End If
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            cbPaymentType.SelectedItem = PaymentType
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

    Private Sub LoadEntry(ByVal CollectionID As Integer)
        Dim query As String
        query = " SELECT ID, JE_No, tblJE_Details.AccntCode, AccountTitle, tblJE_Details.VCECode, VCEName, Debit, Credit, Particulars, RefNo " & _
                " FROM  tblJE_Details LEFT JOIN tblVCE_Master " & _
                " ON     tblJE_Details.VCECode = tblVCE_Master.VCECode " & _
                " INNER JOIN tblCOA_Master " & _
                " ON     tblJE_Details.AccntCode = tblCOA_Master.AccountCode " & _
                " WHERE JE_No = (SELECT  JE_No FROM tblJE_Header WHERE RefType = '" & TransType & "' AND RefTransID = " & CollectionID & ") " & _
                " ORDER BY LineNumber "
        SQL.ReadQuery(query)
        dgvEntry.Rows.Clear()
        While SQL.SQLDR.Read
            JETransiD = SQL.SQLDR("JE_No")
            dgvEntry.Rows.Add(SQL.SQLDR("AccntCode").ToString, SQL.SQLDR("AccountTitle").ToString, CDec(SQL.SQLDR("Debit")).ToString("N2"), _
                               CDec(SQL.SQLDR("Credit")).ToString("N2"), SQL.SQLDR("VCECode").ToString, SQL.SQLDR("VCEName").ToString, _
                               SQL.SQLDR("Particulars").ToString, SQL.SQLDR("RefNo").ToString)
        End While
        txtVCEName.ReadOnly = True
        txtAmount.ReadOnly = True
        TotalDBCR()
    End Sub

    Private Sub LoadPaymentType()
        Dim query As String
        query = " SELECT DISTINCT PaymentType FROM tblCollection_PaymentType WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbPaymentType.Items.Clear()
        While SQL.SQLDR.Read
            cbPaymentType.Items.Add(SQL.SQLDR("PaymentType").ToString)
        End While
        If cbPaymentType.Items.Count > 0 Then
            cbPaymentType.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbPaymentType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPaymentType.SelectedIndexChanged
        Dim query As String
        query = " SELECT WithBank, Account_Code " & _
                " FROM   tblCollection_PaymentType " & _
                " WHERE  Status ='Active' AND PaymentType ='" & cbPaymentType.SelectedItem & "' "
        SQL.ReadQuery(query)
        cbCollectionType.Items.Clear()
        If SQL.SQLDR.Read Then
            gbBank.Visible = SQL.SQLDR("WithBank")
            DBAccount = SQL.SQLDR("Account_Code").ToString
        End If
    End Sub

    Private Sub LoadCollectionType()
        Dim query As String
        query = " SELECT DISTINCT Collection_Type FROM tblCollection_Type WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbCollectionType.Items.Clear()
        While SQL.SQLDR.Read
            cbCollectionType.Items.Add(SQL.SQLDR("Collection_Type").ToString)
        End While
    End Sub

    Private Sub btnTypeMaintenance_Click(sender As System.Object, e As System.EventArgs) Handles btnTypeMaintenance.Click
        frmCollection_Type.ShowDialog()
        LoadCollectionType()
    End Sub

    Public Function getduplicateOR(orno As String) As Boolean
        Dim query As String
        query = "SELECT * FROM Collection WHERE (ORNO = N'" & orno & "')"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub cbCollectionType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCollectionType.SelectedIndexChanged
        Try
            If disableEvent = False Then
                Dim query As String
                Dim amount As Decimal
                query = " SELECT  Account_Code, AccountTitle, Amount, Collection_Type  " & _
                        " FROM    tblCollection_Type INNER JOIN tblCOA_Master " & _
                        " ON      tblCollection_Type.Account_Code = tblCOA_Master.AccountCode " & _
                        " WHERE   Status ='Active' AND Collection_Type = @Collection_Type "
                SQL.FlushParams()
                SQL.AddParam("@Collection_Type", cbCollectionType.SelectedItem)
                SQL.ReadQuery(query)
                If SQL.SQLDR.Read Then
                    If txtAmount.Text = "" Then
                        amount = CDec(SQL.SQLDR("Amount"))
                    Else
                        amount = CDec(txtAmount.Text) - IIf(txtTotalDebit.Text = "", 0, txtTotalDebit.Text)
                    End If
                    dgvEntry.Rows.Add(SQL.SQLDR("Account_Code").ToString, SQL.SQLDR("AccountTitle").ToString, "0.00", CDec(amount).ToString("N2"), "", "", cbCollectionType.SelectedItem, IIf(cbRef.Text = "", txtRef.Text, cbRef.Text & ":" & txtRef.Text))
                    TotalDBCR()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub dgvProducts_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntry.CellEndEdit
        Try
            If e.ColumnIndex = chDebit.Index Or e.ColumnIndex = chCredit.Index Then
                If IsNumeric(dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value = CDec(dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value).ToString("N2")
                End If
                TotalDBCR()
            ElseIf e.ColumnIndex = chAccntCode.Index Or e.ColumnIndex = chAccntTitle.Index Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value.ToString)
                dgvEntry.Item(chAccntCode.Index, e.RowIndex).Value = f.accountcode
                dgvEntry.Item(chAccntTitle.Index, e.RowIndex).Value = f.accttile
                f.Dispose()
                dgvEntry.Item(chDebit.Index, e.RowIndex).Selected = True
            ElseIf e.ColumnIndex = chVCECode.Index Or e.ColumnIndex = chVCEName.Index Then
                Dim f As New frmVCE_Search
                f.cbFilter.SelectedItem = "VCEName"
                f.txtFilter.Text = dgvEntry.Item(e.ColumnIndex, e.RowIndex).Value.ToString
                f.ShowDialog()
                dgvEntry.Item(chVCECode.Index, e.RowIndex).Value = f.VCECode
                dgvEntry.Item(chVCEName.Index, e.RowIndex).Value = f.VCEName
                f.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


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

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmVCE_Search
                f.cbFilter.SelectedItem = "VCEName"
                f.txtFilter.Text = txtVCEName.Text
                f.ShowDialog()
                txtVCECode.Text = f.VCECode
                txtVCEName.Text = f.VCEName
                f.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtBankRefAmount_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
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

    Private Function IfExist(ByVal ID As Integer, Type As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblJE_Header WHERE RefType ='" & Type & "' AND RefTransID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SaveCollection()
        Try
            Dim insertSQL As String
            activityStatus = True
            insertSQL = " INSERT INTO " & _
                        " tblCollection (TransID, TransType, TransNo, DateTrans, VCECode, PaymentType, Amount,  CheckRef, BankRef, CheckDate, Remarks, WhoCreated) " & _
                        " VALUES(@TransID, @TransType, @TransNo, @DateTrans, @VCECode, @PaymentType, @Amount, @CheckRef, @BankRef, @CheckDate, @Remarks, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@TransType", TransType)
            SQL.AddParam("@TransNo", TransNo)
            SQL.AddParam("@DateTrans", dtpDate.Value.Date)
            SQL.AddParam("@PaymentType", cbPaymentType.SelectedItem)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            If IsNumeric(txtAmount.Text) Then
                SQL.AddParam("@Amount", CDec(txtAmount.Text))
            Else
                SQL.AddParam("@Amount", 0)
            End If
            SQL.AddParam("@CheckRef", txtBankRef.Text)
            SQL.AddParam("@BankRef", cbBank.Text)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@CheckDate", IIf(gbBank.Visible, DBNull.Value, dtpBankRefDate.Value.Date))
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            insertSQL = " INSERT INTO " & _
                        " tblJE_Header (AppDate, BranchCode, BusinessCode, RefType, RefTransID, Book, TotalDBCR, Remarks, WhoCreated) " & _
                        " VALUES(@AppDate, @BranchCode, @BusinessCode, @RefType, @RefTransID, @Book, @TotalDBCR, @Remarks, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@AppDate", dtpDate.Value.Date)
            SQL.AddParam("@RefType", TransType)
            SQL.AddParam("@RefTransID", TransID)
            SQL.AddParam("@Book", "Cash Receipts")
            SQL.AddParam("@TotalDBCR", CDec(txtTotalCredit.Text))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            JETransiD = LoadJE(TransType, TransID)

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
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "TransNo", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub ClearText()
        txtVCECode.Text = ""
        txtVCEName.Text = ""
        txtAmount.Text = ""
        txtRemarks.Text = ""
        cbBank.SelectedIndex = -1
        txtBankRef.Text = ""
        txtStatus.Text = ""
        dgvEntry.Rows.Clear()
        tcCollection.SelectedTab = tpCollection
        txtTotalDebit.Text = "0.00"
        txtTotalCredit.Text = "0.00"
    End Sub

    Private Sub dgvManual_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntry.CellContentClick
        Try
            If e.ColumnIndex = 8 Then
                If IsNumeric(txtAmount.Text) AndAlso txtAmount.Text > 0 Then
                    dgvEntry.Rows.Add(DBAccount, GetAccntTitle(DBAccount), CDec(txtAmount.Text).ToString("N2"), "0.00", "", "", "", "")
                    txtAmount.Text = CDec(txtAmount.Text).ToString("N2")
                Else
                    If CDec(txtTotalCredit.Text) > CDec(txtTotalDebit.Text) Then
                        dgvEntry.Rows.Add(DBAccount, GetAccntTitle(DBAccount), CDec(CDec(txtTotalCredit.Text) - CDec(txtTotalDebit.Text)).ToString("N2"), "0.00", "", "", "", "")
                        txtAmount.Text = CDec(CDec(txtTotalCredit.Text) - CDec(txtTotalDebit.Text)).ToString("N2")
                    End If
                End If
                TotalDBCR()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvEntry_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvEntry.RowsRemoved
        Try
            TotalDBCR()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        Dim f As New frmLoadTransactions
        f.ShowDialog(TransType)
        TransID = f.transID
        LoadCollection(TransID)
        f.Dispose()
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        ClearText()
        TransID = ""
        TransNo = ""

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
        txtStatus.Text = "Open"
        EnableControl(True)

        txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
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
        ElseIf gbBank.Visible = True And cbBank.Text = "" Then
            MsgBox("Please enter bank of the received cheque", MsgBoxStyle.Exclamation)
        ElseIf TransAuto = False AndAlso txtTransNum.Text = "" Then
            MsgBox("Please enter " & TransType & " Number", MsgBoxStyle.Exclamation)
        ElseIf TransAuto = False AndAlso IfExist(txtTransNum.Text, TransType) Then
            MsgBox(TransType & " " & txtTransNum.Text & " already exist!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                If TransAuto Then
                    TransNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                Else
                    TransNo = txtTransNum.Text
                End If
                txtTransNum.Text = TransNo
                SaveCollection()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                LoadCollection(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then

                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                LoadCollection(TransID)
            End If
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If txtTransNum.Text <> "" Then
            If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                Try
                    activityStatus = True
                    Dim deleteSQL As String
                    deleteSQL = " UPDATE  tblCV SET Status ='Cancelled' WHERE CV_No = @APV_No "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
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

                    LoadCollection(TransID)
                Catch ex As Exception
                    activityStatus = True
                    SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                Finally
                    RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "TransNo", TransNo, BusinessType, BranchCode, "", activityStatus)
                    SQL.FlushParams()
                End Try
            End If
        End If
    End Sub


    Private Sub frmCollection_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                If tsbPrint.Enabled = True Then tsbPrint.PerformClick()
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

    Private Sub tsbCopyPO_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyPO.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False

        f.ShowDialog("SI")

        f.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        frmUploader.ModID = "Collection"
        frmUploader.Show()
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If TransNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblCollection  WHERE TransNo > '" & TransNo & "' AND TransType = '" & TransType & "'  ORDER BY TransNo ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadCollection(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If TransNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblCollection  WHERE TransNo < '" & TransNo & "'  AND TransType = '" & TransType & "' ORDER BY TransNo DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadCollection(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
End Class