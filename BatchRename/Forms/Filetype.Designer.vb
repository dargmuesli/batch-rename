<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiletype
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiletype))
        Me.ClbIncludeDocuments = New System.Windows.Forms.CheckedListBox()
        Me.ClbIncludeVideos = New System.Windows.Forms.CheckedListBox()
        Me.ClbExcludeExceptions = New System.Windows.Forms.CheckedListBox()
        Me.ClbIncludeMusic = New System.Windows.Forms.CheckedListBox()
        Me.ClbIncludePictures = New System.Windows.Forms.CheckedListBox()
        Me.LblIncludePictures = New System.Windows.Forms.Label()
        Me.LblIncludeMusic = New System.Windows.Forms.Label()
        Me.LblIncludeVideos = New System.Windows.Forms.Label()
        Me.LblExcludeExceptions = New System.Windows.Forms.Label()
        Me.LblIncludeDocuments = New System.Windows.Forms.Label()
        Me.GrpFiletypeInclude = New System.Windows.Forms.GroupBox()
        Me.GrpFiletypeExclude = New System.Windows.Forms.GroupBox()
        Me.lblFiletypeDescription = New System.Windows.Forms.Label()
        Me.TxbAddExtension = New System.Windows.Forms.TextBox()
        Me.CmbAddCategory = New System.Windows.Forms.ComboBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.GrpFiletypeAdd = New System.Windows.Forms.GroupBox()
        Me.GrpFiletypeRemove = New System.Windows.Forms.GroupBox()
        Me.CmbRemoveExtension = New System.Windows.Forms.ComboBox()
        Me.CmbRemoveCategory = New System.Windows.Forms.ComboBox()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.BtnFiletypeOk = New System.Windows.Forms.Button()
        Me.BtnFiletypeCancel = New System.Windows.Forms.Button()
        Me.BtnFiletypeAll = New System.Windows.Forms.Button()
        Me.BtnFiletypeNone = New System.Windows.Forms.Button()
        Me.GrpFiletypeInclude.SuspendLayout()
        Me.GrpFiletypeExclude.SuspendLayout()
        Me.GrpFiletypeAdd.SuspendLayout()
        Me.GrpFiletypeRemove.SuspendLayout()
        Me.SuspendLayout()
        '
        'ClbIncludeDocuments
        '
        Me.ClbIncludeDocuments.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ClbIncludeDocuments.FormattingEnabled = True
        Me.ClbIncludeDocuments.Location = New System.Drawing.Point(105, 46)
        Me.ClbIncludeDocuments.Name = "ClbIncludeDocuments"
        Me.ClbIncludeDocuments.Size = New System.Drawing.Size(81, 184)
        Me.ClbIncludeDocuments.Sorted = True
        Me.ClbIncludeDocuments.TabIndex = 3
        '
        'ClbIncludeVideos
        '
        Me.ClbIncludeVideos.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ClbIncludeVideos.FormattingEnabled = True
        Me.ClbIncludeVideos.Location = New System.Drawing.Point(282, 46)
        Me.ClbIncludeVideos.Name = "ClbIncludeVideos"
        Me.ClbIncludeVideos.Size = New System.Drawing.Size(81, 184)
        Me.ClbIncludeVideos.Sorted = True
        Me.ClbIncludeVideos.TabIndex = 7
        '
        'ClbExcludeExceptions
        '
        Me.ClbExcludeExceptions.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ClbExcludeExceptions.FormattingEnabled = True
        Me.ClbExcludeExceptions.Location = New System.Drawing.Point(17, 46)
        Me.ClbExcludeExceptions.Name = "ClbExcludeExceptions"
        Me.ClbExcludeExceptions.Size = New System.Drawing.Size(81, 184)
        Me.ClbExcludeExceptions.Sorted = True
        Me.ClbExcludeExceptions.TabIndex = 1
        '
        'ClbIncludeMusic
        '
        Me.ClbIncludeMusic.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ClbIncludeMusic.FormattingEnabled = True
        Me.ClbIncludeMusic.Location = New System.Drawing.Point(193, 46)
        Me.ClbIncludeMusic.Name = "ClbIncludeMusic"
        Me.ClbIncludeMusic.Size = New System.Drawing.Size(81, 184)
        Me.ClbIncludeMusic.Sorted = True
        Me.ClbIncludeMusic.TabIndex = 5
        '
        'ClbIncludePictures
        '
        Me.ClbIncludePictures.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ClbIncludePictures.FormattingEnabled = True
        Me.ClbIncludePictures.Location = New System.Drawing.Point(18, 46)
        Me.ClbIncludePictures.Name = "ClbIncludePictures"
        Me.ClbIncludePictures.Size = New System.Drawing.Size(81, 184)
        Me.ClbIncludePictures.Sorted = True
        Me.ClbIncludePictures.TabIndex = 1
        '
        'LblIncludePictures
        '
        Me.LblIncludePictures.AutoSize = True
        Me.LblIncludePictures.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblIncludePictures.Location = New System.Drawing.Point(32, 24)
        Me.LblIncludePictures.Name = "LblIncludePictures"
        Me.LblIncludePictures.Size = New System.Drawing.Size(53, 19)
        Me.LblIncludePictures.TabIndex = 0
        Me.LblIncludePictures.Text = "Pictures"
        '
        'LblIncludeMusic
        '
        Me.LblIncludeMusic.AutoSize = True
        Me.LblIncludeMusic.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblIncludeMusic.Location = New System.Drawing.Point(211, 24)
        Me.LblIncludeMusic.Name = "LblIncludeMusic"
        Me.LblIncludeMusic.Size = New System.Drawing.Size(45, 19)
        Me.LblIncludeMusic.TabIndex = 4
        Me.LblIncludeMusic.Text = "Music"
        '
        'LblIncludeVideos
        '
        Me.LblIncludeVideos.AutoSize = True
        Me.LblIncludeVideos.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblIncludeVideos.Location = New System.Drawing.Point(297, 24)
        Me.LblIncludeVideos.Name = "LblIncludeVideos"
        Me.LblIncludeVideos.Size = New System.Drawing.Size(50, 19)
        Me.LblIncludeVideos.TabIndex = 6
        Me.LblIncludeVideos.Text = "Videos"
        '
        'LblExcludeExceptions
        '
        Me.LblExcludeExceptions.AutoSize = True
        Me.LblExcludeExceptions.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblExcludeExceptions.Location = New System.Drawing.Point(21, 24)
        Me.LblExcludeExceptions.Name = "LblExcludeExceptions"
        Me.LblExcludeExceptions.Size = New System.Drawing.Size(73, 19)
        Me.LblExcludeExceptions.TabIndex = 0
        Me.LblExcludeExceptions.Text = "Exceptions"
        '
        'LblIncludeDocuments
        '
        Me.LblIncludeDocuments.AutoSize = True
        Me.LblIncludeDocuments.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblIncludeDocuments.Location = New System.Drawing.Point(106, 24)
        Me.LblIncludeDocuments.Name = "LblIncludeDocuments"
        Me.LblIncludeDocuments.Size = New System.Drawing.Size(79, 19)
        Me.LblIncludeDocuments.TabIndex = 2
        Me.LblIncludeDocuments.Text = "Documents"
        '
        'GrpFiletypeInclude
        '
        Me.GrpFiletypeInclude.Controls.Add(Me.ClbIncludePictures)
        Me.GrpFiletypeInclude.Controls.Add(Me.ClbIncludeMusic)
        Me.GrpFiletypeInclude.Controls.Add(Me.LblIncludeDocuments)
        Me.GrpFiletypeInclude.Controls.Add(Me.ClbIncludeVideos)
        Me.GrpFiletypeInclude.Controls.Add(Me.ClbIncludeDocuments)
        Me.GrpFiletypeInclude.Controls.Add(Me.LblIncludeVideos)
        Me.GrpFiletypeInclude.Controls.Add(Me.LblIncludePictures)
        Me.GrpFiletypeInclude.Controls.Add(Me.LblIncludeMusic)
        Me.GrpFiletypeInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpFiletypeInclude.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GrpFiletypeInclude.Location = New System.Drawing.Point(12, 49)
        Me.GrpFiletypeInclude.Name = "GrpFiletypeInclude"
        Me.GrpFiletypeInclude.Size = New System.Drawing.Size(375, 250)
        Me.GrpFiletypeInclude.TabIndex = 3
        Me.GrpFiletypeInclude.TabStop = False
        Me.GrpFiletypeInclude.Text = "Include"
        '
        'GrpFiletypeExclude
        '
        Me.GrpFiletypeExclude.Controls.Add(Me.ClbExcludeExceptions)
        Me.GrpFiletypeExclude.Controls.Add(Me.LblExcludeExceptions)
        Me.GrpFiletypeExclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpFiletypeExclude.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GrpFiletypeExclude.Location = New System.Drawing.Point(393, 49)
        Me.GrpFiletypeExclude.Name = "GrpFiletypeExclude"
        Me.GrpFiletypeExclude.Size = New System.Drawing.Size(116, 250)
        Me.GrpFiletypeExclude.TabIndex = 4
        Me.GrpFiletypeExclude.TabStop = False
        Me.GrpFiletypeExclude.Text = "Exclude"
        '
        'lblFiletypeDescription
        '
        Me.lblFiletypeDescription.AutoSize = True
        Me.lblFiletypeDescription.Location = New System.Drawing.Point(12, 18)
        Me.lblFiletypeDescription.Name = "lblFiletypeDescription"
        Me.lblFiletypeDescription.Size = New System.Drawing.Size(250, 19)
        Me.lblFiletypeDescription.TabIndex = 0
        Me.lblFiletypeDescription.Text = "Choose which file extensions to include:"
        '
        'TxbAddExtension
        '
        Me.TxbAddExtension.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxbAddExtension.ForeColor = System.Drawing.SystemColors.GrayText
        Me.TxbAddExtension.Location = New System.Drawing.Point(47, 24)
        Me.TxbAddExtension.Name = "TxbAddExtension"
        Me.TxbAddExtension.Size = New System.Drawing.Size(81, 25)
        Me.TxbAddExtension.TabIndex = 0
        Me.TxbAddExtension.Text = ".xyz"
        '
        'CmbAddCategory
        '
        Me.CmbAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbAddCategory.FormattingEnabled = True
        Me.CmbAddCategory.Items.AddRange(New Object() {"Pictures", "Documents", "Music", "Videos", "Exceptions"})
        Me.CmbAddCategory.Location = New System.Drawing.Point(6, 55)
        Me.CmbAddCategory.Name = "CmbAddCategory"
        Me.CmbAddCategory.Size = New System.Drawing.Size(163, 25)
        Me.CmbAddCategory.TabIndex = 1
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.BackgroundImage = CType(resources.GetObject("BtnAdd.BackgroundImage"), System.Drawing.Image)
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAdd.Location = New System.Drawing.Point(175, 15)
        Me.BtnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(65, 65)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpFiletypeAdd
        '
        Me.GrpFiletypeAdd.Controls.Add(Me.CmbAddCategory)
        Me.GrpFiletypeAdd.Controls.Add(Me.TxbAddExtension)
        Me.GrpFiletypeAdd.Controls.Add(Me.BtnAdd)
        Me.GrpFiletypeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpFiletypeAdd.Location = New System.Drawing.Point(12, 305)
        Me.GrpFiletypeAdd.Name = "GrpFiletypeAdd"
        Me.GrpFiletypeAdd.Size = New System.Drawing.Size(246, 90)
        Me.GrpFiletypeAdd.TabIndex = 5
        Me.GrpFiletypeAdd.TabStop = False
        Me.GrpFiletypeAdd.Text = "Add"
        '
        'GrpFiletypeRemove
        '
        Me.GrpFiletypeRemove.Controls.Add(Me.CmbRemoveExtension)
        Me.GrpFiletypeRemove.Controls.Add(Me.CmbRemoveCategory)
        Me.GrpFiletypeRemove.Controls.Add(Me.BtnRemove)
        Me.GrpFiletypeRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpFiletypeRemove.Location = New System.Drawing.Point(263, 305)
        Me.GrpFiletypeRemove.Name = "GrpFiletypeRemove"
        Me.GrpFiletypeRemove.Size = New System.Drawing.Size(246, 90)
        Me.GrpFiletypeRemove.TabIndex = 6
        Me.GrpFiletypeRemove.TabStop = False
        Me.GrpFiletypeRemove.Text = "Remove"
        '
        'CmbRemoveExtension
        '
        Me.CmbRemoveExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbRemoveExtension.FormattingEnabled = True
        Me.CmbRemoveExtension.Items.AddRange(New Object() {"Pictures", "Documents", "Music", "Videos", "Exceptions"})
        Me.CmbRemoveExtension.Location = New System.Drawing.Point(47, 55)
        Me.CmbRemoveExtension.Name = "CmbRemoveExtension"
        Me.CmbRemoveExtension.Size = New System.Drawing.Size(81, 25)
        Me.CmbRemoveExtension.TabIndex = 1
        '
        'CmbRemoveCategory
        '
        Me.CmbRemoveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbRemoveCategory.FormattingEnabled = True
        Me.CmbRemoveCategory.Items.AddRange(New Object() {"Pictures", "Documents", "Music", "Videos", "Exceptions"})
        Me.CmbRemoveCategory.Location = New System.Drawing.Point(6, 24)
        Me.CmbRemoveCategory.Name = "CmbRemoveCategory"
        Me.CmbRemoveCategory.Size = New System.Drawing.Size(163, 25)
        Me.CmbRemoveCategory.TabIndex = 0
        '
        'BtnRemove
        '
        Me.BtnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemove.BackgroundImage = Global.BatchRename.My.Resources.Resources.No
        Me.BtnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRemove.FlatAppearance.BorderSize = 0
        Me.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnRemove.Location = New System.Drawing.Point(175, 15)
        Me.BtnRemove.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(65, 65)
        Me.BtnRemove.TabIndex = 2
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnFiletypeOk
        '
        Me.BtnFiletypeOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiletypeOk.Location = New System.Drawing.Point(158, 402)
        Me.BtnFiletypeOk.Name = "BtnFiletypeOk"
        Me.BtnFiletypeOk.Size = New System.Drawing.Size(100, 30)
        Me.BtnFiletypeOk.TabIndex = 7
        Me.BtnFiletypeOk.Text = "OK"
        Me.BtnFiletypeOk.UseVisualStyleBackColor = True
        '
        'BtnFiletypeCancel
        '
        Me.BtnFiletypeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnFiletypeCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiletypeCancel.Location = New System.Drawing.Point(263, 402)
        Me.BtnFiletypeCancel.Name = "BtnFiletypeCancel"
        Me.BtnFiletypeCancel.Size = New System.Drawing.Size(100, 30)
        Me.BtnFiletypeCancel.TabIndex = 8
        Me.BtnFiletypeCancel.Text = "Cancel"
        Me.BtnFiletypeCancel.UseVisualStyleBackColor = True
        '
        'BtnFiletypeAll
        '
        Me.BtnFiletypeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiletypeAll.Location = New System.Drawing.Point(323, 11)
        Me.BtnFiletypeAll.Name = "BtnFiletypeAll"
        Me.BtnFiletypeAll.Size = New System.Drawing.Size(90, 30)
        Me.BtnFiletypeAll.TabIndex = 1
        Me.BtnFiletypeAll.Text = "Select all"
        Me.BtnFiletypeAll.UseVisualStyleBackColor = True
        '
        'BtnFiletypeNone
        '
        Me.BtnFiletypeNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiletypeNone.Location = New System.Drawing.Point(419, 11)
        Me.BtnFiletypeNone.Name = "BtnFiletypeNone"
        Me.BtnFiletypeNone.Size = New System.Drawing.Size(90, 30)
        Me.BtnFiletypeNone.TabIndex = 2
        Me.BtnFiletypeNone.Text = "Select none"
        Me.BtnFiletypeNone.UseVisualStyleBackColor = True
        '
        'FrmFiletype
        '
        Me.AcceptButton = Me.BtnFiletypeOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnFiletypeCancel
        Me.ClientSize = New System.Drawing.Size(524, 437)
        Me.Controls.Add(Me.BtnFiletypeNone)
        Me.Controls.Add(Me.BtnFiletypeAll)
        Me.Controls.Add(Me.BtnFiletypeCancel)
        Me.Controls.Add(Me.BtnFiletypeOk)
        Me.Controls.Add(Me.GrpFiletypeRemove)
        Me.Controls.Add(Me.GrpFiletypeAdd)
        Me.Controls.Add(Me.lblFiletypeDescription)
        Me.Controls.Add(Me.GrpFiletypeExclude)
        Me.Controls.Add(Me.GrpFiletypeInclude)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFiletype"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "File Types"
        Me.TopMost = True
        Me.GrpFiletypeInclude.ResumeLayout(False)
        Me.GrpFiletypeInclude.PerformLayout()
        Me.GrpFiletypeExclude.ResumeLayout(False)
        Me.GrpFiletypeExclude.PerformLayout()
        Me.GrpFiletypeAdd.ResumeLayout(False)
        Me.GrpFiletypeAdd.PerformLayout()
        Me.GrpFiletypeRemove.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ClbIncludeDocuments As CheckedListBox
    Friend WithEvents ClbIncludeVideos As CheckedListBox
    Friend WithEvents ClbExcludeExceptions As CheckedListBox
    Friend WithEvents ClbIncludeMusic As CheckedListBox
    Friend WithEvents ClbIncludePictures As CheckedListBox
    Friend WithEvents LblIncludePictures As Label
    Friend WithEvents LblIncludeMusic As Label
    Friend WithEvents LblIncludeVideos As Label
    Friend WithEvents LblExcludeExceptions As Label
    Friend WithEvents LblIncludeDocuments As Label
    Friend WithEvents GrpFiletypeInclude As GroupBox
    Friend WithEvents GrpFiletypeExclude As GroupBox
    Friend WithEvents lblFiletypeDescription As Label
    Friend WithEvents TxbAddExtension As TextBox
    Friend WithEvents CmbAddCategory As ComboBox
    Friend WithEvents BtnAdd As Button
    Friend WithEvents GrpFiletypeAdd As GroupBox
    Friend WithEvents GrpFiletypeRemove As GroupBox
    Friend WithEvents CmbRemoveCategory As ComboBox
    Friend WithEvents BtnRemove As Button
    Friend WithEvents CmbRemoveExtension As ComboBox
    Friend WithEvents BtnFiletypeOk As Button
    Friend WithEvents BtnFiletypeCancel As Button
    Friend WithEvents BtnFiletypeAll As Button
    Friend WithEvents BtnFiletypeNone As Button
End Class
