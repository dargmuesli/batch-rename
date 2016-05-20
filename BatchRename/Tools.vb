Imports System.ComponentModel
Imports System.Environment
Imports System.Globalization
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.WindowsAPICodePack.Taskbar

Public Module Tools
    Function EaseInOutCubic(ByVal currentTime As Double, ByVal startValue As Integer, ByVal changeValue As Integer, ByVal duration As Integer) As Integer

        ' Move along the time axis
        currentTime /= duration / 2

        ' Return the "cubic distance" axis's value
        If (currentTime < 1) Then
            Return changeValue / 2 * currentTime * currentTime * currentTime + startValue
        Else
            currentTime -= 2
            Return changeValue / 2 * (currentTime * currentTime * currentTime + 2) + startValue
        End If
    End Function

    Function CompactString(ByVal input As String, ByVal width As Integer, ByVal font As Font, ByVal formatFlg As TextFormatFlags) As String
        Dim result As String = String.Copy(input)

        ' Shorten the "input" string
        TextRenderer.MeasureText(result, font, New Size(width, 0), formatFlg Or TextFormatFlags.ModifyString)

        Return result
    End Function

    Sub ChangeOnOff(ByVal sender As Object, ByVal settings As String)

        ' Distinguish between a "start/stop" and "enable/disable" action
        If settings = "" Then

            ' Switch the "background" image
            If sender.BackgroundImage Is FrmMain.PGoImg Then
                sender.BackgroundImage = FrmMain.PHaltImg
            Else
                sender.BackgroundImage = FrmMain.PGoImg

                ' Tell the iteration to stop next time
                FrmMain.PAbort = True
            End If
        Else

            ' Switch the "background" image
            If sender.BackgroundImage Is FrmMain.PYesImg Then
                sender.BackgroundImage = FrmMain.PNoImg
            Else
                sender.BackgroundImage = FrmMain.PYesImg
            End If

            ' Switch the setting and "UI" text
            If My.Settings(settings) Then
                My.Settings(settings) = False
                sender.Text = Replace(sender.Text, "Disable", "Enable")
            Else
                My.Settings(settings) = True
                sender.Text = Replace(sender.Text, "Enable", "Disable")
            End If
        End If
    End Sub

    Sub OpenSettings()

        ' Move the UI horizontally to the right
        Dim xSub As New CustomTimer(1, 0, -400, "x")

        xSub.StartTimer()
    End Sub

    Function GetFileList(ByVal container As ArrayList) As ArrayList
        Dim fileInfo As FileInfo()
        Dim fileArray As New ArrayList
        Dim indexedFiles, indexedCategories As Long

        ' Ensure "container" is given
        If container Is Nothing Then
            Throw New ArgumentNullException("container")
        End If

        ' Set procedure variables to their initial value
        FrmMain.PSizeOfAllFiles = 0
        FrmMain.PgbMain.Value = 0
        indexedCategories = 0
        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal)
        TaskbarManager.Instance.SetProgressValue(0, 100)
        FrmMain.PAbort = False

        ' Iterate through all fileextensions
        For Each strng As String In container

            ' Check if the user requested a stop
            If FrmMain.PAbort = True Then
                Exit For
            End If

            ' Search in folder and subfolder if desired
            If FrmMain.ChkFolderSubfolder.Checked Then
                fileInfo = New DirectoryInfo(My.Settings.SelectedFolders(0)).GetFiles("*" & strng, IO.SearchOption.AllDirectories) 'PDirInfo
            Else
                fileInfo = New DirectoryInfo(My.Settings.SelectedFolders(0)).GetFiles("*" & strng, IO.SearchOption.TopDirectoryOnly) 'PDirInfo
            End If

            ' Update UI
            indexedCategories += 1
            FrmMain.LblMainTask.Text = CompactString("Indicating... (" & indexedFiles & " files, " & indexedCategories & " of " & container.Count & " categories)", FrmMain.PgbMain.Width - 7, FrmMain.LblMainTask.Font, TextFormatFlags.PathEllipsis)
            FrmMain.PgbMain.Value = Math.Round(indexedCategories * 100 / container.Count)
            TaskbarManager.Instance.SetProgressValue(FrmMain.PgbMain.Value, 100)

            ' Add every file with current fileextension to an arraylist
            For i As Integer = 0 To fileInfo.Count - 1

                ' Exclude system files
                If fileInfo(i).Attributes.ToString <> "ReadOnly, Hidden, System, Archive" Then
                    fileArray.Add(fileInfo(i))
                    FrmMain.PSizeOfAllFiles += fileInfo(i).Length
                    indexedFiles += 1
                End If
            Next
        Next

        ' Enable "start" button if files were found
        If fileArray.Count > 0 Then
            FrmMain.BtnSortingGoHaltSwitch.Enabled = True
        Else
            FrmMain.BtnSortingGoHaltSwitch.Enabled = False
        End If

        ' Reset the progressbar
        FrmMain.PgbMain.Value = 0
        TaskbarManager.Instance.SetProgressValue(0, 100)

        Return fileArray
    End Function

    <CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Objekte nicht mehrmals verwerfen")>
    Function GetFileType(ByVal mainIndex As Integer) As String
        Dim output As String = Nothing

        If FrmMain.GetImageExtensions.Contains(LCase(FrmMain.PSourceFileList.Item(mainIndex).Extension)) Then
            ' Identify an image
            output = "IMG"
        ElseIf FrmMain.GetDocumentExtensions.Contains(LCase(FrmMain.PSourceFileList.Item(mainIndex).Extension)) Then
            ' Identify a document
            output = "DOC"
        ElseIf FrmMain.GetMusicExtensions.Contains(LCase(FrmMain.PSourceFileList.Item(mainIndex).Extension)) Then
            ' Identify music
            output = "MUS"
        ElseIf FrmMain.GetVideoExtensions.Contains(LCase(FrmMain.PSourceFileList.Item(mainIndex).Extension)) Then
            ' Identify a video
            output = "VID"
        End If

        Return output
    End Function

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.GroupBox.set_Text(System.String)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="Microsoft.VisualBasic.MyServices.FileSystemProxy.WriteAllText(System.String,System.String,System.Boolean)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.Label.set_Text(System.String)")>
    Sub CreateLog()
        Dim str As String = Nothing
        Dim strfirst As String = Nothing
        Dim strmiddle As String = Nothing
        Dim strlast As String = Nothing
        Dim mode As String = Nothing
        Dim id As String = Date.Now.ToString(CultureInfo.InvariantCulture)

        ' Update UI
        FrmMain.LblMainTask.Text = ("Log report is being generated...")

        ' Create the "mode" string from used settings
        If My.Settings.EnableRenaming Then
            If My.Settings.EnableSorting Then
                mode &= "Rename, "
            Else
                mode &= "Rename"
            End If
        End If

        If My.Settings.EnableSorting Then
            mode &= "Sort"

            If My.Settings.CreateCopy Then
                mode &= "; Copy, "
            Else
                mode &= "; Move, "
            End If

            If My.Settings.CreateDuplicate Then
                mode &= "Duplicate"
            Else
                mode &= "Overwrite"
            End If
        End If

        ' Build the "HTML" outline
        strfirst = "<!DOCTYPE html>" & vbCrLf &
            "<html lang=" & Chr(34) & "de" & Chr(34) & " dir=" & Chr(34) & "ltr" & Chr(34) & ">" & vbCrLf &
            "<head>" & vbCrLf &
            "<title>" & vbCrLf &
            FrmMain.PAppName & " - Protocol" & vbCrLf &
            "</title>" & vbCrLf &
            "<meta http-equiv=" & Chr(34) & "Content-Type" & Chr(34) & " content=" & Chr(34) & "text/html;charset=utf-8" & Chr(34) & " />" & vbCrLf &
            "<style type=" & Chr(34) & "text/css" & Chr(34) & ">" & vbCrLf &
            "body{" & vbCrLf &
            "font-family:Consolas, Courier, monospace;" & vbCrLf &
            "font-size:0.8em;" & vbCrLf &
            "margin:auto;width:80%;}" & vbCrLf &
            "table{" & vbCrLf &
            "border-collapse:collapse;" & vbCrLf &
            "margin:1em 0;" & vbCrLf &
            "width:100%;}" & vbCrLf &
            "th, td{" & vbCrLf &
            "border:solid grey;" & vbCrLf &
            "border-width:1px 0;" & vbCrLf &
            "padding-right:2em;}" & vbCrLf &
            "tr:nth-child(odd){" & vbCrLf &
            "background-color:#EEE;}" & vbCrLf &
            ".actions tr td{" & vbCrLf &
            "white-space:nowrap;}" & vbCrLf &
            ".actions tr td:nth-child(5), .errors tr td:nth-child(2){" & vbCrLf &
            "white-space:normal;" & vbCrLf &
            "word-break:break-all;}" & vbCrLf &
            "tr td:last-child{padding-right:0;}" & vbCrLf &
            "</style>" & vbCrLf &
            "</head>" & vbCrLf &
            "<body>" & vbCrLf &
            "<h1>" & FrmMain.PAppName & " - Protocol</h1>" & vbCrLf &
            "<p><a href=" & Chr(34) & "#" & id & Chr(34) & ">Go to the most recent entry</a></p>" & vbCrLf

        ' Create the headline and productversion, mode and "format" string
        strmiddle = "<h2 id=" & Chr(34) & id & Chr(34) & ">" & id & "</h2>" & vbCrLf &
            "<p>" & vbCrLf &
            FrmMain.PAppName & " " & Application.ProductVersion & "<br>" & vbCrLf & vbCrLf &
            "Mode: " & mode & "<br>" & vbCrLf &
            "Format: " & FrmMain.TxbFormatPattern.Text & "<br>" & vbCrLf & vbCrLf

        ' Append "source" and "target" strings
        If My.Settings.EnableSorting Then
            strmiddle &= "Source: " & My.Settings.SelectedFolders(0) & "<br>" & vbCrLf &
                "Pictures target: " & My.Settings.SelectedFolders(1) & "<br>" & vbCrLf &
                "Documents target: " & My.Settings.SelectedFolders(2) & "<br>" & vbCrLf &
                "Music target: " & My.Settings.SelectedFolders(3) & "<br>" & vbCrLf &
                "Videos target: " & My.Settings.SelectedFolders(4) & "<br>" & vbCrLf & vbCrLf
        Else
            strmiddle &= "Source: " & FrmMain.TxbFolderSource.Text & "<br>" & vbCrLf
        End If

        ' Append "completion" statistics
        strmiddle &= "Done: " & FrmMain.PIterationCount & "/" & FrmMain.PSourceFileList.Count & "<br>" & vbCrLf &
            "Elapsed time: " & entireDuration.ToString("hh\:mm\:ss", CultureInfo.CurrentCulture) & "<br>" & vbCrLf &
            "</p>" & vbCrLf &
            "<table class=" & Chr(34) & "actions" & Chr(34) & ">" & vbCrLf

        Dim i = 0

        ' Append each edited filename
        For Each fInfo As FileInfo In FrmMain.PSourceFileList
            If FrmMain.PSourceFileList.IndexOf(fInfo) < FrmMain.PIterationCount Then
                Dim fName As String = fInfo.FullName

                fName = fName.Remove(0, FrmMain.TxbFolderSource.Text.Length)

                If FrmMain.PSourceFileList.Count = FrmMain.PTargetFileList.Count Then
                    strmiddle &= "<tr>" & vbCrLf & "<td>" & fName & "</td>" & vbCrLf & "<td>" & vbCrLf & FrmMain.PTargetFileList(i) & vbCrLf & "</td>" & vbCrLf & "</tr>" & vbCrLf & vbCrLf
                ElseIf FrmMain.PSourceFileList.Count * 2 = FrmMain.PTargetFileList.Count Then
                    strmiddle &= "<tr>" & vbCrLf & "<td>" & fName & "</td>" & vbCrLf & "<td>" & vbCrLf & FrmMain.PTargetFileList(i * 2) & vbCrLf & "</td>" & vbCrLf & "</tr>" & vbCrLf & vbCrLf
                    strmiddle &= "<tr>" & vbCrLf & "<td>" & "</td>" & vbCrLf & "<td>" & vbCrLf & FrmMain.PTargetFileList(i * 2 + 1) & vbCrLf & "</td>" & vbCrLf & "</tr>" & vbCrLf & vbCrLf
                Else
                    Throw New Exception("Source and target filelist count do not match the expected conditions.")
                End If
            End If

            i += 1
        Next

        ' Finish HTML
        strlast = "</table>" & vbCrLf &
            "</body>" & vbCrLf &
            "</html>"

        ' Check if logfile already exists
        If File.Exists(FrmMain.PAppFolder & "\" & FrmMain.PAppName & "\log\log.html") Then

            ' Read the existing file
            Dim lines As String = File.ReadAllText(FrmMain.PAppFolder & "\" & FrmMain.PAppName & "\log\log.html")

            ' Update "jump to bottom" hyperlink 
            lines = lines.Remove(700, 71)
            lines = lines.Insert(700, vbCrLf & "<p><a href=" & Chr(34) & "#" & id & Chr(34) & ">Go to the most recent entry</a></p>")

            ' Append new loginformation
            lines = lines.Remove(lines.Length - 16)
            lines &= strmiddle & strlast

            str = lines
        Else

            ' Combine all strings to a complete HTML structure
            str = strfirst & strmiddle & strlast
        End If

        ' Create the logfile
        My.Computer.FileSystem.CreateDirectory(FrmMain.PAppFolder & "\" & FrmMain.PAppName & "\log")
        My.Computer.FileSystem.WriteAllText(FrmMain.PAppFolder & "\" & FrmMain.PAppName & "\log\log.html", str, False)

        ' Update UI
        FrmMain.LblMainTask.Text = ("Log report was successfully generated.")
        FrmMain.GrpSettingsLog.Text = "Log (" & Math.Round(FileLen(FrmMain.PAppFolder & "\" & FrmMain.PAppName & "\log\log.html") / 1024) & " kb)"
        FrmMain.GrpSettingsLog.Enabled = True
    End Sub

    Private runtimeList As New ArrayList
    Private presentTime As Date
    Private entireDuration As TimeSpan

    Function GetRemainingSeconds(ByVal allTaskCount As Integer, ByVal doneTaskCount As Integer) As Double
        Dim averageTimePerIteration, timeRemaining As Double

        ' Skip first iteration
        If presentTime <> Nothing Then

            ' Append duration of last iteration
            runtimeList.Add(Date.Now.Subtract(presentTime))
            entireDuration = Nothing

            For Each ts As TimeSpan In runtimeList

                ' Calculate the current total duration
                entireDuration += ts
            Next

            ' Downsample to average and upsample to remaining duration
            averageTimePerIteration = entireDuration.TotalSeconds / runtimeList.Count
            timeRemaining = Math.Round(averageTimePerIteration * (allTaskCount - doneTaskCount))
        End If

        ' Set current time for next iteration
        presentTime = Date.Now

        Return timeRemaining
    End Function

    Sub DownloadProgressCallback(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)

        ' Check for ArgumentNullException
        If e Is Nothing Then
            Throw New ArgumentNullException("e")
        End If

        ' Update UI according to download status
        TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100)
        FrmMain.PgbMain.Value = e.ProgressPercentage
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.Label.set_Text(System.String)")>
    Sub DownloadCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        FrmMain.LblMainTask.Text = "Download completed."

        ' Ensure "e" is given
        If e Is Nothing Then
            Throw New ArgumentNullException("e")
        End If

        If e.Error Is Nothing Then

            ' Restart application
            Shell(FrmMain.PDownloadPath)
            Application.Exit()
        Else

            ' Display the error message
            MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.FolderBrowserDialog.set_Description(System.String)")>
    Sub OpenFbd(ByVal index As Short, ByVal folder As String, ByVal label As Label)

        ' Ensure "index" is in range
        If index < 0 Or index > 4 Then
            Throw New ArgumentOutOfRangeException("index")
        End If

        ' Ensure "folder" is valid
        If Not FileSystem.DirectoryExists(folder) Then
            folder = Nothing
        End If

        ' Ensure "textbox" is given
        If label Is Nothing Then
            Throw New ArgumentNullException("label")
        End If

        Dim fbdialog As New FolderBrowserDialog

        Try

            ' Start from desktop
            Fbdialog.RootFolder = SpecialFolder.Desktop

            ' Try to navigate to last used folder
            If FileSystem.DirectoryExists(My.Settings.SelectedFolders(index)) Then
                fbdialog.SelectedPath = My.Settings.SelectedFolders(index)
            Else
                fbdialog.SelectedPath = Nothing
            End If

            ' Show the "folder browser" dialog
            fbdialog.Description = "Select directory:"
            Fbdialog.ShowDialog()

            ' Ensure there is a path selected
            If Fbdialog.SelectedPath = Nothing Then
                If My.Settings.SelectedFolders(index) <> folder Then
                    Fbdialog.SelectedPath = My.Settings.SelectedFolders(index)
                Else
                    Fbdialog.SelectedPath = folder
                End If
            End If

            ' Save the folder in settings
            My.Settings.SelectedFolders(index) = Fbdialog.SelectedPath

            ' Update UI
            label.Text = CompactString(fbdialog.SelectedPath, FrmMain.GrpSortingFolders.Width - 250, label.Font, TextFormatFlags.PathEllipsis)
        Finally

            ' Free resources
            Fbdialog.Dispose()
        End Try
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.FolderBrowserDialog.set_Description(System.String)")>
    Sub OpenFbd(ByVal index As Short, ByVal folder As String, ByVal textBox As TextBox)

        ' Ensure "index" is in range
        If index < 0 Or index > 4 Then
            Throw New ArgumentOutOfRangeException("index")
        End If

        ' Ensure "folder" is valid
        If Not FileSystem.DirectoryExists(folder) Then
            folder = Nothing
        End If

        ' Ensure "textbox" is given
        If textBox Is Nothing Then
            Throw New ArgumentNullException("textBox")
        End If

        Dim Fbdialog As New FolderBrowserDialog

        Try

            ' Start from desktop
            Fbdialog.RootFolder = SpecialFolder.Desktop

            ' Try to navigate to last used folder
            If FileSystem.DirectoryExists(My.Settings.SelectedFolders(index)) Then
                Fbdialog.SelectedPath = My.Settings.SelectedFolders(index)
            Else
                Fbdialog.SelectedPath = Nothing
            End If

            ' Show the "folder browser" dialog
            Fbdialog.Description = "Select directory:"
            Fbdialog.ShowDialog()

            ' Ensure there is a path selected
            If Fbdialog.SelectedPath = Nothing Then
                If My.Settings.SelectedFolders(index) <> folder Then
                    Fbdialog.SelectedPath = My.Settings.SelectedFolders(index)
                Else
                    Fbdialog.SelectedPath = folder
                End If
            End If

            ' Save the folder in settings
            My.Settings.SelectedFolders(index) = Fbdialog.SelectedPath

            ' Update UI
            textBox.Text = Fbdialog.SelectedPath
        Finally

            ' Free resources
            Fbdialog.Dispose()
        End Try
    End Sub
End Module
