<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoan_Charges
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
        Me.dgvRecords = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.dgvRanges = New System.Windows.Forms.DataGridView()
        Me.dgcRangeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcRangeFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcRangeTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcRangeValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcChargeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcMethod = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgcValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAmort = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcRangeBasis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcRangeValueType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvRanges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRecords
        '
        Me.dgvRecords.AllowUserToAddRows = False
        Me.dgvRecords.AllowUserToDeleteRows = False
        Me.dgvRecords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcChargeID, Me.dgcDesc, Me.dgcMethod, Me.dgcValue, Me.dgcAmort, Me.dgcCode, Me.dgcTitle, Me.dgcRangeBasis, Me.dgcRangeValueType})
        Me.dgvRecords.Location = New System.Drawing.Point(0, 39)
        Me.dgvRecords.MultiSelect = False
        Me.dgvRecords.Name = "dgvRecords"
        Me.dgvRecords.RowHeadersWidth = 25
        Me.dgvRecords.Size = New System.Drawing.Size(706, 380)
        Me.dgvRecords.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.SeaGreen
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbDelete, Me.tsbSave, Me.ToolStripSeparator1, Me.tsbExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(706, 40)
        Me.ToolStrip1.TabIndex = 1406
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
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
        'dgvRanges
        '
        Me.dgvRanges.AllowUserToAddRows = False
        Me.dgvRanges.AllowUserToDeleteRows = False
        Me.dgvRanges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRanges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcRangeDesc, Me.dgcRangeFrom, Me.dgcRangeTo, Me.dgcRangeValue})
        Me.dgvRanges.Location = New System.Drawing.Point(114, 107)
        Me.dgvRanges.MultiSelect = False
        Me.dgvRanges.Name = "dgvRanges"
        Me.dgvRanges.RowHeadersWidth = 25
        Me.dgvRanges.Size = New System.Drawing.Size(478, 204)
        Me.dgvRanges.TabIndex = 1407
        Me.dgvRanges.Visible = False
        '
        'dgcRangeDesc
        '
        Me.dgcRangeDesc.HeaderText = "Description"
        Me.dgcRangeDesc.Name = "dgcRangeDesc"
        Me.dgcRangeDesc.Visible = False
        '
        'dgcRangeFrom
        '
        Me.dgcRangeFrom.HeaderText = "From"
        Me.dgcRangeFrom.Name = "dgcRangeFrom"
        Me.dgcRangeFrom.Width = 150
        '
        'dgcRangeTo
        '
        Me.dgcRangeTo.HeaderText = "To"
        Me.dgcRangeTo.Name = "dgcRangeTo"
        Me.dgcRangeTo.Width = 150
        '
        'dgcRangeValue
        '
        Me.dgcRangeValue.HeaderText = "Value"
        Me.dgcRangeValue.Name = "dgcRangeValue"
        Me.dgcRangeValue.Width = 150
        '
        'dgcChargeID
        '
        Me.dgcChargeID.HeaderText = "ChargeID"
        Me.dgcChargeID.Name = "dgcChargeID"
        Me.dgcChargeID.Visible = False
        '
        'dgcDesc
        '
        Me.dgcDesc.HeaderText = "Description"
        Me.dgcDesc.Name = "dgcDesc"
        Me.dgcDesc.Width = 180
        '
        'dgcMethod
        '
        Me.dgcMethod.HeaderText = "Method"
        Me.dgcMethod.Name = "dgcMethod"
        '
        'dgcValue
        '
        Me.dgcValue.HeaderText = "Value"
        Me.dgcValue.Name = "dgcValue"
        Me.dgcValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcValue.Width = 80
        '
        'dgcAmort
        '
        Me.dgcAmort.HeaderText = "Amortize"
        Me.dgcAmort.Name = "dgcAmort"
        Me.dgcAmort.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcAmort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcAmort.Width = 70
        '
        'dgcCode
        '
        Me.dgcCode.HeaderText = "Code"
        Me.dgcCode.Name = "dgcCode"
        Me.dgcCode.Visible = False
        '
        'dgcTitle
        '
        Me.dgcTitle.HeaderText = "Account Title"
        Me.dgcTitle.Name = "dgcTitle"
        Me.dgcTitle.Width = 250
        '
        'dgcRangeBasis
        '
        Me.dgcRangeBasis.HeaderText = "Range Basis"
        Me.dgcRangeBasis.Name = "dgcRangeBasis"
        Me.dgcRangeBasis.Visible = False
        '
        'dgcRangeValueType
        '
        Me.dgcRangeValueType.HeaderText = "Value Type"
        Me.dgcRangeValueType.Name = "dgcRangeValueType"
        Me.dgcRangeValueType.Visible = False
        '
        'frmLoan_Charges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(706, 419)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgvRecords)
        Me.Controls.Add(Me.dgvRanges)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmLoan_Charges"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Charges"
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvRanges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvRecords As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvRanges As System.Windows.Forms.DataGridView
    Friend WithEvents dgcRangeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcRangeFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcRangeTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcRangeValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcChargeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMethod As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgcValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAmort As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcRangeBasis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcRangeValueType As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
