<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FW_ADD_MODEL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FW_ADD_MODEL))
        Me.Main_Panel = New System.Windows.Forms.Panel()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAddPjt = New System.Windows.Forms.Button()
        Me.btnAddGrp = New System.Windows.Forms.Button()
        Me.btnAddMod = New System.Windows.Forms.Button()
        Me.btn_AddStep = New System.Windows.Forms.Button()
        Me.EndDate = New System.Windows.Forms.DateTimePicker()
        Me.StartDate = New System.Windows.Forms.DateTimePicker()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Main_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Main_Panel
        '
        Me.Main_Panel.Controls.Add(Me.btnDel)
        Me.Main_Panel.Controls.Add(Me.btnAddPjt)
        Me.Main_Panel.Controls.Add(Me.btnAddGrp)
        Me.Main_Panel.Controls.Add(Me.btnAddMod)
        Me.Main_Panel.Controls.Add(Me.btn_AddStep)
        Me.Main_Panel.Controls.Add(Me.EndDate)
        Me.Main_Panel.Controls.Add(Me.StartDate)
        Me.Main_Panel.Controls.Add(Me.btnCommit)
        Me.Main_Panel.Controls.Add(Me.Label7)
        Me.Main_Panel.Controls.Add(Me.ListBox4)
        Me.Main_Panel.Controls.Add(Me.ListBox3)
        Me.Main_Panel.Controls.Add(Me.Label6)
        Me.Main_Panel.Controls.Add(Me.Label5)
        Me.Main_Panel.Controls.Add(Me.Label4)
        Me.Main_Panel.Controls.Add(Me.Label3)
        Me.Main_Panel.Controls.Add(Me.Label2)
        Me.Main_Panel.Controls.Add(Me.Label1)
        Me.Main_Panel.Controls.Add(Me.ListBox2)
        Me.Main_Panel.Controls.Add(Me.ListBox1)
        Me.Main_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_Panel.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Main_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Main_Panel.Name = "Main_Panel"
        Me.Main_Panel.Size = New System.Drawing.Size(622, 367)
        Me.Main_Panel.TabIndex = 0
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.Transparent
        Me.btnDel.BackgroundImage = CType(resources.GetObject("btnDel.BackgroundImage"), System.Drawing.Image)
        Me.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDel.Location = New System.Drawing.Point(534, 19)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(29, 23)
        Me.btnDel.TabIndex = 581
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnAddPjt
        '
        Me.btnAddPjt.BackColor = System.Drawing.Color.Transparent
        Me.btnAddPjt.BackgroundImage = CType(resources.GetObject("btnAddPjt.BackgroundImage"), System.Drawing.Image)
        Me.btnAddPjt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddPjt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddPjt.FlatAppearance.BorderSize = 0
        Me.btnAddPjt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddPjt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddPjt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddPjt.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddPjt.Location = New System.Drawing.Point(108, 18)
        Me.btnAddPjt.Name = "btnAddPjt"
        Me.btnAddPjt.Size = New System.Drawing.Size(25, 25)
        Me.btnAddPjt.TabIndex = 580
        Me.btnAddPjt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddPjt.UseVisualStyleBackColor = False
        '
        'btnAddGrp
        '
        Me.btnAddGrp.BackColor = System.Drawing.Color.Transparent
        Me.btnAddGrp.BackgroundImage = CType(resources.GetObject("btnAddGrp.BackgroundImage"), System.Drawing.Image)
        Me.btnAddGrp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddGrp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddGrp.FlatAppearance.BorderSize = 0
        Me.btnAddGrp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddGrp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddGrp.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddGrp.Location = New System.Drawing.Point(243, 19)
        Me.btnAddGrp.Name = "btnAddGrp"
        Me.btnAddGrp.Size = New System.Drawing.Size(25, 25)
        Me.btnAddGrp.TabIndex = 580
        Me.btnAddGrp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddGrp.UseVisualStyleBackColor = False
        '
        'btnAddMod
        '
        Me.btnAddMod.BackColor = System.Drawing.Color.Transparent
        Me.btnAddMod.BackgroundImage = CType(resources.GetObject("btnAddMod.BackgroundImage"), System.Drawing.Image)
        Me.btnAddMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddMod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddMod.FlatAppearance.BorderSize = 0
        Me.btnAddMod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddMod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMod.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddMod.Location = New System.Drawing.Point(446, 19)
        Me.btnAddMod.Name = "btnAddMod"
        Me.btnAddMod.Size = New System.Drawing.Size(25, 25)
        Me.btnAddMod.TabIndex = 579
        Me.btnAddMod.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddMod.UseVisualStyleBackColor = False
        '
        'btn_AddStep
        '
        Me.btn_AddStep.BackColor = System.Drawing.Color.Transparent
        Me.btn_AddStep.BackgroundImage = CType(resources.GetObject("btn_AddStep.BackgroundImage"), System.Drawing.Image)
        Me.btn_AddStep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_AddStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_AddStep.FlatAppearance.BorderSize = 0
        Me.btn_AddStep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_AddStep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_AddStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AddStep.ForeColor = System.Drawing.Color.Transparent
        Me.btn_AddStep.Location = New System.Drawing.Point(569, 18)
        Me.btn_AddStep.Name = "btn_AddStep"
        Me.btn_AddStep.Size = New System.Drawing.Size(25, 25)
        Me.btn_AddStep.TabIndex = 578
        Me.btn_AddStep.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_AddStep.UseVisualStyleBackColor = False
        '
        'EndDate
        '
        Me.EndDate.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EndDate.Location = New System.Drawing.Point(228, 265)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(200, 23)
        Me.EndDate.TabIndex = 577
        '
        'StartDate
        '
        Me.StartDate.CalendarFont = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.StartDate.Location = New System.Drawing.Point(12, 265)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Size = New System.Drawing.Size(200, 23)
        Me.StartDate.TabIndex = 576
        '
        'btnCommit
        '
        Me.btnCommit.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCommit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCommit.ForeColor = System.Drawing.Color.White
        Me.btnCommit.Location = New System.Drawing.Point(491, 234)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(103, 100)
        Me.btnCommit.TabIndex = 575
        Me.btnCommit.Text = "Commit"
        Me.btnCommit.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(13, 317)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(371, 17)
        Me.Label7.TabIndex = 574
        Me.Label7.Text = "데이터 삭제는 오삭제 방지를 위해 담당자에게 요청 바랍니다."
        '
        'ListBox4
        '
        Me.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox4.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.ItemHeight = 15
        Me.ListBox4.Location = New System.Drawing.Point(490, 49)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(104, 167)
        Me.ListBox4.TabIndex = 573
        '
        'ListBox3
        '
        Me.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox3.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 15
        Me.ListBox3.Location = New System.Drawing.Point(287, 49)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(184, 167)
        Me.ListBox3.TabIndex = 572
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(224, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 19)
        Me.Label6.TabIndex = 571
        Me.Label6.Text = "EndDate"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(12, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 19)
        Me.Label5.TabIndex = 570
        Me.Label5.Text = "StartDate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(487, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 19)
        Me.Label4.TabIndex = 569
        Me.Label4.Text = "Step"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(285, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 19)
        Me.Label3.TabIndex = 568
        Me.Label3.Text = "Model"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(152, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 19)
        Me.Label2.TabIndex = 567
        Me.Label2.Text = "Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 19)
        Me.Label1.TabIndex = 566
        Me.Label1.Text = "Project"
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 15
        Me.ListBox2.Location = New System.Drawing.Point(153, 49)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(115, 167)
        Me.ListBox2.TabIndex = 565
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(12, 49)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(121, 167)
        Me.ListBox1.TabIndex = 564
        '
        'FW_ADD_MODEL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(622, 367)
        Me.Controls.Add(Me.Main_Panel)
        Me.Name = "FW_ADD_MODEL"
        Me.Text = "프로젝트 추가(New Project)"
        Me.Main_Panel.ResumeLayout(False)
        Me.Main_Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Main_Panel As Windows.Forms.Panel
    Friend WithEvents btnAddGrp As Windows.Forms.Button
    Friend WithEvents btnAddMod As Windows.Forms.Button
    Friend WithEvents btn_AddStep As Windows.Forms.Button
    Friend WithEvents EndDate As Windows.Forms.DateTimePicker
    Friend WithEvents StartDate As Windows.Forms.DateTimePicker
    Friend WithEvents btnCommit As Windows.Forms.Button
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents ListBox4 As Windows.Forms.ListBox
    Friend WithEvents ListBox3 As Windows.Forms.ListBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ListBox2 As Windows.Forms.ListBox
    Friend WithEvents ListBox1 As Windows.Forms.ListBox
    Friend WithEvents btnAddPjt As Windows.Forms.Button
    Friend WithEvents btnDel As Windows.Forms.Button
End Class
