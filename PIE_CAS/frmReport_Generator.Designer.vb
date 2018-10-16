<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport_Generator
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
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lvFilter = New System.Windows.Forms.ListView()
        Me.chFilter = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rbSpecific = New System.Windows.Forms.RadioButton()
        Me.rbNone = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPeriod = New System.Windows.Forms.ComboBox()
        Me.gbType = New System.Windows.Forms.GroupBox()
        Me.rbDetailed = New System.Windows.Forms.RadioButton()
        Me.rbSummary = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbReport = New System.Windows.Forms.ComboBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.gbPeriodYM = New System.Windows.Forms.GroupBox()
        Me.chkYTD = New System.Windows.Forms.CheckBox()
        Me.nupYear = New System.Windows.Forms.NumericUpDown()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.gbPeriodFT = New System.Windows.Forms.GroupBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbType.SuspendLayout()
        Me.gbPeriodYM.SuspendLayout()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPeriodFT.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.cbBranch)
        Me.GroupBox6.Controls.Add(Me.GroupBox1)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.cbPeriod)
        Me.GroupBox6.Controls.Add(Me.gbType)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.cbReport)
        Me.GroupBox6.Controls.Add(Me.btnPreview)
        Me.GroupBox6.Controls.Add(Me.gbPeriodYM)
        Me.GroupBox6.Controls.Add(Me.gbPeriodFT)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(349, 480)
        Me.GroupBox6.TabIndex = 580
        Me.GroupBox6.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 221)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 868
        Me.Label1.Text = "Branch :"
        '
        'cbBranch
        '
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Items.AddRange(New Object() {"Yearly", "Monthly", "Daily", "Date Range"})
        Me.cbBranch.Location = New System.Drawing.Point(82, 218)
        Me.cbBranch.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(245, 24)
        Me.cbBranch.TabIndex = 867
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lvFilter)
        Me.GroupBox1.Controls.Add(Me.rbSpecific)
        Me.GroupBox1.Controls.Add(Me.rbNone)
        Me.GroupBox1.Controls.Add(Me.rbAll)
        Me.GroupBox1.Location = New System.Drawing.Point(82, 247)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(245, 162)
        Me.GroupBox1.TabIndex = 866
        Me.GroupBox1.TabStop = False
        '
        'lvFilter
        '
        Me.lvFilter.CheckBoxes = True
        Me.lvFilter.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chFilter})
        Me.lvFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFilter.Location = New System.Drawing.Point(1, 35)
        Me.lvFilter.MultiSelect = False
        Me.lvFilter.Name = "lvFilter"
        Me.lvFilter.Size = New System.Drawing.Size(242, 127)
        Me.lvFilter.TabIndex = 598
        Me.lvFilter.UseCompatibleStateImageBehavior = False
        Me.lvFilter.View = System.Windows.Forms.View.Details
        '
        'chFilter
        '
        Me.chFilter.Text = "Filter"
        Me.chFilter.Width = 241
        '
        'rbSpecific
        '
        Me.rbSpecific.AutoSize = True
        Me.rbSpecific.Location = New System.Drawing.Point(73, 12)
        Me.rbSpecific.Name = "rbSpecific"
        Me.rbSpecific.Size = New System.Drawing.Size(74, 20)
        Me.rbSpecific.TabIndex = 865
        Me.rbSpecific.TabStop = True
        Me.rbSpecific.Text = "Specific"
        Me.rbSpecific.UseVisualStyleBackColor = True
        '
        'rbNone
        '
        Me.rbNone.AutoSize = True
        Me.rbNone.Location = New System.Drawing.Point(155, 12)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(88, 20)
        Me.rbNone.TabIndex = 864
        Me.rbNone.TabStop = True
        Me.rbNone.Text = "Pick None"
        Me.rbNone.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Location = New System.Drawing.Point(21, 12)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(41, 20)
        Me.rbAll.TabIndex = 863
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 98)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 32)
        Me.Label2.TabIndex = 601
        Me.Label2.Text = "Period " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Type :"
        '
        'cbPeriod
        '
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriod.FormattingEnabled = True
        Me.cbPeriod.Items.AddRange(New Object() {"Yearly", "Monthly", "Daily", "Date Range"})
        Me.cbPeriod.Location = New System.Drawing.Point(82, 103)
        Me.cbPeriod.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.Size = New System.Drawing.Size(245, 24)
        Me.cbPeriod.TabIndex = 600
        '
        'gbType
        '
        Me.gbType.Controls.Add(Me.rbDetailed)
        Me.gbType.Controls.Add(Me.rbSummary)
        Me.gbType.Location = New System.Drawing.Point(82, 49)
        Me.gbType.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.gbType.Name = "gbType"
        Me.gbType.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.gbType.Size = New System.Drawing.Size(245, 50)
        Me.gbType.TabIndex = 578
        Me.gbType.TabStop = False
        Me.gbType.Text = "Report Type"
        '
        'rbDetailed
        '
        Me.rbDetailed.AutoSize = True
        Me.rbDetailed.Location = New System.Drawing.Point(103, 22)
        Me.rbDetailed.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rbDetailed.Name = "rbDetailed"
        Me.rbDetailed.Size = New System.Drawing.Size(77, 20)
        Me.rbDetailed.TabIndex = 1
        Me.rbDetailed.Text = "Detailed"
        Me.rbDetailed.UseVisualStyleBackColor = True
        '
        'rbSummary
        '
        Me.rbSummary.AutoSize = True
        Me.rbSummary.Checked = True
        Me.rbSummary.Location = New System.Drawing.Point(10, 22)
        Me.rbSummary.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rbSummary.Name = "rbSummary"
        Me.rbSummary.Size = New System.Drawing.Size(83, 20)
        Me.rbSummary.TabIndex = 0
        Me.rbSummary.TabStop = True
        Me.rbSummary.Text = "Summary"
        Me.rbSummary.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 26)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 16)
        Me.Label14.TabIndex = 593
        Me.Label14.Text = "Report :"
        '
        'cbReport
        '
        Me.cbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReport.FormattingEnabled = True
        Me.cbReport.Items.AddRange(New Object() {"Trial Balance", "Subsidiary Ledger Schedule", "Account Schedule", "Book of Accounts"})
        Me.cbReport.Location = New System.Drawing.Point(82, 23)
        Me.cbReport.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cbReport.Name = "cbReport"
        Me.cbReport.Size = New System.Drawing.Size(245, 24)
        Me.cbReport.TabIndex = 592
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(82, 416)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(88, 32)
        Me.btnPreview.TabIndex = 591
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'gbPeriodYM
        '
        Me.gbPeriodYM.Controls.Add(Me.chkYTD)
        Me.gbPeriodYM.Controls.Add(Me.nupYear)
        Me.gbPeriodYM.Controls.Add(Me.lblMonth)
        Me.gbPeriodYM.Controls.Add(Me.Label4)
        Me.gbPeriodYM.Controls.Add(Me.cbMonth)
        Me.gbPeriodYM.Location = New System.Drawing.Point(82, 133)
        Me.gbPeriodYM.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodYM.Name = "gbPeriodYM"
        Me.gbPeriodYM.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodYM.Size = New System.Drawing.Size(245, 75)
        Me.gbPeriodYM.TabIndex = 599
        Me.gbPeriodYM.TabStop = False
        Me.gbPeriodYM.Text = "Period"
        '
        'chkYTD
        '
        Me.chkYTD.AutoSize = True
        Me.chkYTD.Location = New System.Drawing.Point(169, 15)
        Me.chkYTD.Name = "chkYTD"
        Me.chkYTD.Size = New System.Drawing.Size(55, 20)
        Me.chkYTD.TabIndex = 600
        Me.chkYTD.Text = "YTD"
        Me.chkYTD.UseVisualStyleBackColor = True
        Me.chkYTD.Visible = False
        '
        'nupYear
        '
        Me.nupYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupYear.Location = New System.Drawing.Point(63, 16)
        Me.nupYear.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.nupYear.Name = "nupYear"
        Me.nupYear.Size = New System.Drawing.Size(68, 22)
        Me.nupYear.TabIndex = 599
        Me.nupYear.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.Location = New System.Drawing.Point(13, 44)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(50, 16)
        Me.lblMonth.TabIndex = 597
        Me.lblMonth.Text = "Month :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 19)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 596
        Me.Label4.Text = "Year :"
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cbMonth.Location = New System.Drawing.Point(63, 40)
        Me.cbMonth.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(161, 24)
        Me.cbMonth.TabIndex = 595
        '
        'gbPeriodFT
        '
        Me.gbPeriodFT.Controls.Add(Me.dtpFrom)
        Me.gbPeriodFT.Controls.Add(Me.lblFrom)
        Me.gbPeriodFT.Controls.Add(Me.lblTo)
        Me.gbPeriodFT.Controls.Add(Me.dtpTo)
        Me.gbPeriodFT.Location = New System.Drawing.Point(82, 133)
        Me.gbPeriodFT.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodFT.Name = "gbPeriodFT"
        Me.gbPeriodFT.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodFT.Size = New System.Drawing.Size(245, 75)
        Me.gbPeriodFT.TabIndex = 599
        Me.gbPeriodFT.TabStop = False
        Me.gbPeriodFT.Text = "Period"
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(71, 19)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(107, 22)
        Me.dtpFrom.TabIndex = 592
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.Location = New System.Drawing.Point(25, 22)
        Me.lblFrom.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(45, 16)
        Me.lblFrom.TabIndex = 575
        Me.lblFrom.Text = "From :"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(39, 44)
        Me.lblTo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(31, 16)
        Me.lblTo.TabIndex = 576
        Me.lblTo.Text = "To :"
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(71, 43)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(107, 22)
        Me.dtpTo.TabIndex = 593
        '
        'frmReport_Generator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(365, 497)
        Me.Controls.Add(Me.GroupBox6)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmReport_Generator"
        Me.Text = "Report Generator"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbType.ResumeLayout(False)
        Me.gbType.PerformLayout()
        Me.gbPeriodYM.ResumeLayout(False)
        Me.gbPeriodYM.PerformLayout()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPeriodFT.ResumeLayout(False)
        Me.gbPeriodFT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvFilter As System.Windows.Forms.ListView
    Friend WithEvents chFilter As System.Windows.Forms.ColumnHeader
    Friend WithEvents rbSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents gbType As System.Windows.Forms.GroupBox
    Friend WithEvents rbDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents rbSummary As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbReport As System.Windows.Forms.ComboBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents gbPeriodYM As System.Windows.Forms.GroupBox
    Friend WithEvents chkYTD As System.Windows.Forms.CheckBox
    Friend WithEvents nupYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents gbPeriodFT As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
End Class
