﻿'
' Screen Share Utility -> Class FORM1
' Author: Bobby Georgiou
' Date: 2015
'
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ServerScreen1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClientScreen1.Show()
    End Sub
End Class
