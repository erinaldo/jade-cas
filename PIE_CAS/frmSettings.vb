
Public Class frmSettings
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "Settings"
    Dim WTAX_uFlag As Boolean = False ' UPDATE FLAG OF WTAX
    Dim WTAX_vFlag As Boolean = False ' VALIDATE FLAG OF WTAX
    Dim VAT_uFlag As Boolean = False ' UPDATE FLAG OF VAT
    Dim VAT_vFlag As Boolean = False ' VALIDATE FLAG OF VAT
    Dim branch_uFlag As Boolean = False ' UPDATE FLAG OF BRANCH
    Dim busType_uFlag As Boolean = False ' UPDATE FLAG OF BUSINESS TYPE

    Dim WTAX_dtCellBackColor As New DataTable

    Private Sub TreeView1_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Select Case TreeView1.SelectedNode.Text
            Case "User Account"
                tcSettings.SelectedTab = tpUA
            Case "Chart of Account"
                tcSettings.SelectedTab = tpCOA
            Case "Transaction ID"
                tcSettings.SelectedTab = tpGeneral
            Case "VCE Setup"
                tcSettings.SelectedTab = tpGeneral
            Case "Purchasing"
                tcSettings.SelectedTab = tpPurchase
            Case "Accounts Payable"
                tcSettings.SelectedTab = tpAPV
            Case "Tax Setup"
                tcSettings.SelectedTab = tpTax
            Case "Branch Setup"
                tcSettings.SelectedTab = tpBranch
            Case "Business Type Setup"
                tcSettings.SelectedTab = tpBusiType
            Case "Maintenance Group"
                tcSettings.SelectedTab = tpMaintGroup
            Case "Sales"
                tcSettings.SelectedTab = tpSales
            Case "Inventory"
                tcSettings.SelectedTab = tpInventory
            Case "Cooperative"
                tcSettings.SelectedTab = tpCoop
        End Select
    End Sub

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadTransType()
        loadWTAX()
        loadVAT()
        loadBranch()
        loadBusinessType()
        loadCC()
        loadPC()
        loadWH()
        loadSales()
        loadPurchases()
        loadInventory()
        loadCoop()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        updateVatTable()
        updateWtaxTable()
        updateBranch()
        updateBusinessType()
        updateCC()
        updatePC()
        updateWH()
        updateSales()
        updatePurchases()
        updateInventory()
        updateTrans()
        updateCoop()
        Msg("Changes Saved Successfully!", MsgBoxStyle.Information)
    End Sub

    Private Sub UpdateCOAsetup()
        Dim updateSQL As String
        updateSQL = " UPDATE tblSystemSetup " & _
                    " SET       COA_Auto = @COA_Auto, COA_AccntFormat = @COA_AccntFormat "
        SQL.FlushParams()
        SQL.AddParam("@COA_Auto", chkCOAauto.Checked)
        SQL.AddParam("@COA_AccntFormat", cbCOAformat.SelectedItem)
        SQL.ExecNonQuery(updateSQL)
        Msg("Record Updated Successfully", MsgBoxStyle.Information)
    End Sub

    Private Sub chkCOAauto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCOAauto.CheckedChanged
        If chkCOAauto.Checked = True Then
            cbCOAformat.DropDownStyle = ComboBoxStyle.DropDown
        Else
            cbCOAformat.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub

  

   

 

   

