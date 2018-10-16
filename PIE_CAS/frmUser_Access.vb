Public Class frmUser_Access
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "UAR"
    Public UsersID As Integer
    Public ModID As String

    Private Sub frmUser_Access_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadModules()
    End Sub

    Private Sub LoadModules()
        Dim query As String
        query = "   SELECT		AccessType, tblModuleAccess.FunctionID   " & _
                "   FROM	    tblModuleAccess  LEFT JOIN tblUser_Access    " & _
                "   ON			tblUser_Access.FunctionID = tblModuleAccess.FunctionID    " & _
                "   AND	        tblUser_Access.UserID = '" & UsersID & "'  " & _
                "   WHERE		ModuleID ='" & ModID & "' AND UseriD  IS NULL  "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            lvAccess.Items.Add(SQL.SQLDR("AccessType").ToString)
            lvAccess.Items(lvAccess.Items.Count - 1).SubItems.Add(SQL.SQLDR("FunctionID").ToString)
        End While
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If lvAccess.CheckedItems.Count > 0 Then
            If MsgBox("Saving Access Rights" & vbNewLine & "Click Yes to confirm!", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                For Each item As ListViewItem In lvAccess.CheckedItems
                    Try
                        activityStatus = True
                        Dim insertSQL As String
                        insertSQL = " INSERT INTO " & _
                                    " tblUser_Access(UserID, FunctionID, BusinessCode, BranchCode, WhoCreated)  " & _
                                    " VALUES(@UserID, @FunctionID, @BusinessCode, @BranchCode, @WhoCreated)"
                        SQL.FlushParams()
                        SQL.AddParam("@UserID", UsersID)
                        SQL.AddParam("@FunctionID", item.SubItems(chID.Index).Text)
                        SQL.AddParam("@BusinessCode", BusinessType)
                        SQL.AddParam("@BranchCode", BranchCode)
                        SQL.AddParam("@WhoCreated", UserID)
                        SQL.ExecNonQuery(insertSQL)
                    Catch ex As Exception
                        activityStatus = False
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "FunctionID", item.SubItems(chID.Index).Text, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                    
                Next
                Msg("Access Rights Added Scuccessfully", MsgBoxStyle.Information)
                Me.Close()
            End If
        End If
    End Sub
End Class