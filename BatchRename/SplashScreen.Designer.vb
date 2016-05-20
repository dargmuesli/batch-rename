<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSplashscreen
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplashscreen))
        Me.LblSplashscreenVersion = New System.Windows.Forms.Label()
        Me.LblSplashscreenCopyright = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblSplashscreenVersion
        '
        resources.ApplyResources(Me.LblSplashscreenVersion, "LblSplashscreenVersion")
        Me.LblSplashscreenVersion.Name = "LblSplashscreenVersion"
        '
        'LblSplashscreenCopyright
        '
        resources.ApplyResources(Me.LblSplashscreenCopyright, "LblSplashscreenCopyright")
        Me.LblSplashscreenCopyright.Name = "LblSplashscreenCopyright"
        '
        'FrmSplashscreen
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.BatchRename.My.Resources.Resources.Splashscreen
        Me.ControlBox = False
        Me.Controls.Add(Me.LblSplashscreenCopyright)
        Me.Controls.Add(Me.LblSplashscreenVersion)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSplashscreen"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblSplashscreenVersion As Label
    Friend WithEvents LblSplashscreenCopyright As Label
End Class
