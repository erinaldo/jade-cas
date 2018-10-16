Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class SQLControl
    Private SQLCon As SqlConnection
    Private SQLCon1 As SqlConnection
    Private SQLCon2 As SqlConnection
   Private SQLCmd As SqlCommand
    Public SQLDA As SqlDataAdapter
    Public SQLDS As DataSet
    Public SQLDR As SqlDataReader
    Public SQLDRRFID As SqlDataReader
    Public SQLDR2 As SqlDataReader
    Public RecordCount As Integer
    Public SQLParams As New List(Of SqlParameter)
    Dim r As StreamReader
    Dim server As String

    Public Sub New(Optional ByVal System As String = "JADE")
        If System = "JADE" Then
            Dim App_Path As String = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
            server = frmUserLogin.cbServer.Text
            SQLCon = New SqlConnection With {.ConnectionString = ("Server=" & Trim(server) & ";Database=" & database & ";integrated security=sspi;Uid=sa;Pwd=eVoSolution1;Trusted_Connection=no;MultipleActiveResultSets=True")}
            SQLCon1 = New SqlConnection With {.ConnectionString = ("Server=" & Trim(server) & ";Database=" & database & ";integrated security=sspi;Uid=sa;Pwd=eVoSolution1;Trusted_Connection=no;MultipleActiveResultSets=True")}
            SQLCon2 = New SqlConnection With {.ConnectionString = ("Server=" & Trim(server) & ";Database=" & database & ";integrated security=sspi;Uid=sa;Pwd=eVoSolution1;Trusted_Connection=no;MultipleActiveResultSets=True")}
        ElseIf System = "RUBY" Then
            Dim App_Path As String = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
            r = New IO.StreamReader(App_Path & "\Data\eMRP.ini")
            While (r.Peek() > -1)
                server = r.ReadLine
            End While
            SQLCon = New SqlConnection With {.ConnectionString = ("Server=" & Trim(server) & ";Database=" & database.Replace("CAS", "RUBY") & ";integrated security=sspi;Uid=sa;Pwd=eVoSolution1;Trusted_Connection=no;MultipleActiveResultSets=True")}
            SQLCon1 = New SqlConnection With {.ConnectionString = ("Server=" & Trim(server) & ";Database=" & database.Replace("CAS", "RUBY") & ";integrated security=sspi;Uid=sa;Pwd=eVoSolution1;Trusted_Connection=no;MultipleActiveResultSets=True")}
            SQLCon2 = New SqlConnection With {.ConnectionString = ("Server=" & Trim(server) & ";Database=" & database.Replace("CAS", "RUBY") & ";integrated security=sspi;Uid=sa;Pwd=eVoSolution1;Trusted_Connection=no;MultipleActiveResultSets=True")}
        End If
      
    End Sub

    Public Sub GetQuery(ByVal Query As String, Optional ByVal Server As Integer = 86, Optional ByVal With_Param As Boolean = False)
        Try
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            Using SQLCmd = New SqlCommand(Query, SQLCon)
                SQLCon.Open()
                For Each p As SqlParameter In SQLParams
                    SQLCmd.Parameters.Add(p)
                    SQLCmd.Parameters(p.ParameterName).Value = p.Value
                Next
                SQLDA = New SqlDataAdapter(SQLCmd)
                SQLDS = New DataSet
                RecordCount = SQLDA.Fill(SQLDS)
                If With_Param Then
                    FlushParams()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseCon(Server)
        End Try
    End Sub

    Public Sub ReadQuery(ByVal Query As String, Optional ByVal Connection As Integer = 86)
        Try
            If Connection = 86 Then
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                Using SQLCmd = New SqlCommand(Query, SQLCon)
                    SQLCon.Open()
                    For Each p As SqlParameter In SQLParams
                        SQLCmd.Parameters.Add(p)
                        SQLCmd.Parameters(p.ParameterName).Value = p.Value
                    Next
                    SQLDR = SQLCmd.ExecuteReader
                End Using
            ElseIf Connection = 2 Then
                If SQLCon2.State = ConnectionState.Open Then
                    SQLCon2.Close()
                End If
                Using SQLCmd = New SqlCommand(Query, SQLCon2)
                    SQLCon2.Open()
                    SQLDR2 = SQLCmd.ExecuteReader
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FlushParams()
        End Try
    End Sub

    Public Function ExecNonQuery(ByVal Query As String) As Integer
        Try
            Dim RecordChanged As Integer
            Using SQLCmd = New SqlCommand(Query, SQLCon1)
                If SQLCon1.State = 1 Then
                    SQLCon1.Close()
                End If
                SQLCon1.Open()
                For Each p As SqlParameter In SQLParams
                    SQLCmd.Parameters.Add(p)
                    SQLCmd.Parameters(p.ParameterName).Value = p.Value
                Next
                RecordChanged = SQLCmd.ExecuteNonQuery()
            End Using
            Return RecordChanged
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            SQLCon1.Close()
            FlushParams()
        End Try
    End Function

    Public Sub UploadExcel(ByVal path As String, ByVal DTable As String, ByVal STable As String)
        Try
            Dim ExcelConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")
            ExcelConnection.Open()
            Dim query As String
            query = " SELECT * INTO #Payroll_Payroll FROM [" & STable & "$]"
            Dim objCmdSelect As OleDbCommand = New OleDbCommand(query, ExcelConnection)
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
                SQLCon.Open()
                objCmdSelect.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQLCon.Close()
        End Try
    End Sub

    Public Sub AddParam(ByVal Name As String, ByVal Value As Object, Optional ByVal DataType As SqlDbType = SqlDbType.NVarChar)
        Dim newParam As New SqlParameter With {.ParameterName = Name, .Value = Value, .SqlDbType = DataType}
        SQLParams.Add(newParam)
    End Sub

    Public Sub FlushParams()
        SQLParams.Clear()
    End Sub

    Public Sub CloseCon(Optional ByVal Server As Integer = 0)
        If Server = 0 Then
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            If SQLCon1.State = ConnectionState.Open Then
                SQLCon1.Close()
            End If
            If SQLCon2.State = ConnectionState.Open Then
                SQLCon2.Close()
            End If
        End If
    End Sub

End Class
