<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCOA_Search
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
        Me.dgvSearchBPPO = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Account_Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSearchBPPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSearchBPPO
        '
        Me.dgvSearchBPPO.AllowUserToAddRows = False
        Me.dgvSearchBPPO.AllowUserToDeleteRows = False
        Me.dgvSearchBPPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchBPPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Account_Type})
        Me.dgvSearchBPPO.Location = New System.Drawing.Point(2, 1)
        Me.dgvSearchBPPO.Name = "dgvSearchBPPO"
        Me.dgvSearchBPPO.ReadOnly = True
        Me.dgvSearchBPPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearchBPPO.Size = New System.Drawing.Size(690, 259)
        Me.dgvSearchBPPO.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "Accont Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Account Title"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 250
        '
        'Account_Type
        '
        Me.Account_Type.HeaderText = "Account Type"
        Me.Account_Type.Name = "Account_Type"
        Me.Account_Type.ReadOnly = True
        Me.Account_Type.Width = 200
        '
        'FrmChartOfAccountSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 261)
        Me.Controls.Add(Me.dgvSearchBPPO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmChartOfAccountSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Chart of Account"
        CType(Me.dgvSearchBPPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSearchBPPO As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Account_Type As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
