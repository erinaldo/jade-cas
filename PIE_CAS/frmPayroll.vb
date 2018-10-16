Public Class frmPayroll
    Dim SQL As New SQLControl
    Private Sub frmPayroll_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPayroll()
    End Sub

    Private Sub LoadPayroll()
        Dim query As String
        query = " SELECT DISTINCT Payroll_Period FROM Payroll_Entries WHERE Status ='Saved' "
        SQL.ReadQuery(query)
        lvPayroll.Items.Clear()
        While SQL.SQLDR.Read
            lvPayroll.Items.Add(SQL.SQLDR("Payroll_Period"))
        End While
    End Sub

    Private Sub lvPayroll_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvPayroll.DoubleClick
        LoadEntries(lvPayroll.SelectedItems(0).SubItems(0).Text)
    End Sub

    Private Sub LoadEntries(ByVal PayPeriod As String)
        'Dim query As String
        'query = " SELECT  '' AS VCECode, '' AS VCEName, AccntCode, Particulars, SUM(DebitAmnt) AS DebitAmnt, SUM(CreditAmnt) AS CreditAmnt " & _
        '        " FROM    Payroll_Entries " & _
        '        " WHERE   Payroll_Period ='" & PayPeriod & "' " & _
        '        " GROUP BY  AccntCode, Particulars " & _
        '        " ORDER BY AccntCode DESC"
        'SQL.ReadQuery(query)
        'While SQL.SQLDR.Read
        '    With frmDisbursementRR
        '        .dgvProducts.Rows.Add(New String() {"", SQL.SQLDR("AccntCode").ToString, _
        '                                            GetAccntTitle(SQL.SQLDR("AccntCode").ToString), _
        '                                            SQL.SQLDR("DebitAmnt"), _
        '                                            SQL.SQLDR("CreditAmnt"), _
        '                                            SQL.SQLDR("VCECode").ToString, _
        '                                            SQL.SQLDR("VCEName").ToString, _
        '                                            SQL.SQLDR("Particulars"), _
        '                                            ""})
        '        If SQL.SQLDR("AccntCode").ToString = "01020" Then
        '            .txtAmount.Text = SQL.SQLDR("CreditAmnt")
        '            Dim b As Double
        '            .txtAmountWords.Text = .AmountInWords(.txtTotalAmount.Text)
        '            b = .txtAmount.Text
        '            .txtAmount.Text = Format(b, "#,###,###,###.00").ToString()
        '        End If
        '    End With
        'End While
        'frmDisbursementRR.txtRemarks.Text = "Payroll " & lvPayroll.SelectedItems(0).SubItems(0).Text
        'frmDisbursementRR.cbPaymentType.SelectedItem = "Debit Memo"
        'frmDisbursementRR.txtBank.Text = "FCIE Langkaan|ORCBC|1-358-30168-8|01020|Operation bank account, RCBC"
        'frmDisbursementRR.txtCheckNo.Text = GetDebitMemo()
        'frmDisbursementRR.TotalRR()
        'Me.Close()
        'Me.Dispose()
    End Sub

    Private Function GetDebitMemo() As String
        Dim query As String
        query = " SELECT 'DM' + CAST(ISNULL(MAX(REPLACE(CheckNo,'DM',''))+1,1) AS nvarchar) AS MaxID FROM ACV WHERE CheckNo LIKE 'DM%' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("MaxID")
        Else
            Return ""
        End If
    End Function

    Private Function GetAccntTitle(ByVal AccntCode As String) As String
        Dim query As String
        query = " SELECT AccntTitle FROM ChartOfAccount WHERE AccntCode ='" & AccntCode & "' "
        SQL.ReadQuery(query, 2)
        If SQL.SQLDR2.Read Then
            Return SQL.SQLDR2("AccntTitle")
        Else
            Return ""
        End If
    End Function

    Private Sub lvPayroll_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPayroll.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadEntries(lvPayroll.SelectedItems(0).SubItems(0).Text)
        End If
    End Sub
End Class