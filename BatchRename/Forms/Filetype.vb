Imports System.Text.RegularExpressions

Public Class FrmFiletype
    Private Sub FrmFiletype_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Create string arrays for extension list transfer
        Dim imageExtensions(My.Settings.ImageExtensions.Count - 1) As String
        Dim documentExtensions(My.Settings.DocumentExtensions.Count - 1) As String
        Dim musicExtensions(My.Settings.MusicExtensions.Count - 1) As String
        Dim videoExtensions(My.Settings.VideoExtensions.Count - 1) As String
        Dim exceptionExtensions(My.Settings.ExceptionExtensions.Count - 1) As String

        ' Copy extension lists to arrays
        My.Settings.ImageExtensions.CopyTo(imageExtensions, 0)
        My.Settings.DocumentExtensions.CopyTo(documentExtensions, 0)
        My.Settings.MusicExtensions.CopyTo(musicExtensions, 0)
        My.Settings.VideoExtensions.CopyTo(videoExtensions, 0)
        My.Settings.ExceptionExtensions.CopyTo(exceptionExtensions, 0)

        ' Reset all checkedlistboxes
        ClbIncludePictures.Items.Clear()
        ClbIncludeDocuments.Items.Clear()
        ClbIncludeMusic.Items.Clear()
        ClbIncludeVideos.Items.Clear()
        ClbExcludeExceptions.Items.Clear()

        ' Load arrays to lists
        ClbIncludePictures.Items.AddRange(imageExtensions)
        ClbIncludeDocuments.Items.AddRange(documentExtensions)
        ClbIncludeMusic.Items.AddRange(musicExtensions)
        ClbIncludeVideos.Items.AddRange(videoExtensions)
        ClbExcludeExceptions.Items.AddRange(exceptionExtensions)

        ' Select chosen extensions
        For Each item As String In FrmMain.PEnabledExtensions
            If ClbIncludePictures.FindString(item) <> ListBox.NoMatches Then
                ClbIncludePictures.SetItemChecked(ClbIncludePictures.FindString(item), True)
            ElseIf ClbIncludeDocuments.FindString(item) <> ListBox.NoMatches Then
                ClbIncludeDocuments.SetItemChecked(ClbIncludeDocuments.FindString(item), True)
            ElseIf ClbIncludeMusic.FindString(item) <> ListBox.NoMatches Then
                ClbIncludeMusic.SetItemChecked(ClbIncludeMusic.FindString(item), True)
            ElseIf ClbIncludeVideos.FindString(item) <> ListBox.NoMatches Then
                ClbIncludeVideos.SetItemChecked(ClbIncludeVideos.FindString(item), True)
            ElseIf ClbExcludeExceptions.FindString(item) <> ListBox.NoMatches Then
                ClbExcludeExceptions.SetItemChecked(ClbExcludeExceptions.FindString(item), True)
            End If
        Next

        ' Populate "remove" combobox
        CmbRemoveExtension.Items.AddRange(imageExtensions)

        ' Preselect standard values
        CmbAddCategory.SelectedIndex = 0
        CmbRemoveCategory.SelectedIndex = 0
        CmbRemoveExtension.SelectedIndex = 0
    End Sub

    Private Sub BtnFiletypeAll_Click(sender As Object, e As EventArgs) Handles BtnFiletypeAll.Click

        ' Check all checkboxes
        For i As Integer = 0 To ClbIncludePictures.Items.Count - 1
            ClbIncludePictures.SetItemChecked(i, True)
        Next i

        For i As Integer = 0 To ClbIncludeDocuments.Items.Count - 1
            ClbIncludeDocuments.SetItemChecked(i, True)
        Next i

        For i As Integer = 0 To ClbIncludeMusic.Items.Count - 1
            ClbIncludeMusic.SetItemChecked(i, True)
        Next i

        For i As Integer = 0 To ClbIncludeVideos.Items.Count - 1
            ClbIncludeVideos.SetItemChecked(i, True)
        Next i

        For i As Integer = 0 To ClbExcludeExceptions.Items.Count - 1
            ClbExcludeExceptions.SetItemChecked(i, True)
        Next i
    End Sub

    Private Sub BtnFiletypeNone_Click(sender As Object, e As EventArgs) Handles BtnFiletypeNone.Click

        ' Uncheck all checkboxes
        For i As Integer = 0 To ClbIncludePictures.Items.Count - 1
            ClbIncludePictures.SetItemChecked(i, False)
        Next i

        For i As Integer = 0 To ClbIncludeDocuments.Items.Count - 1
            ClbIncludeDocuments.SetItemChecked(i, False)
        Next i

        For i As Integer = 0 To ClbIncludeMusic.Items.Count - 1
            ClbIncludeMusic.SetItemChecked(i, False)
        Next i

        For i As Integer = 0 To ClbIncludeVideos.Items.Count - 1
            ClbIncludeVideos.SetItemChecked(i, False)
        Next i

        For i As Integer = 0 To ClbExcludeExceptions.Items.Count - 1
            ClbExcludeExceptions.SetItemChecked(i, False)
        Next i
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If ValidateExtension() Then

            ' Add extension to the corresponding list and offer a report
            If CmbAddCategory.SelectedIndex = 0 Then
                ClbIncludePictures.Items.Add(TxbAddExtension.Text, True)
                ArrayList.Adapter(My.Settings.ImageExtensions).Sort()
                Call CmbRemoveCategory_SelectedIndexChanged(sender, e)
                ClbIncludePictures.SelectedIndex = ClbIncludePictures.Items.IndexOf(TxbAddExtension.Text)
                ReportExtension(TxbAddExtension.Text, "Image")
            ElseIf CmbAddCategory.SelectedIndex = 1 Then
                ClbIncludeDocuments.Items.Add(TxbAddExtension.Text, True)
                ArrayList.Adapter(My.Settings.DocumentExtensions).Sort()
                Call CmbRemoveCategory_SelectedIndexChanged(sender, e)
                ClbIncludeDocuments.SelectedIndex = ClbIncludeDocuments.Items.IndexOf(TxbAddExtension.Text)
                ReportExtension(TxbAddExtension.Text, "Document")
            ElseIf CmbAddCategory.SelectedIndex = 2 Then
                ClbIncludeMusic.Items.Add(TxbAddExtension.Text, True)
                ArrayList.Adapter(My.Settings.MusicExtensions).Sort()
                Call CmbRemoveCategory_SelectedIndexChanged(sender, e)
                ClbIncludeMusic.SelectedIndex = ClbIncludeMusic.Items.IndexOf(TxbAddExtension.Text)
                ReportExtension(TxbAddExtension.Text, "Music")
            ElseIf CmbAddCategory.SelectedIndex = 3 Then
                ClbIncludeVideos.Items.Add(TxbAddExtension.Text, True)
                ArrayList.Adapter(My.Settings.VideoExtensions).Sort()
                Call CmbRemoveCategory_SelectedIndexChanged(sender, e)
                ClbIncludeVideos.SelectedIndex = ClbIncludeVideos.Items.IndexOf(TxbAddExtension.Text)
                ReportExtension(TxbAddExtension.Text, "Video")
            ElseIf CmbAddCategory.SelectedIndex = 4 Then
                ClbExcludeExceptions.Items.Add(TxbAddExtension.Text, True)
                ArrayList.Adapter(My.Settings.ExceptionExtensions).Sort()
                Call CmbRemoveCategory_SelectedIndexChanged(sender, e)
                ClbExcludeExceptions.SelectedIndex = ClbExcludeExceptions.Items.IndexOf(TxbAddExtension.Text)
                ReportExtension(TxbAddExtension.Text, "Exception")
            End If
        End If

        ' Reset textbox
        TxbAddExtension.Text = ""
        Call TxbAddExtension_Leave(sender, e)
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.TextBox.set_Text(System.String)")>
    Private Sub TxbAddExtension_Enter(sender As Object, e As EventArgs) Handles TxbAddExtension.Enter
        If TxbAddExtension.Text = ".xyz" Then

            ' Remove the placeholder
            TxbAddExtension.Text = "."
            TxbAddExtension.ForeColor = SystemColors.WindowText
        End If
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.TextBox.set_Text(System.String)")>
    Private Sub TxbAddExtension_Leave(sender As Object, e As EventArgs) Handles TxbAddExtension.Leave
        If TxbAddExtension.Text = "" Or TxbAddExtension.Text = "." Then

            ' Add the placeholder
            TxbAddExtension.Text = ".xyz"
            TxbAddExtension.ForeColor = SystemColors.GrayText
        End If
    End Sub

    Private Sub CmbRemoveCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbRemoveCategory.SelectedIndexChanged

        ' Reset "remove" combobox
        CmbRemoveExtension.Items.Clear()

        ' Create string arrays for extension list transfer
        Dim imageExtensions(ClbIncludePictures.Items.Count - 1) As String
        Dim documentExtensions(ClbIncludeDocuments.Items.Count - 1) As String
        Dim musicExtensions(ClbIncludeMusic.Items.Count - 1) As String
        Dim videoExtensions(ClbIncludeVideos.Items.Count - 1) As String
        Dim exceptionExtensions(ClbExcludeExceptions.Items.Count - 1) As String

        ' Copy extension lists to arrays
        ClbIncludePictures.Items.CopyTo(imageExtensions, 0)
        ClbIncludeDocuments.Items.CopyTo(documentExtensions, 0)
        ClbIncludeMusic.Items.CopyTo(musicExtensions, 0)
        ClbIncludeVideos.Items.CopyTo(videoExtensions, 0)
        ClbExcludeExceptions.Items.CopyTo(exceptionExtensions, 0)

        ' Populate "remove" combobox
        If CmbRemoveCategory.SelectedIndex = 0 Then
            CmbRemoveExtension.Items.AddRange(imageExtensions)
        ElseIf CmbRemoveCategory.SelectedIndex = 1 Then
            CmbRemoveExtension.Items.AddRange(documentExtensions)
        ElseIf CmbRemoveCategory.SelectedIndex = 2 Then
            CmbRemoveExtension.Items.AddRange(musicExtensions)
        ElseIf CmbRemoveCategory.SelectedIndex = 3 Then
            CmbRemoveExtension.Items.AddRange(videoExtensions)
        ElseIf CmbRemoveCategory.SelectedIndex = 4 Then
            CmbRemoveExtension.Items.AddRange(exceptionExtensions)
        End If

        ' Select last selected or first item or clear text
        If CmbRemoveExtension.Items.Count > 0 Then
            If CmbRemoveCategory.SelectedIndex = 0 Then
                If ClbIncludePictures.SelectedIndex <> -1 Then
                    CmbRemoveExtension.SelectedIndex = ClbIncludePictures.SelectedIndex
                Else
                    CmbRemoveExtension.SelectedIndex = 0
                End If
            ElseIf CmbRemoveCategory.SelectedIndex = 1 Then
                If ClbIncludeDocuments.SelectedIndex <> -1 Then
                    CmbRemoveExtension.SelectedIndex = ClbIncludeDocuments.SelectedIndex
                Else
                    CmbRemoveExtension.SelectedIndex = 0
                End If
            ElseIf CmbRemoveCategory.SelectedIndex = 2 Then
                If ClbIncludeMusic.SelectedIndex <> -1 Then
                    CmbRemoveExtension.SelectedIndex = ClbIncludeMusic.SelectedIndex
                Else
                    CmbRemoveExtension.SelectedIndex = 0
                End If
            ElseIf CmbRemoveCategory.SelectedIndex = 3 Then
                If ClbIncludeVideos.SelectedIndex <> -1 Then
                    CmbRemoveExtension.SelectedIndex = ClbIncludeVideos.SelectedIndex
                Else
                    CmbRemoveExtension.SelectedIndex = 0
                End If
            ElseIf CmbRemoveCategory.SelectedIndex = 4 Then
                If ClbExcludeExceptions.SelectedIndex <> -1 Then
                    CmbRemoveExtension.SelectedIndex = ClbExcludeExceptions.SelectedIndex
                Else
                    CmbRemoveExtension.SelectedIndex = 0
                End If
            End If
        Else
            CmbRemoveExtension.Text = ""
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        TxbAddExtension.Text = CmbRemoveExtension.Text
        TxbAddExtension.ForeColor = SystemColors.WindowText

        ' Remove extension from list and settings
        If CmbRemoveCategory.SelectedIndex = 0 Then
            ClbIncludePictures.Items.Remove(CmbRemoveExtension.Text)
        ElseIf CmbRemoveCategory.SelectedIndex = 1 Then
            ClbIncludeDocuments.Items.Remove(CmbRemoveExtension.Text)
        ElseIf CmbRemoveCategory.SelectedIndex = 2 Then
            ClbIncludeMusic.Items.Remove(CmbRemoveExtension.Text)
        ElseIf CmbRemoveCategory.SelectedIndex = 3 Then
            ClbIncludeVideos.Items.Remove(CmbRemoveExtension.Text)
        ElseIf CmbRemoveCategory.SelectedIndex = 4 Then
            ClbExcludeExceptions.Items.Remove(CmbRemoveExtension.Text)
        End If

        ' Update "remove" combobox
        Call CmbRemoveCategory_SelectedIndexChanged(sender, e)
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    Private Function ValidateExtension()

        ' Ensure the typed extension is formatted correctly
        If Regex.IsMatch(TxbAddExtension.Text, "\.[a-z0-9].*") AndAlso TxbAddExtension.Text <> ".xyz" Then

            ' Ensure the typed extension is not already present in a list
            If ClbIncludePictures.Items.IndexOf(TxbAddExtension.Text) <> -1 Then
                MessageBox.Show("This extension already exists in the Pictures list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf ClbIncludeDocuments.Items.IndexOf(TxbAddExtension.Text) <> -1 Then
                MessageBox.Show("This extension already exists in the documents list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf ClbIncludeMusic.Items.IndexOf(TxbAddExtension.Text) <> -1 Then
                MessageBox.Show("This extension already exists in the music list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf ClbIncludeVideos.Items.IndexOf(TxbAddExtension.Text) <> -1 Then
                MessageBox.Show("This extension already exists in the videos list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf ClbExcludeExceptions.Items.IndexOf(TxbAddExtension.Text) <> -1 Then
                MessageBox.Show("This extension already exists in the exceptions list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Return True
            End If
        Else
            MessageBox.Show("This is not a valid format for a fileextension!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")>
    <CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId:="System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)")>
    Private Shared Sub ReportExtension(ByVal extension As String, ByVal type As String)

        ' Ensure the extension is unknown
        If Not FrmMain.GetImageExtensions.Contains(extension) And Not FrmMain.GetDocumentExtensions.Contains(extension) And Not FrmMain.GetMusicExtensions.Contains(extension) And Not FrmMain.GetVideoExtensions.Contains(extension) And Not FrmMain.GetExceptionExtensions.Contains(extension) AndAlso Not My.Settings.Feedback.Contains(extension) Then
            Dim dialogResult As DialogResult = DialogResult.No

            ' Show a disclaimer depending on the settings
            If My.Settings.ShowNotifications Then
                dialogResult = MessageBox.Show("Do you want to inform the developer about the extension '" & extension & "'?" & vbCrLf & vbCrLf & "This way it will be natively included in the next official release of this program.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            If dialogResult = DialogResult.Yes Then

                ' Add to "feedback" setting
                My.Settings.Feedback.Add(extension)

                ' Open default mail client
                Dim proc As New Process

                Try
                    proc.StartInfo.FileName = "mailto:batchrename@jonas-thelemann.de?subject=BatchRename: New Extension&body=Hello Jonas,%0A%0AI want to inform you about the fileextension '" & extension & "'!%0AIt would be nice to see this one natively included in the '" & type & "list' of BatchRename's next release.%0A%0AHave a nice day! :)"
                    proc.Start()
                Finally
                    proc.Dispose()
                End Try
            End If
        End If
    End Sub

    Private Sub BtnFiletypeOk_Click(sender As Object, e As EventArgs) Handles BtnFiletypeOk.Click

        ' Rebuild the list of chosen extensions
        FrmMain.PEnabledExtensions.Clear()

        For Each item As String In ClbIncludePictures.CheckedItems
            FrmMain.PEnabledExtensions.Add(item)
        Next

        For Each item As String In ClbIncludeDocuments.CheckedItems
            FrmMain.PEnabledExtensions.Add(item)
        Next

        For Each item As String In ClbIncludeMusic.CheckedItems
            FrmMain.PEnabledExtensions.Add(item)
        Next

        For Each item As String In ClbIncludeVideos.CheckedItems
            FrmMain.PEnabledExtensions.Add(item)
        Next

        ' Only proceed with at least one chosen extension
        If FrmMain.PEnabledExtensions.Count > 0 Then
            For Each item As String In ClbExcludeExceptions.CheckedItems
                FrmMain.PEnabledExtensions.Add(item)
            Next

            ' Rebuild the list of existing extensions
            My.Settings.ImageExtensions.Clear()
            My.Settings.DocumentExtensions.Clear()
            My.Settings.MusicExtensions.Clear()
            My.Settings.VideoExtensions.Clear()
            My.Settings.ExceptionExtensions.Clear()

            For Each item As String In ClbIncludePictures.Items
                My.Settings.ImageExtensions.Add(item)
            Next

            For Each item As String In ClbIncludeDocuments.Items
                My.Settings.DocumentExtensions.Add(item)
            Next

            For Each item As String In ClbIncludeMusic.Items
                My.Settings.MusicExtensions.Add(item)
            Next

            For Each item As String In ClbIncludeVideos.Items
                My.Settings.VideoExtensions.Add(item)
            Next

            For Each item As String In ClbExcludeExceptions.Items
                My.Settings.ExceptionExtensions.Add(item)
            Next

            Close()
        Else
            MessageBox.Show("You must include at least one extension!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ClbIncludePictures_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClbIncludePictures.SelectedIndexChanged

        ' Update and and remove groupboxes
        SelectedIndexChanged(0, ClbIncludePictures)
    End Sub

    Private Sub ClbIncludeDocuments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClbIncludeDocuments.SelectedIndexChanged

        ' Update and and remove groupboxes
        SelectedIndexChanged(1, ClbIncludeDocuments)
    End Sub

    Private Sub ClbIncludeMusic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClbIncludeMusic.SelectedIndexChanged

        ' Update and and remove groupboxes
        SelectedIndexChanged(2, ClbIncludeMusic)
    End Sub

    Private Sub ClbIncludeVideos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClbIncludeVideos.SelectedIndexChanged

        ' Update and and remove groupboxes
        SelectedIndexChanged(3, ClbIncludeVideos)
    End Sub

    Private Sub ClbExcludeExceptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClbExcludeExceptions.SelectedIndexChanged

        ' Update and and remove groupboxes
        SelectedIndexChanged(4, ClbExcludeExceptions)
    End Sub

    Private Sub SelectedIndexChanged(ByVal index As Integer, ByVal clb As CheckedListBox)

        ' Select the checkedlistbox that was clicked
        CmbAddCategory.SelectedIndex = index
        CmbRemoveCategory.SelectedIndex = index

        If clb.SelectedIndex <> -1 Then

            ' Select the extension that was clicked
            CmbRemoveExtension.SelectedIndex = clb.SelectedIndex
        Else

            ' Select the first extension
            CmbRemoveExtension.SelectedIndex = 0
        End If
    End Sub
End Class