<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMedicineForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnCancel = New Button()
        txtCategory = New TextBox()
        lblFullName = New Label()
        Label5 = New Label()
        btnAdd = New Button()
        txtName = New TextBox()
        lblEmail = New Label()
        txtQuantity = New TextBox()
        Label1 = New Label()
        txtUnit = New TextBox()
        txtUn = New Label()
        Label3 = New Label()
        txtSupplier = New TextBox()
        Label4 = New Label()
        dtpExpiryDate = New DateTimePicker()
        lblMessage = New Label()
        txtDescription = New TextBox()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(23, 20)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 27)
        btnCancel.TabIndex = 41
        btnCancel.Text = "Back"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' txtCategory
        ' 
        txtCategory.Font = New Font("Poppins", 9.75F)
        txtCategory.Location = New Point(318, 110)
        txtCategory.Name = "txtCategory"
        txtCategory.Size = New Size(333, 27)
        txtCategory.TabIndex = 38
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Font = New Font("Poppins", 9.75F)
        lblFullName.Location = New Point(166, 110)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(74, 23)
        lblFullName.TabIndex = 43
        lblFullName.Text = "Category:"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(318, 20)
        Label5.Name = "Label5"
        Label5.Size = New Size(156, 27)
        Label5.TabIndex = 42
        Label5.Text = "ADD MEDICINE"
        ' 
        ' btnAdd
        ' 
        btnAdd.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAdd.Location = New Point(657, 396)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(131, 29)
        btnAdd.TabIndex = 40
        btnAdd.Text = "Add Medicine"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' txtName
        ' 
        txtName.Font = New Font("Poppins", 9.75F)
        txtName.Location = New Point(318, 68)
        txtName.Name = "txtName"
        txtName.Size = New Size(333, 27)
        txtName.TabIndex = 37
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Poppins", 9.75F)
        lblEmail.Location = New Point(166, 67)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(113, 23)
        lblEmail.TabIndex = 36
        lblEmail.Text = "Medicine Name:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Poppins", 9.75F)
        txtQuantity.Location = New Point(318, 156)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(333, 27)
        txtQuantity.TabIndex = 44
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Poppins", 9.75F)
        Label1.Location = New Point(166, 156)
        Label1.Name = "Label1"
        Label1.Size = New Size(68, 23)
        Label1.TabIndex = 45
        Label1.Text = "Quantity:"
        ' 
        ' txtUnit
        ' 
        txtUnit.Font = New Font("Poppins", 9.75F)
        txtUnit.Location = New Point(318, 202)
        txtUnit.Name = "txtUnit"
        txtUnit.Size = New Size(333, 27)
        txtUnit.TabIndex = 46
        ' 
        ' txtUn
        ' 
        txtUn.AutoSize = True
        txtUn.Font = New Font("Poppins", 9.75F)
        txtUn.Location = New Point(166, 202)
        txtUn.Name = "txtUn"
        txtUn.Size = New Size(38, 23)
        txtUn.TabIndex = 47
        txtUn.Text = "Unit:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Poppins", 9.75F)
        Label3.Location = New Point(166, 357)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 23)
        Label3.TabIndex = 49
        Label3.Text = "Expiry Date:"
        ' 
        ' txtSupplier
        ' 
        txtSupplier.Font = New Font("Poppins", 9.75F)
        txtSupplier.Location = New Point(318, 253)
        txtSupplier.Name = "txtSupplier"
        txtSupplier.Size = New Size(333, 27)
        txtSupplier.TabIndex = 50
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Poppins", 9.75F)
        Label4.Location = New Point(166, 253)
        Label4.Name = "Label4"
        Label4.Size = New Size(66, 23)
        Label4.TabIndex = 51
        Label4.Text = "Supplier:"
        ' 
        ' dtpExpiryDate
        ' 
        dtpExpiryDate.Location = New Point(318, 357)
        dtpExpiryDate.Name = "dtpExpiryDate"
        dtpExpiryDate.Size = New Size(333, 23)
        dtpExpiryDate.TabIndex = 52
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Location = New Point(23, 410)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(0, 15)
        lblMessage.TabIndex = 53
        ' 
        ' txtDescription
        ' 
        txtDescription.Font = New Font("Poppins", 9.75F)
        txtDescription.Location = New Point(318, 305)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(333, 27)
        txtDescription.TabIndex = 54
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins", 9.75F)
        Label2.Location = New Point(166, 305)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 23)
        Label2.TabIndex = 55
        Label2.Text = "Description:"
        ' 
        ' AddMedicineForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(txtDescription)
        Controls.Add(Label2)
        Controls.Add(lblMessage)
        Controls.Add(dtpExpiryDate)
        Controls.Add(txtSupplier)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(txtUnit)
        Controls.Add(txtUn)
        Controls.Add(txtQuantity)
        Controls.Add(Label1)
        Controls.Add(btnCancel)
        Controls.Add(txtCategory)
        Controls.Add(lblFullName)
        Controls.Add(Label5)
        Controls.Add(btnAdd)
        Controls.Add(txtName)
        Controls.Add(lblEmail)
        Name = "AddMedicineForm"
        Text = "AddMedicineForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents txtUn As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpExpiryDate As DateTimePicker
    Friend WithEvents lblMessage As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label2 As Label
End Class
