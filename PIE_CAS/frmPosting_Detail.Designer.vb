<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatchPosting
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvPosting = New System.Windows.Forms.DataGridView()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.chType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chTransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chTransNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVariance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDrilldown = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.chInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvPosting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPosting
        '
        Me.dgvPosting.AllowUserToAddRows = False
        Me.dgvPosting.AllowUserToDeleteRows = False
        Me.dgvPosting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPosting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chType, Me.chTransID, Me.chTransNo, Me.chDebit, Me.chCredit, Me.chVariance, Me.chDrilldown, Me.chInclude})
        Me.dgvPosting.Location = New System.Drawing.Point(12, 37)
        Me.dgvPosting.Name = "dgvPosting"
        Me.dgvPosting.ReadOnly = True
        Me.dgvPosting.RowHeadersVisible = False
        Me.dgvPosting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPosting.Size = New System.Drawing.Size(714, 322)
        Me.dgvPosting.TabIndex = 1
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCredit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(303, 369)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.Size = New System.Drawing.Size(140, 22)
        Me.txtTotalCredit.TabIndex = 130
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(157, 369)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.Size = New System.Drawing.Size(140, 22)
        Me.txtTotalDebit.TabIndex = 131
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(108, 372)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 16)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Total :"
        '
        'btnPost
        '
        Me.btnPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(505, 365)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(160, 35)
        Me.btnPost.TabIndex = 1327
        Me.btnPost.Text = "Post"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(632, 12)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(76, 19)
        Me.chkAll.TabIndex = 1329
        Me.chkAll.Text = "Check All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'chType
        '
        Me.chType.HeaderText = "Type"
        Me.chType.Name = "chType"
        Me.chType.ReadOnly = True
        '
        'chTransID
        '
        Me.chTransID.HeaderText = "Trans. ID"
        Me.chTransID.Name = "chTransID"
        Me.chTransID.ReadOnly = True
        Me.chTransID.Visible = False
        '
        'chTransNo
        '
        Me.chTransNo.HeaderText = "Trans. No."
        Me.chTransNo.Name = "chTransNo"
        Me.chTransNo.ReadOnly = True
        '
        'chDebit
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.chDebit.DefaultCellStyle = DataGridViewCellStyle1
        Me.chDebit.HeaderText = "Debit"
        Me.chDebit.Name = "chDebit"
        Me.chDebit.ReadOnly = True
        Me.chDebit.Width = 150
        '
        'chCredit
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.chCredit.DefaultCellStyle = DataGridViewCellStyle2
        Me.chCredit.HeaderText = "Credit"
        Me.chCredit.Name = "chCredit"
        Me.chCredit.ReadOnly = True
        Me.chCredit.Width = 150
        '
        'chVariance
        '
        Me.chVariance.HeaderText = "Variance"
        Me.chVariance.Name = "chVariance"
        Me.chVariance.ReadOnly = True
        '
        'chDrilldown
        '
        Me.chDrilldown.HeaderText = ">>"
        Me.chDrilldown.Name = "chDrilldown"
        Me.chDrilldown.ReadOnly = True
        Me.chDrilldown.Width = 30
        '
        'chInclude
        '
        Me.chInclude.HeaderText = "Include"
        Me.chInclude.Name = "chInclude"
        Me.chInclude.ReadOnly = True
        Me.chInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmBatchPosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(734, 406)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.txtTotalCredit)
        Me.Controls.Add(Me.txtTotalDebit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvPosting)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmBatchPosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Posting"
        CType(Me.dgvPosting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPosting As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents chType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chTransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chTransNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVariance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDrilldown As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents chInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
