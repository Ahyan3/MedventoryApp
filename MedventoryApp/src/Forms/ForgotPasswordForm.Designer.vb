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
        Label5 = New Label()
        Label3 = New Label()
        txtFullname = New TextBox()
        btnBack = New Button()
        lblMe = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(117, 121)
        Label1.Name = "Label1"
        Label1.Size = New Size(174, 34)
        Label1.TabIndex = 0
        Label1.Text = "Enter your email:"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(404, 119)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(223, 36)
        txtEmail.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(117, 265)
        Label2.Name = "Label2"
        Label2.Size = New Size(211, 34)
        Label2.TabIndex = 2
        Label2.Text = "Enter new password:"
        ' 
        ' txtNewPassword
        ' 
        txtNewPassword.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNewPassword.Location = New Point(404, 265)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.Size = New Size(223, 36)
        txtNewPassword.TabIndex = 3
        txtNewPassword.UseSystemPasswordChar = True
        ' 
        ' btnReset
        ' 
        btnReset.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReset.Location = New Point(307, 344)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(199, 39)
        btnReset.TabIndex = 4
        btnReset.Text = "Send Request"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMessage.Location = New Point(117, 396)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(0, 28)
        lblMessage.TabIndex = 5
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(307, 33)
        Label5.Name = "Label5"
        Label5.Size = New Size(199, 27)
        Label5.TabIndex = 9
        Label5.Text = "MEDVENTORY APP"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(117, 195)
        Label3.Name = "Label3"
        Label3.Size = New Size(161, 34)
        Label3.TabIndex = 10
        Label3.Text = "Enter Fullname:"
        ' 
        ' txtFullname
        ' 
        txtFullname.Font = New Font("Poppins", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFullname.Location = New Point(404, 192)
        txtFullname.Name = "txtFullname"
        txtFullname.Size = New Size(223, 36)
        txtFullname.TabIndex = 11
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(34, 33)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(75, 23)
        btnBack.TabIndex = 12
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' lblMe
        ' 
        lblMe.AutoSize = True
        lblMe.Location = New Point(117, 402)
        lblMe.Name = "lblMe"
        lblMe.Size = New Size(0, 15)
        lblMe.TabIndex = 13
        ' 
        ' ForgotPasswordForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblMe)
        Controls.Add(btnBack)
        Controls.Add(txtFullname)
        Controls.Add(Label3)
        Controls.Add(Label5)
        Controls.Add(lblMessage)
        Controls.Add(btnReset)
        Controls.Add(txtNewPassword)
        Controls.Add(Label2)
        Controls.Add(txtEmail)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "ForgotPasswordForm"
        StartPosition = FormStartPosition.CenterScreen
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
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFullname As TextBox
    Friend WithEvents btnBack As Button
    Friend WithEvents lblMe As Label
End Class
