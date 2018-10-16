<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBOM_Group
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
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvType = New System.Windows.Forms.ListView()
        Me.dgcID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.dgcDesc = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.dgcUOM = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.dgcSC = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.p = New System.Windows.Forms.GroupBox()
        Me.txtUOM = New System.Windows.Forms.TextBox()
        Me.btnUOM = New System.Windows.Forms.Button()
        Me.txtStandardCost = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGroupName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        Me.p.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(79, 161)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(486, 23)
        Me.txtFilter.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 164)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 1331
        Me.Label3.Text = "Filter by :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 1310
        Me.Label1.Text = "Default UOM :"
        '
        'lvType
        '
        Me.lvType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.dgcID, Me.dgcDesc, Me.dgcUOM, Me.dgcSC})
        Me.lvType.FullRowSelect = True
        Me.lvType.GridLines = True
        Me.lvType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvType.Location = New System.Drawing.Point(3, 192)
        Me.lvType.Margin = New System.Windows.Forms.Padding(4)
        Me.lvType.MultiSelect = False
        Me.lvType.Name = "lvType"
        Me.lvType.Size = New System.Drawing.Size(570, 241)
        Me.lvType.TabIndex = 1327
        Me.lvType.UseCompatibleStateImageBehavior = False
        Me.lvType.View = System.Windows.Forms.View.Details
        '
        'dgcID
        '
        Me.dgcID.Text = "ID"
        Me.dgcID.Width = 0
        '
        'dgcDesc
        '
        Me.dgcDesc.Text = "Description"
        Me.dgcDesc.Width = 350
        '
        'dgcUOM
        '
        Me.dgcUOM.Text = "UOM"
        Me.dgcUOM.Width = 80
        '
        'dgcSC
        '
        Me.dgcSC.Text = "Standard Cost"
        Me.dgcSC.Width = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbDelete, Me.tsbClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(570, 40)
        Me.ToolStrip1.TabIndex = 1346
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNew
        '
        Me.tsbNew.AutoSize = False
        Me.tsbNew.ForeColor = System.Drawing.Color.White
        Me.tsbNew.Image = Global.jade.My.Resources.Resources.circle_document_documents_extension_file_page_sheet_icon_7
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(50, 35)
        Me.tsbNew.Text = "New"
        Me.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbEdit
        '
        Me.tsbEdit.AutoSize = False
        Me.tsbEdit.ForeColor = System.Drawing.Color.White
        Me.tsbEdit.Image = Global.jade.My.Resources.Resources.edit_pen_write_notes_document_3c679c93cb5d1fed_512x512
        Me.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(50, 35)
        Me.tsbEdit.Text = "Edit"
        Me.tsbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbSave
        '
        Me.tsbSave.AutoSize = False
        Me.tsbSave.ForeColor = System.Drawing.Color.White
        Me.tsbSave.Image = Global.jade.My.Resources.Resources.Save_Icon
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(50, 35)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbDelete
        '
        Me.tsbDelete.AutoSize = False
        Me.tsbDelete.ForeColor = System.Drawing.Color.White
        Me.tsbDelete.Image = Global.jade.My.Resources.Resources.close_icon
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(50, 35)
        Me.tsbDelete.Text = "Delete"
        Me.tsbDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbClose
        '
        Me.tsbClose.AutoSize = False
        Me.tsbClose.ForeColor = System.Drawing.Color.White
        Me.tsbClose.Image = Global.jade.My.Resources.Resources.close_button_icon_transparent_background_247604
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(50, 35)
        Me.tsbClose.Text = "Close"
        Me.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'p
        '
        Me.p.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.p.Controls.Add(Me.txtUOM)
        Me.p.Controls.Add(Me.btnUOM)
        Me.p.Controls.Add(Me.txtStandardCost)
        Me.p.Controls.Add(Me.Label4)
        Me.p.Controls.Add(Me.txtGroupName)
        Me.p.Controls.Add(Me.Label2)
        Me.p.Controls.Add(Me.Label1)
        Me.p.Location = New System.Drawing.Point(3, 41)
        Me.p.Name = "p"
        Me.p.Size = New System.Drawing.Size(562, 104)
        Me.p.TabIndex = 1347
        Me.p.TabStop = False
        Me.p.Text = "Data"
        '
        'txtUOM
        '
        Me.txtUOM.BackColor = System.Drawing.SystemColors.Window
        Me.txtUOM.Enabled = False
        Me.txtUOM.ForeColor = System.Drawing.Color.Black
        Me.txtUOM.Location = New System.Drawing.Point(127, 40)
        Me.txtUOM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.ReadOnly = True
        Me.txtUOM.Size = New System.Drawing.Size(210, 23)
        Me.txtUOM.TabIndex = 1325
        '
        'btnUOM
        '
        Me.btnUOM.BackgroundImage = Global.jade.My.Resources.Resources.view
        Me.btnUOM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUOM.Location = New System.Drawing.Point(340, 40)
        Me.btnUOM.Name = "btnUOM"
        Me.btnUOM.Size = New System.Drawing.Size(25, 25)
        Me.btnUOM.TabIndex = 1324
        Me.btnUOM.UseVisualStyleBackColor = True
        '
        'txtStandardCost
        '
        Me.txtStandardCost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStandardCost.Location = New System.Drawing.Point(127, 66)
        Me.txtStandardCost.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStandardCost.Name = "txtStandardCost"
        Me.txtStandardCost.Size = New System.Drawing.Size(210, 23)
        Me.txtStandardCost.TabIndex = 1323
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 69)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 16)
        Me.Label4.TabIndex = 1322
        Me.Label4.Text = "Standard Cost :"
        '
        'txtGroupName
        '
        Me.txtGroupName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGroupName.Location = New System.Drawing.Point(127, 14)
        Me.txtGroupName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.Size = New System.Drawing.Size(427, 23)
        Me.txtGroupName.TabIndex = 1318
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 19)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 1319
        Me.Label2.Text = "Group Name :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Location = New System.Drawing.Point(6, 151)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(567, 3)
        Me.Panel1.TabIndex = 1324
        '
        'frmBOM_Group
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(570, 440)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.p)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvType)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBOM_Group"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item BOM Group"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.p.ResumeLayout(False)
        Me.p.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvType As System.Windows.Forms.ListView
    Friend WithEvents dgcID As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgcUOM As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgcSC As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents p As System.Windows.Forms.GroupBox
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgcDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtStandardCost As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtUOM As System.Windows.Forms.TextBox
    Friend WithEvents btnUOM As System.Windows.Forms.Button
End Class
