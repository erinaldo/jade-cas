<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosting_Main
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvBooks = New System.Windows.Forms.DataGridView()
        Me.chBook = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chVariance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.BtnSearchOR = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.nupYear = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBooks
        '
        Me.dgvBooks.AllowUserToAddRows = False
        Me.dgvBooks.AllowUserToDeleteRows = False
        Me.dgvBooks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBooks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chBook, Me.chDebit, Me.chCredit, Me.chVariance, Me.Column9})
        Me.dgvBooks.Location = New System.Drawing.Point(16, 69)
        Me.dgvBooks.Name = "dgvBooks"
        Me.dgvBooks.ReadOnly = True
        Me.dgvBooks.RowHeadersVisible = False
        Me.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBooks.Size = New System.Drawing.Size(577, 302)
        Me.dgvBooks.TabIndex = 1
        '
        'chBook
        '
        Me.chBook.HeaderText = "Book"
        Me.chBook.Name = "chBook"
        Me.chBook.ReadOnly = True
        Me.chBook.Width = 160
        '
        'chDebit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.chDebit.DefaultCellStyle = DataGridViewCellStyle3
        Me.chDebit.HeaderText = "Debit"
        Me.chDebit.Name = "chDebit"
        Me.chDebit.ReadOnly = True
        Me.chDebit.Width = 150
        '
        'chCredit
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.chCredit.DefaultCellStyle = DataGridViewCellStyle4
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
        Me.chVariance.Width = 80
        '
        'Column9
        '
        Me.Column9.HeaderText = ">>"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column9.Width = 30
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCredit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(326, 377)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.Size = New System.Drawing.Size(140, 22)
        Me.txtTotalCredit.TabIndex = 130
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(180, 377)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.Size = New System.Drawing.Size(140, 22)
        Me.txtTotalDebit.TabIndex = 131
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(123, 380)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 16)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Total :"
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(323, 9)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(186, 22)
        Me.dtpFrom.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(236, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "From Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(255, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(323, 38)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(186, 22)
        Me.dtpTo.TabIndex = 136
        '
        'BtnSearchOR
        '
        Me.BtnSearchOR.Location = New System.Drawing.Point(517, 38)
        Me.BtnSearchOR.Name = "BtnSearchOR"
        Me.BtnSearchOR.Size = New System.Drawing.Size(24, 25)
        Me.BtnSearchOR.TabIndex = 1316
        Me.BtnSearchOR.Text = ">>"
        Me.BtnSearchOR.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 1336
        Me.Label5.Text = "Month :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cbMonth.Location = New System.Drawing.Point(85, 38)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(133, 23)
        Me.cbMonth.TabIndex = 1333
        '
        'nupYear
        '
        Me.nupYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupYear.Location = New System.Drawing.Point(85, 13)
        Me.nupYear.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nupYear.Name = "nupYear"
        Me.nupYear.Size = New System.Drawing.Size(133, 22)
        Me.nupYear.TabIndex = 1337
        Me.nupYear.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 1338
        Me.Label3.Text = "Year :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmPosting_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(605, 406)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nupYear)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbMonth)
        Me.Controls.Add(Me.BtnSearchOR)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalCredit)
        Me.Controls.Add(Me.txtTotalDebit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvBooks)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPosting_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Posting"
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBooks As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSearchOR As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents nupYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chBook As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chVariance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewButtonColumn
End Class
