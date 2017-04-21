'Imports System.Text.RegularExpressions

Public Class Trash

    ' Check if filename contains a suffix
    'Dim regex As Regex = New Regex(".+_.+\..+")
    'Dim match As Match = regex.Match(element.Name)

    'If match.Success Then
    '    'MinifyFilename(name, regex, match, element, targetName)
    'End If


    'Private Sub MinifyFilename(ByRef newName As String, ByRef regex As Regex, ByRef match As Match, ByRef element As FileInfo, ByRef finalName As String)

    '    ' Isolate the suffix
    '    Dim nameParts = Split(newName, "_")
    '    Dim suffix = nameParts(nameParts.Count() - 1).Remove(nameParts(nameParts.Count() - 1).IndexOf(".", StringComparison.Ordinal))

    '    ' Check if it's a correct suffix
    '    regex = New Regex("^\d+$")
    '    match = regex.Match(suffix)

    '    If match.Success Then

    '        ' Derive the original name without suffixnumber
    '        Dim originalName = newName.Remove(newName.LastIndexOf("_" & suffix, StringComparison.Ordinal)) & element.Extension
    '        Dim originalFullName = element.DirectoryName & "\" & originalName

    '        If element.Name <> newName Then

    '            ' Search for the lowest possible suffixnumber
    '            nameParts = Split(originalFullName, ".")
    '            Dim i As Integer = 1

    '            If File.Exists(originalFullName) Then
    '                Do
    '                    i += 1
    '                    originalFullName = nameParts(0) & "_" & i & "." & nameParts(1)
    '                Loop Until Not File.Exists(originalFullName)

    '                nameParts = Split(originalFullName, "\")
    '                originalName = nameParts(nameParts.Count() - 1)
    '            End If

    '            ' Rename the files to their most basic name
    '            My.Computer.FileSystem.RenameFile(element.DirectoryName & "\" & newName, originalName)

    '            If File.Exists(element.DirectoryName & "\" & newName & ".uid-zps") Then
    '                My.Computer.FileSystem.RenameFile(element.FullName & ".uid-zps", originalName & ".uid-zps")
    '            End If
    '        End If

    '        ' Log the current final name
    '        finalName = element.DirectoryName & "\" & newName
    '        finalName = finalName.Remove(0, TxbFolderSource.Text.Length)
    '    End If
    'End Sub
End Class
