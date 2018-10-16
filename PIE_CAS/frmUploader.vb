Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data

Public Class frmUploader
    Public ModID As String
    Dim payDate As Date
    Dim payPeriod As String
    Dim count2 As Integer
    Dim ID As String
    Dim FileID As Integer = 0
    Dim count As Integer = 0
    Dim excelRangeCount As Integer = 0
    Dim path, Branch, Business As String
    Dim BranchName, Period As String
    Dim Valid As Boolean = True
    Dim Uploaded As Boolean = False
    Dim reportName As String  ' NAME OF REPORTS
    Dim currentBranch As String
    Dim currentDate As Date
    Dim currentVCE As String
    Dim currentTrans As String
    Dim excessCol As String
    Dim startIndex As Integer = 0

    Private Sub btnUpload_Click(sender As System.Object, e As System.EventArgs) Handles btnUpload.Click
        If btnUpload.Text = "Upload" Then
            Uploaded = False
            With (OpenFileDialog1)
                .InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                .Filter = "All Files|*.*|Excel Files|*.xls;*.xlsx"
                .FilterIndex = 2
            End With
            If ComboBox1.SelectedIndex = -1 Then
                Msg("Select report type!", MsgBoxStyle.Exclamation)
            ElseIf OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                If MessageBox.Show("Are you sure you want to Contiue?", "HRMS Message Alert", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    path = OpenFileDialog1.FileName
                    dgvTK.Rows.Clear()
                    dgvTK.Columns.Clear()
                    dgvSummary.Rows.Clear()
                    lblTime.Visible = True
                    pgbCounter.Visible = True
                    lblFile.Text = "File Name: " & path
                    reportName = ComboBox1.SelectedItem
                    Branch = Replace(cbBranch.SelectedItem, Strings.Left(cbBranch.SelectedItem, cbBranch.SelectedItem.ToString.IndexOf(" - ") + 3), "") ' GET SELECTED BRANCH
                    bgwUpload.RunWorkerAsync()
                    btnUpload.Text = "Cancel"
                End If
            End If


        Else
            If (bgwUpload.IsBusy = True) Then
                btnUpload.Text = "Upload"
                pgbCounter.Value = 0
                bgwUpload.CancelAsync()
            End If
        End If
    End Sub

     Private Sub LoadBranches()
        Dim query As String
        query = " SELECT BranchCode + ' - ' + Description AS BranchCode FROM tblBranch WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbBranch.Items.Clear()
        cbBranch.Items.Add("ALL - ALL BRANCHES")
        While SQL.SQLDR.Read
            cbBranch.Items.Add(SQL.SQLDR("BranchCode").ToString)
        End While
        cbBranch.SelectedItem = "ALL - ALL BRANCHES"
    End Sub

    Private Sub LoadBusinessType()
        Dim query As String
        query = " SELECT BusinessCode + ' - ' + Description AS BusinessCode FROM tblBusinessType WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbType.Items.Clear()
        While SQL.SQLDR.Read
            cbType.Items.Add(SQL.SQLDR("BusinessCode").ToString)
        End While
        cbType.SelectedIndex = 0
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwUpload.DoWork
        ' OPENING EXCEL FILE VARIABLES
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim Obj As Object
        Dim ObjChecker As Object
        Dim sheetName As String
        Dim range As Excel.Range

        ' REMAINING TIME LABEL AND PROGRESSBAR VARIABLE
        Dim startTime, prevTime, endTime As DateTime
        Dim startProcess, endProcess, processed As Integer
        Dim start As Boolean = False
        Dim timeSpent As TimeSpan
        Dim remainTime As Integer
        Dim stopper As Decimal

        ' OPEN EXCEL FILE
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(path)
        sheetName = xlWorkBook.Worksheets(1).Name.ToString
        xlWorkSheet = xlWorkBook.Worksheets(sheetName)
        range = xlWorkSheet.UsedRange

        Valid = True

        Dim summary As Boolean = False
        Dim rowCount As Integer = 0
        Dim rowSumCount As Integer = 0
        Dim report As String = ""

        ' GET REPORT NAME
        If reportName = "Sales Book Journal Report" OrElse reportName = "Cash Receipts Book Summary 2" Then
            Obj = CType(range.Cells(2, 1), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                report = Obj.value.ToString
            End If

            ' GET BRANCH NAME
            Obj = CType(range.Cells(3, 1), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                BranchName = Obj.value.ToString
            End If

            ' GET REPORT PERIOD
            Obj = CType(range.Cells(4, 1), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                Period = Obj.value.ToString
            End If

            excessCol = 0
            startIndex = 8
        ElseIf reportName = "ACCOUNTS PAYABLE   REGISTER" Then
            Obj = CType(range.Cells(9, 5), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                report = Obj.value.ToString
            End If

            BranchName = "ALL BRANCHES"

            ' GET REPORT PERIOD
            Obj = CType(range.Cells(11, 5), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                Period = Obj.value.ToString
            End If

            startIndex = 19
            excessCol = 1
        ElseIf reportName = "CASH VOUCHER- EXPENSE REPORT" Then
            Obj = CType(range.Cells(11, 8), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                report = Obj.value.ToString
            End If

            BranchName = "ALL BRANCHES"

            ' GET REPORT PERIOD
            Obj = CType(range.Cells(13, 8), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                Period = Obj.value.ToString
            End If

            startIndex = 21
            excessCol = 1
        ElseIf reportName = "CHECK VOUCHER-  EXPENSE REPORT" Then
            Obj = CType(range.Cells(13, 8), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                report = Obj.value.ToString
            End If

            BranchName = "ALL BRANCHES"

            ' GET REPORT PERIOD
            Obj = CType(range.Cells(15, 8), Excel.Range)
            If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                Period = Obj.value.ToString
            End If

            startIndex = 28
            excessCol = 1
        End If

        SetPGBmax(range.Rows.Count - startIndex)  ' SET PROGRESS BAR MAX VALUE
        excelRangeCount = range.Rows.Count

        If reportName <> report Then ' VERIFY IF FILES IS ALREADY UPLOADED
            Msg("Selected File Invalid! " & vbNewLine & " Selected File: " & report & vbNewLine & "Should be: " & reportName, MsgBoxStyle.Exclamation)
        ElseIf FileUploaded() Then
            Uploaded = True
            e.Cancel = True
        Else
            ' LOOP THROUGH ROWS OF EXCEL
            For i As Integer = startIndex To range.Rows.Count

                If bgwUpload.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If

                ' GET START TIME OF CURRENT LOOP 
                If start = False Then
                    startTime = DateTime.Now
                    startProcess = i
                    start = True
                End If
                prevTime = DateTime.Now
                Dim maxCol As Integer = range.Columns.Count - excessCol - 1

                ' LOOP THROUGH COLUMNS OF EXCEL
                For j As Integer = 0 To maxCol
                    Obj = CType(range.Cells(i, j + 1), Excel.Range)


                    If reportName = "Sales Book Journal Report" Then
                        If j = 0 AndAlso (Obj.value Is Nothing OrElse Obj.value.ToString = "") Then ' EXIT LOOP IF FIRST COLUMN OF CURRENT ROW IS BLANK
                            Exit For
                        ElseIf Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                            If i = 8 Then
                                If j = 0 Then
                                    AddColumn("Branch")
                                End If
                                AddColumn(Obj.value)
                            ElseIf i > 8 Then
                                If j = 0 Then
                                    If BranchExist(Obj.value.ToString) AndAlso Branch = "ALL BRANCHES" Then '  IF FIRST COLUMN IS BRANCHNAME AND ALL BRANCHES IS SELECTED
                                        currentBranch = Obj.value.ToString
                                        Exit For
                                    ElseIf IsNumeric(Obj.value) Then '  IF FIRST COLUMN IS INVOICE NUMBER
                                        AddRow()
                                        rowCount += 1
                                        SetCounterValue(rowCount)
                                    Else
                                        Exit For
                                    End If
                                ElseIf j = 1 AndAlso Not IsDate(Obj.value) Then
                                    ' CHANGE CELL COLOR IF INVOICE DATE IS NOT IN DATE FORMAT
                                    ChangeCellColor(rowCount - 1, j + 1)
                                    Valid = False
                                ElseIf j > 8 AndAlso Not IsNumeric(Obj.value) Then
                                    ChangeCellColor(rowCount - 1, j + 1)
                                    Valid = False
                                End If
                                If j = 0 Then
                                    AddValue(currentBranch, rowCount - 1, j)
                                    AddValue(Obj.value, rowCount - 1, j + 1)
                                Else
                                    AddValue(Obj.value, rowCount - 1, j + 1)
                                End If
                            End If
                        End If
                    ElseIf reportName = "Cash Receipts Book Summary 2" Then
                        If j = 0 AndAlso (Obj.value Is Nothing OrElse Obj.value.ToString = "") Then ' EXIT LOOP IF FIRST COLUMN OF CURRENT ROW IS BLANK
                            Exit For
                        ElseIf Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                            If i = 8 Then
                                If j = 0 Then
                                    AddColumn("Branch")
                                End If
                                AddColumn(Obj.value)
                            ElseIf i > 8 Then
                                If j = 0 Then
                                    If BranchExist(Obj.value.ToString) AndAlso Branch = "ALL BRANCHES" Then '  IF FIRST COLUMN IS BRANCHNAME AND ALL BRANCHES IS SELECTED
                                        currentBranch = Obj.value.ToString
                                        Exit For
                                    ElseIf IsDate(Obj.value) Then '  IF FIRST COLUMN IS TRANS DATE
                                        AddRow()
                                        rowCount += 1
                                        SetCounterValue(rowCount)
                                    Else
                                        Exit For
                                    End If
                                ElseIf j = 0 AndAlso Not IsDate(Obj.value) Then
                                    ' CHANGE CELL COLOR IF TRANS DATE IS NOT IN DATE FORMAT
                                    ChangeCellColor(rowCount - 1, j)
                                    Valid = False
                                ElseIf j = 2 AndAlso Not IsNumeric(Obj.Value) Then
                                    ChangeCellColor(rowCount - 1, 2)
                                    Valid = False
                                ElseIf j > range.Columns.Count - 11 AndAlso j < range.Columns.Count - 1 AndAlso Not IsNumeric(Obj.value) Then
                                    ChangeCellColor(rowCount - 1, j)
                                    Valid = False
                                End If
                                If j = 0 Then
                                    AddValue(currentBranch, rowCount - 1, j)
                                    AddValue(Obj.value, rowCount - 1, j + 1)
                                Else
                                    AddValue(Obj.value, rowCount - 1, j + 1)
                                End If
                            End If
                        End If
                    ElseIf reportName = "ACCOUNTS PAYABLE   REGISTER" Then
                        If i = startIndex Then
                            If j = 0 Then
                                AddColumn("Branch")
                            End If
                            AddColumn(Obj.value)
                            If j = 4 Then
                                AddColumn("VAT INPUT")
                                AddColumn("ACCRUED EXPENSE")
                                AddColumn("W/HOLDING TAX")
                                AddColumn("VP SUPPLIER")
                                Exit For
                            End If
                        ElseIf i > startIndex Then
                            If j = 0 Then
                                '  IF THE CURRENT LINE IS TOTAL THEN EXIT LOOP
                                ObjChecker = CType(range.Cells(i, 3), Excel.Range)
                                If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" AndAlso ObjChecker.value.ToString <> "-DO-" Then
                                    If ObjChecker.value.ToString = "TOTAL:" Then
                                        Exit For
                                    End If
                                End If


                                If IsDate(Obj.value) Then '  IF FIRST COLUMN IS TRANS DATE
                                    currentDate = CDate(Obj.value)
                                    AddRow()
                                    rowCount += 1
                                    SetCounterValue(rowCount)
                                Else
                                    ObjChecker = CType(range.Cells(i, 3), Excel.Range)
                                    If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                        currentDate = currentDate
                                        AddRow()
                                        rowCount += 1
                                        SetCounterValue(rowCount)
                                    Else
                                        Exit For
                                    End If
                                End If
                                ' GET CURRENT TRANS
                                ObjChecker = CType(range.Cells(i, 2), Excel.Range)
                                If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                    currentTrans = ObjChecker.value.ToString
                                End If
                                ' GET CURRENT CODE
                                ObjChecker = CType(range.Cells(i, 3), Excel.Range)
                                If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" AndAlso ObjChecker.value.ToString <> "-DO-" Then
                                    If ObjChecker.value.ToString = "TOTAL:" Then
                                        Exit For
                                    End If
                                    currentVCE = ObjChecker.value.ToString
                                End If

                            ElseIf j = 2 AndAlso Not IsNothing(Obj.Value) Then
                                If Obj.Value.ToString <> "CANCELLED" Then
                                    If Obj.Value.ToString = "-DO-" Then
                                        If Not VCENameexist(currentVCE) Then
                                            ChangeCellColor(rowCount - 1, j + 1)
                                            Valid = False
                                        End If
                                    Else

                                        If Not VCENameexist(Obj.Value.ToString) Then
                                            ChangeCellColor(rowCount - 1, j + 1)
                                            Valid = False
                                        End If
                                    End If
                                End If

                            ElseIf j > 4 AndAlso Not IsNumeric(Obj.Value) Then
                                If IsNothing(Obj.Value) Then
                                    Obj.Value = 0
                                Else
                                    ChangeCellColor(rowCount - 1, j + 1)
                                    Valid = False
                                End If
                            End If
                            If j = 0 Then
                                AddValue(Branch, rowCount - 1, j)
                                If IsDate(Obj.value) Then
                                    AddValue(Obj.value, rowCount - 1, j + 1)
                                Else
                                    ObjChecker = CType(range.Cells(i, 3), Excel.Range)
                                    If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                        AddValue(currentDate, rowCount - 1, j + 1)
                                    Else
                                        Exit For
                                    End If
                                End If

                            ElseIf j = 1 Then
                                If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                                    AddValue(Obj.value.ToString, rowCount - 1, j + 1)
                                Else
                                    AddValue(currentTrans, rowCount - 1, j + 1)
                                End If
                            ElseIf j = 2 Then
                                If Obj.value.ToString = "TOTAL:" Then
                                    Exit For
                                End If
                                If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" AndAlso Obj.value.ToString <> "-DO-" Then
                                    AddValue(Obj.value.ToString, rowCount - 1, j + 1)
                                Else
                                    AddValue(currentVCE, rowCount - 1, j + 1)
                                End If
                            Else
                                AddValue(Obj.value, rowCount - 1, j + 1)
                            End If
                        End If
                    ElseIf reportName = "CASH VOUCHER- EXPENSE REPORT" Or reportName = "CHECK VOUCHER-  EXPENSE REPORT" Then
                        If i = startIndex Then
                            If j = 0 Then
                                AddColumn("Branch")
                            End If
                            AddColumn(Obj.value)
                            If j = 2 Then

                                AddColumn("ADVANCES-OFF/EMP")
                                AddColumn("ADVANCES-CAVITE")
                                AddColumn("ADVANCES-METRO")
                                AddColumn("ADVANCES-DAPITAN")
                                AddColumn("ADVANCES-CDO")
                                AddColumn("ADVANCES-LEGAZPI")
                                AddColumn("ACCRUED EXPENSE")
                                If reportName = "CASH VOUCHER- EXPENSE REPORT" Then
                                    AddColumn("CASH ON HAND")
                                Else
                                    AddColumn("REFERENCE")
                                End If

                                AddColumn("SUNDRIES-ACCOUNT TITLE")
                                AddColumn("DEBIT")
                                AddColumn("CREDIT")
                                Exit For
                            End If
                        ElseIf i > startIndex Then
                            ' IF CURRENT ROW IS SUMMARY
                            If summary = True Then
                                If j = 0 Then
                                    If Not IsNothing(Obj.value) Then '  IF FIRST COLUMN IS NOT BLANK
                                        '  IF ROW IS NOT BLANK
                                        ObjChecker = CType(range.Cells(i, 2), Excel.Range)
                                        If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                            AddRowSummary()
                                            rowSumCount += 1
                                            AddValueSummary(Obj.value, rowSumCount - 1, j)
                                        Else
                                            Exit For
                                        End If
                                    Else
                                        ' IF ROW IS TOTAL
                                        ObjChecker = CType(range.Cells(i, 4), Excel.Range)
                                        If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString = "Total:" Then
                                            AddRowSummary()
                                            rowSumCount += 1
                                            AddValueSummary("TOTAL", rowSumCount - 1, j)
                                        Else
                                            Exit For
                                        End If
                                    End If
                                ElseIf j = 1 Then
                                    AddValueSummary(Obj.value, rowSumCount - 1, j)
                                ElseIf reportName = "CHECK VOUCHER-  EXPENSE REPORT" And (j = 4 Or j = 6) Then
                                    If j = 4 Then
                                        If Obj.value Is Nothing Then
                                            AddValueSummary(0, rowSumCount - 1, j - 2)
                                        Else
                                            AddValueSummary(Obj.value, rowSumCount - 1, j - 2)
                                        End If
                                    Else
                                        If Obj.value Is Nothing Then
                                            AddValueSummary(0, rowSumCount - 1, j - 3)
                                        Else
                                            AddValueSummary(Obj.value, rowSumCount - 1, j - 3)
                                        End If
                                    End If
                                   

                                ElseIf reportName = "CASH VOUCHER- EXPENSE REPORT" And (j = 4 Or j = 5) Then
                                    If Obj.value Is Nothing Then
                                        AddValueSummary(0, rowSumCount - 1, j - 2)
                                    Else
                                        AddValueSummary(Obj.value, rowSumCount - 1, j - 2)
                                    End If

                                End If

                            Else
                                ' IF NOT YET SUMMARY 
                                If j = 0 Then
                                    '  IF THE CURRENT LINE IS TOTAL THEN EXIT LOOP
                                    ObjChecker = CType(range.Cells(i, 1), Excel.Range)
                                    If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                        If ObjChecker.value.ToString = "Code" Then
                                            summary = True
                                            Exit For
                                        End If
                                    End If


                                    If IsDate(Obj.value) Then '  IF FIRST COLUMN IS TRANS DATE
                                        currentDate = CDate(Obj.value)
                                        AddRow()
                                        rowCount += 1
                                        SetCounterValue(rowCount)
                                    Else
                                        ObjChecker = CType(range.Cells(i, 2), Excel.Range)
                                        If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                            currentDate = currentDate
                                            AddRow()
                                            rowCount += 1
                                            SetCounterValue(rowCount)
                                        Else
                                            Exit For
                                        End If
                                    End If
                                    ' GET CURRENT TRANS
                                    ObjChecker = CType(range.Cells(i, 2), Excel.Range)
                                    If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                        currentTrans = ObjChecker.value.ToString
                                    End If
                                    ' GET CURRENT CODE
                                    ObjChecker = CType(range.Cells(i, 3), Excel.Range)
                                    If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" AndAlso ObjChecker.value.ToString <> "-DO-" Then
                                        If ObjChecker.value.ToString = "TOTAL:" Then
                                            Exit For
                                        End If
                                        currentVCE = ObjChecker.value.ToString
                                    End If

                                ElseIf j = 2 AndAlso Not IsNothing(Obj.Value) Then
                                    If Obj.Value.ToString <> "CANCELLED" Then
                                        If Obj.Value.ToString = "-DO-" Then
                                            If Not VCENameexist(currentVCE) Then
                                                ChangeCellColor(rowCount - 1, j + 1)
                                                Valid = False
                                            End If
                                        Else

                                            If Not VCENameexist(Obj.Value.ToString) Then
                                                ChangeCellColor(rowCount - 1, j + 1)
                                                Valid = False
                                            End If
                                        End If
                                    End If

                                ElseIf j >= 3 AndAlso j <> 11 AndAlso Not IsNumeric(Obj.Value) Then
                                    If reportName = "CHECK VOUCHER-  EXPENSE REPORT" And j = 10 Then
                                        
                                    Else
                                        If IsNothing(Obj.Value) Then
                                            Obj.Value = 0
                                        Else
                                            ChangeCellColor(rowCount - 1, j + 1)
                                            Valid = False
                                        End If
                                    End If
                                End If
                                If j = 0 Then
                                    AddValue(Branch, rowCount - 1, j)
                                    If IsDate(Obj.value) Then
                                        AddValue(Obj.value, rowCount - 1, j + 1)
                                    Else
                                        ObjChecker = CType(range.Cells(i, 2), Excel.Range)
                                        If Not ObjChecker.value Is Nothing AndAlso ObjChecker.value.ToString <> "" Then
                                            AddValue(currentDate, rowCount - 1, j + 1)
                                        Else
                                            Exit For
                                        End If
                                    End If

                                ElseIf j = 1 Then
                                    If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" Then
                                        AddValue(Obj.value.ToString, rowCount - 1, j + 1)
                                    Else
                                        AddValue(currentTrans, rowCount - 1, j + 1)
                                    End If
                                ElseIf j = 2 Then
                                    If Not Obj.value Is Nothing AndAlso Obj.value.ToString = "TOTAL:" Then
                                        Exit For
                                    End If
                                    If Not Obj.value Is Nothing AndAlso Obj.value.ToString <> "" AndAlso Obj.value.ToString <> "-DO-" Then
                                        AddValue(Obj.value.ToString, rowCount - 1, j + 1)
                                    Else
                                        AddValue(currentVCE, rowCount - 1, j + 1)
                                    End If
                                Else
                                    AddValue(Obj.value, rowCount - 1, j + 1)
                                End If
                            End If
                        End If
                    End If

                Next
                bgwUpload.ReportProgress(i)
                timeSpent = DateTime.Now - prevTime
                stopper += timeSpent.TotalSeconds
                If stopper > 3 Then
                    endTime = DateTime.Now
                    endProcess = i
                    timeSpent = endTime - startTime
                    processed = endProcess - startProcess
                    If processed > 0 Then
                        remainTime = (timeSpent.TotalSeconds / processed) * (range.Rows.Count - i)
                        SetRemainingTime(remainTime)
                        stopper = 0
                    End If
                End If
            Next
        End If
        NAR(Obj)
        NAR(range)
        NAR(xlWorkSheet)
        xlWorkBook.Close(False)
        NAR(xlWorkBook)
        xlApp.Quit()
        NAR(xlApp)
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Function BranchExist(ByVal BranchName As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblBranch WHERE Description = @Description "
        SQL.FlushParams()
        SQL.AddParam("@Description", BranchName)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
        SQL.FlushParams()
    End Function

    Private Delegate Sub AddValueInvoker(ByVal Value As String, ByVal row As Integer, ByVal col As Integer)
    Private Sub AddValue(ByVal Value As String, ByVal row As Integer, ByVal col As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New AddValueInvoker(AddressOf AddValue), Value, row, col)
        Else
            dgvTK.Item(col, row).Value = Value
        End If
    End Sub

    Private Delegate Sub AddValueSummaryInvoker(ByVal Value As String, ByVal row As Integer, ByVal col As Integer)
    Private Sub AddValueSummary(ByVal Value As String, ByVal row As Integer, ByVal col As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New AddValueSummaryInvoker(AddressOf AddValueSummary), Value, row, col)
        Else
            dgvSummary.Item(col, row).Value = Value
        End If
    End Sub

    Private Delegate Sub ChangeCellColorInvoker(ByVal row As Integer, ByVal col As Integer)
    Private Sub ChangeCellColor(ByVal row As Integer, ByVal col As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeCellColorInvoker(AddressOf ChangeCellColor), row, col)
        Else
            dgvTK.Rows(row).Cells(col).Style.BackColor = Color.Yellow
        End If
    End Sub

    Private Delegate Sub AddColumnInvoker(ByVal Value As String)
    Private Sub AddColumn(ByVal Value As String)
        If Me.InvokeRequired Then
            Me.Invoke(New AddColumnInvoker(AddressOf AddColumn), Value)
        Else
            dgvTK.Columns.Add("", Value)
        End If
    End Sub


    Private Sub SetDefaultBranch()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf SetDefaultBranch))
        Else
            Branch = Strings.Left(cbBranch.SelectedItem, cbBranch.SelectedItem.ToString.IndexOf(" - "))
        End If
    End Sub

    Private Sub AddRowSummary()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AddRowSummary))
        Else
            dgvSummary.Rows.Add("")
        End If
    End Sub

    Private Sub AddRow()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AddRow))
        Else
            dgvTK.Rows.Add("")
        End If
    End Sub

    Private Delegate Sub SetPGBmaxInvoker(ByVal Value As String)
    Private Sub SetPGBmax(ByVal Value As String)
        If Me.InvokeRequired Then
            Me.Invoke(New SetPGBmaxInvoker(AddressOf SetPGBmax), Value)
        Else
            pgbCounter.Maximum = Value
            pgbCounter.Value = 0
        End If
    End Sub

    Private Delegate Sub SetCounterValueInvoker(ByVal Value As String)
    Private Sub SetCounterValue(ByVal Value As String)
        If Me.InvokeRequired Then
            Me.Invoke(New SetCounterValueInvoker(AddressOf SetCounterValue), Value)
        Else
            lblCount.Text = "Record Count : " & Value
        End If
    End Sub

    Private Delegate Sub SetRemainingTimeInvoker(ByVal Value As String)
    Private Sub SetRemainingTime(ByVal Value As String)
        If Me.InvokeRequired Then
            Me.Invoke(New SetRemainingTimeInvoker(AddressOf SetRemainingTime), Value)
        Else
            Dim second As Integer
            If Value > 60 Then
                Dim mins As Integer = Value / 60.0
                If mins > 60 Then
                    Dim hrs As Integer = Value / 3600.0
                    mins = (Value - (hrs * 3600)) / 60.0
                    If hrs = 1 Then
                        lblTime.Text = "Time Remaining : About 1 hour and " & mins & " minutes "
                    Else
                        lblTime.Text = "Time Remaining : About " & hrs & " hours and " & mins & " minutes"
                    End If
                Else
                    If mins = 1 Then
                        lblTime.Text = "Time Remaining : About 1 minute"
                    Else
                        lblTime.Text = "Time Remaining : About " & mins & " minutes"
                    End If
                End If
            ElseIf Value >= 10 Then
                second = Value / 5
                second = second * 5
                lblTime.Text = "Time Remaining : About " & second & " seconds"
            ElseIf Value = 1 Then
                lblTime.Text = "Time Remaining : About 1 second"
            Else
                lblTime.Text = "Time Remaining : About " & Value & " seconds"
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwUpload.ProgressChanged
        pgbCounter.Value = e.ProgressPercentage - startIndex
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwUpload.RunWorkerCompleted
        lblTime.Visible = False
        pgbCounter.Visible = False
        lblCount.Text = "Record Count : " & dgvTK.Rows.Count
        lblFile.Text = ""
        If Uploaded Then
            Msg("This file was uploaded already!", MsgBoxStyle.Exclamation)
        Else
            If Valid Then
                MsgBox(dgvTK.Rows.Count & " Records Uploaded Successfully!", vbInformation, "JADE Message Alert")
                btnSave.Enabled = True
            Else
                MsgBox("Some Records are not valid for upload, Please see highlighted cells!", MsgBoxStyle.Exclamation, "JADE Message Alert")
                btnSave.Enabled = False
            End If
        End If
        btnUpload.Text = "Upload"
    End Sub

    Private Sub NAR(ByRef o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If FileUploaded() Then
            Msg("This File is already uploaded!", MsgBoxStyle.Exclamation)
        ElseIf cbType.SelectedIndex = -1 Then
            MsgBox("Please Select Business Type first!", MsgBoxStyle.Exclamation)
        ElseIf cbBranch.SelectedIndex = -1 Then
            MsgBox("Please select Branch", MsgBoxStyle.Exclamation)
        Else
            Branch = Strings.Left(cbBranch.SelectedItem, cbBranch.SelectedItem.ToString.IndexOf(" - "))
            Business = Strings.Left(cbType.SelectedItem, cbType.SelectedItem.ToString.IndexOf(" - "))
            lblTime.Visible = True
            pgbCounter.Visible = True
            InsertUploadDetail(BranchName, Period, excelRangeCount)
            bgwSave.RunWorkerAsync()
            btnSave.Enabled = False
        End If
    End Sub


    Private Function VCEexist(ByVal Code As String) As Boolean
        Try
            Dim query As String
            query = " SELECT VCECode FROM tblVCE_Master WHERE VCECode = @VCECode  "
            SQL.FlushParams()
            SQL.AddParam("@VCECode", Code)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Private Function VCENameexist(ByVal Name As String) As Boolean
        Try
            Dim query As String
            query = " SELECT VCECode FROM tblVCE_Master WHERE VCEName = @VCEName  "
            SQL.FlushParams()
            SQL.AddParam("@VCEName", Name)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Private Function SIexist(ByVal TransID As String) As Boolean
        Try
            Dim query As String
            query = " SELECT SI_No FROM tblSI WHERE SI_No = @SI_No  "
            SQL.FlushParams()
            SQL.AddParam("@SI_No", TransID)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Private Function APVexist(ByVal TransID As String) As Boolean
        Try
            Dim query As String
            query = " SELECT APV_No FROM tblAPV WHERE APV_No = @APV_No  "
            SQL.FlushParams()
            SQL.AddParam("@APV_No", TransID)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Private Function CVexist(ByVal TransID As String) As Boolean
        Try
            Dim query As String
            query = " SELECT CV_No FROM tblCV WHERE CV_No = @CV_No  "
            SQL.FlushParams()
            SQL.AddParam("@CV_No", TransID)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Private Function CollectionExist(ByVal Type As String, ByVal TransID As String) As Boolean
        Try
            Dim query As String
            query = " SELECT TransID FROM tblCollection WHERE TransType = @TransType AND TransNo =  @TransNo "
            SQL.FlushParams()
            SQL.AddParam("@TransNo", TransID)
            SQL.AddParam("@TransType", Type)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Private Sub InsertVCE(ByVal Code As String, ByVal Name As String, Level As String)
        Try
            Dim query As String
            query = " INSERT INTO " & _
                    " tblVCE_Master(VCECode, VCEName, isCustomer, VAT_Code, WTax_Code, DealerLevel) " & _
                    " VALUES(@VCECode, @VCEName, @isCustomer, @VAT_Code, @WTax_Code, @DealerLevel) "
            SQL.FlushParams()
            SQL.AddParam("@VCECode", Code)
            SQL.AddParam("@VCEName", Name)
            SQL.AddParam("@isCustomer", True)
            SQL.AddParam("@VAT_Code", "T0")
            SQL.AddParam("@WTax_Code", "W0")
            SQL.AddParam("@DealerLevel", Level)
            SQL.ExecNonQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub InsertUploadDetail(ByVal Branch As String, Period As String, ByVal RowCount As Decimal)
        Try
            FileID = GenerateTransID("TransID", "tblUploadHistory")
            Dim query As String
            query = " INSERT INTO " & _
                    " tblUploadHistory(TransID, ReportType, Branch, Period, RowCounter,  WhoCreated) " & _
                    " VALUES(@TransID, @ReportType, @Branch, @Period, @RowCounter, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", FileID)
            SQL.AddParam("@ReportType", reportName)
            SQL.AddParam("@Branch", Branch)
            SQL.AddParam("@Period", Period)
            SQL.AddParam("@RowCounter", RowCount)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub InsertSI(ByVal TransID As Integer, TransNo As String, ByVal DateSI As Date, VCE As String, Gross As Decimal, VAT As Decimal, Discount As Decimal, Net As Decimal, Ref As String)
        Try
            Dim query As String
            query = " INSERT INTO " & _
                    " tblSI(TransID, SI_No, SI_Ref, DateSI, VCECode, GrossAmount, VATAmount, Discount, NetAmount, Ref_No, BranchCode, BusinessCode, UploadID, WhoCreated) " & _
                    " VALUES(@TransID, @SI_No, @SI_Ref, @DateSI, @VCECode, @GrossAmount, @VATAmount, @Discount, @NetAmount, @Ref_No, @BranchCode, @BusinessCode, @UploadID, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@SI_No", TransNo)
            SQL.AddParam("@SI_Ref", "SI")
            SQL.AddParam("@DateSI", DateSI)
            SQL.AddParam("@VCECode", VCE)
            SQL.AddParam("@GrossAmount", Gross)
            SQL.AddParam("@VATAmount", VAT)
            SQL.AddParam("@Discount", Discount)
            SQL.AddParam("@NetAmount", Net)
            SQL.AddParam("@Ref_No", Ref)
            SQL.AddParam("@BranchCode", Branch)
            SQL.AddParam("@BusinessCode", Business)
            SQL.AddParam("@UploadID", FileID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub InsertAPV(ByVal TransID As Integer, TransNo As String, ByVal DateAPV As Date, VCE As String, Gross As Decimal, VAT As Decimal, Discount As Decimal, WTax As Decimal, Net As Decimal)
        Try
            Dim query As String
            query = " INSERT INTO " & _
                    " tblAPV(TransID, APV_No, DateAPV, VCECode, Amount, InputVAT, WTax, Discount, NetPurchase, BranchCode, BusinessCode, UploadID, WhoCreated) " & _
                    " VALUES(@TransID, @APV_No, @DateAPV, @VCECode, @Amount, @InputVAT, @WTax, @Discount, @NetPurchase, @BranchCode, @BusinessCode, @UploadID, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@APV_No", TransNo)
            SQL.AddParam("@DateAPV", DateAPV)
            SQL.AddParam("@VCECode", VCE)
            SQL.AddParam("@Amount", Gross)
            SQL.AddParam("@InputVAT", VAT)
            SQL.AddParam("@WTax", WTax)
            SQL.AddParam("@Discount", Discount)
            SQL.AddParam("@NetPurchase", Net)
            SQL.AddParam("@BranchCode", Branch)
            SQL.AddParam("@BusinessCode", Business)
            SQL.AddParam("@UploadID", FileID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub InsertCV(ByVal TransID As Integer, TransNo As String, ByVal DateCV As Date, VCE As String, Amount As Decimal)
        Try
            Dim query As String
            query = " INSERT INTO " & _
                    " tblCV(TransID, CV_No, DateCV, VCECode, TotalAmount,  BranchCode, BusinessCode, UploadID, WhoCreated) " & _
                    " VALUES(@TransID, @CV_No, @DateCV, @VCECode, @TotalAmount, @BranchCode, @BusinessCode, @UploadID, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@CV_No", TransNo)
            SQL.AddParam("@DateCV", DateCV)
            SQL.AddParam("@VCECode", VCE)
            SQL.AddParam("@TotalAmount", Amount)
            SQL.AddParam("@BranchCode", Branch)
            SQL.AddParam("@BusinessCode", Business)
            SQL.AddParam("@UploadID", FileID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub InsertCollection(ByVal TransID As Integer, TransType As String, TransNo As String, ByVal DateTrans As Date, VCE As String, Amount As Decimal, CheckRef As String, BankRef As String, CheckDate As String)
        Try
            Dim query As String
            query = " INSERT INTO " & _
                    " tblCollection(TransID, TransType, TransNo, DateTrans, PaymentType, VCECode, Amount, CheckRef, BankRef, CheckDate, Remarks, BranchCode, BusinessCode, UploadID, WhoCreated) " & _
                    " VALUES(@TransID, @TransType, @TransNo, @DateTrans, @PaymentType, @VCECode, @Amount, @CheckRef, @BankRef, @CheckDate, @Remarks, @BranchCode, @BusinessCode, @UploadID, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@TransType", TransType)
            SQL.AddParam("@TransNo", TransNo)
            SQL.AddParam("@DateTrans", DateTrans)
            If CheckRef = "" Then
                SQL.AddParam("@PaymentType", "Cash")
            Else
                SQL.AddParam("@PaymentType", "Check")
            End If
            SQL.AddParam("@VCECode", VCE)
            SQL.AddParam("@Amount", Amount)
            SQL.AddParam("@CheckRef", CheckRef)
            SQL.AddParam("@BankRef", BankRef)
            If CheckDate = "" Then
                SQL.AddParam("@CheckDate", DBNull.Value)
            Else
                SQL.AddParam("@CheckDate", CheckDate)
            End If
            SQL.AddParam("@Remarks", "")
            SQL.AddParam("@BranchCode", Branch)
            SQL.AddParam("@BusinessCode", Business)
            SQL.AddParam("@UploadID", FileID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub InsertSIDetails(ByVal TransID As String, ByVal Description As String, Gross As Decimal, VAT As Decimal, Discount As Decimal, DiscountRate As Decimal, Net As Decimal)
        Try
            Dim query As String
            query = " INSERT INTO " & _
                    " tblSI_Details(TransID, Description, UOM, QTY, UnitPrice, GrossAmount, VATAmount, DiscountRate, Discount, NetAmount) " & _
                    " VALUES(@TransID, @Description, @UOM, @QTY, @UnitPrice, @GrossAmount, @VATAmount, @DiscountRate, @Discount, @NetAmount) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@Description", Description)
            SQL.AddParam("@UOM", "EA")
            SQL.AddParam("@QTY", 1)
            SQL.AddParam("@UnitPrice", Gross)
            SQL.AddParam("@GrossAmount", Gross)
            SQL.AddParam("@VATAmount", VAT)
            SQL.AddParam("@Discount", Discount)
            SQL.AddParam("@DiscountRate", DiscountRate)
            SQL.AddParam("@NetAmount", Net)
            SQL.ExecNonQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub UpdateTotals(ByVal ID As Integer)
        If reportName = "Sales Book Journal Report" Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblSI " & _
                        " SET GrossAmount = A.GrossAmount, " & _
                        " 	VATAmount = A.VATAmount,  " & _
                        " 	Discount = A.Discount,  " & _
                        " 	NetAmount = A.NetAmount " & _
                        " FROM " & _
                        " ( " & _
                        " SELECT  TransID, " & _
                        " 		ISNULL(SUM(GrossAmount),0) AS GrossAmount,  " & _
                        " 		ISNULL(SUM(VATAmount),0) AS VATAmount,  " & _
                        " 		ISNULL(SUM(Discount),0) AS Discount,  " & _
                        " 		ISNULL(SUM(NetAmount),0) AS NetAmount   " & _
                        " FROM	tblSI_Details  " & _
                        " WHERE TransID = '" & ID & "' " & _
                        " GROUP BY TransID " & _
                        " ) AS A  " & _
                        " WHERE tblSI.TransID = A.TransID "
            SQL.ExecNonQuery(updateSQL)
        End If

    End Sub

    Private Sub SaveEntry(ByVal TransID As Integer, DateSI As Date, TotalAmount As Decimal, Type As String, Book As String)
        Dim insertSQL As String

        insertSQL = " INSERT INTO " & _
                    " tblJE_Header (AppDate, BranchCode, BusinessCode, RefType, RefTransID, Book, TotalDBCR, Remarks, WhoCreated) " & _
                    " VALUES(@AppDate, @BranchCode, @BusinessCode, @RefType, @RefTransID, @Book, @TotalDBCR, @Remarks, @WhoCreated)"
        SQL.FlushParams()
        SQL.AddParam("@AppDate", DateSI)
        SQL.AddParam("@RefType", Type)
        SQL.AddParam("@RefTransID", TransID)
        SQL.AddParam("@Book", Book)
        SQL.AddParam("@TotalDBCR", TotalAmount)
        SQL.AddParam("@Remarks", "")
        SQL.AddParam("@BranchCode", Branch)
        SQL.AddParam("@BusinessCode", Business)
        SQL.AddParam("@WhoCreated", UserID)
        SQL.ExecNonQuery(insertSQL)

    End Sub



    Private Sub UpdateEntry(ByVal JEID As Integer, TotalAmount As Decimal)
        Dim updateSQL As String

        updateSQL = " UPDATE tblJE_Header " & _
                    " SET    TotalDBCR = TotalDBCR + @TotalDBCR  " & _
                    " WHERE  JE_No = @JE_No "
        SQL.FlushParams()
        SQL.AddParam("@JE_No", JEID)
        SQL.AddParam("@TotalDBCR", TotalAmount)
        SQL.ExecNonQuery(updateSQL)
    End Sub

    Private Sub SaveEntryDetails(JE As Integer, AccntCode As String, VCE As String, Debit As Decimal, Credit As Decimal, Particulars As String, Optional RefNo As String = "")
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber) " & _
                    " VALUES(@JE_No, @AccntCode, @VCECode, @Debit, @Credit, @Particulars, @RefNo, @LineNumber)"
        SQL.FlushParams()
        SQL.AddParam("@JE_No", JE)
        SQL.AddParam("@AccntCode", AccntCode)
        SQL.AddParam("@VCECode", VCE)
        SQL.AddParam("@Debit", Debit)
        SQL.AddParam("@Credit", Credit)
        SQL.AddParam("@Particulars", Particulars)
        SQL.AddParam("@RefNo", RefNo)
        SQL.AddParam("@LineNumber", 0)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Function LoadCode(ByVal Title As String) As String
        Dim code As String = ""
        Dim code2 As String = ""
        For Each row As DataGridViewRow In dgvSummary.Rows
            If row.Cells(1).Value = Title Then
                code = row.Cells(0).Value.ToString
            End If
            If Strings.Left(row.Cells(1).Value, Title.Length) = Title Then
                code2 = row.Cells(0).Value.ToString
            End If
        Next
        If code = "" Then
            Return code2
        Else
            Return code
        End If
    End Function


    Private Sub bgwSave_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSave.DoWork
        Dim startTime, prevTime, endTime As DateTime
        Dim startProcess, endProcess, processed As Integer
        Dim start As Boolean = False
        Dim timeSpent As TimeSpan
        Dim remainTime As Integer
        Dim stopper As Decimal
        Select Case reportName
            Case "Sales Book Journal Report"
                SetPGBmax(dgvTK.Rows.Count)
                Dim i As Integer = 0
                For Each row As DataGridViewRow In dgvTK.Rows
                    If start = False Then
                        startTime = DateTime.Now
                        startProcess = i
                        start = True
                    End If
                    prevTime = DateTime.Now
                    If Not VCEexist(row.Cells(6).Value.ToString) Then
                        InsertVCE(row.Cells(6).Value.ToString, row.Cells(7).Value.ToString, row.Cells(8).Value.ToString)
                    End If
                    Dim JETransID As Integer
                    Dim ID As Integer
                    Dim VAT As Decimal
                    If Not SIexist(row.Cells(1).Value.ToString) Then
                        ID = GenerateTransID("TransID", "tblSI")
                        If row.Cells(5).Value Is Nothing Then
                            row.Cells(5).Value = ""
                        End If
                        VAT = row.Cells(9).Value - (CDec(row.Cells(14).Value) + CDec(row.Cells(15).Value) + CDec(row.Cells(16).Value) + CDec(row.Cells(17).Value))
                        InsertSI(ID, row.Cells(1).Value.ToString, row.Cells(2).Value.ToString, row.Cells(6).Value.ToString, _
                                 row.Cells(9).Value, VAT, row.Cells(12).Value + row.Cells(13).Value, _
                                 row.Cells(10).Value + row.Cells(11).Value, row.Cells(5).Value.ToString)
                        InsertSIDetails(ID, row.Cells(3).Value.ToString, row.Cells(9).Value, row.Cells(18).Value, row.Cells(12).Value + row.Cells(13).Value, row.Cells(4).Value, _
                                 row.Cells(10).Value + row.Cells(11).Value)
                        SaveEntry(ID, row.Cells(2).Value, row.Cells(9).Value, "SI", "Sales")
                        JETransID = LoadJE("SI", ID)
                        If row.Cells(10).Value > 0 Then SaveEntryDetails(JETransID, "11010", row.Cells(6).Value.ToString, row.Cells(10).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(11).Value > 0 Then SaveEntryDetails(JETransID, "11030", row.Cells(6).Value.ToString, row.Cells(11).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(12).Value > 0 Then SaveEntryDetails(JETransID, "24010", row.Cells(6).Value.ToString, row.Cells(12).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(13).Value > 0 Then SaveEntryDetails(JETransID, "24020", row.Cells(6).Value.ToString, row.Cells(13).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(14).Value > 0 Then SaveEntryDetails(JETransID, "23030", row.Cells(6).Value.ToString, 0, row.Cells(14).Value, row.Cells(3).Value.ToString)
                        If row.Cells(15).Value > 0 Then SaveEntryDetails(JETransID, "23040", row.Cells(6).Value.ToString, 0, row.Cells(15).Value, row.Cells(3).Value.ToString)
                        If row.Cells(16).Value > 0 Then SaveEntryDetails(JETransID, "23010", row.Cells(6).Value.ToString, 0, row.Cells(16).Value, row.Cells(3).Value.ToString)
                        If row.Cells(17).Value > 0 Then SaveEntryDetails(JETransID, "23020", row.Cells(6).Value.ToString, 0, row.Cells(17).Value, row.Cells(3).Value.ToString)
                        If VAT > 0 Then SaveEntryDetails(JETransID, "21090", row.Cells(6).Value.ToString, 0, VAT, row.Cells(3).Value.ToString)

                    Else
                        ID = GetTransID("TransID", "tblSI", "SI_No", row.Cells(1).Value.ToString)
                        If row.Cells(5).Value Is Nothing Then
                            row.Cells(5).Value = ""
                        End If
                        VAT = row.Cells(9).Value - (CDec(row.Cells(14).Value) + CDec(row.Cells(15).Value) + CDec(row.Cells(16).Value) + CDec(row.Cells(17).Value))
                        InsertSIDetails(ID, row.Cells(3).Value.ToString, row.Cells(9).Value, row.Cells(18).Value, row.Cells(12).Value + row.Cells(13).Value, row.Cells(4).Value, _
                                 row.Cells(10).Value + row.Cells(11).Value)
                        UpdateTotals(ID)
                        JETransID = LoadJE("SI", ID)
                        UpdateEntry(JETransID, row.Cells(9).Value)
                        If row.Cells(10).Value > 0 Then SaveEntryDetails(JETransID, "11010", row.Cells(6).Value.ToString, row.Cells(10).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(11).Value > 0 Then SaveEntryDetails(JETransID, "11030", row.Cells(6).Value.ToString, row.Cells(11).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(12).Value > 0 Then SaveEntryDetails(JETransID, "24010", row.Cells(6).Value.ToString, row.Cells(12).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(13).Value > 0 Then SaveEntryDetails(JETransID, "24020", row.Cells(6).Value.ToString, row.Cells(13).Value, 0, row.Cells(3).Value.ToString)
                        If row.Cells(14).Value > 0 Then SaveEntryDetails(JETransID, "23030", row.Cells(6).Value.ToString, 0, row.Cells(14).Value, row.Cells(3).Value.ToString)
                        If row.Cells(15).Value > 0 Then SaveEntryDetails(JETransID, "23040", row.Cells(6).Value.ToString, 0, row.Cells(15).Value, row.Cells(3).Value.ToString)
                        If row.Cells(16).Value > 0 Then SaveEntryDetails(JETransID, "23010", row.Cells(6).Value.ToString, 0, row.Cells(16).Value, row.Cells(3).Value.ToString)
                        If row.Cells(17).Value > 0 Then SaveEntryDetails(JETransID, "23020", row.Cells(6).Value.ToString, 0, row.Cells(17).Value, row.Cells(3).Value.ToString)
                        If VAT > 0 Then SaveEntryDetails(JETransID, "21090", row.Cells(6).Value.ToString, 0, VAT, row.Cells(3).Value.ToString)
                    End If
                    bgwSave.ReportProgress(i)
                    timeSpent = DateTime.Now - prevTime
                    stopper += timeSpent.TotalSeconds
                    If stopper > 3 Then
                        endTime = DateTime.Now
                        endProcess = i
                        timeSpent = endTime - startTime
                        processed = endProcess - startProcess
                        If processed > 0 Then
                            remainTime = (timeSpent.TotalSeconds / processed) * (dgvTK.Rows.Count - i)
                            SetRemainingTime(remainTime)
                            stopper = 0
                        End If
                    End If
                    i += 1
                Next
            Case "Cash Receipts Book Summary 2"
                SetPGBmax(dgvTK.Rows.Count)
                Dim i As Integer = 0
                For Each row As DataGridViewRow In dgvTK.Rows
                    If start = False Then
                        startTime = DateTime.Now
                        startProcess = i
                        start = True
                    End If
                    prevTime = DateTime.Now
                    If Not VCEexist(row.Cells(7).Value.ToString) Then
                        InsertVCE(row.Cells(7).Value.ToString, row.Cells(8).Value.ToString, row.Cells(9).Value.ToString)
                    End If
                    Dim JETransID As Integer
                    Dim ID As Integer
                    Dim Type, TransNo As String
                    Type = row.Cells(2).Value.ToString
                    TransNo = row.Cells(3).Value.ToString

                    If row.Cells(4).Value Is Nothing Then
                        row.Cells(4).Value = ""
                    End If
                    If row.Cells(5).Value Is Nothing Then
                        row.Cells(5).Value = ""
                    End If
                    If row.Cells(6).Value Is Nothing Then
                        row.Cells(6).Value = ""
                    End If
                    If Not CollectionExist(Type, TransNo) Then
                        ID = GenerateTransID("TransID", "tblCollection")
                        InsertCollection(ID, Type, TransNo, row.Cells(1).Value, row.Cells(7).Value.ToString, row.Cells(10).Value, row.Cells(5).Value.ToString, row.Cells(4).Value.ToString, row.Cells(6).Value)
                        SaveEntry(ID, row.Cells(1).Value, CDec(row.Cells(11).Value) + CDec(row.Cells(12).Value) + CDec(row.Cells(13).Value) + CDec(row.Cells(14).Value), Type, "Cash Receipts")
                        JETransID = LoadJE(Type, ID)
                        If row.Cells(11).Value > 0 Then SaveEntryDetails(JETransID, "10300", row.Cells(7).Value.ToString, row.Cells(11).Value, 0, "", "") ' DEBIT CASH ON HAND
                        If row.Cells(12).Value > 0 Then SaveEntryDetails(JETransID, "10400", row.Cells(7).Value.ToString, row.Cells(12).Value, 0, "", "") ' DEBIT CASH IN BANK
                        If row.Cells(13).Value > 0 Then SaveEntryDetails(JETransID, "11050", row.Cells(7).Value.ToString, row.Cells(13).Value, 0, "", "") ' DEBIT AR-PDC
                        If row.Cells(14).Value > 0 Then SaveEntryDetails(JETransID, "21250", row.Cells(7).Value.ToString, row.Cells(14).Value, 0, "", "") ' DEBIT APP-CM
                        If row.Cells(15).Value > 0 Then SaveEntryDetails(JETransID, "28200", row.Cells(7).Value.ToString, row.Cells(15).Value, 0, "", "") ' DEBIT DEALERS INCENTIVE
                        If row.Cells(16).Value > 0 Then SaveEntryDetails(JETransID, "11010", row.Cells(7).Value.ToString, 0, row.Cells(16).Value, "", "") ' CREDIT AR
                        If row.Cells(17).Value > 0 Then SaveEntryDetails(JETransID, "11030", row.Cells(7).Value.ToString, 0, row.Cells(17).Value, "", "") ' CREDIT AR-OTHERS
                        If row.Cells(18).Value > 0 Then SaveEntryDetails(JETransID, "21170", row.Cells(7).Value.ToString, 0, row.Cells(18).Value, "", "") ' CREDIT BOND PAYABLE
                        If row.Cells(19).Value > 0 Then SaveEntryDetails(JETransID, "11060", row.Cells(7).Value.ToString, row.Cells(19).Value, 0, "", "") ' DEBIT CREDIT CARD
                        If row.Cells(20).Value > 0 Then SaveEntryDetails(JETransID, "", row.Cells(7).Value.ToString, 0, row.Cells(20).Value, "", "")
                    Else
                        ID = GetTransID("TransID", "tblCollection", "TransNo", TransNo, "TransType", Type)

                        If row.Cells(9).Value Is Nothing Then
                            row.Cells(9).Value = ""
                        End If
                        If row.Cells(10).Value Is Nothing Then
                            row.Cells(10).Value = ""
                        End If
                        If row.Cells(11).Value Is Nothing Then
                            row.Cells(11).Value = ""
                        End If
                        If row.Cells(6).Value Is Nothing Then
                            row.Cells(6).Value = ""
                        End If
                        If row.Cells(7).Value Is Nothing Then
                            row.Cells(7).Value = ""
                        End If
                        JETransID = LoadJE(Type, ID)
                        UpdateEntry(JETransID, CDec(row.Cells(11).Value) + CDec(row.Cells(12).Value) + CDec(row.Cells(13).Value) + CDec(row.Cells(14).Value))
                        If row.Cells(11).Value > 0 Then SaveEntryDetails(JETransID, "10300", row.Cells(7).Value.ToString, row.Cells(11).Value, 0, "", "") ' DEBIT CASH ON HAND
                        If row.Cells(12).Value > 0 Then SaveEntryDetails(JETransID, "10400", row.Cells(7).Value.ToString, row.Cells(12).Value, 0, "", "") ' DEBIT CASH IN BANK
                        If row.Cells(13).Value > 0 Then SaveEntryDetails(JETransID, "11050", row.Cells(7).Value.ToString, row.Cells(13).Value, 0, "", "") ' DEBIT AR-PDC
                        If row.Cells(14).Value > 0 Then SaveEntryDetails(JETransID, "21250", row.Cells(7).Value.ToString, row.Cells(14).Value, 0, "", "") ' DEBIT APP-CM
                        If row.Cells(15).Value > 0 Then SaveEntryDetails(JETransID, "28200", row.Cells(7).Value.ToString, row.Cells(15).Value, 0, "", "") ' DEBIT DEALERS INCENTIVE
                        If row.Cells(16).Value > 0 Then SaveEntryDetails(JETransID, "11010", row.Cells(7).Value.ToString, 0, row.Cells(16).Value, "", "") ' CREDIT AR
                        If row.Cells(17).Value > 0 Then SaveEntryDetails(JETransID, "11030", row.Cells(7).Value.ToString, 0, row.Cells(17).Value, "", "") ' CREDIT AR-OTHERS
                        If row.Cells(18).Value > 0 Then SaveEntryDetails(JETransID, "21170", row.Cells(7).Value.ToString, 0, row.Cells(18).Value, "", "") ' CREDIT BOND PAYABLE
                        If row.Cells(19).Value > 0 Then SaveEntryDetails(JETransID, "11060", row.Cells(7).Value.ToString, row.Cells(19).Value, 0, "", "") ' DEBIT CREDIT CARD
                        If row.Cells(20).Value > 0 Then SaveEntryDetails(JETransID, "", row.Cells(7).Value.ToString, 0, row.Cells(20).Value, "", "")
                    End If
                    bgwSave.ReportProgress(i)
                    timeSpent = DateTime.Now - prevTime
                    stopper += timeSpent.TotalSeconds
                    If stopper > 3 And processed <> 0 Then
                        endTime = DateTime.Now
                        endProcess = i
                        timeSpent = endTime - startTime
                        processed = endProcess - startProcess
                        remainTime = (timeSpent.TotalSeconds / processed) * (dgvTK.Rows.Count - i)
                        SetRemainingTime(remainTime)
                        stopper = 0
                    End If
                    i += 1

                Next

            Case "ACCOUNTS PAYABLE   REGISTER"
                SetPGBmax(dgvTK.Rows.Count)
                Dim i As Integer = 0
                Dim currentVCECode As String
                For Each row As DataGridViewRow In dgvTK.Rows
                    If start = False Then
                        startTime = DateTime.Now
                        startProcess = i
                        start = True
                    End If
                    prevTime = DateTime.Now
                    If VCENameexist(row.Cells(3).Value.ToString) Then
                        currentVCECode = GetVCECode(row.Cells(3).Value.ToString)
                    ElseIf row.Cells(3).Value.ToString = "CANCELLED" Then
                        currentVCECode = "CANCELLED"
                    Else
                        Msg(row.Cells(3).Value.ToString & " does not exist in vendor masterfile!", MsgBoxStyle.Exclamation)
                        Exit For
                    End If
                    Dim JETransID As Integer
                    Dim ID As Integer
                    If Not APVexist(row.Cells(2).Value) Then
                        ID = GenerateTransID("TransID", "tblAPV")
                        InsertAPV(ID, row.Cells(2).Value, row.Cells(1).Value, currentVCECode, row.Cells(5).Value, row.Cells(6).Value.ToString, 0, row.Cells(8).Value, row.Cells(9).Value)
                        SaveEntry(ID, row.Cells(1).Value, CDec(row.Cells(5).Value), "APV", "Purchases")
                        JETransID = LoadJE("APV", ID)
                        If row.Cells(7).Value > 0 Then SaveEntryDetails(JETransID, "20010", currentVCECode, row.Cells(7).Value, 0, row.Cells(4).Value, "") ' DEBIT EXPENSE
                        If row.Cells(6).Value > 0 Then SaveEntryDetails(JETransID, "18060", currentVCECode, row.Cells(6).Value, 0, row.Cells(4).Value, "") ' DEBIT VAT
                        If row.Cells(8).Value > 0 Then SaveEntryDetails(JETransID, "21070", currentVCECode, 0, row.Cells(8).Value, row.Cells(4).Value, "") ' CREDIT WTAX
                        If row.Cells(9).Value > 0 Then SaveEntryDetails(JETransID, "19010", currentVCECode, 0, row.Cells(9).Value, row.Cells(4).Value, "") ' CREDIT AP
                    Else
                        ID = GetTransID("TransID", "tblAPV", "APV_No", row.Cells(2).Value.ToString)

                        JETransID = LoadJE("APV", ID)
                        UpdateEntry(JETransID, CDec(row.Cells(5).Value))
                        If row.Cells(7).Value > 0 Then SaveEntryDetails(JETransID, "20010", currentVCECode, row.Cells(7).Value, 0, row.Cells(4).Value, "") ' DEBIT EXPENSE
                        If row.Cells(6).Value > 0 Then SaveEntryDetails(JETransID, "18060", currentVCECode, row.Cells(6).Value, 0, row.Cells(4).Value, "") ' DEBIT VAT
                        If row.Cells(8).Value > 0 Then SaveEntryDetails(JETransID, "21070", currentVCECode, 0, row.Cells(8).Value, row.Cells(4).Value, "") ' CREDIT WTAX
                        If row.Cells(9).Value > 0 Then SaveEntryDetails(JETransID, "19010", currentVCECode, 0, row.Cells(9).Value, row.Cells(4).Value, "") ' CREDIT AP
                    End If
                    If currentVCECode = "CANCELLED" Then
                        Dim updateSQL As String
                        Dim insertSQL As String
                        updateSQL = " UPDATE  tblAPV SET Status ='Cancelled' WHERE TransID = '" & ID & "' "
                        SQL.ExecNonQuery(updateSQL)

                        updateSQL = " UPDATE  tblJE_Header SET Status ='Cancelled' WHERE JE_No = '" & JETransID & "' "
                        SQL.ExecNonQuery(updateSQL)

                        insertSQL = " INSERT INTO tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber, OtherRef) " & _
                                    " SELECT JE_No, AccntCode, VCECode, Credit, Debit, Particulars, RefNo, LineNumber, OtherRef FROM tblJE_Details " & _
                                    " WHERE JE_No = '" & JETransID & "' "
                        SQL.ExecNonQuery(insertSQL)
                    End If
                    bgwSave.ReportProgress(i)
                    timeSpent = DateTime.Now - prevTime
                    stopper += timeSpent.TotalSeconds
                    If stopper > 3 And processed <> 0 Then
                        endTime = DateTime.Now
                        endProcess = i
                        timeSpent = endTime - startTime
                        processed = endProcess - startProcess
                        remainTime = (timeSpent.TotalSeconds / processed) * (dgvTK.Rows.Count - i)
                        SetRemainingTime(remainTime)
                        stopper = 0
                    End If
                    i += 1

                Next
            Case "CASH VOUCHER- EXPENSE REPORT"
                SetPGBmax(dgvTK.Rows.Count)
                Dim i As Integer = 0
                Dim currentVCECode As String
                For Each row As DataGridViewRow In dgvTK.Rows
                    If start = False Then
                        startTime = DateTime.Now
                        startProcess = i
                        start = True
                    End If
                    prevTime = DateTime.Now
                    If VCENameexist(row.Cells(3).Value.ToString) Then
                        currentVCECode = GetVCECode(row.Cells(3).Value.ToString)
                    ElseIf row.Cells(3).Value.ToString = "CANCELLED" Then
                        currentVCECode = "CANCELLED"
                    Else
                        Msg(row.Cells(3).Value.ToString & " does not exist in vendor masterfile!", MsgBoxStyle.Exclamation)
                        Exit For
                    End If
                    Dim JETransID As Integer
                    Dim ID As Integer
                    If Not CVexist(row.Cells(2).Value) Then
                        Dim AccntCode As String = ""
                        Dim tempCode As String
                        If row.Cells(12).Value <> "" Then
                            tempCode = LoadCode(row.Cells(12).Value.ToString)
                            If tempCode.Contains("-") Then
                                AccntCode = Strings.Left(tempCode, tempCode.IndexOf("-"))
                                Branch = Strings.Replace(tempCode, AccntCode & "-", "")
                            Else
                                AccntCode = tempCode
                                SetDefaultBranch()
                            End If
                        Else
                            AccntCode = ""
                            SetDefaultBranch()
                        End If
                        ID = GenerateTransID("TransID", "tblCV")
                        InsertCV(ID, row.Cells(2).Value, row.Cells(1).Value, currentVCECode, 0)
                        SaveEntry(ID, row.Cells(1).Value, 0, "CV", "Cash Disbursements")
                        JETransID = LoadJE("CV", ID)
                        If AccntCode <> "" Then
                            SaveEntryDetails(JETransID, AccntCode, currentVCECode, row.Cells(13).Value, row.Cells(14).Value, "", "") ' ENTRY SUNDRIES
                        End If

                        'If row.Cells(7).Value > 0 Then SaveEntryDetails(JETransID, "20010", currentVCECode, row.Cells(7).Value, 0, row.Cells(4).Value, "") ' DEBIT EXPENSE
                        'If row.Cells(6).Value > 0 Then SaveEntryDetails(JETransID, "18060", currentVCECode, row.Cells(6).Value, 0, row.Cells(4).Value, "") ' DEBIT VAT
                        'If row.Cells(8).Value > 0 Then SaveEntryDetails(JETransID, "21070", currentVCECode, 0, row.Cells(8).Value, row.Cells(4).Value, "") ' CREDIT WTAX
                        'If row.Cells(9).Value > 0 Then SaveEntryDetails(JETransID, "19010", currentVCECode, 0, row.Cells(9).Value, row.Cells(4).Value, "") ' CREDIT AP
                    Else
                        ID = GetTransID("TransID", "tblCV", "CV_No", row.Cells(2).Value.ToString)

                        JETransID = LoadJE("CV", ID)
                        UpdateEntry(JETransID, 0)
                        Dim AccntCode As String = ""
                        Dim tempCode As String
                        If row.Cells(12).Value <> "" Then
                            tempCode = LoadCode(row.Cells(12).Value.ToString)
                            If tempCode.Contains("-") Then
                                AccntCode = Strings.Left(tempCode, tempCode.IndexOf("-"))
                                Branch = Strings.Replace(tempCode, AccntCode & "-", "")
                            Else
                                AccntCode = tempCode
                                SetDefaultBranch()
                            End If
                        Else
                            AccntCode = ""
                            SetDefaultBranch()
                        End If
                        If AccntCode <> "" Then
                            SaveEntryDetails(JETransID, AccntCode, currentVCECode, row.Cells(13).Value, row.Cells(14).Value, "", "") ' ENTRY SUNDRIES
                        End If
                    End If
                    If currentVCECode = "CANCELLED" Then
                        Dim updateSQL As String
                        Dim insertSQL As String
                        updateSQL = " UPDATE  tblAPV SET Status ='Cancelled' WHERE TransID = '" & ID & "' "
                        SQL.ExecNonQuery(updateSQL)

                        updateSQL = " UPDATE  tblJE_Header SET Status ='Cancelled' WHERE JE_No = '" & JETransID & "' "
                        SQL.ExecNonQuery(updateSQL)

                        insertSQL = " INSERT INTO tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber, OtherRef) " & _
                                    " SELECT JE_No, AccntCode, VCECode, Credit, Debit, Particulars, RefNo, LineNumber, OtherRef FROM tblJE_Details " & _
                                    " WHERE JE_No = '" & JETransID & "' "
                        SQL.ExecNonQuery(insertSQL)
                    End If
                    bgwSave.ReportProgress(i)
                    timeSpent = DateTime.Now - prevTime
                    stopper += timeSpent.TotalSeconds
                    If stopper > 3 And processed <> 0 Then
                        endTime = DateTime.Now
                        endProcess = i
                        timeSpent = endTime - startTime
                        processed = endProcess - startProcess
                        remainTime = (timeSpent.TotalSeconds / processed) * (dgvTK.Rows.Count - i)
                        SetRemainingTime(remainTime)
                        stopper = 0
                    End If
                    i += 1
                Next
            Case "CHECK VOUCHER-  EXPENSE REPORT"
                SetPGBmax(dgvTK.Rows.Count)
                Dim i As Integer = 0
                Dim currentVCECode As String
                For Each row As DataGridViewRow In dgvTK.Rows
                    If start = False Then
                        startTime = DateTime.Now
                        startProcess = i
                        start = True
                    End If
                    prevTime = DateTime.Now
                    If VCENameexist(row.Cells(3).Value.ToString) Then
                        currentVCECode = GetVCECode(row.Cells(3).Value.ToString)
                    ElseIf row.Cells(3).Value.ToString = "CANCELLED" Then
                        currentVCECode = "CANCELLED"
                    Else
                        Msg(row.Cells(3).Value.ToString & " does not exist in vendor masterfile!", MsgBoxStyle.Exclamation)
                        Exit For
                    End If
                    Dim JETransID As Integer
                    Dim ID As Integer
                    If Not CVexist(row.Cells(2).Value) Then
                        Dim AccntCode As String = ""
                        Dim tempCode As String
                        If row.Cells(2).Value = "CVTRD-18-00871" Then
                            MsgBox("A")
                        End If
                        If row.Cells(12).Value <> "" Then
                            tempCode = LoadCode(row.Cells(12).Value.ToString)
                            If tempCode.Contains("-") Then
                                AccntCode = Strings.Left(tempCode, tempCode.IndexOf("-"))
                                Branch = Strings.Replace(tempCode, AccntCode & "-", "")
                            Else
                                AccntCode = tempCode
                                SetDefaultBranch()
                            End If
                        Else
                            AccntCode = ""
                            SetDefaultBranch()
                        End If
                        ID = GenerateTransID("TransID", "tblCV")
                        InsertCV(ID, row.Cells(2).Value, row.Cells(1).Value, currentVCECode, 0)
                        SaveEntry(ID, row.Cells(1).Value, 0, "CV", "Cash Disbursements")
                        JETransID = LoadJE("CV", ID)
                        If row.Cells(11).Value Is Nothing Then
                            row.Cells(11).Value = ""
                        End If
                        If AccntCode <> "" Then
                            SaveEntryDetails(JETransID, AccntCode, currentVCECode, row.Cells(13).Value, row.Cells(14).Value, row.Cells(11).Value, "") ' ENTRY SUNDRIES
                        End If

                        'If row.Cells(7).Value > 0 Then SaveEntryDetails(JETransID, "20010", currentVCECode, row.Cells(7).Value, 0, row.Cells(4).Value, "") ' DEBIT EXPENSE
                        'If row.Cells(6).Value > 0 Then SaveEntryDetails(JETransID, "18060", currentVCECode, row.Cells(6).Value, 0, row.Cells(4).Value, "") ' DEBIT VAT
                        'If row.Cells(8).Value > 0 Then SaveEntryDetails(JETransID, "21070", currentVCECode, 0, row.Cells(8).Value, row.Cells(4).Value, "") ' CREDIT WTAX
                        'If row.Cells(9).Value > 0 Then SaveEntryDetails(JETransID, "19010", currentVCECode, 0, row.Cells(9).Value, row.Cells(4).Value, "") ' CREDIT AP
                    Else
                        ID = GetTransID("TransID", "tblCV", "CV_No", row.Cells(2).Value.ToString)

                        JETransID = LoadJE("CV", ID)
                        UpdateEntry(JETransID, 0)
                        Dim AccntCode As String = ""
                        Dim tempCode As String
                        If row.Cells(12).Value <> "" Then
                            tempCode = LoadCode(row.Cells(12).Value.ToString)
                            If tempCode.Contains("-") Then
                                AccntCode = Strings.Left(tempCode, tempCode.IndexOf("-"))
                                Branch = Strings.Replace(tempCode, AccntCode & "-", "")
                            Else
                                AccntCode = tempCode
                                SetDefaultBranch()
                            End If
                        Else
                            AccntCode = ""
                            SetDefaultBranch()
                        End If
                        If row.Cells(11).Value Is Nothing Then
                            row.Cells(11).Value = ""
                        End If
                        If AccntCode <> "" Then
                            SaveEntryDetails(JETransID, AccntCode, currentVCECode, row.Cells(13).Value, row.Cells(14).Value, row.Cells(11).Value, "") ' ENTRY SUNDRIES
                        End If
                    End If
                    If currentVCECode = "CANCELLED" Then
                        Dim updateSQL As String
                        Dim insertSQL As String
                        updateSQL = " UPDATE  tblAPV SET Status ='Cancelled' WHERE TransID = '" & ID & "' "
                        SQL.ExecNonQuery(updateSQL)

                        updateSQL = " UPDATE  tblJE_Header SET Status ='Cancelled' WHERE JE_No = '" & JETransID & "' "
                        SQL.ExecNonQuery(updateSQL)

                        insertSQL = " INSERT INTO tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, RefNo, LineNumber, OtherRef) " & _
                                    " SELECT JE_No, AccntCode, VCECode, Credit, Debit, Particulars, RefNo, LineNumber, OtherRef FROM tblJE_Details " & _
                                    " WHERE JE_No = '" & JETransID & "' "
                        SQL.ExecNonQuery(insertSQL)
                    End If
                    bgwSave.ReportProgress(i)
                    timeSpent = DateTime.Now - prevTime
                    stopper += timeSpent.TotalSeconds
                    If stopper > 3 And processed <> 0 Then
                        endTime = DateTime.Now
                        endProcess = i
                        timeSpent = endTime - startTime
                        processed = endProcess - startProcess
                        remainTime = (timeSpent.TotalSeconds / processed) * (dgvTK.Rows.Count - i)
                        SetRemainingTime(remainTime)
                        stopper = 0
                    End If
                    i += 1

                Next
        End Select
    End Sub

    Private Sub bgwSave_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwSave.ProgressChanged
        pgbCounter.Value = e.ProgressPercentage
    End Sub

    Private Sub bgwSave_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwSave.RunWorkerCompleted
        lblTime.Visible = False
        pgbCounter.Visible = False
        MsgBox(dgvTK.Rows.Count & " Records Saved Successfully!", vbInformation, "JADE Message Alert")
        dgvTK.Rows.Clear()
        dgvTK.Columns.Clear()
        dgvSummary.Rows.Clear()
        btnSave.Enabled = True
    End Sub

    Private Function FileUploaded() As Boolean
        Dim query As String
        query = " SELECT    * " & _
                " FROM      tblUploadHistory " & _
                " WHERE     ReportType = @ReportType AND RowCounter = @RowCounter AND Branch = @Branch AND Period = @Period AND Status ='Active' "
        SQL.FlushParams()
        SQL.AddParam("@ReportType", reportName)
        SQL.AddParam("@RowCounter", excelRangeCount)
        SQL.AddParam("@Branch", BranchName)
        SQL.AddParam("@Period", Period)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
        SQL.FlushParams()
    End Function

    Private Sub frmUploader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnSave.Enabled = False
        LoadBranches()
        LoadBusinessType()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class

