Public Class frmSB_Contract
    Dim SQL As New SQLControl
    Dim enableEvent As Boolean = True
    Dim ID As Integer = 0
    Dim lastIndex As Integer = -1

    Private Sub frmBilling_E_Contract_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadList()
        EnableControl(False)
    End Sub

    Private Sub LoadList()
        Dim query As String
        query = " SELECT Contract_ID, VCEName, Description, Contract_Price, VAT_Amount, Total_Price " & _
                " FROM   tblSoftware_Contract INNER JOIN tblMasterfile_VCE " & _
                " ON     tblSoftware_Contract.VCECode = tblMasterfile_VCE.VCECode " & _
                " WHERE  tblSoftware_Contract.Status ='Active' "
        SQL.ReadQuery(query)
        lvList.Items.Clear()
        While SQL.SQLDR.Read
            lvList.Items.Add(SQL.SQLDR("Contract_ID").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Description").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(CDec(SQL.SQLDR("Contract_Price")).ToString("N2"))
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(CDec(SQL.SQLDR("VAT_Amount")).ToString("N2"))
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(CDec(SQL.SQLDR("Total_Price")).ToString("N2"))
        End While
    End Sub

    Private Sub LoadContract(ByVal ID As Integer)
        Dim query As String
        query = " SELECT Contract_ID, tblSoftware_Contract.VCECode, VCEName, Contract_Date, Description, Contract_Price, VAT_Amount, " & _
                "        Discount, Total_Price, Contract_Type, tblSoftware_Contract.Terms " & _
                " FROM   tblSoftware_Contract INNER JOIN tblMasterfile_VCE " & _
                " ON     tblSoftware_Contract.VCECode = tblMasterfile_VCE.VCECode " & _
                " WHERE  Contract_ID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            enableEvent = False
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtDescription.Text = SQL.SQLDR("Description").ToString
            dtpDate.Text = SQL.SQLDR("Contract_Date")
            txtPrice.Text = CDec(SQL.SQLDR("Contract_Price")).ToString("N2")
            txtVAT.Text = CDec(SQL.SQLDR("VAT_Amount")).ToString("N2")
            txtDiscount.Text = CDec(SQL.SQLDR("Discount")).ToString("N2")
            txtTotalPrice.Text = CDec(SQL.SQLDR("Total_Price")).ToString("N2")
            cbType.SelectedItem = SQL.SQLDR("Contract_Type").ToString
            txtTerms.Text = SQL.SQLDR("Terms").ToString
            enableEvent = True
        End If
    End Sub

    Private Sub lvList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvList.SelectedIndexChanged
        If lvList.SelectedItems.Count = 1 Then
            ID = lvList.SelectedItems(0).SubItems(chID.Index).Text
            LoadContract(ID)
            EnableControl(False)
            btnSave.Text = "New"
            btnUpdate.Text = "Edit"
            btnRemove.Text = "Remove"
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "New" Then
            EnableControl(True)
            Cleartext()
            btnSave.Text = "Save"
            btnUpdate.Text = "Edit"
            btnRemove.Text = "Cancel"
        ElseIf btnSave.Text = "Save" Then
            If MsgBox("Saving contract information, click yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim ID As Integer = GetID()
                SaveContract(ID)
                MsgBox("Saved Successfully!", MsgBoxStyle.Information)
                LoadList()
                btnSave.Text = "New"
                btnUpdate.Text = "Edit"
                btnRemove.Text = "Remove"
                EnableControl(False)
                Cleartext()
            End If
        End If
    End Sub

    Private Function GetID() As Integer
        Dim query As String
        query = " SELECT MAX(Contract_ID) + 1 AS ID FROM tblSoftware_Contract "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read And Not IsDBNull(SQL.SQLDR("ID")) Then
            Return SQL.SQLDR("ID")
        Else
            Return 1
        End If
    End Function

    Private Sub SaveContract(ByVal ID As Integer)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblSoftware_Contract(Contract_ID, VCECode, Contract_Date, Description, Contract_Price, " & _
                    "                       VAT_Amount, Discount, Total_Price, Contract_Type, Terms) " & _
                    " VALUES(@Contract_ID, @VCECode, @Contract_Date, @Description, @Contract_Price, " & _
                    "        @VAT_Amount, @Discount, @Total_Price, @Contract_Type, @Terms) "
        SQL.FlushParams()
        SQL.AddParam("Contract_ID", ID)
        SQL.AddParam("VCECode", txtVCECode.Text)
        SQL.AddParam("Contract_Date", dtpDate.Value.Date)
        SQL.AddParam("Description", txtDescription.Text)
        SQL.AddParam("Contract_Price", IIf(txtPrice.Text = "", 0, CDec(txtPrice.Text)))
        SQL.AddParam("VAT_Amount", IIf(txtVAT.Text = "", 0, CDec(txtVAT.Text)))
        SQL.AddParam("Discount", IIf(txtDiscount.Text = "", 0, CDec(txtDiscount.Text)))
        SQL.AddParam("Total_Price", IIf(txtTotalPrice.Text = "", 0, CDec(txtTotalPrice.Text)))
        SQL.AddParam("Contract_Type", cbType.SelectedItem)
        If txtTerms.Text = "" Then
            SQL.AddParam("Terms", 0)
        Else
            SQL.AddParam("Terms", CInt(txtTerms.Text))
        End If
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub Cleartext()
        txtVCECode.Clear()
        txtVCEName.Clear()
        txtDescription.Clear()
        dtpDate.Value = Date.Today.Date
        txtPrice.Clear()
        txtVAT.Clear()
        txtDiscount.Clear()
        txtTotalPrice.Clear()
        cbType.SelectedIndex = 0
        txtTerms.Clear()
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCEName.ReadOnly = Not Value
        txtDescription.ReadOnly = Not Value
        dtpDate.Enabled = Value
        txtPrice.ReadOnly = Not Value
        txtVAT.ReadOnly = Not Value
        txtDiscount.ReadOnly = Not Value
        txtTotalPrice.ReadOnly = Not Value
        cbType.Enabled = Value
        txtTerms.ReadOnly = Not Value
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If btnUpdate.Text = "Edit" Then
            EnableControl(True)
            btnSave.Text = "New"
            btnUpdate.Text = "Update"
            btnRemove.Text = "Cancel"
        Else
            If MsgBox("Updating Contract information, click yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                UpdateContract(lvList.SelectedItems(0).SubItems(0).Text)
                MsgBox("Updated Successfully!", MsgBoxStyle.Information)
                LoadList()
                EnableControl(False)
                btnSave.Text = "Save"
                btnUpdate.Text = "Edit"
                btnRemove.Text = "Remove"
            End If
        End If
    End Sub

    Private Sub UpdateContract(ByVal ID As Integer)
        Dim updateSQL As String
        updateSQL = " UPDATE tblSoftware_Contract " & _
                    " SET    VCECode = @VCECode, Contract_Date = @Contract_Date, " & _
                    "        Description = @Description, Contract_Price = @Contract_Price, VAT_Amount = @VAT_Amount, " & _
                    "        Discount = @Discount, Total_Price = @Total_Price,  Contract_Type = @Contract_Type, Terms = @Terms" & _
                    " WHERE Contract_ID = @Contract_ID "
        SQL.FlushParams()
        SQL.AddParam("Contract_ID", ID)
        SQL.AddParam("VCECode", txtVCECode.Text)
        SQL.AddParam("Contract_Date", dtpDate.Value.Date)
        SQL.AddParam("Description", txtDescription.Text)
        SQL.AddParam("Contract_Price", IIf(txtPrice.Text = "", 0, CDec(txtPrice.Text)))
        SQL.AddParam("VAT_Amount", IIf(txtVAT.Text = "", 0, CDec(txtVAT.Text)))
        SQL.AddParam("Discount", IIf(txtDiscount.Text = "", 0, CDec(txtDiscount.Text)))
        SQL.AddParam("Total_Price", IIf(txtTotalPrice.Text = "", 0, CDec(txtTotalPrice.Text)))
        SQL.AddParam("Contract_Type", cbType.SelectedItem)
        SQL.AddParam("Terms", IIf(txtTerms.Text = "", 0, CInt(txtTerms.Text)))
        SQL.ExecNonQuery(updateSQL)

    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        If btnRemove.Text = "Cancel" Then
            btnSave.Text = "New"
            btnUpdate.Text = "Edit"
            btnRemove.Text = "Remove"
            EnableControl(False)
        ElseIf btnRemove.Text = "Remove" Then
            If lvList.SelectedItems.Count = 1 Then
                Dim updateSQL As String
                updateSQL = " UPDATE tblSoftware_Contract " & _
                            " SET    Status = 'Inactive' " & _
                            " WHERE Contract_ID = @Contract_ID "
                SQL.FlushParams()
                SQL.AddParam("Contract_ID", lvList.SelectedItems(0).SubItems(0).Text)
                SQL.ExecNonQuery(updateSQL)
            End If
        End If
    End Sub

    Private Sub txtVCEName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCEName.Text = f.VCEName
            txtVCECode.Text = f.VCECode
            f.Dispose()
        End If
    End Sub

    Private Sub txtPrice_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPrice.KeyDown, txtVAT.KeyDown, txtDiscount.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) OrElse e.KeyValue = 190 OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left Then
            If e.KeyValue = 190 And (txtPrice.Text.Contains(".")) Then
                e.SuppressKeyPress = True
            Else
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            txtPrice.Text = CDec(txtPrice.Text).ToString("N2")
            If sender.Name = "txtPrice" Then
                txtVAT.Text = CDec(CDec(txtPrice.Text) * 0.12).ToString("N2")
            End If
            If txtDiscount.Text = "" Then
                txtDiscount.Text = "0.00"
            End If
            If txtVAT.Text = "" Then
                txtVAT.Text = "0.00"
            End If

            txtTotalPrice.Text = CDec(CDec(txtPrice.Text) + CDec(txtVAT.Text) - CDec(txtDiscount.Text)).ToString("N2")
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPrice.TextChanged
        If enableEvent = True Then
            If txtPrice.Text = "" OrElse txtPrice.Text = 0 Then
                enableEvent = False
                txtPrice.Text = 0
                txtPrice.SelectAll()
                enableEvent = True
            End If
        End If
    End Sub

    Private Sub txtVAT_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVAT.KeyDown, txtDiscount.KeyDown

    End Sub

    Private Sub lvList_Click(sender As System.Object, e As System.EventArgs) Handles lvList.Click
        If lvList.SelectedItems.Count = 1 AndAlso lvList.SelectedItems(0).Index = lastIndex Then
            ID = lvList.SelectedItems(0).SubItems(chID.Index).Text
            LoadContract(ID)
            EnableControl(False)
            btnSave.Text = "New"
            btnUpdate.Text = "Edit"
            btnRemove.Text = "Remove"
        Else
            lastIndex = lvList.SelectedItems(0).Index
        End If
    End Sub
End Class