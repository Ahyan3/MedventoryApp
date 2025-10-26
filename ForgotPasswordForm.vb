Imports Npgsql

Public Class ForgotPasswordForm
    ' Replace with your actual Supabase/PostgreSQL connection string
    Private connectionString As String = "Host=aws-1-ap-southeast-1.pooler.supabase.com;Username=postgres.okexwfjhcijqblmzzgxq;Password=DCsID1gqH6Egkv7p;Database=postgres"

    Private Sub ForgotPasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Forgot Password"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim newPassword As String = txtNewPassword.Text.Trim()

        If email = "" Or newPassword = "" Then
            lblMessage.Text = "Please fill in all fields."
            lblMessage.ForeColor = Color.Red
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE email = @Email"
                Using checkCmd As New NpgsqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@Email", email)
                    Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                    If count = 0 Then
                        lblMessage.Text = "Email not found."
                        lblMessage.ForeColor = Color.Red
                        Return
                    End If
                End Using

                Dim updateQuery As String = "UPDATE users SET password = @Password WHERE email = @Email"
                Using updateCmd As New NpgsqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@Password", newPassword)
                    updateCmd.Parameters.AddWithValue("@Email", email)
                    updateCmd.ExecuteNonQuery()
                End Using
            End Using

            lblMessage.Text = "Password reset successful!"
            lblMessage.ForeColor = Color.Green

        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
            lblMessage.ForeColor = Color.Red
        End Try
    End Sub
End Class
