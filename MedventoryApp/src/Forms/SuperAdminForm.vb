Imports System.Reflection.Emit

Public Class SuperAdmin
    Private Sub SuperAdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Super Admin"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        TabControl1.SelectedTab = TabPage4
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        TabControl1.SelectedTab = TabPage5
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        TabControl1.SelectedTab = TabPage6
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        ' Logout user
        MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close the current form (e.g., Dashboard)
        Hide()

        ' Show login form again
        Login.Show()
    End Sub

End Class
