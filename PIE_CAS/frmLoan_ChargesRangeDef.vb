Public Class frmLoan_ChargesRangeDef
    Dim chargeName As String

#Region "DECLARATIONS"
    Private Sub loadValueType()
        cbValueType.Items.Clear()
        cbValueType.Items.Add("Amount")
        cbValueType.Items.Add("Percentage")
        cbValueType.SelectedItem = "Amount"
    End Sub

    Private Sub loadRangebasis()
        cbBasis.Items.Clear()
        cbBasis.Items.Add("Principal")
        cbBasis.SelectedItem = "Principal"
    End Sub
#End Region

#Region "FORM EVENTS"
    Public Overloads Function ShowDialog(ByVal Type As String) As Boolean
        chargeName = Type
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmLoan_ChargesRangeDef_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadValueType()
        loadRangebasis()
    End Sub

    Private Sub dgvRecords_CellValidating(sender As System.Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvRanges.CellValidating
        If e.ColumnIndex = dgcFrom.Index Or e.ColumnIndex = dgcTo.Index Or e.ColumnIndex = dgcValue.Index Then
            Dim dc As Decimal
            If e.FormattedValue.ToString <> String.Empty AndAlso Not Decimal.TryParse(e.FormattedValue.ToString, dc) Then
                Msg("Invalid Data! Value should be numeric only!", MsgBoxStyle.Exclamation)
                e.Cancel = True
            End If
        End If
    End Sub
#End Region

#Region "SUBS"
    
#End Region
   
End Class