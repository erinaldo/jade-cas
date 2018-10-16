Public Class frmLoadTransactions
    Dim moduleID As String
    Public transID As String = ""
    Public itemCode As String = ""

    Public Overloads Function ShowDialog(ByVal ModID As String) As Boolean
        moduleID = ModID
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmLoadTransactions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim filter As String = ""
            Dim query As String = ""

            Select Case moduleID
                Case "JO_BOM"

                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE JO_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblJO.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, JO_No AS [JO No.], DateJO AS [Date], VCEName, ItemCode, Description, QTY, Remarks  " & _
                            " FROM     tblJO LEFT JOIN tblVCE_Master " & _
                            " ON	   tblJO.VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "JO"

                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE JO_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblJO.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, JO_No AS [JO No.], DateJO AS [Date], VCEName, ItemCode, Description, QTY, Remarks,  tblJO.Status  " & _
                            " FROM     tblJO LEFT JOIN tblVCE_Master " & _
                            " ON	   tblJO.VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "BOM"

                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE BOM_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblBOM.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, BOM_No AS [BOM No.], DateBOM AS [Date], VCEName, ItemCode, Description, QTY, Remarks,  tblBOM.Status  " & _
                            " FROM     tblBOM LEFT JOIN tblVCE_Master " & _
                            " ON	   tblBOM.VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "RFP"

                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE RFP_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblRFP.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, RFP_No AS [RFP No.], DateRFP AS [Date], VCEName, Remarks,  tblRFP.Status  " & _
                            " FROM     tblRFP LEFT JOIN tblVCE_Master " & _
                            " ON	   tblRFP.VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "PR"

                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE PR_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblPR.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, PR_No AS [PR No.], DatePR AS [Date],  Remarks, DateNeeded, RequestedBy, tblPR.Status  " & _
                            " FROM     tblPR LEFT JOIN tblVCE_Master " & _
                            " ON	   tblPR.VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)

                Case "PO"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE tblPO.PO_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE viewPO_Status.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   tblPO.TransID, tblPO.PO_No AS [PO No.], DatePO AS [Date], VCEName AS [Supplier], Remarks, NetAmount, viewPO_Status.Status  " & _
                            " FROM     tblPO LEFT JOIN tblVCE_Master " & _
                            " ON	   tblPO.VCECode = tblVCE_Master.VCECode " & _
                            " LEFT JOIN	 viewPO_Status " & _
                            " ON		 tblPO.TransID = viewPO_Status.TransID " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "RR"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE RR_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblRR.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, RR_No AS [RR No.], DateRR AS [Date], VCEName AS [Supplier], Remarks, PO_Ref AS [Reference PO], tblRR.Status  " & _
                            " FROM     tblRR LEFT JOIN tblVCE_Master " & _
                            " ON	   tblRR .VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "APV"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE APV_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE tblAPV.Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE CASE WHEN View_APV_Balance.Ref_TransID IS NOT NULL THEN  'Active'  WHEN tblAPV.Status ='Active' THEN 'Closed' ELSE tblAPV.Status   END LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, tblAPV.APV_No AS [APV No.], DateAPV AS [Date], VCEName AS [Supplier], tblAPV.Remarks, PO_Ref AS [Reference PO], " & _
                            "           CASE WHEN View_APV_Balance.Ref_TransID IS NOT NULL THEN  'Active' " & _
                            "                WHEN tblAPV.Status ='Active' THEN 'Closed' ELSE tblAPV.Status   END AS Status" & _
                            " FROM     tblAPV LEFT JOIN tblVCE_Master " & _
                            " ON	   tblAPV .VCECode = tblVCE_Master.VCECode " & _
                            " LEFT JOIN View_APV_Balance " & _
                            " ON        tblAPV.TransID = View_APV_Balance.Ref_TransID " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "SQ"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE tblSQ.SQ_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblSQ.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   tblSQ.TransID, tblSQ.SQ_No AS [SQ No.], DateSQ AS [Date], VCEName AS [Customer], Remarks, NetAmount, tblSQ.Status  " & _
                            " FROM     tblSQ LEFT JOIN tblVCE_Master " & _
                            " ON	   tblSQ.VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "SO"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE tblSO.SO_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblSO.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   CAST(tblSO.TransID AS nvarchar)  AS TransID, CAST(tblSO.SO_No AS nvarchar)  AS [SO No.],  " & _
                            "          DateSO AS [Date], VCEName AS [Customer], tblSO.NetAmount, Remarks, ReferenceNo, tblSO.Status  " & _
                            " FROM     tblSO LEFT JOIN tblVCE_Master " & _
                            " ON	   tblSO.VCECode = tblVCE_Master.VCECode "
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "Sub SO"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE tblSO.SO_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE viewSO_Status.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   CAST(tblSO.TransID AS nvarchar) + '-' + CAST(tblSO_Details.LineNum AS nvarchar) AS TransID, CAST(tblSO.SO_No AS nvarchar) + '-' + CAST(tblSO_Details.LineNum AS nvarchar)  AS [SO No.],  " & _
                            "          DateSO AS [Date], VCEName AS [Customer], ItemCode, QTY, tblSO_Details.DateDeliver AS [Date Needed], ReferenceNo, viewSO_Status.Status  " & _
                            " FROM     tblSO LEFT JOIN tblSO_Details  " & _
                            " ON		   tblSO.TransID = tblSO_Details.TransID " & _
                            " LEFT JOIN tblVCE_Master " & _
                            " ON	   tblSO.VCECode = tblVCE_Master.VCECode " & _
                            " LEFT JOIN	 viewSO_Status " & _
                            " ON		 tblSO.TransID = viewSO_Status.TransID  " & _
                            " AND		 tblSO_Details.LineNUm = viewSO_Status.LineNUm  " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "DR"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE DR_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblDR.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, DR_No AS [DR No.], DateDR AS [Date], VCEName AS [Customer], Remarks, SO_Ref AS [Reference SO], tblDR.Status  " & _
                            " FROM     tblDR LEFT JOIN tblVCE_Master " & _
                            " ON	   tblDR .VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)

                Case "SI"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE SI_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblSI.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, SI_No AS [SI No.], DateSI AS [Date], VCEName AS [Customer], Remarks, SO_Ref AS [Reference SO], tblSI.Status  " & _
                            " FROM     tblSI LEFT JOIN tblVCE_Master " & _
                            " ON	   tblSI .VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "ADV"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE ADV_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblADV.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, ADV_No AS [ADV No.], DateADV AS [Date], VCEName AS [Supplier], Remarks, PO_Ref AS [Reference PO], tblADV.Status  " & _
                            " FROM     tblADV LEFT JOIN tblVCE_Master " & _
                            " ON	   tblADV .VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "CV"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE CV_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblCV.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, CV_No AS [CV No.], DateCV AS [Date], VCEName AS [Supplier], Remarks, APV_Ref AS [Reference APV], tblCV.Status  " & _
                            " FROM     tblCV LEFT JOIN tblVCE_Master " & _
                            " ON	   tblCV .VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)

                Case "GI"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE GI_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblGI.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, GI_No AS [GI No.], DateGI AS [Date], VCEName AS [VCEName], Remarks, Type AS [Type], tblGI.Status  " & _
                            " FROM     tblGI LEFT JOIN tblVCE_Master " & _
                            " ON	   tblGI .VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)

                Case "GR"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE GR_No LIKE '%' + @Filter + '%' "
                            Case "VCE Name"
                                filter = " WHERE VCEName '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblGR.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, GR_No AS [GR No.], DateGR AS [Date], VCEName AS [VCEName], Remarks, Type AS [Type], tblGR.Status  " & _
                            " FROM     tblGR LEFT JOIN tblVCE_Master " & _
                            " ON	   tblGR .VCECode = tblVCE_Master.VCECode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)

                Case "IT"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE IT_No LIKE '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblIT.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, IT_No AS [IT No.], DateIT AS [Date], Remarks, Type AS [Type], tblIT.Status  " & _
                            " FROM     tblIT " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)

                Case "JV"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE JV_No LIKE '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblJV.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, JV_No AS [JV No.], DateJV AS [Date], Remarks, Type AS [Type], tblJV.Status  " & _
                            " FROM     tblJV " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)

                Case "SP"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE SP_No LIKE '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblSP.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   TransID, SP_No AS [SP No.], DateSP AS [Date], VCEName, NetAmount,  Remarks, Type AS [Type], tblSP.Status  " & _
                            " FROM     tblSP " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "OR"
                    query = GetQueryCollection(moduleID)
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "AR"
                    query = GetQueryCollection(moduleID)
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "CR"
                    query = GetQueryCollection(moduleID)
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "PR"
                    query = GetQueryCollection(moduleID)
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "CF"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE CF_No LIKE '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblCF.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   tblCF.TransID, CF_No AS [CF No.], DateCF AS [Date],  TotalAmount,  tblCF.Remarks, DateNeeded, RequestedBy, tblCF.Status  " & _
                            " FROM     tblCF  " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
                Case "Sub CF"
                    ' CONDITION OF QUERY
                    If cbFilter.SelectedIndex = -1 Then
                        filter = " WHERE '' = ''"
                    Else
                        Select Case cbFilter.SelectedItem
                            Case "Transaction ID"
                                filter = " WHERE CF_No LIKE '%' + @Filter + '%' "
                            Case "Remarks"
                                filter = " WHERE Remarks '%' + @Filter + '%' "
                            Case "Status"
                                filter = " WHERE tblCF.Status LIKE '%' + @Filter + '%' "
                        End Select
                    End If

                    ' QUERY 
                    query = " SELECT   tblCF.TransID, SupplierCode, VCEName, CF_No AS [CF No.], DateCF AS [Date], CFdetials.TotalAmount, [No. of Items],  tblCF.Remarks,  tblCF.Status  " & _
                            " FROM     tblCF INNER JOIN  " & _
                            " ( " & _
                            "     SELECT  TransID, CASE WHEN ApproveSP ='Supplier 1' THEN S1code " & _
                            "                           WHEN ApproveSP ='Supplier 2' THEN S2code " & _
                            "                           WHEN ApproveSP ='Supplier 3' THEN S3code " & _
                            "                           WHEN ApproveSP ='Supplier 4' THEN S4code " & _
                            "                      END AS SupplierCode, " & _
                            "             SUM(TotalAmount) AS TotalAmount, COUNT(TotalAmount) AS [No. of Items] " & _
                            " FROM tblCF_Details " & _
                            " WHERE Status ='Active' " & _
                            " GROUP BY TransID, CASE WHEN ApproveSP ='Supplier 1' THEN S1code " & _
                            "                           WHEN ApproveSP ='Supplier 2' THEN S2code " & _
                            "                           WHEN ApproveSP ='Supplier 3' THEN S3code " & _
                            "                           WHEN ApproveSP ='Supplier 4' THEN S4code " & _
                            "                      END " & _
                            " ) AS CFdetials " & _
                            " ON        tblCF.TransID = CFdetials.TransID " & _
                            " LEFT JOIN tblVCE_Master " & _
                            " ON tblVCE_Master.VCECode = CFdetials.SupplierCode " & filter
                    SQL.FlushParams()
                    SQL.AddParam("@Filter", txtFilter.Text)
            End Select
            If query <> "" Then
                SQL.GetQuery(query)
                If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                    dgvList.DataSource = SQL.SQLDS.Tables(0)
                    dgvList.Columns(0).Visible = False
                End If
            End If

        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Function GetQueryCollection(ByVal Type As String) As String
        ' CONDITION OF QUERY
        Dim filter As String = ""
        Dim temp As String = ""
        If cbFilter.SelectedIndex = -1 Then
            filter = " "
        Else
            Select Case cbFilter.SelectedItem
                Case "Transaction ID"
                    filter = " AND TransNo LIKE '%' + @Filter + '%' "
                Case "Remarks"
                    filter = " AND Remarks '%' + @Filter + '%' "
                Case "Status"
                    filter = " AND tblCollection.Status LIKE '%' + @Filter + '%' "
            End Select
        End If

        ' QUERY 
        temp = " SELECT   TransID, TransNo AS [TransNo.], DateTrans AS [Date], VCEName AS [VCEName], Remarks, Amount AS [Amount], tblCollection.Status  " & _
                " FROM     tblCollection LEFT JOIN tblVCE_Master " & _
                " ON       tblCollection.VCECode = tblVCE_Master.VCECode " & _
                " WHERE    tblCollection.TransType ='" & Type & "'  " & filter
        Return temp
    End Function

    Private Sub dgvList_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dgvList.DoubleClick
      ChooseRecord
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ChooseRecord()
    End Sub

    Private Sub ChooseRecord()
        If dgvList.SelectedRows.Count = 1 Then
            transID = dgvList.SelectedRows(0).Cells(0).Value.ToString
            itemCode = dgvList.SelectedRows(0).Cells(1).Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub dgvList_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvList.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChooseRecord()
        End If
    End Sub

    Private Sub cbFilter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbFilter.SelectedIndexChanged

    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        LoadData()
    End Sub

    Private Sub txtFilter_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadData()
        End If
    End Sub

    Private Sub frmLoadTransactions_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            ' CHANGE FOCUS TO DATAGRID SELECTION ON WHEN KEY DOWN OR KEY UP IS PRESSED
            Dim RowIndex As Integer = 0
            If dgvList.Focused = False Then
                If dgvList.SelectedRows.Count = 0 Then ' IF THERE ARE NO ROWS SELECTED THEN SELECT A DEFAUL ROW IF THERE ARE EXISTING ROW
                    If dgvList.Rows.Count > 0 Then
                        dgvList.Rows(0).Selected = True
                    End If
                Else
                    If e.KeyCode = Keys.Down Then
                        If dgvList.Rows.Count > dgvList.SelectedRows(0).Index + 1 Then
                            dgvList.Focus()
                            RowIndex = dgvList.SelectedRows(0).Index
                            dgvList.Rows(dgvList.SelectedRows(0).Index).Selected = False
                            dgvList.Rows(RowIndex + 1).Selected = True
                        End If
                    ElseIf e.KeyCode = Keys.Up Then
                        If dgvList.SelectedRows(0).Index > 0 Then
                            dgvList.Rows(dgvList.SelectedRows(0).Index - 1).Selected = True
                        End If
                    End If
                End If
                dgvList.Focus()
            End If
        Else
            txtFilter.Focus()
            txtFilter.SelectionStart = txtFilter.TextLength
        End If
    End Sub
End Class