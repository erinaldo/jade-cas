Public Class frmLoan_ChargesRangeDef
    Dim chargeName As String

    Public Overloads Function ShowDialog(ByVal Type As String) As Boolean
        chargeName = Type
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmLoan_ChargesRangeDef_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
  
End Class