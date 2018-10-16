Public Class frmGI
    Dim TransID, RefID As String
    Dim GINo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "GI"
    Dim ColumnPK As String = "GI_No"
    Dim DBTable As String = "tblGI"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim SysCode As String = "EMERALD"

    Public Overloads Function ShowDialog(ByVal docnumber As String) As Boolean
        TransID = docnumber
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmGI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            loadWH()
            LoadBOM()
            If TransID <> "" Then
                '    LoadGI(TransID)
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

    Private Sub LoadBOM()
        Dim query As String
        query = " SELECT BOM_Code FROM tblBOM_Maintenance_Header WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbBOM.Items.Clear()
        While SQL.SQLDR.Read
            cbBOM.Items.Add(SQL.SQLDR("BOM_Code").ToString)
        End While
    End Sub

    Private Sub loadWHFrom()
        If cbIssuerFrom.SelectedItem = "Warehouse" Then
            Dim query As String
            query = " SELECT Description FROM tblWarehouse WHERE Status ='Active' "
            SQL.ReadQuery(query)
            cbWHfrom.Items.Clear()
            While SQL.SQLDR.Read
                cbWHfrom.Items.Add(SQL.SQLDR("Description"))
            End While
        ElseIf cbIssuerFrom.SelectedItem = "Production" Then
            Dim query As String
            query = " SELECT Description FROM tblProdWarehouse WHERE Status ='Active' "
            SQL.ReadQuery(query)
            cbWHfrom.Items.Clear()
            While SQL.SQLDR.Read
                cbWHfrom.Items.Add(SQL.SQLDR("Description"))
            End While
        End If

    End Sub


    Private Sub loadWH()
        If cbIssueTo.SelectedItem = "Warehouse" Then
            Dim query As String
            query = " SELECT Description FROM tblWarehouse WHERE Status ='Active' "
            SQL.ReadQuery(query)
            cbWHto.Items.Clear()
            While SQL.SQLDR.Read
                cbWHto.Items.Add(SQL.SQLDR("Description"))
            End While
        ElseIf cbIssueTo.SelectedItem = "Production" Then
            Dim query As String
            query = " SELECT Description FROM tblProdWarehouse WHERE Status ='Active' "
            SQL.ReadQuery(query)
            cbWHto.Items.Clear()
            While SQL.SQLDR.Read
                cbWHto.Items.Add(SQL.SQLDR("Description"))
            End While
        End If

    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        cbWHto.Enabled = Value
        cbWHfrom.Enabled = Value
        cbIssuerFrom.Enabled = Value
        cbIssueTo.Enabled = Value
        btnSearchVCE.Enabled = Value
        txtVCEName.Enabled = Value
        dgvItemMaster.AllowUserToAddRows = Value
        dgvItemMaster.AllowUserToDeleteRows = Value
        dgvItemMaster.ReadOnly = Not Value
        nupQty.Enabled = Value
        btnAddMats.Enabled = Value
        If Value = True Then
            dgvItemMaster.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvItemMaster.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        cbTransType.Enabled = Value
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        cbBOM.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("GI_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("GI")
            GINo = f.transID
            LoadGI(GINo)
            f.Dispose()
        End If
    End Sub

    Private Sub LoadGI(ByVal ID As String)
        Dim query As String
        Dim WHSE As String
        query = " SELECT   TransID, GI_No, VCECode, DateGI, Type, WHSE, Remarks, Status " & _
                " FROM     tblGI " & _
                " WHERE    TransId = '" & ID & "' " & _
                " ORDER BY TransId "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            GINo = SQL.SQLDR("GI_No").ToString
            txtTransNum.Text = GINo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            dtpDocDate.Text = SQL.SQLDR("DateGI").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            WHSE = SQL.SQLDR("WHSE").ToString
            cbTransType.SelectedItem = SQL.SQLDR("Type").ToString
            cbWHto.SelectedItem = GetWHSEDesc(WHSE)
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            LoadGIDetails(TransID)
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
            Cleartext()
        End If
    End Sub

    Protected Sub LoadGIDetails(ByVal TransID As String)
        Dim ctr As Integer = 0
        Dim query As String
        query = " SELECT	tblGI_Details.ItemCode, tblGI_Details.Description, tblGI_Details.UOM, tblGI_Details.QTY  AS QTY, tblGI_Details.WHSE_from " & _
                " FROM	    tblGI INNER JOIN tblGI_Details " & _
                " ON		tblGI.TransID = tblGI_Details.TransID " & _
                " WHERE     tblGI_Details.TransId = " & TransID & " " & _
                " ORDER BY  tblGI_Details.LineNum "
        disableEvent = True
        dgvItemMaster.Rows.Clear()
        disableEvent = False
        SQL.ReadQuery(query)
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvItemMaster.Rows.Add(row(0).ToString, row(1).ToString, row(2).ToString, _
                                     row(3).ToString, GetWHSEDesc(row(4).ToString))
                LoadUOM(row(0).ToString, ctr)
                LoadWHSE(ctr)
                ctr += 1
            Next
        End If
    End Sub

    Private Sub LoadWHSE(Optional ByVal SelectedIndex As Integer = -1)
        Try
            Dim dgvCB As New DataGridViewComboBoxCell
            dgvCB = dgvItemMaster.Item(chWHSE.Index, SelectedIndex)
            dgvCB.Items.Clear()
            ' ADD ALL WHSEc
            Dim query As String
            If cbWHto.SelectedItem = "Warehouse" Then
                query = " SELECT Description FROM tblWarehouse WHERE Status ='Active' "
            Else
                query = " SELECT Description FROM tblProdWarehouse WHERE Status ='Active' "
            End If
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            While SQL.SQLDR.Read
                dgvCB.Items.Add(SQL.SQLDR("Description").ToString)
            End While
            dgvCB.Items.Add("")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub Cleartext()
        txtVCECode.Clear()
        txtVCEName.Clear()
        txtTransNum.Clear()
        cbWHto.SelectedIndex = -1
        cbTransType.SelectedIndex = -1
        dgvItemMaster.Rows.Clear()
        txtRemarks.Clear()
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("GI_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            GINo = ""

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
        If Not AllowAccess("GI_EDIT") Then
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
        If cbWHto.SelectedIndex = -1 Then
            Msg("Please select warehouse!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                GINo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = GINo
                SaveGI()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                GINo = txtTransNum.Text
                LoadGI(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateGI()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                GINo = txtTransNum.Text
                LoadGI(TransID)
            End If
        End If
    End Sub

    Private Sub SaveGI()
        Try
            Dim MainWHSE, Type As String
            Type = IIf(cbTransType.SelectedIndex = -1, "", cbTransType.SelectedItem)
            MainWHSE = GetWHSECode(cbWHto.SelectedItem)
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblGI(TransID, GI_No, BranchCode, BusinessCode, DateGI, VCECode, WHSE, Type, Remarks, WhoCreated) " & _
                        " VALUES (@TransID, @GI_No, @BranchCode, @BusinessCode, @DateGI, @VCECode, @WHSE, @Type, @Remarks, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@GI_No", GINo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateGI", dtpDocDate.Value.Date)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@WHSE", MainWHSE)
            SQL.AddParam("@Type", Type)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            Dim ItemCode, Description, UOM, WHSEfrom, WHSEto As String
            Dim QTY, UnitCost As Decimal
            For Each row As DataGridViewRow In dgvItemMaster.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    ItemCode = IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value)
                    Description = IIf(row.Cells(chItemName.Index).Value = Nothing, "", row.Cells(chItemName.Index).Value)
                    UOM = IIf(row.Cells(chUOM.Index).Value = Nothing, "", row.Cells(chUOM.Index).Value)
                    UnitCost = GetAverageCost(ItemCode)
                    If IsNumeric(row.Cells(chQTY.Index).Value) Then
                        QTY = CDec(row.Cells(chQTY.Index).Value)
                    Else
                        QTY = 1
                    End If
                    WHSEfrom = IIf(row.Cells(chWHSE.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSE.Index).Value))
                    insertSQL = " INSERT INTO " & _
                         " tblGI_Details(TransId, ItemCode, Description, UOM, QTY, WHSE_From, WHSE_To, LineNum, WhoCreated) " & _
                         " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @WHSE_From, @WHSE_To, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", ItemCode)
                    SQL.AddParam("@Description", Description)
                    SQL.AddParam("@UOM", UOM)
                    SQL.AddParam("@QTY", QTY)
                    SQL.AddParam("@WHSE_From", WHSEfrom)
                    SQL.AddParam("@WHSE_To", WHSEfrom)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1

                    SaveINVTY("OUT", ModuleID, "GI", TransID, dtpDocDate.Value.Date, ItemCode, WHSEfrom, QTY, UOM, UnitCost)
                End If
            Next

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "GI_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateGI()
        Try
            Dim MainWHSE, Type As String
            Type = IIf(cbTransType.SelectedIndex = -1, "", cbTransType.SelectedItem)
            MainWHSE = GetWHSECode(cbWHto.SelectedItem)
            activityStatus = True
            Dim insertSQL, updateSQL, deleteSQL As String
            updateSQL = " UPDATE    tblGI " & _
                        " SET       GI_No = @GI_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, DateGI = @DateGI, " & _
                        "           VCECode = @VCECode, WHSE = @WHSE, Type = @Type, Remarks = @Remarks, " & _
                        "           WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE     TransID = @TransID  "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@GI_No", GINo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@DateGI", dtpDocDate.Value.Date)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@WHSE", MainWHSE)
            SQL.AddParam("@Type", Type)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            deleteSQL = " DELETE FROM tblGI_Details WHERE TransID =@TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.ExecNonQuery(deleteSQL)

            Dim line As Integer = 1
            Dim ItemCode, Description, UOM, WHSE As String
            Dim QTY, UnitCost As Decimal
            For Each row As DataGridViewRow In dgvItemMaster.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    ItemCode = IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value)
                    Description = IIf(row.Cells(chItemName.Index).Value = Nothing, "", row.Cells(chItemName.Index).Value)
                    UOM = IIf(row.Cells(chUOM.Index).Value = Nothing, "", row.Cells(chUOM.Index).Value)
                    UnitCost = GetAverageCost(ItemCode)
                    If IsNumeric(row.Cells(chQTY.Index).Value) Then
                        QTY = CDec(row.Cells(chQTY.Index).Value)
                    Else
                        QTY = 1
                    End If
                    WHSE = IIf(row.Cells(chWHSE.Index).Value = Nothing, "", GetWHSECode(row.Cells(chWHSE.Index).Value))
                    insertSQL = " INSERT INTO " & _
                         " tblGI_Details(TransId, ItemCode, Description, UOM, QTY, WHSE, LineNum, WhoCreated) " & _
                         " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @WHSE, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", ItemCode)
                    SQL.AddParam("@Description", Description)
                    SQL.AddParam("@UOM", UOM)
                    SQL.AddParam("@QTY", QTY)
                    SQL.AddParam("@WHSE", WHSE)
                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                    ' NEGATIVE QUANTITY FOR OUTGOING ITEMS
                    QTY = QTY * -1
                    Dim baseQTY As Decimal = QTY * ConvertUOM(UOM, ItemCode)
                    Dim baseValue As Decimal = QTY * UnitCost

                    UpdateINVTY("OUT", ModuleID, "GI", TransID, dtpDocDate.Value.Date, ItemCode, WHSE, QTY, UOM, UnitCost)
                End If
            Next

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "GI_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("GI_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblGI SET Status ='Cancelled' WHERE GI_No = @GI_No "
                        SQL.FlushParams()
                        GINo = txtTransNum.Text
                        SQL.AddParam("@GI_No", GINo)
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

                        GINo = txtTransNum.Text
                        LoadGI(GINo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "GI_No", GINo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If GINo <> "" Then
            Dim query As String
            query = " SELECT Top 1 GI_No FROM tblGI  WHERE GI_No < '" & GINo & "' ORDER BY GI_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                GINo = SQL.SQLDR("GI_No").ToString
                LoadGI(GINo)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If GINo <> "" Then
            Dim query As String
            query = " SELECT Top 1 GI_No FROM tblGI  WHERE GI_No > '" & GINo & "' ORDER BY GI_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                GINo = SQL.SQLDR("GI_No").ToString
                LoadGI(GINo)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If GINo = "" Then
            Cleartext()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadGI(GINo)
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

    Private Sub frmGI_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub cbBOM_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBOM.SelectedIndexChanged
        If disableEvent = False Then
            LoadBOMData()
        End If

    End Sub

    Private Sub LoadBOMData()
        If cbBOM.SelectedIndex <> -1 Then
            Dim query As String
            query = " SELECT    BOM_Code, tblBOM_Maintenance_Header.ItemCode, ItemName, UOM, QTY  " & _
                    " FROM      tblBOM_Maintenance_Header INNER JOIn tblItem_Master " & _
                    " ON        tblBOM_Maintenance_Header.ItemCode = tblItem_Master.ItemCode " & _
                    " WHERE     tblBOM_Maintenance_Header.Status ='Active' " & _
                    " AND       tblItem_Master.Status ='Active' " & _
                    " AND       BOM_Code ='" & cbBOM.SelectedItem & "' "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
                txtItemName.Text = SQL.SQLDR("ItemName").ToString
                txtUOM.Text = SQL.SQLDR("UOM").ToString
                txtQTY.Text = SQL.SQLDR("QTY").ToString * nupQty.Value
            Else
                txtItemCode.Text = ""
                txtItemName.Text = ""
                txtUOM.Text = ""
                txtQTY.Text = 1
            End If
        End If
    End Sub

    Private Sub nupQty_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nupQty.ValueChanged
        If disableEvent = False Then
            LoadBOMData()
        End If
    End Sub

    Private Sub btnSearchWHSE_Click(sender As System.Object, e As System.EventArgs)
        Dim f As New frmWH
        f.ShowDialog()
        loadWH()
    End Sub

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
        End If
    End Sub

    Private Sub dgvItemMaster_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemMaster.CellEndEdit
        Try
            Dim itemCode As String
            Dim rowIndex As Integer = dgvItemMaster.CurrentCell.RowIndex
            Dim colindex As Integer = dgvItemMaster.CurrentCell.ColumnIndex
            Select Case colindex
                Case chItemCode.Index
                    If dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("All Item", itemCode)
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItemDetails(itemCode)
                        Else
                            dgvItemMaster.Rows.RemoveAt(e.RowIndex)
                        End If
                        f.Dispose()
                    End If
                Case chItemName.Index
                    If dgvItemMaster.Item(chItemName.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemMaster.Item(chItemName.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("All Item", itemCode)
                        If f.TransID <> "" Then
                            itemCode = f.TransID
                            LoadItemDetails(itemCode)
                        Else
                            dgvItemMaster.Rows.RemoveAt(e.RowIndex)
                        End If
                        f.Dispose()
                    End If
            End Select
        Catch ex1 As InvalidOperationException

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try

    End Sub

    Private Sub LoadItemDetails(ByVal ItemCode As String)
        Dim query As String
        query = " SELECT    ItemCode, ItemName, 1 " & _
                " FROM       tblItem_Master " & _
                " WHERE     ItemCode = @ItemCode"
        SQL.FlushParams()
        SQL.AddParam("@ItemCode", IIf(ItemCode = Nothing, "", ItemCode))
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            If dgvItemMaster.SelectedCells.Count > 0 Then

                dgvItemMaster.Item(0, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemCode").ToString
                dgvItemMaster.Item(1, dgvItemMaster.SelectedCells(0).RowIndex).Value = SQL.SQLDR("ItemName").ToString
                dgvItemMaster.Item(2, dgvItemMaster.SelectedCells(0).RowIndex).Value = ""
                dgvItemMaster.Item(3, dgvItemMaster.SelectedCells(0).RowIndex).Value = 1
                dgvItemMaster.Item(4, dgvItemMaster.SelectedCells(0).RowIndex).Value = IIf(cbWHto.SelectedIndex = -1, "", cbWHto.SelectedItem)
                LoadWHSE(dgvItemMaster.SelectedCells(0).RowIndex)
                LoadUOM(ItemCode, dgvItemMaster.SelectedCells(0).RowIndex)
            End If
        End If
    End Sub


    Private Sub LoadUOM(ItemCode As String, ByVal SelectedIndex As Integer)
        Try
            Dim dgvCB As New DataGridViewComboBoxCell
            dgvCB = dgvItemMaster.Item(chUOM.Index, SelectedIndex)
            dgvCB.Items.Clear()
            ' ADD ALL WHSEc
            Dim query As String

            query = " SELECT DISTINCT UOM.UnitCode FROM tblItem_Master INNER JOIN  " & _
               " ( " & _
               " SELECT GroupCode, UnitCode FROM tblUOM_Group WHERE Status ='Active' " & _
               " UNION ALL " & _
               " SELECT GroupCode, UnitCodeFrom FROM tblUOM_GroupDetails " & _
               " UNION ALL " & _
               " SELECT GroupCode, UnitCodeTo FROM tblUOM_GroupDetails " & _
               " ) AS UOM " & _
               " ON tblItem_Master.ItemUOMGroup = UOM.GroupCode " & _
               " OR  tblItem_Master.ItemCode = UOM.GroupCode " & _
               " WHERE ItemCode ='" & ItemCode & "' "
            SQL.ReadQuery(query)
            dgvCB.Items.Clear()
            While SQL.SQLDR.Read
                dgvCB.Items.Add(SQL.SQLDR("UnitCode").ToString)
            End While
            dgvCB.Items.Add("")
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvItemMaster_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemMaster.CellClick
        Try
            If e.ColumnIndex = chUOM.Index Then
                If e.RowIndex <> -1 AndAlso dgvItemMaster.Rows.Count > 0 AndAlso dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value <> Nothing Then

                    LoadUOM(dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value.ToString, e.RowIndex)
                    Dim dgvCol As New DataGridViewComboBoxColumn
                    dgvCol = dgvItemMaster.Columns.Item(e.ColumnIndex)
                    dgvItemMaster.BeginEdit(True)
                    dgvCol.Selected = True
                    DirectCast(dgvItemMaster.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                    Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)

                End If
            ElseIf e.ColumnIndex = chWHSE.Index Then
                If e.RowIndex <> -1 AndAlso dgvItemMaster.Rows.Count > 0 AndAlso dgvItemMaster.Item(chItemCode.Index, e.RowIndex).Value <> Nothing Then
                    LoadWHSE(e.RowIndex)
                    Dim dgvCol As DataGridViewComboBoxColumn
                    dgvCol = dgvItemMaster.Columns.Item(e.ColumnIndex)
                    dgvItemMaster.BeginEdit(True)
                    dgvCol.Selected = True
                    DirectCast(dgvItemMaster.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
                    Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)

                End If
            End If

        Catch ex As NullReferenceException
            If dgvItemMaster.ReadOnly = False Then
                SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvItemMaster_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvItemMaster.EditingControlShowing
        ' GET THE EDITING CONTROL
        Dim editingComboBox As ComboBox = TryCast(e.Control, ComboBox)
        If Not editingComboBox Is Nothing Then
            ' REMOVE AN EXISTING EVENT-HANDLER TO AVOID ADDING MULTIPLE HANDLERS WHEN THE EDITING CONTROL IS REUSED
            RemoveHandler editingComboBox.SelectionChangeCommitted, New EventHandler(AddressOf editingComboBox_SelectionChangeCommitted)

            ' ADD THE EVENT HANDLER
            AddHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted

            ' PREVENT THIS HANDLER FROM FIRING TWICE
            RemoveHandler dgvItemMaster.EditingControlShowing, AddressOf dgvItemMaster_EditingControlShowing
        End If
    End Sub

    Private Sub editingComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rowIndex, columnIndex As Integer
        'Get the editing control
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        If editingComboBox Is Nothing Then Exit Sub
        'Show your Message Boxes
        If editingComboBox.SelectedIndex <> -1 Then
            rowIndex = dgvItemMaster.SelectedCells(0).RowIndex
            columnIndex = dgvItemMaster.SelectedCells(0).ColumnIndex
            If dgvItemMaster.SelectedCells.Count > 0 Then
                Dim tempCell As DataGridViewComboBoxCell = dgvItemMaster.Item(columnIndex, rowIndex)
                Dim temp As String = editingComboBox.Text
                dgvItemMaster.Item(columnIndex, rowIndex).Selected = False
                dgvItemMaster.EndEdit(True)
                tempCell.Value = temp
            End If
        End If

        'Remove the handle to this event. It will be readded each time a new combobox selection causes the EditingControlShowing Event to fire
        RemoveHandler editingComboBox.SelectionChangeCommitted, AddressOf editingComboBox_SelectionChangeCommitted
        'Re-enable the EditingControlShowing event so the above can take place.
        AddHandler dgvItemMaster.EditingControlShowing, AddressOf dgvItemMaster_EditingControlShowing
    End Sub

    Private Sub btnAddMats_Click(sender As System.Object, e As System.EventArgs) Handles btnAddMats.Click
        If cbWHto.SelectedIndex = -1 Then
            Msg("Please select warehouse first!", MsgBoxStyle.Exclamation)
        Else
            Dim ctr As Integer = dgvItemMaster.Rows.Count - 1
            Dim query As String
            query = " SELECT    tblBOM_Maintenance_Header.ItemCode, ItemName, tblBOM_Maintenance_Details.UOM, tblBOM_Maintenance_Details.QTY  " & _
                    " FROM      tblBOM_Maintenance_Header INNER JOIN tblBOM_Maintenance_Details " & _
                    " ON        tblBOM_Maintenance_Header.BOM_Code = tblBOM_Maintenance_Details.BOM_Code " & _
                    " INNER JOIn tblItem_Master " & _
                    " ON        tblBOM_Maintenance_Details.MaterialCode = tblItem_Master.ItemCode " & _
                    " WHERE     tblBOM_Maintenance_Header.Status ='Active' " & _
                    " AND       tblItem_Master.Status ='Active' " & _
                    " AND       tblBOM_Maintenance_Header.BOM_Code = '" & cbBOM.SelectedItem & "' " & _
                    " ORDER BY  LineNumber "
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                    dgvItemMaster.Rows.Add({row(0).ToString, row(1).ToString, row(2).ToString, row(3) * nupQty.Value, cbWHto.SelectedItem})
                    LoadUOM(row(0).ToString, ctr)
                    LoadWHSE(ctr)
                    ctr += 1
                Next
            End If
        End If
    End Sub

    Private Sub dgvItemMaster_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvItemMaster.DataError
        Try

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        txtVCEName.Text = f.VCEName
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cbIssueTo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbIssueTo.SelectedIndexChanged
        If cbIssueTo.SelectedItem = "Warehouse" Then
            txtVCECode.ReadOnly = False
            txtVCEName.ReadOnly = False
            btnSearchVCE.Enabled = True
            gbBOM.Visible = True
        ElseIf cbIssueTo.SelectedItem = "Production" Then
            txtVCECode.ReadOnly = True
            txtVCEName.ReadOnly = True
            btnSearchVCE.Enabled = False
            gbBOM.Visible = False
        End If
        loadWH()
        For Each row As DataGridViewRow In dgvItemMaster.Rows
            If row.Cells(chItemCode.Index).Value <> Nothing AndAlso row.Cells(chItemCode.Index).Value <> "" Then
                LoadWHSE(row.Index)
            End If
        Next
    End Sub

    Private Sub cbWH_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbWHto.SelectedIndexChanged

    End Sub

    Private Sub FromRFPToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub FromAdvancesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub tsbCopyAPV_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub tsbCopyPR_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyPR.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Closed"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False

        f.ShowDialog("JO_BOM")
        LoadJO(f.transID)
        f.Dispose()
    End Sub

    Private Sub LoadJO(ByVal ID As String)
        Try
            cbIssuerFrom.SelectedItem = "Warehouse"
            cbIssueTo.SelectedItem = "Production"
            cbWHfrom.Visible = False
            Dim query As String
            query = " SELECT tblJO.TransID, JO_No, DateJO, tblJO.ItemCode,  tblJO.Description, LotSize, tblBOM.UOM, tblJO.QTY, ProdLine, BOMCode " & _
                    " FROM  tblBOM INNER JOIN tblJO " & _
                    " ON     tblBOM.JO_Ref = tblJO.TransID " & _
                    " WHERE  tblJO.TransID ='" & ID & "' "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                disableEvent = True

                cbBOM.SelectedItem = SQL.SQLDR("BOMCode").ToString
                txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
                txtItemName.Text = SQL.SQLDR("Description").ToString
                nupQty.Value = CInt(SQL.SQLDR("QTY").ToString)
                txtQTY.Text = SQL.SQLDR("LotSize").ToString
                txtUOM.Text = SQL.SQLDR("UOM").ToString
                disableEvent = False
                Dim ctr As Integer = dgvItemMaster.Rows.Count - 1
                query = " SELECT    tblBOM_Maintenance_Details.MaterialCode, ItemName, tblBOM_Maintenance_Details.UOM, tblBOM_Maintenance_Details.QTY  " & _
                        " FROM      tblBOM_Maintenance_Header INNER JOIN tblBOM_Maintenance_Details " & _
                        " ON        tblBOM_Maintenance_Header.BOM_Code = tblBOM_Maintenance_Details.BOM_Code " & _
                        " INNER JOIn tblItem_Master " & _
                        " ON        tblBOM_Maintenance_Details.MaterialCode = tblItem_Master.ItemCode " & _
                        " WHERE     tblBOM_Maintenance_Header.Status ='Active' " & _
                        " AND       tblItem_Master.Status ='Active' " & _
                        " AND       tblBOM_Maintenance_Header.BOM_Code = '" & cbBOM.SelectedItem & "' " & _
                        " ORDER BY  LineNumber "
                SQL.GetQuery(query)
                If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                        dgvItemMaster.Rows.Add({row(0).ToString, row(1).ToString, row(2).ToString, row(3) * nupQty.Value, cbWHto.SelectedItem})
                        LoadUOM(row(0).ToString, ctr)
                        LoadWHSE(ctr)
                        ctr += 1
                    Next
                    dgvItemMaster.Columns(4).Visible = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbIssuerFrom_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbIssuerFrom.SelectedIndexChanged
        loadWHFrom()
    End Sub
End Class