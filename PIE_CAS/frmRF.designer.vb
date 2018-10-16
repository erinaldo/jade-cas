<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRF
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBankRef = New System.Windows.Forms.TextBox()
        Me.txtTransNum = New System.Windows.Forms.TextBox()
        Me.txtBankRefAmount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
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
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpBankRefDate = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.cbBank = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbDisburseType = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtORNo = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.gbPayee = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnUOMGroup = New System.Windows.Forms.Button()
        Me.txtADVRef = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSearchVCE = New System.Windows.Forms.Button()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAPVRef = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbBank = New System.Windows.Forms.GroupBox()
        Me.txtRefStatus = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditEntriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbOption = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CancelCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmUnreleased = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbCopy = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsbCopyAPV = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbCopyADV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrint = New System.Windows.Forms.ToolStripSplitButton()
        Me.PrintRFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChequieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BIR2307ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrevious = New System.Windows.Forms.ToolStripButton()
        Me.tsbNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        CType(Me.dgvEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPayee.SuspendLayout()
        Me.gbBank.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 16)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Check No. :"
        '
        'txtBankRef
        '
        Me.txtBankRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankRef.Location = New System.Drawing.Point(93, 45)
        Me.txtBankRef.Name = "txtBankRef"
        Me.txtBankRef.Size = New System.Drawing.Size(210, 22)
        Me.txtBankRef.TabIndex = 12
        '
        'txtTransNum
        '
        Me.txtTransNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransNum.Location = New System.Drawing.Point(939, 13)
        Me.txtTransNum.Name = "txtTransNum"
        Me.txtTransNum.Size = New System.Drawing.Size(132, 22)
        Me.txtTransNum.TabIndex = 16
        '
        'txtBankRefAmount
        '
        Me.txtBankRefAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankRefAmount.Location = New System.Drawing.Point(93, 95)
        Me.txtBankRefAmount.Name = "txtBankRefAmount"
        Me.txtBankRefAmount.ReadOnly = True
        Me.txtBankRefAmount.Size = New System.Drawing.Size(210, 22)
        Me.txtBankRefAmount.TabIndex = 14
        Me.txtBankRefAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(31, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Amount :"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(276, 536)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Total Debit:"
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(365, 532)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.ReadOnly = True
        Me.txtTotalDebit.Size = New System.Drawing.Size(161, 22)
        Me.txtTotalDebit.TabIndex = 97
        Me.txtTotalDebit.TabStop = False
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCredit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(638, 532)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.ReadOnly = True
        Me.txtTotalCredit.Size = New System.Drawing.Size(161, 22)
        Me.txtTotalCredit.TabIndex = 96
        Me.txtTotalCredit.TabStop = False
        '
        'dtpDocDate
        '
        Me.dtpDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDocDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDocDate.Location = New System.Drawing.Point(939, 38)
        Me.dtpDocDate.Name = "dtpDocDate"
        Me.dtpDocDate.Size = New System.Drawing.Size(132, 22)
        Me.dtpDocDate.TabIndex = 17
        '
        'dgvEntry
        '
        Me.dgvEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chAccntCode, Me.chAccntTitle, Me.chDebit, Me.chCredit, Me.chVCECode, Me.chVCEName, Me.chParticulars, Me.chRef, Me.Column12})
        Me.dgvEntry.Location = New System.Drawing.Point(0, 304)
        Me.dgvEntry.Name = "dgvEntry"
        Me.dgvEntry.RowHeadersWidth = 25
        Me.dgvEntry.Size = New System.Drawing.Size(1091, 217)
        Me.dgvEntry.TabIndex = 21
        '
        'chAccntCode
        '
        Me.chAccntCode.HeaderText = "Account Code"
        Me.chAccntCode.Name = "chAccntCode"
        '
        'chAccntTitle
        '
        Me.chAccntTitle.HeaderText = "Account Title"
        Me.chAccntTitle.Name = "chAccntTitle"
        Me.chAccntTitle.Width = 250
        '
        'chDebit
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "999,999,999.00"
        DataGridViewCellStyle1.NullValue = "0.00"
        Me.chDebit.DefaultCellStyle = DataGridViewCellStyle1
        Me.chDebit.HeaderText = "Debit"
        Me.chDebit.Name = "chDebit"
        '
        'chCredit
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "999,999,999.00"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.chCredit.DefaultCellStyle = DataGridViewCellStyle2
        Me.chCredit.HeaderText = "Credit"
        Me.chCredit.Name = "chCredit"
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
        Me.chRef.HeaderText = "RefNo"
        Me.chRef.Name = "chRef"
        '
        'Column12
        '
        Me.Column12.HeaderText = ">>"
        Me.Column12.Name = "Column12"
        Me.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column12.Width = 50
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(110, 179)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(335, 51)
        Me.txtRemarks.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 189)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 16)
        Me.Label10.TabIndex = 108
        Me.Label10.Text = "Remarks :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 16)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "Check Date :"
        '
        'dtpBankRefDate
        '
        Me.dtpBankRefDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBankRefDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBankRefDate.Location = New System.Drawing.Point(93, 70)
        Me.dtpBankRefDate.Name = "dtpBankRefDate"
        Me.dtpBankRefDate.Size = New System.Drawing.Size(210, 22)
        Me.dtpBankRefDate.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(46, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "Bank :"
        '
        'cbPaymentType
        '
        Me.cbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Items.AddRange(New Object() {"Check", "Cash", "Managers Check", "Debit Memo", "Revolving Fund"})
        Me.cbPaymentType.Location = New System.Drawing.Point(110, 68)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(186, 24)
        Me.cbPaymentType.TabIndex = 4
        '
        'cbBank
        '
        Me.cbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBank.FormattingEnabled = True
        Me.cbBank.Location = New System.Drawing.Point(93, 18)
        Me.cbBank.Name = "cbBank"
        Me.cbBank.Size = New System.Drawing.Size(210, 24)
        Me.cbBank.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(308, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 28)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = ">>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(541, 536)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 16)
        Me.Label20.TabIndex = 129
        Me.Label20.Text = "Total Credit:"
        '
        'cbDisburseType
        '
        Me.cbDisburseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDisburseType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDisburseType.FormattingEnabled = True
        Me.cbDisburseType.Location = New System.Drawing.Point(110, 124)
        Me.cbDisburseType.Name = "cbDisburseType"
        Me.cbDisburseType.Size = New System.Drawing.Size(186, 24)
        Me.cbDisburseType.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(10, 127)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 16)
        Me.Label22.TabIndex = 140
        Me.Label22.Text = "Expense Type :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(39, 149)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 32)
        Me.Label23.TabIndex = 142
        Me.Label23.Text = "Costumer " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OR No. :"
        '
        'txtORNo
        '
        Me.txtORNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNo.Location = New System.Drawing.Point(110, 153)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(186, 22)
        Me.txtORNo.TabIndex = 8
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(9, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(99, 16)
        Me.Label25.TabIndex = 1340
        Me.Label25.Text = "Payment Type :"
        '
        'gbPayee
        '
        Me.gbPayee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPayee.Controls.Add(Me.Label16)
        Me.gbPayee.Controls.Add(Me.btnUOMGroup)
        Me.gbPayee.Controls.Add(Me.txtADVRef)
        Me.gbPayee.Controls.Add(Me.Label14)
        Me.gbPayee.Controls.Add(Me.btnSearchVCE)
        Me.gbPayee.Controls.Add(Me.txtVCEName)
        Me.gbPayee.Controls.Add(Me.txtVCECode)
        Me.gbPayee.Controls.Add(Me.Label2)
        Me.gbPayee.Controls.Add(Me.Label3)
        Me.gbPayee.Controls.Add(Me.txtStatus)
        Me.gbPayee.Controls.Add(Me.Label15)
        Me.gbPayee.Controls.Add(Me.txtAPVRef)
        Me.gbPayee.Controls.Add(Me.Label4)
        Me.gbPayee.Controls.Add(Me.txtAmount)
        Me.gbPayee.Controls.Add(Me.Label1)
        Me.gbPayee.Controls.Add(Me.gbBank)
        Me.gbPayee.Controls.Add(Me.Label13)
        Me.gbPayee.Controls.Add(Me.Label9)
        Me.gbPayee.Controls.Add(Me.txtORNo)
        Me.gbPayee.Controls.Add(Me.Label23)
        Me.gbPayee.Controls.Add(Me.Label10)
        Me.gbPayee.Controls.Add(Me.txtRemarks)
        Me.gbPayee.Controls.Add(Me.cbPaymentType)
        Me.gbPayee.Controls.Add(Me.cbDisburseType)
        Me.gbPayee.Controls.Add(Me.Label22)
        Me.gbPayee.Controls.Add(Me.dtpDocDate)
        Me.gbPayee.Controls.Add(Me.Label25)
        Me.gbPayee.Controls.Add(Me.txtTransNum)
        Me.gbPayee.Location = New System.Drawing.Point(8, 40)
        Me.gbPayee.Name = "gbPayee"
        Me.gbPayee.Size = New System.Drawing.Size(1077, 258)
        Me.gbPayee.TabIndex = 47
        Me.gbPayee.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label16.Location = New System.Drawing.Point(31, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 16)
        Me.Label16.TabIndex = 1368
        Me.Label16.Text = "VCE Code :"
        '
        'btnUOMGroup
        '
        Me.btnUOMGroup.BackgroundImage = Global.jade.My.Resources.Resources._New
        Me.btnUOMGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUOMGroup.Location = New System.Drawing.Point(302, 124)
        Me.btnUOMGroup.Name = "btnUOMGroup"
        Me.btnUOMGroup.Size = New System.Drawing.Size(25, 25)
        Me.btnUOMGroup.TabIndex = 7
        Me.btnUOMGroup.UseVisualStyleBackColor = True
        '
        'txtADVRef
        '
        Me.txtADVRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtADVRef.Enabled = False
        Me.txtADVRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtADVRef.Location = New System.Drawing.Point(939, 113)
        Me.txtADVRef.Name = "txtADVRef"
        Me.txtADVRef.Size = New System.Drawing.Size(132, 22)
        Me.txtADVRef.TabIndex = 20
        Me.txtADVRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(863, 115)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 16)
        Me.Label14.TabIndex = 1366
        Me.Label14.Text = "ADV Ref. :"
        '
        'btnSearchVCE
        '
        Me.btnSearchVCE.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnSearchVCE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchVCE.Location = New System.Drawing.Point(454, 13)
        Me.btnSearchVCE.Name = "btnSearchVCE"
        Me.btnSearchVCE.Size = New System.Drawing.Size(25, 25)
        Me.btnSearchVCE.TabIndex = 2
        Me.btnSearchVCE.UseVisualStyleBackColor = True
        '
        'txtVCEName
        '
        Me.txtVCEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCEName.Location = New System.Drawing.Point(110, 41)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.Size = New System.Drawing.Size(338, 22)
        Me.txtVCEName.TabIndex = 3
        '
        'txtVCECode
        '
        Me.txtVCECode.Enabled = False
        Me.txtVCECode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCECode.Location = New System.Drawing.Point(110, 14)
        Me.txtVCECode.Name = "txtVCECode"
        Me.txtVCECode.Size = New System.Drawing.Size(338, 22)
        Me.txtVCECode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 1360
        Me.Label2.Text = "VCE Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 1361
        Me.Label3.Text = "  "
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(939, 63)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(132, 22)
        Me.txtStatus.TabIndex = 18
        Me.txtStatus.Text = "Open"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(879, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 16)
        Me.Label15.TabIndex = 1355
        Me.Label15.Text = "Status :"
        '
        'txtAPVRef
        '
        Me.txtAPVRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAPVRef.Enabled = False
        Me.txtAPVRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPVRef.Location = New System.Drawing.Point(939, 88)
        Me.txtAPVRef.Name = "txtAPVRef"
        Me.txtAPVRef.Size = New System.Drawing.Size(132, 22)
        Me.txtAPVRef.TabIndex = 19
        Me.txtAPVRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(863, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 1350
        Me.Label4.Text = "APV Ref. :"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(110, 97)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(186, 22)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 1348
        Me.Label1.Text = "Amount :"
        '
        'gbBank
        '
        Me.gbBank.Controls.Add(Me.txtRefStatus)
        Me.gbBank.Controls.Add(Me.Label5)
        Me.gbBank.Controls.Add(Me.cbBank)
        Me.gbBank.Controls.Add(Me.Label12)
        Me.gbBank.Controls.Add(Me.dtpBankRefDate)
        Me.gbBank.Controls.Add(Me.Button3)
        Me.gbBank.Controls.Add(Me.Label11)
        Me.gbBank.Controls.Add(Me.txtBankRefAmount)
        Me.gbBank.Controls.Add(Me.Label7)
        Me.gbBank.Controls.Add(Me.txtBankRef)
        Me.gbBank.Controls.Add(Me.Label6)
        Me.gbBank.Location = New System.Drawing.Point(485, 13)
        Me.gbBank.Name = "gbBank"
        Me.gbBank.Size = New System.Drawing.Size(351, 149)
        Me.gbBank.TabIndex = 10
        Me.gbBank.TabStop = False
        Me.gbBank.Text = "Bank Details"
        '
        'txtRefStatus
        '
        Me.txtRefStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefStatus.Location = New System.Drawing.Point(93, 119)
        Me.txtRefStatus.Name = "txtRefStatus"
        Me.txtRefStatus.ReadOnly = True
        Me.txtRefStatus.Size = New System.Drawing.Size(210, 22)
        Me.txtRefStatus.TabIndex = 15
        Me.txtRefStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "Status :"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(872, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 16)
        Me.Label13.TabIndex = 1346
        Me.Label13.Text = "CV Date :"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(879, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 16)
        Me.Label9.TabIndex = 1345
        Me.Label9.Text = "CV No. :"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditEntriesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 26)
        '
        'EditEntriesToolStripMenuItem
        '
        Me.EditEntriesToolStripMenuItem.Name = "EditEntriesToolStripMenuItem"
        Me.EditEntriesToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.EditEntriesToolStripMenuItem.Text = "Edit Entry"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbCancel, Me.ToolStripSeparator1, Me.tsbOption, Me.tsbCopy, Me.ToolStripSeparator4, Me.tsbPrint, Me.tsbReports, Me.ToolStripSeparator2, Me.tsbPrevious, Me.tsbNext, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1091, 40)
        Me.ToolStrip1.TabIndex = 1344
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
        'tsbOption
        '
        Me.tsbOption.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelCheckToolStripMenuItem, Me.tsmUnreleased})
        Me.tsbOption.ForeColor = System.Drawing.Color.White
        Me.tsbOption.Image = Global.jade.My.Resources.Resources.finance_report_infographic_512
        Me.tsbOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOption.Name = "tsbOption"
        Me.tsbOption.Size = New System.Drawing.Size(57, 37)
        Me.tsbOption.Text = "Option"
        Me.tsbOption.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CancelCheckToolStripMenuItem
        '
        Me.CancelCheckToolStripMenuItem.Name = "CancelCheckToolStripMenuItem"
        Me.CancelCheckToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CancelCheckToolStripMenuItem.Text = "Cancel Cheque"
        '
        'tsmUnreleased
        '
        Me.tsmUnreleased.Enabled = False
        Me.tsmUnreleased.Name = "tsmUnreleased"
        Me.tsmUnreleased.Size = New System.Drawing.Size(157, 22)
        Me.tsmUnreleased.Text = "Release Cheque"
        '
        'tsbCopy
        '
        Me.tsbCopy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCopyAPV, Me.tsbCopyADV})
        Me.tsbCopy.ForeColor = System.Drawing.Color.White
        Me.tsbCopy.Image = Global.jade.My.Resources.Resources.finance_report_infographic_512
        Me.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCopy.Name = "tsbCopy"
        Me.tsbCopy.Size = New System.Drawing.Size(48, 37)
        Me.tsbCopy.Text = "Copy"
        Me.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbCopyAPV
        '
        Me.tsbCopyAPV.Name = "tsbCopyAPV"
        Me.tsbCopyAPV.Size = New System.Drawing.Size(156, 22)
        Me.tsbCopyAPV.Text = "From APV"
        '
        'tsbCopyADV
        '
        Me.tsbCopyADV.Name = "tsbCopyADV"
        Me.tsbCopyADV.Size = New System.Drawing.Size(156, 22)
        Me.tsbCopyADV.Text = "From Advances"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'tsbPrint
        '
        Me.tsbPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintRFToolStripMenuItem, Me.ChequieToolStripMenuItem, Me.BIR2307ToolStripMenuItem})
        Me.tsbPrint.ForeColor = System.Drawing.Color.White
        Me.tsbPrint.Image = Global.jade.My.Resources.Resources.printer_circle_blue_512
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(48, 37)
        Me.tsbPrint.Text = "Print"
        Me.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PrintRFToolStripMenuItem
        '
        Me.PrintRFToolStripMenuItem.Name = "PrintRFToolStripMenuItem"
        Me.PrintRFToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.PrintRFToolStripMenuItem.Text = "Check Voucher"
        '
        'ChequieToolStripMenuItem
        '
        Me.ChequieToolStripMenuItem.Name = "ChequieToolStripMenuItem"
        Me.ChequieToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ChequieToolStripMenuItem.Text = "Check"
        '
        'BIR2307ToolStripMenuItem
        '
        Me.BIR2307ToolStripMenuItem.Name = "BIR2307ToolStripMenuItem"
        Me.BIR2307ToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.BIR2307ToolStripMenuItem.Text = "BIR 2307"
        '
        'tsbReports
        '
        Me.tsbReports.ForeColor = System.Drawing.Color.White
        Me.tsbReports.Image = Global.jade.My.Resources.Resources.finance_report_infographic_512
        Me.tsbReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReports.Name = "tsbReports"
        Me.tsbReports.Size = New System.Drawing.Size(60, 37)
        Me.tsbReports.Text = "Reports"
        Me.tsbReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'frmCV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1091, 561)
        Me.Controls.Add(Me.txtTotalDebit)
        Me.Controls.Add(Me.dgvEntry)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gbPayee)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtTotalCredit)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmCV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disbursement Module"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPayee.ResumeLayout(False)
        Me.gbPayee.PerformLayout()
        Me.gbBank.ResumeLayout(False)
        Me.gbBank.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBankRef As System.Windows.Forms.TextBox
    Friend WithEvents txtTransNum As System.Windows.Forms.TextBox
    Friend WithEvents txtBankRefAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpBankRefDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvEntry As System.Windows.Forms.DataGridView
    Friend WithEvents cbBank As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbDisburseType As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents gbPayee As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gbBank As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAPVRef As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditEntriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCopy As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsbCopyAPV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbReports As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSearchVCE As System.Windows.Forms.Button
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents txtVCECode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tsbCopyADV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chAccntCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chAccntTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVCECode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVCEName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chParticulars As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PrintRFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChequieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BIR2307ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRefStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tsbOption As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmUnreleased As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtADVRef As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnUOMGroup As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
