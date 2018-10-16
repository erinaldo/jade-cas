<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUploader))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgbCounter = New System.Windows.Forms.ProgressBar()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvTK = New System.Windows.Forms.DataGridView()
        Me.bgwUpload = New System.ComponentModel.BackgroundWorker()
        Me.bgwSave = New System.ComponentModel.BackgroundWorker()
        Me.dgvSummary = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgcCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcParticulars = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.lblFile)
        Me.Panel1.Controls.Add(Me.lblTime)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pgbCounter)
        Me.Panel1.Controls.Add(Me.cbType)
        Me.Panel1.Controls.Add(Me.lblCount)
        Me.Panel1.Controls.Add(Me.btnUpload)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cbBranch)
        Me.Panel1.Location = New System.Drawing.Point(10, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1386, 135)
        Me.Panel1.TabIndex = 1071
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 1100
        Me.Label1.Text = "Report Type :"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Sales Book Journal Report", "Cash Receipts Book Summary 2", "ACCOUNTS PAYABLE   REGISTER", "CASH VOUCHER- EXPENSE REPORT"})
        Me.ComboBox1.Location = New System.Drawing.Point(117, 31)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(412, 24)
        Me.ComboBox1.TabIndex = 1099
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFile.Location = New System.Drawing.Point(14, 7)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(0, 16)
        Me.lblFile.TabIndex = 1098
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblTime.Location = New System.Drawing.Point(1117, 96)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(0, 15)
        Me.lblTime.TabIndex = 1097
        Me.lblTime.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1096
        Me.Label2.Text = "Business Type :"
        '
        'pgbCounter
        '
        Me.pgbCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgbCounter.BackColor = System.Drawing.Color.Gainsboro
        Me.pgbCounter.ForeColor = System.Drawing.Color.Red
        Me.pgbCounter.Location = New System.Drawing.Point(1120, 58)
        Me.pgbCounter.Name = "pgbCounter"
        Me.pgbCounter.Size = New System.Drawing.Size(244, 18)
        Me.pgbCounter.TabIndex = 1067
        '
        'cbType
        '
        Me.cbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"General"})
        Me.cbType.Location = New System.Drawing.Point(117, 59)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(412, 24)
        Me.cbType.TabIndex = 1095
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(123, 113)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(96, 16)
        Me.lblCount.TabIndex = 1082
        Me.lblCount.Text = "Record Count :"
        '
        'btnUpload
        '
        Me.btnUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.ForeColor = System.Drawing.Color.White
        Me.btnUpload.Location = New System.Drawing.Point(1120, 15)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(244, 40)
        Me.btnUpload.TabIndex = 803
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(54, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 1087
        Me.Label3.Text = "Branch :"
        '
        'cbBranch
        '
        Me.cbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Items.AddRange(New Object() {"1"})
        Me.cbBranch.Location = New System.Drawing.Point(117, 86)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(412, 24)
        Me.cbBranch.TabIndex = 1084
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(1178, 652)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(213, 39)
        Me.btnSave.TabIndex = 1092
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dgvTK
        '
        Me.dgvTK.AllowUserToAddRows = False
        Me.dgvTK.AllowUserToDeleteRows = False
        Me.dgvTK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTK.BackgroundColor = System.Drawing.Color.White
        Me.dgvTK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTK.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTK.Location = New System.Drawing.Point(12, 148)
        Me.dgvTK.Name = "dgvTK"
        Me.dgvTK.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTK.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTK.RowHeadersWidth = 25
        Me.dgvTK.Size = New System.Drawing.Size(1386, 274)
        Me.dgvTK.TabIndex = 1093
        '
        'bgwUpload
        '
        Me.bgwUpload.WorkerReportsProgress = True
        Me.bgwUpload.WorkerSupportsCancellation = True
        '
        'bgwSave
        '
        Me.bgwSave.WorkerReportsProgress = True
        Me.bgwSave.WorkerSupportsCancellation = True
        '
        'dgvSummary
        '
        Me.dgvSummary.AllowUserToAddRows = False
        Me.dgvSummary.AllowUserToDeleteRows = False
        Me.dgvSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvSummary.BackgroundColor = System.Drawing.Color.White
        Me.dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcCode, Me.dgcTitle, Me.dgcDebit, Me.dgcCredit, Me.dgcParticulars})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSummary.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSummary.Location = New System.Drawing.Point(10, 446)
        Me.dgvSummary.MultiSelect = False
        Me.dgvSummary.Name = "dgvSummary"
        Me.dgvSummary.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSummary.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSummary.RowHeadersVisible = False
        Me.dgvSummary.RowHeadersWidth = 25
        Me.dgvSummary.Size = New System.Drawing.Size(808, 235)
        Me.dgvSummary.TabIndex = 1094
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(23, 426)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 1095
        Me.Label4.Text = "Summary :"
        '
        'dgcCode
        '
        Me.dgcCode.HeaderText = "AccntCode"
        Me.dgcCode.Name = "dgcCode"
        Me.dgcCode.ReadOnly = True
        '
        'dgcTitle
        '
        Me.dgcTitle.HeaderText = "AccntTitle"
        Me.dgcTitle.Name = "dgcTitle"
        Me.dgcTitle.ReadOnly = True
        Me.dgcTitle.Width = 250
        '
        'dgcDebit
        '
        Me.dgcDebit.HeaderText = "Debit"
        Me.dgcDebit.Name = "dgcDebit"
        Me.dgcDebit.ReadOnly = True
        '
        'dgcCredit
        '
        Me.dgcCredit.HeaderText = "Credit"
        Me.dgcCredit.Name = "dgcCredit"
        Me.dgcCredit.ReadOnly = True
        '
        'dgcParticulars
        '
        Me.dgcParticulars.HeaderText = "Particulars"
        Me.dgcParticulars.Name = "dgcParticulars"
        Me.dgcParticulars.ReadOnly = True
        Me.dgcParticulars.Width = 250
        '
        'frmUploader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1403, 693)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvSummary)
        Me.Controls.Add(Me.dgvTK)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUploader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Uploader"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvTK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pgbCounter As System.Windows.Forms.ProgressBar
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvTK As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents bgwUpload As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents bgwSave As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSummary As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgcCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcParticulars As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
