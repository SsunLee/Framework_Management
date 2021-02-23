<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Administrator_Form
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Administrator_Form))
        Me.Left_Menu_Panel = New System.Windows.Forms.Panel()
        Me.btn_Random = New System.Windows.Forms.Button()
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Title_area_panel = New System.Windows.Forms.Panel()
        Me.Main_Area_Panel = New System.Windows.Forms.Panel()
        Me.Left_Menu_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Left_Menu_Panel
        '
        Me.Left_Menu_Panel.AllowDrop = True
        Me.Left_Menu_Panel.AutoScroll = True
        Me.Left_Menu_Panel.BackColor = System.Drawing.Color.SteelBlue
        Me.Left_Menu_Panel.Controls.Add(Me.btn_Random)
        Me.Left_Menu_Panel.Controls.Add(Me.btn_Add)
        Me.Left_Menu_Panel.Controls.Add(Me.Label1)
        Me.Left_Menu_Panel.Dock = System.Windows.Forms.DockStyle.Left
        Me.Left_Menu_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Left_Menu_Panel.Name = "Left_Menu_Panel"
        Me.Left_Menu_Panel.Size = New System.Drawing.Size(157, 591)
        Me.Left_Menu_Panel.TabIndex = 0
        '
        'btn_Random
        '
        Me.btn_Random.FlatAppearance.BorderSize = 0
        Me.btn_Random.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Random.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Random.ForeColor = System.Drawing.Color.White
        Me.btn_Random.Image = CType(resources.GetObject("btn_Random.Image"), System.Drawing.Image)
        Me.btn_Random.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Random.Location = New System.Drawing.Point(12, 111)
        Me.btn_Random.Name = "btn_Random"
        Me.btn_Random.Size = New System.Drawing.Size(132, 31)
        Me.btn_Random.TabIndex = 1
        Me.btn_Random.Text = "       인원 관리"
        Me.btn_Random.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Random.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.FlatAppearance.BorderSize = 0
        Me.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Add.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Add.ForeColor = System.Drawing.Color.White
        Me.btn_Add.Image = CType(resources.GetObject("btn_Add.Image"), System.Drawing.Image)
        Me.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add.Location = New System.Drawing.Point(12, 61)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(132, 31)
        Me.btn_Add.TabIndex = 1
        Me.btn_Add.Text = "       투입 현황"
        Me.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "F/W Assign System"
        '
        'Title_area_panel
        '
        Me.Title_area_panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_area_panel.Location = New System.Drawing.Point(157, 0)
        Me.Title_area_panel.Name = "Title_area_panel"
        Me.Title_area_panel.Size = New System.Drawing.Size(1023, 33)
        Me.Title_area_panel.TabIndex = 1
        '
        'Main_Area_Panel
        '
        Me.Main_Area_Panel.AutoScroll = True
        Me.Main_Area_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Area_Panel.Location = New System.Drawing.Point(157, 33)
        Me.Main_Area_Panel.Name = "Main_Area_Panel"
        Me.Main_Area_Panel.Size = New System.Drawing.Size(1023, 558)
        Me.Main_Area_Panel.TabIndex = 2
        '
        'Administrator_Form
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1180, 591)
        Me.Controls.Add(Me.Main_Area_Panel)
        Me.Controls.Add(Me.Title_area_panel)
        Me.Controls.Add(Me.Left_Menu_Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Administrator_Form"
        Me.Text = "Administrator(관리자)"
        Me.Left_Menu_Panel.ResumeLayout(False)
        Me.Left_Menu_Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Left_Menu_Panel As Panel
    Friend WithEvents Title_area_panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Random As Button
    Friend WithEvents btn_Add As Button
    Friend WithEvents Main_Area_Panel As Panel
End Class
