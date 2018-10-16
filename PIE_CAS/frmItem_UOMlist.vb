Public Class frmItem_UOMlist
    Dim moduleID As String = "ITM"
    Public UoM As String
    Public UoMGroup, item As String

    Public Overloads Function ShowDialog(Optional ByVal Group As String = "", Optional ByVal ItemCode As String = "") As Boolean
        UoMGroup = Group
        item = ItemCode
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmItem_UOM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If UoMGroup = "" Then
            LoadBaseUOM()
        Else
            LoadAltUnit(UoMGroup, item)
        End If
    End Sub

    Private Sub LoadBaseUOM()
        Try
            Dim query As String
            query = " SELECT    UnitCode, Description " & _
                    " FROM      tblUOM " & _
                    " WHERE     Status = 'Active' AND BaseUnit = 1 " & _
                    " AND       (UnitCode = @Filter OR Description LIKE '%' + @Filter + '%') "
            SQL.FlushParams()
            SQL.AddParam("@Filter", txtFilter.Text)
            SQL.ReadQuery(query)
            lvUoM.Items.Clear()
            While SQL.SQLDR.Read
                lvUoM.Items.Add(SQL.SQLDR("UnitCode").ToString)
                lvUoM.Items(lvUoM.Items.Count - 1).SubItems.Add(SQL.SQLDR("Description").ToString)
            End While
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, moduleID)
        Finally
            SQL.FlushParams()
        End Try
    End Sub

    Private Sub LoadAltUnit(Group As String, ByVal ItemCode As String)
        If Group = "(Manual)" Then
            lvUoM.Items.Clear()
            Dim UOMCode As String = ""
            Dim exist As Boolean
            With frmUOMConversion
                For Each row As DataGridViewRow In frmUOMConversion.dgvAltUOM.Rows
                    ' FROM UOM
                    exist = False
                    UOMCode = row.Cells(.chFromUoM.Index).Value
                    For Each item As ListViewItem In lvUoM.Items
                        If item.SubItems(0).Text = UOMCode Then
                            exist = True
                        End If
                    Next
                    If exist = False Then
                        lvUoM.Items.Add(UOMCode)
                        lvUoM.Items(lvUoM.Items.Count - 1).SubItems.Add(GetUOMdescription(UOMCode))
                    End If
                  

                    ' TO UOM
                    exist = False
                    UOMCode = row.Cells(.dgcToUOM.Index).Value
                    For Each item As ListViewItem In lvUoM.Items
                        If item.SubItems(0).Text = UOMCode Then
                            exist = True
                        End If
                    Next
                    If exist = False Then
                        lvUoM.Items.Add(UOMCode)
                        lvUoM.Items(lvUoM.Items.Count - 1).SubItems.Add(GetUOMdescription(UOMCode))
                    End If
                Next
            End With
        Else
            Dim query As String
            query = " SELECT DISTINCT UnitCode, Description " & _
                    "   FROM " & _
                    "   ( " & _
                    " 	  SELECT    tblUOM.UnitCode, Description, GroupCode " & _
                    " 	  FROM      tblUOM_Group   INNER JOIN tblUOM    " & _
                    " 	  ON	    tblUOM_Group.UnitCode = tblUOM.UnitCode    " & _
                    " 	  UNION ALL " & _
                    " 	  SELECT    tblUOM.UnitCode, Description, GroupCode " & _
                    " 	  FROM      tblUOM_GroupDetails INNER JOIN tblUOM    " & _
                    " 	  ON	    tblUOM_GroupDetails.UnitCodeFrom = tblUOM.UnitCode    " & _
                    " 	  UNION ALL " & _
                    " 	  SELECT    tblUOM.UnitCode, Description, GroupCode " & _
                    " 	  FROM      tblUOM_GroupDetails INNER JOIN tblUOM    " & _
                    " 	  ON	    tblUOM_GroupDetails.UnitCodeTo = tblUOM.UnitCode    " & _
                    "   ) AS ALT " & _
                    "   WHERE GroupCode ='" & Group & "' "
            SQL.ReadQuery(query)
            lvUoM.Items.Clear()
            While SQL.SQLDR.Read
                lvUoM.Items.Add(SQL.SQLDR("UnitCode").ToString)
                lvUoM.Items(lvUoM.Items.Count - 1).SubItems.Add(SQL.SQLDR("Description").ToString)
            End While
        End If
       

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnUOMmaster.Click
        frmItem_UOM.ShowDialog()
        LoadBaseUOM()
        frmItem_UOM.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        UoM = ""
    End Sub

    Private Sub btnChoose_Click(sender As System.Object, e As System.EventArgs) Handles btnChoose.Click
        If lvUoM.SelectedItems.Count = 1 Then
            UoM = lvUoM.SelectedItems(0).SubItems(chUOM.Index).Text
            Me.Close()
        End If
    End Sub

    Private Sub lvUoM_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvUoM.DoubleClick
        btnChoose.PerformClick()
    End Sub

    Private Sub lvUoM_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles lvUoM.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnChoose.PerformClick()
        End If
    End Sub
End Class