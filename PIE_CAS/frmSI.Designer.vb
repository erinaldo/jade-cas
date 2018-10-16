<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSI))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
        Me.txtTransNum = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDue = New System.Windows.Forms.DateTimePicker()
        Me.chkVAT = New System.Windows.Forms.CheckBox()
        Me.chkVATInc = New System.Windows.Forms.CheckBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbDefaultAcc = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNet = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGross = New System.Windows.Forms.TextBox()
        Me.txtSORef = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnSearchVCE = New System.Windows.Forms.Button()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpItems = New System.Windows.Forms.TabPage()
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
        Me.tpEntries = New System.Windows.Forms.TabPage()
        Me.dgvEntry = New System.Windows.Forms.DataGridView()
        Me.chAccntCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chAccntTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chParticulars = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVCECode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVCEName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpItems.SuspendLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpEntries.SuspendLayout()
        CType(Me.dgvEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(948, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 16)
        Me.Label9.TabIndex = 1294
        Me.Label9.Text = "SO Ref. :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(936, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Doc. Date :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(956, 68)
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
        Me.dtpDocDate.Location = New System.Drawing.Point(1016, 39)
        Me.dtpDocDate.Name = "dtpDocDate"
        Me.dtpDocDate.Size = New System.Drawing.Size(132, 22)
        Me.dtpDocDate.TabIndex = 16
        '
        'txtTransNum
        '
        Me.txtTransNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransNum.Location = New System.Drawing.Point(1016, 13)
        Me.txtTransNum.Name = "txtTransNum"
        Me.txtTransNum.Size = New System.Drawing.Size(132, 22)
        Me.txtTransNum.TabIndex = 44
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(958, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "SI No. :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpDue)
        Me.GroupBox1.Controls.Add(Me.chkVAT)
        Me.GroupBox1.Controls.Add(Me.chkVATInc)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cbDefaultAcc)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtDiscount)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtNet)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtVAT)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtGross)
        Me.GroupBox1.Controls.Add(Me.txtSORef)
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.btnSearchVCE)
        Me.GroupBox1.Controls.Add(Me.txtVCEName)
        Me.GroupBox1.Controls.Add(Me.txtVCECode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpDocDate)
        Me.GroupBox1.Controls.Add(Me.txtTransNum)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1154, 153)
        Me.GroupBox1.TabIndex = 1313
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 1385
        Me.Label2.Text = "Due Date :"
        '
        'dtpDue
        '
        Me.dtpDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDue.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDue.Location = New System.Drawing.Point(112, 120)
        Me.dtpDue.Name = "dtpDue"
        Me.dtpDue.Size = New System.Drawing.Size(132, 22)
        Me.dtpDue.TabIndex = 1386
        '
        'chkVAT
        '
        Me.chkVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkVAT.AutoSize = True
        Me.chkVAT.Checked = True
        Me.chkVAT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVAT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVAT.Location = New System.Drawing.Point(732, 63)
        Me.chkVAT.Name = "chkVAT"
        Me.chkVAT.Size = New System.Drawing.Size(73, 20)
        Me.chkVAT.TabIndex = 1384
        Me.chkVAT.Text = "VATable"
        Me.chkVAT.UseVisualStyleBackColor = True
        Me.chkVAT.Visible = False
        '
        'chkVATInc
        '
        Me.chkVATInc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkVATInc.AutoSize = True
        Me.chkVATInc.Checked = True
        Me.chkVATInc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVATInc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVATInc.Location = New System.Drawing.Point(807, 63)
        Me.chkVATInc.Margin = New System.Windows.Forms.Padding(4)
        Me.chkVATInc.Name = "chkVATInc"
        Me.chkVATInc.Size = New System.Drawing.Size(103, 20)
        Me.chkVATInc.TabIndex = 1383
        Me.chkVATInc.Text = "VAT Inclusive"
        Me.chkVATInc.UseVisualStyleBackColor = True
        Me.chkVATInc.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(112, 65)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(338, 51)
        Me.txtRemarks.TabIndex = 1380
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(40, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 1382
        Me.Label11.Text = "Remarks :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(486, 115)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 32)
        Me.Label14.TabIndex = 1379
        Me.Label14.Text = "Default " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CR Account :"
        '
        'cbDefaultAcc
        '
        Me.cbDefaultAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDefaultAcc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDefaultAcc.FormattingEnabled = True
        Me.cbDefaultAcc.Items.AddRange(New Object() {"Goods", "Services"})
        Me.cbDefaultAcc.Location = New System.Drawing.Point(575, 120)
        Me.cbDefaultAcc.Name = "cbDefaultAcc"
        Me.cbDefaultAcc.Size = New System.Drawing.Size(369, 24)
        Me.cbDefaultAcc.TabIndex = 1378
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(505, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 16)
        Me.Label13.TabIndex = 1376
        Me.Label13.Text = "Discount :"
        '
        'txtDiscount
        '
        Me.txtDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.Location = New System.Drawing.Point(575, 39)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.ReadOnly = True
        Me.txtDiscount.Size = New System.Drawing.Size(151, 22)
        Me.txtDiscount.TabIndex = 1377
        Me.txtDiscount.Text = "0.00"
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(488, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 16)
        Me.Label12.TabIndex = 1374
        Me.Label12.Text = "Net Invoice :"
        '
        'txtNet
        '
        Me.txtNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNet.Location = New System.Drawing.Point(575, 91)
        Me.txtNet.Name = "txtNet"
        Me.txtNet.ReadOnly = True
        Me.txtNet.Size = New System.Drawing.Size(151, 22)
        Me.txtNet.TabIndex = 1375
        Me.txtNet.Text = "0.00"
        Me.txtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(482, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 16)
        Me.Label10.TabIndex = 1372
        Me.Label10.Text = "VAT Amount :"
        '
        'txtVAT
        '
        Me.txtVAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVAT.Location = New System.Drawing.Point(575, 65)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.ReadOnly = True
        Me.txtVAT.Size = New System.Drawing.Size(151, 22)
        Me.txtVAT.TabIndex = 1373
        Me.txtVAT.Text = "0.00"
        Me.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(512, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 1370
        Me.Label6.Text = "Amount :"
        '
        'txtGross
        '
        Me.txtGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGross.Location = New System.Drawing.Point(575, 13)
        Me.txtGross.Name = "txtGross"
        Me.txtGross.ReadOnly = True
        Me.txtGross.Size = New System.Drawing.Size(151, 22)
        Me.txtGross.TabIndex = 1371
        Me.txtGross.Text = "0.00"
        Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSORef
        '
        Me.txtSORef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSORef.Enabled = False
        Me.txtSORef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtSORef.Location = New System.Drawing.Point(1016, 91)
        Me.txtSORef.Name = "txtSORef"
        Me.txtSORef.Size = New System.Drawing.Size(132, 22)
        Me.txtSORef.TabIndex = 1368
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(1016, 65)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(132, 22)
        Me.txtStatus.TabIndex = 1362
        Me.txtStatus.Text = "Open"
        '
        'btnSearchVCE
        '
        Me.btnSearchVCE.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnSearchVCE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchVCE.Location = New System.Drawing.Point(453, 12)
        Me.btnSearchVCE.Name = "btnSearchVCE"
        Me.btnSearchVCE.Size = New System.Drawing.Size(25, 25)
        Me.btnSearchVCE.TabIndex = 1317
        Me.btnSearchVCE.UseVisualStyleBackColor = True
        '
        'txtVCEName
        '
        Me.txtVCEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCEName.Location = New System.Drawing.Point(112, 38)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.Size = New System.Drawing.Size(338, 22)
        Me.txtVCEName.TabIndex = 1316
        '
        'txtVCECode
        '
        Me.txtVCECode.Enabled = False
        Me.txtVCECode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCECode.Location = New System.Drawing.Point(112, 13)
        Me.txtVCECode.Name = "txtVCECode"
        Me.txtVCECode.Size = New System.Drawing.Size(338, 22)
        Me.txtVCECode.TabIndex = 1315
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 1313
        Me.Label1.Text = "Customer Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 1314
        Me.Label3.Text = "Customer Code :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbCancel, Me.ToolStripSeparator1, Me.tsbCopy, Me.ToolStripSeparator4, Me.tsbPrint, Me.tsbReports, Me.ToolStripSeparator2, Me.tsbPrevious, Me.tsbNext, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1167, 40)
        Me.ToolStrip1.TabIndex = 1318
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
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpItems)
        Me.TabControl1.Controls.Add(Me.tpEntries)
        Me.TabControl1.Location = New System.Drawing.Point(0, 199)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1167, 404)
        Me.TabControl1.TabIndex = 1319
        '
        'tpItems
        '
        Me.tpItems.Controls.Add(Me.dgvItemList)
        Me.tpItems.Location = New System.Drawing.Point(4, 24)
        Me.tpItems.Name = "tpItems"
        Me.tpItems.Padding = New System.Windows.Forms.Padding(3)
        Me.tpItems.Size = New System.Drawing.Size(1159, 376)
        Me.tpItems.TabIndex = 1
        Me.tpItems.Text = "Item List"
        Me.tpItems.UseVisualStyleBackColor = True
        '
        'dgvItemList
        '
        Me.dgvItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chItemCode, Me.chItemDesc, Me.chUOM, Me.chQTY, Me.chUnitPrice, Me.chGross, Me.chDiscountRate, Me.chDiscount, Me.chVATAmount, Me.chNetAmount, Me.chVAT})
        Me.dgvItemList.Location = New System.Drawing.Point(0, 3)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.RowHeadersWidth = 25
        Me.dgvItemList.Size = New System.Drawing.Size(1156, 358)
        Me.dgvItemList.TabIndex = 1311
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
        Me.chUOM.ReadOnly = True
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
        Me.chUnitPrice.ReadOnly = True
        '
        'chGross
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.chGross.DefaultCellStyle = DataGridViewCellStyle2
        Me.chGross.HeaderText = "Gross Price"
        Me.chGross.Name = "chGross"
        Me.chGross.ReadOnly = True
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
        Me.chVATAmount.ReadOnly = True
        Me.chVATAmount.Width = 80
        '
        'chNetAmount
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.chNetAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.chNetAmount.HeaderText = "Net Price"
        Me.chNetAmount.Name = "chNetAmount"
        Me.chNetAmount.ReadOnly = True
        '
        'chVAT
        '
        Me.chVAT.HeaderText = "VAT"
        Me.chVAT.Name = "chVAT"
        Me.chVAT.Width = 30
        '
        'tpEntries
        '
        Me.tpEntries.Controls.Add(Me.dgvEntry)
        Me.tpEntries.Controls.Add(Me.txtTotalCredit)
        Me.tpEntries.Controls.Add(Me.txtTotalDebit)
        Me.tpEntries.Controls.Add(Me.Label15)
        Me.tpEntries.Location = New System.Drawing.Point(4, 24)
        Me.tpEntries.Name = "tpEntries"
        Me.tpEntries.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEntries.Size = New System.Drawing.Size(1159, 376)
        Me.tpEntries.TabIndex = 0
        Me.tpEntries.Text = "Accounting Entries"
        Me.tpEntries.UseVisualStyleBackColor = True
        '
        'dgvEntry
        '
        Me.dgvEntry.AllowUserToAddRows = False
        Me.dgvEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chAccntCode, Me.chAccntTitle, Me.chDebit, Me.chCredit, Me.chParticulars, Me.chVCECode, Me.chVCEName})
        Me.dgvEntry.Location = New System.Drawing.Point(0, 0)
        Me.dgvEntry.Name = "dgvEntry"
        Me.dgvEntry.ReadOnly = True
        Me.dgvEntry.RowHeadersWidth = 25
        Me.dgvEntry.Size = New System.Drawing.Size(1158, 341)
        Me.dgvEntry.TabIndex = 76
        '
        'chAccntCode
        '
        Me.chAccntCode.HeaderText = "Code"
        Me.chAccntCode.Name = "chAccntCode"
        Me.chAccntCode.ReadOnly = True
        '
        'chAccntTitle
        '
        Me.chAccntTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.chAccntTitle.HeaderText = "Account Title"
        Me.chAccntTitle.Name = "chAccntTitle"
        Me.chAccntTitle.ReadOnly = True
        '
        'chDebit
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.chDebit.DefaultCellStyle = DataGridViewCellStyle4
        Me.chDebit.HeaderText = "Debit"
        Me.chDebit.Name = "chDebit"
        Me.chDebit.ReadOnly = True
        '
        'chCredit
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.chCredit.DefaultCellStyle = DataGridViewCellStyle5
        Me.chCredit.HeaderText = "Credit"
        Me.chCredit.Name = "chCredit"
        Me.chCredit.ReadOnly = True
        '
        'chParticulars
        '
        Me.chParticulars.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.chParticulars.HeaderText = "Particulars"
        Me.chParticulars.Name = "chParticulars"
        Me.chParticulars.ReadOnly = True
        '
        'chVCECode
        '
        Me.chVCECode.HeaderText = "VCECode"
        Me.chVCECode.Name = "chVCECode"
        Me.chVCECode.ReadOnly = True
        Me.chVCECode.Visible = False
        '
        'chVCEName
        '
        Me.chVCEName.HeaderText = "VCEName"
        Me.chVCEName.Name = "chVCEName"
        Me.chVCEName.ReadOnly = True
        Me.chVCEName.Visible = False
        Me.chVCEName.Width = 200
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCredit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(540, 347)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.Size = New System.Drawing.Size(100, 22)
        Me.txtTotalCredit.TabIndex = 96
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(436, 347)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.Size = New System.Drawing.Size(100, 22)
        Me.txtTotalDebit.TabIndex = 97
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(385, 350)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 16)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Total:"
        '
        'frmSI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1167, 604)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(969, 590)
        Me.Name = "frmSI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpItems.ResumeLayout(False)
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpEntries.ResumeLayout(False)
        Me.tpEntries.PerformLayout()
        CType(Me.dgvEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTransNum As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents btnSearchVCE As System.Windows.Forms.Button
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents txtVCECode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtSORef As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbDefaultAcc As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNet As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpEntries As System.Windows.Forms.TabPage
    Friend WithEvents dgvEntry As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tpItems As System.Windows.Forms.TabPage
    Friend WithEvents chAccntCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chAccntTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chParticulars As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVCECode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVCEName As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents chkVAT As System.Windows.Forms.CheckBox
    Friend WithEvents chkVATInc As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDue As System.Windows.Forms.DateTimePicker
End Class
