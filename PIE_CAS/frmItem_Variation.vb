Imports System.IO
Public Class frmItem_Variation
    Dim SQL As New SQLControl
    Dim picPath As String
    Dim SKU, subSKU As String


    Public Overloads Function ShowDialog(ByVal SKU1 As String, SubSKU1 As String) As Boolean
        SKU = SKU1
        subSKU = SubSKU1
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub frmItem_Variation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If SKU <> "" And subSKU = "" Then
            subSKU = GetVarNo()
            txtSubSKU.Text = SKU & "-" & Strings.Right("000" & subSKU.ToString, 3)
            btnSave.Text = "Save"
        Else
            btnSave.Text = "Update"
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnUpload.Click
        With OpenFileDialog1
            .InitialDirectory = "C:\"
            .Filter = "All Files|*.*|JPEGs|*.jpg"
            .FilterIndex = 4
        End With
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            With pbPicture
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BorderStyle = BorderStyle.Fixed3D
                picPath = OpenFileDialog1.FileName
            End With
        End If
    End Sub

    Private Sub SaveVariation()
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblItem_Variation(ItemCode, ItemVarCode, Description, VarImage) " & _
                    " VALUES(@ItemCode, @ItemVarCode, @Description, @VarImage) "
        SQL.AddParam("@ItemCode", SKU)
        SQL.AddParam("@ItemVarCode", txtSubSKU.Text)
        SQL.AddParam("@Description", txtVariation.Text)
        Dim imgStreamPic As MemoryStream = New MemoryStream()
        If picPath <> "" AndAlso My.Computer.FileSystem.FileExists(picPath) Then
            Image.FromFile(picPath).Save(imgStreamPic, System.Drawing.Imaging.ImageFormat.Png)
        Else
            Dim imgPic As Image
            imgPic = pbPicture.Image
            If Not pbPicture.Image Is Nothing Then
                imgPic.Save(imgStreamPic, System.Drawing.Imaging.ImageFormat.Png)
            End If
        End If
        imgStreamPic.Close()
        Dim byteArrayPic As Byte() = imgStreamPic.ToArray()
        SQL.AddParam("@VarImage", byteArrayPic, SqlDbType.Image)
        SQL.ExecNonQuery(insertSQL)
    End Sub
    Private Sub UpdateVariation()
        Dim insertSQL As String
        insertSQL = " UPDATE tblItem_Variation " & _
                    " SET    Description = @Description, VarImage = @VarImage " & _
                    " WHERE  ItemCode = ItemCode AND ItemVarCode = @ItemVarCode "
        SQL.AddParam("@ItemCode", SKU)
        SQL.AddParam("@ItemVarCode", txtSubSKU.Text)
        SQL.AddParam("@Description", txtVariation.Text)
        Dim imgStreamPic As MemoryStream = New MemoryStream()
        If picPath <> "" AndAlso My.Computer.FileSystem.FileExists(picPath) Then
            Image.FromFile(picPath).Save(imgStreamPic, System.Drawing.Imaging.ImageFormat.Png)
        Else
            Dim imgPic As Image
            imgPic = pbPicture.Image
            If Not pbPicture.Image Is Nothing Then
                imgPic.Save(imgStreamPic, System.Drawing.Imaging.ImageFormat.Png)
            End If
        End If
        imgStreamPic.Close()
        Dim byteArrayPic As Byte() = imgStreamPic.ToArray()
        SQL.AddParam("@VarImage", byteArrayPic, SqlDbType.Image)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Private Function GetVarNo() As Integer
        Dim query As String
        query = " SELECT COUNT(ItemCode) + 1 AS SKU_No " & _
                " FROM tblItem_Variation WHERE ItemCode ='" & SKU & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("SKU_No")
        Else
            Return 1
        End If
    End Function

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtVariation.Text = "" Then
            MsgBox("Enter description for this variation!", MsgBoxStyle.Exclamation)
        ElseIf btnSave.Text = "Save" Then
            If MsgBox("Are you sure you want to add this variation?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveVariation()
                MsgBox("Variation Saved successfully!", MsgBoxStyle.Information)
                Me.Close()
            End If
        Else
            If MsgBox("Are you sure you want to update this variation?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                UpdateVariation()
                MsgBox("Variation Updated successfully!", MsgBoxStyle.Information)
                Me.Close()
            End If
        End If
    End Sub
End Class