<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLFinacialReportGenerator
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nupYear = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbFiscal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkPEC = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbDetailed = New System.Windows.Forms.RadioButton()
        Me.rbSummary = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbRefID = New System.Windows.Forms.RadioButton()
        Me.rbAccountCode = New System.Windows.Forms.RadioButton()
        Me.rbOrderCategory = New System.Windows.Forms.RadioButton()
        Me.rbOrderSubType = New System.Windows.Forms.RadioButton()
        Me.rbOrderAccount = New System.Windows.Forms.RadioButton()
        Me.rbAccountTitle = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbToDepartment = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFromDepartment = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbAccountTo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbAccountFrom = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CMDPOSTPEC = New System.Windows.Forms.Button()
        Me.btnTBPEC = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnPostBB = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chkBB = New System.Windows.Forms.CheckBox()
        Me.chkJV = New System.Windows.Forms.CheckBox()
        Me.chkDV = New System.Windows.Forms.CheckBox()
        Me.chkOR = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalVariance = New System.Windows.Forms.TextBox()
        Me.rbBalanceSheet = New System.Windows.Forms.RadioButton()
        Me.rbTrialBalance = New System.Windows.Forms.RadioButton()
        Me.CmdPreview = New System.Windows.Forms.Button()
        Me.rbIncomeStatement = New System.Windows.Forms.RadioButton()
        Me.rbARR = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout
        CType(Me.nupYear,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox2.SuspendLayout
        Me.GroupBox3.SuspendLayout
        Me.GroupBox5.SuspendLayout
        Me.GroupBox4.SuspendLayout
        CType(Me.dgvData,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox7.SuspendLayout
        Me.GroupBox8.SuspendLayout
        Me.GroupBox6.SuspendLayout
        Me.SuspendLayout
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(56, 69)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 15)
        Me.Label5.TabIndex = 575
        Me.Label5.Text = "From Period :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nupYear)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbMonth)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbFiscal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(351, 120)
        Me.GroupBox1.TabIndex = 576
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Financial Period"
        '
        'nupYear
        '
        Me.nupYear.Location = New System.Drawing.Point(57, 18)
        Me.nupYear.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.nupYear.Name = "nupYear"
        Me.nupYear.Size = New System.Drawing.Size(68, 21)
        Me.nupYear.TabIndex = 598
        Me.nupYear.Value = New Decimal(New Integer() {2016, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 42)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 15)
        Me.Label10.TabIndex = 597
        Me.Label10.Text = "Month :"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 15)
        Me.Label2.TabIndex = 596
        Me.Label2.Text = "Year :"
        '
        'cbMonth
        '
        Me.cbMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbMonth.FormattingEnabled = true
        Me.cbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cbMonth.Location = New System.Drawing.Point(58, 41)
        Me.cbMonth.Margin = New System.Windows.Forms.Padding(4)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(106, 21)
        Me.cbMonth.TabIndex = 595
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(145, 92)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(124, 21)
        Me.dtpTo.TabIndex = 593
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(145, 68)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(124, 21)
        Me.dtpFrom.TabIndex = 592
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label9.Location = New System.Drawing.Point(179, 20)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 580
        Me.Label9.Text = "Fiscal Option :"
        '
        'cbFiscal
        '
        Me.cbFiscal.DisplayMember = "MTD"
        Me.cbFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbFiscal.FormattingEnabled = true
        Me.cbFiscal.Items.AddRange(New Object() {"MTD", "YTD"})
        Me.cbFiscal.Location = New System.Drawing.Point(263, 18)
        Me.cbFiscal.Margin = New System.Windows.Forms.Padding(4)
        Me.cbFiscal.Name = "cbFiscal"
        Me.cbFiscal.Size = New System.Drawing.Size(80, 21)
        Me.cbFiscal.TabIndex = 578
        Me.cbFiscal.Text = "MTD"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 90)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 576
        Me.Label1.Text = "To Period :"
        '
        'chkPEC
        '
        Me.chkPEC.AutoSize = true
        Me.chkPEC.Location = New System.Drawing.Point(252, 21)
        Me.chkPEC.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPEC.Name = "chkPEC"
        Me.chkPEC.Size = New System.Drawing.Size(50, 19)
        Me.chkPEC.TabIndex = 592
        Me.chkPEC.Text = "PEC"
        Me.chkPEC.UseVisualStyleBackColor = true
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbDetailed)
        Me.GroupBox2.Controls.Add(Me.rbSummary)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 189)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(351, 40)
        Me.GroupBox2.TabIndex = 577
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Report Type"
        '
        'rbDetailed
        '
        Me.rbDetailed.AutoSize = true
        Me.rbDetailed.Location = New System.Drawing.Point(217, 21)
        Me.rbDetailed.Margin = New System.Windows.Forms.Padding(4)
        Me.rbDetailed.Name = "rbDetailed"
        Me.rbDetailed.Size = New System.Drawing.Size(71, 19)
        Me.rbDetailed.TabIndex = 1
        Me.rbDetailed.Text = "Detailed"
        Me.rbDetailed.UseVisualStyleBackColor = true
        '
        'rbSummary
        '
        Me.rbSummary.AutoSize = true
        Me.rbSummary.Checked = true
        Me.rbSummary.Location = New System.Drawing.Point(62, 21)
        Me.rbSummary.Margin = New System.Windows.Forms.Padding(4)
        Me.rbSummary.Name = "rbSummary"
        Me.rbSummary.Size = New System.Drawing.Size(78, 19)
        Me.rbSummary.TabIndex = 0
        Me.rbSummary.TabStop = true
        Me.rbSummary.Text = "Summary"
        Me.rbSummary.UseVisualStyleBackColor = true
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbRefID)
        Me.GroupBox3.Controls.Add(Me.rbAccountCode)
        Me.GroupBox3.Controls.Add(Me.rbOrderCategory)
        Me.GroupBox3.Controls.Add(Me.rbOrderSubType)
        Me.GroupBox3.Controls.Add(Me.rbOrderAccount)
        Me.GroupBox3.Controls.Add(Me.rbAccountTitle)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 228)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(351, 66)
        Me.GroupBox3.TabIndex = 577
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Sort by"
        '
        'rbRefID
        '
        Me.rbRefID.AutoSize = true
        Me.rbRefID.Location = New System.Drawing.Point(243, 39)
        Me.rbRefID.Margin = New System.Windows.Forms.Padding(4)
        Me.rbRefID.Name = "rbRefID"
        Me.rbRefID.Size = New System.Drawing.Size(97, 19)
        Me.rbRefID.TabIndex = 582
        Me.rbRefID.TabStop = true
        Me.rbRefID.Text = "Reference ID"
        Me.rbRefID.UseVisualStyleBackColor = true
        '
        'rbAccountCode
        '
        Me.rbAccountCode.AutoSize = true
        Me.rbAccountCode.Checked = true
        Me.rbAccountCode.Location = New System.Drawing.Point(243, 19)
        Me.rbAccountCode.Margin = New System.Windows.Forms.Padding(4)
        Me.rbAccountCode.Name = "rbAccountCode"
        Me.rbAccountCode.Size = New System.Drawing.Size(100, 19)
        Me.rbAccountCode.TabIndex = 581
        Me.rbAccountCode.TabStop = true
        Me.rbAccountCode.Text = "Account Code"
        Me.rbAccountCode.UseVisualStyleBackColor = true
        '
        'rbOrderCategory
        '
        Me.rbOrderCategory.AutoSize = true
        Me.rbOrderCategory.Location = New System.Drawing.Point(141, 19)
        Me.rbOrderCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.rbOrderCategory.Name = "rbOrderCategory"
        Me.rbOrderCategory.Size = New System.Drawing.Size(73, 19)
        Me.rbOrderCategory.TabIndex = 5
        Me.rbOrderCategory.TabStop = true
        Me.rbOrderCategory.Text = "Category"
        Me.rbOrderCategory.UseVisualStyleBackColor = true
        '
        'rbOrderSubType
        '
        Me.rbOrderSubType.AutoSize = true
        Me.rbOrderSubType.Location = New System.Drawing.Point(15, 39)
        Me.rbOrderSubType.Margin = New System.Windows.Forms.Padding(4)
        Me.rbOrderSubType.Name = "rbOrderSubType"
        Me.rbOrderSubType.Size = New System.Drawing.Size(122, 19)
        Me.rbOrderSubType.TabIndex = 4
        Me.rbOrderSubType.TabStop = true
        Me.rbOrderSubType.Text = "Sub Account Type"
        Me.rbOrderSubType.UseVisualStyleBackColor = true
        '
        'rbOrderAccount
        '
        Me.rbOrderAccount.AutoSize = true
        Me.rbOrderAccount.Location = New System.Drawing.Point(15, 19)
        Me.rbOrderAccount.Margin = New System.Windows.Forms.Padding(4)
        Me.rbOrderAccount.Name = "rbOrderAccount"
        Me.rbOrderAccount.Size = New System.Drawing.Size(97, 19)
        Me.rbOrderAccount.TabIndex = 3
        Me.rbOrderAccount.TabStop = true
        Me.rbOrderAccount.Text = "Account Type"
        Me.rbOrderAccount.UseVisualStyleBackColor = true
        '
        'rbAccountTitle
        '
        Me.rbAccountTitle.AutoSize = true
        Me.rbAccountTitle.Location = New System.Drawing.Point(141, 39)
        Me.rbAccountTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.rbAccountTitle.Name = "rbAccountTitle"
        Me.rbAccountTitle.Size = New System.Drawing.Size(94, 19)
        Me.rbAccountTitle.TabIndex = 1
        Me.rbAccountTitle.TabStop = true
        Me.rbAccountTitle.Text = "Account Title"
        Me.rbAccountTitle.UseVisualStyleBackColor = true
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbToDepartment)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.cmbFromDepartment)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Location = New System.Drawing.Point(0, 86)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(351, 82)
        Me.GroupBox5.TabIndex = 580
        Me.GroupBox5.TabStop = false
        Me.GroupBox5.Text = "Department"
        '
        'cmbToDepartment
        '
        Me.cmbToDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbToDepartment.FormattingEnabled = true
        Me.cmbToDepartment.Items.AddRange(New Object() {"ADM", "FIN"})
        Me.cmbToDepartment.Location = New System.Drawing.Point(169, 49)
        Me.cmbToDepartment.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbToDepartment.Name = "cmbToDepartment"
        Me.cmbToDepartment.Size = New System.Drawing.Size(158, 24)
        Me.cmbToDepartment.TabIndex = 582
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(8, 49)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 583
        Me.Label6.Text = "To Department"
        '
        'cmbFromDepartment
        '
        Me.cmbFromDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbFromDepartment.FormattingEnabled = true
        Me.cmbFromDepartment.Items.AddRange(New Object() {"ADM", "FIN"})
        Me.cmbFromDepartment.Location = New System.Drawing.Point(171, 14)
        Me.cmbFromDepartment.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFromDepartment.Name = "cmbFromDepartment"
        Me.cmbFromDepartment.Size = New System.Drawing.Size(158, 24)
        Me.cmbFromDepartment.TabIndex = 580
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(7, 19)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 581
        Me.Label7.Text = "From Deparment"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbAccountTo)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cbAccountFrom)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 295)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(351, 80)
        Me.GroupBox4.TabIndex = 578
        Me.GroupBox4.TabStop = false
        Me.GroupBox4.Text = "Account Group"
        '
        'cbAccountTo
        '
        Me.cbAccountTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cbAccountTo.FormattingEnabled = true
        Me.cbAccountTo.Items.AddRange(New Object() {" "})
        Me.cbAccountTo.Location = New System.Drawing.Point(129, 42)
        Me.cbAccountTo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbAccountTo.Name = "cbAccountTo"
        Me.cbAccountTo.Size = New System.Drawing.Size(215, 24)
        Me.cbAccountTo.TabIndex = 582
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 44)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 15)
        Me.Label3.TabIndex = 583
        Me.Label3.Text = "To Account Code :"
        '
        'cbAccountFrom
        '
        Me.cbAccountFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cbAccountFrom.FormattingEnabled = true
        Me.cbAccountFrom.Items.AddRange(New Object() {" "})
        Me.cbAccountFrom.Location = New System.Drawing.Point(129, 16)
        Me.cbAccountFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.cbAccountFrom.Name = "cbAccountFrom"
        Me.cbAccountFrom.Size = New System.Drawing.Size(215, 24)
        Me.cbAccountFrom.TabIndex = 580
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 19)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 15)
        Me.Label4.TabIndex = 581
        Me.Label4.Text = "From Account Code :"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(384, 8)
        Me.btnGenerate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(102, 30)
        Me.btnGenerate.TabIndex = 582
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = true
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = false
        Me.dgvData.AllowUserToDeleteRows = false
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Location = New System.Drawing.Point(373, 46)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = true
        Me.dgvData.RowHeadersVisible = false
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(795, 644)
        Me.dgvData.TabIndex = 583
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1389, 8)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 30)
        Me.Button1.TabIndex = 584
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtTotalCredit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(726, 706)
        Me.txtTotalCredit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.Size = New System.Drawing.Size(161, 22)
        Me.txtTotalCredit.TabIndex = 585
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(471, 706)
        Me.txtTotalDebit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.Size = New System.Drawing.Size(162, 22)
        Me.txtTotalDebit.TabIndex = 586
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(395, 845)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 16)
        Me.Label8.TabIndex = 587
        Me.Label8.Text = "Total :"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(18, 18)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 30)
        Me.Button2.TabIndex = 588
        Me.Button2.Text = "Transact PEC"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'CMDPOSTPEC
        '
        Me.CMDPOSTPEC.Location = New System.Drawing.Point(229, 19)
        Me.CMDPOSTPEC.Margin = New System.Windows.Forms.Padding(4)
        Me.CMDPOSTPEC.Name = "CMDPOSTPEC"
        Me.CMDPOSTPEC.Size = New System.Drawing.Size(93, 30)
        Me.CMDPOSTPEC.TabIndex = 589
        Me.CMDPOSTPEC.Text = "Post PEC"
        Me.CMDPOSTPEC.UseVisualStyleBackColor = true
        '
        'btnTBPEC
        '
        Me.btnTBPEC.Location = New System.Drawing.Point(18, 50)
        Me.btnTBPEC.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTBPEC.Name = "btnTBPEC"
        Me.btnTBPEC.Size = New System.Drawing.Size(200, 30)
        Me.btnTBPEC.TabIndex = 590
        Me.btnTBPEC.Text = "TB After Period End Closing"
        Me.btnTBPEC.UseVisualStyleBackColor = true
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnPostBB)
        Me.GroupBox7.Controls.Add(Me.Button2)
        Me.GroupBox7.Controls.Add(Me.btnTBPEC)
        Me.GroupBox7.Controls.Add(Me.CMDPOSTPEC)
        Me.GroupBox7.Location = New System.Drawing.Point(13, 374)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Size = New System.Drawing.Size(351, 84)
        Me.GroupBox7.TabIndex = 591
        Me.GroupBox7.TabStop = false
        Me.GroupBox7.Text = "Period End Closing"
        '
        'btnPostBB
        '
        Me.btnPostBB.Location = New System.Drawing.Point(229, 50)
        Me.btnPostBB.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPostBB.Name = "btnPostBB"
        Me.btnPostBB.Size = New System.Drawing.Size(93, 30)
        Me.btnPostBB.TabIndex = 591
        Me.btnPostBB.Text = "Post BB"
        Me.btnPostBB.UseVisualStyleBackColor = true
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkBB)
        Me.GroupBox8.Controls.Add(Me.chkJV)
        Me.GroupBox8.Controls.Add(Me.chkDV)
        Me.GroupBox8.Controls.Add(Me.chkOR)
        Me.GroupBox8.Controls.Add(Me.chkPEC)
        Me.GroupBox8.Location = New System.Drawing.Point(14, 128)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Size = New System.Drawing.Size(351, 63)
        Me.GroupBox8.TabIndex = 578
        Me.GroupBox8.TabStop = false
        Me.GroupBox8.Text = "Book"
        '
        'chkBB
        '
        Me.chkBB.AutoSize = true
        Me.chkBB.Checked = true
        Me.chkBB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBB.Location = New System.Drawing.Point(128, 41)
        Me.chkBB.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBB.Name = "chkBB"
        Me.chkBB.Size = New System.Drawing.Size(42, 19)
        Me.chkBB.TabIndex = 596
        Me.chkBB.Text = "BB"
        Me.chkBB.UseVisualStyleBackColor = true
        '
        'chkJV
        '
        Me.chkJV.AutoSize = true
        Me.chkJV.Checked = true
        Me.chkJV.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkJV.Location = New System.Drawing.Point(129, 21)
        Me.chkJV.Margin = New System.Windows.Forms.Padding(4)
        Me.chkJV.Name = "chkJV"
        Me.chkJV.Size = New System.Drawing.Size(115, 19)
        Me.chkJV.TabIndex = 595
        Me.chkJV.Text = "Journal Voucher"
        Me.chkJV.UseVisualStyleBackColor = true
        '
        'chkDV
        '
        Me.chkDV.AutoSize = true
        Me.chkDV.Checked = true
        Me.chkDV.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDV.Location = New System.Drawing.Point(12, 41)
        Me.chkDV.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDV.Name = "chkDV"
        Me.chkDV.Size = New System.Drawing.Size(103, 19)
        Me.chkDV.TabIndex = 594
        Me.chkDV.Text = "Disbursement"
        Me.chkDV.UseVisualStyleBackColor = true
        '
        'chkOR
        '
        Me.chkOR.AutoSize = true
        Me.chkOR.Checked = true
        Me.chkOR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOR.Location = New System.Drawing.Point(13, 21)
        Me.chkOR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkOR.Name = "chkOR"
        Me.chkOR.Size = New System.Drawing.Size(99, 19)
        Me.chkOR.TabIndex = 593
        Me.chkOR.Text = "Cash Receipt"
        Me.chkOR.UseVisualStyleBackColor = true
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(392, 709)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 15)
        Me.Label11.TabIndex = 592
        Me.Label11.Text = "Total Debit :"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = true
        Me.Label12.Location = New System.Drawing.Point(640, 709)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 15)
        Me.Label12.TabIndex = 593
        Me.Label12.Text = "Total Credit :"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(1077, 8)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(102, 30)
        Me.btnExport.TabIndex = 594
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = true
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = true
        Me.Label13.Location = New System.Drawing.Point(906, 709)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 596
        Me.Label13.Text = "Variance:"
        '
        'txtTotalVariance
        '
        Me.txtTotalVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtTotalVariance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTotalVariance.Location = New System.Drawing.Point(971, 706)
        Me.txtTotalVariance.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalVariance.Name = "txtTotalVariance"
        Me.txtTotalVariance.Size = New System.Drawing.Size(139, 22)
        Me.txtTotalVariance.TabIndex = 595
        '
        'rbBalanceSheet
        '
        Me.rbBalanceSheet.AutoSize = true
        Me.rbBalanceSheet.Location = New System.Drawing.Point(6, 22)
        Me.rbBalanceSheet.Margin = New System.Windows.Forms.Padding(4)
        Me.rbBalanceSheet.Name = "rbBalanceSheet"
        Me.rbBalanceSheet.Size = New System.Drawing.Size(105, 19)
        Me.rbBalanceSheet.TabIndex = 0
        Me.rbBalanceSheet.TabStop = true
        Me.rbBalanceSheet.Text = "Balance Sheet"
        Me.rbBalanceSheet.UseVisualStyleBackColor = true
        '
        'rbTrialBalance
        '
        Me.rbTrialBalance.AutoSize = true
        Me.rbTrialBalance.Location = New System.Drawing.Point(6, 63)
        Me.rbTrialBalance.Margin = New System.Windows.Forms.Padding(4)
        Me.rbTrialBalance.Name = "rbTrialBalance"
        Me.rbTrialBalance.Size = New System.Drawing.Size(97, 19)
        Me.rbTrialBalance.TabIndex = 6
        Me.rbTrialBalance.TabStop = true
        Me.rbTrialBalance.Text = "Trial Balance"
        Me.rbTrialBalance.UseVisualStyleBackColor = true
        '
        'CmdPreview
        '
        Me.CmdPreview.Location = New System.Drawing.Point(267, 11)
        Me.CmdPreview.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdPreview.Name = "CmdPreview"
        Me.CmdPreview.Size = New System.Drawing.Size(77, 30)
        Me.CmdPreview.TabIndex = 583
        Me.CmdPreview.Text = "Preview"
        Me.CmdPreview.UseVisualStyleBackColor = true
        '
        'rbIncomeStatement
        '
        Me.rbIncomeStatement.AutoSize = true
        Me.rbIncomeStatement.Location = New System.Drawing.Point(6, 42)
        Me.rbIncomeStatement.Margin = New System.Windows.Forms.Padding(4)
        Me.rbIncomeStatement.Name = "rbIncomeStatement"
        Me.rbIncomeStatement.Size = New System.Drawing.Size(125, 19)
        Me.rbIncomeStatement.TabIndex = 584
        Me.rbIncomeStatement.TabStop = true
        Me.rbIncomeStatement.Text = "Income Statement"
        Me.rbIncomeStatement.UseVisualStyleBackColor = true
        '
        'rbARR
        '
        Me.rbARR.AutoSize = true
        Me.rbARR.Location = New System.Drawing.Point(6, 85)
        Me.rbARR.Margin = New System.Windows.Forms.Padding(4)
        Me.rbARR.Name = "rbARR"
        Me.rbARR.Size = New System.Drawing.Size(185, 19)
        Me.rbARR.TabIndex = 585
        Me.rbARR.TabStop = true
        Me.rbARR.Text = "Accounts Receivable Analysis"
        Me.rbARR.UseVisualStyleBackColor = true
        Me.rbARR.Visible = false
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.rbARR)
        Me.GroupBox6.Controls.Add(Me.rbIncomeStatement)
        Me.GroupBox6.Controls.Add(Me.CmdPreview)
        Me.GroupBox6.Controls.Add(Me.rbTrialBalance)
        Me.GroupBox6.Controls.Add(Me.rbBalanceSheet)
        Me.GroupBox6.Location = New System.Drawing.Point(13, 466)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(351, 262)
        Me.GroupBox6.TabIndex = 578
        Me.GroupBox6.TabStop = false
        Me.GroupBox6.Text = "Financial Report"
        Me.GroupBox6.Visible = false
        '
        'frmGLFinacialReportGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 733)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtTotalVariance)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.txtTotalCredit)
        Me.Controls.Add(Me.txtTotalDebit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmGLFinacialReportGenerator"
        Me.Text = "Deparment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.nupYear,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        CType(Me.dgvData,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox7.ResumeLayout(false)
        Me.GroupBox8.ResumeLayout(false)
        Me.GroupBox8.PerformLayout
        Me.GroupBox6.ResumeLayout(false)
        Me.GroupBox6.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSummary As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOrderAccount As System.Windows.Forms.RadioButton
    Friend WithEvents rbAccountTitle As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAccountTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbAccountFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbToDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFromDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrderCategory As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrderSubType As System.Windows.Forms.RadioButton
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CMDPOSTPEC As System.Windows.Forms.Button
    Friend WithEvents btnTBPEC As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPostBB As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPEC As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents nupYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkJV As System.Windows.Forms.CheckBox
    Friend WithEvents chkDV As System.Windows.Forms.CheckBox
    Friend WithEvents chkOR As System.Windows.Forms.CheckBox
    Friend WithEvents rbAccountCode As System.Windows.Forms.RadioButton
    Friend WithEvents rbRefID As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkBB As System.Windows.Forms.CheckBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalVariance As System.Windows.Forms.TextBox
    Friend WithEvents rbBalanceSheet As System.Windows.Forms.RadioButton
    Friend WithEvents rbTrialBalance As System.Windows.Forms.RadioButton
    Friend WithEvents CmdPreview As System.Windows.Forms.Button
    Friend WithEvents rbIncomeStatement As System.Windows.Forms.RadioButton
    Friend WithEvents rbARR As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
End Class