#Region "TRANSACTIONS ID SETUP"
    Private Sub LoadTransType()
        LoadTransHeader()
        LoadTransDetails()
    End Sub

    Private Sub LoadTransHeader()
        Dim query As String
        query = " SELECT TransType, Description, AutoSeries, GlobalSeries FROM tblTransactionSetup "
        SQL.ReadQuery(query)
        dgvTransID.Rows.Clear()
        While SQL.SQLDR.Read
            dgvTransID.Rows.Add({SQL.SQLDR("TransType").ToString, SQL.SQLDR("Description").ToString, SQL.SQLDR("AutoSeries").ToString, SQL.SQLDR("GlobalSeries").ToString})
        End While
    End Sub

    Private Sub LoadTransDetails()
        Dim query As String
        query = " SELECT TransType, BranchCode, BusinessCode, Prefix, Digits  " & _
                " FROM tblTransactionDetails "
        SQL.ReadQuery(query)
        dgvTransDetailsAll.Rows.Clear()
        While SQL.SQLDR.Read
            dgvTransDetailsAll.Rows.Add({SQL.SQLDR("TransType").ToString, SQL.SQLDR("BranchCode").ToString, SQL.SQLDR("BusinessCode").ToString, _
                                    SQL.SQLDR("Prefix").ToString, SQL.SQLDR("Digits").ToString})
        End While
    End Sub

    Private Sub chkTransAuto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTransAuto.CheckedChanged
        If disableEvent = False Then
            If chkTransAuto.Checked = False Then
                dgvTransDetail.Enabled = False
                dgvTransDetail.Rows.Clear()
            Else
                dgvTransDetail.Enabled = True
                If dgvTransID.SelectedRows.Count > 0 Then
                    LoadSeriesDetails(dgvTransID.SelectedRows(0).Cells(dgcTransType.Index).Value.ToString)
                End If
            End If
            dgvTransID.SelectedRows(0).Cells(dgcTransAuto.Index).Value = chkTransAuto.Checked
        End If
    End Sub

    Private Sub chkGlobal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkGlobal.CheckedChanged
        If disableEvent = False Then
            If dgvTransID.SelectedRows.Count > 0 Then
                LoadSeriesDetails(dgvTransID.SelectedRows(0).Cells(dgcTransType.Index).Value.ToString)
            End If
            dgvTransID.SelectedRows(0).Cells(dgcTransGlobal.Index).Value = chkGlobal.Checked
        End If
    End Sub

    Private Sub dgvTransID_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransID.CellClick
        If dgvTransID.SelectedRows.Count = 1 Then
            disableEvent = True
            chkTransAuto.Checked = dgvTransID.SelectedRows(0).Cells(dgcTransAuto.Index).Value
            chkGlobal.Checked = dgvTransID.SelectedRows(0).Cells(dgcTransGlobal.Index).Value
            LoadSeriesDetails(dgvTransID.SelectedRows(0).Cells(dgcTransType.Index).Value.ToString)
            disableEvent = False
        End If
    End Sub

    Private Sub LoadSeriesDetails(ByRef Type As String)
        Dim query As String
        If chkGlobal.Checked = True Then
            dgvTransDetail.Rows.Clear()
            For Each row As DataGridViewRow In dgvTransDetailsAll.Rows
                If row.Cells(dgcTransAllType.Index).Value.ToString = Type Then
                    dgvTransDetail.Rows.Add({row.Cells(dgcTransAllBranch.Index).Value.ToString, row.Cells(dgcTransAllBus.Index).Value.ToString, _
                                                 row.Cells(dgcTransAllPrefix.Index).Value.ToString, row.Cells(dgcTransAlldigit.Index).Value.ToString})
                End If
            Next
            If dgvTransDetail.Rows.Count = 0 Then
                dgvTransDetail.Rows.Add({"All", "All", "", "6"})
            End If
        Else
            query = " SELECT	A.BranchCode, A.BusinessCode,  " & _
                " 		ISNULL(B.Prefix,ROW_NUMBER() OVER (ORDER BY A.BranchCode, A.BusinessCode)) AS Prefix, ISNULL(B.Digits,6) AS Digits " & _
                " FROM  " & _
                " ( " & _
                " 	SELECT	BranchCode, BusinessCode  " & _
                " 	FROM	tblBranch CROSS JOIN tblBusinessType " & _
                " ) AS A LEFT JOIN  " & _
                " ( " & _
                " 	SELECT TransType, BranchCode, BusinessCode, Prefix, Digits  " & _
                " 	FROM tblTransactionDetails " & _
                " 	WHERE  TransType ='PR' " & _
                " ) AS B " & _
                " ON		A.BranchCode = B.BranchCode " & _
                " AND		A.BusinessCode = B.BusinessCode "
            SQL.ReadQuery(query)
            dgvTransDetail.Rows.Clear()
            While SQL.SQLDR.Read
                dgvTransDetail.Rows.Add({SQL.SQLDR("BranchCode").ToString, SQL.SQLDR("BusinessCode").ToString, _
                                            SQL.SQLDR("Prefix").ToString, SQL.SQLDR("Digits").ToString})
            End While
        End If
    End Sub

    Private Sub updateTrans()
        Try
            Dim updateSQL As String
            For Each row As DataGridViewRow In dgvTransID.Rows
                updateSQL = " UPDATE    tblTransactionSetup " & _
                                   " SET       AutoSeries = @AutoSeries, GlobalSeries = @GlobalSeries " & _
                                   " WHERE     TransType = @TransType"
                SQL.FlushParams()
                SQL.AddParam("@TransType", row.Cells(dgcTransType.Index).Value)
                SQL.AddParam("@AutoSeries", row.Cells(dgcTransAuto.Index).Value)
                SQL.AddParam("@GlobalSeries", row.Cells(dgcTransGlobal.Index).Value)
                SQL.ExecNonQuery(updateSQL)
            Next
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub
#End Region
   
#Region "TAX MAINTENANCE"

#Region "VAT"

    Private Sub loadVAT()
        Dim query As String
        query = " SELECT   TaxCode, TaxDescription, TaxAlias, TaxRate,  AccntCode, AccountTitle " & _
                " FROM     tblTaxMaintenance LEFT JOIN tblCOA_Master " & _
                " ON	   tblTaxMaintenance.AccntCode = tblCOA_Master.AccountCode " & _
                " WHERE    tblTaxMaintenance.Status = 'Active' " & _
                " AND      TaxType = 'VAT' "
        SQL.ReadQuery(query)
        dgvVAT.Rows.Clear()
        While SQL.SQLDR.Read
            dgvVAT.Rows.Add(SQL.SQLDR("TaxCode").ToString, SQL.SQLDR("TaxDescription").ToString, SQL.SQLDR("TaxAlias").ToString, _
                             CDec(SQL.SQLDR("TaxRate")).ToString("N2"), SQL.SQLDR("AccntCode").ToString, SQL.SQLDR("AccountTitle").ToString)
        End While
    End Sub

    ' SET VAT UPDATED FLAG TO TRUE WHEN THERE ARE CHANGES IN VAT DATAGRIDVIEW
    Private Sub dgvVAT_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVAT.CellEndEdit
        If disableEvent = False Then
            VAT_uFlag = True
            ValueCheck(e.RowIndex, e.ColumnIndex)
            If e.ColumnIndex = dgcVatAccntTitle.Index Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", dgvVAT.Item(dgcVatAccntTitle.Index, e.RowIndex).Value.ToString)
                dgvVAT.Item(dgcVatAccntCode.Index, e.RowIndex).Value = f.accountcode
                dgvVAT.Item(dgcVatAccntTitle.Index, e.RowIndex).Value = f.accttile
                f.Dispose()
            End If
        End If
    End Sub

    Private Sub updateVatTable()
        Try
            Dim deleteSQL As String
            Dim insertSQL As String

            ' UPDATE VAT TABLE IF THERE ARE CHANGES IN VAT DATAGRID
            If VAT_uFlag Then
                '       SET OLD RECORDS AS INACTIVE
                deleteSQL = "UPDATE tblTaxMaintenance SET Status ='Inactive', DateModified = GETDATE(), WhoModified = '" & UserID & "' WHERE TaxType = 'VAT' AND Status ='Active' "
                SQL.ExecNonQuery(deleteSQL)

                '       INSERT UPDATED RECORDS
                insertSQL = " INSERT INTO " & _
                                " tblTaxMaintenance(TaxType, TaxCode, TaxDescription, TaxRate, TaxAlias, AccntCode, WhoCreated, Status) " & _
                                " VALUES(@TaxType, @TaxCode, @TaxDescription, @TaxRate, @TaxAlias, @AccntCode,  @WhoCreated, 'Active') "
                For Each row As DataGridViewRow In dgvVAT.Rows
                    If row.Cells(dgcVatCode.Index).Value = Nothing Then
                        Exit For
                    End If
                    SQL.FlushParams()
                    SQL.AddParam("@TaxType", "VAT")
                    SQL.AddParam("@TaxCode", row.Cells(dgcVatCode.Index).Value.ToString)

                    If row.Cells(dgcVatDesc.Index).Value = Nothing Then
                        SQL.AddParam("@TaxDescription", "")
                    Else
                        SQL.AddParam("@TaxDescription", row.Cells(dgcVatDesc.Index).Value.ToString)
                    End If


                    If row.Cells(dgcVatAlias.Index).Value = Nothing Then
                        SQL.AddParam("@TaxAlias", "")
                    Else
                        SQL.AddParam("@TaxAlias", row.Cells(dgcVatAlias.Index).Value.ToString)
                    End If

                    If row.Cells(dgcVatRate.Index).Value = Nothing Then
                        SQL.AddParam("@TaxRate", 0)
                    ElseIf Not IsNumeric(row.Cells(dgcVatRate.Index).Value) Then
                        SQL.AddParam("@TaxRate", 0)
                    Else
                        SQL.AddParam("@TaxRate", row.Cells(dgcVatRate.Index).Value)
                    End If


                    If row.Cells(dgcVatAccntCode.Index).Value = Nothing Then
                        SQL.AddParam("@AccntCode", "")
                    Else
                        SQL.AddParam("@AccntCode", row.Cells(dgcVatAccntCode.Index).Value.ToString)
                    End If
                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                Next
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

