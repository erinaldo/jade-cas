<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyFrom
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
        Me.dgvCopyList = New System.Windows.Forms.DataGridView()
        CType(Me.dgvCopyList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCopyList
        '
        Me.dgvCopyList.AllowUserToAddRows = False
        Me.dgvCopyList.AllowUserToDeleteRows = False
        Me.dgvCopyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCopyList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCopyList.Location = New System.Drawing.Point(0, 0)
        Me.dgvCopyList.MultiSelect = False
        Me.dgvCopyList.Name = "dgvCopyList"
        Me.dgvCopyList.ReadOnly = True
        Me.dgvCopyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCopyList.Size = New System.Drawing.Size(624, 236)
        Me.dgvCopyList.TabIndex = 0
        '
        'frmCopyFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 236)
        Me.Controls.Add(Me.dgvCopyList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmCopyFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvCopyList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCopyList As System.Windows.Forms.DataGridView
End Class
