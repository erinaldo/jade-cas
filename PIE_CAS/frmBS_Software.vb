Public Class frmBS_Software
    Dim total As Decimal = 0
    Dim vat As Boolean = False
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmSB_Contract.Show()
    End Sub

    Private Sub frmBilling_E_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadBilling()
        If cbMonth.SelectedIndex <> -1 Then
            Dim query As String
            query = " SELECT  Contract_ID, VCEName, Contract_Type, Installment, Balance " & _
                    " FROM    ViewBS_SoftwareContract " & _
                    " WHERE  (BillYear < " & nupYear.Value & " OR (BillYear = " & nupYear.Value & " And BillMonth =" & cbMonth.SelectedIndex + 1 & ")) " & _
                    " AND     Balance > 0 "
            SQL.ReadQuery(query)
            lvForBilling.Items.Clear()
            While SQL.SQLDR.Read
                lvForBilling.Items.Add(SQL.SQLDR("Contract_ID").ToString)
                lvForBilling.Items(lvForBilling.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
                lvForBilling.Items(lvForBilling.Items.Count - 1).SubItems.Add(SQL.SQLDR("Contract_Type").ToString)
                lvForBilling.Items(lvForBilling.Items.Count - 1).SubItems.Add(SQL.SQLDR("Installment").ToString)
                lvForBilling.Items(lvForBilling.Items.Count - 1).SubItems.Add(SQL.SQLDR("Balance").ToString)
            End While
        End If

    End Sub

    Private Sub nupYear_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nupYear.ValueChanged
        LoadBilling()
    End Sub

    Private Sub cbMonth_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbMonth.SelectedIndexChanged
        LoadBilling()
    End Sub

    Private Sub lvForBilling_Click(sender As System.Object, e As System.EventArgs) Handles lvForBilling.Click
        If lvForBilling.SelectedItems.Count = 1 Then
            Dim query As String
            query = " SELECT Contract_ID, VCECode, VCEName, Contract_Date, Contract_Type, Installment, Balance,  " & _
                    " 	   CASE WHEN Balance < Installment  " & _
                    " 		    THEN CASE WHEN With_VAT = 1 THEN Balance / 1.12 ELSE Balance END  " & _
                    " 			ELSE CASE WHEN With_VAT = 1 THEN Installment / 1.12 ELSE Installment END   " & _
                    " 	   END AS Amount, " & _
                    " 	    CASE WHEN Balance < Installment  " & _
                    " 		    THEN CASE WHEN With_VAT = 1 THEN (Balance / 1.12) * .12 ELSE 0 END  " & _
                    " 			ELSE CASE WHEN With_VAT = 1 THEN (Installment / 1.12) * .12 ELSE 0 END   " & _
                    " 	   END AS VAT, " & _
                    " 	   CASE WHEN Balance < Installment  " & _
                    " 		    THEN CASE WHEN With_VAT = 1 THEN Balance / 1.12 ELSE Balance END  " & _
                    " 			ELSE CASE WHEN With_VAT = 1 THEN Installment / 1.12 ELSE Installment END   " & _
                    " 	   END  +  " & _
                    " 	   CASE WHEN Balance < Installment  " & _
                    " 		    THEN CASE WHEN With_VAT = 1 THEN (Balance / 1.12) * .12 ELSE 0 END  " & _
                    " 			ELSE CASE WHEN With_VAT = 1 THEN (Installment / 1.12) * .12 ELSE 0 END   " & _
                    " 	   END AS Total, Last_Installment + 1 AS Last_Installment  " & _
                    " FROM View_Software_Contract WHERE Contract_ID = '" & lvForBilling.SelectedItems(0).SubItems(0).Text & "' "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                txtContract.Text = SQL.SQLDR("Contract_ID").ToString
                txtVCECode.Text = SQL.SQLDR("VCECode").ToString
                txtVCEName.Text = SQL.SQLDR("VCEName").ToString
                dtpBSDate.Text = CDate(cbMonth.SelectedItem.ToString & "-1-" & nupYear.Value.ToString)
                dtpDueDate.Text = CDate(cbMonth.SelectedItem.ToString & "-7-" & nupYear.Value.ToString)
                txtPrice.Text = CDec(SQL.SQLDR("Amount")).ToString("N2")
                txtVAT.Text = CDec(SQL.SQLDR("VAT")).ToString("N2")
                txtTotal.Text = CDec(SQL.SQLDR("Total")).ToString("N2")
                total = SQL.SQLDR("Total").ToString
                If SQL.SQLDR("Contract_Type").ToString = "Installment" Then
                    txtPeriod.Text = SQL.SQLDR("Last_Installment").ToString
                End If
                cbType.SelectedItem = SQL.SQLDR("Contract_Type").ToString

                If txtVAT.Text > 0 Then
                    vat = True
                Else
                    vat = False
                End If
            End If
        End If
    End Sub


    Private Sub SaveBilling(ByVal BS As String)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblSales(Sales_ID, Sales_Ref, Sales_Type, Ref_TransID, DateBS, VCECode, " & _
                    " 	      Amount, Input_VAT, Discount, Net_Sales, Due_Date, Ref_No, Remarks)   " & _
                    " VALUES(@Sales_ID, @Sales_Ref, @Sales_Type, @Ref_TransID, @DateBS, @VCECode, " & _
                    " 	      @Amount, @Input_VAT, @Discount, @Net_Sales, @Due_Date, @Ref_No, @Remarks)   "
        SQL.FlushParams()
        SQL.AddParam("Sales_ID", BS)
        SQL.AddParam("Sales_Ref", "BS")
        SQL.AddParam("Sales_Type", "Software")
        SQL.AddParam("Ref_TransID", txtContract.Text)
        SQL.AddParam("DateBS", dtpBSDate.Value.Date)
        SQL.AddParam("VCECode", txtVCECode.Text)
        SQL.AddParam("Amount", CDec(txtPrice.Text))
        SQL.AddParam("Input_VAT", CDec(txtVAT.Text))
        SQL.AddParam("Discount", 0)
        SQL.AddParam("Net_Sales", CDec(txtTotal.Text))
        SQL.AddParam("Due_Date", dtpDueDate.Value.Date)
        SQL.AddParam("Ref_No", "")
        If chkDP.Checked = True Then
            SQL.AddParam("Remarks", "Downpayment")
        ElseIf cbType.SelectedItem = "Installment" Then
            If txtPeriod.Text = 1 Then
                SQL.AddParam("Remarks", "1st Installment")
            ElseIf txtPeriod.Text = 2 Then
                SQL.AddParam("Remarks", "2nd Installment")
            ElseIf txtPeriod.Text = 3 Then
                SQL.AddParam("Remarks", "3rd Installment")
            Else
                SQL.AddParam("Remarks", txtPeriod.Text & "th Installment")
            End If
        Else
            SQL.AddParam("Remarks", txtPeriod.Text & "% Completion")
        End If
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Sub cbType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbType.SelectedIndexChanged
        If cbType.SelectedItem = "Installment" Then
            lblPercent.Text = "Installment No."
        Else
            lblPercent.Text = " Completion % :"
            txtPeriod.Text = "100"
        End If
    End Sub

    Private Sub txtPeriod_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPeriod.TextChanged
        If cbType.SelectedItem = "Progressive Billing" Then
            If IsNumeric(txtPeriod.Text) Then
                If txtPeriod.Text > 100 Then
                    txtPeriod.Text = 100
                End If
                If vat = True And txtPeriod.Text <> 0 Then
                    txtPrice.Text = total / 1.12 * (txtPeriod.Text / 100)
                    txtVAT.Text = (total / 1.12) * 0.12 * (txtPeriod.Text / 100)
                    txtTotal.Text = total * (txtPeriod.Text / 100)
                End If

            End If
        End If
    End Sub

End Class