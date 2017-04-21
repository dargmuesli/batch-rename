Public Class CustomTimer
    Private WithEvents timer As New Timer
    Private pCurrentTime As Integer = 0
    Private pStartValue As Integer = 0
    Private pChangeValue As Integer = 0
    Private pDuration As Integer = 50
    Private pAxis As String = ""

    Public Sub New(interval As Integer, startValue As Integer, changeValue As Integer, axis As String)

        ' Create a new timer given properties
        timer = New Timer
        timer.Interval = interval
        pStartValue = startValue
        pChangeValue = changeValue
        pAxis = axis
    End Sub

    Private Sub Timer_Tick() Handles timer.Tick

        ' Go one step along the time axis
        pCurrentTime = pCurrentTime + 1

        If (pAxis = "x") Then

            ' Show or hide the settings
            FrmMain.PnlMainBox.Location = New Point(EaseInOutCubic(pCurrentTime, pStartValue, pChangeValue, pDuration), FrmMain.PnlMainBox.Location.Y)
        Else

            ' Show the next or previous page
            FrmMain.PnlMainBox.Location = New Point(FrmMain.PnlMainBox.Location.X, EaseInOutCubic(pCurrentTime, pStartValue, pChangeValue, pDuration))

            ' Reposition the "settings" page
            FrmMain.PnlBoxSettings.Location = New Point(FrmMain.PnlBoxSettings.Location.X, -pStartValue - pChangeValue)
        End If

        ' Stop at 50 ticks
        If (pCurrentTime = 50) Then
            StopTimer()
        End If
    End Sub

    Public Sub StartTimer()

        ' Start the timer
        timer.Start()
    End Sub

    Public Sub StopTimer()

        ' Stop the timer
        timer.Stop()
    End Sub
End Class