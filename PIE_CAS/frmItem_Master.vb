Public Class frmItem_Master
    Public itemCode As String = ""
    Dim moduleID As String = "ITM"
    Dim disableEvent As Boolean = False
    Dim WHSE As String

    Private Sub frmItem_Master_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadUomGroup()
        LoadWHSE()
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbEdit.Enabled = False
        tsbSave.Enabled = False
        tsbDelete.Enabled = False
        tsbClose.Enabled = False
        tsbPrevious.Enabled = False
        tsbNext.Enabled = False
        tsbExit.Enabled = True
        EnableControl(False)
    End Sub


    Private Sub LoadItem(ByVal ItemCode As String)
        Dim query As String
        query = " SELECT ItemCode, Barcode, ItemName, ItemType, ItemCategory, ItemGroup, ItemUOMGroup, ItemUOM, ISNULL(ItemWeight,0) AS ItemWeight, " & _
                "        isInventory, isSales, isPurchase, isProduce, isFixAsset, isOwned, ItemOwner, " & _
                "        PD_UpdateLatest, PD_Supplier, PD_UnitCost, PD_UOM, ID_Warehouse, PD_SafetyStock, PD_ReorderQTY, VATable, PD_VATinc, " & _
                "        ISNULL(ID_Max,0) AS ID_Max, ISNULL(ID_Min,0) AS ID_Min, ID_Method, ID_UOM, ID_SC, AD_Sales, AD_COS, AD_Inv, AD_Discount " & _
                " FROM tblItem_Master " & _
                " WHERE ItemCode ='" & ItemCode & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            disableEvent = True
            txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
            txtBarcode.Text = SQL.SQLDR("Barcode").ToString
            txtItemName.Text = SQL.SQLDR("ItemName").ToString
            cbItemType.Text = SQL.SQLDR("ItemType").ToString
            If Not cbItemGroup.Items.Contains(SQL.SQLDR("ItemGroup").ToString) Then
                cbItemGroup.Items.Add(SQL.SQLDR("ItemGroup").ToString)
            End If
            cbItemGroup.SelectedItem = SQL.SQLDR("ItemGroup").ToString
            If SQL.SQLDR("ItemWeight") = 0 Then txtWeight.Text = "" Else txtWeight.Text = SQL.SQLDR("ItemWeight").ToString
            cbItemCategory.Text = SQL.SQLDR("ItemCategory").ToString
            If Not cbUoMGroup.Items.Contains(SQL.SQLDR("ItemUOMGroup").ToString) Then
                cbUoMGroup.Items.Add(SQL.SQLDR("ItemUOMGroup").ToString)
            End If
            cbUoMGroup.SelectedItem = SQL.SQLDR("ItemUOMGroup").ToString
            txtUOMBase.Text = SQL.SQLDR("ItemUOM").ToString

            chkInv.Checked = SQL.SQLDR("isInventory")
            chkSale.Checked = SQL.SQLDR("isSales")
            chkPurch.Checked = SQL.SQLDR("isPurchase")
            chkProd.Checked = SQL.SQLDR("isProduce")
            If SQL.SQLDR("isOwned") = False Then
                rbIDOwned.Checked = True
            Else
                rbIDOwned.Checked = False
            End If
            cbIDTolling.Text = SQL.SQLDR("ItemOwner").ToString

            ' PURCHASE DATA 
            chkPurchUpdate.Checked = SQL.SQLDR("PD_UpdateLatest")
            txtPurchVCECode.Text = SQL.SQLDR("PD_Supplier").ToString
            txtPurchPrice.Text = CDec(SQL.SQLDR("PD_UnitCost")).ToString("N2")
            txtPurchUOM.Text = SQL.SQLDR("PD_UOM").ToString
            txtPurchMinimum.Text = CDec(SQL.SQLDR("PD_SafetyStock")).ToString("N2")
            txtPurchReorder.Text = CDec(SQL.SQLDR("PD_ReorderQTY")).ToString("N2")
            chkVATable.Checked = SQL.SQLDR("VATable")
            chkPurchVATInc.Checked = SQL.SQLDR("PD_VATinc")

            ' INVENTORY DATA
            If SQL.SQLDR("ID_Max") = 0 Then
                txtInvMax.Text = ""
            Else
                txtInvMax.Text = SQL.SQLDR("ID_Max")
            End If
            If SQL.SQLDR("ID_Min") = 0 Then
                txtInvMin.Text = ""
            Else
                txtInvMin.Text = SQL.SQLDR("ID_Min")
            End If
            WHSE = SQL.SQLDR("ID_Warehouse").ToString
            cbInvMethod.SelectedItem = SQL.SQLDR("ID_Method").ToString
            txtInvUOM.Text = SQL.SQLDR("ID_UOM").ToString
            txtInvStandard.Text = CDec(SQL.SQLDR("ID_SC")).ToString("N2")

            disableEvent = False

            ' Accounting DATA
            txtSaleAccntCode.Text = SQL.SQLDR("AD_Sales").ToString
            txtCostAccntCode.Text = SQL.SQLDR("AD_COS").ToString
            txtInvAccntCode.Text = SQL.SQLDR("AD_Inv").ToString
            txtDiscAccntCode.Text = SQL.SQLDR("AD_Discount").ToString

            txtSaleAccntTitle.Text = GetAccntTitle(txtSaleAccntCode.Text)
            txtCostAccntTitle.Text = GetAccntTitle(txtCostAccntCode.Text)
            txtInvAccntTitle.Text = GetAccntTitle(txtInvAccntCode.Text)
            txtDiscAccntTitle.Text = GetAccntTitle(txtDiscAccntCode.Text)
            If GetWHSEDesc(WHSE) = "" Then
                cbInvWarehouse.SelectedIndex = -1
            Else
                cbInvWarehouse.SelectedItem = GetWHSEDesc(WHSE)
            End If

            txtPurchVCEname.Text = GetVCEName(txtPurchVCECode.Text)

            LoadPrice("Selling")
            LoadUomBOM()
            LoadWHSE_INVY()

            If cbUoMGroup.Text = "(Manual)" Then
                frmUOMConversion.Dispose()
                frmUOMConversion.LoadItem = True
            End If
            'LoadBOM(txtItemCode.Text)

            ' TOOLSTRIP BUTTONS
            tsbSearch.Enabled = True
            tsbNew.Enabled = True
            tsbEdit.Enabled = True
            tsbSave.Enabled = False
            tsbDelete.Enabled = True
            tsbClose.Enabled = False
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbExit.Enabled = True
            EnableControl(False)
        End If
    End Sub

    Private Sub LoadPrice(Type As String)
        Dim query As String
        query = " SELECT Type, UnitPrice, UOM, UOMQTY, VATInclusive, VCEName " & _
                " FROM   viewItem_Price " & _
                " WHERE  Category='" & Type & "' " & _
                " AND    ItemCode ='" & txtItemCode.Text & "'" & _
                " AND    PriceStatus ='Active' "
        SQL.GetQuery(query)
        dgvSell.Rows.Clear()
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvSell.Rows.Add({row(0).ToString, CDec(row(1)).ToString("N2"), row(2),
                                         row(3), row(4)})
            Next
        End If
    End Sub

    Private Sub LoadBOM(ItemCode As String)
        Dim ctr As Integer = 1
        Dim query As String
        query = " SELECT RecordID, MaterialCode, tblItem_Master.ItemName, tblBOM.UOM, tblBOM.QTY " & _
                " FROM   tblBOM INNER JOIN tblItem_Master " & _
                " ON     tblBOM.ItemCode = tblItem_Master.ItemCode  " & _
                " WHERE  tblItem_Master.ItemCode ='" & ItemCode & "'" & _
                " AND    tblBOM.Status ='Active' "
        SQL.GetQuery(query)
        dgvSell.Rows.Clear()
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                dgvSell.Rows.Add({row(0).ToString, ctr, row(1).ToString, row(2).ToString, row(3).ToString, CDec(row(4)).ToString("N2")})
            Next
        End If
    End Sub

    Private Sub LoadUomGroup()
        Dim temp As String
        Dim query As String
        temp = cbUoMGroup.SelectedItem
        query = " SELECT GroupCode FROM tblUOM_Group WHERE Status ='Active' AND Manual = 0 "
        SQL.ReadQuery(query)
        cbUoMGroup.Items.Clear()
        cbUoMGroup.Items.Add("(Manual)")
        While SQL.SQLDR.Read
            cbUoMGroup.Items.Add(SQL.SQLDR("GroupCode").ToString)
        End While
        If temp <> "" Then
            cbUoMGroup.SelectedItem = temp
        Else
            cbUoMGroup.SelectedItem = "(Manual)"
        End If
    End Sub

    Private Sub LoadBOMGroup()
        Dim temp As String
        Dim query As String
        temp = cbItemGroup.SelectedItem
        query = " SELECT BOMGroup FROM tblBOM_Group WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbItemGroup.Items.Clear()
        While SQL.SQLDR.Read
            cbItemGroup.Items.Add(SQL.SQLDR("BOMGroup").ToString)
        End While
        If temp <> "" Then
            cbItemGroup.SelectedItem = temp
        Else
            cbItemGroup.SelectedIndex = -1
        End If
    End Sub

    Private Sub LoadWHSE()
        Dim query As String
        query = " SELECT Description FROM tblWarehouse WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbInvWarehouse.Items.Clear()
        While SQL.SQLDR.Read
            cbInvWarehouse.Items.Add(SQL.SQLDR("Description").ToString)
        End While
    End Sub

    Private Sub btnUOM_Click(sender As System.Object, e As System.EventArgs) Handles btnUOM.Click
        frmItem_UOMlist.ShowDialog()
        If frmItem_UOMlist.UoM <> "" Then
            txtUOMBase.Text = frmItem_UOMlist.UoM
        End If
        frmItem_UOMlist.Dispose()
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("ITM_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmItem_Search
            f.ShowDialog()
            If f.ItemCode <> "" Then
                itemCode = f.ItemCode
            End If
            LoadItem(itemCode)
            f.Dispose()
        End If
    End Sub

    Private Sub LoadUomBOM()
        cbProdUOM.Items.Clear()
        'If cbUoMGroup.SelectedIndex <> -1 Then
        '    Dim query As String
        '    query = " SELECT DISTINCT UnitCode AS UOM " & _
        '            " FROM  " & _
        '            " ( " & _
        '            "   SELECT UnitCode FROM tblUOM_Group   " & _
        '            "   WHERE GroupCode = '" & cbUoMGroup.SelectedItem & "' " & _
        '            "   UNION ALL " & _
        '            "   SELECT UnitCode FROM tblUOM_GroupDetails " & _
        '            "   WHERE GroupCode = '" & cbUoMGroup.SelectedItem & "' " & _
        '            " ) AS A "
        '    SQL.ReadQuery(query)
        '    While SQL.SQLDR.Read
        '        cbProdUOM.Items.Add(SQL.SQLDR("UOM").ToString)
        '    End While
        'End If

    End Sub
    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("ITM_ADD") Then
            msgRestricted()
        Else
            txtItemCode.Clear()
            txtItemName.Clear()
            cbItemType.Text = ""
            cbItemCategory.Text = ""
            cbItemGroup.SelectedIndex = -1
            cbUoMGroup.SelectedIndex = -1
            txtUOMBase.Clear()
            txtBarcode.Clear()
            chkInv.Checked = False
            chkProd.Checked = False
            chkPurch.Checked = False
            chkSale.Checked = False
            cbUoMGroup.SelectedItem = "Manual"
            txtWeight.Clear()
            itemCode = ""


            ' PURCHASE DATA
            txtPurchUOM.Clear()
            txtPurchVCECode.Clear()
            txtPurchVCEname.Clear()
            txtPurchPrice.Clear()
            txtPurchUOM.Clear()
            txtPurchMinimum.Clear()
            txtPurchReorder.Clear()
            chkPurch.Checked = True

            ' SALES DATA
            dgvSell.Rows.Clear()

            ' INVENTORY DATA
            cbInvWarehouse.SelectedIndex = -1
            cbInvMethod.SelectedIndex = 0
            txtInvMax.Clear()
            txtInvMin.Clear()
            txtInvUOM.Clear()
            dgvInv.Rows.Clear()
            txtInvStock.Clear()
            txtInvOrder.Clear()
            txtInvCommit.Clear()
            txtInvAvailable.Clear()
            cbIDTolling.SelectedIndex = -1

            ' ACCOUNTING DATA
            txtCostAccntCode.Clear()
            txtCostAccntTitle.Clear()
            txtDiscAccntCode.Clear()
            txtDiscAccntTitle.Clear()
            txtInvAccntCode.Clear()
            txtInvAccntTitle.Clear()
            txtSaleAccntCode.Clear()
            txtSaleAccntTitle.Clear()

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
            frmUOMConversion.group = ""
            frmUOMConversion.Close()
            LoadUomGroup()
            LoadWHSE()
            LoadCategory()
            LoadType()
            LoadBOMGroup()
            EnableControl(True)
        End If
    End Sub

    Private Sub LoadCategory()
        Dim query As String
        query = " SELECT DISTINCT ItemCategory FROM tblItem_Master WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbItemCategory.Items.Clear()
        While SQL.SQLDR.Read
            cbItemCategory.Items.Add(SQL.SQLDR("ItemCategory").ToString)
        End While
    End Sub

    Private Sub LoadType()
        Dim query As String
        query = " SELECT DISTINCT ItemType FROM tblItem_Master WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbItemType.Items.Clear()
        While SQL.SQLDR.Read
            cbItemType.Items.Add(SQL.SQLDR("ItemType").ToString)
        End While
    End Sub


    Private Sub EnableControl(ByVal Value As Boolean)
        txtItemCode.Enabled = Value
        txtItemName.Enabled = Value

        cbItemType.Enabled = Value
        cbItemCategory.Enabled = Value
        txtBarcode.Enabled = Value
        chkInv.Enabled = Value
        chkProd.Enabled = Value
        chkPurch.Enabled = Value
        chkSale.Enabled = Value
        btnUOM.Enabled = Value
        btnBOMgroup.Enabled = Value
        cbUoMGroup.Enabled = Value
        btnUOMGroup.Enabled = Value
        chkExcise.Enabled = Value
        chkVATable.Enabled = Value
        cbItemGroup.Enabled = Value
        rbIDOwned.Enabled = Value
        rbIDTolling.Enabled = Value
        cbIDTolling.Enabled = Value
        txtWeight.Enabled = Value

        ' PURCHASE DATA
        If chkPurch.Checked Then
            txtPurchMinimum.Enabled = Value
            txtPurchPrice.Enabled = Value
            txtPurchReorder.Enabled = Value
            txtPurchVCECode.Enabled = Value
            btnPurchSupplier.Enabled = Value
            btnPurchUOM.Enabled = Value
            txtPurchVCEname.Enabled = Value
            chkPurchVATInc.Enabled = Value
            chkPurchUpdate.Enabled = Value
        Else
            txtPurchMinimum.Enabled = False
            txtPurchPrice.Enabled = False
            txtPurchReorder.Enabled = False
            txtPurchVCECode.Enabled = False
            btnPurchSupplier.Enabled = False
            btnPurchUOM.Enabled = False
            txtPurchVCEname.Enabled = False
            chkPurchVATInc.Enabled = False
            chkPurchUpdate.Enabled = False
        End If

        ' SALES DATA
        If chkSale.Checked Then
            cbSellType.Enabled = Value
            chkSellVAT.Enabled = Value
            txtSellPrice.Enabled = Value
            txtSellQTY.Enabled = Value
            btnSellAdd.Enabled = Value
            btnSellRemove.Enabled = Value
            btnSellUOM.Enabled = Value
        Else
            cbSellType.Enabled = False
            chkSellVAT.Enabled = False
            txtSellPrice.Enabled = False
            txtSellQTY.Enabled = False
            btnSellAdd.Enabled = False
            btnSellRemove.Enabled = False
            btnSellUOM.Enabled = False
        End If

        ' INVENTORY DATA 
        If chkInv.Checked Then
            cbInvMethod.Enabled = Value
            txtInvMin.Enabled = Value
            txtInvMax.Enabled = Value
            btnInvUOM.Enabled = Value
            cbInvWarehouse.Enabled = Value
            txtInvStandard.Enabled = Value
        Else
            cbInvMethod.Enabled = False
            txtInvMin.Enabled = False
            txtInvMax.Enabled = False
            btnInvUOM.Enabled = False
            cbInvWarehouse.Enabled = False
            txtInvStandard.Enabled = False
        End If

        ' PRODUCTION DATA 
        If chkProd.Checked Then
            txtProdName.Enabled = Value
            txtProdQTY.Enabled = Value
            btnProdAdd.Enabled = Value
            btnProdRemove.Enabled = Value
            cbProdUOM.Enabled = Value
        Else
            txtProdName.Enabled = False
            txtProdQTY.Enabled = False
            btnProdAdd.Enabled = False
            btnProdRemove.Enabled = False
            cbProdUOM.Enabled = False
        End If

        ' ENTRY DATA
        txtSaleAccntTitle.Enabled = Value
        txtCostAccntTitle.Enabled = Value
        txtInvAccntTitle.Enabled = Value
        txtDiscAccntTitle.Enabled = Value
    End Sub


    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("ITM_EDIT") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
        End If
    End Sub

    Private Sub tsbCloseClick(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If itemCode = "" Then
            tsbNew.PerformClick()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbDelete.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
        Else
            LoadItem(itemCode)
            tsbEdit.Enabled = True
            tsbDelete.Enabled = True
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
        End If
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click
        If Not AllowAccess("ITM_DEL") Then
            msgRestricted()
        Else
            If txtItemCode.Text <> "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " DELETE FROM tblItem_Master WHERE itemCode = @ItemCode "
                        SQL.FlushParams()
                        itemCode = txtItemCode.Text
                        SQL.AddParam("@ItemCode", itemCode)
                        SQL.ExecNonQuery(deleteSQL)
                        Msg("Record deleted successfully", MsgBoxStyle.Information)

                        tsbSearch.Enabled = True
                        tsbNew.Enabled = True
                        tsbEdit.Enabled = False
                        tsbSave.Enabled = False
                        tsbDelete.Enabled = False
                        tsbClose.Enabled = False
                        tsbPrevious.Enabled = False
                        tsbNext.Enabled = False
                        tsbExit.Enabled = True
                        EnableControl(False)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
                    Finally
                        RecordActivity(UserID, moduleID, Me.Name.ToString, "DELETE", "ItemCode", itemCode, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                        tsbNew.PerformClick()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If Validated() Then
            If itemCode = "" Then
                If MsgBox("Saving New Item, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    SaveItem()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    itemCode = txtItemCode.Text
                    LoadItem(itemCode)
                End If
            Else
                If MsgBox("Updating Item Information, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdateItem()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    itemCode = txtItemCode.Text
                    LoadItem(itemCode)
                End If
            End If
        End If
    End Sub

    Private Shadows Function Validated() As Boolean
        If txtItemCode.Text = "" Then
            Msg("Please enter Item Code for this Item!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf cbUoMGroup.SelectedIndex = -1 Then
            Msg("Please select default UoM Group for this item!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf cbUoMGroup.Text = "(Manual)" AndAlso txtUOMBase.Text = "" Then
            Msg("Please select Base UoM for this item!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf chkInv.Checked = True And cbInvWarehouse.SelectedIndex = -1 Then
            Msg("Please select default warehouse for this item!", MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub SaveItem()
        Try
            activityStatus = True
            ' VALIDATE VALUES
            If cbInvWarehouse.SelectedIndex = -1 Then WHSE = "" Else WHSE = GetWHSECode(cbInvWarehouse.SelectedItem)

            ' INSERT QUERY
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblItem_Master(ItemCode, Barcode, ItemName, ItemType, ItemCategory, ItemGroup, ItemOwner, ItemUOM, " & _
                        "        ItemWeight, ItemUOMGroup, isInventory, isSales, isPurchase, isProduce, isOwned,  VATable," & _
                        "        PD_UpdateLatest, PD_Supplier, PD_UnitCost, PD_UOM, PD_SafetyStock, PD_ReorderQTY, PD_VATinc, " & _
                        "        ID_Warehouse, ID_Max, ID_Min, ID_Method, ID_UOM, ID_SC, AD_Sales, AD_COS, AD_Inv, AD_Discount," & _
                        "        WhoCreated) " & _
                        " VALUES(@ItemCode, @Barcode, @ItemName, @ItemType, @ItemCategory, @ItemGroup, @ItemOwner, @ItemUOM, " & _
                        "        @ItemWeight, @ItemUOMGroup, @isInventory, @isSales, @isPurchase, @isProduce, @isOwned, @VATable, " & _
                        "        @PD_UpdateLatest, @PD_Supplier, @PD_UnitCost, @PD_UOM, @PD_SafetyStock, @PD_ReorderQTY, @PD_VATinc, " & _
                        "        @ID_Warehouse, @ID_Max, @ID_Min, @ID_Method, @ID_UOM, @ID_SC, @AD_Sales, @AD_COS, @AD_Inv, @AD_Discount, " & _
                        "        @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@ItemCode", txtItemCode.Text)
            SQL.AddParam("@Barcode", txtBarcode.Text)
            SQL.AddParam("@ItemName", txtItemName.Text)
            SQL.AddParam("@ItemType", cbItemType.Text)
            SQL.AddParam("@ItemCategory", cbItemCategory.Text)
            If IsNumeric(txtWeight.Text) Then SQL.AddParam("@ItemWeight", CDec(txtWeight.Text)) Else SQL.AddParam("@ItemWeight", 0)
            SQL.AddParam("@ItemGroup", IIf(cbItemGroup.SelectedIndex = -1, "", cbItemGroup.SelectedItem))
            SQL.AddParam("@ItemUOMGroup", IIf(cbUoMGroup.SelectedIndex = -1, "", cbUoMGroup.SelectedItem))
            SQL.AddParam("@ItemUOM", txtUOMBase.Text)
            SQL.AddParam("@isInventory", chkInv.Checked)
            SQL.AddParam("@isSales", chkSale.Checked)
            SQL.AddParam("@isPurchase", chkPurch.Checked)
            SQL.AddParam("@isProduce", chkProd.Checked)
            SQL.AddParam("@VATable", chkVATable.Checked)
            SQL.AddParam("@ItemOwner", cbIDTolling.Text)
            If rbIDOwned.Checked = True Then
                SQL.AddParam("@isOwned", True)
            Else
                SQL.AddParam("@isOwned", False)
            End If



            SQL.AddParam("@PD_UpdateLatest", chkPurchUpdate.Checked)
            SQL.AddParam("@PD_Supplier", txtPurchVCECode.Text)
            If IsNumeric(txtPurchPrice.Text) Then
                SQL.AddParam("@PD_UnitCost", CDec(txtPurchPrice.Text))
            Else
                SQL.AddParam("@PD_UnitCost", 0)
            End If
            SQL.AddParam("@PD_UOM", txtPurchUOM.Text)
            If IsNumeric(txtPurchMinimum.Text) Then
                SQL.AddParam("@PD_SafetyStock", CDec(txtPurchMinimum.Text))
            Else
                SQL.AddParam("@PD_SafetyStock", 0)
            End If

            If IsNumeric(txtPurchReorder.Text) Then
                SQL.AddParam("@PD_ReorderQTY", CDec(txtPurchReorder.Text))
            Else
                SQL.AddParam("@PD_ReorderQTY", 0)
            End If
            SQL.AddParam("@PD_VATinc", chkPurchVATInc.Checked)
            If IsNumeric(txtInvMax.Text) Then
                SQL.AddParam("@ID_Max", CDec(txtInvMax.Text))
            Else
                SQL.AddParam("@ID_Max", 0)
            End If

            If IsNumeric(txtInvMin.Text) Then
                SQL.AddParam("@ID_Min", CDec(txtInvMin.Text))
            Else
                SQL.AddParam("@ID_Min", 0)
            End If
            If cbInvMethod.SelectedIndex = -1 Then
                SQL.AddParam("@ID_Method", "")
            Else
                SQL.AddParam("@ID_Method", cbInvMethod.SelectedItem)
            End If
            If cbInvWarehouse.SelectedIndex = -1 Then
                SQL.AddParam("@ID_Warehouse", "")
            Else
                SQL.AddParam("@ID_Warehouse", WHSE)
            End If
            If IsNumeric(txtInvStandard.Text) Then
                SQL.AddParam("@ID_SC", CDec(txtInvStandard.Text))
            Else
                SQL.AddParam("@ID_SC", 0)
            End If
            SQL.AddParam("@ID_UOM", txtInvUOM.Text)
            SQL.AddParam("@AD_Sales", txtSaleAccntCode.Text)
            SQL.AddParam("@AD_COS", txtCostAccntCode.Text)
            SQL.AddParam("@AD_Inv", txtInvAccntCode.Text)
            SQL.AddParam("@AD_Discount", txtDiscAccntCode.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)

            UpdatePrice()
            UpdateUOM()
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "ItemCode", txtItemCode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdateItem()
        Try
            activityStatus = True
            ' VALIDATE VALUES
            If cbInvWarehouse.SelectedIndex = -1 Then WHSE = "" Else WHSE = GetWHSECode(cbInvWarehouse.SelectedItem)

            ' UPDATE QUERY
            Dim updateSQL As String
            updateSQL = " UPDATE tblItem_Master " & _
                        " SET    ItemCode = @ItemCodeNew, Barcode = @Barcode, ItemName = @ItemName, ItemType = @ItemType, ItemGroup = @ItemGroup, ItemWeight = @ItemWeight, " & _
                        "        ItemCategory = @ItemCategory, ItemUOMGroup = @ItemUOMGroup, ItemUOM = @ItemUOM, isInventory = @isInventory, ItemOwner = @ItemOwner," & _
                        "        isSales = @isSales, isPurchase = @isPurchase, isProduce = @isProduce, isOwned = @isOwned, VATable = @VATable,   " & _
                        "        PD_UpdateLatest = @PD_UpdateLatest, PD_Supplier = @PD_Supplier, PD_UnitCost = @PD_UnitCost, " & _
                        "        PD_UOM = @PD_UOM, PD_SafetyStock = @PD_SafetyStock, PD_ReorderQTY = @PD_ReorderQTY, PD_VATinc = @PD_VATinc, " & _
                        "        ID_Warehouse = @ID_Warehouse, ID_Min = @ID_Min, ID_Max = @ID_Max, ID_Method = @ID_Method, ID_UOM = @ID_UOM, ID_SC = @ID_SC, " & _
                        "        AD_Sales = @AD_Sales, AD_COS = @AD_COS, AD_Inv = @AD_Inv, AD_Discount = @AD_Discount," & _
                        "        DateModified = GETDATE(), WhoModified = @WhoModified " & _
                        " WHERE  ItemCode = @ItemCodeOld "
            SQL.FlushParams()
            SQL.AddParam("@ItemCodeOld", itemCode)
            SQL.AddParam("@ItemCodeNew", txtItemCode.Text)
            SQL.AddParam("@ItemUOMGroup", IIf(cbUoMGroup.SelectedIndex = -1, "", cbUoMGroup.SelectedItem))
            SQL.AddParam("@ItemGroup", IIf(cbItemGroup.SelectedIndex = -1, "", cbItemGroup.SelectedItem))
            SQL.AddParam("@Barcode", txtBarcode.Text)
            SQL.AddParam("@ItemName", txtItemName.Text)
            SQL.AddParam("@ItemType", cbItemType.Text)
            SQL.AddParam("@ItemCategory", cbItemCategory.Text)
            If IsNumeric(txtWeight.Text) Then SQL.AddParam("@ItemWeight", CDec(txtWeight.Text)) Else SQL.AddParam("@ItemWeight", 0)
            SQL.AddParam("@ItemUOM", txtUOMBase.Text)
            SQL.AddParam("@isInventory", chkInv.Checked)
            SQL.AddParam("@isSales", chkSale.Checked)
            SQL.AddParam("@isPurchase", chkPurch.Checked)
            SQL.AddParam("@isProduce", chkProd.Checked)
            SQL.AddParam("@PD_UpdateLatest", chkPurchUpdate.Checked)
            SQL.AddParam("@PD_Supplier", txtPurchVCECode.Text)
            SQL.AddParam("@ItemOwner", cbIDTolling.Text)
            If rbIDOwned.Checked = True Then
                SQL.AddParam("@isOwned", True)
            Else
                SQL.AddParam("@isOwned", False)
            End If

            If IsNumeric(txtPurchPrice.Text) Then
                SQL.AddParam("@PD_UnitCost", CDec(txtPurchPrice.Text))
            Else
                SQL.AddParam("@PD_UnitCost", 0)
            End If
            SQL.AddParam("@PD_UOM", txtPurchUOM.Text)
            If IsNumeric(txtPurchMinimum.Text) Then
                SQL.AddParam("@PD_SafetyStock", CDec(txtPurchMinimum.Text))
            Else
                SQL.AddParam("@PD_SafetyStock", 0)
            End If

            If IsNumeric(txtPurchReorder.Text) Then
                SQL.AddParam("@PD_ReorderQTY", CDec(txtPurchReorder.Text))
            Else
                SQL.AddParam("@PD_ReorderQTY", 0)
            End If
            SQL.AddParam("@VATable", chkVATable.Checked)
            SQL.AddParam("@PD_VATinc", chkPurchVATInc.Checked)
            If IsNumeric(txtInvMax.Text) Then
                SQL.AddParam("@ID_Max", CDec(txtInvMax.Text))
            Else
                SQL.AddParam("@ID_Max", 0)
            End If

            If IsNumeric(txtInvMin.Text) Then
                SQL.AddParam("@ID_Min", CDec(txtInvMin.Text))
            Else
                SQL.AddParam("@ID_Min", 0)
            End If
            If cbInvMethod.SelectedIndex = -1 Then
                SQL.AddParam("@ID_Method", "")
            Else
                SQL.AddParam("@ID_Method", cbInvMethod.SelectedItem)
            End If
            If cbInvWarehouse.SelectedIndex = -1 Then
                SQL.AddParam("@ID_Warehouse", "")
            Else
                SQL.AddParam("@ID_Warehouse", WHSE)
            End If
            If IsNumeric(txtInvStandard.Text) Then
                SQL.AddParam("@ID_SC", CDec(txtInvStandard.Text))
            Else
                SQL.AddParam("@ID_SC", 0)
            End If
            SQL.AddParam("@ID_UOM", txtInvUOM.Text)
            SQL.AddParam("@AD_Sales", txtSaleAccntCode.Text)
            SQL.AddParam("@AD_COS", txtCostAccntCode.Text)
            SQL.AddParam("@AD_Inv", txtInvAccntCode.Text)
            SQL.AddParam("@AD_Discount", txtDiscAccntCode.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)

            UpdatePrice()
            UpdateUOM()
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "ItemCode", txtItemCode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdateUOM()
        Try
            If cbUoMGroup.Text = "(Manual)" Then
                With frmUOMConversion
                    Dim insertSQL, updateSQL As String
                    activityStatus = True
                    Dim query As String
                    query = " SELECT * FROM tblUOM_Group WHERE GroupCode = @GroupCode "
                    SQL.FlushParams()
                    SQL.AddParam("@GroupCode", txtItemCode.Text)
                    SQL.ReadQuery(query)
                    If SQL.SQLDR.Read Then
                        updateSQL = " UPDATE tblUOM_Group " & _
                                    " SET    UnitCode = @UnitCode, Manual = @Manual, WhoModified = @WhoModified " & _
                                    " WHERE  GroupCode = @GroupCode "
                        SQL.FlushParams()
                        SQL.AddParam("@GroupCode", txtItemCode.Text)
                        SQL.AddParam("@UnitCode", txtUOMBase.Text)
                        If cbUoMGroup.Text = "(Manual)" Then
                            SQL.AddParam("@Manual", True)
                        Else
                            SQL.AddParam("@Manual", False)
                        End If
                        SQL.AddParam("@WhoModified", UserID)
                        SQL.ExecNonQuery(updateSQL)
                    Else
                        insertSQL = "  INSERT INTO " & _
                                    "  tblUOM_Group(GroupCode, UnitCode, Manual, WhoCreated) " & _
                                    "  VALUES(@GroupCode, @UnitCode, @Manual, @WhoCreated) "
                        SQL.FlushParams()
                        SQL.AddParam("@GroupCode", txtItemCode.Text)
                        SQL.AddParam("@UnitCode", txtUOMBase.Text)
                        If cbUoMGroup.Text = "(Manual)" Then
                            SQL.AddParam("@Manual", True)
                        Else
                            SQL.AddParam("@Manual", False)
                        End If
                        SQL.AddParam("@WhoCreated", UserID)
                        SQL.ExecNonQuery(insertSQL)
                    End If

                    For Each row As DataGridViewRow In .dgvAltUOM.Rows
                        If Not IsNothing(row.Cells(.chFromUoM.Index).Value) AndAlso Not IsNothing(row.Cells(.dgcToUOM.Index).Value) AndAlso IsNumeric(row.Cells(.chQTY.Index).Value) Then
                            insertSQL = " INSERT INTO " & _
                                        " tblUOM_GroupDetails(GroupCode, UnitCodeFrom, QTY, UnitCodeTo, WhoCreated) " & _
                                        " VALUES(@GroupCode, @UnitCodeFrom, @QTY, @UnitCodeTo, @WhoCreated)"
                            SQL.FlushParams()
                            SQL.AddParam("@GroupCode", txtItemCode.Text)
                            SQL.AddParam("@WhoCreated", UserID)
                            SQL.AddParam("@UnitCodeFrom", row.Cells(.chFromUoM.Index).Value.ToString)
                            If Not row.Cells(.chQTY.Index).Value Is Nothing AndAlso IsNumeric(row.Cells(.chQTY.Index).Value) Then
                                SQL.AddParam("@QTY", row.Cells(.chQTY.Index).Value)
                            Else
                                SQL.AddParam("@QTY", "1")
                            End If
                            SQL.AddParam("@UnitCodeTo", row.Cells(.dgcToUOM.Index).Value.ToString)
                            SQL.ExecNonQuery(insertSQL)
                        End If
                    Next
                End With
            End If
            
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "GroupCode", frmUOMConversion.cbUoMGroup.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    'Private Sub UpdateUOM()
    '    Try
    '        activityStatus = True
    '        Dim updateSQL As String
    '        updateSQL = "  UPDATE tblUOM_Group " & _
    '                    "  SET    UnitCode = @UnitCode, WhoModified = @WhoModified, Manual = @Manual " & _
    '                    "  WHERE  GroupCode = @GroupCode     "
    '        SQL.FlushParams()
    '        SQL.AddParam("@GroupCode", cbUoMGroup.Text)
    '        SQL.AddParam("@UnitCode", cbBaseUnit.SelectedItem)
    '        If group = "Manual" Then
    '            SQL.AddParam("@Manual", True)
    '        Else
    '            SQL.AddParam("@Manual", False)
    '        End If

    '        SQL.AddParam("@WhoModified", UserID)
    '        SQL.ExecNonQuery(updateSQL)

    '        Dim deleteSQL As String
    '        deleteSQL = " DELETE FROM tblUOM_GroupDetails WHERE GroupCode = @GroupCode "
    '        SQL.FlushParams()
    '        SQL.AddParam("@GroupCode", cbUoMGroup.Text)
    '        SQL.ExecNonQuery(deleteSQL)

    '        For Each row As DataGridViewRow In dgvAltUOM.Rows
    '            If row.Cells(chFromUoM.Index).Value <> Nothing Then
    '                Dim insertSQL As String
    '                insertSQL = " INSERT INTO " & _
    '                            " tblUOM_GroupDetails(GroupCode, UnitCodeFrom, QTY, UnitCodeTo, WhoCreated) " & _
    '                            " VALUES(@GroupCode, @UnitCodeFrom, @QTY, @UnitCodeTo, @WhoCreated)"
    '                SQL.FlushParams()
    '                SQL.AddParam("@GroupCode", cbUoMGroup.Text)
    '                SQL.AddParam("@WhoCreated", UserID)
    '                SQL.AddParam("@UnitCodeFrom", row.Cells(chFromUoM.Index).Value.ToString)
    '                If Not row.Cells(chQTY.Index).Value Is Nothing AndAlso IsNumeric(row.Cells(chQTY.Index).Value) Then
    '                    SQL.AddParam("@QTY", row.Cells(chQTY.Index).Value)
    '                Else
    '                    SQL.AddParam("@QTY", "1")
    '                End If
    '                SQL.AddParam("@UnitCodeTo", row.Cells(dgcToUOM.Index).Value.ToString)
    '                SQL.ExecNonQuery(insertSQL)
    '            End If
    '        Next

    '    Catch ex As Exception
    '        activityStatus = False
    '        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
    '    Finally
    '        RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "GroupCode", cbUoMGroup.Text, BusinessType, BranchCode, "", activityStatus)
    '        SQL.FlushParams()
    '    End Try
    'End Sub

    Private Sub UpdatePrice()
        Dim insertSQL As String
        Dim updateSQL As String
        updateSQL = " UPDATE tblItem_Price SET Status ='Inactive' WHERE ItemCode = @ItemCode"
        SQL.FlushParams()
        SQL.AddParam("@ItemCode", txtItemCode.Text)
        SQL.ExecNonQuery(updateSQL)

        For Each row As DataGridViewRow In dgvSell.Rows
            If Not row.Cells(dcSell_Price.Index).Value Is Nothing Then
                insertSQL = " INSERT INTO " & _
                        " tblItem_Price (Category, Type, ItemCode, VCECode, UOM, UOMQTY, UnitPrice, VATInclusive) " & _
                        " VALUES (@Category, @Type, @ItemCode, @VCECode, @UOM, @UOMQTY, @UnitPrice, @VATInclusive ) "
                SQL.FlushParams()
                SQL.AddParam("@Category", "Selling")
                SQL.AddParam("@Type", row.Cells(dcSell_Type.Index).Value)
                SQL.AddParam("@ItemCode", txtItemCode.Text)
                SQL.AddParam("@VCECode", DBNull.Value)
                SQL.AddParam("@UOM", row.Cells(dcSell_UOM.Index).Value)
                SQL.AddParam("@UOMQTY", CDec(row.Cells(dcSell_UOMQTY.Index).Value))
                SQL.AddParam("@UnitPrice", CDec(row.Cells(dcSell_Price.Index).Value))
                SQL.AddParam("@VATInclusive", row.Cells(dcSell_VAT.Index).Value)
                SQL.ExecNonQuery(insertSQL)
            End If
        Next

    End Sub


    Private Sub UpdateBOM()
        Dim insertSQL As String
        Dim updateSQL As String
        updateSQL = " UPDATE tblBOM SET Status ='Inactive' WHERE ItemCode = @ItemCode"
        SQL.FlushParams()
        SQL.AddParam("@ItemCode", txtItemCode.Text)
        SQL.ExecNonQuery(updateSQL)

        For Each row As DataGridViewRow In dgvSell.Rows
            If Not row.Cells(dcSell_Price.Index).Value Is Nothing Then
                insertSQL = " INSERT INTO " & _
                        " tblBOM (ItemCode, MaterialCode, UOM, QTY) " & _
                        " VALUES (ItemCode, MaterialCode, UOM, QTY) "
                SQL.FlushParams()
                SQL.AddParam("@ItemCode", txtItemCode.Text)
                SQL.AddParam("@UOM", row.Cells(chBOMcode.Index).Value)
                SQL.AddParam("@UOM", row.Cells(chBOMuom.Index).Value)
                SQL.AddParam("@QTY", CDec(row.Cells(chBOMqty.Index).Value))
                SQL.ExecNonQuery(insertSQL)
            End If
        Next

    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If itemCode <> "" Then
            Dim query As String
            query = " SELECT Top 1 ItemCode FROM tblItem_Master  WHERE ItemCode < '" & itemCode & "' ORDER BY ItemCode DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                itemCode = SQL.SQLDR("ItemCode").ToString
                LoadItem(itemCode)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If itemCode <> "" Then
            Dim query As String
            query = " SELECT Top 1 ItemCode FROM tblItem_Master  WHERE ItemCode > '" & itemCode & "' ORDER BY ItemCode ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                itemCode = SQL.SQLDR("ItemCode").ToString
                LoadItem(itemCode)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnUOMGroup_Click(sender As System.Object, e As System.EventArgs) Handles btnUOMGroup.Click
        If cbUoMGroup.Text <> "(Manual)" Then
            Dim f As New frmUOMConversion
            f.itemCode = txtItemCode.Text
            f.group = cbUoMGroup.Text
            f.ShowDialog()
            f.Dispose()
            LoadUomGroup()
        Else
            frmUOMConversion.Show()
        End If

    End Sub

    Private Sub cbUoMGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbUoMGroup.SelectedIndexChanged
        If disableEvent = False Then
            If cbUoMGroup.SelectedIndex <> -1 Then
                Dim query As String
                If cbUoMGroup.SelectedItem <> "Manual" Then
                    query = "  SELECT UnitCode FROM tblUOM_Group WHERE GroupCode ='" & cbUoMGroup.SelectedItem & "' "
                    SQL.ReadQuery(query)
                    If SQL.SQLDR.Read Then
                        txtUOMBase.Text = SQL.SQLDR("UnitCode").ToString
                        txtPurchUOM.Text = SQL.SQLDR("UnitCode").ToString
                        txtSellUOM.Text = SQL.SQLDR("UnitCode").ToString
                        txtInvUOM.Text = SQL.SQLDR("UnitCode").ToString
                        LoadUomBOM()
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub btnPurchSupplier_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchSupplier.Click
        Dim f As New frmVCE_Search
        f.Type = "Vendor"
        f.ShowDialog()
        txtPurchVCECode.Text = f.VCECode
        txtPurchVCEname.Text = f.VCEName
    End Sub

    Private Sub chkPurch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPurch.CheckedChanged
        txtPurchMinimum.Enabled = sender.checked
        txtPurchPrice.Enabled = sender.checked
        txtPurchReorder.Enabled = sender.checked
        txtPurchVCECode.Enabled = sender.checked
        btnPurchSupplier.Enabled = sender.checked
        btnPurchUOM.Enabled = sender.checked
        txtPurchVCEname.Enabled = sender.checked
        chkPurchUpdate.Enabled = sender.checked
        If chkVATable.Checked = False Then
            chkPurchVATInc.Enabled = False
        Else
            chkPurchVATInc.Enabled = sender.checked
        End If

    End Sub

    Private Sub frmItem_Master_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                If tsbDelete.Enabled = True Then tsbDelete.PerformClick()
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
                e.SuppressKeyPress = True
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbClose.Enabled = True Then
                    tsbClose.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
        End If
    End Sub

    Private Sub btnPurchUOM_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchUOM.Click
        If cbUoMGroup.SelectedIndex <> -1 Then
            frmItem_UOMlist.ShowDialog(cbUoMGroup.SelectedItem, itemCode)
        Else
            frmItem_UOMlist.ShowDialog()
        End If
        If Not IsNothing(frmItem_UOMlist.UoM) OrElse frmItem_UOMlist.UoM <> "" Then
            txtPurchUOM.Text = frmItem_UOMlist.UoM
        End If

        frmItem_UOMlist.Dispose()
    End Sub

    Private Sub txtSellQTY_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSellQTY.KeyDown
        If e.KeyValue <> 8 And Not (e.KeyValue >= 48 And e.KeyValue <= 57) Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnSellUOM_Click(sender As System.Object, e As System.EventArgs) Handles btnSellUOM.Click
        If cbUoMGroup.SelectedIndex <> -1 Then
            frmItem_UOMlist.ShowDialog(cbUoMGroup.SelectedItem, itemCode)
        Else
            frmItem_UOMlist.ShowDialog()
        End If
        If Not IsNothing(frmItem_UOMlist.UoM) OrElse frmItem_UOMlist.UoM <> "" Then
            txtSellUOM.Text = frmItem_UOMlist.UoM
        End If

        frmItem_UOMlist.Dispose()
    End Sub

    Private Sub chkSale_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSale.CheckedChanged
        cbSellType.Enabled = sender.checked
        txtSellPrice.Enabled = sender.checked
        txtSellQTY.Enabled = sender.checked
        btnSellAdd.Enabled = sender.checked
        btnSellRemove.Enabled = sender.checked
        btnSellUOM.Enabled = sender.checked
        If chkVATable.Checked = False Then
            chkSellVAT.Enabled = False
        Else
            chkSellVAT.Enabled = sender.checked
        End If
    End Sub

    Private Sub chkVATable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVATable.CheckedChanged
        If chkVATable.Checked = False Then
            chkSellVAT.Enabled = False
            chkPurchVATInc.Enabled = False
            chkSellVAT.Checked = False
            chkPurchVATInc.Checked = False
        Else
            If chkPurch.Checked = True Then
                chkPurchVATInc.Enabled = True
            End If
            If chkSale.Checked = True Then
                chkSellVAT.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtPurchPrice_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurchPrice.KeyPress, txtPurchMinimum.KeyPress, _
        txtPurchReorder.KeyPress
        If ControlChars.Back <> e.KeyChar Then
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnSellAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnSellAdd.Click
        If cbSellType.Text = "" Then
            Msg("Enter Selling Price Type", MsgBoxStyle.Exclamation)
        ElseIf txtSellUOM.Text = "" Then
            Msg("Please select UoM for this Price Type", MsgBoxStyle.Exclamation)
        ElseIf Not IsNumeric(txtSellPrice.Text) Then
            Msg("Invalid Price!", MsgBoxStyle.Exclamation)
        ElseIf IsNumeric(txtSellPrice.Text) AndAlso CDec(txtSellPrice.Text) <= 0 Then
            Msg("Price should be greater than zero!", MsgBoxStyle.Exclamation)
        Else
            dgvSell.Rows.Add({cbSellType.Text, txtSellPrice.Text, txtSellUOM.Text, txtSellQTY.Text, chkSellVAT.Checked})
            cbSellType.Text = ""
            txtSellPrice.Text = ""
            txtSellUOM.Text = ""
            txtSellQTY.Text = 1
            chkSellVAT.Checked = True
        End If
    End Sub

    Private Sub btnSellRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnSellRemove.Click
        If dgvSell.SelectedRows.Count = 1 Then
            dgvSell.Rows.RemoveAt(dgvSell.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub chkProd_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkProd.CheckedChanged
        txtProdName.Enabled = sender.checked
        txtProdQTY.Enabled = sender.checked
        btnProdAdd.Enabled = sender.checked
        btnProdRemove.Enabled = sender.checked
        cbProdUOM.Enabled = sender.checked
    End Sub

    Private Sub txtSaleAccntTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSaleAccntTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtSaleAccntTitle.Text)
                txtSaleAccntCode.Text = f.accountcode
                txtSaleAccntTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try
    End Sub

    Private Sub txtCostAccntTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCostAccntTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtCostAccntTitle.Text)
                txtCostAccntCode.Text = f.accountcode
                txtCostAccntTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try
    End Sub

    Private Sub txtInvAccntTitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtInvAccntTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtInvAccntTitle.Text)
                txtInvAccntCode.Text = f.accountcode
                txtInvAccntTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try
    End Sub

    Private Sub txtProdName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProdName.KeyDown

    End Sub

    Private Sub btnInvUOM_Click(sender As System.Object, e As System.EventArgs) Handles btnInvUOM.Click
        If cbUoMGroup.SelectedIndex <> -1 Then
            frmItem_UOMlist.ShowDialog(cbUoMGroup.SelectedItem)
        Else
            frmItem_UOMlist.ShowDialog()
        End If
        If frmItem_UOMlist.UoM <> "" Then
            txtInvUOM.Text = frmItem_UOMlist.UoM
        End If
        frmItem_UOMlist.Dispose()
    End Sub

    Private Sub chkInv_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkInv.CheckedChanged
        txtInvMax.Enabled = sender.checked
        txtInvMin.Enabled = sender.checked
        btnInvUOM.Enabled = sender.checked
        cbInvMethod.Enabled = sender.checked
        cbInvWarehouse.Enabled = sender.checked
        txtInvStandard.Enabled = sender.checked
    End Sub

    Private Sub TextBox5_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDiscAccntTitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtDiscAccntTitle.Text)
                txtDiscAccntCode.Text = f.accountcode
                txtDiscAccntTitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        End Try
    End Sub

    Private Sub LoadWHSE_INVY()
        Dim InStock, Ordered, Committed As Decimal
        InStock = 0
        Ordered = 0
        Committed = 0
        Dim query As String
        query = " SELECT  pvt.WHSE, Description, " & _
                " 		ISNULL(Instock,0) AS Instock, ISNULL(Ordered,0) AS Ordered, ISNULL(Committed,0) AS Committed, " & _
                " 		ISNULL(Instock,0)  + ISNULL(Ordered,0) - ISNULL(Committed,0) AS Available " & _
                " FROM " & _
                " ( " & _
                " 	SELECT   WHSE, SUM(QTY) AS QTY , 'InStock' AS Type " & _
                " 	FROM	 tblInventory " & _
                " 	WHERE	 ItemCode ='" & txtItemCode.Text & "'" & _
                " 	GROUP BY ItemCode, WHSE " & _
                " UNION ALL  " & _
                " 	SELECT	 WHSE, Unserved, 'Ordered' AS Type " & _
                " 	FROM	 viewPO_Unserved " & _
                " 	WHERE    ItemCode ='" & txtItemCode.Text & "' " & _
                " UNION ALL " & _
                " 	SELECT	 WHSE, Unserved, 'Committed' AS Type " & _
                " 	FROM	 viewSO_Unserved " & _
                " 	WHERE    ItemCode ='" & txtItemCode.Text & "' " & _
                " ) " & _
                " AS INVTY " & _
                " PIVOT  " & _
                " ( " & _
                " 	SUM(QTY) FOR [Type] " & _
                " 	IN ([Instock],[Ordered],[Committed]) " & _
                " ) AS pvt " & _
                " LEFT JOIN tblWarehouse " & _
                " ON pvt.WHSE = tblWarehouse.Code AND Status ='Active'"
        SQL.ReadQuery(query)
        dgvInv.Rows.Clear()
        While SQL.SQLDR.Read
            dgvInv.Rows.Add({SQL.SQLDR("WHSE").ToString, SQL.SQLDR("Description").ToString, CDec(SQL.SQLDR("InStock")).ToString("N2"), _
                             CDec(SQL.SQLDR("Ordered")).ToString("N2"), CDec(SQL.SQLDR("Committed")).ToString("N2"), CDec(SQL.SQLDR("Available")).ToString("N2")})
            InStock += SQL.SQLDR("InStock")
            Committed += SQL.SQLDR("Committed")
            Ordered += SQL.SQLDR("Ordered")
        End While
        txtInvStock.Text = InStock.ToString("N2")
        txtInvOrder.Text = Ordered.ToString("N2")
        txtInvCommit.Text = Committed.ToString("N2")
        txtInvAvailable.Text = (InStock + Ordered - Committed).ToString("N2")
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadWHSE_INVY()
    End Sub

    Private Sub gbSales_Enter(sender As System.Object, e As System.EventArgs) Handles gbSales.Enter

    End Sub

    Private Sub rbIDTolling_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbIDTolling.CheckedChanged
        If rbIDTolling.Checked = True Then
            cbIDTolling.Visible = True
        End If
    End Sub

    Private Sub btnBOMgroup_Click(sender As System.Object, e As System.EventArgs) Handles btnBOMgroup.Click
        Dim f As New frmBOM_Group
        f.ShowDialog()
        f.Dispose()
        LoadBOMGroup()
    End Sub
End Class