'
' Screen Share Utility -> Class SERVERSCREEN2
' Author: Bobby Georgiou
' Date: 2015
'
Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary

Public Class ServerScreen2

    Dim client As New TcpClient
    Dim port As Integer
    Dim server As TcpListener
    Dim ns As NetworkStream
    Dim listening As New Thread(AddressOf Listen)
    Dim GetImage As New Thread(AddressOf ReceiveImage)
    Dim NEWSTR As String

    Function ReceiveImage() As Image
        Dim bf As New BinaryFormatter
        While client.Connected = True
            ns = client.GetStream
            ReceiveImage = bf.Deserialize(ns)
            PictureBox1.Image = ReceiveImage

        End While
    End Function

    Private Sub Listen()
        While client.Connected = False
            server.Start()
            client = server.AcceptTcpClient
        End While
        GetImage.Start()
    End Sub

    Private Sub ServerScreen2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        port = Integer.Parse(ServerScreen1.TextBox1.Text)
        server = New TcpListener(port)
        listening.Start()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        TextBox1.Text = e.ProgressPercentage.ToString
    End Sub
End Class