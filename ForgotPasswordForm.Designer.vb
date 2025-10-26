<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForgotPasswordForm
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
        Label1 = New Label()
        txtEmail = New TextBox()
        Label2 = New Label()
        txtNewPassword = New TextBox()
        btnReset = New Button()
        lblMessage = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(141, 115)
        Label1.Name = "Label1"
        Label1.Size = New Size(174, 34)
        Label1.TabIndex = 0
        Label1.Text = "Enter your email:"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(340, 115)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(223, 36)
        txtEmail.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(104, 199)
        Label2.Name = "Label2"
        Label2.Size = New Size(211, 34)
        Label2.TabIndex = 2
        Label2.Text = "Enter new password:"
        ' 
        ' txtNewPassword
        ' 
        txtNewPassword.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNewPassword.Location = New Point(340, 199)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.Size = New Size(223, 36)
        txtNewPassword.TabIndex = 3
        txtNewPassword.UseSystemPasswordChar = True
        ' 
        ' btnReset
        ' 
        btnReset.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReset.Location = New Point(340, 283)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(223, 39)
        btnReset.TabIndex = 4
        btnReset.Text = "Enter"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMessage.Location = New Point(340, 351)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(0, 28)
        lblMessage.TabIndex = 5
        ' 
        ' ForgotPasswordForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblMessage)
        Controls.Add(btnReset)
        Controls.Add(txtNewPassword)
        Controls.Add(Label2)
        Controls.Add(txtEmail)
        Controls.Add(Label1)
        Name = "ForgotPasswordForm"
        Text = "ForgotPasswordForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents btnReset As Button
    Friend WithEvents lblMessage As Label
End Class
