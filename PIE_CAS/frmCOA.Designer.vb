<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCOA
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvPreview = New System.Windows.Forms.DataGridView()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.dgvUndo = New System.Windows.Forms.DataGridView()
        Me.chFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUndo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.btnUndo)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.dgvPreview)
        Me.GroupBox1.Controls.Add(Me.btnDown)
        Me.GroupBox1.Controls.Add(Me.btnUp)
        Me.GroupBox1.Controls.Add(Me.dgvUndo)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.cbType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(923, 566)
        Me.GroupBox1.TabIndex = 1341
        Me.GroupBox1.TabStop = False
        '
        'btnUndo
        '
        Me.btnUndo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUndo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnUndo.Location = New System.Drawing.Point(827, 175)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(79, 29)
        Me.btnUndo.TabIndex = 1365
        Me.btnUndo.Text = "&Undo"
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(827, 87)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(79, 29)
        Me.btnEdit.TabIndex = 1364
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnSave.Location = New System.Drawing.Point(827, 531)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 29)
        Me.btnSave.TabIndex = 1363
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dgvPreview
        '
        Me.dgvPreview.AllowDrop = True
        Me.dgvPreview.AllowUserToAddRows = False
        Me.dgvPreview.AllowUserToDeleteRows = False
        Me.dgvPreview.AllowUserToOrderColumns = True
        Me.dgvPreview.AllowUserToResizeColumns = False
        Me.dgvPreview.AllowUserToResizeRows = False
        Me.dgvPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPreview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPreview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPreview.ColumnHeadersHeight = 18
        Me.dgvPreview.ColumnHeadersVisible = False
        Me.dgvPreview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chCode, Me.chTitle, Me.chGroup})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPreview.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPreview.GridColor = System.Drawing.Color.White
        Me.dgvPreview.Location = New System.Drawing.Point(7, 57)
        Me.dgvPreview.MultiSelect = False
        Me.dgvPreview.Name = "dgvPreview"
        Me.dgvPreview.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPreview.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPreview.RowHeadersVisible = False
        Me.dgvPreview.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.dgvPreview.RowTemplate.Height = 16
        Me.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPreview.ShowCellToolTips = False
        Me.dgvPreview.Size = New System.Drawing.Size(814, 503)
        Me.dgvPreview.TabIndex = 1355
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown.Location = New System.Drawing.Point(827, 146)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(34, 28)
        Me.btnDown.TabIndex = 1354
        Me.btnDown.Text = "↓"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp.Location = New System.Drawing.Point(827, 117)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(34, 28)
        Me.btnUp.TabIndex = 1353
        Me.btnUp.Text = "↑"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'dgvUndo
        '
        Me.dgvUndo.AllowUserToAddRows = False
        Me.dgvUndo.AllowUserToDeleteRows = False
        Me.dgvUndo.AllowUserToOrderColumns = True
        Me.dgvUndo.AllowUserToResizeColumns = False
        Me.dgvUndo.AllowUserToResizeRows = False
        Me.dgvUndo.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUndo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvUndo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUndo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chFrom, Me.chTo})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUndo.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvUndo.Location = New System.Drawing.Point(21, 57)
        Me.dgvUndo.Name = "dgvUndo"
        Me.dgvUndo.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUndo.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvUndo.RowHeadersVisible = False
        Me.dgvUndo.Size = New System.Drawing.Size(469, 299)
        Me.dgvUndo.TabIndex = 1343
        Me.dgvUndo.Visible = False
        '
        'chFrom
        '
        Me.chFrom.HeaderText = "From"
        Me.chFrom.Name = "chFrom"
        Me.chFrom.ReadOnly = True
        '
        'chTo
        '
        Me.chTo.HeaderText = "To"
        Me.chTo.Name = "chTo"
        Me.chTo.ReadOnly = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(827, 57)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(79, 29)
        Me.btnAdd.TabIndex = 1352
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Balance Sheet", "Income Statement"})
        Me.cbType.Location = New System.Drawing.Point(77, 19)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(244, 23)
        Me.cbType.TabIndex = 1350
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(32, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 1349
        Me.Label1.Text = "Type :"
        '
        'chCode
        '
        Me.chCode.HeaderText = "Code"
        Me.chCode.Name = "chCode"
        Me.chCode.ReadOnly = True
        Me.chCode.Visible = False
        Me.chCode.Width = 150
        '
        'chTitle
        '
        Me.chTitle.HeaderText = "Balance Sheet"
        Me.chTitle.Name = "chTitle"
        Me.chTitle.ReadOnly = True
        Me.chTitle.Width = 1000
        '
        'chGroup
        '
        Me.chGroup.HeaderText = "Group"
        Me.chGroup.Name = "chGroup"
        Me.chGroup.ReadOnly = True
        Me.chGroup.Visible = False
        '
        'frmCOA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(944, 590)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmCOA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chart of Account"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUndo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvUndo As System.Windows.Forms.DataGridView
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents dgvPreview As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents chFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnUndo As System.Windows.Forms.Button
    Friend WithEvents chCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chGroup As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
