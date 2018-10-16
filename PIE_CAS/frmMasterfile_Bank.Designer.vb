<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterfile_Bank
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAccntTitle = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBankAccntNo = New System.Windows.Forms.TextBox()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSeriesFr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSeriesTo = New System.Windows.Forms.TextBox()
        Me.lvBank = New System.Windows.Forms.ListView()
        Me.chIDX = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chBank = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chBranch = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAccntCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAccntTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chBankAccount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCheckSeriesFrom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCheckSeriesTo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.txtAccntCode = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(42, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 1335
        Me.Label4.Text = "Account Title :"
        '
        'txtAccntTitle
        '
        Me.txtAccntTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccntTitle.Location = New System.Drawing.Point(137, 97)
        Me.txtAccntTitle.Name = "txtAccntTitle"
        Me.txtAccntTitle.Size = New System.Drawing.Size(300, 22)
        Me.txtAccntTitle.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(50, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 1333
        Me.Label7.Text = "Bank Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 1329
        Me.Label1.Text = "Account Code :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 16)
        Me.Label6.TabIndex = 1337
        Me.Label6.Text = "Bank Account No :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(77, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 16)
        Me.Label8.TabIndex = 1331
        Me.Label8.Text = "Branch :"
        '
        'txtBankAccntNo
        '
        Me.txtBankAccntNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankAccntNo.Location = New System.Drawing.Point(137, 123)
        Me.txtBankAccntNo.Name = "txtBankAccntNo"
        Me.txtBankAccntNo.Size = New System.Drawing.Size(300, 22)
        Me.txtBankAccntNo.TabIndex = 5
        '
        'txtBank
        '
        Me.txtBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBank.Location = New System.Drawing.Point(137, 19)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.Size = New System.Drawing.Size(300, 22)
        Me.txtBank.TabIndex = 1
        '
        'txtBranch
        '
        Me.txtBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.Location = New System.Drawing.Point(137, 45)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(300, 22)
        Me.txtBranch.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 1339
        Me.Label2.Text = "Series From :"
        '
        'txtSeriesFr
        '
        Me.txtSeriesFr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeriesFr.Location = New System.Drawing.Point(137, 149)
        Me.txtSeriesFr.Name = "txtSeriesFr"
        Me.txtSeriesFr.Size = New System.Drawing.Size(300, 22)
        Me.txtSeriesFr.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 1341
        Me.Label3.Text = "Series To :"
        '
        'txtSeriesTo
        '
        Me.txtSeriesTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeriesTo.Location = New System.Drawing.Point(137, 175)
        Me.txtSeriesTo.Name = "txtSeriesTo"
        Me.txtSeriesTo.Size = New System.Drawing.Size(300, 22)
        Me.txtSeriesTo.TabIndex = 7
        '
        'lvBank
        '
        Me.lvBank.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBank.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chIDX, Me.chBank, Me.chBranch, Me.chAccntCode, Me.chAccntTitle, Me.chBankAccount, Me.chCheckSeriesFrom, Me.chCheckSeriesTo})
        Me.lvBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBank.FullRowSelect = True
        Me.lvBank.GridLines = True
        Me.lvBank.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvBank.Location = New System.Drawing.Point(12, 12)
        Me.lvBank.MultiSelect = False
        Me.lvBank.Name = "lvBank"
        Me.lvBank.Size = New System.Drawing.Size(893, 193)
        Me.lvBank.TabIndex = 1344
        Me.lvBank.UseCompatibleStateImageBehavior = False
        Me.lvBank.View = System.Windows.Forms.View.Details
        '
        'chIDX
        '
        Me.chIDX.Text = "idx"
        Me.chIDX.Width = 0
        '
        'chBank
        '
        Me.chBank.Text = "Bank"
        Me.chBank.Width = 211
        '
        'chBranch
        '
        Me.chBranch.Text = "Branch"
        Me.chBranch.Width = 133
        '
        'chAccntCode
        '
        Me.chAccntCode.Text = "Account Code"
        Me.chAccntCode.Width = 0
        '
        'chAccntTitle
        '
        Me.chAccntTitle.Text = "Account Title"
        Me.chAccntTitle.Width = 235
        '
        'chBankAccount
        '
        Me.chBankAccount.Text = "Bank Account No"
        Me.chBankAccount.Width = 140
        '
        'chCheckSeriesFrom
        '
        Me.chCheckSeriesFrom.Text = "Series From"
        Me.chCheckSeriesFrom.Width = 92
        '
        'chCheckSeriesTo
        '
        Me.chCheckSeriesTo.Text = "Series To"
        Me.chCheckSeriesTo.Width = 74
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(461, 268)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(116, 32)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(461, 230)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(116, 32)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "New"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(461, 306)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(116, 32)
        Me.btnRemove.TabIndex = 10
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'txtAccntCode
        '
        Me.txtAccntCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccntCode.Location = New System.Drawing.Point(137, 71)
        Me.txtAccntCode.Name = "txtAccntCode"
        Me.txtAccntCode.ReadOnly = True
        Me.txtAccntCode.Size = New System.Drawing.Size(300, 22)
        Me.txtAccntCode.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtBank)
        Me.GroupBox1.Controls.Add(Me.txtAccntCode)
        Me.GroupBox1.Controls.Add(Me.txtBranch)
        Me.GroupBox1.Controls.Add(Me.txtBankAccntNo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAccntTitle)
        Me.GroupBox1.Controls.Add(Me.txtSeriesFr)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSeriesTo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 211)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(443, 213)
        Me.GroupBox1.TabIndex = 1350
        Me.GroupBox1.TabStop = False
        '
        'frmMasterfileBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(917, 444)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lvBank)
        Me.Name = "frmMasterfileBank"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank Maintenance"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAccntTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBankAccntNo As System.Windows.Forms.TextBox
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents txtBranch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSeriesFr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSeriesTo As System.Windows.Forms.TextBox
    Friend WithEvents lvBank As System.Windows.Forms.ListView
    Friend WithEvents chBank As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBranch As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAccntCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAccntTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBankAccount As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents txtAccntCode As System.Windows.Forms.TextBox
    Friend WithEvents chCheckSeriesFrom As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCheckSeriesTo As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chIDX As System.Windows.Forms.ColumnHeader
End Class
