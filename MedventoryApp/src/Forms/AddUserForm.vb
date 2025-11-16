Imports Npgsql
Imports System.Net.Mail

Public Class AddUserForm
    Private ReadOnly connectionString As String

    Public Sub New(connStr As String)
        InitializeComponent()
        connectionString = connStr
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRole.Items.AddRange({"Super Admin", "Admin", "Doctor", "Pharmacist"})
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim name = txtFullName.Text.Trim()
        Dim email = txtEmail.Text.Trim()
        Dim selectedRole = cmbRole.SelectedItem?.ToString()

        Dim role As String = selectedRole.ToLower().Replace(" ", "_")

        If name = "" Or email = "" Or role Is Nothing Then
            MessageBox.Show("Please fill all fields.")
            Return
        End If

        ' 🔍 Email format validation
        If Not IsValidEmail(email) Then
            MessageBox.Show("Invalid email format. Please enter a valid email.")
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                    INSERT INTO users (id, full_name, email, password, role)
                    VALUES (gen_random_uuid(), @Name, @Email, ENCODE(DIGEST('temporary123', 'sha256'), 'hex'), @Role)
                "
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' ✉️ Send Invitation Email
            SendInvitationEmail(email, name)

            MessageBox.Show("User added and invitation sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error adding user: " & ex.Message)
        End Try
    End Sub

    Private Sub SendInvitationEmail(email As String, fullName As String)
        Try
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.Credentials = New Net.NetworkCredential("YOUR_EMAIL@gmail.com", "YOUR_APP_PASSWORD")
            smtp.EnableSsl = True

            Dim mail As New MailMessage()
            mail.From = New MailAddress("YOUR_EMAIL@gmail.com", "Medventory Admin")
            mail.To.Add(email)
            mail.Subject = "You're Invited to Medventory"
            mail.Body = $"Hello {fullName}," & vbCrLf &
                        "You have been invited to Medventory by the Super Admin." & vbCrLf &
                        "Use the temporary password 'temporary123' to log in and change it immediately." & vbCrLf &
                        "Welcome aboard!"

            smtp.Send(mail)
        Catch ex As Exception
            MessageBox.Show("Error sending email: " & ex.Message)
        End Try
    End Sub

    'Validate Email Format
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr As New MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

End Class
