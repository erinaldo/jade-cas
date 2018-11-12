<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoan_Setup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoan_Setup))
        Me.lvLoanType = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtLoanType = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.tcDetails = New System.Windows.Forms.TabControl()
        Me.tpInterest = New System.Windows.Forms.TabPage()
        Me.chkUnearned = New System.Windows.Forms.CheckBox()
        Me.txtIntIncomeTitle = New System.Windows.Forms.TextBox()
        Me.txtIntIncomeCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tpPenalty = New System.Windows.Forms.TabPage()
        Me.tpDeductions = New System.Windows.Forms.TabPage()
        Me.chkAmortize = New System.Windows.Forms.CheckBox()
        Me.txtIntValue = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbIntMethod = New System.Windows.Forms.ComboBox()
        Me.txtUnearnedTitle = New System.Windows.Forms.TextBox()
        Me.txtUnearnedCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIntRecTitle = New System.Windows.Forms.TextBox()
        Me.txtIntRecCode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgcID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcMethod = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgcAmort = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcAccount = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.chAll = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.chLocked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcRangeBasis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcRangeValueType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbInfo.SuspendLayout()
        CType(Me.nupTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.tcDetails.SuspendLayout()
        Me.tpInterest.SuspendLayout()
        Me.tpDeductions.SuspendLayout()
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
        Me.txtLoanType.Location = New System.Drawing.Point(163, 33)
        Me.txtLoanType.Name = "txtLoanType"
        Me.txtLoanType.Size = New System.Drawing.Size(357, 21)
        Me.txtLoanType.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(87, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 1385
        Me.Label7.Text = "Loan Type :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 105)
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
        Me.cbPeriod.Location = New System.Drawing.Point(211, 54)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.Size = New System.Drawing.Size(105, 23)
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
        Me.gbInfo.Controls.Add(Me.txtLoanType)
        Me.gbInfo.Controls.Add(Me.Label7)
        Me.gbInfo.Controls.Add(Me.Label2)
        Me.gbInfo.Location = New System.Drawing.Point(263, 43)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Size = New System.Drawing.Size(899, 220)
        Me.gbInfo.TabIndex = 1403
        Me.gbInfo.TabStop = False
        '
        'nupTerms
        '
        Me.nupTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.nupTerms.Location = New System.Drawing.Point(163, 102)
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
        Me.txtAccntTitle.Location = New System.Drawing.Point(269, 178)
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
        Me.txtAccntCode.Location = New System.Drawing.Point(163, 178)
        Me.txtAccntCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccntCode.Name = "txtAccntCode"
        Me.txtAccntCode.Size = New System.Drawing.Size(105, 20)
        Me.txtAccntCode.TabIndex = 1428
        '
        'chkCash_Voucher
        '
        Me.chkCash_Voucher.AutoSize = True
        Me.chkCash_Voucher.Location = New System.Drawing.Point(163, 57)
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
        Me.Label6.Location = New System.Drawing.Point(59, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 15)
        Me.Label6.TabIndex = 1425
        Me.Label6.Text = "Default Account :"
        '
        'cbCategory
        '
        Me.cbCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(163, 77)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(357, 23)
        Me.cbCategory.TabIndex = 1423
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(535, 50)
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
        Me.Label5.Location = New System.Drawing.Point(532, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 30)
        Me.Label5.TabIndex = 1422
        Me.Label5.Text = "Loan " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(96, 81)
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
        Me.cbPayment.Location = New System.Drawing.Point(163, 152)
        Me.cbPayment.Name = "cbPayment"
        Me.cbPayment.Size = New System.Drawing.Size(357, 23)
        Me.cbPayment.TabIndex = 1417
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 154)
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
        Me.cbMethod.Location = New System.Drawing.Point(163, 126)
        Me.cbMethod.Name = "cbMethod"
        Me.cbMethod.Size = New System.Drawing.Size(357, 23)
        Me.cbMethod.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(31, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 15)
        Me.Label12.TabIndex = 1404
        Me.Label12.Text = "Amortization Method :"
        '
        'dgvCharges
        '
        Me.dgvCharges.AllowUserToAddRows = False
        Me.dgvCharges.AllowUserToDeleteRows = False
        Me.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcID, Me.chInclude, Me.dgcType, Me.dgcValue, Me.dgcMethod, Me.dgcAmort, Me.dgcAccount, Me.chAll, Me.chLocked, Me.dgcRangeBasis, Me.dgcRangeValueType})
        Me.dgvCharges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCharges.Location = New System.Drawing.Point(3, 3)
        Me.dgvCharges.Name = "dgvCharges"
        Me.dgvCharges.RowHeadersWidth = 25
        Me.dgvCharges.Size = New System.Drawing.Size(885, 312)
        Me.dgvCharges.TabIndex = 1404
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbDelete, Me.ToolStripSeparator1, Me.ToolStripDropDownButton1, Me.tsbReports, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
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
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ToolStripDropDownButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripDropDownButton1.Image = Global.jade.My.Resources.Resources.finance_report_infographic_512
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(62, 37)
        Me.ToolStripDropDownButton1.Text = "Settings"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem1.Text = "Default Charges"
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
        'tcDetails
        '
        Me.tcDetails.Controls.Add(Me.tpInterest)
        Me.tcDetails.Controls.Add(Me.tpDeductions)
        Me.tcDetails.Controls.Add(Me.tpPenalty)
        Me.tcDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcDetails.Location = New System.Drawing.Point(263, 269)
        Me.tcDetails.Name = "tcDetails"
        Me.tcDetails.SelectedIndex = 0
        Me.tcDetails.Size = New System.Drawing.Size(899, 346)
        Me.tcDetails.TabIndex = 1406
        '
        'tpInterest
        '
        Me.tpInterest.Controls.Add(Me.txtIntRecTitle)
        Me.tpInterest.Controls.Add(Me.txtIntRecCode)
        Me.tpInterest.Controls.Add(Me.Label11)
        Me.tpInterest.Controls.Add(Me.txtUnearnedTitle)
        Me.tpInterest.Controls.Add(Me.txtUnearnedCode)
        Me.tpInterest.Controls.Add(Me.Label10)
        Me.tpInterest.Controls.Add(Me.cbIntMethod)
        Me.tpInterest.Controls.Add(Me.txtIntValue)
        Me.tpInterest.Controls.Add(Me.Label9)
        Me.tpInterest.Controls.Add(Me.chkAmortize)
        Me.tpInterest.Controls.Add(Me.chkUnearned)
        Me.tpInterest.Controls.Add(Me.txtIntIncomeTitle)
        Me.tpInterest.Controls.Add(Me.txtIntIncomeCode)
        Me.tpInterest.Controls.Add(Me.cbPeriod)
        Me.tpInterest.Controls.Add(Me.Label8)
        Me.tpInterest.Controls.Add(Me.Label1)
        Me.tpInterest.Location = New System.Drawing.Point(4, 24)
        Me.tpInterest.Name = "tpInterest"
        Me.tpInterest.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInterest.Size = New System.Drawing.Size(891, 318)
        Me.tpInterest.TabIndex = 1
        Me.tpInterest.Text = "Interest"
        Me.tpInterest.UseVisualStyleBackColor = True
        '
        'chkUnearned
        '
        Me.chkUnearned.AutoSize = True
        Me.chkUnearned.Location = New System.Drawing.Point(211, 105)
        Me.chkUnearned.Name = "chkUnearned"
        Me.chkUnearned.Size = New System.Drawing.Size(287, 19)
        Me.chkUnearned.TabIndex = 1432
        Me.chkUnearned.Text = "Setup Unearned Interest on Loan Disbursement"
        Me.chkUnearned.UseVisualStyleBackColor = True
        '
        'txtIntIncomeTitle
        '
        Me.txtIntIncomeTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntIncomeTitle.ForeColor = System.Drawing.Color.Black
        Me.txtIntIncomeTitle.Location = New System.Drawing.Point(317, 80)
        Me.txtIntIncomeTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIntIncomeTitle.Name = "txtIntIncomeTitle"
        Me.txtIntIncomeTitle.Size = New System.Drawing.Size(251, 21)
        Me.txtIntIncomeTitle.TabIndex = 1430
        '
        'txtIntIncomeCode
        '
        Me.txtIntIncomeCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntIncomeCode.Enabled = False
        Me.txtIntIncomeCode.ForeColor = System.Drawing.Color.Black
        Me.txtIntIncomeCode.Location = New System.Drawing.Point(211, 80)
        Me.txtIntIncomeCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIntIncomeCode.Name = "txtIntIncomeCode"
        Me.txtIntIncomeCode.Size = New System.Drawing.Size(105, 21)
        Me.txtIntIncomeCode.TabIndex = 1431
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(69, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 15)
        Me.Label8.TabIndex = 1429
        Me.Label8.Text = "Interest Income Account :"
        '
        'tpPenalty
        '
        Me.tpPenalty.Location = New System.Drawing.Point(4, 24)
        Me.tpPenalty.Name = "tpPenalty"
        Me.tpPenalty.Size = New System.Drawing.Size(891, 318)
        Me.tpPenalty.TabIndex = 2
        Me.tpPenalty.Text = "Penalty"
        Me.tpPenalty.UseVisualStyleBackColor = True
        '
        'tpDeductions
        '
        Me.tpDeductions.Controls.Add(Me.dgvCharges)
        Me.tpDeductions.Location = New System.Drawing.Point(4, 24)
        Me.tpDeductions.Name = "tpDeductions"
        Me.tpDeductions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDeductions.Size = New System.Drawing.Size(891, 318)
        Me.tpDeductions.TabIndex = 0
        Me.tpDeductions.Text = "Loan Deductions"
        Me.tpDeductions.UseVisualStyleBackColor = True
        '
        'chkAmortize
        '
        Me.chkAmortize.AutoSize = True
        Me.chkAmortize.Location = New System.Drawing.Point(496, 30)
        Me.chkAmortize.Name = "chkAmortize"
        Me.chkAmortize.Size = New System.Drawing.Size(74, 19)
        Me.chkAmortize.TabIndex = 1433
        Me.chkAmortize.Text = "Amortize"
        Me.chkAmortize.UseVisualStyleBackColor = True
        '
        'txtIntValue
        '
        Me.txtIntValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntValue.Enabled = False
        Me.txtIntValue.ForeColor = System.Drawing.Color.Black
        Me.txtIntValue.Location = New System.Drawing.Point(317, 29)
        Me.txtIntValue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIntValue.Name = "txtIntValue"
        Me.txtIntValue.Size = New System.Drawing.Size(176, 21)
        Me.txtIntValue.TabIndex = 1435
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(70, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(142, 15)
        Me.Label9.TabIndex = 1434
        Me.Label9.Text = "Interest Rate per Period :"
        '
        'cbIntMethod
        '
        Me.cbIntMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIntMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIntMethod.FormattingEnabled = True
        Me.cbIntMethod.Items.AddRange(New Object() {"Percentage", "Range Table", "Formula"})
        Me.cbIntMethod.Location = New System.Drawing.Point(211, 29)
        Me.cbIntMethod.Name = "cbIntMethod"
        Me.cbIntMethod.Size = New System.Drawing.Size(105, 23)
        Me.cbIntMethod.TabIndex = 1436
        '
        'txtUnearnedTitle
        '
        Me.txtUnearnedTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnearnedTitle.ForeColor = System.Drawing.Color.Black
        Me.txtUnearnedTitle.Location = New System.Drawing.Point(317, 124)
        Me.txtUnearnedTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUnearnedTitle.Name = "txtUnearnedTitle"
        Me.txtUnearnedTitle.Size = New System.Drawing.Size(251, 21)
        Me.txtUnearnedTitle.TabIndex = 1438
        '
        'txtUnearnedCode
        '
        Me.txtUnearnedCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnearnedCode.Enabled = False
        Me.txtUnearnedCode.ForeColor = System.Drawing.Color.Black
        Me.txtUnearnedCode.Location = New System.Drawing.Point(211, 124)
        Me.txtUnearnedCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUnearnedCode.Name = "txtUnearnedCode"
        Me.txtUnearnedCode.Size = New System.Drawing.Size(105, 21)
        Me.txtUnearnedCode.TabIndex = 1439
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(54, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(158, 15)
        Me.Label10.TabIndex = 1437
        Me.Label10.Text = "Unearned Income Account :"
        '
        'txtIntRecTitle
        '
        Me.txtIntRecTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntRecTitle.ForeColor = System.Drawing.Color.Black
        Me.txtIntRecTitle.Location = New System.Drawing.Point(317, 146)
        Me.txtIntRecTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIntRecTitle.Name = "txtIntRecTitle"
        Me.txtIntRecTitle.Size = New System.Drawing.Size(251, 21)
        Me.txtIntRecTitle.TabIndex = 1441
        '
        'txtIntRecCode
        '
        Me.txtIntRecCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntRecCode.Enabled = False
        Me.txtIntRecCode.ForeColor = System.Drawing.Color.Black
        Me.txtIntRecCode.Location = New System.Drawing.Point(211, 146)
        Me.txtIntRecCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIntRecCode.Name = "txtIntRecCode"
        Me.txtIntRecCode.Size = New System.Drawing.Size(105, 21)
        Me.txtIntRecCode.TabIndex = 1442
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(95, 149)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 15)
        Me.Label11.TabIndex = 1440
        Me.Label11.Text = "Interest Receivable :"
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
        Me.dgcMethod.Width = 150
        '
        'dgcAmort
        '
        Me.dgcAmort.HeaderText = "Amortize"
        Me.dgcAmort.Name = "dgcAmort"
        Me.dgcAmort.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcAmort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcAmort.Width = 60
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
        'dgcRangeBasis
        '
        Me.dgcRangeBasis.HeaderText = "Basis"
        Me.dgcRangeBasis.Name = "dgcRangeBasis"
        Me.dgcRangeBasis.Visible = False
        '
        'dgcRangeValueType
        '
        Me.dgcRangeValueType.HeaderText = "ValueType"
        Me.dgcRangeValueType.Name = "dgcRangeValueType"
        Me.dgcRangeValueType.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 15)
        Me.Label1.TabIndex = 1389
        Me.Label1.Text = "Interest Period :"
        '
        'frmLoan_Setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1174, 627)
        Me.Controls.Add(Me.tcDetails)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbInfo)
        Me.Controls.Add(Me.lvLoanType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmLoan_Setup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Maintenance"
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        CType(Me.nupTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tcDetails.ResumeLayout(False)
        Me.tpInterest.ResumeLayout(False)
        Me.tpInterest.PerformLayout()
        Me.tpDeductions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvLoanType As System.Windows.Forms.ListView
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtLoanType As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
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
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tcDetails As System.Windows.Forms.TabControl
    Friend WithEvents tpInterest As System.Windows.Forms.TabPage
    Friend WithEvents tpPenalty As System.Windows.Forms.TabPage
    Friend WithEvents tpDeductions As System.Windows.Forms.TabPage
    Friend WithEvents chkUnearned As System.Windows.Forms.CheckBox
    Friend WithEvents txtIntIncomeTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtIntIncomeCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkAmortize As System.Windows.Forms.CheckBox
    Friend WithEvents cbIntMethod As System.Windows.Forms.ComboBox
    Friend WithEvents txtIntValue As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIntRecTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtIntRecCode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtUnearnedTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtUnearnedCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgcID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMethod As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgcAmort As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcAccount As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents chAll As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chLocked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcRangeBasis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcRangeValueType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
