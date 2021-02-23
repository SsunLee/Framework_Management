<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class uc_a_add
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_a_add))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.add_main_panel = New System.Windows.Forms.Panel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TreeListView1 = New WinControls.ListView.TreeListView()
        Me.btn_addrow = New System.Windows.Forms.PictureBox()
        Me.btn_member = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Slide_panel = New System.Windows.Forms.Panel()
        Me.txtseq = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEndin = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStepin = New System.Windows.Forms.TextBox()
        Me.btnS1 = New System.Windows.Forms.Button()
        Me.txtGroupin = New System.Windows.Forms.TextBox()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.txtStartin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtModelin = New System.Windows.Forms.TextBox()
        Me.cbCompany = New System.Windows.Forms.ComboBox()
        Me.txtProin = New System.Windows.Forms.TextBox()
        Me.btnS2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPro = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnS3 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnS4 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStep = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.add_main_panel.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_addrow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Slide_panel.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'add_main_panel
        '
        Me.add_main_panel.BackColor = System.Drawing.Color.White
        Me.add_main_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.add_main_panel.Controls.Add(Me.DataGridView2)
        Me.add_main_panel.Controls.Add(Me.TreeListView1)
        Me.add_main_panel.Controls.Add(Me.btn_addrow)
        Me.add_main_panel.Controls.Add(Me.btn_member)
        Me.add_main_panel.Controls.Add(Me.btn_save)
        Me.add_main_panel.Controls.Add(Me.Button7)
        Me.add_main_panel.Controls.Add(Me.Button3)
        Me.add_main_panel.Controls.Add(Me.Slide_panel)
        Me.add_main_panel.Controls.Add(Me.Button4)
        Me.add_main_panel.Controls.Add(Me.DataGridView1)
        Me.add_main_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.add_main_panel.Location = New System.Drawing.Point(0, 0)
        Me.add_main_panel.Name = "add_main_panel"
        Me.add_main_panel.Size = New System.Drawing.Size(872, 593)
        Me.add_main_panel.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(280, 131)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.Size = New System.Drawing.Size(368, 443)
        Me.DataGridView2.TabIndex = 69
        '
        'TreeListView1
        '
        Me.TreeListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TreeListView1.Location = New System.Drawing.Point(16, 131)
        Me.TreeListView1.Name = "TreeListView1"
        Me.TreeListView1.Size = New System.Drawing.Size(258, 443)
        Me.TreeListView1.TabIndex = 68
        '
        'btn_addrow
        '
        Me.btn_addrow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_addrow.Image = CType(resources.GetObject("btn_addrow.Image"), System.Drawing.Image)
        Me.btn_addrow.Location = New System.Drawing.Point(616, 109)
        Me.btn_addrow.Name = "btn_addrow"
        Me.btn_addrow.Size = New System.Drawing.Size(20, 16)
        Me.btn_addrow.TabIndex = 67
        Me.btn_addrow.TabStop = False
        '
        'btn_member
        '
        Me.btn_member.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_member.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_member.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_member.ForeColor = System.Drawing.Color.Gray
        Me.btn_member.Image = CType(resources.GetObject("btn_member.Image"), System.Drawing.Image)
        Me.btn_member.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_member.Location = New System.Drawing.Point(121, 101)
        Me.btn_member.Name = "btn_member"
        Me.btn_member.Size = New System.Drawing.Size(95, 24)
        Me.btn_member.TabIndex = 40
        Me.btn_member.Text = "    인원관리"
        Me.btn_member.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_save.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_save.ForeColor = System.Drawing.Color.Gray
        Me.btn_save.Image = CType(resources.GetObject("btn_save.Image"), System.Drawing.Image)
        Me.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_save.Location = New System.Drawing.Point(222, 101)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(95, 24)
        Me.btn_save.TabIndex = 40
        Me.btn_save.Text = "    Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Gray
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(755, 101)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(95, 24)
        Me.Button7.TabIndex = 40
        Me.Button7.Text = "    Upload"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Gray
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(654, 101)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(95, 24)
        Me.Button3.TabIndex = 39
        Me.Button3.Text = "    양식 D/L"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Slide_panel
        '
        Me.Slide_panel.BackColor = System.Drawing.Color.White
        Me.Slide_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Slide_panel.Controls.Add(Me.txtseq)
        Me.Slide_panel.Controls.Add(Me.Label16)
        Me.Slide_panel.Controls.Add(Me.Label8)
        Me.Slide_panel.Controls.Add(Me.txtEndin)
        Me.Slide_panel.Controls.Add(Me.Label5)
        Me.Slide_panel.Controls.Add(Me.txtStepin)
        Me.Slide_panel.Controls.Add(Me.btnS1)
        Me.Slide_panel.Controls.Add(Me.txtGroupin)
        Me.Slide_panel.Controls.Add(Me.txtModel)
        Me.Slide_panel.Controls.Add(Me.txtStartin)
        Me.Slide_panel.Controls.Add(Me.Label7)
        Me.Slide_panel.Controls.Add(Me.txtModelin)
        Me.Slide_panel.Controls.Add(Me.cbCompany)
        Me.Slide_panel.Controls.Add(Me.txtProin)
        Me.Slide_panel.Controls.Add(Me.btnS2)
        Me.Slide_panel.Controls.Add(Me.Label13)
        Me.Slide_panel.Controls.Add(Me.txtPro)
        Me.Slide_panel.Controls.Add(Me.Label14)
        Me.Slide_panel.Controls.Add(Me.Label6)
        Me.Slide_panel.Controls.Add(Me.btnS3)
        Me.Slide_panel.Controls.Add(Me.Label12)
        Me.Slide_panel.Controls.Add(Me.btnS4)
        Me.Slide_panel.Controls.Add(Me.Label11)
        Me.Slide_panel.Controls.Add(Me.txtStep)
        Me.Slide_panel.Controls.Add(Me.Label10)
        Me.Slide_panel.Controls.Add(Me.Label9)
        Me.Slide_panel.ForeColor = System.Drawing.Color.Gray
        Me.Slide_panel.Location = New System.Drawing.Point(16, 19)
        Me.Slide_panel.Name = "Slide_panel"
        Me.Slide_panel.Size = New System.Drawing.Size(834, 74)
        Me.Slide_panel.TabIndex = 32
        '
        'txtseq
        '
        Me.txtseq.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtseq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtseq.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtseq.ForeColor = System.Drawing.Color.Gray
        Me.txtseq.Location = New System.Drawing.Point(559, 81)
        Me.txtseq.Name = "txtseq"
        Me.txtseq.Size = New System.Drawing.Size(48, 15)
        Me.txtseq.TabIndex = 63
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(520, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 62
        Me.Label16.Text = "seq : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(412, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "차수"
        '
        'txtEndin
        '
        Me.txtEndin.BackColor = System.Drawing.Color.Gainsboro
        Me.txtEndin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEndin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtEndin.ForeColor = System.Drawing.Color.Gray
        Me.txtEndin.Location = New System.Drawing.Point(364, 79)
        Me.txtEndin.Name = "txtEndin"
        Me.txtEndin.Size = New System.Drawing.Size(150, 15)
        Me.txtEndin.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(230, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "모델"
        '
        'txtStepin
        '
        Me.txtStepin.BackColor = System.Drawing.SystemColors.Info
        Me.txtStepin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStepin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStepin.ForeColor = System.Drawing.Color.Gray
        Me.txtStepin.Location = New System.Drawing.Point(642, 44)
        Me.txtStepin.Name = "txtStepin"
        Me.txtStepin.Size = New System.Drawing.Size(150, 15)
        Me.txtStepin.TabIndex = 40
        '
        'btnS1
        '
        Me.btnS1.FlatAppearance.BorderSize = 0
        Me.btnS1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnS1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnS1.Image = CType(resources.GetObject("btnS1.Image"), System.Drawing.Image)
        Me.btnS1.Location = New System.Drawing.Point(364, 5)
        Me.btnS1.Name = "btnS1"
        Me.btnS1.Size = New System.Drawing.Size(27, 23)
        Me.btnS1.TabIndex = 28
        Me.btnS1.UseVisualStyleBackColor = True
        '
        'txtGroupin
        '
        Me.txtGroupin.BackColor = System.Drawing.SystemColors.Info
        Me.txtGroupin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGroupin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtGroupin.ForeColor = System.Drawing.Color.Gray
        Me.txtGroupin.Location = New System.Drawing.Point(263, 47)
        Me.txtGroupin.Name = "txtGroupin"
        Me.txtGroupin.Size = New System.Drawing.Size(95, 15)
        Me.txtGroupin.TabIndex = 41
        '
        'txtModel
        '
        Me.txtModel.BackColor = System.Drawing.Color.White
        Me.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModel.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtModel.Location = New System.Drawing.Point(265, 7)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(93, 22)
        Me.txtModel.TabIndex = 18
        '
        'txtStartin
        '
        Me.txtStartin.BackColor = System.Drawing.Color.Gainsboro
        Me.txtStartin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStartin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStartin.ForeColor = System.Drawing.Color.Gray
        Me.txtStartin.Location = New System.Drawing.Point(90, 79)
        Me.txtStartin.Name = "txtStartin"
        Me.txtStartin.Size = New System.Drawing.Size(193, 15)
        Me.txtStartin.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(606, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "검증 그룹"
        '
        'txtModelin
        '
        Me.txtModelin.BackColor = System.Drawing.SystemColors.Info
        Me.txtModelin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtModelin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtModelin.ForeColor = System.Drawing.Color.Gray
        Me.txtModelin.Location = New System.Drawing.Point(443, 46)
        Me.txtModelin.Name = "txtModelin"
        Me.txtModelin.Size = New System.Drawing.Size(130, 15)
        Me.txtModelin.TabIndex = 43
        '
        'cbCompany
        '
        Me.cbCompany.BackColor = System.Drawing.Color.White
        Me.cbCompany.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbCompany.FormattingEnabled = True
        Me.cbCompany.Location = New System.Drawing.Point(666, 7)
        Me.cbCompany.Name = "cbCompany"
        Me.cbCompany.Size = New System.Drawing.Size(93, 21)
        Me.cbCompany.TabIndex = 29
        '
        'txtProin
        '
        Me.txtProin.BackColor = System.Drawing.SystemColors.Info
        Me.txtProin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtProin.ForeColor = System.Drawing.Color.Gray
        Me.txtProin.Location = New System.Drawing.Point(72, 47)
        Me.txtProin.Name = "txtProin"
        Me.txtProin.Size = New System.Drawing.Size(130, 15)
        Me.txtProin.TabIndex = 44
        '
        'btnS2
        '
        Me.btnS2.FlatAppearance.BorderSize = 0
        Me.btnS2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnS2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnS2.Image = CType(resources.GetObject("btnS2.Image"), System.Drawing.Image)
        Me.btnS2.Location = New System.Drawing.Point(172, 5)
        Me.btnS2.Name = "btnS2"
        Me.btnS2.Size = New System.Drawing.Size(27, 23)
        Me.btnS2.TabIndex = 27
        Me.btnS2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Start Date : "
        '
        'txtPro
        '
        Me.txtPro.BackColor = System.Drawing.Color.White
        Me.txtPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPro.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtPro.Location = New System.Drawing.Point(73, 7)
        Me.txtPro.Name = "txtPro"
        Me.txtPro.Size = New System.Drawing.Size(93, 22)
        Me.txtPro.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.Location = New System.Drawing.Point(295, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "End date : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(13, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "프로젝트"
        '
        'btnS3
        '
        Me.btnS3.FlatAppearance.BorderSize = 0
        Me.btnS3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnS3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnS3.Image = CType(resources.GetObject("btnS3.Image"), System.Drawing.Image)
        Me.btnS3.Location = New System.Drawing.Point(546, 6)
        Me.btnS3.Name = "btnS3"
        Me.btnS3.Size = New System.Drawing.Size(27, 23)
        Me.btnS3.TabIndex = 25
        Me.btnS3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.Location = New System.Drawing.Point(596, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Step : "
        '
        'btnS4
        '
        Me.btnS4.FlatAppearance.BorderSize = 0
        Me.btnS4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnS4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnS4.Image = CType(resources.GetObject("btnS4.Image"), System.Drawing.Image)
        Me.btnS4.Location = New System.Drawing.Point(765, 5)
        Me.btnS4.Name = "btnS4"
        Me.btnS4.Size = New System.Drawing.Size(27, 23)
        Me.btnS4.TabIndex = 26
        Me.btnS4.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.Location = New System.Drawing.Point(386, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Model : "
        '
        'txtStep
        '
        Me.txtStep.BackColor = System.Drawing.Color.White
        Me.txtStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStep.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStep.Location = New System.Drawing.Point(447, 7)
        Me.txtStep.Name = "txtStep"
        Me.txtStep.Size = New System.Drawing.Size(93, 22)
        Me.txtStep.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(208, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Group : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Project : "
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Gray
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(16, 101)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(95, 24)
        Me.Button4.TabIndex = 42
        Me.Button4.Text = "    모델 추가"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(654, 131)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(196, 443)
        Me.DataGridView1.TabIndex = 44
        '
        'Add_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.add_main_panel)
        Me.Name = "Add_Control"
        Me.Size = New System.Drawing.Size(872, 593)
        Me.add_main_panel.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_addrow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Slide_panel.ResumeLayout(False)
        Me.Slide_panel.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents add_main_panel As Windows.Forms.Panel
    Friend WithEvents Slide_panel As Windows.Forms.Panel
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents txtEndin As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtStepin As Windows.Forms.TextBox
    Friend WithEvents btnS1 As Windows.Forms.Button
    Friend WithEvents txtGroupin As Windows.Forms.TextBox
    Friend WithEvents txtModel As Windows.Forms.TextBox
    Friend WithEvents txtStartin As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents txtModelin As Windows.Forms.TextBox
    Friend WithEvents cbCompany As Windows.Forms.ComboBox
    Friend WithEvents txtProin As Windows.Forms.TextBox
    Friend WithEvents btnS2 As Windows.Forms.Button
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents txtPro As Windows.Forms.TextBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents btnS3 As Windows.Forms.Button
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents btnS4 As Windows.Forms.Button
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents txtStep As Windows.Forms.TextBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Button4 As Windows.Forms.Button
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button7 As Windows.Forms.Button
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents txtseq As Windows.Forms.TextBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents btn_addrow As Windows.Forms.PictureBox
    Friend WithEvents TreeListView1 As WinControls.ListView.TreeListView
    Friend WithEvents btn_member As Windows.Forms.Button
    Friend WithEvents DataGridView2 As Windows.Forms.DataGridView
    Friend WithEvents btn_save As Windows.Forms.Button
End Class
