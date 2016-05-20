<CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.LblFolderTitle = New System.Windows.Forms.Label()
        Me.LblMainDescription = New System.Windows.Forms.Label()
        Me.TxbFolderSource = New System.Windows.Forms.TextBox()
        Me.PnlBoxFolder = New System.Windows.Forms.Panel()
        Me.ChkFolderSubfolder = New System.Windows.Forms.CheckBox()
        Me.BtnFolderSource = New System.Windows.Forms.Button()
        Me.BtnFolderSettings = New System.Windows.Forms.Button()
        Me.BtnFolderNext = New System.Windows.Forms.Button()
        Me.GrpSettingsFeedback = New System.Windows.Forms.GroupBox()
        Me.BtnFeedbackReset = New System.Windows.Forms.Button()
        Me.GrpSettingsAbout = New System.Windows.Forms.GroupBox()
        Me.BtnAboutOpen = New System.Windows.Forms.Button()
        Me.GrpSettingsHelp = New System.Windows.Forms.GroupBox()
        Me.BtnHelpOpen = New System.Windows.Forms.Button()
        Me.GrpSettingsUpdate = New System.Windows.Forms.GroupBox()
        Me.GrpUpdateSearch = New System.Windows.Forms.Button()
        Me.GrpSettingsNotifications = New System.Windows.Forms.GroupBox()
        Me.BtnNotificationsSwitch = New System.Windows.Forms.Button()
        Me.GrpSettingsSplashscreen = New System.Windows.Forms.GroupBox()
        Me.BtnSplashscreenSwitch = New System.Windows.Forms.Button()
        Me.GrpSettingsLog = New System.Windows.Forms.GroupBox()
        Me.BtnLogDelete = New System.Windows.Forms.Button()
        Me.BtnLogShow = New System.Windows.Forms.Button()
        Me.LblSettingsTitle = New System.Windows.Forms.Label()
        Me.LblSettingsDescription = New System.Windows.Forms.Label()
        Me.PnlMainBox = New System.Windows.Forms.Panel()
        Me.BtnSortingGoHaltSwitch = New System.Windows.Forms.Button()
        Me.PnlBoxSettings = New System.Windows.Forms.Panel()
        Me.PnlSettingsSpacer = New System.Windows.Forms.Panel()
        Me.BtnSettingsBack = New System.Windows.Forms.Button()
        Me.BtnSettingsReset = New System.Windows.Forms.Button()
        Me.PnlBoxFormat = New System.Windows.Forms.Panel()
        Me.ChkFormatSwitch = New System.Windows.Forms.CheckBox()
        Me.LblFormatExamples = New System.Windows.Forms.Label()
        Me.BtnFormatPrevious = New System.Windows.Forms.Button()
        Me.LblFormatExample2 = New System.Windows.Forms.Label()
        Me.LblFormatExample1 = New System.Windows.Forms.Label()
        Me.BtnFormatSettings = New System.Windows.Forms.Button()
        Me.TxbFormatPattern = New System.Windows.Forms.TextBox()
        Me.LblFormatTitle = New System.Windows.Forms.Label()
        Me.BtnFormatNext = New System.Windows.Forms.Button()
        Me.LblFormatDescription = New System.Windows.Forms.Label()
        Me.PnlBoxSorting = New System.Windows.Forms.Panel()
        Me.GrpSortingFolders = New System.Windows.Forms.GroupBox()
        Me.LblFoldersMusic = New System.Windows.Forms.Label()
        Me.LblFoldersVideos = New System.Windows.Forms.Label()
        Me.LblFoldersDocuments = New System.Windows.Forms.Label()
        Me.LblFoldersImages = New System.Windows.Forms.Label()
        Me.BtnFoldersVideos = New System.Windows.Forms.Button()
        Me.BtnFoldersImages = New System.Windows.Forms.Button()
        Me.BtnFoldersMusic = New System.Windows.Forms.Button()
        Me.BtnFoldersDocuments = New System.Windows.Forms.Button()
        Me.GrpSortingSource = New System.Windows.Forms.GroupBox()
        Me.RbSourceCopy = New System.Windows.Forms.RadioButton()
        Me.RbSourceMove = New System.Windows.Forms.RadioButton()
        Me.GrpSortingTarget = New System.Windows.Forms.GroupBox()
        Me.RbTargetDuplicate = New System.Windows.Forms.RadioButton()
        Me.RbTargetOverwrite = New System.Windows.Forms.RadioButton()
        Me.BtnSortingPrevious = New System.Windows.Forms.Button()
        Me.ChkSortingSwitch = New System.Windows.Forms.CheckBox()
        Me.BtnSortingSettings = New System.Windows.Forms.Button()
        Me.LblSortingTitle = New System.Windows.Forms.Label()
        Me.LblSortingDescription = New System.Windows.Forms.Label()
        Me.PnlBoxFiletype = New System.Windows.Forms.Panel()
        Me.BtnFiletypeSelect = New System.Windows.Forms.Button()
        Me.ChkFiletypeEXIF = New System.Windows.Forms.CheckBox()
        Me.BtnFiletypePrevious = New System.Windows.Forms.Button()
        Me.BtnFiletypeSettings = New System.Windows.Forms.Button()
        Me.LblFiletypeTitle = New System.Windows.Forms.Label()
        Me.BtnFiletypeNext = New System.Windows.Forms.Button()
        Me.LblFiletypeDescription = New System.Windows.Forms.Label()
        Me.PgbMain = New System.Windows.Forms.ProgressBar()
        Me.LblMainTask = New System.Windows.Forms.Label()
        Me.PnlProgress = New System.Windows.Forms.Panel()
        Me.PnlBoxFolder.SuspendLayout()
        Me.GrpSettingsFeedback.SuspendLayout()
        Me.GrpSettingsAbout.SuspendLayout()
        Me.GrpSettingsHelp.SuspendLayout()
        Me.GrpSettingsUpdate.SuspendLayout()
        Me.GrpSettingsNotifications.SuspendLayout()
        Me.GrpSettingsSplashscreen.SuspendLayout()
        Me.GrpSettingsLog.SuspendLayout()
        Me.PnlMainBox.SuspendLayout()
        Me.PnlBoxSettings.SuspendLayout()
        Me.PnlBoxFormat.SuspendLayout()
        Me.PnlBoxSorting.SuspendLayout()
        Me.GrpSortingFolders.SuspendLayout()
        Me.GrpSortingSource.SuspendLayout()
        Me.GrpSortingTarget.SuspendLayout()
        Me.PnlBoxFiletype.SuspendLayout()
        Me.PnlProgress.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblFolderTitle
        '
        resources.ApplyResources(Me.LblFolderTitle, "LblFolderTitle")
        Me.LblFolderTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFolderTitle.Name = "LblFolderTitle"
        '
        'LblMainDescription
        '
        resources.ApplyResources(Me.LblMainDescription, "LblMainDescription")
        Me.LblMainDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblMainDescription.Name = "LblMainDescription"
        '
        'TxbFolderSource
        '
        resources.ApplyResources(Me.TxbFolderSource, "TxbFolderSource")
        Me.TxbFolderSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxbFolderSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.TxbFolderSource.Name = "TxbFolderSource"
        '
        'PnlBoxFolder
        '
        Me.PnlBoxFolder.Controls.Add(Me.ChkFolderSubfolder)
        Me.PnlBoxFolder.Controls.Add(Me.BtnFolderSource)
        Me.PnlBoxFolder.Controls.Add(Me.BtnFolderSettings)
        Me.PnlBoxFolder.Controls.Add(Me.TxbFolderSource)
        Me.PnlBoxFolder.Controls.Add(Me.LblFolderTitle)
        Me.PnlBoxFolder.Controls.Add(Me.BtnFolderNext)
        Me.PnlBoxFolder.Controls.Add(Me.LblMainDescription)
        resources.ApplyResources(Me.PnlBoxFolder, "PnlBoxFolder")
        Me.PnlBoxFolder.Name = "PnlBoxFolder"
        '
        'ChkFolderSubfolder
        '
        resources.ApplyResources(Me.ChkFolderSubfolder, "ChkFolderSubfolder")
        Me.ChkFolderSubfolder.Name = "ChkFolderSubfolder"
        Me.ChkFolderSubfolder.UseVisualStyleBackColor = True
        '
        'BtnFolderSource
        '
        Me.BtnFolderSource.BackgroundImage = Global.BatchRename.My.Resources.Resources.Folder_Up
        resources.ApplyResources(Me.BtnFolderSource, "BtnFolderSource")
        Me.BtnFolderSource.FlatAppearance.BorderSize = 0
        Me.BtnFolderSource.Name = "BtnFolderSource"
        Me.BtnFolderSource.UseVisualStyleBackColor = True
        '
        'BtnFolderSettings
        '
        resources.ApplyResources(Me.BtnFolderSettings, "BtnFolderSettings")
        Me.BtnFolderSettings.BackgroundImage = Global.BatchRename.My.Resources.Resources.Settings
        Me.BtnFolderSettings.FlatAppearance.BorderSize = 0
        Me.BtnFolderSettings.Name = "BtnFolderSettings"
        Me.BtnFolderSettings.UseVisualStyleBackColor = True
        '
        'BtnFolderNext
        '
        resources.ApplyResources(Me.BtnFolderNext, "BtnFolderNext")
        Me.BtnFolderNext.BackgroundImage = Global.BatchRename.My.Resources.Resources.Down
        Me.BtnFolderNext.FlatAppearance.BorderSize = 0
        Me.BtnFolderNext.Name = "BtnFolderNext"
        Me.BtnFolderNext.UseVisualStyleBackColor = True
        '
        'GrpSettingsFeedback
        '
        resources.ApplyResources(Me.GrpSettingsFeedback, "GrpSettingsFeedback")
        Me.GrpSettingsFeedback.Controls.Add(Me.BtnFeedbackReset)
        Me.GrpSettingsFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSettingsFeedback.Name = "GrpSettingsFeedback"
        Me.GrpSettingsFeedback.TabStop = False
        '
        'BtnFeedbackReset
        '
        resources.ApplyResources(Me.BtnFeedbackReset, "BtnFeedbackReset")
        Me.BtnFeedbackReset.FlatAppearance.BorderSize = 0
        Me.BtnFeedbackReset.Name = "BtnFeedbackReset"
        Me.BtnFeedbackReset.UseVisualStyleBackColor = True
        '
        'GrpSettingsAbout
        '
        resources.ApplyResources(Me.GrpSettingsAbout, "GrpSettingsAbout")
        Me.GrpSettingsAbout.Controls.Add(Me.BtnAboutOpen)
        Me.GrpSettingsAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSettingsAbout.Name = "GrpSettingsAbout"
        Me.GrpSettingsAbout.TabStop = False
        '
        'BtnAboutOpen
        '
        Me.BtnAboutOpen.BackgroundImage = Global.BatchRename.My.Resources.Resources.Info_Up
        resources.ApplyResources(Me.BtnAboutOpen, "BtnAboutOpen")
        Me.BtnAboutOpen.FlatAppearance.BorderSize = 0
        Me.BtnAboutOpen.Name = "BtnAboutOpen"
        Me.BtnAboutOpen.UseVisualStyleBackColor = True
        '
        'GrpSettingsHelp
        '
        resources.ApplyResources(Me.GrpSettingsHelp, "GrpSettingsHelp")
        Me.GrpSettingsHelp.Controls.Add(Me.BtnHelpOpen)
        Me.GrpSettingsHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSettingsHelp.Name = "GrpSettingsHelp"
        Me.GrpSettingsHelp.TabStop = False
        '
        'BtnHelpOpen
        '
        resources.ApplyResources(Me.BtnHelpOpen, "BtnHelpOpen")
        Me.BtnHelpOpen.FlatAppearance.BorderSize = 0
        Me.BtnHelpOpen.Name = "BtnHelpOpen"
        Me.BtnHelpOpen.UseVisualStyleBackColor = True
        '
        'GrpSettingsUpdate
        '
        resources.ApplyResources(Me.GrpSettingsUpdate, "GrpSettingsUpdate")
        Me.GrpSettingsUpdate.Controls.Add(Me.GrpUpdateSearch)
        Me.GrpSettingsUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSettingsUpdate.Name = "GrpSettingsUpdate"
        Me.GrpSettingsUpdate.TabStop = False
        '
        'GrpUpdateSearch
        '
        resources.ApplyResources(Me.GrpUpdateSearch, "GrpUpdateSearch")
        Me.GrpUpdateSearch.FlatAppearance.BorderSize = 0
        Me.GrpUpdateSearch.Name = "GrpUpdateSearch"
        Me.GrpUpdateSearch.UseVisualStyleBackColor = True
        '
        'GrpSettingsNotifications
        '
        resources.ApplyResources(Me.GrpSettingsNotifications, "GrpSettingsNotifications")
        Me.GrpSettingsNotifications.Controls.Add(Me.BtnNotificationsSwitch)
        Me.GrpSettingsNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSettingsNotifications.Name = "GrpSettingsNotifications"
        Me.GrpSettingsNotifications.TabStop = False
        '
        'BtnNotificationsSwitch
        '
        resources.ApplyResources(Me.BtnNotificationsSwitch, "BtnNotificationsSwitch")
        Me.BtnNotificationsSwitch.FlatAppearance.BorderSize = 0
        Me.BtnNotificationsSwitch.Name = "BtnNotificationsSwitch"
        Me.BtnNotificationsSwitch.UseVisualStyleBackColor = True
        '
        'GrpSettingsSplashscreen
        '
        resources.ApplyResources(Me.GrpSettingsSplashscreen, "GrpSettingsSplashscreen")
        Me.GrpSettingsSplashscreen.Controls.Add(Me.BtnSplashscreenSwitch)
        Me.GrpSettingsSplashscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSettingsSplashscreen.Name = "GrpSettingsSplashscreen"
        Me.GrpSettingsSplashscreen.TabStop = False
        '
        'BtnSplashscreenSwitch
        '
        resources.ApplyResources(Me.BtnSplashscreenSwitch, "BtnSplashscreenSwitch")
        Me.BtnSplashscreenSwitch.FlatAppearance.BorderSize = 0
        Me.BtnSplashscreenSwitch.Name = "BtnSplashscreenSwitch"
        Me.BtnSplashscreenSwitch.UseVisualStyleBackColor = True
        '
        'GrpSettingsLog
        '
        resources.ApplyResources(Me.GrpSettingsLog, "GrpSettingsLog")
        Me.GrpSettingsLog.Controls.Add(Me.BtnLogDelete)
        Me.GrpSettingsLog.Controls.Add(Me.BtnLogShow)
        Me.GrpSettingsLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSettingsLog.Name = "GrpSettingsLog"
        Me.GrpSettingsLog.TabStop = False
        '
        'BtnLogDelete
        '
        resources.ApplyResources(Me.BtnLogDelete, "BtnLogDelete")
        Me.BtnLogDelete.FlatAppearance.BorderSize = 0
        Me.BtnLogDelete.Name = "BtnLogDelete"
        Me.BtnLogDelete.UseVisualStyleBackColor = True
        '
        'BtnLogShow
        '
        resources.ApplyResources(Me.BtnLogShow, "BtnLogShow")
        Me.BtnLogShow.FlatAppearance.BorderSize = 0
        Me.BtnLogShow.Name = "BtnLogShow"
        Me.BtnLogShow.UseVisualStyleBackColor = True
        '
        'LblSettingsTitle
        '
        resources.ApplyResources(Me.LblSettingsTitle, "LblSettingsTitle")
        Me.LblSettingsTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblSettingsTitle.Name = "LblSettingsTitle"
        '
        'LblSettingsDescription
        '
        resources.ApplyResources(Me.LblSettingsDescription, "LblSettingsDescription")
        Me.LblSettingsDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblSettingsDescription.Name = "LblSettingsDescription"
        '
        'PnlMainBox
        '
        Me.PnlMainBox.Controls.Add(Me.BtnSortingGoHaltSwitch)
        Me.PnlMainBox.Controls.Add(Me.PnlBoxSettings)
        Me.PnlMainBox.Controls.Add(Me.PnlBoxFolder)
        Me.PnlMainBox.Controls.Add(Me.PnlBoxFormat)
        Me.PnlMainBox.Controls.Add(Me.PnlBoxSorting)
        Me.PnlMainBox.Controls.Add(Me.PnlBoxFiletype)
        resources.ApplyResources(Me.PnlMainBox, "PnlMainBox")
        Me.PnlMainBox.Name = "PnlMainBox"
        '
        'BtnSortingGoHaltSwitch
        '
        resources.ApplyResources(Me.BtnSortingGoHaltSwitch, "BtnSortingGoHaltSwitch")
        Me.BtnSortingGoHaltSwitch.FlatAppearance.BorderSize = 0
        Me.BtnSortingGoHaltSwitch.Name = "BtnSortingGoHaltSwitch"
        Me.BtnSortingGoHaltSwitch.UseVisualStyleBackColor = True
        '
        'PnlBoxSettings
        '
        resources.ApplyResources(Me.PnlBoxSettings, "PnlBoxSettings")
        Me.PnlBoxSettings.Controls.Add(Me.PnlSettingsSpacer)
        Me.PnlBoxSettings.Controls.Add(Me.GrpSettingsFeedback)
        Me.PnlBoxSettings.Controls.Add(Me.BtnSettingsBack)
        Me.PnlBoxSettings.Controls.Add(Me.GrpSettingsUpdate)
        Me.PnlBoxSettings.Controls.Add(Me.LblSettingsTitle)
        Me.PnlBoxSettings.Controls.Add(Me.GrpSettingsNotifications)
        Me.PnlBoxSettings.Controls.Add(Me.GrpSettingsAbout)
        Me.PnlBoxSettings.Controls.Add(Me.LblSettingsDescription)
        Me.PnlBoxSettings.Controls.Add(Me.BtnSettingsReset)
        Me.PnlBoxSettings.Controls.Add(Me.GrpSettingsLog)
        Me.PnlBoxSettings.Controls.Add(Me.GrpSettingsSplashscreen)
        Me.PnlBoxSettings.Controls.Add(Me.GrpSettingsHelp)
        Me.PnlBoxSettings.Name = "PnlBoxSettings"
        '
        'PnlSettingsSpacer
        '
        resources.ApplyResources(Me.PnlSettingsSpacer, "PnlSettingsSpacer")
        Me.PnlSettingsSpacer.Name = "PnlSettingsSpacer"
        '
        'BtnSettingsBack
        '
        Me.BtnSettingsBack.BackgroundImage = Global.BatchRename.My.Resources.Resources.Back
        resources.ApplyResources(Me.BtnSettingsBack, "BtnSettingsBack")
        Me.BtnSettingsBack.FlatAppearance.BorderSize = 0
        Me.BtnSettingsBack.Name = "BtnSettingsBack"
        Me.BtnSettingsBack.UseVisualStyleBackColor = True
        '
        'BtnSettingsReset
        '
        resources.ApplyResources(Me.BtnSettingsReset, "BtnSettingsReset")
        Me.BtnSettingsReset.FlatAppearance.BorderSize = 0
        Me.BtnSettingsReset.Name = "BtnSettingsReset"
        Me.BtnSettingsReset.UseVisualStyleBackColor = True
        '
        'PnlBoxFormat
        '
        Me.PnlBoxFormat.Controls.Add(Me.ChkFormatSwitch)
        Me.PnlBoxFormat.Controls.Add(Me.LblFormatExamples)
        Me.PnlBoxFormat.Controls.Add(Me.BtnFormatPrevious)
        Me.PnlBoxFormat.Controls.Add(Me.LblFormatExample2)
        Me.PnlBoxFormat.Controls.Add(Me.LblFormatExample1)
        Me.PnlBoxFormat.Controls.Add(Me.BtnFormatSettings)
        Me.PnlBoxFormat.Controls.Add(Me.TxbFormatPattern)
        Me.PnlBoxFormat.Controls.Add(Me.LblFormatTitle)
        Me.PnlBoxFormat.Controls.Add(Me.BtnFormatNext)
        Me.PnlBoxFormat.Controls.Add(Me.LblFormatDescription)
        resources.ApplyResources(Me.PnlBoxFormat, "PnlBoxFormat")
        Me.PnlBoxFormat.Name = "PnlBoxFormat"
        '
        'ChkFormatSwitch
        '
        resources.ApplyResources(Me.ChkFormatSwitch, "ChkFormatSwitch")
        Me.ChkFormatSwitch.Checked = True
        Me.ChkFormatSwitch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkFormatSwitch.Name = "ChkFormatSwitch"
        Me.ChkFormatSwitch.UseVisualStyleBackColor = True
        '
        'LblFormatExamples
        '
        resources.ApplyResources(Me.LblFormatExamples, "LblFormatExamples")
        Me.LblFormatExamples.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFormatExamples.Name = "LblFormatExamples"
        '
        'BtnFormatPrevious
        '
        resources.ApplyResources(Me.BtnFormatPrevious, "BtnFormatPrevious")
        Me.BtnFormatPrevious.BackgroundImage = Global.BatchRename.My.Resources.Resources.Up
        Me.BtnFormatPrevious.FlatAppearance.BorderSize = 0
        Me.BtnFormatPrevious.Name = "BtnFormatPrevious"
        Me.BtnFormatPrevious.UseVisualStyleBackColor = True
        '
        'LblFormatExample2
        '
        resources.ApplyResources(Me.LblFormatExample2, "LblFormatExample2")
        Me.LblFormatExample2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFormatExample2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFormatExample2.Name = "LblFormatExample2"
        '
        'LblFormatExample1
        '
        Me.LblFormatExample1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFormatExample1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.LblFormatExample1, "LblFormatExample1")
        Me.LblFormatExample1.Name = "LblFormatExample1"
        '
        'BtnFormatSettings
        '
        resources.ApplyResources(Me.BtnFormatSettings, "BtnFormatSettings")
        Me.BtnFormatSettings.BackgroundImage = Global.BatchRename.My.Resources.Resources.Settings
        Me.BtnFormatSettings.FlatAppearance.BorderSize = 0
        Me.BtnFormatSettings.Name = "BtnFormatSettings"
        Me.BtnFormatSettings.UseVisualStyleBackColor = True
        '
        'TxbFormatPattern
        '
        resources.ApplyResources(Me.TxbFormatPattern, "TxbFormatPattern")
        Me.TxbFormatPattern.Name = "TxbFormatPattern"
        '
        'LblFormatTitle
        '
        resources.ApplyResources(Me.LblFormatTitle, "LblFormatTitle")
        Me.LblFormatTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFormatTitle.Name = "LblFormatTitle"
        '
        'BtnFormatNext
        '
        resources.ApplyResources(Me.BtnFormatNext, "BtnFormatNext")
        Me.BtnFormatNext.BackgroundImage = Global.BatchRename.My.Resources.Resources.Down
        Me.BtnFormatNext.FlatAppearance.BorderSize = 0
        Me.BtnFormatNext.Name = "BtnFormatNext"
        Me.BtnFormatNext.UseVisualStyleBackColor = True
        '
        'LblFormatDescription
        '
        resources.ApplyResources(Me.LblFormatDescription, "LblFormatDescription")
        Me.LblFormatDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFormatDescription.Name = "LblFormatDescription"
        '
        'PnlBoxSorting
        '
        Me.PnlBoxSorting.Controls.Add(Me.GrpSortingFolders)
        Me.PnlBoxSorting.Controls.Add(Me.GrpSortingSource)
        Me.PnlBoxSorting.Controls.Add(Me.GrpSortingTarget)
        Me.PnlBoxSorting.Controls.Add(Me.BtnSortingPrevious)
        Me.PnlBoxSorting.Controls.Add(Me.ChkSortingSwitch)
        Me.PnlBoxSorting.Controls.Add(Me.BtnSortingSettings)
        Me.PnlBoxSorting.Controls.Add(Me.LblSortingTitle)
        Me.PnlBoxSorting.Controls.Add(Me.LblSortingDescription)
        resources.ApplyResources(Me.PnlBoxSorting, "PnlBoxSorting")
        Me.PnlBoxSorting.Name = "PnlBoxSorting"
        '
        'GrpSortingFolders
        '
        Me.GrpSortingFolders.Controls.Add(Me.LblFoldersMusic)
        Me.GrpSortingFolders.Controls.Add(Me.LblFoldersVideos)
        Me.GrpSortingFolders.Controls.Add(Me.LblFoldersDocuments)
        Me.GrpSortingFolders.Controls.Add(Me.LblFoldersImages)
        Me.GrpSortingFolders.Controls.Add(Me.BtnFoldersVideos)
        Me.GrpSortingFolders.Controls.Add(Me.BtnFoldersImages)
        Me.GrpSortingFolders.Controls.Add(Me.BtnFoldersMusic)
        Me.GrpSortingFolders.Controls.Add(Me.BtnFoldersDocuments)
        Me.GrpSortingFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.GrpSortingFolders, "GrpSortingFolders")
        Me.GrpSortingFolders.Name = "GrpSortingFolders"
        Me.GrpSortingFolders.TabStop = False
        '
        'LblFoldersMusic
        '
        resources.ApplyResources(Me.LblFoldersMusic, "LblFoldersMusic")
        Me.LblFoldersMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFoldersMusic.Name = "LblFoldersMusic"
        '
        'LblFoldersVideos
        '
        resources.ApplyResources(Me.LblFoldersVideos, "LblFoldersVideos")
        Me.LblFoldersVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFoldersVideos.Name = "LblFoldersVideos"
        '
        'LblFoldersDocuments
        '
        resources.ApplyResources(Me.LblFoldersDocuments, "LblFoldersDocuments")
        Me.LblFoldersDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFoldersDocuments.Name = "LblFoldersDocuments"
        '
        'LblFoldersImages
        '
        resources.ApplyResources(Me.LblFoldersImages, "LblFoldersImages")
        Me.LblFoldersImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFoldersImages.Name = "LblFoldersImages"
        '
        'BtnFoldersVideos
        '
        Me.BtnFoldersVideos.BackgroundImage = Global.BatchRename.My.Resources.Resources.Folder_Up
        resources.ApplyResources(Me.BtnFoldersVideos, "BtnFoldersVideos")
        Me.BtnFoldersVideos.FlatAppearance.BorderSize = 0
        Me.BtnFoldersVideos.Name = "BtnFoldersVideos"
        Me.BtnFoldersVideos.UseVisualStyleBackColor = True
        '
        'BtnFoldersImages
        '
        Me.BtnFoldersImages.BackgroundImage = Global.BatchRename.My.Resources.Resources.Folder_Up
        resources.ApplyResources(Me.BtnFoldersImages, "BtnFoldersImages")
        Me.BtnFoldersImages.FlatAppearance.BorderSize = 0
        Me.BtnFoldersImages.Name = "BtnFoldersImages"
        Me.BtnFoldersImages.UseVisualStyleBackColor = True
        '
        'BtnFoldersMusic
        '
        Me.BtnFoldersMusic.BackgroundImage = Global.BatchRename.My.Resources.Resources.Folder_Up
        resources.ApplyResources(Me.BtnFoldersMusic, "BtnFoldersMusic")
        Me.BtnFoldersMusic.FlatAppearance.BorderSize = 0
        Me.BtnFoldersMusic.Name = "BtnFoldersMusic"
        Me.BtnFoldersMusic.UseVisualStyleBackColor = True
        '
        'BtnFoldersDocuments
        '
        Me.BtnFoldersDocuments.BackgroundImage = Global.BatchRename.My.Resources.Resources.Folder_Up
        resources.ApplyResources(Me.BtnFoldersDocuments, "BtnFoldersDocuments")
        Me.BtnFoldersDocuments.FlatAppearance.BorderSize = 0
        Me.BtnFoldersDocuments.Name = "BtnFoldersDocuments"
        Me.BtnFoldersDocuments.UseVisualStyleBackColor = True
        '
        'GrpSortingSource
        '
        Me.GrpSortingSource.Controls.Add(Me.RbSourceCopy)
        Me.GrpSortingSource.Controls.Add(Me.RbSourceMove)
        Me.GrpSortingSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.GrpSortingSource, "GrpSortingSource")
        Me.GrpSortingSource.Name = "GrpSortingSource"
        Me.GrpSortingSource.TabStop = False
        '
        'RbSourceCopy
        '
        resources.ApplyResources(Me.RbSourceCopy, "RbSourceCopy")
        Me.RbSourceCopy.Name = "RbSourceCopy"
        Me.RbSourceCopy.UseVisualStyleBackColor = True
        '
        'RbSourceMove
        '
        resources.ApplyResources(Me.RbSourceMove, "RbSourceMove")
        Me.RbSourceMove.Checked = True
        Me.RbSourceMove.Name = "RbSourceMove"
        Me.RbSourceMove.TabStop = True
        Me.RbSourceMove.UseVisualStyleBackColor = True
        '
        'GrpSortingTarget
        '
        Me.GrpSortingTarget.Controls.Add(Me.RbTargetDuplicate)
        Me.GrpSortingTarget.Controls.Add(Me.RbTargetOverwrite)
        Me.GrpSortingTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.GrpSortingTarget, "GrpSortingTarget")
        Me.GrpSortingTarget.Name = "GrpSortingTarget"
        Me.GrpSortingTarget.TabStop = False
        '
        'RbTargetDuplicate
        '
        resources.ApplyResources(Me.RbTargetDuplicate, "RbTargetDuplicate")
        Me.RbTargetDuplicate.Name = "RbTargetDuplicate"
        Me.RbTargetDuplicate.UseVisualStyleBackColor = True
        '
        'RbTargetOverwrite
        '
        resources.ApplyResources(Me.RbTargetOverwrite, "RbTargetOverwrite")
        Me.RbTargetOverwrite.Checked = True
        Me.RbTargetOverwrite.Name = "RbTargetOverwrite"
        Me.RbTargetOverwrite.TabStop = True
        Me.RbTargetOverwrite.UseVisualStyleBackColor = True
        '
        'BtnSortingPrevious
        '
        resources.ApplyResources(Me.BtnSortingPrevious, "BtnSortingPrevious")
        Me.BtnSortingPrevious.BackgroundImage = Global.BatchRename.My.Resources.Resources.Up
        Me.BtnSortingPrevious.FlatAppearance.BorderSize = 0
        Me.BtnSortingPrevious.Name = "BtnSortingPrevious"
        Me.BtnSortingPrevious.UseVisualStyleBackColor = True
        '
        'ChkSortingSwitch
        '
        resources.ApplyResources(Me.ChkSortingSwitch, "ChkSortingSwitch")
        Me.ChkSortingSwitch.Checked = True
        Me.ChkSortingSwitch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSortingSwitch.Name = "ChkSortingSwitch"
        Me.ChkSortingSwitch.UseVisualStyleBackColor = True
        '
        'BtnSortingSettings
        '
        resources.ApplyResources(Me.BtnSortingSettings, "BtnSortingSettings")
        Me.BtnSortingSettings.BackgroundImage = Global.BatchRename.My.Resources.Resources.Settings
        Me.BtnSortingSettings.FlatAppearance.BorderSize = 0
        Me.BtnSortingSettings.Name = "BtnSortingSettings"
        Me.BtnSortingSettings.UseVisualStyleBackColor = True
        '
        'LblSortingTitle
        '
        resources.ApplyResources(Me.LblSortingTitle, "LblSortingTitle")
        Me.LblSortingTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblSortingTitle.Name = "LblSortingTitle"
        '
        'LblSortingDescription
        '
        resources.ApplyResources(Me.LblSortingDescription, "LblSortingDescription")
        Me.LblSortingDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblSortingDescription.Name = "LblSortingDescription"
        '
        'PnlBoxFiletype
        '
        Me.PnlBoxFiletype.Controls.Add(Me.BtnFiletypeSelect)
        Me.PnlBoxFiletype.Controls.Add(Me.ChkFiletypeEXIF)
        Me.PnlBoxFiletype.Controls.Add(Me.BtnFiletypePrevious)
        Me.PnlBoxFiletype.Controls.Add(Me.BtnFiletypeSettings)
        Me.PnlBoxFiletype.Controls.Add(Me.LblFiletypeTitle)
        Me.PnlBoxFiletype.Controls.Add(Me.BtnFiletypeNext)
        Me.PnlBoxFiletype.Controls.Add(Me.LblFiletypeDescription)
        resources.ApplyResources(Me.PnlBoxFiletype, "PnlBoxFiletype")
        Me.PnlBoxFiletype.Name = "PnlBoxFiletype"
        '
        'BtnFiletypeSelect
        '
        resources.ApplyResources(Me.BtnFiletypeSelect, "BtnFiletypeSelect")
        Me.BtnFiletypeSelect.FlatAppearance.BorderSize = 0
        Me.BtnFiletypeSelect.Name = "BtnFiletypeSelect"
        Me.BtnFiletypeSelect.UseVisualStyleBackColor = True
        '
        'ChkFiletypeEXIF
        '
        resources.ApplyResources(Me.ChkFiletypeEXIF, "ChkFiletypeEXIF")
        Me.ChkFiletypeEXIF.Checked = True
        Me.ChkFiletypeEXIF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkFiletypeEXIF.Name = "ChkFiletypeEXIF"
        Me.ChkFiletypeEXIF.UseVisualStyleBackColor = True
        '
        'BtnFiletypePrevious
        '
        resources.ApplyResources(Me.BtnFiletypePrevious, "BtnFiletypePrevious")
        Me.BtnFiletypePrevious.BackgroundImage = Global.BatchRename.My.Resources.Resources.Up
        Me.BtnFiletypePrevious.FlatAppearance.BorderSize = 0
        Me.BtnFiletypePrevious.Name = "BtnFiletypePrevious"
        Me.BtnFiletypePrevious.UseVisualStyleBackColor = True
        '
        'BtnFiletypeSettings
        '
        resources.ApplyResources(Me.BtnFiletypeSettings, "BtnFiletypeSettings")
        Me.BtnFiletypeSettings.BackgroundImage = Global.BatchRename.My.Resources.Resources.Settings
        Me.BtnFiletypeSettings.FlatAppearance.BorderSize = 0
        Me.BtnFiletypeSettings.Name = "BtnFiletypeSettings"
        Me.BtnFiletypeSettings.UseVisualStyleBackColor = True
        '
        'LblFiletypeTitle
        '
        resources.ApplyResources(Me.LblFiletypeTitle, "LblFiletypeTitle")
        Me.LblFiletypeTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFiletypeTitle.Name = "LblFiletypeTitle"
        '
        'BtnFiletypeNext
        '
        resources.ApplyResources(Me.BtnFiletypeNext, "BtnFiletypeNext")
        Me.BtnFiletypeNext.BackgroundImage = Global.BatchRename.My.Resources.Resources.Down
        Me.BtnFiletypeNext.FlatAppearance.BorderSize = 0
        Me.BtnFiletypeNext.Name = "BtnFiletypeNext"
        Me.BtnFiletypeNext.UseVisualStyleBackColor = True
        '
        'LblFiletypeDescription
        '
        resources.ApplyResources(Me.LblFiletypeDescription, "LblFiletypeDescription")
        Me.LblFiletypeDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblFiletypeDescription.Name = "LblFiletypeDescription"
        '
        'PgbMain
        '
        resources.ApplyResources(Me.PgbMain, "PgbMain")
        Me.PgbMain.Name = "PgbMain"
        '
        'LblMainTask
        '
        resources.ApplyResources(Me.LblMainTask, "LblMainTask")
        Me.LblMainTask.BackColor = System.Drawing.Color.Transparent
        Me.LblMainTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblMainTask.Name = "LblMainTask"
        '
        'PnlProgress
        '
        Me.PnlProgress.Controls.Add(Me.LblMainTask)
        Me.PnlProgress.Controls.Add(Me.PgbMain)
        resources.ApplyResources(Me.PnlProgress, "PnlProgress")
        Me.PnlProgress.Name = "PnlProgress"
        '
        'FrmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlProgress)
        Me.Controls.Add(Me.PnlMainBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.PnlBoxFolder.ResumeLayout(False)
        Me.PnlBoxFolder.PerformLayout()
        Me.GrpSettingsFeedback.ResumeLayout(False)
        Me.GrpSettingsAbout.ResumeLayout(False)
        Me.GrpSettingsHelp.ResumeLayout(False)
        Me.GrpSettingsUpdate.ResumeLayout(False)
        Me.GrpSettingsNotifications.ResumeLayout(False)
        Me.GrpSettingsSplashscreen.ResumeLayout(False)
        Me.GrpSettingsLog.ResumeLayout(False)
        Me.PnlMainBox.ResumeLayout(False)
        Me.PnlBoxSettings.ResumeLayout(False)
        Me.PnlBoxSettings.PerformLayout()
        Me.PnlBoxFormat.ResumeLayout(False)
        Me.PnlBoxFormat.PerformLayout()
        Me.PnlBoxSorting.ResumeLayout(False)
        Me.PnlBoxSorting.PerformLayout()
        Me.GrpSortingFolders.ResumeLayout(False)
        Me.GrpSortingFolders.PerformLayout()
        Me.GrpSortingSource.ResumeLayout(False)
        Me.GrpSortingSource.PerformLayout()
        Me.GrpSortingTarget.ResumeLayout(False)
        Me.GrpSortingTarget.PerformLayout()
        Me.PnlBoxFiletype.ResumeLayout(False)
        Me.PnlBoxFiletype.PerformLayout()
        Me.PnlProgress.ResumeLayout(False)
        Me.PnlProgress.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblFolderTitle As Label
    Friend WithEvents LblMainDescription As Label
    Friend WithEvents BtnFolderSource As Button
    Friend WithEvents BtnFolderNext As Button
    Friend WithEvents TxbFolderSource As TextBox
    Friend WithEvents BtnFolderSettings As Button
    Friend WithEvents PnlBoxFolder As Panel
    Friend WithEvents LblSettingsTitle As Label
    Friend WithEvents LblSettingsDescription As Label
    Friend WithEvents PnlMainBox As Panel
    Friend WithEvents ChkFolderSubfolder As CheckBox
    Friend WithEvents PnlBoxFormat As Panel
    Friend WithEvents BtnFormatSettings As Button
    Friend WithEvents TxbFormatPattern As TextBox
    Friend WithEvents LblFormatTitle As Label
    Friend WithEvents BtnFormatNext As Button
    Friend WithEvents LblFormatDescription As Label
    Friend WithEvents LblFormatExample2 As Label
    Friend WithEvents LblFormatExample1 As Label
    Friend WithEvents BtnFormatPrevious As Button
    Friend WithEvents PnlBoxSorting As Panel
    Friend WithEvents BtnSortingPrevious As Button
    Friend WithEvents BtnSortingSettings As Button
    Friend WithEvents LblSortingTitle As Label
    Friend WithEvents BtnSortingGoHaltSwitch As Button
    Friend WithEvents LblSortingDescription As Label
    Friend WithEvents PnlBoxFiletype As Panel
    Friend WithEvents BtnFiletypePrevious As Button
    Friend WithEvents BtnFiletypeSettings As Button
    Friend WithEvents LblFiletypeTitle As Label
    Friend WithEvents BtnFiletypeNext As Button
    Friend WithEvents LblFiletypeDescription As Label
    Friend WithEvents GrpSettingsNotifications As GroupBox
    Friend WithEvents BtnNotificationsSwitch As Button
    Friend WithEvents GrpSettingsSplashscreen As GroupBox
    Friend WithEvents BtnSplashscreenSwitch As Button
    Friend WithEvents BtnSettingsReset As Button
    Friend WithEvents GrpSettingsLog As GroupBox
    Friend WithEvents BtnLogDelete As Button
    Friend WithEvents BtnLogShow As Button
    Friend WithEvents GrpSettingsAbout As GroupBox
    Friend WithEvents BtnAboutOpen As Button
    Friend WithEvents GrpSettingsHelp As GroupBox
    Friend WithEvents BtnHelpOpen As Button
    Friend WithEvents GrpSettingsUpdate As GroupBox
    Friend WithEvents GrpUpdateSearch As Button
    Friend WithEvents GrpSettingsFeedback As GroupBox
    Friend WithEvents BtnFeedbackReset As Button
    Friend WithEvents PnlBoxSettings As Panel
    Friend WithEvents BtnSettingsBack As Button
    Friend WithEvents LblFormatExamples As Label
    Friend WithEvents ChkFiletypeEXIF As CheckBox
    Friend WithEvents ChkSortingSwitch As CheckBox
    Friend WithEvents PgbMain As ProgressBar
    Friend WithEvents LblMainTask As Label
    Friend WithEvents PnlProgress As Panel
    Friend WithEvents PnlSettingsSpacer As Panel
    Friend WithEvents GrpSortingSource As GroupBox
    Friend WithEvents RbSourceCopy As RadioButton
    Friend WithEvents RbSourceMove As RadioButton
    Friend WithEvents GrpSortingTarget As GroupBox
    Friend WithEvents RbTargetDuplicate As RadioButton
    Friend WithEvents RbTargetOverwrite As RadioButton
    Friend WithEvents BtnFoldersVideos As Button
    Friend WithEvents BtnFoldersMusic As Button
    Friend WithEvents BtnFoldersImages As Button
    Friend WithEvents BtnFoldersDocuments As Button
    Friend WithEvents GrpSortingFolders As GroupBox
    Friend WithEvents LblFoldersMusic As Label
    Friend WithEvents LblFoldersVideos As Label
    Friend WithEvents LblFoldersDocuments As Label
    Friend WithEvents LblFoldersImages As Label
    Friend WithEvents ChkFormatSwitch As CheckBox
    Friend WithEvents BtnFiletypeSelect As Button
End Class
