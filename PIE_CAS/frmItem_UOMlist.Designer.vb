<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItem_UOMlist
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
        Me.lvUoM = New System.Windows.Forms.ListView()
        Me.chUOM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUOMmaster = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvUoM
        '
        Me.lvUoM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvUoM.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chUOM, Me.chDesc})
        Me.lvUoM.FullRowSelect = True
        Me.lvUoM.Location = New System.Drawing.Point(8, 50)
        Me.lvUoM.MultiSelect = False
        Me.lvUoM.Name = "lvUoM"
        Me.lvUoM.Size = New System.Drawing.Size(287, 226)
        Me.lvUoM.TabIndex = 0
        Me.lvUoM.UseCompatibleStateImageBehavior = False
        Me.lvUoM.View = System.Windows.Forms.View.Details
        '
        'chUOM
        '
        Me.chUOM.Text = "Code"
        Me.chUOM.Width = 166
        '
        'chDesc
        '
        Me.chDesc.Text = "Description"
        Me.chDesc.Width = 133
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Find"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(42, 13)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(100, 21)
        Me.txtFilter.TabIndex = 3
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChoose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnChoose.Location = New System.Drawing.Point(12, 282)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(62, 34)
        Me.btnChoose.TabIndex = 1304
        Me.btnChoose.Text = "Choose"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnClose.Location = New System.Drawing.Point(80, 282)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(62, 34)
        Me.btnClose.TabIndex = 1305
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUOMmaster
        '
        Me.btnUOMmaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUOMmaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnUOMmaster.Location = New System.Drawing.Point(183, 6)
        Me.btnUOMmaster.Name = "btnUOMmaster"
        Me.btnUOMmaster.Size = New System.Drawing.Size(105, 34)
        Me.btnUOMmaster.TabIndex = 1306
        Me.btnUOMmaster.Text = "UoM Master list"
        Me.btnUOMmaster.UseVisualStyleBackColor = True
        '
        'frmItem_UOMlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(300, 328)
        Me.Controls.Add(Me.btnUOMmaster)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lvUoM)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmItem_UOMlist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unit of Measure List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvUoM As System.Windows.Forms.ListView
    Friend WithEvents chUOM As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents btnChoose As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUOMmaster As System.Windows.Forms.Button
End Class
