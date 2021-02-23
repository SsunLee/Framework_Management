<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class uc_m_model
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_m_model))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.StartDate = New System.Windows.Forms.DateTimePicker()
        Me.EndDate = New System.Windows.Forms.DateTimePicker()
        Me.txtML = New System.Windows.Forms.TextBox()
        Me.txtMM = New System.Windows.Forms.TextBox()
        Me.txtPL = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAddPjt = New System.Windows.Forms.Button()
        Me.btnAddGrp = New System.Windows.Forms.Button()
        Me.btnAddMod = New System.Windows.Forms.Button()
        Me.btn_AddStep = New System.Windows.Forms.Button()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1266, 35)
        Me.Panel4.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Model List"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(19, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 584
        Me.Label8.Text = "Project"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label9.Location = New System.Drawing.Point(496, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 584
        Me.Label9.Text = "모델리더"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label10.Location = New System.Drawing.Point(646, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 584
        Me.Label10.Text = "MM Part"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label11.Location = New System.Drawing.Point(776, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 584
        Me.Label11.Text = "PL개발실"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(195, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 585
        Me.Label1.Text = "Group"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(325, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 586
        Me.Label3.Text = "Model"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(595, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 587
        Me.Label4.Text = "Step"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(241, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 589
        Me.Label6.Text = "~"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(21, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(313, 13)
        Me.Label7.TabIndex = 592
        Me.Label7.Text = "데이터 삭제는 오삭제 방지를 위해 담당자에게 요청 바랍니다."
        '
        'btnCommit
        '
        Me.btnCommit.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCommit.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnCommit.ForeColor = System.Drawing.Color.White
        Me.btnCommit.Location = New System.Drawing.Point(779, 43)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(116, 68)
        Me.btnCommit.TabIndex = 593
        Me.btnCommit.Text = "Commit"
        Me.btnCommit.UseVisualStyleBackColor = False
        '
        'StartDate
        '
        Me.StartDate.CalendarFont = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.StartDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.StartDate.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.StartDate.Location = New System.Drawing.Point(24, 154)
        Me.StartDate.MaxDate = New Date(2023, 12, 31, 0, 0, 0, 0)
        Me.StartDate.MinDate = New Date(2014, 1, 1, 0, 0, 0, 0)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Size = New System.Drawing.Size(201, 22)
        Me.StartDate.TabIndex = 594
        '
        'EndDate
        '
        Me.EndDate.CalendarFont = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.EndDate.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EndDate.Location = New System.Drawing.Point(272, 154)
        Me.EndDate.MaxDate = New Date(2023, 12, 31, 0, 0, 0, 0)
        Me.EndDate.MinDate = New Date(2014, 1, 1, 0, 0, 0, 0)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(200, 22)
        Me.EndDate.TabIndex = 595
        '
        'txtML
        '
        Me.txtML.BackColor = System.Drawing.SystemColors.Info
        Me.txtML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtML.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtML.Location = New System.Drawing.Point(499, 154)
        Me.txtML.Name = "txtML"
        Me.txtML.Size = New System.Drawing.Size(126, 22)
        Me.txtML.TabIndex = 601
        '
        'txtMM
        '
        Me.txtMM.BackColor = System.Drawing.SystemColors.Info
        Me.txtMM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMM.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtMM.Location = New System.Drawing.Point(645, 154)
        Me.txtMM.Name = "txtMM"
        Me.txtMM.Size = New System.Drawing.Size(115, 22)
        Me.txtMM.TabIndex = 601
        '
        'txtPL
        '
        Me.txtPL.BackColor = System.Drawing.SystemColors.Info
        Me.txtPL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPL.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtPL.Location = New System.Drawing.Point(779, 154)
        Me.txtPL.Name = "txtPL"
        Me.txtPL.Size = New System.Drawing.Size(116, 22)
        Me.txtPL.TabIndex = 601
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel13)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1266, 633)
        Me.Panel1.TabIndex = 2
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.Label8)
        Me.Panel13.Controls.Add(Me.Label5)
        Me.Panel13.Controls.Add(Me.Label9)
        Me.Panel13.Controls.Add(Me.btnDel)
        Me.Panel13.Controls.Add(Me.Label10)
        Me.Panel13.Controls.Add(Me.btnAddPjt)
        Me.Panel13.Controls.Add(Me.Label11)
        Me.Panel13.Controls.Add(Me.btnAddGrp)
        Me.Panel13.Controls.Add(Me.Label1)
        Me.Panel13.Controls.Add(Me.btnAddMod)
        Me.Panel13.Controls.Add(Me.Label3)
        Me.Panel13.Controls.Add(Me.btn_AddStep)
        Me.Panel13.Controls.Add(Me.Label4)
        Me.Panel13.Controls.Add(Me.ListBox4)
        Me.Panel13.Controls.Add(Me.ListBox3)
        Me.Panel13.Controls.Add(Me.Label6)
        Me.Panel13.Controls.Add(Me.ListBox2)
        Me.Panel13.Controls.Add(Me.Label7)
        Me.Panel13.Controls.Add(Me.ListBox1)
        Me.Panel13.Controls.Add(Me.btnCommit)
        Me.Panel13.Controls.Add(Me.txtPL)
        Me.Panel13.Controls.Add(Me.StartDate)
        Me.Panel13.Controls.Add(Me.txtMM)
        Me.Panel13.Controls.Add(Me.EndDate)
        Me.Panel13.Controls.Add(Me.txtML)
        Me.Panel13.Location = New System.Drawing.Point(15, 51)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1141, 415)
        Me.Panel13.TabIndex = 613
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(21, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 584
        Me.Label5.Text = "모델 일정"
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.Transparent
        Me.btnDel.BackgroundImage = CType(resources.GetObject("btnDel.BackgroundImage"), System.Drawing.Image)
        Me.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDel.Location = New System.Drawing.Point(643, 14)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(29, 23)
        Me.btnDel.TabIndex = 610
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
        Me.btnAddPjt.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAddPjt.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddPjt.Location = New System.Drawing.Point(150, 14)
        Me.btnAddPjt.Name = "btnAddPjt"
        Me.btnAddPjt.Size = New System.Drawing.Size(25, 25)
        Me.btnAddPjt.TabIndex = 608
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
        Me.btnAddGrp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAddGrp.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddGrp.Location = New System.Drawing.Point(285, 16)
        Me.btnAddGrp.Name = "btnAddGrp"
        Me.btnAddGrp.Size = New System.Drawing.Size(25, 25)
        Me.btnAddGrp.TabIndex = 609
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
        Me.btnAddMod.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAddMod.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddMod.Location = New System.Drawing.Point(543, 16)
        Me.btnAddMod.Name = "btnAddMod"
        Me.btnAddMod.Size = New System.Drawing.Size(25, 25)
        Me.btnAddMod.TabIndex = 607
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
        Me.btn_AddStep.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_AddStep.ForeColor = System.Drawing.Color.Transparent
        Me.btn_AddStep.Location = New System.Drawing.Point(678, 13)
        Me.btn_AddStep.Name = "btn_AddStep"
        Me.btn_AddStep.Size = New System.Drawing.Size(25, 25)
        Me.btn_AddStep.TabIndex = 606
        Me.btn_AddStep.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_AddStep.UseVisualStyleBackColor = False
        '
        'ListBox4
        '
        Me.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.Location = New System.Drawing.Point(599, 43)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(104, 67)
        Me.ListBox4.TabIndex = 605
        '
        'ListBox3
        '
        Me.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(329, 44)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(239, 67)
        Me.ListBox3.TabIndex = 604
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(195, 44)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(115, 67)
        Me.ListBox2.TabIndex = 603
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(23, 44)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(152, 67)
        Me.ListBox1.TabIndex = 602
        '
        'uc_m_model
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Name = "uc_m_model"
        Me.Size = New System.Drawing.Size(1266, 633)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents btnCommit As Windows.Forms.Button
    Friend WithEvents StartDate As Windows.Forms.DateTimePicker
    Friend WithEvents EndDate As Windows.Forms.DateTimePicker
    Friend WithEvents txtML As Windows.Forms.TextBox
    Friend WithEvents txtMM As Windows.Forms.TextBox
    Friend WithEvents txtPL As Windows.Forms.TextBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents ListBox4 As Windows.Forms.ListBox
    Friend WithEvents ListBox3 As Windows.Forms.ListBox
    Friend WithEvents ListBox2 As Windows.Forms.ListBox
    Friend WithEvents ListBox1 As Windows.Forms.ListBox
    Friend WithEvents btnDel As Windows.Forms.Button
    Friend WithEvents btnAddPjt As Windows.Forms.Button
    Friend WithEvents btnAddGrp As Windows.Forms.Button
    Friend WithEvents btnAddMod As Windows.Forms.Button
    Friend WithEvents btn_AddStep As Windows.Forms.Button
    Friend WithEvents Panel13 As Windows.Forms.Panel
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
