<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollection
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollection))
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lvctrlist = New System.Windows.Forms.ListView()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader48 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.tcCollection = New System.Windows.Forms.TabControl()
        Me.tpCollection = New System.Windows.Forms.TabPage()
        Me.dgvEntry = New System.Windows.Forms.DataGridView()
        Me.chAccntCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chAccntTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVCECode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVCEName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chParticulars = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.ListOR = New System.Windows.Forms.ListView()
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbCollectionType = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbRef = New System.Windows.Forms.ComboBox()
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.gbBank = New System.Windows.Forms.GroupBox()
        Me.cbBank = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpBankRefDate = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBankRef = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCopy = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsbCopyPO = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsbReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TestToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrevious = New System.Windows.Forms.ToolStripButton()
        Me.tsbNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchVCE = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtTransNum = New System.Windows.Forms.TextBox()
        Me.btnTypeMaintenance = New System.Windows.Forms.Button()
        Me.tcCollection.SuspendLayout()
        Me.tpCollection.SuspendLayout()
        CType(Me.dgvEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBank.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtVCECode
        '
        Me.txtVCECode.Enabled = False
        Me.txtVCECode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCECode.Location = New System.Drawing.Point(120, 43)
        Me.txtVCECode.Name = "txtVCECode"
        Me.txtVCECode.Size = New System.Drawing.Size(193, 21)
        Me.txtVCECode.TabIndex = 1254
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(37, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 1251
        Me.Label1.Text = "VCE Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(41, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 1261
        Me.Label2.Text = "VCE Code :"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(120, 603)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(83, 35)
        Me.cmdCancel.TabIndex = 1279
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        Me.cmdCancel.Visible = False
        '
        'lvctrlist
        '
        Me.lvctrlist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvctrlist.BackColor = System.Drawing.Color.White
        Me.lvctrlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvctrlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader48})
        Me.lvctrlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvctrlist.ForeColor = System.Drawing.Color.Black
        Me.lvctrlist.FullRowSelect = True
        Me.lvctrlist.GridLines = True
        Me.lvctrlist.Location = New System.Drawing.Point(988, 93)
        Me.lvctrlist.MinimumSize = New System.Drawing.Size(262, 230)
        Me.lvctrlist.MultiSelect = False
        Me.lvctrlist.Name = "lvctrlist"
        Me.lvctrlist.Size = New System.Drawing.Size(262, 240)
        Me.lvctrlist.TabIndex = 1288
        Me.lvctrlist.UseCompatibleStateImageBehavior = False
        Me.lvctrlist.View = System.Windows.Forms.View.Details
        Me.lvctrlist.Visible = False
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "BSNO"
        Me.ColumnHeader19.Width = 104
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Company Name"
        Me.ColumnHeader20.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "CompanyID"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "ConsolidatingBP"
        '
        'ColumnHeader48
        '
        Me.ColumnHeader48.Text = "WTaxType"
        '
        'tcCollection
        '
        Me.tcCollection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcCollection.Controls.Add(Me.tpCollection)
        Me.tcCollection.Location = New System.Drawing.Point(5, 250)
        Me.tcCollection.Name = "tcCollection"
        Me.tcCollection.SelectedIndex = 0
        Me.tcCollection.Size = New System.Drawing.Size(967, 340)
        Me.tcCollection.TabIndex = 1281
        '
        'tpCollection
        '
        Me.tpCollection.Controls.Add(Me.dgvEntry)
        Me.tpCollection.Controls.Add(Me.txtTotalCredit)
        Me.tpCollection.Controls.Add(Me.Label36)
        Me.tpCollection.Controls.Add(Me.txtTotalDebit)
        Me.tpCollection.Location = New System.Drawing.Point(4, 24)
        Me.tpCollection.Name = "tpCollection"
        Me.tpCollection.Size = New System.Drawing.Size(959, 312)
        Me.tpCollection.TabIndex = 7
        Me.tpCollection.Text = "AR Ledger"
        '
        'dgvEntry
        '
        Me.dgvEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chAccntCode, Me.chAccntTitle, Me.chDebit, Me.chCredit, Me.chVCECode, Me.chVCEName, Me.chParticulars, Me.chRef, Me.Column12})
        Me.dgvEntry.Location = New System.Drawing.Point(3, 0)
        Me.dgvEntry.Name = "dgvEntry"
        Me.dgvEntry.Size = New System.Drawing.Size(953, 274)
        Me.dgvEntry.TabIndex = 1303
        '
        'chAccntCode
        '
        Me.chAccntCode.HeaderText = "Account Code"
        Me.chAccntCode.Name = "chAccntCode"
        Me.chAccntCode.Width = 70
        '
        'chAccntTitle
        '
        Me.chAccntTitle.HeaderText = "Account Title"
        Me.chAccntTitle.Name = "chAccntTitle"
        Me.chAccntTitle.Width = 220
        '
        'chDebit
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "999,999,999.00"
        DataGridViewCellStyle1.NullValue = "0.00"
        Me.chDebit.DefaultCellStyle = DataGridViewCellStyle1
        Me.chDebit.HeaderText = "Debit"
        Me.chDebit.Name = "chDebit"
        Me.chDebit.Width = 80
        '
        'chCredit
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "999,999,999.00"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.chCredit.DefaultCellStyle = DataGridViewCellStyle2
        Me.chCredit.HeaderText = "Credit"
        Me.chCredit.Name = "chCredit"
        Me.chCredit.Width = 80
        '
        'chVCECode
        '
        Me.chVCECode.HeaderText = "VCECode"
        Me.chVCECode.Name = "chVCECode"
        Me.chVCECode.Width = 80
        '
        'chVCEName
        '
        Me.chVCEName.HeaderText = "VCEName"
        Me.chVCEName.Name = "chVCEName"
        Me.chVCEName.Width = 160
        '
        'chParticulars
        '
        Me.chParticulars.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.chParticulars.DefaultCellStyle = DataGridViewCellStyle3
        Me.chParticulars.HeaderText = "Particulars"
        Me.chParticulars.Name = "chParticulars"
        '
        'chRef
        '
        Me.chRef.HeaderText = "Reference ID"
        Me.chRef.Name = "chRef"
        Me.chRef.Width = 80
        '
        'Column12
        '
        Me.Column12.HeaderText = ">>"
        Me.Column12.Name = "Column12"
        Me.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column12.Width = 50
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCredit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(440, 280)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.Size = New System.Drawing.Size(118, 22)
        Me.txtTotalCredit.TabIndex = 1339
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(270, 280)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(43, 16)
        Me.Label36.TabIndex = 1341
        Me.Label36.Text = "Total :"
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(319, 280)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.Size = New System.Drawing.Size(114, 22)
        Me.txtTotalDebit.TabIndex = 1340
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label26.Location = New System.Drawing.Point(42, 150)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 17)
        Me.Label26.TabIndex = 1298
        Me.Label26.Text = "Ramarks :"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(120, 147)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(316, 45)
        Me.txtRemarks.TabIndex = 8
        '
        'ListOR
        '
        Me.ListOR.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.ListOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListOR.BackColor = System.Drawing.Color.White
        Me.ListOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListOR.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader24, Me.ColumnHeader23, Me.ColumnHeader26, Me.ColumnHeader28})
        Me.ListOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListOR.ForeColor = System.Drawing.Color.Black
        Me.ListOR.FullRowSelect = True
        Me.ListOR.GridLines = True
        Me.ListOR.Location = New System.Drawing.Point(993, 61)
        Me.ListOR.MinimumSize = New System.Drawing.Size(262, 115)
        Me.ListOR.MultiSelect = False
        Me.ListOR.Name = "ListOR"
        Me.ListOR.Size = New System.Drawing.Size(262, 115)
        Me.ListOR.TabIndex = 1317
        Me.ListOR.UseCompatibleStateImageBehavior = False
        Me.ListOR.View = System.Windows.Forms.View.Details
        Me.ListOR.Visible = False
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "DocNo"
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "ORNO"
        Me.ColumnHeader23.Width = 104
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Amount"
        Me.ColumnHeader26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Balance"
        '
        'cbCollectionType
        '
        Me.cbCollectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCollectionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCollectionType.FormattingEnabled = True
        Me.cbCollectionType.Location = New System.Drawing.Point(120, 119)
        Me.cbCollectionType.Name = "cbCollectionType"
        Me.cbCollectionType.Size = New System.Drawing.Size(193, 23)
        Me.cbCollectionType.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label30.Location = New System.Drawing.Point(5, 122)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(113, 17)
        Me.Label30.TabIndex = 1322
        Me.Label30.Text = "Collection Type :"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label37.Location = New System.Drawing.Point(-339, 112)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(82, 17)
        Me.Label37.TabIndex = 1329
        Me.Label37.Text = "Reference :"
        Me.Label37.Visible = False
        '
        'cbRef
        '
        Me.cbRef.BackColor = System.Drawing.SystemColors.Window
        Me.cbRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRef.FormattingEnabled = True
        Me.cbRef.Items.AddRange(New Object() {"IMP"})
        Me.cbRef.Location = New System.Drawing.Point(-253, 109)
        Me.cbRef.Name = "cbRef"
        Me.cbRef.Size = New System.Drawing.Size(73, 23)
        Me.cbRef.TabIndex = 6
        Me.cbRef.Visible = False
        '
        'cbPaymentType
        '
        Me.cbPaymentType.BackColor = System.Drawing.SystemColors.Window
        Me.cbPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Location = New System.Drawing.Point(120, 16)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(192, 23)
        Me.cbPaymentType.TabIndex = 1338
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label15.Location = New System.Drawing.Point(22, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 16)
        Me.Label15.TabIndex = 1339
        Me.Label15.Text = "Payment Type :"
        '
        'txtVCEName
        '
        Me.txtVCEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCEName.Location = New System.Drawing.Point(120, 68)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.Size = New System.Drawing.Size(316, 21)
        Me.txtVCEName.TabIndex = 1340
        '
        'gbBank
        '
        Me.gbBank.Controls.Add(Me.cbBank)
        Me.gbBank.Controls.Add(Me.Label12)
        Me.gbBank.Controls.Add(Me.dtpBankRefDate)
        Me.gbBank.Controls.Add(Me.Button1)
        Me.gbBank.Controls.Add(Me.Label11)
        Me.gbBank.Controls.Add(Me.txtBankRef)
        Me.gbBank.Controls.Add(Me.Label16)
        Me.gbBank.Location = New System.Drawing.Point(456, 16)
        Me.gbBank.Name = "gbBank"
        Me.gbBank.Size = New System.Drawing.Size(282, 96)
        Me.gbBank.TabIndex = 1348
        Me.gbBank.TabStop = False
        Me.gbBank.Text = "Check Details"
        '
        'cbBank
        '
        Me.cbBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBank.FormattingEnabled = True
        Me.cbBank.Location = New System.Drawing.Point(90, 17)
        Me.cbBank.Name = "cbBank"
        Me.cbBank.Size = New System.Drawing.Size(145, 24)
        Me.cbBank.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(42, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "Bank :"
        '
        'dtpBankRefDate
        '
        Me.dtpBankRefDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBankRefDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBankRefDate.Location = New System.Drawing.Point(90, 69)
        Me.dtpBankRefDate.Name = "dtpBankRefDate"
        Me.dtpBankRefDate.Size = New System.Drawing.Size(145, 22)
        Me.dtpBankRefDate.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(241, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 24)
        Me.Button1.TabIndex = 128
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 16)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "Check Date :"
        '
        'txtBankRef
        '
        Me.txtBankRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankRef.Location = New System.Drawing.Point(90, 44)
        Me.txtBankRef.Name = "txtBankRef"
        Me.txtBankRef.Size = New System.Drawing.Size(145, 22)
        Me.txtBankRef.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 16)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Check No. :"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(120, 93)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(234, 22)
        Me.txtAmount.TabIndex = 7
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(57, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Amount :"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(431, 174)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 16)
        Me.Label21.TabIndex = 1359
        Me.Label21.Text = "JE No. :"
        '
        'txtRef
        '
        Me.txtRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRef.Location = New System.Drawing.Point(-174, 110)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(155, 22)
        Me.txtRef.TabIndex = 1361
        Me.txtRef.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbCancel, Me.ToolStripSeparator1, Me.tsbCopy, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.tsbPrint, Me.tsbReports, Me.ToolStripSeparator2, Me.tsbPrevious, Me.tsbNext, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(972, 40)
        Me.ToolStrip1.TabIndex = 1362
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
        'tsbCancel
        '
        Me.tsbCancel.AutoSize = False
        Me.tsbCancel.ForeColor = System.Drawing.Color.White
        Me.tsbCancel.Image = Global.jade.My.Resources.Resources.close_icon
        Me.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancel.Name = "tsbCancel"
        Me.tsbCancel.Size = New System.Drawing.Size(50, 35)
        Me.tsbCancel.Text = "Cancel"
        Me.tsbCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'tsbCopy
        '
        Me.tsbCopy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCopyPO})
        Me.tsbCopy.ForeColor = System.Drawing.Color.White
        Me.tsbCopy.Image = Global.jade.My.Resources.Resources.finance_report_infographic_512
        Me.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCopy.Name = "tsbCopy"
        Me.tsbCopy.Size = New System.Drawing.Size(48, 37)
        Me.tsbCopy.Text = "Copy"
        Me.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbCopyPO
        '
        Me.tsbCopyPO.Name = "tsbCopyPO"
        Me.tsbCopyPO.Size = New System.Drawing.Size(114, 22)
        Me.tsbCopyPO.Text = "From SI"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1.Image = Global.jade.My.Resources.Resources.close_icon
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(50, 35)
        Me.ToolStripButton1.Text = "Upload"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'tsbPrint
        '
        Me.tsbPrint.AutoSize = False
        Me.tsbPrint.ForeColor = System.Drawing.Color.White
        Me.tsbPrint.Image = Global.jade.My.Resources.Resources.printer_circle_blue_512
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(50, 35)
        Me.tsbPrint.Text = "Print"
        Me.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbReports
        '
        Me.tsbReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestToolStripMenuItem1})
        Me.tsbReports.ForeColor = System.Drawing.Color.White
        Me.tsbReports.Image = Global.jade.My.Resources.Resources.finance_report_infographic_512
        Me.tsbReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReports.Name = "tsbReports"
        Me.tsbReports.Size = New System.Drawing.Size(60, 37)
        Me.tsbReports.Text = "Reports"
        Me.tsbReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TestToolStripMenuItem1
        '
        Me.TestToolStripMenuItem1.Name = "TestToolStripMenuItem1"
        Me.TestToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.TestToolStripMenuItem1.Text = "Collection List"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
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
        Me.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnSearchVCE)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.txtTransNum)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtVCECode)
        Me.GroupBox1.Controls.Add(Me.cbCollectionType)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.cbPaymentType)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtVCEName)
        Me.GroupBox1.Controls.Add(Me.btnTypeMaintenance)
        Me.GroupBox1.Controls.Add(Me.gbBank)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(957, 204)
        Me.GroupBox1.TabIndex = 1304
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " "
        '
        'btnSearchVCE
        '
        Me.btnSearchVCE.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnSearchVCE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchVCE.Location = New System.Drawing.Point(319, 42)
        Me.btnSearchVCE.Name = "btnSearchVCE"
        Me.btnSearchVCE.Size = New System.Drawing.Size(25, 25)
        Me.btnSearchVCE.TabIndex = 1376
        Me.btnSearchVCE.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(744, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 1375
        Me.Label4.Text = "Doc. Date :"
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(819, 67)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(132, 22)
        Me.txtStatus.TabIndex = 1370
        Me.txtStatus.Text = "Open"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(764, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 1374
        Me.Label3.Text = "Status :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(759, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 1371
        Me.Label5.Text = "OR No. :"
        '
        'dtpDate
        '
        Me.dtpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(819, 42)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(132, 22)
        Me.dtpDate.TabIndex = 1368
        '
        'txtTransNum
        '
        Me.txtTransNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransNum.Location = New System.Drawing.Point(819, 17)
        Me.txtTransNum.Name = "txtTransNum"
        Me.txtTransNum.Size = New System.Drawing.Size(132, 22)
        Me.txtTransNum.TabIndex = 1367
        '
        'btnTypeMaintenance
        '
        Me.btnTypeMaintenance.Location = New System.Drawing.Point(316, 121)
        Me.btnTypeMaintenance.Name = "btnTypeMaintenance"
        Me.btnTypeMaintenance.Size = New System.Drawing.Size(38, 23)
        Me.btnTypeMaintenance.TabIndex = 1355
        Me.btnTypeMaintenance.Text = ">>"
        Me.btnTypeMaintenance.UseVisualStyleBackColor = True
        '
        'frmCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(972, 590)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cbRef)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.ListOR)
        Me.Controls.Add(Me.tcCollection)
        Me.Controls.Add(Me.lvctrlist)
        Me.Controls.Add(Me.cmdCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCollection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collection"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcCollection.ResumeLayout(False)
        Me.tpCollection.ResumeLayout(False)
        Me.tpCollection.PerformLayout()
        CType(Me.dgvEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBank.ResumeLayout(false)
        Me.gbBank.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txtVCECode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lvctrlist As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tcCollection As System.Windows.Forms.TabControl
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents ListOR As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpCollection As System.Windows.Forms.TabPage
    Friend WithEvents ColumnHeader48 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbCollectionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbRef As System.Windows.Forms.ComboBox
    Friend WithEvents cbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents gbBank As System.Windows.Forms.GroupBox
    Friend WithEvents cbBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpBankRefDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBankRef As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dgvEntry As System.Windows.Forms.DataGridView
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCopy As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsbCopyPO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbReports As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TestToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTransNum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSearchVCE As System.Windows.Forms.Button
    Friend WithEvents btnTypeMaintenance As System.Windows.Forms.Button
    Friend WithEvents chAccntCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chAccntTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVCECode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVCEName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chParticulars As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
