<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUserForm
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
        cmbRole = New ComboBox()
        btnCancel = New Button()
        txtFullname = New TextBox()
        lblFullName = New Label()
        Label5 = New Label()
        lblMessage = New Label()
        btnAddUser = New Button()
        Label2 = New Label()
        txtEmail = New TextBox()
        lblEmail = New Label()
        SuspendLayout()
        ' 
        ' cmbRole
        ' 
        cmbRole.FormattingEnabled = True
        cmbRole.Location = New Point(392, 262)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(333, 23)
        cmbRole.TabIndex = 35
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(75, 30)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 27)
        btnCancel.TabIndex = 31
        btnCancel.Text = "Back"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' txtFullname
        ' 
        txtFullname.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFullname.Location = New Point(392, 182)
        txtFullname.Name = "txtFullname"
        txtFullname.Size = New Size(333, 36)
        txtFullname.TabIndex = 28
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFullName.Location = New Point(105, 185)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(113, 34)
        lblFullName.TabIndex = 34
        lblFullName.Text = "Full name:"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(340, 30)
        Label5.Name = "Label5"
        Label5.Size = New Size(111, 27)
        Label5.TabIndex = 33
        Label5.Text = "ADD USER"
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMessage.Location = New Point(105, 392)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(0, 28)
        lblMessage.TabIndex = 32
        ' 
        ' btnAddUser
        ' 
        btnAddUser.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddUser.Location = New Point(332, 332)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Size = New Size(199, 39)
        btnAddUser.TabIndex = 30
        btnAddUser.Text = "Add User"
        btnAddUser.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(105, 255)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 34)
        Label2.TabIndex = 29
        Label2.Text = "Role List:"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(392, 109)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(333, 36)
        txtEmail.TabIndex = 27
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmail.Location = New Point(105, 111)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(72, 34)
        lblEmail.TabIndex = 26
        lblEmail.Text = "Email:"
        ' 
        ' AddUserForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(cmbRole)
        Controls.Add(btnCancel)
        Controls.Add(txtFullname)
        Controls.Add(lblFullName)
        Controls.Add(Label5)
        Controls.Add(lblMessage)
        Controls.Add(btnAddUser)
        Controls.Add(Label2)
        Controls.Add(txtEmail)
        Controls.Add(lblEmail)
        Name = "AddUserForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AddUserForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtFullname As TextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnAddUser As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
End Class
