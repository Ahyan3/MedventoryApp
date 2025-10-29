<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuperAdmin
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
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        TabPage3 = New TabPage()
        TabPage4 = New TabPage()
        TabPage5 = New TabPage()
        TabPage6 = New TabPage()
        PurchaseToolStripMenuItem = New ToolStripMenuItem()
        AddSupplierToolStripMenuItem = New ToolStripMenuItem()
        UpdateSupplierDetailsToolStripMenuItem = New ToolStripMenuItem()
        PurToolStripMenuItem = New ToolStripMenuItem()
        PurchaseToolStripMenuItem1 = New ToolStripMenuItem()
        StockToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        Panel3 = New Panel()
        Panel1 = New Panel()
        Label8 = New Label()
        Label7 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel4 = New Panel()
        Panel5 = New Panel()
        Panel6 = New Panel()
        Panel7 = New Panel()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        TabControl1.SuspendLayout()
        TabPage2.SuspendLayout()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Controls.Add(TabPage5)
        TabControl1.Controls.Add(TabPage6)
        TabControl1.Location = New Point(2, 5)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1306, 780)
        TabControl1.TabIndex = 1
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.Gainsboro
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(1298, 752)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Dashboard"
        ' 
        ' TabPage2
        ' 
        TabPage2.BackColor = Color.Gainsboro
        TabPage2.Controls.Add(Panel7)
        TabPage2.Controls.Add(Panel6)
        TabPage2.Controls.Add(Panel5)
        TabPage2.Controls.Add(Panel4)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(1298, 752)
        TabPage2.TabIndex = 1
        TabPage2.Text = "User Management"
        ' 
        ' TabPage3
        ' 
        TabPage3.BackColor = Color.Gainsboro
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(1298, 752)
        TabPage3.TabIndex = 2
        TabPage3.Text = "File Management"
        ' 
        ' TabPage4
        ' 
        TabPage4.BackColor = Color.Gainsboro
        TabPage4.Location = New Point(4, 24)
        TabPage4.Name = "TabPage4"
        TabPage4.Padding = New Padding(3)
        TabPage4.Size = New Size(1298, 752)
        TabPage4.TabIndex = 3
        TabPage4.Text = "Reports"
        ' 
        ' TabPage5
        ' 
        TabPage5.BackColor = Color.Gainsboro
        TabPage5.Location = New Point(4, 24)
        TabPage5.Name = "TabPage5"
        TabPage5.Padding = New Padding(3)
        TabPage5.Size = New Size(1298, 752)
        TabPage5.TabIndex = 4
        TabPage5.Text = "Windows"
        ' 
        ' TabPage6
        ' 
        TabPage6.BackColor = Color.Gainsboro
        TabPage6.Location = New Point(4, 24)
        TabPage6.Name = "TabPage6"
        TabPage6.Padding = New Padding(3)
        TabPage6.Size = New Size(1298, 752)
        TabPage6.TabIndex = 5
        TabPage6.Text = "Help"
        ' 
        ' PurchaseToolStripMenuItem
        ' 
        PurchaseToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AddSupplierToolStripMenuItem, UpdateSupplierDetailsToolStripMenuItem, PurToolStripMenuItem, PurchaseToolStripMenuItem1})
        PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        PurchaseToolStripMenuItem.Size = New Size(180, 22)
        PurchaseToolStripMenuItem.Text = "Purchase"
        ' 
        ' AddSupplierToolStripMenuItem
        ' 
        AddSupplierToolStripMenuItem.Name = "AddSupplierToolStripMenuItem"
        AddSupplierToolStripMenuItem.Size = New Size(198, 22)
        AddSupplierToolStripMenuItem.Text = "Add Supplier Details"
        ' 
        ' UpdateSupplierDetailsToolStripMenuItem
        ' 
        UpdateSupplierDetailsToolStripMenuItem.Name = "UpdateSupplierDetailsToolStripMenuItem"
        UpdateSupplierDetailsToolStripMenuItem.Size = New Size(198, 22)
        UpdateSupplierDetailsToolStripMenuItem.Text = "Update/Delete Supplier"
        ' 
        ' PurToolStripMenuItem
        ' 
        PurToolStripMenuItem.Name = "PurToolStripMenuItem"
        PurToolStripMenuItem.Size = New Size(198, 22)
        PurToolStripMenuItem.Text = "Purchase Order Details "
        ' 
        ' PurchaseToolStripMenuItem1
        ' 
        PurchaseToolStripMenuItem1.Name = "PurchaseToolStripMenuItem1"
        PurchaseToolStripMenuItem1.Size = New Size(198, 22)
        PurchaseToolStripMenuItem1.Text = "Purchase Return Details"
        ' 
        ' StockToolStripMenuItem
        ' 
        StockToolStripMenuItem.Name = "StockToolStripMenuItem"
        StockToolStripMenuItem.Size = New Size(180, 22)
        StockToolStripMenuItem.Text = "Stock"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(180, 22)
        ToolStripMenuItem2.Text = " "
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Location = New Point(2, -14)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1306, 24)
        Panel3.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(2, 30)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(230, 750)
        Panel1.TabIndex = 5
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(74, 687)
        Label8.Name = "Label8"
        Label8.Size = New Size(77, 28)
        Label8.TabIndex = 8
        Label8.Text = "Log out"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(73, 458)
        Label7.Name = "Label7"
        Label7.Size = New Size(86, 28)
        Label7.TabIndex = 7
        Label7.Text = "Settings"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(73, 331)
        Label5.Name = "Label5"
        Label5.Size = New Size(81, 28)
        Label5.TabIndex = 5
        Label5.Text = "Reports"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(68, 395)
        Label6.Name = "Label6"
        Label6.Size = New Size(92, 28)
        Label6.TabIndex = 6
        Label6.Text = "Windows"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(34, 267)
        Label4.Name = "Label4"
        Label4.Size = New Size(167, 28)
        Label4.TabIndex = 5
        Label4.Text = "File Management"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(27, 199)
        Label3.Name = "Label3"
        Label3.Size = New Size(177, 28)
        Label3.TabIndex = 4
        Label3.Text = "User Management"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(59, 135)
        Label2.Name = "Label2"
        Label2.Size = New Size(111, 28)
        Label2.TabIndex = 3
        Label2.Text = "Dashboard"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Black
        Panel2.Location = New Point(44, 67)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(150, 1)
        Panel2.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(52, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(134, 23)
        Label1.TabIndex = 0
        Label1.Text = "Super Admin"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.WhiteSmoke
        Panel4.Controls.Add(Label9)
        Panel4.Controls.Add(PictureBox1)
        Panel4.Location = New Point(258, 30)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(500, 330)
        Panel4.TabIndex = 0
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.WhiteSmoke
        Panel5.Controls.Add(Label10)
        Panel5.Controls.Add(PictureBox2)
        Panel5.Location = New Point(774, 30)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(500, 330)
        Panel5.TabIndex = 1
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.WhiteSmoke
        Panel6.Controls.Add(Label11)
        Panel6.Controls.Add(PictureBox3)
        Panel6.Location = New Point(258, 376)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(500, 330)
        Panel6.TabIndex = 1
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.WhiteSmoke
        Panel7.Controls.Add(Label12)
        Panel7.Controls.Add(PictureBox4)
        Panel7.Location = New Point(774, 376)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(500, 330)
        Panel7.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(465, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(25, 25)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Location = New Point(463, 10)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(25, 25)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Location = New Point(465, 10)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(25, 25)
        PictureBox3.TabIndex = 2
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Location = New Point(463, 10)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(25, 25)
        PictureBox4.TabIndex = 2
        PictureBox4.TabStop = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(13, 13)
        Label9.Name = "Label9"
        Label9.Size = New Size(130, 28)
        Label9.TabIndex = 9
        Label9.Text = "Pending User"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(13, 13)
        Label10.Name = "Label10"
        Label10.Size = New Size(177, 28)
        Label10.TabIndex = 10
        Label10.Text = "User Management"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(13, 13)
        Label11.Name = "Label11"
        Label11.Size = New Size(112, 28)
        Label11.TabIndex = 11
        Label11.Text = "Full Access"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(13, 13)
        Label12.Name = "Label12"
        Label12.Size = New Size(310, 28)
        Label12.TabIndex = 12
        Label12.Text = "Pending Password Reset Request"
        ' 
        ' SuperAdmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1309, 786)
        Controls.Add(Panel1)
        Controls.Add(Panel3)
        Controls.Add(TabControl1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "SuperAdmin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SuperAdminForm"
        TabControl1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents PurchaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddSupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateSupplierDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PurToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
End Class
