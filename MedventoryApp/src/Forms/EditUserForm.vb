Imports Npgsql

Public Class EditUserForm
    Private ReadOnly connectionString As String
    Private ReadOnly userEmail As String

    ' Constructor
    Public Sub New(email As String, fullName As String, role As String, connStr As String)
        InitializeComponent()
        connectionString = connStr
        userEmail = email

        txtEmail.Text = email
        txtFullname.Text = fullName
        cmbRole.Items.Clear()
        cmbRole.Items.Add("super_admin")
        cmbRole.Items.Add("admin")
        cmbRole.Items.Add("doctor")
        cmbRole.Items.Add("pharmacist")

        cmbRole.SelectedItem = role
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validate Full Name
            If String.IsNullOrWhiteSpace(txtFullname.Text) Then
                MessageBox.Show("Full name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Validate Role
            If cmbRole.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Convert role to lowercase to satisfy DB CHECK constraint
            Dim selectedRole As String = cmbRole.SelectedItem.ToString().ToLower()

            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()

                Dim query As String = "UPDATE users SET full_name = @FullName, role = @Role WHERE email = @Email"

                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@FullName", txtFullname.Text.Trim())
                    cmd.Parameters.AddWithValue("@Role", selectedRole)
                    cmd.Parameters.AddWithValue("@Email", userEmail)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