#End Region
#Region "WTAX"

    ' LOAD WTAX TABLE INTO DATAGRIDVIEW
    Private Sub loadWTAX()
        Dim query As String
        query = " SELECT   TaxCode, TaxDescription, TaxAlias, TaxRate,  AccntCode, AccountTitle, ATC, NatureOfIncome " & _
                " FROM     tblTaxMaintenance LEFT JOIN tblCOA_Master " & _
                " ON	   tblTaxMaintenance.AccntCode = tblCOA_Master.AccountCode " & _
                " WHERE    tblTaxMaintenance.Status = 'Active' " & _
                " AND      TaxType = 'EWT' "
        SQL.ReadQuery(query)
        dgvWTAX.Rows.Clear()
        While SQL.SQLDR.Read
            dgvWTAX.Rows.Add(SQL.SQLDR("TaxCode").ToString, SQL.SQLDR("TaxDescription").ToString, SQL.SQLDR("TaxAlias").ToString, _
                             CDec(SQL.SQLDR("TaxRate")).ToString("N2"), SQL.SQLDR("AccntCode").ToString, SQL.SQLDR("AccountTitle").ToString, _
                             SQL.SQLDR("ATC").ToString, SQL.SQLDR("NatureOfIncome").ToString)
        End While
    End Sub


    ' SET WTAX UPDATED FLAG TO TRUE WHEN THERE ARE CHANGES IN VAT DATAGRIDVIEW
    Private Sub dgvWTAX_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWTAX.CellEndEdit
        If disableEvent = False Then
            WTAX_uFlag = True
            ValueCheck(e.RowIndex, e.ColumnIndex)
            If e.ColumnIndex = dgcEwtAccntTitle.Index Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", dgvWTAX.Item(dgcEwtAccntTitle.Index, e.RowIndex).Value.ToString)
                dgvWTAX.Item(dgcEwtAccountCode.Index, e.RowIndex).Value = f.accountcode
                dgvWTAX.Item(dgcEwtAccntTitle.Index, e.RowIndex).Value = f.accttile
                f.Dispose()
            End If
        End If
    End Sub


    ' FUNCTION FOR VALIDATING CELL VALUES OF WTAX DATAGRIDVIEW 
    Private Function WTAX_Validated(Optional colInd As Integer = -1) As Boolean
        Dim valid As Boolean = True
        dgvWTAX.DefaultCellStyle.BackColor = Color.White
        If dgvWTAX.Rows.Count > 1 Then
            For i As Integer = 0 To dgvWTAX.Rows.Count - 2
                If colInd = -1 Then
                    For Each col As DataGridViewColumn In dgvWTAX.Columns
                        ValueCheck(i, col.Index)
                    Next
                Else
                    ValueCheck(i, colInd)
                End If
            Next
        End If
        Return valid
    End Function

    ' FUNCTION FOR VALIDATING CELL VALUES OF WTAX DATAGRIDVIEW 
    Private Function ValueCheck(ByRef RowIndex As Integer, ByRef ColIndex As Integer) As Boolean
        Select Case ColIndex
            Case dgcEwtCode.Index
                If IsNothing(dgvWTAX.Item(ColIndex, RowIndex).Value) Then   ' VALIDATE TAX CODE
                    dgvWTAX.Item(ColIndex, RowIndex).Style.BackColor = Color.Yellow
                    WTAX_dtCellBackColor.Rows.Add(ColIndex, RowIndex)
                    Msg("Please enter tax code", MsgBoxStyle.Exclamation)
                    Return False
                Else
                    dgvWTAX.Item(ColIndex, RowIndex).Style.BackColor = Color.White
                End If
            Case dgcEwtDesc.Index
                If IsNothing(dgvWTAX.Item(ColIndex, RowIndex).Value) Then   ' VALIDATE TAX DESCRIPTION
                    dgvWTAX.Item(ColIndex, RowIndex).Style.BackColor = Color.Yellow
                    Msg("Please enter tax description", MsgBoxStyle.Exclamation)
                    Return False
                Else
                    dgvWTAX.Item(ColIndex, RowIndex).Style.BackColor = Color.White
                End If
            Case dgcEwtAlias.Index
                If IsNothing(dgvWTAX.Item(ColIndex, RowIndex).Value) Then   ' VALIDATE TAX ALIAS
                    dgvWTAX.Item(ColIndex, RowIndex).Value = ""
                    Return False
                End If
            Case dgcEwtRate.Index
                If IsNothing(dgvWTAX.Item(ColIndex, RowIndex).Value) Then   ' VALIDATE TAX RATE
                    dgvWTAX.Item(ColIndex, RowIndex).Style.BackColor = Color.Yellow
                    Msg("Please enter tax rate", MsgBoxStyle.Exclamation)
                    Return False
                ElseIf Not IsNumeric(dgvWTAX.Item(ColIndex, RowIndex).Value) Then
                    dgvWTAX.Item(ColIndex, RowIndex).Style.BackColor = Color.Yellow
                    Msg("Invalid Tax Rate", MsgBoxStyle.Exclamation)

                    dgvWTAX.Item(ColIndex, RowIndex).Selected = True
                    Return False
                Else
                    dgvWTAX.Item(ColIndex, RowIndex).Style.BackColor = Color.White
                End If
            Case dgcEwtAccountCode.Index
                If IsNothing(dgvWTAX.Item(ColIndex, RowIndex).Value) Then   ' VALIDATE ACCOUNT CODE 
                    dgvWTAX.Item(ColIndex, RowIndex).Value = ""
                    Return False
                End If
            Case dgcEwtATC.Index
                If IsNothing(dgvWTAX.Item(ColIndex, RowIndex).Value) Then   ' VALIDATE ATC
                    dgvWTAX.Item(ColIndex, RowIndex).Value = ""
                    Return False
                End If
            Case dgcEwtNature.Index
                If IsNothing(dgvWTAX.Item(ColIndex, RowIndex).Value) Then   ' VALIDATE NATURE OF INCOME
                    dgvWTAX.Item(ColIndex, RowIndex).Value = ""
                    Return False
                End If
        End Select
    End Function

    ' SUB FOR UPDATING WTAX TABLE
    Private Sub updateWtaxTable()
        Try
            Dim updateSQL As String
            Dim insertSQL As String
            ' UPDATE WTAX TABLE IF THERE ARE CHANGES IN WTAX DATAGRID
            If WTAX_uFlag Then
                '       SET OLD RECORDS AS INACTIVE
                updateSQL = "UPDATE tblTaxMaintenance SET Status ='Inactive', DateModified = GETDATE(), WhoModified = '" & UserID & "' WHERE TaxType = 'EWT' AND Status ='Active' "
                SQL.ExecNonQuery(updateSQL)

                '       INSERT UPDATED RECORDS
                insertSQL = " INSERT INTO " & _
                                " tblTaxMaintenance(TaxType, TaxCode, TaxDescription, TaxRate, TaxAlias, AccntCode, ATC, NatureOfIncome, Status, WhoCreated) " & _
                                " VALUES(@TaxType, @TaxCode, @TaxDescription, @TaxRate, @TaxAlias, @AccntCode, @ATC, @NatureOfIncome, 'Active', @WhoCreated) "

                For Each row As DataGridViewRow In dgvWTAX.Rows
                    If row.Cells(dgcEwtCode.Index).Value = Nothing Then
                        Exit For
                    End If
                    SQL.FlushParams()
                    SQL.AddParam("@TaxType", "EWT")
                    SQL.AddParam("@TaxCode", row.Cells(dgcEwtCode.Index).Value.ToString)

                    If row.Cells(dgcEwtDesc.Index).Value = Nothing Then
                        SQL.AddParam("@TaxDescription", "")
                    Else
                        SQL.AddParam("@TaxDescription", row.Cells(dgcEwtDesc.Index).Value.ToString)
                    End If


                    If row.Cells(dgcEwtAlias.Index).Value = Nothing Then
                        SQL.AddParam("@TaxAlias", "")
                    Else
                        SQL.AddParam("@TaxAlias", row.Cells(dgcEwtAlias.Index).Value.ToString)
                    End If

                    If row.Cells(dgcEwtRate.Index).Value = Nothing Then
                        SQL.AddParam("@TaxRate", 0)
                    ElseIf Not IsNumeric(row.Cells(dgcEwtRate.Index).Value) Then
                        SQL.AddParam("@TaxRate", 0)
                    Else
                        SQL.AddParam("@TaxRate", row.Cells(dgcEwtRate.Index).Value)
                    End If


                    If row.Cells(dgcEwtAccountCode.Index).Value = Nothing Then
                        SQL.AddParam("@AccntCode", "")
                    Else
                        SQL.AddParam("@AccntCode", row.Cells(dgcEwtAccountCode.Index).Value.ToString)
                    End If


                    If row.Cells(dgcEwtATC.Index).Value = Nothing Then
                        SQL.AddParam("@ATC", "")
                    Else
                        SQL.AddParam("@ATC", row.Cells(dgcEwtATC.Index).Value.ToString)
                    End If


                    If row.Cells(dgcEwtNature.Index).Value = Nothing Then
                        SQL.AddParam("@NatureOfIncome", "")
                    Else
                        SQL.AddParam("@NatureOfIncome", row.Cells(dgcEwtNature.Index).Value.ToString)
                    End If

                    SQL.AddParam("@WhoCreated", UserID)
                    SQL.ExecNonQuery(insertSQL)
                Next
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

