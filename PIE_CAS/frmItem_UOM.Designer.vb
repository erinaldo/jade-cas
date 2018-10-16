<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItem_UOM
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
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.dgvUOM = New System.Windows.Forms.DataGridView()
        Me.chCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chBase = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.chkBase = New System.Windows.Forms.CheckBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        CType(Me.dgvUOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(338, 222)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 25)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'dgvUOM
        '
        Me.dgvUOM.AllowUserToAddRows = False
        Me.dgvUOM.AllowUserToDeleteRows = False
        Me.dgvUOM.AllowUserToOrderColumns = True
        Me.dgvUOM.AllowUserToResizeColumns = False
        Me.dgvUOM.AllowUserToResizeRows = False
        Me.dgvUOM.BackgroundColor = System.Drawing.Color.White
        Me.dgvUOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUOM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chCode, Me.chDesc, Me.chBase})
        Me.dgvUOM.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvUOM.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvUOM.Location = New System.Drawing.Point(0, 0)
        Me.dgvUOM.MultiSelect = False
        Me.dgvUOM.Name = "dgvUOM"
        Me.dgvUOM.ReadOnly = True
        Me.dgvUOM.RowHeadersVisible = False
        Me.dgvUOM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUOM.Size = New System.Drawing.Size(419, 191)
        Me.dgvUOM.TabIndex = 3
        '
        'chCode
        '
        Me.chCode.HeaderText = "Code"
        Me.chCode.Name = "chCode"
        Me.chCode.ReadOnly = True
        '
        'chDesc
        '
        Me.chDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.chDesc.HeaderText = "Description"
        Me.chDesc.Name = "chDesc"
        Me.chDesc.ReadOnly = True
        '
        'chBase
        '
        Me.chBase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.chBase.HeaderText = "Base Unit?"
        Me.chBase.Name = "chBase"
        Me.chBase.ReadOnly = True
        Me.chBase.Width = 50
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(81, 197)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(96, 21)
        Me.txtCode.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Code :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Description :"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(81, 221)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(241, 21)
        Me.txtDescription.TabIndex = 8
        '
        'chkBase
        '
        Me.chkBase.AutoSize = True
        Me.chkBase.Location = New System.Drawing.Point(81, 248)
        Me.chkBase.Name = "chkBase"
        Me.chkBase.Size = New System.Drawing.Size(79, 19)
        Me.chkBase.TabIndex = 10
        Me.chkBase.Text = "Base Unit"
        Me.chkBase.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(338, 248)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(338, 197)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 25)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'frmItem_UOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(419, 285)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.chkBase)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.dgvUOM)
        Me.Controls.Add(Me.btnEdit)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmItem_UOM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unit of Measue Maintenance"
        CType(Me.dgvUOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents dgvUOM As System.Windows.Forms.DataGridView
    Friend WithEvents chCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chBase As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents chkBase As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
End Class
