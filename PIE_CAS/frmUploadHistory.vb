
Public Class frmUploadHistory


    Private Sub LoadUploaded(ByVal Report As String)
        Dim query As String
        query = " SELECT    RecordID, Branch, Period, Rowcounter, tblUploadHistory.DateCreated, UserName  " & _
                " FROM      tblUploadHistory  LEFT JOIN tblUser " & _
                " ON        tblUploadHistory.WhoCreated = tbluser.UserID  " & _
                " WHERE     ReportType = @ReportType AND tblUploadHistory.Status ='Active' "
        SQL.FlushParams()
        SQL.AddParam("@ReportType", Report)
        SQL.ReadQuery(query)
        dgvSummary.Rows.Clear()
        While SQL.SQLDR.Read
            dgvSummary.Rows.Add(SQL.SQLDR("RecordID").ToString, SQL.SQLDR("Period").ToString, SQL.SQLDR("Branch").ToString, SQL.SQLDR("Rowcounter").ToString, SQL.SQLDR("DateCreated").ToString, SQL.SQLDR("UserName").ToString)
        End While
        SQL.FlushParams()
    End Sub

    Private Sub cbReport_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbReport.SelectedIndexChanged
        If cbReport.SelectedIndex <> -1 Then
            LoadUploaded(cbReport.SelectedItem)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If dgvSummary.SelectedRows.Count = 1 Then
            If MsgBox("Are you sure you want to delete this upload records?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Select Case cbReport.SelectedItem
                    Case "CASH VOUCHER- EXPENSE REPORT"
                        Dim deleteSQL, updateSQL As String
                        deleteSQL = " DELETE FROM tblJE_Header " & _
                                    " WHERE RefType ='CV' AND RefTransID IN (SELECT TransID FROM tblCV WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "')"
                        SQL.ExecNonQuery(deleteSQL)
                        deleteSQL = " DELETE FROM tblCV WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(deleteSQL)
                        updateSQL = " UPDATE tblUploadHistory " & _
                                    " SET    Status ='Deleted', WhoModified = '" & UserID & "' , DateModified = GETDATE() " & _
                                    " WHERE  RecordID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(updateSQL)
                        MsgBox("Record Deleted successfully!", MsgBoxStyle.Information)
                    Case "CHECK VOUCHER-  EXPENSE REPORT"
                        Dim deleteSQL, updateSQL As String
                        deleteSQL = " DELETE FROM tblJE_Header " & _
                                    " WHERE RefType ='CV' AND RefTransID IN (SELECT TransID FROM tblCV WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "')"
                        SQL.ExecNonQuery(deleteSQL)
                        deleteSQL = " DELETE FROM tblCV WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(deleteSQL)
                        updateSQL = " UPDATE tblUploadHistory " & _
                                    " SET    Status ='Deleted', WhoModified = '" & UserID & "' , DateModified = GETDATE() " & _
                                    " WHERE  RecordID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(updateSQL)
                        MsgBox("Record Deleted successfully!", MsgBoxStyle.Information)
                    Case "Sales Book Journal Report"
                        Dim deleteSQL, updateSQL As String
                        deleteSQL = " DELETE FROM tblJE_Header " & _
                                    " WHERE RefType ='SI' AND RefTransID IN (SELECT TransID FROM tblSI WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "')"
                        SQL.ExecNonQuery(deleteSQL)
                        deleteSQL = " DELETE FROM tblSI WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(deleteSQL)
                        updateSQL = " UPDATE tblUploadHistory " & _
                                    " SET    Status ='Deleted', WhoModified = '" & UserID & "' , DateModified = GETDATE() " & _
                                    " WHERE  RecordID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(updateSQL)
                        MsgBox("Record Deleted successfully!", MsgBoxStyle.Information)
                    Case "Cash Receipts Book Summary 2"
                        Dim deleteSQL, updateSQL As String
                        deleteSQL = " DELETE FROM tblJE_Header " & _
                                    " WHERE Book ='Cash Receipts' AND RefTransID IN (SELECT TransID FROM tblCollection WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "')"
                        SQL.ExecNonQuery(deleteSQL)
                        deleteSQL = " DELETE FROM tblCollection WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(deleteSQL)
                        updateSQL = " UPDATE tblUploadHistory " & _
                                    " SET    Status ='Deleted', WhoModified = '" & UserID & "' , DateModified = GETDATE() " & _
                                    " WHERE  RecordID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(updateSQL)
                        MsgBox("Record Deleted successfully!", MsgBoxStyle.Information)
                    Case "ACCOUNTS PAYABLE   REGISTER"
                        Dim deleteSQL, updateSQL As String
                        deleteSQL = " DELETE FROM tblJE_Header " & _
                                    " WHERE Book ='Purchases' AND RefTransID IN (SELECT TransID FROM tblAPV WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "')"
                        SQL.ExecNonQuery(deleteSQL)
                        deleteSQL = " DELETE FROM tblAPV WHERE UploadID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(deleteSQL)
                        updateSQL = " UPDATE tblUploadHistory " & _
                                    " SET    Status ='Deleted', WhoModified = '" & UserID & "' , DateModified = GETDATE() " & _
                                    " WHERE  RecordID = '" & dgvSummary.SelectedRows(0).Cells(0).Value & "'"
                        SQL.ExecNonQuery(updateSQL)
                        MsgBox("Record Deleted successfully!", MsgBoxStyle.Information)
                End Select
            End If
            LoadUploaded(cbReport.SelectedItem)
        End If

    End Sub
End Class

