Public Class frmCOA_Search
    Public accountcode As String
    Public accttile As String
    Public filterfield As String
    Dim SQL As New SQLControl

    Public Overloads Function ShowDialog(fld As String, ByVal Accttle As String) As Boolean
        filterfield = fld
        If filterfield = "AccntCode" Then
            accountcode = Accttle
        Else
            accttile = Accttle
        End If
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub FrmChartOfAccountSearch_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim query As String = ""
        Select Case filterfield
            Case "AccntCode"
                query = "SELECT  AccountCode, AccountTitle " & _
                       " FROM    tblCOA_Master " & _
                       " WHERE   AccountNature <> '' AND AccountCode= '" & accountcode & "'" & _
                       " ORDER BY AccountCode"
            Case "AccntTitle"
                query = "SELECT  AccountCode, AccountTitle " & _
                       " FROM    tblCOA_Master" & _
                       " WHERE   AccountNature <> '' AND AccountTitle LIKE '%" & accttile & "%'" & _
                       " ORDER BY AccountTitle"
        End Select
        SQL.ReadQuery(query)
        If SQL.SQLDR.HasRows Then
            While SQL.SQLDR.Read
                dgvSearchBPPO.Rows.Add(New String() {SQL.SQLDR("AccountCode").ToString, _
                                                     SQL.SQLDR("AccountTitle").ToString})
            End While
            If filterfield = "AccntCode" AndAlso dgvSearchBPPO.Rows.Count = 1 Then
                accountcode = dgvSearchBPPO.Item(0, 0).Value
                accttile = dgvSearchBPPO.Item(1, 0).Value
                Me.Close()
            End If
        Else
            MsgBox("No Record Found!", MsgBoxStyle.Exclamation)
            accountcode = ""
            accttile = ""
            Me.Close()
        End If
    End Sub
    Private Sub dgvSearchBPPO_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearchBPPO.CellMouseClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            accountcode = dgvSearchBPPO.Item(0, e.RowIndex).Value
            accttile = dgvSearchBPPO.Item(1, e.RowIndex).Value
            Me.Close()
        End If
    End Sub

    Private Sub dgvSearchBPPO_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvSearchBPPO.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvSearchBPPO.SelectedRows.Count > 0 Then
                accountcode = dgvSearchBPPO.SelectedRows(0).Cells(0).Value.ToString
                accttile = dgvSearchBPPO.SelectedRows(0).Cells(1).Value.ToString
            End If
            Me.Close()
        End If
    End Sub
End Class