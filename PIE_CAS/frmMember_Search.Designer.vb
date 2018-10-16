<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMember_Search
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMember_Search))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.cbFilter = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chMemberCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.chMemberName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTIN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(529, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1191
        Me.Label2.Text = "Status"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Item Code", "Item Name"})
        Me.cbStatus.Location = New System.Drawing.Point(576, 5)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(186, 21)
        Me.cbStatus.TabIndex = 1190
        '
        'cbFilter
        '
        Me.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilter.FormattingEnabled = True
        Me.cbFilter.Items.AddRange(New Object() {"Full_Name", "Member_ID"})
        Me.cbFilter.Location = New System.Drawing.Point(73, 5)
        Me.cbFilter.Name = "cbFilter"
        Me.cbFilter.Size = New System.Drawing.Size(129, 21)
        Me.cbFilter.TabIndex = 1189
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1188
        Me.Label1.Text = "Filter by :"
        '
        'chMemberCode
        '
        Me.chMemberCode.Text = "Member Code"
        Me.chMemberCode.Width = 160
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(205, 5)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(266, 20)
        Me.txtFilter.TabIndex = 1187
        '
        'lvList
        '
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chMemberCode, Me.chMemberName, Me.chTIN})
        Me.lvList.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lvList.FullRowSelect = True
        Me.lvList.Location = New System.Drawing.Point(0, 35)
        Me.lvList.MultiSelect = False
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(774, 419)
        Me.lvList.TabIndex = 1186
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'chMemberName
        '
        Me.chMemberName.Text = "Member Name"
        Me.chMemberName.Width = 490
        '
        'chTIN
        '
        Me.chTIN.Text = "TIN"
        Me.chTIN.Width = 119
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearch.Location = New System.Drawing.Point(475, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(25, 25)
        Me.btnSearch.TabIndex = 1192
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'frmMember_Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(774, 454)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbStatus)
        Me.Controls.Add(Me.cbFilter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lvList)
        Me.Controls.Add(Me.btnSearch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMember_Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chMemberCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents chMemberName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTIN As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearch As System.Windows.Forms.Button
End Class
