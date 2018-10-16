<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUploadHistory))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbReport = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgvSummary = New System.Windows.Forms.DataGridView()
        Me.dgcID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcPeriod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTimestamp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 1100
        Me.Label1.Text = "Report Type :"
        '
        'cbReport
        '
        Me.cbReport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbReport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReport.FormattingEnabled = True
        Me.cbReport.Items.AddRange(New Object() {"Sales Book Journal Report", "Cash Receipts Book Summary 2", "ACCOUNTS PAYABLE   REGISTER", "CASH VOUCHER- EXPENSE REPORT", "CHECK VOUCHER-  EXPENSE REPORT"})
        Me.cbReport.Location = New System.Drawing.Point(119, 12)
        Me.cbReport.Name = "cbReport"
        Me.cbReport.Size = New System.Drawing.Size(412, 24)
        Me.cbReport.TabIndex = 1099
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(616, 344)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(213, 39)
        Me.btnDelete.TabIndex = 1092
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'dgvSummary
        '
        Me.dgvSummary.AllowUserToAddRows = False
        Me.dgvSummary.AllowUserToDeleteRows = False
        Me.dgvSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSummary.BackgroundColor = System.Drawing.Color.White
        Me.dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcID, Me.dgcPeriod, Me.dgcBranch, Me.dgcCount, Me.dgcTimestamp, Me.dgcUser})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSummary.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSummary.Location = New System.Drawing.Point(10, 42)
        Me.dgvSummary.MultiSelect = False
        Me.dgvSummary.Name = "dgvSummary"
        Me.dgvSummary.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSummary.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSummary.RowHeadersVisible = False
        Me.dgvSummary.RowHeadersWidth = 25
        Me.dgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSummary.Size = New System.Drawing.Size(825, 296)
        Me.dgvSummary.TabIndex = 1094
        '
        'dgcID
        '
        Me.dgcID.HeaderText = "ID"
        Me.dgcID.Name = "dgcID"
        Me.dgcID.ReadOnly = True
        Me.dgcID.Visible = False
        '
        'dgcPeriod
        '
        Me.dgcPeriod.HeaderText = "Period"
        Me.dgcPeriod.Name = "dgcPeriod"
        Me.dgcPeriod.ReadOnly = True
        Me.dgcPeriod.Width = 200
        '
        'dgcBranch
        '
        Me.dgcBranch.HeaderText = "Branch"
        Me.dgcBranch.Name = "dgcBranch"
        Me.dgcBranch.ReadOnly = True
        Me.dgcBranch.Width = 200
        '
        'dgcCount
        '
        Me.dgcCount.HeaderText = "Record Count"
        Me.dgcCount.Name = "dgcCount"
        Me.dgcCount.ReadOnly = True
        Me.dgcCount.Width = 120
        '
        'dgcTimestamp
        '
        Me.dgcTimestamp.HeaderText = "Upload Timestamp"
        Me.dgcTimestamp.Name = "dgcTimestamp"
        Me.dgcTimestamp.ReadOnly = True
        Me.dgcTimestamp.Width = 150
        '
        'dgcUser
        '
        Me.dgcUser.HeaderText = "Uploaded by"
        Me.dgcUser.Name = "dgcUser"
        Me.dgcUser.ReadOnly = True
        Me.dgcUser.Width = 150
        '
        'frmUploadHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(841, 395)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSummary)
        Me.Controls.Add(Me.cbReport)
        Me.Controls.Add(Me.btnDelete)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUploadHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Uploader"
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbReport As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSummary As System.Windows.Forms.DataGridView
    Friend WithEvents dgcID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcPeriod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTimestamp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcUser As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
