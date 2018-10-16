Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.Net.NetworkInformation

Public Class Main_JADE
    Public Overloads Function ShowDialog(ByVal DTBSE As String, ByVal IPADD As String) As Boolean
        TxtDatabase.Text = DTBSE
        MyBase.ShowDialog()
        Return True
    End Function

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnMasterfile.Click
        mtcMenu.SelectedTab = MetroTabPage1
        btnMasterfile.BackColor = Color.OliveDrab
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnPurchasing_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchasing.Click
        mtcMenu.SelectedTab = MetroTabPage2
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.OliveDrab
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnCollection_Click(sender As System.Object, e As System.EventArgs) Handles btnCollection.Click
        mtcMenu.SelectedTab = MetroTabPage3
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.OliveDrab
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnSales_Click(sender As System.Object, e As System.EventArgs) Handles btnSales.Click
        mtcMenu.SelectedTab = MetroTabPage4
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.OliveDrab
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnInventory_Click(sender As System.Object, e As System.EventArgs) Handles btnInventory.Click
        mtcMenu.SelectedTab = MetroTabPage5
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.OliveDrab
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnGeneralJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralJournal.Click
        mtcMenu.SelectedTab = MetroTabPage6
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.OliveDrab
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnDisbursement_Click(sender As System.Object, e As System.EventArgs) Handles btnDisbursement.Click
        mtcMenu.SelectedTab = MetroTabPage7
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.OliveDrab
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnPosting_Click(sender As System.Object, e As System.EventArgs) Handles btnPosting.Click
        mtcMenu.SelectedTab = MetroTabPage8
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.OliveDrab
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnReports_Click(sender As System.Object, e As System.EventArgs) Handles btnReports.Click
        mtcMenu.SelectedTab = MetroTabPage9
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.OliveDrab
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub btnOtherModules_Click(sender As System.Object, e As System.EventArgs) Handles btnOtherModules.Click
        mtcMenu.SelectedTab = MetroTabPage10
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.OliveDrab
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub MetroTile9_Click(sender As System.Object, e As System.EventArgs) Handles tilePurchaseOrder.Click
        frmPO.Show()
    End Sub

    Private Sub MetroTile1_Click(sender As System.Object, e As System.EventArgs) Handles tileVCEMaster.Click
        frmVCE_Master.Show()
    End Sub

    Private Sub tileItemMaster_Click(sender As System.Object, e As System.EventArgs) Handles tileItemMaster.Click
        frmItem_Master.Show()
    End Sub

    Private Sub tileChartofAccount_Click(sender As System.Object, e As System.EventArgs) Handles tileChartofAccount.Click
        frmCOA.Show()
    End Sub

    Private Sub tileBankList_Click(sender As System.Object, e As System.EventArgs) Handles tileBankList.Click
        frmMasterfile_Bank.Show()
    End Sub

    Private Sub tileUserMaster_Click(sender As System.Object, e As System.EventArgs) Handles tileUserMaster.Click
        If Not AllowAccess("UAR_VIEW") Then
            msgRestrictedMod()
        Else
            frmUser_Master.Show()
        End If

    End Sub

    Private Sub tileWarehouseMaster_Click(sender As System.Object, e As System.EventArgs) Handles tileWarehouseMaster.Click
        frmWH.Show()
    End Sub

    Private Sub tileBillsofMaterials_Click(sender As System.Object, e As System.EventArgs)
        frmBOMList.Show()
    End Sub

    Private Sub MainForm1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'To avoid borderless form cover the taskbar
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.Manual
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        mtcMenu.SelectedTab = MetroHomeTab

    End Sub

    Private Sub MetroTile8_Click(sender As System.Object, e As System.EventArgs) Handles tilePurchaseRequisition.Click
        frmPR.Show()
    End Sub

    Private Sub MetroTile10_Click(sender As System.Object, e As System.EventArgs) Handles tileAccountsPayableVoucher.Click
        frmAPV.Show()
    End Sub

    Private Sub MetroTile11_Click(sender As System.Object, e As System.EventArgs) Handles tileOfficialReceipt.Click
        frmCollection.TransType = "OR"
        frmCollection.Show()
    End Sub

    Private Sub tileCollectionReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tileCollectionReceipt.Click
        frmCollection.TransType = "CR"
        frmCollection.Show()
    End Sub

    Private Sub tileBankDeposit_Click(sender As System.Object, e As System.EventArgs) Handles tileBankDeposit.Click
        frmdeposit.Show()
    End Sub

    Private Sub tileAcknowledgementReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tileAcknowledgementReceipt.Click
        frmCollection.TransType = "AR"
        frmCollection.Show()
    End Sub

    Private Sub tileBankRecon_Click(sender As System.Object, e As System.EventArgs) Handles tileBankRecon.Click
        FrmBank_Recon.Show()
    End Sub

    Private Sub tileSalesOrder_Click(sender As System.Object, e As System.EventArgs) Handles tileSalesOrder.Click
        frmSO.Show()
    End Sub

    Private Sub tileSalesInvoice_Click(sender As System.Object, e As System.EventArgs) Handles tileSalesInvoice.Click
        frmSI.Show()
    End Sub

    Private Sub tileReceivingReport_Click(sender As System.Object, e As System.EventArgs) Handles tileReceivingReport.Click
        frmRR.Show()
    End Sub

    Private Sub tileDeliveryReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tileDeliveryReceipt.Click
        frmDR.Show()
    End Sub

    Private Sub tileGoodsIssue_Click(sender As System.Object, e As System.EventArgs) Handles tileGoodsIssue.Click
        frmGI.Show()
    End Sub

    Private Sub tileGoodsReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tileGoodsReceipt.Click
        frmGR.Show()
    End Sub

    Private Sub tileInventoryTransfer_Click(sender As System.Object, e As System.EventArgs) Handles tileInventoryTransfer.Click
        frmIT.Show()
    End Sub

    Private Sub tileJournalVoucher_Click(sender As System.Object, e As System.EventArgs) Handles tileJournalVoucher.Click
        frmJV.Show()
    End Sub

    Private Sub tileCashDisbursement_Click(sender As System.Object, e As System.EventArgs) Handles tileCashDisbursement.Click
        frmCV.Show()
    End Sub

    Private Sub tileAdvances_Click(sender As System.Object, e As System.EventArgs) Handles tileAdvances.Click
        frmAdvances.Show()
    End Sub

    Private Sub tileBatchPosting_Click(sender As System.Object, e As System.EventArgs) Handles tileBatchPosting.Click
        frmPosting_Main.Show()
    End Sub

    Private Sub picLogout_Click(sender As System.Object, e As System.EventArgs) Handles picLogout.Click
        Dim myForms As FormCollection = Application.OpenForms
        Dim listBox As New ListBox
        For Each frmName As Form In myForms
            listBox.Items.Add(frmName.Name.ToString)
        Next
        If listBox.Items.Count > 3 Then
            If MsgBox("There are still opened forms, Are you sure you want to logout?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each item In listBox.Items
                    If item.ToString <> "" AndAlso item.ToString <> "MainForm" AndAlso item.ToString <> "LoadingScreen" Then
                        Dim myForm As Form = Application.OpenForms(item.ToString)
                        myForm.Close()
                    End If
                Next
                frmUserLogin.Show()
                Me.Close()
            End If
        Else
            frmUserLogin.Show()
            Me.Close()
        End If
        SQL.CloseCon()
    End Sub

    Private Sub picLogout_MouseEnter(sender As Object, e As System.EventArgs) Handles picLogout.MouseHover
        picLogout.BackColor = Color.Green
    End Sub

    Private Sub picLogout_MouseLeave(sender As Object, e As System.EventArgs) Handles picLogout.MouseLeave
        picLogout.BackColor = Color.Transparent
    End Sub

    Private Sub picSettings_MouseEnter(sender As Object, e As System.EventArgs) Handles picSettings.MouseEnter
        picSettings.BackColor = Color.Green
    End Sub

    Private Sub picSettings_MouseLeave(sender As Object, e As System.EventArgs) Handles picSettings.MouseLeave
        picSettings.BackColor = Color.Transparent
    End Sub

    Private Sub MetroTile2_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile2.Click
        frmGLFinacialReportGenerator.Show()
    End Sub

    Private Sub MetroTile1_Click_1(sender As System.Object, e As System.EventArgs) Handles MetroTile1.Click
        frmReport_Generator.Show()
    End Sub

    Private Sub picSettings_Click(sender As System.Object, e As System.EventArgs) Handles picSettings.Click
        frmSettings.Show()
    End Sub

    Private Sub MetroTile4_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile4.Click
        frmBS_Software.Show()
    End Sub

    Private Sub MetroTile3_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile3.Click
        frmBilling_Manpower.Show()
    End Sub

    Private Sub MetroTile5_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile5.Click
        frmSP.Show()
    End Sub

    Private Sub MetroTile6_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile6.Click
        frmSC.show()
    End Sub

    Private Sub MetroTile7_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile7.Click
        frmUploader.Show()
    End Sub

    Private Sub MetroTile8_Click_1(sender As System.Object, e As System.EventArgs) Handles MetroTile8.Click
        frmUploadHistory.Show()
    End Sub

    Private Sub MetroTile9_Click_1(sender As System.Object, e As System.EventArgs) Handles MetroTile9.Click
        frmRFP.Show()
    End Sub

    Private Sub MetroTile10_Click_1(sender As System.Object, e As System.EventArgs) Handles mtCC.Click
        frmCC.Show()
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles btnProduction.Click
        mtcMenu.SelectedTab = mtpProd
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.OliveDrab
        btnCoop.BackColor = Color.Transparent
    End Sub

    Private Sub MetroTile11_Click_1(sender As System.Object, e As System.EventArgs) Handles MetroTile11.Click
        frmJO.Show()
    End Sub

    Private Sub MetroTile13_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile13.Click
        frmBOM.Show()
    End Sub

    Private Sub MetroTile12_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile12.Click
        frmBOMlist.Show()
    End Sub

    Private Sub MetroTile14_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile14.Click
        frmCF.Show()
    End Sub

    Private Sub mtPC_Click(sender As System.Object, e As System.EventArgs) Handles mtPC.Click
        frmPC.show()
    End Sub

    Private Sub MetroTile10_Click_2(sender As System.Object, e As System.EventArgs) Handles MetroTile10.Click
        frmCompanyProfile.Show()
    End Sub

    Private Sub MetroTile15_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile15.Click
        frmPWH.Show()
    End Sub

    Private Sub btnCoop_Click(sender As System.Object, e As System.EventArgs) Handles btnCoop.Click
        mtcMenu.SelectedTab = mtpCoop
        btnMasterfile.BackColor = Color.Transparent
        btnPurchasing.BackColor = Color.Transparent
        btnCollection.BackColor = Color.Transparent
        btnSales.BackColor = Color.Transparent
        btnInventory.BackColor = Color.Transparent
        btnGeneralJournal.BackColor = Color.Transparent
        btnDisbursement.BackColor = Color.Transparent
        btnPosting.BackColor = Color.Transparent
        btnReports.BackColor = Color.Transparent
        btnOtherModules.BackColor = Color.Transparent
        btnProduction.BackColor = Color.Transparent
        btnCoop.BackColor = Color.OliveDrab
    End Sub

    Private Sub MetroTile16_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile16.Click
        frmMember_Master.Show()
    End Sub

    Private Sub MetroTile18_Click(sender As System.Object, e As System.EventArgs) Handles MetroTile18.Click
        frmLoan_Maintenance.Show()
    End Sub
End Class