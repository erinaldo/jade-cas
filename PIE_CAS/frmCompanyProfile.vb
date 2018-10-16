Imports System.IO
Public Class frmCompanyProfile
    Dim SQl As New SQLControl
    Dim disableEvent As Boolean = False
    Dim EmployerID As String
    Dim picPath As String

    Private Sub frmCompanyProfile_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetEmployerInfo()
    End Sub

    Private Sub GetEmployerInfo()
        Dim query As String
        query = " SELECT  Employer_ID, Employer_Name, Employer_Type, " & _
                "         Address_Unit, Address_Lot_Blk, Address_Street, Address_Subd, Address_Brgy, Address_Municipality, Address_Province, " & _
                "         Foreign_Address, Foreign_Address_Country, Zip_Code, " & _
                "         Contact_Telephone_No, Contact_Cellphone_No, Contact_Fax, Contact_Email_Add, Contact_Website, " & _
                "         Tin_No, Employer_Head, Company_Logo, ISNULL(VAT_Reg,0) AS VAT_Reg" & _
                " FROM    tblCompany "
        SQl.ReadQuery(query)
        If SQl.SQLDR.Read() Then
            disableEvent = True
            EmployerID = SQl.SQLDR("Employer_ID").ToString
            txtEmployerName.Text = SQl.SQLDR("Employer_Name").ToString
            If SQl.SQLDR("Employer_Type").ToString = "Private" Then
                rbPrivate.Checked = True
            Else
                rbGovt.Checked = True
            End If
            txtUnit.Text = SQl.SQLDR("Address_Unit").ToString
            txtLotBlk.Text = SQl.SQLDR("Address_Lot_Blk").ToString
            txtStreet.Text = SQl.SQLDR("Address_Street").ToString
            txtSubd.Text = SQl.SQLDR("Address_Subd").ToString
            txtBrgy.Text = SQl.SQLDR("Address_Brgy").ToString
            txtCity.Text = SQl.SQLDR("Address_Municipality").ToString
            txtProvince.Text = SQl.SQLDR("Address_Province").ToString
            txtForeignAddress.Text = SQl.SQLDR("Foreign_Address").ToString
            txtForeignCountry.Text = SQl.SQLDR("Foreign_Address_Country").ToString
            txtZipCode.Text = SQl.SQLDR("Zip_Code").ToString
            txtTelephoneNo.Text = SQl.SQLDR("Contact_Telephone_No").ToString
            txtCellphoneNo.Text = SQl.SQLDR("Contact_Cellphone_No").ToString
            txtFaxNo.Text = SQl.SQLDR("Contact_Fax").ToString
            txtEmailAdd.Text = SQl.SQLDR("Contact_Email_Add").ToString
            txtWebsite.Text = SQl.SQLDR("Contact_Website").ToString
            txtTinNo.Text = SQl.SQLDR("Tin_No").ToString
            txtEmployerHead.Text = SQl.SQLDR("Employer_Head").ToString
            chkVAT.Checked = SQl.SQLDR("VAT_Reg")
            If Not IsDBNull(SQl.SQLDR("Company_Logo")) Then
                pbPicture.Image = New Bitmap(byteArrayToImage(SQl.SQLDR("Company_Logo")))
                pbPicture.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                LoadDefaultImage()
            End If
            disableEvent = False
            btnSave.Text = "Update"
        Else
            btnSave.Text = "Save"
        End If
    End Sub

    Private Sub LoadDefaultImage()
        Dim App_Path As String
        App_Path = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
        pbPicture.ImageLocation = App_Path & "\Images\DefaultLogo.jpg"
        pbPicture.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Function byteArrayToImage(ByVal ByteArrayin As Byte()) As Image
        Using msStream As New MemoryStream(ByteArrayin)
            Return Image.FromStream(msStream)
        End Using
    End Function

    Private Sub Cleartext()
        EmployerID = ""
        txtEmployerName.Clear()
        rbPrivate.Checked = True
        txtUnit.Clear()
        txtLotBlk.Clear()
        txtStreet.Clear()
        txtSubd.Clear()
        txtBrgy.Clear()
        txtCity.Clear()
        txtProvince.Clear()
        txtForeignAddress.Clear()
        txtForeignCountry.Clear()
        txtZipCode.Clear()
        txtTelephoneNo.Clear()
        txtCellphoneNo.Clear()
        txtFaxNo.Clear()
        txtEmailAdd.Clear()
        txtWebsite.Clear()
        txtTinNo.Clear()
        txtEmployerHead.Clear()
      
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        btnUpload.Enabled = Value
        txtEmployerName.ReadOnly = Not Value
        rbPrivate.Enabled = Value
        rbGovt.Enabled = Value
        txtUnit.ReadOnly = Not Value
        txtLotBlk.ReadOnly = Not Value
        txtStreet.ReadOnly = Not Value
        txtSubd.ReadOnly = Not Value
        txtBrgy.ReadOnly = Not Value
        chkVAT.Enabled = Value
        txtCity.ReadOnly = Not Value
        txtProvince.ReadOnly = Not Value
        txtForeignAddress.ReadOnly = Not Value
        txtForeignCountry.ReadOnly = Not Value
        txtZipCode.ReadOnly = Not Value
        txtTelephoneNo.ReadOnly = Not Value
        txtCellphoneNo.ReadOnly = Not Value
        txtFaxNo.ReadOnly = Not Value
        txtEmailAdd.ReadOnly = Not Value
        txtWebsite.ReadOnly = Not Value
        txtTinNo.ReadOnly = Not Value
        txtEmployerHead.ReadOnly = Not Value
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "Save" Then
                 If txtEmployerName.Text = "" Then
                    MsgBox("Please enter registered employer name!", MsgBoxStyle.Exclamation)
                ElseIf MsgBox("Are you sure you want to save this information?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    SaveEmployer()
                    btnSave.Text = "Update"
                End If
            Else
                If txtEmployerName.Text = "" Then
                    MsgBox("Please enter registered employer name!", MsgBoxStyle.Exclamation)
                ElseIf MsgBox("Are you sure you want to update this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    UpdateEmployer()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SaveEmployer()
        Dim insertSQl As String
        insertSQl = " INSERT INTO " & _
                    " tblCompany  (Employer_Name, Employer_Type, Address_Unit, Address_Lot_Blk, Address_Street, Address_Subd, Address_Brgy, " & _
                    "              Address_Municipality, Address_Province, Foreign_Address, Foreign_Address_Country, Zip_Code, Contact_Telephone_No,  " & _
                    "              Contact_Cellphone_No, Contact_Fax, Contact_Email_Add, Contact_Website, Tin_No, Employer_Head, VAT_Reg, " & _
                    "              Who_Modified) " & _
                    " VALUES     (@Employer_Name, @Employer_Type, @Address_Unit, @Address_Lot_Blk, @Address_Street, @Address_Subd, @Address_Brgy, " & _
                    "             @Address_Municipality, @Address_Province, @Foreign_Address, @Foreign_Address_Country, @Zip_Code, @Contact_Telephone_No,  " & _
                    "             @Contact_Cellphone_No, @Contact_Fax, @Contact_Email_Add, @Contact_Website, @Tin_No, @Employer_Head, @VAT_Reg, " & _
                    "             @Who_Modified)"
        SQl.FlushParams()
        SQl.AddParam("@Employer_Name", txtEmployerName.Text)
        SQl.AddParam("@Employer_Type", IIf(rbGovt.Checked = True, "Government", "Private"))
        SQl.AddParam("@Address_Unit", txtUnit.Text)
        SQl.AddParam("@Address_Lot_Blk", txtLotBlk.Text)
        SQl.AddParam("@Address_Street", txtStreet.Text)
        SQl.AddParam("@Address_Subd", txtSubd.Text)
        SQl.AddParam("@Address_Brgy", txtBrgy.Text)
        SQl.AddParam("@Address_Municipality", txtCity.Text)
        SQl.AddParam("@Address_Province", txtProvince.Text)
        SQl.AddParam("@Foreign_Address", txtForeignAddress.Text)
        SQl.AddParam("@Foreign_Address_Country", txtForeignCountry.Text)
        SQl.AddParam("@Zip_Code", txtZipCode.Text)
        SQl.AddParam("@Contact_Telephone_No", txtTelephoneNo.Text)
        SQl.AddParam("@Contact_Cellphone_No", txtCellphoneNo.Text)
        SQl.AddParam("@Contact_Fax", txtFaxNo.Text)
        SQl.AddParam("@Contact_Email_Add", txtEmailAdd.Text)
        SQl.AddParam("@Contact_Website", txtWebsite.Text)
        SQl.AddParam("@Tin_No", txtTinNo.Text)
        SQl.AddParam("@Employer_Head", txtEmployerHead.Text)
        SQl.AddParam("@VAT_Reg", chkVAT.Checked)
        SQl.AddParam("@Who_Modified", "")
        If SQl.ExecNonQuery(insertSQl) = 1 Then
            MsgBox("Company Information Saved Successfully!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub UpdateLogo()
        Dim updateSQL As String
        updateSQL = " UPDATE tblCompany SET Company_Logo = @Company_Logo "
        SQl.FlushParams()
        Dim imgStreamPic As MemoryStream = New MemoryStream()
        If picPath <> "" AndAlso My.Computer.FileSystem.FileExists(picPath) Then
            Image.FromFile(picPath).Save(imgStreamPic, System.Drawing.Imaging.ImageFormat.Png)
        Else
            Dim imgPic As Image
            imgPic = pbPicture.Image
            imgPic.Save(imgStreamPic, System.Drawing.Imaging.ImageFormat.Png)
        End If
        imgStreamPic.Close()
        Dim byteArrayPic As Byte() = imgStreamPic.ToArray()
        SQl.AddParam("@Company_Logo", byteArrayPic, SqlDbType.Image)
        SQl.ExecNonQuery(updateSQL)

    End Sub

    Private Function isDuplicate(ByVal Name As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblCompany WHERE Employer_Name = '" & Name & "' AND Status='Active'"
        SQl.ReadQuery(query)
        If SQl.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub UpdateEmployer()
        Dim updateSQL As String
        updateSQL = " UPDATE tblCompany" & _
                    " SET    Employer_Name = @Employer_Name, Employer_Type = @Employer_Type, " & _
                    "        Address_Unit = @Address_Unit, Address_Lot_Blk = @Address_Lot_Blk, Address_Street = @Address_Street, " & _
                    "        Address_Subd = @Address_Subd, Address_Brgy = @Address_Brgy, Address_Municipality = @Address_Municipality," & _
                    "        Address_Province = @Address_Province, Foreign_Address = @Foreign_Address, Foreign_Address_Country = @Foreign_Address_Country, " & _
                    "        Zip_Code = @Zip_Code, Contact_Telephone_No = @Contact_Telephone_No, Contact_Cellphone_No = @Contact_Cellphone_No,  " & _
                    "        Contact_Fax = @Contact_Fax, Contact_Email_Add = @Contact_Email_Add, Contact_Website = @Contact_Website, " & _
                    "        Tin_No = @Tin_No, Employer_Head = @Employer_Head, VAT_Reg = @VAT_Reg, Who_Modified = @Who_Modified "
        SQl.FlushParams()
        SQl.AddParam("@Employer_Name", txtEmployerName.Text)
        SQl.AddParam("@Employer_Type", IIf(rbGovt.Checked = True, "Government", "Private"))
        SQl.AddParam("@Address_Unit", txtUnit.Text)
        SQl.AddParam("@Address_Lot_Blk", txtLotBlk.Text)
        SQl.AddParam("@Address_Street", txtStreet.Text)
        SQl.AddParam("@Address_Subd", txtSubd.Text)
        SQl.AddParam("@Address_Brgy", txtBrgy.Text)
        SQl.AddParam("@Address_Municipality", txtCity.Text)
        SQl.AddParam("@Address_Province", txtProvince.Text)
        SQl.AddParam("@Foreign_Address", txtForeignAddress.Text)
        SQl.AddParam("@Foreign_Address_Country", txtForeignCountry.Text)
        SQl.AddParam("@Zip_Code", txtZipCode.Text)
        SQl.AddParam("@Contact_Telephone_No", txtTelephoneNo.Text)
        SQl.AddParam("@Contact_Cellphone_No", txtCellphoneNo.Text)
        SQl.AddParam("@Contact_Fax", txtFaxNo.Text)
        SQl.AddParam("@Contact_Email_Add", txtEmailAdd.Text)
        SQl.AddParam("@Contact_Website", txtWebsite.Text)
        SQl.AddParam("@Tin_No", txtTinNo.Text)
        SQl.AddParam("@Employer_Head", txtEmployerHead.Text)
        SQl.AddParam("@VAT_Reg", chkVAT.Checked)
        SQl.AddParam("@Who_Modified", "")
        If SQl.ExecNonQuery(updateSQL) = 1 Then
            UpdateLogo()
            MsgBox("Employer Information Updated Successfully!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub RemoveEmployer(ByVal Employer_ID As String)
        Dim updateSQL As String
        updateSQL = " UPDATE tblCompany" & _
                    " SET    Status ='Inactive' " & _
                    " WHERE  Employer_ID ='" & Employer_ID & " '"
        If SQl.ExecNonQuery(updateSQL) = 1 Then
            MsgBox("Employer Removed Successfully!", MsgBoxStyle.Information)
        End If
    End Sub

  
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnUpload.Click
        With OpenFileDialog1
            .InitialDirectory = "C:\"
            .Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
            .FilterIndex = 4
        End With
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            With pbPicture
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BorderStyle = BorderStyle.Fixed3D
                picPath = OpenFileDialog1.FileName
            End With
        End If
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class