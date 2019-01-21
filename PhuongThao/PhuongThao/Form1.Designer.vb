<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_action = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Spacing = New System.Windows.Forms.TextBox()
        Me.cbb_Type = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_CrankRatio = New System.Windows.Forms.TextBox()
        Me.txt_Distance = New System.Windows.Forms.TextBox()
        Me.cbb_Spaccing = New System.Windows.Forms.ComboBox()
        Me.cbb_CrankOrientation = New System.Windows.Forms.ComboBox()
        Me.txt_LapLenght = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbb_name = New System.Windows.Forms.ComboBox()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_Load = New System.Windows.Forms.Button()
        Me.txt_SaveAs = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_action
        '
        Me.btn_action.Location = New System.Drawing.Point(257, 254)
        Me.btn_action.Name = "btn_action"
        Me.btn_action.Size = New System.Drawing.Size(75, 23)
        Me.btn_action.TabIndex = 0
        Me.btn_action.Text = "AcTion"
        Me.btn_action.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PhuongThao.My.Resources.Resources.image1_20
        Me.PictureBox1.Location = New System.Drawing.Point(122, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(478, 155)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Spacing"
        '
        'txt_Spacing
        '
        Me.txt_Spacing.Location = New System.Drawing.Point(56, 162)
        Me.txt_Spacing.Name = "txt_Spacing"
        Me.txt_Spacing.Size = New System.Drawing.Size(60, 20)
        Me.txt_Spacing.TabIndex = 3
        '
        'cbb_Type
        '
        Me.cbb_Type.FormattingEnabled = True
        Me.cbb_Type.Items.AddRange(New Object() {"Crank ratio", "Distance"})
        Me.cbb_Type.Location = New System.Drawing.Point(157, 74)
        Me.cbb_Type.Name = "cbb_Type"
        Me.cbb_Type.Size = New System.Drawing.Size(121, 21)
        Me.cbb_Type.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Type"
        '
        'txt_CrankRatio
        '
        Me.txt_CrankRatio.Location = New System.Drawing.Point(315, 75)
        Me.txt_CrankRatio.Name = "txt_CrankRatio"
        Me.txt_CrankRatio.Size = New System.Drawing.Size(57, 20)
        Me.txt_CrankRatio.TabIndex = 6
        '
        'txt_Distance
        '
        Me.txt_Distance.Location = New System.Drawing.Point(390, 75)
        Me.txt_Distance.Name = "txt_Distance"
        Me.txt_Distance.Size = New System.Drawing.Size(57, 20)
        Me.txt_Distance.TabIndex = 7
        '
        'cbb_Spaccing
        '
        Me.cbb_Spaccing.FormattingEnabled = True
        Me.cbb_Spaccing.Items.AddRange(New Object() {"Auto", "Fixed"})
        Me.cbb_Spaccing.Location = New System.Drawing.Point(56, 136)
        Me.cbb_Spaccing.Name = "cbb_Spaccing"
        Me.cbb_Spaccing.Size = New System.Drawing.Size(60, 21)
        Me.cbb_Spaccing.TabIndex = 8
        '
        'cbb_CrankOrientation
        '
        Me.cbb_CrankOrientation.FormattingEnabled = True
        Me.cbb_CrankOrientation.Items.AddRange(New Object() {"Under", "On"})
        Me.cbb_CrankOrientation.Location = New System.Drawing.Point(420, 228)
        Me.cbb_CrankOrientation.Name = "cbb_CrankOrientation"
        Me.cbb_CrankOrientation.Size = New System.Drawing.Size(93, 21)
        Me.cbb_CrankOrientation.TabIndex = 9
        '
        'txt_LapLenght
        '
        Me.txt_LapLenght.Location = New System.Drawing.Point(257, 228)
        Me.txt_LapLenght.Name = "txt_LapLenght"
        Me.txt_LapLenght.Size = New System.Drawing.Size(93, 20)
        Me.txt_LapLenght.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(276, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Lap lenght"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(424, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Crank orientation"
        '
        'cbb_name
        '
        Me.cbb_name.FormattingEnabled = True
        Me.cbb_name.Items.AddRange(New Object() {"Crank ratio", "Distance"})
        Me.cbb_name.Location = New System.Drawing.Point(312, 12)
        Me.cbb_name.Name = "cbb_name"
        Me.cbb_name.Size = New System.Drawing.Size(121, 21)
        Me.cbb_name.TabIndex = 13
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(150, 10)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save.TabIndex = 14
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_Load
        '
        Me.btn_Load.Location = New System.Drawing.Point(231, 10)
        Me.btn_Load.Name = "btn_Load"
        Me.btn_Load.Size = New System.Drawing.Size(75, 23)
        Me.btn_Load.TabIndex = 15
        Me.btn_Load.Text = "Load"
        Me.btn_Load.UseVisualStyleBackColor = True
        '
        'txt_SaveAs
        '
        Me.txt_SaveAs.Location = New System.Drawing.Point(439, 13)
        Me.txt_SaveAs.Name = "txt_SaveAs"
        Me.txt_SaveAs.Size = New System.Drawing.Size(121, 20)
        Me.txt_SaveAs.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 333)
        Me.Controls.Add(Me.txt_SaveAs)
        Me.Controls.Add(Me.btn_Load)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.cbb_name)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_LapLenght)
        Me.Controls.Add(Me.cbb_CrankOrientation)
        Me.Controls.Add(Me.cbb_Spaccing)
        Me.Controls.Add(Me.txt_Distance)
        Me.Controls.Add(Me.txt_CrankRatio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbb_Type)
        Me.Controls.Add(Me.txt_Spacing)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_action)
        Me.Name = "Form1"
        Me.Text = "BimWorks"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_action As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_Spacing As TextBox
    Friend WithEvents cbb_Type As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_CrankRatio As TextBox
    Friend WithEvents txt_Distance As TextBox
    Friend WithEvents cbb_Spaccing As ComboBox
    Friend WithEvents cbb_CrankOrientation As ComboBox
    Friend WithEvents txt_LapLenght As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbb_name As ComboBox
    Friend WithEvents btn_Save As Button
    Friend WithEvents btn_Load As Button
    Friend WithEvents txt_SaveAs As TextBox
End Class
