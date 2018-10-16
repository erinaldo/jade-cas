<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUOMConversion
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
        Me.cbUoMGroup = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbBaseUnit = New System.Windows.Forms.ComboBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.dgvAltUOM = New System.Windows.Forms.DataGridView()
        Me.chFromUoM = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgcEqualLbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcToUOM = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.btnUOMBase = New System.Windows.Forms.Button()
        CType(Me.dgvAltUOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbUoMGroup
        '
        Me.cbUoMGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUoMGroup.FormattingEnabled = True
        Me.cbUoMGroup.Location = New System.Drawing.Point(96, 10)
        Me.cbUoMGroup.Name = "cbUoMGroup"
        Me.cbUoMGroup.Size = New System.Drawing.Size(158, 23)
        Me.cbUoMGroup.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Group Code :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Base Unit :"
        '
        'cbBaseUnit
        '
        Me.cbBaseUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBaseUnit.FormattingEnabled = True
        Me.cbBaseUnit.Location = New System.Drawing.Point(96, 37)
        Me.cbBaseUnit.Name = "cbBaseUnit"
        Me.cbBaseUnit.Size = New System.Drawing.Size(158, 23)
        Me.cbBaseUnit.TabIndex = 11
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(3, 249)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 25)
        Me.btnNew.TabIndex = 15
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(165, 249)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(84, 249)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 25)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'dgvAltUOM
        '
        Me.dgvAltUOM.AllowUserToAddRows = False
        Me.dgvAltUOM.AllowUserToDeleteRows = False
        Me.dgvAltUOM.AllowUserToOrderColumns = True
        Me.dgvAltUOM.AllowUserToResizeColumns = False
        Me.dgvAltUOM.AllowUserToResizeRows = False
        Me.dgvAltUOM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAltUOM.BackgroundColor = System.Drawing.Color.White
        Me.dgvAltUOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAltUOM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chFromUoM, Me.dgcEqualLbl, Me.chQTY, Me.dgcToUOM})
        Me.dgvAltUOM.Location = New System.Drawing.Point(3, 34)
        Me.dgvAltUOM.Name = "dgvAltUOM"
        Me.dgvAltUOM.RowHeadersWidth = 20
        Me.dgvAltUOM.Size = New System.Drawing.Size(522, 240)
        Me.dgvAltUOM.TabIndex = 16
        '
        'chFromUoM
        '
        Me.chFromUoM.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.chFromUoM.HeaderText = "From UoM"
        Me.chFromUoM.Name = "chFromUoM"
        Me.chFromUoM.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chFromUoM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.chFromUoM.Width = 150
        '
        'dgcEqualLbl
        '
        DataGridViewCellStyle1.NullValue = "="
        Me.dgcEqualLbl.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcEqualLbl.HeaderText = "="
        Me.dgcEqualLbl.Name = "dgcEqualLbl"
        Me.dgcEqualLbl.ReadOnly = True
        Me.dgcEqualLbl.Width = 50
        '
        'chQTY
        '
        Me.chQTY.HeaderText = "Quantity"
        Me.chQTY.Name = "chQTY"
        Me.chQTY.Width = 150
        '
        'dgcToUOM
        '
        Me.dgcToUOM.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.dgcToUOM.HeaderText = "To UoM"
        Me.dgcToUOM.Name = "dgcToUOM"
        Me.dgcToUOM.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcToUOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgcToUOM.Width = 150
        '
        'btnUOMBase
        '
        Me.btnUOMBase.BackgroundImage = Global.jade.My.Resources.Resources._New
        Me.btnUOMBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUOMBase.Location = New System.Drawing.Point(500, 3)
        Me.btnUOMBase.Name = "btnUOMBase"
        Me.btnUOMBase.Size = New System.Drawing.Size(25, 25)
        Me.btnUOMBase.TabIndex = 1190
        Me.btnUOMBase.UseVisualStyleBackColor = True
        '
        'frmUOMConversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(527, 281)
        Me.Controls.Add(Me.btnUOMBase)
        Me.Controls.Add(Me.dgvAltUOM)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbBaseUnit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbUoMGroup)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmUOMConversion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UoM Conversion"
        CType(Me.dgvAltUOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbUoMGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbBaseUnit As System.Windows.Forms.ComboBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents dgvAltUOM As System.Windows.Forms.DataGridView
    Friend WithEvents btnUOMBase As System.Windows.Forms.Button
    Friend WithEvents chFromUoM As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgcEqualLbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcToUOM As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
