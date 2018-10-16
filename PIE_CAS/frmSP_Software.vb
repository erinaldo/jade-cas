Public Class frmSP_Software
    Dim SPCode As String
    Dim moduleID As String = "SP"
    Dim FileName As String

    Private Sub tsbNew_Click(sender As Object, e As EventArgs) Handles tsbNew.Click
        If Not AllowAccess("SP_MNT") Then
            msgRestricted()
        Else
            cbSize.SelectedIndex = -1
            cbType.SelectedIndex = -1
            txtSC.Clear()
            txtName.Clear()
            txtPrice.Clear()
            txtDescription.Clear()
            LoadSize()
            LoadType()
            LoadSoftware()

            SPCode = ""

            ' Toolstrip Buttons
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True


            EnableControl(True)
        End If
    End Sub

    Private Sub SaveWHSE()
        Try
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblSP_Software(SoftwareCode, Description, Price, Size, Type) " & _
                        " VALUES(@SoftwareCode, @Description, @Price, @Size, @Type)"

            SQL.FlushParams()
            SQL.AddParam("@SoftwareCode", txtSC.Text)
            SQL.AddParam("@Description", txtName.Text)
            SQL.AddParam("@Price", txtName.Text)
            SQL.AddParam("@Size", txtName.Text)
            SQL.AddParam("@Type", txtName.Text)
            If SQL.ExecNonQuery(insertSQL) = -1 Then
                MsgBox("This is duplidate data!", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Added Successfully!", MsgBoxStyle.Information)
            End If


        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "SoftwareCode", txtSC.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()

        End Try
    End Sub

    Private Sub tsbEdit_Click_1(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("SP_MNT") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True
        End If
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtSC.Enabled = Value
        txtName.Enabled = Value
        txtPrice.Enabled = Value
        cbSize.Enabled = Value
        cbType.Enabled = Value
        txtDescription.Enabled = Value
    End Sub

    Private Sub tsbSave_Click_1(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtSC.Text = "" Then
            Msg("Please enter SoftwareCode!", MsgBoxStyle.Exclamation)
        ElseIf SPCode = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then

                If RecordExist(txtSC.Text) Then
                    Msg("SoftwareCode already in used! Please change SoftwareCode", MsgBoxStyle.Exclamation)
                Else
                    SaveSoftware()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    SPCode = txtSC.Text
                    LoadSoftware()
                End If
            End If
        Else
            ' IF VCECODE IS CHANGED VALIDATE IF NEW CODE EXIST
            Dim Validated As Boolean = True
            If SPCode <> txtSC.Text Then
                If RecordExist(txtSC.Text) Then
                    Validated = False
                Else
                    Validated = True
                End If
            End If

            If Validated Then
                If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdateVCE()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    SPCode = txtSC.Text
                    LoadSoftware()
                End If
            Else
                Msg("New SoftwareCode is already in used! Please change SoftwareCode", MsgBoxStyle.Exclamation)
                txtSC.Text = SPCode
                txtSC.SelectAll()
            End If

        End If
    End Sub
    Private Function RecordExist(ByVal Record As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblSP_Software WHERE SoftwareCode ='" & Record & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SaveSoftware()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                         " tblSP_Software(SoftwareCode, SoftwareName, Description, Price, Size, Type) " & _
                         " VALUES(@SoftwareCode, @SoftwareName, @Description, @Price, @Size, @Type )"
            SQL.FlushParams()
            SQL.AddParam("@SoftwareCode", txtSC.Text)
            SQL.AddParam("@SoftwareName", txtName.Text)
            SQL.AddParam("@Price", CDec(txtPrice.Text))
            SQL.AddParam("@Size", cbSize.Text)
            SQL.AddParam("@Type", cbType.Text)
            SQL.AddParam("@Description", txtDescription.Text)

            SQL.ExecNonQuery(insertSQL)
        Catch ex As System.Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "SoftwareCode", txtSC.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub LoadSoftware()
        Dim query As String
        query = " SELECT   SoftwareCode, SoftwareName, Description, Price, Size, Type  " & _
                 " FROM    tblSP_Software"
        SQL.ReadQuery(query)
        ListView1.Items.Clear()
        While SQL.SQLDR.Read
            ListView1.Items.Add(SQL.SQLDR("SoftwareCode").ToString)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(SQL.SQLDR("SoftwareName").ToString)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(CDec(SQL.SQLDR("Price").ToString).ToString("N2"))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(SQL.SQLDR("Size").ToString)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(SQL.SQLDR("Type").ToString)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(SQL.SQLDR("Description").ToString)
        End While
        ' Toolstrip Buttons
        tsbNew.Enabled = True
        tsbEdit.Enabled = True
        tsbSave.Enabled = False
        tsbDelete.Enabled = True
        EnableControl(False)
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If Not AllowAccess("SQ_DEL") Then
            msgRestricted()
        Else
            If txtSC.Text <> "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " DELETE FROM tblSP_Software WHERE SoftwareCode = @SoftwareCode "
                        SQL.FlushParams()
                        SQL.AddParam("@SoftwareCode", txtSC.Text)
                        SQL.ExecNonQuery(deleteSQL)
                        Msg("Record deleted successfully", MsgBoxStyle.Information)
                        LoadSoftware()
                        tsbNew.PerformClick()

                        tsbNew.Enabled = True
                        tsbEdit.Enabled = False
                        tsbSave.Enabled = False
                        tsbDelete.Enabled = True

                        EnableControl(False)
                    Catch ex As System.Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
                    Finally
                        RecordActivity(UserID, moduleID, Me.Name.ToString, "DELETE", "SoftwareCode", txtSC.Text, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub
    Private Sub UpdateVCE()
        Try
            activityStatus = True
            Dim updateSQL As String
            updateSQL = " UPDATE   tblSP_Software " & _
                         " SET     SoftwareName = @SoftwareName,  Description = @Description, Price = @Price, Size = @Size, Type = @Type " & _
                         " WHERE   SoftwareCode = @SoftwareCode "
            SQL.FlushParams()
            SQL.AddParam("@SoftwareCode", SPCode)
            SQL.AddParam("@SoftwareName", txtName.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@Price", CDec(txtPrice.Text))
            SQL.AddParam("@Size", cbSize.Text)
            SQL.AddParam("@Type", cbType.Text)

            SQL.ExecNonQuery(updateSQL)
        Catch ex As System.Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "SoftwareCode", txtSC.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub frmSP_Software_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadType()
        LoadSize()
        LoadSoftware()
        tsbNew.Enabled = True
        tsbEdit.Enabled = True
        tsbSave.Enabled = False
        tsbDelete.Enabled = False
        tsbClose.Enabled = False
    End Sub

    Private Sub LoadType()
        Dim query As String
        query = " SELECT DISTINCT Type FROM tblSP_Software "
        SQL.ReadQuery(query)
        cbType.Items.Clear()
        While SQL.SQLDR.Read
            cbType.Items.Add(SQL.SQLDR("Type").ToString)
        End While
    End Sub

    Private Sub LoadSize()
        Dim query As String
        query = " SELECT DISTINCT Size FROM tblSP_Software "
        SQL.ReadQuery(query)
        cbSize.Items.Clear()
        While SQL.SQLDR.Read
            cbSize.Items.Add(SQL.SQLDR("Size").ToString)
        End While
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            txtSC.Text = ListView1.SelectedItems(0).SubItems(0).Text
            txtName.Text = ListView1.SelectedItems(0).SubItems(1).Text
            txtPrice.Text = ListView1.SelectedItems(0).SubItems(2).Text
            cbSize.Text = ListView1.SelectedItems(0).SubItems(3).Text
            cbType.Text = ListView1.SelectedItems(0).SubItems(4).Text
            txtDescription.Text = ListView1.SelectedItems(0).SubItems(5).Text
            SPCode = txtSC.Text

        End If

    End Sub

    Private Sub tsbCancel_Click_1(sender As Object, e As EventArgs)
        If Not AllowAccess("SQ_DEL") Then
            msgRestricted()
        Else
            If txtSC.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblSP_Software SET Status ='Cancelled' WHERE SoftwareCode = @SoftwareCode "
                        SQL.FlushParams()
                        SPCode = txtSC.Text
                        SQL.AddParam("@SoftwareCode", txtSC.Text)
                        SQL.ExecNonQuery(deleteSQL)
                        Msg("Record cancelled successfully", MsgBoxStyle.Information)

                        tsbNew.Enabled = True
                        tsbEdit.Enabled = False
                        tsbSave.Enabled = False



                        EnableControl(False)

                        SPCode = txtSC.Text
                        LoadSoftware()
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
                    Finally
                        RecordActivity(UserID, moduleID, Me.Name.ToString, "CANCEL", "SoftwareCode", SPCode, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If SPCode = "" Then
            tsbNew.PerformClick()
            EnableControl(False)
            tsbEdit.Enabled = True
            tsbDelete.Enabled = False

        Else
            LoadSoftware()
            tsbEdit.Enabled = True
            tsbDelete.Enabled = True

        End If

        tsbNew.Enabled = True
        tsbSave.Enabled = False

    End Sub

End Class