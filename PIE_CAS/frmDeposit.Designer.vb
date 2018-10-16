<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdeposit
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpDepositDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnPrintDepSlip = New System.Windows.Forms.Button()
        Me.dgvPendingList = New System.Windows.Forms.DataGridView()
        Me.lnkClose = New System.Windows.Forms.LinkLabel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbBank = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDepositType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.lblGrandtotal = New System.Windows.Forms.Label()
        Me.dgvDenomination = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDepositNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvTransid = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepositDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBankName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbDepositMonth = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nupDepositYear = New System.Windows.Forms.NumericUpDown()
        Me.txtTotalDeposit = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dgvPendingList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDenomination, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupDepositYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDepositDate
        '
        Me.dtpDepositDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDepositDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDepositDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDepositDate.Location = New System.Drawing.Point(489, 65)
        Me.dtpDepositDate.Name = "dtpDepositDate"
        Me.dtpDepositDate.Size = New System.Drawing.Size(409, 22)
        Me.dtpDepositDate.TabIndex = 586
        '
        'btnSelect
        '
        Me.btnSelect.BackColor = System.Drawing.Color.Transparent
        Me.btnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSelect.Location = New System.Drawing.Point(16, 53)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(134, 32)
        Me.btnSelect.TabIndex = 584
        Me.btnSelect.Text = "Select All"
        Me.btnSelect.UseVisualStyleBackColor = False
        '
        'btnPrintDepSlip
        '
        Me.btnPrintDepSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDepSlip.BackColor = System.Drawing.Color.DimGray
        Me.btnPrintDepSlip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintDepSlip.ForeColor = System.Drawing.Color.White
        Me.btnPrintDepSlip.Location = New System.Drawing.Point(233, 697)
        Me.btnPrintDepSlip.Name = "btnPrintDepSlip"
        Me.btnPrintDepSlip.Size = New System.Drawing.Size(194, 34)
        Me.btnPrintDepSlip.TabIndex = 583
        Me.btnPrintDepSlip.Text = "Print Deposit Slip"
        Me.btnPrintDepSlip.UseVisualStyleBackColor = False
        '
        'dgvPendingList
        '
        Me.dgvPendingList.AllowUserToAddRows = False
        Me.dgvPendingList.AllowUserToDeleteRows = False
        Me.dgvPendingList.AllowUserToOrderColumns = True
        Me.dgvPendingList.AllowUserToResizeColumns = False
        Me.dgvPendingList.AllowUserToResizeRows = False
        Me.dgvPendingList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPendingList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPendingList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPendingList.Location = New System.Drawing.Point(16, 147)
        Me.dgvPendingList.MultiSelect = False
        Me.dgvPendingList.Name = "dgvPendingList"
        Me.dgvPendingList.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPendingList.RowHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgvPendingList.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPendingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPendingList.Size = New System.Drawing.Size(882, 325)
        Me.dgvPendingList.TabIndex = 582
        '
        'lnkClose
        '
        Me.lnkClose.AutoSize = True
        Me.lnkClose.BackColor = System.Drawing.Color.Transparent
        Me.lnkClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkClose.LinkColor = System.Drawing.Color.Blue
        Me.lnkClose.Location = New System.Drawing.Point(12, 6)
        Me.lnkClose.Name = "lnkClose"
        Me.lnkClose.Size = New System.Drawing.Size(54, 20)
        Me.lnkClose.TabIndex = 594
        Me.lnkClose.TabStop = True
        Me.lnkClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.DimGray
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(16, 697)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(193, 34)
        Me.btnSave.TabIndex = 596
        Me.btnSave.Text = "Save Deposit"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cbBank
        '
        Me.cbBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBank.FormattingEnabled = True
        Me.cbBank.Location = New System.Drawing.Point(489, 117)
        Me.cbBank.Name = "cbBank"
        Me.cbBank.Size = New System.Drawing.Size(409, 24)
        Me.cbBank.TabIndex = 600
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(373, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 20)
        Me.Label1.TabIndex = 601
        Me.Label1.Text = "Deposit Date :"
        '
        'cbDepositType
        '
        Me.cbDepositType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDepositType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepositType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepositType.FormattingEnabled = True
        Me.cbDepositType.Items.AddRange(New Object() {"Cash", "Checks"})
        Me.cbDepositType.Location = New System.Drawing.Point(489, 90)
        Me.cbDepositType.Name = "cbDepositType"
        Me.cbDepositType.Size = New System.Drawing.Size(409, 24)
        Me.cbDepositType.TabIndex = 602
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(373, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 20)
        Me.Label2.TabIndex = 603
        Me.Label2.Text = "Deposit Type :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(429, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 20)
        Me.Label3.TabIndex = 604
        Me.Label3.Text = "Bank :"
        '
        'btnUnselect
        '
        Me.btnUnselect.BackColor = System.Drawing.Color.Transparent
        Me.btnUnselect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnselect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnUnselect.Location = New System.Drawing.Point(156, 53)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(134, 32)
        Me.btnUnselect.TabIndex = 605
        Me.btnUnselect.Text = "Un-Select All"
        Me.btnUnselect.UseVisualStyleBackColor = False
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(659, 509)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(183, 22)
        Me.txtTotalAmount.TabIndex = 606
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(651, 486)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 20)
        Me.Label4.TabIndex = 607
        Me.Label4.Text = "Total Amount For Deposit"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGrandTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(265, 672)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Size = New System.Drawing.Size(162, 22)
        Me.txtGrandTotal.TabIndex = 612
        '
        'lblGrandtotal
        '
        Me.lblGrandtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandtotal.AutoSize = True
        Me.lblGrandtotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandtotal.Location = New System.Drawing.Point(220, 675)
        Me.lblGrandtotal.Name = "lblGrandtotal"
        Me.lblGrandtotal.Size = New System.Drawing.Size(39, 16)
        Me.lblGrandtotal.TabIndex = 611
        Me.lblGrandtotal.Text = "Total:"
        '
        'dgvDenomination
        '
        Me.dgvDenomination.AllowUserToAddRows = False
        Me.dgvDenomination.AllowUserToDeleteRows = False
        Me.dgvDenomination.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDenomination.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDenomination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDenomination.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column2})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDenomination.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDenomination.Location = New System.Drawing.Point(16, 478)
        Me.dgvDenomination.Name = "dgvDenomination"
        Me.dgvDenomination.RowHeadersVisible = False
        Me.dgvDenomination.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDenomination.Size = New System.Drawing.Size(411, 188)
        Me.dgvDenomination.TabIndex = 610
        '
        'Column1
        '
        Me.Column1.HeaderText = "Denomination"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "No of Pieces"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "Amount"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 145
        '
        'txtDepositNo
        '
        Me.txtDepositNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepositNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepositNo.Location = New System.Drawing.Point(776, 12)
        Me.txtDepositNo.Name = "txtDepositNo"
        Me.txtDepositNo.Size = New System.Drawing.Size(122, 22)
        Me.txtDepositNo.TabIndex = 1290
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(686, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 1291
        Me.Label5.Text = "DepositNo"
        '
        'dgvTransid
        '
        Me.dgvTransid.AllowUserToAddRows = False
        Me.dgvTransid.AllowUserToDeleteRows = False
        Me.dgvTransid.AllowUserToResizeColumns = False
        Me.dgvTransid.AllowUserToResizeRows = False
        Me.dgvTransid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTransid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Amount, Me.DepositDate, Me.chBankName})
        Me.dgvTransid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvTransid.Location = New System.Drawing.Point(11, 47)
        Me.dgvTransid.Name = "dgvTransid"
        Me.dgvTransid.RowHeadersVisible = False
        Me.dgvTransid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransid.Size = New System.Drawing.Size(395, 634)
        Me.dgvTransid.TabIndex = 1292
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "TransID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'DepositDate
        '
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DepositDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.DepositDate.HeaderText = "DepositDate"
        Me.DepositDate.Name = "DepositDate"
        '
        'chBankName
        '
        Me.chBankName.HeaderText = "Bank"
        Me.chBankName.Name = "chBankName"
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(72, 113)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(100, 22)
        Me.dtpFrom.TabIndex = 1293
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(241, 112)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(107, 22)
        Me.dtpTo.TabIndex = 1294
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 20)
        Me.Label6.TabIndex = 1295
        Me.Label6.Text = "From :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(200, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 20)
        Me.Label7.TabIndex = 1296
        Me.Label7.Text = "To :"
        '
        'cbDepositMonth
        '
        Me.cbDepositMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepositMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepositMonth.FormattingEnabled = True
        Me.cbDepositMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cbDepositMonth.Location = New System.Drawing.Point(85, 19)
        Me.cbDepositMonth.Name = "cbDepositMonth"
        Me.cbDepositMonth.Size = New System.Drawing.Size(119, 24)
        Me.cbDepositMonth.TabIndex = 1297
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 20)
        Me.Label8.TabIndex = 1298
        Me.Label8.Text = "Month :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(210, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 20)
        Me.Label9.TabIndex = 1299
        Me.Label9.Text = "Year :"
        '
        'nupDepositYear
        '
        Me.nupDepositYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupDepositYear.Location = New System.Drawing.Point(267, 19)
        Me.nupDepositYear.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nupDepositYear.Name = "nupDepositYear"
        Me.nupDepositYear.Size = New System.Drawing.Size(91, 24)
        Me.nupDepositYear.TabIndex = 1300
        Me.nupDepositYear.Value = New Decimal(New Integer() {2016, 0, 0, 0})
        '
        'txtTotalDeposit
        '
        Me.txtTotalDeposit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDeposit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDeposit.Location = New System.Drawing.Point(139, 687)
        Me.txtTotalDeposit.Name = "txtTotalDeposit"
        Me.txtTotalDeposit.ReadOnly = True
        Me.txtTotalDeposit.Size = New System.Drawing.Size(267, 22)
        Me.txtTotalDeposit.TabIndex = 1301
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 689)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 20)
        Me.Label10.TabIndex = 1302
        Me.Label10.Text = "Total Deposit :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvTransid)
        Me.GroupBox1.Controls.Add(Me.cbDepositMonth)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.nupDepositYear)
        Me.GroupBox1.Controls.Add(Me.txtTotalDeposit)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(904, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 715)
        Me.GroupBox1.TabIndex = 1303
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Deposit Sumary"
        '
        'frmdeposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1328, 733)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.txtDepositNo)
        Me.Controls.Add(Me.txtGrandTotal)
        Me.Controls.Add(Me.lblGrandtotal)
        Me.Controls.Add(Me.dgvDenomination)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.btnUnselect)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbDepositType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbBank)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lnkClose)
        Me.Controls.Add(Me.dtpDepositDate)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnPrintDepSlip)
        Me.Controls.Add(Me.dgvPendingList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmdeposit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposit"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvPendingList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDenomination, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupDepositYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnPrintDepSlip As System.Windows.Forms.Button
    Friend WithEvents dgvPendingList As System.Windows.Forms.DataGridView
    Friend WithEvents lnkClose As System.Windows.Forms.LinkLabel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDepositType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUnselect As System.Windows.Forms.Button
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDepositDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblGrandtotal As System.Windows.Forms.Label
    Friend WithEvents dgvDenomination As System.Windows.Forms.DataGridView
    Friend WithEvents txtDepositNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvTransid As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepositDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBankName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbDepositMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nupDepositYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtTotalDeposit As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
