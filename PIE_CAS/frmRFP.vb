Public Class frmRFP
    Dim TransID, RefID, JETransiD As String
    Dim RFPNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "RFP"
    Dim ColumnPK As String = "RFP_No"
    Dim DBTable As String = "tblRFP"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim APV_ID, ADV_ID As Integer
    Dim bankID As Integer
    Dim tempBranch As String
    Dim controlDisabled As Boolean = False

    Public Overloads Function ShowDialog(ByVal DocNumber As String) As Boolean
        TransID = DocNumber
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub Disbursement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            LoadBranches()
            LoadBankList()
            If TransID <> "" Then
                LoadRFP(TransID)
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
            EnableControl(False)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
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

    Private Sub LoadBranches(Optional ByVal SelectedIndex As Integer = -1)
        Try
            If SelectedIndex = -1 Then
                Dim query As String
                query = " SELECT BranchCode + ' - ' + Description AS BranchCode FROM tblBranch WHERE Status ='Active' "
                SQL.ReadQuery(query)
                cbBranch.Items.Clear()
                cbBranch.Items.Add("Multiple Branch")
                While SQL.SQLDR.Read
                    cbBranch.Items.Add(SQL.SQLDR("BranchCode").ToString)
                End While
                If cbBranch.Items.Count > 0 Then
                    cbBranch.SelectedIndex = 0
                End If
            Else
                Dim dgvCB As DataGridViewComboBoxCell
                dgvCB = dgvRecords.Item(dgcBranch.Index, SelectedIndex)
                dgvCB.Items.Clear()
                ' ADD ALL WHSEc
                Dim query As String
                query = " SELECT BranchCode AS BranchCode FROM tblBranch WHERE Status ='Active' "
                SQL.ReadQuery(query)
                dgvCB.Items.Clear()
                While SQL.SQLDR.Read
                    dgvCB.Items.Add(SQL.SQLDR("BranchCode").ToString)
                End While
                dgvCB.Items.Add("")
            End If

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try

    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCEName.Enabled = Value
        btnSearchVCE.Enabled = Value
        dgvRecords.AllowUserToDeleteRows = Value
        txtPeriod.Enabled = Value
        If Value = True Then
            dgvRecords.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvRecords.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        txtRemarks.Enabled = Value
        cbBranch.Enabled = Value
        dtpDocDate.Enabled = Value
        chkEWT.Enabled = Value

        ' CASH IN BANK CONTROLS
        cbBank.Enabled = Value
        txtBankRef.Enabled = Value
        dtpBankRefDate.Enabled = Value


        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
        controlDisabled = Not Value
    End Sub

    Private Sub LoadRFPDetails(ByVal ID As Integer)
        Dim query As String
        query = " SELECT TransID, Ref_No, RecordDate, CodePayee, RecordPayee, OR_Ref, TIN, Type, ISNULL(Category,'') AS Category, Particulars, " & _
                "        Amount, VATable, InputVAT, BaseAmount, BranchCode, ISNULL(EWT,0) AS EWT, ISNULL(EWTRate,0) AS EWTRate, ISNULL(EWTAmount,0) AS EWTAmount " & _
                " FROM   tblRFP_Details " & _
                " WHERE  TransID = '" & ID & "' " & _
                " ORDER BY LineNum "
        SQL.ReadQuery(query)
        dgvRecords.Rows.Clear()
        While SQL.SQLDR.Read
            dgvRecords.Rows.Add(SQL.SQLDR("BranchCode").ToString, SQL.SQLDR("RecordDate").ToString, SQL.SQLDR("Ref_No").ToString, SQL.SQLDR("CodePayee").ToString, SQL.SQLDR("RecordPayee").ToString, SQL.SQLDR("OR_Ref").ToString, _
                               SQL.SQLDR("TIN").ToString, CDec(SQL.SQLDR("Amount")).ToString("N2"), SQL.SQLDR("VATable"), SQL.SQLDR("EWT"), SQL.SQLDR("Category").ToString, SQL.SQLDR("EWTRate"), SQL.SQLDR("Type").ToString, SQL.SQLDR("Particulars").ToString, _
                              CDec(SQL.SQLDR("InputVAT")).ToString("N2"), CDec(SQL.SQLDR("BaseAmount")).ToString("N2"), CDec(SQL.SQLDR("EWTAmount")).ToString("N2"))

        End While
        RefreshDGC()

        ComputeTotal()
    End Sub

    Private Sub RefreshDGC()
        For i As Integer = 0 To dgvRecords.Rows.Count - 1
            LoadType(i)
            LoadBranches(i)
            LoadEWT(i)
        Next
    End Sub

    Private Sub LoadType(Optional ByVal SelectedIndex As Integer = 0)
        Try
            Dim dgvCB As DataGridViewComboBoxCell
            dgvCB = dgvRecords.Item(dgcType.Index, SelectedIndex)
            dgvCB.Items.Clear()
            ' ADD ALL WHSEc
            Dim query As String
            query = " SELECT Type FROM tblRFP_Type "
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            While SQL.SQLDR.Read
                dgvCB.Items.Add(SQL.SQLDR("Type").ToString)
            End While
            dgvCB.Items.Add("")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadEWT(Optional ByVal SelectedIndex As Integer = 0)
        Try
            Dim dgvCB As DataGridViewComboBoxCell
            dgvCB = dgvRecords.Item(dgcCategory.Index, SelectedIndex)
            dgvCB.Items.Clear()
            ' ADD ALL WHSEc
            Dim query As String
            query = "  SELECT TaxAlias FROM tblTaxMaintenance WHERE TaxType ='EWT' AND Status ='Active' "
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            While SQL.SQLDR.Read
                dgvCB.Items.Add(SQL.SQLDR("TaxAlias").ToString)
            End While
            dgvCB.Items.Add("")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadRFP(ByVal ID As String)
        Dim query As String
        query = " SELECT  TransID, RFP_No, tblRFP.VCECode, VCEName, DateRFP, Amount, InputVAT, BaseAmount," & _
                "         PeriodCovered, Remarks, tblRFP.Status, " & _
                "         CASE WHEN tblBranch.Description IS NOT NULL " & _
                "              THEN tblRFP.BranchCode + ' - ' + tblBranch.Description " & _
                "              ELSE 'Multiple Branch' " & _
                "         END AS Branch, ISNULL(EWT,0) AS EWT " & _
                " FROM    tblRFP LEFT JOIN tblVCE_Master " & _
                " ON      tblRFP.VCECode = tblVCE_Master.VCECode " & _
                " LEFT JOIN tblBranch  " & _
                " ON		tblRFP.BranchCode = tblBranch.BranchCode " & _
                " WHERE   TransID = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            RFPNo = SQL.SQLDR("RFP_No").ToString
            txtTransNum.Text = RFPNo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            dtpDocDate.Value = SQL.SQLDR("DateRFP")
            txtAmount.Text = CDec(SQL.SQLDR("Amount")).ToString("N2")
            txtInputVAT.Text = CDec(SQL.SQLDR("InputVAT")).ToString("N2")
            txtBaseAmount.Text = CDec(SQL.SQLDR("BaseAmount")).ToString("N2")
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            cbBranch.SelectedItem = SQL.SQLDR("Branch").ToString

            chkEWT.Checked = SQL.SQLDR("EWT")
            LoadRFPRef(TransID)
            LoadRFPDetails(TransID)

            dgvRecords.ClearSelection()
            ' TOOLSTRIP BUTTONS
            If txtStatus.Text = "Cancelled" Then
                tsbEdit.Enabled = False
                tsbCancel.Enabled = False
            ElseIf txtStatus.Text = "Closed" Then
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
            EnableControl(False)
        Else
            ClearText()
        End If
    End Sub

    Private Sub LoadRFPRef(ByVal RFPID As Integer)
        Dim query As String
        query = " SELECT tblMasterfile_Bank.Bank_ID, CAST(tblMasterfile_Bank.Bank_ID AS nvarchar) + '-' + Bank + ' ' + Branch + CASE WHEN Account_No <> '' THEN ' (' + Account_No  +  ')' ELSE '' END AS Bank, " & _
                " 	     RefNo, RefDate, RefAmount, tblRFP_BankRef.Status " & _
                " FROM   tblRFP_BankRef INNER JOIN tblMasterfile_Bank " & _
                " ON     tblRFP_BankRef.BankID = tblMasterfile_Bank.Bank_ID " & _
                " WHERE  TransID ='" & RFPID & "' AND tblRFP_BankRef.Status <> 'Cancelled' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            disableEvent = True
            bankID = SQL.SQLDR("Bank_ID").ToString
            txtBankRef.Text = SQL.SQLDR("RefNo").ToString
            dtpBankRefDate.Value = SQL.SQLDR("RefDate")
            txtBankRefAmount.Text = CDec(SQL.SQLDR("RefAmount")).ToString("N2")
            cbBank.SelectedItem = SQL.SQLDR("Bank").ToString
            disableEvent = False
        Else
            disableEvent = True
            bankID = 0
            txtBankRef.Clear()
            dtpBankRefDate.Value = dtpDocDate.Value.Date
            txtBankRefAmount.Text = txtAmount.Text
            cbBank.SelectedItem = -1
            disableEvent = False
        End If
    End Sub

    Private Sub dgvRecords_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRecords.EditingControlShowing
        ' GET THE EDITING CONTROL
        Dim editingComboBox As ComboBox = TryCast(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            ' REMOVE AN EXISTING EVENT-HANDLER TO AVOID ADDING MULTIPLE HANDLERS WHEN THE EDITING CONTROL IS REUSED
            RemoveHandler editingComboBox.SelectionChangeCommitted, New EventHandler(AddressOf editingComboBox_SelectionChangeCommitted)

            ' ADD THE EVENT HANDLER
            AddHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted

            ' PREVENT THIS HANDLER FROM FIRING TWICE
            RemoveHandler dgvRecords.EditingControlShowing, AddressOf dgvRecords_EditingControlShowing
        End If
    End Sub

    Private Sub editingComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        Try
            Dim rowIndex, columnIndex As Integer
            'Get the editing control
            If editingComboBox Is Nothing Then Exit Sub
            'Show your Message Boxes
            If editingComboBox.SelectedIndex <> -1 Then
                If dgvRecords.SelectedCells.Count > 0 Then
                    rowIndex = dgvRecords.SelectedCells(0).RowIndex
                    columnIndex = dgvRecords.SelectedCells(0).ColumnIndex
                    If dgvRecords.SelectedCells.Count > 0 Then
                        Dim tempCell As DataGridViewComboBoxCell = dgvRecords.Item(columnIndex, rowIndex)
                        Dim temp As String = editingComboBox.Text
                        dgvRecords.Item(columnIndex, rowIndex).Selected = False
                        dgvRecords.EndEdit(True)
                        tempCell.Value = temp
                        If columnIndex = dgcCategory.Index Then
                            dgvRecords.Item(dgcEWTRate.Index, rowIndex).Value = GetEWTRate("TaxAlias", tempCell.Value)
                            ComputeTaxes(rowIndex)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
            RemoveHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted
            'Re-enable the EditingControlShowing event so the above can take place.
            AddHandler dgvRecords.EditingControlShowing, AddressOf dgvRecords_EditingControlShowing
        End Try


    End Sub

    Private Function GetEWTRate(ByRef Type As String, Value As String) As Decimal
        Try
            Dim query As String
            query = " SELECT TaxRate FROM tblTaxMaintenance WHERE Status ='Active' AND TaxType ='EWT' AND " & Type & " = @Value "
            SQL.FlushParams()
            SQL.AddParam("@Value", Value)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return SQL.SQLDR("TaxRate")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            SQL.FlushParams()
        End Try
    End Function

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

    Private Sub dgvManual_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvRecords.RowsRemoved
        Try
            ComputeTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ComputeTotal()
        Try
            ' COMPUTE TOTAL AMOUNT
            Dim a As Double = 0
            For i As Integer = 0 To dgvRecords.Rows.Count - 1
                If dgvRecords.Item(dgcPayee.Index, i).Value <> "" AndAlso Val(dgvRecords.Item(dgcAmount.Index, i).Value) <> 0 Then
                    a = a + Double.Parse(dgvRecords.Item(dgcAmount.Index, i).Value).ToString("N2")
                End If
            Next
            txtAmount.Text = a.ToString("N2")

            ' COMPUTE TOTAL INPUT VAT 
            Dim b As Double = 0
            For i As Integer = 0 To dgvRecords.Rows.Count - 1
                If dgvRecords.Item(dgcPayee.Index, i).Value <> "" AndAlso Val(dgvRecords.Item(dgcInputVAT.Index, i).Value) <> 0 Then
                    b = b + Double.Parse(dgvRecords.Item(dgcInputVAT.Index, i).Value).ToString("N2")
                End If
            Next
            txtInputVAT.Text = b.ToString("N2")

            ' COMPUTE TOTAL BASE AMOUNT
            Dim c As Double = 0
            For i As Integer = 0 To dgvRecords.Rows.Count - 1
                If dgvRecords.Item(dgcPayee.Index, i).Value <> "" AndAlso Val(dgvRecords.Item(dgcBase.Index, i).Value) <> 0 Then
                    c = c + Double.Parse(dgvRecords.Item(dgcBase.Index, i).Value).ToString("N2")
                End If
            Next
            txtBaseAmount.Text = c.ToString("N2")

            ' COMPUTE TOTAL BASE AMOUNT
            Dim d As Double = 0
            For i As Integer = 0 To dgvRecords.Rows.Count - 1
                If dgvRecords.Item(dgcPayee.Index, i).Value <> "" AndAlso Val(dgvRecords.Item(dgcEWTamt.Index, i).Value) <> 0 Then
                    d = d + Double.Parse(dgvRecords.Item(dgcEWTamt.Index, i).Value).ToString("N2")
                End If
            Next
            txtEWTAmount.Text = d.ToString("N2")

            txtBankRefAmount.Text = a.ToString("N2")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ClearText()
        txtVCECode.Text = ""
        txtVCEName.Text = ""
        txtAmount.Text = ""
        txtRemarks.Text = ""
        txtPeriod.Text = ""
        txtTransNum.Text = ""
        txtStatus.Text = ""
        dgvRecords.Rows.Clear()
        txtInputVAT.Text = "0.00"
        txtBaseAmount.Text = "0.00"
    End Sub

    Private Sub SaveRFP()
        Try
            Dim insertSQL As String
            activityStatus = True
            insertSQL = " INSERT INTO " & _
                        " tblRFP (TransID, RFP_No, BranchCode, BusinessCode, VCECode, DateRFP, EWT, Amount, InputVAT, BaseAmount, Remarks, PeriodCovered, WhoCreated) " & _
                        " VALUES(@TransID, @RFP_No, @BranchCode, @BusinessCode,  @VCECode, @DateRFP, @EWT, @Amount, @InputVAT, @BaseAmount,  @Remarks, @PeriodCovered, @WhoCreated)"
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@RFP_No", RFPNo)
            If cbBranch.SelectedItem = "Multiple Branch" Then
                SQL.AddParam("@BranchCode", "MB")
            Else
                If tempBranch = "" Then
                    SQL.AddParam("@BranchCode", BranchCode)
                Else
                    SQL.AddParam("@BranchCode", tempBranch)
                End If
            End If
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateRFP", dtpDocDate.Value.Date)
            SQL.AddParam("@EWT", chkEWT.Checked)
            SQL.AddParam("@Amount", CDec(txtAmount.Text))
            SQL.AddParam("@InputVAT", CDec(txtInputVAT.Text))
            SQL.AddParam("@BaseAmount", CDec(txtBaseAmount.Text))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@PeriodCovered", txtPeriod.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            If txtBankRef.Text <> "" Then
                SaveRFPRef(TransID)
            End If

            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvRecords.Rows
                Dim VCECode, TIN As String
                If item.Cells(dgcTIN.Index).Value Is Nothing Then
                    TIN = ""
                Else
                    TIN = item.Cells(dgcTIN.Index).Value.ToString
                End If

                If IsNothing(item.Cells(dgcVCECode.Index).Value) OrElse item.Cells(dgcVCECode.Index).Value.ToString = "" Then
                    VCECode = GetExistingCode(item.Cells(dgcPayee.Index).Value.ToString, TIN)
                    If VCECode = "" Then
                        Dim query As String
                        query = " SELECT 'V' + RIGHT('00000' + CAST(ISNULL(CAST(REPLACE(MAX(VCECode),'V','') AS int),0) + 1 AS nvarchar),6) AS VCECode FROM tblVCE_Master WHERE SystemGen = 1 AND isVendor = 1 AND VCECode LIKE 'V%'"
                        SQL.ReadQuery(query)
                        If SQL.SQLDR.Read Then
                            VCECode = SQL.SQLDR("VCECode").ToString
                            AutoSaveVendor(VCECode, item.Cells(dgcPayee.Index).Value.ToString, TIN)
                        Else
                            VCECode = ""
                        End If
                    End If
                Else
                    VCECode = item.Cells(dgcVCECode.Index).Value.ToString
                    UpdateTIN(VCECode, TIN)
                End If
                insertSQL = " INSERT INTO " & _
                                   " tblRFP_Details(TransID, BranchCode, Ref_No, RecordDate, CodePayee, RecordPayee, OR_Ref, TIN, Type, Category, Particulars, Amount, VATable, EWT, EWTRate, InputVAT, BaseAmount, EWTAmount, LineNum) " & _
                                   " VALUES(@TransID, @BranchCode, @Ref_No, @RecordDate, @CodePayee, @RecordPayee, @OR_Ref, @TIN, @Type, @Category, @Particulars, @Amount, @VATable, @EWT, @EWTRate, @InputVAT, @BaseAmount, @EWTAmount, @LineNum)"
                SQL.FlushParams()
                SQL.AddParam("@TransID", TransID)
                If cbBranch.SelectedItem = "Multiple Branch" Then
                    SQL.AddParam("@BranchCode", item.Cells(dgcBranch.Index).Value.ToString)
                Else
                    SQL.AddParam("@BranchCode", tempBranch)
                End If
                If item.Cells(dgcRefNo.Index).Value Is Nothing Then
                    SQL.AddParam("@Ref_No", "")
                Else
                    SQL.AddParam("@Ref_No", item.Cells(dgcRefNo.Index).Value.ToString)
                End If
                SQL.AddParam("@RecordDate", item.Cells(dgcDate.Index).Value.ToString)
                SQL.AddParam("@CodePayee", VCECode)
                If item.Cells(dgcPayee.Index).Value Is Nothing Then
                    SQL.AddParam("@RecordPayee", "")
                Else
                    SQL.AddParam("@RecordPayee", item.Cells(dgcPayee.Index).Value.ToString)
                End If

                If item.Cells(dgcOR.Index).Value Is Nothing Then
                    SQL.AddParam("@OR_Ref", "")
                Else
                    SQL.AddParam("@OR_Ref", item.Cells(dgcOR.Index).Value.ToString)
                End If


                SQL.AddParam("@TIN", TIN)

                If item.Cells(dgcType.Index).Value Is Nothing Then
                    SQL.AddParam("@Type", "")
                Else
                    SQL.AddParam("@Type", item.Cells(dgcType.Index).Value.ToString)
                End If

                If item.Cells(dgcCategory.Index).Value Is Nothing Then
                    SQL.AddParam("@Category", "")
                Else
                    SQL.AddParam("@Category", item.Cells(dgcCategory.Index).Value.ToString)
                End If
                If item.Cells(dgcParticulars.Index).Value Is Nothing Then
                    SQL.AddParam("@Particulars", "")
                Else
                    SQL.AddParam("@Particulars", item.Cells(dgcParticulars.Index).Value.ToString)
                End If
                If item.Cells(dgcAmount.Index).Value Is Nothing Then
                    SQL.AddParam("@Amount", 0)
                ElseIf Not IsNumeric(item.Cells(dgcAmount.Index).Value) Then
                    SQL.AddParam("@Amount", 0)
                Else
                    SQL.AddParam("@Amount", CDec(item.Cells(dgcAmount.Index).Value))
                End If
                If item.Cells(dgcVAT.Index).Value Is Nothing Then
                    SQL.AddParam("@VATable", False)
                Else
                    SQL.AddParam("@VATable", item.Cells(dgcVAT.Index).Value.ToString)
                End If
                If item.Cells(dgcEWT.Index).Value Is Nothing Then
                    SQL.AddParam("@EWT", False)
                Else
                    SQL.AddParam("@EWT", item.Cells(dgcEWT.Index).Value.ToString)
                End If
                If item.Cells(dgcEWTRate.Index).Value Is Nothing Then
                    SQL.AddParam("@EWTRate", 0)
                Else
                    SQL.AddParam("@EWTRate", item.Cells(dgcEWTRate.Index).Value.ToString)
                End If
                SQL.AddParam("@InputVAT", CDec(item.Cells(dgcInputVAT.Index).Value))
                SQL.AddParam("@BaseAmount", CDec(item.Cells(dgcBase.Index).Value))
                SQL.AddParam("@EWTAmount", CDec(item.Cells(dgcEWTamt.Index).Value))
                SQL.AddParam("@LineNum", line)
                SQL.ExecNonQuery(insertSQL)
                line += 1
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "RFP_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub AutoSaveVendor(ByVal Code As String, Name As String, TIN As String)
        Dim query As String
        query = "SELECT * FROM tblVCE_Master WHERE VCECode = @VCECode  "
        SQL.FlushParams()
        SQL.AddParam("@VCECode", Code)
        If Not SQL.SQLDR.Read Then
            Dim insertSQl As String
            insertSQl = " INSERT INTO " & _
                        " tblVCE_Master(VCECode, VCEName, TIN_No, isVendor, SystemGen) " & _
                        " VALUES (@VCECode, @VCEName, @TIN_No, @isVendor, @SystemGen) "
            SQL.FlushParams()
            SQL.AddParam("@VCECode", Code)
            SQL.AddParam("@VCEName", Name)
            SQL.AddParam("@TIN_No", TIN)
            SQL.AddParam("@isVendor", True)
            SQL.AddParam("@SystemGen", True)
            SQL.ExecNonQuery(insertSQl)
        End If
    End Sub

    Private Function GetExistingCode(Name As String, TIN As String) As String
        Dim query As String
        query = "SELECT VCECode FROM tblVCE_Master WHERE (VCEName = @VCEName  OR TIN_NO = @TIN ) AND TIN_No <> '' "
        SQL.FlushParams()
        SQL.AddParam("@VCEName", Name)
        SQL.AddParam("@TIN", TIN)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("VCECode").ToString
        Else
            Return ""
        End If
    End Function


    Private Sub UpdateTIN(ByVal Code As String, TIN As String)
        Dim updateSQL As String
        updateSQL = " UPDATE    tblVCE_Master " & _
                    " SET       TIN_No = @TIN_No, isVendor = @isVendor " & _
                    " WHERE     VCECode = @VCECode "
        SQL.FlushParams()
        SQL.AddParam("@VCECode", Code)
        SQL.AddParam("@TIN_No", TIN)
        SQL.AddParam("@isVendor", True)
        SQL.ExecNonQuery(updateSQL)
    End Sub

    Private Sub UpdateRFP()
        Try
            Dim insertSQL, updateSQL, deleteSQL As String
            activityStatus = True
            updateSQL = " UPDATE tblRFP  " & _
                        " SET    RFP_No = @RFP_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, VCECode = @VCECode, DateRFP = @DateRFP, EWT = @EWT, " & _
                        "        Amount = @Amount, InputVAT = @InputVAT, BaseAmount = @BaseAmount, Remarks = @Remarks, PeriodCovered = @PeriodCovered, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@RFP_No", RFPNo)
            If cbBranch.SelectedItem = "Multiple Branch" Then
                SQL.AddParam("@BranchCode", "MB")
            Else
                If tempBranch = "" Then
                    SQL.AddParam("@BranchCode", BranchCode)
                Else
                    SQL.AddParam("@BranchCode", tempBranch)
                End If
            End If
         

            SQL.AddParam("@EWT", chkEWT.Checked)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateRFP", dtpDocDate.Value.Date)
            SQL.AddParam("@Amount", CDec(txtAmount.Text))
            SQL.AddParam("@InputVAT", CDec(txtInputVAT.Text))
            SQL.AddParam("@BaseAmount", CDec(txtBaseAmount.Text))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@PeriodCovered", txtPeriod.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            If txtBankRef.Text <> "" Then
                SaveRFPRef(TransID)
            End If


            ' DELETE ACCOUNTING ENTRIES
            deleteSQL = " DELETE FROM tblRFP_Details  WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            Dim line As Integer = 1
            For Each item As DataGridViewRow In dgvRecords.Rows
                Dim VCECode, TIN As String
                If item.Cells(dgcTIN.Index).Value Is Nothing Then
                    TIN = ""
                Else
                    TIN = item.Cells(dgcTIN.Index).Value.ToString
                End If

                If IsNothing(item.Cells(dgcVCECode.Index).Value) OrElse item.Cells(dgcVCECode.Index).Value.ToString = "" Then
                    VCECode = GetExistingCode(item.Cells(dgcPayee.Index).Value.ToString, TIN)
                    If VCECode = "" Then
                        Dim query As String
                        query = " SELECT 'V' + RIGHT('00000' + CAST(ISNULL(CAST(REPLACE(MAX(VCECode),'V','') AS int),0) + 1 AS nvarchar),6) AS VCECode FROM tblVCE_Master WHERE SystemGen = 1 AND isVendor = 1 AND VCECode LIKE 'V%'"
                        SQL.ReadQuery(query)
                        If SQL.SQLDR.Read Then
                            VCECode = SQL.SQLDR("VCECode").ToString
                            AutoSaveVendor(VCECode, item.Cells(dgcPayee.Index).Value.ToString, TIN)
                        Else
                            VCECode = ""
                        End If
                    End If
                Else
                    VCECode = item.Cells(dgcVCECode.Index).Value.ToString
                    UpdateTIN(VCECode, TIN)
                End If
                insertSQL = " INSERT INTO " & _
                                   " tblRFP_Details(TransID, Ref_No, RecordDate, CodePayee, RecordPayee, OR_Ref, TIN, Type, Category, Particulars, Amount, VATable, EWT, EWTRate, InputVAT, BaseAmount, EWTAmount, BranchCode, LineNum) " & _
                                   " VALUES(@TransID, @Ref_No, @RecordDate, @CodePayee, @RecordPayee, @OR_Ref, @TIN, @Type, @Category, @Particulars, @Amount, @VATable, @EWT, @EWTRate, @InputVAT, @BaseAmount, @EWTAmount, @BranchCode, @LineNum)"
                SQL.FlushParams()
                SQL.AddParam("@TransID", TransID)
                If item.Cells(dgcRefNo.Index).Value Is Nothing Then
                    SQL.AddParam("@Ref_No", "")
                Else
                    SQL.AddParam("@Ref_No", item.Cells(dgcRefNo.Index).Value.ToString)
                End If
                SQL.AddParam("@RecordDate", item.Cells(dgcDate.Index).Value.ToString)
                SQL.AddParam("@CodePayee", VCECode)
                If item.Cells(dgcPayee.Index).Value Is Nothing Then
                    SQL.AddParam("@RecordPayee", "")
                Else
                    SQL.AddParam("@RecordPayee", item.Cells(dgcPayee.Index).Value.ToString)
                End If

                If item.Cells(dgcOR.Index).Value Is Nothing Then
                    SQL.AddParam("@OR_Ref", "")
                Else
                    SQL.AddParam("@OR_Ref", item.Cells(dgcOR.Index).Value.ToString)
                End If


                SQL.AddParam("@TIN", TIN)

                If item.Cells(dgcType.Index).Value Is Nothing Then
                    SQL.AddParam("@Type", "")
                Else
                    SQL.AddParam("@Type", item.Cells(dgcType.Index).Value.ToString)
                End If

                If item.Cells(dgcCategory.Index).Value Is Nothing Then
                    SQL.AddParam("@Category", "")
                Else
                    SQL.AddParam("@Category", item.Cells(dgcCategory.Index).Value.ToString)
                End If
                If item.Cells(dgcParticulars.Index).Value Is Nothing Then
                    SQL.AddParam("@Particulars", "")
                Else
                    SQL.AddParam("@Particulars", item.Cells(dgcParticulars.Index).Value.ToString)
                End If
                If item.Cells(dgcAmount.Index).Value Is Nothing Then
                    SQL.AddParam("@Amount", 0)
                ElseIf Not IsNumeric(item.Cells(dgcAmount.Index).Value) Then
                    SQL.AddParam("@Amount", 0)
                Else
                    SQL.AddParam("@Amount", CDec(item.Cells(dgcAmount.Index).Value))
                End If
                If item.Cells(dgcVAT.Index).Value Is Nothing Then
                    SQL.AddParam("@VATable", False)
                Else
                    SQL.AddParam("@VATable", item.Cells(dgcVAT.Index).Value.ToString)
                End If
                If item.Cells(dgcEWT.Index).Value Is Nothing Then
                    SQL.AddParam("@EWT", False)
                Else
                    SQL.AddParam("@EWT", item.Cells(dgcEWT.Index).Value.ToString)
                End If
                If item.Cells(dgcEWTRate.Index).Value Is Nothing Then
                    SQL.AddParam("@EWTRate", 0)
                Else
                    SQL.AddParam("@EWTRate", item.Cells(dgcEWTRate.Index).Value.ToString)
                End If
                SQL.AddParam("@InputVAT", CDec(item.Cells(dgcInputVAT.Index).Value))
                SQL.AddParam("@BaseAmount", CDec(item.Cells(dgcBase.Index).Value))
                SQL.AddParam("@EWTAmount", CDec(item.Cells(dgcEWTamt.Index).Value))
                SQL.AddParam("@BranchCode", item.Cells(dgcBranch.Index).Value)
                SQL.AddParam("@LineNum", line)
                SQL.ExecNonQuery(insertSQL)
                line += 1
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "RFP_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub SaveRFPRef(ByVal RFPID As Integer)
        Dim deleteSQL As String
        deleteSQL = "DELETE FROM tblRFP_BankRef WHERE TransID ='" & RFPID & "'"
        SQL.ExecNonQuery(deleteSQL)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblRFP_BankRef (TransID, BankID, RefNo, RefDate, RefAmount) " & _
                    " VALUES(@TransID, @BankID, @RefNo, @RefDate, @RefAmount)"
        SQL.FlushParams()
        SQL.AddParam("@TransID", RFPID)
        SQL.AddParam("@BankID", bankID)
        SQL.AddParam("@RefNo", txtBankRef.Text)
        SQL.AddParam("@RefDate", dtpBankRefDate.Value.Date)
        SQL.AddParam("@RefAmount", CDec(txtAmount.Text))
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Function LoadListRFP(Type As String, Text As String, RowInd As Integer) As Boolean
        Dim query As String
        Dim exist As Boolean = False
        Dim filtertype As String = ""
        If Type = "TIN" Then
            filtertype = "TIN_No"
        Else
            filtertype = "VCEName"
        End If
        query = " SELECT DISTINCT MAX(VCECode) AS VCECode, VCEName, MAX(TIN_No) AS TIN_No " & _
                " FROM " & _
                " ( " & _
                "       SELECT VCECode, VCEName, TIN_No FROM tblVCE_Master WHERE  " & filtertype & " LIKE '%' + @Filter + '%'  " & _
                "       UNION ALL " & _
                "       SELECT '', RecordPayee, TIN FROM tblRFP_Details WHERE " & Type & " LIKE '%' + @Filter + '%' " & _
                " ) AS A " & _
                " GROUP BY VCEName, TIN_No "
        SQL.FlushParams()

        SQL.AddParam("@Filter", Text)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            exist = True
        Else
            For Each row As DataGridViewRow In dgvRecords.Rows
                If row.Index <> RowInd Then
                    If Type = "RecordPayee" Then
                        If Not row.Cells(dgcPayee.Index).Value Is Nothing Then
                            If Strings.UCase(row.Cells(dgcPayee.Index).Value).ToString.Contains(Strings.UCase(Text)) Then
                                exist = True
                                Exit For
                            End If
                        End If
                    ElseIf Type = "TIN" Then
                        If Not row.Cells(dgcTIN.Index).Value Is Nothing Then
                            If row.Cells(dgcTIN.Index).Value = Text Then
                                exist = True
                                Exit For
                            End If
                        End If
                    End If
                End If
               
            Next
        End If
        Return exist
        SQL.FlushParams()
    End Function

    Private Sub dgvRecords_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecords.CellEndEdit
        If e.ColumnIndex = dgcTIN.Index Then
            Dim filter As String = ""
            If Not dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                filter = dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value.ToString
            End If
            If LoadListRFP("TIN", filter, e.RowIndex) Then
                Dim f As New frmVCE_Search
                f.ModFrom = "RFP"
                f.cbFilter.Items.Clear()
                f.cbFilter.Items.Add("RecordPayee")
                f.cbFilter.Items.Add("TIN")
                f.cbFilter.SelectedItem = "TIN"
                f.Type = "TIN"
                f.rowInd = e.RowIndex
                f.txtFilter.Text = filter
                f.ShowDialog()
                If Not f.TIN Is Nothing Or Not f.VCEName Is Nothing Then
                    dgvRecords.Item(dgcTIN.Index, e.RowIndex).Value = f.TIN
                    dgvRecords.Item(dgcPayee.Index, e.RowIndex).Value = f.VCEName
                End If
                f.Dispose()
            End If
        ElseIf e.ColumnIndex = dgcPayee.Index Then
            Dim filter As String = ""
            If Not dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                filter = dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value.ToString
            End If
            If LoadListRFP("RecordPayee", filter, e.RowIndex) Then
                Dim f As New frmVCE_Search
                f.ModFrom = "RFP"
                f.cbFilter.Items.Clear()
                f.cbFilter.Items.Add("RecordPayee")
                f.cbFilter.Items.Add("TIN")
                f.cbFilter.SelectedItem = "RecordPayee"
                f.Type = "RecordPayee"
                f.rowInd = e.RowIndex
                f.txtFilter.Text = filter
                f.ShowDialog()
                If Not f.TIN Is Nothing Or Not f.VCEName Is Nothing Then
                    dgvRecords.Item(dgcTIN.Index, e.RowIndex).Value = f.TIN
                    dgvRecords.Item(dgcPayee.Index, e.RowIndex).Value = f.VCEName
                End If
                f.Dispose()
            End If
        ElseIf e.ColumnIndex = dgcType.Index Then
            LoadType(e.RowIndex)
        ElseIf e.ColumnIndex = dgcBranch.Index Then
            LoadBranches(e.RowIndex)
        ElseIf e.ColumnIndex = dgcCategory.Index Then
            LoadEWT(e.RowIndex)
        ElseIf e.ColumnIndex = dgcDate.Index Then
            If IsDate(dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value) Then
                dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value = CDate(dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value)
            End If
            LoadPeriod()
        ElseIf e.ColumnIndex = dgcAmount.Index Then
            disableEvent = True
            ComputeTaxes(e.RowIndex)
            disableEvent = False
        End If
        ComputeTotal()
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("RFP_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("RFP")
            TransID = f.transID
            LoadRFP(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("RFP_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            RFPNo = ""

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
            txtStatus.Text = "Open"
            EnableControl(True)
            dgvRecords.Rows.Add(tempBranch, dtpDocDate.Value.Date)
            RefreshDGC()
            If dgvRecords.Rows.Count > 0 Then
                dgvRecords.Rows(0).Cells(dgcDate.Index).Value = dtpDocDate.Value
            End If
            If dgvRecords.SelectedCells.Count > 0 Then
                dgvRecords.SelectedCells(0).Selected = False
            End If

            LoadPeriod()
            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
            txtVCEName.Select()
        End If
    End Sub

    Private Sub LoadPeriod()
        Dim minPeriod, maxPeriod, tempDate As Date
        For Each row As DataGridViewRow In dgvRecords.Rows
            If IsDate(row.Cells(dgcDate.Index).Value) Then
                tempDate = row.Cells(dgcDate.Index).Value
                If minPeriod = #12:00:00 AM# OrElse tempDate <= minPeriod Then
                    minPeriod = tempDate
                End If
                If maxPeriod = #12:00:00 AM# OrElse tempDate >= maxPeriod Then
                    maxPeriod = tempDate
                End If
            End If
        Next
        If maxPeriod = minPeriod Then
            txtPeriod.Text = maxPeriod.ToString("MM/dd/yyyy")
        Else
            txtPeriod.Text = minPeriod.ToString("MM/dd/yyyy") + " to " + maxPeriod.ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("RFP_EDIT") Then
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
            If dgvRecords.Rows.Count = 0 Then
                dgvRecords.Rows.Add(tempBranch, dtpDocDate.Value.Date)
                RefreshDGC()
            End If
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("RFP_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblRFP SET Status ='Cancelled' WHERE RFP_No = @RFP_No "
                        SQL.FlushParams()
                        RFPNo = txtTransNum.Text
                        SQL.AddParam("@RFP_No", RFPNo)
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
                        EnableControl(False)

                        RFPNo = txtTransNum.Text
                        LoadRFP(TransID)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "RFP_No", RFPNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs)
        Dim f As New frmReport_Display
        f.ShowDialog("RFP", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If RFPNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblRFP  WHERE RFP_No < '" & RFPNo & "' ORDER BY RFP_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadRFP(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If RFPNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblRFP  WHERE RFP_No > '" & RFPNo & "' ORDER BY RFP_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadRFP(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If RFPNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadRFP(TransID)
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
        ElseIf txtAmount.Text = "" Then
            MsgBox("Please check amount!", MsgBoxStyle.Exclamation)
        ElseIf dgvRecords.Rows.Count = 0 Then
            MsgBox("No entries, Please check!", MsgBoxStyle.Exclamation)
        ElseIf txtBankRef.Text <> "" And bankID = 0 Then
            MsgBox("Please Select Check Bank!", MsgBoxStyle.Exclamation)
        ElseIf TransAuto = False And txtTransNum.Text = "" Then
            MsgBox("Please Enter RFP No.!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" AndAlso TransAuto = False AndAlso DuplicateTransNo(txtTransNum.Text) Then
            MsgBox("RFP No. already Exist!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                If TransAuto = True Then
                    RFPNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                    txtTransNum.Text = RFPNo
                Else
                    RFPNo = txtTransNum.Text
                End If
                SaveRFP()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                LoadRFP(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                If TransAuto = True Then
                    txtTransNum.Text = RFPNo
                Else
                    RFPNo = txtTransNum.Text
                End If
                UpdateRFP()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                RFPNo = txtTransNum.Text
                LoadRFP(TransID)
            End If
        End If
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

    Private Function DuplicateTransNo(TransNo As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblRFP WHERE RFP_No = @RFP_No "
        SQL.FlushParams()
        SQL.AddParam("@RFP_No", TransNo)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub frmRFP_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.Control = True AndAlso e.KeyCode = Keys.Enter Then
                If Not controlDisabled Then
                    dgvRecords.Rows.Add(tempBranch)
                    If dgvRecords.Rows.Count >= 2 AndAlso Not IsNothing(dgvRecords.Item(dgcCategory.Index, dgvRecords.Rows.Count - 2).Value) Then
                        dgvRecords.Item(dgcCategory.Index, dgvRecords.Rows.Count - 1).Value = dgvRecords.Item(dgcCategory.Index, dgvRecords.Rows.Count - 2).Value
                        dgvRecords.Item(dgcEWTRate.Index, dgvRecords.Rows.Count - 1).Value = dgvRecords.Item(dgcEWTRate.Index, dgvRecords.Rows.Count - 2).Value
                    End If
                    LoadType(dgvRecords.Rows.Count - 1)
                    LoadBranches(dgvRecords.Rows.Count - 1)
                    LoadEWT(dgvRecords.Rows.Count - 1)
                    If dgvRecords.SelectedCells.Count > 0 Then
                        dgvRecords.SelectedCells(0).Selected = False
                    End If
                    If dgvRecords.IsCurrentCellInEditMode Then
                        dgvRecords.EndEdit()
                    End If
                    If dgvRecords.Columns(dgcBranch.Index).Visible = True Then
                        dgvRecords.Item(dgcBranch.Index, dgvRecords.Rows.Count - 1).Selected = True
                    Else
                        dgvRecords.Item(dgcDate.Index, dgvRecords.Rows.Count - 1).Selected = True
                    End If
                    dgvRecords.BeginEdit(True)
                End If
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbExit.Enabled = True Then
                    tsbExit.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.Shift = True Then
            If e.KeyCode = Keys.Escape Then
                If tsbClose.Enabled = True Then tsbClose.PerformClick()
            End If
        End If
    End Sub

    Private Sub PrintRFPToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim f As New frmReport_Display
        f.ShowDialog("RFP", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbPrint_ButtonClick(sender As System.Object, e As System.EventArgs)
        Dim f As New frmReport_Display
        f.ShowDialog("RFP", TransID)
        f.Dispose()
    End Sub

    Private Sub ChequieToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim f As New frmCheckPrinting
        f.CVTransID = TransID
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub dgvEntry_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvRecords.KeyDown
        If e.Shift = True AndAlso e.KeyCode = Keys.Space Then
            e.SuppressKeyPress = True

        ElseIf e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        ElseIf e.Shift = True AndAlso e.KeyCode = Keys.Down Then
            If Not controlDisabled Then
                If dgvRecords.SelectedCells(0).RowIndex >= 1 AndAlso Not IsNothing(dgvRecords.Item(dgvRecords.SelectedCells(0).ColumnIndex, dgvRecords.SelectedCells(0).RowIndex - 1).Value) Then
                    dgvRecords.SelectedCells(0).Value = dgvRecords.Item(dgvRecords.SelectedCells(0).ColumnIndex, dgvRecords.SelectedCells(0).RowIndex - 1).Value
                End If
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Delete Then
            dgvRecords.SelectedCells(0).Value = Nothing
        End If
    End Sub

    Private Sub dgvRecords_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRecords.DataError
        Try

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvRecords_CellValidating(sender As System.Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvRecords.CellValidating
        If e.ColumnIndex = dgcDate.Index Then
            Dim dt As DateTime
            If e.FormattedValue.ToString <> String.Empty AndAlso Not DateTime.TryParse(e.FormattedValue.ToString, dt) Then
                MessageBox.Show("Enter correct Date")
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub dgvRecords_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRecords.CellBeginEdit
        If e.ColumnIndex = dgcDate.Index And e.ColumnIndex > 0 Then
            If dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                dgvRecords.Item(e.ColumnIndex, e.RowIndex).Value = dgvRecords.Item(e.ColumnIndex, e.RowIndex - 1).Value
                dgvRecords.Item(e.ColumnIndex, e.RowIndex).Selected = True
            End If
        ElseIf e.ColumnIndex = dgcEWT.Index Or e.ColumnIndex = dgcVAT.Index Then
            If dgvRecords.SelectedCells(0).RowIndex <> -1 Then
                dgvRecords.EndEdit(True)
            End If
        End If
    End Sub

    Private Sub cbBranch_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBranch.SelectedIndexChanged
        If disableEvent = False Then
            If cbBranch.SelectedIndex <> -1 Then
                If cbBranch.SelectedItem = "Multiple Branch" Then
                    If tempBranch <> "" Then
                        For Each row As DataGridViewRow In dgvRecords.Rows
                            row.Cells(dgcBranch.Index).Value = tempBranch
                        Next
                    End If
                    dgvRecords.Columns(dgcBranch.Index).Visible = True
                Else
                    dgvRecords.Columns(dgcBranch.Index).Visible = False
                    tempBranch = Strings.Left(cbBranch.SelectedItem, cbBranch.SelectedItem.ToString.IndexOf(" - "))
                End If
            End If
        End If
    End Sub

    Private Sub dgvRecords_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgvRecords.CurrentCellDirtyStateChanged
        If dgvRecords.SelectedCells.Count > 0 Then
            If dgvRecords.SelectedCells(0).ColumnIndex = dgcVAT.Index Then
                If dgvRecords.SelectedCells(0).RowIndex <> -1 Then
                    dgvRecords.CommitEdit(DataGridViewDataErrorContexts.Commit)
                End If
            ElseIf dgvRecords.SelectedCells(0).ColumnIndex = dgcEWT.Index Then
                If dgvRecords.SelectedCells(0).RowIndex <> -1 Then
                    dgvRecords.CommitEdit(DataGridViewDataErrorContexts.Commit)
                End If
            End If

        End If
    End Sub


    Private Sub dgvRecords_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecords.CellValueChanged
        If disableEvent = False Then
            If dgvRecords.SelectedCells.Count > 0 Then
                If e.ColumnIndex = dgcVAT.Index Or e.ColumnIndex = dgcEWT.Index Then
                    If e.ColumnIndex = dgcVAT.Index Then
                        If dgvRecords.Item(dgcVAT.Index, dgvRecords.SelectedCells(0).RowIndex).Value = False Then
                            dgvRecords.Item(dgcEWT.Index, dgvRecords.SelectedCells(0).RowIndex).Value = False
                            dgvRecords.Columns(dgcEWT.Index).ReadOnly = True
                        Else
                            dgvRecords.Columns(dgcEWT.Index).ReadOnly = False
                        End If
                    End If
                    ComputeTaxes(dgvRecords.SelectedCells(0).RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub ComputeTaxes(ByVal rowIndex As Integer)
        Dim gross, base, vat, ewt, ewtrate As Decimal
        If rowIndex <> -1 Then
            ' CHECK IF THERE IS GROSS AMOUNT
            If IsNumeric(dgvRecords.Item(dgcAmount.Index, rowIndex).Value) Then
                gross = dgvRecords.Item(dgcAmount.Index, rowIndex).Value
                ' CHECK IF VATABLE
                If dgvRecords.Item(dgcVAT.Index, rowIndex).Value Then  '
                    base = (gross / 1.12) ' GET BASE AMOUNT BY DIVIDING GROSS BY 1.12
                    vat = base * 0.12
                    If dgvRecords.Item(dgcEWT.Index, rowIndex).Value Then
                        ewtrate = dgvRecords.Item(dgcEWTRate.Index, rowIndex).Value
                        ewt = base * (ewtrate / 100.0)
                    Else
                        ewtrate = 0
                        ewt = 0
                    End If
                Else  ' IF NOT VATABLE, ZERO VAT, ZERO EWT
                    base = gross
                    vat = 0.0
                    ewt = 0.0
                End If
                dgvRecords.Item(dgcAmount.Index, rowIndex).Value = gross.ToString("N2")
                dgvRecords.Item(dgcBase.Index, rowIndex).Value = base.ToString("N2")
                dgvRecords.Item(dgcInputVAT.Index, rowIndex).Value = vat.ToString("N2")
                dgvRecords.Item(dgcEWTamt.Index, rowIndex).Value = ewt.ToString("N2")
                ComputeTotal()
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If Not AllowAccess("RFP_MNT") Then
            msgRestricted()
        Else
            Dim f As New frmRFP_Type
            f.ShowDialog()
            f.Dispose()
            RefreshDGC()
        End If
    End Sub

    Private Sub tsbPrint_ButtonClick_1(sender As System.Object, e As System.EventArgs) Handles tsbPrint.ButtonClick
        Dim f As New frmReport_Display
        f.ShowDialog("RFP", TransID)
        f.Dispose()
    End Sub

    Private Sub PrintRFPDetailsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintRFPDetailsToolStripMenuItem.Click
        Dim f As New frmReport_Display
        f.ShowDialog("RFP_VAT", TransID)
        f.Dispose()
    End Sub

    Private Sub PrintRFPSummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintRFPSummaryToolStripMenuItem.Click
        Dim f As New frmReport_Display
        f.ShowDialog("RFP_Summary", TransID)
        f.Dispose()
    End Sub

    Private Sub TestToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TestToolStripMenuItem1.Click
        Dim f As New frmReport_Filter
        f.Report = "RFP List"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbGroup.SelectedIndexChanged
        If cbGroup.SelectedIndex <> -1 Then
            lvSubtotal.Items.Clear()
            For Each row As DataGridViewRow In dgvRecords.Rows
                Select Case cbGroup.SelectedItem
                    Case "CV No."
                        Dim exist As Boolean = False
                        If row.Cells(dgcRefNo.Index).Value Is Nothing Then
                            row.Cells(dgcRefNo.Index).Value = ""
                        End If
                        For Each item As ListViewItem In lvSubtotal.Items

                            If item.SubItems(0).Text = row.Cells(dgcRefNo.Index).Value Then
                                exist = True
                                item.SubItems(dgcSubAmount.Index).Text = CDec(CDec(item.SubItems(dgcSubAmount.Index).Text) + CDec(row.Cells(dgcAmount.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubVAT.Index).Text = CDec(CDec(item.SubItems(dgcSubVAT.Index).Text) + CDec(row.Cells(dgcInputVAT.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubBase.Index).Text = CDec(CDec(item.SubItems(dgcSubBase.Index).Text) + CDec(row.Cells(dgcBase.Index).Value)).ToString("N2")
                            End If
                        Next
                        If exist = False Then
                            lvSubtotal.Items.Add(row.Cells(dgcRefNo.Index).Value)
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcAmount.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcInputVAT.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcBase.Index).Value).ToString("N2"))
                        End If
                    Case "Date"
                        Dim exist As Boolean = False
                        If row.Cells(dgcDate.Index).Value Is Nothing Then
                            row.Cells(dgcDate.Index).Value = Date.Today.Date
                        End If
                        For Each item As ListViewItem In lvSubtotal.Items

                            If item.SubItems(0).Text = CDate(row.Cells(dgcDate.Index).Value).Date Then
                                exist = True
                                item.SubItems(dgcSubAmount.Index).Text = CDec(CDec(item.SubItems(dgcSubAmount.Index).Text) + CDec(row.Cells(dgcAmount.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubVAT.Index).Text = CDec(CDec(item.SubItems(dgcSubVAT.Index).Text) + CDec(row.Cells(dgcInputVAT.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubBase.Index).Text = CDec(CDec(item.SubItems(dgcSubBase.Index).Text) + CDec(row.Cells(dgcBase.Index).Value)).ToString("N2")
                            End If
                        Next
                        If exist = False Then
                            lvSubtotal.Items.Add(CDate(row.Cells(dgcDate.Index).Value).Date)
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcAmount.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcInputVAT.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcBase.Index).Value).ToString("N2"))
                        End If
                    Case "Payee"
                        Dim exist As Boolean = False
                        If row.Cells(dgcPayee.Index).Value Is Nothing Then
                            row.Cells(dgcPayee.Index).Value = ""
                        End If
                        For Each item As ListViewItem In lvSubtotal.Items

                            If item.SubItems(0).Text = row.Cells(dgcPayee.Index).Value Then
                                exist = True
                                item.SubItems(dgcSubAmount.Index).Text = CDec(CDec(item.SubItems(dgcSubAmount.Index).Text) + CDec(row.Cells(dgcAmount.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubVAT.Index).Text = CDec(CDec(item.SubItems(dgcSubVAT.Index).Text) + CDec(row.Cells(dgcInputVAT.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubBase.Index).Text = CDec(CDec(item.SubItems(dgcSubBase.Index).Text) + CDec(row.Cells(dgcBase.Index).Value)).ToString("N2")
                            End If
                        Next
                        If exist = False Then
                            lvSubtotal.Items.Add(row.Cells(dgcPayee.Index).Value)
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcAmount.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcInputVAT.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcBase.Index).Value).ToString("N2"))
                        End If
                    Case "O.R.#"
                        Dim exist As Boolean = False
                        If row.Cells(dgcOR.Index).Value Is Nothing Then
                            row.Cells(dgcOR.Index).Value = ""
                        End If
                        For Each item As ListViewItem In lvSubtotal.Items

                            If item.SubItems(0).Text = row.Cells(dgcOR.Index).Value Then
                                exist = True
                                item.SubItems(dgcSubAmount.Index).Text = CDec(CDec(item.SubItems(dgcSubAmount.Index).Text) + CDec(row.Cells(dgcAmount.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubVAT.Index).Text = CDec(CDec(item.SubItems(dgcSubVAT.Index).Text) + CDec(row.Cells(dgcInputVAT.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubBase.Index).Text = CDec(CDec(item.SubItems(dgcSubBase.Index).Text) + CDec(row.Cells(dgcBase.Index).Value)).ToString("N2")
                            End If
                        Next
                        If exist = False Then
                            lvSubtotal.Items.Add(row.Cells(dgcOR.Index).Value)
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcAmount.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcInputVAT.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcBase.Index).Value).ToString("N2"))
                        End If
                    Case "Type"
                        Dim exist As Boolean = False
                        If row.Cells(dgcType.Index).Value Is Nothing Then
                            row.Cells(dgcType.Index).Value = ""
                        End If
                        For Each item As ListViewItem In lvSubtotal.Items

                            If item.SubItems(0).Text = row.Cells(dgcType.Index).Value Then
                                exist = True
                                item.SubItems(dgcSubAmount.Index).Text = CDec(CDec(item.SubItems(dgcSubAmount.Index).Text) + CDec(row.Cells(dgcAmount.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubVAT.Index).Text = CDec(CDec(item.SubItems(dgcSubVAT.Index).Text) + CDec(row.Cells(dgcInputVAT.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubBase.Index).Text = CDec(CDec(item.SubItems(dgcSubBase.Index).Text) + CDec(row.Cells(dgcBase.Index).Value)).ToString("N2")
                            End If
                        Next
                        If exist = False Then
                            lvSubtotal.Items.Add(row.Cells(dgcType.Index).Value)
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcAmount.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcInputVAT.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcBase.Index).Value).ToString("N2"))
                        End If
                    Case "Category"
                        Dim exist As Boolean = False
                        If row.Cells(dgcCategory.Index).Value Is Nothing Then
                            row.Cells(dgcCategory.Index).Value = ""
                        End If
                        For Each item As ListViewItem In lvSubtotal.Items

                            If item.SubItems(0).Text = row.Cells(dgcCategory.Index).Value Then
                                exist = True
                                item.SubItems(dgcSubAmount.Index).Text = CDec(CDec(item.SubItems(dgcSubAmount.Index).Text) + CDec(row.Cells(dgcAmount.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubVAT.Index).Text = CDec(CDec(item.SubItems(dgcSubVAT.Index).Text) + CDec(row.Cells(dgcInputVAT.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubBase.Index).Text = CDec(CDec(item.SubItems(dgcSubBase.Index).Text) + CDec(row.Cells(dgcBase.Index).Value)).ToString("N2")
                            End If
                        Next
                        If exist = False Then
                            lvSubtotal.Items.Add(row.Cells(dgcCategory.Index).Value)
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcAmount.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcInputVAT.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcBase.Index).Value).ToString("N2"))
                        End If
                    Case "VAT"
                        Dim exist As Boolean = False
                        Dim VatType As String = ""
                        If row.Cells(dgcVAT.Index).Value Is Nothing Then
                            row.Cells(dgcVAT.Index).Value = False
                        End If
                        If row.Cells(dgcVAT.Index).Value = True Then
                            VatType = "VAT"
                        Else
                            VatType = "Non-VAT"
                        End If
                        For Each item As ListViewItem In lvSubtotal.Items
                            If item.SubItems(0).Text = VatType Then
                                exist = True
                                item.SubItems(dgcSubAmount.Index).Text = CDec(CDec(item.SubItems(dgcSubAmount.Index).Text) + CDec(row.Cells(dgcAmount.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubVAT.Index).Text = CDec(CDec(item.SubItems(dgcSubVAT.Index).Text) + CDec(row.Cells(dgcInputVAT.Index).Value)).ToString("N2")
                                item.SubItems(dgcSubBase.Index).Text = CDec(CDec(item.SubItems(dgcSubBase.Index).Text) + CDec(row.Cells(dgcBase.Index).Value)).ToString("N2")
                            End If
                        Next
                        If exist = False Then
                            lvSubtotal.Items.Add(VatType)
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcAmount.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcInputVAT.Index).Value).ToString("N2"))
                            lvSubtotal.Items(lvSubtotal.Items.Count - 1).SubItems.Add(CDec(row.Cells(dgcBase.Index).Value).ToString("N2"))
                        End If
                End Select

            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim f As New frmMasterfile_Bank
        f.ShowDialog()
        f.Dispose()
        LoadBankList()
    End Sub

    Private Sub cbBank_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBank.SelectedIndexChanged
        Try
            If disableEvent = False Then
                If cbBank.SelectedIndex <> -1 Then
                    bankID = GetBankID(cbBank.SelectedItem)
                    txtBankRef.Text = GetCheckNo(bankID)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

    Private Function GetCheckNo(ByVal Bank_ID As String) As String
        Dim query As String
        query = " SELECT  ISNULL(RIGHT('000000000000' + CAST((CAST(MAX(RefNo) AS bigint) + 1) AS nvarchar), LEN(SeriesFrom)),SeriesFrom) AS RefNo, SeriesFrom " & _
                " FROM    tblRFP_BankRef RIGHT JOIN tblMasterfile_Bank " & _
                " ON      tblRFP_BankRef.BankID = tblMasterfile_Bank.Bank_ID " & _
                " AND     tblRFP_BankRef.RefNo BETWEEN SeriesFrom AND SeriesTo " & _
                " WHERE   tblMasterfile_Bank.Bank_ID = '" & Bank_ID & "'   " & _
                " GROUP BY LEN(SeriesFrom), SeriesFrom  "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("RefNo")) Then
            Return SQL.SQLDR("RefNo").ToString
        Else
            Return SQL.SQLDR("SeriesFrom").ToString
        End If
    End Function

    Private Sub chkEWT_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEWT.CheckedChanged
        dgvRecords.Columns(dgcEWT.Index).Visible = chkEWT.Checked
        dgvRecords.Columns(dgcEWTamt.Index).Visible = chkEWT.Checked
    End Sub
End Class