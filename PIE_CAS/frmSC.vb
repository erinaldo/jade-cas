Public Class frmSC
    Dim TransID, RefID, JETransID As String
    Dim SCNo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "SC"
    Dim ColumnPK As String = "SC_No"
    Dim DBTable As String = "tblSC"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim accntDR, accntCR, accntVAT, accntDiscount As String
    Dim FileName As String

    Private Sub frmSC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadArea()
        LoadRegion()
        LoadProvince()
        LoadCity()
        LoadType()
        LoadSize()
        LoadContractType()
        TransAuto = GetTransSetup(ModuleID)

        dtpDocDate.Value = Date.Today.Date
        If TransID <> "" Then
            LoadSC(TransID)
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
        tsbApprove.Enabled = False
        EnableControl(False)
    End Sub

    Private Sub LoadArea(Optional ByVal Area As String = "", Optional ByVal Region As String = "", Optional ByVal Province As String = "", Optional ByVal City As String = "")
        If disableEvent = False Then
            Dim query As String
            query = " SELECT  DISTINCT Area " & _
                    " FROM    tblLocation " & _
                    " ORDER BY Area "
            SQL.ReadQuery(query)
            cbArea.Items.Clear()
            cbArea.Items.Add("")
            While SQL.SQLDR.Read
                cbArea.Items.Add(SQL.SQLDR("Area"))
            End While
        End If
    End Sub

    Private Sub LoadRegion(Optional ByVal Area As String = "", Optional ByVal Region As String = "", Optional ByVal Province As String = "", Optional ByVal City As String = "")
        If disableEvent = False Then
            Dim query As String
            Dim filter As String = ""

            SQL.FlushParams()
            If Area <> "" Then
                filter = " WHERE   Area = @Area"
                SQL.AddParam("@Area", Area)
            ElseIf Region <> "" Then
                filter = " WHERE   Region = @Region"
                SQL.AddParam("@Region", Region)
            End If
            query = " SELECT  DISTINCT Area, Region " & _
                   " FROM    tblLocation " & filter & _
                   " ORDER BY Region "
            SQL.ReadQuery(query)
            If Region = "" Then cbRegion.Items.Clear()
            While SQL.SQLDR.Read
                disableEvent = True
                If Region <> "" Then
                    cbArea.SelectedItem = SQL.SQLDR("Area").ToString
                Else
                    cbRegion.Items.Add(SQL.SQLDR("Region"))
                End If
                disableEvent = False
            End While
        End If
    End Sub
    Private Sub LoadProvince(Optional ByVal Area As String = "", Optional ByVal Region As String = "", Optional ByVal Province As String = "", Optional ByVal City As String = "")
        If disableEvent = False Then
            Dim query As String
            Dim filter As String = ""
            SQL.FlushParams()
            If Area <> "" Then
                filter = " WHERE   Area = @Area "
                SQL.AddParam("@Area", Area)
            ElseIf Region <> "" Then
                filter = " WHERE   Region = @Region "
                SQL.AddParam("@Region", Region)
            ElseIf Province <> "" Then
                filter = " WHERE   Province = @Province "
                SQL.AddParam("@Province", Province)
            End If
            query = " SELECT  DISTINCT Area, Region, Province " & _
                    " FROM    tblLocation " & filter & _
                    " ORDER BY Province "
            SQL.ReadQuery(query)
            If Province = "" Then cbProvince.Items.Clear()
            While SQL.SQLDR.Read
                disableEvent = True
                If Province <> "" Then
                    cbArea.SelectedItem = SQL.SQLDR("Area").ToString
                    cbRegion.SelectedItem = SQL.SQLDR("Region").ToString
                Else
                    cbProvince.Items.Add(SQL.SQLDR("Province"))


                End If
                disableEvent = False
            End While
        End If
    End Sub
    Private Sub LoadCity(Optional ByVal Area As String = "", Optional ByVal Region As String = "", Optional ByVal Province As String = "", Optional ByVal City As String = "")
        If disableEvent = False Then
            Dim query As String
            Dim filter As String = ""

            SQL.FlushParams()
            If City <> "" Then
                filter = " WHERE   City = @City "
                SQL.AddParam("@City", City)
            ElseIf Province <> "" Then
                filter = " WHERE   Province = @Province "
                SQL.AddParam("@Province", Province)
            ElseIf Region <> "" Then
                filter = " WHERE   Region = @Region"
                SQL.AddParam("@Region", Region)
            ElseIf Area <> "" Then
                filter = " WHERE   Area = @Area "
                SQL.AddParam("@Area", Area)
            End If
            query = " SELECT DISTINCT Area, Region, Province, City " & _
                   " FROM    tblLocation " & filter & _
                   " ORDER BY City "
            SQL.ReadQuery(query)
            If City <> "" Then
                If SQL.SQLDR.Read Then
                    disableEvent = True
                    cbProvince.SelectedItem = SQL.SQLDR("Province").ToString
                    cbRegion.SelectedItem = SQL.SQLDR("Region").ToString
                    cbArea.SelectedItem = SQL.SQLDR("Area").ToString
                    disableEvent = False
                End If
            Else
                cbCity.Items.Clear()
                While SQL.SQLDR.Read
                    cbCity.Items.Add(SQL.SQLDR("City"))
                End While
            End If
        End If


    End Sub

    Private Sub cbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArea.SelectedIndexChanged
        If disableEvent = False Then
            If cbArea.SelectedItem = "" Then
                LoadRegion()
                LoadProvince()
                LoadCity()
            Else
                LoadRegion(cbArea.SelectedItem)
                LoadProvince(cbArea.SelectedItem)
                LoadCity(cbArea.SelectedItem)
            End If
        End If
    End Sub

    Private Sub cbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegion.SelectedIndexChanged
        If disableEvent = False Then
            LoadRegion("", cbRegion.SelectedItem)
            LoadProvince(cbArea.SelectedItem, cbRegion.SelectedItem)
            LoadCity(cbArea.SelectedItem, cbRegion.SelectedItem)
        End If

    End Sub

    Private Sub cbProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProvince.SelectedIndexChanged
        If disableEvent = False Then
            LoadProvince("", "", cbProvince.SelectedItem)
            LoadCity(cbArea.SelectedItem, cbRegion.SelectedItem, cbProvince.SelectedItem)
        End If
    End Sub

    Private Sub cbCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCity.SelectedIndexChanged
        If disableEvent = False Then
            If cbCity.SelectedIndex <> -1 Then
                LoadCity("", "", "", cbCity.SelectedItem)
            End If
        End If
    End Sub

    Private Sub LoadType()
        Dim query As String
        query = " SELECT DISTINCT Type " & _
                " FROM   tblSC " & _
                " ORDER BY Type "
        SQL.ReadQuery(query)
        cbType.Items.Clear()
        While SQL.SQLDR.Read
            cbType.Items.Add(SQL.SQLDR("Type"))
        End While
    End Sub

    Private Sub LoadSize()
        Dim query As String
        query = " SELECT DISTINCT Size FROM tblSC_Software "
        SQL.ReadQuery(query)
        cbSize.Items.Clear()
        While SQL.SQLDR.Read
            cbSize.Items.Add(SQL.SQLDR("Size").ToString)
        End While
    End Sub

    Private Sub LoadContractType()
        Dim query As String
        query = " SELECT DISTINCT Type FROM tblSC_Software "
        SQL.ReadQuery(query)
        cbContractType.Items.Clear()
        While SQL.SQLDR.Read
            cbContractType.Items.Add(SQL.SQLDR("Type").ToString)
        End While
    End Sub

    Private Sub tsbNew_Click(sender As Object, e As EventArgs) Handles tsbNew.Click
        If Not AllowAccess("SC_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            SCNo = ""

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
            tsbApprove.Enabled = False
            EnableControl(True)
            disableEvent = False
            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        btnSearchVCE.Enabled = Value

        dgvSoftware.AllowUserToAddRows = Value
        dgvSoftware.AllowUserToDeleteRows = Value
        dgvSoftware.ReadOnly = Not Value
        If Value = True Then
            dgvSoftware.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvSoftware.EditMode = DataGridViewEditMode.EditProgrammatically
        End If

        dgvHardware.AllowUserToAddRows = Value
        dgvHardware.AllowUserToDeleteRows = Value
        dgvHardware.ReadOnly = Not Value
        If Value = True Then
            dgvHardware.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvHardware.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        txtDiscount.Enabled = Value
        txtVCEName.Enabled = Value
        txtVCECode.Enabled = Value
        txtAddress.Enabled = Value
        txtContactNum.Enabled = Value
        txtContactPerson.Enabled = Value
        txtEmail.Enabled = Value
        txtRemarks.Enabled = Value
        txtSignatory.Enabled = Value
        txtPosition.Enabled = Value
        txtTitle.Enabled = Value
        chkVAT.Enabled = Value
        chkVATinc.Enabled = Value
        gbTerms.Enabled = Value
        gbMaintenance.Enabled = Value
        cbArea.Enabled = Value
        cbRegion.Enabled = Value
        cbProvince.Enabled = Value
        cbCity.Enabled = Value
        cbContractType.Enabled = Value
        cbType.Enabled = Value
        cbSize.Enabled = Value
        dtpDocDate.Enabled = Value

        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadSoftware(ByVal itemCode As String)
        Dim query As String
        query = " SELECT DISTINCT  SoftwareCode, SoftwareName, Price " & _
                " FROM    tblSC_Software " & _
                " WHERE  SoftwareCode = '" & itemCode & "' "

        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            dgvSoftware.Rows.Add(New String() {SQL.SQLDR("SoftwareCode").ToString, SQL.SQLDR("SoftwareName").ToString, CDec(SQL.SQLDR("Price")).ToString("N2")})
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("SC_EDIT") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbCancel.Enabled = True
            tsbClose.Enabled = True
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtVCEName.Text = "" Then
            Msg("Please enter Customer Name!", MsgBoxStyle.Exclamation)
        ElseIf txtAddress.Text = "" Then
            Msg("Please enter Customer Address!", MsgBoxStyle.Exclamation)
        ElseIf txtAddress.Text = "" Then
            Msg("Please enter Customer Address!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                SCNo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = SCNo
                SaveSC()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                SCNo = txtTransNum.Text
                LoadSC(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateSC()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                SCNo = txtTransNum.Text
                LoadSC(TransID)
            End If
        End If
    End Sub

    Private Sub UpdateSC()
        Try
            activityStatus = True
            Dim updateSQL, insertSQL, deleteSQL As String
            updateSQL = " UPDATE tblSC" & _
                        " SET    SC_No = @SC_No, DateSC = @DateSC, VCECode = @VCECode, VCEName = @VCEName, SignatoryName = @SignatoryName, " & _
                        "        ContactNo = @ContactNo, ContactPerson = @ContactPerson, Email = @Email, SignatoryPosition = @SignatoryPosition, " & _
                        "        Address = @Address, Area = @Area, Region = @Region, Province = @Province, City = @City, ProposalTitle = @ProposalTitle," & _
                        "        Type = @Type, Size = @Size, ContractType = @ContractType, Remarks = @Remarks, " & _
                        "        GrossAmount = @GrossAmount, Discount = @Discount, VATAmount = @VATAmount, NetAmount = @NetAmount, " & _
                        "        VATable = @VATable, VATInclusive = @VATInclusive, " & _
                        "        RecurFee = @RecurFee, RecurFeeAmt = @RecurFeeAmt, RecurFeeDate = @RecurFeeDate, RecurFeePeriod = @RecurFeePeriod, " & _
                        "        TermsType = @TermsType, TermsDP = @TermsDP, TermsRetention = @TermsRetention, TermsBalance = @TermsBalance, TermsPDC = @TermsPDC " & _
                        " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@SC_No", SCNo)
            SQL.AddParam("@DateSC", dtpDocDate.Value.Date)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@VCEName", txtVCEName.Text)
            SQL.AddParam("@Address", txtAddress.Text)
            SQL.AddParam("@ContactNo", txtContactNum.Text)
            SQL.AddParam("@ContactPerson", txtContactPerson.Text)
            SQL.AddParam("@Email", txtEmail.Text)
            SQL.AddParam("@Area", cbArea.SelectedItem)
            SQL.AddParam("@Region", cbRegion.SelectedItem)
            SQL.AddParam("@Province", cbProvince.SelectedItem)
            SQL.AddParam("@City", cbCity.SelectedItem)
            SQL.AddParam("@Type", cbType.Text)
            SQL.AddParam("@Size", cbSize.SelectedItem)
            SQL.AddParam("@ContractType", cbContractType.SelectedItem)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@SignatoryName", txtSignatory.Text)
            SQL.AddParam("@SignatoryPosition", txtPosition.Text)
            SQL.AddParam("@ProposalTitle", txtTitle.Text)
            SQL.AddParam("@GrossAmount", CDec(txtGross.Text))
            SQL.AddParam("@Discount", CDec(txtDiscount.Text))
            SQL.AddParam("@VATAmount", CDec(txtVAT.Text))
            SQL.AddParam("@NetAmount", CDec(txtNet.Text))
            SQL.AddParam("@VATable", chkVAT.Checked)
            SQL.AddParam("@VATInclusive", chkVATinc.Checked)
            SQL.AddParam("@RecurFee", chkMaintFee.Checked)
            If chkMaintFee.Checked Then
                SQL.AddParam("@RecurFeeAmt", CDec(txtMaintAmount.Text))
                SQL.AddParam("@RecurFeeDate", dtpMaintStart.Value.Date)
                SQL.AddParam("@RecurFeePeriod", cbMaintPeriod.SelectedItem)
            Else
                SQL.AddParam("@RecurFeeAmt", 0.0)
                SQL.AddParam("@RecurFeeDate", dtpDocDate.Value.Date)
                SQL.AddParam("@RecurFeePeriod", "Monthly")
            End If
            If rbInstallment.Checked = True Then
                SQL.AddParam("@TermsType", "Installment")
                SQL.AddParam("@TermsDP", CDec(txtDP.Text))
                SQL.AddParam("@TermsRetention", CDec(txtRetention.Text))
                SQL.AddParam("@TermsBalance", CInt(nupBalance.Value))
                SQL.AddParam("@TermsPDC", chkPDC.Checked)
            Else
                SQL.AddParam("@TermsType", "Progress")
                SQL.AddParam("@TermsDP", 0.0)
                SQL.AddParam("@TermsRetention", 0.0)
                SQL.AddParam("@TermsBalance", 0)
                SQL.AddParam("@TermsPDC", False)
            End If

            SQL.ExecNonQuery(updateSQL)

            ' IF PROGRESS BILLING UPDATE PROGRESS BREAKDOWN

            deleteSQL = " DELETE FROM tblSC_Progress WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            If rbProgress.Checked = True Then
                For Each row As DataGridViewRow In dgvProgress.Rows
                    If Not row.Cells(dgcTermRemarks.Index).Value Is Nothing AndAlso IsNumeric(row.Cells(dgcTermPercent.Index).Value) Then
                        insertSQL = " INSERT INTO " & _
                                    " tblSC_Progress(TransID, Progress, Remarks, WhoCreated) " & _
                                    " VALUES(@TransID, @Progress, @Remarks, @WhoCreated) "
                        SQL.FlushParams()
                        SQL.AddParam("@TransID", TransID)
                        SQL.AddParam("@Progress", row.Cells(dgcTermPercent.Index).Value)
                        SQL.AddParam("@Remarks", row.Cells(dgcTermRemarks.Index).Value)
                        SQL.AddParam("@WhoCreated", UserID)
                        SQL.ExecNonQuery(insertSQL)
                    End If
                Next
            End If


            deleteSQL = " DELETE FROM tblSC_Details WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            ' UPDATE SOFTWARE ITEMS
            Dim line As Integer = 1
            For Each row As DataGridViewRow In dgvSoftware.Rows
                If Not row.Cells(dgcCode.Index).Value Is Nothing AndAlso Not row.Cells(dgcSoftPrice.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblSC_Details(TransId, Type, ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, VATable, VATAmount, " & _
                                "                DiscountRate, Discount, NetAmount, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @Type, @ItemCode, @Description, @UOM, @QTY, @UnitPrice, @GrossAmount, @VATable, @VATAmount, " & _
                                "        @DiscountRate, @Discount, @NetAmount, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@Type", "Software")
                    SQL.AddParam("@ItemCode", IIf(row.Cells(dgcCode.Index).Value = Nothing, "", row.Cells(dgcCode.Index).Value))
                    SQL.AddParam("@Description", row.Cells(dgcSoftDesc.Index).Value.ToString)
                    SQL.AddParam("@UOM", "EA")
                    SQL.AddParam("@QTY", 1)
                    SQL.AddParam("@UnitPrice", CDec(row.Cells(dgcSoftPrice.Index).Value))
                    SQL.AddParam("@GrossAmount", CDec(row.Cells(dgcSoftPrice.Index).Value))
                    SQL.AddParam("@VATable", 0)
                    SQL.AddParam("@VATAmount", 0)
                    SQL.AddParam("@DiscountRate", 0)
                    SQL.AddParam("@Discount", 0)
                    SQL.AddParam("@NetAmount", CDec(row.Cells(dgcSoftPrice.Index).Value))
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next

            ' HARDWARE
            line = 1
            For Each row As DataGridViewRow In dgvHardware.Rows
                If Not row.Cells(dgcHardDesc.Index).Value Is Nothing AndAlso Not row.Cells(dgcHardPrice.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblSC_Details(TransId, Type, ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, VATable, VATAmount, " & _
                                "                DiscountRate, Discount, NetAmount, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @Type, @ItemCode, @Description, @UOM, @QTY, @UnitPrice, @GrossAmount, @VATable, @VATAmount, " & _
                                "        @DiscountRate, @Discount, @NetAmount, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@Type", "Hardware")
                    SQL.AddParam("@ItemCode", "")
                    SQL.AddParam("@Description", row.Cells(dgcHardDesc.Index).Value.ToString)
                    SQL.AddParam("@UOM", "EA")
                    SQL.AddParam("@QTY", 1)
                    SQL.AddParam("@UnitPrice", CDec(row.Cells(dgcHardPrice.Index).Value))
                    SQL.AddParam("@GrossAmount", CDec(row.Cells(dgcHardPrice.Index).Value))
                    SQL.AddParam("@VATable", 0)
                    SQL.AddParam("@VATAmount", 0)
                    SQL.AddParam("@DiscountRate", 0)
                    SQL.AddParam("@Discount", 0)
                    SQL.AddParam("@NetAmount", CDec(row.Cells(dgcHardPrice.Index).Value))
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As System.Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "SC_No", txtVCECode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub LoadSC(ByVal TransID As String)
        Dim query As String
        query = " SELECT   TransID, SC_No, DateSC, VCECode, VCEName, ContractType, Size, Type, SignatoryName, SignatoryPosition, ProposalTitle, " & _
                "          Address, City, Province, Region, Area, ContactPerson, ContactNo, Email, Remarks, " & _
                "          GrossAmount, Discount, VATAmount, NetAmount, VATable, VATInclusive, " & _
                "          RecurFee, RecurFeeAmt, RecurFeeDate, RecurFeePeriod, Status, " & _
                "          TermsType, TermsDP, TermsRetention, TermsBalance, TermsPDC " & _
                " FROM     tblSC " & _
                " WHERE    TransId = '" & TransID & "' " & _
                " ORDER BY TransId "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            disableEvent = True
            TransID = SQL.SQLDR("TransID").ToString
            SCNo = SQL.SQLDR("SC_No").ToString
            txtTransNum.Text = SCNo
            dtpDocDate.Text = SQL.SQLDR("DateSC").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            cbContractType.SelectedItem = SQL.SQLDR("ContractType").ToString
            cbSize.SelectedItem = SQL.SQLDR("Size").ToString
            cbType.Text = SQL.SQLDR("Type").ToString
            txtAddress.Text = SQL.SQLDR("Address").ToString
            cbCity.SelectedItem = SQL.SQLDR("City").ToString
            cbProvince.SelectedItem = SQL.SQLDR("Province").ToString
            cbRegion.SelectedItem = SQL.SQLDR("Region").ToString
            cbArea.SelectedItem = SQL.SQLDR("Area").ToString
            txtContactPerson.Text = SQL.SQLDR("ContactPerson").ToString
            txtContactNum.Text = SQL.SQLDR("ContactNo").ToString
            txtEmail.Text = SQL.SQLDR("Email").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtSignatory.Text = SQL.SQLDR("SignatoryName").ToString
            txtPosition.Text = SQL.SQLDR("SignatoryPosition").ToString
            txtTitle.Text = SQL.SQLDR("ProposalTitle").ToString
            txtGross.Text = CDec(SQL.SQLDR("GrossAmount").ToString).ToString("N2")
            txtVAT.Text = CDec(SQL.SQLDR("VATAmount").ToString).ToString("N2")
            txtDiscount.Text = CDec(SQL.SQLDR("Discount").ToString).ToString("N2")
            txtNet.Text = CDec(SQL.SQLDR("NetAmount").ToString).ToString("N2")
            chkVAT.Checked = SQL.SQLDR("VATable")
            chkVATinc.Checked = SQL.SQLDR("VATInclusive")
            txtStatus.Text = SQL.SQLDR("Status").ToString
            disableEvent = False

            If SQL.SQLDR("TermsType").ToString = "Installment" Then
                rbInstallment.Checked = True
            Else
                rbProgress.Checked = True
            End If
            chkMaintFee.Checked = SQL.SQLDR("RecurFee")

            disableEvent = True
            txtDP.Text = SQL.SQLDR("TermsDP").ToString
            txtRetention.Text = SQL.SQLDR("TermsRetention").ToString
            nupBalance.Value = SQL.SQLDR("TermsBalance").ToString
            chkPDC.Checked = SQL.SQLDR("TermsPDC")
            If SQL.SQLDR("RecurFee") = True Then
                txtMaintAmount.Text = CDec(SQL.SQLDR("RecurFeeAmt")).ToString("N2")
                dtpDocDate.Value = (SQL.SQLDR("RecurFeeDate"))
                cbMaintPeriod.SelectedItem = SQL.SQLDR("RecurFeePeriod").ToString
            End If
            disableEvent = False


            LoadSCDetails(TransID)
            ComputeTotal()

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
            EnableControl(False)
        Else
            ClearText()
        End If
    End Sub

    Private Sub ClearText()
        txtVCECode.Clear()
        txtVCEName.Clear()
        txtAddress.Clear()
        txtContactNum.Clear()
        txtContactPerson.Clear()
        txtRemarks.Clear()
        txtEmail.Clear()
        txtTransNum.Clear()
        txtSignatory.Clear()
        txtPosition.Clear()
        txtTitle.Clear()
        cbArea.SelectedIndex = -1
        cbRegion.SelectedIndex = -1
        cbProvince.SelectedIndex = -1
        cbCity.SelectedIndex = -1
        dgvSoftware.Rows.Clear()
        dgvHardware.Rows.Clear()
        cbContractType.SelectedIndex = -1
        cbType.Text = ""
        cbSize.SelectedIndex = -1

        ' MAINTENANCE FEE CONTROL
        cbMaintPeriod.SelectedItem = "Monthly"
        txtMaintAmount.Text = "0.00"
        dtpMaintStart.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, dtpDocDate.Value))

        txtHardTotal.Text = "0.00"
        txtSoftTotal.Text = "0.00"
        txtGross.Text = "0.00"
        txtNet.Text = "0.00"
        txtDiscount.Text = "0.00"
        txtVAT.Text = "0.00"
        dtpDocDate.Value = Date.Today.Date
        txtStatus.Text = "Open"
    End Sub

    Protected Sub LoadSCDetails(ByVal TransID As String)
        dgvSoftware.Rows.Clear()
        dgvHardware.Rows.Clear()

        Dim query As String
        query = " SELECT    Type, ItemCode, Description, UOM, QTY, ISNULL(UnitPrice,0) AS UnitPrice, " & _
                "           ISNULL(GrossAmount,0) AS GrossAmount, ISNULL(DiscountRate,0) AS DiscountRate, ISNULL(Discount,0) AS Discount, " & _
                "           ISNULL(VATAmount,0) AS VATAmount, ISNULL(NetAmount,0) AS NetAmount, ISNULL(VATable,1) AS VATable " & _
                " FROM      tblSC_Details " & _
                " WHERE     tblSC_Details.TransId = " & TransID & " " & _
                " ORDER BY  LineNum "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            If SQL.SQLDR("Type").ToString = "Software" Then
                dgvSoftware.Rows.Add(SQL.SQLDR("ItemCode").ToString, SQL.SQLDR("Description").ToString,
                                CDec(SQL.SQLDR("GrossAmount")).ToString("N2"))
            Else
                dgvHardware.Rows.Add(SQL.SQLDR("Description").ToString,
                                CDec(SQL.SQLDR("GrossAmount")).ToString("N2"))
            End If

        End While
    End Sub

    Private Function RecordExist(ByVal Record As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblSC WHERE TransID ='" & Record & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub SaveSC()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblSC(TransID, SC_No, BranchCode, BusinessCode, DateSC, VCECode, VCEName, ContactNo, ContactPerson, Email, ProposalTitle, " & _
                        "        Address, Area, Region, Province, City, Type, Size, ContractType, Remarks, SignatoryName, SignatoryPosition, " & _
                        "        GrossAmount, Discount, VATAmount, NetAmount, VATable, VATInclusive, " & _
                        "        RecurFee, RecurFeeAmt, RecurFeeDate, RecurFeePeriod, " & _
                        "        TermsType, TermsDP, TermsRetention, TermsBalance, TermsPDC) " & _
                        " VALUES(@TransID, @SC_No, @BranchCode, @BusinessCode, @DateSC, @VCECode, @VCEName, @ContactNo, @ContactPerson, @Email, @ProposalTitle," & _
                        "        @Address, @Area, @Region, @Province, @City, @Type, @Size, @ContractType, @Remarks, @SignatoryName, @SignatoryPosition, " & _
                        "        @GrossAmount, @Discount, @VATAmount, @NetAmount, @VATable, @VATInclusive, " & _
                        "        @RecurFee, @RecurFeeAmt, @RecurFeeDate, @RecurFeePeriod, " & _
                        "        @TermsType, @TermsDP, @TermsRetention, @TermsBalance, @TermsPDC) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@SC_No", SCNo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateSC", dtpDocDate.Value.Date)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@VCEName", txtVCEName.Text)
            SQL.AddParam("@Address", txtAddress.Text)
            SQL.AddParam("@ContactNo", txtContactNum.Text)
            SQL.AddParam("@ContactPerson", txtContactPerson.Text)
            SQL.AddParam("@Email", txtEmail.Text)
            SQL.AddParam("@Area", cbArea.SelectedItem)
            SQL.AddParam("@Region", cbRegion.SelectedItem)
            SQL.AddParam("@Province", cbProvince.SelectedItem)
            SQL.AddParam("@City", cbCity.SelectedItem)
            SQL.AddParam("@Type", cbType.Text)
            SQL.AddParam("@Size", cbSize.SelectedItem)
            SQL.AddParam("@ContractType", cbContractType.SelectedItem)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@SignatoryName", txtSignatory.Text)
            SQL.AddParam("@SignatoryPosition", txtPosition.Text)
            SQL.AddParam("@ProposalTitle", txtTitle.Text)
            SQL.AddParam("@GrossAmount", CDec(txtGross.Text))
            SQL.AddParam("@Discount", CDec(txtDiscount.Text))
            SQL.AddParam("@VATAmount", CDec(txtVAT.Text))
            SQL.AddParam("@NetAmount", CDec(txtNet.Text))
            SQL.AddParam("@VATable", chkVAT.Checked)
            SQL.AddParam("@VATInclusive", chkVATinc.Checked)
            SQL.AddParam("@RecurFee", chkMaintFee.Checked)
            If chkMaintFee.Checked Then
                SQL.AddParam("@RecurFeeAmt", CDec(txtMaintAmount.Text))
                SQL.AddParam("@RecurFeeDate", dtpMaintStart.Value.Date)
                SQL.AddParam("@RecurFeePeriod", cbMaintPeriod.SelectedItem)
            Else
                SQL.AddParam("@RecurFeeAmt", 0.0)
                SQL.AddParam("@RecurFeeDate", dtpDocDate.Value.Date)
                SQL.AddParam("@RecurFeePeriod", "Monthly")
            End If
            If rbInstallment.Checked = True Then
                SQL.AddParam("@TermsType", "Installment")
                SQL.AddParam("@TermsDP", CDec(txtDP.Text))
                SQL.AddParam("@TermsRetention", CDec(txtRetention.Text))
                SQL.AddParam("@TermsBalance", CInt(nupBalance.Value))
                SQL.AddParam("@TermsPDC", chkPDC.Checked)
            Else
                SQL.AddParam("@TermsType", "Progress")
                SQL.AddParam("@TermsDP", 0.0)
                SQL.AddParam("@TermsRetention", 0.0)
                SQL.AddParam("@TermsBalance", 0)
                SQL.AddParam("@TermsPDC", False)
            End If

            SQL.ExecNonQuery(insertSQL)

            ' IF PROGRESS BILLING SAVE PROGRESS BREAKDOWN
            If rbProgress.Checked = True Then
                For Each row As DataGridViewRow In dgvProgress.Rows
                    If Not row.Cells(dgcTermRemarks.Index).Value Is Nothing AndAlso IsNumeric(row.Cells(dgcTermPercent.Index).Value) Then
                        insertSQL = " INSERT INTO " & _
                                    " tblSC_Progress(TransID, Progress, Remarks, WhoCreated) " & _
                                    " VALUES(@TransID, @Progress, @Remarks, @WhoCreated) "
                        SQL.FlushParams()
                        SQL.AddParam("@TransID", TransID)
                        SQL.AddParam("@Progress", row.Cells(dgcTermPercent.Index).Value)
                        SQL.AddParam("@Remarks", row.Cells(dgcTermRemarks.Index).Value)
                        SQL.AddParam("@WhoCreated", UserID)
                        SQL.ExecNonQuery(insertSQL)
                    End If
                Next
            End If

            ' SOFTWARE
            Dim line As Integer = 1
            For Each row As DataGridViewRow In dgvSoftware.Rows
                If Not row.Cells(dgcCode.Index).Value Is Nothing AndAlso Not row.Cells(dgcSoftPrice.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblSC_Details(TransId, Type, ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, VATable, VATAmount, " & _
                                "                DiscountRate, Discount, NetAmount, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @Type, @ItemCode, @Description, @UOM, @QTY, @UnitPrice, @GrossAmount, @VATable, @VATAmount, " & _
                                "        @DiscountRate, @Discount, @NetAmount, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@Type", "Software")
                    SQL.AddParam("@ItemCode", IIf(row.Cells(dgcCode.Index).Value = Nothing, "", row.Cells(dgcCode.Index).Value))
                    SQL.AddParam("@Description", row.Cells(dgcSoftDesc.Index).Value.ToString)
                    SQL.AddParam("@UOM", "EA")
                    SQL.AddParam("@QTY", 1)
                    SQL.AddParam("@UnitPrice", CDec(row.Cells(dgcSoftPrice.Index).Value))
                    SQL.AddParam("@GrossAmount", CDec(row.Cells(dgcSoftPrice.Index).Value))
                    SQL.AddParam("@VATable", 0)
                    SQL.AddParam("@VATAmount", 0)
                    SQL.AddParam("@DiscountRate", 0)
                    SQL.AddParam("@Discount", 0)
                    SQL.AddParam("@NetAmount", CDec(row.Cells(dgcSoftPrice.Index).Value))
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next

            ' HARDWARE
            line = 1
            For Each row As DataGridViewRow In dgvHardware.Rows
                If Not row.Cells(dgcHardDesc.Index).Value Is Nothing AndAlso Not row.Cells(dgcHardPrice.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblSC_Details(TransId, Type, ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, VATable, VATAmount, " & _
                                "                DiscountRate, Discount, NetAmount, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @Type, @ItemCode, @Description, @UOM, @QTY, @UnitPrice, @GrossAmount, @VATable, @VATAmount, " & _
                                "        @DiscountRate, @Discount, @NetAmount, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@Type", "Hardware")
                    SQL.AddParam("@ItemCode", "")
                    SQL.AddParam("@Description", row.Cells(dgcHardDesc.Index).Value.ToString)
                    SQL.AddParam("@UOM", "EA")
                    SQL.AddParam("@QTY", 1)
                    SQL.AddParam("@UnitPrice", CDec(row.Cells(dgcHardPrice.Index).Value))
                    SQL.AddParam("@GrossAmount", CDec(row.Cells(dgcHardPrice.Index).Value))
                    SQL.AddParam("@VATable", 0)
                    SQL.AddParam("@VATAmount", 0)
                    SQL.AddParam("@DiscountRate", 0)
                    SQL.AddParam("@Discount", 0)
                    SQL.AddParam("@NetAmount", CDec(row.Cells(dgcHardPrice.Index).Value))
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As System.Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "SC_No", txtVCECode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If SCNo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadSC(TransID)
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

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        frmSP_Software.ShowDialog()
        LoadSize()
        LoadContractType()
    End Sub
    Private Sub dgvSoftware_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSoftware.CellEndEdit
        Try
            If cbContractType.SelectedIndex = -1 Then
                Msg("Please select contract type first", MsgBoxStyle.Exclamation)
            ElseIf cbSize.SelectedIndex = -1 Then
                Msg("Please select client size", MsgBoxStyle.Exclamation)
            Else
                Dim itemCode As String
                Dim rowIndex As Integer = dgvSoftware.CurrentCell.RowIndex
                Dim colindex As Integer = dgvSoftware.CurrentCell.ColumnIndex
                Select Case colindex
                    Case dgcSoftDesc.Index
                        If dgvSoftware.Item(dgcSoftDesc.Index, e.RowIndex).Value <> "" Then
                            itemCode = dgvSoftware.Item(dgcSoftDesc.Index, e.RowIndex).Value
                            Dim f As New frmCopyFrom
                            f.ShowDialog("ItemListSoftware", itemCode, cbContractType.SelectedItem, cbSize.SelectedItem)
                            If f.TransID <> "" Then
                                itemCode = f.TransID
                                LoadSoftware(itemCode)
                            End If
                            dgvSoftware.Rows.RemoveAt(e.RowIndex)
                            f.Dispose()
                        End If
                End Select
                ComputeTotal()
            End If

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub ComputeTotal()
        ' COMPUTE SOFTWARE
        txtSoftTotal.Text = "0.00"
        txtHardTotal.Text = "0.00"
        If dgvSoftware.Rows.Count > 0 Then
            Dim a As Decimal = 0
            ' COMPUTE GROSS
            For i As Integer = 0 To dgvSoftware.Rows.Count - 1
                If Val(dgvSoftware.Item(dgcSoftPrice.Index, i).Value) <> 0 Then
                    If IsNumeric(dgvSoftware.Item(dgcSoftPrice.Index, i).Value) Then
                        a = a + Double.Parse(dgvSoftware.Item(dgcSoftPrice.Index, i).Value).ToString
                    End If
                End If
            Next
            txtSoftTotal.Text = a.ToString("N2")
        End If

        ' COMPUTE HARDWARE
        If dgvHardware.Rows.Count > 0 Then
            Dim a As Decimal = 0
            ' COMPUTE GROSS
            For i As Integer = 0 To dgvHardware.Rows.Count - 1
                If Val(dgvHardware.Item(dgcHardPrice.Index, i).Value) <> 0 Then
                    If IsNumeric(dgvHardware.Item(dgcHardPrice.Index, i).Value) Then
                        a = a + Double.Parse(dgvHardware.Item(dgcHardPrice.Index, i).Value).ToString
                    End If
                End If
            Next
            txtHardTotal.Text = a.ToString("N2")
        End If

        txtGross.Text = CDec(CDec(txtHardTotal.Text) + CDec(txtSoftTotal.Text)).ToString("N2")
        If chkVAT.Checked = True Then
            txtVAT.Text = CDec(CDec(txtGross.Text) * 0.12).ToString("N2")
        Else
            txtVAT.Text = "0.00"
        End If
        If chkVATinc.Checked = True Then
            txtNet.Text = CDec(txtGross.Text).ToString("N2")
        Else
            txtNet.Text = CDec(CDec(txtGross.Text) + CDec(txtVAT.Text)).ToString("N2")
        End If
    End Sub

    Public Sub LoadItem(ByVal SCNo As String)
        Try
            Dim query As String

            query = " SELECT  SoftwareCode,  Description, Price,  " & _
                    " WHERE   SoftwareCode = @SoftwareCode "
            SQL.FlushParams()
            SQL.AddParam("@SoftwareCode", SCNo)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then

                dgvSoftware.Rows.Add(New String() {SQL.SQLDR("SoftwareCode").ToString, _
                                                    SQL.SQLDR("Description").ToString, _
                                                   SQL.SQLDR("Price").ToString})

            End If


        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub frmSC_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub dgvHardware_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHardware.CellEndEdit
        If disableEvent = False Then
            ComputeTotal()
        End If
    End Sub

    Private Sub VAT_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVATinc.CheckedChanged, chkVAT.CheckedChanged
        If disableEvent = False Then
            chkVATinc.Enabled = chkVAT.Checked
            ComputeTotal()
        End If
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("SC_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("SC")
            If f.transID <> "" Then
                TransID = f.transID
            End If
            LoadSC(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub chkMaintFee_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMaintFee.CheckedChanged
        If disableEvent = False Then
            cbMaintPeriod.Enabled = chkMaintFee.Checked
            dtpMaintStart.Enabled = chkMaintFee.Checked
            txtMaintAmount.Enabled = chkMaintFee.Checked
        End If
    End Sub

    Private Sub rbInstallment_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbInstallment.CheckedChanged, rbProgress.CheckedChanged
        If disableEvent = False Then
            dgvProgress.Visible = rbProgress.Checked
            lblTotalPercent.Visible = rbProgress.Checked
            txtTotalPercent.Visible = rbProgress.Checked

            lblBalance.Visible = rbInstallment.Checked
            lblDP.Visible = rbInstallment.Checked
            lblMonths.Visible = rbInstallment.Checked
            lblRetention.Visible = rbInstallment.Checked
            txtDP.Visible = rbInstallment.Checked
            txtRetention.Visible = rbInstallment.Checked
            nupBalance.Visible = rbInstallment.Checked
            chkDP.Visible = rbInstallment.Checked
            chkRetention.Visible = rbInstallment.Checked
            chkPDC.Visible = rbInstallment.Checked
        End If
    End Sub

    Private Sub dtpDocDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDocDate.ValueChanged
        If disableEvent = False Then
            dtpMaintStart.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, dtpDocDate.Value))
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If SCNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblSC  WHERE SC_No < '" & SCNo & "' ORDER BY SC_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadSC(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If SCNo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblSC  WHERE SC_No > '" & SCNo & "' ORDER BY SC_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadSC(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub cbContractType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbContractType.SelectedIndexChanged
        If disableEvent = False Then
            If cbContractType.SelectedItem = "Monthly" Then
                gbTerms.Enabled = False
                chkMaintFee.Enabled = False
                chkMaintFee.Checked = True
            Else
                gbTerms.Enabled = True
                chkMaintFee.Enabled = True
            End If
        End If
    End Sub

    Private Sub tsmiAnnexA_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAnnexA.Click
        Dim f As New frmReport_Display
        f.ShowDialog("SC_AnnexA", TransID)
        f.Dispose()
    End Sub

    Private Sub tsmiAnnexC_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAnnexC.Click
        Dim f As New frmReport_Display
        f.ShowDialog("SC_AnnexC", TransID)
        f.Dispose()
    End Sub

    Private Sub tsmiAnnexD_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAnnexD.Click
        Dim f As New frmReport_Display
        f.ShowDialog("SC_AnnexD", TransID)
        f.Dispose()
    End Sub

    Private Sub tsmiAnnexMOA_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAnnexMOA.Click
        Dim f As New frmReport_Display
        f.ShowDialog("SC_AnnexMOA", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbApprove_Click(sender As System.Object, e As System.EventArgs) Handles tsbApprove.Click
        If Not AllowAccess("SC_APRV") Then
            msgRestricted()
        Else
            Dim updateSQL As String
            updateSQL = " UPDATE tblSC SET Status ='Approved' WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(updateSQL)
            Msg("Proposal Approved Successfully!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class