#End Region

#End Region

#Region "BUSINESS TYPE"
    Private Sub loadBusinessType()
        Dim query As String
        query = " SELECT   BusinessCode, Description  " & _
                " FROM     tblBusinessType " & _
                " WHERE    Status = 'Active' "
        SQL.ReadQuery(query)
        dgvBusType.Rows.Clear()
        While SQL.SQLDR.Read
            dgvBusType.Rows.Add(SQL.SQLDR("BusinessCode").ToString, SQL.SQLDR("BusinessCode").ToString, SQL.SQLDR("Description").ToString)
        End While
    End Sub

    Private Sub dgvBusType_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBusType.CellEndEdit
        busType_uFlag = True
    End Sub

    Private Sub updateBusinessType()
        Try
            Dim updateSQL As String
            Dim insertSQL As String
            ' UPDATE WTAX TABLE IF THERE ARE CHANGES IN WTAX DATAGRID
            If busType_uFlag Then
                '       SET OLD RECORDS AS INACTIVE
                updateSQL = "UPDATE tblBusinessType SET Status ='Inactive', DateModified = GETDATE(), WhoModified = '" & UserID & "' WHERE Status ='Active' "
                SQL.ExecNonQuery(updateSQL)


                '       INSERT UPDATED RECORDS
                insertSQL = " INSERT INTO " & _
                            " tblBusinessType(BusinessCode, Description, WhoCreated) " & _
                            " VALUES(@BusinessCode, @Description, @WhoCreated) "
                updateSQL = " UPDATE tblBusinessType " & _
                            " SET  BusinessCode = @BusinessCodeNew, Description = @Description, WhoModified = @WhoModified, DateModified = GETDATE(), Status ='Active' " & _
                            " WHERE BusinessCode = @BusinessCodeOld "
                For Each row As DataGridViewRow In dgvBusType.Rows
                    If row.Cells(dgcBusType.Index).Value = Nothing Then
                        Exit For
                    End If
                    If BusinessTypeExist(row.Cells(dgcBusTypeOld.Index).Value) Then ' CHECK IF CODE ALREADY EXIST
                        SQL.FlushParams()
                        SQL.AddParam("@BusinessCodeOld", row.Cells(dgcBusTypeOld.Index).Value.ToString)
                        SQL.AddParam("@BusinessCodeNew", row.Cells(dgcBusType.Index).Value.ToString)
                        If row.Cells(dgcBusTypeDesc.Index).Value = Nothing Then
                            SQL.AddParam("@Description", "")
                        Else
                            SQL.AddParam("@Description", row.Cells(dgcBusTypeDesc.Index).Value.ToString)
                        End If

                        SQL.AddParam("@WhoModified", UserID)
                        SQL.ExecNonQuery(updateSQL)
                    Else
                        SQL.FlushParams()
                        SQL.AddParam("@BusinessCode", row.Cells(dgcBusType.Index).Value.ToString)

                        If row.Cells(dgcBusTypeDesc.Index).Value = Nothing Then
                            SQL.AddParam("@Description", "")
                        Else
                            SQL.AddParam("@Description", row.Cells(dgcBusTypeDesc.Index).Value.ToString)
                        End If

                        SQL.AddParam("@WhoCreated", UserID)
                        SQL.ExecNonQuery(insertSQL)
                    End If
                Next
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

