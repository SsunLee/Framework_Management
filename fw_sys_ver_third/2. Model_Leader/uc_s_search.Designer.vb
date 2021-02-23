<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class uc_s_search
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_s_search))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Setting_pnael = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLow = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMiddle = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtHigh = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtTester = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPro = New System.Windows.Forms.ComboBox()
        Me.cbGrp = New System.Windows.Forms.ComboBox()
        Me.cbMod = New System.Windows.Forms.ComboBox()
        Me.cbStep = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_DB = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnMDSave = New System.Windows.Forms.Button()
        Me.btnMD = New System.Windows.Forms.Button()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.rd_level_Tct = New MetroFramework.Controls.MetroRadioButton()
        Me.rd_level_cate = New MetroFramework.Controls.MetroRadioButton()
        Me.rd_level_all = New MetroFramework.Controls.MetroRadioButton()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.cbFilter = New System.Windows.Forms.ComboBox()
        Me.rdoTCt = New MetroFramework.Controls.MetroRadioButton()
        Me.rdoCate = New MetroFramework.Controls.MetroRadioButton()
        Me.rdo_all = New MetroFramework.Controls.MetroRadioButton()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.ToggleSwitch1 = New JCS.ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.date_End = New System.Windows.Forms.DateTimePicker()
        Me.date_start = New System.Windows.Forms.DateTimePicker()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.PictureBox()
        Me.Setting_pnael.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.btnRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(804, 26)
        Me.Panel1.TabIndex = 0
        '
        'Setting_pnael
        '
        Me.Setting_pnael.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Setting_pnael.Controls.Add(Me.Label6)
        Me.Setting_pnael.Controls.Add(Me.txtLow)
        Me.Setting_pnael.Controls.Add(Me.Label16)
        Me.Setting_pnael.Controls.Add(Me.txtMiddle)
        Me.Setting_pnael.Controls.Add(Me.Label17)
        Me.Setting_pnael.Controls.Add(Me.txtHigh)
        Me.Setting_pnael.Location = New System.Drawing.Point(50, 3)
        Me.Setting_pnael.Name = "Setting_pnael"
        Me.Setting_pnael.Size = New System.Drawing.Size(189, 73)
        Me.Setting_pnael.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "상 : "
        '
        'txtLow
        '
        Me.txtLow.BackColor = System.Drawing.Color.White
        Me.txtLow.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLow.Location = New System.Drawing.Point(54, 42)
        Me.txtLow.Name = "txtLow"
        Me.txtLow.Size = New System.Drawing.Size(100, 16)
        Me.txtLow.TabIndex = 43
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(28, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "중 : "
        '
        'txtMiddle
        '
        Me.txtMiddle.BackColor = System.Drawing.Color.White
        Me.txtMiddle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMiddle.Location = New System.Drawing.Point(54, 24)
        Me.txtMiddle.Name = "txtMiddle"
        Me.txtMiddle.Size = New System.Drawing.Size(100, 16)
        Me.txtMiddle.TabIndex = 43
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 13)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "하 : "
        '
        'txtHigh
        '
        Me.txtHigh.BackColor = System.Drawing.Color.White
        Me.txtHigh.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHigh.Location = New System.Drawing.Point(54, 5)
        Me.txtHigh.Name = "txtHigh"
        Me.txtHigh.Size = New System.Drawing.Size(100, 16)
        Me.txtHigh.TabIndex = 43
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(23, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox3.TabIndex = 66
        Me.PictureBox3.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 610)
        Me.Panel2.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.txtTester)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Location = New System.Drawing.Point(23, 83)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(756, 30)
        Me.Panel7.TabIndex = 7
        '
        'txtTester
        '
        Me.txtTester.BackColor = System.Drawing.SystemColors.Info
        Me.txtTester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTester.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtTester.Location = New System.Drawing.Point(150, 3)
        Me.txtTester.Name = "txtTester"
        Me.txtTester.Size = New System.Drawing.Size(233, 22)
        Me.txtTester.TabIndex = 8
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(144, 28)
        Me.Panel8.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(41, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 15)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "이름조회"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.cbPro)
        Me.Panel3.Controls.Add(Me.btnRefresh)
        Me.Panel3.Controls.Add(Me.cbGrp)
        Me.Panel3.Controls.Add(Me.cbMod)
        Me.Panel3.Controls.Add(Me.cbStep)
        Me.Panel3.Location = New System.Drawing.Point(23, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(756, 28)
        Me.Panel3.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(144, 26)
        Me.Panel4.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(41, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "조회조건"
        '
        'cbPro
        '
        Me.cbPro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPro.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbPro.FormattingEnabled = True
        Me.cbPro.Location = New System.Drawing.Point(150, 3)
        Me.cbPro.Name = "cbPro"
        Me.cbPro.Size = New System.Drawing.Size(147, 21)
        Me.cbPro.TabIndex = 4
        '
        'cbGrp
        '
        Me.cbGrp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbGrp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbGrp.FormattingEnabled = True
        Me.cbGrp.Location = New System.Drawing.Point(303, 3)
        Me.cbGrp.Name = "cbGrp"
        Me.cbGrp.Size = New System.Drawing.Size(80, 21)
        Me.cbGrp.TabIndex = 4
        '
        'cbMod
        '
        Me.cbMod.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbMod.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbMod.FormattingEnabled = True
        Me.cbMod.Location = New System.Drawing.Point(389, 3)
        Me.cbMod.Name = "cbMod"
        Me.cbMod.Size = New System.Drawing.Size(160, 21)
        Me.cbMod.TabIndex = 4
        '
        'cbStep
        '
        Me.cbStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbStep.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbStep.FormattingEnabled = True
        Me.cbStep.Location = New System.Drawing.Point(555, 3)
        Me.cbStep.Name = "cbStep"
        Me.cbStep.Size = New System.Drawing.Size(98, 21)
        Me.cbStep.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(794, 353)
        Me.DataGridView1.TabIndex = 5
        '
        'btn_DB
        '
        Me.btn_DB.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_DB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DB.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_DB.Image = CType(resources.GetObject("btn_DB.Image"), System.Drawing.Image)
        Me.btn_DB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_DB.Location = New System.Drawing.Point(708, 218)
        Me.btn_DB.Name = "btn_DB"
        Me.btn_DB.Size = New System.Drawing.Size(71, 26)
        Me.btn_DB.TabIndex = 3
        Me.btn_DB.Text = "    Search"
        Me.btn_DB.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DataGridView1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(794, 353)
        Me.Panel5.TabIndex = 8
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Setting_pnael)
        Me.Panel6.Controls.Add(Me.btnMDSave)
        Me.Panel6.Controls.Add(Me.PictureBox3)
        Me.Panel6.Controls.Add(Me.btnMD)
        Me.Panel6.Controls.Add(Me.Panel3)
        Me.Panel6.Controls.Add(Me.Panel15)
        Me.Panel6.Controls.Add(Me.Panel13)
        Me.Panel6.Controls.Add(Me.btn_DB)
        Me.Panel6.Controls.Add(Me.Panel11)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(794, 257)
        Me.Panel6.TabIndex = 9
        '
        'btnMDSave
        '
        Me.btnMDSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnMDSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMDSave.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnMDSave.Image = CType(resources.GetObject("btnMDSave.Image"), System.Drawing.Image)
        Me.btnMDSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMDSave.Location = New System.Drawing.Point(119, 218)
        Me.btnMDSave.Name = "btnMDSave"
        Me.btnMDSave.Size = New System.Drawing.Size(71, 23)
        Me.btnMDSave.TabIndex = 8
        Me.btnMDSave.Text = "   Upload"
        Me.btnMDSave.UseVisualStyleBackColor = True
        '
        'btnMD
        '
        Me.btnMD.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnMD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMD.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnMD.Image = CType(resources.GetObject("btnMD.Image"), System.Drawing.Image)
        Me.btnMD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMD.Location = New System.Drawing.Point(28, 218)
        Me.btnMD.Name = "btnMD"
        Me.btnMD.Size = New System.Drawing.Size(85, 23)
        Me.btnMD.TabIndex = 8
        Me.btnMD.Text = "     MD 작성하기"
        Me.btnMD.UseVisualStyleBackColor = True
        '
        'Panel15
        '
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.rd_level_Tct)
        Me.Panel15.Controls.Add(Me.rd_level_cate)
        Me.Panel15.Controls.Add(Me.rd_level_all)
        Me.Panel15.Controls.Add(Me.Panel16)
        Me.Panel15.Location = New System.Drawing.Point(23, 140)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(756, 30)
        Me.Panel15.TabIndex = 7
        '
        'rd_level_Tct
        '
        Me.rd_level_Tct.AutoSize = True
        Me.rd_level_Tct.Location = New System.Drawing.Point(312, 6)
        Me.rd_level_Tct.Name = "rd_level_Tct"
        Me.rd_level_Tct.Size = New System.Drawing.Size(60, 15)
        Me.rd_level_Tct.TabIndex = 8
        Me.rd_level_Tct.TabStop = True
        Me.rd_level_Tct.Text = "TCtype"
        Me.rd_level_Tct.UseVisualStyleBackColor = True
        '
        'rd_level_cate
        '
        Me.rd_level_cate.AutoSize = True
        Me.rd_level_cate.Location = New System.Drawing.Point(225, 6)
        Me.rd_level_cate.Name = "rd_level_cate"
        Me.rd_level_cate.Size = New System.Drawing.Size(71, 15)
        Me.rd_level_cate.TabIndex = 8
        Me.rd_level_cate.TabStop = True
        Me.rd_level_cate.Text = "Category"
        Me.rd_level_cate.UseVisualStyleBackColor = True
        '
        'rd_level_all
        '
        Me.rd_level_all.AutoSize = True
        Me.rd_level_all.Location = New System.Drawing.Point(159, 6)
        Me.rd_level_all.Name = "rd_level_all"
        Me.rd_level_all.Size = New System.Drawing.Size(47, 15)
        Me.rd_level_all.TabIndex = 8
        Me.rd_level_all.TabStop = True
        Me.rd_level_all.Text = "전체"
        Me.rd_level_all.UseVisualStyleBackColor = True
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel16.Controls.Add(Me.Label5)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(144, 28)
        Me.Panel16.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(41, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "역량조회"
        '
        'Panel13
        '
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.cbFilter)
        Me.Panel13.Controls.Add(Me.rdoTCt)
        Me.Panel13.Controls.Add(Me.rdoCate)
        Me.Panel13.Controls.Add(Me.rdo_all)
        Me.Panel13.Controls.Add(Me.Panel14)
        Me.Panel13.Location = New System.Drawing.Point(23, 112)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(756, 30)
        Me.Panel13.TabIndex = 7
        '
        'cbFilter
        '
        Me.cbFilter.FormattingEnabled = True
        Me.cbFilter.Location = New System.Drawing.Point(392, 2)
        Me.cbFilter.Name = "cbFilter"
        Me.cbFilter.Size = New System.Drawing.Size(121, 23)
        Me.cbFilter.TabIndex = 9
        '
        'rdoTCt
        '
        Me.rdoTCt.AutoSize = True
        Me.rdoTCt.Location = New System.Drawing.Point(312, 6)
        Me.rdoTCt.Name = "rdoTCt"
        Me.rdoTCt.Size = New System.Drawing.Size(60, 15)
        Me.rdoTCt.TabIndex = 8
        Me.rdoTCt.TabStop = True
        Me.rdoTCt.Text = "TCtype"
        Me.rdoTCt.UseVisualStyleBackColor = True
        '
        'rdoCate
        '
        Me.rdoCate.AutoSize = True
        Me.rdoCate.Location = New System.Drawing.Point(225, 6)
        Me.rdoCate.Name = "rdoCate"
        Me.rdoCate.Size = New System.Drawing.Size(71, 15)
        Me.rdoCate.TabIndex = 8
        Me.rdoCate.TabStop = True
        Me.rdoCate.Text = "Category"
        Me.rdoCate.UseVisualStyleBackColor = True
        '
        'rdo_all
        '
        Me.rdo_all.AutoSize = True
        Me.rdo_all.Location = New System.Drawing.Point(159, 6)
        Me.rdo_all.Name = "rdo_all"
        Me.rdo_all.Size = New System.Drawing.Size(47, 15)
        Me.rdo_all.TabIndex = 8
        Me.rdo_all.TabStop = True
        Me.rdo_all.Text = "전체"
        Me.rdo_all.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel14.Controls.Add(Me.Label7)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(144, 28)
        Me.Panel14.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(41, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "필터하기"
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.ToggleSwitch1)
        Me.Panel11.Controls.Add(Me.Label4)
        Me.Panel11.Controls.Add(Me.Label3)
        Me.Panel11.Controls.Add(Me.date_End)
        Me.Panel11.Controls.Add(Me.date_start)
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Location = New System.Drawing.Point(23, 55)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(756, 30)
        Me.Panel11.TabIndex = 7
        '
        'ToggleSwitch1
        '
        Me.ToggleSwitch1.Location = New System.Drawing.Point(150, 5)
        Me.ToggleSwitch1.Name = "ToggleSwitch1"
        Me.ToggleSwitch1.OffFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleSwitch1.OnFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleSwitch1.Size = New System.Drawing.Size(50, 19)
        Me.ToggleSwitch1.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone
        Me.ToggleSwitch1.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(594, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "까지"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(389, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "에서"
        '
        'date_End
        '
        Me.date_End.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.date_End.Location = New System.Drawing.Point(424, 3)
        Me.date_End.Name = "date_End"
        Me.date_End.Size = New System.Drawing.Size(164, 22)
        Me.date_End.TabIndex = 9
        '
        'date_start
        '
        Me.date_start.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.date_start.Location = New System.Drawing.Point(209, 3)
        Me.date_start.Name = "date_start"
        Me.date_start.Size = New System.Drawing.Size(174, 22)
        Me.date_start.TabIndex = 9
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel12.Controls.Add(Me.Label1)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(144, 28)
        Me.Panel12.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(41, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "조회기간"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Controls.Add(Me.Panel6)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(10, 26)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(794, 610)
        Me.Panel9.TabIndex = 10
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel5)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 257)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(794, 353)
        Me.Panel10.TabIndex = 10
        '
        'btnRefresh
        '
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(659, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(21, 19)
        Me.btnRefresh.TabIndex = 66
        Me.btnRefresh.TabStop = False
        '
        'Search_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Search_Control"
        Me.Size = New System.Drawing.Size(804, 636)
        Me.Setting_pnael.ResumeLayout(False)
        Me.Setting_pnael.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.btnRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents cbMod As Windows.Forms.ComboBox
    Friend WithEvents cbStep As Windows.Forms.ComboBox
    Friend WithEvents cbGrp As Windows.Forms.ComboBox
    Friend WithEvents cbPro As Windows.Forms.ComboBox
    Friend WithEvents btn_DB As Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents Panel7 As Windows.Forms.Panel
    Friend WithEvents Panel8 As Windows.Forms.Panel
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents txtTester As Windows.Forms.TextBox
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents Panel6 As Windows.Forms.Panel
    Friend WithEvents Panel9 As Windows.Forms.Panel
    Friend WithEvents Panel10 As Windows.Forms.Panel
    Friend WithEvents btnMD As Windows.Forms.Button
    Friend WithEvents btnMDSave As Windows.Forms.Button
    Friend WithEvents Panel11 As Windows.Forms.Panel
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents date_End As Windows.Forms.DateTimePicker
    Friend WithEvents date_start As Windows.Forms.DateTimePicker
    Friend WithEvents Panel12 As Windows.Forms.Panel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ToggleSwitch1 As JCS.ToggleSwitch
    Friend WithEvents Panel13 As Windows.Forms.Panel
    Friend WithEvents rdoTCt As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rdoCate As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rdo_all As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents Panel14 As Windows.Forms.Panel
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents cbFilter As Windows.Forms.ComboBox
    Friend WithEvents Setting_pnael As Windows.Forms.Panel
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txtLow As Windows.Forms.TextBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents txtMiddle As Windows.Forms.TextBox
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents txtHigh As Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As Windows.Forms.PictureBox
    Friend WithEvents Panel15 As Windows.Forms.Panel
    Friend WithEvents rd_level_Tct As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rd_level_cate As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rd_level_all As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents Panel16 As Windows.Forms.Panel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents btnRefresh As Windows.Forms.PictureBox
End Class
