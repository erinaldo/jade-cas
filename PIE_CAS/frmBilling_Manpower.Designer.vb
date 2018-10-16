<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBilling_Manpower
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBilling_Manpower))
        Me.btnImport = New System.Windows.Forms.Button()
        Me.lvContract = New System.Windows.Forms.ListView()
        Me.chBSNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPeriod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnPrintOT = New System.Windows.Forms.Button()
        Me.btnPrintDTR = New System.Windows.Forms.Button()
        Me.btnPrintDetails = New System.Windows.Forms.Button()
        Me.btnPrintSummary = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGross = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAmountDue = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEWT = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAdmin = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.dgvCharges = New System.Windows.Forms.DataGridView()
        Me.dcCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpBSDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBSNo = New System.Windows.Forms.TextBox()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(1123, 10)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(151, 26)
        Me.btnImport.TabIndex = 1341
        Me.btnImport.Text = "Contract Maintenance"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'lvContract
        '
        Me.lvContract.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvContract.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chBSNo, Me.chName, Me.chPeriod, Me.chAmount})
        Me.lvContract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvContract.FullRowSelect = True
        Me.lvContract.HideSelection = False
        Me.lvContract.Location = New System.Drawing.Point(12, 44)
        Me.lvContract.MultiSelect = False
        Me.lvContract.Name = "lvContract"
        Me.lvContract.Size = New System.Drawing.Size(572, 568)
        Me.lvContract.TabIndex = 1344
        Me.lvContract.UseCompatibleStateImageBehavior = False
        Me.lvContract.View = System.Windows.Forms.View.Details
        '
        'chBSNo
        '
        Me.chBSNo.Text = "BS No."
        Me.chBSNo.Width = 66
        '
        'chName
        '
        Me.chName.Text = "Client Name"
        Me.chName.Width = 203
        '
        'chPeriod
        '
        Me.chPeriod.Text = "Period"
        Me.chPeriod.Width = 170
        '
        'chAmount
        '
        Me.chAmount.Text = "Amount"
        Me.chAmount.Width = 127
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnPrintOT)
        Me.GroupBox1.Controls.Add(Me.btnPrintDTR)
        Me.GroupBox1.Controls.Add(Me.btnPrintDetails)
        Me.GroupBox1.Controls.Add(Me.btnPrintSummary)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtGross)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtAmountDue)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtEWT)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtVAT)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtAdmin)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.dgvCharges)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtpDueDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpBSDate)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPeriod)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtVCEName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtVCECode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtBSNo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(590, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(685, 581)
        Me.GroupBox1.TabIndex = 1345
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Billing Details"
        '
        'btnPrintOT
        '
        Me.btnPrintOT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintOT.Location = New System.Drawing.Point(512, 297)
        Me.btnPrintOT.Name = "btnPrintOT"
        Me.btnPrintOT.Size = New System.Drawing.Size(151, 46)
        Me.btnPrintOT.TabIndex = 1393
        Me.btnPrintOT.Text = "Print Attachment " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Overtime)"
        Me.btnPrintOT.UseVisualStyleBackColor = True
        '
        'btnPrintDTR
        '
        Me.btnPrintDTR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDTR.Location = New System.Drawing.Point(512, 249)
        Me.btnPrintDTR.Name = "btnPrintDTR"
        Me.btnPrintDTR.Size = New System.Drawing.Size(151, 46)
        Me.btnPrintDTR.TabIndex = 1392
        Me.btnPrintDTR.Text = "Print Attachment " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(DTR)"
        Me.btnPrintDTR.UseVisualStyleBackColor = True
        '
        'btnPrintDetails
        '
        Me.btnPrintDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDetails.Location = New System.Drawing.Point(512, 201)
        Me.btnPrintDetails.Name = "btnPrintDetails"
        Me.btnPrintDetails.Size = New System.Drawing.Size(151, 46)
        Me.btnPrintDetails.TabIndex = 1391
        Me.btnPrintDetails.Text = "Print Billing Detailed"
        Me.btnPrintDetails.UseVisualStyleBackColor = True
        '
        'btnPrintSummary
        '
        Me.btnPrintSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintSummary.Location = New System.Drawing.Point(512, 153)
        Me.btnPrintSummary.Name = "btnPrintSummary"
        Me.btnPrintSummary.Size = New System.Drawing.Size(151, 46)
        Me.btnPrintSummary.TabIndex = 1390
        Me.btnPrintSummary.Text = "Print Billing Summary"
        Me.btnPrintSummary.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(430, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 16)
        Me.Label15.TabIndex = 1389
        Me.Label15.Text = "Status :"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(481, 99)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(117, 22)
        Me.txtStatus.TabIndex = 1388
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 551)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 16)
        Me.Label14.TabIndex = 1387
        Me.Label14.Text = "Gross Amount :"
        '
        'txtGross
        '
        Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGross.Location = New System.Drawing.Point(121, 549)
        Me.txtGross.Name = "txtGross"
        Me.txtGross.Size = New System.Drawing.Size(133, 22)
        Me.txtGross.TabIndex = 1386
        Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(274, 551)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 16)
        Me.Label13.TabIndex = 1385
        Me.Label13.Text = "Amount Due :"
        '
        'txtAmountDue
        '
        Me.txtAmountDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAmountDue.Location = New System.Drawing.Point(365, 549)
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.Size = New System.Drawing.Size(133, 22)
        Me.txtAmountDue.TabIndex = 1384
        Me.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(316, 527)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 16)
        Me.Label12.TabIndex = 1383
        Me.Label12.Text = "EWT :"
        '
        'txtEWT
        '
        Me.txtEWT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtEWT.Location = New System.Drawing.Point(365, 525)
        Me.txtEWT.Name = "txtEWT"
        Me.txtEWT.Size = New System.Drawing.Size(133, 22)
        Me.txtEWT.TabIndex = 1382
        Me.txtEWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(320, 503)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 16)
        Me.Label11.TabIndex = 1381
        Me.Label11.Text = "VAT :"
        '
        'txtVAT
        '
        Me.txtVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtVAT.Location = New System.Drawing.Point(365, 501)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(133, 22)
        Me.txtVAT.TabIndex = 1380
        Me.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 527)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 1379
        Me.Label10.Text = "Admin Fee :"
        '
        'txtAdmin
        '
        Me.txtAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAdmin.Location = New System.Drawing.Point(121, 525)
        Me.txtAdmin.Name = "txtAdmin"
        Me.txtAdmin.Size = New System.Drawing.Size(133, 22)
        Me.txtAdmin.TabIndex = 1378
        Me.txtAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 503)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 16)
        Me.Label9.TabIndex = 1377
        Me.Label9.Text = "Total Amount :"
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.Location = New System.Drawing.Point(121, 501)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(133, 22)
        Me.txtAmount.TabIndex = 1376
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvCharges
        '
        Me.dgvCharges.AllowUserToAddRows = False
        Me.dgvCharges.AllowUserToDeleteRows = False
        Me.dgvCharges.AllowUserToResizeColumns = False
        Me.dgvCharges.AllowUserToResizeRows = False
        Me.dgvCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCharges.BackgroundColor = System.Drawing.Color.White
        Me.dgvCharges.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcCategory, Me.dcType, Me.dcHours, Me.dcAmount})
        Me.dgvCharges.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCharges.Location = New System.Drawing.Point(6, 153)
        Me.dgvCharges.Name = "dgvCharges"
        Me.dgvCharges.RowHeadersVisible = False
        Me.dgvCharges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCharges.Size = New System.Drawing.Size(500, 342)
        Me.dgvCharges.TabIndex = 1368
        '
        'dcCategory
        '
        Me.dcCategory.HeaderText = "Category"
        Me.dcCategory.Name = "dcCategory"
        Me.dcCategory.Width = 150
        '
        'dcType
        '
        Me.dcType.HeaderText = "Type"
        Me.dcType.Name = "dcType"
        Me.dcType.Width = 110
        '
        'dcHours
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dcHours.DefaultCellStyle = DataGridViewCellStyle1
        Me.dcHours.HeaderText = "Days|Hours"
        Me.dcHours.Name = "dcHours"
        '
        'dcAmount
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dcAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.dcAmount.HeaderText = "Amount"
        Me.dcAmount.Name = "dcAmount"
        Me.dcAmount.Width = 120
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(512, 400)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(151, 46)
        Me.btnEdit.TabIndex = 1367
        Me.btnEdit.Text = "Edit Billing"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(512, 449)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(151, 46)
        Me.btnCancel.TabIndex = 1366
        Me.btnCancel.Text = "Cancel Billing"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(410, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 16)
        Me.Label8.TabIndex = 1360
        Me.Label8.Text = "Due Date :"
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Enabled = False
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDate.Location = New System.Drawing.Point(481, 75)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(117, 22)
        Me.dtpDueDate.TabIndex = 1359
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(417, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 1358
        Me.Label7.Text = "BS Date :"
        '
        'dtpBSDate
        '
        Me.dtpBSDate.Enabled = False
        Me.dtpBSDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBSDate.Location = New System.Drawing.Point(481, 51)
        Me.dtpBSDate.Name = "dtpBSDate"
        Me.dtpBSDate.Size = New System.Drawing.Size(117, 22)
        Me.dtpBSDate.TabIndex = 1357
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 16)
        Me.Label6.TabIndex = 1356
        Me.Label6.Text = "Remarks :"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(72, 97)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ReadOnly = True
        Me.txtRemarks.Size = New System.Drawing.Size(267, 50)
        Me.txtRemarks.TabIndex = 1355
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 1354
        Me.Label5.Text = "Period :"
        '
        'txtPeriod
        '
        Me.txtPeriod.Location = New System.Drawing.Point(72, 73)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.ReadOnly = True
        Me.txtPeriod.Size = New System.Drawing.Size(267, 22)
        Me.txtPeriod.TabIndex = 1353
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 1352
        Me.Label4.Text = "Name :"
        '
        'txtVCEName
        '
        Me.txtVCEName.Location = New System.Drawing.Point(72, 49)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.ReadOnly = True
        Me.txtVCEName.Size = New System.Drawing.Size(267, 22)
        Me.txtVCEName.TabIndex = 1351
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 16)
        Me.Label3.TabIndex = 1350
        Me.Label3.Text = "Code :"
        '
        'txtVCECode
        '
        Me.txtVCECode.Location = New System.Drawing.Point(72, 25)
        Me.txtVCECode.Name = "txtVCECode"
        Me.txtVCECode.ReadOnly = True
        Me.txtVCECode.Size = New System.Drawing.Size(100, 22)
        Me.txtVCECode.TabIndex = 1349
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(424, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 1348
        Me.Label2.Text = "BS No. :"
        '
        'txtBSNo
        '
        Me.txtBSNo.Location = New System.Drawing.Point(481, 27)
        Me.txtBSNo.Name = "txtBSNo"
        Me.txtBSNo.ReadOnly = True
        Me.txtBSNo.Size = New System.Drawing.Size(117, 22)
        Me.txtBSNo.TabIndex = 0
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(77, 14)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(121, 24)
        Me.cbStatus.TabIndex = 1346
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 1347
        Me.Label1.Text = "Status :"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(966, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 26)
        Me.Button1.TabIndex = 1362
        Me.Button1.Text = "Create New Billing"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmBilling_Manpower
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1286, 624)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbStatus)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvContract)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnImport)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBilling_Manpower"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents lvContract As System.Windows.Forms.ListView
    Friend WithEvents chBSNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPeriod As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpBSDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVCECode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBSNo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dgvCharges As System.Windows.Forms.DataGridView
    Friend WithEvents dcCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAmountDue As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtEWT As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAdmin As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnPrintOT As System.Windows.Forms.Button
    Friend WithEvents btnPrintDTR As System.Windows.Forms.Button
    Friend WithEvents btnPrintDetails As System.Windows.Forms.Button
    Friend WithEvents btnPrintSummary As System.Windows.Forms.Button
End Class
