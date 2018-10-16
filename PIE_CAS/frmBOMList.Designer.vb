<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBOMList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBOMList))
        Me.cbUOM = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chItemCode = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chItemName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chUOM = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chQTY = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.dgvItemMaster = New System.Windows.Forms.DataGridView()
        Me.chIDX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcItemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBOMItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBOMItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBOMUOM = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.chBOMQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvLabor = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgcDLactivity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDLrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDLcrewNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDLtime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDLTotalMins = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDLtotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvOverhead = New System.Windows.Forms.DataGridView()
        Me.dgcFOactivity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFOmachine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFOrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFOKW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFOhrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFOtotalKWH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFOcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvItemMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvLabor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvOverhead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbUOM
        '
        Me.cbUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.cbUOM.FormattingEnabled = True
        Me.cbUOM.Location = New System.Drawing.Point(105, 91)
        Me.cbUOM.Name = "cbUOM"
        Me.cbUOM.Size = New System.Drawing.Size(110, 24)
        Me.cbUOM.TabIndex = 8134
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(24, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 8132
        Me.Label4.Text = "Item Code :"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.White
        Me.txtItemCode.Enabled = False
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtItemCode.ForeColor = System.Drawing.Color.Black
        Me.txtItemCode.Location = New System.Drawing.Point(105, 43)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(267, 22)
        Me.txtItemCode.TabIndex = 8127
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 8130
        Me.Label1.Text = "Item Name :"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.White
        Me.txtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtItemName.ForeColor = System.Drawing.Color.Black
        Me.txtItemName.Location = New System.Drawing.Point(105, 67)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(267, 22)
        Me.txtItemName.TabIndex = 8128
        '
        'txtQTY
        '
        Me.txtQTY.BackColor = System.Drawing.Color.White
        Me.txtQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtQTY.ForeColor = System.Drawing.Color.Black
        Me.txtQTY.Location = New System.Drawing.Point(264, 91)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(108, 22)
        Me.txtQTY.TabIndex = 8129
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(54, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 8135
        Me.Label2.Text = "UOM :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(221, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 8136
        Me.Label3.Text = "QTY :"
        '
        'lvList
        '
        Me.lvList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvList.BackColor = System.Drawing.Color.White
        Me.lvList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chID, Me.chItemCode, Me.chItemName, Me.chUOM, Me.chQTY})
        Me.lvList.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lvList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList.FullRowSelect = True
        Me.lvList.Location = New System.Drawing.Point(12, 12)
        Me.lvList.MultiSelect = False
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(634, 287)
        Me.lvList.TabIndex = 8137
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'chID
        '
        Me.chID.Text = "ID"
        Me.chID.Width = 0
        '
        'chItemCode
        '
        Me.chItemCode.Text = "ItemCode"
        Me.chItemCode.Width = 88
        '
        'chItemName
        '
        Me.chItemName.Text = "ItemName"
        Me.chItemName.Width = 333
        '
        'chUOM
        '
        Me.chUOM.Text = "UoM"
        Me.chUOM.Width = 104
        '
        'chQTY
        '
        Me.chQTY.Text = "QTY"
        Me.chQTY.Width = 104
        '
        'dgvItemMaster
        '
        Me.dgvItemMaster.BackgroundColor = System.Drawing.Color.White
        Me.dgvItemMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chIDX, Me.dgcItemCategory, Me.dgcItemGroup, Me.chBOMItemCode, Me.chBOMItemName, Me.chBOMUOM, Me.chBOMQTY})
        Me.dgvItemMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemMaster.Location = New System.Drawing.Point(3, 3)
        Me.dgvItemMaster.Name = "dgvItemMaster"
        Me.dgvItemMaster.Size = New System.Drawing.Size(1028, 159)
        Me.dgvItemMaster.TabIndex = 8138
        '
        'chIDX
        '
        Me.chIDX.HeaderText = "idx"
        Me.chIDX.Name = "chIDX"
        Me.chIDX.Visible = False
        '
        'dgcItemCategory
        '
        Me.dgcItemCategory.HeaderText = "Category"
        Me.dgcItemCategory.Name = "dgcItemCategory"
        '
        'dgcItemGroup
        '
        Me.dgcItemGroup.HeaderText = "Group"
        Me.dgcItemGroup.Name = "dgcItemGroup"
        '
        'chBOMItemCode
        '
        Me.chBOMItemCode.HeaderText = "Item Code"
        Me.chBOMItemCode.Name = "chBOMItemCode"
        '
        'chBOMItemName
        '
        Me.chBOMItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.chBOMItemName.HeaderText = "Item Description"
        Me.chBOMItemName.Name = "chBOMItemName"
        '
        'chBOMUOM
        '
        Me.chBOMUOM.HeaderText = "UOM"
        Me.chBOMUOM.Name = "chBOMUOM"
        Me.chBOMUOM.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chBOMUOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'chBOMQTY
        '
        Me.chBOMQTY.HeaderText = "Quantity"
        Me.chBOMQTY.Name = "chBOMQTY"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtItemCode)
        Me.GroupBox1.Controls.Add(Me.txtQTY)
        Me.GroupBox1.Controls.Add(Me.txtItemName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbUOM)
        Me.GroupBox1.Location = New System.Drawing.Point(652, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 287)
        Me.GroupBox1.TabIndex = 8139
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(237, 212)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 34)
        Me.Button1.TabIndex = 8143
        Me.Button1.Text = "Delete"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.Location = New System.Drawing.Point(105, 118)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(170, 88)
        Me.txtDescription.TabIndex = 8139
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 16)
        Me.Label7.TabIndex = 8140
        Me.Label7.Text = "Description :"
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.Enabled = False
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtCode.ForeColor = System.Drawing.Color.Black
        Me.txtCode.Location = New System.Drawing.Point(105, 19)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(267, 22)
        Me.txtCode.TabIndex = 8137
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(124, 212)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 34)
        Me.btnSave.TabIndex = 8142
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(11, 212)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(107, 34)
        Me.btnNew.TabIndex = 8140
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 8138
        Me.Label5.Text = "BOM Code :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(-1, 305)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1048, 319)
        Me.GroupBox2.TabIndex = 8140
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BOM Details"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1042, 299)
        Me.TabControl1.TabIndex = 8139
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvItemMaster)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1034, 165)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Materials"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvLabor)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1034, 165)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Direct Labour"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvLabor
        '
        Me.dgvLabor.BackgroundColor = System.Drawing.Color.White
        Me.dgvLabor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLabor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcDLactivity, Me.dgcDLrate, Me.dgcDLcrewNo, Me.dgcDLtime, Me.dgcDLTotalMins, Me.dgcDLtotalCost})
        Me.dgvLabor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabor.Location = New System.Drawing.Point(3, 3)
        Me.dgvLabor.Name = "dgvLabor"
        Me.dgvLabor.Size = New System.Drawing.Size(1028, 159)
        Me.dgvLabor.TabIndex = 8139
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvOverhead)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1034, 271)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Overhead"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgcDLactivity
        '
        Me.dgcDLactivity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgcDLactivity.HeaderText = "Activity"
        Me.dgcDLactivity.Name = "dgcDLactivity"
        '
        'dgcDLrate
        '
        Me.dgcDLrate.HeaderText = "Rate/Hour"
        Me.dgcDLrate.Name = "dgcDLrate"
        '
        'dgcDLcrewNo
        '
        Me.dgcDLcrewNo.HeaderText = "No. of Crew"
        Me.dgcDLcrewNo.Name = "dgcDLcrewNo"
        '
        'dgcDLtime
        '
        Me.dgcDLtime.HeaderText = "Time (in mins)"
        Me.dgcDLtime.Name = "dgcDLtime"
        '
        'dgcDLTotalMins
        '
        Me.dgcDLTotalMins.HeaderText = "Total Mins"
        Me.dgcDLTotalMins.Name = "dgcDLTotalMins"
        '
        'dgcDLtotalCost
        '
        Me.dgcDLtotalCost.HeaderText = "Total Cost"
        Me.dgcDLtotalCost.Name = "dgcDLtotalCost"
        '
        'dgvOverhead
        '
        Me.dgvOverhead.BackgroundColor = System.Drawing.Color.White
        Me.dgvOverhead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOverhead.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcFOactivity, Me.dgcFOmachine, Me.dgcFOrate, Me.dgcFOKW, Me.dgcFOhrs, Me.dgcFOtotalKWH, Me.dgcFOcost})
        Me.dgvOverhead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOverhead.Location = New System.Drawing.Point(3, 3)
        Me.dgvOverhead.Name = "dgvOverhead"
        Me.dgvOverhead.Size = New System.Drawing.Size(1028, 265)
        Me.dgvOverhead.TabIndex = 8140
        '
        'dgcFOactivity
        '
        Me.dgcFOactivity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgcFOactivity.HeaderText = "Activity"
        Me.dgcFOactivity.Name = "dgcFOactivity"
        '
        'dgcFOmachine
        '
        Me.dgcFOmachine.HeaderText = "Machine"
        Me.dgcFOmachine.Name = "dgcFOmachine"
        Me.dgcFOmachine.Width = 150
        '
        'dgcFOrate
        '
        Me.dgcFOrate.HeaderText = "Rate/Hour"
        Me.dgcFOrate.Name = "dgcFOrate"
        '
        'dgcFOKW
        '
        Me.dgcFOKW.HeaderText = "KW"
        Me.dgcFOKW.Name = "dgcFOKW"
        '
        'dgcFOhrs
        '
        Me.dgcFOhrs.HeaderText = "No. of Hrs"
        Me.dgcFOhrs.Name = "dgcFOhrs"
        '
        'dgcFOtotalKWH
        '
        Me.dgcFOtotalKWH.HeaderText = "Total KWH"
        Me.dgcFOtotalKWH.Name = "dgcFOtotalKWH"
        '
        'dgcFOcost
        '
        Me.dgcFOcost.HeaderText = "Total Cost"
        Me.dgcFOcost.Name = "dgcFOcost"
        '
        'frmBOMList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1047, 636)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBOMList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOM"
        CType(Me.dgvItemMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvLabor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvOverhead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents cbUOM As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents txtQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents chUOM As System.Windows.Forms.ColumnHeader
    Friend WithEvents chItemCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents chItemName As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgvItemMaster As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chQTY As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chIDX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcItemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBOMItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBOMItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBOMUOM As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents chBOMQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvLabor As System.Windows.Forms.DataGridView
    Friend WithEvents dgcDLactivity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDLrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDLcrewNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDLtime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDLTotalMins As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDLtotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvOverhead As System.Windows.Forms.DataGridView
    Friend WithEvents dgcFOactivity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFOmachine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFOrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFOKW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFOhrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFOtotalKWH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFOcost As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