#End Region

#Region "BRANCH"
    Private Sub loadBranch()
        Dim query As String
        query = " SELECT   BranchCode, Description, Main  " & _
                " FROM     tblBranch " & _
                " WHERE    Status = 'Active' "
        SQL.ReadQuery(query)
        dgvBranch.Rows.Clear()
        While SQL.SQLDR.Read
            dgvBranch.Rows.Add(SQL.SQLDR("BranchCode").ToString, SQL.SQLDR("BranchCode").ToString, SQL.SQLDR("Description").ToString, SQL.SQLDR("Main"))
        End While
    End Sub

    Private Sub dgvBranch_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBranch.CellEndEdit
        branch_uFlag = True
    End Sub

    Private Sub dgvBranch_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgvBranch.CurrentCellDirtyStateChanged
        If disableEvent = False Then
            If dgvBranch.SelectedCells.Count > 0 Then
                If dgvBranch.SelectedCells(0).ColumnIndex = dgcBranchMain.Index Then
                    If dgvBranch.SelectedCells(0).RowIndex <> -1 Then
                        dgvBranch.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    End If
                End If
            End If
        End If
        
    End Sub

    Private Sub dgvBranch_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBranch.CellValueChanged
        If disableEvent = False Then
            If dgvBranch.SelectedCells.Count > 0 Then
                If e.ColumnIndex = dgcBranchMain.Index Then
                    For Each row As DataGridViewRow In dgvBranch.Rows
                        If row.Index <> e.RowIndex Then
                            disableEvent = True
                            row.Cells(dgcBranchMain.Index).Value = False
                            disableEvent = False
                        End If
                    Next
                End If
            End If
        End If
     
    End Sub



    Private Sub updateBranch()
        Try
            Dim updateSQL As String
            Dim insertSQL As String
            ' UPDATE WTAX TABLE IF THERE ARE CHANGES IN WTAX DATAGRID
            If branch_uFlag Then
                '       SET OLD RECORDS AS INACTIVE
                updateSQL = "UPDATE tblBranch SET Status ='Inactive', DateModified = GETDATE(), WhoModified = '" & UserID & "' WHERE Status ='Active' "
                SQL.ExecNonQuery(updateSQL)

             
                '       INSERT UPDATED RECORDS
                insertSQL = " INSERT INTO " & _
                            " tblBranch(BranchCode, Description, Main, WhoCreated) " & _
                            " VALUES(@BranchCode, @Description, @Main, @WhoCreated) "
                updateSQL = " UPDATE tblBranch " & _
                            " SET  BranchCode = @BranchCodeNew, Description = @Description, Main = @Main, WhoModified = @WhoModified, DateModified = GETDATE(), Status ='Active' " & _
                            " WHERE BranchCode = @BranchCodeOld "
                For Each row As DataGridViewRow In dgvBranch.Rows
                    If row.Cells(dgcBranchCode.Index).Value = Nothing Then
                        Exit For
                    End If
                    If BranchExist(row.Cells(dgcBranchOldCode.Index).Value) Then ' CHECK IF CODE ALREADY EXIST
                        SQL.FlushParams()
                        SQL.AddParam("@BranchCodeOld", row.Cells(dgcBranchOldCode.Index).Value.ToString)
                        SQL.AddParam("@BranchCodeNew", row.Cells(dgcBranchCode.Index).Value.ToString)
                        If row.Cells(dgcBranchName.Index).Value = Nothing Then
                            SQL.AddParam("@Description", "")
                        Else
                            SQL.AddParam("@Description", row.Cells(dgcBranchName.Index).Value.ToString)
                        End If

                        If row.Cells(dgcBranchMain.Index).Value = Nothing Then
                            SQL.AddParam("@Main", "")
                        Else
                            SQL.AddParam("@Main", row.Cells(dgcBranchMain.Index).Value.ToString)
                        End If

                        SQL.AddParam("@WhoModified", UserID)
                        SQL.ExecNonQuery(updateSQL)
                    Else
                        SQL.FlushParams()
                        SQL.AddParam("@BranchCode", row.Cells(dgcBranchCode.Index).Value.ToString)

                        If row.Cells(dgcBranchName.Index).Value = Nothing Then
                            SQL.AddParam("@Description", "")
                        Else
                            SQL.AddParam("@Description", row.Cells(dgcBranchName.Index).Value.ToString)
                        End If

                        If row.Cells(dgcBranchMain.Index).Value = Nothing Then
                            SQL.AddParam("@Main", "")
                        Else
                            SQL.AddParam("@Main", row.Cells(dgcBranchMain.Index).Value.ToString)
                        End If

                        SQL.AddParam("@WhoCreated", UserID)
                        SQL.ExecNonQuery(insertSQL)
                    End If
                Next
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

 

