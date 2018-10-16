<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBS_Software
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
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpBSDate = New System.Windows.Forms.DateTimePicker()
        Me.lvForBilling = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chBillAmount = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chBalance = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.txtContract = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.chkDP = New System.Windows.Forms.CheckBox()
        Me.nupYear = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCopy = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsbCopyPO = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSORef = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSearchVCE = New System.Windows.Forms.Button()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
        Me.txtTransNum = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvItemList = New System.Windows.Forms.DataGridView()
        Me.chItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chItemDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chGross = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDiscountRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVATAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chNetAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVAT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.nupYear,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        CType(Me.dgvItemList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDate.Location = New System.Drawing.Point(614, 36)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(103, 21)
        Me.dtpDueDate.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(545, 38)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Due Date :"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(551, 17)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "BS Date :"
        '
        'dtpBSDate
        '
        Me.dtpBSDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBSDate.Location = New System.Drawing.Point(614, 12)
        Me.dtpBSDate.Name = "dtpBSDate"
        Me.dtpBSDate.Size = New System.Drawing.Size(103, 21)
        Me.dtpBSDate.TabIndex = 20
        '
        'lvForBilling
        '
        Me.lvForBilling.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lvForBilling.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chID, Me.chName, Me.chType, Me.chBillAmount, Me.chBalance})
        Me.lvForBilling.FullRowSelect = true
        Me.lvForBilling.Location = New System.Drawing.Point(3, 3)
        Me.lvForBilling.MultiSelect = false
        Me.lvForBilling.Name = "lvForBilling"
        Me.lvForBilling.Size = New System.Drawing.Size(1115, 320)
        Me.lvForBilling.TabIndex = 26
        Me.lvForBilling.UseCompatibleStateImageBehavior = false
        Me.lvForBilling.View = System.Windows.Forms.View.Details
        '
        'chID
        '
        Me.chID.Text = "ID"
        Me.chID.Width = 53
        '
        'chName
        '
        Me.chName.Text = "Client"
        Me.chName.Width = 251
        '
        'chType
        '
        Me.chType.Text = "Type"
        Me.chType.Width = 146
        '
        'chBillAmount
        '
        Me.chBillAmount.Text = "Amount"
        Me.chBillAmount.Width = 129
        '
        'chBalance
        '
        Me.chBalance.Text = "Balance"
        Me.chBalance.Width = 134
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(751, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 30)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Contract Masterfile"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(324, 108)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Type :"
        '
        'txtPeriod
        '
        Me.txtPeriod.Location = New System.Drawing.Point(364, 130)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(137, 21)
        Me.txtPeriod.TabIndex = 34
        '
        'txtContract
        '
        Me.txtContract.Location = New System.Drawing.Point(789, 20)
        Me.txtContract.Name = "txtContract"
        Me.txtContract.Size = New System.Drawing.Size(78, 21)
        Me.txtContract.TabIndex = 64
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(716, 22)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 15)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Contract ID :"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = true
        Me.cbType.Items.AddRange(New Object() {"Installment", "Progressive Billing"})
        Me.cbType.Location = New System.Drawing.Point(364, 105)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(196, 23)
        Me.cbType.TabIndex = 63
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(614, 58)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(188, 21)
        Me.txtPrice.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(568, 61)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 15)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Price :"
        '
        'txtVAT
        '
        Me.txtVAT.Location = New System.Drawing.Point(614, 81)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(188, 21)
        Me.txtVAT.TabIndex = 59
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(572, 84)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 15)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "VAT :"
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(526, 105)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 15)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Total Amount :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(614, 103)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(188, 21)
        Me.txtTotal.TabIndex = 61
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = true
        Me.lblPercent.Location = New System.Drawing.Point(276, 132)
        Me.lblPercent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(93, 15)
        Me.lblPercent.TabIndex = 54
        Me.lblPercent.Text = " Completion % :"
        '
        'chkDP
        '
        Me.chkDP.AutoSize = true
        Me.chkDP.Location = New System.Drawing.Point(506, 130)
        Me.chkDP.Name = "chkDP"
        Me.chkDP.Size = New System.Drawing.Size(43, 19)
        Me.chkDP.TabIndex = 53
        Me.chkDP.Text = "DP"
        Me.chkDP.UseVisualStyleBackColor = true
        '
        'nupYear
        '
        Me.nupYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.nupYear.Location = New System.Drawing.Point(679, 63)
        Me.nupYear.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nupYear.Name = "nupYear"
        Me.nupYear.Size = New System.Drawing.Size(61, 22)
        Me.nupYear.TabIndex = 1281
        Me.nupYear.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.Label8.Location = New System.Drawing.Point(471, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 17)
        Me.Label8.TabIndex = 1279
        Me.Label8.Text = "Billing Period :"
        '
        'cbMonth
        '
        Me.cbMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cbMonth.FormattingEnabled = true
        Me.cbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "November", "December"})
        Me.cbMonth.Location = New System.Drawing.Point(570, 62)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(106, 24)
        Me.cbMonth.TabIndex = 1280
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = false
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbCancel, Me.ToolStripSeparator1, Me.tsbCopy, Me.ToolStripSeparator4, Me.tsbPrint, Me.tsbReports, Me.ToolStripSeparator2, Me.tsbPrevious, Me.tsbNext, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1141, 40)
        Me.ToolStrip1.TabIndex = 1318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSearch
        '
        Me.tsbSearch.AutoSize = false
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
        Me.tsbCopyPO.Size = New System.Drawing.Size(120, 22)
        Me.tsbCopyPO.Text = "From SO"
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
        Me.tsbReports.Visible = False
        '
        'TestToolStripMenuItem1
        '
        Me.TestToolStripMenuItem1.Name = "TestToolStripMenuItem1"
        Me.TestToolStripMenuItem1.Size = New System.Drawing.Size(110, 22)
        Me.TestToolStripMenuItem1.Text = "DR List"
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cbType)
        Me.GroupBox2.Controls.Add(Me.txtContract)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtSORef)
        Me.GroupBox2.Controls.Add(Me.lblPercent)
        Me.GroupBox2.Controls.Add(Me.nupYear)
        Me.GroupBox2.Controls.Add(Me.chkDP)
        Me.GroupBox2.Controls.Add(Me.txtPrice)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtVAT)
        Me.GroupBox2.Controls.Add(Me.txtPeriod)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbMonth)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtStatus)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.txtRemarks)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.btnSearchVCE)
        Me.GroupBox2.Controls.Add(Me.txtVCEName)
        Me.GroupBox2.Controls.Add(Me.txtVCECode)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.dtpDocDate)
        Me.GroupBox2.Controls.Add(Me.txtTransNum)
        Me.GroupBox2.Controls.Add(Me.dtpDueDate)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.dtpBSDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 43)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1121, 165)
        Me.GroupBox2.TabIndex = 1319
        Me.GroupBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(915, 93)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 16)
        Me.Label12.TabIndex = 1319
        Me.Label12.Text = "SO Ref. :"
        '
        'txtSORef
        '
        Me.txtSORef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSORef.Enabled = False
        Me.txtSORef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtSORef.Location = New System.Drawing.Point(983, 90)
        Me.txtSORef.Name = "txtSORef"
        Me.txtSORef.Size = New System.Drawing.Size(132, 22)
        Me.txtSORef.TabIndex = 1320
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(923, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 16)
        Me.Label13.TabIndex = 1317
        Me.Label13.Text = "Status :"
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(983, 64)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(132, 22)
        Me.txtStatus.TabIndex = 1318
        Me.txtStatus.Text = "Open"
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(112, 89)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(338, 51)
        Me.txtRemarks.TabIndex = 1316
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(38, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 16)
        Me.Label14.TabIndex = 1315
        Me.Label14.Text = "Remarks :"
        '
        'btnSearchVCE
        '
        Me.btnSearchVCE.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnSearchVCE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchVCE.Location = New System.Drawing.Point(456, 12)
        Me.btnSearchVCE.Name = "btnSearchVCE"
        Me.btnSearchVCE.Size = New System.Drawing.Size(25, 25)
        Me.btnSearchVCE.TabIndex = 1312
        Me.btnSearchVCE.UseVisualStyleBackColor = true
        '
        'txtVCEName
        '
        Me.txtVCEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtVCEName.Location = New System.Drawing.Point(112, 38)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.Size = New System.Drawing.Size(338, 22)
        Me.txtVCEName.TabIndex = 1311
        '
        'txtVCECode
        '
        Me.txtVCECode.Enabled = false
        Me.txtVCECode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtVCECode.Location = New System.Drawing.Point(112, 13)
        Me.txtVCECode.Name = "txtVCECode"
        Me.txtVCECode.Size = New System.Drawing.Size(338, 22)
        Me.txtVCECode.TabIndex = 1310
        '
        'Label16
        '
        Me.Label16.AutoSize = true
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label16.Location = New System.Drawing.Point(2, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 16)
        Me.Label16.TabIndex = 1308
        Me.Label16.Text = "Customer Name :"
        '
        'Label17
        '
        Me.Label17.AutoSize = true
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(106, 16)
        Me.Label17.TabIndex = 1309
        Me.Label17.Text = "Customer Code :"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = true
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label18.Location = New System.Drawing.Point(912, 41)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 16)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "DR Date :"
        '
        'dtpDocDate
        '
        Me.dtpDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.dtpDocDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDocDate.Location = New System.Drawing.Point(983, 38)
        Me.dtpDocDate.Name = "dtpDocDate"
        Me.dtpDocDate.Size = New System.Drawing.Size(132, 22)
        Me.dtpDocDate.TabIndex = 16
        '
        'txtTransNum
        '
        Me.txtTransNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTransNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTransNum.Location = New System.Drawing.Point(983, 12)
        Me.txtTransNum.Name = "txtTransNum"
        Me.txtTransNum.Size = New System.Drawing.Size(132, 22)
        Me.txtTransNum.TabIndex = 44
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = true
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label19.Location = New System.Drawing.Point(919, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 16)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "BS No. :"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 214)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1141, 360)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvItemList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1133, 332)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvForBilling)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1133, 332)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'dgvItemList
        '
        Me.dgvItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chItemCode, Me.chItemDesc, Me.chUOM, Me.chQTY, Me.chUnitPrice, Me.chGross, Me.chDiscountRate, Me.chDiscount, Me.chVATAmount, Me.chNetAmount, Me.chVAT})
        Me.dgvItemList.Location = New System.Drawing.Point(0, 0)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.RowHeadersWidth = 25
        Me.dgvItemList.Size = New System.Drawing.Size(1133, 311)
        Me.dgvItemList.TabIndex = 1312
        '
        'chItemCode
        '
        Me.chItemCode.HeaderText = "ItemCode"
        Me.chItemCode.Name = "chItemCode"
        '
        'chItemDesc
        '
        Me.chItemDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.chItemDesc.HeaderText = "Item Description"
        Me.chItemDesc.Name = "chItemDesc"
        '
        'chUOM
        '
        Me.chUOM.HeaderText = "UOM"
        Me.chUOM.Name = "chUOM"
        Me.chUOM.ReadOnly = true
        Me.chUOM.Width = 70
        '
        'chQTY
        '
        Me.chQTY.HeaderText = "Quantity"
        Me.chQTY.Name = "chQTY"
        Me.chQTY.Width = 60
        '
        'chUnitPrice
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.chUnitPrice.DefaultCellStyle = DataGridViewCellStyle1
        Me.chUnitPrice.HeaderText = "Unit Price"
        Me.chUnitPrice.Name = "chUnitPrice"
        Me.chUnitPrice.ReadOnly = true
        '
        'chGross
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.chGross.DefaultCellStyle = DataGridViewCellStyle2
        Me.chGross.HeaderText = "Gross Price"
        Me.chGross.Name = "chGross"
        Me.chGross.ReadOnly = true
        '
        'chDiscountRate
        '
        Me.chDiscountRate.HeaderText = "Disc. Rate (%)"
        Me.chDiscountRate.Name = "chDiscountRate"
        Me.chDiscountRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chDiscountRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.chDiscountRate.Width = 70
        '
        'chDiscount
        '
        Me.chDiscount.HeaderText = "Discount"
        Me.chDiscount.Name = "chDiscount"
        '
        'chVATAmount
        '
        Me.chVATAmount.HeaderText = "VAT Amount"
        Me.chVATAmount.Name = "chVATAmount"
        Me.chVATAmount.ReadOnly = true
        Me.chVATAmount.Width = 80
        '
        'chNetAmount
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.chNetAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.chNetAmount.HeaderText = "Net Price"
        Me.chNetAmount.Name = "chNetAmount"
        Me.chNetAmount.ReadOnly = true
        '
        'chVAT
        '
        Me.chVAT.HeaderText = "VAT"
        Me.chVAT.Name = "chVAT"
        Me.chVAT.Width = 30
        '
        'frmBS_Software
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1141, 578)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBS_Software"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billing Statement"
        CType(Me.nupYear,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        CType(Me.dgvItemList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpBSDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvForBilling As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents chkDP As System.Windows.Forms.CheckBox
    Friend WithEvents nupYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBillAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBalance As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtContract As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSORef As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnSearchVCE As System.Windows.Forms.Button
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents txtVCECode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTransNum As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents chItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chItemDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chGross As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDiscountRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVATAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chNetAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVAT As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
