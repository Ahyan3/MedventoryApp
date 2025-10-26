Imports Npgsql

Module Database
    Public Function GetConnection() As NpgsqlConnection
        Dim connString As String =
            "Host=aws-1-ap-southeast-1.pooler.supabase.com;" &
            "Port=5432;" &
            "Username=postgres.okexwfjhcijqblmzzgxq;" &
            "Password=DCsID1gqH6Egkv7p;" &
            "Database=postgres;" &
            "SSL Mode=Require;" &
            "Trust Server Certificate=true"
        Return New NpgsqlConnection(connString)
    End Function

    Public Sub TestQuery()
        Using conn As NpgsqlConnection = GetConnection()
            conn.Open()
            Using cmd As New NpgsqlCommand("SELECT NOW()", conn)
                Dim result = cmd.ExecuteScalar()
                Console.WriteLine("Database time: " & result.ToString())
            End Using
        End Using
    End Sub
End Module