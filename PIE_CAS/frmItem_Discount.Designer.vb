<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItem_Discount
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
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.lvDiscount = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chItemType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chItemValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chMethod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCustomer = New System.Windows.Forms.ListView()
        Me.chCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDiscountType = New System.Windows.Forms.ComboBox()
        Me.txtDiscountValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbGroupValue = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(15, 11)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(239, 22)
        Me.txtFilter.TabIndex = 0
        '
        'lvDiscount
        '
        Me.lvDiscount.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDiscount.BackColor = System.Drawing.Color.White
        Me.lvDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvDiscount.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chID, Me.chItemType, Me.chItemValue, Me.chMethod, Me.chValue})
        Me.lvDiscount.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lvDiscount.FullRowSelect = True
        Me.lvDiscount.GridLines = True
        Me.lvDiscount.Location = New System.Drawing.Point(303, 42)
        Me.lvDiscount.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.lvDiscount.MultiSelect = False
        Me.lvDiscount.Name = "lvDiscount"
        Me.lvDiscount.Size = New System.Drawing.Size(480, 220)
        Me.lvDiscount.TabIndex = 9
        Me.lvDiscount.UseCompatibleStateImageBehavior = False
        Me.lvDiscount.View = System.Windows.Forms.View.Details
        '
        'chID
        '
        Me.chID.DisplayIndex = 4
        Me.chID.Text = "ID"
        Me.chID.Width = 0
        '
        'chItemType
        '
        Me.chItemType.DisplayIndex = 0
        Me.chItemType.Text = "Type"
        Me.chItemType.Width = 120
        '
        'chItemValue
        '
        Me.chItemValue.DisplayIndex = 1
        Me.chItemValue.Text = "Field Value"
        Me.chItemValue.Width = 120
        '
        'chMethod
        '
        Me.chMethod.DisplayIndex = 2
        Me.chMethod.Text = "Method"
        Me.chMethod.Width = 120
        '
        'chValue
        '
        Me.chValue.DisplayIndex = 3
        Me.chValue.Text = "Value"
        Me.chValue.Width = 120
        '
        'lvCustomer
        '
        Me.lvCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvCustomer.BackColor = System.Drawing.Color.White
        Me.lvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvCustomer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCode, Me.chName})
        Me.lvCustomer.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lvCustomer.FullRowSelect = True
        Me.lvCustomer.GridLines = True
        Me.lvCustomer.Location = New System.Drawing.Point(10, 43)
        Me.lvCustomer.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.lvCustomer.MultiSelect = False
        Me.lvCustomer.Name = "lvCustomer"
        Me.lvCustomer.Size = New System.Drawing.Size(276, 375)
        Me.lvCustomer.TabIndex = 10
        Me.lvCustomer.UseCompatibleStateImageBehavior = False
        Me.lvCustomer.View = System.Windows.Forms.View.Details
        '
        'chCode
        '
        Me.chCode.Text = "Code"
        Me.chCode.Width = 70
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 200
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(368, 273)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 16)
        Me.Label8.TabIndex = 1134
        Me.Label8.Text = "Type :"
        '
        'cbType
        '
        Me.cbType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Specific Item", "Category"})
        Me.cbType.Location = New System.Drawing.Point(421, 270)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(310, 24)
        Me.cbType.TabIndex = 1133
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(330, 302)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 1136
        Me.Label1.Text = "Type Value :"
        '
        'cbDiscountType
        '
        Me.cbDiscountType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDiscountType.FormattingEnabled = True
        Me.cbDiscountType.Items.AddRange(New Object() {"Fixed Amount", "Percent", "Formula"})
        Me.cbDiscountType.Location = New System.Drawing.Point(421, 324)
        Me.cbDiscountType.Name = "cbDiscountType"
        Me.cbDiscountType.Size = New System.Drawing.Size(310, 24)
        Me.cbDiscountType.TabIndex = 1135
        '
        'txtDiscountValue
        '
        Me.txtDiscountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDiscountValue.Location = New System.Drawing.Point(421, 352)
        Me.txtDiscountValue.Name = "txtDiscountValue"
        Me.txtDiscountValue.Size = New System.Drawing.Size(310, 22)
        Me.txtDiscountValue.TabIndex = 1138
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(313, 328)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 1139
        Me.Label2.Text = "Discount Type :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(310, 355)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 1140
        Me.Label3.Text = "Discount Value :"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(346, 384)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(123, 34)
        Me.btnSave.TabIndex = 1141
        Me.btnSave.Text = "New"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(477, 384)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(123, 34)
        Me.btnEdit.TabIndex = 1142
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(608, 384)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(123, 34)
        Me.btnRemove.TabIndex = 1143
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(295, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(5, 407)
        Me.Panel1.TabIndex = 1144
        '
        'lblName
        '
        Me.lblName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(74, 6)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(0, 16)
        Me.lblName.TabIndex = 1145
        '
        'lblCode
        '
        Me.lblCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCode.AutoSize = True
        Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.White
        Me.lblCode.Location = New System.Drawing.Point(4, 6)
        Me.lblCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(0, 16)
        Me.lblCode.TabIndex = 1146
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(260, 10)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(31, 24)
        Me.btnSearch.TabIndex = 1147
        Me.btnSearch.Text = ">>"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cbGroupValue
        '
        Me.cbGroupValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbGroupValue.FormattingEnabled = True
        Me.cbGroupValue.Items.AddRange(New Object() {"Specific Item", "Category"})
        Me.cbGroupValue.Location = New System.Drawing.Point(421, 297)
        Me.cbGroupValue.Name = "cbGroupValue"
        Me.cbGroupValue.Size = New System.Drawing.Size(310, 24)
        Me.cbGroupValue.TabIndex = 1148
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblCode)
        Me.Panel2.Controls.Add(Me.lblName)
        Me.Panel2.Location = New System.Drawing.Point(303, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(480, 27)
        Me.Panel2.TabIndex = 1149
        '
        'frmItem_Discount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(788, 431)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cbGroupValue)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDiscountValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbDiscountType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.lvCustomer)
        Me.Controls.Add(Me.lvDiscount)
        Me.Controls.Add(Me.txtFilter)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmItem_Discount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Discount Maintenance"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents lvDiscount As System.Windows.Forms.ListView
    Friend WithEvents chItemType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chItemValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCustomer As System.Windows.Forms.ListView
    Friend WithEvents chCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMethod As System.Windows.Forms.ColumnHeader
    Friend WithEvents chValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDiscountType As System.Windows.Forms.ComboBox
    Friend WithEvents txtDiscountValue As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cbGroupValue As System.Windows.Forms.ComboBox
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
