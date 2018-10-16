Public Class frmUserChange
    Dim SQL As New SQLControl

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim query As String
            If txtOldPass.Text = "" Or txtNewPass.Text = "" Or txtConfirm.Text = "" Then
                msgRequired()
                RequireField(txtOldPass)
                RequireField(txtNewPass)
                RequireField(txtConfirm)
            ElseIf txtNewPass.Text <> txtConfirm.Text Then
                MsgBox("Password confirmation doesn't match!", MsgBoxStyle.Exclamation)
            ElseIf txtNewPass.Text.Length < 6 Then
                MsgBox("Password with less than 6 character is not acceptable, it is considered a weak password.", MsgBoxStyle.Exclamation)
            Else
                query = " UPDATE  tblUser" & _
                        " SET     Password = @Password,  FirstLogin = 0  " & _
                        " WHERE   UserID = @UserID  "
                SQL.FlushParams()
                SQL.AddParam("@UserID", lblUserID.Text)
                SQL.AddParam("@Password", txtNewPass.Text)
                SQL.ExecNonQuery(query)
                MsgBox("Password changed successfully!", MsgBoxStyle.Information)
                Me.Close()
                Me.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class