<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport_Filter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport_Filter))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPeriod = New System.Windows.Forms.ComboBox()
        Me.gbType = New System.Windows.Forms.GroupBox()
        Me.rbDetailed = New System.Windows.Forms.RadioButton()
        Me.rbSummary = New System.Windows.Forms.RadioButton()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.gbType.SuspendLayout()
        Me.gbPeriodYM.SuspendLayout()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPeriodFT.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 74)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 879
        Me.Label2.Text = "Period Type :"
        '
        'cbPeriod
        '
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriod.FormattingEnabled = True
        Me.cbPeriod.Items.AddRange(New Object() {"Yearly", "Monthly", "Daily", "Date Range"})
        Me.cbPeriod.Location = New System.Drawing.Point(102, 71)
        Me.cbPeriod.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.Size = New System.Drawing.Size(157, 24)
        Me.cbPeriod.TabIndex = 878
        '
        'gbType
        '
        Me.gbType.Controls.Add(Me.rbDetailed)
        Me.gbType.Controls.Add(Me.rbSummary)
        Me.gbType.Location = New System.Drawing.Point(14, 17)
        Me.gbType.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.gbType.Name = "gbType"
        Me.gbType.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.gbType.Size = New System.Drawing.Size(245, 50)
        Me.gbType.TabIndex = 874
        Me.gbType.TabStop = False
        Me.gbType.Text = "Report Type"
        '
        'rbDetailed
        '
        Me.rbDetailed.AutoSize = True
        Me.rbDetailed.Location = New System.Drawing.Point(103, 22)
        Me.rbDetailed.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rbDetailed.Name = "rbDetailed"
        Me.rbDetailed.Size = New System.Drawing.Size(71, 19)
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
        Me.rbSummary.Size = New System.Drawing.Size(78, 19)
        Me.rbSummary.TabIndex = 0
        Me.rbSummary.TabStop = True
        Me.rbSummary.Text = "Summary"
        Me.rbSummary.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(173, 216)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(88, 32)
        Me.btnPreview.TabIndex = 875
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
        Me.gbPeriodYM.Location = New System.Drawing.Point(14, 101)
        Me.gbPeriodYM.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodYM.Name = "gbPeriodYM"
        Me.gbPeriodYM.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodYM.Size = New System.Drawing.Size(245, 75)
        Me.gbPeriodYM.TabIndex = 876
        Me.gbPeriodYM.TabStop = False
        Me.gbPeriodYM.Text = "Period"
        '
        'chkYTD
        '
        Me.chkYTD.AutoSize = True
        Me.chkYTD.Location = New System.Drawing.Point(159, 17)
        Me.chkYTD.Name = "chkYTD"
        Me.chkYTD.Size = New System.Drawing.Size(49, 19)
        Me.chkYTD.TabIndex = 601
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
        Me.nupYear.Value = New Decimal(New Integer() {2018, 0, 0, 0})
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
        Me.gbPeriodFT.Location = New System.Drawing.Point(14, 101)
        Me.gbPeriodFT.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodFT.Name = "gbPeriodFT"
        Me.gbPeriodFT.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.gbPeriodFT.Size = New System.Drawing.Size(245, 75)
        Me.gbPeriodFT.TabIndex = 877
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 186)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 881
        Me.Label1.Text = "Status :"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(69, 183)
        Me.cbStatus.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(191, 24)
        Me.cbStatus.TabIndex = 880
        '
        'frmReport_Filter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(275, 264)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbPeriod)
        Me.Controls.Add(Me.gbType)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.gbPeriodYM)
        Me.Controls.Add(Me.gbPeriodFT)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReport_Filter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Filter"
        Me.gbType.ResumeLayout(False)
        Me.gbType.PerformLayout()
        Me.gbPeriodYM.ResumeLayout(False)
        Me.gbPeriodYM.PerformLayout()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPeriodFT.ResumeLayout(False)
        Me.gbPeriodFT.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents gbType As System.Windows.Forms.GroupBox
    Friend WithEvents rbDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents rbSummary As System.Windows.Forms.RadioButton
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents gbPeriodYM As System.Windows.Forms.GroupBox
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
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents chkYTD As System.Windows.Forms.CheckBox
End Class
