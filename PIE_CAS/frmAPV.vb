Public Class frmAPV
    Dim TransID, RefID, JETransiD As String
    Dim Adv_Amount As Decimal
    Dim APVNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "APV"
    Dim ColumnPK As String = "APV_No"
    Dim DBTable As String = "tblAPV"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim PO_ID As Integer
    Dim accntDR, accntCR, accntVAT, accntAdvance As String

    Public Overloads Function ShowDialog(ByVal DocID As String) As Boolean
        TransID = DocID
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub APV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            LoadChartOfAccount()
            If TransID <> "" Then
                LoadAPV(TransID)
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

    Private Sub LoadChartOfAccount()
        Dim query As String
        query = " SELECT  AccountCode, AccountTitle " & _
                " FROM    tblCOA_Master " & _
                " WHERE   AccountNature = 'Credit' " & _
                " ORDER BY AccountTitle "
        SQL.ReadQuery(query)
        cbCreditAccount.Items.Clear()
        While SQL.SQLDR.Read
            cbCreditAccount.Items.Add(SQL.SQLDR("AccountTitle"))
        End While
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
        dtpDocDate.Enabled = Value
        txtPORef.Enabled = Value
        txtSINo.Enabled = Value
        txtAmount.Enabled = Value
        txtDiscount.Enabled = Value
        txtVAT.Enabled = Value
        txtNet.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadAPV(ID As String)
        Dim query As String
        query = " SELECT  TransID, APV_No, tblAPV.VCECOde, VCEName, DateAPV, ISNULL(Amount,0) AS Amount, ISNULL(Discount,0) AS Discount, " & _
                "         ISNULL(InputVAT,0) AS InputVAT, ISNULL(NetPurchase,0) AS NetPurchase, Remarks, PO_Ref, SI_Ref, tblAPV.Status, AccntCode  " & _
                " FROM    tblAPV INNER JOIN tblVCE_Master " & _
                " ON      tblAPV.VCECode = tblVCE_Master.VCECode " & _
                " WHERE   TransID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            APVNo = SQL.SQLDR("APV_No").ToString
            txtTransNum.Text = APVNo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            dtpDocDate.Value = SQL.SQLDR("DateAPV")
            txtAmount.Text = CDec(SQL.SQLDR("Amount").ToString).ToString("N2")
            txtDiscount.Text = CDec(SQL.SQLDR("Discount")).ToString("N2")
            txtVAT.Text = CDec(SQL.SQLDR("InputVAT")).ToString("N2")
            txtNet.Text = CDec(SQL.SQLDR("NetPurchase")).ToString("N2")
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtPORef.Text = SQL.SQLDR("PO_Ref").ToString
            txtSINo.Text = SQL.SQLDR("SI_Ref").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            cbCreditAccount.SelectedItem = GetAccntTitle(SQL.SQLDR("AccntCode").ToString)
            LoadAccountingEntry(TransID)

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

    Private Function LoadPONo(PO_ID As Integer) As String
        Dim query As String
        query = " SELECT PO_No FROM tblPO WHERE TransID = '" & PO_ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("PO_No")
        Else
            Return 0
        End If
    End Function

    Private Sub LoadAccountingEntry(ByVal TransID As Integer)
        Try
            Dim query As String
            query = " SELECT JE_No, VCECode, VCEName, AccntCode, AccntTitle, Particulars, " & _
                    "        ISNULL(Debit,0) AS Debit, ISNULL(Credit,0) AS Credit " & _
                    " FROM   View_GL  " & _
                    " WHERE  RefType ='APV' AND RefTransID ='" & TransID & "' "
            SQL.ReadQuery(query)
            dgvEntry.Rows.Clear()
            If SQL.SQLDR.HasRows Then
                While SQL.SQLDR.Read
                    JETransiD = SQL.SQLDR("JE_No").ToString
                    dgvEntry.Rows.Add(SQL.SQLDR("AccntCode").ToString, SQL.SQLDR("AccntTitle").ToString, _
                                      IIf(CDec(SQL.SQLDR("Debit")) = 0, "", CDec(SQL.SQLDR("Debit")).ToString("N2")), _
                                      IIf(CDec(SQL.SQLDR("Credit")) = 0, "", CDec(SQL.SQLDR("Credit")).ToString("N2")), _
                                      SQL.SQLDR("Particulars").ToString, SQL.SQLDR("VCECode").ToString, SQL.SQLDR("VCEName").ToString)
                End While
                TotalDBCR()
            Else
                JETransiD = 0
                dgvEntry.Rows.Clear()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub TotalDBCR()
        ' COMPUTE TOTAL DEBIT
        Dim db As Decimal = 0

        For i As Integer = 0 To dgvEntry.Rows.Count - 1
            If Val(dgvEntry.Item(chDebit.Index, i).Value) <> 0 Then
                db = db + Double.Parse(dgvEntry.Item(chDebit.Index, i).Value).ToString("N2")
            End If
        Next
        txtTotalDebit.Text = db.ToString("N2")

        ' COMPUTE TOTAL CREDIT
        Dim b As Decimal = 0

        For i As Integer = 0 To dgvEntry.Rows.Count - 1
            If Val(dgvEntry.Item(chCredit.Index, i).Value) <> 0 Then
                b = b + Double.Parse(dgvEntry.Item(chCredit.Index, i).Value).ToString("N2")
            End If
        Next
        txtTotalCredit.Text = b.ToString("N2")
    End Sub

    Private Sub txtVCEName_KeyDown_1(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
        End If
    End Sub

    Private Sub ClearText()
        txtTransNum.Clear()
        txtVCECode.Clear()
        txtVCEName.Clear()
        dgvEntry.Rows.Clear()
        txtRemarks.Clear()
        txtPORef.Clear()
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        txtAmount.Text = "0.00"
        txtDiscount.Text = "0.00"
        txtVAT.Text = "0.00"
        txtNet.Text = "0.00"
        txtSINo.Clear()
        dgvEntry.Rows.Clear()
        txtTotalCredit.Clear()
        txtTotalDebit.Clear()
    End Sub

    Private Sub LoadPO(ByVal ID As String)
        Dim query As String
        query = " SELECT    tblPO.TransID, tblPO.PO_No, DatePO AS Date, tblPO.VCECode, VCEName,  " & _
                " 		    ISNULL(ADV_Amount,0) AS Advances, GrossAmount AS Amount, " & _
                " 		    VATAmount AS VAT, " & _
                " 		    NetAmount AS NetPurchase, " & _
                " 		    Remarks, tblPO.AccntCode, ADV.AccntCode  AS ADVAccount " & _
                " FROM      tblPO INNER JOIN tblVCE_Master " & _
                " ON        tblPO.VCECode = tblVCE_Master.VCECode " & _
                " INNER JOIN viewPO_Status " & _
                " ON        tblPO.TransID = viewPO_Status.TransID " & _
                " LEFT JOIN " & _
                " (  SELECT PO_Ref, AccntCode, SUM(ADV_Amount) AS ADV_Amount  FROM tblADV WHERE Status ='Closed' GROUP BY PO_Ref, AccntCode) AS ADV " & _
                " ON        tblPO.TransID  = ADV.PO_Ref " & _
                " WHERE     viewPO_Status.Status ='Closed' AND tblPO.TransID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            RefID = SQL.SQLDR("TransID")
            txtPORef.Text = SQL.SQLDR("PO_No").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtAmount.Text = CDec(SQL.SQLDR("Amount")).ToString("N2")
            txtDiscount.Text = "0.00"
            txtVAT.Text = CDec(SQL.SQLDR("VAT")).ToString("N2")
            txtNet.Text = CDec(SQL.SQLDR("NetPurchase")).ToString("N2")
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            accntDR = SQL.SQLDR("AccntCode").ToString
            Adv_Amount = SQL.SQLDR("Advances").ToString
            accntAdvance = SQL.SQLDR("ADVAccount").ToString
            GenerateEntry(ID)
        Else
            ClearText()
        End If
    End Sub

    Private Sub GenerateEntry(ByVal PO_ID As Integer)
        Dim baseAmt As Decimal = 0
        Dim query As String
        query = " SELECT BaseAmount, AD_Inv FROM viewAPV_InvEntry WHERE TransID = '" & PO_ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            accntDR = SQL.SQLDR("AD_Inv").ToString
            baseAmt = SQL.SQLDR("BaseAmount").ToString
        End If
        accntCR = GetAccntCode(cbCreditAccount.SelectedItem)
        accntVAT = "70"
        dgvEntry.Rows.Clear()
        dgvEntry.Rows.Add({accntDR, GetAccntTitle(accntDR), CDec(txtNet.Text) - CDec(txtVAT.Text).ToString("N2"), "0.00", ""})
        If CDec(txtVAT.Text) <> 0 Then
            dgvEntry.Rows.Add({accntVAT, GetAccntTitle(accntVAT), CDec(txtVAT.Text).ToString("N2"), "0.00", ""})
        End If
        If Adv_Amount <> 0 Then
            dgvEntry.Rows.Add({accntAdvance, GetAccntTitle(accntAdvance), "0.00", Adv_Amount.ToString("N2"), ""})
        End If
        If CDec(txtNet.Text) - Adv_Amount <> 0 Then
            dgvEntry.Rows.Add({accntCR, GetAccntTitle(accntCR), "0.00", (CDec(txtNet.Text) - Adv_Amount).ToString("N2"), ""})
        End If
        TotalDBCR()
    End Sub



    Private Sub dgvCVRR_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntry.CellEndEdit
        Dim rowIndex As Integer = dgvEntry.CurrentCell.RowIndex
        Dim colIndex As Integer = dgvEntry.CurrentCell.ColumnIndex
        Dim Accountcode As String
        Try
            Select Case colIndex
                Case chAccntCode.Index
                    dgvEntry.Item(chAccntTitle.Index, e.RowIndex).Value = GetAccntTitle((dgvEntry.Item(chAccntCode.Index, e.RowIndex).Value))

                    dgvEntry.Item(chParticulars.Index, e.RowIndex).Value = txtRemarks.Text
                    dgvEntry.Item(chVCECode.Index, e.RowIndex).Value = txtVCECode.Text
                    dgvEntry.Item(chVCEName.Index, e.RowIndex).Value = txtVCEName.Text
                Case chAccntTitle.Index
                    Accountcode = dgvEntry.Item(1, e.RowIndex).Value
                    Dim f As New frmCOA_Search
                    f.accttile = Accountcode
                    f.ShowDialog("AccntTitle", Accountcode)
                    dgvEntry.Rows.RemoveAt(rowIndex) 'delete active row
                    dgvEntry.Item(0, e.RowIndex).Value = f.accountcode
                    dgvEntry.Item(1, e.RowIndex).Value = f.accttile
                    f.Dispose()
                    dgvEntry.Item(4, e.RowIndex).Value = txtRemarks.Text
                    dgvEntry.Item(5, e.RowIndex).Value = txtVCECode.Text
                    dgvEntry.Item(6, e.RowIndex).Value = txtVCEName.Text
            End Select
            TotalDBCR()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetTransID() As Integer
        Dim query As String
        query = " SELECT MAX(TransID) + 1 AS TransID FROM tblAPV"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read() And Not IsDBNull(SQL.SQLDR("TransID")) Then
            Return SQL.SQLDR("TransID")
        Else
            Return 1
        End If
    End Function

    Private Sub SaveAPV()

        Try
            If cbCreditAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbCreditAccount.SelectedItem)
            End If
            Dim insertSQL As String
            activityStatus = True
            insertSQL = " INSERT INTO " & _
                    " tblAPV    (TransID, APV_No, BranchCode, BusinessCode, VCECode, DateAPV, SI_Ref, AccntCode, Amount, Discount, InputVAT, NetPurchase, Remarks, PO_Ref, WhoCreated) " & _
                    " VALUES (@TransID, @APV_No, @BranchCode, @BusinessCode, @VCECode, @DateAPV, @SI_Ref, @AccntCode, @Amount, @Discount, @InputVAT, @NetPurchase, @Remarks, @PO_Ref, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@APV_No", APVNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateAPV", dtpDocDate.Value.Date)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@Amount", IIf(txtAmount.Text = "", 0, CDec(txtAmount.Text)))
            SQL.AddParam("@Discount", IIf(txtDiscount.Text = "", 0, CDec(txtDiscount.Text)))
            SQL.AddParam("@InputVAT", IIf(txtVAT.Text = "", 0, CDec(txtVAT.Text)))
            SQL.AddParam("@NetPurchase", IIf(txtNet.Text = "", 0, CDec(txtNet.Text)))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@PO_Ref", IIf(RefID = Nothing, 0, RefID))
            SQL.AddParam("@SI_Ref", txtSINo.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim updateSQl As String
            updateSQl = " UPDATE tblPO SET Status ='Posted' WHERE TransID ='" & RefID & "' "
            SQL.ExecNonQuery(updateSQl)

            insertSQL = " INSERT INTO " & _
                        " tblJE_Header (AppDate, BranchCode, BusinessCode, RefType, RefTransID, Book, TotalDBCR, Remarks, WhoCreated) " & _
                        " VALUES(@AppDate, @BranchCode, @BusinessCode, @RefType, @RefTransID, @Book, @TotalDBCR, @Remarks, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@AppDate", dtpDocDate.Value.Date)
            SQL.AddParam("@RefType", "APV")
            SQL.AddParam("@RefTransID", TransID)
            SQL.AddParam("@Book", "Purchases")
            SQL.AddParam("@TotalDBCR", CDec(txtTotalCredit.Text))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            JETransiD = LoadJE("APV", TransID)

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
                    SQL.AddParam("@RefNo", "")
                    SQL.AddParam("@LineNumber", line)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "APV_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateAPV()
        Try
            If cbCreditAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbCreditAccount.SelectedItem)
            End If
            Dim insertSQL, updateSQL, deleteSQL As String
            activityStatus = True
            updateSQL = " UPDATE tblAPV " & _
                        " SET    APV_No = @APV_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, " & _
                        "        VCECode = @VCECode, DateAPV = @DateAPV, SI_Ref = @SI_Ref, AccntCode = @AccntCode, " & _
                        "        Amount = @Amount, Discount = @Discount, InputVAT = @InputVAT, NetPurchase = @NetPurchase, " & _
                        "        Remarks = @Remarks, PO_Ref = @PO_Ref, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@APV_No", APVNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateAPV", dtpDocDate.Value.Date)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@Amount", IIf(txtAmount.Text = "", 0, CDec(txtAmount.Text)))
            SQL.AddParam("@Discount", IIf(txtDiscount.Text = "", 0, CDec(txtDiscount.Text)))
            SQL.AddParam("@InputVAT", IIf(txtVAT.Text = "", 0, CDec(txtVAT.Text)))
            SQL.AddParam("@NetPurchase", IIf(txtNet.Text = "", 0, CDec(txtNet.Text)))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@PO_Ref", txtPORef.Text)
            SQL.AddParam("@SI_Ref", txtSINo.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            JETransiD = LoadJE("APV", TransID)

            If JETransiD = 0 Then
                insertSQL = " INSERT INTO " & _
                            " tblJE_Header (AppDate, BranchCode, BusinessCode, RefType, RefTransID, Book, TotalDBCR, Remarks, WhoCreated) " & _
                            " VALUES(@AppDate, @BranchCode, @BusinessCode, @RefType, @RefTransID, @Book, @TotalDBCR, @Remarks, @WhoCreated)"
                SQL.FlushParams()
                SQL.AddParam("@AppDate", dtpDocDate.Value.Date)
                SQL.AddParam("@RefType", "APV")
                SQL.AddParam("@RefTransID", TransID)
                SQL.AddParam("@Book", "Purchases")
                SQL.AddParam("@TotalDBCR", CDec(txtTotalCredit.Text))
                SQL.AddParam("@Remarks", txtRemarks.Text)
                SQL.AddParam("@BranchCode", BranchCode)
                SQL.AddParam("@BusinessCode", BusinessType)
                SQL.AddParam("@WhoCreated", UserID)
                SQL.ExecNonQuery(insertSQL)

                JETransiD = LoadJE("APV", TransID)
            Else
                updateSQL = " UPDATE tblJE_Header " & _
                            " SET    AppDate = @AppDate, BranchCode = @BranchCode, BusinessCode = @BusinessCode, " & _
                            "        RefType = @RefType, RefTransID = @RefTransID, Book = @Book, TotalDBCR = @TotalDBCR, " & _
                            "        Remarks = @Remarks, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                            " WHERE  JE_No = @JE_No "
                SQL.FlushParams()
                SQL.AddParam("@JE_No", JETransiD)
                SQL.AddParam("@AppDate", dtpDocDate.Value.Date)
                SQL.AddParam("@RefType", "APV")
                SQL.AddParam("@RefTransID", TransID)
                SQL.AddParam("@Book", "Purchases")
                SQL.AddParam("@TotalDBCR", CDec(txtTotalCredit.Text))
                SQL.AddParam("@Remarks", txtRemarks.Text)
                SQL.AddParam("@BranchCode", BranchCode)
                SQL.AddParam("@BusinessCode", BusinessType)
                SQL.AddParam("@WhoModified", UserID)
                SQL.ExecNonQuery(updateSQL)
            End If

            Dim line As Integer = 1

            ' DELETE ACCOUNTING ENTRIES
            deleteSQL = " DELETE FROM tblJE_Details  WHERE  JE_No = @JE_No "
            SQL.FlushParams()
            SQL.AddParam("@JE_No", JETransiD)
            SQL.ExecNonQuery(deleteSQL)

            ' INSERT NEW ENTRIES
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
                    SQL.AddParam("@RefNo", "")
                    SQL.AddParam("@LineNumber", line)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "APV_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown, txtVAT.KeyDown, txtDiscount.KeyDown, txtNet.KeyDown
        Try
            If e.KeyValue <> 8 And Not (e.KeyValue >= 48 And e.KeyValue <= 57) Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dgvEntry_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvEntry.RowsRemoved
        TotalDBCR()
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("APV_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("APV")
            If f.transID <> "" Then
                TransID = f.transID
            End If
            LoadAPV(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("APV_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            APVNo = ""

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
            EnableControl(True)

            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub


    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("APV_EDIT") Then
            msgRestricted()
        Else
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
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If txtVCECode.Text = "" Then
            Msg("Please enter VCECode!", MsgBoxStyle.Exclamation)
        ElseIf txtTotalDebit.Text <> txtTotalCredit.Text Then
            MsgBox("Please check the Debit and Credit Amount!", MsgBoxStyle.Exclamation)
        ElseIf txtAmount.Text = "" Or txtNet.Text = "" Then
            MsgBox("Please check amount!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                APVNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = APVNo
                SaveAPV()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                APVNo = txtTransNum.Text
                LoadAPV(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateAPV()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                APVNo = txtTransNum.Text
                LoadAPV(TransID)
            End If
        End If
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrint.Click
        Dim f As New frmReport_Display
        f.ShowDialog("APV", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("APV_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim updateSQL As String
                        updateSQL = " UPDATE  tblAPV SET Status ='Cancelled' WHERE TransID = @TransID "
                        SQL.FlushParams()
                        SQL.AddParam("@TransID", TransID)
                        SQL.ExecNonQuery(updateSQL)

                        updateSQL = " UPDATE  tblJE_Header SET Status ='Cancelled' WHERE RefTransID = @RefTransID  AND RefType ='APV' "
                        SQL.FlushParams()
                        SQL.AddParam("@RefTransID", TransID)
                        SQL.ExecNonQuery(updateSQL)

                        Dim insertSQL As String
                        insertSQL = " INSERT INTO tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber, OtherRef) " & _
                                    " SELECT JE_No, AccntCode, VCECode, Credit, Debit, Particulars, RefNo, LineNumber, OtherRef FROM tblJE_Details " & _
                                    " WHERE JE_No IN (SELECT DISTINCT JE_No FROM tblJE_Header WHERE RefType ='APV' AND RefTransID ='" & TransID & "') "
                        SQL.ExecNonQuery(insertSQL)
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

                        APVNo = txtTransNum.Text
                        LoadAPV(TransID)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "APV_No", APVNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If APVNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblAPV  WHERE APV_No < '" & APVNo & "' ORDER BY APV_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadAPV(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If APVNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblAPV  WHERE APV_No > '" & APVNo & "' ORDER BY APV_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadAPV(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If TransID = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadAPV(TransID)
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

    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        txtVCEName.Text = f.VCEName
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmAPV_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            ElseIf e.KeyCode = Keys.C Then
                If tsbCopy.Enabled = True Then tsbCopy.ShowDropDown()
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
            ElseIf e.KeyCode = Keys.P Then
                If tsbPrint.Enabled = True Then tsbPrint.PerformClick()
            ElseIf e.KeyCode = Keys.R Then
                If tsbReports.Enabled = True Then tsbReports.PerformClick()
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
        If cbCreditAccount.SelectedIndex = -1 Then
            Msg("Please select default Credit account first!", MsgBoxStyle.Exclamation)
        Else
            Dim f As New frmLoadTransactions
            f.cbFilter.SelectedItem = "Status"
            f.txtFilter.Text = "Closed"
            f.txtFilter.Enabled = False
            f.cbFilter.Enabled = False
            f.btnSearch.Enabled = False
            f.ShowDialog("PO")
            LoadPO(f.transID)
            f.Dispose()
        End If
    End Sub

    Private Sub TestToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TestToolStripMenuItem1.Click
        Dim f As New frmReport_Filter
        f.Report = "APV List"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub cbCreditAccount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbCreditAccount.KeyPress
        e.Handled = True
    End Sub
End Class