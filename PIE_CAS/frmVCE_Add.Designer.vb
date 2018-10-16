<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVCE_Add
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVCEName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTinNo = New System.Windows.Forms.TextBox()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbVatType = New System.Windows.Forms.ComboBox()
        Me.cbWTaxType = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpBasic = New System.Windows.Forms.TabPage()
        Me.tpAddress = New System.Windows.Forms.TabPage()
        Me.txtZipCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtProvince = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtBrgy = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBlkLot = New System.Windows.Forms.TextBox()
        Me.txtSubd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.tpContact = New System.Windows.Forms.TabPage()
        Me.txtWebsite = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCellphone = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkPEZA = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tpBasic.SuspendLayout()
        Me.tpAddress.SuspendLayout()
        Me.tpContact.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "VCE Name :"
        '
        'txtVCEName
        '
        Me.txtVCEName.Location = New System.Drawing.Point(85, 6)
        Me.txtVCEName.Name = "txtVCEName"
        Me.txtVCEName.Size = New System.Drawing.Size(210, 21)
        Me.txtVCEName.TabIndex = 39
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 15)
        Me.Label13.TabIndex = 85
        Me.Label13.Text = "TIN No. :"
        '
        'txtTinNo
        '
        Me.txtTinNo.Location = New System.Drawing.Point(85, 31)
        Me.txtTinNo.Name = "txtTinNo"
        Me.txtTinNo.Size = New System.Drawing.Size(210, 21)
        Me.txtTinNo.TabIndex = 86
        '
        'txtTerms
        '
        Me.txtTerms.Location = New System.Drawing.Point(85, 56)
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(210, 21)
        Me.txtTerms.TabIndex = 88
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 15)
        Me.Label24.TabIndex = 87
        Me.Label24.Text = "Terms :"
        '
        'cbVatType
        '
        Me.cbVatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVatType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVatType.FormattingEnabled = True
        Me.cbVatType.Items.AddRange(New Object() {"T0", "T1", "T2"})
        Me.cbVatType.Location = New System.Drawing.Point(85, 106)
        Me.cbVatType.Name = "cbVatType"
        Me.cbVatType.Size = New System.Drawing.Size(210, 21)
        Me.cbVatType.TabIndex = 92
        '
        'cbWTaxType
        '
        Me.cbWTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWTaxType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbWTaxType.FormattingEnabled = True
        Me.cbWTaxType.Items.AddRange(New Object() {"W0", "W1", "W2", "W5", "W10"})
        Me.cbWTaxType.Location = New System.Drawing.Point(85, 81)
        Me.cbWTaxType.Name = "cbWTaxType"
        Me.cbWTaxType.Size = New System.Drawing.Size(210, 21)
        Me.cbWTaxType.TabIndex = 91
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 84)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 15)
        Me.Label20.TabIndex = 89
        Me.Label20.Text = "WTax Code :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 109)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 15)
        Me.Label23.TabIndex = 90
        Me.Label23.Text = "VAT Code :"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpBasic)
        Me.TabControl1.Controls.Add(Me.tpAddress)
        Me.TabControl1.Controls.Add(Me.tpContact)
        Me.TabControl1.Location = New System.Drawing.Point(4, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(311, 221)
        Me.TabControl1.TabIndex = 93
        '
        'tpBasic
        '
        Me.tpBasic.Controls.Add(Me.chkPEZA)
        Me.tpBasic.Controls.Add(Me.txtVCEName)
        Me.tpBasic.Controls.Add(Me.cbVatType)
        Me.tpBasic.Controls.Add(Me.Label2)
        Me.tpBasic.Controls.Add(Me.cbWTaxType)
        Me.tpBasic.Controls.Add(Me.txtTinNo)
        Me.tpBasic.Controls.Add(Me.Label20)
        Me.tpBasic.Controls.Add(Me.Label13)
        Me.tpBasic.Controls.Add(Me.Label23)
        Me.tpBasic.Controls.Add(Me.Label24)
        Me.tpBasic.Controls.Add(Me.txtTerms)
        Me.tpBasic.Location = New System.Drawing.Point(4, 24)
        Me.tpBasic.Name = "tpBasic"
        Me.tpBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBasic.Size = New System.Drawing.Size(303, 193)
        Me.tpBasic.TabIndex = 0
        Me.tpBasic.Text = "Basic Info."
        Me.tpBasic.UseVisualStyleBackColor = True
        '
        'tpAddress
        '
        Me.tpAddress.Controls.Add(Me.txtZipCode)
        Me.tpAddress.Controls.Add(Me.Label17)
        Me.tpAddress.Controls.Add(Me.Label27)
        Me.tpAddress.Controls.Add(Me.txtProvince)
        Me.tpAddress.Controls.Add(Me.Label11)
        Me.tpAddress.Controls.Add(Me.Label9)
        Me.tpAddress.Controls.Add(Me.txtCity)
        Me.tpAddress.Controls.Add(Me.txtUnit)
        Me.tpAddress.Controls.Add(Me.txtBrgy)
        Me.tpAddress.Controls.Add(Me.Label4)
        Me.tpAddress.Controls.Add(Me.Label3)
        Me.tpAddress.Controls.Add(Me.txtBlkLot)
        Me.tpAddress.Controls.Add(Me.txtSubd)
        Me.tpAddress.Controls.Add(Me.Label6)
        Me.tpAddress.Controls.Add(Me.Label10)
        Me.tpAddress.Controls.Add(Me.txtStreet)
        Me.tpAddress.Location = New System.Drawing.Point(4, 24)
        Me.tpAddress.Name = "tpAddress"
        Me.tpAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAddress.Size = New System.Drawing.Size(303, 193)
        Me.tpAddress.TabIndex = 1
        Me.tpAddress.Text = "Address"
        Me.tpAddress.UseVisualStyleBackColor = True
        '
        'txtZipCode
        '
        Me.txtZipCode.Location = New System.Drawing.Point(137, 157)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(155, 21)
        Me.txtZipCode.TabIndex = 125
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(75, 160)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 15)
        Me.Label17.TabIndex = 124
        Me.Label17.Text = "Zip Code :"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(77, 135)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 15)
        Me.Label27.TabIndex = 123
        Me.Label27.Text = "Province :"
        '
        'txtProvince
        '
        Me.txtProvince.Location = New System.Drawing.Point(137, 132)
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Size = New System.Drawing.Size(155, 21)
        Me.txtProvince.TabIndex = 122
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(31, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 15)
        Me.Label11.TabIndex = 121
        Me.Label11.Text = "City / Municipality :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 15)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Brgy. / DIstrict / Locality :"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(137, 107)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(155, 21)
        Me.txtCity.TabIndex = 118
        '
        'txtUnit
        '
        Me.txtUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUnit.Location = New System.Drawing.Point(137, -26)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.Size = New System.Drawing.Size(155, 21)
        Me.txtUnit.TabIndex = 111
        '
        'txtBrgy
        '
        Me.txtBrgy.Location = New System.Drawing.Point(137, 82)
        Me.txtBrgy.Name = "txtBrgy"
        Me.txtBrgy.Size = New System.Drawing.Size(155, 21)
        Me.txtBrgy.TabIndex = 117
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, -32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 30)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Room/Floor/Unit No." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "          && Bldg. Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 15)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "House/Lot && Blk No. :"
        '
        'txtBlkLot
        '
        Me.txtBlkLot.Location = New System.Drawing.Point(137, 7)
        Me.txtBlkLot.Name = "txtBlkLot"
        Me.txtBlkLot.Size = New System.Drawing.Size(155, 21)
        Me.txtBlkLot.TabIndex = 113
        '
        'txtSubd
        '
        Me.txtSubd.Location = New System.Drawing.Point(137, 57)
        Me.txtSubd.Name = "txtSubd"
        Me.txtSubd.Size = New System.Drawing.Size(155, 21)
        Me.txtSubd.TabIndex = 116
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(61, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 15)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Subdivision :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(55, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "Street Name :"
        '
        'txtStreet
        '
        Me.txtStreet.Location = New System.Drawing.Point(137, 32)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(155, 21)
        Me.txtStreet.TabIndex = 115
        '
        'tpContact
        '
        Me.tpContact.Controls.Add(Me.txtWebsite)
        Me.tpContact.Controls.Add(Me.Label18)
        Me.tpContact.Controls.Add(Me.txtEmail)
        Me.tpContact.Controls.Add(Me.Label19)
        Me.tpContact.Controls.Add(Me.txtContact)
        Me.tpContact.Controls.Add(Me.Label29)
        Me.tpContact.Controls.Add(Me.txtTelephone)
        Me.tpContact.Controls.Add(Me.Label7)
        Me.tpContact.Controls.Add(Me.txtCellphone)
        Me.tpContact.Controls.Add(Me.Label8)
        Me.tpContact.Controls.Add(Me.txtFax)
        Me.tpContact.Controls.Add(Me.Label5)
        Me.tpContact.Location = New System.Drawing.Point(4, 24)
        Me.tpContact.Name = "tpContact"
        Me.tpContact.Padding = New System.Windows.Forms.Padding(3)
        Me.tpContact.Size = New System.Drawing.Size(303, 193)
        Me.tpContact.TabIndex = 2
        Me.tpContact.Text = "Contact"
        Me.tpContact.UseVisualStyleBackColor = True
        '
        'txtWebsite
        '
        Me.txtWebsite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtWebsite.Location = New System.Drawing.Point(115, 61)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(182, 21)
        Me.txtWebsite.TabIndex = 127
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(52, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 15)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "Website :"
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Location = New System.Drawing.Point(115, 85)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(182, 21)
        Me.txtEmail.TabIndex = 126
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 15)
        Me.Label19.TabIndex = 123
        Me.Label19.Text = "Contact Person :"
        '
        'txtContact
        '
        Me.txtContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtContact.Location = New System.Drawing.Point(115, 109)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(182, 21)
        Me.txtContact.TabIndex = 125
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(17, 87)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(92, 15)
        Me.Label29.TabIndex = 122
        Me.Label29.Text = "Email Address :"
        '
        'txtTelephone
        '
        Me.txtTelephone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTelephone.Location = New System.Drawing.Point(113, -31)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.ReadOnly = True
        Me.txtTelephone.Size = New System.Drawing.Size(182, 21)
        Me.txtTelephone.TabIndex = 121
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, -28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 15)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "Telephone No. :"
        '
        'txtCellphone
        '
        Me.txtCellphone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCellphone.Location = New System.Drawing.Point(115, 13)
        Me.txtCellphone.Name = "txtCellphone"
        Me.txtCellphone.Size = New System.Drawing.Size(182, 21)
        Me.txtCellphone.TabIndex = 120
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 15)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Cellphone No. :"
        '
        'txtFax
        '
        Me.txtFax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFax.Location = New System.Drawing.Point(115, 37)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(182, 21)
        Me.txtFax.TabIndex = 119
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(54, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Fax No. :"
        '
        'chkPEZA
        '
        Me.chkPEZA.AutoSize = True
        Me.chkPEZA.Location = New System.Drawing.Point(85, 133)
        Me.chkPEZA.Name = "chkPEZA"
        Me.chkPEZA.Size = New System.Drawing.Size(119, 19)
        Me.chkPEZA.TabIndex = 117
        Me.chkPEZA.Text = "PEZA Registered"
        Me.chkPEZA.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(49, 231)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(105, 37)
        Me.btnSave.TabIndex = 94
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(160, 231)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 37)
        Me.Button1.TabIndex = 95
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmVCE_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(320, 273)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmVCE_Add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.tpBasic.ResumeLayout(False)
        Me.tpBasic.PerformLayout()
        Me.tpAddress.ResumeLayout(False)
        Me.tpAddress.PerformLayout()
        Me.tpContact.ResumeLayout(False)
        Me.tpContact.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVCEName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTinNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbVatType As System.Windows.Forms.ComboBox
    Friend WithEvents cbWTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpBasic As System.Windows.Forms.TabPage
    Friend WithEvents tpAddress As System.Windows.Forms.TabPage
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtProvince As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtBrgy As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBlkLot As System.Windows.Forms.TextBox
    Friend WithEvents txtSubd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents tpContact As System.Windows.Forms.TabPage
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTelephone As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCellphone As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkPEZA As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
