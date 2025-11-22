Imports System.Configuration
Imports System.Net
Imports System.Net.Mail
Imports Npgsql

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
        Dim selectedRoleObj = cmbRole.SelectedItem
        If selectedRoleObj Is Nothing Then
            MessageBox.Show("Please select a role.")
            Return
        End If

        Dim selectedRole As String = selectedRoleObj.ToString()
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
    Private Sub SendInvitationEmail(recipientEmail As String, fullName As String)
        Try
            ' 🔐 Load from app.config
            Dim senderEmail As String = ConfigurationManager.AppSettings("SenderEmail")
            Dim senderPassword As String = ConfigurationManager.AppSettings("SenderPassword")

            ' ✉️ Email setup
            Dim mail As New MailMessage()
            mail.From = New MailAddress(senderEmail, "Medventory Admin")
            mail.To.Add(recipientEmail)
            mail.Subject = "You're Invited to Medventory"
            mail.Body =
            $"Hello {fullName}," & vbCrLf & vbCrLf &
            "You have been added to the Medventory System by the Super Admin." & vbCrLf &
            "Your temporary password is: temporary123" & vbCrLf &
            "Please change it immediately after your first login." & vbCrLf & vbCrLf &
            "Welcome aboard!" & vbCrLf

            ' 🌐 Gmail SMTP configuration
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.EnableSsl = True

            ' 🔐 REQUIRED: Gmail App Password authentication
            smtp.Credentials = New NetworkCredential(senderEmail, senderPassword)

            ' 🚀 Send email
            smtp.Send(mail)

        Catch ex As Exception
            MessageBox.Show("Error sending email: " & ex.Message)
        End Try
    End Sub

    ' ✔ Email format validator
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr As New MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

End Class
