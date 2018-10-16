
Public Class frmPosting_Main
    Public BOOK As String = Nothing
    Public JEID As Integer = Nothing
    Public DocID As Integer = Nothing
    Public docnum As String
    Public docutype As String
    Public fromDocdate As String
    Public toDocdate As String

    Public Overloads Function ShowDialog(ByVal docnumber As String, ByVal doctype As String, fromdate As String, todate As String) As Boolean
        docnum = docnumber
        docutype = doctype
        fromDocdate = fromdate
        toDocdate = todate
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmTiralBalance_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        nupYear.Value = Now.Year
        cbMonth.SelectedIndex = Now.Month - 1
    End Sub

    Private Sub BtnSearchOR_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearchOR.Click
        LoadForPosting()
    End Sub

    Private Sub LoadForPosting()
        Try
            Dim query As String
            query = " SELECT	Book, SUM(Debit) AS Debit, SUM(Credit) AS Credit,  " & _
                    " 		    SUM(Debit) - SUM(Credit) AS Variance " & _
                    " FROM	    View_GL " & _
                    " WHERE     AppDate BETWEEN '" & dtpFrom.Value.Date & "' AND '" & dtpTo.Value.Date & "' AND Status ='Saved' " & _
                    " GROUP BY  Book "
            SQL.ReadQuery(query)
            dgvBooks.Rows.Clear()
            If SQL.SQLDR.HasRows Then
                While SQL.SQLDR.Read
                    dgvBooks.Rows.Add(New String() {SQL.SQLDR("Book").ToString, _
                                                   CDec(SQL.SQLDR("Debit")).ToString("N2"), _
                                                   CDec(SQL.SQLDR("Credit")).ToString("N2"), _
                                                   CDec(SQL.SQLDR("Variance")).ToString("N2"), _
                                                         ">>"})
                End While
            Else
                MsgBox("No Records for posting", MsgBoxStyle.Exclamation)
            End If

            TotalRR()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TotalRR()
        Try
            'debit compute & print in textbox
            Dim a As Double = 0
            For i As Integer = 0 To dgvBooks.Rows.Count - 1

                If Val(dgvBooks.Item(chDebit.Index, i).Value) <> 0 Then
                    a = a + Double.Parse(dgvBooks.Item(chDebit.Index, i).Value).ToString("N2")
                End If
            Next
            txtTotalDebit.Text = a.ToString("N2")

            'credit compute & print in textbox
            Dim b As Double = 0

            For i As Integer = 0 To dgvBooks.Rows.Count - 1
                If Val(dgvBooks.Item(chCredit.Index, i).Value) <> 0 Then
                    b = b + Double.Parse(dgvBooks.Item(chCredit.Index, i).Value).ToString("N2")
                End If
            Next
            txtTotalCredit.Text = b.ToString("N2")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub dgvCVRR_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBooks.CellContentClick
        Dim rowIndex As Integer = dgvBooks.CurrentCell.RowIndex
        Dim colIndex As Integer = dgvBooks.CurrentCell.ColumnIndex
        Dim docnumber As String = dgvBooks.Item(3, rowIndex).Value
        Dim doctype As String = dgvBooks.Item(3, rowIndex).Value
        Dim f As New frmBatchPosting 'LoadingScreen 'ParentMenu '
        f.ShowDialog(dgvBooks.Item(0, rowIndex).Value, dtpFrom.Value, dtpTo.Value)
        f.Dispose()
        LoadForPosting()
    End Sub

    Private Sub LoadPeriod()
        dtpFrom.Value = (cbMonth.SelectedIndex + 1).ToString & "-1-" & nupYear.Value.ToString
        dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate((cbMonth.SelectedIndex + 1).ToString & "-1-" & nupYear.Value.ToString)))
    End Sub

    Private Sub nupYear_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nupYear.ValueChanged, cbMonth.SelectedIndexChanged
        If cbMonth.SelectedIndex <> -1 Then
            LoadPeriod()
        End If
    End Sub

End Class