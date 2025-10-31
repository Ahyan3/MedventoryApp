Imports System.Reflection.Emit
Imports Npgsql
Imports System.Data
Imports System.Configuration
Imports System.Security.Cryptography

Public Class SuperAdmin

    ' 🧩 Database Connection (Supabase/PostgreSQL)
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("SupabaseConnection").ConnectionString

    ' 📧 Email Configuration (Stored in App.config for Security)
    Private ReadOnly senderEmail As String = ConfigurationManager.AppSettings("SenderEmail")
    Private ReadOnly senderPassword As String = ConfigurationManager.AppSettings("SenderPassword")
    Private ReadOnly superAdminEmail As String = ConfigurationManager.AppSettings("SuperAdminEmail")

    Private Sub SuperAdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Super Admin"
        LoadPendingResetRequests()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub LoadPendingResetRequests()
        Try

            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT id, full_name, email, status, request_date 
                FROM password_reset_requests
                WHERE status = 'Pending'
                ORDER BY request_date DESC;
            "

                Dim da As New NpgsqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvResetRequests.DataSource = dt
            End Using

            ' Format columns
            dgvResetRequests.Columns("id").Visible = False
            dgvResetRequests.Columns("full_name").HeaderText = "Full Name"
            dgvResetRequests.Columns("email").HeaderText = "Email"
            dgvResetRequests.Columns("status").HeaderText = "Status"
            dgvResetRequests.Columns("request_date").HeaderText = "Request Date"

            ' Auto-resize columns
            dgvResetRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvResetRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvResetRequests.ReadOnly = True

            ' Add Approve/Reject buttons if not yet added
            If dgvResetRequests.Columns.Contains("Approve") = False Then
                Dim approveButton As New DataGridViewButtonColumn()
                approveButton.Name = "Approve"
                approveButton.HeaderText = "Approve"
                approveButton.Text = "Approve"
                approveButton.UseColumnTextForButtonValue = True
                dgvResetRequests.Columns.Add(approveButton)
            End If

            If dgvResetRequests.Columns.Contains("Reject") = False Then
                Dim rejectButton As New DataGridViewButtonColumn()
                rejectButton.Name = "Reject"
                rejectButton.HeaderText = "Reject"
                rejectButton.Text = "Reject"
                rejectButton.UseColumnTextForButtonValue = True
                dgvResetRequests.Columns.Add(rejectButton)
            End If

            ' Add Approve button column
            If Not dgvResetRequests.Columns.Contains("Approve") Then
                Dim approveButton As New DataGridViewButtonColumn()
                approveButton.Name = "Approve"
                approveButton.HeaderText = "Approve"
                approveButton.Text = "Approve"
                approveButton.UseColumnTextForButtonValue = True
                approveButton.SortMode = DataGridViewColumnSortMode.NotSortable
                dgvResetRequests.Columns.Add(approveButton)
            End If

            ' Add Reject button column
            If Not dgvResetRequests.Columns.Contains("Reject") Then
                Dim rejectButton As New DataGridViewButtonColumn()
                rejectButton.Name = "Reject"
                rejectButton.HeaderText = "Reject"
                rejectButton.Text = "Reject"
                rejectButton.UseColumnTextForButtonValue = True
                rejectButton.SortMode = DataGridViewColumnSortMode.NotSortable
                dgvResetRequests.Columns.Add(rejectButton)
            End If


        Catch ex As Exception
            MessageBox.Show("Error loading reset requests: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvResetRequests_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResetRequests.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim id As Integer = CInt(dgvResetRequests.Rows(e.RowIndex).Cells("id").Value)
        Dim userEmail As String = dgvResetRequests.Rows(e.RowIndex).Cells("email").Value.ToString()

        If dgvResetRequests.Columns(e.ColumnIndex).Name = "Approve" Then
            ApproveRequest(id, userEmail)
        ElseIf dgvResetRequests.Columns(e.ColumnIndex).Name = "Reject" Then
            RejectRequest(id, userEmail)
        End If
    End Sub

    Private Sub ApproveRequest(requestId As Integer, email As String)
        Try

            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' Get the new password first
                Dim newPasswordQuery As String = "SELECT new_password FROM password_reset_requests WHERE id = @Id"
                Dim newPassword As String = ""
                Using cmd As New NpgsqlCommand(newPasswordQuery, conn)
                    cmd.Parameters.AddWithValue("@Id", requestId)
                    newPassword = cmd.ExecuteScalar().ToString()
                End Using

                ' Update user's password
                Dim hashedPassword As String = BitConverter.ToString(SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(newPassword))).Replace("-", "").ToLower()
                Dim updateUserQuery As String = "UPDATE users SET password = @NewPassword WHERE email = @Email"
                Using cmd As New NpgsqlCommand(updateUserQuery, conn)
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.ExecuteNonQuery()
                End Using

                ' Mark request as approved
                Dim updateRequestQuery As String = "UPDATE password_reset_requests SET status = 'Approved' WHERE id = @Id"
                Using cmd As New NpgsqlCommand(updateRequestQuery, conn)
                    cmd.Parameters.AddWithValue("@Id", requestId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Password reset approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPendingResetRequests()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error approving request: " & ex.Message)
        End Try
    End Sub

    Private Sub RejectRequest(requestId As Integer, email As String)
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE password_reset_requests SET status = 'Rejected' WHERE id = @Id"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Id", requestId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Password reset request rejected.", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadPendingResetRequests()

        Catch ex As Exception
            MessageBox.Show("Error rejecting request: " & ex.Message)
        End Try
    End Sub

    Private Sub SendNotification(toEmail As String, subject As String, body As String)
        Try
            Dim smtp As New Net.Mail.SmtpClient("smtp.gmail.com", 587)
            smtp.EnableSsl = True
            smtp.Credentials = New Net.NetworkCredential(senderEmail, senderPassword)
            smtp.Send(senderEmail, toEmail, subject, body)
        Catch ex As Exception
            MessageBox.Show("Failed to send notification email: " & ex.Message)
        End Try
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
