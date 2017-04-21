Imports System.Globalization
Imports System.Threading

Public NotInheritable Class FrmSplashscreen
    Private Sub FrmSplashscreen_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Populate version and copyright information on the splashscreen
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US", True)

        LblSplashscreenVersion.Text = String.Format(CultureInfo.CurrentCulture, "Version {0}", My.Application.Info.Version)
        LblSplashscreenCopyright.Text = My.Application.Info.Copyright
    End Sub
End Class
