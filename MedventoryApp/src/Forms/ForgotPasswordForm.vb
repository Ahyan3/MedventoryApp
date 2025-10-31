Imports Npgsql
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports System.Configuration
Imports System.Threading.Tasks

Public Class ForgotPasswordForm

    ' 🧩 Database Connection (Supabase/PostgreSQL)
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("SupabaseConnection").ConnectionString

    ' 📧 Email Configuration (Stored in App.config for Security)
    Private ReadOnly senderEmail As String = ConfigurationManager.AppSettings("SenderEmail")
    Private ReadOnly senderPassword As String = ConfigurationManager.AppSettings("SenderPassword")
    Private ReadOnly superAdminEmail As String = ConfigurationManager.AppSettings("SuperAdminEmail")

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
            Return BitConverter.ToString(bytes).Replace("-", "").ToLower()
        End Using
    End Function

    ' 📨 Centralized email sender (async)
    Private Async Function SendEmailAsync(toEmail As String, subject As String, body As String, Optional bcc As String = Nothing) As Task(Of Boolean)
        Try
            Using mail As New MailMessage()
                mail.From = New MailAddress(senderEmail, "Medventory Password System")
                mail.To.Add(toEmail)
                If Not String.IsNullOrEmpty(bcc) Then mail.Bcc.Add(bcc)
                mail.Subject = subject
                mail.Body = body

                Using smtp As New SmtpClient("smtp.gmail.com", 587)
                    smtp.Credentials = New Net.NetworkCredential(senderEmail, senderPassword)
                    smtp.EnableSsl = True
                    Await smtp.SendMailAsync(mail)
                End Using
            End Using
            Return True
        Catch ex As Exception
            LogNotification(toEmail, "", "Email Failed", "System", "Failed", ex.Message)
            Return False
        End Try
    End Function

    ' 🧾 Logs all notifications to database
    Private Sub LogNotification(email As String, fullName As String, notifType As String, sentTo As String, status As String, message As String)
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                    INSERT INTO notification_logs (email, full_name, notification_type, status, message, sent_to, log_time)
                    VALUES (@Email, @FullName, @Type, @Status, @Message, @SentTo, NOW());
                "
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
                    cmd.Parameters.AddWithValue("@Type", notifType)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@Message", message)
                    cmd.Parameters.AddWithValue("@SentTo", sentTo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' Silent fail on logging to avoid blocking main flow
        End Try
    End Sub

    ' 📩 Sends all related emails asynchronously
    Private Async Function SendAllNotificationsAsync(email As String, fullName As String) As Task
        ' 🧍 User Email
        Dim userBody As String =
$"Hello {fullName},

We received your password reset request.
Your request is currently pending approval from the Super Admin.

You’ll be notified once your password reset is approved.

Best regards,
Medventory Support Team"

        Await SendEmailAsync(email, "Password Reset Request Received", userBody)
        LogNotification(email, fullName, "User Confirmation", email, "Sent", "User notified of password reset request.")

        ' 👨‍💼 Super Admin Email
        Dim adminBody As String =
$"Dear Super Admin,

A new password reset request has been submitted:

Full Name: {fullName}
Email: {email}
Request Date: {DateTime.Now}

Please log in to the admin panel to review and approve or reject this request.

Best regards,
Medventory Notification System"
        Await SendEmailAsync(superAdminEmail, "New Password Reset Request", adminBody)
        LogNotification(email, fullName, "Admin Notification", superAdminEmail, "Sent", "Super Admin notified of new request.")

        ' 📨 System Notification
        Dim systemBody As String =
$"Dear Medventory Admin,

A user has submitted a password reset request and is waiting for verification.

Full Name: {fullName}
Email: {email}
Request Date: {DateTime.Now:MM/dd/yyyy hh:mm:ss tt}

Please log in to the admin panel to approve or cancel this request.

Best regards,
Password Reset Notification System"
        Await SendEmailAsync(senderEmail, "🔔 User Password Reset Request", systemBody)
        LogNotification(email, fullName, "System Notification", senderEmail, "Sent", "System notified of password reset request.")
    End Function

    ' 🔘 Reset Button
    Private Async Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim full_name As String = txtFullname.Text.Trim()
        Dim newPassword As String = txtNewPassword.Text.Trim()

        lblMessage.Text = ""
        lblMessage.ForeColor = Color.Black

        ' 🧾 Validation
        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(full_name) OrElse String.IsNullOrWhiteSpace(newPassword) Then
            lblMessage.Text = "Please fill in all fields."
            lblMessage.ForeColor = Color.Red
            Return
        End If

        If Not email.Contains("@") OrElse Not email.Contains(".") Then
            lblMessage.Text = "Please enter a valid email address."
            lblMessage.ForeColor = Color.Red
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                Await conn.OpenAsync()

                ' 🔍 Check for duplicate pending requests
                Dim pendingCheck As String = "
                    SELECT COUNT(*) FROM password_reset_requests 
                    WHERE email = @Email AND status = 'Pending';
                "
                Using pendingCmd As New NpgsqlCommand(pendingCheck, conn)
                    pendingCmd.Parameters.AddWithValue("@Email", email)
                    Dim pendingCount As Integer = CInt(Await pendingCmd.ExecuteScalarAsync())
                    If pendingCount > 0 Then
                        lblMessage.Text = "You already have a pending password reset request. Please wait for approval."
                        lblMessage.ForeColor = Color.OrangeRed
                        Return
                    End If
                End Using

                ' ✅ Validate user
                Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE email = @Email AND full_name = @Fullname"
                Using checkCmd As New NpgsqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@Email", email)
                    checkCmd.Parameters.AddWithValue("@Fullname", full_name)
                    Dim count As Integer = CInt(Await checkCmd.ExecuteScalarAsync())
                    If count = 0 Then
                        lblMessage.Text = "Email and full name do not match our records."
                        lblMessage.ForeColor = Color.Red
                        Return
                    End If
                End Using

                ' 🔐 Hash new password
                Dim hashedPassword As String = HashPassword(newPassword)

                ' 🗂 Insert reset request
                Dim insertQuery As String = "
                    INSERT INTO password_reset_requests (email, full_name, new_password, status, request_date)
                    VALUES (@Email, @Fullname, @NewPassword, 'Pending', NOW());
                "
                Using insertCmd As New NpgsqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@Email", email)
                    insertCmd.Parameters.AddWithValue("@Fullname", full_name)
                    insertCmd.Parameters.AddWithValue("@NewPassword", hashedPassword)
                    Await insertCmd.ExecuteNonQueryAsync()
                End Using
            End Using

            ' 📩 Send all notification emails (non-blocking)
            Await SendAllNotificationsAsync(email, full_name)

            lblMessage.Text = "Password reset request sent. Please wait for Super Admin approval."
            lblMessage.ForeColor = Color.Green

            MessageBox.Show("Your password reset request has been submitted successfully." & vbCrLf &
                            "You'll receive an email once approved.",
                            "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtEmail.Clear()
            txtFullname.Clear()
            txtNewPassword.Clear()

        Catch ex As Exception
            lblMessage.Text = "An unexpected error occurred. Please try again later."
            lblMessage.ForeColor = Color.Red
            LogNotification(email, full_name, "System Error", "System", "Failed", ex.Message)
        End Try
    End Sub

    ' 🔙 Back to Login
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

End Class
