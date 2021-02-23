<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_index
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_index))
        Me.btn_connect_fw = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_pjt = New System.Windows.Forms.Button()
        Me.laName = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_connect_fw
        '
        Me.btn_connect_fw.FlatAppearance.BorderSize = 0
        Me.btn_connect_fw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_connect_fw.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_connect_fw.ForeColor = System.Drawing.Color.Gray
        Me.btn_connect_fw.Image = CType(resources.GetObject("btn_connect_fw.Image"), System.Drawing.Image)
        Me.btn_connect_fw.Location = New System.Drawing.Point(428, 158)
        Me.btn_connect_fw.Name = "btn_connect_fw"
        Me.btn_connect_fw.Size = New System.Drawing.Size(131, 122)
        Me.btn_connect_fw.TabIndex = 0
        Me.btn_connect_fw.Text = "FW Assign System"
        Me.btn_connect_fw.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_connect_fw.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(646, 429)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Local Version : 0.0.1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(10, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(146, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(162, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "for Developer"
        '
        'btn_pjt
        '
        Me.btn_pjt.FlatAppearance.BorderSize = 0
        Me.btn_pjt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pjt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_pjt.ForeColor = System.Drawing.Color.Gray
        Me.btn_pjt.Image = CType(resources.GetObject("btn_pjt.Image"), System.Drawing.Image)
        Me.btn_pjt.Location = New System.Drawing.Point(212, 158)
        Me.btn_pjt.Name = "btn_pjt"
        Me.btn_pjt.Size = New System.Drawing.Size(131, 122)
        Me.btn_pjt.TabIndex = 0
        Me.btn_pjt.Text = "New Project"
        Me.btn_pjt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_pjt.UseVisualStyleBackColor = True
        '
        'laName
        '
        Me.laName.AutoSize = True
        Me.laName.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.laName.ForeColor = System.Drawing.Color.Gray
        Me.laName.Location = New System.Drawing.Point(444, 11)
        Me.laName.Name = "laName"
        Me.laName.Size = New System.Drawing.Size(0, 13)
        Me.laName.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 438)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Main_index
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.laName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_pjt)
        Me.Controls.Add(Me.btn_connect_fw)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main_index"
        Me.Text = "Main_index"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_connect_fw As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_pjt As Button
    Friend WithEvents laName As Label
    Friend WithEvents Button1 As Button
End Class
