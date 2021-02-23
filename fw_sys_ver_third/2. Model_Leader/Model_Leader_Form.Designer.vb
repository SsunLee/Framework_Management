<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Model_Leader_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Model_Leader_Form))
        Me.Left_Menu_Panel = New System.Windows.Forms.Panel()
        Me.btn_Ass = New System.Windows.Forms.Button()
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Title_area_panel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.la_step = New System.Windows.Forms.Label()
        Me.la_model = New System.Windows.Forms.Label()
        Me.la_grp = New System.Windows.Forms.Label()
        Me.la_pjt = New System.Windows.Forms.Label()
        Me.Main_Area_Panel = New System.Windows.Forms.Panel()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.Left_Menu_Panel.SuspendLayout()
        Me.Title_area_panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Left_Menu_Panel
        '
        Me.Left_Menu_Panel.AllowDrop = True
        Me.Left_Menu_Panel.AutoScroll = True
        Me.Left_Menu_Panel.BackColor = System.Drawing.Color.SteelBlue
        Me.Left_Menu_Panel.Controls.Add(Me.btn_view)
        Me.Left_Menu_Panel.Controls.Add(Me.btn_Ass)
        Me.Left_Menu_Panel.Controls.Add(Me.btn_Add)
        Me.Left_Menu_Panel.Controls.Add(Me.Label1)
        Me.Left_Menu_Panel.Dock = System.Windows.Forms.DockStyle.Left
        Me.Left_Menu_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Left_Menu_Panel.Name = "Left_Menu_Panel"
        Me.Left_Menu_Panel.Size = New System.Drawing.Size(157, 591)
        Me.Left_Menu_Panel.TabIndex = 0
        '
        'btn_Ass
        '
        Me.btn_Ass.FlatAppearance.BorderSize = 0
        Me.btn_Ass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Ass.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Ass.ForeColor = System.Drawing.Color.White
        Me.btn_Ass.Image = CType(resources.GetObject("btn_Ass.Image"), System.Drawing.Image)
        Me.btn_Ass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Ass.Location = New System.Drawing.Point(24, 111)
        Me.btn_Ass.Name = "btn_Ass"
        Me.btn_Ass.Size = New System.Drawing.Size(120, 31)
        Me.btn_Ass.TabIndex = 1
        Me.btn_Ass.Text = "       F/W 할당"
        Me.btn_Ass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Ass.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.FlatAppearance.BorderSize = 0
        Me.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Add.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Add.ForeColor = System.Drawing.Color.White
        Me.btn_Add.Image = CType(resources.GetObject("btn_Add.Image"), System.Drawing.Image)
        Me.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add.Location = New System.Drawing.Point(24, 61)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(120, 31)
        Me.btn_Add.TabIndex = 1
        Me.btn_Add.Text = "       F/W 등록"
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
        Me.Title_area_panel.Controls.Add(Me.Label2)
        Me.Title_area_panel.Controls.Add(Me.la_step)
        Me.Title_area_panel.Controls.Add(Me.la_model)
        Me.Title_area_panel.Controls.Add(Me.la_grp)
        Me.Title_area_panel.Controls.Add(Me.la_pjt)
        Me.Title_area_panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_area_panel.Location = New System.Drawing.Point(157, 0)
        Me.Title_area_panel.Name = "Title_area_panel"
        Me.Title_area_panel.Size = New System.Drawing.Size(1023, 33)
        Me.Title_area_panel.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "프로젝트 Info :"
        '
        'la_step
        '
        Me.la_step.AutoSize = True
        Me.la_step.BackColor = System.Drawing.Color.White
        Me.la_step.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.la_step.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.la_step.Location = New System.Drawing.Point(625, 9)
        Me.la_step.Name = "la_step"
        Me.la_step.Size = New System.Drawing.Size(41, 13)
        Me.la_step.TabIndex = 57
        Me.la_step.Text = "Label2"
        '
        'la_model
        '
        Me.la_model.AutoSize = True
        Me.la_model.BackColor = System.Drawing.Color.White
        Me.la_model.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.la_model.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.la_model.Location = New System.Drawing.Point(441, 9)
        Me.la_model.Name = "la_model"
        Me.la_model.Size = New System.Drawing.Size(41, 13)
        Me.la_model.TabIndex = 57
        Me.la_model.Text = "Label2"
        '
        'la_grp
        '
        Me.la_grp.AutoSize = True
        Me.la_grp.BackColor = System.Drawing.Color.White
        Me.la_grp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.la_grp.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.la_grp.Location = New System.Drawing.Point(289, 9)
        Me.la_grp.Name = "la_grp"
        Me.la_grp.Size = New System.Drawing.Size(41, 13)
        Me.la_grp.TabIndex = 57
        Me.la_grp.Text = "Label2"
        '
        'la_pjt
        '
        Me.la_pjt.AutoSize = True
        Me.la_pjt.BackColor = System.Drawing.Color.White
        Me.la_pjt.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.la_pjt.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.la_pjt.Location = New System.Drawing.Point(165, 9)
        Me.la_pjt.Name = "la_pjt"
        Me.la_pjt.Size = New System.Drawing.Size(41, 13)
        Me.la_pjt.TabIndex = 57
        Me.la_pjt.Text = "Label2"
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
        'btn_view
        '
        Me.btn_view.FlatAppearance.BorderSize = 0
        Me.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_view.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_view.ForeColor = System.Drawing.Color.White
        Me.btn_view.Image = CType(resources.GetObject("btn_view.Image"), System.Drawing.Image)
        Me.btn_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_view.Location = New System.Drawing.Point(24, 161)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(120, 31)
        Me.btn_view.TabIndex = 1
        Me.btn_view.Text = "       Viewer"
        Me.btn_view.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_view.UseVisualStyleBackColor = True
        '
        'Model_Leader_Form
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1180, 591)
        Me.Controls.Add(Me.Main_Area_Panel)
        Me.Controls.Add(Me.Title_area_panel)
        Me.Controls.Add(Me.Left_Menu_Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Model_Leader_Form"
        Me.Text = "FW 아이템 등록 및 할당"
        Me.Left_Menu_Panel.ResumeLayout(False)
        Me.Left_Menu_Panel.PerformLayout()
        Me.Title_area_panel.ResumeLayout(False)
        Me.Title_area_panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Left_Menu_Panel As Panel
    Friend WithEvents Title_area_panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Ass As Button
    Friend WithEvents btn_Add As Button
    Friend WithEvents Main_Area_Panel As Panel
    Friend WithEvents la_step As Label
    Friend WithEvents la_model As Label
    Friend WithEvents la_grp As Label
    Friend WithEvents la_pjt As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_view As Button
End Class
