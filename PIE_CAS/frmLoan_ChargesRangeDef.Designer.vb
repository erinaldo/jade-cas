<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoan_ChargesRangeDef
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
        Me.dgvRecords = New System.Windows.Forms.DataGridView()
        Me.dgvRecordsAll = New System.Windows.Forms.DataGridView()
        Me.dgcDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAllDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAllFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAllTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAllValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRecordsAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRecords
        '
        Me.dgvRecords.AllowUserToAddRows = False
        Me.dgvRecords.AllowUserToDeleteRows = False
        Me.dgvRecords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcDesc, Me.dgcFrom, Me.dgcTo, Me.dgcValue})
        Me.dgvRecords.Location = New System.Drawing.Point(0, 0)
        Me.dgvRecords.MultiSelect = False
        Me.dgvRecords.Name = "dgvRecords"
        Me.dgvRecords.RowHeadersWidth = 25
        Me.dgvRecords.Size = New System.Drawing.Size(478, 301)
        Me.dgvRecords.TabIndex = 1
        '
        'dgvRecordsAll
        '
        Me.dgvRecordsAll.AllowUserToAddRows = False
        Me.dgvRecordsAll.AllowUserToDeleteRows = False
        Me.dgvRecordsAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecordsAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecordsAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcAllDesc, Me.dgcAllFrom, Me.dgcAllTo, Me.dgcAllValue})
        Me.dgvRecordsAll.Location = New System.Drawing.Point(0, 0)
        Me.dgvRecordsAll.MultiSelect = False
        Me.dgvRecordsAll.Name = "dgvRecordsAll"
        Me.dgvRecordsAll.RowHeadersWidth = 25
        Me.dgvRecordsAll.Size = New System.Drawing.Size(478, 301)
        Me.dgvRecordsAll.TabIndex = 2
        Me.dgvRecordsAll.Visible = False
        '
        'dgcDesc
        '
        Me.dgcDesc.HeaderText = "Description"
        Me.dgcDesc.Name = "dgcDesc"
        Me.dgcDesc.Visible = False
        '
        'dgcFrom
        '
        Me.dgcFrom.HeaderText = "From"
        Me.dgcFrom.Name = "dgcFrom"
        Me.dgcFrom.Width = 150
        '
        'dgcTo
        '
        Me.dgcTo.HeaderText = "To"
        Me.dgcTo.Name = "dgcTo"
        Me.dgcTo.Width = 150
        '
        'dgcValue
        '
        Me.dgcValue.HeaderText = "Value"
        Me.dgcValue.Name = "dgcValue"
        Me.dgcValue.Width = 150
        '
        'dgcAllDesc
        '
        Me.dgcAllDesc.HeaderText = "Description"
        Me.dgcAllDesc.Name = "dgcAllDesc"
        Me.dgcAllDesc.Visible = False
        '
        'dgcAllFrom
        '
        Me.dgcAllFrom.HeaderText = "From"
        Me.dgcAllFrom.Name = "dgcAllFrom"
        Me.dgcAllFrom.Width = 150
        '
        'dgcAllTo
        '
        Me.dgcAllTo.HeaderText = "To"
        Me.dgcAllTo.Name = "dgcAllTo"
        Me.dgcAllTo.Width = 150
        '
        'dgcAllValue
        '
        Me.dgcAllValue.HeaderText = "Value"
        Me.dgcAllValue.Name = "dgcAllValue"
        Me.dgcAllValue.Width = 150
        '
        'frmLoan_ChargesRangeDef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(478, 301)
        Me.Controls.Add(Me.dgvRecords)
        Me.Controls.Add(Me.dgvRecordsAll)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmLoan_ChargesRangeDef"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Range Table"
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRecordsAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvRecords As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRecordsAll As System.Windows.Forms.DataGridView
    Friend WithEvents dgcDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAllDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAllFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAllTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAllValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
