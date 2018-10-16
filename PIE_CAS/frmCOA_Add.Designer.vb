<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCOA_Add
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
        Me.cbGroup = New System.Windows.Forms.ComboBox()
        Me.lblMainAccnt = New System.Windows.Forms.Label()
        Me.txtAccntTitle = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSaveClose = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAccntCode = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.rbDebit = New System.Windows.Forms.RadioButton()
        Me.rbCredit = New System.Windows.Forms.RadioButton()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSubsidiary = New System.Windows.Forms.CheckBox()
        Me.chkAllow = New System.Windows.Forms.CheckBox()
        Me.panelAccount = New System.Windows.Forms.Panel()
        Me.btnSaveNew = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.panelAccount.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbGroup
        '
        Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbGroup.FormattingEnabled = True
        Me.cbGroup.Location = New System.Drawing.Point(125, 39)
        Me.cbGroup.Name = "cbGroup"
        Me.cbGroup.Size = New System.Drawing.Size(180, 23)
        Me.cbGroup.TabIndex = 2
        '
        'lblMainAccnt
        '
        Me.lblMainAccnt.AutoSize = True
        Me.lblMainAccnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblMainAccnt.Location = New System.Drawing.Point(72, 39)
        Me.lblMainAccnt.Name = "lblMainAccnt"
        Me.lblMainAccnt.Size = New System.Drawing.Size(47, 15)
        Me.lblMainAccnt.TabIndex = 1354
        Me.lblMainAccnt.Text = "Group :"
        '
        'txtAccntTitle
        '
        Me.txtAccntTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAccntTitle.Location = New System.Drawing.Point(125, 91)
        Me.txtAccntTitle.Name = "txtAccntTitle"
        Me.txtAccntTitle.Size = New System.Drawing.Size(247, 21)
        Me.txtAccntTitle.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(77, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 15)
        Me.Label7.TabIndex = 1353
        Me.Label7.Text = "Code :"
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveClose.Location = New System.Drawing.Point(142, 229)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(111, 41)
        Me.btnSaveClose.TabIndex = 12
        Me.btnSaveClose.Text = "&Save && Close"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(44, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 15)
        Me.Label8.TabIndex = 1352
        Me.Label8.Text = "Description :"
        '
        'txtAccntCode
        '
        Me.txtAccntCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAccntCode.Location = New System.Drawing.Point(125, 66)
        Me.txtAccntCode.Name = "txtAccntCode"
        Me.txtAccntCode.Size = New System.Drawing.Size(247, 21)
        Me.txtAccntCode.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(259, 229)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(111, 41)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'rbDebit
        '
        Me.rbDebit.AutoSize = True
        Me.rbDebit.Checked = True
        Me.rbDebit.Location = New System.Drawing.Point(114, 24)
        Me.rbDebit.Name = "rbDebit"
        Me.rbDebit.Size = New System.Drawing.Size(54, 19)
        Me.rbDebit.TabIndex = 7
        Me.rbDebit.TabStop = True
        Me.rbDebit.Text = "Debit"
        Me.rbDebit.UseVisualStyleBackColor = True
        '
        'rbCredit
        '
        Me.rbCredit.AutoSize = True
        Me.rbCredit.Location = New System.Drawing.Point(172, 24)
        Me.rbCredit.Name = "rbCredit"
        Me.rbCredit.Size = New System.Drawing.Size(57, 19)
        Me.rbCredit.TabIndex = 8
        Me.rbCredit.Text = "Credit"
        Me.rbCredit.UseVisualStyleBackColor = True
        '
        'txtAlias
        '
        Me.txtAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtAlias.Location = New System.Drawing.Point(125, 116)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(247, 21)
        Me.txtAlias.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(40, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 15)
        Me.Label1.TabIndex = 1360
        Me.Label1.Text = "Report Alias :"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Balance Sheet", "Income Statement"})
        Me.cbType.Location = New System.Drawing.Point(125, 12)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(247, 23)
        Me.cbType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(80, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 1361
        Me.Label2.Text = "Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(3, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 15)
        Me.Label3.TabIndex = 1363
        Me.Label3.Text = "Nature of Account :"
        '
        'chkSubsidiary
        '
        Me.chkSubsidiary.AutoSize = True
        Me.chkSubsidiary.Location = New System.Drawing.Point(114, 45)
        Me.chkSubsidiary.Name = "chkSubsidiary"
        Me.chkSubsidiary.Size = New System.Drawing.Size(150, 19)
        Me.chkSubsidiary.TabIndex = 9
        Me.chkSubsidiary.Text = "with Subsidiary Ledger"
        Me.chkSubsidiary.UseVisualStyleBackColor = True
        '
        'chkAllow
        '
        Me.chkAllow.AutoSize = True
        Me.chkAllow.Location = New System.Drawing.Point(114, 6)
        Me.chkAllow.Name = "chkAllow"
        Me.chkAllow.Size = New System.Drawing.Size(85, 19)
        Me.chkAllow.TabIndex = 6
        Me.chkAllow.Text = "Allow Entry"
        Me.chkAllow.UseVisualStyleBackColor = True
        '
        'panelAccount
        '
        Me.panelAccount.Controls.Add(Me.Label3)
        Me.panelAccount.Controls.Add(Me.rbCredit)
        Me.panelAccount.Controls.Add(Me.chkAllow)
        Me.panelAccount.Controls.Add(Me.chkSubsidiary)
        Me.panelAccount.Controls.Add(Me.rbDebit)
        Me.panelAccount.Location = New System.Drawing.Point(12, 143)
        Me.panelAccount.Name = "panelAccount"
        Me.panelAccount.Size = New System.Drawing.Size(367, 72)
        Me.panelAccount.TabIndex = 1366
        '
        'btnSaveNew
        '
        Me.btnSaveNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveNew.Location = New System.Drawing.Point(25, 229)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.Size = New System.Drawing.Size(111, 41)
        Me.btnSaveNew.TabIndex = 11
        Me.btnSaveNew.Text = "Save && Create &New"
        Me.btnSaveNew.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(311, 39)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(59, 23)
        Me.btnAdd.TabIndex = 1367
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'frmCOA_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(391, 282)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnSaveNew)
        Me.Controls.Add(Me.panelAccount)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cbGroup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMainAccnt)
        Me.Controls.Add(Me.txtAlias)
        Me.Controls.Add(Me.txtAccntTitle)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAccntCode)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCOA_Add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Account"
        Me.panelAccount.ResumeLayout(False)
        Me.panelAccount.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents lblMainAccnt As System.Windows.Forms.Label
    Friend WithEvents txtAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rbDebit As System.Windows.Forms.RadioButton
    Friend WithEvents rbCredit As System.Windows.Forms.RadioButton
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkSubsidiary As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllow As System.Windows.Forms.CheckBox
    Friend WithEvents panelAccount As System.Windows.Forms.Panel
    Friend WithEvents btnSaveNew As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
