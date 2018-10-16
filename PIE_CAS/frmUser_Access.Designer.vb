<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser_Access
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lvAccess = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblModule = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(203, 315)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(77, 26)
        Me.btnAdd.TabIndex = 150
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lvAccess
        '
        Me.lvAccess.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.lvAccess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvAccess.BackColor = System.Drawing.Color.White
        Me.lvAccess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvAccess.CheckBoxes = True
        Me.lvAccess.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chType, Me.chID})
        Me.lvAccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lvAccess.ForeColor = System.Drawing.Color.Black
        Me.lvAccess.FullRowSelect = True
        Me.lvAccess.GridLines = True
        Me.lvAccess.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvAccess.Location = New System.Drawing.Point(1, 33)
        Me.lvAccess.MultiSelect = False
        Me.lvAccess.Name = "lvAccess"
        Me.lvAccess.Size = New System.Drawing.Size(280, 280)
        Me.lvAccess.TabIndex = 155
        Me.lvAccess.UseCompatibleStateImageBehavior = False
        Me.lvAccess.View = System.Windows.Forms.View.Details
        '
        'chID
        '
        Me.chID.Text = "AccessID"
        Me.chID.Width = 0
        '
        'chType
        '
        Me.chType.Text = "Access Type"
        Me.chType.Width = 300
        '
        'lblModule
        '
        Me.lblModule.AutoSize = True
        Me.lblModule.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblModule.Location = New System.Drawing.Point(5, 10)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(55, 15)
        Me.lblModule.TabIndex = 156
        Me.lblModule.Text = "Module :"
        '
        'frmUser_Access
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(281, 345)
        Me.Controls.Add(Me.lblModule)
        Me.Controls.Add(Me.lvAccess)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmUser_Access"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Module Access Rights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lvAccess As System.Windows.Forms.ListView
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblModule As System.Windows.Forms.Label
End Class
