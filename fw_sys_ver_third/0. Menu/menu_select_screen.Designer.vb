<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class menu_select_screen
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Tester = New System.Windows.Forms.Button()
        Me.btn_ML = New System.Windows.Forms.Button()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(84, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "메뉴를 선택하세요."
        '
        'btn_Tester
        '
        Me.btn_Tester.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Tester.FlatAppearance.BorderSize = 0
        Me.btn_Tester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Tester.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Tester.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_Tester.Location = New System.Drawing.Point(49, 251)
        Me.btn_Tester.Name = "btn_Tester"
        Me.btn_Tester.Size = New System.Drawing.Size(181, 24)
        Me.btn_Tester.TabIndex = 10
        Me.btn_Tester.Text = "Tester(검증원)"
        Me.btn_Tester.UseVisualStyleBackColor = False
        '
        'btn_ML
        '
        Me.btn_ML.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_ML.FlatAppearance.BorderSize = 0
        Me.btn_ML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ML.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_ML.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ML.Location = New System.Drawing.Point(49, 196)
        Me.btn_ML.Name = "btn_ML"
        Me.btn_ML.Size = New System.Drawing.Size(181, 24)
        Me.btn_ML.TabIndex = 11
        Me.btn_ML.Text = "Model Leader(ML)"
        Me.btn_ML.UseVisualStyleBackColor = False
        '
        'btnAdmin
        '
        Me.btnAdmin.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnAdmin.FlatAppearance.BorderSize = 0
        Me.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdmin.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAdmin.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAdmin.Location = New System.Drawing.Point(49, 137)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(181, 24)
        Me.btnAdmin.TabIndex = 12
        Me.btnAdmin.Text = "Administrator(관리자)"
        Me.btnAdmin.UseVisualStyleBackColor = False
        '
        'menu_select_screen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Tester)
        Me.Controls.Add(Me.btn_ML)
        Me.Controls.Add(Me.btnAdmin)
        Me.Name = "menu_select_screen"
        Me.Size = New System.Drawing.Size(292, 402)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Tester As Button
    Friend WithEvents btn_ML As Button
    Friend WithEvents btnAdmin As Button
End Class
