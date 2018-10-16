Public Class frmUser_Master
    Dim disableEvent As Boolean = False
    Dim ModuleID As String = "UAR"
    Dim User_ID As Integer
    Dim ModID As String
    Dim lvSelected As ListView

    Dim uFlag_System As Boolean = False
    Dim uFlag_Module As Boolean = False
    Dim uFlag_Activity As Boolean = False

    Private Sub frmManageUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSystem()
        tsbSearch.Enabled = True
        tsbNew.Enabled = True
        tsbEdit.Enabled = False
        tsbTools.Enabled = False
        tsbDelete.Enabled = False
        tsbPrevious.Enabled = False
        tsbNext.Enabled = False
        tsbExit.Enabled = True
        EnableControl(False)
    End Sub

#Region "Verified"
#Region "SUBS"
    Private Sub LoadSystem()
        Dim query As String
        query = " SELECT Code, SystemEnabled FROM tblSystem WHERE SystemEnabled = 1 "
        SQL.ReadQuery(query)
        chkJade.Visible = False
        chkEmerald.Visible = False
        chkPearl.Visible = False
        chkSapphire.Visible = False
        chkRuby.Visible = False
        chkOnyx.Visible = False
        chkAll.Visible = False
        Dim ctr As Integer = 0
        While SQL.SQLDR.Read
            ctr += 1
            Select Case SQL.SQLDR("Code").ToString
                Case "JADE"
                    chkJade.Visible = SQL.SQLDR("SystemEnabled")
                    chkJade.Location = New Point(chkJade.Location.X, ctr * 25)
                Case "PEARL"
                    chkPearl.Visible = SQL.SQLDR("SystemEnabled")
                    chkPearl.Location = New Point(chkPearl.Location.X, ctr * 25)
                Case "ONYX"
                    chkOnyx.Visible = SQL.SQLDR("SystemEnabled")
                    chkOnyx.Location = New Point(chkOnyx.Location.X, ctr * 25)
                Case "EMERALD"
                    chkEmerald.Visible = SQL.SQLDR("SystemEnabled")
                    chkEmerald.Location = New Point(chkEmerald.Location.X, ctr * 25)
                Case "RUBY"
                    chkRuby.Visible = SQL.SQLDR("SystemEnabled")
                    chkRuby.Location = New Point(chkRuby.Location.X, ctr * 25)
                Case "SAPPHIRE"
                    chkSapphire.Visible = SQL.SQLDR("SystemEnabled")
                    chkSapphire.Location = New Point(chkSapphire.Location.X, ctr * 25)
            End Select
        End While
        If ctr > 1 Then
            ctr += 1
            chkAll.Visible = True
            chkAll.Location = New Point(chkAll.Location.X, ctr * 25)
        End If
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        chkEmerald.Enabled = Value
        chkJade.Enabled = Value
        chkOnyx.Enabled = Value
        chkPearl.Enabled = Value
        chkRuby.Enabled = Value
        chkSapphire.Enabled = Value
        chkAll.Enabled = Value
        cbSystem.Enabled = Value
    End Sub

    Private Sub LoadUserDetails()
        Try
            Dim query As String
            query = " SELECT    UserID, UserName, LoginName, Password, UserLevel, RefID, EmailAddress, ContactNo, Status, DateLastLogin " & _
                    " FROM      tblUser " & _
                    " WHERE     UserID = '" & User_ID & "' "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                lblUserID.Text = SQL.SQLDR("UserID").ToString
                lblUserName.Text = SQL.SQLDR("UserName").ToString
                lblLogin.Text = SQL.SQLDR("LoginName").ToString
                Password = SQL.SQLDR("Password").ToString
                lblPassword.Text = "**********"
                lblUserLevel.Text = SQL.SQLDR("UserLevel").ToString
                lblEmail.Text = SQL.SQLDR("EmailAddress").ToString
                lblContact.Text = SQL.SQLDR("ContactNo").ToString
                lblStatus.Text = SQL.SQLDR("Status").ToString
                If IsDBNull(SQL.SQLDR("DateLastLogin")) Then
                    lblLastLogin.Text = ""
                Else
                    lblLastLogin.Text = SQL.SQLDR("DateLastLogin")
                End If
                LoadModuleList()
                LoadSystemAccess()
                LoadModuleAccess()
                ' Toolstrip Buttons
                tsbSearch.Enabled = True
                tsbNew.Enabled = True
                tsbEdit.Enabled = True
                tsbTools.Enabled = False
                tsbDelete.Enabled = True
                tsbPrevious.Enabled = True
                tsbNext.Enabled = True
                tsbExit.Enabled = True
                EnableControl(True)

            Else
                lblUserID.Text = ""
                lblUserName.Text = ""
                lblLogin.Text = ""
                Password = ""
                lblPassword.Text = ""
                lblUserLevel.Text = ""
                lblEmail.Text = ""
                lblContact.Text = ""
                lblStatus.Text = ""
                lblLastLogin.Text = ""
                lvModule.Items.Clear()
            End If
            ResetFlags()
        Catch ex As Exception
            SaveError(ex.Message, ex.StackTrace, Me.Name.ToString, ModuleID)
        End Try
    End Sub

    Private Sub ResetFlags()
        uFlag_System = False
        uFlag_Module = False
        uFlag_Activity = False
        lvAccessAll.Items.Clear()
    End Sub

    Private Sub SaveAccess(ByVal user As Integer, Type As String, Code As String, Allow As Boolean)
        ' QUERY FIRST IF THERE IS AN EXISTING RECORD
        Dim query As String
        query = " SELECT isAllowed FROM tblUser_Access WHERE UserID = @UserID AND Type = @Type AND Code = @Code AND Status ='Active' "
        SQL.FlushParams()
        SQL.AddParam("@UserID", user)
        SQL.AddParam("@Type", Type)
        SQL.AddParam("@Code", Code)
        SQL.ReadQuery(query)
        If SQL.SQLDR.Read Then
            If SQL.SQLDR("isAllowed") <> Allow Then
                ' IF THERE IS EXISTING RECORD, SET OLD RECORD TO INACTIVE IF THERE IS ALLOWED IS MODIFIED
                Dim updateSQl As String
                updateSQl = " UPDATE tblUser_Access " & _
                            " SET    Status ='Inactive', DateModified = GETDATE(), WhoModified = @WhoModified " & _
                            " WHERE  UserID = @UserID AND Type = @Type AND Code = @Code"
                SQL.FlushParams()
                SQL.AddParam("@UserID", user)
                SQL.AddParam("@Type", Type)
                SQL.AddParam("@Code", Code)
                SQL.AddParam("@WhoModified", UserID)
                SQL.ExecNonQuery(updateSQl)
                ' INSERT NEW ACTIVE RECORD WITH MODIFIED VALUE
                Dim insertSQL As String
                insertSQL = " INSERT INTO " & _
                            " tblUser_Access(UserID, Type, Code, isAllowed, Status, WhoCreated) " & _
                            " VALUES(@UserID, @Type, @Code, @isAllowed, @Status, @WhoCreated) "
                SQL.FlushParams()
                SQL.AddParam("@UserID", user)
                SQL.AddParam("@Type", Type)
                SQL.AddParam("@Code", Code)
                SQL.AddParam("@isAllowed", Allow)
                SQL.AddParam("@Status", "Active")
                SQL.AddParam("@WhoCreated", UserID)
                SQL.ExecNonQuery(insertSQL)
            End If
        Else
            ' IF NO EXISTING RECORD, INSERT NEW RECORD
            Dim insertSQL As String
            insertSQL = " INSERT INTO " & _
                        " tblUser_Access(UserID, Type, Code, isAllowed, Status, WhoCreated) " & _
                        " VALUES(@UserID, @Type, @Code, @isAllowed, @Status, @WhoCreated) "
            SQL.FlushParams()
            SQL.AddParam("@UserID", user)
            SQL.AddParam("@Type", Type)
            SQL.AddParam("@Code", Code)
            SQL.AddParam("@isAllowed", Allow)
            SQL.AddParam("@Status", "Active")
            SQL.AddParam("@WhoCreated", UserID)
            SQL.ExecNonQuery(insertSQL)
        End If
    End Sub

    Private Sub LoadModuleList()
        Dim query As String
        query = "	SELECT ModuleID, ModuleName, SortNum, Type " & _
                "	FROM " & _
                "	( " & _
                "	SELECT ModuleID, ModuleName, SortNum, 'JADE' AS Type FROM tblModule WHERE JADE = 1 " & _
                "	UNION ALL " & _
                "	SELECT ModuleID, ModuleName, SortNum, 'PEARL' FROM tblModule WHERE PEARL = 1 " & _
                "	UNION ALL " & _
                "	SELECT ModuleID, ModuleName, SortNum, 'EMERALD' FROM tblModule WHERE EMERALD = 1 " & _
                "	UNION ALL " & _
                "	SELECT ModuleID, ModuleName, SortNum, 'ONYX' FROM tblModule WHERE ONYX = 1 " & _
                "	UNION ALL " & _
                "	SELECT ModuleID, ModuleName, SortNum, 'SAPPHIRE' FROM tblModule WHERE SAPPHIRE = 1  " & _
                "	UNION ALL  " & _
                "	SELECT ModuleID, ModuleName, SortNum, 'RUBY' FROM tblModule WHERE RUBY = 1 " & _
                "	) " & _
                "	AS Modules " & _
                "	ORDER BY Type, SortNum "
        SQL.ReadQuery(query)
        lvModuleList.Items.Clear()
        While SQL.SQLDR.Read
            lvModuleList.Items.Add(SQL.SQLDR("ModuleID").ToString)
            lvModuleList.Items(lvModuleList.Items.Count - 1).SubItems.Add(SQL.SQLDR("ModuleName").ToString)
            lvModuleList.Items(lvModuleList.Items.Count - 1).SubItems.Add(SQL.SQLDR("SortNum").ToString)
            lvModuleList.Items(lvModuleList.Items.Count - 1).SubItems.Add(SQL.SQLDR("Type").ToString)
        End While
    End Sub

    Private Sub LoadModules()
        lvModule.Items.Clear()
        For Each item As ListViewItem In lvModuleList.Items
            ' IF FILTER IS SET TO ALL ADD ONLY MODULES THAT BELONG TO CHECKED SYSTEMS 
            ' IF SET TO SPECIFIC SYSTEM ADD ONLY MODULE THAT BELONG TO THAT SYSTEM
            If (cbSystem.SelectedItem = chkJade.Text Or (cbSystem.SelectedItem = "ALL" And chkJade.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "JADE" Then
                AddModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkPearl.Text Or (cbSystem.SelectedItem = "ALL" And chkPearl.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "PEARL" Then
                AddModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkOnyx.Text Or (cbSystem.SelectedItem = "ALL" And chkOnyx.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "ONYX" Then
              AddModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkRuby.Text Or (cbSystem.SelectedItem = "ALL" And chkRuby.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "RUBY" Then
                AddModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkEmerald.Text Or (cbSystem.SelectedItem = "ALL" And chkEmerald.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "EMERALD" Then
                AddModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkSapphire.Text Or (cbSystem.SelectedItem = "ALL" And chkSapphire.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "SAPPHIRE" Then
                AddModuleToList(item)
            End If
        Next
    End Sub

    Private Sub AddModuleToList(item As ListViewItem)
        ' CHECK FIRST IF ITEM IS NOT ALREADY IN lvModAllowedAll LISTVIEW
        If Not ModExist(item.Text, lvModAllowedAll) Or ModAllowed(item.Text) = "N" Then
            ' IF NOT IN THE LIST CHECK IF IT IS NOT YET ADDED TO lvModule LISTVIEW
            If Not ModExist(item.Text, lvModule) Then
                ' ADD IF NOT YET ADDED
                lvModule.Items.Add(item.SubItems(chAllModID.Index).Text)
                lvModule.Items(lvModule.Items.Count - 1).SubItems.Add(item.SubItems(chAllModName.Index).Text)
            End If
        End If
    End Sub

    Private Sub LoadModulesAllowed()
        lvModAllowed.Items.Clear()
        For Each item As ListViewItem In lvModuleList.Items
            ' IF FILTER IS SET TO ALL ADD ONLY ALLOWED MODULES THAT BELONG TO CHECKED SYSTEMS 
            ' IF SET TO SPECIFIC SYSTEM ADD ONLY  ALLOWED MODULE THAT BELONG TO THAT SYSTEM
            If (cbSystem.SelectedItem = chkJade.Text Or (cbSystem.SelectedItem = "ALL" And chkJade.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "JADE" Then
                AddAllowedModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkPearl.Text Or (cbSystem.SelectedItem = "ALL" And chkPearl.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "PEARL" Then
                AddAllowedModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkOnyx.Text Or (cbSystem.SelectedItem = "ALL" And chkOnyx.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "ONYX" Then
                AddAllowedModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkRuby.Text Or (cbSystem.SelectedItem = "ALL" And chkRuby.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "RUBY" Then
                AddAllowedModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkEmerald.Text Or (cbSystem.SelectedItem = "ALL" And chkEmerald.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "EMERALD" Then
                AddAllowedModuleToList(item)
            ElseIf (cbSystem.SelectedItem = chkSapphire.Text Or (cbSystem.SelectedItem = "ALL" And chkSapphire.Checked = True)) AndAlso item.SubItems(chAllModCategory.Index).Text = "SAPPHIRE" Then
                AddAllowedModuleToList(item)
            End If
        Next
    End Sub

    Private Sub AddAllowedModuleToList(item As ListViewItem)
        ' CHECK FIRST IF ITEM IS ALREADY IS IN lvModAllowedAll LISTVIEW
        If ModExist(item.Text, lvModAllowedAll) AndAlso ModAllowed(item.Text) = "Y" Then
            ' IF IN THE LIST CHECK IF IT IS NOT YET ADDED TO lvModAllowed LISTVIEW
            If Not ModExist(item.Text, lvModAllowed) Then
                ' ADD IF NOT YET ADDED
                lvModAllowed.Items.Add(item.SubItems(chAllModID.Index).Text)
                lvModAllowed.Items(lvModAllowed.Items.Count - 1).SubItems.Add(item.SubItems(chAllModName.Index).Text)
            End If

        End If
    End Sub

    Private Sub LoadModuleAccess(ByVal Mod_ID As String)
        Dim functionID, accessType, isAllowed As String
        Dim query As String
        query = " SELECT	tblModuleAccess.FunctionID, AccessType, (CASE WHEN ISNULL(isAllowed,0) = '1' THEN 'Y' ELSE 'N' END) AS Allowed " & _
                " FROM	    tblModuleAccess LEFT JOIN tblUser_Access " & _
                " ON		tblUser_Access.Code = tblModuleAccess.FunctionID " & _
                " AND       tblUser_Access.Type ='Module Access'" & _
                " AND       tblUser_Access.UserID = '" & User_ID & "' " & _
                " AND Status ='Active'  " & _
                " WHERE     ModuleID ='" & Mod_ID & "' "
        SQL.GetQuery(query)
        lvAccess.Items.Clear()
        If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                functionID = row(0).ToString
                accessType = row(1).ToString
                isAllowed = row(2).ToString
                For Each item As ListViewItem In lvAccessAll.Items
                    If item.SubItems(0).Text = "Module Access" Then
                        If item.SubItems(1).Text = functionID Then
                            isAllowed = item.SubItems(2).Text
                        End If
                    End If
                Next
                lvAccess.Items.Add(functionID)
                lvAccess.Items(lvAccess.Items.Count - 1).SubItems.Add(accessType)
                lvAccess.Items(lvAccess.Items.Count - 1).SubItems.Add(isAllowed)
            Next
        End If
       
    End Sub

    Private Sub RefreshModuleAccess()
        If lvModAllowed.SelectedItems.Count = 1 Then
            lblModule.Text = "MODULE : " & lvModAllowed.SelectedItems(0).SubItems(1).Text.ToUpper
            ModID = lvModAllowed.SelectedItems(0).Text
            LoadModuleAccess(ModID)
        Else
            lblModule.Text = ""
            ModID = ""
            lvAccess.Items.Clear()
        End If
    End Sub

    Private Sub LoadSystemAccess()
        Dim query As String
        query = " SELECT	tblSystem.Code, ISNULL(isAllowed,0) AS isAllowed  " & _
                " FROM	    tblSystem LEFT JOIN tblUser_Access  " & _
                " ON        tblSystem.Code = tblUser_Access.Code" & _
                " AND       tblUser_Access.Type = 'System Access' " & _
                " AND       UserID = '" & User_ID & "' AND Status ='Active'  "
        SQL.ReadQuery(query)
        While SQL.SQLDR.Read
            Select Case SQL.SQLDR("Code").ToString
                Case "JADE" 
                    If chkJade.Visible = True Then chkJade.Checked = SQL.SQLDR("isAllowed") Else chkJade.Checked = False
                Case "RUBY"
                    If chkRuby.Visible = True Then chkRuby.Checked = SQL.SQLDR("isAllowed") Else chkRuby.Checked = False
                Case "EMERALD"
                    If chkEmerald.Visible = True Then chkEmerald.Checked = SQL.SQLDR("isAllowed") Else chkEmerald.Checked = False
                Case "SAPPHIRE"
                    If chkSapphire.Visible = True Then chkSapphire.Checked = SQL.SQLDR("isAllowed") Else chkSapphire.Checked = False
                Case "ONYX"
                    If chkOnyx.Visible = True Then chkOnyx.Checked = SQL.SQLDR("isAllowed") Else chkOnyx.Checked = False
                Case "PEARL"
                    If chkPearl.Visible = True Then chkPearl.Checked = SQL.SQLDR("isAllowed") Else chkPearl.Checked = False
            End Select

        End While
        cbSystem.SelectedItem = "ALL"
    End Sub

    Private Sub LoadModuleAccess()
        Dim query As String
        query = " SELECT	tblModule.ModuleID, ModuleName, 'Y' AS isAllowed  " & _
                " FROM	    tblModule INNER JOIN tblUser_Access  " & _
                " ON        tblModule.ModuleID = tblUser_Access.Code" & _
                " AND       tblUser_Access.Type = 'Module Access' " & _
                " AND       UserID = '" & User_ID & "' AND Status ='Active'  AND isAllowed = 1 "
        SQL.ReadQuery(query)
        lvModAllowedAll.Items.Clear()
        While SQL.SQLDR.Read
            lvModAllowedAll.Items.Add(SQL.SQLDR("ModuleID").ToString)
            lvModAllowedAll.Items(lvModAllowedAll.Items.Count - 1).SubItems.Add(SQL.SQLDR("ModuleName").ToString)
            lvModAllowedAll.Items(lvModAllowedAll.Items.Count - 1).SubItems.Add(SQL.SQLDR("isAllowed").ToString)
        End While
        LoadModules()
        LoadModulesAllowed()
        lvAccess.Items.Clear()
        lvAccessAll.Items.Clear()
        refreshOther()
    End Sub

    Private Sub SaveSystemAccess()
        Dim JADE, RUBY, EMERALD, SAPPHIRE, ONYX, PEARL As Boolean
        If chkJade.Visible = True AndAlso chkJade.Checked = True Then JADE = True Else JADE = False
        If chkRuby.Visible = True AndAlso chkRuby.Checked = True Then RUBY = True Else RUBY = False
        If chkEmerald.Visible = True AndAlso chkEmerald.Checked = True Then EMERALD = True Else EMERALD = False
        If chkSapphire.Visible = True AndAlso chkSapphire.Checked = True Then SAPPHIRE = True Else SAPPHIRE = False
        If chkOnyx.Visible = True AndAlso chkOnyx.Checked = True Then ONYX = True Else ONYX = False
        If chkPearl.Visible = True AndAlso chkPearl.Checked = True Then PEARL = True Else PEARL = False
        SaveAccess(User_ID, "System Access", "JADE", JADE)
        SaveAccess(User_ID, "System Access", "RUBY", RUBY)
        SaveAccess(User_ID, "System Access", "EMERALD", EMERALD)
        SaveAccess(User_ID, "System Access", "SAPPHIRE", SAPPHIRE)
        SaveAccess(User_ID, "System Access", "ONYX", ONYX)
        SaveAccess(User_ID, "System Access", "PEARL", PEARL)
    End Sub

    Private Sub SaveModuleAccess()
        Dim Allowed As Boolean = False
        For Each item As ListViewItem In lvModAllowedAll.Items
            If item.SubItems(2).Text = "Y" Then Allowed = True Else Allowed = False
            SaveAccess(User_ID, "Module Access", item.SubItems(0).Text, Allowed)
        Next
    End Sub

    Private Sub SaveModuleActivity()
        Dim Allowed As Boolean = False
        For Each item As ListViewItem In lvAccessAll.Items
            If item.SubItems(2).Text = "Y" Then Allowed = True Else Allowed = False
            SaveAccess(User_ID, item.SubItems(0).Text, item.SubItems(1).Text, Allowed)
        Next
    End Sub

    Private Sub LoadModuleContent(ByVal Mod_ID As String)
        Dim query As String
        query = " SELECT	tblUser_Access.FunctionID, AccessType  " & _
                " FROM	    tblModuleContent " & _
                " LEFT JOIN tblWarehouse " & _
                " ON        tblModuleContent.ModID = tblWarehouse.ModID " & _
                " WHERE     UserID = '" & User_ID & "' AND ModuleID ='" & Mod_ID & "' "
        SQL.ReadQuery(query)
        lvAccess.Items.Clear()
        While SQL.SQLDR.Read
            lvAccess.Items.Add(SQL.SQLDR("FunctionID"))
            lvAccess.Items(lvAccess.Items.Count - 1).SubItems.Add(SQL.SQLDR("AccessType"))
        End While
    End Sub

    Private Sub UpdateModRecord(ByVal ModID As String, Value As String)
        For Each item As ListViewItem In lvModAllowedAll.Items
            If item.Text = ModID Then
                item.SubItems(2).Text = Value
                Exit For
            End If
        Next
    End Sub
#End Region
#Region "FUNCTIONS"
    Private Function ModExist(ByVal ModID As String, lvMod As ListView) As Boolean
        Dim exist As Boolean = False
        For Each item As ListViewItem In lvMod.Items
            If item.Text = ModID Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function

    Private Function ModAllowed(ByVal ModID As String) As String
        Dim allowed As String = ""
        For Each item As ListViewItem In lvModAllowedAll.Items
            If item.Text = ModID Then
                If item.SubItems(2).Text = "Y" Then
                    allowed = "Y"
                ElseIf item.SubItems(2).Text = "N" Then
                    allowed = "N"
                End If
                Exit For
            End If
        Next
        Return allowed
    End Function
#End Region
#Region "TOOLBAR EVENTS"

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        If Not AllowAccess("UAR_VIEW") Then
            msgRestricted()
        Else
            Dim f As New frmVCE_Search
            f.ModFrom = "UAR"
            f.ShowDialog()
            If f.VCECode <> "" Then
                User_ID = f.VCECode
            End If
            LoadUserDetails()

            f.Dispose()
        End If
    End Sub

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click
        If Not AllowAccess("UAR_ADD") Then
            msgRestricted()
        Else
            Dim f As New frmUser_Add
            f.Type = "ADD"
            f.ShowDialog()
            User_ID = f.User_ID
            f.Dispose()
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        If MsgBox("Saving Changes, Click Yes to confirm", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "JADE Message Alert") = MsgBoxResult.Yes Then
            If uFlag_System = True Then SaveSystemAccess()
            If uFlag_Module = True Then SaveModuleAccess()
            If uFlag_Activity = True Then SaveModuleActivity()
            Msg("Record Saved Succesfully!", MsgBoxStyle.Information)
            ResetFlags()
        End If
    End Sub

    Private Sub tsbPrevious_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrevious.Click
        If Not IsNothing(User_ID) Then
            Dim query As String
            query = " SELECT Top 1 UserID FROM tblUser  WHERE UserID < '" & User_ID & "' ORDER BY UserID DESC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                User_ID = SQL.SQLDR("UserID").ToString
                LoadUserDetails()
            Else
                Msg("Reached the beginning of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub tsbNext_Click(sender As System.Object, e As System.EventArgs) Handles tsbNext.Click
        If Not IsNothing(User_ID) Then
            Dim query As String
            query = " SELECT Top 1 UserID FROM tblUser  WHERE UserID > '" & User_ID & "' ORDER BY UserID ASC "
            SQL.ReadQuery(query)
            If SQL.SQLDR.Read Then
                User_ID = SQL.SQLDR("UserID").ToString
                LoadUserDetails()
            Else
                Msg("Reached the end of record!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
#End Region
#Region "CONTROL EVENTS"

    Private Sub frmUser_Master_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.S Then
                If tsbSave.Enabled = True Then tsbSave.PerformClick()
            ElseIf e.KeyCode = Keys.F Then
                If tsbSearch.Enabled = True Then tsbSearch.PerformClick()
            ElseIf e.KeyCode = Keys.N Then
                If tsbNew.Enabled = True Then tsbNew.PerformClick()
            ElseIf e.KeyCode = Keys.E Then
                If tsbEdit.Enabled = True Then tsbEdit.PerformClick()
            ElseIf e.KeyCode = Keys.Left Then
                If tsbPrevious.Enabled = True Then tsbPrevious.PerformClick()
            ElseIf e.KeyCode = Keys.Right Then
                If tsbNext.Enabled = True Then tsbNext.PerformClick()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                If tsbExit.Enabled = True Then
                    tsbExit.PerformClick()
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        End If
    End Sub

    Private Sub chk_MouseEnter(sender As Object, e As System.EventArgs) Handles chkJade.MouseEnter, chkRuby.MouseEnter, chkPearl.MouseEnter, chkEmerald.MouseEnter, chkOnyx.MouseEnter, chkSapphire.MouseEnter
        sender.ForeColor = Color.Red
    End Sub


    Private Sub chk_MouseLeave(sender As Object, e As System.EventArgs) Handles chkJade.MouseLeave, chkRuby.MouseLeave, chkPearl.MouseLeave, chkEmerald.MouseLeave, chkOnyx.MouseLeave, chkSapphire.MouseLeave
        sender.ForeColor = Color.FromArgb(255, 0, 0, 0)
    End Sub

    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
        If disableEvent = False Then
            If chkAll.Checked = True Then
                ' CHECK ALL SYSTEM CHECKBOX
                If chkJade.Visible = True Then chkJade.Checked = True Else chkJade.Visible = False
                If chkPearl.Visible = True Then chkPearl.Checked = True Else chkPearl.Visible = False
                If chkRuby.Visible = True Then chkRuby.Checked = True Else chkRuby.Visible = False
                If chkOnyx.Visible = True Then chkOnyx.Checked = True Else chkOnyx.Visible = False
                If chkEmerald.Visible = True Then chkEmerald.Checked = True Else chkEmerald.Visible = False
                If chkSapphire.Visible = True Then chkSapphire.Checked = True Else chkSapphire.Visible = False

            ElseIf chkAll.Checked = False Then
                ' UNCHECK ALL SYSTEM CHECKBOX
                chkJade.Checked = False
                chkEmerald.Checked = False
                chkPearl.Checked = False
                chkSapphire.Checked = False
                chkRuby.Checked = False
                chkOnyx.Checked = False

            End If
            uFlag_System = True
        End If
    End Sub

    ' SYSTEM CHECKBOX
    Private Sub chk_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkJade.CheckedChanged, chkPearl.CheckedChanged, chkRuby.CheckedChanged, chkEmerald.CheckedChanged, chkOnyx.CheckedChanged, chkSapphire.CheckedChanged
        If disableEvent = False Then
            uFlag_System = True
            If sender.checked = True Then ' IF ALLOWED, ADD TO COMBOBOX

                ' ADD ONLY IF NOT IN COMBOBOX
                If Not cbSystem.Items.Contains(sender.Text) Then
                    cbSystem.Items.Add(sender.Text)
                End If

                ' IF SYSTEM COMBOBOX CONTAINS MORE THAN ONE ITEMS, ADD 'ALL' VALUE
                If cbSystem.Items.Count > 1 AndAlso Not cbSystem.Items.Contains(chkAll.Text) Then
                    cbSystem.Items.Add(chkAll.Text)
                End If
            ElseIf sender.checked = False Then  ' IF NOT ALLOWED, REMOVE TO COMBOBOX

                ' ADD ONLY IF NOT IN COMBOBOX
                If cbSystem.Items.Contains(sender.Text) Then
                    cbSystem.Items.Remove(sender.Text)
                End If

                ' REMOVE CHECK IN 'ALL' CHECKBOX 
                If chkAll.Checked = True Then
                    disableEvent = True
                    chkAll.Checked = False
                    disableEvent = False
                End If
            End If
            LoadModules()
            LoadModulesAllowed()
        End If

    End Sub

    Private Sub cbSystem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSystem.SelectedIndexChanged
        LoadModules()
        LoadModulesAllowed()
    End Sub

    Private Sub btnAddAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAll.Click    ' MOVE ALL ROWS IN lvModule TO lvModAllowedAll LISTVIEW
        ' CHECK FIRST IF lvModule HAS ITEMS
        If lvModule.Items.Count > 0 Then
            For Each item As ListViewItem In lvModule.Items
                ' ADD ITEM IF NOT YET EXISTING IN lvModAllowedAll 
                If Not ModExist(item.Text, lvModAllowedAll) Then
                    lvModAllowedAll.Items.Add(item.Text)
                    lvModAllowedAll.Items(lvModAllowedAll.Items.Count - 1).SubItems.Add(item.SubItems(chAllModName.Index).Text)
                    lvModAllowedAll.Items(lvModAllowedAll.Items.Count - 1).SubItems.Add("Y")
                Else
                    UpdateModRecord(item.Text, "Y")
                End If
            Next
            LoadModules()
            LoadModulesAllowed()
            uFlag_Module = True
        End If
    End Sub

    Private Sub btnAddSpecific_Click(sender As System.Object, e As System.EventArgs) Handles btnAddSpecific.Click
        ' CHECK FIRST IF lvModule HAS SELECTED ITEMS
        If lvModule.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In lvModule.SelectedItems
                ' ADD ITEM IF NOT YET EXISTING IN lvModAllowedAll 
                If Not ModExist(item.Text, lvModAllowedAll) Then
                    lvModAllowedAll.Items.Add(item.Text)
                    lvModAllowedAll.Items(lvModAllowedAll.Items.Count - 1).SubItems.Add(item.SubItems(chAllModName.Index).Text)
                    lvModAllowedAll.Items(lvModAllowedAll.Items.Count - 1).SubItems.Add("Y")
                Else
                    UpdateModRecord(item.Text, "Y")
                End If
            Next
            LoadModules()
            LoadModulesAllowed()
            uFlag_Module = True
        End If
    End Sub

    Private Sub btnRemSpecific_Click(sender As System.Object, e As System.EventArgs) Handles btnRemSpecific.Click
        If lvModAllowed.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In lvModAllowed.SelectedItems
                For Each item2 As ListViewItem In lvModAllowedAll.Items
                    If item.Text = item2.Text Then
                        item2.SubItems(2).Text = "N"
                    End If
                Next
            Next
            LoadModules()
            LoadModulesAllowed()
            RefreshModuleAccess()
            uFlag_Module = True
        End If
    End Sub



    Private Sub btnRemAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRemAll.Click
        If lvModAllowed.Items.Count > 0 Then
            For Each item As ListViewItem In lvModAllowed.Items
                For Each item2 As ListViewItem In lvModAllowedAll.Items
                    If item.Text = item2.Text Then
                        item2.SubItems(2).Text = "N"
                    End If
                Next
            Next
            LoadModules()
            LoadModulesAllowed()
            RefreshModuleAccess()
            uFlag_Module = True
        End If
    End Sub

    Private Sub lvModAllowed_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvModAllowed.SelectedIndexChanged
        RefreshModuleAccess()
    End Sub

    Private Sub cbType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbType.SelectedIndexChanged
        refreshOther()
    End Sub

    Private Sub refreshOther()
        lvOthers.Items.Clear()
        Dim otherID, otherDesc, isAllowed As String
        If cbType.SelectedItem = "Warehouse" Then
            Dim query As String
            query = " SELECT tblWarehouse.Code, Description, CASE WHEN ISNULL(isAllowed,0) = 0 THEN 'N' ELSE 'Y' END AS isAllowed " & _
                    " FROM tblWarehouse LEFT JOIN tblUser_Access " & _
                    " ON tblWarehouse.Code = tblUser_Access.Code " & _
                    " AND Type = 'Warehouse' AND  tblUser_Access.Status ='Active' " & _
                    " AND tblUser_Access.UserID = '" & User_ID & "' " & _
                    " WHERE tblWarehouse.Status ='Active' "
            SQL.GetQuery(query)
            If SQL.SQLDS.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In SQL.SQLDS.Tables(0).Rows
                    otherID = row(0).ToString
                    otherDesc = row(1).ToString
                    isAllowed = row(2).ToString
                    For Each item As ListViewItem In lvAccessAll.Items
                        If item.SubItems(0).Text = cbType.SelectedItem Then
                            If item.SubItems(1).Text = otherID Then
                                isAllowed = item.SubItems(2).Text
                            End If
                        End If
                    Next
                    lvOthers.Items.Add(otherID)
                    lvOthers.Items(lvOthers.Items.Count - 1).SubItems.Add(otherDesc)
                    lvOthers.Items(lvOthers.Items.Count - 1).SubItems.Add(isAllowed)
                Next
            End If
        End If
    End Sub

    Private Sub lvAccess_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvAccess.MouseDown, lvOthers.MouseDown
        If e.Button = MouseButtons.Right Then
            If sender.Items.Count > 0 Then
                If Not sender.FocusedItem Is Nothing Then
                    If sender.SelectedItems.Count > 0 Then
                        Dim lvItem As ListViewItem
                        lvItem = sender.GetItemAt(e.X, e.Y)
                        If Not lvItem Is Nothing Then
                            If lvItem.SubItems(2).Text = "Y" Then
                                ' SHOW DISALLOW OPTION WHEN MODULE IS SET TO ALLOWED
                                tsmiAllow.Visible = False
                                tsmiDisallow.Visible = True
                            Else
                                ' SHOW ALLOW OPTION WHEN MODULE IS SET TO DISALLOWED
                                tsmiAllow.Visible = True
                                tsmiDisallow.Visible = False
                            End If
                            Me.cmsUpdate.Show(sender, New Point(e.X, e.Y))
                            lvSelected = sender
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tsmiAllow_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAllow.Click
        Dim category As String = ""
        If lvSelected.SelectedItems.Count = 1 Then
            If lvSelected Is lvAccess Then
                category = "Module Access"
            ElseIf lvSelected Is lvOthers Then
                If cbType.SelectedIndex <> -1 Then
                    category = cbType.SelectedItem
                End If
            End If
            If category <> "" Then
                Dim exist As Boolean = False
                ' LOOP THROUGH lvAccessAll LISTVIEW IF ACCESS CODE ALREADY HAS UPDATE RECORD
                For Each item As ListViewItem In lvAccessAll.Items
                    If item.SubItems(0).Text = category AndAlso item.SubItems(1).Text = lvSelected.SelectedItems(0).SubItems(0).Text Then
                        item.SubItems(2).Text = "Y"
                        exist = True
                        Exit For
                    End If
                Next

                ' IF NO EXISTING RECORD, ADD UPDATE RECORD
                If exist = False Then
                    lvAccessAll.Items.Add(category)
                    lvAccessAll.Items(lvAccessAll.Items.Count - 1).SubItems.Add(lvSelected.SelectedItems(0).SubItems(0).Text)
                    lvAccessAll.Items(lvAccessAll.Items.Count - 1).SubItems.Add("Y")
                End If
                ' CHANGE ALLOW STATUS IN DISPLAYED LISTVIEW
                lvSelected.SelectedItems(0).SubItems(2).Text = "Y"
            End If
            uFlag_Activity = True
        End If
    End Sub

    Private Sub tsmiDisallow_Click(sender As System.Object, e As System.EventArgs) Handles tsmiDisallow.Click
        Dim category As String = ""
        If lvSelected.SelectedItems.Count = 1 Then
            If lvSelected Is lvAccess Then
                category = "Module Access"
            ElseIf lvSelected Is lvOthers Then
                If cbType.SelectedIndex <> -1 Then
                    category = cbType.SelectedItem
                End If
            End If
            If category <> "" Then
                Dim exist As Boolean = False
                ' LOOP THROUGH lvAccessAll LISTVIEW IF ACCESS CODE ALREADY HAS UPDATE RECORD
                For Each item As ListViewItem In lvAccessAll.Items
                    If item.SubItems(0).Text = category AndAlso item.SubItems(1).Text = lvSelected.SelectedItems(0).SubItems(0).Text Then
                        item.SubItems(2).Text = "N"
                        Exit For
                        exist = True
                    End If
                Next

                ' IF NO EXISTING RECORD, ADD UPDATE RECORD
                If exist = False Then
                    lvAccessAll.Items.Add(category)
                    lvAccessAll.Items(lvAccessAll.Items.Count - 1).SubItems.Add(lvSelected.SelectedItems(0).SubItems(0).Text)
                    lvAccessAll.Items(lvAccessAll.Items.Count - 1).SubItems.Add("N")
                End If
                ' CHANGE ALLOW STATUS IN DISPLAYED LISTVIEW
                lvSelected.SelectedItems(0).SubItems(2).Text = "N"
            End If
            uFlag_Activity = True
        End If
    End Sub
#End Region
#End Region







    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        Try
            If lvModule.SelectedItems.Count = 1 Then
                Dim ModIndex As Integer = lvModule.SelectedItems(0).Index
                ModID = lvModule.SelectedItems(0).SubItems(0).Text
                Dim f As New frmUser_Access
                f.lblModule.Text = "Module : " & lvModule.SelectedItems(0).SubItems(1).Text
                f.UsersID = User_ID
                f.ModID = ModID
                f.ShowDialog()
                f.Dispose()
                lvModule.Items(ModIndex).Selected = True
                lvModule.Items(ModIndex).Focused = True
                lvModule.Select()
                LoadModuleAccess(lvModule.SelectedItems(0).SubItems(0).Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click

    End Sub
End Class