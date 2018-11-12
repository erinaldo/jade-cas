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
        Me.dgvRanges = New System.Windows.Forms.DataGridView()
        Me.cbBasis = New System.Windows.Forms.ComboBox()
        Me.lblRangeType = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbValueType = New System.Windows.Forms.ComboBox()
        Me.dgcFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvRanges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRanges
        '
        Me.dgvRanges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRanges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcFrom, Me.dgcTo, Me.dgcValue})
        Me.dgvRanges.Location = New System.Drawing.Point(0, 37)
        Me.dgvRanges.MultiSelect = False
        Me.dgvRanges.Name = "dgvRanges"
        Me.dgvRanges.RowHeadersWidth = 25
        Me.dgvRanges.Size = New System.Drawing.Size(478, 264)
        Me.dgvRanges.TabIndex = 1
        '
        'cbBasis
        '
        Me.cbBasis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBasis.FormattingEnabled = True
        Me.cbBasis.Location = New System.Drawing.Point(90, 8)
        Me.cbBasis.Name = "cbBasis"
        Me.cbBasis.Size = New System.Drawing.Size(149, 23)
        Me.cbBasis.TabIndex = 3
        '
        'lblRangeType
        '
        Me.lblRangeType.AutoSize = True
        Me.lblRangeType.Location = New System.Drawing.Point(6, 11)
        Me.lblRangeType.Name = "lblRangeType"
        Me.lblRangeType.Size = New System.Drawing.Size(83, 15)
        Me.lblRangeType.TabIndex = 4
        Me.lblRangeType.Text = "Range Basis :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(253, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Value Type :"
        '
        'cbValueType
        '
        Me.cbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbValueType.FormattingEnabled = True
        Me.cbValueType.Location = New System.Drawing.Point(328, 7)
        Me.cbValueType.Name = "cbValueType"
        Me.cbValueType.Size = New System.Drawing.Size(147, 23)
        Me.cbValueType.TabIndex = 5
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
        'frmLoan_ChargesRangeDef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(478, 301)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbValueType)
        Me.Controls.Add(Me.lblRangeType)
        Me.Controls.Add(Me.cbBasis)
        Me.Controls.Add(Me.dgvRanges)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmLoan_ChargesRangeDef"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Range Table"
        CType(Me.dgvRanges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRanges As System.Windows.Forms.DataGridView
    Friend WithEvents cbBasis As System.Windows.Forms.ComboBox
    Friend WithEvents lblRangeType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbValueType As System.Windows.Forms.ComboBox
    Friend WithEvents dgcFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
