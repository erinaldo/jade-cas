Public Class frmItem_Discount '
    Dim itemCode, category As String
    Dim disableEvent As Boolean = False
    Dim ID As Integer = 0

    Private Sub tblItem_Discount_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadVCE()
    End Sub

    Private Sub LoadVCE()
        Try
            Dim query As String
            query = " SELECT	DISTINCT tblItem_Discount.VCECode, VCEName  " & _
                    " FROM	    tblItem_Discount INNER JOIN viewVCE_Master " & _
                    " ON		tblItem_Discount.VCECode = viewVCE_Master.VCECode  " & _
                    " WHERE	    tblItem_Discount.Status ='Active' " & _
                    " AND       VCEName LIKE '%' + @Name +'%' "
            SQL.FlushParams()
            SQL.AddParam("@Name", txtFilter.Text)
            SQL.ReadQuery(query)
            lvCustomer.Items.Clear()
            While SQL.SQLDR.Read
                lvCustomer.Items.Add(SQL.SQLDR("VCECode").ToString)
                lvCustomer.Items(lvCustomer.Items.Count - 1).SubItems.Add(SQL.SQLDR("VCEName").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub LoadDiscount(VCECode As String)
        Dim query As String
        query = " SELECT	Discount_ID, Item_Field, Item_Value, Calc_Method,  " & _
                " 		    CASE WHEN Calc_Method = 'Formula'  " & _
                " 			     THEN Formula  " & _
                " 			     ELSE Calc_Value  " & _
                " 		    END AS Calc_Value  " & _
                " FROM      tblItem_Discount " & _
                " WHERE     Status ='Active' " & _
                " AND       VCECode ='" & VCECode & "' " & _
                " ORDER BY  Item_Field, Item_Value "
        SQL.ReadQuery(query)
        lvDiscount.Items.Clear()
        While SQL.SQLDR.Read
            lvDiscount.Items.Add(SQL.SQLDR("Discount_ID").ToString)
            lvDiscount.Items(lvDiscount.Items.Count - 1).SubItems.Add(SQL.SQLDR("Item_Field").ToString)
            lvDiscount.Items(lvDiscount.Items.Count - 1).SubItems.Add(SQL.SQLDR("Item_Value").ToString)
            lvDiscount.Items(lvDiscount.Items.Count - 1).SubItems.Add(SQL.SQLDR("Calc_Method").ToString)
            lvDiscount.Items(lvDiscount.Items.Count - 1).SubItems.Add(SQL.SQLDR("Calc_Value").ToString)
        End While
    End Sub

    Private Sub lvCustomer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCustomer.SelectedIndexChanged, lvCustomer.MouseClick
        If disableEvent = False Then
            If lvCustomer.SelectedItems.Count = 1 Then
                lblCode.Text = lvCustomer.SelectedItems(0).SubItems(chCode.Index).Text
                lblName.Text = lvCustomer.SelectedItems(0).SubItems(chName.Index).Text
                LoadDiscount(lvCustomer.SelectedItems(0).SubItems(chCode.Index).Text)
                ClearData()
                EnableControl(False)
                btnSave.Text = "New"
                btnEdit.Text = "Edit"
                btnEdit.Enabled = False
                btnRemove.Enabled = False
                btnRemove.Text = "Remove"
            End If
        End If

    End Sub

    Private Sub lvDiscount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDiscount.SelectedIndexChanged, lvDiscount.MouseClick
        If disableEvent = False Then
            If lvDiscount.SelectedItems.Count = 1 Then
                ID = lvDiscount.SelectedItems(0).SubItems(chID.Index).Text
                LoadDetails(ID)
                btnSave.Text = "New"
                btnEdit.Text = "Edit"
                btnRemove.Text = "Remove"
                btnEdit.Enabled = True
                btnRemove.Enabled = True
            End If
        End If
    End Sub

    Private Sub LoadDetails(ID As Integer)
        Dim category As String
        Dim query As String
        query = " SELECT	Item_Field, Item_Value, Calc_Method,  " & _
                " 		    CASE WHEN Calc_Method = 'Formula'  " & _
                " 			     THEN Formula  " & _
                " 			     ELSE Calc_Value  " & _
                " 		    END AS Calc_Value  " & _
                " FROM      tblItem_Discount " & _
                " WHERE     Status ='Active' " & _
                " AND       Discount_ID ='" & ID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            disableEvent = True
            cbType.SelectedItem = SQL.SQLDR("Item_Field").ToString
            category = SQL.SQLDR("Item_Value").ToString
            cbDiscountType.SelectedItem = SQL.SQLDR("Calc_Method").ToString
            txtDiscountValue.Text = SQL.SQLDR("Calc_Value").ToString
            disableEvent = False
             LoadCategory()
            If cbType.SelectedItem = "Category" Then
                cbGroupValue.SelectedItem = category
            Else
                cbGroupValue.Text = category
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim f As New frmVCE_Search
        f.ShowDialog()
        lblCode.Text = f.VCECode
        lblName.Text = f.VCEName
        f.Dispose()
        lvDiscount.Items.Clear()
        ClearData()
        EnableControl(False)
        btnSave.Text = "New"
        btnEdit.Text = "Edit"
    End Sub

    Private Sub txtFilter_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFilter.TextChanged
        LoadVCE()
    End Sub

    Private Sub txtFilter_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim f As New frmVCE_Search
            f.txtFilter.Text = txtFilter.Text
            f.ShowDialog()
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "New" Then
            ClearData()
            EnableControl(True)
            btnSave.Text = "Save"
            btnEdit.Enabled = False
            btnRemove.Enabled = True
            btnRemove.Text = "Cancel"
        ElseIf btnSave.Text = "Save" Then
            If cbType.SelectedIndex = -1 Then
                MsgBox("Please select type!", MsgBoxStyle.Exclamation)
            ElseIf MsgBox("Are you sure you want to save this discount?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveDiscount()
                LoadDiscount(lblCode.Text)
                LoadVCE()
                MsgBox("Discount Saved successfully!", MsgBoxStyle.Information)
            End If
        End If

    End Sub

    Private Sub ClearData()
        cbType.SelectedIndex = 1
        cbGroupValue.SelectedIndex = -1
        cbGroupValue.Text = ""
        cbDiscountType.SelectedIndex = 0
        txtDiscountValue.Text = ""
        itemCode = ""
        ID = 0
    End Sub

    Private Sub cbType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbType.SelectedIndexChanged
        If disableEvent = False Then
            If cbType.SelectedItem = "Category" Then
                cbGroupValue.DropDownStyle = ComboBoxStyle.DropDownList
                LoadCategory()
            Else
                cbGroupValue.DropDownStyle = ComboBoxStyle.Simple
            End If
        End If
    End Sub

    Private Sub LoadCategory()
        Dim query As String
        query = " SELECT DISTINCT Description FROM tblItem_Category WHERE Status='Active' "
        SQL.ReadQuery(query)
        cbGroupValue.Items.Clear()
        While SQL.SQLDR.Read
            cbGroupValue.Items.Add(SQL.SQLDR("Description").ToString)
        End While
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            EnableControl(True)
            btnEdit.Text = "Update"
            btnRemove.Text = "Cancel"
        Else
            If MsgBox("Are you sure you want to update this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                UpdateDiscount(ID)
                btnEdit.Text = "Edit"
                btnSave.Text = "New"
                LoadDiscount(lblCode.Text)
                LoadVCE()
                MsgBox("Discount Updated successfully!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub EnableControl(Value As Boolean)
        cbGroupValue.Enabled = Value
        cbDiscountType.Enabled = Value
        cbType.Enabled = Value
        txtDiscountValue.ReadOnly = Not Value
    End Sub

    Private Sub SaveDiscount()
        Try
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblItem_Discount(VCECode, Item_Field, Item_Value, Calc_Method, Calc_Value, Formula, Who_Created)  " & _
                        " VALUES(@VCECode, @Item_Field, @Item_Value, @Calc_Method, @Calc_Value, @Formula, @Who_Created)  "
            SQL.FlushParams()
            SQL.AddParam("@VCECode", lblCode.Text)
            SQL.AddParam("@Item_Field", cbType.SelectedItem)
            If cbType.SelectedItem = "Category" Then
                SQL.AddParam("@Item_Value", cbGroupValue.SelectedItem)
            Else
                SQL.AddParam("@Item_Value", cbGroupValue.Text)
            End If
            SQL.AddParam("@Calc_Method", cbDiscountType.Text)
            If cbDiscountType.SelectedItem = "Formula" Then
                SQL.AddParam("@Calc_Value", 0)
                SQL.AddParam("@Formula", txtDiscountValue.Text)
            Else
                SQL.AddParam("@Calc_Value", CDec(txtDiscountValue.Text))
                SQL.AddParam("@Formula", "")
            End If
            SQL.AddParam("@Who_Created", "")
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub UpdateDiscount(ID As Integer)
        Try
            Dim insertSQL As String
            insertSQL = " UPDATE tblItem_Discount " & _
                        " SET    VCECode = @VCECode, Item_Field = @Item_Field, Item_Value = @Item_Value, " & _
                        "        Calc_Method = @Calc_Method, Calc_Value = @Calc_Value, Formula = @Formula, " & _
                        "        Date_Modified = GETDATE(), Who_Modified = @Who_Modified   " & _
                        " WHERE   Discount_ID = @Discount_ID"
            SQL.FlushParams()
            SQL.AddParam("@VCECode", lblCode.Text)
            SQL.AddParam("@Item_Field", cbType.SelectedItem)
            If cbType.SelectedItem = "Category" Then
                SQL.AddParam("@Item_Value", cbGroupValue.SelectedItem)
            Else
                SQL.AddParam("@Item_Value", itemCode)
            End If
            SQL.AddParam("@Calc_Method", cbDiscountType.Text)
            If cbDiscountType.SelectedItem = "Formula" Then
                SQL.AddParam("@Calc_Value", 0)
                SQL.AddParam("@Formula", txtDiscountValue.Text)
            Else
                SQL.AddParam("@Calc_Value", CDec(txtDiscountValue.Text))
                SQL.AddParam("@Formula", "")
            End If
            SQL.AddParam("@Who_Modified", "")
            SQL.AddParam("@Discount_ID", ID)
            SQL.ExecNonQuery(insertSQL)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQL.FlushParams()
        End Try

    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        If btnRemove.Text = "Cancel" Then
            If ID <> 0 Then
                btnEdit.Enabled = True
            Else
                btnEdit.Enabled = False
            End If
            btnSave.Text = "New"
            btnEdit.Text = "Edit"
            btnRemove.Text = "Remove"
        ElseIf btnSave.Text = "Remove" Then
            If ID <> 0 Then
                If MsgBox("Are you sure you want to remove this discount?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim updateSQL As String
                    updateSQL = " UPDATE tblItem_Discount " & _
                                " SET     Status ='Inactive' " & _
                                " WHERE  Discount_ID = '" & ID & "'"
                    SQL.ExecNonQuery(updateSQL)
                    LoadVCE()
                    LoadDiscount(lblCode.Text)
                End If
            End If

        End If
       
    End Sub
End Class