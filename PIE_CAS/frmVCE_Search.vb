Public Class frmVCE_Search
    Public VCECode, VCEName, TIN, Type As String
    Public rowInd As Integer
    Public ModType As String = "VCE"
    Public ModFrom As String = "ALL"
    Dim disableEvent As Boolean = False

    Private Sub frmSearchVendor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cbFilter.SelectedIndex = -1 Then
            cbFilter.SelectedIndex = 0
        End If
        LoadList()
    End Sub

    Private Sub LoadList()
        If ModType = "RFP" Then
            cbStatus.Items.Clear()
            cbStatus.Enabled = False
            LoadListRFP()
        ElseIf ModFrom = "ALL" Then
            disableEvent = True
            LoadStatus()
            disableEvent = False
            LoadALL()
            cbStatus.Enabled = True
        ElseIf ModFrom = "VCE" Then
            disableEvent = True
            LoadStatus()
            disableEvent = False
            LoadVCE()
            cbStatus.Enabled = True
        ElseIf ModFrom = "CF" Then
            cbStatus.Items.Clear()
            cbStatus.Enabled = False
            LoadCF()
        ElseIf ModFrom = "UAR" Then
            cbStatus.Items.Clear()
            cbStatus.Enabled = False
            LoadUser()
        End If
    End Sub

    Private Sub LoadStatus()
        Dim query As String
        query = " SELECT DISTINCT Status FROM tblVCE_Master WHERE Status <> 'Deleted' "
        SQL.ReadQuery(query)
        cbStatus.Items.Clear()
        cbStatus.Items.Add("All")
        While SQL.SQLDR.Read
            cbStatus.Items.Add(SQL.SQLDR("Status").ToString)
        End While
        If cbStatus.Items.Count = 2 Then
            cbStatus.Items.Remove("All")
        End If
        cbStatus.SelectedIndex = 0
    End Sub


    Private Sub LoadListRFP()
        Dim query As String
        Dim filtertype As String = ""
        If cbFilter.SelectedItem = "TIN" Then
            filtertype = "TIN_No"
        Else
            filtertype = "VCEName"
        End If
        query = " SELECT DISTINCT MAX(VCECode) AS VCECode, VCEName, MAX(TIN_No) AS TIN_No " & _
                " FROM " & _
                " ( " & _
                "       SELECT VCECode AS VCECode,  VCEName, TIN_No FROM tblVCE_Master WHERE " & filtertype & " LIKE '%' + @Filter + '%' " & _
                "       UNION ALL " & _
                "       SELECT '', RecordPayee, TIN FROM tblRFP_Details WHERE " & cbFilter.SelectedItem & " LIKE '%' + @Filter + '%'  " & _
                " ) AS Payee " & _
                " GROUP BY VCEName "
        SQL.FlushParams()
        SQL.AddParam("@Filter", txtFilter.Text)
        SQL.ReadQuery(query)
        lvList.Items.Clear()
        While SQL.SQLDR.Read
            lvList.Items.Add(SQL.SQLDR("VCECode").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
            lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("TIN_No").ToString)
        End While
        SQL.FlushParams()
        For Each row As DataGridViewRow In frmRFP.dgvRecords.Rows
            If row.Index <> rowInd Then
                If Type = "RecordPayee" Then
                    If Not row.Cells(frmRFP.dgcPayee.Index).Value Is Nothing Then
                        If Strings.UCase(row.Cells(frmRFP.dgcPayee.Index).Value).ToString.Contains(Strings.UCase(txtFilter.Text)) Then
                            Dim alreadyExist As Boolean = False

                            For Each Item As ListViewItem In lvList.Items
                                If Item.SubItems(chVCEName.Index).Text = row.Cells(frmRFP.dgcPayee.Index).Value.ToString Then
                                    alreadyExist = True
                                End If
                            Next
                            If alreadyExist = False Then
                                lvList.Items.Add("")
                                lvList.Items(lvList.Items.Count - 1).SubItems.Add(row.Cells(frmRFP.dgcPayee.Index).Value.ToString)
                                If row.Cells(frmRFP.dgcTIN.Index).Value Is Nothing Then
                                    lvList.Items(lvList.Items.Count - 1).SubItems.Add("")
                                Else
                                    lvList.Items(lvList.Items.Count - 1).SubItems.Add(row.Cells(frmRFP.dgcTIN.Index).Value.ToString)
                                End If
                            End If
                        End If
                    End If

                ElseIf Type = "TIN" Then
                    If Not row.Cells(frmRFP.dgcTIN.Index).Value Is Nothing Then
                        If row.Cells(frmRFP.dgcTIN.Index).Value = txtFilter.Text Then
                            Dim alreadyExist As Boolean = False

                            For Each Item As ListViewItem In lvList.Items
                                If Item.SubItems(chTIN.Index).Text = row.Cells(frmRFP.dgcTIN.Index).Value.ToString Then
                                    alreadyExist = True
                                End If
                            Next
                            If alreadyExist = False Then
                                lvList.Items.Add("")
                                If row.Cells(frmRFP.dgcPayee.Index).Value Is Nothing Then
                                    lvList.Items(lvList.Items.Count - 1).SubItems.Add("")
                                Else
                                    lvList.Items(lvList.Items.Count - 1).SubItems.Add(row.Cells(frmRFP.dgcPayee.Index).Value.ToString)
                                End If
                                lvList.Items(lvList.Items.Count - 1).SubItems.Add(row.Cells(frmRFP.dgcTIN.Index).Value.ToString)
                            End If
                        End If
                    End If

                End If
            End If

        Next

        lvList.Columns(0).Width = 0
        If lvList.Items.Count > 0 Then
            lvList.Items(0).Selected = True
        Else
            Me.Close()

        End If
    End Sub

    Private Sub LoadVCE()
        If cbStatus.SelectedIndex <> -1 Then
            Dim query As String
            query = " SELECT VCECode, VCEName FROM tblVCE_Master WHERE " & cbFilter.SelectedItem & " LIKE '%" & txtFilter.Text & "%'  " & _
            IIf(cbStatus.SelectedItem = "All", "", " AND Status ='" & cbStatus.SelectedItem & "' ") & _
            IIf(Type = "Vendor", " AND isVendor = 1 ", "") & _
            IIf(Type = "Customer", " AND isCustomer = 1 ", "")
            SQL.ReadQuery(query)
            lvList.Items.Clear()
            While SQL.SQLDR.Read
                lvList.Items.Add(SQL.SQLDR("VCECode").ToString)
                lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
            End While
            If lvList.Items.Count > 0 Then
                lvList.Items(0).Selected = True
            End If
            lvList.Columns(0).Width = 160
        End If
    End Sub

    Private Sub LoadALL()
        If cbStatus.SelectedIndex <> -1 Then
            Dim query As String
            query = " SELECT VCECode, VCEName FROM viewVCE_Master WHERE " & cbFilter.SelectedItem & " LIKE '%" & txtFilter.Text & "%'  " & _
            IIf(cbStatus.SelectedItem = "All", "", " AND Status ='" & cbStatus.SelectedItem & "' ") & _
            IIf(Type = "Vendor", " AND isVendor = 1 ", "") & _
            IIf(Type = "Customer", " AND isCustomer = 1 ", "")
            SQL.ReadQuery(query)
            lvList.Items.Clear()
            While SQL.SQLDR.Read
                lvList.Items.Add(SQL.SQLDR("VCECode").ToString)
                lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
            End While
            If lvList.Items.Count > 0 Then
                lvList.Items(0).Selected = True
            End If
            lvList.Columns(0).Width = 160
        End If
    End Sub

    Private Sub LoadCF()
        With frmCF
            Dim query, VCEcode As String
            query = " SELECT VCECode, VCEName, TIN_No FROM tblVCE_Master WHERE VCEName LIKE '%' + @Filter + '%' "
            SQL.FlushParams()
            SQL.AddParam("@Filter", txtFilter.Text)
            SQL.ReadQuery(query)
            lvList.Items.Clear()
            While SQL.SQLDR.Read
                VCEcode = SQL.SQLDR("VCECode").ToString
                If VCEcode <> frmCF.supA And VCEcode <> .supB And VCEcode <> .supC And VCEcode <> .supD Then
                    lvList.Items.Add(SQL.SQLDR("VCECode").ToString)
                    lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
                    lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("TIN_No").ToString)
                End If
            End While
            SQL.FlushParams()
        End With

        lvList.Columns(0).Width = 0
        If lvList.Items.Count > 0 Then
            lvList.Items(0).Selected = True
        Else
            Me.Close()
        End If
    End Sub

    Private Sub LoadUser()
        With frmCF
            Dim query As String
            query = " SELECT  UserID, UserName, Status FROM tblUser WHERE UserName LIKE '%' + @Filter + '%' AND Status = 'Active' "
            SQL.FlushParams()
            SQL.AddParam("@Filter", txtFilter.Text)
            SQL.ReadQuery(query)
            lvList.Items.Clear()
            While SQL.SQLDR.Read
                lvList.Items.Add(SQL.SQLDR("UserID").ToString)
                lvList.Items(lvList.Items.Count - 1).SubItems.Add(SQL.SQLDR("UserName").ToString)
            End While
            SQL.FlushParams()
            lvList.Columns(chTIN.Index).Width = 0
        End With

        lvList.Columns(0).Width = 0
        If lvList.Items.Count > 0 Then
            lvList.Items(0).Selected = True
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lvList_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvList.DoubleClick
        If lvList.SelectedItems.Count = 1 Then
            VCECode = lvList.SelectedItems(0).SubItems(chVCECode.Index).Text
            VCEName = lvList.SelectedItems(0).SubItems(chVCEName.Index).Text
            If ModType <> "VCE" Then
                TIN = lvList.SelectedItems(0).SubItems(chTIN.Index).Text
            End If
            Me.Close()
        End If
    End Sub

    Private Sub cbStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbStatus.SelectedIndexChanged
        If disableEvent = False Then
            LoadList()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        LoadList()
    End Sub

    Private Sub frmVCE_Search_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtFilter_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadList()
        End If
    End Sub

    Private Sub lvList_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles lvList.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lvList.SelectedItems.Count = 1 Then
                VCECode = lvList.SelectedItems(0).SubItems(chVCECode.Index).Text
                VCEName = lvList.SelectedItems(0).SubItems(chVCEName.Index).Text
                If ModType <> "VCE" Then
                    TIN = lvList.SelectedItems(0).SubItems(chTIN.Index).Text
                End If
                Me.Close()
            End If
        End If
    End Sub
End Class