#End Region

#Region "COST CENTER"
    Dim oldCCG1, oldCCG2, oldCCG3, oldCCG4, oldCCG5 As String

    Private Sub loadCC()
        Dim query As String
        query = " SELECT GroupID, Description FROM tblGroup WHERE type ='Cost Center' AND Status ='Active' "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            Select Case SQL.SQLDR("GroupID").ToString
                Case "G1"
                    txtCCG1.Text = SQL.SQLDR("Description").ToString
                Case "G2"
                    txtCCG2.Text = SQL.SQLDR("Description").ToString
                Case "G3"
                    txtCCG3.Text = SQL.SQLDR("Description").ToString
                Case "G4"
                    txtCCG4.Text = SQL.SQLDR("Description").ToString
                Case "G5"
                    txtCCG5.Text = SQL.SQLDR("Description").ToString
            End Select
        End While
        oldCCG1 = txtCCG1.Text
        oldCCG2 = txtCCG2.Text
        oldCCG3 = txtCCG3.Text
        oldCCG4 = txtCCG4.Text
        oldCCG5 = txtCCG5.Text
    End Sub

    Private Sub updateCC()
        If txtCCG1.Text <> oldCCG1 Or txtCCG2.Text <> oldCCG2 Or txtCCG3.Text <> oldCCG3 Or txtCCG4.Text <> oldCCG4 Or txtCCG5.Text <> oldCCG5 Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblGroup  SET Status ='Inactive' WHERE Type ='Cost Center' "
            SQL.ExecNonQuery(updateSQL)
            If txtCCG1.Text <> "" Then SaveGroup("Cost Center", "G1", txtCCG1)
            If txtCCG2.Text <> "" Then SaveGroup("Cost Center", "G2", txtCCG2)
            If txtCCG3.Text <> "" Then SaveGroup("Cost Center", "G3", txtCCG3)
            If txtCCG4.Text <> "" Then SaveGroup("Cost Center", "G4", txtCCG4)
            If txtCCG5.Text <> "" Then SaveGroup("Cost Center", "G5", txtCCG5)
        End If
    End Sub
#End Region

#Region "PROFIT CENTER"
    Dim oldPCG1, oldPCG2, oldPCG3, oldPCG4, oldPCG5 As String

    Private Sub loadPC()
        Dim query As String
        query = " SELECT GroupID, Description FROM tblGroup WHERE type ='Profit Center' AND Status ='Active' "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            Select Case SQL.SQLDR("GroupID").ToString
                Case "G1"
                    txtPCG1.Text = SQL.SQLDR("Description").ToString
                Case "G2"
                    txtPCG2.Text = SQL.SQLDR("Description").ToString
                Case "G3"
                    txtPCG3.Text = SQL.SQLDR("Description").ToString
                Case "G4"
                    txtPCG4.Text = SQL.SQLDR("Description").ToString
                Case "G5"
                    txtPCG5.Text = SQL.SQLDR("Description").ToString
            End Select
        End While
        oldPCG1 = txtPCG1.Text
        oldPCG2 = txtPCG2.Text
        oldPCG3 = txtPCG3.Text
        oldPCG4 = txtPCG4.Text
        oldPCG5 = txtPCG5.Text
    End Sub

    Private Sub updatePC()
        If txtPCG1.Text <> oldPCG1 Or txtPCG2.Text <> oldPCG2 Or txtPCG3.Text <> oldPCG3 Or txtPCG4.Text <> oldPCG4 Or txtPCG5.Text <> oldPCG5 Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblGroup  SET Status ='Inactive' WHERE Type ='Profit Center' "
            SQL.ExecNonQuery(updateSQL)
            If txtPCG1.Text <> "" Then SaveGroup("Profit Center", "G1", txtPCG1)
            If txtPCG2.Text <> "" Then SaveGroup("Profit Center", "G2", txtPCG2)
            If txtPCG3.Text <> "" Then SaveGroup("Profit Center", "G3", txtPCG3)
            If txtPCG4.Text <> "" Then SaveGroup("Profit Center", "G4", txtPCG4)
            If txtPCG5.Text <> "" Then SaveGroup("Profit Center", "G5", txtCCG5)
        End If
    End Sub
#End Region

#Region "WAREHOUSE"
    Private Sub LoadWH()
        loadInvWH()
        loadProdWH()
    End Sub

    Private Sub UpdateWH()
        updateInvWH()
        updateProdWH()
    End Sub

#Region "INVENTORY WAREHOUSE"
    Dim oldWHG1, oldWHG2, oldWHG3, oldWHG4, oldWHG5 As String

    Private Sub loadInvWH()
        Dim query As String
        query = " SELECT GroupID, Description FROM tblGroup WHERE type ='Warehouse' AND Status ='Active' "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            Select Case SQL.SQLDR("GroupID").ToString
                Case "G1"
                    txtWHG1.Text = SQL.SQLDR("Description").ToString
                Case "G2"
                    txtWHG2.Text = SQL.SQLDR("Description").ToString
                Case "G3"
                    txtWHG3.Text = SQL.SQLDR("Description").ToString
                Case "G4"
                    txtWHG4.Text = SQL.SQLDR("Description").ToString
                Case "G5"
                    txtWHG5.Text = SQL.SQLDR("Description").ToString
            End Select
        End While
        oldWHG1 = txtWHG1.Text
        oldWHG2 = txtWHG2.Text
        oldWHG3 = txtWHG3.Text
        oldWHG4 = txtWHG4.Text
        oldWHG5 = txtWHG5.Text
    End Sub

    Private Sub updateInvWH()
        If txtWHG1.Text <> oldWHG1 Or txtWHG2.Text <> oldWHG2 Or txtWHG3.Text <> oldWHG3 Or txtWHG4.Text <> oldWHG4 Or txtWHG5.Text <> oldWHG5 Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblGroup  SET Status ='Inactive' WHERE Type ='Warehouse' "
            SQL.ExecNonQuery(updateSQL)
            If txtWHG1.Text <> "" Then SaveGroup("Warehouse", "G1", txtWHG1)
            If txtWHG2.Text <> "" Then SaveGroup("Warehouse", "G2", txtWHG2)
            If txtWHG3.Text <> "" Then SaveGroup("Warehouse", "G3", txtWHG3)
            If txtWHG4.Text <> "" Then SaveGroup("Warehouse", "G4", txtWHG4)
            If txtWHG5.Text <> "" Then SaveGroup("Warehouse", "G5", txtWHG5)
        End If
    End Sub
