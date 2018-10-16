<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBilling_Manpower_New
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBilling_Manpower_New))
        Me.gbReportType = New System.Windows.Forms.GroupBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.cbCutoff = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.lvSelected = New System.Windows.Forms.ListView()
        Me.chEmpID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chEmpName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPeriod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbFilter2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFilter = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbEmpType = New System.Windows.Forms.ComboBox()
        Me.lvEmp = New System.Windows.Forms.ListView()
        Me.chAvailEmpID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAvailEmpName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAvailStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpBSDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBSNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVCECode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvCharges = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbVCEName = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAdmin = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEWT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAmountDue = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGross = New System.Windows.Forms.TextBox()
        Me.pbRecords = New System.Windows.Forms.ProgressBar()
        Me.dcCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbReportType.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbReportType
        '
        Me.gbReportType.Controls.Add(Me.lblTo)
        Me.gbReportType.Controls.Add(Me.dtpFrom)
        Me.gbReportType.Controls.Add(Me.lblType)
        Me.gbReportType.Controls.Add(Me.lblPeriod)
        Me.gbReportType.Controls.Add(Me.dtpTo)
        Me.gbReportType.Controls.Add(Me.cbCutoff)
        Me.gbReportType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReportType.Location = New System.Drawing.Point(401, 12)
        Me.gbReportType.Name = "gbReportType"
        Me.gbReportType.Size = New System.Drawing.Size(379, 94)
        Me.gbReportType.TabIndex = 864
        Me.gbReportType.TabStop = False
        Me.gbReportType.Text = "Period Covered"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(221, 56)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(25, 16)
        Me.lblTo.TabIndex = 866
        Me.lblTo.Text = "To"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(115, 53)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(103, 22)
        Me.dtpFrom.TabIndex = 864
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(13, 28)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(99, 16)
        Me.lblType.TabIndex = 863
        Me.lblType.Text = "Payroll Period :"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(67, 56)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(45, 16)
        Me.lblPeriod.TabIndex = 148
        Me.lblPeriod.Text = "From :"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(246, 53)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(103, 22)
        Me.dtpTo.TabIndex = 865
        '
        'cbCutoff
        '
        Me.cbCutoff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCutoff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCutoff.FormattingEnabled = True
        Me.cbCutoff.Location = New System.Drawing.Point(115, 25)
        Me.cbCutoff.Name = "cbCutoff"
        Me.cbCutoff.Size = New System.Drawing.Size(234, 24)
        Me.cbCutoff.TabIndex = 868
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnRemoveAll)
        Me.GroupBox3.Controls.Add(Me.btnRemove)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Controls.Add(Me.btnAddAll)
        Me.GroupBox3.Controls.Add(Me.lvSelected)
        Me.GroupBox3.Controls.Add(Me.cbFilter2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cbFilter)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cbEmpType)
        Me.GroupBox3.Controls.Add(Me.lvEmp)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 112)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(751, 498)
        Me.GroupBox3.TabIndex = 867
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filter Employee"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Location = New System.Drawing.Point(314, 274)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(34, 24)
        Me.btnRemoveAll.TabIndex = 1346
        Me.btnRemoveAll.Text = "<<"
        Me.btnRemoveAll.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(314, 247)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(34, 24)
        Me.btnRemove.TabIndex = 1345
        Me.btnRemove.Text = "<"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(314, 212)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(34, 24)
        Me.btnAdd.TabIndex = 1344
        Me.btnAdd.Text = ">"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnAddAll
        '
        Me.btnAddAll.Location = New System.Drawing.Point(314, 185)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(34, 24)
        Me.btnAddAll.TabIndex = 1343
        Me.btnAddAll.Text = ">>"
        Me.btnAddAll.UseVisualStyleBackColor = True
        '
        'lvSelected
        '
        Me.lvSelected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvSelected.CheckBoxes = True
        Me.lvSelected.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chEmpID, Me.chEmpName, Me.chStatus, Me.chPeriod})
        Me.lvSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSelected.FullRowSelect = True
        Me.lvSelected.Location = New System.Drawing.Point(355, 83)
        Me.lvSelected.Name = "lvSelected"
        Me.lvSelected.Size = New System.Drawing.Size(383, 409)
        Me.lvSelected.TabIndex = 912
        Me.lvSelected.UseCompatibleStateImageBehavior = False
        Me.lvSelected.View = System.Windows.Forms.View.Details
        '
        'chEmpID
        '
        Me.chEmpID.Text = "EmpID"
        Me.chEmpID.Width = 0
        '
        'chEmpName
        '
        Me.chEmpName.Text = "Emp. Name"
        Me.chEmpName.Width = 182
        '
        'chStatus
        '
        Me.chStatus.Text = "Status"
        Me.chStatus.Width = 80
        '
        'chPeriod
        '
        Me.chPeriod.Text = "Period"
        Me.chPeriod.Width = 117
        '
        'cbFilter2
        '
        Me.cbFilter2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilter2.FormattingEnabled = True
        Me.cbFilter2.Location = New System.Drawing.Point(261, 21)
        Me.cbFilter2.Name = "cbFilter2"
        Me.cbFilter2.Size = New System.Drawing.Size(158, 24)
        Me.cbFilter2.TabIndex = 911
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 910
        Me.Label1.Text = "Filter by :"
        '
        'cbFilter
        '
        Me.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilter.FormattingEnabled = True
        Me.cbFilter.Items.AddRange(New Object() {"Employee", "Group"})
        Me.cbFilter.Location = New System.Drawing.Point(88, 21)
        Me.cbFilter.Name = "cbFilter"
        Me.cbFilter.Size = New System.Drawing.Size(167, 24)
        Me.cbFilter.TabIndex = 909
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 908
        Me.Label2.Text = "Emp. Type :"
        '
        'cbEmpType
        '
        Me.cbEmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEmpType.FormattingEnabled = True
        Me.cbEmpType.Items.AddRange(New Object() {"All", "Active", "Inactive"})
        Me.cbEmpType.Location = New System.Drawing.Point(88, 49)
        Me.cbEmpType.Name = "cbEmpType"
        Me.cbEmpType.Size = New System.Drawing.Size(167, 24)
        Me.cbEmpType.TabIndex = 907
        '
        'lvEmp
        '
        Me.lvEmp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvEmp.CheckBoxes = True
        Me.lvEmp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chAvailEmpID, Me.chAvailEmpName, Me.chAvailStatus})
        Me.lvEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEmp.FullRowSelect = True
        Me.lvEmp.Location = New System.Drawing.Point(17, 83)
        Me.lvEmp.Name = "lvEmp"
        Me.lvEmp.Size = New System.Drawing.Size(291, 409)
        Me.lvEmp.TabIndex = 900
        Me.lvEmp.UseCompatibleStateImageBehavior = False
        Me.lvEmp.View = System.Windows.Forms.View.Details
        '
        'chAvailEmpID
        '
        Me.chAvailEmpID.Text = "Emp. ID"
        Me.chAvailEmpID.Width = 0
        '
        'chAvailEmpName
        '
        Me.chAvailEmpName.Text = "Name"
        Me.chAvailEmpName.Width = 202
        '
        'chAvailStatus
        '
        Me.chAvailStatus.Text = "Status"
        Me.chAvailStatus.Width = 85
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1046, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 16)
        Me.Label8.TabIndex = 871
        Me.Label8.Text = "Due Date :"
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDate.Location = New System.Drawing.Point(1120, 65)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(152, 22)
        Me.dtpDueDate.TabIndex = 870
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1053, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 869
        Me.Label4.Text = "BS Date :"
        '
        'dtpBSDate
        '
        Me.dtpBSDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpBSDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBSDate.Location = New System.Drawing.Point(1120, 40)
        Me.dtpBSDate.Name = "dtpBSDate"
        Me.dtpBSDate.Size = New System.Drawing.Size(152, 22)
        Me.dtpBSDate.TabIndex = 868
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1061, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 873
        Me.Label3.Text = "BS No. :"
        '
        'txtBSNo
        '
        Me.txtBSNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBSNo.Location = New System.Drawing.Point(1120, 15)
        Me.txtBSNo.Name = "txtBSNo"
        Me.txtBSNo.Size = New System.Drawing.Size(117, 22)
        Me.txtBSNo.TabIndex = 872
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 875
        Me.Label5.Text = "VCECode :"
        '
        'txtVCECode
        '
        Me.txtVCECode.Location = New System.Drawing.Point(100, 9)
        Me.txtVCECode.Name = "txtVCECode"
        Me.txtVCECode.ReadOnly = True
        Me.txtVCECode.Size = New System.Drawing.Size(152, 22)
        Me.txtVCECode.TabIndex = 874
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 877
        Me.Label6.Text = "VCEName :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 16)
        Me.Label7.TabIndex = 879
        Me.Label7.Text = "Remarks :"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(100, 60)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(291, 46)
        Me.txtRemarks.TabIndex = 878
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(255, 8)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(30, 24)
        Me.btnImport.TabIndex = 1341
        Me.btnImport.Text = ">>"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1241, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 24)
        Me.Button1.TabIndex = 1342
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCharges.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcCategory, Me.dcType, Me.dcHours, Me.dcAmount})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCharges.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCharges.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCharges.Location = New System.Drawing.Point(772, 133)
        Me.dgvCharges.Name = "dgvCharges"
        Me.dgvCharges.RowHeadersVisible = False
        Me.dgvCharges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCharges.Size = New System.Drawing.Size(500, 359)
        Me.dgvCharges.TabIndex = 1362
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Green
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(769, 575)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(503, 35)
        Me.btnSave.TabIndex = 1347
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cbVCEName
        '
        Me.cbVCEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVCEName.FormattingEnabled = True
        Me.cbVCEName.Location = New System.Drawing.Point(100, 34)
        Me.cbVCEName.Name = "cbVCEName"
        Me.cbVCEName.Size = New System.Drawing.Size(291, 24)
        Me.cbVCEName.TabIndex = 1363
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(783, 500)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 16)
        Me.Label9.TabIndex = 1365
        Me.Label9.Text = "Total Amount :"
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.Location = New System.Drawing.Point(881, 498)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(133, 22)
        Me.txtAmount.TabIndex = 1364
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(797, 524)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 1367
        Me.Label10.Text = "Admin Fee :"
        '
        'txtAdmin
        '
        Me.txtAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAdmin.Location = New System.Drawing.Point(881, 522)
        Me.txtAdmin.Name = "txtAdmin"
        Me.txtAdmin.Size = New System.Drawing.Size(133, 22)
        Me.txtAdmin.TabIndex = 1366
        Me.txtAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1080, 500)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 16)
        Me.Label11.TabIndex = 1369
        Me.Label11.Text = "VAT :"
        '
        'txtVAT
        '
        Me.txtVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtVAT.Location = New System.Drawing.Point(1125, 498)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(133, 22)
        Me.txtVAT.TabIndex = 1368
        Me.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(1076, 524)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 16)
        Me.Label12.TabIndex = 1371
        Me.Label12.Text = "EWT :"
        '
        'txtEWT
        '
        Me.txtEWT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtEWT.Location = New System.Drawing.Point(1125, 522)
        Me.txtEWT.Name = "txtEWT"
        Me.txtEWT.Size = New System.Drawing.Size(133, 22)
        Me.txtEWT.TabIndex = 1370
        Me.txtEWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1034, 548)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 16)
        Me.Label13.TabIndex = 1373
        Me.Label13.Text = "Amount Due :"
        '
        'txtAmountDue
        '
        Me.txtAmountDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAmountDue.Location = New System.Drawing.Point(1125, 546)
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.Size = New System.Drawing.Size(133, 22)
        Me.txtAmountDue.TabIndex = 1372
        Me.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(778, 548)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 16)
        Me.Label14.TabIndex = 1375
        Me.Label14.Text = "Gross Amount :"
        '
        'txtGross
        '
        Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtGross.Location = New System.Drawing.Point(881, 546)
        Me.txtGross.Name = "txtGross"
        Me.txtGross.Size = New System.Drawing.Size(133, 22)
        Me.txtGross.TabIndex = 1374
        Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pbRecords
        '
        Me.pbRecords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbRecords.Location = New System.Drawing.Point(772, 118)
        Me.pbRecords.Name = "pbRecords"
        Me.pbRecords.Size = New System.Drawing.Size(499, 10)
        Me.pbRecords.TabIndex = 1376
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dcHours.DefaultCellStyle = DataGridViewCellStyle2
        Me.dcHours.HeaderText = "Days|Hours"
        Me.dcHours.Name = "dcHours"
        '
        'dcAmount
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dcAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.dcAmount.HeaderText = "Amount"
        Me.dcAmount.Name = "dcAmount"
        Me.dcAmount.Width = 120
        '
        'frmBilling_Manpower_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1284, 619)
        Me.Controls.Add(Me.pbRecords)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtGross)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtAmountDue)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtEWT)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtVAT)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtAdmin)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.cbVCEName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvCharges)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtVCECode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBSNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDueDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpBSDate)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gbReportType)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBilling_Manpower_New"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billing - Payroll"
        Me.gbReportType.ResumeLayout(False)
        Me.gbReportType.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbReportType As System.Windows.Forms.GroupBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbCutoff As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbEmpType As System.Windows.Forms.ComboBox
    Friend WithEvents lvEmp As System.Windows.Forms.ListView
    Friend WithEvents chAvailEmpName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAvailStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpBSDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBSNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVCECode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnAddAll As System.Windows.Forms.Button
    Friend WithEvents lvSelected As System.Windows.Forms.ListView
    Friend WithEvents chEmpID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chEmpName As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbFilter2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvCharges As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbVCEName As System.Windows.Forms.ComboBox
    Friend WithEvents chAvailEmpID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPeriod As System.Windows.Forms.ColumnHeader
    Friend WithEvents chStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAdmin As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtEWT As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAmountDue As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents pbRecords As System.Windows.Forms.ProgressBar
    Friend WithEvents dcCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcAmount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
