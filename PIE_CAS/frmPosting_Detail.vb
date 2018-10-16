Public Class frmBatchPosting
    Dim Book As String
    Dim fromDate, toDate As Date

    Public Overloads Function ShowDialog(ByVal param_Book As String, param_From As Date, param_To As Date) As Boolean
        Book = param_Book
        fromDate = param_From
        toDate = param_To
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmTiralBalance_Load(sender As Object, e As System.EventArgs) Handles Me.Load
         LoadTB()
    End Sub

    Private Sub LoadTB()
        Try
            Dim query As String
            query = " SELECT  RefTransID, RefType, TransNo,  SUM(Debit) AS Debit, SUM(Credit) AS Credit, SUM(Debit-Credit) AS Variance " & _
                    " FROM	  View_GL " & _
                    " WHERE   Status ='Saved' AND Book ='" & Book & "' AND AppDate BETWEEN '" & fromDate & "' AND '" & toDate & "' " & _
                    " GROUP BY RefType, RefTransID ,TransNo" & _
                    " ORDER BY RefType, RefTransID ,TransNo"
            SQL.ReadQuery(query)
            dgvPosting.Rows.Clear()
            While SQL.SQLDR.Read
                dgvPosting.Rows.Add(New String() {SQL.SQLDR("RefType").ToString, _
                                                  SQL.SQLDR("RefTransID").ToString, _
                                                  SQL.SQLDR("TransNo").ToString, _
                                                 Format(SQL.SQLDR("Debit"), "#,###,###,###.00").ToString, _
                                                 Format(SQL.SQLDR("Credit"), "#,###,###,###.00").ToString, _
                                                 Format(SQL.SQLDR("Variance"), "#,###,###,###.00").ToString,
                                               ">>"})
            End While
            TotalRR()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TotalRR()
        Try
            'debit compute & print in textbox
            Dim a As Double = 0

            For i As Integer = 0 To dgvPosting.Rows.Count - 1

                If Val(dgvPosting.Item(chDebit.Index, i).Value) <> 0 Then
                    a = a + Double.Parse(dgvPosting.Item(chDebit.Index, i).Value).ToString("N2")
                End If
            Next
            txtTotalDebit.Text = a.ToString("N2")

            'credit compute & print in textbox
            Dim b As Double = 0

            For i As Integer = 0 To dgvPosting.Rows.Count - 1
                If Val(dgvPosting.Item(chCredit.Index, i).Value) <> 0 Then
                    b = b + Double.Parse(dgvPosting.Item(chCredit.Index, i).Value).ToString("N2")
                End If
            Next
            txtTotalCredit.Text = b.ToString("N2")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCVRR_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPosting.CellContentClick
        Dim rowIndex As Integer = dgvPosting.CurrentCell.RowIndex
        Dim colIndex As Integer = dgvPosting.CurrentCell.ColumnIndex
        Dim TransID As Integer
        Try
            If colIndex = chDrilldown.Index Then
                TransID = dgvPosting.Item(chTransID.Index, rowIndex).Value

                Select Case Book
                    Case "Purchases"
                        Dim f As New frmAPV  'LoadingScreen 'ParentMenu '
                        f.ShowDialog(TransID)
                        f.Dispose()
                    Case "Cash Disbursement"
                        Dim f As New frmCV 'LoadingScreen 'ParentMenu '
                        f.ShowDialog(TransID)
                        f.Dispose()
                    Case "Cash Receipts"
                        Dim f As New frmCollection 'LoadingScreen 'ParentMenu '
                        f.ShowDialog(TransID)
                        f.Dispose()
                    Case "Sales"
                        Dim f As New frmSI
                        f.ShowDialog(TransID)
                        f.Dispose()
                    Case "General Journal"
                        Dim f As New frmJV  'LoadingScreen 'ParentMenu '
                        f.ShowDialog(TransID)
                        f.Dispose()
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnPost_Click(sender As System.Object, e As System.EventArgs) Handles btnPost.Click
        Try
            For Each item As DataGridViewRow In dgvPosting.Rows
                If item.Cells(chInclude.Index).Value = True Then
                    Dim updateSQL As String
                    updateSQL = " UPDATE tblJE_Header " & _
                                " SET    Status ='Posted' " & _
                                " WHERE  Ref_Type ='" & item.Cells(chType.Index).Value.ToString & "'  " & _
                                " AND    Ref_TransID ='" & item.Cells(chTransID.Index).Value.ToString & "' "
                    SQL.ExecNonQuery(updateSQL)
                End If
            Next
            MsgBox("Records posted succesfully", MsgBoxStyle.Information)
            LoadTB()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each row As DataGridViewRow In dgvPosting.Rows
            If chkAll.Checked = True Then
                row.Cells(chInclude.Index).Value = True
            Else
                row.Cells(chInclude.Index).Value = False
            End If
        Next
    End Sub
End Class