<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoan_Maintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoan_Maintenance))
        Me.lvLoanType = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.txtLoanType = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPeriod = New System.Windows.Forms.ComboBox()
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.nupTerms = New System.Windows.Forms.NumericUpDown()
        Me.txtAccntTitle = New System.Windows.Forms.TextBox()
        Me.txtAccntCode = New System.Windows.Forms.TextBox()
        Me.chkCash_Voucher = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPayment = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbMethod = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvCharges = New System.Windows.Forms.DataGridView()
        Me.dgcID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcMethod = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgcAmmort = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcAccount = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.chAll = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.chLocked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.gbInfo.SuspendLayout()
        CType(Me.nupTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvLoanType
        '
        Me.lvLoanType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvLoanType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chID, Me.chType})
        Me.lvLoanType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvLoanType.FullRowSelect = True
        Me.lvLoanType.HideSelection = False
        Me.lvLoanType.Location = New System.Drawing.Point(12, 48)
        Me.lvLoanType.MultiSelect = False
        Me.lvLoanType.Name = "lvLoanType"
        Me.lvLoanType.Size = New System.Drawing.Size(245, 567)
        Me.lvLoanType.TabIndex = 0
        Me.lvLoanType.UseCompatibleStateImageBehavior = False
        Me.lvLoanType.View = System.Windows.Forms.View.Details
        '
        'chID
        '
        Me.chID.Text = "Loan_ID"
        Me.chID.Width = 0
        '
        'chType
        '
        Me.chType.Text = "Loan Type"
        Me.chType.Width = 245
        '
        'txtLoanType
        '
        Me.txtLoanType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanType.Location = New System.Drawing.Point(163, 19)
        Me.txtLoanType.Name = "txtLoanType"
        Me.txtLoanType.Size = New System.Drawing.Size(357, 21)
        Me.txtLoanType.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(87, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 1385
        Me.Label7.Text = "Loan Type :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 15)
        Me.Label1.TabIndex = 1389
        Me.Label1.Text = "Interest Period :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 15)
        Me.Label2.TabIndex = 1388
        Me.Label2.Text = "Default Terms (in Months) :"
        '
        'cbPeriod
        '
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriod.FormattingEnabled = True
        Me.cbPeriod.Items.AddRange(New Object() {"Monthly", "Quarterly", "Annually"})
        Me.cbPeriod.Location = New System.Drawing.Point(163, 89)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.Size = New System.Drawing.Size(357, 23)
        Me.cbPeriod.TabIndex = 6
        '
        'gbInfo
        '
        Me.gbInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbInfo.Controls.Add(Me.nupTerms)
        Me.gbInfo.Controls.Add(Me.txtAccntTitle)
        Me.gbInfo.Controls.Add(Me.txtAccntCode)
        Me.gbInfo.Controls.Add(Me.chkCash_Voucher)
        Me.gbInfo.Controls.Add(Me.Label6)
        Me.gbInfo.Controls.Add(Me.cbCategory)
        Me.gbInfo.Controls.Add(Me.txtDescription)
        Me.gbInfo.Controls.Add(Me.Label5)
        Me.gbInfo.Controls.Add(Me.Label4)
        Me.gbInfo.Controls.Add(Me.cbPayment)
        Me.gbInfo.Controls.Add(Me.Label3)
        Me.gbInfo.Controls.Add(Me.cbMethod)
        Me.gbInfo.Controls.Add(Me.Label12)
        Me.gbInfo.Controls.Add(Me.cbPeriod)
        Me.gbInfo.Controls.Add(Me.txtLoanType)
        Me.gbInfo.Controls.Add(Me.Label7)
        Me.gbInfo.Controls.Add(Me.Label2)
        Me.gbInfo.Controls.Add(Me.Label1)
        Me.gbInfo.Location = New System.Drawing.Point(263, 43)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Size = New System.Drawing.Size(899, 239)
        Me.gbInfo.TabIndex = 1403
        Me.gbInfo.TabStop = False
        '
        'nupTerms
        '
        Me.nupTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.nupTerms.Location = New System.Drawing.Point(163, 115)
        Me.nupTerms.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.nupTerms.Name = "nupTerms"
        Me.nupTerms.Size = New System.Drawing.Size(105, 21)
        Me.nupTerms.TabIndex = 1429
        Me.nupTerms.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtAccntTitle
        '
        Me.txtAccntTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccntTitle.ForeColor = System.Drawing.Color.Black
        Me.txtAccntTitle.Location = New System.Drawing.Point(269, 191)
        Me.txtAccntTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccntTitle.Name = "txtAccntTitle"
        Me.txtAccntTitle.Size = New System.Drawing.Size(251, 20)
        Me.txtAccntTitle.TabIndex = 1427
        '
        'txtAccntCode
        '
        Me.txtAccntCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccntCode.Enabled = False
        Me.txtAccntCode.ForeColor = System.Drawing.Color.Black
        Me.txtAccntCode.Location = New System.Drawing.Point(163, 191)
        Me.txtAccntCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccntCode.Name = "txtAccntCode"
        Me.txtAccntCode.Size = New System.Drawing.Size(105, 20)
        Me.txtAccntCode.TabIndex = 1428
        '
        'chkCash_Voucher
        '
        Me.chkCash_Voucher.AutoSize = True
        Me.chkCash_Voucher.Location = New System.Drawing.Point(163, 43)
        Me.chkCash_Voucher.Name = "chkCash_Voucher"
        Me.chkCash_Voucher.Size = New System.Drawing.Size(93, 17)
        Me.chkCash_Voucher.TabIndex = 1426
        Me.chkCash_Voucher.Text = "Cash Voucher"
        Me.chkCash_Voucher.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(59, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 15)
        Me.Label6.TabIndex = 1425
        Me.Label6.Text = "Default Account :"
        '
        'cbCategory
        '
        Me.cbCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(163, 63)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(357, 23)
        Me.cbCategory.TabIndex = 1423
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(535, 63)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(324, 148)
        Me.txtDescription.TabIndex = 1421
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(532, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 30)
        Me.Label5.TabIndex = 1422
        Me.Label5.Text = "Loan " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(96, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 1420
        Me.Label4.Text = "Category :"
        '
        'cbPayment
        '
        Me.cbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPayment.FormattingEnabled = True
        Me.cbPayment.Items.AddRange(New Object() {"Over the Counter", "Salary Deduction", "PDC", "OTC", "ONLINE", "ADA"})
        Me.cbPayment.Location = New System.Drawing.Point(163, 165)
        Me.cbPayment.Name = "cbPayment"
        Me.cbPayment.Size = New System.Drawing.Size(357, 23)
        Me.cbPayment.TabIndex = 1417
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 15)
        Me.Label3.TabIndex = 1418
        Me.Label3.Text = "Default Payment Method :"
        '
        'cbMethod
        '
        Me.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMethod.FormattingEnabled = True
        Me.cbMethod.Items.AddRange(New Object() {"Straight Line", "Diminishing Balance"})
        Me.cbMethod.Location = New System.Drawing.Point(163, 139)
        Me.cbMethod.Name = "cbMethod"
        Me.cbMethod.Size = New System.Drawing.Size(357, 23)
        Me.cbMethod.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 142)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 15)
        Me.Label12.TabIndex = 1404
        Me.Label12.Text = "Ammortization Method :"
        '
        'dgvCharges
        '
        Me.dgvCharges.AllowUserToAddRows = False
        Me.dgvCharges.AllowUserToDeleteRows = False
        Me.dgvCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcID, Me.chInclude, Me.dgcType, Me.dgcValue, Me.dgcMethod, Me.dgcAmmort, Me.dgcAccount, Me.chAll, Me.chLocked})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCharges.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCharges.Location = New System.Drawing.Point(263, 288)
        Me.dgvCharges.Name = "dgvCharges"
        Me.dgvCharges.RowHeadersWidth = 25
        Me.dgvCharges.Size = New System.Drawing.Size(899, 327)
        Me.dgvCharges.TabIndex = 1404
        '
        'dgcID
        '
        Me.dgcID.HeaderText = "ID"
        Me.dgcID.Name = "dgcID"
        Me.dgcID.Visible = False
        '
        'chInclude
        '
        Me.chInclude.HeaderText = "Inc."
        Me.chInclude.Name = "chInclude"
        Me.chInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.chInclude.Width = 30
        '
        'dgcType
        '
        Me.dgcType.HeaderText = "Type"
        Me.dgcType.Name = "dgcType"
        Me.dgcType.ReadOnly = True
        Me.dgcType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcType.Width = 120
        '
        'dgcValue
        '
        Me.dgcValue.HeaderText = "Value"
        Me.dgcValue.Name = "dgcValue"
        Me.dgcValue.Width = 150
        '
        'dgcMethod
        '
        Me.dgcMethod.HeaderText = "Method"
        Me.dgcMethod.Name = "dgcMethod"
        Me.dgcMethod.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgcAmmort
        '
        Me.dgcAmmort.HeaderText = "Ammortize"
        Me.dgcAmmort.Name = "dgcAmmort"
        Me.dgcAmmort.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcAmmort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcAmmort.Width = 60
        '
        'dgcAccount
        '
        Me.dgcAccount.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.dgcAccount.HeaderText = "Default_Account"
        Me.dgcAccount.Name = "dgcAccount"
        Me.dgcAccount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcAccount.Width = 250
        '
        'chAll
        '
        Me.chAll.HeaderText = "All"
        Me.chAll.Name = "chAll"
        Me.chAll.Visible = False
        '
        'chLocked
        '
        Me.chLocked.HeaderText = "Locked"
        Me.chLocked.Name = "chLocked"
        Me.chLocked.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbReports, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1174, 40)
        Me.ToolStrip1.TabIndex = 1405
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'frmLoan_Maintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1174, 627)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgvCharges)
        Me.Controls.Add(Me.gbInfo)
        Me.Controls.Add(Me.lvLoanType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLoan_Maintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Maintenance"
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        CType(Me.nupTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents lvLoanType As System.Windows.Forms.ListView
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtLoanType As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents gbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbMethod As System.Windows.Forms.ComboBox
    Friend WithEvents cbPayment As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvCharges As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgcID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMethod As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgcAmmort As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcAccount As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents chAll As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chLocked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkCash_Voucher As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbReports As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents nupTerms As System.Windows.Forms.NumericUpDown
End Class
