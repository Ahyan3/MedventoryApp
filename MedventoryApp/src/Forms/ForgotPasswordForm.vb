Imports Npgsql

Public Class ForgotPasswordForm
    ' Your Supabase/PostgreSQL connection string
    Private connectionString As String = "Host=aws-1-ap-southeast-1.pooler.supabase.com;Username=postgres.okexwfjhcijqblmzzgxq;Password=DCsID1gqH6Egkv7p;Database=postgres"

    Private Sub ForgotPasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Forgot Password"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim full_name As String = txtFullname.Text.Trim()
        Dim newPassword As String = txtNewPassword.Text.Trim()

        ' Validate empty fields
        If email = "" Or full_name = "" Or newPassword = "" Then
            lblMessage.Text = "Please fill in all fields."
            lblMessage.ForeColor = Color.Red
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' ✅ Step 1: Check if email and full name match an existing user
                Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE email = @Email AND full_name = @Fullname"
                Using checkCmd As New NpgsqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@Email", email)
                    checkCmd.Parameters.AddWithValue("@Fullname", full_name)
                    Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                    If count = 0 Then
                        lblMessage.Text = "Email and full name do not match our records."
                        lblMessage.ForeColor = Color.Red
                        Return
                    End If
                End Using

                ' ✅ Step 2: Insert a password reset request instead of changing immediately
                ' (So Super Admin can approve it later)
                Dim insertQuery As String = "
                    INSERT INTO password_reset_requests (email, full_name, new_password, status, request_date)
                    VALUES (@Email, @Fullname, @NewPassword, 'Pending', NOW());
                "
                Using insertCmd As New NpgsqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@Email", email)
                    insertCmd.Parameters.AddWithValue("@Fullname", full_name)
                    insertCmd.Parameters.AddWithValue("@NewPassword", newPassword)
                    insertCmd.ExecuteNonQuery()
                End Using
            End Using

            ' ✅ Step 3: Notify user
            lblMessage.Text = "Password reset request sent. Please wait for Super Admin approval."
            lblMessage.ForeColor = Color.Green

            MessageBox.Show("Your password reset request has been sent. Please wait for the Super Admin to approve it before you can log in.",
                            "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Optional: Clear the form
            txtEmail.Clear()
            txtFullname.Clear()
            txtNewPassword.Clear()

        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
            lblMessage.ForeColor = Color.Red
        End Try
    End Sub
End Class
