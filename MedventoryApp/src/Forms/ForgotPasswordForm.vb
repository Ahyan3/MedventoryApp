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
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim fullName As String = txtFullname.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim newPassword As String = txtNewPassword.Text.Trim()

        ' 🔒 Disable button to prevent duplicate clicks
        btnReset.Enabled = False
        lblMessage.Text = ""
        lblMessage.ForeColor = Color.Black

        ' 🧾 Validation
        If fullName = "" Or email = "" Or newPassword = "" Then
            lblMessage.Text = "Please fill in all fields."
            lblMessage.ForeColor = Color.Red
            btnReset.Enabled = True
            Return
        End If

        Try
        Using conn As New NpgsqlConnection(connectionString)
            conn.Open()

            ' 🧠 Step 1: Verify if user exists and full name matches
            Dim checkUserQuery As String = "SELECT COUNT(*) FROM users WHERE email = @Email AND full_name = @FullName"
            Using checkCmd As New NpgsqlCommand(checkUserQuery, conn)
                checkCmd.Parameters.AddWithValue("@Email", email)
                checkCmd.Parameters.AddWithValue("@FullName", fullName)
                Dim userExists As Integer = CInt(checkCmd.ExecuteScalar())

                If userExists = 0 Then
                    lblMessage.Text = "User not found or full name does not match."
                    lblMessage.ForeColor = Color.Red
                    btnReset.Enabled = True
                    Return
                End If
            End Using

            ' 🧠 Step 2: Check if there's already a pending request for this user
            Dim checkPendingQuery As String = "SELECT COUNT(*) FROM password_reset_requests WHERE email = @Email AND status = 'Pending'"
            Using pendingCmd As New NpgsqlCommand(checkPendingQuery, conn)
                pendingCmd.Parameters.AddWithValue("@Email", email)
                Dim pendingCount As Integer = CInt(pendingCmd.ExecuteScalar())

                If pendingCount > 0 Then
                    lblMessage.Text = "You already have a pending request. Please wait for admin approval."
                    lblMessage.ForeColor = Color.Orange
                    btnReset.Enabled = True
                    Return
                End If
            End Using

            ' 🧩 Step 3: Insert new password reset request
            Dim insertQuery As String = "
                INSERT INTO password_reset_requests (full_name, email, new_password, status, request_date)
                VALUES (@FullName, @Email, @NewPassword, 'Pending', NOW());
            "

            Using insertCmd As New NpgsqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@FullName", fullName)
                insertCmd.Parameters.AddWithValue("@Email", email)
                insertCmd.Parameters.AddWithValue("@NewPassword", HashPassword(newPassword))
                insertCmd.ExecuteNonQuery()
            End Using
        End Using

        lblMessage.Text = "Request submitted. Please wait for admin approval."
        lblMessage.ForeColor = Color.Green

            MessageBox.Show("Password reset request sent successfully. Please wait for SuperAdmin approval.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 📤 Send notifications (non-blocking)
            Task.Run(Async Function()
                         Await SendAllNotificationsAsync(email, fullName)
                     End Function)

            ' 🧹 Clear fields
            txtFullname.Clear()
        txtEmail.Clear()
        txtNewPassword.Clear()

    Catch ex As Exception
        lblMessage.Text = "Error: " & ex.Message
        lblMessage.ForeColor = Color.Red
    Finally
        btnReset.Enabled = True ' 🔓 Always re-enable button at the end
    End Try
End Sub

    ' 🔙 Back to Login
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

End Class