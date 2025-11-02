Imports Npgsql

Module ActivityLogHelper
    Public Sub AddActivityLog(action As String,
                              Optional actorEmail As String = "superadmin@medventory.com",
                              Optional role As String = "Super Admin",
                              Optional targetEmail As String = Nothing)

        Dim connectionString As String = "YOUR_SUPABASE_CONNECTION_STRING"

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
End Module
