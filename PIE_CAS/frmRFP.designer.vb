<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRFP
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRFP))
        Me.txtTransNum = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtInputVAT = New System.Windows.Forms.TextBox()
        Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
        Me.dgvRecords = New System.Windows.Forms.DataGridView()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbPayee = New System.Windows.Forms.GroupBox()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnSearchVCE = New System.Windows.Forms.Button()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditEntriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrint = New System.Windows.Forms.ToolStripSplitButton()
        Me.PrintRFPDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintRFPSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TestToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbSettings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrevious = New System.Windows.Forms.ToolStripButton()
        Me.tsbNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.txtBaseAmount = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.gbSub = New System.Windows.Forms.GroupBox()
        Me.lvSubtotal = New System.Windows.Forms.ListView()
        Me.dgcSubGroup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgcSubAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgcSubVAT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgcSubBase = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbGroup = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbBank = New System.Windows.Forms.GroupBox()
        Me.cbBank = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpBankRefDate = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBankRefAmount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBankRef = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkEWT = New System.Windows.Forms.CheckBox()
        Me.dgcBranch = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgcDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVCECode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcPayee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVAT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcEWT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcCategory = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgcEWTRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgcParticulars = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcInputVAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEWTamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEWTAmount = New System.Windows.Forms.TextBox()
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPayee.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.gbSub.SuspendLayout()
        Me.gbBank.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTransNum
        '
        Me.txtTransNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransNum.Location = New System.Drawing.Point(1003, 13)
        Me.txtTransNum.Name = "txtTransNum"
        Me.txtTransNum.Size = New System.Drawing.Size(132, 22)
        Me.txtTransNum.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(869, 433)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 16)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Total Input VAT :"
        '
        'txtInputVAT
        '
        Me.txtInputVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInputVAT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInputVAT.Location = New System.Drawing.Point(974, 430)
        Me.txtInputVAT.Name = "txtInputVAT"
        Me.txtInputVAT.ReadOnly = True
        Me.txtInputVAT.Size = New System.Drawing.Size(170, 22)
        Me.txtInputVAT.TabIndex = 97
        Me.txtInputVAT.TabStop = False
        Me.txtInputVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDocDate
        '
        Me.dtpDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDocDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDocDate.Location = New System.Drawing.Point(1003, 38)
        Me.dtpDocDate.Name = "dtpDocDate"
        Me.dtpDocDate.Size = New System.Drawing.Size(132, 22)
        Me.dtpDocDate.TabIndex = 8
        '
        'dgvRecords
        '
        Me.dgvRecords.AllowUserToAddRows = False
        Me.dgvRecords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcBranch, Me.dgcDate, Me.dgcRefNo, Me.dgcVCECode, Me.dgcPayee, Me.dgcOR, Me.dgcTIN, Me.dgcAmount, Me.dgcVAT, Me.dgcEWT, Me.dgcCategory, Me.dgcEWTRate, Me.dgcType, Me.dgcParticulars, Me.dgcInputVAT, Me.dgcBase, Me.dgcEWTamt})
        Me.dgvRecords.Location = New System.Drawing.Point(0, 177)
        Me.dgvRecords.MultiSelect = False
        Me.dgvRecords.Name = "dgvRecords"
        Me.dgvRecords.RowHeadersWidth = 25
        Me.dgvRecords.Size = New System.Drawing.Size(1155, 221)
        Me.dgvRecords.TabIndex = 21
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(567, 13)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(335, 103)
        Me.txtRemarks.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(497, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 16)
        Me.Label10.TabIndex = 108
        Me.Label10.Text = "Remarks :"
        '
        'gbPayee
        '
        Me.gbPayee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPayee.Controls.Add(Me.txtPeriod)
        Me.gbPayee.Controls.Add(Me.chkEWT)
        Me.gbPayee.Controls.Add(Me.Label4)
        Me.gbPayee.Controls.Add(Me.Label16)
        Me.gbPayee.Controls.Add(Me.btnSearchVCE)
        Me.gbPayee.Controls.Add(Me.txtVCEName)
        Me.gbPayee.Controls.Add(Me.txtVCECode)
        Me.gbPayee.Controls.Add(Me.Label2)
        Me.gbPayee.Controls.Add(Me.Label3)
        Me.gbPayee.Controls.Add(Me.txtStatus)
        Me.gbPayee.Controls.Add(Me.Label15)
        Me.gbPayee.Controls.Add(Me.Label13)
        Me.gbPayee.Controls.Add(Me.Label9)
        Me.gbPayee.Controls.Add(Me.Label10)
        Me.gbPayee.Controls.Add(Me.txtRemarks)
        Me.gbPayee.Controls.Add(Me.cbBranch)
        Me.gbPayee.Controls.Add(Me.Label22)
        Me.gbPayee.Controls.Add(Me.dtpDocDate)
        Me.gbPayee.Controls.Add(Me.txtTransNum)
        Me.gbPayee.Location = New System.Drawing.Point(8, 40)
        Me.gbPayee.Name = "gbPayee"
        Me.gbPayee.Size = New System.Drawing.Size(1141, 131)
        Me.gbPayee.TabIndex = 47
        Me.gbPayee.TabStop = False
        '
        'txtPeriod
        '
        Me.txtPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.Location = New System.Drawing.Point(110, 94)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(338, 22)
        Me.txtPeriod.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 16)
        Me.Label4.TabIndex = 1370
        Me.Label4.Text = "Period Covered :"
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
        Me.txtStatus.Location = New System.Drawing.Point(1003, 63)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(132, 22)
        Me.txtStatus.TabIndex = 9
        Me.txtStatus.Text = "Open"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(943, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 16)
        Me.Label15.TabIndex = 1355
        Me.Label15.Text = "Status :"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(923, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 16)
        Me.Label13.TabIndex = 1346
        Me.Label13.Text = "Doc. Date :"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(931, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 1345
        Me.Label9.Text = "RFP No. :"
        '
        'cbBranch
        '
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(110, 66)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(265, 24)
        Me.cbBranch.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(51, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(57, 16)
        Me.Label22.TabIndex = 140
        Me.Label22.Text = "Branch :"
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(974, 404)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(170, 22)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TabStop = False
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(880, 407)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 1348
        Me.Label1.Text = "Total Amount :"
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbCancel, Me.ToolStripSeparator1, Me.tsbPrint, Me.tsbReports, Me.tsbSettings, Me.ToolStripSeparator2, Me.tsbPrevious, Me.tsbNext, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1155, 40)
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
        'tsbPrint
        '
        Me.tsbPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintRFPDetailsToolStripMenuItem, Me.PrintRFPSummaryToolStripMenuItem})
        Me.tsbPrint.ForeColor = System.Drawing.Color.White
        Me.tsbPrint.Image = Global.jade.My.Resources.Resources.printer_circle_blue_512
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(48, 37)
        Me.tsbPrint.Text = "Print"
        Me.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PrintRFPDetailsToolStripMenuItem
        '
        Me.PrintRFPDetailsToolStripMenuItem.Name = "PrintRFPDetailsToolStripMenuItem"
        Me.PrintRFPDetailsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PrintRFPDetailsToolStripMenuItem.Text = "Print RFP VAT Relief"
        '
        'PrintRFPSummaryToolStripMenuItem
        '
        Me.PrintRFPSummaryToolStripMenuItem.Name = "PrintRFPSummaryToolStripMenuItem"
        Me.PrintRFPSummaryToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PrintRFPSummaryToolStripMenuItem.Text = "Print RFP Summary"
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
        Me.TestToolStripMenuItem1.Size = New System.Drawing.Size(115, 22)
        Me.TestToolStripMenuItem1.Text = "RFP List"
        '
        'tsbSettings
        '
        Me.tsbSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.tsbSettings.ForeColor = System.Drawing.Color.White
        Me.tsbSettings.Image = Global.jade.My.Resources.Resources.finance_report_infographic_512
        Me.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSettings.Name = "tsbSettings"
        Me.tsbSettings.Size = New System.Drawing.Size(62, 37)
        Me.tsbSettings.Text = "Settings"
        Me.tsbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(122, 22)
        Me.ToolStripMenuItem1.Text = "RFP Type"
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
        'txtBaseAmount
        '
        Me.txtBaseAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBaseAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseAmount.Location = New System.Drawing.Point(974, 456)
        Me.txtBaseAmount.Name = "txtBaseAmount"
        Me.txtBaseAmount.ReadOnly = True
        Me.txtBaseAmount.Size = New System.Drawing.Size(170, 22)
        Me.txtBaseAmount.TabIndex = 96
        Me.txtBaseAmount.TabStop = False
        Me.txtBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(846, 459)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(125, 16)
        Me.Label20.TabIndex = 129
        Me.Label20.Text = "Total Base Amount :"
        '
        'gbSub
        '
        Me.gbSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbSub.Controls.Add(Me.lvSubtotal)
        Me.gbSub.Controls.Add(Me.cbGroup)
        Me.gbSub.Controls.Add(Me.Label5)
        Me.gbSub.Location = New System.Drawing.Point(16, 404)
        Me.gbSub.Name = "gbSub"
        Me.gbSub.Size = New System.Drawing.Size(486, 145)
        Me.gbSub.TabIndex = 1349
        Me.gbSub.TabStop = False
        Me.gbSub.Text = "Subtotal"
        '
        'lvSubtotal
        '
        Me.lvSubtotal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.dgcSubGroup, Me.dgcSubAmount, Me.dgcSubVAT, Me.dgcSubBase})
        Me.lvSubtotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lvSubtotal.FullRowSelect = True
        Me.lvSubtotal.Location = New System.Drawing.Point(3, 45)
        Me.lvSubtotal.MultiSelect = False
        Me.lvSubtotal.Name = "lvSubtotal"
        Me.lvSubtotal.Size = New System.Drawing.Size(480, 97)
        Me.lvSubtotal.TabIndex = 1350
        Me.lvSubtotal.UseCompatibleStateImageBehavior = False
        Me.lvSubtotal.View = System.Windows.Forms.View.Details
        '
        'dgcSubGroup
        '
        Me.dgcSubGroup.Text = "Group"
        Me.dgcSubGroup.Width = 202
        '
        'dgcSubAmount
        '
        Me.dgcSubAmount.Text = "Gross"
        Me.dgcSubAmount.Width = 104
        '
        'dgcSubVAT
        '
        Me.dgcSubVAT.Text = "InputVAT"
        Me.dgcSubVAT.Width = 91
        '
        'dgcSubBase
        '
        Me.dgcSubBase.Text = "Base"
        Me.dgcSubBase.Width = 94
        '
        'cbGroup
        '
        Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroup.FormattingEnabled = True
        Me.cbGroup.Items.AddRange(New Object() {"CV No.", "Date", "Payee", "O.R.#", "Type", "Category", "VAT"})
        Me.cbGroup.Location = New System.Drawing.Point(115, 15)
        Me.cbGroup.Name = "cbGroup"
        Me.cbGroup.Size = New System.Drawing.Size(366, 24)
        Me.cbGroup.TabIndex = 1350
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(50, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 1351
        Me.Label5.Text = "Sum by :"
        '
        'gbBank
        '
        Me.gbBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbBank.Controls.Add(Me.cbBank)
        Me.gbBank.Controls.Add(Me.Label12)
        Me.gbBank.Controls.Add(Me.dtpBankRefDate)
        Me.gbBank.Controls.Add(Me.Button3)
        Me.gbBank.Controls.Add(Me.Label11)
        Me.gbBank.Controls.Add(Me.txtBankRefAmount)
        Me.gbBank.Controls.Add(Me.Label7)
        Me.gbBank.Controls.Add(Me.txtBankRef)
        Me.gbBank.Controls.Add(Me.Label14)
        Me.gbBank.Location = New System.Drawing.Point(508, 404)
        Me.gbBank.Name = "gbBank"
        Me.gbBank.Size = New System.Drawing.Size(332, 142)
        Me.gbBank.TabIndex = 1350
        Me.gbBank.TabStop = False
        Me.gbBank.Text = "Bank Details"
        '
        'cbBank
        '
        Me.cbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBank.FormattingEnabled = True
        Me.cbBank.Location = New System.Drawing.Point(93, 18)
        Me.cbBank.Name = "cbBank"
        Me.cbBank.Size = New System.Drawing.Size(200, 24)
        Me.cbBank.TabIndex = 10
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
        'dtpBankRefDate
        '
        Me.dtpBankRefDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBankRefDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBankRefDate.Location = New System.Drawing.Point(93, 70)
        Me.dtpBankRefDate.Name = "dtpBankRefDate"
        Me.dtpBankRefDate.Size = New System.Drawing.Size(200, 22)
        Me.dtpBankRefDate.TabIndex = 13
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(295, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 28)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = ">>"
        Me.Button3.UseVisualStyleBackColor = True
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
        'txtBankRefAmount
        '
        Me.txtBankRefAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankRefAmount.Location = New System.Drawing.Point(93, 95)
        Me.txtBankRefAmount.Name = "txtBankRefAmount"
        Me.txtBankRefAmount.ReadOnly = True
        Me.txtBankRefAmount.Size = New System.Drawing.Size(200, 22)
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
        'txtBankRef
        '
        Me.txtBankRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankRef.Location = New System.Drawing.Point(93, 45)
        Me.txtBankRef.Name = "txtBankRef"
        Me.txtBankRef.Size = New System.Drawing.Size(200, 22)
        Me.txtBankRef.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 16)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "Check No. :"
        '
        'chkEWT
        '
        Me.chkEWT.AutoSize = True
        Me.chkEWT.Location = New System.Drawing.Point(381, 69)
        Me.chkEWT.Name = "chkEWT"
        Me.chkEWT.Size = New System.Drawing.Size(67, 19)
        Me.chkEWT.TabIndex = 1351
        Me.chkEWT.Text = "w/ EWT"
        Me.chkEWT.UseVisualStyleBackColor = True
        '
        'dgcBranch
        '
        Me.dgcBranch.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.dgcBranch.HeaderText = "Branch Code"
        Me.dgcBranch.Name = "dgcBranch"
        Me.dgcBranch.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcBranch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcBranch.Visible = False
        Me.dgcBranch.Width = 50
        '
        'dgcDate
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.dgcDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcDate.HeaderText = "Date (mm/dd/yyyy)"
        Me.dgcDate.Name = "dgcDate"
        Me.dgcDate.Width = 80
        '
        'dgcRefNo
        '
        Me.dgcRefNo.HeaderText = "CV No."
        Me.dgcRefNo.Name = "dgcRefNo"
        Me.dgcRefNo.Width = 70
        '
        'dgcVCECode
        '
        Me.dgcVCECode.HeaderText = "VCECode"
        Me.dgcVCECode.Name = "dgcVCECode"
        Me.dgcVCECode.Visible = False
        '
        'dgcPayee
        '
        Me.dgcPayee.HeaderText = "Payee"
        Me.dgcPayee.Name = "dgcPayee"
        Me.dgcPayee.Width = 300
        '
        'dgcOR
        '
        Me.dgcOR.HeaderText = "O.R.#"
        Me.dgcOR.Name = "dgcOR"
        '
        'dgcTIN
        '
        Me.dgcTIN.HeaderText = "TIN"
        Me.dgcTIN.Name = "dgcTIN"
        Me.dgcTIN.Width = 120
        '
        'dgcAmount
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.dgcAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgcAmount.HeaderText = "Amount"
        Me.dgcAmount.Name = "dgcAmount"
        Me.dgcAmount.Width = 80
        '
        'dgcVAT
        '
        Me.dgcVAT.HeaderText = "VAT"
        Me.dgcVAT.Name = "dgcVAT"
        Me.dgcVAT.Width = 40
        '
        'dgcEWT
        '
        Me.dgcEWT.HeaderText = "EWT"
        Me.dgcEWT.Name = "dgcEWT"
        Me.dgcEWT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcEWT.Visible = False
        Me.dgcEWT.Width = 40
        '
        'dgcCategory
        '
        Me.dgcCategory.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.dgcCategory.HeaderText = "EWT Cat."
        Me.dgcCategory.Name = "dgcCategory"
        Me.dgcCategory.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcCategory.Width = 50
        '
        'dgcEWTRate
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.dgcEWTRate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgcEWTRate.HeaderText = "EWTrate"
        Me.dgcEWTRate.Name = "dgcEWTRate"
        Me.dgcEWTRate.Visible = False
        '
        'dgcType
        '
        Me.dgcType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.dgcType.HeaderText = "Type"
        Me.dgcType.Name = "dgcType"
        Me.dgcType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcType.Width = 180
        '
        'dgcParticulars
        '
        Me.dgcParticulars.HeaderText = "Particulars"
        Me.dgcParticulars.Name = "dgcParticulars"
        Me.dgcParticulars.Width = 150
        '
        'dgcInputVAT
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.dgcInputVAT.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgcInputVAT.HeaderText = "InputVAT"
        Me.dgcInputVAT.Name = "dgcInputVAT"
        Me.dgcInputVAT.ReadOnly = True
        Me.dgcInputVAT.Width = 80
        '
        'dgcBase
        '
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.dgcBase.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgcBase.HeaderText = "Base Amount"
        Me.dgcBase.Name = "dgcBase"
        Me.dgcBase.ReadOnly = True
        Me.dgcBase.Width = 80
        '
        'dgcEWTamt
        '
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.dgcEWTamt.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgcEWTamt.HeaderText = "EWT Amt."
        Me.dgcEWTamt.Name = "dgcEWTamt"
        Me.dgcEWTamt.ReadOnly = True
        Me.dgcEWTamt.Visible = False
        Me.dgcEWTamt.Width = 80
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(894, 486)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 1352
        Me.Label6.Text = "Total EWT :"
        '
        'txtEWTAmount
        '
        Me.txtEWTAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEWTAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEWTAmount.Location = New System.Drawing.Point(974, 482)
        Me.txtEWTAmount.Name = "txtEWTAmount"
        Me.txtEWTAmount.ReadOnly = True
        Me.txtEWTAmount.Size = New System.Drawing.Size(170, 22)
        Me.txtEWTAmount.TabIndex = 1351
        Me.txtEWTAmount.TabStop = False
        Me.txtEWTAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmRFP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1155, 561)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEWTAmount)
        Me.Controls.Add(Me.gbBank)
        Me.Controls.Add(Me.gbSub)
        Me.Controls.Add(Me.txtInputVAT)
        Me.Controls.Add(Me.dgvRecords)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gbPayee)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtBaseAmount)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRFP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request for Payment "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPayee.ResumeLayout(False)
        Me.gbPayee.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbSub.ResumeLayout(False)
        Me.gbSub.PerformLayout()
        Me.gbBank.ResumeLayout(False)
        Me.gbBank.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTransNum As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInputVAT As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvRecords As System.Windows.Forms.DataGridView
    Friend WithEvents gbPayee As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBaseAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tsbSettings As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PrintRFPDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintRFPSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbReports As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TestToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbSub As System.Windows.Forms.GroupBox
    Friend WithEvents lvSubtotal As System.Windows.Forms.ListView
    Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgcSubGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgcSubAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgcSubVAT As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgcSubBase As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbBank As System.Windows.Forms.GroupBox
    Friend WithEvents cbBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpBankRefDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBankRefAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBankRef As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkEWT As System.Windows.Forms.CheckBox
    Friend WithEvents dgcBranch As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgcDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcRefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVCECode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPayee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVAT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcEWT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcCategory As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgcEWTRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgcParticulars As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcInputVAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEWTamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEWTAmount As System.Windows.Forms.TextBox
End Class
