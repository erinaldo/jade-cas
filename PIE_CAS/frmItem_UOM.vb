Public Class frmItem_UOM
    Dim moduleID As String = "UOM"

    Private Sub frmItem_UOM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        LoadUOM()
        ' Control Buttons
        btnNew.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub LoadUOM()
        Dim query As String
        query = "  SELECT UnitCode, Description, BaseUnit FROM tblUOM WHERE Status ='Active' "
        SQL.ReadQuery(query)
        dgvUOM.Rows.Clear()
        While SQL.SQLDR.Read
            dgvUOM.Rows.Add({SQL.SQLDR("UnitCode").ToString, SQL.SQLDR("Description").ToString, SQL.SQLDR("BaseUnit").ToString})
        End While
        EnableControl(False)

    End Sub

    Private Sub dgvUOM_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUOM.CellClick
        If dgvUOM.SelectedRows.Count = 1 Then
            txtCode.Text = dgvUOM.SelectedRows(0).Cells(chCode.Index).Value.ToString
            txtDescription.Text = dgvUOM.SelectedRows(0).Cells(chDesc.Index).Value.ToString
            chkBase.Checked = dgvUOM.SelectedRows(0).Cells(chBase.Index).Value.ToString
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnNew.Text = "New"
            btnEdit.Text = "Edit"
            btnDelete.Text = "Delete"
        Else
            ClearText()
        End If
    End Sub

    Private Sub ClearText()
        txtCode.Clear()
        txtDescription.Clear()
        chkBase.Checked = False
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        txtCode.Enabled = Value
        txtDescription.Enabled = Value
        chkBase.Enabled = Value
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "New" Then
            ClearText()
            EnableControl(True)
            If dgvUOM.SelectedRows.Count = 1 Then
                dgvUOM.SelectedRows(0).Selected = False
            End If
            txtCode.Select()
            ' Control Buttons
            btnNew.Enabled = True
            btnEdit.Enabled = False
            btnDelete.Enabled = True
            btnNew.Text = "Save"
            btnDelete.Text = "Cancel"
        ElseIf btnNew.Text = "Save" Then
            If MsgBox("Saving New Item, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveUOM()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                LoadUOM()

                ' Control Buttons
                btnNew.Text = "New"
                btnEdit.Text = "Edit"
                btnDelete.Text = "Delete"
                btnEdit.Enabled = True
            End If
        End If
        
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            If txtCode.Text <> "" Then
                EnableControl(True)
                btnEdit.Text = "Update"
                btnDelete.Text = "Cancel"
                btnNew.Text = "New"
            End If
        Else
            If MsgBox("Updating Item Information, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                UpdateUOM()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                LoadUOM()

                ' Control Buttons
                btnEdit.Text = "Edit"
                btnDelete.Text = "Delete"
            End If
        End If

    End Sub


    Private Sub SaveUOM()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = "  INSERT INTO " & _
                        "  tblUOM(UnitCode, Description, BaseUnit, WhoCreated) " & _
                        "  VALUES(@UnitCode, @Description, @BaseUnit, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@UnitCode", txtCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@BaseUnit", chkBase.Checked)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "INSERT", "UnitCode", txtCode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateUOM()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " UPDATE tblUOM " & _
                        " SET    Description = @Description, BaseUnit = @BaseUnit, " & _
                        "        DateModified = GETDATE(), WhoModified = @WhoModified" & _
                        " WHERE  UnitCode = @UnitCode "
            SQL.FlushParams()
            SQL.AddParam("@UnitCode", txtCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@BaseUnit", chkBase.Checked)
            SQL.AddParam("@WhoModified", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            RecordActivity(UserID, moduleID, Me.Name.ToString, "UPDATE", "UnitCode", txtCode.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If btnDelete.Text = "Cancel" Then
            If txtCode.Text = "" Then
                btnNew.Text = "New"
                btnEdit.Enabled = False
                btnEdit.Text = "Edit"
                btnDelete.Text = "Delete"
                EnableControl(False)
            Else
                btnNew.Text = "New"
                btnEdit.Enabled = True
                btnEdit.Text = "Edit"
                btnDelete.Text = "Delete"
                EnableControl(False)
            End If
        Else
            If txtCode.Text <> "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " DELETE FROM tblUOM WHERE UnitCode = @UnitCode "
                        SQL.FlushParams()
                        SQL.AddParam("@UnitCode", txtCode.Text)
                        SQL.ExecNonQuery(deleteSQL)

                        Msg("Record deleted successfully", MsgBoxStyle.Information)
                        btnNew.Text = "New"
                        btnEdit.Enabled = False
                        btnEdit.Text = "Edit"
                        btnDelete.Text = "Delete"
                        btnDelete.Enabled = False
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
                    Finally
                        RecordActivity(UserID, moduleID, Me.Name.ToString, "DELETE", "UnitCode", txtCode.Text, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub
End Class