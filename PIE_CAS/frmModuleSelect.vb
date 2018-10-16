Public Class frmModuleSelect
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmModuleSelect_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmModuleSelect_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmModuleSelect_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As System.EventArgs) Handles Button1.MouseEnter
        Button1.ForeColor = Color.DarkRed
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As System.EventArgs) Handles Button1.MouseLeave
        Button1.ForeColor = Color.White
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles picJade.Click
        Me.Dispose()
        lsJADE.Show()
    End Sub
End Class