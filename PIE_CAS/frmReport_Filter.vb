Public Class frmReport_Filter
    Public Report As String

    Private Sub frmReport_Filter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbPeriod.SelectedItem = "Monthly"
        nupYear.Value = Date.Today.Year
        cbMonth.SelectedIndex = Date.Today.Month - 1
        LoadStatus()
    End Sub

    Private Sub LoadStatus()
        Select Case Report
            Case "PR List"
                Dim query As String
                query = " SELECT DISTINCT Status  FROM tblPR	 "
                SQL.ReadQuery(query)
                cbStatus.Items.Clear()
                cbStatus.Items.Add("All")
                While SQL.SQLDR.Read
                    cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
                End While
                cbStatus.SelectedIndex = 0
            Case "PO List"
                Dim query As String
                query = " SELECT DISTINCT Status  FROM viewPO_Status	 "
                SQL.ReadQuery(query)
                cbStatus.Items.Clear()
                cbStatus.Items.Add("All")
                While SQL.SQLDR.Read
                    cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
                End While
                cbStatus.SelectedIndex = 0
            Case "RFP List"
                Dim query As String
                query = " SELECT DISTINCT Status  FROM tblRFP	 "
                SQL.ReadQuery(query)
                cbStatus.Items.Clear()
                cbStatus.Items.Add("All")
                While SQL.SQLDR.Read
                    cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
                End While
                cbStatus.SelectedIndex = 0
            Case "APV List"
                Dim query As String
                query = " SELECT DISTINCT Status  FROM tblAPV	 "
                SQL.ReadQuery(query)
                cbStatus.Items.Clear()
                cbStatus.Items.Add("All")
                While SQL.SQLDR.Read
                    cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
                End While
                cbStatus.SelectedIndex = 0
            Case "RR List"
                Dim query As String
                query = " SELECT DISTINCT Status  FROM tblRR "
                SQL.ReadQuery(query)
                cbStatus.Items.Clear()
                cbStatus.Items.Add("All")
                While SQL.SQLDR.Read
                    cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
                End While
                cbStatus.SelectedIndex = 0
            Case "SO List"
                Dim query As String
                query = " SELECT DISTINCT Status  FROM tblSO "
                SQL.ReadQuery(query)
                cbStatus.Items.Clear()
                cbStatus.Items.Add("All")
                While SQL.SQLDR.Read
                    cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
                End While
                cbStatus.SelectedIndex = 0
        End Select

    End Sub

    Private Sub nupYear_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nupYear.ValueChanged, cbMonth.SelectedIndexChanged, chkYTD.CheckedChanged
        LoadPeriod()
    End Sub

    Private Sub LoadPeriod()
        If cbMonth.SelectedIndex <> -1 Then
            Dim period As String = (cbMonth.SelectedIndex + 1).ToString & "-1-" & nupYear.Value.ToString
            If chkYTD.Checked Then
                dtpFrom.Value = Date.Parse("1-1-" & nupYear.Value.ToString)
                dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Date.Parse(period)))
            Else
                dtpFrom.Value = Date.Parse(period)
                dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Date.Parse(period)))
            End If
        End If
    End Sub

    Private Sub btnPreview_Click(sender As System.Object, e As System.EventArgs) Handles btnPreview.Click
        If Report = "PR List" Then
            Dim f As New frmReport_Display
            f.ShowDialog("PR_List", "", IIf(rbSummary.Checked, "Summary", "Detailed"), dtpFrom.Value.Date, dtpTo.Value.Date, cbStatus.SelectedItem)
            f.Dispose()
        ElseIf Report = "PO List" Then
            Dim f As New frmReport_Display
            f.ShowDialog("PO_List", "", IIf(rbSummary.Checked, "Summary", "Detailed"), dtpFrom.Value.Date, dtpTo.Value.Date, cbStatus.SelectedItem)
            f.Dispose()
        ElseIf Report = "RFP List" Then
            Dim f As New frmReport_Display
            f.ShowDialog("RFP_List", "", IIf(rbSummary.Checked, "Summary", "Detailed"), dtpFrom.Value.Date, dtpTo.Value.Date, cbStatus.SelectedItem)
            f.Dispose()
        ElseIf Report = "APV List" Then
            Dim f As New frmReport_Display
            f.ShowDialog("APV_List", "", IIf(rbSummary.Checked, "Summary", "Detailed"), dtpFrom.Value.Date, dtpTo.Value.Date, cbStatus.SelectedItem)
            f.Dispose()
        ElseIf Report = "RR List" Then
            Dim f As New frmReport_Display
            f.ShowDialog("RR_List", "", IIf(rbSummary.Checked, "Summary", "Detailed"), dtpFrom.Value.Date, dtpTo.Value.Date, cbStatus.SelectedItem)
            f.Dispose()
        ElseIf Report = "SO List" Then
            Dim f As New frmReport_Display
            f.ShowDialog("SO_List", "", IIf(rbSummary.Checked, "Summary", "Detailed"), dtpFrom.Value.Date, dtpTo.Value.Date, cbStatus.SelectedItem)
            f.Dispose()
        End If
    End Sub

    Private Sub cbPeriod_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPeriod.SelectedIndexChanged
        If cbPeriod.SelectedItem = "Monthly" Then
            gbPeriodYM.Visible = True
            gbPeriodFT.Visible = False
            chkYTD.Visible = False
            cbMonth.Enabled = True
            cbMonth.Items.Clear()
            cbMonth.Items.Add("January")
            cbMonth.Items.Add("February")
            cbMonth.Items.Add("March")
            cbMonth.Items.Add("April")
            cbMonth.Items.Add("May")
            cbMonth.Items.Add("June")
            cbMonth.Items.Add("July")
            cbMonth.Items.Add("August")
            cbMonth.Items.Add("September")
            cbMonth.Items.Add("October")
            cbMonth.Items.Add("November")
            cbMonth.Items.Add("December")
            lblMonth.Text = "Month :"
        ElseIf cbPeriod.SelectedItem = "Daily" Then
            gbPeriodYM.Visible = False
            gbPeriodFT.Visible = True
            lblTo.Visible = False
            dtpTo.Visible = False
            lblFrom.Text = "Date :"
        ElseIf cbPeriod.SelectedItem = "Date Range" Then
            lblFrom.Text = "From :"
            lblTo.Visible = True
            dtpTo.Visible = True
            gbPeriodYM.Visible = False
            gbPeriodFT.Visible = True '
        ElseIf cbPeriod.SelectedItem = "Yearly" Then
            chkYTD.Checked = True
            LoadPeriod()
            lblFrom.Text = "From :"
            lblTo.Visible = True
            dtpTo.Visible = True
            gbPeriodYM.Visible = True
            gbPeriodFT.Visible = False
            cbMonth.Enabled = False
        ElseIf cbPeriod.SelectedItem = "Quarterly" Then
            chkYTD.Checked = True
            LoadPeriod()
            cbMonth.Items.Clear()
            cbMonth.Items.Add("1st Quarter")
            cbMonth.Items.Add("2nd Quarter")
            cbMonth.Items.Add("3rd Quarter")
            cbMonth.Items.Add("4th Quarter")
            lblMonth.Text = "Quarter :"
            lblFrom.Text = "From :"
            lblTo.Visible = True
            dtpTo.Visible = True
            gbPeriodYM.Visible = True
            gbPeriodFT.Visible = False
            cbMonth.Enabled = True
        End If
        LoadPeriod()
    End Sub
End Class