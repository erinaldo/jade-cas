Imports System.Data.OleDb

Public NotInheritable Class lsJADE
    Inherits MetroFramework.Forms.MetroForm
    Dim a As Integer

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Start()
    End Sub

    Private Sub LoadDatabase()
        frmUserLogin.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        a += 1
        If a = 10 Then
            Timer1.Stop()
            LoadDatabase()
        End If
    End Sub

End Class
