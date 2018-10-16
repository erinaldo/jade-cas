<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserLogin
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserLogin))
        Me.gbOptions = New System.Windows.Forms.GroupBox()
        Me.cbServer = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.txtPass = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.txtUser = New MetroFramework.Controls.MetroTextBox()
        Me.panelLogin = New System.Windows.Forms.Panel()
        Me.lnkModuleSelect = New System.Windows.Forms.LinkLabel()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnOption = New MetroFramework.Controls.MetroButton()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.cbDatabase = New MetroFramework.Controls.MetroComboBox()
        Me.txtPassword = New MetroFramework.Controls.MetroTextBox()
        Me.btnLogin = New MetroFramework.Controls.MetroButton()
        Me.txtUsername = New MetroFramework.Controls.MetroTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbOptions.SuspendLayout()
        Me.panelLogin.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbOptions
        '
        Me.gbOptions.Controls.Add(Me.cbServer)
        Me.gbOptions.Controls.Add(Me.btnConnect)
        Me.gbOptions.Controls.Add(Me.MetroLabel2)
        Me.gbOptions.Controls.Add(Me.MetroLabel3)
        Me.gbOptions.Controls.Add(Me.txtPass)
        Me.gbOptions.Controls.Add(Me.MetroLabel4)
        Me.gbOptions.Controls.Add(Me.txtUser)
        Me.gbOptions.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOptions.Location = New System.Drawing.Point(357, 28)
        Me.gbOptions.Name = "gbOptions"
        Me.gbOptions.Size = New System.Drawing.Size(296, 300)
        Me.gbOptions.TabIndex = 43
        Me.gbOptions.TabStop = False
        Me.gbOptions.Text = "Server Login"
        '
        'cbServer
        '
        Me.cbServer.FormattingEnabled = True
        Me.cbServer.Location = New System.Drawing.Point(95, 84)
        Me.cbServer.Name = "cbServer"
        Me.cbServer.Size = New System.Drawing.Size(161, 25)
        Me.cbServer.TabIndex = 53
        '
        'btnConnect
        '
        Me.btnConnect.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnConnect.Highlight = True
        Me.btnConnect.Location = New System.Drawing.Point(159, 193)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(97, 36)
        Me.btnConnect.Style = MetroFramework.MetroColorStyle.Green
        Me.btnConnect.TabIndex = 47
        Me.btnConnect.Text = "CONNECT"
        Me.btnConnect.UseSelectable = True
        Me.btnConnect.UseStyleColors = True
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(38, 90)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(51, 19)
        Me.MetroLabel2.TabIndex = 48
        Me.MetroLabel2.Text = "Server:"
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(45, 121)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(44, 19)
        Me.MetroLabel3.TabIndex = 49
        Me.MetroLabel3.Text = "Login:"
        '
        'txtPass
        '
        '
        '
        '
        Me.txtPass.CustomButton.Image = Nothing
        Me.txtPass.CustomButton.Location = New System.Drawing.Point(137, 1)
        Me.txtPass.CustomButton.Name = ""
        Me.txtPass.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.txtPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPass.CustomButton.TabIndex = 1
        Me.txtPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPass.CustomButton.UseSelectable = True
        Me.txtPass.CustomButton.Visible = False
        Me.txtPass.Lines = New String(-1) {}
        Me.txtPass.Location = New System.Drawing.Point(95, 146)
        Me.txtPass.MaxLength = 32767
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPass.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPass.SelectedText = ""
        Me.txtPass.SelectionLength = 0
        Me.txtPass.SelectionStart = 0
        Me.txtPass.ShortcutsEnabled = True
        Me.txtPass.Size = New System.Drawing.Size(161, 25)
        Me.txtPass.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPass.TabIndex = 52
        Me.txtPass.UseSelectable = True
        Me.txtPass.UseStyleColors = True
        Me.txtPass.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPass.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(23, 152)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(66, 19)
        Me.MetroLabel4.TabIndex = 50
        Me.MetroLabel4.Text = "Password:"
        '
        'txtUser
        '
        '
        '
        '
        Me.txtUser.CustomButton.Image = Nothing
        Me.txtUser.CustomButton.Location = New System.Drawing.Point(137, 1)
        Me.txtUser.CustomButton.Name = ""
        Me.txtUser.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.txtUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtUser.CustomButton.TabIndex = 1
        Me.txtUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtUser.CustomButton.UseSelectable = True
        Me.txtUser.CustomButton.Visible = False
        Me.txtUser.Lines = New String(-1) {}
        Me.txtUser.Location = New System.Drawing.Point(95, 115)
        Me.txtUser.MaxLength = 32767
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtUser.SelectedText = ""
        Me.txtUser.SelectionLength = 0
        Me.txtUser.SelectionStart = 0
        Me.txtUser.ShortcutsEnabled = True
        Me.txtUser.Size = New System.Drawing.Size(161, 25)
        Me.txtUser.Style = MetroFramework.MetroColorStyle.Green
        Me.txtUser.TabIndex = 51
        Me.txtUser.UseSelectable = True
        Me.txtUser.UseStyleColors = True
        Me.txtUser.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtUser.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'panelLogin
        '
        Me.panelLogin.BackColor = System.Drawing.Color.White
        Me.panelLogin.Controls.Add(Me.lnkModuleSelect)
        Me.panelLogin.Controls.Add(Me.MetroLabel5)
        Me.panelLogin.Controls.Add(Me.PictureBox2)
        Me.panelLogin.Controls.Add(Me.btnOption)
        Me.panelLogin.Controls.Add(Me.pbLogo)
        Me.panelLogin.Controls.Add(Me.MetroLabel1)
        Me.panelLogin.Controls.Add(Me.cbDatabase)
        Me.panelLogin.Controls.Add(Me.txtPassword)
        Me.panelLogin.Controls.Add(Me.btnLogin)
        Me.panelLogin.Controls.Add(Me.txtUsername)
        Me.panelLogin.Controls.Add(Me.gbOptions)
        Me.panelLogin.Location = New System.Drawing.Point(0, 33)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.Size = New System.Drawing.Size(687, 374)
        Me.panelLogin.TabIndex = 40
        '
        'lnkModuleSelect
        '
        Me.lnkModuleSelect.AutoSize = True
        Me.lnkModuleSelect.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkModuleSelect.LinkColor = System.Drawing.Color.Green
        Me.lnkModuleSelect.Location = New System.Drawing.Point(106, 340)
        Me.lnkModuleSelect.Name = "lnkModuleSelect"
        Me.lnkModuleSelect.Size = New System.Drawing.Size(141, 15)
        Me.lnkModuleSelect.TabIndex = 49
        Me.lnkModuleSelect.TabStop = True
        Me.lnkModuleSelect.Text = "Back to Module Selection"
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.MetroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel5.Location = New System.Drawing.Point(36, 87)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(204, 25)
        Me.MetroLabel5.TabIndex = 48
        Me.MetroLabel5.Text = "Jade Accounting System"
        Me.MetroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.jade.My.Resources.Resources.Jade1
        Me.PictureBox2.Location = New System.Drawing.Point(98, 10)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(77, 73)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 47
        Me.PictureBox2.TabStop = False
        '
        'btnOption
        '
        Me.btnOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOption.Location = New System.Drawing.Point(164, 295)
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(83, 33)
        Me.btnOption.Style = MetroFramework.MetroColorStyle.Green
        Me.btnOption.TabIndex = 46
        Me.btnOption.Text = "OPTIONS>>"
        Me.btnOption.UseSelectable = True
        Me.btnOption.UseStyleColors = True
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.jade.My.Resources.Resources.ako_revised_logo_colored
        Me.pbLogo.Location = New System.Drawing.Point(27, 315)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(64, 40)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 45
        Me.pbLogo.TabStop = False
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(22, 295)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(81, 19)
        Me.MetroLabel1.TabIndex = 44
        Me.MetroLabel1.Text = "Powered by:"
        '
        'cbDatabase
        '
        Me.cbDatabase.FormattingEnabled = True
        Me.cbDatabase.ItemHeight = 23
        Me.cbDatabase.Location = New System.Drawing.Point(27, 191)
        Me.cbDatabase.Name = "cbDatabase"
        Me.cbDatabase.PromptText = "Database"
        Me.cbDatabase.Size = New System.Drawing.Size(220, 29)
        Me.cbDatabase.Style = MetroFramework.MetroColorStyle.Green
        Me.cbDatabase.TabIndex = 3
        Me.cbDatabase.UseSelectable = True
        Me.cbDatabase.UseStyleColors = True
        '
        'txtPassword
        '
        '
        '
        '
        Me.txtPassword.CustomButton.Image = Nothing
        Me.txtPassword.CustomButton.Location = New System.Drawing.Point(196, 1)
        Me.txtPassword.CustomButton.Name = ""
        Me.txtPassword.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPassword.CustomButton.TabIndex = 1
        Me.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPassword.CustomButton.UseSelectable = True
        Me.txtPassword.CustomButton.Visible = False
        Me.txtPassword.DisplayIcon = True
        Me.txtPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtPassword.Icon = Global.jade.My.Resources.Resources.key
        Me.txtPassword.Lines = New String(-1) {}
        Me.txtPassword.Location = New System.Drawing.Point(27, 160)
        Me.txtPassword.MaxLength = 32767
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPassword.PromptText = "Password"
        Me.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPassword.SelectedText = ""
        Me.txtPassword.SelectionLength = 0
        Me.txtPassword.SelectionStart = 0
        Me.txtPassword.ShortcutsEnabled = True
        Me.txtPassword.ShowClearButton = True
        Me.txtPassword.Size = New System.Drawing.Size(220, 25)
        Me.txtPassword.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPassword.UseSelectable = True
        Me.txtPassword.UseStyleColors = True
        Me.txtPassword.WaterMark = "Password"
        Me.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPassword.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.White
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Highlight = True
        Me.btnLogin.Location = New System.Drawing.Point(54, 236)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(163, 33)
        Me.btnLogin.Style = MetroFramework.MetroColorStyle.Green
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "LOGIN"
        Me.btnLogin.UseSelectable = True
        Me.btnLogin.UseStyleColors = True
        '
        'txtUsername
        '
        '
        '
        '
        Me.txtUsername.CustomButton.Image = Nothing
        Me.txtUsername.CustomButton.Location = New System.Drawing.Point(196, 1)
        Me.txtUsername.CustomButton.Name = ""
        Me.txtUsername.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtUsername.CustomButton.TabIndex = 1
        Me.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtUsername.CustomButton.UseSelectable = True
        Me.txtUsername.CustomButton.Visible = False
        Me.txtUsername.DisplayIcon = True
        Me.txtUsername.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtUsername.Icon = Global.jade.My.Resources.Resources.avatar__1_
        Me.txtUsername.Lines = New String(-1) {}
        Me.txtUsername.Location = New System.Drawing.Point(27, 129)
        Me.txtUsername.MaxLength = 32767
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsername.PromptText = "Username"
        Me.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtUsername.SelectedText = ""
        Me.txtUsername.SelectionLength = 0
        Me.txtUsername.SelectionStart = 0
        Me.txtUsername.ShortcutsEnabled = True
        Me.txtUsername.ShowClearButton = True
        Me.txtUsername.Size = New System.Drawing.Size(220, 25)
        Me.txtUsername.Style = MetroFramework.MetroColorStyle.Green
        Me.txtUsername.TabIndex = 1
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtUsername.UseSelectable = True
        Me.txtUsername.UseStyleColors = True
        Me.txtUsername.WaterMark = "Username"
        Me.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtUsername.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(241, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(30, 30)
        Me.btnClose.TabIndex = 41
        Me.btnClose.Text = "✖"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmUserLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(268, 407)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.panelLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserLogin"
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Green
        Me.gbOptions.ResumeLayout(False)
        Me.gbOptions.PerformLayout()
        Me.panelLogin.ResumeLayout(False)
        Me.panelLogin.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbOptions As System.Windows.Forms.GroupBox
    Friend WithEvents panelLogin As System.Windows.Forms.Panel
    Friend WithEvents txtUsername As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btnLogin As MetroFramework.Controls.MetroButton
    Friend WithEvents txtPassword As MetroFramework.Controls.MetroTextBox
    Friend WithEvents cbDatabase As MetroFramework.Controls.MetroComboBox
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnOption As MetroFramework.Controls.MetroButton
    Friend WithEvents btnConnect As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtPass As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtUser As MetroFramework.Controls.MetroTextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents cbServer As System.Windows.Forms.ComboBox
    Friend WithEvents lnkModuleSelect As System.Windows.Forms.LinkLabel
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
