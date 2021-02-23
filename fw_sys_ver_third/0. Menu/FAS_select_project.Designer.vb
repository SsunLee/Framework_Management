<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAS_select_project
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAS_select_project))
        Me.cb_pjt = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_year = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_back = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbModel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbStep = New System.Windows.Forms.ComboBox()
        Me.pn_model = New System.Windows.Forms.Panel()
        Me.pn_step = New System.Windows.Forms.Panel()
        Me.pn_grp = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbGrp = New System.Windows.Forms.ComboBox()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.pn_model.SuspendLayout()
        Me.pn_step.SuspendLayout()
        Me.pn_grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'cb_pjt
        '
        Me.cb_pjt.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cb_pjt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_pjt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cb_pjt.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cb_pjt.FormattingEnabled = True
        Me.cb_pjt.Location = New System.Drawing.Point(51, 199)
        Me.cb_pjt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb_pjt.Name = "cb_pjt"
        Me.cb_pjt.Size = New System.Drawing.Size(178, 23)
        Me.cb_pjt.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Location = New System.Drawing.Point(51, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "* 프로젝트를 선택하세요."
        '
        'cb_year
        '
        Me.cb_year.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cb_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_year.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cb_year.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cb_year.FormattingEnabled = True
        Me.cb_year.Location = New System.Drawing.Point(51, 106)
        Me.cb_year.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb_year.Name = "cb_year"
        Me.cb_year.Size = New System.Drawing.Size(178, 23)
        Me.cb_year.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Location = New System.Drawing.Point(51, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "* 연도를 선택하세요."
        '
        'btn_back
        '
        Me.btn_back.FlatAppearance.BorderSize = 0
        Me.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_back.Image = CType(resources.GetObject("btn_back.Image"), System.Drawing.Image)
        Me.btn_back.Location = New System.Drawing.Point(3, 3)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(29, 23)
        Me.btn_back.TabIndex = 7
        Me.btn_back.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Location = New System.Drawing.Point(18, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "* 모델명을 선택하세요."
        '
        'cbModel
        '
        Me.cbModel.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbModel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cbModel.FormattingEnabled = True
        Me.cbModel.Location = New System.Drawing.Point(18, 33)
        Me.cbModel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbModel.Name = "cbModel"
        Me.cbModel.Size = New System.Drawing.Size(178, 23)
        Me.cbModel.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Location = New System.Drawing.Point(16, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "* 차수를 선택하세요."
        '
        'cbStep
        '
        Me.cbStep.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cbStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStep.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbStep.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cbStep.FormattingEnabled = True
        Me.cbStep.Location = New System.Drawing.Point(16, 31)
        Me.cbStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbStep.Name = "cbStep"
        Me.cbStep.Size = New System.Drawing.Size(178, 23)
        Me.cbStep.TabIndex = 5
        '
        'pn_model
        '
        Me.pn_model.Controls.Add(Me.Label3)
        Me.pn_model.Controls.Add(Me.cbModel)
        Me.pn_model.Location = New System.Drawing.Point(33, 344)
        Me.pn_model.Name = "pn_model"
        Me.pn_model.Size = New System.Drawing.Size(238, 72)
        Me.pn_model.TabIndex = 8
        '
        'pn_step
        '
        Me.pn_step.Controls.Add(Me.Label4)
        Me.pn_step.Controls.Add(Me.cbStep)
        Me.pn_step.Location = New System.Drawing.Point(33, 439)
        Me.pn_step.Name = "pn_step"
        Me.pn_step.Size = New System.Drawing.Size(237, 70)
        Me.pn_step.TabIndex = 9
        '
        'pn_grp
        '
        Me.pn_grp.Controls.Add(Me.Label5)
        Me.pn_grp.Controls.Add(Me.cbGrp)
        Me.pn_grp.Location = New System.Drawing.Point(33, 251)
        Me.pn_grp.Name = "pn_grp"
        Me.pn_grp.Size = New System.Drawing.Size(238, 71)
        Me.pn_grp.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Location = New System.Drawing.Point(16, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "* 출시지역을 선택하세요."
        '
        'cbGrp
        '
        Me.cbGrp.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.cbGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbGrp.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cbGrp.FormattingEnabled = True
        Me.cbGrp.Location = New System.Drawing.Point(16, 35)
        Me.cbGrp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbGrp.Name = "cbGrp"
        Me.cbGrp.Size = New System.Drawing.Size(178, 23)
        Me.cbGrp.TabIndex = 5
        '
        'btn_Save
        '
        Me.btn_Save.BackColor = System.Drawing.Color.CadetBlue
        Me.btn_Save.FlatAppearance.BorderSize = 0
        Me.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Save.ForeColor = System.Drawing.Color.White
        Me.btn_Save.Location = New System.Drawing.Point(78, 527)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(90, 32)
        Me.btn_Save.TabIndex = 10
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = False
        '
        'FAS_select_project
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.pn_step)
        Me.Controls.Add(Me.pn_grp)
        Me.Controls.Add(Me.pn_model)
        Me.Controls.Add(Me.btn_back)
        Me.Controls.Add(Me.cb_pjt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb_year)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FAS_select_project"
        Me.Size = New System.Drawing.Size(292, 574)
        Me.pn_model.ResumeLayout(False)
        Me.pn_model.PerformLayout()
        Me.pn_step.ResumeLayout(False)
        Me.pn_step.PerformLayout()
        Me.pn_grp.ResumeLayout(False)
        Me.pn_grp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents cb_pjt As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cb_year As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_back As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbModel As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbStep As ComboBox
    Friend WithEvents pn_model As Panel
    Friend WithEvents pn_step As Panel
    Friend WithEvents pn_grp As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents cbGrp As ComboBox
    Friend WithEvents btn_Save As Button
End Class
