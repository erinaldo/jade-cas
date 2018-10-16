Imports System.IO
Public Class frmMember_Master
    Dim MemCode As String
    Dim moduleID As String = "MM"
    Dim FileName As String
    Dim DisableEvent As Boolean = False
    Dim picPath, sigPath As String


    Private Sub frmMember_Master_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmMember_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbEdit.Enabled = False
        tsbSave.Enabled = False
        tsbDelete.Enabled = False
        tsbClose.Enabled = False
        tsbPrevious.Enabled = False
        tsbNext.Enabled = False
        tsbExit.Enabled = True
        tsbUpload.Enabled = True
        EnableControl(False)
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        ' PERSONAL INFO
        txtMemID.Enabled = Value
        cbTitle.Enabled = Value
        txtLast.Enabled = Value
        txtFirst.Enabled = Value
        txtMiddle.Enabled = Value
        txtSuffix.Enabled = Value
        txtNickName.Enabled = Value
        rbFemale.Enabled = Value
        rbMale.Enabled = Value
        dtpBirthDate.Enabled = Value
        txtBirthPlace.Enabled = Value
        cbBirthCountry.Enabled = Value
        cbNationality.Enabled = Value
        chkResident.Enabled = Value
        cbReligion.Enabled = Value
        cbCivilStatus.Enabled = Value

        ' MEMBERSHIP
        cbStatus.Enabled = Value
        dtpMembershipDate.Enabled = Value
        cbMemberType.Enabled = Value

        ' ADDRESS
        txtMainAddress.Enabled = Value
        txtMainStreet.Enabled = Value
        txtMainBrgy.Enabled = Value
        txtMainSubd.Enabled = Value
        txtMainProv.Enabled = Value
        txtMainCity.Enabled = Value
        txtMainPostal.Enabled = Value
        cbMainCountry.Enabled = Value
        cbMainOwner.Enabled = Value
        dtpMainOcc.Enabled = Value
        txtMailFull.Enabled = Value
        txtMailBrgy.Enabled = Value
        txtMailStreet.Enabled = Value
        txtMailSubd.Enabled = Value
        txtMailCity.Enabled = Value
        txtMailProv.Enabled = Value
        txtMailPostal.Enabled = Value
        dtpMailOccupy.Enabled = Value
        cbMailCountry.Enabled = Value
        cbMailOwner.Enabled = Value

        ' CONTACT
        cbContactType.Enabled = Value
        txtContactNo.Enabled = Value
        btnContactAdd.Enabled = Value
        btnContactRem.Enabled = Value

        ' EMPLOYMENT TAB
        txtCompany.Enabled = Value
        txtCompTin.Enabled = Value
        txtCompContact.Enabled = Value
        cbPSIC.Enabled = Value
        txtGross.Enabled = Value
        cbCurrency.Enabled = Value
        cbOccupationStatus.Enabled = Value
        cbSalaryType.Enabled = Value
        cbOccupation.Enabled = Value
        dtpHiredFrom.Enabled = Value
        dtpHiredTo.Enabled = Value
        cbDepartment.Enabled = Value
        cbSection.Enabled = Value
        txtBusinessName.Enabled = Value
        txtBMainFull.Enabled = Value
        txtBMainStreet.Enabled = Value
        txtBMainSubd.Enabled = Value
        txtBMainBrgy.Enabled = Value
        txtBMainCity.Enabled = Value
        txtBMainProv.Enabled = Value
        txtBMainPostal.Enabled = Value
        cbBMainCountry.Enabled = Value
        dtpBMainOccupy.Enabled = Value
        cbBMainOwner.Enabled = Value
        txtBAddlFull.Enabled = Value
        txtBAddlStreet.Enabled = Value
        txtBAddlSubd.Enabled = Value
        txtBAddlBrgy.Enabled = Value
        txtBAddlCity.Enabled = Value
        txtBAddlProv.Enabled = Value
        txtBAddlPostal.Enabled = Value
        cbBAddlOwner.Enabled = Value
        dtpBAddlOccupy.Enabled = Value
        cbBAddlCountry.Enabled = Value
        cbBContactType.Enabled = Value
        txtBContactNo.Enabled = Value
        btnBContactAdd.Enabled = Value
        btnBContactRem.Enabled = Value
        cbBIDType.Enabled = Value
        txtBIDNo.Enabled = Value
        btnBIDAdd.Enabled = Value
        btnBIDRem.Enabled = Value
        txtEducation.Enabled = Value
        nupNoOfDependents.Enabled = Value
        txtSocialAffiliation.Enabled = Value
        nupCarsOwned.Enabled = Value
        txtFFirst.Enabled = Value
        txtFLast.Enabled = Value
        txtFMiddle.Enabled = Value
        txtFSuffix.Enabled = Value
        txtMFirst.Enabled = Value
        txtMLast.Enabled = Value
        txtMMiddle.Enabled = Value
        txtSFirst.Enabled = Value
        txtSLast.Enabled = Value
        txtSMiddle.Enabled = Value
        cbIDType.Enabled = Value
        txtIDNo.Enabled = Value
        btnIDAdd.Enabled = Value
        btnIDRemove.Enabled = Value
        cbDoctype.Enabled = Value
        txtDocNo.Enabled = Value
        btnDocAdd.Enabled = Value
        btnDocRemove.Enabled = Value
        dtpExpiryDate.Enabled = Value
        dtpDateIssued.Enabled = Value
        cbCountryIssued.Enabled = Value
        txtIssuedBy.Enabled = Value
        btnUploadPic.Enabled = Value
        btnUploadSig.Enabled = Value
    End Sub

    Private Sub tsbNew_Click(sender As Object, e As EventArgs) Handles tsbNew.Click
        If Not AllowAccess("MM_ADD") Then
            msgRestricted()
        Else
            ' PERSONAL INFO 
            txtMemID.Clear()
            cbTitle.SelectedIndex = 0
            txtLast.Clear()
            txtFirst.Clear()
            txtMiddle.Clear()
            txtSuffix.Clear()
            txtNickName.Clear()
            rbFemale.Enabled = True
            rbMale.Enabled = True
            dtpBirthDate.Enabled = True
            txtBirthPlace.Clear()
            cbBirthCountry.SelectedItem = "PHILIPPINES"
            cbNationality.SelectedItem = "PHILIPPINES"
            chkResident.Checked = False
            cbReligion.SelectedIndex = -1
            cbCivilStatus.SelectedIndex = 0
            MemCode = ""

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

            'MEMBERSHIP

            cbStatus.SelectedIndex = 0
            dtpMembershipDate.Enabled = True
            cbMemberType.SelectedIndex = 0

            ' ADDRESS
            txtMainAddress.Clear()
            txtMainStreet.Clear()
            txtMainBrgy.Clear()
            txtMainSubd.Clear()
            txtMainProv.Clear()
            txtMainCity.Clear()
            txtMainPostal.Clear()
            cbMainCountry.SelectedItem = "PHILIPPINES"
            cbMainOwner.SelectedIndex = 0
            dtpMainOcc.Enabled = True
            txtMailFull.Clear()
            txtMailBrgy.Clear()
            txtMailStreet.Clear()
            txtMailSubd.Clear()
            txtMailCity.Clear()
            txtMailProv.Clear()
            txtMailPostal.Clear()
            dtpMailOccupy.Enabled = True
            cbMailCountry.SelectedItem = "PHILIPPINES"
            cbMailOwner.SelectedIndex = 0

            ' CONTACT
            cbContactType.SelectedIndex = 0
            txtContactNo.Clear()
            btnContactAdd.Enabled = True
            btnContactRem.Enabled = True

            ' EMPLOYMENT TAB
            txtCompany.Clear()
            txtCompTin.Clear()
            txtCompContact.Clear()
            cbPSIC.SelectedIndex = 0
            txtGross.Clear()
            cbCurrency.SelectedIndex = 0
            cbOccupationStatus.SelectedIndex = 0
            cbSalaryType.SelectedIndex = 0
            cbOccupation.SelectedIndex = 0
            dtpHiredFrom.Enabled = True
            dtpHiredTo.Enabled = True
            cbDepartment.Enabled = True
            cbSection.Enabled = True
            txtBusinessName.Clear()
            txtBMainFull.Clear()
            txtBMainStreet.Clear()
            txtBMainSubd.Clear()
            txtBMainBrgy.Clear()
            txtBMainCity.Clear()
            txtBMainProv.Clear()
            txtBMainPostal.Clear()
            cbBMainCountry.SelectedItem = "PHILIPPINES"
            dtpBMainOccupy.Enabled = True
            cbBMainOwner.SelectedIndex = 0
            txtBAddlFull.Clear()
            txtBAddlStreet.Clear()
            txtBAddlSubd.Clear()
            txtBAddlBrgy.Clear()
            txtBAddlCity.Clear()
            txtBAddlProv.Clear()
            txtBAddlPostal.Clear()
            cbBAddlOwner.SelectedIndex = 0
            dtpBAddlOccupy.Enabled = True
            cbBAddlCountry.SelectedItem = "PHILIPPINES"
            cbBContactType.SelectedIndex = 0
            txtBContactNo.Clear()
            btnBContactAdd.Enabled = True
            btnBContactRem.Enabled = True
            cbBIDType.SelectedIndex = 0
            txtBIDNo.Clear()
            btnBIDAdd.Enabled = True
            btnBIDRem.Enabled = True
            txtEducation.Clear()
            nupNoOfDependents.Enabled = True
            txtSocialAffiliation.Clear()
            nupCarsOwned.Enabled = True
            txtFFirst.Clear()
            txtFLast.Clear()
            txtFMiddle.Clear()
            txtFSuffix.Clear()
            txtMFirst.Clear()
            txtMLast.Clear()
            txtMMiddle.Clear()
            txtSFirst.Clear()
            txtSLast.Clear()
            txtSMiddle.Clear()
            cbIDType.SelectedIndex = 0
            txtIDNo.Clear()
            btnIDAdd.Enabled = True
            btnIDRemove.Enabled = True
            cbDoctype.SelectedIndex = 0
            txtDocNo.Clear()
            btnDocAdd.Enabled = True
            btnDocRemove.Enabled = True
            dtpExpiryDate.Enabled = True
            dtpDateIssued.Enabled = True
            cbCountryIssued.SelectedItem = "PHILIPPINES"
            txtIssuedBy.Clear()
            btnUploadPic.Enabled = True
            btnUploadSig.Enabled = True
        End If
    End Sub

    Private Sub tsbExit_Click(sender As Object, e As EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("MM_EDIT") Then
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
    Public Sub listViewAlternateColor(listView As ListView)
        Dim iView As Integer = listView.Items.Count - 1
        For i = 0 To iView Step 2
            listView.Items(i).UseItemStyleForSubItems = True
            listView.Items(i).BackColor = Drawing.Color.WhiteSmoke
        Next i
    End Sub

    Private Sub SaveMember()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO tblMember_Master" & _
                        " (   Member_ID, Title, First_Name, Last_Name, Middle_Name, Suffix, Nick_Name, Full_Name, Gender, Birth_Date,  " & _
                        " 	  Birth_Place, Birth_Country, Nationality, Resident, Civil_Status, Dependent_No, Cars_Owned,  " & _
                        "     Spouse_FirstName, Spouse_LastName, Spouse_MiddleName, Mother_FirstName, Mother_LastName, Mother_MiddleName,  " & _
                        " 	  Father_FirstName, Father_MiddleName, Father_Last_Name, Father_Suffix, Photo, Signature," & _
                        "     Religion, Educational_Attainment, Social_Affiliation, Member_Type, Status, Membership_Date) " & _
                        " VALUES " & _
                        " (   @Member_ID, @Title, @First_Name, @Last_Name, @Middle_Name, @Suffix, @Nick_Name, @Full_Name, @Gender, @Birth_Date,  " & _
                        " 	  @Birth_Place, @Birth_Country, @Nationality, @Resident, @Civil_Status, @Dependent_No, @Cars_Owned,  " & _
                        "     @Spouse_FirstName, @Spouse_LastName, @Spouse_MiddleName, @Mother_FirstName, @Mother_LastName, @Mother_MiddleName,  " & _
                        " 	  @Father_FirstName, @Father_MiddleName, @Father_Last_Name, @Father_Suffix, @Photo, @Signature," & _
                        "     @Religion, @Educational_Attainment, @Social_Affiliation, @Member_Type, @Status, @Membership_Date) "
            SQL.FlushParams()
            SQL.AddParam("@Member_ID", txtMemID.Text)
            SQL.AddParam("@Title", IIf(cbTitle.SelectedItem = Nothing, "", cbTitle.SelectedItem))
            SQL.AddParam("@First_Name", txtFirst.Text)
            SQL.AddParam("@Middle_Name", txtMiddle.Text)
            SQL.AddParam("@Last_Name", txtLast.Text)
            SQL.AddParam("@Suffix", txtSuffix.Text)
            SQL.AddParam("@Nick_Name", txtMainAddress.Text)
            SQL.AddParam("@Full_Name", txtLast.Text + ", " + txtFirst.Text + IIf(txtMiddle.Text = "", "", " " + txtMiddle.Text) + IIf(txtSuffix.Text = "", "", " " + txtSuffix.Text))
            SQL.AddParam("@Gender", IIf(rbFemale.Checked = True, "Female", "Male"))
            SQL.AddParam("@Birth_Date", IIf(dtpBirthDate.Checked, dtpBirthDate.Value.Date, DBNull.Value))
            SQL.AddParam("@Birth_Place", txtBirthPlace.Text)
            SQL.AddParam("@Birth_Country", cbBirthCountry.SelectedItem)
            SQL.AddParam("@Nationality", cbNationality.SelectedItem)
            SQL.AddParam("@Resident", chkResident.Checked)
            SQL.AddParam("@Civil_Status", cbCivilStatus.SelectedItem)
            SQL.AddParam("@Dependent_No", nupNoOfDependents.Value)
            SQL.AddParam("@Cars_Owned", nupCarsOwned.Value)
            SQL.AddParam("@Religion", cbReligion.Text)
            SQL.AddParam("@Educational_Attainment", txtEducation.Text)
            SQL.AddParam("@Social_Affiliation", txtSocialAffiliation.Text)
            SQL.AddParam("@Spouse_FirstName", txtSFirst.Text)
            SQL.AddParam("@Spouse_LastName", txtSLast.Text)
            SQL.AddParam("@Spouse_MiddleName", txtSMiddle.Text)
            SQL.AddParam("@Mother_FirstName", txtMFirst.Text)
            SQL.AddParam("@Mother_LastName", txtMLast.Text)
            SQL.AddParam("@Mother_MiddleName", txtMMiddle.Text)
            SQL.AddParam("@Father_FirstName", txtFFirst.Text)
            SQL.AddParam("@Father_MiddleName", txtFMiddle.Text)
            SQL.AddParam("@Father_Last_Name", txtFLast.Text)
            SQL.AddParam("@Father_Suffix", txtFSuffix.Text)
            SQL.AddParam("@Member_Type", cbMemberType.Text)
            SQL.AddParam("@Status", cbStatus.SelectedItem)
            SQL.AddParam("@Membership_Date", IIf(dtpMembershipDate.Checked, dtpMembershipDate.Value.Date, DBNull.Value))

            ' SAVE IMAGE AND SIGNATURE
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
            SQL.AddParam("@Photo", byteArrayPic, SqlDbType.Image)
            Dim imgStreamSig As MemoryStream = New MemoryStream()
            If sigPath <> "" AndAlso My.Computer.FileSystem.FileExists(sigPath) Then
                Image.FromFile(sigPath).Save(imgStreamSig, System.Drawing.Imaging.ImageFormat.Jpeg)
            Else
                Dim imgSig As Image
                imgSig = pbSignature.Image
                imgSig.Save(imgStreamSig, System.Drawing.Imaging.ImageFormat.Png)
            End If
            imgStreamSig.Close()
            Dim byteArraySig As Byte() = imgStreamSig.ToArray()
            SQL.AddParam("@Signature", byteArraySig, SqlDbType.Image)
            SQL.ExecNonQuery(insertSQL)

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "MemCode", txtMemID.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub
    Private Sub SaveEmpAddressMI()
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblMember_Address(Member_ID, Address_Type, Full_Address, Postal, Street, Subd, Brgy, City, Province, Country,  " & _
                    "                   Address_Owner, Occupied_Since, Sole_Trader)   " & _
                    " VALUES(@Member_ID, @Address_Type, @Full_Address, @Postal, @Street, @Subd, @Brgy, @City, @Province, @Country,  " & _
                    "                   @Address_Owner, @Occupied_Since, @Sole_Trader)   "
        SQL.FlushParams()
        SQL.AddParam("@Member_ID", txtMemID.Text)
        SQL.AddParam("@Address_Type", "MI")
        SQL.AddParam("@Full_Address", txtMainAddress.Text)
        SQL.AddParam("@Postal", txtMainPostal.Text)
        SQL.AddParam("@Street", txtMainStreet.Text)
        SQL.AddParam("@Subd", txtMainSubd.Text)
        SQL.AddParam("@Brgy", txtMainBrgy.Text)
        SQL.AddParam("@City", txtMainCity.Text)
        SQL.AddParam("@Province", txtMainProv.Text)
        SQL.AddParam("@Country", cbMainCountry.SelectedItem)
        SQL.AddParam("@Address_Owner", cbMainOwner.SelectedItem)
        SQL.AddParam("@Occupied_Since", IIf(dtpMainOcc.Checked, DBNull.Value, dtpMainOcc.Value.Date))
        SQL.AddParam("@Sole_Trader", 0)
        SQL.ExecNonQuery(insertSQL)

    End Sub
    Private Sub SaveEmpAddressAI()
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblMember_Address(Member_ID, Address_Type, Full_Address, Postal, Street, Subd, Brgy, City, Province, Country,  " & _
                    "                   Address_Owner, Occupied_Since, Sole_Trader)   " & _
                    " VALUES(@Member_ID, @Address_Type, @Full_Address, @Postal, @Street, @Subd, @Brgy, @City, @Province, @Country,  " & _
                    "                   @Address_Owner, @Occupied_Since, @Sole_Trader)   "
        SQL.FlushParams()
        SQL.AddParam("@Member_ID", txtMemID.Text)
        SQL.AddParam("@Address_Type", "AI")
        SQL.AddParam("@Full_Address", txtMailFull.Text)
        SQL.AddParam("@Postal", txtMailPostal.Text)
        SQL.AddParam("@Street", txtMailStreet.Text)
        SQL.AddParam("@Subd", txtMailSubd.Text)
        SQL.AddParam("@Brgy", txtMailBrgy.Text)
        SQL.AddParam("@City", txtMailCity.Text)
        SQL.AddParam("@Province", txtMailProv.Text)
        SQL.AddParam("@Country", cbMailCountry.SelectedItem)
        SQL.AddParam("@Address_Owner", cbMailOwner.SelectedItem)
        SQL.AddParam("@Occupied_Since", IIf(dtpMailOccupy.Checked, dtpMailOccupy.Value.Date, DBNull.Value))
        SQL.AddParam("@Sole_Trader", 0)
        SQL.ExecNonQuery(insertSQL)
    End Sub
    Private Sub SaveContact()
        Dim insertSQL As String
        For Each item As ListViewItem In lvContact.Items
            insertSQL = " INSERT INTO " & _
                        " tblMember_Contact(Member_ID, Contact_Type, Contact_No, Sole_Trader) " & _
                        " VALUES(@Member_ID, @Contact_Type, @Contact_No, @Sole_Trader)  "
            SQL.FlushParams()
            SQL.AddParam("@Member_ID", txtMemID.Text)
            SQL.AddParam("@Contact_Type", item.SubItems(0).Text)
            SQL.AddParam("@Contact_No", item.SubItems(1).Text)
            SQL.AddParam("@Sole_Trader", 0)
            SQL.ExecNonQuery(insertSQL)
        Next
    End Sub

    Private Sub SaveContactST()
        Dim insertSQL As String
        For Each item As ListViewItem In lvBContactList.Items
            insertSQL = " INSERT INTO " & _
                        " tblMember_Contact(Member_ID, Contact_Type, Contact_No, Sole_Trader) " & _
                        " VALUES(@Member_ID, @Contact_Type, @Contact_No, @Sole_Trader)  "
            SQL.FlushParams()
            SQL.AddParam("@Member_ID", txtMemID.Text)
            SQL.AddParam("@Contact_Type", item.SubItems(0).Text)
            SQL.AddParam("@Contact_No", item.SubItems(1).Text)
            SQL.AddParam("@Sole_Trader", 1)
            SQL.ExecNonQuery(insertSQL)
        Next
    End Sub

    Private Sub SaveBussAddressMI()
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblMember_Address(Member_ID, Address_Type, Full_Address, Postal, Street, Subd, Brgy, City, Province, Country,  " & _
                    "                   Address_Owner, Occupied_Since, Sole_Trader)   " & _
                    " VALUES(@Member_ID, @Address_Type, @Full_Address, @Postal, @Street, @Subd, @Brgy, @City, @Province, @Country,  " & _
                    "                   @Address_Owner, @Occupied_Since, @Sole_Trader)   "
        SQL.FlushParams()
        SQL.AddParam("@Member_ID", txtMemID.Text)
        SQL.AddParam("@Address_Type", "MI")
        SQL.AddParam("@Full_Address", txtBMainFull.Text)
        SQL.AddParam("@Postal", txtBMainPostal.Text)
        SQL.AddParam("@Street", txtBMainStreet.Text)
        SQL.AddParam("@Subd", txtBMainSubd.Text)
        SQL.AddParam("@Brgy", txtBMainBrgy.Text)
        SQL.AddParam("@City", txtBMainCity.Text)
        SQL.AddParam("@Province", txtBMainProv.Text)
        SQL.AddParam("@Country", cbBMainCountry.SelectedItem)
        SQL.AddParam("@Address_Owner", cbBMainOwner.SelectedItem)
        SQL.AddParam("@Occupied_Since", IIf(dtpBMainOccupy.Checked, dtpBMainOccupy.Value.Date, DBNull.Value))
        SQL.AddParam("@Sole_Trader", 1)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub SaveBussAddressAI()
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblMember_Address(Member_ID, Address_Type, Full_Address, Postal, Street, Subd, Brgy, City, Province, Country,  " & _
                    "                   Address_Owner, Occupied_Since, Sole_Trader)   " & _
                    " VALUES(@Member_ID, @Address_Type, @Full_Address, @Postal, @Street, @Subd, @Brgy, @City, @Province, @Country,  " & _
                    "                   @Address_Owner, @Occupied_Since, @Sole_Trader)   "
        SQL.FlushParams()
        SQL.AddParam("@Member_ID", txtMemID.Text)
        SQL.AddParam("@Address_Type", "AI")
        SQL.AddParam("@Full_Address", txtBAddlFull.Text)
        SQL.AddParam("@Postal", txtBAddlPostal.Text)
        SQL.AddParam("@Street", txtBAddlStreet.Text)
        SQL.AddParam("@Subd", txtBAddlSubd.Text)
        SQL.AddParam("@Brgy", txtBAddlBrgy.Text)
        SQL.AddParam("@City", txtBAddlCity.Text)
        SQL.AddParam("@Province", txtBAddlProv.Text)
        SQL.AddParam("@Country", cbBAddlCountry.SelectedItem)
        SQL.AddParam("@Address_Owner", cbBAddlOwner.SelectedItem)
        SQL.AddParam("@Occupied_Since", IIf(dtpBAddlOccupy.Checked, dtpBAddlOccupy.Value.Date, DBNull.Value))
        SQL.AddParam("@Sole_Trader", 1)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub SaveEmployment()
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                " tblMember_Employment(Member_ID, Trade_Name, TIN_No, Phone_No, PSIC, Gross_Income, Annual_Monthly, Currency, " & _
                "                      Occupation_Status, Hired_From, Hired_To, Occupation, Sole_Trader, Department, Section)  " & _
                " VALUES(@Member_ID, @Trade_Name, @TIN_No, @Phone_No, @PSIC, @Gross_Income, @Annual_Monthly, @Currency, " & _
                "        @Occupation_Status, @Hired_From, @Hired_To, @Occupation, @Sole_Trader, @Department, @Section)  "
        SQL.FlushParams()
        SQL.AddParam("@Member_ID", txtMemID.Text)
        SQL.AddParam("@Trade_Name", txtCompany.Text)
        SQL.AddParam("@TIN_No", txtCompTin.Text)
        SQL.AddParam("@Phone_No", txtCompContact.Text)
        SQL.AddParam("@PSIC", cbPSIC.SelectedItem)
        If IsNumeric(txtGross.Text) Then
            SQL.AddParam("@Gross_Income", CDec(txtGross.Text))
        Else
            SQL.AddParam("@Gross_Income", 0)
        End If
        SQL.AddParam("@Annual_Monthly", cbSalaryType.SelectedItem)
        SQL.AddParam("@Currency", cbCurrency.SelectedItem)
        SQL.AddParam("@Occupation_Status", cbOccupationStatus.SelectedItem)
        SQL.AddParam("@Hired_From", IIf(dtpHiredFrom.Checked, dtpHiredFrom.Value, DBNull.Value))
        SQL.AddParam("@Hired_To", IIf(dtpHiredTo.Checked, dtpHiredTo.Value, DBNull.Value))
        SQL.AddParam("@Occupation", cbOccupation.SelectedItem)
        SQL.AddParam("@Sole_Trader", txtBusinessName.Text)
        SQL.AddParam("@Department", cbDepartment.Text)
        SQL.AddParam("@Section", cbSection.Text)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub SavePrimaryID()
        For Each item As ListViewItem In lvPrimary.Items
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblMember_ID(Member_ID, Type, ID_Number, Sole_Trader) " & _
                        " VALUES(@Member_ID, @Type, @ID_Number, @Sole_Trader) "
            SQL.FlushParams()
            SQL.AddParam("@Member_ID", txtMemID.Text)
            SQL.AddParam("@Type", item.SubItems(0).Text)
            SQL.AddParam("@ID_Number", item.SubItems(1).Text)
            SQL.AddParam("@Sole_Trader", 0)
            SQL.ExecNonQuery(insertSQL)
        Next
    End Sub

    Private Sub SaveBussPrimaryID()
        For Each item As ListViewItem In lvBIDList.Items
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblMember_ID(Member_ID, Type, ID_Number, Sole_Trader) " & _
                        " VALUES(@Member_ID, @Type, @ID_Number, @Sole_Trader) "
            SQL.FlushParams()
            SQL.AddParam("@Member_ID", txtMemID.Text)
            SQL.AddParam("@Type", item.SubItems(0).Text)
            SQL.AddParam("@ID_Number", item.SubItems(1).Text)
            SQL.AddParam("@Sole_Trader", 0)
            SQL.ExecNonQuery(insertSQL)
        Next
    End Sub

    Private Sub SaveDocumentID()
        For Each item As ListViewItem In lvDocList.Items
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblMember_Documents(Member_ID, Doc_Type, Doc_Number, Issue_Date, Issue_Country,  Expiry_Date, Issued_By) " & _
                        " VALUES(@Member_ID, @Doc_Type, @Doc_Number, @Issue_Date, @Issue_Country, @Expiry_Date, @Issued_By)"
            SQL.FlushParams()
            SQL.AddParam("@Member_ID", txtMemID.Text)
            SQL.AddParam("@Doc_Type", item.SubItems(0).Text)
            SQL.AddParam("@Doc_Number", item.SubItems(1).Text)
            If IsDate(item.SubItems(2).Text) Then
                SQL.AddParam("@Issue_Date", item.SubItems(2).Text)
            Else
                SQL.AddParam("@Issue_Date", DBNull.Value)
            End If
            SQL.AddParam("@Issue_Country", item.SubItems(3).Text)
            If IsDate(item.SubItems(4).Text) Then
                SQL.AddParam("@Expiry_Date", item.SubItems(4).Text)
            Else
                SQL.AddParam("@Expiry_Date", DBNull.Value)
            End If

            SQL.AddParam("@Issued_By", item.SubItems(5).Text)
            SQL.ExecNonQuery(insertSQL)
        Next

    End Sub
    Private Sub LoadMember(ByVal Code As String)
        Dim query As String
        query = " SELECT    Member_ID, Title, First_Name, Last_Name, Middle_Name, Suffix, Nick_Name, Full_Name, Gender, Birth_Date, " & _
                 "          Birth_Place, Birth_Country, Nationality, Resident, Civil_Status, Dependent_No, Cars_Owned,  " & _
                 "          Spouse_FirstName, Spouse_LastName, Spouse_MiddleName, Mother_FirstName, Mother_LastName, Mother_MiddleName, " & _
                 "          Father_FirstName, Father_MiddleName, Father_Last_Name, Father_Suffix, Photo, Signature, " & _
                 "          Religion, Educational_Attainment, Social_Affiliation, Member_Type, Status, Membership_Date " & _
                 " FROM     tblMember_Master " & _
                 " WHERE    Member_ID = '" & Code & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtMemID.Text = SQL.SQLDR("Member_ID").ToString
            cbTitle.Text = SQL.SQLDR("Title").ToString
            txtFirst.Text = SQL.SQLDR("First_Name").ToString
            txtLast.Text = SQL.SQLDR("Last_Name").ToString
            txtMiddle.Text = SQL.SQLDR("Middle_Name").ToString
            txtSuffix.Text = SQL.SQLDR("Suffix").ToString
            txtNickName.Text = SQL.SQLDR("Nick_Name").ToString
            If SQL.SQLDR("Gender").ToString = "Male" Then
                rbMale.Checked = True
            Else
                rbFemale.Checked = True
            End If
            If Not IsDBNull(SQL.SQLDR("Birth_Date")) Then
                dtpBirthDate.Value = SQL.SQLDR("Birth_Date")
                dtpBirthDate.Checked = True
                dtpBirthDate.Format = DateTimePickerFormat.Short
                dtpBirthDate.CustomFormat = ""
            Else
                dtpBirthDate.Format = DateTimePickerFormat.Custom
                dtpBirthDate.CustomFormat = " "
                dtpBirthDate.Checked = False
            End If
            txtBirthPlace.Text = SQL.SQLDR("Birth_Place").ToString
            cbBirthCountry.Text = SQL.SQLDR("Birth_Country").ToString
            cbNationality.Text = SQL.SQLDR("Nationality").ToString
            chkResident.Text = SQL.SQLDR("Resident").ToString
            cbReligion.Text = SQL.SQLDR("Religion").ToString
            cbCivilStatus.Text = SQL.SQLDR("Civil_Status").ToString
            nupNoOfDependents.Text = SQL.SQLDR("Dependent_No").ToString
            nupCarsOwned.Text = SQL.SQLDR("Cars_Owned").ToString
            txtSFirst.Text = SQL.SQLDR("Spouse_FirstName").ToString
            txtSLast.Text = SQL.SQLDR("Spouse_LastName").ToString
            txtSMiddle.Text = SQL.SQLDR("Spouse_MiddleName").ToString
            txtMFirst.Text = SQL.SQLDR("Mother_FirstName").ToString
            txtMMiddle.Text = SQL.SQLDR("Mother_MiddleName").ToString
            txtFFirst.Text = SQL.SQLDR("Father_FirstName").ToString
            txtFMiddle.Text = SQL.SQLDR("Father_MiddleName").ToString
            txtFLast.Text = SQL.SQLDR("Father_Last_Name").ToString
            txtFSuffix.Text = SQL.SQLDR("Father_Suffix").ToString
            txtEducation.Text = SQL.SQLDR("Educational_Attainment").ToString
            txtSocialAffiliation.Text = SQL.SQLDR("Social_Affiliation").ToString
            cbMemberType.Text = SQL.SQLDR("Member_Type").ToString
            cbStatus.Text = SQL.SQLDR("Status").ToString
            dtpMembershipDate.Text = SQL.SQLDR("Membership_Date").ToString
            If Not IsDBNull(SQL.SQLDR("Photo")) Then
                pbPicture.Image = New Bitmap(byteArrayToImage(SQL.SQLDR("Photo")))
                pbPicture.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                LoadDefaultImage("Picture", IIf(rbFemale.Checked = True, "Female", "Male"))
            End If
            If Not IsDBNull(SQL.SQLDR("Signature")) Then
                pbSignature.Image = New Bitmap(byteArrayToImage(SQL.SQLDR("Signature")))
                pbSignature.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                LoadDefaultImage("Signature")
            End If

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
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)

    End Sub
    Private Sub LoadEmpAddressMI(ByVal MemID As String)
        Dim query As String
        query = " SELECT  Full_Address, Postal, Street, Subd, Brgy, City, Province, Country, Address_Owner, Occupied_Since   " & _
                " FROM    tblMember_Address WHERE Member_ID ='" & MemID & "' " & _
                " AND     Address_Type ='MI' AND Sole_Trader = 0 "
        SQl.ReadQuery(query)
        If SQL.SQLDR.Read Then
            DisableEvent = True
            txtMainAddress.Text = SQL.SQLDR("Full_Address").ToString
            txtMainPostal.Text = SQL.SQLDR("Postal").ToString
            txtMainStreet.Text = SQL.SQLDR("Street").ToString
            txtMainSubd.Text = SQL.SQLDR("Subd").ToString
            txtMainBrgy.Text = SQL.SQLDR("Brgy").ToString
            txtMainCity.Text = SQL.SQLDR("City").ToString
            txtMainProv.Text = SQL.SQLDR("Province").ToString
            cbMainCountry.SelectedItem = SQL.SQLDR("Country").ToString
            cbMainOwner.SelectedItem = SQL.SQLDR("Address_Owner").ToString
            If Not IsDBNull(SQL.SQLDR("Occupied_Since")) Then
                dtpMainOcc.Value = SQL.SQLDR("Occupied_Since")
                dtpMainOcc.Checked = True
                dtpMainOcc.Format = DateTimePickerFormat.Short
                dtpMainOcc.CustomFormat = ""
            Else
                dtpMainOcc.Format = DateTimePickerFormat.Custom
                dtpMainOcc.CustomFormat = " "
                dtpMainOcc.Checked = False
            End If
            DisableEvent = False
        End If
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadEmpAddressAI(ByVal MemID As String)
        Dim query As String
        query = " SELECT  Full_Address, Postal, Street, Subd, Brgy, City, Province, Country, Address_Owner, Occupied_Since   " & _
                " FROM    tblMember_Address WHERE Member_ID ='" & MemID & "' " & _
                " AND     Address_Type ='AI' AND Sole_Trader = 0 "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtMailFull.Text = SQL.SQLDR("Full_Address").ToString
            txtMailPostal.Text = SQL.SQLDR("Postal").ToString
            txtMailStreet.Text = SQL.SQLDR("Street").ToString
            txtMailSubd.Text = SQL.SQLDR("Subd").ToString
            txtMailBrgy.Text = SQL.SQLDR("Brgy").ToString
            txtMailCity.Text = SQL.SQLDR("City").ToString
            txtMailProv.Text = SQL.SQLDR("Province").ToString
            cbMailCountry.SelectedItem = SQL.SQLDR("Country").ToString
            cbMailOwner.SelectedItem = SQL.SQLDR("Address_Owner").ToString
            If Not IsDBNull(SQL.SQLDR("Occupied_Since")) Then
                dtpMailOccupy.Value = SQL.SQLDR("Occupied_Since")
                dtpMailOccupy.Checked = True
                dtpMailOccupy.Format = DateTimePickerFormat.Short
                dtpMailOccupy.CustomFormat = ""
            Else
                dtpMailOccupy.Format = DateTimePickerFormat.Custom
                dtpMailOccupy.CustomFormat = " "
                dtpMailOccupy.Checked = False
            End If
        End If
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadEmpContact(ByVal MemID As String)
        Dim query As String
        query = " SELECT  Contact_Type, Contact_No FROM tblMember_Contact " & _
                " WHERE   Member_ID ='" & MemID & "' AND Sole_Trader =0 "
        SQl.ReadQuery(query)
        lvContact.Items.Clear()
        While SQl.SQLDR.Read
            lvContact.Items.Add(SQl.SQLDR("Contact_Type").ToString)
            lvContact.Items(lvContact.Items.Count - 1).SubItems.Add(SQl.SQLDR("Contact_No").ToString)
        End While
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadEmployment(ByVal MemID As String)
        Dim query As String
        query = " SELECT  Trade_Name, TIN_No, Phone_No, PSIC, Gross_Income, Annual_Monthly, Currency, " & _
                "         Occupation_Status, Hired_From, Hired_To, Occupation, Sole_Trader, Department, Section  " & _
                " FROM    tblMember_Employment " & _
                " WHERE   Member_ID ='" & MemID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtCompany.Text = SQL.SQLDR("Trade_Name").ToString
            txtCompTin.Text = SQL.SQLDR("TIN_No").ToString
            txtCompContact.Text = SQL.SQLDR("Phone_No").ToString
            cbPSIC.SelectedItem = SQL.SQLDR("PSIC").ToString
            txtGross.Text = CDec(SQL.SQLDR("Gross_Income")).ToString("N2")
            cbSalaryType.SelectedItem = SQL.SQLDR("Annual_Monthly").ToString
            cbCurrency.SelectedItem = SQL.SQLDR("Currency").ToString
            cbOccupationStatus.SelectedItem = SQL.SQLDR("Occupation_Status").ToString
            If Not IsDBNull(SQL.SQLDR("Hired_From")) Then
                dtpHiredFrom.Value = SQL.SQLDR("Hired_From")
                dtpHiredFrom.Checked = True
                dtpHiredFrom.Format = DateTimePickerFormat.Short
                dtpHiredFrom.CustomFormat = ""
            Else
                dtpHiredFrom.Format = DateTimePickerFormat.Custom
                dtpHiredFrom.CustomFormat = " "
                dtpHiredFrom.Checked = False
            End If
            If Not IsDBNull(SQL.SQLDR("Hired_To")) Then
                dtpHiredTo.Value = SQL.SQLDR("Hired_To")
                dtpHiredTo.Checked = True
                dtpHiredTo.Format = DateTimePickerFormat.Short
                dtpHiredTo.CustomFormat = ""
            Else
                dtpHiredTo.Format = DateTimePickerFormat.Custom
                dtpHiredTo.CustomFormat = " "
                dtpHiredTo.Checked = False
            End If
            cbOccupation.SelectedItem = SQL.SQLDR("Occupation").ToString
            txtBusinessName.Text = SQL.SQLDR("Sole_Trader").ToString
            cbDepartment.Text = SQL.SQLDR("Department").ToString
            cbSection.Text = SQL.SQLDR("Section").ToString
        End If
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadPrimaryID(ByVal EmpID As String)
        Dim query As String
        query = " SELECT Type, ID_Number  FROM tblMember_ID " & _
                " WHERE Member_ID = '" & EmpID & "' AND Sole_Trader = 0 "
        SQL.ReadQuery(query)
        lvPrimary.Items.Clear()
        While SQL.SQLDR.Read
            lvPrimary.Items.Add(SQL.SQLDR("Type").ToString)
            lvPrimary.Items(lvPrimary.Items.Count - 1).SubItems.Add(SQL.SQLDR("ID_Number").ToString)
        End While
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadDocumentID(ByVal EmpID As String)
        Dim query As String
        query = " SELECT  Doc_Type, Doc_Number, Issue_Date, Issue_Country, Expiry_Date, Issued_By " & _
                " FROM    tblMember_Documents " & _
                " WHERE   Member_ID = '" & EmpID & "' "
        SQL.ReadQuery(query)
        lvDocList.Items.Clear()
        While SQL.SQLDR.Read
            lvDocList.Items.Add(SQL.SQLDR("Doc_Type").ToString)
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Doc_Number").ToString)
            If Not IsDBNull(SQL.SQLDR("Issue_Date")) Then
                lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Issue_Date"))
            Else
                lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add("")
            End If
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Issue_Country").ToString)
            If Not IsDBNull(SQL.SQLDR("Expiry_Date")) Then
                lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Expiry_Date"))
            Else
                lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add("")
            End If
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Issued_By").ToString)
        End While
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadBussAddressMI(ByVal MemID As String)
        Dim query As String
        query = " SELECT  Full_Address, Postal, Street, Subd, Brgy, City, Province, Country, Address_Owner, Occupied_Since   " & _
                " FROM    tblMember_Address WHERE Member_ID ='" & MemID & "' " & _
                " AND     Address_Type ='MI' AND Sole_Trader = 1 "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtBMainFull.Text = SQL.SQLDR("Full_Address").ToString
            txtBMainPostal.Text = SQL.SQLDR("Postal").ToString
            txtBMainStreet.Text = SQL.SQLDR("Street").ToString
            txtBMainSubd.Text = SQL.SQLDR("Subd").ToString
            txtBMainBrgy.Text = SQL.SQLDR("Brgy").ToString
            txtBMainCity.Text = SQL.SQLDR("City").ToString
            txtBMainProv.Text = SQL.SQLDR("Province").ToString
            If SQL.SQLDR("Full_Address").ToString = "" Then
                cbBMainCountry.SelectedItem = SQL.SQLDR("Country").ToString
            Else
                cbBMainCountry.SelectedItem = "PHILIPPINES"
            End If

            cbBMainOwner.SelectedItem = SQL.SQLDR("Address_Owner").ToString
            If Not IsDBNull(SQL.SQLDR("Occupied_Since")) Then
                dtpBMainOccupy.Checked = True
                dtpBMainOccupy.Format = DateTimePickerFormat.Short
                dtpBMainOccupy.CustomFormat = ""
                dtpBMainOccupy.Value = SQL.SQLDR("Occupied_Since")
            Else
                dtpBMainOccupy.Checked = False
                dtpBMainOccupy.Format = DateTimePickerFormat.Custom
                dtpBMainOccupy.CustomFormat = " "
            End If
        End If
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadBussAddressAI(ByVal MemID As String)
        Dim query As String
        query = " SELECT  Full_Address, Postal, Street, Subd, Brgy, City, Province, Country, Address_Owner, Occupied_Since   " & _
                " FROM    tblMember_Address WHERE Member_ID ='" & MemID & "' " & _
                " AND     Address_Type ='AI' AND Sole_Trader = 1 "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtBAddlFull.Text = SQL.SQLDR("Full_Address").ToString
            txtBAddlPostal.Text = SQL.SQLDR("Postal").ToString
            txtBAddlStreet.Text = SQL.SQLDR("Street").ToString
            txtBAddlSubd.Text = SQL.SQLDR("Subd").ToString
            txtBAddlBrgy.Text = SQL.SQLDR("Brgy").ToString
            txtBAddlCity.Text = SQL.SQLDR("City").ToString
            txtBAddlProv.Text = SQL.SQLDR("Province").ToString
            If SQL.SQLDR("Full_Address").ToString = "" Then
                cbBAddlCountry.SelectedItem = SQL.SQLDR("Country").ToString
            Else
                cbBAddlCountry.SelectedItem = "PHILIPPINES"
            End If

            cbBAddlOwner.SelectedItem = SQL.SQLDR("Address_Owner").ToString
            If Not IsDBNull(SQL.SQLDR("Occupied_Since")) Then
                dtpBAddlOccupy.Value = SQL.SQLDR("Occupied_Since")
                dtpBAddlOccupy.Checked = True
                dtpBAddlOccupy.Format = DateTimePickerFormat.Short
                dtpBAddlOccupy.CustomFormat = ""
            Else
                dtpBAddlOccupy.Checked = False
                dtpBAddlOccupy.Format = DateTimePickerFormat.Custom
                dtpBAddlOccupy.CustomFormat = " "
            End If
        End If
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadBussID(ByVal EmpID As String)
        Dim query As String
        query = " SELECT Type, ID_Number  FROM tblMember_ID " & _
                " WHERE Member_ID = '" & EmpID & "' AND Sole_Trader =1 "
        SQL.ReadQuery(query)
        lvBIDList.Items.Clear()
        While SQL.SQLDR.Read
            lvBIDList.Items.Add(SQL.SQLDR("Type").ToString)
            lvBIDList.Items(lvBIDList.Items.Count - 1).SubItems.Add(SQL.SQLDR("ID_Number").ToString)
        End While
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub

    Private Sub LoadBussContact(ByVal MemID As String)
        Dim query As String
        query = " SELECT  Contact_Type, Contact_No FROM tblMember_Contact " & _
                " WHERE   Member_ID ='" & MemID & "' AND Sole_Trader =1 "
        SQL.ReadQuery(query)
        lvBContactList.Items.Clear()
        While SQL.SQLDR.Read
            lvBContactList.Items.Add(SQL.SQLDR("Contact_Type").ToString)
            lvBContactList.Items(lvBContactList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Contact_No").ToString)
        End While
        listViewAlternateColor(lvContact)
        listViewAlternateColor(lvBIDList)
        listViewAlternateColor(lvDocList)
    End Sub
    Private Sub UpdateMember()
        Try
            activityStatus = True
            Dim updateSQL As String

            updateSQL = " UPDATE tblMember_Master" & _
                        " SET    Member_ID = @Member_ID, Title = @Title, First_Name = @First_Name, Last_Name = @Last_Name, Middle_Name = @Middle_Name, Suffix = @Suffix, Nick_Name = @Nick_Name, " & _
                        "        Full_Name = @Full_Name, Gender = @Gender, Birth_Date = @Birth_Date, Birth_Place = @Birth_Place, Birth_Country = @Birth_Country, " & _
                        "        Nationality = @Nationality, Resident = @Resident, Civil_Status = @Civil_Status, Dependent_No = @Dependent_No, Cars_Owned = @Cars_Owned,  " & _
                        "        Spouse_FirstName = @Spouse_FirstName, Spouse_LastName = @Spouse_LastName, Spouse_MiddleName = @Spouse_MiddleName, Mother_FirstName = @Mother_FirstName, " & _
                        "        Mother_LastName = @Mother_LastName, Mother_MiddleName = @Mother_MiddleName, Father_FirstName = @Father_FirstName, Father_MiddleName = @Father_MiddleName, " & _
                        " 	     Father_Last_Name = @Father_Last_Name, Father_Suffix = @Father_Suffix, Religion = @Religion," & _
                        "        Educational_Attainment = @Educational_Attainment, Social_Affiliation = @Social_Affiliation, Member_Type = @Member_Type, " & _
                        "        Status = @Status, Membership_Date = @Membership_Date " & _
                        " WHERE  Member_ID = @Member_ID "
            SQL.FlushParams()
            SQL.AddParam("@Member_ID", txtMemID.Text)
            SQL.AddParam("@Title", IIf(cbTitle.SelectedItem = Nothing, "", cbTitle.SelectedItem))
            SQL.AddParam("@First_Name", txtFirst.Text)
            SQL.AddParam("@Middle_Name", txtMiddle.Text)
            SQL.AddParam("@Last_Name", txtLast.Text)
            SQL.AddParam("@Suffix", txtSuffix.Text)
            SQL.AddParam("@Nick_Name", txtNickName.Text)
            SQL.AddParam("@Full_Name", txtLast.Text + ", " + txtFirst.Text + IIf(txtMiddle.Text = "", "", " " + txtMiddle.Text) + IIf(txtSuffix.Text = "", "", " " + txtSuffix.Text))
            SQL.AddParam("@Gender", IIf(rbFemale.Checked = True, "Female", "Male"))
            SQL.AddParam("@Birth_Date", IIf(dtpBirthDate.Checked, dtpBirthDate.Value.Date, DBNull.Value))
            SQL.AddParam("@Birth_Place", txtBirthPlace.Text)
            SQL.AddParam("@Birth_Country", cbBirthCountry.SelectedItem)
            SQL.AddParam("@Nationality", cbNationality.SelectedItem)
            SQL.AddParam("@Resident", chkResident.Checked)
            SQL.AddParam("@Civil_Status", cbCivilStatus.SelectedItem)
            SQL.AddParam("@Dependent_No", nupNoOfDependents.Value)
            SQL.AddParam("@Cars_Owned", nupCarsOwned.Value)
            SQL.AddParam("@Religion", cbReligion.Text)
            SQL.AddParam("@Educational_Attainment", txtEducation.Text)
            SQL.AddParam("@Social_Affiliation", txtSocialAffiliation.Text)
            SQL.AddParam("@Spouse_FirstName", txtSFirst.Text)
            SQL.AddParam("@Spouse_LastName", txtSLast.Text)
            SQL.AddParam("@Spouse_MiddleName", txtSMiddle.Text)
            SQL.AddParam("@Mother_FirstName", txtMFirst.Text)
            SQL.AddParam("@Mother_LastName", txtMLast.Text)
            SQL.AddParam("@Mother_MiddleName", txtMMiddle.Text)
            SQL.AddParam("@Father_FirstName", txtFFirst.Text)
            SQL.AddParam("@Father_MiddleName", txtFMiddle.Text)
            SQL.AddParam("@Father_Last_Name", txtFLast.Text)
            SQL.AddParam("@Father_Suffix", txtFSuffix.Text)
            SQL.AddParam("@Member_Type", cbMemberType.Text)
            SQL.AddParam("@Status", cbStatus.SelectedItem)
            SQL.AddParam("@Membership_Date", IIf(dtpMembershipDate.Checked, dtpMembershipDate.Value.Date, DBNull.Value))



            ' SAVE IMAGE AND SIGNATURE
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
            SQL.AddParam("@Photo", byteArrayPic, SqlDbType.Image)
            Dim imgStreamSig As MemoryStream = New MemoryStream()
            If sigPath <> "" AndAlso My.Computer.FileSystem.FileExists(sigPath) Then
                Image.FromFile(sigPath).Save(imgStreamSig, System.Drawing.Imaging.ImageFormat.Jpeg)
            Else
                Dim imgSig As Image
                imgSig = pbSignature.Image
                imgSig.Save(imgStreamSig, System.Drawing.Imaging.ImageFormat.Png)
            End If
            imgStreamSig.Close()
            Dim byteArraySig As Byte() = imgStreamSig.ToArray()
            SQL.AddParam("@Signature", byteArraySig, SqlDbType.Image)
            SQL.ExecNonQuery(updateSQL)

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "MemCode", txtMemID.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
        Dim deleteSQL As String
        deleteSQL = " DELETE FROM tblMember_Address WHERE Member_ID = '" & txtMemID.Text & "' "
        SQL.ExecNonQuery(deleteSQL)
        deleteSQL = " DELETE FROM tblMember_Contact WHERE Member_ID = '" & txtMemID.Text & "' "
        SQL.ExecNonQuery(deleteSQL)
        deleteSQL = " DELETE FROM tblMember_Documents WHERE Member_ID = '" & txtMemID.Text & "' "
        SQL.ExecNonQuery(deleteSQL)
        deleteSQL = " DELETE FROM tblMember_Employment WHERE Member_ID = '" & txtMemID.Text & "' "
        SQL.ExecNonQuery(deleteSQL)
        deleteSQL = " DELETE FROM tblMember_ID WHERE Member_ID = '" & txtMemID.Text & "' "
        SQL.ExecNonQuery(deleteSQL)
        SaveEmpAddressMI()
        SaveEmpAddressAI()
        SaveContact()
        SaveEmployment()
        SaveBussAddressAI()
        SaveBussAddressMI()
        SaveContactST()
        SavePrimaryID()
        SaveDocumentID()
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtMemID.Text = "" Then
            Msg("Please enter Member ID!", MsgBoxStyle.Exclamation)
        ElseIf MemCode = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                If RecordExist(txtMemID.Text) Then
                    Msg("VCECode already in used! Please change Member ID", MsgBoxStyle.Exclamation)
                Else
                    SaveMember()
                    SaveEmpAddressMI()
                    SaveEmpAddressAI()
                    SaveContact()
                    SaveEmployment()
                    SaveBussAddressAI()
                    SaveBussAddressMI()
                    SaveContactST()
                    SavePrimaryID()
                    SaveDocumentID()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    MemCode = txtMemID.Text
                    LoadMember(MemCode)
                    LoadEmpAddressMI(MemCode)
                    LoadEmpAddressAI(MemCode)
                    LoadEmpContact(MemCode)
                    LoadEmployment(MemCode)
                    LoadPrimaryID(MemCode)
                    LoadDocumentID(MemCode)
                    LoadBussAddressMI(MemCode)
                    LoadBussAddressAI(MemCode)
                    LoadBussID(MemCode)
                    LoadBussContact(MemCode)
                End If
            End If
        Else
            ' IF VCECODE IS CHANGED VALIDATE IF NEW CODE EXIST
            Dim Validated As Boolean = True
            If MemCode <> txtMemID.Text Then
                If RecordExist(txtMemID.Text) Then
                    Validated = False
                Else
                    Validated = True
                End If
            End If

            If Validated Then
                If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdateMember()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    MemCode = txtMemID.Text
                    LoadMember(MemCode)
                    LoadEmpAddressMI(MemCode)
                    LoadEmpAddressAI(MemCode)
                    LoadEmpContact(MemCode)
                    LoadEmployment(MemCode)
                    LoadPrimaryID(MemCode)
                    LoadDocumentID(MemCode)
                    LoadBussAddressMI(MemCode)
                    LoadBussAddressAI(MemCode)
                    LoadBussID(MemCode)
                    LoadBussContact(MemCode)
                End If
            Else
                Msg("New VCECode is already in used! Please change VCECode", MsgBoxStyle.Exclamation)
                txtMemID.Text = MemCode
                txtMemID.SelectAll()
            End If

        End If
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("MM_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmMember_Search
            f.ShowDialog()
            If f.MemberID <> "" Then
                MemCode = f.MemberID
            End If
            LoadMember(MemCode)
            LoadEmpAddressMI(MemCode)
            LoadEmpAddressAI(MemCode)
            LoadEmpContact(MemCode)
            LoadEmployment(MemCode)
            LoadPrimaryID(MemCode)
            LoadDocumentID(MemCode)
            LoadBussAddressMI(MemCode)
            LoadBussAddressAI(MemCode)
            LoadBussID(MemCode)
            LoadBussContact(MemCode)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If Not AllowAccess("MM_DEL") Then
            msgRestricted()
        Else
            If txtMemID.Text <> "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " DELETE FROM tblMember_Master WHERE Member_ID = @Member_ID "
                        SQL.FlushParams()
                        SQL.AddParam("@Member_ID", txtMemID.Text)
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
                        RecordActivity(UserID, moduleID, Me.Name.ToString, "DELETE", "VCECode", txtMemID.Text, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As Object, e As EventArgs) Handles tsbPrevious.Click
        If MemCode <> "" Then
            Dim query As String
            query = " SELECT Top 1 Member_ID FROM tblMember_Master  WHERE Member_ID < '" & MemCode & "' ORDER BY Member_ID DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                MemCode = SQL.SQLDR("Member_ID").ToString
                LoadMember(MemCode)
                LoadEmpAddressMI(MemCode)
                LoadEmpAddressAI(MemCode)
                LoadEmpContact(MemCode)
                LoadEmployment(MemCode)
                LoadPrimaryID(MemCode)
                LoadDocumentID(MemCode)
                LoadBussAddressMI(MemCode)
                LoadBussAddressAI(MemCode)
                LoadBussID(MemCode)
                LoadBussContact(MemCode)
            Else
                MsgBox("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As Object, e As EventArgs) Handles tsbNext.Click
        If MemCode <> "" Then
            Dim query As String
            query = " SELECT Top 1 Member_ID FROM tblMember_Master  WHERE Member_ID > '" & MemCode & "' ORDER BY Member_ID ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                MemCode = SQL.SQLDR("Member_ID").ToString
                LoadMember(MemCode)
                LoadEmpAddressMI(MemCode)
                LoadEmpAddressAI(MemCode)
                LoadEmpContact(MemCode)
                LoadEmployment(MemCode)
                LoadPrimaryID(MemCode)
                LoadDocumentID(MemCode)
                LoadBussAddressMI(MemCode)
                LoadBussAddressAI(MemCode)
                LoadBussID(MemCode)
                LoadBussContact(MemCode)
            Else
                MsgBox("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click

        ' Toolstrip Buttons
        If MemCode = "" Then
            tsbNew.PerformClick()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbDelete.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
        Else
            LoadMember(MemCode)
            LoadEmpAddressMI(MemCode)
            LoadEmpAddressAI(MemCode)
            LoadEmpContact(MemCode)
            LoadEmployment(MemCode)
            LoadPrimaryID(MemCode)
            LoadDocumentID(MemCode)
            LoadBussAddressMI(MemCode)
            LoadBussAddressAI(MemCode)
            LoadBussID(MemCode)
            LoadBussContact(MemCode)
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
        LoadMember(MemCode)
        LoadEmpAddressMI(MemCode)
        LoadEmpAddressAI(MemCode)
        LoadEmpContact(MemCode)
        LoadEmployment(MemCode)
        LoadPrimaryID(MemCode)
        LoadDocumentID(MemCode)
        LoadBussAddressMI(MemCode)
        LoadBussAddressAI(MemCode)
        LoadBussID(MemCode)
        LoadBussContact(MemCode)
    End Sub

    Private Sub btnContactAdd_Click(sender As Object, e As EventArgs) Handles btnContactAdd.Click
        If txtContactNo.Text <> "" Then
            lvContact.Items.Add(cbContactType.SelectedItem)
            lvContact.Items(lvContact.Items.Count - 1).SubItems.Add(txtContactNo.Text)
            For i As Integer = 0 To cbContactType.Items.Count - 1
                Dim exist As Boolean = False
                For Each item As ListViewItem In lvContact.Items
                    If item.SubItems(0).Text = cbContactType.Items(i) Then
                        exist = True
                    End If
                Next
                If Not exist Then
                    cbContactType.SelectedIndex = i
                    Exit For
                End If
            Next
            txtContactNo.Text = ""
        End If
    End Sub

    Private Sub btnContactRem_Click(sender As Object, e As EventArgs) Handles btnContactRem.Click
        lvContact.Items.RemoveAt(lvContact.SelectedItems(0).Index)
    End Sub

    Private Sub btnUploadPic_Click(sender As Object, e As EventArgs) Handles btnUploadPic.Click
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

    Private Sub btnUploadSig_Click(sender As Object, e As EventArgs) Handles btnUploadSig.Click
        With OpenFileDialog1
            .InitialDirectory = "C:\"
            .Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
            .FilterIndex = 4
        End With
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            With pbSignature
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BorderStyle = BorderStyle.Fixed3D
                sigPath = OpenFileDialog1.FileName
            End With
        End If
    End Sub

    Private Sub pbSignature_Click(sender As Object, e As EventArgs) Handles pbSignature.Click

    End Sub

    Private Sub btnBContactAdd_Click(sender As Object, e As EventArgs) Handles btnBContactAdd.Click
        If txtBContactNo.Text <> "" Then
            lvBContactList.Items.Add(cbBContactType.SelectedItem)
            lvBContactList.Items(lvBContactList.Items.Count - 1).SubItems.Add(txtBContactNo.Text)
            For i As Integer = 0 To cbBContactType.Items.Count - 1
                Dim exist As Boolean = False
                For Each item As ListViewItem In lvBContactList.Items
                    If item.SubItems(0).Text = cbBContactType.Items(i) Then
                        exist = True
                    End If
                Next
                If Not exist Then
                    cbBContactType.SelectedIndex = i
                    Exit For
                End If
            Next
            txtBContactNo.Text = ""
        End If
    End Sub

    Private Sub btnBContactRem_Click(sender As Object, e As EventArgs) Handles btnBContactRem.Click
        lvBContactList.Items.RemoveAt(lvBContactList.SelectedItems(0).Index)
    End Sub

    Private Sub btnBIDAdd_Click(sender As Object, e As EventArgs) Handles btnBIDAdd.Click
        If txtBIDNo.Text <> "" Then
            lvBIDList.Items.Add(cbBIDType.SelectedItem)
            lvBIDList.Items(lvBIDList.Items.Count - 1).SubItems.Add(txtBIDNo.Text)
            For i As Integer = 0 To cbBIDType.Items.Count - 1
                Dim exist As Boolean = False
                For Each item As ListViewItem In lvBIDList.Items
                    If item.SubItems(0).Text = cbBIDType.Items(i) Then
                        exist = True
                    End If
                Next
                If Not exist Then
                    cbBIDType.SelectedIndex = i
                    Exit For
                End If
            Next
            txtBIDNo.Text = ""
        End If
    End Sub

    Private Sub btnBIDRem_Click(sender As Object, e As EventArgs) Handles btnBIDRem.Click
        lvBIDList.Items.RemoveAt(lvBIDList.SelectedItems(0).Index)
    End Sub

    Private Sub btnIDAdd_Click(sender As Object, e As EventArgs) Handles btnIDAdd.Click
        If txtIDNo.Text <> "" Then
            lvPrimary.Items.Add(cbIDType.SelectedItem)
            lvPrimary.Items(lvPrimary.Items.Count - 1).SubItems.Add(txtIDNo.Text)
            For i As Integer = 0 To cbIDType.Items.Count - 1
                Dim exist As Boolean = False
                For Each item As ListViewItem In lvPrimary.Items
                    If item.SubItems(0).Text = cbIDType.Items(i) Then
                        exist = True
                    End If
                Next
                If Not exist Then
                    cbIDType.SelectedIndex = i
                    Exit For
                End If
            Next
            txtIDNo.Text = ""
        End If
    End Sub

    Private Sub btnDocAdd_Click(sender As Object, e As EventArgs) Handles btnDocAdd.Click
        If txtDocNo.Text <> "" Then
            lvDocList.Items.Add(cbDoctype.SelectedItem)
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(txtDocNo.Text)
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(IIf(dtpDateIssued.Checked, dtpDateIssued.Value.Date, ""))
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(cbCountryIssued.SelectedItem)
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(IIf(dtpExpiryDate.Checked, dtpExpiryDate.Value.Date, ""))
            lvDocList.Items(lvDocList.Items.Count - 1).SubItems.Add(txtIssuedBy.Text)
            For i As Integer = 0 To cbDoctype.Items.Count - 1
                Dim exist As Boolean = False
                For Each item As ListViewItem In lvDocList.Items
                    If item.SubItems(0).Text = cbDoctype.Items(i) Then
                        exist = True
                    End If
                Next
                If Not exist Then
                    cbDoctype.SelectedIndex = i
                    Exit For
                End If
            Next
            txtDocNo.Text = ""
        End If
    End Sub

    Private Sub btnIDRemove_Click(sender As Object, e As EventArgs) Handles btnIDRemove.Click
        lvPrimary.Items.RemoveAt(lvPrimary.SelectedItems(0).Index)
    End Sub

    Private Sub btnDocRemove_Click(sender As Object, e As EventArgs) Handles btnDocRemove.Click
        lvDocList.Items.RemoveAt(lvDocList.SelectedItems(0).Index)
    End Sub

    Private Sub tbsUpload_Click(sender As Object, e As EventArgs) Handles tsbUpload.Click
        Dim OpenFileDialog As New OpenFileDialog
        Dim ctrN As Integer
        Dim str As String
        Dim objExcel As New Microsoft.Office.Interop.Excel.Application

        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            FileName = OpenFileDialog.FileName
            objExcel.Workbooks.Open(FileName)
            str = "a"
            ctrN = 2

            Dim count As Integer = 1

            Do While str <> ""
                Dim Member_Code, Member_ID, Title, First_Name, Last_Name, Middle_Name, Suffix, Nick_Name, Full_Name, Gender,
                Birth_Place, Birth_Country, Nationality, Resident, Civil_Status, Dependent_No, Cars_Owned, Spouse_FirstName,
                Spouse_LastName, Spouse_MiddleName, Mother_FirstName, Mother_LastName, Mother_MiddleName, Father_FirstName,
                Father_MiddleName, Father_Last_Name, Father_Suffix, Religion, Educational_Attainment, Social_Affiliation, Last_Name_Prev,
                Member_Type, Status As String
                Dim Membership_Date, Birth_Date As Date
                Dim principal, interest As Decimal
                Dim loan_ID As Integer = 0
                principal = 0
                interest = 0

                Member_Code = txtMemID.Text
                Member_ID = RTrim(objExcel.Range("a" & CStr(ctrN)).Value)
                Title = RTrim(objExcel.Range("b" & CStr(ctrN)).Value)
                First_Name = RTrim(objExcel.Range("c" & CStr(ctrN)).Value)
                Last_Name = RTrim(objExcel.Range("d" & CStr(ctrN)).Value)
                Middle_Name = RTrim(objExcel.Range("e" & CStr(ctrN)).Value)
                Suffix = RTrim(objExcel.Range("f" & CStr(ctrN)).Value)
                Nick_Name = RTrim(objExcel.Range("g" & CStr(ctrN)).Value)
                Full_Name = RTrim(objExcel.Range("h" & CStr(ctrN)).Value)
                Last_Name_Prev = RTrim(objExcel.Range("i" & CStr(ctrN)).Value)
                Gender = RTrim(objExcel.Range("j" & CStr(ctrN)).Value)
                Birth_Date = IIf(RTrim(objExcel.Range("k" & CStr(ctrN)).Value) = "NULL", "1/1/1995", RTrim(objExcel.Range("k" & CStr(ctrN)).Value))
                Birth_Place = RTrim(objExcel.Range("l" & CStr(ctrN)).Value)
                Birth_Country = RTrim(objExcel.Range("m" & CStr(ctrN)).Value)
                Nationality = RTrim(objExcel.Range("n" & CStr(ctrN)).Value)
                Resident = RTrim(objExcel.Range("o" & CStr(ctrN)).Value)
                Civil_Status = RTrim(objExcel.Range("p" & CStr(ctrN)).Value)
                Dependent_No = RTrim(objExcel.Range("q" & CStr(ctrN)).Value)
                Cars_Owned = RTrim(objExcel.Range("r" & CStr(ctrN)).Value)
                Spouse_FirstName = RTrim(objExcel.Range("s" & CStr(ctrN)).Value)
                Spouse_LastName = RTrim(objExcel.Range("t" & CStr(ctrN)).Value)
                Spouse_MiddleName = RTrim(objExcel.Range("u" & CStr(ctrN)).Value)
                Mother_FirstName = RTrim(objExcel.Range("v" & CStr(ctrN)).Value)
                Mother_LastName = RTrim(objExcel.Range("w" & CStr(ctrN)).Value)
                Mother_MiddleName = RTrim(objExcel.Range("x" & CStr(ctrN)).Value)
                Father_FirstName = RTrim(objExcel.Range("y" & CStr(ctrN)).Value)
                Father_MiddleName = RTrim(objExcel.Range("z" & CStr(ctrN)).Value)
                Father_Last_Name = RTrim(objExcel.Range("aa" & CStr(ctrN)).Value)
                Father_Suffix = RTrim(objExcel.Range("ab" & CStr(ctrN)).Value)
                'Photo = RTrim(objExcel.Range("ac" & CStr(ctrN)).Value)
                'Signature = RTrim(objExcel.Range("ad" & CStr(ctrN)).Value)
                Religion = RTrim(objExcel.Range("ae" & CStr(ctrN)).Value)
                Educational_Attainment = RTrim(objExcel.Range("af" & CStr(ctrN)).Value)
                Social_Affiliation = RTrim(objExcel.Range("ag" & CStr(ctrN)).Value)
                Member_Type = RTrim(objExcel.Range("ah" & CStr(ctrN)).Value)
                Status = RTrim(objExcel.Range("ai" & CStr(ctrN)).Value)
                Membership_Date = IIf(RTrim(objExcel.Range("aj" & CStr(ctrN)).Value) = "NULL", "1/1/1995", RTrim(objExcel.Range("aj" & CStr(ctrN)).Value))

                Dim insertSQL As String

                insertSQL = " INSERT INTO tblMember_Master (Member_ID, Title, First_Name, Last_Name, Middle_Name, Suffix, Nick_Name, Full_Name, Gender, Birth_Date,  " & _
                        " 	  Birth_Place, Birth_Country, Nationality, Resident, Civil_Status, Dependent_No, Cars_Owned,  " & _
                        "     Spouse_FirstName, Spouse_LastName, Spouse_MiddleName, Mother_FirstName, Mother_LastName, Mother_MiddleName,  " & _
                        " 	  Father_FirstName, Father_MiddleName, Father_Last_Name, Father_Suffix, " & _
                        "     Religion, Educational_Attainment, Social_Affiliation, Member_Type, Status, Membership_Date,Last_Name_Prev) " & _
                        "     VALUES  (@Member_ID, @Title, @First_Name, @Last_Name, @Middle_Name, @Suffix, @Nick_Name, @Full_Name, @Gender, @Birth_Date,  " & _
                        " 	  @Birth_Place, @Birth_Country, @Nationality, @Resident, @Civil_Status, @Dependent_No, @Cars_Owned,  " & _
                        "     @Spouse_FirstName, @Spouse_LastName, @Spouse_MiddleName, @Mother_FirstName, @Mother_LastName, @Mother_MiddleName,  " & _
                        " 	  @Father_FirstName, @Father_MiddleName, @Father_Last_Name, @Father_Suffix, " & _
                        "     @Religion, @Educational_Attainment, @Social_Affiliation, @Member_Type, @Status, @Membership_Date,@Last_Name_Prev) "

                dgvMemberMaster.Rows.Add(New String() {
                                       Member_ID.ToString, _
                                       Title.ToString, _
                                        First_Name.ToString, _
                                        Middle_Name.ToString, _
                                        Last_Name.ToString, _
                                       Nick_Name.ToString, _
                                       Full_Name.ToString, _
                                       Last_Name_Prev.ToString, _
                                       Last_Name_Prev.ToString, _
                                       Gender.ToString, _
                                       Birth_Date.ToString, _
                                      Birth_Place.ToString, _
                                       Birth_Country.ToString, _
                                       Nationality.ToString, _
                                       Resident.ToString, _
                                       Civil_Status.ToString, _
                                       Dependent_No.ToString, _
                                       Cars_Owned.ToString, _
                                       Religion.ToString, _
                                       Educational_Attainment.ToString, _
                                       Social_Affiliation.ToString, _
                                       Spouse_FirstName.ToString, _
                                       Spouse_LastName.ToString, _
                                       Spouse_MiddleName.ToString, _
                                       Mother_FirstName.ToString, _
                                       Mother_LastName.ToString, _
                                       Mother_MiddleName.ToString, _
                                       Father_FirstName.ToString, _
                                       Father_MiddleName.ToString, _
                                       Father_Last_Name.ToString, _
                                       Father_Suffix.ToString, _
                                       Member_Type.ToString, _
                                       Status.ToString, _
                                       Membership_Date.ToString})

                ctrN = ctrN + 1
                str = RTrim(objExcel.Range("a" & CStr(ctrN)).Value)
                count += 1
            Loop
            objExcel.Workbooks.Close()
        End If
        SaveMember_upload()
        LoadMember(txtMemID.Text)
    End Sub
    Private Function RecordExist(ByVal code As String) As Boolean
        Dim query As String
        query = " SELECT * from tblMember_Master where Member_ID = '" & code & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False

        End If
    End Function
    Private Sub SaveMember_upload()
        Try
            activityStatus = True
            Dim insertSQL As String
            Dim i As Integer = 0
            For Each row As DataGridViewRow In dgvMemberMaster.Rows
                If Not row.Cells(0).Value Is Nothing Then

                    If Not RecordExist(row.Cells(0).Value.ToString) Then
                        insertSQL = " INSERT INTO tblMember_Master" & _
                         " (   Member_ID, Title, First_Name, Last_Name, Middle_Name, Suffix, Nick_Name, Full_Name,Last_Name_Prev, Gender, Birth_Date,  " & _
                         " 	  Birth_Place, Birth_Country, Nationality, Resident, Civil_Status, Dependent_No, Cars_Owned,  " & _
                         "     Spouse_FirstName, Spouse_LastName, Spouse_MiddleName, Mother_FirstName, Mother_LastName, Mother_MiddleName,  " & _
                         " 	  Father_FirstName, Father_MiddleName, Father_Last_Name, Father_Suffix, " & _
                         "     Religion, Educational_Attainment, Social_Affiliation, Member_Type, Status, Membership_Date) " & _
                         " VALUES " & _
                         " (   @Member_ID, @Title, @First_Name, @Last_Name, @Middle_Name, @Suffix, @Nick_Name, @Full_Name, @Last_Name_Prev, @Gender, @Birth_Date,  " & _
                         " 	  @Birth_Place, @Birth_Country, @Nationality, @Resident, @Civil_Status, @Dependent_No, @Cars_Owned,  " & _
                         "     @Spouse_FirstName, @Spouse_LastName, @Spouse_MiddleName, @Mother_FirstName, @Mother_LastName, @Mother_MiddleName,  " & _
                         " 	  @Father_FirstName, @Father_MiddleName, @Father_Last_Name, @Father_Suffix, " & _
                         "     @Religion, @Educational_Attainment, @Social_Affiliation, @Member_Type, @Status, @Membership_Date) "
                        SQL.FlushParams()
                        SQL.AddParam("@Member_ID", row.Cells(0).Value.ToString)
                        SQL.AddParam("@Title", row.Cells(1).Value.ToString)
                        SQL.AddParam("@First_Name", row.Cells(2).Value.ToString)
                        SQL.AddParam("@Middle_Name", row.Cells(3).Value.ToString)
                        SQL.AddParam("@Last_Name", row.Cells(4).Value.ToString)
                        SQL.AddParam("@Suffix", row.Cells(5).Value.ToString)
                        SQL.AddParam("@Nick_Name", row.Cells(6).Value.ToString)
                        SQL.AddParam("@Full_Name", row.Cells(7).Value.ToString)
                        SQL.AddParam("@Last_Name_Prev", row.Cells(8).Value.ToString)
                        SQL.AddParam("@Gender", row.Cells(9).Value.ToString)
                        SQL.AddParam("@Birth_Date", row.Cells(10).Value)
                        SQL.AddParam("@Birth_Place", row.Cells(11).Value.ToString)
                        SQL.AddParam("@Birth_Country", row.Cells(12).Value.ToString)
                        SQL.AddParam("@Nationality", row.Cells(13).Value.ToString)
                        SQL.AddParam("@Resident", row.Cells(14).Value.ToString)
                        SQL.AddParam("@Civil_Status", row.Cells(15).Value.ToString)
                        SQL.AddParam("@Dependent_No", row.Cells(16).Value)
                        SQL.AddParam("@Cars_Owned", row.Cells(17).Value)
                        SQL.AddParam("@Religion", row.Cells(18).Value.ToString)
                        SQL.AddParam("@Educational_Attainment", row.Cells(19).Value.ToString)
                        SQL.AddParam("@Social_Affiliation", row.Cells(20).Value.ToString)
                        SQL.AddParam("@Spouse_FirstName", row.Cells(21).Value.ToString)
                        SQL.AddParam("@Spouse_LastName", row.Cells(22).Value.ToString)
                        SQL.AddParam("@Spouse_MiddleName", row.Cells(23).Value.ToString)
                        SQL.AddParam("@Mother_FirstName", row.Cells(24).Value.ToString)
                        SQL.AddParam("@Mother_LastName", row.Cells(25).Value.ToString)
                        SQL.AddParam("@Mother_MiddleName", row.Cells(26).Value.ToString)
                        SQL.AddParam("@Father_FirstName", row.Cells(27).Value.ToString)
                        SQL.AddParam("@Father_MiddleName", row.Cells(28).Value.ToString)
                        SQL.AddParam("@Father_Last_Name", row.Cells(29).Value.ToString)
                        SQL.AddParam("@Father_Suffix", row.Cells(30).Value.ToString)
                        SQL.AddParam("@Member_Type", row.Cells(31).Value.ToString)
                        SQL.AddParam("@Status", row.Cells(32).Value.ToString)
                        SQL.AddParam("@Membership_Date", row.Cells(33).Value)

                        SQL.ExecNonQuery(insertSQL)
                    Else
                        MsgBox("Duplicated Member Code", MsgBoxStyle.Exclamation)
                        i -= 1
                    End If
                    i += 1
                End If
            Next
            If i > 0 Then
                MessageBox.Show("Added Successfully!")
            End If
        Catch ex As System.Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "Member", UserID, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

End Class