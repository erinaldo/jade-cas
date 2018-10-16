Public Class frmAdvances
    Dim TransID, RefID, JETransiD As String
    Dim ADVNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "ADV"
    Dim ColumnPK As String = "ADV_No"
    Dim DBTable As String = "tblADV"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim PO_ID As Integer
    Dim accntDR, accntCR, accntVAT As String

    Public Overloads Function ShowDialog(ByVal DocNumber As String) As Boolean
        ADVNo = DocNumber
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub ADV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            LoadChartOfAccount()
            If ADVNo <> "" Then
                LoadADV(ADVNo)
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

            Dim date1 As DateTime
            date1 = Convert.ToDateTime(Date.Today.Date + " 16:31")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadChartOfAccount()
        Dim query As String
        query = " SELECT  AccountCode, AccountTitle " & _
                " FROM    tblCOA_Master " & _
                " WHERE   AccountNature <> '' " & _
                " ORDER BY AccountTitle "
        SQL.ReadQuery(query)
        cbDefAccount.Items.Clear()
        While SQL.SQLDR.Read
            cbDefAccount.Items.Add(SQL.SQLDR("AccountTitle"))
        End While
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCEName.Enabled = Value
        btnSearchVCE.Enabled = Value
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        txtPORef.Enabled = Value
        txtAdvAmount.Enabled = Value
        txtAdvPercent.Enabled = Value
        cbDefAccount.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadADV(ID As String)
        Dim query As String
        query = " SELECT  TransID, ADV_No, tblADV.VCECOde, VCEName, DateADV, ISNULL(TotalAmount,0) AS TotalAmount, AccntCode, " & _
                "         ISNULL(ADV_Percent,0) AS ADV_Percent, ISNULL(ADV_Amount,0) AS ADV_Amount, Remarks, PO_Ref, tblADV.Status  " & _
                " FROM    tblADV INNER JOIN tblVCE_Master " & _
                " ON      tblADV.VCECode = tblVCE_Master.VCECode " & _
                " WHERE   TransID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            ADVNo = SQL.SQLDR("ADV_No").ToString
            txtTransNum.Text = ADVNo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            dtpDocDate.Value = SQL.SQLDR("DateADV")
            txtTotalAmount.Text = CDec(SQL.SQLDR("TotalAmount")).ToString("N2")
            txtAdvPercent.Text = CDec(SQL.SQLDR("ADV_Percent")).ToString("N2")
            txtAdvAmount.Text = CDec(SQL.SQLDR("ADV_Amount")).ToString("N2")
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            RefID = SQL.SQLDR("PO_Ref").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            cbDefAccount.SelectedItem = GetAccntTitle(SQL.SQLDR("AccntCode").ToString)
            txtPORef.Text = LoadPONo(RefID)
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
        txtRemarks.Clear()
        txtPORef.Clear()
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        txtAdvPercent.Text = "0.00"
        txtAdvAmount.Text = "0.00"
        txtTotalAmount.Text = "0.00"
    End Sub

    Private Sub LoadPO(ByVal ID As String)
        Dim query As String
        query = " SELECT    tblPO.TransID, tblPO.PO_No, DatePO AS Date, tblPO.VCECode, VCEName,  " & _
                " 		    NetAmount AS NetPurchase, " & _
                " 		    Remarks, AccntCode " & _
                " FROM      tblPO INNER JOIN tblVCE_Master " & _
                " ON        tblPO.VCECode = tblVCE_Master.VCECode " & _
                " INNER JOIN viewPO_Status " & _
                " ON        tblPO.TransID = viewPO_Status.TransID " & _
                " WHERE     viewPO_Status.Status ='Active' AND tblPO.TransID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            RefID = SQL.SQLDR("TransID")
            txtPORef.Text = SQL.SQLDR("PO_No").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtTotalAmount.Text = CDec(SQL.SQLDR("NetPurchase")).ToString("N2")
            txtAdvPercent.Text = "100.00"
            txtAdvAmount.Text = CDec(SQL.SQLDR("NetPurchase")).ToString("N2")
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtPORef.Enabled = False
        Else
            ClearText()
        End If
    End Sub

    Public Function GetTransID() As Integer
        Dim query As String
        query = " SELECT MAX(TransID) + 1 AS TransID FROM tblADV"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read() And Not IsDBNull(SQL.SQLDR("TransID")) Then
            Return SQL.SQLDR("TransID")
        Else
            Return 1
        End If
    End Function

    Private Sub SaveADV()
        Try
            If cbDefAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbDefAccount.SelectedItem)
            End If
            Dim insertSQL As String
            activityStatus = True
            insertSQL = " INSERT INTO " & _
                    " tblADV    (TransID, ADV_No, BranchCode, BusinessCode, VCECode, DateADV,  TotalAmount, AccntCode, ADV_Percent,  ADV_Amount, Remarks, PO_Ref, WhoCreated) " & _
                    " VALUES (@TransID, @ADV_No, @BranchCode, @BusinessCode, @VCECode, @DateADV, @TotalAmount, @AccntCode, @ADV_Percent, @ADV_Amount, @Remarks, @PO_Ref, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@ADV_No", ADVNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateADV", dtpDocDate.Value.Date)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@TotalAmount", IIf(txtTotalAmount.Text = "", 0, CDec(txtTotalAmount.Text)))
            SQL.AddParam("@ADV_Percent", IIf(txtAdvPercent.Text = "", 0, CDec(txtAdvPercent.Text)))
            SQL.AddParam("@ADV_Amount", IIf(txtAdvAmount.Text = "", 0, CDec(txtAdvAmount.Text)))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@PO_Ref", RefID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "ADV_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateADV()
        Try
            If cbDefAccount.SelectedIndex = -1 Then
                AccntCode = ""
            Else
                AccntCode = GetAccntCode(cbDefAccount.SelectedItem)
            End If
            Dim insertSQL As String
            activityStatus = True
            insertSQL = " UPDATE tblADV " & _
                        " SET    ADV_No = @ADV_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, " & _
                        "        VCECode = @VCECode, DateADV = @DateADV, TotalAmount = @TotalAmount,   " & _
                        "        ADV_Percent = @ADV_Percent, ADV_Amount = @ADV_Amount, AccntCode = @AccntCode, " & _
                        "        Remarks = @Remarks, PO_Ref = @PO_Ref, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@ADV_No", ADVNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateADV", dtpDocDate.Value.Date)
            SQL.AddParam("@AccntCode", AccntCode)
            SQL.AddParam("@TotalAmount", IIf(txtTotalAmount.Text = "", 0, CDec(txtTotalAmount.Text)))
            SQL.AddParam("@ADV_Percent", IIf(txtAdvPercent.Text = "", 0, CDec(txtAdvPercent.Text)))
            SQL.AddParam("@ADV_Amount", IIf(txtAdvAmount.Text = "", 0, CDec(txtAdvAmount.Text)))
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@PO_Ref", RefID)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "ADV_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTotalAmount.KeyDown
        Try
            If e.KeyValue <> 8 And Not (e.KeyValue >= 48 And e.KeyValue <= 57) Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("ADV_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("ADV")
            TransID = f.transID
            LoadADV(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("ADV_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            ADVNo = ""

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
        If Not AllowAccess("ADV_EDIT") Then
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
        ElseIf txtRemarks.Text = "" Then
            Msg("Please enter a remark/short explanation", MsgBoxStyle.Exclamation)
        ElseIf cbDefAccount.SelectedIndex = -1 Then
            Msg("Please select default advances account!", MsgBoxStyle.Exclamation)
        ElseIf Not IsNumeric(txtAdvAmount.Text) Then
            Msg("Invalid Advance Amount!", MsgBoxStyle.Exclamation)
        ElseIf CDec(txtAdvAmount.Text) <= 0 Then
            Msg("Advance Amount should be greater than zero!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                ADVNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = ADVNo
                SaveADV()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                ADVNo = txtTransNum.Text
                LoadADV(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateADV()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                ADVNo = txtTransNum.Text
                LoadADV(TransID)
            End If
        End If
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrint.Click
        Dim f As New frmReport_Display
        f.ShowDialog("ADV", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("ADV_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblADV SET Status ='Cancelled' WHERE ADV_No = @ADV_No "
                        SQL.FlushParams()
                        ADVNo = txtTransNum.Text
                        SQL.AddParam("@ADV_No", ADVNo)
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

                        ADVNo = txtTransNum.Text
                        LoadADV(ADVNo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "ADV_No", ADVNo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If ADVNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 ADV_No FROM tblADV  WHERE ADV_No < '" & ADVNo & "' ORDER BY ADV_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                ADVNo = SQL.SQLDR("ADV_No").ToString
                LoadADV(ADVNo)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If ADVNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 ADV_No FROM tblADV  WHERE ADV_No > '" & ADVNo & "' ORDER BY ADV_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                ADVNo = SQL.SQLDR("ADV_No").ToString
                LoadADV(ADVNo)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If ADVNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadADV(ADVNo)
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

    Private Sub frmADV_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
                If tsbPrint.Enabled = True Then
                    tsbPrint.PerformClick()
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
        f.ShowDialog("PO")
        LoadPO(f.transID)
        f.Dispose()
    End Sub

    Private Sub Validate_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAdvPercent.KeyDown, txtAdvAmount.KeyDown
        Try
            If e.KeyValue <> 8 And Not (e.KeyValue >= 48 And e.KeyValue <= 57) Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtAdvPercent_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAdvPercent.TextChanged
        If disableEvent = False Then
            If IsNumeric(txtAdvPercent.Text) Then
                If CDec(txtAdvPercent.Text) > 100 Then
                    txtAdvPercent.Text = "100.00"
                    txtAdvPercent.SelectionStart = txtAdvPercent.TextLength
                ElseIf CDec(txtAdvPercent.Text) > 0 Then
                    txtAdvAmount.Text = CDec(CDec(txtTotalAmount.Text) * (CDec(txtAdvPercent.Text) / 100.0)).ToString("N2")
                End If
            Else
                txtAdvAmount.Text = "0.00"
            End If
        End If

    End Sub

    Private Sub cbDefAccount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbDefAccount.KeyPress
        e.Handled = True
    End Sub
End Class