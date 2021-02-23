<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_m_level_upload
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_m_level_upload))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_template = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_ex_up = New System.Windows.Forms.Button()
        Me.lst_up = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(12, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "검증원 역량 업로드"
        '
        'btn_template
        '
        Me.btn_template.BackColor = System.Drawing.Color.LemonChiffon
        Me.btn_template.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_template.FlatAppearance.BorderSize = 0
        Me.btn_template.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_template.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_template.ForeColor = System.Drawing.Color.Black
        Me.btn_template.Image = CType(resources.GetObject("btn_template.Image"), System.Drawing.Image)
        Me.btn_template.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_template.Location = New System.Drawing.Point(145, -1)
        Me.btn_template.Name = "btn_template"
        Me.btn_template.Size = New System.Drawing.Size(155, 21)
        Me.btn_template.TabIndex = 617
        Me.btn_template.Text = "     최신 템플릿 문서 다운로드"
        Me.btn_template.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_template.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btn_template)
        Me.GroupBox1.Controls.Add(Me.btn_ex_up)
        Me.GroupBox1.Controls.Add(Me.lst_up)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 180)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btn_ex_up
        '
        Me.btn_ex_up.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_ex_up.FlatAppearance.BorderSize = 0
        Me.btn_ex_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ex_up.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_ex_up.ForeColor = System.Drawing.Color.Black
        Me.btn_ex_up.Image = CType(resources.GetObject("btn_ex_up.Image"), System.Drawing.Image)
        Me.btn_ex_up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ex_up.Location = New System.Drawing.Point(217, 82)
        Me.btn_ex_up.Name = "btn_ex_up"
        Me.btn_ex_up.Size = New System.Drawing.Size(70, 24)
        Me.btn_ex_up.TabIndex = 617
        Me.btn_ex_up.Text = "     업로드"
        Me.btn_ex_up.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ex_up.UseVisualStyleBackColor = True
        '
        'lst_up
        '
        Me.lst_up.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.lst_up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lst_up.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lst_up.ForeColor = System.Drawing.Color.Black
        Me.lst_up.FormattingEnabled = True
        Me.lst_up.Location = New System.Drawing.Point(15, 35)
        Me.lst_up.Name = "lst_up"
        Me.lst_up.Size = New System.Drawing.Size(272, 41)
        Me.lst_up.TabIndex = 3
        '
        'Timer1
        '
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 148)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(272, 10)
        Me.ProgressBar1.TabIndex = 618
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(16, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 619
        Me.Label1.Text = "Label1"
        '
        'uc_m_level_upload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "uc_m_level_upload"
        Me.Size = New System.Drawing.Size(336, 209)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents btn_template As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_ex_up As Button
    Friend WithEvents lst_up As ListBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
End Class
