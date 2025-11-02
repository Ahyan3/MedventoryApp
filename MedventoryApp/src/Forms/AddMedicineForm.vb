Imports Npgsql
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data

Public Class AddMedicineForm
    Private ReadOnly connectionString As String
    Private ReadOnly LoggedInEmail As String

    Public Sub New(connString As String, loggedEmail As String)
        InitializeComponent()
        connectionString = connString
        LoggedInEmail = loggedEmail
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim name As String = txtName.Text.Trim()
        Dim category As String = txtCategory.Text.Trim()
        Dim quantityStr As String = txtQuantity.Text.Trim()
        Dim unit As String = txtUnit.Text.Trim()
        Dim supplier As String = txtSupplier.Text.Trim()
        Dim description As String = txtDescription.Text.Trim()
        Dim expiryDate As Date = dtpExpiryDate.Value


        lblMessage.Text = ""
        lblMessage.ForeColor = Color.Black

        ' ✅ Validation
        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(category) OrElse
           String.IsNullOrWhiteSpace(quantityStr) OrElse String.IsNullOrWhiteSpace(unit) OrElse
           String.IsNullOrWhiteSpace(supplier) Then
            lblMessage.Text = "Please fill in all fields."
            lblMessage.ForeColor = Color.Red
            Return
        End If

        Dim quantity As Integer
        If Not Integer.TryParse(quantityStr, quantity) OrElse quantity < 0 Then
            lblMessage.Text = "Quantity must be a valid positive number."
            lblMessage.ForeColor = Color.Red
            Return
        End If

        Try
            Using conn As New NpgsqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                    INSERT INTO medicines (name, category, quantity, unit, supplier, description, expiry_date, added_by)
                    VALUES (@Name, @Category, @Quantity, @Unit, @Supplier, @Description, @ExpiryDate, @AddedBy);
                "
                Using cmd As New NpgsqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@Category", category)
                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@Unit", unit)
                    cmd.Parameters.AddWithValue("@Supplier", supplier)
                    cmd.Parameters.AddWithValue("@Description", description)
                    cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate)
                    cmd.Parameters.AddWithValue("@AddedBy", LoggedInEmail)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            lblMessage.Text = "Medicine added successfully!"
            lblMessage.ForeColor = Color.Green
            MessageBox.Show("Medicine has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 🧾 Log activity
            AddActivityLog($"Added new medicine: {name}", LoggedInEmail)

            ' Clear form
            txtName.Clear()
            txtCategory.Clear()
            txtQuantity.Clear()
            txtUnit.Clear()
            txtSupplier.Clear()
            txtDescription.Clear()
            dtpExpiryDate.Value = DateTime.Now

        Catch ex As Exception
            lblMessage.Text = "Error adding medicine: " & ex.Message
            lblMessage.ForeColor = Color.Red
        End Try
    End Sub
End Class
