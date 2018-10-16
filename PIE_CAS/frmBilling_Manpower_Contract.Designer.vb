<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBilling_Manpower_Contract
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBilling_Manpower_Contract))
        Me.btnImport = New System.Windows.Forms.Button()
        Me.lvContract = New System.Windows.Forms.ListView()
        Me.chContractNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chVCECode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCategory = New System.Windows.Forms.ListView()
        Me.chCategory = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.dtpContractDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvCharges = New System.Windows.Forms.DataGridView()
        Me.dcCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcCalcMethod = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dcRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcAdminFee = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcSort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCatDown = New System.Windows.Forms.Button()
        Me.btnCatUp = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbGroup = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnChargeDown = New System.Windows.Forms.Button()
        Me.btnChargeUp = New System.Windows.Forms.Button()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.btnRemAll = New System.Windows.Forms.Button()
        Me.btnRemSpecific = New System.Windows.Forms.Button()
        Me.lvCharges = New System.Windows.Forms.ListView()
        Me.chCharges = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddSpecific = New System.Windows.Forms.Button()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpContractEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblContractEnd = New System.Windows.Forms.Label()
        Me.txtAdminFee = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCatRemove = New System.Windows.Forms.Button()
        Me.btnCatAdd = New System.Windows.Forms.Button()
        Me.dgvChargesAll = New System.Windows.Forms.DataGridView()
        Me.dcAllCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcAllCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcAllMethod = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dcAllRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcAllAdmin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcSortAll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnNew = New System.Windows.Forms.Button()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvChargesAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(281, 529)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(109, 41)
        Me.btnImport.TabIndex = 1342
        Me.btnImport.Text = "Charges Maintenance"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'lvContract
        '
        Me.lvContract.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvContract.CheckBoxes = True
        Me.lvContract.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chContractNo, Me.chVCECode, Me.chName})
        Me.lvContract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvContract.FullRowSelect = True
        Me.lvContract.HideSelection = False
        Me.lvContract.Location = New System.Drawing.Point(12, 12)
        Me.lvContract.MultiSelect = False
        Me.lvContract.Name = "lvContract"
        Me.lvContract.Size = New System.Drawing.Size(253, 558)
        Me.lvContract.TabIndex = 1343
        Me.lvContract.UseCompatibleStateImageBehavior = False
        Me.lvContract.View = System.Windows.Forms.View.Details
        '
        'chContractNo
        '
        Me.chContractNo.Text = "Contract No."
        Me.chContractNo.Width = 0
        '
        'chVCECode
        '
        Me.chVCECode.Text = "VCECode"
        Me.chVCECode.Width = 0
        '
        'chName
        '
        Me.chName.Text = "Client Name"
        Me.chName.Width = 264
        '
        'lvCategory
        '
        Me.lvCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvCategory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCategory})
        Me.lvCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCategory.FullRowSelect = True
        Me.lvCategory.HideSelection = False
        Me.lvCategory.Location = New System.Drawing.Point(281, 143)
        Me.lvCategory.MultiSelect = False
        Me.lvCategory.Name = "lvCategory"
        Me.lvCategory.Size = New System.Drawing.Size(146, 350)
        Me.lvCategory.TabIndex = 1344
        Me.lvCategory.UseCompatibleStateImageBehavior = False
        Me.lvCategory.View = System.Windows.Forms.View.Details
        '
        'chCategory
        '
        Me.chCategory.Text = "Category"
        Me.chCategory.Width = 142
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Location = New System.Drawing.Point(270, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(5, 560)
        Me.Panel1.TabIndex = 1346
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 1345
        Me.Label3.Text = "VCECode :"
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(106, 21)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(130, 22)
        Me.txtCode.TabIndex = 1344
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 1347
        Me.Label1.Text = "VCEName :"
        '
        'txtVCEName
        '
        Me.txtVCEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCEName.Location = New System.Drawing.Point(106, 46)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.Size = New System.Drawing.Size(259, 22)
        Me.txtVCEName.TabIndex = 1346
        '
        'dtpContractDate
        '
        Me.dtpContractDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpContractDate.Location = New System.Drawing.Point(106, 71)
        Me.dtpContractDate.Name = "dtpContractDate"
        Me.dtpContractDate.Size = New System.Drawing.Size(130, 22)
        Me.dtpContractDate.TabIndex = 1348
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 1349
        Me.Label2.Text = "Contract Date :"
        '
        'dgvCharges
        '
        Me.dgvCharges.AllowUserToAddRows = False
        Me.dgvCharges.AllowUserToDeleteRows = False
        Me.dgvCharges.AllowUserToResizeRows = False
        Me.dgvCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCharges.BackgroundColor = System.Drawing.Color.White
        Me.dgvCharges.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcCode, Me.dcCalcMethod, Me.dcRate, Me.dcAdminFee, Me.dcSort})
        Me.dgvCharges.Location = New System.Drawing.Point(674, 143)
        Me.dgvCharges.Name = "dgvCharges"
        Me.dgvCharges.RowHeadersVisible = False
        Me.dgvCharges.Size = New System.Drawing.Size(523, 380)
        Me.dgvCharges.TabIndex = 1350
        '
        'dcCode
        '
        Me.dcCode.Frozen = True
        Me.dcCode.HeaderText = "Code"
        Me.dcCode.Name = "dcCode"
        Me.dcCode.ReadOnly = True
        Me.dcCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcCode.Width = 120
        '
        'dcCalcMethod
        '
        Me.dcCalcMethod.HeaderText = "Method"
        Me.dcCalcMethod.Name = "dcCalcMethod"
        Me.dcCalcMethod.Width = 180
        '
        'dcRate
        '
        Me.dcRate.HeaderText = "Rate"
        Me.dcRate.Name = "dcRate"
        Me.dcRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcRate.Width = 120
        '
        'dcAdminFee
        '
        Me.dcAdminFee.HeaderText = "w/ Admin Fee"
        Me.dcAdminFee.Name = "dcAdminFee"
        '
        'dcSort
        '
        Me.dcSort.HeaderText = "Sort"
        Me.dcSort.Name = "dcSort"
        Me.dcSort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcSort.Visible = False
        '
        'btnCatDown
        '
        Me.btnCatDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatDown.Location = New System.Drawing.Point(430, 173)
        Me.btnCatDown.Name = "btnCatDown"
        Me.btnCatDown.Size = New System.Drawing.Size(34, 28)
        Me.btnCatDown.TabIndex = 1352
        Me.btnCatDown.Text = "↓"
        Me.btnCatDown.UseVisualStyleBackColor = True
        '
        'btnCatUp
        '
        Me.btnCatUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatUp.Location = New System.Drawing.Point(430, 143)
        Me.btnCatUp.Name = "btnCatUp"
        Me.btnCatUp.Size = New System.Drawing.Size(34, 28)
        Me.btnCatUp.TabIndex = 1351
        Me.btnCatUp.Text = "↑"
        Me.btnCatUp.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(597, 529)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 41)
        Me.btnSave.TabIndex = 1355
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(712, 529)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(109, 41)
        Me.btnRemove.TabIndex = 1356
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Location = New System.Drawing.Point(470, 143)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(5, 380)
        Me.Panel2.TabIndex = 1358
        '
        'cbGroup
        '
        Me.cbGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.cbGroup.FormattingEnabled = True
        Me.cbGroup.Location = New System.Drawing.Point(106, 96)
        Me.cbGroup.Name = "cbGroup"
        Me.cbGroup.Size = New System.Drawing.Size(259, 24)
        Me.cbGroup.TabIndex = 1359
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 1360
        Me.Label4.Text = "Default Group :"
        '
        'btnChargeDown
        '
        Me.btnChargeDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChargeDown.Location = New System.Drawing.Point(1203, 173)
        Me.btnChargeDown.Name = "btnChargeDown"
        Me.btnChargeDown.Size = New System.Drawing.Size(34, 28)
        Me.btnChargeDown.TabIndex = 1362
        Me.btnChargeDown.Text = "↓"
        Me.btnChargeDown.UseVisualStyleBackColor = True
        '
        'btnChargeUp
        '
        Me.btnChargeUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChargeUp.Location = New System.Drawing.Point(1203, 143)
        Me.btnChargeUp.Name = "btnChargeUp"
        Me.btnChargeUp.Size = New System.Drawing.Size(34, 28)
        Me.btnChargeUp.TabIndex = 1361
        Me.btnChargeUp.Text = "↑"
        Me.btnChargeUp.UseVisualStyleBackColor = True
        '
        'cbCategory
        '
        Me.cbCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(281, 499)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(146, 24)
        Me.cbCategory.TabIndex = 1365
        '
        'btnRemAll
        '
        Me.btnRemAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemAll.Location = New System.Drawing.Point(634, 376)
        Me.btnRemAll.Name = "btnRemAll"
        Me.btnRemAll.Size = New System.Drawing.Size(34, 28)
        Me.btnRemAll.TabIndex = 1367
        Me.btnRemAll.Text = "<<"
        Me.btnRemAll.UseVisualStyleBackColor = True
        '
        'btnRemSpecific
        '
        Me.btnRemSpecific.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemSpecific.Location = New System.Drawing.Point(634, 346)
        Me.btnRemSpecific.Name = "btnRemSpecific"
        Me.btnRemSpecific.Size = New System.Drawing.Size(34, 28)
        Me.btnRemSpecific.TabIndex = 1366
        Me.btnRemSpecific.Text = "<"
        Me.btnRemSpecific.UseVisualStyleBackColor = True
        '
        'lvCharges
        '
        Me.lvCharges.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvCharges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCharges})
        Me.lvCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCharges.FullRowSelect = True
        Me.lvCharges.Location = New System.Drawing.Point(482, 143)
        Me.lvCharges.Name = "lvCharges"
        Me.lvCharges.Size = New System.Drawing.Size(146, 380)
        Me.lvCharges.TabIndex = 1368
        Me.lvCharges.UseCompatibleStateImageBehavior = False
        Me.lvCharges.View = System.Windows.Forms.View.Details
        '
        'chCharges
        '
        Me.chCharges.Text = "Charges"
        Me.chCharges.Width = 142
        '
        'btnAddSpecific
        '
        Me.btnAddSpecific.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSpecific.Location = New System.Drawing.Point(634, 281)
        Me.btnAddSpecific.Name = "btnAddSpecific"
        Me.btnAddSpecific.Size = New System.Drawing.Size(34, 28)
        Me.btnAddSpecific.TabIndex = 1370
        Me.btnAddSpecific.Text = ">"
        Me.btnAddSpecific.UseVisualStyleBackColor = True
        '
        'btnAddAll
        '
        Me.btnAddAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAll.Location = New System.Drawing.Point(634, 251)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(34, 28)
        Me.btnAddAll.TabIndex = 1369
        Me.btnAddAll.Text = ">>"
        Me.btnAddAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpContractEnd)
        Me.GroupBox1.Controls.Add(Me.lblContractEnd)
        Me.GroupBox1.Controls.Add(Me.txtAdminFee)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtVCEName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpContractDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbGroup)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(281, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(952, 129)
        Me.GroupBox1.TabIndex = 1371
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "    "
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(542, 46)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(143, 22)
        Me.txtStatus.TabIndex = 1365
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(485, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 1366
        Me.Label7.Text = "Status :"
        '
        'dtpContractEnd
        '
        Me.dtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpContractEnd.Location = New System.Drawing.Point(542, 71)
        Me.dtpContractEnd.Name = "dtpContractEnd"
        Me.dtpContractEnd.Size = New System.Drawing.Size(143, 22)
        Me.dtpContractEnd.TabIndex = 1363
        Me.dtpContractEnd.Visible = False
        '
        'lblContractEnd
        '
        Me.lblContractEnd.AutoSize = True
        Me.lblContractEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractEnd.Location = New System.Drawing.Point(414, 74)
        Me.lblContractEnd.Name = "lblContractEnd"
        Me.lblContractEnd.Size = New System.Drawing.Size(122, 16)
        Me.lblContractEnd.TabIndex = 1364
        Me.lblContractEnd.Text = "Contract End Date :"
        Me.lblContractEnd.Visible = False
        '
        'txtAdminFee
        '
        Me.txtAdminFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdminFee.Location = New System.Drawing.Point(542, 21)
        Me.txtAdminFee.Name = "txtAdminFee"
        Me.txtAdminFee.Size = New System.Drawing.Size(143, 22)
        Me.txtAdminFee.TabIndex = 1361
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(434, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 16)
        Me.Label5.TabIndex = 1362
        Me.Label5.Text = "Admin Fee (%) :"
        '
        'btnCatRemove
        '
        Me.btnCatRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatRemove.Location = New System.Drawing.Point(433, 465)
        Me.btnCatRemove.Name = "btnCatRemove"
        Me.btnCatRemove.Size = New System.Drawing.Size(34, 28)
        Me.btnCatRemove.TabIndex = 1373
        Me.btnCatRemove.Text = "-"
        Me.btnCatRemove.UseVisualStyleBackColor = True
        '
        'btnCatAdd
        '
        Me.btnCatAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatAdd.Location = New System.Drawing.Point(433, 435)
        Me.btnCatAdd.Name = "btnCatAdd"
        Me.btnCatAdd.Size = New System.Drawing.Size(34, 28)
        Me.btnCatAdd.TabIndex = 1372
        Me.btnCatAdd.Text = "+"
        Me.btnCatAdd.UseVisualStyleBackColor = True
        '
        'dgvChargesAll
        '
        Me.dgvChargesAll.AllowUserToAddRows = False
        Me.dgvChargesAll.AllowUserToDeleteRows = False
        Me.dgvChargesAll.AllowUserToOrderColumns = True
        Me.dgvChargesAll.AllowUserToResizeRows = False
        Me.dgvChargesAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvChargesAll.BackgroundColor = System.Drawing.Color.White
        Me.dgvChargesAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChargesAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcAllCategory, Me.dcAllCode, Me.dcAllMethod, Me.dcAllRate, Me.dcAllAdmin, Me.dcSortAll})
        Me.dgvChargesAll.Location = New System.Drawing.Point(674, 143)
        Me.dgvChargesAll.Name = "dgvChargesAll"
        Me.dgvChargesAll.RowHeadersVisible = False
        Me.dgvChargesAll.Size = New System.Drawing.Size(523, 380)
        Me.dgvChargesAll.TabIndex = 1374
        Me.dgvChargesAll.Visible = False
        '
        'dcAllCategory
        '
        Me.dcAllCategory.HeaderText = "Category"
        Me.dcAllCategory.Name = "dcAllCategory"
        '
        'dcAllCode
        '
        Me.dcAllCode.HeaderText = "Code"
        Me.dcAllCode.Name = "dcAllCode"
        Me.dcAllCode.Width = 120
        '
        'dcAllMethod
        '
        Me.dcAllMethod.HeaderText = "Method"
        Me.dcAllMethod.Name = "dcAllMethod"
        Me.dcAllMethod.Width = 180
        '
        'dcAllRate
        '
        Me.dcAllRate.HeaderText = "Rate"
        Me.dcAllRate.Name = "dcAllRate"
        Me.dcAllRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcAllRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcAllRate.Width = 120
        '
        'dcAllAdmin
        '
        Me.dcAllAdmin.HeaderText = "w/ Admin Fee"
        Me.dcAllAdmin.Name = "dcAllAdmin"
        '
        'dcSortAll
        '
        Me.dcSortAll.HeaderText = "Sort"
        Me.dcSortAll.Name = "dcSortAll"
        Me.dcSortAll.Visible = False
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(482, 529)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(109, 41)
        Me.btnNew.TabIndex = 1375
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'frmBilling_Manpower_Contract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1245, 582)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnCatRemove)
        Me.Controls.Add(Me.btnCatAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAddSpecific)
        Me.Controls.Add(Me.btnAddAll)
        Me.Controls.Add(Me.lvCharges)
        Me.Controls.Add(Me.btnRemAll)
        Me.Controls.Add(Me.btnRemSpecific)
        Me.Controls.Add(Me.cbCategory)
        Me.Controls.Add(Me.btnChargeDown)
        Me.Controls.Add(Me.btnChargeUp)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCatDown)
        Me.Controls.Add(Me.btnCatUp)
        Me.Controls.Add(Me.lvContract)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lvCategory)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.dgvCharges)
        Me.Controls.Add(Me.dgvChargesAll)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBilling_Manpower_Contract"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billing - Manpower (Contract Maintenance)"
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvChargesAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents lvContract As System.Windows.Forms.ListView
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chContractNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents chVCECode As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCategory As System.Windows.Forms.ListView
    Friend WithEvents chCategory As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents dtpContractDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvCharges As System.Windows.Forms.DataGridView
    Friend WithEvents btnCatDown As System.Windows.Forms.Button
    Friend WithEvents btnCatUp As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnChargeDown As System.Windows.Forms.Button
    Friend WithEvents btnChargeUp As System.Windows.Forms.Button
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnRemAll As System.Windows.Forms.Button
    Friend WithEvents btnRemSpecific As System.Windows.Forms.Button
    Friend WithEvents lvCharges As System.Windows.Forms.ListView
    Friend WithEvents chCharges As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddSpecific As System.Windows.Forms.Button
    Friend WithEvents btnAddAll As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCatRemove As System.Windows.Forms.Button
    Friend WithEvents btnCatAdd As System.Windows.Forms.Button
    Friend WithEvents txtAdminFee As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvChargesAll As System.Windows.Forms.DataGridView
    Friend WithEvents dcAllCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcAllCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcAllMethod As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dcAllRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcAllAdmin As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcSortAll As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpContractEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractEnd As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents dcCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcCalcMethod As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dcRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcAdminFee As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcSort As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
