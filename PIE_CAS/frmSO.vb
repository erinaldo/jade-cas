Public Class frmSO
    Dim TransID, RefID As String
    Dim SONo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "SO"
    Dim ColumnPK As String = "SO_No"
    Dim DBTable As String = "tblSO"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim SQ_ID As Integer
    Dim POreq As Boolean

    Public Overloads Function ShowDialog(ByVal DocID As String) As Boolean
        TransID = DocID
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmSO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            LoadSetup()
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            dtpDelivery.Value = Date.Today.Date
            If TransID <> "" Then
                LoadSO(TransID)
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

    Private Sub LoadSetup()
        Dim query As String
        query = " SELECT  ISNULL(SO_EditPrice,0) AS SO_EditPrice, ISNULL(SO_ReqPO,0) AS SO_ReqPO FROM tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            dgvItemList.Columns(chUnitPrice.Index).ReadOnly = Not SQL.SQLDR("SO_EditPrice")
            POreq = SQL.SQLDR("SO_ReqPO")
        End If
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCEName.Enabled = Value
        btnSearchVCE.Enabled = Value
        dgvItemList.AllowUserToAddRows = Value
        dgvItemList.AllowUserToDeleteRows = Value
        txtDiscountRate.Enabled = Value
        btnApplyRate.Enabled = Value
        If Value = True Then
            dgvItemList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Else
            dgvItemList.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        dtpDelivery.Enabled = Value
        txtRefNo.Enabled = Value
        chkStaggared.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub LoadSO(ByVal ID As String)
        Dim query As String
        query = " SELECT     TransID, SO_No, VCECode, DateSO, DateDeliver, Remarks, StaggardDelivery, " & _
                "            ISNULL(GrossAmount,0) AS GrossAmount, ISNULL(VATAmount,0) AS VATAmount, ISNULL(Discount,0) AS Discount, ISNULL(NetAmount,0) AS NetAmount,  " & _
                "            VATable, VATInclusive, Status, ReferenceNo, ISNULL(SQ_Ref,0) AS SQ_Ref " & _
                " FROM       tblSO " & _
                " WHERE      TransId = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            SONo = SQL.SQLDR("SO_No").ToString
            txtTransNum.Text = SONo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            dtpDocDate.Text = SQL.SQLDR("DateSO").ToString
            dtpDelivery.Text = SQL.SQLDR("DateDeliver").ToString
            txtGross.Text = CDec(SQL.SQLDR("GrossAmount").ToString).ToString("N2")
            txtVAT.Text = CDec(SQL.SQLDR("VATAmount").ToString).ToString("N2")
            txtDiscount.Text = CDec(SQL.SQLDR("Discount").ToString).ToString("N2")
            txtNet.Text = CDec(SQL.SQLDR("NetAmount").ToString).ToString("N2")
            txtRefNo.Text = SQL.SQLDR("ReferenceNo").ToString
            chkStaggared.Checked = SQL.SQLDR("StaggardDelivery")
            chkVAT.Checked = SQL.SQLDR("VATable")
            chkVATInc.Checked = SQL.SQLDR("VATInclusive")
            SQ_ID = SQL.SQLDR("SQ_Ref").ToString
            txtSQ_Ref.Text = LoadSQNo(SQ_ID)
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            LoadSODetails(TransID)
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
            tsbCopy.Enabled = False
            EnableControl(False)
        Else
            ClearText()
        End If

    End Sub

    Private Function LoadSQNo(SQ_ID As Integer) As String
        Dim query As String
        query = " SELECT SQ_No FROM tblSQ WHERE TransID = '" & SQ_ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("SQ_No")
        Else
            Return ""
        End If
    End Function

    Protected Sub LoadSODetails(ByVal TransID As String)
        Dim query As String
        query = " SELECT    ItemCode, Description, UOM, QTY, ISNULL(UnitPrice,0) AS UnitPrice, " & _
                "           ISNULL(GrossAmount,0) AS GrossAmount, ISNULL(DiscountRate,0) AS DiscountRate, ISNULL(Discount,0) AS Discount, " & _
                "           ISNULL(VATAmount,0) AS VATAmount, ISNULL(NetAmount,0) AS NetAmount, ISNULL(VATable,1) AS VATable, ISNULL(VATinc,1) AS VATinc, " & _
                "           WHSE, DateDeliver " & _
                " FROM      tblSO_Details " & _
                " WHERE     tblSO_Details.TransId = " & TransID & " " & _
                " ORDER BY  LineNum "
        dgvItemList.Rows.Clear()
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            dgvItemList.Rows.Add(SQL.SQLDR("ItemCode").ToString, SQL.SQLDR("Description").ToString, SQL.SQLDR("UOM").ToString, _
                                 SQL.SQLDR("QTY").ToString, CDec(SQL.SQLDR("UnitPrice")).ToString("N2"), _
                                 CDec(SQL.SQLDR("GrossAmount")).ToString("N2"), _
                                 IIf((SQL.SQLDR("DiscountRate") <> 0), SQL.SQLDR("DiscountRate"), ""), _
                                 CDec(SQL.SQLDR("Discount")).ToString("N2"), _
                                 CDec(SQL.SQLDR("VATAmount")).ToString("N2"), _
                                 CDec(SQL.SQLDR("NetAmount")).ToString("N2"), _
                                 SQL.SQLDR("VATable").ToString, SQL.SQLDR("VATinc").ToString, SQL.SQLDR("WHSE").ToString, SQL.SQLDR("DateDeliver"))
        End While
    End Sub

    Private Sub LoadSQ(ByVal SQ_No As String)
        Dim query As String
        query = " SELECT    TransID, SQ_No, VCECode, Remarks, " & _
                "            ISNULL(GrossAmount,0) AS GrossAmount, ISNULL(VATAmount,0) AS VATAmount, ISNULL(Discount,0) AS Discount, ISNULL(NetAmount,0) AS NetAmount,  " & _
                "            ISNULL(VATable,1) AS VATable, VATInclusive, Status " & _
                " FROM       tblSQ " & _
                " WHERE      TransId = '" & SQ_No & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            RefID = SQL.SQLDR("TransID")
            txtRefNo.Text = SQL.SQLDR("SQ_No").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtGross.Text = CDec(SQL.SQLDR("GrossAmount")).ToString("N2")
            txtVAT.Text = CDec(SQL.SQLDR("VATAmount")).ToString("N2")
            txtDiscount.Text = CDec(SQL.SQLDR("Discount")).ToString("N2")
            txtNet.Text = CDec(SQL.SQLDR("NetAmount")).ToString("N2")
            chkVAT.Checked = SQL.SQLDR("VATable")
            chkVATInc.Checked = SQL.SQLDR("VATInclusive")
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            query = " SELECT    ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, DiscountRate, Discount, VATAmount, NetAmount, VATable " & _
                " FROM      tblSQ_Details " & _
                " WHERE     tblSQ_Details.TransId = " & RefID & " " & _
                " ORDER BY  LineNum "
            dgvItemList.Rows.Clear()
            SQL.ReadQuery(query)
            While SQL.SQLDR.Read
                dgvItemList.Rows.Add(SQL.SQLDR("ItemCode").ToString, SQL.SQLDR("Description").ToString, SQL.SQLDR("UOM").ToString, _
                                     SQL.SQLDR("QTY").ToString, CDec(SQL.SQLDR("UnitPrice")).ToString("N2"), _
                                     CDec(SQL.SQLDR("GrossAmount")).ToString("N2"), _
                                     IIf(IsNumeric(SQL.SQLDR("DiscountRate")), SQL.SQLDR("DiscountRate"), ""), _
                                     CDec(SQL.SQLDR("Discount")).ToString("N2"), _
                                     CDec(SQL.SQLDR("VATAmount")).ToString("N2"), _
                                     CDec(SQL.SQLDR("NetAmount")).ToString("N2"), _
                                     SQL.SQLDR("VATable").ToString)
            End While
        Else
            ClearText()
        End If
    End Sub

    Private Sub ClearText()
        txtTransNum.Text = ""
        txtVCECode.Text = ""
        txtVCEName.Text = ""
        dgvItemList.Rows.Clear()
        txtRemarks.Text = ""
        txtGross.Text = "0.00"
        txtNet.Text = "0.00"
        txtVAT.Text = "0.00"
        txtDiscount.Text = "0.00"
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        dtpDelivery.Value = Date.Today.Date
        txtRefNo.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Are you sure you want to cancel Purchase Order No. " & txtTransNum.Text & "? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblSO SET Status ='Cancelled' WHERE TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", txtTransNum.Text)
            SQL.ExecNonQuery(updateSQL)
            MsgBox("SO No. " & txtTransNum.Text & " has been cancelled", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Recompute(ByVal RowID As Integer, ByVal ColID As Integer)
        Dim gross, VAT, discount, net, baseVAT As Decimal
        If RowID <> -1 Then
            If IsNumeric(dgvItemList.Item(chGross.Index, RowID).Value) Then
                ' GET GROSS AMOUNT (VAT INCLUSIVE)
                gross = CDec(dgvItemList.Item(chUnitPrice.Index, RowID).Value) * CDec(dgvItemList.Item(chQTY.Index, RowID).Value)
                baseVAT = gross
                ' COMPUTE VAT IF VATABLE
                If ColID = chVAT.Index Then
                    If dgvItemList.Item(chVAT.Index, RowID).Value = True Then
                        dgvItemList.Item(chVAT.Index, RowID).Value = False

                        dgvItemList.Item(chVATInc.Index, RowID).Value = False
                        VAT = 0
                        dgvItemList.Item(chVATInc.Index, RowID).ReadOnly = True
                    Else
                        dgvItemList.Item(chVAT.Index, RowID).Value = True

                        dgvItemList.Item(chVATInc.Index, RowID).ReadOnly = False
                        If dgvItemList.Item(chVATInc.Index, RowID).Value = False Then
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        Else
                            baseVAT = (gross / 1.12)
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        End If

                    End If
                ElseIf ColID = chVATInc.Index Then
                    If dgvItemList.Item(chVAT.Index, RowID).Value = False Then
                        VAT = 0
                    Else
                        If dgvItemList.Item(chVATInc.Index, RowID).Value = True Then
                            dgvItemList.Item(chVATInc.Index, RowID).Value = False
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        Else
                            dgvItemList.Item(chVATInc.Index, RowID).Value = True
                            baseVAT = (gross / 1.12)
                            VAT = CDec(baseVAT * 0.12).ToString("N2")
                        End If

                    End If
                Else
                    If dgvItemList.Item(chVAT.Index, RowID).Value = False Then
                        VAT = 0
                        dgvItemList.Item(chVATInc.Index, RowID).ReadOnly = True
                    Else
                        dgvItemList.Item(chVATInc.Index, RowID).ReadOnly = False
                        If dgvItemList.Item(chVATInc.Index, RowID).Value = True Then ' IF VAT INCLUSIVE, BASE AMOUNT WILL BE GROSS / 1.12
                            baseVAT = (gross / 1.12)
                        End If
                        VAT = CDec(baseVAT * 0.12).ToString("N2")
                    End If
                End If


                ' COMPUTE DISCOUNT

                If IsNumeric(dgvItemList.Item(chDiscountRate.Index, RowID).Value) Then
                    discount = CDec(baseVAT * (CDec(dgvItemList.Item(chDiscountRate.Index, RowID).Value) / 100.0)).ToString("N2")
                ElseIf IsNumeric(dgvItemList.Item(chDiscount.Index, RowID).Value) Then
                    discount = CDec(dgvItemList.Item(chDiscount.Index, RowID).Value)
                Else
                    discount = 0
                End If
                net = baseVAT - discount + VAT
                dgvItemList.Item(chGross.Index, RowID).Value = Format(gross, "#,###,###,###.00").ToString()
                dgvItemList.Item(chDiscount.Index, RowID).Value = Format(discount, "#,###,###,###.00").ToString()
                dgvItemList.Item(chVATAmount.Index, RowID).Value = Format(VAT, "#,###,###,###.00").ToString()
                dgvItemList.Item(chNetAmount.Index, RowID).Value = Format(net, "#,###,###,###.00").ToString()
                ComputeTotal()
            End If
        End If

    End Sub

    Public Sub LoadItem(ByVal ID As String, ByVal ItemCode As String)
        Dim query As String
        query = " SELECT  ItemCode, ItemName, UOM, 1 AS QTY, UnitPrice, VATable, VATInclusive,  " & _
                "         CASE WHEN VATable = 0 THEN 0 " & _
                "              WHEN VATInclusive = 1 THEN UnitPrice/1.12*.12 " & _
                "              ELSE UnitPrice * 0.12 " & _
                "         END AS VAT, WHSE " & _
                " FROM    viewItem_Price " & _
                " WHERE   RecordID ='" & ID & "' AND ItemCode = '" & ItemCode & "' AND Category ='Selling' "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            dgvItemList.Rows.Add(New String() {SQL.SQLDR("ItemCode").ToString, _
                                                 SQL.SQLDR("ItemName").ToString, _
                                                 SQL.SQLDR("UOM").ToString, _
                                                 SQL.SQLDR("QTY").ToString, _
                                                 Format(SQL.SQLDR("UnitPrice"), "#,###,###,###.00").ToString, _
                                                 Format(SQL.SQLDR("UnitPrice"), "#,###,###,###.00").ToString, _
                                                 "", "0.00", _
                                                 Format(SQL.SQLDR("VAT"), "#,###,###,###.00").ToString, _
                                                 Format(SQL.SQLDR("UnitPrice"), "#,###,###,###.00").ToString, _
                                                 SQL.SQLDR("VAtable"), SQL.SQLDR("VATInclusive"), SQL.SQLDR("WHSE").ToString})
        End While
        ComputeTotal()
    End Sub

    Private Sub SaveSO()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                                " tblSO  (TransID, SO_No, BranchCode, BusinessCode, VCECode, DateSO, DateDeliver, Remarks, StaggardDelivery, " & _
                                "         GrossAmount, Discount, VATAmount, NetAmount, VATable, VATInclusive, ReferenceNo, SQ_Ref, WhoCreated) " & _
                                " VALUES (@TransID, @SO_No, @BranchCode, @BusinessCode, @VCECode,  @DateSO, @DateDeliver, @Remarks, @StaggardDelivery, " & _
                                "         @GrossAmount, @Discount, @VATAmount, @NetAmount, @VATable, @VATInclusive,  @ReferenceNo, @SQ_Ref, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@SO_No", SONo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateSO", dtpDocDate.Value.Date)
            SQL.AddParam("@DateDeliver", dtpDelivery.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@StaggardDelivery", chkStaggared.Checked)
            SQL.AddParam("@GrossAmount", CDec(txtGross.Text))
            SQL.AddParam("@Discount", CDec(txtDiscount.Text))
            SQL.AddParam("@VATAmount", CDec(txtVAT.Text))
            SQL.AddParam("@NetAmount", CDec(txtNet.Text))
            SQL.AddParam("@VATable", chkVAT.Checked)
            SQL.AddParam("@VATInclusive", chkVATInc.Checked)
            SQL.AddParam("@ReferenceNo", txtRefNo.Text)
            SQL.AddParam("@SQ_Ref", SQ_ID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            Dim line As Integer = 1
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblSO_Details(TransId, ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, VATable, VATinc, VATAmount, " & _
                                "                DiscountRate, Discount, NetAmount, WHSE, DateDeliver, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @UnitPrice, @GrossAmount, @VATable, @VATinc, @VATAmount, " & _
                                "        @DiscountRate, @Discount, @NetAmount, @WHSE, @DateDeliver, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value))
                    SQL.AddParam("@Description", row.Cells(chItemDesc.Index).Value.ToString)
                    SQL.AddParam("@UOM", row.Cells(chUOM.Index).Value.ToString)
                    SQL.AddParam("@QTY", CDec(row.Cells(chQTY.Index).Value))
                    SQL.AddParam("@UnitPrice", CDec(row.Cells(chUnitPrice.Index).Value))
                    SQL.AddParam("@GrossAmount", CDec(row.Cells(chGross.Index).Value))
                    If IsNothing(row.Cells(chVAT.Index).Value) Then SQL.AddParam("@VATable", False) Else SQL.AddParam("@VATable", row.Cells(chVAT.Index).Value)
                    If IsNothing(row.Cells(chVATInc.Index).Value) Then SQL.AddParam("@VATVATincable", False) Else SQL.AddParam("@VATinc", row.Cells(chVATInc.Index).Value)
                    SQL.AddParam("@VATAmount", CDec(row.Cells(chVATAmount.Index).Value))
                    If IsNumeric(row.Cells(chDiscountRate.Index).Value) Then
                        SQL.AddParam("@DiscountRate", CDec(row.Cells(chDiscountRate.Index).Value))
                    Else
                        SQL.AddParam("@DiscountRate", 0)
                    End If
                    SQL.AddParam("@Discount", CDec(row.Cells(chDiscount.Index).Value))
                    SQL.AddParam("@NetAmount", CDec(row.Cells(chNetAmount.Index).Value))
                    SQL.AddParam("@WHSE", row.Cells(chWHSE.Index).Value)
                    If Not row.Cells(chDelivery.Index).Value Is Nothing AndAlso IsDate(row.Cells(chDelivery.Index).Value) Then
                        SQL.AddParam("@DateDeliver", row.Cells(chDelivery.Index).Value)
                    Else
                        SQL.AddParam("@DateDeliver", dtpDelivery.Value.Date)
                    End If

                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "SO_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdateSO()
        Try
            activityStatus = True
            Dim insertSQL, updateSQL As String
            updateSQL = " UPDATE  tblSO " & _
                         " SET    SO_No = @SO_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, VCECode = @VCECode, DateSO = @DateSO, " & _
                         "        DateDeliver = @DateDeliver, Remarks = @Remarks, StaggardDelivery = @StaggardDelivery, " & _
                         "        GrossAmount = @GrossAmount, Discount = @Discount, VATAmount = @VATAmount, NetAmount = @NetAmount, " & _
                         "        VATable = @VATable, VATInclusive = @VATInclusive, " & _
                         "        ReferenceNo = @ReferenceNo, SQ_Ref = @SQ_Ref, " & _
                         "        DateModified = GETDATE(), WhoModified = @WhoModified " & _
                         " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@SO_No", SONo)
            SQL.AddParam("@BranchCode", BranchCode)
            SQL.AddParam("@BusinessCode", BusinessType)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateSO", dtpDocDate.Value.Date)
            SQL.AddParam("@DateDeliver", dtpDelivery.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@StaggardDelivery", chkStaggared.Checked)
            SQL.AddParam("@GrossAmount", CDec(txtGross.Text))
            SQL.AddParam("@Discount", CDec(txtDiscount.Text))
            SQL.AddParam("@VATAmount", CDec(txtVAT.Text))
            SQL.AddParam("@NetAmount", CDec(txtNet.Text))
            SQL.AddParam("@VATable", chkVAT.Checked)
            SQL.AddParam("@VATInclusive", chkVATInc.Checked)
            SQL.AddParam("@ReferenceNo", txtRefNo.Text)
            SQL.AddParam("@SQ_Ref", SQ_ID)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            Dim deleteSQL As String
            deleteSQL = " DELETE FROM tblSO_Details WHERE TransID = '" & TransID & "' "
            SQL.ExecNonQuery(deleteSQL)

            Dim line As Integer = 1
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso Not row.Cells(chItemCode.Index).Value Is Nothing Then
                    insertSQL = " INSERT INTO " & _
                                " tblSO_Details(TransId, ItemCode, Description, UOM, QTY, UnitPrice, GrossAmount, VATable, VATinc, VATAmount, " & _
                                "                DiscountRate, Discount, NetAmount, WHSE, DateDeliver, LineNum, WhoCreated) " & _
                                " VALUES(@TransId, @ItemCode, @Description, @UOM, @QTY, @UnitPrice, @GrossAmount, @VATable, @VATinc, @VATAmount, " & _
                                "        @DiscountRate, @Discount, @NetAmount, @WHSE, @DateDeliver, @LineNum, @WhoCreated) "
                    SQL.FlushParams()
                    SQL.AddParam("@TransID", TransID)
                    SQL.AddParam("@ItemCode", IIf(row.Cells(chItemCode.Index).Value = Nothing, "", row.Cells(chItemCode.Index).Value))
                    SQL.AddParam("@Description", row.Cells(chItemDesc.Index).Value.ToString)
                    SQL.AddParam("@UOM", row.Cells(chUOM.Index).Value.ToString)
                    SQL.AddParam("@QTY", CDec(row.Cells(chQTY.Index).Value))
                    SQL.AddParam("@UnitPrice", CDec(row.Cells(chUnitPrice.Index).Value))
                    SQL.AddParam("@GrossAmount", CDec(row.Cells(chGross.Index).Value))
                    If IsNothing(row.Cells(chVAT.Index).Value) Then SQL.AddParam("@VATable", False) Else SQL.AddParam("@VATable", row.Cells(chVAT.Index).Value)
                    If IsNothing(row.Cells(chVATInc.Index).Value) Then SQL.AddParam("@VATVATincable", False) Else SQL.AddParam("@VATinc", row.Cells(chVATInc.Index).Value)
                    SQL.AddParam("@VATAmount", CDec(row.Cells(chVATAmount.Index).Value))
                    If IsNumeric(row.Cells(chDiscountRate.Index).Value) Then
                        SQL.AddParam("@DiscountRate", CDec(row.Cells(chDiscountRate.Index).Value))
                    Else
                        SQL.AddParam("@DiscountRate", 0)
                    End If
                    SQL.AddParam("@Discount", CDec(row.Cells(chDiscount.Index).Value))
                    SQL.AddParam("@NetAmount", CDec(row.Cells(chNetAmount.Index).Value))
                    SQL.AddParam("@WHSE", row.Cells(chWHSE.Index).Value)
                    If Not row.Cells(chDelivery.Index).Value Is Nothing AndAlso IsDate(row.Cells(chDelivery.Index).Value) Then
                        SQL.AddParam("@DateDeliver", row.Cells(chDelivery.Index).Value)
                    Else
                        SQL.AddParam("@DateDeliver", dtpDelivery.Value.Date)
                    End If

                    SQL.AddParam("@LineNum", line)
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                    line += 1
                End If
            Next
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "SO_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub ComputeTotal()
        Dim b As Decimal = 0
        Dim a As Decimal = 0
        Dim c As Decimal = 0
        Dim d As Decimal = 0
        ' COMPUTE GROSS
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chGross.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chGross.Index, i).Value) Then
                    a = a + Double.Parse(dgvItemList.Item(chGross.Index, i).Value).ToString
                End If
            End If
        Next
        txtGross.Text = a.ToString("N2")

        ' COMPUTE DISCOUNT
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chDiscount.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chDiscount.Index, i).Value) Then
                    b = b + Double.Parse(dgvItemList.Item(chDiscount.Index, i).Value)
                End If
            End If
        Next
        txtDiscount.Text = b.ToString("N2")


        ' COMPUTE VAT
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chVATAmount.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chVATAmount.Index, i).Value) Then
                    c = c + Double.Parse(dgvItemList.Item(chVATAmount.Index, i).Value).ToString
                End If
            End If
        Next
        txtVAT.Text = c.ToString("N2")

        ' COMPUTE NET
        For i As Integer = 0 To dgvItemList.Rows.Count - 1
            If Val(dgvItemList.Item(chNetAmount.Index, i).Value) <> 0 Then
                If IsNumeric(dgvItemList.Item(chNetAmount.Index, i).Value) Then
                    d = d + Double.Parse(dgvItemList.Item(chNetAmount.Index, i).Value).ToString
                End If
            End If
        Next
        txtNet.Text = d.ToString("N2")
    End Sub

    Private Sub dgvItemMaster_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        ComputeTotal()
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("SO_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("SO")
            If f.transID <> "" Then
                TransID = f.transID
            End If
            LoadSO(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("SO_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            SONo = ""

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
            If dgvItemList.Rows.Count > 0 Then
                dgvItemList.Rows(0).Cells(chDelivery.Index).Value = dtpDelivery.Value
            End If
            If dgvItemList.SelectedCells.Count > 0 Then
                dgvItemList.SelectedCells(0).Selected = False
            End If
            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("SO_EDIT") Then
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
        ElseIf dgvItemList.Rows.Count = 1 Then
            Msg("No item entered!", MsgBoxStyle.Exclamation)
        ElseIf POreq AndAlso txtRefNo.Text = "" Then
            Msg("Customer PO Required!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" AndAlso txtRefNo.Text <> "" AndAlso CustomerPOvalid() <> "" Then  ' WHEN ADDING NEW CV
            Msg("Customer PO Ref. already used for SO No. " & CustomerPOvalid() & "!", MsgBoxStyle.Exclamation)
        ElseIf TransID <> "" AndAlso txtRefNo.Text <> "" AndAlso CustomerPOvalid() <> "" AndAlso CustomerPOvalid() <> txtTransNum.Text Then  ' WHEN ADDING NEW CV
            Msg("Customer PO Ref. already used for SO No. " & CustomerPOvalid() & "!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                SONo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = SONo
                SaveSO()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                SONo = txtTransNum.Text
                LoadSO(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateSO()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                SONo = txtTransNum.Text
                LoadSO(TransID)
            End If
        End If
    End Sub

    Private Function CustomerPOvalid() As String
        Dim query As String
        query = " SELECT SO_No FROM tblSO WHERE ReferenceNo = @ReferenceNo AND VCECode = @VCECode  "
        SQL.FlushParams()
        SQL.AddParam("@ReferenceNo", txtRefNo.Text)
        SQL.AddParam("@VCECode", txtVCECode.Text)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("SO_No")
        Else
            Return ""
        End If
    End Function

    Private Sub tsbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrint.Click
        Dim f As New frmReport_Display
        f.ShowDialog("SO", TransID)
        f.Dispose()
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If SONo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblSO  WHERE SO_No < '" & SONo & "' ORDER BY SO_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadSO(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If SONo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblSO  WHERE SO_No > '" & SONo & "' ORDER BY SO_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadSO(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("SO_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblSO SET Status ='Cancelled', WhoModified = @WhoModified WHERE SO_No = @SO_No "
                        SQL.FlushParams()
                        SONo = txtTransNum.Text
                        SQL.AddParam("@SO_No", SONo)
                        SQL.AddParam("@WhoModified", UserID)
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

                        SONo = txtTransNum.Text
                        LoadSO(SONo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "SO_No", SONo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub btnSearchVCE_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVCE.Click
        Dim f As New frmVCE_Search
        f.Type = "Customer"
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        txtVCEName.Text = f.VCEName
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
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
            ElseIf e.KeyCode = Keys.P Then
                If tsbPrint.Enabled = True Then tsbPrint.PerformClick()
            ElseIf e.KeyCode = Keys.R Then
                If tsbReports.Enabled = True Then tsbReports.PerformClick()
            ElseIf e.KeyCode = Keys.C Then
                If tsbCopy.Enabled = True Then tsbCopy.ShowDropDown()
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

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If SONo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadSO(SONo)
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

    Private Sub tsbCopySQ_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopyPR.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("SQ")
        LoadSQ(f.transID)
        f.Dispose()
    End Sub

    Private Sub dgvItemList_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemList.CellEndEdit
        Try
            Dim itemCode, RecordID As String
            Dim rowIndex As Integer = dgvItemList.CurrentCell.RowIndex
            Dim colindex As Integer = dgvItemList.CurrentCell.ColumnIndex
            Select Case colindex
                Case chItemCode.Index
                    If dgvItemList.Item(chItemCode.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemList.Item(chItemCode.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("ItemMaster", itemCode, "Selling")
                        If f.TransID <> "" Then
                            RecordID = f.TransID
                            itemCode = f.ItemCode
                            LoadItem(RecordID, itemCode)
                        End If
                        dgvItemList.Rows.RemoveAt(e.RowIndex)
                        f.Dispose()
                    End If
                Case chItemDesc.Index
                    If dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value <> "" Then
                        itemCode = dgvItemList.Item(chItemDesc.Index, e.RowIndex).Value
                        Dim f As New frmCopyFrom
                        f.ShowDialog("ItemMaster", itemCode, "Selling")
                        If f.TransID <> "" Then
                            RecordID = f.TransID
                            itemCode = f.ItemCode
                            LoadItem(RecordID, itemCode)
                        End If
                        dgvItemList.Rows.RemoveAt(e.RowIndex)
                        f.Dispose()
                    End If
                Case chQTY.Index
                    If dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = "" OrElse IsNothing(dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    ElseIf IsNumeric(dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chQTY.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chUnitPrice.Index
                    If dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = "" OrElse IsNothing(dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    ElseIf IsNumeric(dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chQTY.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                        dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value = CDec(dgvItemList.Item(chUnitPrice.Index, e.RowIndex).Value).ToString("N2")
                    End If
                Case chDiscountRate.Index
                    If IsNumeric(dgvItemList.Item(chGross.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chDiscountRate.Index, e.RowIndex).Value) Then
                        txtDiscountRate.Text = ""
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chDiscount.Index
                    dgvItemList.Item(chDiscountRate.Index, e.RowIndex).Value = Nothing
                    If IsNumeric(dgvItemList.Item(chGross.Index, e.RowIndex).Value) AndAlso IsNumeric(dgvItemList.Item(chDiscount.Index, e.RowIndex).Value) Then
                        Recompute(e.RowIndex, e.ColumnIndex)
                        ComputeTotal()
                    End If
                Case chDelivery.Index
                    If IsDate(dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value = CDate(dgvItemList.Item(e.ColumnIndex, e.RowIndex).Value)
                    End If
            End Select
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub dgvItemList_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgvItemList.CurrentCellDirtyStateChanged
        If dgvItemList.SelectedCells.Count > 0 AndAlso (dgvItemList.SelectedCells(0).ColumnIndex = chVAT.Index OrElse dgvItemList.SelectedCells(0).ColumnIndex = chVATInc.Index) Then
            If dgvItemList.SelectedCells(0).RowIndex <> -1 Then
                Recompute(dgvItemList.SelectedCells(0).RowIndex, dgvItemList.SelectedCells(0).ColumnIndex)
                dgvItemList.SelectedCells(0).Selected = False
                dgvItemList.EndEdit()
            End If
        End If
    End Sub

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.Type = "Customer"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
        End If
    End Sub

    Private Sub chkStaggared_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStaggared.CheckedChanged
        If chkStaggared.Checked = True Then
            dgvItemList.Columns(chDelivery.Index).Visible = True
            dtpDelivery.Enabled = False
        Else
            dgvItemList.Columns(chDelivery.Index).Visible = False
            dtpDelivery.Enabled = True
        End If
    End Sub

    Private Sub dgvItemList_CellValidating(sender As System.Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvItemList.CellValidating
        If e.ColumnIndex = chUnitPrice.Index Or e.ColumnIndex = chQTY.Index Then
            Dim dc As Decimal
            If e.FormattedValue.ToString <> String.Empty AndAlso Not Decimal.TryParse(e.FormattedValue.ToString, dc) Then
                Msg("Invalid Number Format!", MsgBoxStyle.Exclamation)
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub txtDiscountRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountRate.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnApplyRate_Click(sender As System.Object, e As System.EventArgs) Handles btnApplyRate.Click
        If IsNumeric(txtDiscount.Text) Then
            For Each row As DataGridViewRow In dgvItemList.Rows
                If Not IsNothing(row.Cells(chItemCode.Index).Value) Then
                    row.Cells(chDiscountRate.Index).Value = txtDiscountRate.Text
                    Recompute(row.Index, chDiscountRate.Index)
                End If
            Next
        End If
    End Sub

    Private Sub txtDiscountRate_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDiscountRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txtDiscount.Text) Then
                For Each row As DataGridViewRow In dgvItemList.Rows
                    If Not IsNothing(row.Cells(chItemCode.Index).Value) Then
                        row.Cells(chDiscountRate.Index).Value = txtDiscountRate.Text
                        Recompute(row.Index, chDiscountRate.Index)
                    End If
                Next
            End If
        End If
    End Sub
End Class