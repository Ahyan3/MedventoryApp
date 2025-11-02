Imports System.Reflection.Emit
Imports Npgsql
Imports System.Data
Imports System.Configuration
Imports System.Security.Cryptography

Public Class SuperAdmin

    ' 🧩 Database Connection (Supabase/PostgreSQL)
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("SupabaseConnection").ConnectionString

    Public LoggedInEmail As String = "superadmin@medventory.com" ' Temporary, until LoginForm passes it
    Public LoggedInRole As String = "Super Admin"

    ' 📧 Email Configuration (Stored in App.config for Security)
    Private ReadOnly senderEmail As String = ConfigurationManager.AppSettings("SenderEmail")
    Private ReadOnly senderPassword As String = ConfigurationManager.AppSettings("SenderPassword")
    Private ReadOnly superAdminEmail As String = ConfigurationManager.AppSettings("SuperAdminEmail")

    Private Sub SuperAdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Super Admin"
        LoadUsers()
        LoadActivityLogs()
        LoadPendingResetRequests()
    End Sub

    Private Sub btnRefreshAll_Click(sender As Object, e As EventArgs) Handles btnRefreshAll.Click
        Try
            LoadUsers()
            LoadPendingResetRequests()
            ' Add other here for refresh

            MessageBox.Show("All data refreshed successfully!", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error refreshing data: " & ex.Message)
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub LoadUsers()
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT full_name, email, role FROM users ORDER BY full_name ASC"
                Dim da As New NpgsqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvUsers.DataSource = dt
            End Using

            ' Optional UI polish
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvUsers.ReadOnly = True
            dgvUsers.AllowUserToAddRows = False
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ' 🧩 Add Edit and Delete buttons if not already added
            If dgvUsers.Columns.Contains("Edit") = False Then
                Dim editBtn As New DataGridViewButtonColumn()
                editBtn.HeaderText = "Edit"
                editBtn.Text = "Edit"
                editBtn.UseColumnTextForButtonValue = True
                editBtn.Name = "Edit"
                dgvUsers.Columns.Add(editBtn)
            End If

            If dgvUsers.Columns.Contains("Delete") = False Then
                Dim deleteBtn As New DataGridViewButtonColumn()
                deleteBtn.HeaderText = "Delete"
                deleteBtn.Text = "Delete"
                deleteBtn.UseColumnTextForButtonValue = True
                deleteBtn.Name = "Delete"
                dgvUsers.Columns.Add(deleteBtn)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick
        ' Ignore header clicks
        If e.RowIndex < 0 Then Return

        Dim selectedRow = dgvUsers.Rows(e.RowIndex)
        Dim email = selectedRow.Cells("email").Value.ToString

        ' 🧩 Edit Button
        If dgvUsers.Columns(e.ColumnIndex).Name = "Edit" Then
            Dim fullName = selectedRow.Cells("full_name").Value.ToString
            Dim role = selectedRow.Cells("role").Value.ToString

            Dim editForm As New EditUserForm(email, fullName, role, connectionString)
            If editForm.ShowDialog = DialogResult.OK Then
                LoadUsers()
                LoadActivityLogs()
                AddActivityLog("Edited user: " & email)
            End If
        End If

        ' 🧩 Delete Button
        If dgvUsers.Columns(e.ColumnIndex).Name = "Delete" Then
            Dim confirm = MessageBox.Show($"Are you sure you want to delete {email}?",
                                                      "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = DialogResult.Yes Then
                Try
                    Using conn As New NpgsqlConnection(connectionString)
                        conn.Open()
                        Dim query = "DELETE FROM users WHERE email = @Email"
                        Using cmd As New NpgsqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@Email", email)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    ' ✅ Log action
                    AddActivityLog("Deleted user: " & email)

                    ' ✅ Refresh both tables instantly
                    LoadUsers()
                    LoadActivityLogs() ' 👈 instantly show in the Activity Logs tab

                    MessageBox.Show("User deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("Error deleting user: " & ex.Message)
                End Try
            End If
        End If

    End Sub

    'Private Sub AddActivityLog(actionDescription As String)
    '    Try
    '        ' Replace this with the logged-in super admin email later
    '        Dim adminEmail As String = "superadmin@medventory.com"
    '        'Later (when the login form is used again), replace/remove the comment
    '        'Dim adminEmail As String = CurrentUserEmail
    '        'where CurrentUserEmail is a global variable or shared session value from the login form.
    '        'So for now, Leave it as Is — it's just a placeholder.
    ' ito yung papalit AddActivityLog("Deleted user: " & email, LoggedInEmail)


    '        Using conn As New NpgsqlConnection(connectionString)
    '            conn.Open()
    '            Dim query As String = "INSERT INTO user_activity_logs (admin_email, action) VALUES (@Email, @Action)"
    '            Using cmd As New NpgsqlCommand(query, conn)
    '                cmd.Parameters.AddWithValue("@Email", adminEmail)
    '                cmd.Parameters.AddWithValue("@Action", actionDescription)
    '                cmd.ExecuteNonQuery()
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Error logging activity: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub AddActivityLog(action As String, Optional actorEmail As String = "superadmin@medventory.com", Optional role As String = "Super Admin", Optional targetEmail As String = Nothing)
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                INSERT INTO user_activity_logs (email, role, target_email, action, log_date)
                VALUES (@Email, @Role, @TargetEmail, @Action, NOW());
            "
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Email", actorEmail)
                    cmd.Parameters.AddWithValue("@Role", role)
                    cmd.Parameters.AddWithValue("@TargetEmail", If(targetEmail, DBNull.Value))
                    cmd.Parameters.AddWithValue("@Action", action)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Log insert failed: " & ex.Message)
        End Try
    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    ' =====================
    ' Load pending password reset requests
    ' =====================
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

            ' Hide ID column and rename headers
            dgvResetRequests.Columns("id").Visible = False
            dgvResetRequests.Columns("full_name").HeaderText = "Full Name"
            dgvResetRequests.Columns("email").HeaderText = "Email"
            dgvResetRequests.Columns("status").HeaderText = "Status"
            dgvResetRequests.Columns("request_date").HeaderText = "Request Date"

            dgvResetRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvResetRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvResetRequests.ReadOnly = True

            ' Add Approve button if not exists
            If Not dgvResetRequests.Columns.Contains("Approve") Then
                Dim approveButton As New DataGridViewButtonColumn()
                approveButton.Name = "Approve"
                approveButton.HeaderText = "Approve"
                approveButton.Text = "Approve"
                approveButton.UseColumnTextForButtonValue = True
                approveButton.SortMode = DataGridViewColumnSortMode.NotSortable
                dgvResetRequests.Columns.Add(approveButton)
            End If

            ' Add Reject button if not exists
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

    ' =====================
    ' Handle Approve and Reject button clicks
    ' =====================
    Private Sub dgvResetRequests_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResetRequests.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim id As Integer = dgvResetRequests.Rows(e.RowIndex).Cells("id").Value
        Dim userEmail = dgvResetRequests.Rows(e.RowIndex).Cells("email").Value.ToString

        If dgvResetRequests.Columns(e.ColumnIndex).Name = "Approve" Then
            ApproveRequest(id, userEmail)
        ElseIf dgvResetRequests.Columns(e.ColumnIndex).Name = "Reject" Then
            RejectRequest(id, userEmail)
        End If
    End Sub

    ' =====================
    ' Approve a reset request
    ' =====================
    Private Sub ApproveRequest(requestId As Integer, email As String)
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                ' 🧩 Fetch the new password from the request
                Dim newPasswordQuery As String = "SELECT new_password FROM password_reset_requests WHERE id = @Id"
                Dim newPassword As String = ""
                Using cmd As New NpgsqlCommand(newPasswordQuery, conn)
                    cmd.Parameters.AddWithValue("@Id", requestId)
                    newPassword = cmd.ExecuteScalar().ToString()
                End Using

                ' 🔐 Hash the password using SHA256
                Dim hashedPassword As String = BitConverter.ToString(SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(newPassword))).Replace("-", "").ToLower()

                ' 🧠 Update the user's password in the database
                Dim updateUserQuery As String = "UPDATE users SET password = @NewPassword WHERE email = @Email"
                Using cmd As New NpgsqlCommand(updateUserQuery, conn)
                    cmd.Parameters.AddWithValue("@NewPassword", hashedPassword)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.ExecuteNonQuery()
                End Using

                ' 🟢 Mark the request as approved
                Dim updateRequestQuery As String = "UPDATE password_reset_requests SET status = 'Approved' WHERE id = @Id"
                Using cmd As New NpgsqlCommand(updateRequestQuery, conn)
                    cmd.Parameters.AddWithValue("@Id", requestId)
                    cmd.ExecuteNonQuery()
                End Using

                ' 📩 Send confirmation email
                SendNotification(
                email,
                "Password Reset Approved",
                $"Your password reset request has been approved successfully." & vbCrLf &
                $"You may now log in using your new password: {newPassword}" & vbCrLf & vbCrLf &
                $"🔒 For security reasons, please make sure to change your password after logging in." & vbCrLf &
                $"If you did not request this password change, contact the system administrator immediately."
            )

                ' ✅ Success message for the admin
                MessageBox.Show("The password reset has been successfully approved." & vbCrLf &
                            "An email has been sent to the user with their new login details and security instructions.",
                            "Request Approved",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

                ' 🔄 Refresh the request list
                LoadPendingResetRequests()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error approving request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =====================
    ' Reject a reset request
    ' =====================
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

            ' Send rejection notice
            SendNotification(email, "Password Reset Rejected", "Your password reset request was rejected. Please contact the administrator if you believe this is an error.")

            MessageBox.Show("Password reset request rejected.", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadPendingResetRequests()
        Catch ex As Exception
            MessageBox.Show("Error rejecting request: " & ex.Message)
        End Try
    End Sub

    ' =====================
    ' Send email notification
    ' =====================
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

    Private Sub txtSearchUser_TextChanged(sender As Object, e As EventArgs) Handles txtSearchUser.TextChanged
        'LoadUsers(txtSearchUser.Text)
    End Sub


    '=====================
    'Medicine Management Tab
    '=====================
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub LoadMedicines(Optional filter As String = "")
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT name, category, quantity, unit, expiry_date, supplier, added_by, added_date
                FROM medicines
                ORDER BY added_date DESC;
            "

                If Not String.IsNullOrEmpty(filter) Then
                    query = "
                    SELECT name, category, quantity, unit, expiry_date, supplier, added_by, added_date
                    FROM medicines
                    WHERE LOWER(name) LIKE @Filter
                       OR LOWER(category) LIKE @Filter
                       OR LOWER(supplier) LIKE @Filter
                    ORDER BY added_date DESC;
                "
                End If

                Using cmd As New NpgsqlCommand(query, conn)
                    If Not String.IsNullOrEmpty(filter) Then
                        cmd.Parameters.AddWithValue("@Filter", "%" & filter.ToLower() & "%")
                    End If

                    Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)
                        dgvMedicines.DataSource = dt
                    End Using
                End Using
            End Using

            dgvMedicines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvMedicines.Columns("name").HeaderText = "Medicine Name"
            dgvMedicines.Columns("category").HeaderText = "Category"
            dgvMedicines.Columns("quantity").HeaderText = "Quantity"
            dgvMedicines.Columns("unit").HeaderText = "Unit"
            dgvMedicines.Columns("expiry_date").HeaderText = "Expiry Date"
            dgvMedicines.Columns("supplier").HeaderText = "Supplier"
            dgvMedicines.Columns("added_by").HeaderText = "Added By"
            dgvMedicines.Columns("added_date").HeaderText = "Date Added"

        Catch ex As Exception
            MessageBox.Show("Error loading medicines: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshMedicine_Click(sender As Object, e As EventArgs) Handles btnRefreshMedicine.Click
        LoadMedicines()
    End Sub

    Private Sub txtSearchMedicine_TextChanged(sender As Object, e As EventArgs) Handles txtSearchMedicine.TextChanged
        LoadMedicines(txtSearchMedicine.Text)
    End Sub

    Private Sub btnAddMedicine_Click(sender As Object, e As EventArgs) Handles btnAddMedicine.Click
        Dim addForm As New AddMedicineForm(connectionString, LoggedInEmail)
        addForm.ShowDialog()
        LoadMedicines() ' 🔄 Refresh after adding
    End Sub


    '=====================
    'Activity Logs Tab
    '=====================
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        TabControl1.SelectedTab = tabActivityLogs
    End Sub

    Private Sub LoadActivityLogs(Optional filter As String = "")

        If dgvActivityLogs.Rows.Count > 0 Then
            dgvActivityLogs.FirstDisplayedScrollingRowIndex = 0
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT log_date, email, action
                FROM user_activity_logs
                ORDER BY log_date DESC
            "

                If Not String.IsNullOrEmpty(filter) Then
                    query = "
                    SELECT log_date, email, action
                    FROM user_activity_logs
                    WHERE LOWER(email) LIKE @Filter
                       OR LOWER(action) LIKE @Filter
                    ORDER BY log_date DESC
                "
                End If

                Using cmd As New NpgsqlCommand(query, conn)
                    If Not String.IsNullOrEmpty(filter) Then
                        cmd.Parameters.AddWithValue("@Filter", "%" & filter.ToLower() & "%")
                    End If

                    Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)
                        dgvActivityLogs.DataSource = dt
                    End Using
                End Using
            End Using

            ' Style the DataGridView
            dgvActivityLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvActivityLogs.Columns("log_date").HeaderText = "Timestamp"
            dgvActivityLogs.Columns("email").HeaderText = "Email"
            dgvActivityLogs.Columns("action").HeaderText = "Action Performed"

        Catch ex As Exception
            MessageBox.Show("Error loading logs: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshLogs_Click(sender As Object, e As EventArgs) Handles btnRefreshLogs.Click
        LoadActivityLogs()
    End Sub

    Private Sub txtSearchLogs_TextChanged(sender As Object, e As EventArgs) Handles txtSearchLogs.TextChanged
        LoadActivityLogs(txtSearchLogs.Text)
    End Sub



    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        TabControl1.SelectedTab = TabPage4
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        TabControl1.SelectedTab = TabPage5
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        ' Logout user
        MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close the current form (e.g., Dashboard)
        Hide()

        ' Show login form again
        Login.Show()
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
        TabControl1.SelectedTab = TabPage6
    End Sub


End Class
