Public Class frmLoan_Setup
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "LM"
    Dim LoanCode As Integer = 0
    Dim Accnt_Typed As String = ""


#Region "SUBS"
    Private Sub EnableControl(ByVal Value As Boolean)
        txtLoanType.Enabled = Value
        cbCategory.Enabled = Value
        chkCash_Voucher.Enabled = Value
        txtDescription.Enabled = Value
        cbPeriod.Enabled = Value
        nupTerms.Enabled = Value
        cbMethod.Enabled = Value
        cbPayment.Enabled = Value
        cbIntMethod.Enabled = Value
        dgvCharges.Enabled = Value
        txtIntValue.Enabled = Value
        chkAmortize.Enabled = Value
        chkUnearned.Enabled = Value
        If chkUnearned.Checked = True Then
            txtIntRecTitle.Enabled = Value
            txtUnearnedTitle.Enabled = Value
        Else
            txtIntRecTitle.Enabled = False
            txtUnearnedTitle.Enabled = False
        End If
        txtAccntTitle.Enabled = Value
        txtIntIncomeTitle.Enabled = Value
    End Sub

    Private Sub LoadComboboxMethod()
        Dim dgvCB As DataGridViewComboBoxColumn
        dgvCB = dgvCharges.Columns(dgcMethod.Index)

        dgvCB.Items.Clear()
        dgvCB.Items.Add("Amount")
        dgvCB.Items.Add("Percentage")
        dgvCB.Items.Add("Range Table")
        dgvCB.Items.Add("Formula")
    End Sub

    Private Sub LoadDefaultCharges()
        Try
            LoadComboboxMethod()
            Dim query As String
            query = " SELECT  ChargeID, Description, Value, Method, Amortize, AccountTitle, ISNULL(ApplyAll,0) AS ApplyAll, ISNULL(LockValue,0) AS LockValue, RangeBasis, RangeValueType " & _
                    " FROM    tblLoan_ChargesDefault LEFT JOIN tblCOA_Master " & _
                    " ON      tblLoan_ChargesDefault.DefaultAccount = tblCOA_Master.AccountCode " & _
                    " AND     tblCOA_Master.Status ='Active'  " & _
                    " WHERE   tblLoan_ChargesDefault.Status ='Active'  " & _
                    " ORDER BY SortNum "
            SQL.ReadQuery(query)
            dgvCharges.Rows.Clear()
            Dim rowId As Integer = 0
            While SQL.SQLDR.Read
                dgvCharges.Rows.Add({SQL.SQLDR("ChargeID"), SQL.SQLDR("ApplyAll"), SQL.SQLDR("Description").ToString, SQL.SQLDR("Value").ToString, _
                                   SQL.SQLDR("Method").ToString, SQL.SQLDR("Amortize").ToString, SQL.SQLDR("AccountTitle").ToString, _
                                   SQL.SQLDR("ApplyAll"), SQL.SQLDR("LockValue"), SQL.SQLDR("RangeBasis").ToString, SQL.SQLDR("RangeValueType").ToString})
                If dgvCharges.Rows(rowId).Cells(chInclude.Index).Value = True Then
                    dgvCharges.Rows(rowId).ReadOnly = False
                    dgvCharges.Rows(rowId).DefaultCellStyle.BackColor = Color.White
                    If dgvCharges.Rows(rowId).Cells(chLocked.Index).Value = True Then
                        dgvCharges.Rows(rowId).Cells(dgcValue.Index).ReadOnly = True
                        dgvCharges.Rows(rowId).Cells(dgcMethod.Index).ReadOnly = True
                        dgvCharges.Rows(rowId).DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
                    Else
                        dgvCharges.Rows(rowId).Cells(dgcValue.Index).ReadOnly = False
                        dgvCharges.Rows(rowId).Cells(dgcMethod.Index).ReadOnly = False
                        dgvCharges.Rows(rowId).DefaultCellStyle.BackColor = Color.White
                    End If
                Else
                    dgvCharges.Rows(rowId).ReadOnly = True
                    dgvCharges.Rows(rowId).DefaultCellStyle.BackColor = Color.Gray
                End If
                If dgvCharges.Rows(rowId).Cells(chAll.Index).Value = True Then
                    dgvCharges.Rows(rowId).Cells(chInclude.Index).ReadOnly = True
                Else
                    dgvCharges.Rows(rowId).Cells(chInclude.Index).ReadOnly = False
                End If

                rowId += 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadLoanType()
        Dim query As String
        query = " SELECT LoanCode, LoanType " & _
                " FROM   tblLoan_Type " & _
                " WHERE  Status ='Active'  "
        lvLoanType.Items.Clear()
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            lvLoanType.Items.Add(SQL.SQLDR("LoanCode").ToString)
            lvLoanType.Items(lvLoanType.Items.Count - 1).SubItems.Add((SQL.SQLDR("LoanType").ToString))
        End While
    End Sub

    Private Sub LoadComboboxAccount()
        Dim dgvCB As DataGridViewComboBoxColumn
        dgvCB = dgvCharges.Columns(dgcAccount.Index)
        Dim query As String
        query = " SELECT   AccountTitle " & _
                " FROM     tblCOA_Master " & _
                " ORDER BY AccountTitle"
        SQL.ReadQuery(query)
        dgvCB.Items.Clear()
        While SQL.SQLDR.Read
            dgvCB.Items.Add(SQL.SQLDR("AccountTitle").ToString)
            dgvCB.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        End While
    End Sub

    Private Function LoanExistID(ByVal Type As String) As Integer
        Dim query As String
        query = " SELECT LoanCode FROM tblLoan_Type WHERE LoanType = @LoanType "
        SQL.FlushParams()
        SQL.AddParam("@LoanType", Type)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("LoanCode")
        Else
            Return 0
        End If
    End Function

    Private Sub LoadLoanInfo(ByVal LoanCode As Integer)
        EnableControl(False)
        Dim query As String
        query = " SELECT LoanType, Category, Method, InterestPeriod, Terms, PaymentType, SetupUnearned, " & _
                "        LoanAccount, IntIncomeAccount, UnearnedAccount, IntRecAccount, APR_Method, APR_Value, AmortizeInterest, CashVoucher" & _
                " FROM   tblLoan_Type " & _
                " WHERE  Status ='Active' AND LoanCode ='" & LoanCode & "'  "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtLoanType.Text = SQL.SQLDR("LoanType").ToString
            cbCategory.Text = SQL.SQLDR("Category").ToString
            cbMethod.SelectedItem = SQL.SQLDR("Method").ToString
            cbPeriod.SelectedItem = SQL.SQLDR("InterestPeriod").ToString
            nupTerms.Value = SQL.SQLDR("Terms").ToString
            cbPayment.SelectedItem = SQL.SQLDR("PaymentType").ToString
            chkCash_Voucher.Checked = IIf(SQL.SQLDR("CashVoucher").ToString = "True", True, False)
            txtAccntCode.Text = SQL.SQLDR("LoanAccount").ToString
            txtIntIncomeCode.Text = SQL.SQLDR("IntIncomeAccount").ToString
            txtUnearnedCode.Text = SQL.SQLDR("UnearnedAccount").ToString
            txtIntRecCode.Text = SQL.SQLDR("IntRecAccount").ToString
            cbIntMethod.SelectedItem = SQL.SQLDR("APR_Method").ToString
            txtIntValue.Text = SQL.SQLDR("APR_Value").ToString
            chkAmortize.Checked = SQL.SQLDR("AmortizeInterest").ToString
            chkUnearned.Checked = SQL.SQLDR("SetupUnearned").ToString
            txtAccntTitle.Text = GetAccntTitle(txtAccntCode.Text)
            txtIntIncomeTitle.Text = GetAccntTitle(txtIntIncomeCode.Text)
            txtUnearnedTitle.Text = GetAccntTitle(txtUnearnedCode.Text)
            txtIntRecTitle.Text = GetAccntTitle(txtIntRecCode.Text)
            LoadLoanCharges(LoanCode)
        Else
            ClearText()
        End If
    End Sub

    Private Sub UpdateLoanType()
        Try
            Dim insertSQL As String
            insertSQL = " UPDATE  tblLoan_Type" & _
                        " SET     LoanType = @LoanType, Category = @Category, Description = @Description, Method = @Method, InterestPeriod = @InterestPeriod, Terms = @Terms, " & _
                        "         LoanAccount = @LoanAccount, IntIncomeAccount = @IntIncomeAccount, UnearnedAccount = @UnearnedAccount, IntRecAccount = @IntRecAccount, " & _
                        "         SetupUnearned = @SetupUnearned, APR_Method = @APR_Method, APR_Value = @APR_Value, AmortizeInterest = @AmortizeInterest, PaymentType = @PaymentType " & _
                        " WHERE   LoanCode = @LoanCode "
            SQL.FlushParams()
            SQL.AddParam("@LoanCode", LoanCode)
            SQL.AddParam("@LoanType", txtLoanType.Text)
            SQL.AddParam("@Category", cbCategory.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@Method", cbMethod.SelectedItem)
            SQL.AddParam("@InterestPeriod", cbPeriod.SelectedItem)
            SQL.AddParam("@Terms", nupTerms.Value)
            SQL.AddParam("@LoanAccount", txtAccntCode.Text)
            SQL.AddParam("@IntIncomeAccount", txtIntIncomeCode.Text)
            SQL.AddParam("@UnearnedAccount", txtUnearnedCode.Text)
            SQL.AddParam("@IntRecAccount", txtIntRecCode.Text)
            SQL.AddParam("@APR_Method", cbIntMethod.SelectedItem)
            SQL.AddParam("@APR_Value", txtIntValue.Text)
            SQL.AddParam("@AmortizeInterest", chkAmortize.Checked)
            SQL.AddParam("@SetupUnearned", chkUnearned.Checked)
            SQL.AddParam("@PaymentType", cbPayment.SelectedItem)
            SQL.AddParam("@Cash_Voucher", IIf(chkCash_Voucher.Checked = True, "True", "False"))
            SQL.ExecNonQuery(insertSQL)
            SaveLoanCharges(LoanCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub LoadLoanCharges(ByVal LoanCode As Integer)
        Dim query As String
        query = "  SELECT   ChargeID, Value, Method, Amortize, AccountTitle  " & _
                "  FROM     tblLoan_Charges  LEFT JOIN tblCOA_Master   " & _
                "  ON       tblLoan_Charges.DefaultAccount = tblCOA_Master.AccountCode   " & _
                "  WHERE    LoanCode ='" & LoanCode & "'   " & _
                "  ORDER BY ChargeID "
        SQL.ReadQuery(query)
        For Each item As DataGridViewRow In dgvCharges.Rows
            item.Cells(chInclude.Index).Value = False
            item.DefaultCellStyle.BackColor = Color.Gray

        Next
        While SQL.SQLDR.Read
            For Each item As DataGridViewRow In dgvCharges.Rows
                If item.Cells(dgcID.Index).Value = SQL.SQLDR("ChargeID") Then
                    item.Cells(chInclude.Index).Value = True
                    item.Cells(dgcValue.Index).Value = SQL.SQLDR("Value").ToString
                    item.Cells(dgcMethod.Index).Value = SQL.SQLDR("Method").ToString
                    item.Cells(dgcAmort.Index).Value = SQL.SQLDR("Amortize")
                    item.Cells(dgcAccount.Index).Value = SQL.SQLDR("AccountTitle").ToString
                    item.DefaultCellStyle.BackColor = Color.White
                    If item.Cells(chInclude.Index).Value = True Then
                        item.ReadOnly = False
                        item.DefaultCellStyle.BackColor = Color.White
                        If item.Cells(chLocked.Index).Value = True Then
                            item.Cells(dgcValue.Index).ReadOnly = True
                            item.Cells(dgcMethod.Index).ReadOnly = True
                            item.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
                        Else
                            item.Cells(dgcValue.Index).ReadOnly = False
                            item.Cells(dgcMethod.Index).ReadOnly = False
                            item.DefaultCellStyle.BackColor = Color.White
                        End If
                    Else
                        item.ReadOnly = True
                        item.DefaultCellStyle.BackColor = Color.Gray
                    End If
                    If item.Cells(chAll.Index).Value = True Then
                        item.Cells(chInclude.Index).ReadOnly = True
                    Else
                        item.Cells(chInclude.Index).ReadOnly = False
                    End If
                    Exit For
                End If
            Next
        End While
    End Sub
#End Region

#Region "CONTROL EVENTS"
    Private Sub frmLoanMaintenance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadDefaultCharges()
        LoadLoanType()
        LoadComboboxAccount()
        tsbNew.Enabled = True
        tsbEdit.Enabled = False
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
        EnableControl(False)
    End Sub

    Private Sub txtAccntTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAccntTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtAccntTitle.Text)
                txtAccntCode.Text = f.accountcode
                txtAccntTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub frmLoan_Maintenance_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.S Then
                If tsbSave.Enabled = True Then tsbSave.PerformClick()
            ElseIf e.KeyCode = Keys.N Then
                If tsbNew.Enabled = True Then tsbNew.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                If tsbEdit.Enabled = True Then tsbEdit.PerformClick()
            ElseIf e.KeyCode = Keys.D Then
                If tsbDelete.Enabled = True Then tsbDelete.PerformClick()
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

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("LM_ADD") Then
            msgRestricted()
        Else
            ClearText()
            LoanCode = 0

            LoadDefaultCharges()
            If lvLoanType.SelectedItems.Count > 0 Then
                lvLoanType.SelectedItems(0).Selected = False
            End If

            ' Toolstrip Buttons
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbClose.Enabled = True
            tsbExit.Enabled = False

            EnableControl(True)
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("LM_EDIT") Then
            msgRestricted()
        Else
            EnableControl(True)
            ' Toolstrip Buttons
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True
            tsbExit.Enabled = False
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If txtLoanType.Text = "" Then
            MsgBox("Please enter loan type", MsgBoxStyle.Exclamation)
        ElseIf LoanCode <> 0 AndAlso LoanExistID(txtLoanType.Text) <> LoanCode AndAlso LoanExistID(txtLoanType.Text) <> 0 Then
            MsgBox("Loan type already exist!", MsgBoxStyle.Exclamation)
        ElseIf LoanCode = 0 Then
            If MsgBox("Saving New Item, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                LoanCode = GetLoanCode()
                SaveLoanType()
                MsgBox("Loan Type (" & txtLoanType.Text & ") Added Succesfully", MsgBoxStyle.Information)
                LoadLoanType()
                ClearText()
            End If
        Else
            If MsgBox("Updating Item Information, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateLoanType()
                MsgBox("Loan Type (" & txtLoanType.Text & ") Updated Succesfully", MsgBoxStyle.Information)
                LoadLoanType()
                ClearText()
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If LoanCode = 0 Then
            tsbNew.PerformClick()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbDelete.Enabled = False
        Else
            LoadLoanInfo(LoanCode)
            tsbEdit.Enabled = True
            tsbDelete.Enabled = True
        End If
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
    End Sub

    Private Sub lvLoanType_Click(sender As System.Object, e As System.EventArgs) Handles lvLoanType.Click, lvLoanType.SelectedIndexChanged
        Try
            If lvLoanType.SelectedItems.Count = 1 Then
                LoadDefaultCharges()
                LoanCode = lvLoanType.SelectedItems(0).SubItems(chID.Index).Text
                LoadLoanInfo(LoanCode)

                ' TOOLSTRIP BUTTONS
                tsbNew.Enabled = True
                tsbEdit.Enabled = True
                tsbSave.Enabled = False
                tsbDelete.Enabled = True
                tsbClose.Enabled = False
                tsbExit.Enabled = True
                EnableControl(False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub LoadComboboxType2(ByVal RowID As Integer, Selected As String)
        Dim dgvCB As DataGridViewComboBoxCell
        dgvCB = dgvCharges.Rows(RowID).Cells(dgcType.Index)
        dgvCB.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        Dim query As String
        query = " SELECT  DISTINCT Description " & _
                " FROM    tblLoan_ChargesDefault WHERE   ApplyAll = 0"
        SQL.ReadQuery(query)
        If Selected <> "" Then
            dgvCB.Value = Nothing
            dgvCB.Items.Clear()
            dgvCB.Items.Add("")
            dgvCB.Items.Add(Selected)
        Else
            dgvCB.Items.Clear()
            dgvCB.Items.Add("")
        End If

        While SQL.SQLDR.Read
            Dim contains As Boolean = False
            For Each row As DataGridViewRow In dgvCharges.Rows
                If row.Cells(dgcType.Index).Value = SQL.SQLDR("Description").ToString Then
                    contains = True
                    Exit For
                End If
            Next
            If contains = False Then
                dgvCB.Items.Add(SQL.SQLDR("Description").ToString)
            End If
        End While

    End Sub

    Private Sub LoadAccountTitle()
        Dim query As String
        query = " SELECT DISTINCT AccountTitle FROM tblCOA_Master WHERE AccountTitle IS NOT NULL "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read

        End While
    End Sub


    Private Sub ClearText()
        txtLoanType.Clear()
        cbPeriod.SelectedIndex = 0
        nupTerms.Value = 1
        cbMethod.SelectedIndex = 0
        txtDescription.Clear()
        cbPayment.SelectedIndex = 0

        txtAccntCode.Clear()
        txtAccntTitle.Clear()
        txtIntIncomeCode.Clear()
        txtIntIncomeTitle.Clear()
        txtUnearnedCode.Clear()
        txtUnearnedTitle.Clear()
        txtIntRecCode.Clear()
        txtIntRecTitle.Clear()

        txtIntValue.Clear()
        cbIntMethod.SelectedItem = "Percentage"
        chkAmortize.Checked = True
        chkUnearned.Checked = True
    End Sub

    Private Sub SaveLoanType()
        Try
            Dim insertSQL As String
            insertSQL = " INSERT INTO  " & _
                        " tblLoan_Type(LoanCode, LoanType, Category, Description, Method, InterestPeriod, Terms, " & _
                        "              LoanAccount, IntIncomeAccount, UnearnedAccount, IntRecAccount, APR_Method, APR_Value, AmortizeInterest " & _
                        "              SetupUnearned, PaymentType, CashVoucher, Status, WhoCreated) " & _
                        " VALUES(@LoanCode, @LoanType, @Category, @Description, @Method, @InterestPeriod, @Terms, " & _
                        "              @LoanAccount, @IntIncomeAccount, @UnearnedAccount, @IntRecAccount, @APR_Method, @APR_Value, @AmortizeInterest " & _
                        "              @SetupUnearned, @PaymentType, @CashVoucher, @Status, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@LoanCode", loanCode)
            SQL.AddParam("@LoanType", txtLoanType.Text)
            SQL.AddParam("@Category", cbCategory.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@Method", cbMethod.SelectedItem)
            SQL.AddParam("@InterestPeriod", cbPeriod.SelectedItem)
            SQL.AddParam("@Terms", nupTerms.Value)
            SQL.AddParam("@LoanAccount", txtAccntCode.Text)
            SQL.AddParam("@IntIncomeAccount", txtIntIncomeCode.Text)
            SQL.AddParam("@UnearnedAccount", txtUnearnedCode.Text)
            SQL.AddParam("@IntRecAccount", txtIntRecCode.Text)
            SQL.AddParam("@APR_Method", cbIntMethod.SelectedItem)
            SQL.AddParam("@APR_Value", txtIntValue.Text)
            SQL.AddParam("@AmortizeInterest", chkAmortize.Checked)
            SQL.AddParam("@PaymentType", cbPayment.SelectedItem)
            SQL.AddParam("@SetupUnearned", chkUnearned.Checked)
            SQL.AddParam("@CashVoucher", IIf(chkCash_Voucher.Checked = True, "True", "False"))
            SQL.AddParam("@Status", "Active")
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
            SaveLoanCharges(loanCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub SaveLoanCharges(ByVal LoanCode As Integer)
        Try
            Dim deleteSQL As String
            deleteSQL = " DELETE FROM tblLoan_Charges WHERE LoanCode =  " & LoanCode & ""
            SQL.ExecNonQuery(deleteSQL)
            For Each item As DataGridViewRow In dgvCharges.Rows
                If item.Cells(chInclude.Index).Value = True Then
                    Dim insertSQL As String
                    Dim Account As String = GetAccntCode(item.Cells(dgcAccount.Index).Value)
                    insertSQL = " INSERT INTO " & _
                                " tblLoan_Charges (ChargeID, LoanCode, Value, Method, Amortize, DefaultAccount, DefaultValue) " & _
                                " VALUES (@ChargeID, @LoanCode, @Value, @Method, @Amortize, @DefaultAccount, @DefaultValue)"
                    SQL.FlushParams()
                    SQL.AddParam("ChargeID", item.Cells(dgcID.Index).Value)
                    SQL.AddParam("LoanCode", LoanCode)
                    SQL.AddParam("Value", item.Cells(dgcValue.Index).Value)
                    SQL.AddParam("Method", item.Cells(dgcMethod.Index).Value)
                    SQL.AddParam("Amortize", item.Cells(dgcAmort.Index).Value)
                    SQL.AddParam("DefaultAccount", Account)
                    SQL.AddParam("DefaultValue", item.Cells(dgcValue.Index).Value)
                    SQL.ExecNonQuery(insertSQL)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Function GetLoanCode() As Integer
        Dim query As String
        query = " SELECT MAX(LoanCode) + 1 AS LoanCode FROM tblLoan_Type "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("LoanCode")) Then
            Return SQL.SQLDR("LoanCode")
        Else
            Return 1
        End If
    End Function


    Private Sub dgvCharges_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvCharges.CellValidating
        Dim comboBoxColumn As DataGridViewComboBoxColumn = dgvCharges.Columns(dgcAccount.Index)
        If (e.ColumnIndex = comboBoxColumn.DisplayIndex) Then
            Accnt_Typed = e.FormattedValue
        End If
    End Sub

    Private Sub dgvCharges_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgvCharges.CurrentCellDirtyStateChanged
        If dgvCharges.IsCurrentCellDirty Then
            dgvCharges.CommitEdit(DataGridViewDataErrorContexts.Commit)
            If dgvCharges.CurrentCell.RowIndex > -1 And dgvCharges.CurrentCell.ColumnIndex > 0 Then
                If dgvCharges.CurrentCell.ColumnIndex = chInclude.Index Then
                    If dgvCharges.Item(dgvCharges.CurrentCell.ColumnIndex, dgvCharges.CurrentCell.RowIndex).Value = True Then
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.White
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).ReadOnly = False
                        If dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(chLocked.Index).Value = True Then
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcValue.Index).ReadOnly = True
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcMethod.Index).ReadOnly = True
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcValue.Index).Style.BackColor = Color.LightGray
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcMethod.Index).Style.BackColor = Color.LightGray
                        Else
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcValue.Index).ReadOnly = False
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcMethod.Index).ReadOnly = False
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcValue.Index).Style.BackColor = Color.White
                            dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcMethod.Index).Style.BackColor = Color.White
                        End If
                    Else
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Gray
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).ReadOnly = True
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcValue.Index).Style.BackColor = Color.Gray
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(dgcMethod.Index).Style.BackColor = Color.Gray
                    End If
                    If dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(chAll.Index).Value = True Then
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(chInclude.Index).ReadOnly = True
                    Else
                        dgvCharges.Rows(dgvCharges.CurrentCell.RowIndex).Cells(chInclude.Index).ReadOnly = False
                    End If
                    dgvCharges.BeginEdit(True)
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCharges.EditingControlShowing
        If dgvCharges.CurrentCell.RowIndex >= 0 Then
            If dgvCharges.CurrentCell.ColumnIndex = dgcValue.Index Then
                AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
            ElseIf dgvCharges.CurrentCell.ColumnIndex = dgcAccount.Index Then
                If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
                    CType(e.Control, ComboBox).DropDownStyle = ComboBoxStyle.DropDown
                    CType(e.Control, ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems
                    CType(e.Control, ComboBox).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
                End If
            End If

        End If
    End Sub

    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If dgvCharges.CurrentCell.ColumnIndex >= 0 And dgvCharges.CurrentCell.RowIndex >= 0 Then
            If dgvCharges.Rows(dgvCharges.CurrentRow.Index).Cells(dgcMethod.Index).Value = "Percent" Or dgvCharges.Rows(dgvCharges.CurrentRow.Index).Cells(dgcMethod.Index).Value = "Fixed Amount" Then
                If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then
                    e.Handled = True
                End If
                If Not (Char.IsDigit(CChar(CStr(e.KeyChar)))) Then
                    e.Handled = True
                End If
                If e.KeyChar = "" Then
                    e.Handled = False
                End If
                If e.KeyChar = "." Then
                    If dgvCharges.CurrentCell.Value.ToString.Contains(".") = False Then
                        e.Handled = False
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub dgvCharges_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCharges.CellEndEdit
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = dgcAccount.Index Then
                Dim cellCB As DataGridViewComboBoxCell = dgvCharges.Rows(e.RowIndex).Cells(dgcAccount.Index)
                If Not cellCB.Items.Contains(Accnt_Typed) Then
                    Dim f As New frmCOA_Search
                    f.ShowDialog("AccountTitle", Accnt_Typed)
                    If Not f.accountcode Is Nothing Then
                        dgvCharges.Rows(e.RowIndex).Cells(dgcAccount.Index).Value = f.accttile
                    End If
                End If
                Accnt_Typed = ""
                SendKeys.Send("{up}")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmLoan_Charges.ShowDialog()
        frmLoan_Charges.Dispose()
        LoadDefaultCharges()
        LoadLoanCharges(LoanCode)
    End Sub

    Private Sub dgvCharges_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvCharges.DataError
        Try
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub chkUnearned_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUnearned.CheckedChanged
        If disableEvent = False Then
            If chkUnearned.Checked = True Then
                txtUnearnedTitle.Enabled = True
                txtIntRecTitle.Enabled = True
            Else
                txtUnearnedTitle.Enabled = False
                txtIntRecTitle.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtIntIncomeTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtIntIncomeTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtIntIncomeTitle.Text)
                txtIntIncomeCode.Text = f.accountcode
                txtIntIncomeTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtUnearnedTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUnearnedTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtUnearnedTitle.Text)
                txtUnearnedCode.Text = f.accountcode
                txtUnearnedTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtIntRecTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtIntRecTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtIntRecTitle.Text)
                txtIntRecCode.Text = f.accountcode
                txtIntRecTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub
End Class