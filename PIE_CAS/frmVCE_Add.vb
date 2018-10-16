Public Class frmVCE_Add
    Public VCEType, VCECode, VCEName As String

    Private Sub frmVCE_Add_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtVCEName.Text = VCEName
        cbVatType.SelectedIndex = 0
        cbWTaxType.SelectedIndex = 0
    End Sub

    Public Overloads Function ShowDialog(ByVal Type As String, Value As String) As Boolean
        VCEType = Type
        VCEName = Value
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtVCEName.Text = "" Then
            MsgBox("Please enter VCE Name!", MsgBoxStyle.Exclamation)
        ElseIf MessageBox.Show("Saving " & VCEType & " information" & vbNewLine & " Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            VCECode = GetVCECode(VCEType)
            SaveVCE(VCECode, VCEType)
            MsgBox("New Record Saved successfully!", MsgBoxStyle.Information)
            Me.Close()
        End If
    End Sub

    Private Sub SaveVCE(VCECode As String, Type As String)
        activityStatus = True
        Try
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblMasterfile_VCE(VCECode, VCEName, VCE_Type, Address_Unit, Address_Lot_Blk, Address_Street, Address_Subd, Address_Brgy,  " & _
                        " 	             Address_City, Address_Province, Address_ZipCode, Contact_Telephone, Contact_Cellphone, Contact_Fax, " & _
                        "                Contact_Email, Contact_Website, Contact_Person, Terms, TIN_No, VAT_Code, WTax_Code, PEZA) " & _
                        " VALUES(@VCECode, @VCEName, @VCE_Type, @Address_Unit, @Address_Lot_Blk, @Address_Street, @Address_Subd, @Address_Brgy,  " & _
                        " 	     @Address_City, @Address_Province, @Address_ZipCode, @Contact_Telephone, @Contact_Cellphone, @Contact_Fax, " & _
                        "        @Contact_Email, @Contact_Website, @Contact_Person, @Terms, @TIN_No, @VAT_Code, @WTax_Code, @PEZA)"
            SQL.FlushParams()
            SQL.AddParam("@VCECode", VCECode)
            SQL.AddParam("@VCEName", txtVCEName.Text)
            SQL.AddParam("@VCE_Type", Type)
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
            SQL.AddParam("@Terms", txtTerms.Text)
            SQL.AddParam("@TIN_No", txtTinNo.Text)
            SQL.AddParam("@VAT_Code", cbVatType.SelectedItem)
            SQL.AddParam("@WTax_Code", cbWTaxType.SelectedItem)
            SQL.AddParam("@PEZA", chkPEZA.Checked)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            MsgBox(ex.Message)
            activityStatus = False
        Finally
            '        RecordActivity(UserID, ModuleID, "INSERT", "Inserted VCECode : " & VCECode, activityStatus)
        End Try

    End Sub

    Private Function GetVCECode(VCEType As String) As String
        Dim query As String
        query = " SELECT '" & Strings.Left(VCEType, 1) & "' +  RIGHT('00000' + CAST(CAST(MAX(REPLACE(VCECode,'" & Strings.Left(VCEType, 1) & "','')) AS int) + 1 AS nvarchar),5) AS VCECode  " & _
                " FROM tblMasterfile_VCE  " & _
                " WHERE VCE_Type ='" & VCEType & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("VCECode")
        Else
            Return Strings.Left(VCEType, 1) + "00001"
        End If
    End Function
End Class