#End Region
#Region "PRODUCTION WAREHOUSE"
    Dim oldPWHG1, oldPWHG2, oldPWHG3, oldPWHG4, oldPWHG5 As String

    Private Sub loadProdWH()
        Dim query As String
        query = " SELECT GroupID, Description FROM tblGroup WHERE type ='Production Warehouse' AND Status ='Active' "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            Select Case SQL.SQLDR("GroupID").ToString
                Case "G1"
                    txtPWHG1.Text = SQL.SQLDR("Description").ToString
                Case "G2"
                    txtPWHG2.Text = SQL.SQLDR("Description").ToString
                Case "G3"
                    txtPWHG3.Text = SQL.SQLDR("Description").ToString
                Case "G4"
                    txtPWHG4.Text = SQL.SQLDR("Description").ToString
                Case "G5"
                    txtPWHG5.Text = SQL.SQLDR("Description").ToString
            End Select
        End While
        oldPWHG1 = txtPWHG1.Text
        oldPWHG2 = txtPWHG2.Text
        oldPWHG3 = txtPWHG3.Text
        oldPWHG4 = txtPWHG4.Text
        oldPWHG5 = txtPWHG5.Text
    End Sub

    Private Sub updateProdWH()
        If txtPWHG1.Text <> oldPWHG1 Or txtPWHG2.Text <> oldPWHG2 Or txtPWHG3.Text <> oldPWHG3 Or txtPWHG4.Text <> oldPWHG4 Or txtPWHG5.Text <> oldPWHG5 Then
            Dim updateSQL As String
            updateSQL = " UPDATE tblGroup SET Status ='Inactive' WHERE Type ='Production Warehouse' "
            SQL.ExecNonQuery(updateSQL)
            If txtPWHG1.Text <> "" Then SaveGroup("Production Warehouse", "G1", txtPWHG1)
            If txtPWHG2.Text <> "" Then SaveGroup("Production Warehouse", "G2", txtPWHG2)
            If txtPWHG3.Text <> "" Then SaveGroup("Production Warehouse", "G3", txtPWHG3)
            If txtPWHG4.Text <> "" Then SaveGroup("Production Warehouse", "G4", txtPWHG4)
            If txtPWHG5.Text <> "" Then SaveGroup("Production Warehouse", "G5", txtPWHG5)
        End If
    End Sub
#End Region

#End Region

#Region "SALES"
    Private Sub loadSales()
        Dim query As String
        query = " SELECT  ISNULL(SO_EditPrice,0) AS SO_EditPrice, ISNULL(SO_ReqPO,0) AS SO_ReqPO FROM tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            chkSOeditPrice.Checked = SQL.SQLDR("SO_EditPrice")
            chkSOreqPO.Checked = SQL.SQLDR("SO_ReqPO")
        End If
    End Sub

    Private Sub updateSales()
        Try
            Dim updateSQL As String
            updateSQL = " UPDATE tblSystemSetup " & _
                        " SET    SO_EditPrice = @SO_EditPrice, SO_ReqPO = @SO_ReqPO "
            SQL.FlushParams()
            SQL.AddParam("@SO_EditPrice", chkSOeditPrice.Checked)
            SQL.AddParam("@SO_ReqPO", chkSOreqPO.Checked)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
       
    End Sub
#End Region

#Region "PURCHASES"
    Private Sub loadPurchases()
        LoadWarehouseLevel()
        loadPurchaseData()
    End Sub

    Private Sub LoadWarehouseLevel()
        Dim query As String
        query = " SELECT Description FROm tblGroup WHERE Type ='Warehouse' AND Status ='Active' "
        SQL.ReadQuery(query)
        cbPRstock.Items.Clear()
        While SQL.SQLDR.Read
            cbPRstock.Items.Add(SQL.SQLDR("Description").ToString)
        End While
    End Sub

    Private Sub loadPurchaseData()
        Dim WHgroup As String = ""
        Dim query As String
        query = " SELECT  ISNULL(PR_StockLevel,0) AS PR_StockLevel, ISNULL(PO_Approval,0) AS PO_Approval FROM tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            WHgroup = SQL.SQLDR("PR_StockLevel").ToString
            chkPOapproval.Checked = SQL.SQLDR("PO_Approval")
            cbPRstock.SelectedItem = GetGroupDesc(WHgroup)
        End If
    End Sub


    Private Sub updatePurchases()
        Try
            Dim groupID As String = ""
            ' GET WAREHOUSE GROUP ID
            If cbPRstock.SelectedIndex <> -1 Then
                groupID = GetGroupID(cbPRstock.SelectedItem)
            End If

            Dim updateSQL As String
            updateSQL = " UPDATE tblSystemSetup " & _
                        " SET    PR_StockLevel = @PR_StockLevel, PO_Approval = @PO_Approval "
            SQL.FlushParams()
            SQL.AddParam("@PR_StockLevel", groupID)
            SQL.AddParam("@PO_Approval", chkPOapproval.Checked)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub


    Private Function GetGroupDesc(ByVal GroupID As String) As String
        Dim query As String
        query = " SELECT Description FROM tblGroup WHERE Type ='Warehouse' AND Status ='Active' AND GroupID = '" & GroupID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Description").ToString
        Else
            Return ""
        End If
    End Function

    Private Function GetGroupID(ByVal GroupDesc As String) As String
        Dim query As String
        query = " SELECT GroupID FROM tblGroup WHERE Type ='Warehouse' AND Status ='Active' AND Description = '" & GroupDesc & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("GroupID").ToString
        Else
            Return ""
        End If
    End Function
