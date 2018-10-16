Public Class frmVCE_Master
    Dim VCECode As String
    Dim moduleID As String = "VCE"

    Private Sub fmrAddVendor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadVAT()
        loadEWT()
        LoadTerms()
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbEdit.Enabled = False
        tsbSave.Enabled = False
        tsbDelete.Enabled = False
        tsbClose.Enabled = False
        tsbPrevious.Enabled = False
        tsbNext.Enabled = False
        tsbExit.Enabled = True
        EnableControl(False)
    End Sub

    Private Sub loadVAT()
        Dim query As String
        query = " SELECT TaxCode FROM tblTaxMaintenance WHERE TaxType ='VAT' AND Status ='Active' "
        SQL.ReadQuery(query)
        cbVATType.Items.Clear()
        While SQL.SQLDR.Read
            cbVATType.Items.Add(SQL.SQLDR("TaxCode").ToString)
        End While
    End Sub

    Private Sub loadEWT()
        Dim query As String
        query = " SELECT TaxCode FROM tblTaxMaintenance WHERE TaxType ='EWT' AND Status ='Active' "
        SQL.ReadQuery(query)
        cbWTaxType.Items.Clear()
        While SQL.SQLDR.Read
            cbWTaxType.Items.Add(SQL.SQLDR("TaxCode").ToString)
        End While
    End Sub

    Private Sub LoadTerms()
        Dim query As String
        query = " SELECT  DISTINCT Terms " & _
                " FROM    tblVCE_Master " & _
                " ORDER BY Terms "
        SQL.ReadQuery(query)
        cbTerms.Items.Clear()
        While SQL.SQLDR.Read
            cbTerms.Items.Add(SQL.SQLDR("Terms"))
        End While
    End Sub

    Private Sub LoadVCE(ByVal Code As String)
        Dim query As String
        query = " SELECT   VCECode, VCEName, TIN_No,  " & _
                 "          ISNULL(isVendor,0) AS isVendor, ISNULL(isCustomer,0) AS isCustomer, ISNULL(isMember,0) AS isMember, ISNULL(isEmployee,0) AS isEmployee, " & _
                 "          Address_Unit, Address_Lot_Blk, Address_Street, Address_Subd, Address_Brgy, Address_City, Address_Province, " & _
                 "          Address_ZipCode, Contact_Telephone, Contact_Cellphone, Contact_Fax, Contact_Email, Contact_Website, Contact_Person, Terms " & _
                 " FROM     tblVCE_Master " & _
                 " WHERE    VCECode = '" & Code & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtVCEName.Text = SQL.SQLDR("VCEName").ToString
            txtTinNo.Text = SQL.SQLDR("TIN_No").ToString
            chkVendor.Checked = SQL.SQLDR("isVendor")
            chkCustomer.Checked = SQL.SQLDR("isCustomer")
            chkEmployee.Checked = SQL.SQLDR("isEmployee")
            chkMember.Checked = SQL.SQLDR("isMember")
            txtUnit.Text = SQL.SQLDR("Address_Unit").ToString
            txtBlkLot.Text = SQL.SQLDR("Address_Lot_Blk").ToString
            txtStreet.Text = SQL.SQLDR("Address_Street").ToString
            txtSubd.Text = SQL.SQLDR("Address_Subd").ToString
            txtBrgy.Text = SQL.SQLDR("Address_Brgy").ToString
            txtCity.Text = SQL.SQLDR("Address_City").ToString
            txtProvince.Text = SQL.SQLDR("Address_Province").ToString
            txtZipCode.Text = SQL.SQLDR("Address_ZipCode").ToString
            txtTelephone.Text = SQL.SQLDR("Contact_Telephone").ToString
            txtCellphone.Text = SQL.SQLDR("Contact_Cellphone").ToString
            txtFax.Text = SQL.SQLDR("Contact_Fax").ToString
            txtEmail.Text = SQL.SQLDR("Contact_Email").ToString
            txtWebsite.Text = SQL.SQLDR("Contact_Website").ToString
            txtContact.Text = SQL.SQLDR("Contact_Person").ToString
            cbTerms.Text = SQL.SQLDR("Terms").ToString

            ' Toolstrip Buttons
            tsbSearch.Enabled = True
            tsbNew.Enabled = True
            tsbEdit.Enabled = True
            tsbSave.Enabled = False
            tsbDelete.Enabled = True
            tsbClose.Enabled = False
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbExit.Enabled = True
            EnableControl(False)
        End If
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("VCE_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmVCE_Search
            f.ModFrom = "VCE"
            f.ShowDialog()
            If f.VCECode <> "" Then
                VCECode = f.VCECode
            End If
            LoadVCE(VCECode)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("VCE_ADD") Then
            msgRestricted()
        Else
            txtVCECode.Clear()
            txtVCEName.Clear()
            txtTinNo.Clear()
            chkVendor.Checked = False
            chkCustomer.Checked = False
            chkEmployee.Checked = False
            chkMember.Checked = False

            cbWTaxType.SelectedIndex = 0
            cbVatType.SelectedIndex = 0
            txtUnit.Clear()
            txtBlkLot.Clear()
            txtStreet.Clear()
            txtSubd.Clear()
            txtBrgy.Clear()
            txtCity.Clear()
            txtProvince.Clear()
            txtZipCode.Clear()
            chkPEZA.Checked = False
            txtCellphone.Clear()
            txtTelephone.Clear()
            txtFax.Clear()
            txtWebsite.Clear()
            txtEmail.Clear()
            txtContact.Clear()
            VCECode = ""

            txtVCECode.Select()
            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False

            EnableControl(True)
        End If
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtVCECode.Enabled = Value
        txtVCEName.Enabled = Value
        txtTinNo.Enabled = Value
        chkVendor.Enabled = Value
        chkCustomer.Enabled = Value
        chkEmployee.Enabled = Value
        chkMember.Enabled = Value
        cbVatType.Enabled = Value
        cbWTaxType.Enabled = Value
        chkPEZA.Enabled = Value
        txtUnit.Enabled = Value
        txtBlkLot.Enabled = Value
        txtStreet.Enabled = Value
        txtSubd.Enabled = Value
        txtBrgy.Enabled = Value
        txtCity.Enabled = Value
        txtProvince.Enabled = Value
        txtZipCode.Enabled = Value
        cbTerms.Enabled = Value

        txtFax.Enabled = Value
        txtCellphone.Enabled = Value
        txtTelephone.Enabled = Value
        txtEmail.Enabled = Value
        txtWebsite.Enabled = Value
        txtContact.Enabled = Value
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("VCE_ADD") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click


        ' Toolstrip Buttons
        If VCECode = "" Then
            tsbNew.PerformClick()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbDelete.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
        Else
            LoadVCE(VCECode)
            tsbEdit.Enabled = True
            tsbDelete.Enabled = True
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
        End If
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click
        If Not AllowAccess("VCE_DEL") Then
            msgRestricted()
        Else
            If txtVCECode.Text <> "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " DELETE FROM tblVCE_Master WHERE VCECode = @VCECode "
                        SQL.FlushParams()
                        SQL.AddParam("@VCECode", txtVCECode.Text)
                        SQL.ExecNonQuery(deleteSQL)
                        Msg("Record deleted successfully", MsgBoxStyle.Information)

                        tsbNew.PerformClick()
                        tsbSearch.Enabled = True
                        tsbNew.Enabled = True
                        tsbEdit.Enabled = False
                        tsbSave.Enabled = False
                        tsbDelete.Enabled = False
                        tsbClose.Enabled = False
                        tsbPrevious.Enabled = False
                        tsbNext.Enabled = False
                        tsbExit.Enabled = True
                        EnableControl(False)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
                    Finally
                        RecordActivity(UserID, moduleID, Me.Name.ToString, "DELETE", "VCECode", txtVCECode.Text, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub


    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If txtVCECode.Text = "" Then
            Msg("Please enter VCECode!", MsgBoxStyle.Exclamation)
        ElseIf VCECode = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                If RecordExist(txtVCECode.Text) Then
                    Msg("VCECode already in used! Please change VCECode", MsgBoxStyle.Exclamation)
                Else
                    SaveVCE()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    VCECode = txtVCECode.Text
                    LoadVCE(VCECode)
                End If
            End If
        Else
            ' IF VCECODE IS CHANGED VALIDATE IF NEW CODE EXIST
            Dim Validated As Boolean = True
            If VCECode <> txtVCECode.Text Then
                If RecordExist(txtVCECode.Text) Then
                    Validated = False
                Else
                    Validated = True
                End If
            End If

            If Validated Then
                If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdateVCE()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    VCECode = txtVCECode.Text
                    LoadVCE(VCECode)
                End If
            Else
                Msg("New VCECode is already in used! Please change VCECode", MsgBoxStyle.Exclamation)
                txtVCECode.Text = VCECode
                txtVCECode.SelectAll()
            End If

        End If
    End Sub

    Private Sub SaveVCE()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                         " tblVCE_Master(VCECode, VCEName, TIN_No, isVendor, isCustomer, isMember, isEmployee, Terms, " & _
                         "               Address_Unit, Address_Lot_Blk, Address_Street, Address_Subd, Address_Brgy,  " & _
                         " 	             Address_City, Address_Province, Address_ZipCode, Contact_Telephone, Contact_Cellphone, Contact_Fax, " & _
                         "                Contact_Email, Contact_Website, Contact_Person,  VAT_Code, WTax_Code, PEZA) " & _
                         " VALUES(@VCECode, @VCEName , @TIN_No, @isVendor, @isCustomer, @isMember, @isEmployee, @Terms, " & _
                         "        @Address_Unit, @Address_Lot_Blk, @Address_Street, @Address_Subd, @Address_Brgy,  " & _
                         " 	      @Address_City, @Address_Province, @Address_ZipCode, @Contact_Telephone, @Contact_Cellphone, @Contact_Fax, " & _
                         "        @Contact_Email, @Contact_Website, @Contact_Person, @VAT_Code, @WTax_Code, @PEZA)"
            SQL.FlushParams()
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@VCEName", txtVCEName.Text)
            SQL.AddParam("@TIN_No", txtTinNo.Text)
            SQL.AddParam("@isVendor", chkVendor.Checked)
            SQL.AddParam("@isCustomer", chkCustomer.Checked)
            SQL.AddParam("@isMember", chkMember.Checked)
            SQL.AddParam("@isEmployee", chkEmployee.Checked)
            SQL.AddParam("@Address_Unit", txtUnit.Text)
            SQL.AddParam("@Address_Lot_Blk", txtBlkLot.Text)
            SQL.AddParam("@Address_Street", txtStreet.Text)
            SQL.AddParam("@Address_Subd", txtSubd.Text)
            SQL.AddParam("@Address_Brgy", txtBrgy.Text)
            SQL.AddParam("@Address_City", txtCity.Text)
            SQL.AddParam("@Address_Province", txtProvince.Text)
            SQL.AddParam("@Address_ZipCode", txtZipCode.Text)
            SQL.AddParam("@Contact_Telephone", txtTelephone.Text)
            SQL.AddParam("@Contact_Cellphone", txtCellphone.Text)
            SQL.AddParam("@Contact_Fax", txtFax.Text)
            SQL.AddParam("@Contact_Email", txtEmail.Text)
            SQL.AddParam("@Contact_Website", txtWebsite.Text)
            SQL.AddParam("@Contact_Person", txtContact.Text)
            SQL.AddParam("@VAT_Code", cbWTaxType.SelectedItem)
            SQL.AddParam("@WTax_Code", cbVATType.SelectedItem)
            SQL.AddParam("@PEZA", chkPEZA.Checked)
            SQL.AddParam("@Terms", cbTerms.Text)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "VCECode", txtVCECode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdateVCE()
        Try
            activityStatus = True
            Dim updateSQL As String
            updateSQL = " UPDATE   tblVCE_Master " & _
                         " SET     VCECode = @VCECodeNew, VCEName = @VCEName, TIN_No = @TIN_No,  " & _
                         "         isVendor = @isVendor, isCustomer = @isCustomer, isMember = @isMember, isEmployee = @isEmployee, " & _
                         "         Address_Unit = @Address_Unit, Address_Lot_Blk = @Address_Lot_Blk, " & _
                         "         Address_Street = @Address_Street, Address_Subd = @Address_Subd, Address_Brgy = @Address_Brgy,  " & _
                         "         Address_City = @Address_City, Address_Province = @Address_Province, Address_ZipCode = @Address_ZipCode, " & _
                         "         Contact_Telephone = @Contact_Telephone, Contact_Cellphone = @Contact_Cellphone, Contact_Fax = @Contact_Fax, " & _
                         "         Contact_Email = @Contact_Email, Contact_Website = @Contact_Website, Contact_Person = @Contact_Person, " & _
                         "         VAT_Code = @VAT_Code, WTax_Code = @WTax_Code, PEZA = @PEZA, Terms = @Terms " & _
                         " WHERE   VCECode = @VCECode "
            SQL.FlushParams()
            SQL.AddParam("@VCECode", VCECode)
            SQL.AddParam("@VCECodeNew", txtVCECode.Text)
            SQL.AddParam("@VCEName", txtVCEName.Text)
            SQL.AddParam("@TIN_No", txtTinNo.Text)
            SQL.AddParam("@isVendor", chkVendor.Checked)
            SQL.AddParam("@isCustomer", chkCustomer.Checked)
            SQL.AddParam("@isMember", chkMember.Checked)
            SQL.AddParam("@isEmployee", chkEmployee.Checked)
            SQL.AddParam("@Address_Unit", txtUnit.Text)
            SQL.AddParam("@Address_Lot_Blk", txtBlkLot.Text)
            SQL.AddParam("@Address_Street", txtStreet.Text)
            SQL.AddParam("@Address_Subd", txtSubd.Text)
            SQL.AddParam("@Address_Brgy", txtBrgy.Text)
            SQL.AddParam("@Address_City", txtCity.Text)
            SQL.AddParam("@Address_Province", txtProvince.Text)
            SQL.AddParam("@Address_ZipCode", txtZipCode.Text)
            SQL.AddParam("@Contact_Telephone", txtTelephone.Text)
            SQL.AddParam("@Contact_Cellphone", txtCellphone.Text)
            SQL.AddParam("@Contact_Fax", txtFax.Text)
            SQL.AddParam("@Contact_Email", txtEmail.Text)
            SQL.AddParam("@Contact_Website", txtWebsite.Text)
            SQL.AddParam("@Contact_Person", txtContact.Text)
            SQL.AddParam("@VAT_Code", IIf(cbWTaxType.SelectedItem = Nothing, "", cbWTaxType.SelectedItem))
            SQL.AddParam("@WTax_Code", IIf(cbVATType.SelectedItem = Nothing, "", cbVATType.SelectedItem))
            SQL.AddParam("@PEZA", chkPEZA.Checked)
            SQL.AddParam("@Terms", cbTerms.Text)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "VCECode", txtVCECode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Function RecordExist(ByVal Record As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblVCE_Master WHERE VCECode ='" & Record & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If VCECode <> "" Then
            Dim query As String
            query = " SELECT Top 1 VCECode FROM tblVCE_Master  WHERE VCECode < '" & VCECode & "' ORDER BY VCECode DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                VCECode = SQL.SQLDR("VCECode").ToString
                LoadVCE(VCECode)
            Else
                MsgBox("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If VCECode <> "" Then
            Dim query As String
            query = " SELECT Top 1 VCECode FROM tblVCE_Master  WHERE VCECode > '" & VCECode & "' ORDER BY VCECode ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                VCECode = SQL.SQLDR("VCECode").ToString
                LoadVCE(VCECode)
            Else
                MsgBox("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub frmVCE_Master_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.S Then
                If tsbSave.Enabled = True Then tsbSave.PerformClick()
            ElseIf e.KeyCode = Keys.F Then
                If tsbSearch.Enabled = True Then tsbSearch.PerformClick()
            ElseIf e.KeyCode = Keys.N Then
                If tsbNew.Enabled = True Then tsbNew.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                If tsbEdit.Enabled = True Then tsbEdit.PerformClick()
            ElseIf e.KeyCode = Keys.D Then
                If tsbDelete.Enabled = True Then tsbDelete.PerformClick()
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
                e.SuppressKeyPress = True
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbExit.Enabled = True Then
                    tsbExit.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
        End If
    End Sub
End Class