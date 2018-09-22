'
' Screen Share Utility -> Class CLIENTSCREEN1
' Author: Bobby Georgiou
' Date: 2015
'
Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary

Public Class ClientScreen1

    Dim client As New TcpClient
    Dim ns As NetworkStream
    Dim port As Integer

    Public Function Desktop() As Image
        Dim bounds As Rectangle = Nothing
        Dim screenshot As System.Drawing.Bitmap = Nothing
        Dim graph As Graphics = Nothing
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Return screenshot
    End Function

    Private Sub SendDesktop()
        Dim bf As BinaryFormatter = New BinaryFormatter
        ns = client.GetStream
        bf.Serialize(ns, Desktop())
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        port = Integer.Parse(TextBox2.Text)
        Try
            client.Connect(TextBox1.Text, port)
            MsgBox("Connected")
        Catch ex As Exception
            MsgBox("Failed to connect" & vbCrLf & vbCrLf & "Message: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendDesktop()
    End Sub
End Class