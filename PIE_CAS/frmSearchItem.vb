Imports System.Data
Imports System.Data.SqlClient

Public Class frmSearchItem
    Public Itemcode As String = Nothing
    Public ItemName As String = Nothing

    Private Sub frmSearchVendor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
            Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
            If ItemName = "*" Then
                Dim rowCount As Integer
                Dim query As String
                query = " SELECT ItemCode, ItemName, UOM, UnitPrice " & _
                        " FROM   viewItem_Price " & _
                        " ORDER BY ItemName"
                SQL.ReadQuery(query)
                If SQL.SQLDR.HasRows Then
                    While SQL.SQLDR.Read
                        dgvSearch.Rows.Add(New String() {SQL.SQLDR("ItemCode ").ToString, _
                                                         SQL.SQLDR("ItemName ").ToString, _
                                                         SQL.SQLDR("UOM").ToString, _
                                                         SQL.SQLDR("UnitPrice").ToString})
                        rowCount = rowCount + 1
                    End While
                End If
            Else
                Dim rowCount As Integer
                Dim query As String
                query = " SELECT    ItemCode, ItemName, UOM, UnitPrice  " & _
                        " FROM      viewItem_Price " & _
                        " WHERE     ItemName LIKE '%" & ItemName & "%' " & _
                        " ORDER BY  ItemName"
                SQL.ReadQuery(query)
                If SQL.SQLDR.HasRows Then
                    While (SQL.SQLDR.Read)
                        dgvSearch.Rows.Add(New String() {SQL.SQLDR("ItemCode").ToString, _
                                                         SQL.SQLDR("ItemName").ToString, _
                                                         SQL.SQLDR("UOM").ToString, _
                                                         SQL.SQLDR("UnitPrice").ToString})
                        rowCount = rowCount + 1
                    End While
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearch.CellMouseClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Itemcode = dgvSearch.Item(0, e.RowIndex).Value
            ItemName = dgvSearch.Item(1, e.RowIndex).Value
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearch.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Itemcode = dgvSearch.Item(0, e.RowIndex).Value
            ItemName = dgvSearch.Item(1, e.RowIndex).Value
            Me.Close()
        End If
    End Sub

    Private Sub dgvSearch_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvSearch.KeyDown
        Dim rowindex As Integer
        rowindex = dgvSearch.CurrentRow.Index
        If e.KeyCode = Keys.Enter Then
            Itemcode = dgvSearch.Item(0, rowindex).Value
            ItemName = dgvSearch.Item(1, rowindex).Value
            Me.Close()
        End If
    End Sub
End Class
