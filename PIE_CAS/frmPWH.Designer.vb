<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPWH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPWH))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAccntTitle = New System.Windows.Forms.TextBox()
        Me.txtAccntCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dgcProcessNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcProcess = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAccountTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(973, 40)
        Me.ToolStrip1.TabIndex = 1306
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtAccntTitle)
        Me.GroupBox1.Controls.Add(Me.txtAccntCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
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
        Me.GroupBox1.Size = New System.Drawing.Size(961, 161)
        Me.GroupBox1.TabIndex = 1307
        Me.GroupBox1.TabStop = False
        '
        'txtAccntTitle
        '
        Me.txtAccntTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccntTitle.ForeColor = System.Drawing.Color.Black
        Me.txtAccntTitle.Location = New System.Drawing.Point(107, 117)
        Me.txtAccntTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccntTitle.Name = "txtAccntTitle"
        Me.txtAccntTitle.Size = New System.Drawing.Size(282, 21)
        Me.txtAccntTitle.TabIndex = 1333
        '
        'txtAccntCode
        '
        Me.txtAccntCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccntCode.Enabled = False
        Me.txtAccntCode.ForeColor = System.Drawing.Color.Black
        Me.txtAccntCode.Location = New System.Drawing.Point(107, 94)
        Me.txtAccntCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccntCode.Name = "txtAccntCode"
        Me.txtAccntCode.Size = New System.Drawing.Size(282, 21)
        Me.txtAccntCode.TabIndex = 1334
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 1332
        Me.Label2.Text = "Account Title :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(2, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 17)
        Me.Label1.TabIndex = 1330
        Me.Label1.Text = "Account Code :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label17.Location = New System.Drawing.Point(19, 46)
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
        Me.Label16.Location = New System.Drawing.Point(57, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 17)
        Me.Label16.TabIndex = 1327
        Me.Label16.Text = "Code :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblG5
        '
        Me.lblG5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblG5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG5.Location = New System.Drawing.Point(493, 125)
        Me.lblG5.Name = "lblG5"
        Me.lblG5.Size = New System.Drawing.Size(132, 17)
        Me.lblG5.TabIndex = 1326
        Me.lblG5.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG5.Visible = False
        '
        'lblG4
        '
        Me.lblG4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblG4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG4.Location = New System.Drawing.Point(493, 99)
        Me.lblG4.Name = "lblG4"
        Me.lblG4.Size = New System.Drawing.Size(132, 17)
        Me.lblG4.TabIndex = 1325
        Me.lblG4.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG4.Visible = False
        '
        'lblG3
        '
        Me.lblG3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblG3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG3.Location = New System.Drawing.Point(493, 73)
        Me.lblG3.Name = "lblG3"
        Me.lblG3.Size = New System.Drawing.Size(132, 17)
        Me.lblG3.TabIndex = 1324
        Me.lblG3.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG3.Visible = False
        '
        'lblG2
        '
        Me.lblG2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG2.Location = New System.Drawing.Point(493, 47)
        Me.lblG2.Name = "lblG2"
        Me.lblG2.Size = New System.Drawing.Size(132, 17)
        Me.lblG2.TabIndex = 1323
        Me.lblG2.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG2.Visible = False
        '
        'lblG1
        '
        Me.lblG1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblG1.Location = New System.Drawing.Point(493, 21)
        Me.lblG1.Name = "lblG1"
        Me.lblG1.Size = New System.Drawing.Size(132, 23)
        Me.lblG1.TabIndex = 1322
        Me.lblG1.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblG1.Visible = False
        '
        'cbG5
        '
        Me.cbG5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbG5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG5.FormattingEnabled = True
        Me.cbG5.Location = New System.Drawing.Point(633, 122)
        Me.cbG5.Name = "cbG5"
        Me.cbG5.Size = New System.Drawing.Size(312, 24)
        Me.cbG5.TabIndex = 1321
        Me.cbG5.Visible = False
        '
        'cbG4
        '
        Me.cbG4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbG4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG4.FormattingEnabled = True
        Me.cbG4.Location = New System.Drawing.Point(633, 96)
        Me.cbG4.Name = "cbG4"
        Me.cbG4.Size = New System.Drawing.Size(312, 24)
        Me.cbG4.TabIndex = 1320
        Me.cbG4.Visible = False
        '
        'cbG3
        '
        Me.cbG3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbG3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG3.FormattingEnabled = True
        Me.cbG3.Location = New System.Drawing.Point(633, 70)
        Me.cbG3.Name = "cbG3"
        Me.cbG3.Size = New System.Drawing.Size(312, 24)
        Me.cbG3.TabIndex = 1319
        Me.cbG3.Visible = False
        '
        'cbG2
        '
        Me.cbG2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG2.FormattingEnabled = True
        Me.cbG2.Location = New System.Drawing.Point(633, 44)
        Me.cbG2.Name = "cbG2"
        Me.cbG2.Size = New System.Drawing.Size(312, 24)
        Me.cbG2.TabIndex = 1318
        Me.cbG2.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDescription.Location = New System.Drawing.Point(107, 45)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(282, 47)
        Me.txtDescription.TabIndex = 1317
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtCode.Location = New System.Drawing.Point(107, 20)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(282, 23)
        Me.txtCode.TabIndex = 1316
        '
        'cbG1
        '
        Me.cbG1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbG1.FormattingEnabled = True
        Me.cbG1.Location = New System.Drawing.Point(633, 18)
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
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvData.Location = New System.Drawing.Point(0, 207)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersWidth = 25
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(532, 294)
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
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcProcessNo, Me.dgcProcess, Me.dgcAccountCode, Me.dgcAccountTitle})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(3, 17)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(423, 274)
        Me.DataGridView1.TabIndex = 1330
        '
        'dgcProcessNo
        '
        Me.dgcProcessNo.HeaderText = "No."
        Me.dgcProcessNo.Name = "dgcProcessNo"
        Me.dgcProcessNo.ReadOnly = True
        Me.dgcProcessNo.Width = 51
        '
        'dgcProcess
        '
        Me.dgcProcess.HeaderText = "Process"
        Me.dgcProcess.Name = "dgcProcess"
        Me.dgcProcess.ReadOnly = True
        Me.dgcProcess.Width = 76
        '
        'dgcAccountCode
        '
        Me.dgcAccountCode.HeaderText = "Code"
        Me.dgcAccountCode.Name = "dgcAccountCode"
        Me.dgcAccountCode.ReadOnly = True
        Me.dgcAccountCode.Visible = False
        Me.dgcAccountCode.Width = 61
        '
        'dgcAccountTitle
        '
        Me.dgcAccountTitle.HeaderText = "Default Account"
        Me.dgcAccountTitle.Name = "dgcAccountTitle"
        Me.dgcAccountTitle.ReadOnly = True
        Me.dgcAccountTitle.Width = 107
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(538, 207)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 294)
        Me.GroupBox2.TabIndex = 1335
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Work in Process"
        '
        'frmPWH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(973, 502)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtOldCode)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPWH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warehouse Maintenance"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgcProcessNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcProcess As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAccountTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
