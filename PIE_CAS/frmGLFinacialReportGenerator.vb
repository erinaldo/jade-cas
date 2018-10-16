Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.Net.NetworkInformation
 
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Public Class frmGLFinacialReportGenerator
    Public Period
    Public TextFile As IO.StreamWriter
    Public TextFile1 As IO.StreamWriter
    Public FROMPERIOD, TOPERIOD As String
    Dim SQL As New SQLControl

    Private Sub frmGLFinacialReportGenerator_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        nupYear.Value = Date.Today.Year
        cbMonth.SelectedIndex = Date.Today.Month - 1
        LoadAccountCode()
    End Sub

    Private Sub LoadPeriod()
        Dim period As String = (cbMonth.SelectedIndex + 1).ToString & "-1-" & nupYear.Value.ToString
        If cbFiscal.Text = "MTD" Then
            dtpFrom.Value = Date.Parse(period)
            dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Date.Parse(period)))
        ElseIf cbFiscal.Text = "YTD" Then
            dtpFrom.Value = Date.Parse("1-1-" & nupYear.Value.ToString)
            dtpTo.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Date.Parse(period)))
        End If
    End Sub

    Private Sub LoadAccountCode()
        'Dim query As String
        'query = "SELECT  AccntTitle FROM ChartOfAccount ORDER BY AccntCode"
        'SQL.ReadQuery(query)
        'cbAccountFrom.Items.Clear()
        'cbAccountTo.Items.Clear()
        'While SQL.SQLDR.Read
        '    cbAccountFrom.Items.Add(SQL.SQLDR("AccntTitle").ToString)
        '    cbAccountTo.Items.Add(SQL.SQLDR("AccntTitle").ToString)
        'End While
    End Sub

    Private Sub LoadTBDetailed()
        Dim query As String
        If cbFiscal.SelectedItem = "MTD" AndAlso chkBB.Checked = True Then
            query = " SELECT  MainAccountCode, MainAccountTitle,ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle,  " & _
                    "          Debit, Credit, VCECode, VCEName, Book, Ref_Type, CASE WHEN Ref_TransID ='BB' THEN CAST(JE.JE_No AS nvarchar) ELSE CAST(Ref_TransID AS nvarchar) END AS Ref_TransID, App_Date, " & _
                    "          ChartOfAccount.Account_Type, Account_Sub_Type, Sub_Category " & _
                    " FROM     " & _
                    " (      SELECT  JE_No, VCECode, VCEName, Ref_TransID, Ref_Type,  AccntCode, AccntTitle,  " & _
                    " 		        Debit, Credit, App_Date, Book  " & _
                    "        FROM	view_GL ) AS JE  " & _
                    " INNER JOIN ChartOfAccount  " & _
                    " ON	   JE.AccntCode = ChartOfAccount.AccntCode  " & _
                    " WHERE    JE.App_Date BETWEEN '" & dtpFrom.Value.Date & "' AND '" & dtpTo.Value.Date & "'  " & _
                    " AND	   ChartOfAccount.AccntCode >= N'" & GetAccntCode(cbAccountFrom.SelectedItem) & "' " & _
                    " AND      ChartOfAccount.AccntCode <= N'" & GetAccntCode(cbAccountTo.SelectedItem) & "' " & _
                    " AND	   Ref_Type IN ('" & IIf(chkOR.Checked = True, "OR", "") & "','" & IIf(chkOR.Checked = True, "Deposit", "") & "','" & IIf(chkDV.Checked = True, "DV", "") & "','" & IIf(chkJV.Checked = True, "JV", "") & "','" & IIf(chkPEC.Checked = True, "Period End Closing", "") & "','" & IIf(chkBB.Checked = True, "BB", "") & "') " & OrderBy()
        Else
            query = " SELECT   MainAccountCode, MainAccountTitle,ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle,  " & _
                    "          Debit AS Debit, Credit AS Credit, VCECode, VCEName, Book, Ref_Type, CASE WHEN Ref_Type ='BB' THEN CAST(view_GL.JE_No AS nvarchar) ELSE CAST(Ref_TransID AS nvarchar) END AS Ref_TransID, App_Date, " & _
                    "          ChartOfAccount.Account_Type, Account_Sub_Type, Sub_Category " & _
                    " FROM     view_GL INNER JOIN ChartOfAccount  " & _
                    " ON	   view_GL.AccntCode = ChartOfAccount.AccntCode  " & _
                    " WHERE    view_GL.App_Date BETWEEN '" & dtpFrom.Value.Date & "' AND '" & dtpTo.Value.Date & "'  " & _
                    " AND	   ChartOfAccount.AccntCode >= N'" & GetAccntCode(cbAccountFrom.SelectedItem) & "' " & _
                    " AND      ChartOfAccount.AccntCode <= N'" & GetAccntCode(cbAccountTo.SelectedItem) & "' " & _
                    " AND	   Ref_Type IN ('" & IIf(chkOR.Checked = True, "OR", "") & "','" & IIf(chkOR.Checked = True, "Deposit", "") & "','" & IIf(chkDV.Checked = True, "CV", "") & "','" & IIf(chkJV.Checked = True, "JV", "") & "','" & IIf(chkPEC.Checked = True, "Period End Closing", "") & "','" & IIf(chkBB.Checked = True, "BB", "") & "') " & OrderBy()
        End If
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            dgvData.DataSource = SQL.SQLDS.Tables(0)
            dgvData.Columns(4).DefaultCellStyle.Format = Format("#,###,###,###.00").ToString
            dgvData.Columns(5).DefaultCellStyle.Format = Format("#,###,###,###.00").ToString
            dgvData.Columns(4).Frozen = True
            dgvData.Columns(5).Frozen = True
            TotalRR()
        Else
            dgvData.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadTBSummary()
        Dim query As String
        If cbFiscal.SelectedItem = "MTD" AndAlso chkBB.Checked = True Then
            query = " SELECT   MainAccountCode, MainAccountTitle, ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle,  " & _
                       "          CASE WHEN SUM(Debit) > SUM(Credit) THEN SUM(Debit) - SUM(Credit) ELSE 0 END AS Debit, " & _
                       "          CASE WHEN SUM(Credit) > SUM(Debit) THEN SUM(Credit) - SUM(Debit) ELSE 0 END AS Credit, " & _
                       "          ChartOfAccount.Account_Type, Account_Sub_Type, Sub_Category " & _
                       " FROM     " & _
                       " (      SELECT  JE_No, VCECode, Ref_TransID, Ref_Type,  AccntCode, AccntTitle,  " & _
                       " 		        Debit, Credit, App_Date  " & _
                       "        FROM	view_GL ) AS JE  " & _
                       " INNER JOIN ChartOfAccount  " & _
                       " ON	   JE.AccntCode = ChartOfAccount.AccntCode  " & _
                       " WHERE    JE.App_Date BETWEEN '" & dtpFrom.Value.Date & "' AND '" & dtpTo.Value.Date & "'  " & _
                       " AND	   ChartOfAccount.AccntCode >= N'" & GetAccntCode(cbAccountFrom.SelectedItem) & "' " & _
                       " AND      ChartOfAccount.AccntCode <= N'" & GetAccntCode(cbAccountTo.SelectedItem) & "' " & _
                       " AND	   Ref_Type IN ('" & IIf(chkOR.Checked = True, "OR", "") & "','" & IIf(chkDV.Checked = True, "CV", "") & "','" & IIf(chkJV.Checked = True, "JV", "") & "','" & IIf(chkPEC.Checked = True, "Period End Closing", "") & "','" & IIf(chkBB.Checked = True, "BB", "") & "') " & _
                       " GROUP BY MainAccountCode, MainAccountTitle, ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle, ChartOfAccount.Account_Type, ChartOfAccount.Account_Sub_Type, Sub_Category " & OrderBy()
        Else
            query = " SELECT   MainAccountCode, MainAccountTitle, ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle,  " & _
                    "          CASE WHEN SUM(Debit) > SUM(Credit) THEN SUM(Debit) - SUM(Credit) ELSE 0 END AS Debit, " & _
                    "          CASE WHEN SUM(Credit) > SUM(Debit) THEN SUM(Credit) - SUM(Debit) ELSE 0 END AS Credit, " & _
                    "          ChartOfAccount.Account_Type, Account_Sub_Type, Sub_Category " & _
                    " FROM     view_GL INNER JOIN ChartOfAccount  " & _
                    " ON	   view_GL.AccntCode = ChartOfAccount.AccntCode  " & _
                    " WHERE    view_GL.App_Date BETWEEN '" & dtpFrom.Value.Date & "' AND '" & dtpTo.Value.Date & "'  " & _
                    " AND	   ChartOfAccount.AccntCode >= N'" & GetAccntCode(cbAccountFrom.SelectedItem) & "' " & _
                    " AND      ChartOfAccount.AccntCode <= N'" & GetAccntCode(cbAccountTo.SelectedItem) & "' " & _
                    " AND	   Ref_Type IN ('" & IIf(chkOR.Checked = True, "OR", "") & "','" & IIf(chkDV.Checked = True, "CV", "") & "','" & IIf(chkJV.Checked = True, "JV", "") & "','" & IIf(chkPEC.Checked = True, "Period End Closing", "") & "','" & IIf(chkBB.Checked = True, "BB", "") & "') " & _
                    " GROUP BY MainAccountCode, MainAccountTitle, ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle, ChartOfAccount.Account_Type, ChartOfAccount.Account_Sub_Type, Sub_Category " & OrderBy()
        End If
        SQL.GetQuery(query)
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            dgvData.DataSource = SQL.SQLDS.Tables(0)
            dgvData.Columns(4).DefaultCellStyle.Format = Format("#,###,###,###.00").ToString
            dgvData.Columns(5).DefaultCellStyle.Format = Format("#,###,###,###.00").ToString
            TotalRR()
        Else
            dgvData.DataSource = Nothing
            dgvData.Refresh()
            MsgBox("No Record Found", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Function OrderBy() As String
        If rbOrderAccount.Checked = True Then
            Return " ORDER BY Account_Type"
        ElseIf rbOrderSubType.Checked = True Then
            Return " ORDER BY Account_Sub_Type "
        ElseIf rbOrderCategory.Checked = True Then
            Return " ORDER BY Sub_Category "
        ElseIf rbAccountCode.Checked = True Then
            Return " ORDER BY AccntCode "
        ElseIf rbAccountTitle.Checked = True Then
            Return " ORDER BY AccntTitle "
        ElseIf rbRefID.Checked = True Then
            Return " ORDER BY Ref_TransID "
        Else
            Return ""
        End If
    End Function

    Private Function GetAccntCode(ByVal AccntTitle As String) As String
        Dim query As String
        query = " SELECT AccntCode FROM ChartOfAccount WHERE AccntTitle = '" & AccntTitle & "' "
        SQL.FlushParams()
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AccntCode").ToString
        Else
            Return ""
        End If
    End Function

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Try
            GenerateReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GenerateReport()
        If cbAccountFrom.SelectedIndex = -1 Or cbAccountTo.SelectedIndex = -1 Then
            MsgBox("Please select account code!", MsgBoxStyle.Exclamation)
        Else
            dgvData.DataSource = Nothing
            If dgvData.Rows.Count > 0 Then
                dgvData.Rows.Clear()
            End If
            If dgvData.Columns.Count > 0 Then
                dgvData.Columns.Clear()
            End If

            If rbDetailed.Checked = True Then
                LoadTBDetailed()
            Else
                LoadTBSummary()
            End If
        End If
        TotalRR()
    End Sub

    Private Sub cmbToDepartment_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbToDepartment.KeyDown
        'Try
        '    If e.KeyCode = Keys.Enter Then
        '        Dim cmd As New SqlCommand
        '        Dim dr As SqlDataReader

        '        cmd = conn.CreateCommand
        '        cmd.CommandText = " SELECT        dbo.ChartOfAccount.Account_Type, dbo.ChartOfAccount.Account_Sub_Type, dbo.ChartOfAccount.Sub_Category, dbo.ChartOfAccount.Segment, SUM(je.Debit) AS Debit, SUM(je.Credit) AS Credit" & _
        '                        " FROM            dbo.view_GL AS je INNER JOIN     dbo.ChartOfAccount ON je.AccntCode = dbo.ChartOfAccount.AccntCode" & _
        '                        " GROUP BY je.FromPeriod, je.ToPeriod, dbo.ChartOfAccount.Account_Type, dbo.ChartOfAccount.Account_Sub_Type, dbo.ChartOfAccount.Sub_Category, dbo.ChartOfAccount.Segment" & _
        '                        " HAVING        (je.FromPeriod >= '" & FROMPERIOD & "') AND (je.ToPeriod <= '" & TOPERIOD & "') AND (dbo.ChartOfAccount.Segment >= N'" & cbAccountFrom.Text & "' AND dbo.ChartOfAccount.Segment <= N'" & cmbToDepartment.Text & "')"

        '        dr = cmd.ExecuteReader
        '        If dr.HasRows Then
        '            While dr.Read
        '                dgvData.Rows.Add(New String() {dr("Account_Type").ToString, _
        '                                                   dr("Account_Sub_Type").ToString, _
        '                                                    dr("Sub_Category").ToString, _
        '                                                    dr("Segment").ToString, _
        '                                                       "", _
        '                                                      "", _
        '                                                      dr("Debit").ToString, _
        '                                                     dr("Credit").ToString, ""})
        '            End While
        '            dgvData.Columns(0).Visible = True
        '            dgvData.Columns(1).Visible = True
        '            dgvData.Columns(2).Visible = True
        '            dgvData.Columns(3).Visible = True
        '            dgvData.Columns(4).Visible = False
        '            dgvData.Columns(5).Visible = False
        '            dgvData.Columns(6).Visible = True
        '            dgvData.Columns(7).Visible = True
        '        End If
        '        dr.Close()
        '        conn.Close()

        '    End If
        'Catch exs As SqlException

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cmbPeriod_Covered_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

        Period = Split(dtpFrom.Text, " To ")
        If UBound(Period) > 0 Then
            FROMPERIOD = Period(0)
            TOPERIOD = Period(1)
        Else
            FROMPERIOD = dtpFrom.Text
            TOPERIOD = dtpTo.Text
        End If

    End Sub


    Private Sub cmbToDepartment_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbToDepartment.SelectedIndexChanged

    End Sub

    Private Sub cmbToAccountCode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbAccountTo.KeyDown
        'Try

        '    Period = Split(dtpFrom.Text, " To ")
        '    FROMPERIOD = Period(0)
        '    TOPERIOD = Period(1)
        '    If e.KeyCode = Keys.Enter Then
        '        Dim cmd As New SqlCommand
        '        Dim dr As SqlDataReader
        '        cmd = conn.CreateCommand
        '        cmd.CommandText = " SELECT        dbo.ChartOfAccount.Account_Type, dbo.ChartOfAccount.Account_Sub_Type, dbo.ChartOfAccount.Sub_Category, dbo.ChartOfAccount.Segment, SUM(je.Debit) AS Debit, SUM(je.Credit) AS Credit" & _
        '                        " FROM            dbo.view_GL AS je INNER JOIN     dbo.ChartOfAccount ON je.AccntCode = dbo.ChartOfAccount.AccntCode" & _
        '                        " where        (je.FromPeriod >= '" & FROMPERIOD & "') AND (je.ToPeriod <= '" & TOPERIOD & "') AND (dbo.ChartOfAccount.AccntCode >= N'" & cbAccountFrom.Text & "' AND dbo.ChartOfAccount.AccntCode <= N'" & cbAccountTo.Text & "')" & _
        '                        " GROUP BY je.FromPeriod, je.ToPeriod, dbo.ChartOfAccount.Account_Type, dbo.ChartOfAccount.Account_Sub_Type, dbo.ChartOfAccount.Sub_Category, dbo.ChartOfAccount.Segment"

        '        dr = cmd.ExecuteReader
        '        If dr.HasRows Then
        '            While dr.Read
        '                dgvData.Rows.Add(New String() {dr("Account_Type").ToString, _
        '                                                   dr("Account_Sub_Type").ToString, _
        '                                                    dr("Sub_Category").ToString, _
        '                                                    dr("Segment").ToString, _
        '                                                       "", _
        '                                                      "", _
        '                                                      dr("Debit").ToString, _
        '                                                     dr("Credit").ToString, ""})
        '            End While
        '            dgvData.Columns(0).Visible = True
        '            dgvData.Columns(1).Visible = True
        '            dgvData.Columns(2).Visible = True
        '            dgvData.Columns(3).Visible = True
        '            dgvData.Columns(4).Visible = False
        '            dgvData.Columns(5).Visible = False
        '            dgvData.Columns(6).Visible = True
        '            dgvData.Columns(7).Visible = True
        '        End If
        '        dr.Close()
        '        conn.Close()

        '    End If
        'Catch exs As SqlException

        'Catch ex As Exception

        'End Try

    End Sub


    Private Sub CmdPreview_Click(sender As System.Object, e As System.EventArgs) Handles CmdPreview.Click
        Period = Split(dtpFrom.Text, " To ")
        If UBound(Period) > 0 Then
            FROMPERIOD = Period(0)
            TOPERIOD = Period(1)
        Else
            FROMPERIOD = dtpFrom.Text
            TOPERIOD = dtpTo.Text
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        printtotxt()
    End Sub


    Private Sub printtotxt()
        'Try
        '    Dim maxtransid As String
        '    Dim App_Path As String
        '    App_Path = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName


        '    maxtransid = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second
        '    App_Path = App_Path & "\DownloadedFiles\ReportGenerator"
        '    TextFile = New StreamWriter(App_Path & maxtransid & ".txt")


        '    TextFile.WriteLine(Date.Now)


        '    If dgvData.RowCount > 0 Then
        '    End If

        '    'debit compute & print in textbox
        '    Dim a As Double = 0
        '    For x As Integer = 0 To dgvData.ColumnCount - 2
        '        '  maxtransid = dgvCVRR.Columns(x).HeaderText
        '        TextFile.Write(dgvData.Columns(x).HeaderText)        '((dgvCVRR.Columns(0))  '.Item(1).Value.Columns))
        '        TextFile.Write("|")
        '    Next
        '    TextFile.WriteLine()
        '    For y As Integer = 0 To dgvData.Rows.Count - 1
        '        For x As Integer = 0 To dgvData.ColumnCount - 2
        '            TextFile.Write((dgvData.Item(x, y).Value).ToString)
        '            TextFile.Write("|")
        '        Next
        '        TextFile.WriteLine()
        '    Next


        '    TextFile.Close()
        '    'MessageBox("Txt file created : " & App_Path & maxtransid & ".txt", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        'Catch exs As SqlException
        '    MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        '    CN.Close()
        '    CN2.Close()
        '    CN3.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        '    CN.Close()
        '    CN2.Close()
        '    CN3.Close()
        'End Try
    End Sub
    Private Sub TotalRR()
        Try
            'debit compute & print in textbox
            Dim a As Double = 0
            For i As Integer = 0 To dgvData.Rows.Count - 1

                If Val(dgvData.Item(4, i).Value) <> 0 Then
                    a = a + Double.Parse(dgvData.Item(4, i).Value).ToString("N2")
                End If
            Next
            txtTotalDebit.Text = a.ToString("N2")

            'credit compute & print in textbox
            Dim b As Double = 0

            For i As Integer = 0 To dgvData.Rows.Count - 1
                If Val(dgvData.Item(5, i).Value) <> 0 Then
                    b = b + Double.Parse(dgvData.Item(5, i).Value).ToString("N2")
                End If
            Next
            txtTotalCredit.Text = b.ToString("N2")
            txtTotalVariance.Text = Math.Abs(CDec(txtTotalDebit.Text) - CDec(txtTotalCredit.Text))
        Catch exs As SqlException
            MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub TotalRRPEC()
        Try
            'debit compute & print in textbox
            Dim a As Double = 0
            For i As Integer = 0 To dgvData.Rows.Count - 1

                If Val(dgvData.Item(5, i).Value) <> 0 Then
                    a = a + Double.Parse(dgvData.Item(5, i).Value).ToString("N2")
                End If
            Next
            txtTotalDebit.Text = a.ToString("N2")

            'credit compute & print in textbox
            Dim b As Double = 0

            For i As Integer = 0 To dgvData.Rows.Count - 1
                If Val(dgvData.Item(6, i).Value) <> 0 Then
                    b = b + Double.Parse(dgvData.Item(6, i).Value).ToString("N2")
                End If
            Next
            txtTotalCredit.Text = b.ToString("N2")
            txtTotalVariance.Text = Math.Abs(CDec(txtTotalDebit.Text) - CDec(txtTotalCredit.Text))
        Catch exs As SqlException
            MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            Period = Split(dtpFrom.Text, " To ")
            If UBound(Period) > 0 Then
                FROMPERIOD = Period(0)
                TOPERIOD = Period(1)
            Else
                FROMPERIOD = dtpFrom.Text
                TOPERIOD = dtpTo.Text
            End If
            loadPeriodEndEntry()
            If dgvData.RowCount = 0 Then
                viewPeriodEndClosing()
            Else
                MsgBox("Already have Period End Closing from " & dtpFrom.Text & "   to  " & dtpTo.Text & "  ")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub viewPeriodEndClosing()
        Dim query As String
        query = " SELECT   Account_Type, Account_Sub_Type, Sub_Category, AccntCode, AccntTitle, Debit, Credit " & _
                " FROM " & _
                " ( " & _
                " SELECT   Account_Type, Account_Sub_Type, Sub_Category, ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle, SortAccount_Type, SorAccount_Sub_Type, SortSub_Category, " & _
                "          CASE WHEN SUM(Debit) > SUM(Credit) THEN SUM(Debit) - SUM(Credit) ELSE 0 END AS Debit, " & _
                "          CASE WHEN SUM(Debit) < SUM(Credit) THEN SUM(Credit) - SUM(Debit) ELSE 0 END AS Credit " & _
                " FROM     view_GL INNER JOIN ChartOfAccount  " & _
                " ON		 view_GL.AccntCode = ChartOfAccount.AccntCode  " & _
                " WHERE    view_GL.FromPeriod >= '" & dtpFrom.Value.Date & "' AND view_GL.ToPeriod <= '" & dtpTo.Value.Date & "'  " & _
                " AND      Account_Type ='Income Statement' " & _
                " GROUP BY SortAccount_Type, Account_Type, SorAccount_Sub_Type, Account_Sub_Type, SortSub_Category, Sub_Category, ChartOfAccount.AccntCode, ChartOfAccount.AccntTitle " & _
                " ) AS DBCR " & _
                " WHERE Debit > 0 OR Credit > 0 " & _
                " ORDER BY SortAccount_Type, SorAccount_Sub_Type, SortSub_Category "
        SQL.ReadQuery(query)
        dgvData.ClearSelection()
        dgvData.Rows.Clear()
        dgvData.Columns.Clear()
        dgvData.Columns.Add("Account_Type", "Account Type")
        dgvData.Columns.Add("Account_Sub_Type", "Account SubType")
        dgvData.Columns.Add("Sub_Category", "SubCategory")
        dgvData.Columns.Add("AccntCode", "Account Code")
        dgvData.Columns.Add("AccntTitle", "Account Title")
        dgvData.Columns.Add("Debit", "Debit")
        dgvData.Columns.Add("Credit", "Credit")
        If SQL.SQLDR.HasRows Then
            While SQL.SQLDR.Read
                dgvData.Rows.Add(New String() {SQL.SQLDR("Account_Type").ToString, _
                                               SQL.SQLDR("Account_Sub_Type").ToString, _
                                               SQL.SQLDR("Sub_Category").ToString, _
                                               SQL.SQLDR("AccntCode").ToString, _
                                               SQL.SQLDR("AccntTitle").ToString, _
                                               Format(SQL.SQLDR("Credit"), "#,###,###,###.00").ToString, _
                                               Format(SQL.SQLDR("Debit"), "#,###,###,###.00").ToString})
            End While
        End If
        TotalRRPEC()
        If txtTotalCredit.Text > txtTotalDebit.Text Then
            dgvData.Rows.Add(New String() {"", _
                                                    "", _
                                                     "", _
                                                         "", _
                                                       "Net Surplus (Loss)", _
                                                  Format(txtTotalCredit.Text - txtTotalDebit.Text, "#,###,###,###.00").ToString, _
                  "0"})
        Else
            dgvData.Rows.Add(New String() {"", _
                                                    "", _
                                                     "", _
                                                         "", _
                                                       "Net Surplus (Loss)", _
                                                  "0", _
                  Format(txtTotalDebit.Text - txtTotalCredit.Text, "#,###,###,###.00").ToString})
        End If
        TotalRRPEC()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles CMDPOSTPEC.Click
        Try
            If dgvData.RowCount = 0 Then
                loadPeriodEndEntry()
                If dgvData.RowCount = 0 Then
                    MsgBox("Period End Closing for this Period is empty.  Transact all necessary entries then click 'Period End Clossing' Button to compute for this Period", vbCritical, "Posting Errror Msg")
                End If
            Else
                If MsgBox("Are you sure you want to Post this Period End Closing Entry for the Year: " & Year(dtpTo.Text) & " and Month : " & Month(dtpTo.Text) & " ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = vbYes Then
                    If MsgBox("Press OK again to post this entry ", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = vbYes Then
                        SaveJE1ManualEntry()
                        loadPeriodEndEntry()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SaveJE1ManualEntry()
        'Dim deleteSQL, insertSQL As String
        'Try
        '    Dim GLACCOUNTTITILE, GLAccount As String
        '    Dim DebitAmount, CreditAmount As Double

        '    deleteSQL = " DELETE FROM view_GL " & _
        '                " WHERE  (Ref_TransID  = 0) AND (Book = N'Period End Entry') " & _
        '                " AND    (JE_No = 0) AND (Remarks = 'Period End Entry') " & _
        '                " AND    (Book = 'Period End Entry') " & _
        '                " AND    (ApplicationDate = '" & dtpTo.Text & "')"
        '    SQL.ExecNonQuery(deleteSQL)
        '    For i As Integer = 0 To dgvData.RowCount - 1
        '        GLAccount = dgvData.Item(3, i).Value
        '        GLACCOUNTTITILE = dgvData.Item(4, i).Value
        '        If IsNumeric(dgvData.Item(5, i).Value) Then
        '            DebitAmount = dgvData.Item(5, i).Value.Replace(",", "")
        '        Else
        '            DebitAmount = 0
        '        End If
        '        If IsNumeric(dgvData.Item(6, i).Value) Then
        '            CreditAmount = dgvData.Item(6, i).Value.Replace(",", "")
        '        Else
        '            CreditAmount = 0
        '        End If
        '        insertSQL = " INSERT INTO " & _
        '                    " view_GL (LineNumber,  Book,  JE_No, Ref_Type, Ref_TransID, AccntCode, AccntTitle, " & _
        '                    "             Debit, Credit, Particulars, ApplicationDate, Remarks)" & _
        '                    " VALUES (@LineNumber, @Book, @JE_No, @Ref_Type, @Ref_TransID,  @AccntCode,  @AccntTitle, " & _
        '                    "         @Debit, @Credit, @Particulars, @ApplicationDate, @Remarks)"
        '        SQL.AddParam("@LineNumber", i)
        '        SQL.AddParam("@Book", "Period End Closing")
        '        SQL.AddParam("@JE_No", "0")
        '        SQL.AddParam("@Ref_Type", "Period End Closing")
        '        SQL.AddParam("@Ref_TransID", "0")
        '        SQL.AddParam("@AccntCode", GLAccount)
        '        SQL.AddParam("@AccntTitle", GLACCOUNTTITILE)
        '        SQL.AddParam("@Debit", DebitAmount)
        '        SQL.AddParam("@Credit", CreditAmount)
        '        SQL.AddParam("@Particulars", "Period End Closing")
        '        SQL.AddParam("@ApplicationDate", dtpTo.Value.Date)
        '        SQL.AddParam("@Remarks", "Period End Closing")
        '        SQL.ExecNonQuery(insertSQL)
        '    Next
        'Catch exs As SqlException
        '    MessageBox.Show(exs.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        '    CN.Close()
        '    CN2.Close()
        '    CN3.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        '    CN.Close()
        '    CN2.Close()
        '    CN3.Close()
        'End Try
    End Sub

    Private Sub loadPeriodEndEntry()
        Dim query As String

        query = " SELECT        TOP (100) PERCENT dbo.ChartOfAccount.SortAccount_Type, dbo.ChartOfAccount.SorAccount_Sub_Type, dbo.ChartOfAccount.Account_Type, dbo.ChartOfAccount.Account_Sub_Type,  " & _
            "                          dbo.ChartOfAccount.Sub_Category, dbo.ChartOfAccount.Segment, je.AccntCode, je.AccntTitle, SUM(je.Debit) AS Debit, SUM(je.Credit) AS Expr2, CASE WHEN (SUM(je.Debit) - SUM(je.Credit) > 0)  " & _
            "                          THEN SUM(je.Debit) - SUM(je.Credit) ELSE 0 END AS db, CASE WHEN (SUM(je.Debit) - SUM(je.Credit) < 0) THEN SUM(je.Credit) - SUM(je.Debit) ELSE 0 END AS cr,  " & _
            "                          dbo.ChartOfAccount.AccntCode AS Expr1, dbo.ChartOfAccount.BSTitle, dbo.ChartOfAccount.BSGroup, dbo.ChartOfAccount.MainAccountCode, dbo.ChartOfAccount.MainAccountTitle, je.ApplicationDate " & _
            " FROM            dbo.view_GL AS je LEFT OUTER JOIN " & _
            "                          dbo.ChartOfAccount ON je.AccntCode = dbo.ChartOfAccount.AccntCode " & _
            " WHERE        (je.Book = 'Period End Closing') AND (je.JE_No = 0) AND (je.Remarks = 'Period End Closing') " & _
            " GROUP BY dbo.ChartOfAccount.SortAccount_Type, dbo.ChartOfAccount.SorAccount_Sub_Type, je.FromPeriod, je.ToPeriod, je.AccntCode, je.AccntTitle, dbo.ChartOfAccount.Segment, dbo.ChartOfAccount.Account_Type,  " & _
            "                          dbo.ChartOfAccount.Account_Sub_Type, dbo.ChartOfAccount.Sub_Category, dbo.ChartOfAccount.AccntCode, dbo.ChartOfAccount.BSTitle, dbo.ChartOfAccount.BSGroup, dbo.ChartOfAccount.MainAccountCode,  " & _
            "                          dbo.ChartOfAccount.MainAccountTitle, je.ApplicationDate " & _
            " HAVING        (je.ApplicationDate = '" & dtpTo.Text & "') " & _
            " ORDER BY dbo.ChartOfAccount.Account_Type, dbo.ChartOfAccount.Account_Sub_Type, dbo.ChartOfAccount.Sub_Category, dbo.ChartOfAccount.Segment "
        SQL.ReadQuery(query)
        dgvData.ClearSelection()
        dgvData.Rows.Clear()
        If SQL.SQLDR.HasRows Then
            dgvData.Columns.Clear()
            dgvData.Columns.Add("Account_Type", "Account Type")
            dgvData.Columns.Add("Account_Sub_Type", "Account SubType")
            dgvData.Columns.Add("Sub_Category", "SubCategory")
            dgvData.Columns.Add("AccntCode", "Account Code")
            dgvData.Columns.Add("AccntTitle", "Account Title")
            dgvData.Columns.Add("Debit", "Debit")
            dgvData.Columns.Add("Credit", "Credit")
            While SQL.SQLDR.Read


                dgvData.Rows.Add(New String() {SQL.SQLDR("Account_Type").ToString, _
                                               SQL.SQLDR("Account_Sub_Type").ToString, _
                                               SQL.SQLDR("Sub_Category").ToString, _
                                               SQL.SQLDR("AccntCode").ToString, _
                                               SQL.SQLDR("AccntTitle").ToString, _
                                        Format(SQL.SQLDR("db"), "#,###,###,###.00").ToString, _
                                        Format(SQL.SQLDR("cr"), "#,###,###,###.00").ToString})


            End While

            dgvData.Columns(0).Visible = True
            dgvData.Columns(1).Visible = True
            dgvData.Columns(2).Visible = True
            dgvData.Columns(3).Visible = True
            dgvData.Columns(4).Visible = True
            dgvData.Columns(5).Visible = True
            dgvData.Columns(6).Visible = True
        End If
        TotalRRPEC()
    End Sub

    Private Sub btnTBPEC_Click(sender As System.Object, e As System.EventArgs) Handles btnTBPEC.Click
        Try
            LoadTBAfterPEC()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub LoadTBAfterPEC()
        Dim query As String
        query = " SELECT  ChartOfAccount.Account_Type, ChartOfAccount.Account_Sub_Type, ChartOfAccount.Sub_Category, ChartOfAccount.Segment, " & _
                "         view_GL.AccntCode, ChartOfAccount.AccntTitle, " & _
                "         SUM(view_GL.Debit)  AS Debit1, SUM(view_GL.Credit) AS Credit1,  " & _
                "         CASE WHEN (SUM(view_GL.Debit) - SUM(view_GL.Credit) > 0) THEN SUM(view_GL.Debit) - SUM(view_GL.Credit) ELSE 0 END AS Debit,  " & _
                "         CASE WHEN (SUM(view_GL.Debit) - SUM(view_GL.Credit) < 0) THEN SUM(view_GL.Credit) - SUM(view_GL.Debit) ELSE 0 END AS Credit " & _
                " FROM    view_GL INNER JOIN ChartOfAccount " & _
                " ON      view_GL.AccntCode = ChartOfAccount.AccntCode " & _
                " WHERE   ApplicationDate >= '01-01-" & dtpFrom.Value.Year & "' AND ApplicationDate <= '" & dtpTo.Text & "' " & _
                " GROUP BY ChartOfAccount.Account_Type, ChartOfAccount.Account_Sub_Type, ChartOfAccount.Sub_Category, ChartOfAccount.Segment, " & _
                "         view_GL.AccntCode, ChartOfAccount.AccntTitle " & _
                " HAVING  ChartOfAccount.Account_Type <> N'Income Statement' " & _
                " ORDER BY ChartOfAccount.Account_Type, ChartOfAccount.Account_Sub_Type, ChartOfAccount.Sub_Category, ChartOfAccount.Segment "
        SQL.FlushParams()
        SQL.ReadQuery(query)
        dgvData.ClearSelection()
        Try
            dgvData.Rows.Clear()
        Catch ex1 As ArgumentException
            dgvData.DataSource = Nothing
        End Try
        If SQL.SQLDR.HasRows Then
            dgvData.Columns.Clear()
            dgvData.Columns.Add("Account_Type", "Account Type")
            dgvData.Columns.Add("Account_Sub_Type", "Account SubType")
            dgvData.Columns.Add("Sub_Category", "SubCategory")
            dgvData.Columns.Add("AccntCode", "Account Code")
            dgvData.Columns.Add("AccntTitle", "Account Title")
            dgvData.Columns.Add("Debit", "Debit")
            dgvData.Columns.Add("Credit", "Credit")
            While SQL.SQLDR.Read
                dgvData.Rows.Add(New String() {SQL.SQLDR("Account_Type").ToString, _
                                               SQL.SQLDR("Account_Sub_Type").ToString, _
                                               SQL.SQLDR("Sub_Category").ToString, _
                                               SQL.SQLDR("AccntCode").ToString, _
                                               SQL.SQLDR("AccntTitle").ToString, _
                                               Format(SQL.SQLDR("Debit"), "#,###,###,###.00").ToString, _
                                               Format(SQL.SQLDR("Credit"), "#,###,###,###.00").ToString})
            End While
            dgvData.Columns(0).Visible = True
            dgvData.Columns(1).Visible = True
            dgvData.Columns(2).Visible = True
            dgvData.Columns(3).Visible = True
            dgvData.Columns(4).Visible = True
            dgvData.Columns(5).Visible = True
            dgvData.Columns(6).Visible = True
        End If
        TotalRRPEC()
    End Sub
    Private Sub btnPostBB_Click(sender As System.Object, e As System.EventArgs) Handles btnPostBB.Click
        Try
            Dim applydate As String
            If MsgBox("Are you sure you want to Post the " & vbNewLine & "Beginning Balance for the Period Year : " & Year(dtpTo.Text) & " and Month : " & Month(dtpTo.Text) + 1 & " ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = vbYes Then
                If MsgBox("Press OK again to post this entry ", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = vbYes Then
                    If Month(dtpTo.Text) <> 12 Then
                        applydate = Month(dtpTo.Text) + 1 & "/1/" & Year(dtpTo.Text)
                    Else
                        applydate = "01/01/" & Year(dtpTo.Text) + 1
                    End If
                    LoadTBAfterPEC()
                    SaveJE1ManualEntrybb(applydate)
                    LoadBBPEC()
                    MsgBox("BB has been posted for " & applydate, MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadBBPEC()
        cbFiscal.SelectedItem = "MTD"
        If cbMonth.SelectedIndex = 11 Then
            cbMonth.SelectedIndex = 0
            nupYear.Value = nupYear.Value + 1
        Else
            cbMonth.SelectedIndex = cbMonth.SelectedIndex + 1
        End If
        cbAccountFrom.SelectedIndex = 0
        cbAccountTo.SelectedIndex = cbAccountTo.Items.Count - 1
        rbSummary.Checked = True
        chkBB.Checked = True
        chkDV.Checked = False
        chkOR.Checked = False
        chkPEC.Checked = False
        chkJV.Checked = False
        rbAccountCode.Checked = True
        GenerateReport()
    End Sub

    Private Sub SaveJE1ManualEntrybb(applydate As String)
        Dim deleteSQL, insertSQL As String
        Try
            Dim GLACCOUNTTITILE, GLAccount As String
            Dim DebitAmount, CreditAmount As Double

            deleteSQL = " DELETE FROM view_GLBegBal " & _
                        " WHERE  (Ref_TransID  = 0) AND    (Book = 'BB')  " & _
                        " AND MONTH(ApplicationDate) = '" & cbMonth.SelectedIndex + 2 & "' AND YEAR(ApplicationDate) = '" & nupYear.Value & "' "
            SQL.ExecNonQuery(deleteSQL)
            For i As Integer = 0 To dgvData.RowCount - 1
                GLAccount = dgvData.Item(3, i).Value
                GLACCOUNTTITILE = dgvData.Item(4, i).Value
                If IsNumeric(dgvData.Item(5, i).Value) Then
                    DebitAmount = dgvData.Item(5, i).Value.Replace(",", "")
                Else
                    DebitAmount = 0
                End If
                If IsNumeric(dgvData.Item(6, i).Value) Then
                    CreditAmount = dgvData.Item(6, i).Value.Replace(",", "")
                Else
                    CreditAmount = 0
                End If
                SQL.FlushParams()
                insertSQL = " INSERT INTO " & _
                            " view_GLBegBal (LineNumber, Book, JE_No, Ref_Type, Ref_TransID, AccntCode, AccntTitle, " & _
                            "                   Debit, Credit, Particulars, ApplicationDate, Remarks )" & _
                            " VALUES (@LineNumber, @Book, @JE_No, @Ref_Type, @Ref_TransID, @AccntCode, @AccntTitle, " & _
                            "         @Debit, @Credit, @Particulars, @ApplicationDate, @Remarks)"
                SQL.AddParam("@LineNumber", i)
                SQL.AddParam("@Book", "BB")
                SQL.AddParam("@JE_No", Year(dtpTo.Text) & Format(Month(dtpTo.Text) + 1, "00").ToString)
                SQL.AddParam("@Ref_Type", "BB")
                SQL.AddParam("@Ref_TransID", "0")
                SQL.AddParam("@AccntCode", GLAccount)
                SQL.AddParam("@AccntTitle", GLACCOUNTTITILE)
                SQL.AddParam("@Debit", DebitAmount)
                SQL.AddParam("@Credit", CreditAmount)
                SQL.AddParam("@Particulars", "BB")
                SQL.AddParam("@ApplicationDate", applydate)
                SQL.AddParam("@Remarks", "BB")
                SQL.ExecNonQuery(insertSQL)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmbFiscalOption(sender As System.Object, e As System.EventArgs) Handles cbFiscal.SelectedIndexChanged, cbMonth.SelectedIndexChanged
        If cbMonth.SelectedIndex <> -1 Then
            LoadPeriod()
        End If
    End Sub

    Private Sub rbDetailed_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbDetailed.CheckedChanged
        If rbDetailed.Checked = True Then
            rbRefID.Visible = True
        Else
            If rbRefID.Checked = True Then
                rbAccountCode.Checked = True
            End If
            rbRefID.Visible = False
        End If
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Try
            If ((dgvData.Columns.Count = 0) Or (dgvData.Rows.Count = 0)) Then
                MsgBox("No Records to Export!", MsgBoxStyle.Exclamation, "Message Alert")
            Else
                If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Export(FolderBrowserDialog1.SelectedPath)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Export(ByVal Path As String)
        Dim DSet As New DataSet
        DSet.Tables.Add()
        For i As Integer = 0 To dgvData.ColumnCount - 1
            DSet.Tables(0).Columns.Add(dgvData.Columns(i).HeaderText)
        Next
        'add rows to the table
        Dim row As DataRow
        For i As Integer = 0 To dgvData.RowCount - 1
            row = DSet.Tables(0).NewRow
            For j As Integer = 0 To dgvData.Columns.Count - 1
                row(j) = dgvData.Rows(i).Cells(j).Value
            Next
            DSet.Tables(0).Rows.Add(row)
        Next

        Dim excel As New Microsoft.Office.Interop.Excel.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = DSet.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            excel.Cells(1, colIndex) = dc.ColumnName
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        wSheet.Columns.AutoFit()
        Dim strFileName As String
        strFileName = FolderBrowserDialog1.SelectedPath & "\" & "ExtractedReport" & Date.Today.Month.ToString("00") & Date.Today.Day.ToString("00") & Date.Today.Year.ToString("00") & Now.Hour.ToString("00") & Now.Minute.ToString("00") & ".xls"

        Dim blnFileOpen As Boolean = False

        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If

        wBook.SaveAs(strFileName)
        excel.Workbooks.Open(strFileName)
        excel.Visible = True
        MsgBox("Exported Succesfully", MsgBoxStyle.Information, "Message Alert")
    End Sub

    Private Sub dgvData_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        Try
            If rbDetailed.Checked = True Then
                Dim RefType As String = dgvData.CurrentRow.Cells(9).Value.ToString
                Dim RefID As String = dgvData.CurrentRow.Cells(10).Value.ToString
                Select Case RefType
                    Case "CV"
                        Dim f As New frmCV
                        f.ShowDialog(RefID)
                        f.Dispose()
                    Case "JV"
                        Dim f As New frmJV
                        f.ShowDialog(RefID)
                        f.Dispose()
                    Case "OR"
                        Dim f As New frmCollection
                        f.ShowDialog(RefID)
                        f.Dispose()
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class