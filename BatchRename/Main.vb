Imports System.Environment
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports ExifLibrary
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.WindowsAPICodePack.Taskbar

<Assembly: CLSCompliant(True)>

Public Class FrmMain

    ' Application dependent variables
    Private appName As String = Application.ProductName
    Private appFolder As String = GetFolderPath(SpecialFolder.ApplicationData)
    Private currentVersion As String = Application.ProductVersion
    Private downloadPath As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & appName & "\Update\"

    ' Make "switch" buttons' images exchangable
    Private yesImg As Image = My.Resources.Yes_Up
    Private noImg As Image = My.Resources.No_Up
    Private goImg As Image = My.Resources.Go
    Private haltImg As Image = My.Resources.Halt

    ' All known file extensions
    Private imageExtensions() As String = {".3fr", ".arw", ".asf", ".bcm", ".bmi", ".bmp", ".bms", ".cr2", ".crw", ".cs1", ".dcm", ".dib", ".dng", ".erf", ".fff", ".gif", ".hdp", ".hdr", ".ico", ".j2k", ".jp2", ".jpc", ".jpe", ".jpeg", ".jpg", ".jps", ".jxr", ".kdc", ".mdm", ".mef", ".mpo", ".mrw", ".nef", ".nrw", ".orf", ".pam", ".pbm", ".pcd", ".pcx", ".pef", ".pgm", ".png", ".pnm", ".pns", ".ppm", ".psb", ".psd", ".psp", ".pspimage", ".raf", ".raw", ".ref", ".rle", ".rw2", ".rwl", ".rwz", ".sr2", ".srf", ".srw", ".tga", ".thm", ".tif", ".tiff", ".wbm", ".wbmp", ".wdp", ".wpg", ".x3f"}
    Private documentExtensions() As String = {".doc", ".docx", ".log", ".rtf", ".pdf", ".txt"}
    Private musicExtensions() As String = {".aif", ".aiff", ".au", ".m4a", ".mid", ".midi", ".mp3", ".wav"}
    Private videoExtensions() As String = {".avi", ".flc", ".fli", ".m1v", ".mov", ".mp4", ".mpe", ".mpeg", ".mpg", ".mts", ".ogv", ".qt", ".wmv"}
    Private exceptionExtensions() As String = {".dll", ".dropbox", ".exe", ".ink", ".ini", ".sys", ".was"}

    ' File quantity variables
    Private sourceFileList As New ArrayList
    Private targetFileList As New ArrayList
    Private enabledExtensions As New ArrayList

    ' "Statistic" variables
    Private sizeOfAllFiles As Long
    Private iterationCount As Integer

    Private abort As Boolean = False

    Public ReadOnly Property PAppName() As String

        ' Make private "appName" variable gettable
        Get
            Return appName
        End Get
    End Property

    Public ReadOnly Property PAppFolder() As String

        ' Make private "appFolder" variable gettable
        Get
            Return appFolder
        End Get
    End Property

    Public ReadOnly Property PCurrentVersion() As String

        ' Make private "currentVersion" variable gettable
        Get
            Return currentVersion
        End Get
    End Property

    Public ReadOnly Property PDownloadPath() As String

        ' Make private "downloadPath" variable gettable
        Get
            Return downloadPath
        End Get
    End Property

    Public ReadOnly Property PYesImg() As Image

        ' Make private "yesImg" variable gettable
        Get
            Return yesImg
        End Get
    End Property

    Public ReadOnly Property PNoImg() As Image

        ' Make private "noImg" variable gettable
        Get
            Return noImg
        End Get
    End Property

    Public ReadOnly Property PGoImg() As Image

        ' Make private "goImg" variable gettable
        Get
            Return goImg
        End Get
    End Property

    Public ReadOnly Property PHaltImg() As Image

        ' Make private "haltImg" variable gettable
        Get
            Return haltImg
        End Get
    End Property

    Public Function GetImageExtensions() As String()

        ' Make private "imageExtensions" variable gettable
        Return DirectCast(imageExtensions.Clone(), String())
    End Function

    Public Function GetDocumentExtensions() As String()

        ' Make private "documentExtensions" variable gettable
        Return DirectCast(documentExtensions.Clone(), String())
    End Function

    Public Function GetMusicExtensions() As String()

        ' Make private "musicExtensions" variable gettable
        Return DirectCast(musicExtensions.Clone(), String())
    End Function

    Public Function GetVideoExtensions() As String()

        ' Make private "videoExtensions" variable gettable
        Return DirectCast(videoExtensions.Clone(), String())
    End Function

    Public Function GetExceptionExtensions() As String()

        ' Make private "exceptionExtensions" variable gettable
        Return DirectCast(exceptionExtensions.Clone(), String())
    End Function

    Public ReadOnly Property PSourceFileList() As ArrayList

        ' Make private "sourceFileList" variable gettable
        Get
            Return sourceFileList
        End Get
    End Property

    Public ReadOnly Property PTargetFileList() As ArrayList

        ' Make private "targetFileList" variable gettable
        Get
            Return targetFileList
        End Get
    End Property

    Public ReadOnly Property PEnabledExtensions() As ArrayList

        ' Make private "enabledExtensions" variable gettable and settable
        Get
            Return enabledExtensions
        End Get
    End Property

    Public Property PSizeOfAllFiles() As Long

        ' Make private "sizeOfAllFiles" variable gettable and settable
        Get
            Return sizeOfAllFiles
        End Get
        Set
            sizeOfAllFiles = Value
        End Set
    End Property

    Public ReadOnly Property PIterationCount() As Integer

        ' Make private "iterationCount" variable gettable
        Get
            Return iterationCount
        End Get
    End Property

    Public Property PAbort() As Boolean

        ' Make private "cancel" variable gettable and settable
        Get
            Return abort
        End Get
        Set
            abort = Value
        End Set
    End Property

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.GroupBox.set_Text(System.String)")>
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Load "splashscreen" settings
        If My.Settings.ShowSplashscreen Then
            BtnSplashscreenSwitch.BackgroundImage = YesImg
        Else
            BtnSplashscreenSwitch.BackgroundImage = NoImg
            BtnSplashscreenSwitch.Text = Replace(BtnSplashscreenSwitch.Text, "Disable", "Enable")
        End If

        ' Load "feedback" settings
        If My.Settings.Feedback Is Nothing Then
            My.Settings.Feedback = New ArrayList
        End If

        ' Load "notification" settings
        If My.Settings.ShowNotifications Then
            BtnNotificationsSwitch.BackgroundImage = YesImg
        Else
            BtnNotificationsSwitch.BackgroundImage = NoImg
            BtnNotificationsSwitch.Text = Replace(BtnNotificationsSwitch.Text, "Disable", "Enable")
        End If

        ' Load "subfolder" settings
        If My.Settings.IncludeSubfolders Then
            ChkFolderSubfolder.Checked = True
        Else
            ChkFolderSubfolder.Checked = False
        End If

        ' Load "format" settings
        TxbFormatPattern.Text = My.Settings.Format

        ' Load "EXIF" settings
        If My.Settings.UseEXIF Then
            ChkFiletypeEXIF.Checked = True
        Else
            ChkFiletypeEXIF.Checked = False
        End If

        ' Initialize "extensions" settings
        If My.Settings.EnabledExtensions Is Nothing Then
            My.Settings.EnabledExtensions = New ArrayList

            For Each extension As String In imageExtensions
                My.Settings.EnabledExtensions.Add(extension.ToString)
            Next

            For Each extension As String In documentExtensions
                My.Settings.EnabledExtensions.Add(extension.ToString)
            Next

            For Each extension As String In musicExtensions
                My.Settings.EnabledExtensions.Add(extension.ToString)
            Next

            For Each extension As String In videoExtensions
                My.Settings.EnabledExtensions.Add(extension.ToString)
            Next

            For Each extension As String In exceptionExtensions
                My.Settings.EnabledExtensions.Add(extension.ToString)
            Next
        End If

        enabledExtensions = My.Settings.EnabledExtensions

        ' Load "sorting" settings
        If Not My.Settings.EnableSorting Then
            ChkSortingSwitch.Checked = False
            GrpSortingFolders.Enabled = False
            GrpSortingSource.Enabled = False
            GrpSortingTarget.Enabled = False
        End If

        ' Load "renaming" settings
        If Not My.Settings.EnableRenaming Then
            ChkFormatSwitch.Checked = False
            TxbFormatPattern.Enabled = False
            LblFormatExamples.Enabled = False
            LblFormatExample1.Enabled = False
            LblFormatExample2.Enabled = False
        End If

        ' Initialize "folder" settings
        If My.Settings.SelectedFolders Is Nothing Then
            My.Settings.SelectedFolders = New Specialized.StringCollection

            My.Settings.SelectedFolders.Add(GetFolderPath(SpecialFolder.Desktop))
            My.Settings.SelectedFolders.Add(GetFolderPath(SpecialFolder.MyPictures))
            My.Settings.SelectedFolders.Add(GetFolderPath(SpecialFolder.MyDocuments))
            My.Settings.SelectedFolders.Add(GetFolderPath(SpecialFolder.MyMusic))
            My.Settings.SelectedFolders.Add(GetFolderPath(SpecialFolder.MyVideos))
        End If

        TxbFolderSource.Text = My.Settings.SelectedFolders(0)
        LblFoldersImages.Text = CompactString(My.Settings.SelectedFolders(1), GrpSortingFolders.Width - 250, LblFoldersImages.Font, TextFormatFlags.PathEllipsis)
        LblFoldersDocuments.Text = CompactString(My.Settings.SelectedFolders(2), GrpSortingFolders.Width - 250, LblFoldersDocuments.Font, TextFormatFlags.PathEllipsis)
        LblFoldersMusic.Text = CompactString(My.Settings.SelectedFolders(3), GrpSortingFolders.Width - 250, LblFoldersMusic.Font, TextFormatFlags.PathEllipsis)
        LblFoldersVideos.Text = CompactString(My.Settings.SelectedFolders(4), GrpSortingFolders.Width - 250, LblFoldersVideos.Font, TextFormatFlags.PathEllipsis)

        ' Load "duplicate" settings
        If My.Settings.CreateCopy Then
            RbSourceCopy.Checked = True
        Else
            RbSourceCopy.Checked = False
        End If

        ' Load "copy" settings
        If My.Settings.CreateDuplicate Then
            RbTargetDuplicate.Checked = True
        Else
            RbTargetDuplicate.Checked = False
        End If

        ' Initialize "extensions" settings
        If My.Settings.ImageExtensions Is Nothing And My.Settings.DocumentExtensions Is Nothing And My.Settings.MusicExtensions Is Nothing And My.Settings.VideoExtensions Is Nothing And My.Settings.ExceptionExtensions Is Nothing Then
            My.Settings.ImageExtensions = New Specialized.StringCollection()
            My.Settings.DocumentExtensions = New Specialized.StringCollection()
            My.Settings.MusicExtensions = New Specialized.StringCollection()
            My.Settings.VideoExtensions = New Specialized.StringCollection()
            My.Settings.ExceptionExtensions = New Specialized.StringCollection()

            My.Settings.ImageExtensions.AddRange(imageExtensions)
            My.Settings.DocumentExtensions.AddRange(documentExtensions)
            My.Settings.MusicExtensions.AddRange(musicExtensions)
            My.Settings.VideoExtensions.AddRange(videoExtensions)
            My.Settings.ExceptionExtensions.AddRange(exceptionExtensions)
        End If

        ' Initialize the start button's backgroundimage
        BtnSortingGoHaltSwitch.BackgroundImage = goImg

        ' Clean temporary folder
        If Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & AppName & "") Then
            My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & AppName & "", DeleteDirectoryOption.DeleteAllContents)
        End If

        ' Initialize "log" settings
        If File.Exists(appFolder & "\" & appName & "\log\log.html") Then
            GrpSettingsLog.Text = "Log (" & Math.Round(FileLen(appFolder & "\" & appName & "\log\log.html") / 1024) & " kb)"
            GrpSettingsLog.Enabled = True
        End If
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        ' Ensure no settings get lost
        My.Settings.Save()
    End Sub

    ' Set up navigation buttons
    Private Sub BtnFolderSettings_Click(sender As Object, e As EventArgs) Handles BtnFolderSettings.Click

        ' Move the UI horizontally to the right
        OpenSettings()
    End Sub

    Private Sub BtnFormatSettings_Click(sender As Object, e As EventArgs) Handles BtnFormatSettings.Click

        ' Move the UI horizontally to the right
        OpenSettings()
    End Sub

    Private Sub BtnFiletypeSettings_Click(sender As Object, e As EventArgs) Handles BtnFiletypeSettings.Click

        ' Move the UI horizontally to the right
        OpenSettings()
    End Sub

    Private Sub BtnSortingSettings_Click(sender As Object, e As EventArgs) Handles BtnSortingSettings.Click

        ' Move the UI horizontally to the right
        OpenSettings()
    End Sub

    Private Sub BtnSettingsBack_Click(sender As Object, e As EventArgs) Handles BtnSettingsBack.Click
        Dim customTimer As New CustomTimer(1, -400, 400, "x")

        ' Move the UI horizontally to the left
        customTimer.StartTimer()
    End Sub

    Private Sub BtnFolderNext_Click(sender As Object, e As EventArgs) Handles BtnFolderNext.Click
        Dim customTimer As New CustomTimer(1, 0, -475, "y")

        ' Move the UI vertically down
        customTimer.StartTimer()
    End Sub

    Private Sub BtnFormatNext_Click(sender As Object, e As EventArgs) Handles BtnFormatNext.Click
        Dim customTimer As New CustomTimer(1, -475, -475, "y")

        ' Move the UI vertically down
        customTimer.StartTimer()
    End Sub

    Private Sub BtnFiletypeNext_Click(sender As Object, e As EventArgs) Handles BtnFiletypeNext.Click
        Dim customTimer As New CustomTimer(1, -950, -475, "y")

        ' Move the UI vertically down
        customTimer.StartTimer()
    End Sub

    Private Sub BtnFormatPrevious_Click(sender As Object, e As EventArgs) Handles BtnFormatPrevious.Click
        Dim customTimer As New CustomTimer(1, -475, 475, "y")

        ' Move the UI vertically up
        customTimer.StartTimer()
    End Sub

    Private Sub BtnFiletypePrevious_Click(sender As Object, e As EventArgs) Handles BtnFiletypePrevious.Click
        Dim customTimer As New CustomTimer(1, -950, 475, "y")

        ' Move the UI vertically up
        customTimer.StartTimer()
    End Sub

    Private Sub BtnSortingPrevious_Click(sender As Object, e As EventArgs) Handles BtnSortingPrevious.Click
        Dim customTimer As New CustomTimer(1, -1425, 475, "y")

        ' Move the UI vertically up
        customTimer.StartTimer()
    End Sub

    Private Sub BtnFolderSource_Click(sender As Object, e As EventArgs) Handles BtnFolderSource.Click

        ' Open a "folder browser" dialog
        OpenFbd(0, My.Settings.SelectedFolders(0), TxbFolderSource)
    End Sub

    Private Sub TxbFolderSource_TextChanged(sender As Object, e As EventArgs) Handles TxbFolderSource.TextChanged

        ' Save av valid directory as source
        If FileSystem.DirectoryExists(TxbFolderSource.Text) Then
            My.Settings.SelectedFolders(0) = TxbFolderSource.Text
        End If
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.Label.set_Text(System.String)")>
    Private Sub TxbFormatPattern_TextChanged(sender As Object, e As EventArgs) Handles TxbFormatPattern.TextChanged
        My.Settings.Format = TxbFormatPattern.Text

        ' Generate an example string
        If TxbFormatPattern.Text Is Nothing Then
            LblFormatExample1.Text = "Fill The Textbox Above"
            LblFormatExample2.Text = "Fill The Textbox Above"
        Else
            Try

                ' Format two example dates
                Dim testDateTimeOne As Date = #6/27/2014 5:26:03 PM#
                Dim testStrOne As String = Format(testDateTimeOne, TxbFormatPattern.Text)
                Dim testDateTimeTwo As Date = #12/3/1980 8:30:12 AM#
                Dim testStrTwo As String = Format(testDateTimeTwo, TxbFormatPattern.Text)

                ' Consider the special tag and append a fileextension for both
                If TestStrOne.Contains("P") Then
                    TestStrOne = TestStrOne.Replace("P", "IMG")
                End If

                LblFormatExample1.Text = TestStrOne & ".jpg"

                If TestStrTwo.Contains("P") Then
                    TestStrTwo = TestStrTwo.Replace("P", "VID")
                End If

                LblFormatExample2.Text = TestStrTwo & ".mp4"
            Catch fe As FormatException

                ' Warn that the input is malformed
                LblFormatExample1.Text = "Format Exception"
                LblFormatExample2.Text = "Format Exception"
            End Try
        End If

        TxbFormatPattern.DeselectAll()
    End Sub

    Private Sub ChkFolderSubfolder_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFolderSubfolder.CheckedChanged

        ' Switch the "subfolder" setting on or off
        If ChkFolderSubfolder.Checked Then
            My.Settings.IncludeSubfolders = True
        Else
            My.Settings.IncludeSubfolders = False
        End If
    End Sub

    Private Sub ChkFormatSwitch_MouseUp(sender As Object, e As EventArgs) Handles ChkFormatSwitch.MouseUp

        ' Switch "renaming" setting on or off and enable or disable UI elements
        If ChkFormatSwitch.Checked Then
            My.Settings.EnableRenaming = True
            TxbFormatPattern.Enabled = True
            LblFormatExamples.Enabled = True
            LblFormatExample1.Enabled = True
            LblFormatExample2.Enabled = True
        Else
            My.Settings.EnableRenaming = False
            TxbFormatPattern.Enabled = False
            LblFormatExamples.Enabled = False
            LblFormatExample1.Enabled = False
            LblFormatExample2.Enabled = False
        End If
    End Sub

    Private Sub BtnFiletypeSelect_Click(sender As Object, e As EventArgs) Handles BtnFiletypeSelect.Click

        ' Open the "filetype" dialog
        FrmFiletype.ShowDialog()
    End Sub

    Private Sub ChkFiletypeEXIF_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFiletypeEXIF.CheckedChanged

        ' Switch "EXIF" setting on or off
        If ChkFiletypeEXIF.Checked Then
            My.Settings.UseEXIF = True
        Else
            My.Settings.UseEXIF = False
        End If
    End Sub

    Private Sub ChkSortingSwitch_MouseUp(sender As Object, e As MouseEventArgs) Handles ChkSortingSwitch.MouseUp

        ' Switch "sorting" setting on or off and enable or disable UI elements
        If ChkSortingSwitch.Checked Then
            My.Settings.EnableSorting = True
            GrpSortingFolders.Enabled = True
            GrpSortingSource.Enabled = True
            GrpSortingTarget.Enabled = True
        Else
            My.Settings.EnableSorting = False
            GrpSortingFolders.Enabled = False
            GrpSortingSource.Enabled = False
            GrpSortingTarget.Enabled = False
        End If
    End Sub

    Private Sub BtnFoldersImages_Click(sender As Object, e As EventArgs) Handles BtnFoldersImages.Click

        ' Open a "folder browser" dialog
        OpenFbd(1, My.Settings.SelectedFolders(1), LblFoldersImages) 'GetFolderPath(SpecialFolder.MyPictures)
    End Sub

    Private Sub LblFoldersImages_Click(sender As Object, e As EventArgs) Handles LblFoldersImages.Click

        ' Redirect to button's click event
        Call BtnFoldersImages_Click(sender, e)
    End Sub

    Private Sub BtnFoldersDocuments_Click(sender As Object, e As EventArgs) Handles BtnFoldersDocuments.Click

        ' Open a "folder browser" dialog
        OpenFbd(2, My.Settings.SelectedFolders(2), LblFoldersDocuments)
    End Sub

    Private Sub LblFoldersDocuments_Click(sender As Object, e As EventArgs) Handles LblFoldersDocuments.Click

        ' Redirect to button's click event
        Call BtnFoldersDocuments_Click(sender, e)
    End Sub

    Private Sub BtnFoldersMusic_Click(sender As Object, e As EventArgs) Handles BtnFoldersMusic.Click

        ' Open a "folder browser" dialog
        OpenFbd(3, My.Settings.SelectedFolders(3), LblFoldersMusic)
    End Sub

    Private Sub LblFoldersMusic_Click(sender As Object, e As EventArgs) Handles LblFoldersMusic.Click

        ' Redirect to button's click event
        Call BtnFoldersMusic_Click(sender, e)
    End Sub

    Private Sub BtnFoldersVideos_Click(sender As Object, e As EventArgs) Handles BtnFoldersVideos.Click

        ' Open a "folder browser" dialog
        OpenFbd(4, My.Settings.SelectedFolders(4), LblFoldersVideos)
    End Sub

    Private Sub LblFoldersVideos_Click(sender As Object, e As EventArgs) Handles LblFoldersVideos.Click

        ' Redirect to button's click event
        Call BtnFoldersVideos_Click(sender, e)
    End Sub

    Private Sub RbSourceCopy_CheckedChanged(sender As Object, e As EventArgs) Handles RbSourceCopy.CheckedChanged

        ' Switch "copy" setting on or off
        If RbSourceCopy.Checked Then
            My.Settings.CreateCopy = True
        Else
            My.Settings.CreateCopy = False
        End If
    End Sub

    Private Sub RbTargetDuplicate_CheckedChanged(sender As Object, e As EventArgs) Handles RbTargetDuplicate.CheckedChanged

        ' Switch "duplicate" setting on or off
        If RbTargetDuplicate.Checked Then
            My.Settings.CreateDuplicate = True
        Else
            My.Settings.CreateDuplicate = False
        End If
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.Label.set_Text(System.String)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    Private Sub BtnSortingGoHaltSwitch_Click(sender As Object, e As EventArgs) Handles BtnSortingGoHaltSwitch.Click

        ' If the user intended to start the iteration
        If BtnSortingGoHaltSwitch.BackgroundImage Is goImg Then
            Dim dialogResult As DialogResult = DialogResult.Yes

            ' Check if all directories exist
            If Not Directory.Exists(My.Settings.SelectedFolders(0)) Then
                dialogResult = MessageBox.Show("The folder '" & My.Settings.SelectedFolders(0) & "' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not Directory.Exists(My.Settings.SelectedFolders(1)) Then
                dialogResult = MessageBox.Show("The folder '" & My.Settings.SelectedFolders(1) & "' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not Directory.Exists(My.Settings.SelectedFolders(2)) Then
                dialogResult = MessageBox.Show("The folder '" & My.Settings.SelectedFolders(2) & "' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not Directory.Exists(My.Settings.SelectedFolders(3)) Then
                dialogResult = MessageBox.Show("The folder '" & My.Settings.SelectedFolders(3) & "' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not Directory.Exists(My.Settings.SelectedFolders(4)) Then
                dialogResult = MessageBox.Show("The folder '" & My.Settings.SelectedFolders(4) & "' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Check if there is neither renaming nor sorting activated and warn if so
            If Not ChkFormatSwitch.Checked And Not ChkSortingSwitch.Checked Then
                dialogResult = MessageBox.Show("Neither renaming nor sorting is enabled!" & vbCrLf & vbCrLf & "No actions will be executed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Show a disclaimer depending on the settings
            If dialogResult = DialogResult.Yes And My.Settings.ShowNotifications Then
                dialogResult = MessageBox.Show("Do you really want to proceed?" & vbCrLf & vbCrLf & "You are responsible for any resulting damage to files and folders.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            End If

            If dialogResult = DialogResult.Yes Then

                ' Switch backgroundimage
                ChangeOnOff(sender, "")

                ' Merge all extensionarrays to a list
                Dim includedExtensions As New ArrayList

                includedExtensions.AddRange(imageExtensions)
                includedExtensions.AddRange(documentExtensions)
                includedExtensions.AddRange(musicExtensions)
                includedExtensions.AddRange(videoExtensions)

                ' Prevent gui input except stop button
                PnlBoxSorting.Enabled = False

                ' Update the filelist
                sourceFileList = GetFileList(includedExtensions)

                ' Iterate through all files
                Iterate()

                ' Permit gui input
                PnlBoxSorting.Enabled = True

                ' Build the log file
                CreateLog()

                ' Reset UI
                PgbMain.Value = 0
                TaskbarManager.Instance.SetProgressValue(0, 100)
                LblMainTask.Text = "Done!"

                ' Switch backgroundimage
                ChangeOnOff(sender, "")
            End If
        Else

            ' Switch backgroundimage
            ChangeOnOff(sender, "")
        End If
    End Sub

    Private Sub Iterate()

        ' Reset "iterate" variables to default
        Dim processedFilesize As Long = 0

        iterationCount = 0
        abort = False
        targetFileList.Clear()

        ' Iterate through all source files
        For Each element As FileInfo In sourceFileList

            ' Exclude unwanted and unknown files
            If Not exceptionExtensions.Contains(LCase(element.Extension)) Or Not My.Settings.Feedback.Contains(LCase(element.Extension)) Then

                ' Calculate the remaining time
                Dim remainingSeconds As Double = GetRemainingSeconds(sourceFileList.Count, iterationCount)

                ' Update the UI with current task
                LblMainTask.Text = CompactString("Processing... | " & PgbMain.Value & "% | ~" & remainingSeconds & "s left" & " | " & element.FullName, PgbMain.Width - 10, LblMainTask.Font, TextFormatFlags.PathEllipsis)

                ' Check if the user requested a stop
                If abort = True Then
                    Exit For
                End If

                Dim fileDate As String = Nothing

                ExtractEXIF(element, fileDate)

                ' Fallback to date of last filechange
                If fileDate Is Nothing Then
                    fileDate = element.LastWriteTime.ToString(CultureInfo.InvariantCulture)
                End If

                ' Parse the date
                Dim parsedFileDate As Date = Date.ParseExact(fileDate, {"dd.MM.yyyy HH:mm:ss", "yyyy:MM:dd HH:mm:ss", "MM/dd/yyyy HH:mm:ss"}, CultureInfo.InvariantCulture, DateTimeStyles.None)
                Dim targetName As String = ""
                Dim fullTargetName As String = ""

                If My.Settings.EnableRenaming Then

                    ' Format the parsed date with the user's pattern
                    targetName = Format(parsedFileDate, TxbFormatPattern.Text)

                    ' Consider the special tag and append a fileextension
                    If targetName.Contains("P") Then
                        targetName = Replace(targetName, "P", GetFileType(sourceFileList.IndexOf(element)))
                    End If

                    targetName = targetName & LCase(element.Extension)
                    fullTargetName = element.DirectoryName & "\" & targetName

                    ' Check if the file is already named correctly
                    If element.Name <> targetName Then
                        Dim index As Integer = 1

                        ' Search for an unused filename
                        If File.Exists(fullTargetName) Then
                            Do
                                index += 1
                                fullTargetName = Path.GetDirectoryName(fullTargetName) & "\" & Path.GetFileNameWithoutExtension(fullTargetName) & "_" & index & Path.GetExtension(fullTargetName)
                            Loop Until Not File.Exists(fullTargetName) Or element.FullName = fullTargetName

                            targetName = Path.GetFileName(fullTargetName)
                        End If

                        If element.Name <> targetName Then

                            ' Rename files
                            My.Computer.FileSystem.RenameFile(element.FullName, targetName)
                        End If

                        If File.Exists(element.FullName & ".uid-zps") Then
                            My.Computer.FileSystem.RenameFile(element.FullName & ".uid-zps", targetName & ".uid-zps")
                        End If
                    End If
                End If

                ' Count up iterations and filesize
                iterationCount += 1
                processedFilesize += element.Length

                ' Set the progress bar to the according value
                PgbMain.Value = Math.Round((100 * processedFilesize / sizeOfAllFiles + 100 * iterationCount / sourceFileList.Count) / 2)
                TaskbarManager.Instance.SetProgressValue(PgbMain.Value, 100)

                ' Sort the files if desired
                If My.Settings.EnableSorting Then

                    ' Log the output filename
                    targetFileList.Add("\" & targetName)

                    Sort(element, parsedFileDate, targetName, fullTargetName)
                End If
            End If
        Next
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    Private Shared Sub ExtractEXIF(ByRef element As FileInfo, ByRef aDate As String)

        ' Extract "EXIF" data from jpg
        If My.Settings.UseEXIF AndAlso LCase(element.Extension) = ".jpg" Then
            Try
                Dim file As ExifFile = ExifFile.Read(element.FullName)

                If file.Properties.ContainsKey(ExifTag.DateTime) Then
                    aDate = file.Properties(ExifTag.DateTime).Value
                End If

                ' Show errormessages to three frequent exceptions
            Catch aEx As ArgumentException
                If aEx.HResult <> -2147024809 Then
                    MessageBox.Show(aEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch navjfEx As NotValidJPEGFileException
                If navjfEx.HResult <> -2146233088 Then
                    MessageBox.Show(navjfEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch fEx As FormatException
                If fEx.HResult <> -2146233033 Then
                    MessageBox.Show(fEx.GetType().ToString & " - " & fEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try
        End If
    End Sub

    Private Sub Sort(ByRef element As FileInfo, ByRef parsedFileDate As Date, ByRef targetName As String, ByRef fullTargetName As String)

        ' Get along with diabled renaming
        If targetName = "" Then
            targetName = element.Name
        End If

        If fullTargetName = "" Then
            fullTargetName = element.FullName
        End If

        ' Derive folder structure from date
        Dim subFolderStructure = Format(parsedFileDate, "yyyy-MM")
        Dim targetFolder As String = Nothing

        subFolderStructure = Replace(subFolderStructure, "-", "\")

        ' Expand folder structure from "target" settings
        If Not exceptionExtensions.Contains(LCase(element.Extension)) Then
            If imageExtensions.Contains(LCase(element.Extension)) Then
                targetFolder = My.Settings.SelectedFolders(1) & "\" & subFolderStructure
            ElseIf documentExtensions.Contains(LCase(element.Extension)) Then
                targetFolder = My.Settings.SelectedFolders(2) & "\" & subFolderStructure
            ElseIf musicExtensions.Contains(LCase(element.Extension)) Then
                targetFolder = My.Settings.SelectedFolders(3) & "\" & subFolderStructure
            ElseIf videoExtensions.Contains(LCase(element.Extension)) Then
                targetFolder = My.Settings.SelectedFolders(4) & "\" & subFolderStructure
            End If
        End If

        ' Ensure the "target" folder exists
        If Not Directory.Exists(targetFolder) Then
            Directory.CreateDirectory(targetFolder)
        End If

        ' Generate the new full name
        Dim fullTargetfullName As String = targetFolder & "\" & targetName
        Dim fullTargetfullNameZPS As String = fullTargetfullName & ".uid-zps"

        If My.Settings.CreateDuplicate Then

            ' Find an unused name
            Dim fullTargetNameParts As String() = Split(fullTargetfullName, ".")
            Dim index = 1

            If File.Exists(fullTargetfullName) Then
                Do
                    index += 1
                    fullTargetfullName = fullTargetNameParts(0) & "_" & index & "." & fullTargetNameParts(1)
                Loop Until Not File.Exists(fullTargetfullName)
            End If
        Else

            ' Delete existing files
            If File.Exists(fullTargetfullName) Then
                File.Delete(fullTargetfullName)
            End If

            If File.Exists(fullTargetfullNameZPS) Then
                File.Delete(fullTargetfullNameZPS)
            End If
        End If

        ' Declare often used variables once
        Dim fullTargetNameZPS As String = fullTargetName & ".uid-zps"

        If My.Settings.CreateCopy Then

            ' Copy the file
            File.Copy(fullTargetName, fullTargetfullName)

            If File.Exists(fullTargetNameZPS) Then
                File.Copy(fullTargetNameZPS, fullTargetfullNameZPS)
            End If
        Else

            ' Move the file
            File.Move(fullTargetName, fullTargetfullName)

            If File.Exists(fullTargetNameZPS) Then
                File.Move(fullTargetNameZPS, fullTargetfullNameZPS)
            End If
        End If

        ' Log the output filename
        targetFileList.Add("\" & subFolderStructure & "\" & targetName)
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton)")>
    Private Sub BtnSettingsReset_Click(sender As Object, e As EventArgs) Handles BtnSettingsReset.Click
        Dim exePath = New Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) & "\" & AppName & ".exe").LocalPath

        ' Show a confirmation dialog
        Dim result As Integer = MessageBox.Show("To reset the settings the application needs to be restarted. Do you really want to reset the settings?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        If result = DialogResult.Yes Then

            ' Reset all settings
            My.Settings.Reset()

            ' Restart application, not minimized
            Application.Exit()
            Shell(exePath, AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub BtnHelpOpen_Click(sender As Object, e As EventArgs) Handles BtnHelpOpen.Click

        ' Open the application's page on the developer's website
        Process.Start("https://jonas-thelemann.de/" & LCase(AppName))
    End Sub

    Private Sub BtnSplashscreenSwitch_Click(sender As Object, e As EventArgs) Handles BtnSplashscreenSwitch.Click

        ' Switch "splashscreen" visibility on or off
        ChangeOnOff(sender, "ShowSplashscreen")
    End Sub

    Private Sub BtnLogShow_Click(sender As Object, e As EventArgs) Handles BtnLogShow.Click

        ' Open the logfile
        Process.Start("file:///" & Replace(AppFolder, "\", "/") & "/" & AppName & "/log/log.html")
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.GroupBox.set_Text(System.String)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    Private Sub BtnLogDelete_Click(sender As Object, e As EventArgs) Handles BtnLogDelete.Click

        ' Delete the "log" directory
        My.Computer.FileSystem.DeleteDirectory(AppFolder & "\" & AppName & "\log", UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin)

        ' Display a "confirmation" dialog
        MessageBox.Show("Logfile successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Reset "log" counter
        GrpSettingsLog.Text = "Log (0 kb)"
        GrpSettingsLog.Enabled = False
    End Sub

    Private Sub BtnNotificationsSwitch_Click(sender As Object, e As EventArgs) Handles BtnNotificationsSwitch.Click

        ' Switch "notifications" on or off
        ChangeOnOff(sender, "ShowNotifications")
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    Private Sub BtnFeedbackReset_Click(sender As Object, e As EventArgs) Handles BtnFeedbackReset.Click

        ' Clear the "feedback" list
        My.Settings.Feedback.Clear()

        ' Display a "confirmation" dialog
        MessageBox.Show("Feedback has been reset.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Async Sub GrpUpdateSearch_Click(sender As Object, e As EventArgs) Handles GrpUpdateSearch.Click
        Try
            Dim dResult As New DialogResult
            Dim webClient As New WebClient()
            Dim remoteVersion As String = Nothing
            Dim remoteVersionNumber As Integer
            Dim currentVersionNumber = Replace(CurrentVersion, ".", "")

            ' Connect "download" events to their sub
            AddHandler webClient.DownloadProgressChanged, AddressOf DownloadProgressCallback
            AddHandler webClient.DownloadFileCompleted, AddressOf DownloadCompletedCallback

            ' Update the UI with current task
            LblMainTask.Text = "Searching..."

            ' Check for the newest version
            Dim result As Stream = Await webClient.OpenReadTaskAsync(New Uri("https://dl.dropboxusercontent.com/u/74738294/" & AppName & "/current_version.txt"))
            Dim sr As StreamReader = New StreamReader(result)

            ' Read "remote" version number and update taskbar
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate)
            remoteVersion = sr.ReadToEnd()
            remoteVersionNumber = Replace(remoteVersion, ".", "")
            sr.Close()
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress)

            ' Compare version numbers
            If currentVersionNumber < remoteVersionNumber Then

                ' A new version exists - offering download
                dResult = MessageBox.Show("Current version: " & CurrentVersion & vbCrLf & "Newest version available: " & remoteVersion & vbCrLf & vbCrLf & "Do you want to update now?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            ElseIf currentVersionNumber > remoteVersionNumber Then

                ' A development build is used - greeting the developer
                dResult = MessageBox.Show("Current version: " & currentVersion & vbCrLf & "Newest version available: " & remoteVersion & vbCrLf & vbCrLf & "It seems like you are using a development build... Great, dear developer, a new version must be there soon :)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                ' No update found - showing status
                dResult = MessageBox.Show("Current version: " & CurrentVersion & vbCrLf & "Newest version available: " & remoteVersion & vbCrLf & vbCrLf & "No update is available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Download newest ".exe" asynchronically
            If dResult = DialogResult.Yes Then
                If Not File.Exists(DownloadPath & AppName & "_" & remoteVersion & ".exe") Then
                    My.Computer.FileSystem.CreateDirectory(DownloadPath)
                    LblMainTask.Text = "Downloading..."
                    webClient.DownloadFileAsync(New Uri("https://dl.dropboxusercontent.com/u/74738294/" & AppName & "/" & AppName & "_" & remoteVersion & ".exe"), DownloadPath & AppName & "_" & remoteVersion & ".exe")
                End If
            End If

            ' Update the UI with current task
            LblMainTask.Text = "Done!"
        Catch ex As WebException

            ' Display errormessage with according taskbar color
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error)
            TaskbarManager.Instance.SetProgressValue(100, 100)
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Revert back to normal state
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal)
            TaskbarManager.Instance.SetProgressValue(0, 100)
        End Try
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    Private Sub BtnAboutOpen_Click(sender As Object, e As EventArgs) Handles BtnAboutOpen.Click

        ' Show the "about" dialog
        MessageBox.Show(AppName & " " & CurrentVersion & vbCrLf & "Copyright " & Date.Today.Year & " " & Application.CompanyName & vbCrLf & vbCrLf & "With this application you can rename and sort large amounts of photos and other files at once using a specified pattern." & vbCrLf & vbCrLf & "If you have questions and suggestions you can send an email to" & vbCrLf & "batchrename@jonas-thelemann.de" & vbCrLf & vbCrLf & "Thank you very much!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LblMainTask_TextChanged(sender As Object, e As EventArgs) Handles LblMainTask.TextChanged

        ' Prevent buggy UI
        Application.DoEvents()
    End Sub
End Class