#End Region

#Region "INVENTORY"
    Private Sub loadInventory()
        loadInventoryData()
    End Sub

    Private Sub loadInventoryData()
        Dim query As String
        query = " SELECT  ISNULL(RR_RestrictWHSEItem,0) AS RR_RestrictWHSEItem FROM tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            chkRR_RestrictWHSEItem.Checked = SQL.SQLDR("RR_RestrictWHSEItem")
        End If
    End Sub


    Private Sub updateInventory()
        Try
            Dim updateSQL As String
            updateSQL = " UPDATE tblSystemSetup " & _
                        " SET    RR_RestrictWHSEItem = @RR_RestrictWHSEItem "
            SQL.FlushParams()
            SQL.AddParam("@RR_RestrictWHSEItem", chkRR_RestrictWHSEItem.Checked)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub
#End Region


#Region "COOPEATIVE"
    Private Sub loadCoop()
        loadCoopData()
    End Sub

    Private Sub loadCoopData()
        Dim query As String
        query = " SELECT    Coop_PUC_Common, Coop_PUC_Preferred, Coop_SC_Common, Coop_SC_Preferred, Coop_SR_Common, Coop_SR_Preferred, " & _
                "           Coop_TC_Common, Coop_TC_Preferred, Coop_DFCS " & _
                " FROM      tblSystemSetup "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            txtPUCCcode.Text = SQL.SQLDR("Coop_PUC_Common").ToString
            txtPUCPcode.Text = SQL.SQLDR("Coop_PUC_Preferred").ToString
            txtSCCcode.Text = SQL.SQLDR("Coop_SC_Common").ToString
            txtSCPcode.Text = SQL.SQLDR("Coop_SC_Preferred").ToString
            txtSRCcode.Text = SQL.SQLDR("Coop_SR_Common").ToString
            txtSRPcode.Text = SQL.SQLDR("Coop_SR_Preferred").ToString
            txtTCCcode.Text = SQL.SQLDR("Coop_TC_Common").ToString
            txtTCPcode.Text = SQL.SQLDR("Coop_TC_Preferred").ToString
            txtDFCScode.Text = SQL.SQLDR("Coop_DFCS").ToString

            ' GET ACCOUNT TITLES
            txtPUCCtitle.Text = GetAccntTitle(txtPUCCcode.Text)
            txtPUCPtitle.Text = GetAccntTitle(txtPUCPcode.Text)
            txtSCCtitle.Text = GetAccntTitle(txtSCCcode.Text)
            txtSCPtitle.Text = GetAccntTitle(txtSCPcode.Text)
            txtSRCtitle.Text = GetAccntTitle(txtSRCcode.Text)
            txtSRPtitle.Text = GetAccntTitle(txtSRPcode.Text)
            txtTCCtitle.Text = GetAccntTitle(txtTCCcode.Text)
            txtTCPtitle.Text = GetAccntTitle(txtTCPcode.Text)
            txtDFCStitle.Text = GetAccntTitle(txtDFCScode.Text)
        End If
    End Sub

    Private Sub updateCoop()
        Try

            Dim updateSQL As String
            updateSQL = " UPDATE    tblSystemSetup " & _
                        " SET       Coop_PUC_Common = @Coop_PUC_Common, Coop_PUC_Preferred = @Coop_PUC_Preferred, " & _
                        "           Coop_SC_Common = @Coop_SC_Common, Coop_SC_Preferred = @Coop_SC_Preferred, " & _
                        "           Coop_SR_Common = @Coop_SR_Common, Coop_SR_Preferred = @Coop_SR_Preferred, " & _
                        "           Coop_TC_Common = @Coop_TC_Common, Coop_TC_Preferred = @Coop_TC_Preferred, " & _
                        "           Coop_DFCS = @Coop_DFCS "
            SQL.FlushParams()
            SQL.AddParam("@Coop_PUC_Common", txtPUCCcode.Text)
            SQL.AddParam("@Coop_PUC_Preferred", txtPUCPcode.Text)
            SQL.AddParam("@Coop_SC_Common", txtSCCcode.Text)
            SQL.AddParam("@Coop_SC_Preferred", txtSCPcode.Text)
            SQL.AddParam("@Coop_SR_Common", txtSRCcode.Text)
            SQL.AddParam("@Coop_SR_Preferred", txtSRPcode.Text)
            SQL.AddParam("@Coop_TC_Common", txtTCCcode.Text)
            SQL.AddParam("@Coop_TC_Preferred", txtTCPcode.Text)
            SQL.AddParam("@Coop_DFCS", txtDFCScode.Text)
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtSCCtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSCCtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtSCCtitle.Text)
                txtSCCcode.Text = f.accountcode
                txtSCCtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtSRCtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSRCtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtSRCtitle.Text)
                txtSRCcode.Text = f.accountcode
                txtSRCtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtPUCCtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPUCCtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtPUCCtitle.Text)
                txtPUCCcode.Text = f.accountcode
                txtPUCCtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtTCCtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTCCtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtTCCtitle.Text)
                txtTCCcode.Text = f.accountcode
                txtTCCtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtSCPtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSCPtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtSCPtitle.Text)
                txtSCPcode.Text = f.accountcode
                txtSCPtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtSRPtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSRPtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtSRPtitle.Text)
                txtSRPcode.Text = f.accountcode
                txtSRPtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtPUCPtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPUCPtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtPUCPtitle.Text)
                txtPUCPcode.Text = f.accountcode
                txtPUCPtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtTCPtitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTCPtitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtTCPtitle.Text)
                txtTCPcode.Text = f.accountcode
                txtTCPtitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub txtDFCStitle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDFCStitle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim f As New frmCOA_Search
                f.ShowDialog("AccntTitle", txtDFCStitle.Text)
                txtDFCScode.Text = f.accountcode
                txtDFCStitle.Text = f.accttile
                f.Dispose()
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub
#End Region

   
End Class