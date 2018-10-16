<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Chart of Account")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transaction ID")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VCE Setup")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User Account")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tax Setup")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Branch Setup")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Business Type Setup")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintenance Group")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Purchasing")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventory")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.tcSettings = New System.Windows.Forms.TabControl()
        Me.tpUA = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nupUAminLen = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.attemptLock = New System.Windows.Forms.CheckBox()
        Me.tpCOA = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCOAFormat = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbCOAformat = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnCatDown = New System.Windows.Forms.Button()
        Me.btnCatUp = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lvType = New System.Windows.Forms.ListView()
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDigit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chOrder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkCOAauto = New System.Windows.Forms.CheckBox()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dgvTransDetailsAll = New System.Windows.Forms.DataGridView()
        Me.dgcTransAllType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransAllBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransAllBus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransAllPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransAlldigit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkTransAuto = New System.Windows.Forms.CheckBox()
        Me.chkGlobal = New System.Windows.Forms.CheckBox()
        Me.dgvTransDetail = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTransID = New System.Windows.Forms.DataGridView()
        Me.dgcTransType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransAuto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcTransGlobal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpVCE = New System.Windows.Forms.TabPage()
        Me.gbVCE = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.tpAPV = New System.Windows.Forms.TabPage()
        Me.gbAP = New System.Windows.Forms.GroupBox()
        Me.lbPurchases = New System.Windows.Forms.ListBox()
        Me.txtPendingAP = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbPayables = New System.Windows.Forms.ListBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAdvance = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.tpPurchase = New System.Windows.Forms.TabPage()
        Me.gbPO = New System.Windows.Forms.GroupBox()
        Me.chkPOapproval = New System.Windows.Forms.CheckBox()
        Me.gbPR = New System.Windows.Forms.GroupBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cbPRstock = New System.Windows.Forms.ComboBox()
        Me.tpTax = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.dgvVAT = New System.Windows.Forms.DataGridView()
        Me.dgcVatCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVatDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVatAlias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVatRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVatAccntCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVatAccntTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.dgvWTAX = New System.Windows.Forms.DataGridView()
        Me.dgcEwtCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEwtDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEwtAlias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEwtRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEwtAccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEwtAccntTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEwtATC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEwtNature = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpBranch = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.dgvBranch = New System.Windows.Forms.DataGridView()
        Me.dgcBranchOldCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBranchCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBranchName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBranchMain = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpBusiType = New System.Windows.Forms.TabPage()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.dgvBusType = New System.Windows.Forms.DataGridView()
        Me.dgcBusTypeOld = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBusType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBusTypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpMaintGroup = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gbProdWH = New System.Windows.Forms.GroupBox()
        Me.txtPWHG1 = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtPWHG5 = New System.Windows.Forms.TextBox()
        Me.txtPWHG2 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtPWHG4 = New System.Windows.Forms.TextBox()
        Me.txtPWHG3 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.gbPC = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPCG5 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPCG4 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtPCG3 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtPCG2 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPCG1 = New System.Windows.Forms.TextBox()
        Me.gbCC = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCCG5 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCCG4 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCCG3 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCCG2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCCG1 = New System.Windows.Forms.TextBox()
        Me.gbInvWH = New System.Windows.Forms.GroupBox()
        Me.txtWHG1 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtWHG5 = New System.Windows.Forms.TextBox()
        Me.txtWHG2 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtWHG4 = New System.Windows.Forms.TextBox()
        Me.txtWHG3 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tpSales = New System.Windows.Forms.TabPage()
        Me.gbSO = New System.Windows.Forms.GroupBox()
        Me.chkSOreqPO = New System.Windows.Forms.CheckBox()
        Me.chkSOeditPrice = New System.Windows.Forms.CheckBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tpInventory = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chkRR_RestrictWHSEItem = New System.Windows.Forms.CheckBox()
        Me.tcSettings.SuspendLayout()
        Me.tpUA.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nupUAminLen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCOA.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgvTransDetailsAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpVCE.SuspendLayout()
        Me.gbVCE.SuspendLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAPV.SuspendLayout()
        Me.gbAP.SuspendLayout()
        Me.tpPurchase.SuspendLayout()
        Me.gbPO.SuspendLayout()
        Me.gbPR.SuspendLayout()
        Me.tpTax.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.dgvVAT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgvWTAX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpBranch.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        CType(Me.dgvBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpBusiType.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.dgvBusType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMaintGroup.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gbProdWH.SuspendLayout()
        Me.gbPC.SuspendLayout()
        Me.gbCC.SuspendLayout()
        Me.gbInvWH.SuspendLayout()
        Me.tpSales.SuspendLayout()
        Me.gbSO.SuspendLayout()
        Me.tpInventory.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcSettings
        '
        Me.tcSettings.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tcSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcSettings.Controls.Add(Me.tpUA)
        Me.tcSettings.Controls.Add(Me.tpCOA)
        Me.tcSettings.Controls.Add(Me.tpGeneral)
        Me.tcSettings.Controls.Add(Me.tpVCE)
        Me.tcSettings.Controls.Add(Me.tpAPV)
        Me.tcSettings.Controls.Add(Me.tpPurchase)
        Me.tcSettings.Controls.Add(Me.tpTax)
        Me.tcSettings.Controls.Add(Me.tpBranch)
        Me.tcSettings.Controls.Add(Me.tpBusiType)
        Me.tcSettings.Controls.Add(Me.tpMaintGroup)
        Me.tcSettings.Controls.Add(Me.tpSales)
        Me.tcSettings.Controls.Add(Me.tpInventory)
        Me.tcSettings.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.tcSettings.ItemSize = New System.Drawing.Size(0, 1)
        Me.tcSettings.Location = New System.Drawing.Point(285, 12)
        Me.tcSettings.Multiline = True
        Me.tcSettings.Name = "tcSettings"
        Me.tcSettings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tcSettings.SelectedIndex = 0
        Me.tcSettings.Size = New System.Drawing.Size(794, 422)
        Me.tcSettings.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcSettings.TabIndex = 0
        '
        'tpUA
        '
        Me.tpUA.Controls.Add(Me.Panel1)
        Me.tpUA.Location = New System.Drawing.Point(5, 4)
        Me.tpUA.Name = "tpUA"
        Me.tpUA.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUA.Size = New System.Drawing.Size(785, 414)
        Me.tpUA.TabIndex = 0
        Me.tpUA.Text = "User Account"
        Me.tpUA.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(779, 408)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.CheckBox13)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(554, 73)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Registration"
        '
        'CheckBox13
        '
        Me.CheckBox13.AutoSize = True
        Me.CheckBox13.Location = New System.Drawing.Point(30, 27)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(193, 21)
        Me.CheckBox13.TabIndex = 0
        Me.CheckBox13.Text = "Allow user self-registration"
        Me.CheckBox13.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.CheckBox11)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.CheckBox10)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 358)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(554, 104)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Password Expiration"
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(122, 54)
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(42, 23)
        Me.NumericUpDown4.TabIndex = 6
        Me.NumericUpDown4.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(170, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "days prior to expiration"
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(50, 56)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(75, 21)
        Me.CheckBox11.TabIndex = 4
        Me.CheckBox11.Text = "Remind"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(160, 29)
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(42, 23)
        Me.NumericUpDown3.TabIndex = 3
        Me.NumericUpDown3.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Maximum Failed Login Attempts"
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(30, 31)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(146, 21)
        Me.CheckBox10.TabIndex = 0
        Me.CheckBox10.Text = "Expire Password in"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CheckBox9)
        Me.GroupBox2.Controls.Add(Me.CheckBox8)
        Me.GroupBox2.Controls.Add(Me.CheckBox7)
        Me.GroupBox2.Controls.Add(Me.CheckBox6)
        Me.GroupBox2.Controls.Add(Me.CheckBox5)
        Me.GroupBox2.Controls.Add(Me.CheckBox4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.nupUAminLen)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(554, 269)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Password Policy"
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(30, 21)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(182, 21)
        Me.CheckBox9.TabIndex = 14
        Me.CheckBox9.Text = "Enforce Password Policy"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(67, 238)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(268, 21)
        Me.CheckBox8.TabIndex = 13
        Me.CheckBox8.Text = "Username cannot be part of password"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(67, 217)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(456, 21)
        Me.CheckBox7.TabIndex = 12
        Me.CheckBox7.Text = "At least 1 special character in password  E.g.  !, @, #, $, %, ^, &&, *, _"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(67, 196)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(217, 21)
        Me.CheckBox6.TabIndex = 11
        Me.CheckBox6.Text = "At least 1 number in password"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(67, 175)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(232, 21)
        Me.CheckBox5.TabIndex = 10
        Me.CheckBox5.Text = "At least 1 lowercase in password"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(67, 154)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(236, 21)
        Me.CheckBox4.TabIndex = 9
        Me.CheckBox4.Text = "At least 1 uppercase in password"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(213, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Password Mandatory Characters"
        '
        'nupUAminLen
        '
        Me.nupUAminLen.Location = New System.Drawing.Point(50, 106)
        Me.nupUAminLen.Name = "nupUAminLen"
        Me.nupUAminLen.Size = New System.Drawing.Size(42, 23)
        Me.nupUAminLen.TabIndex = 7
        Me.nupUAminLen.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Password Minimum Length"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(50, 85)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(181, 21)
        Me.CheckBox3.TabIndex = 5
        Me.CheckBox3.Text = "Enable Forgot Password"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(50, 43)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(285, 21)
        Me.CheckBox2.TabIndex = 0
        Me.CheckBox2.Text = "Require Password Change on First Login"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(50, 64)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(209, 21)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Generate Random Password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.attemptLock)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 468)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account Locking"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(47, 53)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(42, 23)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Maximum Failed Login Attempts"
        '
        'attemptLock
        '
        Me.attemptLock.AutoSize = True
        Me.attemptLock.Location = New System.Drawing.Point(30, 31)
        Me.attemptLock.Name = "attemptLock"
        Me.attemptLock.Size = New System.Drawing.Size(168, 21)
        Me.attemptLock.TabIndex = 0
        Me.attemptLock.Text = "Account Lock Enabled"
        Me.attemptLock.UseVisualStyleBackColor = True
        '
        'tpCOA
        '
        Me.tpCOA.Controls.Add(Me.GroupBox6)
        Me.tpCOA.Location = New System.Drawing.Point(5, 4)
        Me.tpCOA.Name = "tpCOA"
        Me.tpCOA.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCOA.Size = New System.Drawing.Size(785, 414)
        Me.tpCOA.TabIndex = 1
        Me.tpCOA.Text = "Chart of Account"
        Me.tpCOA.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.txtCOAFormat)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.cbCOAformat)
        Me.GroupBox6.Controls.Add(Me.GroupBox5)
        Me.GroupBox6.Controls.Add(Me.chkCOAauto)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox6.Size = New System.Drawing.Size(761, 308)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Chart of Account Settings"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(291, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 17)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Desired Format"
        '
        'txtCOAFormat
        '
        Me.txtCOAFormat.Location = New System.Drawing.Point(402, 47)
        Me.txtCOAFormat.Name = "txtCOAFormat"
        Me.txtCOAFormat.Size = New System.Drawing.Size(100, 23)
        Me.txtCOAFormat.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Format Type "
        '
        'cbCOAformat
        '
        Me.cbCOAformat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCOAformat.FormattingEnabled = True
        Me.cbCOAformat.Items.AddRange(New Object() {"Auto Increment"})
        Me.cbCOAformat.Location = New System.Drawing.Point(125, 47)
        Me.cbCOAformat.Name = "cbCOAformat"
        Me.cbCOAformat.Size = New System.Drawing.Size(137, 24)
        Me.cbCOAformat.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.btnCatDown)
        Me.GroupBox5.Controls.Add(Me.btnCatUp)
        Me.GroupBox5.Controls.Add(Me.Button4)
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Controls.Add(Me.lvType)
        Me.GroupBox5.Location = New System.Drawing.Point(18, 73)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.Size = New System.Drawing.Size(726, 153)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Account Type"
        '
        'btnCatDown
        '
        Me.btnCatDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatDown.Location = New System.Drawing.Point(421, 48)
        Me.btnCatDown.Name = "btnCatDown"
        Me.btnCatDown.Size = New System.Drawing.Size(28, 27)
        Me.btnCatDown.TabIndex = 1354
        Me.btnCatDown.Text = "↓"
        Me.btnCatDown.UseVisualStyleBackColor = True
        '
        'btnCatUp
        '
        Me.btnCatUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatUp.Location = New System.Drawing.Point(421, 19)
        Me.btnCatUp.Name = "btnCatUp"
        Me.btnCatUp.Size = New System.Drawing.Size(28, 27)
        Me.btnCatUp.TabIndex = 1353
        Me.btnCatUp.Text = "↑"
        Me.btnCatUp.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button4.Location = New System.Drawing.Point(421, 109)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 30)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Remove"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button3.Location = New System.Drawing.Point(421, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Add"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lvType
        '
        Me.lvType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chType, Me.chDesc, Me.chDigit, Me.chOrder})
        Me.lvType.Location = New System.Drawing.Point(11, 19)
        Me.lvType.Name = "lvType"
        Me.lvType.Size = New System.Drawing.Size(405, 119)
        Me.lvType.TabIndex = 0
        Me.lvType.UseCompatibleStateImageBehavior = False
        Me.lvType.View = System.Windows.Forms.View.Details
        '
        'chType
        '
        Me.chType.Text = "Type"
        Me.chType.Width = 88
        '
        'chDesc
        '
        Me.chDesc.Text = "Description"
        Me.chDesc.Width = 221
        '
        'chDigit
        '
        Me.chDigit.Text = "Digit"
        Me.chDigit.Width = 90
        '
        'chOrder
        '
        Me.chOrder.Text = "Order"
        Me.chOrder.Width = 0
        '
        'chkCOAauto
        '
        Me.chkCOAauto.AutoSize = True
        Me.chkCOAauto.Location = New System.Drawing.Point(30, 27)
        Me.chkCOAauto.Name = "chkCOAauto"
        Me.chkCOAauto.Size = New System.Drawing.Size(266, 21)
        Me.chkCOAauto.TabIndex = 0
        Me.chkCOAauto.Text = "Generate Account Code Automatically"
        Me.chkCOAauto.UseVisualStyleBackColor = True
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.GroupBox7)
        Me.tpGeneral.Controls.Add(Me.dgvTransID)
        Me.tpGeneral.Location = New System.Drawing.Point(5, 4)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(785, 414)
        Me.tpGeneral.TabIndex = 2
        Me.tpGeneral.Text = "TabPage1"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.dgvTransDetailsAll)
        Me.GroupBox7.Controls.Add(Me.chkTransAuto)
        Me.GroupBox7.Controls.Add(Me.chkGlobal)
        Me.GroupBox7.Controls.Add(Me.dgvTransDetail)
        Me.GroupBox7.Location = New System.Drawing.Point(326, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(448, 350)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Transaction ID Details"
        '
        'dgvTransDetailsAll
        '
        Me.dgvTransDetailsAll.AllowUserToAddRows = False
        Me.dgvTransDetailsAll.AllowUserToDeleteRows = False
        Me.dgvTransDetailsAll.BackgroundColor = System.Drawing.Color.White
        Me.dgvTransDetailsAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransDetailsAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcTransAllType, Me.dgcTransAllBranch, Me.dgcTransAllBus, Me.dgcTransAllPrefix, Me.dgcTransAlldigit})
        Me.dgvTransDetailsAll.Location = New System.Drawing.Point(26, 71)
        Me.dgvTransDetailsAll.Name = "dgvTransDetailsAll"
        Me.dgvTransDetailsAll.RowHeadersVisible = False
        Me.dgvTransDetailsAll.Size = New System.Drawing.Size(396, 173)
        Me.dgvTransDetailsAll.TabIndex = 6
        Me.dgvTransDetailsAll.Visible = False
        '
        'dgcTransAllType
        '
        Me.dgcTransAllType.HeaderText = "Type"
        Me.dgcTransAllType.Name = "dgcTransAllType"
        Me.dgcTransAllType.Visible = False
        '
        'dgcTransAllBranch
        '
        Me.dgcTransAllBranch.HeaderText = "Branch"
        Me.dgcTransAllBranch.Name = "dgcTransAllBranch"
        '
        'dgcTransAllBus
        '
        Me.dgcTransAllBus.HeaderText = "Business Type"
        Me.dgcTransAllBus.Name = "dgcTransAllBus"
        Me.dgcTransAllBus.Width = 140
        '
        'dgcTransAllPrefix
        '
        Me.dgcTransAllPrefix.HeaderText = "Prefix"
        Me.dgcTransAllPrefix.Name = "dgcTransAllPrefix"
        Me.dgcTransAllPrefix.Width = 60
        '
        'dgcTransAlldigit
        '
        Me.dgcTransAlldigit.HeaderText = "Digits"
        Me.dgcTransAlldigit.Name = "dgcTransAlldigit"
        Me.dgcTransAlldigit.Width = 60
        '
        'chkTransAuto
        '
        Me.chkTransAuto.AutoSize = True
        Me.chkTransAuto.Location = New System.Drawing.Point(26, 27)
        Me.chkTransAuto.Name = "chkTransAuto"
        Me.chkTransAuto.Size = New System.Drawing.Size(270, 21)
        Me.chkTransAuto.TabIndex = 5
        Me.chkTransAuto.Text = "Generate Transaction ID Automatically"
        Me.chkTransAuto.UseVisualStyleBackColor = True
        '
        'chkGlobal
        '
        Me.chkGlobal.AutoSize = True
        Me.chkGlobal.Location = New System.Drawing.Point(26, 46)
        Me.chkGlobal.Name = "chkGlobal"
        Me.chkGlobal.Size = New System.Drawing.Size(112, 21)
        Me.chkGlobal.TabIndex = 2
        Me.chkGlobal.Text = "Global Series"
        Me.chkGlobal.UseVisualStyleBackColor = True
        '
        'dgvTransDetail
        '
        Me.dgvTransDetail.AllowUserToAddRows = False
        Me.dgvTransDetail.AllowUserToDeleteRows = False
        Me.dgvTransDetail.BackgroundColor = System.Drawing.Color.White
        Me.dgvTransDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvTransDetail.Location = New System.Drawing.Point(26, 71)
        Me.dgvTransDetail.Name = "dgvTransDetail"
        Me.dgvTransDetail.RowHeadersVisible = False
        Me.dgvTransDetail.Size = New System.Drawing.Size(396, 173)
        Me.dgvTransDetail.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Branch"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Business Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 140
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Prefix"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Digits"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'dgvTransID
        '
        Me.dgvTransID.AllowDrop = True
        Me.dgvTransID.AllowUserToAddRows = False
        Me.dgvTransID.AllowUserToDeleteRows = False
        Me.dgvTransID.AllowUserToOrderColumns = True
        Me.dgvTransID.AllowUserToResizeColumns = False
        Me.dgvTransID.AllowUserToResizeRows = False
        Me.dgvTransID.BackgroundColor = System.Drawing.Color.White
        Me.dgvTransID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransID.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcTransType, Me.dgcTransDesc, Me.dgcTransAuto, Me.dgcTransGlobal})
        Me.dgvTransID.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvTransID.Location = New System.Drawing.Point(6, 6)
        Me.dgvTransID.MultiSelect = False
        Me.dgvTransID.Name = "dgvTransID"
        Me.dgvTransID.RowHeadersVisible = False
        Me.dgvTransID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransID.Size = New System.Drawing.Size(314, 350)
        Me.dgvTransID.TabIndex = 0
        '
        'dgcTransType
        '
        Me.dgcTransType.HeaderText = "Type"
        Me.dgcTransType.Name = "dgcTransType"
        Me.dgcTransType.Width = 50
        '
        'dgcTransDesc
        '
        Me.dgcTransDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgcTransDesc.HeaderText = "Description"
        Me.dgcTransDesc.Name = "dgcTransDesc"
        '
        'dgcTransAuto
        '
        Me.dgcTransAuto.HeaderText = "Auto"
        Me.dgcTransAuto.Name = "dgcTransAuto"
        Me.dgcTransAuto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcTransAuto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcTransAuto.Visible = False
        '
        'dgcTransGlobal
        '
        Me.dgcTransGlobal.HeaderText = "Global"
        Me.dgcTransGlobal.Name = "dgcTransGlobal"
        Me.dgcTransGlobal.Visible = False
        '
        'tpVCE
        '
        Me.tpVCE.Controls.Add(Me.gbVCE)
        Me.tpVCE.Location = New System.Drawing.Point(5, 4)
        Me.tpVCE.Name = "tpVCE"
        Me.tpVCE.Padding = New System.Windows.Forms.Padding(3)
        Me.tpVCE.Size = New System.Drawing.Size(785, 414)
        Me.tpVCE.TabIndex = 3
        Me.tpVCE.Text = "VCE"
        Me.tpVCE.UseVisualStyleBackColor = True
        '
        'gbVCE
        '
        Me.gbVCE.BackColor = System.Drawing.Color.White
        Me.gbVCE.Controls.Add(Me.NumericUpDown5)
        Me.gbVCE.Controls.Add(Me.Label9)
        Me.gbVCE.Controls.Add(Me.Label8)
        Me.gbVCE.Controls.Add(Me.TextBox1)
        Me.gbVCE.Controls.Add(Me.CheckBox12)
        Me.gbVCE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbVCE.Location = New System.Drawing.Point(3, 3)
        Me.gbVCE.Margin = New System.Windows.Forms.Padding(0)
        Me.gbVCE.Name = "gbVCE"
        Me.gbVCE.Padding = New System.Windows.Forms.Padding(0)
        Me.gbVCE.Size = New System.Drawing.Size(779, 408)
        Me.gbVCE.TabIndex = 3
        Me.gbVCE.TabStop = False
        Me.gbVCE.Text = "VCE Settings"
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Location = New System.Drawing.Point(120, 52)
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(100, 23)
        Me.NumericUpDown5.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(66, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 17)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Digits :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(66, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Prefix :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(120, 75)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 23)
        Me.TextBox1.TabIndex = 4
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(30, 27)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(242, 21)
        Me.CheckBox12.TabIndex = 0
        Me.CheckBox12.Text = "Generate VCE Code Automatically"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'tpAPV
        '
        Me.tpAPV.Controls.Add(Me.gbAP)
        Me.tpAPV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.tpAPV.Location = New System.Drawing.Point(5, 4)
        Me.tpAPV.Name = "tpAPV"
        Me.tpAPV.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAPV.Size = New System.Drawing.Size(785, 414)
        Me.tpAPV.TabIndex = 4
        Me.tpAPV.Text = "TabPage1"
        Me.tpAPV.UseVisualStyleBackColor = True
        '
        'gbAP
        '
        Me.gbAP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAP.BackColor = System.Drawing.Color.White
        Me.gbAP.Controls.Add(Me.lbPurchases)
        Me.gbAP.Controls.Add(Me.txtPendingAP)
        Me.gbAP.Controls.Add(Me.Label15)
        Me.gbAP.Controls.Add(Me.lbPayables)
        Me.gbAP.Controls.Add(Me.Label14)
        Me.gbAP.Controls.Add(Me.Label13)
        Me.gbAP.Controls.Add(Me.TextBox4)
        Me.gbAP.Controls.Add(Me.Label12)
        Me.gbAP.Controls.Add(Me.txtAdvance)
        Me.gbAP.Controls.Add(Me.Label11)
        Me.gbAP.Controls.Add(Me.TextBox3)
        Me.gbAP.Controls.Add(Me.Label10)
        Me.gbAP.Controls.Add(Me.Button6)
        Me.gbAP.Controls.Add(Me.Button7)
        Me.gbAP.Location = New System.Drawing.Point(3, 12)
        Me.gbAP.Margin = New System.Windows.Forms.Padding(0)
        Me.gbAP.Name = "gbAP"
        Me.gbAP.Padding = New System.Windows.Forms.Padding(0)
        Me.gbAP.Size = New System.Drawing.Size(767, 399)
        Me.gbAP.TabIndex = 3
        Me.gbAP.TabStop = False
        Me.gbAP.Text = "Default Entries"
        '
        'lbPurchases
        '
        Me.lbPurchases.FormattingEnabled = True
        Me.lbPurchases.ItemHeight = 15
        Me.lbPurchases.Location = New System.Drawing.Point(286, 27)
        Me.lbPurchases.Name = "lbPurchases"
        Me.lbPurchases.Size = New System.Drawing.Size(338, 79)
        Me.lbPurchases.TabIndex = 19
        '
        'txtPendingAP
        '
        Me.txtPendingAP.Location = New System.Drawing.Point(286, 127)
        Me.txtPendingAP.Name = "txtPendingAP"
        Me.txtPendingAP.Size = New System.Drawing.Size(338, 21)
        Me.txtPendingAP.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(102, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(178, 15)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Liability Account for Pending AP"
        '
        'lbPayables
        '
        Me.lbPayables.FormattingEnabled = True
        Me.lbPayables.ItemHeight = 15
        Me.lbPayables.Location = New System.Drawing.Point(286, 211)
        Me.lbPayables.Name = "lbPayables"
        Me.lbPayables.Size = New System.Drawing.Size(338, 79)
        Me.lbPayables.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(60, 211)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(220, 15)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Liability Account for Tracking Payables :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(237, 15)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Asset or Expense Accounts for Purchases :"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(286, 181)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(338, 21)
        Me.TextBox4.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(99, 184)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(181, 15)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Expense Account for Discounts :"
        '
        'txtAdvance
        '
        Me.txtAdvance.Location = New System.Drawing.Point(286, 154)
        Me.txtAdvance.Name = "txtAdvance"
        Me.txtAdvance.Size = New System.Drawing.Size(338, 21)
        Me.txtAdvance.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(52, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(228, 15)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Asset Account for Advances to Suppliers :"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(286, 310)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(338, 21)
        Me.TextBox3.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(121, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 15)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Asset Account for Input VAT :"
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button6.Location = New System.Drawing.Point(628, 58)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 30)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Remove"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button7.Location = New System.Drawing.Point(628, 26)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 30)
        Me.Button7.TabIndex = 3
        Me.Button7.Text = "Add"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'tpPurchase
        '
        Me.tpPurchase.Controls.Add(Me.gbPO)
        Me.tpPurchase.Controls.Add(Me.gbPR)
        Me.tpPurchase.Location = New System.Drawing.Point(5, 4)
        Me.tpPurchase.Name = "tpPurchase"
        Me.tpPurchase.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPurchase.Size = New System.Drawing.Size(785, 414)
        Me.tpPurchase.TabIndex = 5
        Me.tpPurchase.Text = "TabPage1"
        Me.tpPurchase.UseVisualStyleBackColor = True
        '
        'gbPO
        '
        Me.gbPO.Controls.Add(Me.chkPOapproval)
        Me.gbPO.Location = New System.Drawing.Point(6, 139)
        Me.gbPO.Name = "gbPO"
        Me.gbPO.Size = New System.Drawing.Size(773, 136)
        Me.gbPO.TabIndex = 2
        Me.gbPO.TabStop = False
        Me.gbPO.Text = "Purchase Order (PO)"
        '
        'chkPOapproval
        '
        Me.chkPOapproval.AutoSize = True
        Me.chkPOapproval.Location = New System.Drawing.Point(37, 34)
        Me.chkPOapproval.Name = "chkPOapproval"
        Me.chkPOapproval.Size = New System.Drawing.Size(161, 21)
        Me.chkPOapproval.TabIndex = 0
        Me.chkPOapproval.Text = "Require PO Approval"
        Me.chkPOapproval.UseVisualStyleBackColor = True
        '
        'gbPR
        '
        Me.gbPR.Controls.Add(Me.Label36)
        Me.gbPR.Controls.Add(Me.cbPRstock)
        Me.gbPR.Location = New System.Drawing.Point(6, 3)
        Me.gbPR.Name = "gbPR"
        Me.gbPR.Size = New System.Drawing.Size(773, 136)
        Me.gbPR.TabIndex = 1
        Me.gbPR.TabStop = False
        Me.gbPR.Text = "Purchase Requisition (PR)"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(34, 31)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(151, 17)
        Me.Label36.TabIndex = 1
        Me.Label36.Text = "Check Stock Level by :"
        '
        'cbPRstock
        '
        Me.cbPRstock.FormattingEnabled = True
        Me.cbPRstock.Location = New System.Drawing.Point(191, 28)
        Me.cbPRstock.Name = "cbPRstock"
        Me.cbPRstock.Size = New System.Drawing.Size(261, 24)
        Me.cbPRstock.TabIndex = 0
        '
        'tpTax
        '
        Me.tpTax.Controls.Add(Me.GroupBox11)
        Me.tpTax.Controls.Add(Me.GroupBox10)
        Me.tpTax.Location = New System.Drawing.Point(5, 4)
        Me.tpTax.Name = "tpTax"
        Me.tpTax.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTax.Size = New System.Drawing.Size(785, 414)
        Me.tpTax.TabIndex = 6
        Me.tpTax.Text = "Tax"
        Me.tpTax.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.dgvVAT)
        Me.GroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox11.Location = New System.Drawing.Point(3, 234)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(778, 174)
        Me.GroupBox11.TabIndex = 4
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "VAT"
        '
        'dgvVAT
        '
        Me.dgvVAT.BackgroundColor = System.Drawing.Color.White
        Me.dgvVAT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVAT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcVatCode, Me.dgcVatDesc, Me.dgcVatAlias, Me.dgcVatRate, Me.dgcVatAccntCode, Me.dgcVatAccntTitle})
        Me.dgvVAT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVAT.Location = New System.Drawing.Point(3, 17)
        Me.dgvVAT.Name = "dgvVAT"
        Me.dgvVAT.RowHeadersWidth = 25
        Me.dgvVAT.Size = New System.Drawing.Size(772, 154)
        Me.dgvVAT.TabIndex = 2
        '
        'dgcVatCode
        '
        Me.dgcVatCode.HeaderText = "Code"
        Me.dgcVatCode.Name = "dgcVatCode"
        Me.dgcVatCode.Width = 50
        '
        'dgcVatDesc
        '
        Me.dgcVatDesc.HeaderText = "Description"
        Me.dgcVatDesc.Name = "dgcVatDesc"
        Me.dgcVatDesc.Width = 180
        '
        'dgcVatAlias
        '
        Me.dgcVatAlias.HeaderText = "Alias"
        Me.dgcVatAlias.Name = "dgcVatAlias"
        Me.dgcVatAlias.Width = 70
        '
        'dgcVatRate
        '
        Me.dgcVatRate.HeaderText = "Rate"
        Me.dgcVatRate.Name = "dgcVatRate"
        Me.dgcVatRate.Width = 50
        '
        'dgcVatAccntCode
        '
        Me.dgcVatAccntCode.HeaderText = "Account Code"
        Me.dgcVatAccntCode.Name = "dgcVatAccntCode"
        Me.dgcVatAccntCode.Visible = False
        '
        'dgcVatAccntTitle
        '
        Me.dgcVatAccntTitle.HeaderText = "Default Entry"
        Me.dgcVatAccntTitle.Name = "dgcVatAccntTitle"
        Me.dgcVatAccntTitle.Width = 200
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.dgvWTAX)
        Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(778, 222)
        Me.GroupBox10.TabIndex = 3
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Witholding Tax"
        '
        'dgvWTAX
        '
        Me.dgvWTAX.BackgroundColor = System.Drawing.Color.White
        Me.dgvWTAX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWTAX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcEwtCode, Me.dgcEwtDesc, Me.dgcEwtAlias, Me.dgcEwtRate, Me.dgcEwtAccountCode, Me.dgcEwtAccntTitle, Me.dgcEwtATC, Me.dgcEwtNature})
        Me.dgvWTAX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWTAX.Location = New System.Drawing.Point(3, 17)
        Me.dgvWTAX.Name = "dgvWTAX"
        Me.dgvWTAX.RowHeadersWidth = 25
        Me.dgvWTAX.Size = New System.Drawing.Size(772, 202)
        Me.dgvWTAX.TabIndex = 2
        '
        'dgcEwtCode
        '
        Me.dgcEwtCode.HeaderText = "Code"
        Me.dgcEwtCode.Name = "dgcEwtCode"
        Me.dgcEwtCode.Width = 50
        '
        'dgcEwtDesc
        '
        Me.dgcEwtDesc.HeaderText = "Description"
        Me.dgcEwtDesc.Name = "dgcEwtDesc"
        Me.dgcEwtDesc.Width = 180
        '
        'dgcEwtAlias
        '
        Me.dgcEwtAlias.HeaderText = "Alias"
        Me.dgcEwtAlias.Name = "dgcEwtAlias"
        Me.dgcEwtAlias.Width = 70
        '
        'dgcEwtRate
        '
        Me.dgcEwtRate.HeaderText = "Rate"
        Me.dgcEwtRate.Name = "dgcEwtRate"
        Me.dgcEwtRate.Width = 50
        '
        'dgcEwtAccountCode
        '
        Me.dgcEwtAccountCode.HeaderText = "Account Code"
        Me.dgcEwtAccountCode.Name = "dgcEwtAccountCode"
        Me.dgcEwtAccountCode.Visible = False
        '
        'dgcEwtAccntTitle
        '
        Me.dgcEwtAccntTitle.HeaderText = "Default Entry"
        Me.dgcEwtAccntTitle.Name = "dgcEwtAccntTitle"
        Me.dgcEwtAccntTitle.Width = 190
        '
        'dgcEwtATC
        '
        Me.dgcEwtATC.HeaderText = "ATC"
        Me.dgcEwtATC.Name = "dgcEwtATC"
        '
        'dgcEwtNature
        '
        Me.dgcEwtNature.HeaderText = "Nature of Income"
        Me.dgcEwtNature.Name = "dgcEwtNature"
        Me.dgcEwtNature.Width = 120
        '
        'tpBranch
        '
        Me.tpBranch.Controls.Add(Me.GroupBox13)
        Me.tpBranch.Location = New System.Drawing.Point(5, 4)
        Me.tpBranch.Name = "tpBranch"
        Me.tpBranch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBranch.Size = New System.Drawing.Size(785, 414)
        Me.tpBranch.TabIndex = 7
        Me.tpBranch.Text = "Branch"
        Me.tpBranch.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox13.Controls.Add(Me.dgvBranch)
        Me.GroupBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(773, 405)
        Me.GroupBox13.TabIndex = 2
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Branches"
        '
        'dgvBranch
        '
        Me.dgvBranch.AllowDrop = True
        Me.dgvBranch.AllowUserToOrderColumns = True
        Me.dgvBranch.AllowUserToResizeColumns = False
        Me.dgvBranch.AllowUserToResizeRows = False
        Me.dgvBranch.BackgroundColor = System.Drawing.Color.White
        Me.dgvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBranch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcBranchOldCode, Me.dgcBranchCode, Me.dgcBranchName, Me.dgcBranchMain})
        Me.dgvBranch.Location = New System.Drawing.Point(6, 21)
        Me.dgvBranch.MultiSelect = False
        Me.dgvBranch.Name = "dgvBranch"
        Me.dgvBranch.RowHeadersWidth = 25
        Me.dgvBranch.Size = New System.Drawing.Size(355, 381)
        Me.dgvBranch.TabIndex = 1
        '
        'dgcBranchOldCode
        '
        Me.dgcBranchOldCode.HeaderText = "OldCode"
        Me.dgcBranchOldCode.Name = "dgcBranchOldCode"
        Me.dgcBranchOldCode.Visible = False
        '
        'dgcBranchCode
        '
        Me.dgcBranchCode.HeaderText = "Code"
        Me.dgcBranchCode.Name = "dgcBranchCode"
        Me.dgcBranchCode.Width = 80
        '
        'dgcBranchName
        '
        Me.dgcBranchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgcBranchName.HeaderText = "Description"
        Me.dgcBranchName.Name = "dgcBranchName"
        '
        'dgcBranchMain
        '
        Me.dgcBranchMain.HeaderText = "Default"
        Me.dgcBranchMain.Name = "dgcBranchMain"
        Me.dgcBranchMain.Width = 55
        '
        'tpBusiType
        '
        Me.tpBusiType.Controls.Add(Me.GroupBox12)
        Me.tpBusiType.Location = New System.Drawing.Point(5, 4)
        Me.tpBusiType.Name = "tpBusiType"
        Me.tpBusiType.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBusiType.Size = New System.Drawing.Size(785, 414)
        Me.tpBusiType.TabIndex = 8
        Me.tpBusiType.Text = "TabPage1"
        Me.tpBusiType.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox12.Controls.Add(Me.dgvBusType)
        Me.GroupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox12.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(773, 402)
        Me.GroupBox12.TabIndex = 3
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Business Type"
        '
        'dgvBusType
        '
        Me.dgvBusType.AllowDrop = True
        Me.dgvBusType.AllowUserToOrderColumns = True
        Me.dgvBusType.AllowUserToResizeColumns = False
        Me.dgvBusType.AllowUserToResizeRows = False
        Me.dgvBusType.BackgroundColor = System.Drawing.Color.White
        Me.dgvBusType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcBusTypeOld, Me.dgcBusType, Me.dgcBusTypeDesc})
        Me.dgvBusType.Location = New System.Drawing.Point(6, 21)
        Me.dgvBusType.MultiSelect = False
        Me.dgvBusType.Name = "dgvBusType"
        Me.dgvBusType.RowHeadersWidth = 25
        Me.dgvBusType.Size = New System.Drawing.Size(355, 374)
        Me.dgvBusType.TabIndex = 2
        '
        'dgcBusTypeOld
        '
        Me.dgcBusTypeOld.HeaderText = "OldCode"
        Me.dgcBusTypeOld.Name = "dgcBusTypeOld"
        Me.dgcBusTypeOld.Visible = False
        '
        'dgcBusType
        '
        Me.dgcBusType.HeaderText = "Code"
        Me.dgcBusType.Name = "dgcBusType"
        Me.dgcBusType.Width = 80
        '
        'dgcBusTypeDesc
        '
        Me.dgcBusTypeDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgcBusTypeDesc.HeaderText = "Description"
        Me.dgcBusTypeDesc.Name = "dgcBusTypeDesc"
        '
        'tpMaintGroup
        '
        Me.tpMaintGroup.Controls.Add(Me.Panel2)
        Me.tpMaintGroup.Location = New System.Drawing.Point(5, 4)
        Me.tpMaintGroup.Name = "tpMaintGroup"
        Me.tpMaintGroup.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMaintGroup.Size = New System.Drawing.Size(785, 414)
        Me.tpMaintGroup.TabIndex = 9
        Me.tpMaintGroup.Text = "TabPage1"
        Me.tpMaintGroup.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.gbProdWH)
        Me.Panel2.Controls.Add(Me.gbPC)
        Me.Panel2.Controls.Add(Me.gbCC)
        Me.Panel2.Controls.Add(Me.gbInvWH)
        Me.Panel2.Location = New System.Drawing.Point(3, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(776, 402)
        Me.Panel2.TabIndex = 20
        '
        'gbProdWH
        '
        Me.gbProdWH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProdWH.Controls.Add(Me.txtPWHG1)
        Me.gbProdWH.Controls.Add(Me.Label31)
        Me.gbProdWH.Controls.Add(Me.Label32)
        Me.gbProdWH.Controls.Add(Me.txtPWHG5)
        Me.gbProdWH.Controls.Add(Me.txtPWHG2)
        Me.gbProdWH.Controls.Add(Me.Label33)
        Me.gbProdWH.Controls.Add(Me.Label34)
        Me.gbProdWH.Controls.Add(Me.txtPWHG4)
        Me.gbProdWH.Controls.Add(Me.txtPWHG3)
        Me.gbProdWH.Controls.Add(Me.Label35)
        Me.gbProdWH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.gbProdWH.Location = New System.Drawing.Point(9, 493)
        Me.gbProdWH.Name = "gbProdWH"
        Me.gbProdWH.Size = New System.Drawing.Size(610, 158)
        Me.gbProdWH.TabIndex = 22
        Me.gbProdWH.TabStop = False
        Me.gbProdWH.Text = "Production Warehouse Group"
        '
        'txtPWHG1
        '
        Me.txtPWHG1.Location = New System.Drawing.Point(104, 25)
        Me.txtPWHG1.Name = "txtPWHG1"
        Me.txtPWHG1.Size = New System.Drawing.Size(258, 22)
        Me.txtPWHG1.TabIndex = 10
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(41, 128)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 16)
        Me.Label31.TabIndex = 19
        Me.Label31.Text = "Group 5 :"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(41, 28)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(61, 16)
        Me.Label32.TabIndex = 11
        Me.Label32.Text = "Group 1 :"
        '
        'txtPWHG5
        '
        Me.txtPWHG5.Location = New System.Drawing.Point(104, 125)
        Me.txtPWHG5.Name = "txtPWHG5"
        Me.txtPWHG5.Size = New System.Drawing.Size(258, 22)
        Me.txtPWHG5.TabIndex = 18
        '
        'txtPWHG2
        '
        Me.txtPWHG2.Location = New System.Drawing.Point(104, 50)
        Me.txtPWHG2.Name = "txtPWHG2"
        Me.txtPWHG2.Size = New System.Drawing.Size(258, 22)
        Me.txtPWHG2.TabIndex = 12
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(41, 103)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(61, 16)
        Me.Label33.TabIndex = 17
        Me.Label33.Text = "Group 4 :"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(41, 53)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(61, 16)
        Me.Label34.TabIndex = 13
        Me.Label34.Text = "Group 2 :"
        '
        'txtPWHG4
        '
        Me.txtPWHG4.Location = New System.Drawing.Point(104, 100)
        Me.txtPWHG4.Name = "txtPWHG4"
        Me.txtPWHG4.Size = New System.Drawing.Size(258, 22)
        Me.txtPWHG4.TabIndex = 16
        '
        'txtPWHG3
        '
        Me.txtPWHG3.Location = New System.Drawing.Point(104, 75)
        Me.txtPWHG3.Name = "txtPWHG3"
        Me.txtPWHG3.Size = New System.Drawing.Size(258, 22)
        Me.txtPWHG3.TabIndex = 14
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(41, 78)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(61, 16)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Group 3 :"
        '
        'gbPC
        '
        Me.gbPC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPC.Controls.Add(Me.Label26)
        Me.gbPC.Controls.Add(Me.txtPCG5)
        Me.gbPC.Controls.Add(Me.Label27)
        Me.gbPC.Controls.Add(Me.txtPCG4)
        Me.gbPC.Controls.Add(Me.Label28)
        Me.gbPC.Controls.Add(Me.txtPCG3)
        Me.gbPC.Controls.Add(Me.Label29)
        Me.gbPC.Controls.Add(Me.txtPCG2)
        Me.gbPC.Controls.Add(Me.Label30)
        Me.gbPC.Controls.Add(Me.txtPCG1)
        Me.gbPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPC.Location = New System.Drawing.Point(9, 161)
        Me.gbPC.Name = "gbPC"
        Me.gbPC.Size = New System.Drawing.Size(610, 158)
        Me.gbPC.TabIndex = 21
        Me.gbPC.TabStop = False
        Me.gbPC.Text = "Profit Center Group"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(42, 126)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(61, 16)
        Me.Label26.TabIndex = 9
        Me.Label26.Text = "Group 5 :"
        '
        'txtPCG5
        '
        Me.txtPCG5.Location = New System.Drawing.Point(104, 123)
        Me.txtPCG5.Name = "txtPCG5"
        Me.txtPCG5.Size = New System.Drawing.Size(258, 22)
        Me.txtPCG5.TabIndex = 8
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(42, 101)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(61, 16)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Group 4 :"
        '
        'txtPCG4
        '
        Me.txtPCG4.Location = New System.Drawing.Point(104, 98)
        Me.txtPCG4.Name = "txtPCG4"
        Me.txtPCG4.Size = New System.Drawing.Size(258, 22)
        Me.txtPCG4.TabIndex = 6
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(42, 76)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 16)
        Me.Label28.TabIndex = 5
        Me.Label28.Text = "Group 3 :"
        '
        'txtPCG3
        '
        Me.txtPCG3.Location = New System.Drawing.Point(104, 73)
        Me.txtPCG3.Name = "txtPCG3"
        Me.txtPCG3.Size = New System.Drawing.Size(258, 22)
        Me.txtPCG3.TabIndex = 4
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(42, 51)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(61, 16)
        Me.Label29.TabIndex = 3
        Me.Label29.Text = "Group 2 :"
        '
        'txtPCG2
        '
        Me.txtPCG2.Location = New System.Drawing.Point(104, 48)
        Me.txtPCG2.Name = "txtPCG2"
        Me.txtPCG2.Size = New System.Drawing.Size(258, 22)
        Me.txtPCG2.TabIndex = 2
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(42, 26)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 16)
        Me.Label30.TabIndex = 1
        Me.Label30.Text = "Group 1 :"
        '
        'txtPCG1
        '
        Me.txtPCG1.Location = New System.Drawing.Point(104, 23)
        Me.txtPCG1.Name = "txtPCG1"
        Me.txtPCG1.Size = New System.Drawing.Size(258, 22)
        Me.txtPCG1.TabIndex = 0
        '
        'gbCC
        '
        Me.gbCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCC.Controls.Add(Me.Label20)
        Me.gbCC.Controls.Add(Me.txtCCG5)
        Me.gbCC.Controls.Add(Me.Label19)
        Me.gbCC.Controls.Add(Me.txtCCG4)
        Me.gbCC.Controls.Add(Me.Label18)
        Me.gbCC.Controls.Add(Me.txtCCG3)
        Me.gbCC.Controls.Add(Me.Label17)
        Me.gbCC.Controls.Add(Me.txtCCG2)
        Me.gbCC.Controls.Add(Me.Label16)
        Me.gbCC.Controls.Add(Me.txtCCG1)
        Me.gbCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCC.Location = New System.Drawing.Point(9, 5)
        Me.gbCC.Name = "gbCC"
        Me.gbCC.Size = New System.Drawing.Size(610, 154)
        Me.gbCC.TabIndex = 4
        Me.gbCC.TabStop = False
        Me.gbCC.Text = "Cost Center Group"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(42, 123)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 16)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Group 5 :"
        '
        'txtCCG5
        '
        Me.txtCCG5.Location = New System.Drawing.Point(104, 120)
        Me.txtCCG5.Name = "txtCCG5"
        Me.txtCCG5.Size = New System.Drawing.Size(258, 22)
        Me.txtCCG5.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(42, 98)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 16)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Group 4 :"
        '
        'txtCCG4
        '
        Me.txtCCG4.Location = New System.Drawing.Point(104, 95)
        Me.txtCCG4.Name = "txtCCG4"
        Me.txtCCG4.Size = New System.Drawing.Size(258, 22)
        Me.txtCCG4.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(42, 73)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 16)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Group 3 :"
        '
        'txtCCG3
        '
        Me.txtCCG3.Location = New System.Drawing.Point(104, 70)
        Me.txtCCG3.Name = "txtCCG3"
        Me.txtCCG3.Size = New System.Drawing.Size(258, 22)
        Me.txtCCG3.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(42, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 16)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Group 2 :"
        '
        'txtCCG2
        '
        Me.txtCCG2.Location = New System.Drawing.Point(104, 45)
        Me.txtCCG2.Name = "txtCCG2"
        Me.txtCCG2.Size = New System.Drawing.Size(258, 22)
        Me.txtCCG2.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(42, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 16)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Group 1 :"
        '
        'txtCCG1
        '
        Me.txtCCG1.Location = New System.Drawing.Point(104, 20)
        Me.txtCCG1.Name = "txtCCG1"
        Me.txtCCG1.Size = New System.Drawing.Size(258, 22)
        Me.txtCCG1.TabIndex = 0
        '
        'gbInvWH
        '
        Me.gbInvWH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbInvWH.Controls.Add(Me.txtWHG1)
        Me.gbInvWH.Controls.Add(Me.Label21)
        Me.gbInvWH.Controls.Add(Me.Label25)
        Me.gbInvWH.Controls.Add(Me.txtWHG5)
        Me.gbInvWH.Controls.Add(Me.txtWHG2)
        Me.gbInvWH.Controls.Add(Me.Label22)
        Me.gbInvWH.Controls.Add(Me.Label24)
        Me.gbInvWH.Controls.Add(Me.txtWHG4)
        Me.gbInvWH.Controls.Add(Me.txtWHG3)
        Me.gbInvWH.Controls.Add(Me.Label23)
        Me.gbInvWH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.gbInvWH.Location = New System.Drawing.Point(9, 326)
        Me.gbInvWH.Name = "gbInvWH"
        Me.gbInvWH.Size = New System.Drawing.Size(610, 158)
        Me.gbInvWH.TabIndex = 20
        Me.gbInvWH.TabStop = False
        Me.gbInvWH.Text = "Inventory Warehouse Group"
        '
        'txtWHG1
        '
        Me.txtWHG1.Location = New System.Drawing.Point(104, 25)
        Me.txtWHG1.Name = "txtWHG1"
        Me.txtWHG1.Size = New System.Drawing.Size(258, 22)
        Me.txtWHG1.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(41, 128)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 16)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Group 5 :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(41, 28)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "Group 1 :"
        '
        'txtWHG5
        '
        Me.txtWHG5.Location = New System.Drawing.Point(104, 125)
        Me.txtWHG5.Name = "txtWHG5"
        Me.txtWHG5.Size = New System.Drawing.Size(258, 22)
        Me.txtWHG5.TabIndex = 18
        '
        'txtWHG2
        '
        Me.txtWHG2.Location = New System.Drawing.Point(104, 50)
        Me.txtWHG2.Name = "txtWHG2"
        Me.txtWHG2.Size = New System.Drawing.Size(258, 22)
        Me.txtWHG2.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(41, 103)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 16)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Group 4 :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(41, 53)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 16)
        Me.Label24.TabIndex = 13
        Me.Label24.Text = "Group 2 :"
        '
        'txtWHG4
        '
        Me.txtWHG4.Location = New System.Drawing.Point(104, 100)
        Me.txtWHG4.Name = "txtWHG4"
        Me.txtWHG4.Size = New System.Drawing.Size(258, 22)
        Me.txtWHG4.TabIndex = 16
        '
        'txtWHG3
        '
        Me.txtWHG3.Location = New System.Drawing.Point(104, 75)
        Me.txtWHG3.Name = "txtWHG3"
        Me.txtWHG3.Size = New System.Drawing.Size(258, 22)
        Me.txtWHG3.TabIndex = 14
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(41, 78)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 16)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Group 3 :"
        '
        'tpSales
        '
        Me.tpSales.Controls.Add(Me.gbSO)
        Me.tpSales.Location = New System.Drawing.Point(5, 4)
        Me.tpSales.Name = "tpSales"
        Me.tpSales.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSales.Size = New System.Drawing.Size(785, 414)
        Me.tpSales.TabIndex = 10
        Me.tpSales.Text = "TabPage1"
        Me.tpSales.UseVisualStyleBackColor = True
        '
        'gbSO
        '
        Me.gbSO.Controls.Add(Me.chkSOreqPO)
        Me.gbSO.Controls.Add(Me.chkSOeditPrice)
        Me.gbSO.Location = New System.Drawing.Point(6, 6)
        Me.gbSO.Name = "gbSO"
        Me.gbSO.Size = New System.Drawing.Size(773, 136)
        Me.gbSO.TabIndex = 0
        Me.gbSO.TabStop = False
        Me.gbSO.Text = "Sales Order"
        '
        'chkSOreqPO
        '
        Me.chkSOreqPO.AutoSize = True
        Me.chkSOreqPO.Location = New System.Drawing.Point(50, 54)
        Me.chkSOreqPO.Name = "chkSOreqPO"
        Me.chkSOreqPO.Size = New System.Drawing.Size(246, 21)
        Me.chkSOreqPO.TabIndex = 1
        Me.chkSOreqPO.Text = "Require Customer Purchase Order"
        Me.chkSOreqPO.UseVisualStyleBackColor = True
        '
        'chkSOeditPrice
        '
        Me.chkSOeditPrice.AutoSize = True
        Me.chkSOeditPrice.Location = New System.Drawing.Point(50, 32)
        Me.chkSOeditPrice.Name = "chkSOeditPrice"
        Me.chkSOeditPrice.Size = New System.Drawing.Size(154, 21)
        Me.chkSOeditPrice.TabIndex = 0
        Me.chkSOeditPrice.Text = "Enable Price Editing"
        Me.chkSOeditPrice.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "nodeCOA"
        TreeNode1.Text = "Chart of Account"
        TreeNode2.Name = "nodeTrans"
        TreeNode2.Text = "Transaction ID"
        TreeNode3.Name = "nodeVCE"
        TreeNode3.Text = "VCE Setup"
        TreeNode4.Name = "nodeUser"
        TreeNode4.Text = "User Account"
        TreeNode5.Name = "nodeTax"
        TreeNode5.Text = "Tax Setup"
        TreeNode6.Name = "nodeBranch"
        TreeNode6.Text = "Branch Setup"
        TreeNode7.Name = "nodeBustype"
        TreeNode7.Text = "Business Type Setup"
        TreeNode8.Name = "nodeGroup"
        TreeNode8.Text = "Maintenance Group"
        TreeNode9.Name = "Node0"
        TreeNode9.Text = "General"
        TreeNode10.Name = "Node1"
        TreeNode10.Text = "Purchasing"
        TreeNode11.Name = "Node2"
        TreeNode11.Text = "Sales"
        TreeNode12.Name = "Node3"
        TreeNode12.Text = "Inventory"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode9, TreeNode10, TreeNode11, TreeNode12})
        Me.TreeView1.ShowLines = False
        Me.TreeView1.Size = New System.Drawing.Size(267, 424)
        Me.TreeView1.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnSave.Location = New System.Drawing.Point(856, 438)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 30)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnClose.Location = New System.Drawing.Point(972, 438)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 30)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tpInventory
        '
        Me.tpInventory.Controls.Add(Me.GroupBox8)
        Me.tpInventory.Location = New System.Drawing.Point(5, 4)
        Me.tpInventory.Name = "tpInventory"
        Me.tpInventory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInventory.Size = New System.Drawing.Size(785, 414)
        Me.tpInventory.TabIndex = 11
        Me.tpInventory.Text = "TabPage1"
        Me.tpInventory.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkRR_RestrictWHSEItem)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(773, 269)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Receiving Report (RR)"
        '
        'chkRR_RestrictWHSEItem
        '
        Me.chkRR_RestrictWHSEItem.AutoSize = True
        Me.chkRR_RestrictWHSEItem.Location = New System.Drawing.Point(56, 37)
        Me.chkRR_RestrictWHSEItem.Name = "chkRR_RestrictWHSEItem"
        Me.chkRR_RestrictWHSEItem.Size = New System.Drawing.Size(297, 21)
        Me.chkRR_RestrictWHSEItem.TabIndex = 2
        Me.chkRR_RestrictWHSEItem.Text = "Only show Item from accessible warehouse"
        Me.chkRR_RestrictWHSEItem.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaGreen
        Me.ClientSize = New System.Drawing.Size(1086, 475)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.tcSettings)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcSettings.ResumeLayout(False)
        Me.tpUA.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nupUAminLen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCOA.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.dgvTransDetailsAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpVCE.ResumeLayout(False)
        Me.gbVCE.ResumeLayout(False)
        Me.gbVCE.PerformLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAPV.ResumeLayout(False)
        Me.gbAP.ResumeLayout(False)
        Me.gbAP.PerformLayout()
        Me.tpPurchase.ResumeLayout(False)
        Me.gbPO.ResumeLayout(False)
        Me.gbPO.PerformLayout()
        Me.gbPR.ResumeLayout(False)
        Me.gbPR.PerformLayout()
        Me.tpTax.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        CType(Me.dgvVAT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.dgvWTAX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpBranch.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        CType(Me.dgvBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpBusiType.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.dgvBusType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMaintGroup.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.gbProdWH.ResumeLayout(False)
        Me.gbProdWH.PerformLayout()
        Me.gbPC.ResumeLayout(False)
        Me.gbPC.PerformLayout()
        Me.gbCC.ResumeLayout(False)
        Me.gbCC.PerformLayout()
        Me.gbInvWH.ResumeLayout(False)
        Me.gbInvWH.PerformLayout()
        Me.tpSales.ResumeLayout(False)
        Me.gbSO.ResumeLayout(False)
        Me.gbSO.PerformLayout()
        Me.tpInventory.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcSettings As System.Windows.Forms.TabControl
    Friend WithEvents tpUA As System.Windows.Forms.TabPage
    Friend WithEvents tpCOA As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents attemptLock As System.Windows.Forms.CheckBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nupUAminLen As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox13 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lvType As System.Windows.Forms.ListView
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDigit As System.Windows.Forms.ColumnHeader
    Friend WithEvents chOrder As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCatDown As System.Windows.Forms.Button
    Friend WithEvents btnCatUp As System.Windows.Forms.Button
    Friend WithEvents chkCOAauto As System.Windows.Forms.CheckBox
    Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents cbCOAformat As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCOAFormat As System.Windows.Forms.TextBox
    Friend WithEvents dgvTransDetail As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chkGlobal As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransAuto As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpVCE As System.Windows.Forms.TabPage
    Friend WithEvents gbVCE As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tpAPV As System.Windows.Forms.TabPage
    Friend WithEvents gbAP As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents dgvTransID As System.Windows.Forms.DataGridView
    Friend WithEvents tpPurchase As System.Windows.Forms.TabPage
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAdvance As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbPurchases As System.Windows.Forms.ListBox
    Friend WithEvents txtPendingAP As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbPayables As System.Windows.Forms.ListBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tpTax As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVAT As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvWTAX As System.Windows.Forms.DataGridView
    Friend WithEvents dgcVatCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVatDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVatAlias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVatRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVatAccntCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVatAccntTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtAlias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtAccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtAccntTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtATC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEwtNature As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpBranch As System.Windows.Forms.TabPage
    Friend WithEvents dgvBranch As System.Windows.Forms.DataGridView
    Friend WithEvents dgcBranchOldCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBranchCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBranchName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBranchMain As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpBusiType As System.Windows.Forms.TabPage
    Friend WithEvents dgvBusType As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents dgcBusTypeOld As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBusType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBusTypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpMaintGroup As System.Windows.Forms.TabPage
    Friend WithEvents gbCC As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCCG5 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCCG4 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCCG3 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCCG2 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCCG1 As System.Windows.Forms.TextBox
    Friend WithEvents gbInvWH As System.Windows.Forms.GroupBox
    Friend WithEvents txtWHG1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtWHG5 As System.Windows.Forms.TextBox
    Friend WithEvents txtWHG2 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtWHG4 As System.Windows.Forms.TextBox
    Friend WithEvents txtWHG3 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents gbPC As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPCG5 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtPCG4 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtPCG3 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtPCG2 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtPCG1 As System.Windows.Forms.TextBox
    Friend WithEvents tpSales As System.Windows.Forms.TabPage
    Friend WithEvents gbSO As System.Windows.Forms.GroupBox
    Friend WithEvents chkSOeditPrice As System.Windows.Forms.CheckBox
    Friend WithEvents chkSOreqPO As System.Windows.Forms.CheckBox
    Friend WithEvents gbProdWH As System.Windows.Forms.GroupBox
    Friend WithEvents txtPWHG1 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtPWHG5 As System.Windows.Forms.TextBox
    Friend WithEvents txtPWHG2 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtPWHG4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPWHG3 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents dgcTransType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTransDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTransAuto As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcTransGlobal As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvTransDetailsAll As System.Windows.Forms.DataGridView
    Friend WithEvents dgcTransAllType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTransAllBranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTransAllBus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTransAllPrefix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTransAlldigit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbPR As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cbPRstock As System.Windows.Forms.ComboBox
    Friend WithEvents gbPO As System.Windows.Forms.GroupBox
    Friend WithEvents chkPOapproval As System.Windows.Forms.CheckBox
    Friend WithEvents tpInventory As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRR_RestrictWHSEItem As System.Windows.Forms.CheckBox
End Class
