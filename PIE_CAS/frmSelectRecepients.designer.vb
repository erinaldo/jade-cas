<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectRecipients
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chMemNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chMemName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMember = New System.Windows.Forms.ListView()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "Filter :"
        '
        'chMemNo
        '
        Me.chMemNo.Text = "Member No."
        Me.chMemNo.Width = 118
        '
        'chMemName
        '
        Me.chMemName.Text = "Member Name"
        Me.chMemName.Width = 235
        '
        'lvMember
        '
        Me.lvMember.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMember.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chMemNo, Me.chMemName})
        Me.lvMember.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvMember.FullRowSelect = True
        Me.lvMember.GridLines = True
        Me.lvMember.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvMember.Location = New System.Drawing.Point(6, 38)
        Me.lvMember.MultiSelect = False
        Me.lvMember.Name = "lvMember"
        Me.lvMember.Size = New System.Drawing.Size(354, 461)
        Me.lvMember.TabIndex = 202
        Me.lvMember.UseCompatibleStateImageBehavior = False
        Me.lvMember.View = System.Windows.Forms.View.Details
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(61, 12)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(240, 20)
        Me.txtFilter.TabIndex = 205
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(312, 13)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(48, 16)
        Me.LinkLabel1.TabIndex = 206
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Close"
        '
        'frmSelectRecipients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 499)
        Me.ControlBox = False
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvMember)
        Me.Name = "frmSelectRecipients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSelectRecepients"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chMemNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMemName As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMember As System.Windows.Forms.ListView
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
