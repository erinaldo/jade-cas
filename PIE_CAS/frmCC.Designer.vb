<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCC))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblG5 = New System.Windows.Forms.Label()
        Me.lblG4 = New System.Windows.Forms.Label()
        Me.lblG3 = New System.Windows.Forms.Label()
        Me.lblG2 = New System.Windows.Forms.Label()
        Me.lblG1 = New System.Windows.Forms.Label()
        Me.cbG5 = New System.Windows.Forms.ComboBox()
        Me.cbG4 = New System.Windows.Forms.ComboBox()
        Me.cbG3 = New System.Windows.Forms.ComboBox()
        Me.cbG2 = New System.Windows.Forms.ComboBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.cbG1 = New System.Windows.Forms.ComboBox()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.txtOldCode = New System.Windows.Forms.TextBox()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbEdit, Me.tsbSave, Me.tsbDelete, Me.ToolStripSeparator3, Me.tsbClose, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(871, 40)
        Me.ToolStrip1.TabIndex = 1306
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.lblG5)
        Me.GroupBox1.Controls.Add(Me.lblG4)
        Me.GroupBox1.Controls.Add(Me.lblG3)
        Me.GroupBox1.Controls.Add(Me.lblG2)
        Me.GroupBox1.Controls.Add(Me.lblG1)
        Me.GroupBox1.Controls.Add(Me.cbG5)
        Me.GroupBox1.Controls.Add(Me.cbG4)
        Me.GroupBox1.Controls.Add(Me.cbG3)
        Me.GroupBox1.Controls.Add(Me.cbG2)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.cbG1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(859, 161)
        Me.GroupBox1.TabIndex = 1307
        Me.GroupBox1.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label17.Location = New System.Drawing.Point(16, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 17)
        Me.Label17.TabIndex = 1328
        Me.Label17.Text = "Description :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label16.Location = New System.Drawing.Point(54, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 17)
        Me.Label16.TabIndex = 1327
        Me.Label16.Text = "Code :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblG5
        '
        Me.lblG5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG5.Location = New System.Drawing.Point(387, 124)
        Me.lblG5.Name = "lblG5"
        Me.lblG5.Size = New System.Drawing.Size(132, 17)
        Me.lblG5.TabIndex = 1326
        Me.lblG5.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG5.Visible = False
        '
        'lblG4
        '
        Me.lblG4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG4.Location = New System.Drawing.Point(387, 98)
        Me.lblG4.Name = "lblG4"
        Me.lblG4.Size = New System.Drawing.Size(132, 17)
        Me.lblG4.TabIndex = 1325
        Me.lblG4.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG4.Visible = False
        '
        'lblG3
        '
        Me.lblG3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG3.Location = New System.Drawing.Point(387, 72)
        Me.lblG3.Name = "lblG3"
        Me.lblG3.Size = New System.Drawing.Size(132, 17)
        Me.lblG3.TabIndex = 1324
        Me.lblG3.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG3.Visible = False
        '
        'lblG2
        '
        Me.lblG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG2.Location = New System.Drawing.Point(387, 46)
        Me.lblG2.Name = "lblG2"
        Me.lblG2.Size = New System.Drawing.Size(132, 17)
        Me.lblG2.TabIndex = 1323
        Me.lblG2.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG2.Visible = False
        '
        'lblG1
        '
        Me.lblG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG1.Location = New System.Drawing.Point(387, 20)
        Me.lblG1.Name = "lblG1"
        Me.lblG1.Size = New System.Drawing.Size(132, 23)
        Me.lblG1.TabIndex = 1322
        Me.lblG1.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG1.Visible = False
        '
        'cbG5
        '
        Me.cbG5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG5.FormattingEnabled = True
        Me.cbG5.Location = New System.Drawing.Point(527, 121)
        Me.cbG5.Name = "cbG5"
        Me.cbG5.Size = New System.Drawing.Size(312, 24)
        Me.cbG5.TabIndex = 1321
        Me.cbG5.Visible = False
        '
        'cbG4
        '
        Me.cbG4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG4.FormattingEnabled = True
        Me.cbG4.Location = New System.Drawing.Point(527, 95)
        Me.cbG4.Name = "cbG4"
        Me.cbG4.Size = New System.Drawing.Size(312, 24)
        Me.cbG4.TabIndex = 1320
        Me.cbG4.Visible = False
        '
        'cbG3
        '
        Me.cbG3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG3.FormattingEnabled = True
        Me.cbG3.Location = New System.Drawing.Point(527, 69)
        Me.cbG3.Name = "cbG3"
        Me.cbG3.Size = New System.Drawing.Size(312, 24)
        Me.cbG3.TabIndex = 1319
        Me.cbG3.Visible = False
        '
        'cbG2
        '
        Me.cbG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG2.FormattingEnabled = True
        Me.cbG2.Location = New System.Drawing.Point(527, 43)
        Me.cbG2.Name = "cbG2"
        Me.cbG2.Size = New System.Drawing.Size(312, 24)
        Me.cbG2.TabIndex = 1318
        Me.cbG2.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDescription.Location = New System.Drawing.Point(106, 46)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(215, 69)
        Me.txtDescription.TabIndex = 1317
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtCode.Location = New System.Drawing.Point(106, 20)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(215, 23)
        Me.txtCode.TabIndex = 1316
        '
        'cbG1
        '
        Me.cbG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG1.FormattingEnabled = True
        Me.cbG1.Location = New System.Drawing.Point(527, 17)
        Me.cbG1.Name = "cbG1"
        Me.cbG1.Size = New System.Drawing.Size(312, 24)
        Me.cbG1.TabIndex = 1315
        Me.cbG1.Visible = False
        '
        'dgvData
        '
        Me.dgvData.AllowDrop = True
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvData.Location = New System.Drawing.Point(0, 207)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersWidth = 25
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(865, 294)
        Me.dgvData.TabIndex = 1308
        '
        'txtOldCode
        '
        Me.txtOldCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOldCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtOldCode.Location = New System.Drawing.Point(147, 275)
        Me.txtOldCode.Name = "txtOldCode"
        Me.txtOldCode.Size = New System.Drawing.Size(91, 23)
        Me.txtOldCode.TabIndex = 1329
        Me.txtOldCode.Visible = False
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
        'tsbExit
        '
        Me.tsbExit.AutoSize = False
        Me.tsbExit.ForeColor = System.Drawing.Color.White
        Me.tsbExit.Image = Global.jade.My.Resources.Resources.exit_button_icon_18
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(50, 35)
        Me.tsbExit.Text = "Exit"
        Me.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(871, 502)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtOldCode)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cost Center Maintenance"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblG5 As System.Windows.Forms.Label
    Friend WithEvents lblG4 As System.Windows.Forms.Label
    Friend WithEvents lblG3 As System.Windows.Forms.Label
    Friend WithEvents lblG2 As System.Windows.Forms.Label
    Friend WithEvents lblG1 As System.Windows.Forms.Label
    Friend WithEvents cbG5 As System.Windows.Forms.ComboBox
    Friend WithEvents cbG4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbG3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbG2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents cbG1 As System.Windows.Forms.ComboBox
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents txtOldCode As System.Windows.Forms.TextBox
End Class
