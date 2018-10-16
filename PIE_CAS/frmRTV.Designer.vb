<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRTV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRTV))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsbReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TestToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRWithoutPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrevious = New System.Windows.Forms.ToolStripButton()
        Me.tsbNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.tsbCopy = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsbCopyPO = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSIRef = New System.Windows.Forms.TextBox()
        Me.btnSearchVCE = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPORef = New System.Windows.Forms.TextBox()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDRRef = New System.Windows.Forms.TextBox()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTransNum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.dgvItemList = New System.Windows.Forms.DataGridView()
        Me.chItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chItemDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chWHSE = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FromRRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbCancel, Me.ToolStripSeparator4, Me.tsbCopy, Me.ToolStripSeparator1, Me.tsbPrint, Me.tsbReports, Me.ToolStripSeparator2, Me.tsbPrevious, Me.tsbNext, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(972, 40)
        Me.ToolStrip1.TabIndex = 1305
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
        Me.tsbReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestToolStripMenuItem1, Me.PRWithoutPOToolStripMenuItem})
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
        Me.TestToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.TestToolStripMenuItem1.Text = "PR List"
        '
        'PRWithoutPOToolStripMenuItem
        '
        Me.PRWithoutPOToolStripMenuItem.Name = "PRWithoutPOToolStripMenuItem"
        Me.PRWithoutPOToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PRWithoutPOToolStripMenuItem.Text = "PR without PO"
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
        'tsbCopy
        '
        Me.tsbCopy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCopyPO, Me.FromRRToolStripMenuItem})
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
        Me.tsbCopyPO.Size = New System.Drawing.Size(152, 22)
        Me.tsbCopyPO.Text = "From PO"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpInvoiceDate)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtSIRef)
        Me.GroupBox1.Controls.Add(Me.btnSearchVCE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPORef)
        Me.GroupBox1.Controls.Add(Me.dtpDeliveryDate)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtDRRef)
        Me.GroupBox1.Controls.Add(Me.txtVCEName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtVCECode)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpDocDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTransNum)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(955, 172)
        Me.GroupBox1.TabIndex = 1306
        Me.GroupBox1.TabStop = False
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(349, 87)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(101, 22)
        Me.dtpInvoiceDate.TabIndex = 1311
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(257, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 16)
        Me.Label10.TabIndex = 1310
        Me.Label10.Text = "Invoice Date :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(57, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 16)
        Me.Label8.TabIndex = 1308
        Me.Label8.Text = "SI Ref. :"
        '
        'txtSIRef
        '
        Me.txtSIRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIRef.Location = New System.Drawing.Point(112, 88)
        Me.txtSIRef.Name = "txtSIRef"
        Me.txtSIRef.Size = New System.Drawing.Size(132, 22)
        Me.txtSIRef.TabIndex = 1309
        '
        'btnSearchVCE
        '
        Me.btnSearchVCE.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnSearchVCE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchVCE.Location = New System.Drawing.Point(456, 12)
        Me.btnSearchVCE.Name = "btnSearchVCE"
        Me.btnSearchVCE.Size = New System.Drawing.Size(25, 25)
        Me.btnSearchVCE.TabIndex = 1307
        Me.btnSearchVCE.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(749, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 1300
        Me.Label6.Text = "PO Ref. :"
        '
        'txtPORef
        '
        Me.txtPORef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPORef.Enabled = False
        Me.txtPORef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtPORef.Location = New System.Drawing.Point(817, 90)
        Me.txtPORef.Name = "txtPORef"
        Me.txtPORef.Size = New System.Drawing.Size(132, 22)
        Me.txtPORef.TabIndex = 1301
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(349, 62)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(101, 22)
        Me.dtpDeliveryDate.TabIndex = 1299
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(251, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 16)
        Me.Label9.TabIndex = 1298
        Me.Label9.Text = "Delivery Date :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(51, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 16)
        Me.Label12.TabIndex = 1287
        Me.Label12.Text = "DR Ref. :"
        '
        'txtDRRef
        '
        Me.txtDRRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDRRef.Location = New System.Drawing.Point(112, 63)
        Me.txtDRRef.Name = "txtDRRef"
        Me.txtDRRef.Size = New System.Drawing.Size(132, 22)
        Me.txtDRRef.TabIndex = 1288
        '
        'txtVCEName
        '
        Me.txtVCEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCEName.Location = New System.Drawing.Point(112, 38)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.Size = New System.Drawing.Size(338, 22)
        Me.txtVCEName.TabIndex = 1290
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(746, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "RR Date :"
        '
        'txtVCECode
        '
        Me.txtVCECode.Enabled = False
        Me.txtVCECode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCECode.Location = New System.Drawing.Point(112, 13)
        Me.txtVCECode.Name = "txtVCECode"
        Me.txtVCECode.Size = New System.Drawing.Size(338, 22)
        Me.txtVCECode.TabIndex = 1289
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(112, 113)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(338, 51)
        Me.txtRemarks.TabIndex = 1300
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 1294
        Me.Label2.Text = "Remarks :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(757, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Status :"
        '
        'dtpDocDate
        '
        Me.dtpDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDocDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDocDate.Location = New System.Drawing.Point(817, 38)
        Me.dtpDocDate.Name = "dtpDocDate"
        Me.dtpDocDate.Size = New System.Drawing.Size(132, 22)
        Me.dtpDocDate.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendor Name :"
        '
        'txtTransNum
        '
        Me.txtTransNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransNum.Location = New System.Drawing.Point(817, 12)
        Me.txtTransNum.Name = "txtTransNum"
        Me.txtTransNum.Size = New System.Drawing.Size(132, 22)
        Me.txtTransNum.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Vendor Code :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(753, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "RR No. :"
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(817, 64)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(132, 22)
        Me.txtStatus.TabIndex = 8
        Me.txtStatus.Text = "Open"
        '
        'dgvItemList
        '
        Me.dgvItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chItemCode, Me.chItemDesc, Me.chUOM, Me.chQTY, Me.chUnitCost, Me.chWHSE})
        Me.dgvItemList.Location = New System.Drawing.Point(1, 6)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.RowHeadersWidth = 25
        Me.dgvItemList.Size = New System.Drawing.Size(961, 305)
        Me.dgvItemList.TabIndex = 1307
        '
        'chItemCode
        '
        Me.chItemCode.HeaderText = "ItemCode"
        Me.chItemCode.Name = "chItemCode"
        Me.chItemCode.Width = 80
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
        Me.chUOM.ReadOnly = True
        Me.chUOM.Width = 80
        '
        'chQTY
        '
        Me.chQTY.HeaderText = "Actual Quantity"
        Me.chQTY.Name = "chQTY"
        '
        'chUnitCost
        '
        Me.chUnitCost.HeaderText = "UnitCost"
        Me.chUnitCost.Name = "chUnitCost"
        Me.chUnitCost.Visible = False
        '
        'chWHSE
        '
        Me.chWHSE.HeaderText = "Warehouse"
        Me.chWHSE.Name = "chWHSE"
        Me.chWHSE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chWHSE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.chWHSE.Width = 150
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 221)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(973, 346)
        Me.TabControl1.TabIndex = 1308
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvItemList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(965, 317)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Line Items"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(965, 317)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Credit Memo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FromRRToolStripMenuItem
        '
        Me.FromRRToolStripMenuItem.Name = "FromRRToolStripMenuItem"
        Me.FromRRToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FromRRToolStripMenuItem.Text = "From RR"
        '
        'frmRTV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(972, 567)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmRTV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return to Vendor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbReports As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TestToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRWithoutPOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCopy As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsbCopyPO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSIRef As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchVCE As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPORef As System.Windows.Forms.TextBox
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDRRef As System.Windows.Forms.TextBox
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVCECode As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTransNum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents chItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chItemDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chWHSE As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents FromRRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
