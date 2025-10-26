Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open the Login Form
        Dim login As New Login()
        login.Show()

        ' Optionally hide this form so only the login shows
        Me.Hide()
    End Sub
End Class
