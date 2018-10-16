Public Class frmJO
    Dim TransID, RefID As String
    Dim JONo As String
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "JO"
    Dim ColumnPK As String = "JO_No"
    Dim DBTable As String = "tblJO"
    Dim TransAuto As Boolean
    Dim AccntCode As String
    Dim SO_ID, LineID As Integer

    Public Overloads Function ShowDialog(ByVal DocID As String) As Boolean
        TransID = DocID
        MyBase.ShowDialog()
        Return True
    End Function
    Private Sub EnableControl(ByVal Value As Boolean)
        txtRemarks.Enabled = Value
        dtpDocDate.Enabled = Value
        cbProdLine.Enabled = Value
        If TransAuto Then
            txtTransNum.Enabled = False
        Else
            txtTransNum.Enabled = Value
        End If
    End Sub

    Private Sub ClearText()
        txtTransNum.Text = ""
        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtUOM.Text = ""
        txtQTY.Text = ""
        txtRefNo.Text = ""
        cbProdLine.Text = ""
        txtVCECode.Text = ""
        txtVCEName.Text = ""
        txtRemarks.Text = ""
        txtStatus.Text = "Open"
        dtpDocDate.Value = Date.Today.Date
        dtpDelivery.Value = Date.Today.Date
    End Sub

    Private Sub LoadJO(ByVal ID As String)
        Dim query As String
        query = " SELECT    TransID, JO_No, DateJO, VCECode, ItemCode, Description, UOM, QTY,  Remarks, DateNeeded, ProdLine, SO_Ref, SO_Ref_LineNum, Status " & _
                " FROM       tblJO " & _
                " WHERE      TransId = '" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID").ToString
            JONo = SQL.SQLDR("JO_No").ToString
            txtTransNum.Text = JONo
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
            txtDescription.Text = SQL.SQLDR("Description").ToString
            txtUOM.Text = SQL.SQLDR("UOM").ToString
            txtQTY.Text = SQL.SQLDR("QTY").ToString
            cbProdLine.Text = SQL.SQLDR("ProdLine").ToString
            txtRemarks.Text = SQL.SQLDR("Remarks").ToString
            txtStatus.Text = SQL.SQLDR("Status").ToString
            dtpDocDate.Text = SQL.SQLDR("DateJO").ToString
            dtpDelivery.Text = SQL.SQLDR("DateNeeded").ToString
            SO_ID = SQL.SQLDR("SO_Ref").ToString
            LineID = SQL.SQLDR("SO_Ref_LineNum").ToString
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
            txtRefNo.Text = LoadSONo(SO_ID).ToCharArray + "-" + LineID.ToString

            ' TOOLSTRIP BUTTONS
            If txtStatus.Text = "Cancelled" Then
                tsbEdit.Enabled = False
                tsbCancel.Enabled = False
            ElseIf txtStatus.Text = "Closed" Then
                tsbEdit.Enabled = False
                tsbCancel.Enabled = False
            Else
                tsbEdit.Enabled = True
                tsbCancel.Enabled = True
            End If
            tsbPrint.Enabled = True
            tsbClose.Enabled = False
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbPrint.Enabled = True
            tsbSave.Enabled = False
            tsbNew.Enabled = True
            tsbSearch.Enabled = True
            tsbExit.Enabled = True
            tsbCopy.Enabled = True
            EnableControl(False)
        Else
            ClearText()
        End If

    End Sub

    Private Function LoadSONo(SO_ID As Integer) As String
        Dim query As String
        query = " SELECT SO_No FROM tblSO WHERE TransID = '" & SO_ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("SO_No")
        Else
            Return 0
        End If
    End Function

    Private Sub frmJO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TransAuto = GetTransSetup(ModuleID)
            dtpDocDate.Value = Date.Today.Date
            dtpDelivery.Value = Date.Today.Date
            If TransID <> "" Then
                LoadJO(TransID)
            End If
            LoadProdWarehouse()
            tsbSearch.Enabled = True
            tsbNew.Enabled = True
            tsbEdit.Enabled = False
            tsbSave.Enabled = False
            tsbCancel.Enabled = False
            tsbClose.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = True
            tsbPrint.Enabled = False
            tsbCopy.Enabled = False
            EnableControl(False)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub LoadProdWarehouse()
        Dim query As String
        query = " SELECT Code FROM tblProdWarehouse WHERE Status ='Active' "
        SQL.ReadQuery(query)
        cbProdLine.Items.Clear()
        While SQL.SQLDR.Read
            cbProdLine.Items.Add(SQL.SQLDR("Code").ToString)
        End While
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("JO_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmLoadTransactions
            f.ShowDialog("JO")
            If f.transID <> "" Then
                TransID = f.transID
            End If
            LoadJO(TransID)
            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As Object, e As EventArgs) Handles tsbNew.Click
        If Not AllowAccess("JO_ADD") Then
            msgRestricted()
        Else
            ClearText()
            TransID = ""
            JONo = ""

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbCancel.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
            tsbPrint.Enabled = False
            tsbCopy.Enabled = True
            EnableControl(True)

            txtTransNum.Text = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
        End If
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If Not AllowAccess("JO_EDIT") Then
            msgRestricted()
        Else
            EnableControl(True)

            ' Toolstrip Buttons
            tsbSearch.Enabled = False
            tsbNew.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = True
            tsbCancel.Enabled = False
            tsbClose.Enabled = True
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbExit.Enabled = False
            tsbPrint.Enabled = False
            tsbCopy.Enabled = False
        End If
    End Sub
    Private Sub SaveJO()
        Try
            activityStatus = True
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                                " tblJO  (TransID, JO_No, VCECode, DateJO, ItemCode, Description, UOM, QTY,  " & _
                                "         DateNeeded, Remarks, ProdLine, SO_Ref, SO_Ref_LineNum,  WhoCreated) " & _
                                " VALUES (@TransID, @JO_No, @VCECode, @DateJO, @ItemCode, @Description, @UOM, @QTY,  " & _
                                "         @DateNeeded, @Remarks, @ProdLine, @SO_Ref, @SO_Ref_LineNum, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@JO_No", JONo)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateJO", dtpDocDate.Text)
            SQL.AddParam("@ItemCode", txtItemCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@UOM", txtUOM.Text)
            SQL.AddParam("@QTY", txtQTY.Text)
            SQL.AddParam("@DateNeeded", dtpDelivery.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@ProdLine", cbProdLine.Text)
            SQL.AddParam("@SO_Ref", SO_ID)
            SQL.AddParam("@SO_Ref_LineNum", LineID)
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "INSERT", "JO_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try

    End Sub
    Private Sub UpdateJO()
        Try
            activityStatus = True
            Dim updateSQL As String

            updateSQL = " UPDATE tblJO " & _
                        " SET    JO_No = @JO_No, BranchCode = @BranchCode, BusinessCode = @BusinessCode, DateJO = @DateJO, VCECode = @VCECode, " & _
                        "        ItemCode = @ItemCode, Description = @Description, UOM = @UOM, " & _
                        "        QTY = @QTY,  DateNeeded = @DateNeeded, Remarks = @Remarks, " & _
                        "        ProdLine = @ProdLine, SO_Ref = @SO_Ref, SO_Ref_LineNum = @SO_Ref_LineNum,  WhoModified = @WhoModified, DateModified = GETDATE() " & _
                        " WHERE  TransID = @TransID "
            SQL.FlushParams()
            SQL.AddParam("@TransID", TransID)
            SQL.AddParam("@JO_No", JONo)
            SQL.AddParam("@VCECode", txtVCECode.Text)
            SQL.AddParam("@DateJO", dtpDocDate.Text)
            SQL.AddParam("@ItemCode", txtItemCode.Text)
            SQL.AddParam("@Description", txtDescription.Text)
            SQL.AddParam("@UOM", txtUOM.Text)
            SQL.AddParam("@QTY", txtQTY.Text)
            SQL.AddParam("@DateNeeded", dtpDelivery.Value.Date)
            SQL.AddParam("@Remarks", txtRemarks.Text)
            SQL.AddParam("@ProdLine", cbProdLine.Text)
            SQL.AddParam("@SO_Ref", SO_ID)
            SQL.AddParam("@SO_Ref_LineNum", LineID)
            SQL.AddParam("@WhoModified", UserID)

            SQL.ExecNonQuery(updateSQL)

        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, Me.Name.ToString, "UPDATE", "JO_No", txtTransNum.Text, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtVCECode.Text = "" Then
            Msg("Please enter VCECode!", MsgBoxStyle.Exclamation)
        ElseIf TransID = "" Then
            If MsgBox("Saving New Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                TransID = GenerateTransID(ColumnPK, DBTable)
                JONo = GenerateTransNum(TransAuto, ModuleID, ColumnPK, DBTable)
                txtTransNum.Text = JONo
                SaveJO()
                Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
                JONo = txtTransNum.Text
                LoadJO(TransID)
            End If
        Else
            If MsgBox("Updating Record, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                UpdateJO()
                Msg("Record Updated Succesfully!", MsgBoxStyle.Information)
                JONo = txtTransNum.Text
                LoadJO(TransID)
            End If
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As Object, e As EventArgs) Handles tsbCancel.Click
        If Not AllowAccess("JO_DEL") Then
            msgRestricted()
        Else
            If txtTransNum.Text <> "" Then
                If MsgBox("Are you sure you want to cancel this record?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
                    Try
                        activityStatus = True
                        Dim deleteSQL As String
                        deleteSQL = " UPDATE  tblJO SET Status ='Cancelled', WhoModified = @WhoModified WHERE JO_No = @JO_No "
                        SQL.FlushParams()
                        JONo = txtTransNum.Text
                        SQL.AddParam("@JO_No", JONo)
                        SQL.AddParam("@WhoModified", UserID)
                        SQL.ExecNonQuery(deleteSQL)
                        Msg("Record cancelled successfully", MsgBoxStyle.Information)

                        tsbSearch.Enabled = True
                        tsbNew.Enabled = True
                        tsbEdit.Enabled = False
                        tsbSave.Enabled = False
                        tsbCancel.Enabled = False
                        tsbClose.Enabled = False
                        tsbPrevious.Enabled = False
                        tsbNext.Enabled = False
                        tsbExit.Enabled = True
                        tsbPrint.Enabled = True
                        tsbCopy.Enabled = False
                        EnableControl(False)

                        JONo = txtTransNum.Text
                        LoadJO(JONo)
                    Catch ex As Exception
                        activityStatus = True
                        SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
                    Finally
                        RecordActivity(UserID, ModuleID, Me.Name.ToString, "CANCEL", "JO_No", JONo, BusinessType, BranchCode, "", activityStatus)
                        SQL.FlushParams()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub LoadSO(ByVal ID As String)
        If ID.Contains("-") Then
            SO_ID = Strings.Left(ID, ID.IndexOf("-"))
            LineID = Strings.Mid(ID, ID.IndexOf("-") + 2, ID.ToString.Length - SO_ID.ToString.Length)
        End If
        Dim query As String
        query = " SELECT     tblSO.TransID, SO_No, VCECode, DateSO, tblSO_Details.DateDeliver, Remarks, " & _
                "            ItemCode, Description, UOM, QTY, tblSO_Details.Status, LineNum " & _
                " FROM       tblSO INNER JOIN tblSO_Details " & _
                " ON         tblSO.TransID = tblSO_Details.TransID " & _
                " AND        tblSO_Details.LineNum = '" & LineID & "' " & _
                " WHERE      tblSO.TransId = '" & SO_ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtRefNo.Text = SQL.SQLDR("SO_No").ToString & "-" & SQL.SQLDR("LineNum").ToString
            txtVCECode.Text = SQL.SQLDR("VCECode").ToString
            dtpDelivery.Text = SQL.SQLDR("DateDeliver").ToString
            txtItemCode.Text = SQL.SQLDR("ItemCode").ToString
            txtDescription.Text = SQL.SQLDR("Description").ToString
            txtUOM.Text = SQL.SQLDR("UOM").ToString
            txtQTY.Text = SQL.SQLDR("QTY").ToString
            txtVCEName.Text = GetVCEName(txtVCECode.Text)
        Else
            ClearText()
        End If

    End Sub

    Private Sub tsbCopyPR_Click(sender As Object, e As EventArgs) Handles tsbCopyPR.Click
        Dim f As New frmLoadTransactions
        f.cbFilter.SelectedItem = "Status"
        f.txtFilter.Text = "Active"
        f.txtFilter.Enabled = False
        f.cbFilter.Enabled = False
        f.btnSearch.Enabled = False
        f.ShowDialog("Sub SO")
        LoadSO(f.transID)
        f.Dispose()
    End Sub


    Private Sub tsbNext_Click(sender As Object, e As EventArgs) Handles tsbNext.Click
        If JONo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblJO  WHERE JO_No > '" & JONo & "' ORDER BY JO_No ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadJO(TransID)
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As Object, e As EventArgs) Handles tsbPrevious.Click
        If JONo <> "" Then
            Dim query As String
            query = " SELECT Top 1 TransID FROM tblJO  WHERE JO_No < '" & JONo & "' ORDER BY JO_No DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                TransID = SQL.SQLDR("TransID").ToString
                LoadJO(TransID)
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnSearchVCE_Click(sender As Object, e As EventArgs)
        Dim f As New frmVCE_Search
        f.Type = "Customer"
        f.ShowDialog()
        txtVCECode.Text = f.VCECode
        txtVCEName.Text = f.VCEName
    End Sub

    Private Sub tsbExit_Click(sender As Object, e As EventArgs) Handles tsbExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click
        ' Toolstrip Buttons
        If JONo = "" Then
            ClearText()
            EnableControl(False)
            tsbEdit.Enabled = False
            tsbCancel.Enabled = False
            tsbPrevious.Enabled = False
            tsbNext.Enabled = False
            tsbPrint.Enabled = False
        Else
            LoadSO(JONo)
            tsbEdit.Enabled = True
            tsbCancel.Enabled = True
            tsbPrevious.Enabled = True
            tsbNext.Enabled = True
            tsbPrint.Enabled = True
        End If
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbSave.Enabled = False
        tsbClose.Enabled = False
        tsbExit.Enabled = True
        tsbCopy.Enabled = False
    End Sub

    Private Sub txtVCEName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVCEName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.cbFilter.SelectedItem = "VCEName"
            f.Type = "Customer"
            f.txtFilter.Text = txtVCEName.Text
            f.ShowDialog()
            txtVCECode.Text = f.VCECode
            txtVCEName.Text = f.VCEName
        End If
    End Sub

    Private Sub ToBOMToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ToBOMToolStripMenuItem.Click

    End Sub

    Private Sub frmJO_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.S Then
                If tsbSave.Enabled = True Then tsbSave.PerformClick()
            ElseIf e.KeyCode = Keys.F Then
                If tsbSearch.Enabled = True Then tsbSearch.PerformClick()
            ElseIf e.KeyCode = Keys.N Then
                If tsbNew.Enabled = True Then tsbNew.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                If tsbEdit.Enabled = True Then tsbEdit.PerformClick()
            ElseIf e.KeyCode = Keys.D Then
                If tsbCancel.Enabled = True Then tsbCancel.PerformClick()
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
            ElseIf e.KeyCode = Keys.P Then
                If tsbPrint.Enabled = True Then tsbPrint.PerformClick()
            ElseIf e.KeyCode = Keys.R Then
                If tsbReports.Enabled = True Then tsbReports.PerformClick()
            ElseIf e.KeyCode = Keys.C Then
                If tsbReports.Enabled = True Then tsbCopy.ShowDropDown()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbExit.Enabled = True Then
                    tsbExit.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If tsbClose.Enabled = True Then tsbClose.PerformClick()
        End If
    End Sub
End Class