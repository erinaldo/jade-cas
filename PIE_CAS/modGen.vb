Imports System.IO
Imports System.Data.OleDb

Module modGen
    Public DBUser, DBPassword As String
    Public UserID, UserName, Password, Name, UserLevel, database As String
    Public BusinessType, BranchCode As String
    Public SQL As SQLControl
    Public SQL_RUBY As SQLControl
    Public Module_Import As Integer = 0
    Public App_Path As String = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
    Public activityStatus As Boolean
    Public AlphaCmd As OleDbCommand
    Public AlphaReader As OleDbDataReader
    Public AlphaCon As OleDbConnection

    Public Sub AlphaConnect()
        AlphaCon = New OleDbConnection With {.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Alpha.accdb;Jet OLEDB:Database Password=@dm1nEvo;")}
    End Sub

    Public Sub AlphaQuery(ByVal query As String)
        AlphaConnect()
        If AlphaCon.State = ConnectionState.Open Then
            AlphaCon.Close()
        End If
        Using AlphaCmd = New OleDbCommand(query, AlphaCon)
            AlphaCon.Open()
            AlphaReader = AlphaCmd.ExecuteReader
        End Using
    End Sub

    Public Function AlphaExecute(ByVal query As String) As Integer
        Try
            AlphaConnect()
            If AlphaCon.State = ConnectionState.Open Then
                AlphaCon.Close()
            End If
            Using AlphaCmd = New OleDbCommand(query, AlphaCon)
                AlphaCon.Open()
                Return AlphaCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Msg(ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        End Try
    End Function

    Public Sub SetDatabase()
        SQL = New SQLControl
        activityStatus = True
    End Sub

    Public Sub SetPayrollDatabase()
        SQL_RUBY = New SQLControl("RUBY")
        activityStatus = True
    End Sub

    Public Function byteArrayToImage(ByVal ByteArrayin As Byte()) As Image
        Using msStream As New MemoryStream(ByteArrayin)
            Return Image.FromStream(msStream)
        End Using
    End Function

    Public Function LoadDefaultImage(ByVal ImageType As String, Optional ByVal Gender As String = "Male") As String
        Dim App_Path As String
        App_Path = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
        If ImageType = "Picture" Then
            If Gender = "Male" Then
                Return App_Path & "\Images\Male.jpg"
            Else
                Return App_Path & "\Images\Female.png"
            End If
        Else
            Return App_Path & "\Images\Signature.png"
        End If
    End Function

    Public Function RequireField(ByVal obj As Object) As Boolean
        If TypeOf obj Is System.Windows.Forms.TextBox Then
            If CType(obj, System.Windows.Forms.TextBox).Text = "" Then
                CType(obj, System.Windows.Forms.TextBox).BackColor = Color.FromArgb(255, 255, 128)
                Return False
            Else
                CType(obj, System.Windows.Forms.TextBox).BackColor = SystemColors.Window
                Return True
            End If
        ElseIf TypeOf obj Is System.Windows.Forms.ComboBox Then
            If CType(obj, Windows.Forms.ComboBox).DropDownStyle = ComboBoxStyle.DropDown AndAlso CType(obj, Windows.Forms.ComboBox).Text = "" Then
                CType(obj, Windows.Forms.ComboBox).BackColor = Color.FromArgb(255, 255, 128)
                Return False
            Else
                CType(obj, Windows.Forms.ComboBox).BackColor = SystemColors.Window
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Public Sub RecordActivity(ByVal UserID As String, ModuleID As String, formName As String, LogType As String, RefType As String, ByVal RefID As String, _
                              ByVal BusinessCode As String, ByVal BranchCode As String, ByVal Remarks As String, ByVal Status As Boolean)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblAuditTrail(UserID, ModID, FormName, LogType, RefType, RefID, BusinessCode, BranchCode, Remarks, LogStatus) " & _
                    " VALUES (@UserID, @ModID, @FormName, @LogType, @RefType, @RefID, @BusinessCode, @BranchCode, @Remarks, @LogStatus) "
        SQL.FlushParams()
        SQL.AddParam("@UserID", IIf(IsNumeric(UserID), UserID, DBNull.Value))
        SQL.AddParam("@ModID", ModuleID)
        SQL.AddParam("@FormName", formName)
        SQL.AddParam("@LogType", LogType)
        SQL.AddParam("@RefType", RefType)
        SQL.AddParam("@RefID", RefID)
        SQL.AddParam("@BusinessCode", BusinessCode)
        SQL.AddParam("@BranchCode", BranchCode)
        SQL.AddParam("@Remarks", Remarks)
        SQL.AddParam("@LogStatus", Status)
        SQL.ExecNonQuery(insertSQL)
        SQL.FlushParams()
    End Sub

    Public Function LoadTransID(ByVal Table As String, Column As String, Optional FilterCol As String = "", Optional Filter As String = "") As String
        Dim query As String
        query = "SELECT MAX(" & Column & ") + 1 AS TransID FROM " & Table & " " & IIf(Filter = "", "", "WHERE " & FilterCol & " = '" & Filter & "' ")
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("TransID")) Then
            Return SQL.SQLDR("TransID")
        Else
            Return 1
        End If
    End Function

    Public Function LoadJE(ByVal Ref_Type As String, Ref_TransID As String) As String
        Dim query As String
        query = " SELECT JE_No FROM tblJE_Header WHERE RefType='" & Ref_Type & "' AND RefTransID ='" & Ref_TransID & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("JE_No")) Then
            Return SQL.SQLDR("JE_No")
        Else
            Return 0
        End If
    End Function

    Public Function LoadDefaultAccount(ByVal Type As String) As String
        Dim query As String
        query = " SELECT Account_Code FROM tblCollection_PaymentType WHERE Payment_Type ='" & Type & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Account_Code").ToString
        Else
            Return ""
        End If
    End Function

    Public Function LoadBankAccount(ByVal BankID As Integer) As String
        Dim query As String
        query = " SELECT Account_Code FROM tblMasterfile_Bank WHERE Bank_ID ='" & BankID & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Account_Code").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetVCEName(ByVal VCECode As String) As String
        Dim query As String
        query = " SELECT VCEName FROM tblVCE_Master WHERE VCECode ='" & VCECode & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("VCEName").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetVCECode(ByVal VCEName As String) As String
        Dim query As String
        query = " SELECT VCECode FROM tblVCE_Master WHERE VCEName ='" & VCEName & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("VCECode").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetCCCode(ByVal CCName As String) As String
        Dim query As String
        query = " SELECT Code FROM tblCC WHERE Description ='" & CCName & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Code").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetCCName(ByVal CCCode As String) As String
        Dim query As String
        query = " SELECT Description FROM tblCC WHERE Code ='" & CCCode & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Description").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetDefaultAccnt(ByVal Type As String) As String
        Dim query As String
        query = " SELECT  AccntCode FROM tblDefaultAccount WHERE Type ='" & Type & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AccntCode").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetAccntTitle(ByVal AccntCode As String) As String
        Dim query As String
        query = " SELECT AccountTitle FROM tblCOA_Master WHERE AccountCode ='" & AccntCode & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AccountTitle").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetItemCode(ByVal ItemName As String) As String
        Dim query As String
        query = " SELECT ItemCode FROM tblItem_Master WHERE ItemName ='" & ItemName & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("ItemCode").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetItemName(ByVal ItemCode As String) As String
        Dim query As String
        query = " SELECT ItemName FROM tblItem_Master WHERE ItemCode ='" & ItemCode & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("ItemName").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetRecord(ByVal TransID As String, type As String, table As String) As Integer
        Dim query As String = ""
        If type = "Prev" Then
            If TransID = "" Then
                query = " SELECT MIN(TransID) AS TransID FROM " & table
            Else
                query = " SELECT MAX(TransID) AS TransID FROM " & table & " WHERE TransID < '" & TransID & "'"
            End If
        ElseIf type = "Next" Then
            If TransID = "" Then
                query = " SELECT MAX(TransID) AS TransID FROM " & table
            Else
                query = " SELECT MIN(TransID) AS TransID FROM " & table & " WHERE TransID > '" & TransID & "'"
            End If
        End If
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read() AndAlso Not IsDBNull(SQL.SQLDR("TransID")) Then
            Return SQL.SQLDR("TransID")
        Else
            Return 0
        End If
    End Function

    Public Sub SaveEntry(ByVal JE As Integer, AccntCode As Integer, VCECode As Integer, Debit As Decimal, Credit As Decimal, Particulars As String, Ref_No As String, Line As Integer)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblJE_Details(JE_No, AccntCode, VCECode, Debit, Credit, Particulars, Ref_No, Line_Number) " & _
                    " VALUES (@JE_No, @AccntCode, @VCECode, @Debit, @Credit, @Particulars, @Ref_No, @Line_Number) "
        SQL.FlushParams()
        SQL.AddParam("JE_No", JE)
        SQL.AddParam("AccntCode", AccntCode)
        SQL.AddParam("VCECode", VCECode)
        SQL.AddParam("Debit", Debit)
        SQL.AddParam("Credit", Credit)
        SQL.AddParam("Particulars", Particulars)
        SQL.AddParam("Ref_No", Ref_No)
        SQL.AddParam("Line_Number", Line)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Public Function LoadDefaultAccnt(ByVal Category As String, Type As String) As String
        Dim query As String
        query = " SELECT AccntCode FROM tblDefaultAccount WHERE Category ='" & Category & "' AND Type ='" & Type & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AccntCode")
        Else
            Return ""
        End If

    End Function

    Public Sub msgRequired()
        MsgBox("Please fill-up the required fields", vbInformation, "JADE Message Alert")
    End Sub

    Public Sub SaveError(ErrorMessage As String, Stacktrace As String, Winform As String, ModID As String)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                    " tblError(ErrorMessage, ErrorStacktrace, WinForm, ModuleID) " & _
                    " VALUES (@ErrorMessage, @ErrorStacktrace, @WinForm, @ModuleID) "
        SQL.FlushParams()
        SQL.AddParam("@ErrorMessage", ErrorMessage)
        SQL.AddParam("@ErrorStacktrace", Stacktrace)
        SQL.AddParam("@WinForm", Winform)
        SQL.AddParam("@ModuleID", ModID)
        SQL.ExecNonQuery(insertSQL)
        Msg(ErrorMessage, MsgBoxStyle.Exclamation)
    End Sub

    Public Sub Msg(ByVal Message As String, style As MsgBoxStyle)
        MsgBox(Message, style, "JADE Message Alert")
    End Sub

    Public Function GetTransSetup(ByVal Type As String) As Boolean
        Dim query As String
        query = " SELECT AutoSeries FROM tblTransactionSetup WHERE TransType ='" & Type & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AutoSeries")
        Else
            Return False
        End If
    End Function

    Public Function GenerateTransNum(ByRef Auto As Boolean, ModuleID As String, ColumnPK As String, Table As String) As String
        Dim TransNum As String = ""
        If Auto = True Then
            ' GENERATE TRANS ID 
            Dim query As String
            query = " SELECT	GlobalSeries, ISNULL(BranchCode,'All') AS BranchCode, ISNULL(BusinessCode,'All') AS BusinessCode,  " & _
                    " 		    ISNULL(TransGroup,0) AS TransGroup, ISNULL(Prefix,'') AS Prefix, ISNULL(Digits,6) AS Digits, " & _
                    "           ISNULL(StartRecord,1) AS StartRecord, LEN(ISNULL(Prefix,'')) + ISNULL(Digits,6) AS ID_Length " & _
                    " FROM	    tblTransactionSetup LEFT JOIN tblTransactionDetails " & _
                    " ON		tblTransactionSetup.TransType = tblTransactionDetails.TransType " & _
                    " WHERE	    tblTransactionSetup.TransType ='" & ModuleID & "' "
            SQL.ReadQuery(query)
            While SQL.SQLDR.Read
                If SQL.SQLDR("GlobalSeries") = True Then
                    If SQL.SQLDR("BranchCode") = "All" AndAlso SQL.SQLDR("BusinessCode") = "All" Then
                        Dim digits As Integer = SQL.SQLDR("Digits")
                        Dim prefix As String = SQL.SQLDR("Prefix")
                        query = " SELECT    ISNULL(MAX(SUBSTRING(" & ColumnPK & "," & prefix.Length + 1 & "," & digits & "))+ 1,1) AS TransID  " & _
                                " FROM      " & Table & "  " & _
                                " WHERE     " & ColumnPK & " LIKE '" & prefix & "%' AND LEN(" & ColumnPK & ") = '" & digits & "' "
                        SQL.ReadQuery(query)
                        If SQL.SQLDR.Read Then
                            TransNum = SQL.SQLDR("TransID")
                            For i As Integer = 1 To digits
                                TransNum = "0" & TransNum
                            Next
                            TransNum = prefix & Strings.Right(TransNum, digits)
                        End If
                    End If
                End If
            End While
            Return TransNum
        Else
            Return ""
        End If
    End Function

    Public Function GenerateTransID(ColumnPK As String, Table As String) As String
        Dim TransID As String = ""
            ' GENERATE TRANS ID 
        Dim query As String
        query = " SELECT    ISNULL(MAX(" & ColumnPK & ")+ 1,1) AS TransID  " & _
                " FROM      " & Table & "  "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID")
        Else
            TransID = 0
        End If
        Return TransID
    End Function

    Public Function GetTransID(ColumnPK As String, Table As String, ColumnTrans As String, TransNo As String, Optional ByVal ColumnType As String = "", Optional ByVal Type As String = "") As String
        Dim TransID As String = ""
        ' GENERATE TRANS ID 
        Dim query As String
        query = " SELECT     TransID  " & _
                " FROM      " & Table & " WHERE  " & ColumnTrans & " = '" & TransNo & "' " & IIf(ColumnType = "", "", " AND " & ColumnType & " = '" & Type & "'")
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            TransID = SQL.SQLDR("TransID")
        Else
            TransID = 0
        End If
        Return TransID
    End Function

    Public Function AllowAccess(ByVal FunctionID As String, Optional ByVal Type As String = "Module Access") As Boolean
        Dim query As String
        query = " SELECT * FROM tblUser_Access " & _
                " WHERE Status ='Active' AND  UserID ='" & UserID & "' AND Code ='" & FunctionID & "' AND Type ='" & Type & "' AND isAllowed ='1' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetAccntCode(ByVal AccntTitle As String) As String
        Dim query As String
        query = " SELECT AccountCode FROM tblCOA_Master WHERE AccountTitle = '" & AccntTitle & "'"
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AccountCode").ToString
        Else
            Return ""
        End If
    End Function

    Public Sub SaveINVTY(Type As String, ModuleID As String, RefType As String, RefID As String, PostDate As Date, ItemCode As String, WHSE As String, QTY As Decimal, _
                          UOM As String, UnitCost As Decimal)
        Try
            
            If Type = "OUT" Then
                QTY = QTY * -1
            End If
            Dim TransQTY As Decimal = QTY * ConvertUOM(UOM, ItemCode)
            Dim TransValue As Decimal = QTY * UnitCost
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblInventory(MovementType, RefType, RefID, PostDate, ItemCode, WHSE, QTY, UOM, UnitCost, TransQTY, TransValue)  " & _
                        " VALUES(@MovementType, @RefType, @RefID, @PostDate, @ItemCode, @WHSE, @QTY, @UOM, @UnitCost, @TransQTY, @TransValue) "
            SQL.FlushParams()
            SQL.AddParam("@MovementType", Type)
            SQL.AddParam("@RefType", RefType)
            SQL.AddParam("@RefID", RefID)
            SQL.AddParam("@PostDate", PostDate)
            SQL.AddParam("@ItemCode", ItemCode)
            SQL.AddParam("@WHSE", WHSE)
            SQL.AddParam("@QTY", QTY)
            SQL.AddParam("@UOM", UOM)
            SQL.AddParam("@UnitCost", UnitCost)
            SQL.AddParam("@TransQTY", TransQTY)
            SQL.AddParam("@TransValue", TransValue)
            SQL.ExecNonQuery(insertSQL)
            ComputeWAUC(RefType, RefID)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, "modGen", ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, "modGen", "SAVE", RefType, RefID, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Public Sub UpdateINVTY(Type As String, ModuleID As String, RefType As String, RefID As String, PostDate As Date, ItemCode As String, WHSE As String, QTY As Decimal, _
                          UOM As String, UnitCost As Decimal)
        Try
            If Type = "OUT" Then
                QTY = QTY * -1
            End If
            Dim TransQTY As Decimal = QTY * ConvertUOM(UOM, ItemCode)
            Dim TransValue As Decimal = QTY * UnitCost
            Dim updateSQL As String
            updateSQL = " UPDATE  tblInventory " & _
                        " SET     MovementType = @MovementType ,PostDate = @PostDate, ItemCode = @ItemCode, WHSE = @WHSE, " & _
                        "         QTY = @QTY, UOM = @UOM, UnitCost = @UnitCost, TransQTY = @TransQTY, TransValue = @TransValue  " & _
                        " WHERE   RefType = @RefType AND RefID = @RefID "
            SQL.FlushParams()
            SQL.AddParam("@MovementType", Type)
            SQL.AddParam("@RefType", RefType)
            SQL.AddParam("@RefID", RefID)
            SQL.AddParam("@PostDate", PostDate)
            SQL.AddParam("@ItemCode", ItemCode)
            SQL.AddParam("@WHSE", WHSE)
            SQL.AddParam("@QTY", QTY)
            SQL.AddParam("@UOM", UOM)
            SQL.AddParam("@UnitCost", UnitCost)
            SQL.AddParam("@TransQTY", TransQTY)
            SQL.AddParam("@TransValue", TransValue)
            SQL.ExecNonQuery(updateSQL)
            ComputeWAUC(RefType, RefID)
        Catch ex As Exception
            activityStatus = False
            SaveError(ex.Message, ex.StackTrace, "modGen", ModuleID)
        Finally
            RecordActivity(UserID, ModuleID, "modGen", "UPDATE", RefType, RefID, BusinessType, BranchCode, "", activityStatus)
            SQL.FlushParams()
        End Try
    End Sub

    Public Function GetWHSECode(ByVal Description As String) As String
        If Description = Nothing Then
            Description = ""
        End If
        Try
            Dim query As String
            query = " SELECT Code FROM tblWarehouse WHERE Description = @Description "
            SQL.FlushParams()
            SQL.AddParam("@Description", Description)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return SQL.SQLDR("Code").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, "modGen", "modGen")
            Return ""
        Finally
            SQL.FlushParams()
        End Try
    End Function

    Public Function GetWHSEDesc(ByVal Code As String) As String
        Try
            Dim query As String
            query = " SELECT Description FROM tblWarehouse WHERE Code = @Code "
            SQL.FlushParams()
            SQL.AddParam("@Code", Code)
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                Return SQL.SQLDR("Description").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, "modGen", "modGen")
            Return ""
        Finally
            SQL.FlushParams()
        End Try

    End Function

    Public Function ConvertUOM(ByVal UOM As String, ItemCode As String) As Decimal
        Dim query As String
        query = " SELECT QTY FROM viewItem_UOM WHERE GroupCode ='" & ItemCode & "' AND UnitCode ='" & UOM & "' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("QTY")
        Else
            Return 1
        End If
    End Function

    Public Sub ComputeWAUC(Type As String, TransID As Integer)
        Try
            Dim updateSQL As String
            updateSQL = " UPDATE tblInventory " & _
                        " SET		ComQTY = A.ComQTY, ComValue = A.ComValue, AverageCost = A.ComValue/A.ComQTY " & _
                        " FROM " & _
                        " ( " & _
                        " 	SELECT	Selected.RecordID, Selected.RefType, Selected.RefID, Selected.ItemCode,  " & _
                        " 			CASE WHEN ComQTY IS NULL THEN Selected.TransQTY ELSE ComQTY + Selected.TransQTY END AS ComQTY, " & _
                        " 			CASE WHEN ComValue IS NULL THEN Selected.TransValue ELSE ComValue + Selected.TransValue END AS ComValue, " & _
                        " 			tblInventory.DateCreated, tblInventory.PostDate,  " & _
                        " 			ROW_NUMBER() OVER (ORDER BY tblInventory.Postdate DESC, tblInventory.DateCreated DESC) AS RowNum " & _
                        " 	FROM	 " & _
                        " 	( " & _
                        " 		SELECT	RecordID, RefType, RefID, PostDate, DateCreated, ItemCode, TransQTY, TransValue " & _
                        " 		FROM	tblInventory  " & _
                        " 		WHERE	RefType ='" & Type & "' AND RefID = " & TransID & " " & _
                        " 	) AS Selected " & _
                        " 	LEFT JOIN tblInventory " & _
                        " 	ON		tblInventory.ItemCode = Selected.ItemCode " & _
                        " 	AND     (tblInventory.PostDate < Selected.PostDate " & _
                        " 	OR     (tblInventory.PostDate = Selected.PostDate AND  tblInventory.DateCreated < Selected.DateCreated)) " & _
                        " ) AS A " & _
                        " WHERE tblInventory.RecordID = A.RecordID " & _
                        " AND RowNum = 1 "
            SQL.ExecNonQuery(updateSQL)

            updateSQL = " UPDATE  tblInventory " & _
                        " SET     tblInventory.ComQTY = A.ComQTY, " & _
                        " 		tblInventory.ComValue = A.ComValue, AverageCost = A.ComValue/A.ComQTY  " & _
                        " FROM " & _
                        " ( " & _
                        " 	SELECT	tblInventory.RecordID, " & _
                        " 			Selected.ComQTY  + SUM(TransQTY) OVER (ORDER BY tblInventory.Postdate ASC, tblInventory.DateCreated ASC) AS ComQTY, " & _
                        " 			Selected.ComValue + SUM(TransValue) OVER (ORDER BY tblInventory.Postdate ASC, tblInventory.DateCreated ASC) AS ComValue " & _
                        " 		FROM	 " & _
                        " 		( " & _
                        " 			SELECT	RecordID, RefType, RefID, PostDate, DateCreated, ItemCode, ComQTY, ComValue " & _
                        " 			FROM	tblInventory  " & _
                        " 			WHERE	RefType ='" & Type & "' AND RefID = " & TransID & " " & _
                        " 		) AS Selected " & _
                        " 	LEFT JOIN tblInventory " & _
                        " 	ON		tblInventory.ItemCode = Selected.ItemCode " & _
                        " 	AND     (tblInventory.PostDate > Selected.PostDate " & _
                        " 	OR      (tblInventory.PostDate = Selected.PostDate AND  tblInventory.DateCreated > Selected.DateCreated)) " & _
                        " ) AS A " & _
                        " WHERE  tblInventory.RecordID = A.RecordID "
            SQL.ExecNonQuery(updateSQL)
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, "modGen", "modGen")
        End Try
    End Sub

    Public Function GetAverageCost(ByVal ItemCode As String) As Decimal
        Dim query As String
        query = " SELECT    TOP 1 AverageCost " & _
                " FROM      tblInventory " & _
                " WHERE     ItemCode ='" & ItemCode & "' " & _
                " ORDER BY  PostDate DESC, DateCreated DESC "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("AverageCost")
        Else
            Return 0
        End If
    End Function

    Public Sub InitializeDB()
        Dim deleteSQL As String
        deleteSQL = " DELETE FROM tblSI "
        SQL.ExecNonQuery(deleteSQL)
        deleteSQL = " DELETE FROM tblJE_Header "
        SQL.ExecNonQuery(deleteSQL)
        deleteSQL = " DELETE FROM tblUploadHistory "
        SQL.ExecNonQuery(deleteSQL)
        MsgBox("Database initialized successfully!", MsgBoxStyle.Information)
    End Sub

    Public Sub msgsave()
        'Required Fields
        Msg("Data has been Successfully saved", MsgBoxStyle.Information)
    End Sub

    Public Sub msgupdated()
        Msg("Data has been successfully updated", MsgBoxStyle.Information)
    End Sub

    Public Function GetRecordID(ByVal Table As String, Column As String) As Integer
        Dim query As String
        query = "SELECT ISNULL(MAX(" & Column & "),0) + 1 AS RecordID FROm " & Table & ""
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("RecordID")
        Else
            Return 0
        End If
    End Function

    Public Function GetUOMdescription(ByVal UoMCode As String)
        Dim query As String
        query = " SELECT * FROM tblUOM WHERE UnitCode = @UnitCode "
        SQL.FlushParams()
        SQL.AddParam("@UnitCode", UoMCode)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return SQL.SQLDR("Description").ToString
        Else
            Return ""
        End If
        SQL.FlushParams()
    End Function

    Public Sub msgRestricted()
        Msg("You have insufficient privileges to access this function!", MsgBoxStyle.Information)
    End Sub

    Public Sub msgRestrictedMod()
        Msg("You have insufficient privileges to access this Module!", MsgBoxStyle.Information)
    End Sub

    Public Function BranchExist(ByVal Code As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblBranch WHERE BranchCode = @BranchCode "
        SQL.FlushParams()
        SQL.AddParam("@BranchCode", Code)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function BusinessTypeExist(ByVal Code As String) As Boolean
        Dim query As String
        query = " SELECT * FROM tblBusinessType WHERE BusinessCode = @BusinessCode "
        SQL.FlushParams()
        SQL.AddParam("@BusinessCode", Code)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Sub SaveGroup(Type As String, GroupID As String, txtGroup As TextBox)
        Dim insertSQL As String
        insertSQL = " INSERT INTO " & _
                       " tblGroup(Type, GroupID, Description, Status, WhoCreated) " & _
                       " VALUES(@Type, @GroupID, @Description, @Status, @WhoCreated) "
        SQL.FlushParams()
        SQL.AddParam("@Type", Type)
        SQL.AddParam("@GroupID", GroupID)
        SQL.AddParam("@Description", txtGroup.Text)
        SQL.AddParam("@Status", "Active")
        SQL.AddParam("@WhoCreated", UserID)
        SQL.ExecNonQuery(insertSQL)
    End Sub

    Public Function GetMaxPEC() As Date
        Dim query As String
        query = " SELECT DATEADD(DAY,1,ISNULL(MAX(datePEC),'01-01-1900')) AS datePEC FROM tblPEC WHERE Status ='Active' "
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read AndAlso Not IsDBNull(SQL.SQLDR("datePEC")) Then
            Return SQL.SQLDR("datePEC")
        Else
            Return "01-01-1900"
        End If
    End Function

End Module
