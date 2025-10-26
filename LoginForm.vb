Imports System.Runtime.CompilerServices
Imports Npgsql

Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()

        If email = "" Or password = "" Then
            Label3.Text = "Please enter email and password."
            Return
        End If

        Try
            Using conn As NpgsqlConnection = Database.GetConnection()
                conn.Open()

                ' ✅ Use email instead of name
                Dim query As String = "SELECT role, full_name FROM users WHERE email = @e AND password = @p"
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@e", email)
                    cmd.Parameters.AddWithValue("@p", password)

                    Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim role As String = reader("role").ToString().ToLower()
                            Dim fullName As String = reader("full_name").ToString()

                            Select Case role
                                Case "super_admin"
                                    MessageBox.Show("Welcome Super Admin " & fullName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Dim superAdminForm As New SuperAdmin()
                                    superAdminForm.Show()
                                    Me.Hide()

                                Case "admin"
                                    MessageBox.Show("Welcome Admin " & fullName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Dim adminForm As New AdminForm()
                                    adminForm.Show()
                                    Me.Hide()

                                Case "doctor"
                                    MessageBox.Show("Welcome Doctor " & fullName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Dim doctorForm As New DoctorForm()
                                    doctorForm.Show()
                                    Me.Hide()

                                Case "pharmacist"
                                    MessageBox.Show("Welcome Pharmacist " & fullName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Dim pharmForm As New PharmacistForm()
                                    pharmForm.Show()
                                    Me.Hide()

                                Case Else
                                    Label3.Text = "Unknown role: " & role
                            End Select
                        Else
                            Label3.Text = "Invalid email or password."
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Label3.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        ' Show the Forgot Password form
        Dim forgotForm As New ForgotPasswordForm()
        forgotForm.Show()
        ' Optionally, hide the current form
        ' Me.Hide()
    End Sub
End Class