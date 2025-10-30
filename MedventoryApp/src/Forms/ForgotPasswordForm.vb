Imports Npgsql
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text

Public Class ForgotPasswordForm
    ' 🧩 Database Connection (Supabase/PostgreSQL)
    Private connectionString As String = "Host=aws-1-ap-southeast-1.pooler.supabase.com;Username=postgres.okexwfjhcijqblmzzgxq;Password=DCsID1gqH6Egkv7p;Database=postgres"

    ' 📧 Email configuration
    Private senderEmail As String = "medventory.notification@gmail.com"
    Private senderPassword As String = "hbnn upxn suca shzb"
    Private superAdminEmail As String = "ahyanromano02@gmail.com" ' Super Admin email for approval

    Private Sub ForgotPasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Forgot Password"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        lblMessage.Text = ""
    End Sub

    ' 🔒 Secure SHA256 hashing for new passwords
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' 📩 Send confirmation email to the user
    Private Sub SendUserEmail(toEmail As String, fullName As String)
        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress(senderEmail, "Medventory Password System")
            mail.To.Add(toEmail)
            mail.Subject = "Password Reset Request Received"
            mail.Body =
$"Hello {fullName},

We received your password reset request.
Your request is currently pending approval from the Super Admin.

You’ll be notified once your password reset is approved.

Best regards,
Medventory Support Team"

            Dim smtp As New SmtpClient("smtp.gmail.com", 587)
            smtp.Credentials = New Net.NetworkCredential(senderEmail, senderPassword)
            smtp.EnableSsl = True
            smtp.Send(mail)

        Catch ex As Exception
            MessageBox.Show("Failed to send confirmation email: " & ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' 🧑‍💼 Notify Super Admin of a new password reset request
    Private Sub SendAdminEmail(userEmail As String, fullName As String)
        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress(senderEmail, "Medventory Password System")
            mail.To.Add(superAdminEmail)
            mail.Subject = "New Password Reset Request"
            mail.Body =
$"Dear Super Admin,

A new password reset request has been submitted:

Full Name: {fullName}
Email: {userEmail}
Request Date: {DateTime.Now}

Please log in to the admin panel to review and approve or reject this request.

Best regards,
Medventory Notification System"

            Dim smtp As New SmtpClient("smtp.gmail.com", 587)
            smtp.Credentials = New Net.NetworkCredential(senderEmail, senderPassword)
            smtp.EnableSsl = True
            smtp.Send(mail)

        Catch ex As Exception
            MessageBox.Show("Failed to notify Super Admin: " & ex.Message, "Admin Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' 📨 Notify medventory.notification Gmail about reset request
    Private Sub NotifySystemEmail(userEmail As String, fullName As String)
        Try
            Dim notifMail As New MailMessage()
            notifMail.From = New MailAddress(senderEmail, "Medventory Password System")
            notifMail.To.Add("medventory.notification@gmail.com")
            notifMail.Subject = "🔔 User Password Reset Request"
            notifMail.Body =
$"Dear Medventory Admin,

A user has submitted a password reset request and is waiting for verification.

Full Name: {fullName}
Email: {userEmail}
Request Date: {DateTime.Now:MM/dd/yyyy hh:mm:ss tt}

Please log in to the admin panel to approve or cancel this request.

Best regards,
Password Reset Notification System"

            Dim smtpNotif As New SmtpClient("smtp.gmail.com", 587)
            smtpNotif.Credentials = New Net.NetworkCredential(senderEmail, senderPassword)
            smtpNotif.EnableSsl = True
            smtpNotif.Send(notifMail)

        Catch ex As Exception
            MessageBox.Show("Failed to notify system admin: " & ex.Message, "Notification Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 🔘 Reset button click event
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim full_name As String = txtFullname.Text.Trim()
        Dim newPassword As String = txtNewPassword.Text.Trim()

        ' 🧾 Validate required fields
        If email = "" Or full_name = "" Or newPassword = "" Then
            lblMessage.Text = "Please fill in all fields."
            lblMessage.ForeColor = Color.Red
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' 🔍 Check if the last reset request was rejected
                Dim rejectCheckQuery As String = "
                    SELECT status FROM password_reset_requests 
                    WHERE email = @Email 
                    ORDER BY request_date DESC 
                    LIMIT 1;
                "
                Using rejectCmd As New NpgsqlCommand(rejectCheckQuery, conn)
                    rejectCmd.Parameters.AddWithValue("@Email", email)
                    Dim lastStatus As Object = rejectCmd.ExecuteScalar()

                    If lastStatus IsNot Nothing AndAlso lastStatus.ToString() = "Rejected" Then
                        MessageBox.Show("Your previous password reset request was rejected. Please contact the administrator before submitting another request.",
                                        "Request Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' ✅ Validate user
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

                ' 🔐 Hash new password
                Dim hashedPassword As String = HashPassword(newPassword)

                ' 🗂 Insert reset request for admin approval
                Dim insertQuery As String = "
                    INSERT INTO password_reset_requests (email, full_name, new_password, status, request_date)
                    VALUES (@Email, @Fullname, @NewPassword, 'Pending', NOW());
                "
                Using insertCmd As New NpgsqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@Email", email)
                    insertCmd.Parameters.AddWithValue("@Fullname", full_name)
                    insertCmd.Parameters.AddWithValue("@NewPassword", hashedPassword)
                    insertCmd.ExecuteNonQuery()
                End Using
            End Using

            ' ------------------------------------------
            ' 📩 Notify Admin that a user requested a password reset
            ' ------------------------------------------
            Try
                Dim notifMail As New MailMessage()
                notifMail.From = New MailAddress(senderEmail, "Medventory Notification")
                notifMail.Subject = "🔔 Password Reset Request Alert"
                notifMail.Body = $"A user has requested a password reset." & vbCrLf & vbCrLf &
                     $"👤 Username: {full_name}" & vbCrLf &
                     $"📧 Email: {email}" & vbCrLf &
                     $"🕒 Time: {DateTime.Now}" & vbCrLf & vbCrLf &
                     $"Please review this request in the admin panel (approve or reject)."

                ' ✅ Use BCC to send a copy to the same account — keeps a record in Sent
                notifMail.Bcc.Add(senderEmail)
                notifMail.To.Add(superAdminEmail)

                Dim smtpNotif As New SmtpClient("smtp.gmail.com", 587)
                smtpNotif.Credentials = New Net.NetworkCredential(senderEmail, senderPassword)
                smtpNotif.EnableSsl = True

                smtpNotif.Send(notifMail)

                ' ✅ Bonus confirmation popup
                MessageBox.Show("Notification email successfully sent to system Gmail and Super Admin.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("⚠️ Failed to send admin notification: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' ✉️ Send emails only if address looks valid
            If email.Contains("@") Then
                SendUserEmail(email, full_name)
                SendAdminEmail(email, full_name)
                NotifySystemEmail(email, full_name)
            End If

            lblMessage.Text = "Password reset request sent. Please wait for Super Admin approval."
            lblMessage.ForeColor = Color.Green

            MessageBox.Show("Your password reset request has been sent. You’ll receive an email once approved.",
                            "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtEmail.Clear()
            txtFullname.Clear()
            txtNewPassword.Clear()

        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
            lblMessage.ForeColor = Color.Red
        End Try
    End Sub

    ' 🔙 Back to Login button
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub
End Class
