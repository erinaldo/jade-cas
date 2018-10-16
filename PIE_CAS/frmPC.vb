Public Class frmPC
    Dim Code As String
    Dim moduleID As String = "PC"

    Private Sub frmCostCenter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub loadData()
        LoadRecords() ' LOAD DATAGRIDVIEW DATA
        loadGroupField("G1", lblG1, cbG1)  ' LOAD GROUP 1 LABEL AND COMBOBOX
        loadGroupField("G2", lblG2, cbG2)  ' LOAD GROUP 2 LABEL AND COMBOBOX
        loadGroupField("G3", lblG3, cbG3)  ' LOAD GROUP 3 LABEL AND COMBOBOX
        loadGroupField("G4", lblG4, cbG4)  ' LOAD GROUP 4 LABEL AND COMBOBOX
        loadGroupField("G5", lblG5, cbG5)  ' LOAD GROUP 5 LABEL AND COMBOBOX

        ClearText()
        tsbNew.Enabled = True
        tsbEdit.Enabled = False
        tsbSave.Enabled = False
        tsbDelete.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
        EnableControl(False)
    End Sub

    Private Sub loadGroupField(ByVal GroupID As String, lblName As Label, cbName As ComboBox)
        lblName.Text = LoadGroupName("Profit Center", GroupID)
        If lblName.Text = "" Then
            lblName.Visible = False
            cbName.Visible = False
        Else
            lblName.Visible = True
            cbName.Visible = True
            LoadGroupData(GroupID, cbName)
        End If
    End Sub

    Private Sub LoadGroupData(ByVal GroupID As String, cbName As ComboBox)
        Dim query As String
        query = " SELECT DISTINCT ISNULL(" & GroupID & ",'') AS GroupData FROM tblPC WHERE  ISNULL(" & GroupID & ",'') <> ''"
        SQL.ReadQuery(query)
        cbName.Items.Clear()
        While SQL.SQLDR.Read
            cbName.Items.Add(SQL.SQLDR("GroupData").ToString)
        End While
    End Sub

    Private Sub LoadRecords() ' LOAD COST CENTER TABLE
        Dim dt As DataTable
        dt = LoadGroup("Profit Center")
        If Not dt Is Nothing Then
            Dim groupName As String = ""
            For Each row As DataRow In dt.Rows
                groupName = groupName & ", " & row(0).ToString & " AS '" & row(1).ToString & "' "
            Next
            Dim query As String
            query = " SELECT Code AS oldCode, Code, Description " & groupName & _
                    " FROM tblPC WHERE Status ='Active' "
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                dgvData.DataSource = SQL.SQLDS.Tables(0)
                dgvData.Columns(0).Visible = False
                dgvData.Columns(1).Width = 60
                dgvData.Columns(2).Width = 300
            Else
                dgvData.DataSource = Nothing
            End If
            dgvData.Refresh()
        End If
    End Sub


    Private Function LoadGroup(ByVal Type As String) As DataTable
        ' LOAD GROUP NAME
        Dim dt As New DataTable
        Dim query As String
        query = " SELECT GroupID, Description FROM tblGroup WHERE Type ='" & Type & "' AND Status ='Active' "
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            Return SQL.SQLDS.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    Private Function LoadGroupName(ByVal Type As String, GroupCode As String) As String
        Dim query As String
        query = " SELECT GroupID, Description FROM tblGroup WHERE Type ='" & Type & "' AND GroupID = '" & GroupCode & "' AND Status ='Active' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Description")
        Else
            Return ""
        End If
    End Function

    Private Sub dgvCC_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick
        LoadRecord()
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("PC_ADD") Then
            msgRestricted()
        Else
            Code = ""
            ClearText()
            ' Toolstrip Buttons
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True


            EnableControl(True)
        End If
    End Sub

    Private Sub ClearText()
        txtCode.Clear()
        txtDescription.Clear()
        txtOldCode.Clear()
        cbG1.Text = ""
        cbG2.Text = ""
        cbG3.Text = ""
        cbG4.Text = ""
        cbG5.Text = ""
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtCode.Enabled = Value
        txtDescription.Enabled = Value
        cbG1.Enabled = Value
        cbG2.Enabled = Value
        cbG3.Enabled = Value
        cbG4.Enabled = Value
        cbG5.Enabled = Value
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If Validated() Then
            If Code = "" Then
                If MsgBox("Saving New Profit Center, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    SaveRecord()
                    Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                    loadData()
                End If
            Else
                If MsgBox("Updating Profit Center, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    UpdateRecord()
                    Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                    loadData()
                End If
            End If
        End If
    End Sub

    Private Sub SaveRecord()
        Try
            activityStatus = True
            ' INSERT QUERY
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblPC(Code, Description, G1, G2, G3, G4, G5, WhoCreated) " & _
                        " VALUES(@Code, @Description, @G1, @G2, @G3, @G4, @G5, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@Code", txtCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@G1", cbG1.Text)
            SQL.AddParam("@G2", cbG2.Text)
            SQL.AddParam("@G3", cbG3.Text)
            SQL.AddParam("@G4", cbG4.Text)
            SQL.AddParam("@G5", cbG5.Text)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "Code", txtCode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateRecord()
        Try
            activityStatus = True
            ' INSERT QUERY
            Dim updateSQL As String
            updateSQL = " UPDATE tblPC " & _
                        " SET    Code = @Code, Description = @Description, G1 = @G1, G2 = @G2, G3 = @G3, G4 = @G4, G5 = @G5, WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE  Code = @OldCode "
            SQL.FlushParams()
            SQL.AddParam("@Code", txtCode.Text)
            SQL.AddParam("@OldCode", txtOldCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@G1", cbG1.Text)
            SQL.AddParam("@G2", cbG2.Text)
            SQL.AddParam("@G3", cbG3.Text)
            SQL.AddParam("@G4", cbG4.Text)
            SQL.AddParam("@G5", cbG5.Text)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "Code", txtCode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Shadows Function Validated() As Boolean
        If txtCode.Text = "" Then
            Msg("Please enter profit center code!", MsgBoxStyle.Exclamation)
            Return False
        ElseIf txtDescription.Text = "" Then
            Msg("Please enter profit center name!", MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub tsbClose_Click(sender As System.Object, e As System.EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If Code = "" Then
            tsbNew.PerformClick()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbDelete.Enabled = False
        Else
            LoadRecord()
            tsbEdit.Enabled = True
            tsbDelete.Enabled = True
        End If
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
    End Sub

    Private Sub LoadRecord()
        If dgvData.SelectedRows.Count = 1 Then
            txtOldCode.Text = dgvData.SelectedRows(0).Cells(0).Value.ToString
            txtCode.Text = dgvData.SelectedRows(0).Cells(1).Value.ToString
            Code = dgvData.SelectedRows(0).Cells(1).Value.ToString
            txtDescription.Text = dgvData.SelectedRows(0).Cells(2).Value.ToString
            If cbG1.Visible Then cbG1.Text = dgvData.SelectedRows(0).Cells(3).Value.ToString
            If cbG2.Visible Then cbG2.Text = dgvData.SelectedRows(0).Cells(4).Value.ToString
            If cbG3.Visible Then cbG3.Text = dgvData.SelectedRows(0).Cells(5).Value.ToString
            If cbG4.Visible Then cbG4.Text = dgvData.SelectedRows(0).Cells(6).Value.ToString
            If cbG5.Visible Then cbG5.Text = dgvData.SelectedRows(0).Cells(7).Value.ToString
            tsbNew.Enabled = True
            tsbEdit.Enabled = True
            tsbSave.Enabled = False
            tsbDelete.Enabled = True
            tsbClose.Enabled = False
            tsbExit.Enabled = True
            EnableControl(False)
        End If
    End Sub

    Private Sub frmCostCenter_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.S Then
                If tsbSave.Enabled = True Then tsbSave.PerformClick()
            ElseIf e.KeyCode = Keys.N Then
                If tsbNew.Enabled = True Then tsbNew.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                If tsbEdit.Enabled = True Then tsbEdit.PerformClick()
            ElseIf e.KeyCode = Keys.D Then
                If tsbDelete.Enabled = True Then tsbDelete.PerformClick()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbClose.Enabled = True Then
                    tsbClose.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("PC_EDIT") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbDelete.Enabled = False
            tsbClose.Enabled = True
            tsbExit.Enabled = False
        End If
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click
        If Not AllowAccess("PC_DEL") Then
            msgRestricted()
        Else
            If txtCode.Text <> "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim updateSQL As String
                        updateSQL = " UPDATE tblPC SET Status ='Inactive', DateModified = GETDATE(), WhoModified = @WhoModified WHERE Code = @Code "
                        SQL.FlushParams()
                        Code = txtCode.Text
                        SQL.AddParam("@Code", Code)
                        SQL.AddParam("@WhoModified", UserID)
                        SQL.ExecNonQuery(updateSQL)
                        Msg("Record deleted successfully", MsgBoxStyle.Information)

                        loadData()
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
                    Finally
                        RecordActivity(UserID, moduleID, Me.Name.ToString, "DELETE", "Code", CCCode, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Function CCCode() As String
        Throw New NotImplementedException
    End Function

End Class