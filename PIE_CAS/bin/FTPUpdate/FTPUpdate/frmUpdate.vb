Public Class frmUpdate
    Dim a As Integer = 0
    Private Sub frmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CloseEVO()
            Timer1.Start()
        Catch
        End Try
    End Sub

    Private Sub CloseEVO()
        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "jade" Then
                prog.Kill()
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        a += 1
        If a = 1 Then
            Timer1.Stop()
            Dim App_Path As String
            App_Path = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
            Dim FileToDelete As String = App_Path & "\jade.exe"
            If My.Computer.FileSystem.FileExists(FileToDelete) Then
                My.Computer.FileSystem.DeleteFile(FileToDelete)
            End If
            My.Computer.FileSystem.CopyFile("\\192.168.1.119\shared folder\Live\JADE\jade.exe", App_Path & "\jade.exe")

            System.Diagnostics.Process.Start(App_Path & "\jade.exe")
            End
        End If
    End Sub
End Class