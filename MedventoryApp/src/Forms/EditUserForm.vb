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
        cmbRole.Items.AddRange({"Super Admin", "Admin", "Doctor", "Pharmacist"})
        cmbRole.SelectedItem = role
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE users SET full_name = @FullName, role = @Role WHERE email = @Email"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@FullName", txtFullname.Text.Trim())
                    cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString().ToLower())
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
