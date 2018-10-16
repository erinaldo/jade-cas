<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItem_Master
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItem_Master))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.tcItemDetails = New System.Windows.Forms.TabControl()
        Me.tpPD = New System.Windows.Forms.TabPage()
        Me.chkSerial = New System.Windows.Forms.CheckBox()
        Me.btnPurchSupplier = New System.Windows.Forms.Button()
        Me.txtPurchUOM = New System.Windows.Forms.TextBox()
        Me.btnPurchUOM = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPurchReorder = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtPurchMinimum = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkPurchVATInc = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPurchPrice = New System.Windows.Forms.TextBox()
        Me.txtPurchVCECode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPurchVCEname = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkPurchUpdate = New System.Windows.Forms.CheckBox()
        Me.tpSD = New System.Windows.Forms.TabPage()
        Me.gbSales = New System.Windows.Forms.GroupBox()
        Me.btnSellUOM = New System.Windows.Forms.Button()
        Me.dgvSell = New System.Windows.Forms.DataGridView()
        Me.dcSell_Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcSell_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcSell_UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcSell_UOMQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcSell_VAT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnSellRemove = New System.Windows.Forms.Button()
        Me.cbSellType = New System.Windows.Forms.ComboBox()
        Me.btnSellAdd = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSellPrice = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkSellVAT = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSellUOM = New System.Windows.Forms.TextBox()
        Me.txtSellQTY = New System.Windows.Forms.TextBox()
        Me.tpID = New System.Windows.Forms.TabPage()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtInvStandard = New System.Windows.Forms.TextBox()
        Me.txtInvUOM = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbInvWarehouse = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtInvMax = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInvMin = New System.Windows.Forms.TextBox()
        Me.cbInvMethod = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInvAvailable = New System.Windows.Forms.TextBox()
        Me.txtInvCommit = New System.Windows.Forms.TextBox()
        Me.txtInvOrder = New System.Windows.Forms.TextBox()
        Me.txtInvStock = New System.Windows.Forms.TextBox()
        Me.dgvInv = New System.Windows.Forms.DataGridView()
        Me.chInvWHSECode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chInvWHSEName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chInvStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chInvOrdered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chInvCommit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chInvAvail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnInvUOM = New System.Windows.Forms.Button()
        Me.tpMD = New System.Windows.Forms.TabPage()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cbProdUOM = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtProdCode = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtProdQTY = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtProdName = New System.Windows.Forms.TextBox()
        Me.btnProdRemove = New System.Windows.Forms.Button()
        Me.btnProdAdd = New System.Windows.Forms.Button()
        Me.dgvProdBOM = New System.Windows.Forms.DataGridView()
        Me.chProdID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBOMcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBOMname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBOMuom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBOMqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpDefaultEntry = New System.Windows.Forms.TabPage()
        Me.txtDiscAccntTitle = New System.Windows.Forms.TextBox()
        Me.txtDiscAccntCode = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtInvAccntTitle = New System.Windows.Forms.TextBox()
        Me.txtInvAccntCode = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCostAccntTitle = New System.Windows.Forms.TextBox()
        Me.txtCostAccntCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSaleAccntTitle = New System.Windows.Forms.TextBox()
        Me.txtSaleAccntCode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkVATable = New System.Windows.Forms.CheckBox()
        Me.chkInv = New System.Windows.Forms.CheckBox()
        Me.chkSale = New System.Windows.Forms.CheckBox()
        Me.chkPurch = New System.Windows.Forms.CheckBox()
        Me.chkProd = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbItemType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbItemCategory = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrevious = New System.Windows.Forms.ToolStripButton()
        Me.tsbNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.cbUoMGroup = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtUOMBase = New System.Windows.Forms.TextBox()
        Me.chkExcise = New System.Windows.Forms.CheckBox()
        Me.cbItemGroup = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbIDTolling = New System.Windows.Forms.ComboBox()
        Me.rbIDTolling = New System.Windows.Forms.RadioButton()
        Me.rbIDOwned = New System.Windows.Forms.RadioButton()
        Me.btnUOMGroup = New System.Windows.Forms.Button()
        Me.btnUOM = New System.Windows.Forms.Button()
        Me.btnBOMgroup = New System.Windows.Forms.Button()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tcItemDetails.SuspendLayout()
        Me.tpPD.SuspendLayout()
        Me.tpSD.SuspendLayout()
        Me.gbSales.SuspendLayout()
        CType(Me.dgvSell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpID.SuspendLayout()
        CType(Me.dgvInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMD.SuspendLayout()
        CType(Me.dgvProdBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDefaultEntry.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 86)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 1077
        Me.Label1.Text = "Item Name :"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.SystemColors.Window
        Me.txtItemName.ForeColor = System.Drawing.Color.Black
        Me.txtItemName.Location = New System.Drawing.Point(110, 82)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(431, 22)
        Me.txtItemName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(30, 60)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 1087
        Me.Label4.Text = "Item Code :"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtItemCode.ForeColor = System.Drawing.Color.Black
        Me.txtItemCode.Location = New System.Drawing.Point(110, 57)
        Me.txtItemCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(431, 22)
        Me.txtItemCode.TabIndex = 1
        '
        'tcItemDetails
        '
        Me.tcItemDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcItemDetails.Controls.Add(Me.tpPD)
        Me.tcItemDetails.Controls.Add(Me.tpSD)
        Me.tcItemDetails.Controls.Add(Me.tpID)
        Me.tcItemDetails.Controls.Add(Me.tpMD)
        Me.tcItemDetails.Controls.Add(Me.tpDefaultEntry)
        Me.tcItemDetails.Location = New System.Drawing.Point(13, 243)
        Me.tcItemDetails.Name = "tcItemDetails"
        Me.tcItemDetails.SelectedIndex = 0
        Me.tcItemDetails.Size = New System.Drawing.Size(1066, 441)
        Me.tcItemDetails.TabIndex = 1167
        '
        'tpPD
        '
        Me.tpPD.BackColor = System.Drawing.Color.White
        Me.tpPD.Controls.Add(Me.chkSerial)
        Me.tpPD.Controls.Add(Me.btnPurchSupplier)
        Me.tpPD.Controls.Add(Me.txtPurchUOM)
        Me.tpPD.Controls.Add(Me.btnPurchUOM)
        Me.tpPD.Controls.Add(Me.Label23)
        Me.tpPD.Controls.Add(Me.txtPurchReorder)
        Me.tpPD.Controls.Add(Me.Label24)
        Me.tpPD.Controls.Add(Me.txtPurchMinimum)
        Me.tpPD.Controls.Add(Me.Button1)
        Me.tpPD.Controls.Add(Me.chkPurchVATInc)
        Me.tpPD.Controls.Add(Me.Label17)
        Me.tpPD.Controls.Add(Me.txtPurchPrice)
        Me.tpPD.Controls.Add(Me.txtPurchVCECode)
        Me.tpPD.Controls.Add(Me.Label13)
        Me.tpPD.Controls.Add(Me.txtPurchVCEname)
        Me.tpPD.Controls.Add(Me.Label11)
        Me.tpPD.Controls.Add(Me.chkPurchUpdate)
        Me.tpPD.Location = New System.Drawing.Point(4, 25)
        Me.tpPD.Name = "tpPD"
        Me.tpPD.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPD.Size = New System.Drawing.Size(1058, 412)
        Me.tpPD.TabIndex = 0
        Me.tpPD.Text = "Purchase Data"
        '
        'chkSerial
        '
        Me.chkSerial.AutoSize = True
        Me.chkSerial.Location = New System.Drawing.Point(227, 126)
        Me.chkSerial.Name = "chkSerial"
        Me.chkSerial.Size = New System.Drawing.Size(131, 20)
        Me.chkSerial.TabIndex = 1210
        Me.chkSerial.Text = "Serial # Required"
        Me.chkSerial.UseVisualStyleBackColor = True
        Me.chkSerial.Visible = False
        '
        'btnPurchSupplier
        '
        Me.btnPurchSupplier.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnPurchSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPurchSupplier.Location = New System.Drawing.Point(647, 42)
        Me.btnPurchSupplier.Name = "btnPurchSupplier"
        Me.btnPurchSupplier.Size = New System.Drawing.Size(25, 25)
        Me.btnPurchSupplier.TabIndex = 1213
        Me.btnPurchSupplier.UseVisualStyleBackColor = True
        '
        'txtPurchUOM
        '
        Me.txtPurchUOM.BackColor = System.Drawing.SystemColors.Window
        Me.txtPurchUOM.Enabled = False
        Me.txtPurchUOM.ForeColor = System.Drawing.Color.Black
        Me.txtPurchUOM.Location = New System.Drawing.Point(227, 70)
        Me.txtPurchUOM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchUOM.Name = "txtPurchUOM"
        Me.txtPurchUOM.Size = New System.Drawing.Size(111, 22)
        Me.txtPurchUOM.TabIndex = 1212
        '
        'btnPurchUOM
        '
        Me.btnPurchUOM.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnPurchUOM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPurchUOM.Location = New System.Drawing.Point(340, 69)
        Me.btnPurchUOM.Name = "btnPurchUOM"
        Me.btnPurchUOM.Size = New System.Drawing.Size(25, 25)
        Me.btnPurchUOM.TabIndex = 1211
        Me.btnPurchUOM.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(105, 205)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(115, 16)
        Me.Label23.TabIndex = 1206
        Me.Label23.Text = "Reorder Quantity :"
        '
        'txtPurchReorder
        '
        Me.txtPurchReorder.BackColor = System.Drawing.SystemColors.Window
        Me.txtPurchReorder.ForeColor = System.Drawing.Color.Black
        Me.txtPurchReorder.Location = New System.Drawing.Point(223, 202)
        Me.txtPurchReorder.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchReorder.Name = "txtPurchReorder"
        Me.txtPurchReorder.Size = New System.Drawing.Size(157, 22)
        Me.txtPurchReorder.TabIndex = 1205
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(57, 180)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(163, 16)
        Me.Label24.TabIndex = 1204
        Me.Label24.Text = "Minimum Before Reorder :"
        '
        'txtPurchMinimum
        '
        Me.txtPurchMinimum.BackColor = System.Drawing.SystemColors.Window
        Me.txtPurchMinimum.ForeColor = System.Drawing.Color.Black
        Me.txtPurchMinimum.Location = New System.Drawing.Point(223, 176)
        Me.txtPurchMinimum.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchMinimum.Name = "txtPurchMinimum"
        Me.txtPurchMinimum.Size = New System.Drawing.Size(157, 22)
        Me.txtPurchMinimum.TabIndex = 1203
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(223, 231)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 45)
        Me.Button1.TabIndex = 1202
        Me.Button1.Text = "Purchase History"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chkPurchVATInc
        '
        Me.chkPurchVATInc.AutoSize = True
        Me.chkPurchVATInc.Checked = True
        Me.chkPurchVATInc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPurchVATInc.Location = New System.Drawing.Point(345, 100)
        Me.chkPurchVATInc.Name = "chkPurchVATInc"
        Me.chkPurchVATInc.Size = New System.Drawing.Size(77, 20)
        Me.chkPurchVATInc.TabIndex = 1195
        Me.chkPurchVATInc.Text = "VAT Inc."
        Me.chkPurchVATInc.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(155, 98)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 16)
        Me.Label17.TabIndex = 1187
        Me.Label17.Text = "Unit Price :"
        '
        'txtPurchPrice
        '
        Me.txtPurchPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtPurchPrice.ForeColor = System.Drawing.Color.Black
        Me.txtPurchPrice.Location = New System.Drawing.Point(227, 96)
        Me.txtPurchPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchPrice.Name = "txtPurchPrice"
        Me.txtPurchPrice.Size = New System.Drawing.Size(111, 22)
        Me.txtPurchPrice.TabIndex = 1186
        '
        'txtPurchVCECode
        '
        Me.txtPurchVCECode.BackColor = System.Drawing.SystemColors.Window
        Me.txtPurchVCECode.ForeColor = System.Drawing.Color.Black
        Me.txtPurchVCECode.Location = New System.Drawing.Point(227, 44)
        Me.txtPurchVCECode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchVCECode.Name = "txtPurchVCECode"
        Me.txtPurchVCECode.Size = New System.Drawing.Size(111, 22)
        Me.txtPurchVCECode.TabIndex = 1183
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(101, 46)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(123, 16)
        Me.Label13.TabIndex = 1182
        Me.Label13.Text = "Preferred Supplier :"
        '
        'txtPurchVCEname
        '
        Me.txtPurchVCEname.BackColor = System.Drawing.SystemColors.Window
        Me.txtPurchVCEname.ForeColor = System.Drawing.Color.Black
        Me.txtPurchVCEname.Location = New System.Drawing.Point(339, 44)
        Me.txtPurchVCEname.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchVCEname.Name = "txtPurchVCEname"
        Me.txtPurchVCEname.Size = New System.Drawing.Size(305, 22)
        Me.txtPurchVCEname.TabIndex = 1181
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(121, 73)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 16)
        Me.Label11.TabIndex = 1177
        Me.Label11.Text = "Purchase UoM :"
        '
        'chkPurchUpdate
        '
        Me.chkPurchUpdate.AutoSize = True
        Me.chkPurchUpdate.Location = New System.Drawing.Point(227, 21)
        Me.chkPurchUpdate.Name = "chkPurchUpdate"
        Me.chkPurchUpdate.Size = New System.Drawing.Size(219, 20)
        Me.chkPurchUpdate.TabIndex = 1172
        Me.chkPurchUpdate.Text = "Update based on Last purchase"
        Me.chkPurchUpdate.UseVisualStyleBackColor = True
        '
        'tpSD
        '
        Me.tpSD.Controls.Add(Me.gbSales)
        Me.tpSD.Location = New System.Drawing.Point(4, 25)
        Me.tpSD.Name = "tpSD"
        Me.tpSD.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSD.Size = New System.Drawing.Size(1058, 412)
        Me.tpSD.TabIndex = 6
        Me.tpSD.Text = "Sales Data"
        Me.tpSD.UseVisualStyleBackColor = True
        '
        'gbSales
        '
        Me.gbSales.Controls.Add(Me.btnSellUOM)
        Me.gbSales.Controls.Add(Me.dgvSell)
        Me.gbSales.Controls.Add(Me.btnSellRemove)
        Me.gbSales.Controls.Add(Me.cbSellType)
        Me.gbSales.Controls.Add(Me.btnSellAdd)
        Me.gbSales.Controls.Add(Me.Label20)
        Me.gbSales.Controls.Add(Me.txtSellPrice)
        Me.gbSales.Controls.Add(Me.Label15)
        Me.gbSales.Controls.Add(Me.chkSellVAT)
        Me.gbSales.Controls.Add(Me.Label18)
        Me.gbSales.Controls.Add(Me.Label16)
        Me.gbSales.Controls.Add(Me.txtSellUOM)
        Me.gbSales.Controls.Add(Me.txtSellQTY)
        Me.gbSales.Location = New System.Drawing.Point(8, 9)
        Me.gbSales.Name = "gbSales"
        Me.gbSales.Size = New System.Drawing.Size(945, 306)
        Me.gbSales.TabIndex = 1172
        Me.gbSales.TabStop = False
        Me.gbSales.Text = "Prices"
        '
        'btnSellUOM
        '
        Me.btnSellUOM.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnSellUOM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSellUOM.Location = New System.Drawing.Point(581, 80)
        Me.btnSellUOM.Name = "btnSellUOM"
        Me.btnSellUOM.Size = New System.Drawing.Size(25, 25)
        Me.btnSellUOM.TabIndex = 1212
        Me.btnSellUOM.UseVisualStyleBackColor = True
        '
        'dgvSell
        '
        Me.dgvSell.AllowUserToAddRows = False
        Me.dgvSell.AllowUserToDeleteRows = False
        Me.dgvSell.AllowUserToResizeColumns = False
        Me.dgvSell.AllowUserToResizeRows = False
        Me.dgvSell.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvSell.BackgroundColor = System.Drawing.Color.White
        Me.dgvSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSell.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcSell_Type, Me.dcSell_Price, Me.dcSell_UOM, Me.dcSell_UOMQTY, Me.dcSell_VAT})
        Me.dgvSell.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSell.Location = New System.Drawing.Point(8, 21)
        Me.dgvSell.MultiSelect = False
        Me.dgvSell.Name = "dgvSell"
        Me.dgvSell.ReadOnly = True
        Me.dgvSell.RowHeadersVisible = False
        Me.dgvSell.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSell.Size = New System.Drawing.Size(438, 211)
        Me.dgvSell.TabIndex = 1158
        '
        'dcSell_Type
        '
        Me.dcSell_Type.HeaderText = "Type"
        Me.dcSell_Type.Name = "dcSell_Type"
        Me.dcSell_Type.ReadOnly = True
        Me.dcSell_Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcSell_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcSell_Type.Width = 150
        '
        'dcSell_Price
        '
        Me.dcSell_Price.HeaderText = "Price"
        Me.dcSell_Price.Name = "dcSell_Price"
        Me.dcSell_Price.ReadOnly = True
        Me.dcSell_Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcSell_UOM
        '
        Me.dcSell_UOM.HeaderText = "UOM"
        Me.dcSell_UOM.Name = "dcSell_UOM"
        Me.dcSell_UOM.ReadOnly = True
        Me.dcSell_UOM.Width = 60
        '
        'dcSell_UOMQTY
        '
        Me.dcSell_UOMQTY.HeaderText = "QTY"
        Me.dcSell_UOMQTY.Name = "dcSell_UOMQTY"
        Me.dcSell_UOMQTY.ReadOnly = True
        Me.dcSell_UOMQTY.Width = 60
        '
        'dcSell_VAT
        '
        Me.dcSell_VAT.HeaderText = "w/ VAT"
        Me.dcSell_VAT.Name = "dcSell_VAT"
        Me.dcSell_VAT.ReadOnly = True
        Me.dcSell_VAT.Width = 60
        '
        'btnSellRemove
        '
        Me.btnSellRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSellRemove.Enabled = False
        Me.btnSellRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSellRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSellRemove.ForeColor = System.Drawing.Color.White
        Me.btnSellRemove.Location = New System.Drawing.Point(453, 170)
        Me.btnSellRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSellRemove.Name = "btnSellRemove"
        Me.btnSellRemove.Size = New System.Drawing.Size(75, 24)
        Me.btnSellRemove.TabIndex = 1171
        Me.btnSellRemove.Text = "Remove"
        Me.btnSellRemove.UseVisualStyleBackColor = False
        '
        'cbSellType
        '
        Me.cbSellType.FormattingEnabled = True
        Me.cbSellType.Location = New System.Drawing.Point(506, 30)
        Me.cbSellType.Name = "cbSellType"
        Me.cbSellType.Size = New System.Drawing.Size(153, 24)
        Me.cbSellType.TabIndex = 1160
        '
        'btnSellAdd
        '
        Me.btnSellAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSellAdd.Enabled = False
        Me.btnSellAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSellAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSellAdd.ForeColor = System.Drawing.Color.White
        Me.btnSellAdd.Location = New System.Drawing.Point(453, 145)
        Me.btnSellAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSellAdd.Name = "btnSellAdd"
        Me.btnSellAdd.Size = New System.Drawing.Size(75, 24)
        Me.btnSellAdd.TabIndex = 1170
        Me.btnSellAdd.Text = "Add"
        Me.btnSellAdd.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(458, 33)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 16)
        Me.Label20.TabIndex = 1161
        Me.Label20.Text = "Type :"
        '
        'txtSellPrice
        '
        Me.txtSellPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtSellPrice.ForeColor = System.Drawing.Color.Black
        Me.txtSellPrice.Location = New System.Drawing.Point(506, 56)
        Me.txtSellPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSellPrice.Name = "txtSellPrice"
        Me.txtSellPrice.Size = New System.Drawing.Size(153, 22)
        Me.txtSellPrice.TabIndex = 1162
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(463, 106)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 16)
        Me.Label15.TabIndex = 1167
        Me.Label15.Text = "QTY :"
        '
        'chkSellVAT
        '
        Me.chkSellVAT.AutoSize = True
        Me.chkSellVAT.Checked = True
        Me.chkSellVAT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSellVAT.Location = New System.Drawing.Point(666, 59)
        Me.chkSellVAT.Name = "chkSellVAT"
        Me.chkSellVAT.Size = New System.Drawing.Size(77, 20)
        Me.chkSellVAT.TabIndex = 1168
        Me.chkSellVAT.Text = "VAT Inc."
        Me.chkSellVAT.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(460, 81)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 16)
        Me.Label18.TabIndex = 1165
        Me.Label18.Text = "UOM :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(460, 59)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 16)
        Me.Label16.TabIndex = 1163
        Me.Label16.Text = "Price :"
        '
        'txtSellUOM
        '
        Me.txtSellUOM.BackColor = System.Drawing.SystemColors.Window
        Me.txtSellUOM.Enabled = False
        Me.txtSellUOM.ForeColor = System.Drawing.Color.Black
        Me.txtSellUOM.Location = New System.Drawing.Point(506, 81)
        Me.txtSellUOM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSellUOM.Name = "txtSellUOM"
        Me.txtSellUOM.Size = New System.Drawing.Size(68, 22)
        Me.txtSellUOM.TabIndex = 1164
        '
        'txtSellQTY
        '
        Me.txtSellQTY.BackColor = System.Drawing.SystemColors.Window
        Me.txtSellQTY.ForeColor = System.Drawing.Color.Black
        Me.txtSellQTY.Location = New System.Drawing.Point(506, 106)
        Me.txtSellQTY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSellQTY.Name = "txtSellQTY"
        Me.txtSellQTY.Size = New System.Drawing.Size(68, 22)
        Me.txtSellQTY.TabIndex = 1166
        Me.txtSellQTY.Text = "1"
        '
        'tpID
        '
        Me.tpID.Controls.Add(Me.Label30)
        Me.tpID.Controls.Add(Me.txtInvStandard)
        Me.tpID.Controls.Add(Me.txtInvUOM)
        Me.tpID.Controls.Add(Me.Label8)
        Me.tpID.Controls.Add(Me.cbInvWarehouse)
        Me.tpID.Controls.Add(Me.Label12)
        Me.tpID.Controls.Add(Me.txtInvMax)
        Me.tpID.Controls.Add(Me.Label7)
        Me.tpID.Controls.Add(Me.txtInvMin)
        Me.tpID.Controls.Add(Me.cbInvMethod)
        Me.tpID.Controls.Add(Me.Label6)
        Me.tpID.Controls.Add(Me.Label5)
        Me.tpID.Controls.Add(Me.txtInvAvailable)
        Me.tpID.Controls.Add(Me.txtInvCommit)
        Me.tpID.Controls.Add(Me.txtInvOrder)
        Me.tpID.Controls.Add(Me.txtInvStock)
        Me.tpID.Controls.Add(Me.dgvInv)
        Me.tpID.Controls.Add(Me.btnRefresh)
        Me.tpID.Controls.Add(Me.btnInvUOM)
        Me.tpID.Location = New System.Drawing.Point(4, 25)
        Me.tpID.Name = "tpID"
        Me.tpID.Size = New System.Drawing.Size(1058, 412)
        Me.tpID.TabIndex = 2
        Me.tpID.Text = "Inventory Data"
        Me.tpID.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(47, 96)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(99, 16)
        Me.Label30.TabIndex = 1213
        Me.Label30.Text = "Standard Cost :"
        '
        'txtInvStandard
        '
        Me.txtInvStandard.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvStandard.ForeColor = System.Drawing.Color.Black
        Me.txtInvStandard.Location = New System.Drawing.Point(146, 93)
        Me.txtInvStandard.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInvStandard.Name = "txtInvStandard"
        Me.txtInvStandard.Size = New System.Drawing.Size(279, 22)
        Me.txtInvStandard.TabIndex = 1212
        '
        'txtInvUOM
        '
        Me.txtInvUOM.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvUOM.Enabled = False
        Me.txtInvUOM.ForeColor = System.Drawing.Color.Black
        Me.txtInvUOM.Location = New System.Drawing.Point(146, 13)
        Me.txtInvUOM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInvUOM.Name = "txtInvUOM"
        Me.txtInvUOM.Size = New System.Drawing.Size(279, 22)
        Me.txtInvUOM.TabIndex = 1187
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(482, 39)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 16)
        Me.Label8.TabIndex = 1182
        Me.Label8.Text = "Maximum :"
        '
        'cbInvWarehouse
        '
        Me.cbInvWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInvWarehouse.DropDownWidth = 400
        Me.cbInvWarehouse.FormattingEnabled = True
        Me.cbInvWarehouse.Location = New System.Drawing.Point(146, 65)
        Me.cbInvWarehouse.Name = "cbInvWarehouse"
        Me.cbInvWarehouse.Size = New System.Drawing.Size(279, 24)
        Me.cbInvWarehouse.TabIndex = 1210
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(17, 69)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 16)
        Me.Label12.TabIndex = 1209
        Me.Label12.Text = "Default Warehouse :"
        '
        'txtInvMax
        '
        Me.txtInvMax.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvMax.ForeColor = System.Drawing.Color.Black
        Me.txtInvMax.Location = New System.Drawing.Point(559, 36)
        Me.txtInvMax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInvMax.Name = "txtInvMax"
        Me.txtInvMax.Size = New System.Drawing.Size(179, 22)
        Me.txtInvMax.TabIndex = 1181
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(486, 15)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 16)
        Me.Label7.TabIndex = 1180
        Me.Label7.Text = "Minimum :"
        '
        'txtInvMin
        '
        Me.txtInvMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvMin.ForeColor = System.Drawing.Color.Black
        Me.txtInvMin.Location = New System.Drawing.Point(559, 12)
        Me.txtInvMin.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInvMin.Name = "txtInvMin"
        Me.txtInvMin.Size = New System.Drawing.Size(179, 22)
        Me.txtInvMin.TabIndex = 1179
        '
        'cbInvMethod
        '
        Me.cbInvMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInvMethod.FormattingEnabled = True
        Me.cbInvMethod.Items.AddRange(New Object() {"Weighted Average Unit Cost"})
        Me.cbInvMethod.Location = New System.Drawing.Point(146, 38)
        Me.cbInvMethod.Name = "cbInvMethod"
        Me.cbInvMethod.Size = New System.Drawing.Size(279, 24)
        Me.cbInvMethod.TabIndex = 1178
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(33, 41)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 16)
        Me.Label6.TabIndex = 1177
        Me.Label6.Text = "Costing Method :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(33, 16)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 1175
        Me.Label5.Text = "Inventory UoM"
        '
        'txtInvAvailable
        '
        Me.txtInvAvailable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvAvailable.Location = New System.Drawing.Point(859, 384)
        Me.txtInvAvailable.Name = "txtInvAvailable"
        Me.txtInvAvailable.ReadOnly = True
        Me.txtInvAvailable.Size = New System.Drawing.Size(103, 22)
        Me.txtInvAvailable.TabIndex = 4
        Me.txtInvAvailable.TabStop = False
        '
        'txtInvCommit
        '
        Me.txtInvCommit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvCommit.Location = New System.Drawing.Point(759, 384)
        Me.txtInvCommit.Name = "txtInvCommit"
        Me.txtInvCommit.ReadOnly = True
        Me.txtInvCommit.Size = New System.Drawing.Size(101, 22)
        Me.txtInvCommit.TabIndex = 3
        Me.txtInvCommit.TabStop = False
        '
        'txtInvOrder
        '
        Me.txtInvOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvOrder.Location = New System.Drawing.Point(659, 384)
        Me.txtInvOrder.Name = "txtInvOrder"
        Me.txtInvOrder.ReadOnly = True
        Me.txtInvOrder.Size = New System.Drawing.Size(101, 22)
        Me.txtInvOrder.TabIndex = 2
        Me.txtInvOrder.TabStop = False
        '
        'txtInvStock
        '
        Me.txtInvStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvStock.Location = New System.Drawing.Point(559, 384)
        Me.txtInvStock.Name = "txtInvStock"
        Me.txtInvStock.ReadOnly = True
        Me.txtInvStock.Size = New System.Drawing.Size(101, 22)
        Me.txtInvStock.TabIndex = 1
        Me.txtInvStock.TabStop = False
        '
        'dgvInv
        '
        Me.dgvInv.AllowUserToAddRows = False
        Me.dgvInv.AllowUserToDeleteRows = False
        Me.dgvInv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInv.BackgroundColor = System.Drawing.Color.White
        Me.dgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chInvWHSECode, Me.chInvWHSEName, Me.chInvStock, Me.chInvOrdered, Me.chInvCommit, Me.chInvAvail})
        Me.dgvInv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvInv.Location = New System.Drawing.Point(12, 157)
        Me.dgvInv.Name = "dgvInv"
        Me.dgvInv.ReadOnly = True
        Me.dgvInv.RowHeadersWidth = 25
        Me.dgvInv.Size = New System.Drawing.Size(950, 227)
        Me.dgvInv.TabIndex = 0
        '
        'chInvWHSECode
        '
        Me.chInvWHSECode.HeaderText = "Code"
        Me.chInvWHSECode.Name = "chInvWHSECode"
        Me.chInvWHSECode.ReadOnly = True
        '
        'chInvWHSEName
        '
        Me.chInvWHSEName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.chInvWHSEName.HeaderText = "Warehouse Name"
        Me.chInvWHSEName.Name = "chInvWHSEName"
        Me.chInvWHSEName.ReadOnly = True
        '
        'chInvStock
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.chInvStock.DefaultCellStyle = DataGridViewCellStyle1
        Me.chInvStock.HeaderText = "In Stock"
        Me.chInvStock.Name = "chInvStock"
        Me.chInvStock.ReadOnly = True
        '
        'chInvOrdered
        '
        Me.chInvOrdered.HeaderText = "Ordered"
        Me.chInvOrdered.Name = "chInvOrdered"
        Me.chInvOrdered.ReadOnly = True
        '
        'chInvCommit
        '
        Me.chInvCommit.HeaderText = "Committed"
        Me.chInvCommit.Name = "chInvCommit"
        Me.chInvCommit.ReadOnly = True
        '
        'chInvAvail
        '
        Me.chInvAvail.HeaderText = "Available"
        Me.chInvAvail.Name = "chInvAvail"
        Me.chInvAvail.ReadOnly = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.Location = New System.Drawing.Point(535, 384)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(25, 23)
        Me.btnRefresh.TabIndex = 1211
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnInvUOM
        '
        Me.btnInvUOM.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnInvUOM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInvUOM.Location = New System.Drawing.Point(426, 12)
        Me.btnInvUOM.Name = "btnInvUOM"
        Me.btnInvUOM.Size = New System.Drawing.Size(25, 25)
        Me.btnInvUOM.TabIndex = 1188
        Me.btnInvUOM.UseVisualStyleBackColor = True
        '
        'tpMD
        '
        Me.tpMD.Controls.Add(Me.Label28)
        Me.tpMD.Controls.Add(Me.cbProdUOM)
        Me.tpMD.Controls.Add(Me.Label27)
        Me.tpMD.Controls.Add(Me.txtProdCode)
        Me.tpMD.Controls.Add(Me.Label22)
        Me.tpMD.Controls.Add(Me.txtProdQTY)
        Me.tpMD.Controls.Add(Me.Label21)
        Me.tpMD.Controls.Add(Me.txtProdName)
        Me.tpMD.Controls.Add(Me.btnProdRemove)
        Me.tpMD.Controls.Add(Me.btnProdAdd)
        Me.tpMD.Controls.Add(Me.dgvProdBOM)
        Me.tpMD.Location = New System.Drawing.Point(4, 25)
        Me.tpMD.Name = "tpMD"
        Me.tpMD.Size = New System.Drawing.Size(1058, 412)
        Me.tpMD.TabIndex = 4
        Me.tpMD.Text = "Production Data"
        Me.tpMD.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(206, 44)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(92, 16)
        Me.Label28.TabIndex = 1213
        Me.Label28.Text = "Raw Material :"
        '
        'cbProdUOM
        '
        Me.cbProdUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProdUOM.FormattingEnabled = True
        Me.cbProdUOM.Location = New System.Drawing.Point(307, 65)
        Me.cbProdUOM.Name = "cbProdUOM"
        Me.cbProdUOM.Size = New System.Drawing.Size(161, 24)
        Me.cbProdUOM.TabIndex = 1212
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(255, 69)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 16)
        Me.Label27.TabIndex = 1211
        Me.Label27.Text = "UoM :"
        '
        'txtProdCode
        '
        Me.txtProdCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtProdCode.Enabled = False
        Me.txtProdCode.ForeColor = System.Drawing.Color.Black
        Me.txtProdCode.Location = New System.Drawing.Point(307, 15)
        Me.txtProdCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProdCode.Name = "txtProdCode"
        Me.txtProdCode.Size = New System.Drawing.Size(161, 22)
        Me.txtProdCode.TabIndex = 1210
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(176, 94)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 16)
        Me.Label22.TabIndex = 1208
        Me.Label22.Text = "Consume Quantity :"
        '
        'txtProdQTY
        '
        Me.txtProdQTY.BackColor = System.Drawing.SystemColors.Window
        Me.txtProdQTY.ForeColor = System.Drawing.Color.Black
        Me.txtProdQTY.Location = New System.Drawing.Point(307, 92)
        Me.txtProdQTY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProdQTY.Name = "txtProdQTY"
        Me.txtProdQTY.Size = New System.Drawing.Size(161, 22)
        Me.txtProdQTY.TabIndex = 1207
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(251, 19)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 16)
        Me.Label21.TabIndex = 1206
        Me.Label21.Text = "Code :"
        '
        'txtProdName
        '
        Me.txtProdName.BackColor = System.Drawing.SystemColors.Window
        Me.txtProdName.ForeColor = System.Drawing.Color.Black
        Me.txtProdName.Location = New System.Drawing.Point(307, 40)
        Me.txtProdName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProdName.Name = "txtProdName"
        Me.txtProdName.Size = New System.Drawing.Size(400, 22)
        Me.txtProdName.TabIndex = 1205
        '
        'btnProdRemove
        '
        Me.btnProdRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnProdRemove.Enabled = False
        Me.btnProdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProdRemove.ForeColor = System.Drawing.Color.White
        Me.btnProdRemove.Location = New System.Drawing.Point(501, 94)
        Me.btnProdRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdRemove.Name = "btnProdRemove"
        Me.btnProdRemove.Size = New System.Drawing.Size(92, 27)
        Me.btnProdRemove.TabIndex = 1204
        Me.btnProdRemove.Text = "Remove"
        Me.btnProdRemove.UseVisualStyleBackColor = False
        '
        'btnProdAdd
        '
        Me.btnProdAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnProdAdd.Enabled = False
        Me.btnProdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProdAdd.ForeColor = System.Drawing.Color.White
        Me.btnProdAdd.Location = New System.Drawing.Point(501, 65)
        Me.btnProdAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProdAdd.Name = "btnProdAdd"
        Me.btnProdAdd.Size = New System.Drawing.Size(92, 27)
        Me.btnProdAdd.TabIndex = 1203
        Me.btnProdAdd.Text = "Add"
        Me.btnProdAdd.UseVisualStyleBackColor = False
        '
        'dgvProdBOM
        '
        Me.dgvProdBOM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProdBOM.BackgroundColor = System.Drawing.Color.White
        Me.dgvProdBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdBOM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chProdID, Me.DataGridViewTextBoxColumn1, Me.chBOMcode, Me.chBOMname, Me.chBOMuom, Me.chBOMqty})
        Me.dgvProdBOM.Location = New System.Drawing.Point(11, 130)
        Me.dgvProdBOM.Name = "dgvProdBOM"
        Me.dgvProdBOM.ReadOnly = True
        Me.dgvProdBOM.Size = New System.Drawing.Size(1044, 268)
        Me.dgvProdBOM.TabIndex = 1
        '
        'chProdID
        '
        Me.chProdID.HeaderText = "ID"
        Me.chProdID.Name = "chProdID"
        Me.chProdID.ReadOnly = True
        Me.chProdID.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 40
        '
        'chBOMcode
        '
        Me.chBOMcode.HeaderText = "Code"
        Me.chBOMcode.Name = "chBOMcode"
        Me.chBOMcode.ReadOnly = True
        Me.chBOMcode.Width = 150
        '
        'chBOMname
        '
        Me.chBOMname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.chBOMname.DefaultCellStyle = DataGridViewCellStyle2
        Me.chBOMname.HeaderText = "Material Name"
        Me.chBOMname.Name = "chBOMname"
        Me.chBOMname.ReadOnly = True
        '
        'chBOMuom
        '
        Me.chBOMuom.HeaderText = "UOM"
        Me.chBOMuom.Name = "chBOMuom"
        Me.chBOMuom.ReadOnly = True
        '
        'chBOMqty
        '
        Me.chBOMqty.HeaderText = "Consume Quantity"
        Me.chBOMqty.Name = "chBOMqty"
        Me.chBOMqty.ReadOnly = True
        Me.chBOMqty.Width = 150
        '
        'tpDefaultEntry
        '
        Me.tpDefaultEntry.BackColor = System.Drawing.Color.White
        Me.tpDefaultEntry.Controls.Add(Me.txtDiscAccntTitle)
        Me.tpDefaultEntry.Controls.Add(Me.txtDiscAccntCode)
        Me.tpDefaultEntry.Controls.Add(Me.Label29)
        Me.tpDefaultEntry.Controls.Add(Me.txtInvAccntTitle)
        Me.tpDefaultEntry.Controls.Add(Me.txtInvAccntCode)
        Me.tpDefaultEntry.Controls.Add(Me.Label19)
        Me.tpDefaultEntry.Controls.Add(Me.txtCostAccntTitle)
        Me.tpDefaultEntry.Controls.Add(Me.txtCostAccntCode)
        Me.tpDefaultEntry.Controls.Add(Me.Label9)
        Me.tpDefaultEntry.Controls.Add(Me.txtSaleAccntTitle)
        Me.tpDefaultEntry.Controls.Add(Me.txtSaleAccntCode)
        Me.tpDefaultEntry.Controls.Add(Me.Label14)
        Me.tpDefaultEntry.Location = New System.Drawing.Point(4, 25)
        Me.tpDefaultEntry.Name = "tpDefaultEntry"
        Me.tpDefaultEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDefaultEntry.Size = New System.Drawing.Size(1058, 412)
        Me.tpDefaultEntry.TabIndex = 5
        Me.tpDefaultEntry.Text = "Default Accounting Entry"
        '
        'txtDiscAccntTitle
        '
        Me.txtDiscAccntTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtDiscAccntTitle.ForeColor = System.Drawing.Color.Black
        Me.txtDiscAccntTitle.Location = New System.Drawing.Point(329, 90)
        Me.txtDiscAccntTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiscAccntTitle.Name = "txtDiscAccntTitle"
        Me.txtDiscAccntTitle.Size = New System.Drawing.Size(305, 22)
        Me.txtDiscAccntTitle.TabIndex = 1224
        '
        'txtDiscAccntCode
        '
        Me.txtDiscAccntCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtDiscAccntCode.Enabled = False
        Me.txtDiscAccntCode.ForeColor = System.Drawing.Color.Black
        Me.txtDiscAccntCode.Location = New System.Drawing.Point(217, 90)
        Me.txtDiscAccntCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiscAccntCode.Name = "txtDiscAccntCode"
        Me.txtDiscAccntCode.Size = New System.Drawing.Size(111, 22)
        Me.txtDiscAccntCode.TabIndex = 1225
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(26, 94)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(149, 16)
        Me.Label29.TabIndex = 1223
        Me.Label29.Text = "Default Sales Discount :"
        '
        'txtInvAccntTitle
        '
        Me.txtInvAccntTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvAccntTitle.ForeColor = System.Drawing.Color.Black
        Me.txtInvAccntTitle.Location = New System.Drawing.Point(329, 117)
        Me.txtInvAccntTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInvAccntTitle.Name = "txtInvAccntTitle"
        Me.txtInvAccntTitle.Size = New System.Drawing.Size(305, 22)
        Me.txtInvAccntTitle.TabIndex = 1221
        '
        'txtInvAccntCode
        '
        Me.txtInvAccntCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvAccntCode.Enabled = False
        Me.txtInvAccntCode.ForeColor = System.Drawing.Color.Black
        Me.txtInvAccntCode.Location = New System.Drawing.Point(217, 117)
        Me.txtInvAccntCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInvAccntCode.Name = "txtInvAccntCode"
        Me.txtInvAccntCode.Size = New System.Drawing.Size(111, 22)
        Me.txtInvAccntCode.TabIndex = 1222
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(26, 121)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(164, 16)
        Me.Label19.TabIndex = 1220
        Me.Label19.Text = "Default Inventory Account :"
        '
        'txtCostAccntTitle
        '
        Me.txtCostAccntTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtCostAccntTitle.ForeColor = System.Drawing.Color.Black
        Me.txtCostAccntTitle.Location = New System.Drawing.Point(329, 64)
        Me.txtCostAccntTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCostAccntTitle.Name = "txtCostAccntTitle"
        Me.txtCostAccntTitle.Size = New System.Drawing.Size(305, 22)
        Me.txtCostAccntTitle.TabIndex = 1218
        '
        'txtCostAccntCode
        '
        Me.txtCostAccntCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtCostAccntCode.Enabled = False
        Me.txtCostAccntCode.ForeColor = System.Drawing.Color.Black
        Me.txtCostAccntCode.Location = New System.Drawing.Point(217, 64)
        Me.txtCostAccntCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCostAccntCode.Name = "txtCostAccntCode"
        Me.txtCostAccntCode.Size = New System.Drawing.Size(111, 22)
        Me.txtCostAccntCode.TabIndex = 1219
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(26, 40)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 16)
        Me.Label9.TabIndex = 1217
        Me.Label9.Text = "Default Sales Account :"
        '
        'txtSaleAccntTitle
        '
        Me.txtSaleAccntTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtSaleAccntTitle.ForeColor = System.Drawing.Color.Black
        Me.txtSaleAccntTitle.Location = New System.Drawing.Point(329, 37)
        Me.txtSaleAccntTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaleAccntTitle.Name = "txtSaleAccntTitle"
        Me.txtSaleAccntTitle.Size = New System.Drawing.Size(305, 22)
        Me.txtSaleAccntTitle.TabIndex = 1215
        '
        'txtSaleAccntCode
        '
        Me.txtSaleAccntCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtSaleAccntCode.Enabled = False
        Me.txtSaleAccntCode.ForeColor = System.Drawing.Color.Black
        Me.txtSaleAccntCode.Location = New System.Drawing.Point(217, 37)
        Me.txtSaleAccntCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaleAccntCode.Name = "txtSaleAccntCode"
        Me.txtSaleAccntCode.Size = New System.Drawing.Size(111, 22)
        Me.txtSaleAccntCode.TabIndex = 1216
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(26, 67)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(189, 16)
        Me.Label14.TabIndex = 1214
        Me.Label14.Text = "Default Cost of Sales Account :"
        '
        'chkVATable
        '
        Me.chkVATable.AutoSize = True
        Me.chkVATable.Checked = True
        Me.chkVATable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVATable.Location = New System.Drawing.Point(451, 138)
        Me.chkVATable.Name = "chkVATable"
        Me.chkVATable.Size = New System.Drawing.Size(81, 20)
        Me.chkVATable.TabIndex = 1208
        Me.chkVATable.Text = "VATable"
        Me.chkVATable.UseVisualStyleBackColor = True
        '
        'chkInv
        '
        Me.chkInv.AutoSize = True
        Me.chkInv.Location = New System.Drawing.Point(711, 59)
        Me.chkInv.Name = "chkInv"
        Me.chkInv.Size = New System.Drawing.Size(109, 20)
        Me.chkInv.TabIndex = 1168
        Me.chkInv.Text = "Inventory Item"
        Me.chkInv.UseVisualStyleBackColor = True
        '
        'chkSale
        '
        Me.chkSale.AutoSize = True
        Me.chkSale.Location = New System.Drawing.Point(711, 79)
        Me.chkSale.Name = "chkSale"
        Me.chkSale.Size = New System.Drawing.Size(90, 20)
        Me.chkSale.TabIndex = 1169
        Me.chkSale.Text = "Sales Item"
        Me.chkSale.UseVisualStyleBackColor = True
        '
        'chkPurch
        '
        Me.chkPurch.AutoSize = True
        Me.chkPurch.Location = New System.Drawing.Point(711, 99)
        Me.chkPurch.Name = "chkPurch"
        Me.chkPurch.Size = New System.Drawing.Size(112, 20)
        Me.chkPurch.TabIndex = 1170
        Me.chkPurch.Text = "Purchase Item"
        Me.chkPurch.UseVisualStyleBackColor = True
        '
        'chkProd
        '
        Me.chkProd.AutoSize = True
        Me.chkProd.Location = New System.Drawing.Point(711, 119)
        Me.chkProd.Name = "chkProd"
        Me.chkProd.Size = New System.Drawing.Size(114, 20)
        Me.chkProd.TabIndex = 1171
        Me.chkProd.Text = "Produced Item"
        Me.chkProd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(37, 112)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 1173
        Me.Label2.Text = "Item type :"
        '
        'cbItemType
        '
        Me.cbItemType.FormattingEnabled = True
        Me.cbItemType.Location = New System.Drawing.Point(110, 107)
        Me.cbItemType.Name = "cbItemType"
        Me.cbItemType.Size = New System.Drawing.Size(137, 24)
        Me.cbItemType.TabIndex = 1174
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(254, 110)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 1175
        Me.Label3.Text = "Item Category :"
        '
        'cbItemCategory
        '
        Me.cbItemCategory.FormattingEnabled = True
        Me.cbItemCategory.Location = New System.Drawing.Point(358, 106)
        Me.cbItemCategory.Name = "cbItemCategory"
        Me.cbItemCategory.Size = New System.Drawing.Size(182, 24)
        Me.cbItemCategory.TabIndex = 1176
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(27, 192)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 16)
        Me.Label10.TabIndex = 1177
        Me.Label10.Text = "Base UoM :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(39, 219)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(66, 16)
        Me.Label25.TabIndex = 1181
        Me.Label25.Text = "Barcode :"
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.SystemColors.Window
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.Location = New System.Drawing.Point(110, 214)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(431, 22)
        Me.txtBarcode.TabIndex = 1180
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbPrevious, Me.tsbNext, Me.ToolStripSeparator2, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1091, 40)
        Me.ToolStrip1.TabIndex = 1185
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSearch
        '
        Me.tsbSearch.AutoSize = False
        Me.tsbSearch.ForeColor = System.Drawing.Color.White
        Me.tsbSearch.Image = Global.jade.My.Resources.Resources.view
        Me.tsbSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSearch.Name = "tsbSearch"
        Me.tsbSearch.Size = New System.Drawing.Size(50, 35)
        Me.tsbSearch.Text = "Search"
        Me.tsbSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbNew
        '
        Me.tsbNew.AutoSize = False
        Me.tsbNew.ForeColor = System.Drawing.Color.White
        Me.tsbNew.Image = Global.jade.My.Resources.Resources.circle_document_documents_extension_file_page_sheet_icon_7
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(50, 35)
        Me.tsbNew.Text = "New"
        Me.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbEdit
        '
        Me.tsbEdit.AutoSize = False
        Me.tsbEdit.ForeColor = System.Drawing.Color.White
        Me.tsbEdit.Image = Global.jade.My.Resources.Resources.edit_pen_write_notes_document_3c679c93cb5d1fed_512x512
        Me.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(50, 35)
        Me.tsbEdit.Text = "Edit"
        Me.tsbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbSave
        '
        Me.tsbSave.AutoSize = False
        Me.tsbSave.ForeColor = System.Drawing.Color.White
        Me.tsbSave.Image = Global.jade.My.Resources.Resources.Save_Icon
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(50, 35)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbDelete
        '
        Me.tsbDelete.AutoSize = False
        Me.tsbDelete.ForeColor = System.Drawing.Color.White
        Me.tsbDelete.Image = Global.jade.My.Resources.Resources.close_icon
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(50, 35)
        Me.tsbDelete.Text = "Delete"
        Me.tsbDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'tsbPrevious
        '
        Me.tsbPrevious.AutoSize = False
        Me.tsbPrevious.ForeColor = System.Drawing.Color.White
        Me.tsbPrevious.Image = Global.jade.My.Resources.Resources.arrows_147746_960_720
        Me.tsbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrevious.Name = "tsbPrevious"
        Me.tsbPrevious.Size = New System.Drawing.Size(50, 35)
        Me.tsbPrevious.Text = "Previous"
        Me.tsbPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbNext
        '
        Me.tsbNext.AutoSize = False
        Me.tsbNext.ForeColor = System.Drawing.Color.White
        Me.tsbNext.Image = Global.jade.My.Resources.Resources.red_arrow_png_15
        Me.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNext.Name = "tsbNext"
        Me.tsbNext.Size = New System.Drawing.Size(50, 35)
        Me.tsbNext.Text = "Next"
        Me.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'tsbClose
        '
        Me.tsbClose.AutoSize = False
        Me.tsbClose.ForeColor = System.Drawing.Color.White
        Me.tsbClose.Image = Global.jade.My.Resources.Resources.close_button_icon_transparent_background_247604
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(50, 35)
        Me.tsbClose.Text = "Close"
        Me.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbExit
        '
        Me.tsbExit.AutoSize = False
        Me.tsbExit.ForeColor = System.Drawing.Color.White
        Me.tsbExit.Image = Global.jade.My.Resources.Resources.exit_button_icon_18
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(50, 35)
        Me.tsbExit.Text = "Exit"
        Me.tsbExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cbUoMGroup
        '
        Me.cbUoMGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUoMGroup.FormattingEnabled = True
        Me.cbUoMGroup.Location = New System.Drawing.Point(110, 161)
        Me.cbUoMGroup.Name = "cbUoMGroup"
        Me.cbUoMGroup.Size = New System.Drawing.Size(210, 24)
        Me.cbUoMGroup.TabIndex = 1188
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(22, 164)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(83, 16)
        Me.Label26.TabIndex = 1187
        Me.Label26.Text = "UoM Group :"
        '
        'txtUOMBase
        '
        Me.txtUOMBase.BackColor = System.Drawing.SystemColors.Window
        Me.txtUOMBase.Enabled = False
        Me.txtUOMBase.ForeColor = System.Drawing.Color.Black
        Me.txtUOMBase.Location = New System.Drawing.Point(110, 189)
        Me.txtUOMBase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUOMBase.Name = "txtUOMBase"
        Me.txtUOMBase.Size = New System.Drawing.Size(210, 22)
        Me.txtUOMBase.TabIndex = 1186
        '
        'chkExcise
        '
        Me.chkExcise.AutoSize = True
        Me.chkExcise.Checked = True
        Me.chkExcise.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcise.Location = New System.Drawing.Point(451, 161)
        Me.chkExcise.Name = "chkExcise"
        Me.chkExcise.Size = New System.Drawing.Size(93, 20)
        Me.chkExcise.TabIndex = 1209
        Me.chkExcise.Text = "Excise Tax"
        Me.chkExcise.UseVisualStyleBackColor = True
        '
        'cbItemGroup
        '
        Me.cbItemGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbItemGroup.FormattingEnabled = True
        Me.cbItemGroup.Location = New System.Drawing.Point(110, 134)
        Me.cbItemGroup.Name = "cbItemGroup"
        Me.cbItemGroup.Size = New System.Drawing.Size(210, 24)
        Me.cbItemGroup.TabIndex = 1211
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(24, 138)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(79, 16)
        Me.Label31.TabIndex = 1210
        Me.Label31.Text = "Item Group :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbIDTolling)
        Me.GroupBox1.Controls.Add(Me.rbIDTolling)
        Me.GroupBox1.Controls.Add(Me.rbIDOwned)
        Me.GroupBox1.Location = New System.Drawing.Point(699, 145)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 102)
        Me.GroupBox1.TabIndex = 1214
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stock"
        Me.GroupBox1.Visible = False
        '
        'cbIDTolling
        '
        Me.cbIDTolling.FormattingEnabled = True
        Me.cbIDTolling.Location = New System.Drawing.Point(17, 66)
        Me.cbIDTolling.Name = "cbIDTolling"
        Me.cbIDTolling.Size = New System.Drawing.Size(294, 24)
        Me.cbIDTolling.TabIndex = 1175
        '
        'rbIDTolling
        '
        Me.rbIDTolling.AutoSize = True
        Me.rbIDTolling.Location = New System.Drawing.Point(17, 45)
        Me.rbIDTolling.Name = "rbIDTolling"
        Me.rbIDTolling.Size = New System.Drawing.Size(140, 20)
        Me.rbIDTolling.TabIndex = 1
        Me.rbIDTolling.Text = "Customer Supplied"
        Me.rbIDTolling.UseVisualStyleBackColor = True
        '
        'rbIDOwned
        '
        Me.rbIDOwned.AutoSize = True
        Me.rbIDOwned.Checked = True
        Me.rbIDOwned.Location = New System.Drawing.Point(17, 21)
        Me.rbIDOwned.Name = "rbIDOwned"
        Me.rbIDOwned.Size = New System.Drawing.Size(68, 20)
        Me.rbIDOwned.TabIndex = 0
        Me.rbIDOwned.TabStop = True
        Me.rbIDOwned.Text = "Owned"
        Me.rbIDOwned.UseVisualStyleBackColor = True
        '
        'btnUOMGroup
        '
        Me.btnUOMGroup.BackgroundImage = Global.jade.My.Resources.Resources._New
        Me.btnUOMGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUOMGroup.Location = New System.Drawing.Point(326, 161)
        Me.btnUOMGroup.Name = "btnUOMGroup"
        Me.btnUOMGroup.Size = New System.Drawing.Size(25, 25)
        Me.btnUOMGroup.TabIndex = 1189
        Me.btnUOMGroup.UseVisualStyleBackColor = True
        '
        'btnUOM
        '
        Me.btnUOM.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnUOM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUOM.Location = New System.Drawing.Point(326, 189)
        Me.btnUOM.Name = "btnUOM"
        Me.btnUOM.Size = New System.Drawing.Size(25, 25)
        Me.btnUOM.TabIndex = 1183
        Me.btnUOM.UseVisualStyleBackColor = True
        '
        'btnBOMgroup
        '
        Me.btnBOMgroup.BackgroundImage = Global.jade.My.Resources.Resources._New
        Me.btnBOMgroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBOMgroup.Location = New System.Drawing.Point(326, 133)
        Me.btnBOMgroup.Name = "btnBOMgroup"
        Me.btnBOMgroup.Size = New System.Drawing.Size(25, 25)
        Me.btnBOMgroup.TabIndex = 1215
        Me.btnBOMgroup.UseVisualStyleBackColor = True
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.SystemColors.Window
        Me.txtWeight.Enabled = False
        Me.txtWeight.ForeColor = System.Drawing.Color.Black
        Me.txtWeight.Location = New System.Drawing.Point(451, 190)
        Me.txtWeight.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(90, 22)
        Me.txtWeight.TabIndex = 1216
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(364, 193)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(85, 16)
        Me.Label32.TabIndex = 1217
        Me.Label32.Text = "Weight (KG) :"
        '
        'frmItem_Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1091, 691)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.btnBOMgroup)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbItemGroup)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.chkExcise)
        Me.Controls.Add(Me.btnUOMGroup)
        Me.Controls.Add(Me.cbUoMGroup)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtUOMBase)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.chkVATable)
        Me.Controls.Add(Me.btnUOM)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbItemCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbItemType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkProd)
        Me.Controls.Add(Me.chkPurch)
        Me.Controls.Add(Me.chkSale)
        Me.Controls.Add(Me.chkInv)
        Me.Controls.Add(Me.tcItemDetails)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmItem_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcItemDetails.ResumeLayout(False)
        Me.tpPD.ResumeLayout(False)
        Me.tpPD.PerformLayout()
        Me.tpSD.ResumeLayout(False)
        Me.gbSales.ResumeLayout(False)
        Me.gbSales.PerformLayout()
        CType(Me.dgvSell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpID.ResumeLayout(False)
        Me.tpID.PerformLayout()
        CType(Me.dgvInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMD.ResumeLayout(False)
        Me.tpMD.PerformLayout()
        CType(Me.dgvProdBOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDefaultEntry.ResumeLayout(False)
        Me.tpDefaultEntry.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents tcItemDetails As System.Windows.Forms.TabControl
    Friend WithEvents tpPD As System.Windows.Forms.TabPage
    Friend WithEvents tpID As System.Windows.Forms.TabPage
    Friend WithEvents chkInv As System.Windows.Forms.CheckBox
    Friend WithEvents chkSale As System.Windows.Forms.CheckBox
    Friend WithEvents chkPurch As System.Windows.Forms.CheckBox
    Friend WithEvents chkProd As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbItemType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbItemCategory As System.Windows.Forms.ComboBox
    Friend WithEvents dgvInv As System.Windows.Forms.DataGridView
    Friend WithEvents txtInvStock As System.Windows.Forms.TextBox
    Friend WithEvents txtInvCommit As System.Windows.Forms.TextBox
    Friend WithEvents txtInvOrder As System.Windows.Forms.TextBox
    Friend WithEvents txtInvAvailable As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInvMin As System.Windows.Forms.TextBox
    Friend WithEvents cbInvMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInvMax As System.Windows.Forms.TextBox
    Friend WithEvents chkPurchUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPurchVCECode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPurchVCEname As System.Windows.Forms.TextBox
    Friend WithEvents chkPurchVATInc As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPurchPrice As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSaleAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSaleAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tpMD As System.Windows.Forms.TabPage
    Friend WithEvents dgvProdBOM As System.Windows.Forms.DataGridView
    Friend WithEvents btnProdAdd As System.Windows.Forms.Button
    Friend WithEvents btnProdRemove As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtProdName As System.Windows.Forms.TextBox
    Friend WithEvents txtProdQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tpDefaultEntry As System.Windows.Forms.TabPage
    Friend WithEvents txtInvAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtInvAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCostAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtCostAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPurchReorder As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPurchMinimum As System.Windows.Forms.TextBox
    Friend WithEvents chkVATable As System.Windows.Forms.CheckBox
    Friend WithEvents cbInvWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents btnUOM As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPurchUOM As System.Windows.Forms.Button
    Friend WithEvents cbUoMGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnUOMGroup As System.Windows.Forms.Button
    Friend WithEvents txtUOMBase As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchUOM As System.Windows.Forms.TextBox
    Friend WithEvents btnPurchSupplier As System.Windows.Forms.Button
    Friend WithEvents tpSD As System.Windows.Forms.TabPage
    Friend WithEvents btnSellRemove As System.Windows.Forms.Button
    Friend WithEvents btnSellAdd As System.Windows.Forms.Button
    Friend WithEvents chkSellVAT As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSellQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSellUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbSellType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSell As System.Windows.Forms.DataGridView
    Friend WithEvents gbSales As System.Windows.Forms.GroupBox
    Friend WithEvents dcSell_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcSell_Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcSell_UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcSell_UOMQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcSell_VAT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkExcise As System.Windows.Forms.CheckBox
    Private WithEvents btnSellUOM As System.Windows.Forms.Button
    Friend WithEvents btnInvUOM As System.Windows.Forms.Button
    Friend WithEvents txtInvUOM As System.Windows.Forms.TextBox
    Friend WithEvents cbProdUOM As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtProdCode As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chProdID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBOMcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBOMname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBOMuom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBOMqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDiscAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtInvStandard As System.Windows.Forms.TextBox
    Friend WithEvents chInvWHSECode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chInvWHSEName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chInvStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chInvOrdered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chInvCommit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chInvAvail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSerial As System.Windows.Forms.CheckBox
    Friend WithEvents cbItemGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbIDTolling As System.Windows.Forms.ComboBox
    Friend WithEvents rbIDTolling As System.Windows.Forms.RadioButton
    Friend WithEvents rbIDOwned As System.Windows.Forms.RadioButton
    Friend WithEvents btnBOMgroup As System.Windows.Forms.Button
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
End Class
