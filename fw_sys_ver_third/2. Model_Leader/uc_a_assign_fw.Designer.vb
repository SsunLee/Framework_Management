<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_a_assign_fw
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_a_assign_fw))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Setting_pnael = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tggl_Prechk = New JCS.ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToggleSwitch1 = New JCS.ToggleSwitch()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLow = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMiddle = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtHigh = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TreeListView1 = New WinControls.ListView.TreeListView()
        Me.ContainerColumnHeader1 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader2 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader4 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader3 = New WinControls.ListView.ContainerColumnHeader()
        Me.TreeListView2 = New WinControls.ListView.TreeListView()
        Me.ContainerColumnHeader5 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader7 = New WinControls.ListView.ContainerColumnHeader()
        Me.ContainerColumnHeader8 = New WinControls.ListView.ContainerColumnHeader()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnSetting = New System.Windows.Forms.PictureBox()
        Me.la_NowSteps = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_upload = New System.Windows.Forms.Button()
        Me.btn_Expand = New System.Windows.Forms.Button()
        Me.TreeListView3 = New WinControls.ListView.TreeListView()
        Me.la_member = New System.Windows.Forms.Label()
        Me.btnList_excel = New System.Windows.Forms.Button()
        Me.btnAvg_excel = New System.Windows.Forms.Button()
        Me.treeView_m = New System.Windows.Forms.TreeView()
        Me.txtCmt = New System.Windows.Forms.TextBox()
        Me.Setting_pnael.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Setting_pnael
        '
        Me.Setting_pnael.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Setting_pnael.Controls.Add(Me.Label18)
        Me.Setting_pnael.Controls.Add(Me.tggl_Prechk)
        Me.Setting_pnael.Controls.Add(Me.Label4)
        Me.Setting_pnael.Controls.Add(Me.ToggleSwitch1)
        Me.Setting_pnael.Controls.Add(Me.Label1)
        Me.Setting_pnael.Controls.Add(Me.txtLow)
        Me.Setting_pnael.Controls.Add(Me.Label16)
        Me.Setting_pnael.Controls.Add(Me.txtMiddle)
        Me.Setting_pnael.Controls.Add(Me.Label17)
        Me.Setting_pnael.Controls.Add(Me.txtHigh)
        Me.Setting_pnael.Location = New System.Drawing.Point(754, 12)
        Me.Setting_pnael.Name = "Setting_pnael"
        Me.Setting_pnael.Size = New System.Drawing.Size(218, 123)
        Me.Setting_pnael.TabIndex = 75
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label18.Location = New System.Drawing.Point(22, 99)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(140, 13)
        Me.Label18.TabIndex = 66
        Me.Label18.Text = "이전 차수 데이터 가져오기"
        '
        'tggl_Prechk
        '
        Me.tggl_Prechk.Location = New System.Drawing.Point(163, 96)
        Me.tggl_Prechk.Name = "tggl_Prechk"
        Me.tggl_Prechk.OffFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.tggl_Prechk.OnFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.tggl_Prechk.Size = New System.Drawing.Size(50, 19)
        Me.tggl_Prechk.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone
        Me.tggl_Prechk.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "상세역량 항상띄우기"
        '
        'ToggleSwitch1
        '
        Me.ToggleSwitch1.Location = New System.Drawing.Point(163, 71)
        Me.ToggleSwitch1.Name = "ToggleSwitch1"
        Me.ToggleSwitch1.OffFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleSwitch1.OnFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleSwitch1.Size = New System.Drawing.Size(50, 19)
        Me.ToggleSwitch1.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone
        Me.ToggleSwitch1.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "상 : "
        '
        'txtLow
        '
        Me.txtLow.BackColor = System.Drawing.Color.White
        Me.txtLow.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLow.Location = New System.Drawing.Point(54, 42)
        Me.txtLow.Name = "txtLow"
        Me.txtLow.Size = New System.Drawing.Size(100, 14)
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
        Me.txtMiddle.Size = New System.Drawing.Size(100, 14)
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
        Me.txtHigh.Size = New System.Drawing.Size(100, 14)
        Me.txtHigh.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "투입 현황"
        '
        'TreeListView1
        '
        Me.TreeListView1.AllowDefaultDragDrop = True
        Me.TreeListView1.AllowDrop = True
        Me.TreeListView1.BorderStyle = WinControls.ListView.Enums.BorderStyleType.FixedSingle
        Me.TreeListView1.CheckBoxSelection = System.Windows.Forms.ItemActivation.OneClick
        Me.TreeListView1.Columns.AddRange(New WinControls.ListView.ContainerColumnHeader() {Me.ContainerColumnHeader1, Me.ContainerColumnHeader2, Me.ContainerColumnHeader4, Me.ContainerColumnHeader3})
        Me.TreeListView1.DefaultImageIndex = 1
        Me.TreeListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TreeListView1.FullRowSelect = False
        Me.TreeListView1.HoverSelection = True
        Me.TreeListView1.Location = New System.Drawing.Point(23, 54)
        Me.TreeListView1.Name = "TreeListView1"
        Me.TreeListView1.Size = New System.Drawing.Size(494, 234)
        Me.TreeListView1.TabIndex = 72
        '
        'ContainerColumnHeader1
        '
        Me.ContainerColumnHeader1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ContainerColumnHeader1.Text = "TC Info"
        Me.ContainerColumnHeader1.Width = 204
        '
        'ContainerColumnHeader2
        '
        Me.ContainerColumnHeader2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ContainerColumnHeader2.Text = "Tester"
        Me.ContainerColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ContainerColumnHeader2.Width = 71
        '
        'ContainerColumnHeader4
        '
        Me.ContainerColumnHeader4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ContainerColumnHeader4.Text = "역량"
        Me.ContainerColumnHeader4.Width = 45
        '
        'ContainerColumnHeader3
        '
        Me.ContainerColumnHeader3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ContainerColumnHeader3.Text = "비고"
        Me.ContainerColumnHeader3.Width = 116
        '
        'TreeListView2
        '
        Me.TreeListView2.AllowDefaultDragDrop = True
        Me.TreeListView2.AllowDrop = True
        Me.TreeListView2.BorderStyle = WinControls.ListView.Enums.BorderStyleType.FixedSingle
        Me.TreeListView2.CheckBoxSelection = System.Windows.Forms.ItemActivation.OneClick
        Me.TreeListView2.Columns.AddRange(New WinControls.ListView.ContainerColumnHeader() {Me.ContainerColumnHeader5, Me.ContainerColumnHeader7, Me.ContainerColumnHeader8})
        Me.TreeListView2.DefaultImageIndex = 1
        Me.TreeListView2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TreeListView2.FullRowSelect = False
        Me.TreeListView2.HoverSelection = True
        Me.TreeListView2.Location = New System.Drawing.Point(534, 55)
        Me.TreeListView2.Name = "TreeListView2"
        Me.TreeListView2.Size = New System.Drawing.Size(448, 234)
        Me.TreeListView2.TabIndex = 73
        '
        'ContainerColumnHeader5
        '
        Me.ContainerColumnHeader5.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ContainerColumnHeader5.Text = "TC Info"
        Me.ContainerColumnHeader5.Width = 197
        '
        'ContainerColumnHeader7
        '
        Me.ContainerColumnHeader7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ContainerColumnHeader7.Text = "역량"
        Me.ContainerColumnHeader7.Width = 44
        '
        'ContainerColumnHeader8
        '
        Me.ContainerColumnHeader8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ContainerColumnHeader8.Text = "비고"
        Me.ContainerColumnHeader8.Width = 62
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label19.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(531, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(87, 15)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "투입 역량 평균"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(930, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 74
        Me.PictureBox2.TabStop = False
        '
        'btnSetting
        '
        Me.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSetting.Image = CType(resources.GetObject("btnSetting.Image"), System.Drawing.Image)
        Me.btnSetting.Location = New System.Drawing.Point(961, 3)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(21, 19)
        Me.btnSetting.TabIndex = 76
        Me.btnSetting.TabStop = False
        '
        'la_NowSteps
        '
        Me.la_NowSteps.AutoSize = True
        Me.la_NowSteps.Font = New System.Drawing.Font("맑은 고딕", 8.25!)
        Me.la_NowSteps.ForeColor = System.Drawing.Color.Gray
        Me.la_NowSteps.Location = New System.Drawing.Point(25, 30)
        Me.la_NowSteps.Name = "la_NowSteps"
        Me.la_NowSteps.Size = New System.Drawing.Size(0, 13)
        Me.la_NowSteps.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 321)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "검증 F/W 할당"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.Location = New System.Drawing.Point(23, 347)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(495, 272)
        Me.DataGridView1.TabIndex = 51
        '
        'btn_upload
        '
        Me.btn_upload.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_upload.FlatAppearance.BorderSize = 0
        Me.btn_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_upload.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_upload.ForeColor = System.Drawing.Color.Gray
        Me.btn_upload.Image = CType(resources.GetObject("btn_upload.Image"), System.Drawing.Image)
        Me.btn_upload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_upload.Location = New System.Drawing.Point(630, 317)
        Me.btn_upload.Name = "btn_upload"
        Me.btn_upload.Size = New System.Drawing.Size(25, 24)
        Me.btn_upload.TabIndex = 616
        Me.btn_upload.UseVisualStyleBackColor = True
        '
        'btn_Expand
        '
        Me.btn_Expand.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_Expand.FlatAppearance.BorderSize = 0
        Me.btn_Expand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Expand.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Expand.ForeColor = System.Drawing.Color.Gray
        Me.btn_Expand.Image = CType(resources.GetObject("btn_Expand.Image"), System.Drawing.Image)
        Me.btn_Expand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Expand.Location = New System.Drawing.Point(112, 318)
        Me.btn_Expand.Name = "btn_Expand"
        Me.btn_Expand.Size = New System.Drawing.Size(25, 24)
        Me.btn_Expand.TabIndex = 616
        Me.btn_Expand.UseVisualStyleBackColor = True
        '
        'TreeListView3
        '
        Me.TreeListView3.AllowDefaultDragDrop = True
        Me.TreeListView3.AllowDrop = True
        Me.TreeListView3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TreeListView3.Location = New System.Drawing.Point(737, 346)
        Me.TreeListView3.Name = "TreeListView3"
        Me.TreeListView3.Size = New System.Drawing.Size(246, 272)
        Me.TreeListView3.TabIndex = 80
        '
        'la_member
        '
        Me.la_member.AutoSize = True
        Me.la_member.BackColor = System.Drawing.Color.Transparent
        Me.la_member.Cursor = System.Windows.Forms.Cursors.Hand
        Me.la_member.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.la_member.ForeColor = System.Drawing.Color.Black
        Me.la_member.Location = New System.Drawing.Point(537, 322)
        Me.la_member.Name = "la_member"
        Me.la_member.Size = New System.Drawing.Size(87, 15)
        Me.la_member.TabIndex = 79
        Me.la_member.Text = "검증 투입 인원"
        '
        'btnList_excel
        '
        Me.btnList_excel.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnList_excel.FlatAppearance.BorderSize = 0
        Me.btnList_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnList_excel.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnList_excel.ForeColor = System.Drawing.Color.Gray
        Me.btnList_excel.Image = CType(resources.GetObject("btnList_excel.Image"), System.Drawing.Image)
        Me.btnList_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnList_excel.Location = New System.Drawing.Point(97, 24)
        Me.btnList_excel.Name = "btnList_excel"
        Me.btnList_excel.Size = New System.Drawing.Size(25, 24)
        Me.btnList_excel.TabIndex = 616
        Me.btnList_excel.UseVisualStyleBackColor = True
        '
        'btnAvg_excel
        '
        Me.btnAvg_excel.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnAvg_excel.FlatAppearance.BorderSize = 0
        Me.btnAvg_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAvg_excel.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAvg_excel.ForeColor = System.Drawing.Color.Gray
        Me.btnAvg_excel.Image = CType(resources.GetObject("btnAvg_excel.Image"), System.Drawing.Image)
        Me.btnAvg_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvg_excel.Location = New System.Drawing.Point(624, 25)
        Me.btnAvg_excel.Name = "btnAvg_excel"
        Me.btnAvg_excel.Size = New System.Drawing.Size(25, 24)
        Me.btnAvg_excel.TabIndex = 616
        Me.btnAvg_excel.UseVisualStyleBackColor = True
        '
        'treeView_m
        '
        Me.treeView_m.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.treeView_m.Location = New System.Drawing.Point(536, 346)
        Me.treeView_m.Name = "treeView_m"
        Me.treeView_m.Size = New System.Drawing.Size(195, 271)
        Me.treeView_m.TabIndex = 617
        '
        'txtCmt
        '
        Me.txtCmt.BackColor = System.Drawing.SystemColors.Info
        Me.txtCmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCmt.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtCmt.Location = New System.Drawing.Point(23, 621)
        Me.txtCmt.Multiline = True
        Me.txtCmt.Name = "txtCmt"
        Me.txtCmt.Size = New System.Drawing.Size(960, 33)
        Me.txtCmt.TabIndex = 618
        '
        'uc_a_assign_fw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtCmt)
        Me.Controls.Add(Me.treeView_m)
        Me.Controls.Add(Me.btn_upload)
        Me.Controls.Add(Me.btn_Expand)
        Me.Controls.Add(Me.TreeListView3)
        Me.Controls.Add(Me.btnAvg_excel)
        Me.Controls.Add(Me.btnList_excel)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.la_member)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Setting_pnael)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TreeListView1)
        Me.Controls.Add(Me.TreeListView2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.la_NowSteps)
        Me.Name = "uc_a_assign_fw"
        Me.Size = New System.Drawing.Size(1007, 682)
        Me.Setting_pnael.ResumeLayout(False)
        Me.Setting_pnael.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSetting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Setting_pnael As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents tggl_Prechk As JCS.ToggleSwitch
    Friend WithEvents Label4 As Label
    Friend WithEvents ToggleSwitch1 As JCS.ToggleSwitch
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLow As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMiddle As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtHigh As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TreeListView1 As WinControls.ListView.TreeListView
    Friend WithEvents ContainerColumnHeader1 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader2 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader4 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader3 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents TreeListView2 As WinControls.ListView.TreeListView
    Friend WithEvents ContainerColumnHeader5 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader7 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents ContainerColumnHeader8 As WinControls.ListView.ContainerColumnHeader
    Friend WithEvents Label19 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnSetting As PictureBox
    Friend WithEvents la_NowSteps As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_upload As Button
    Friend WithEvents btn_Expand As Button
    Friend WithEvents TreeListView3 As WinControls.ListView.TreeListView
    Friend WithEvents la_member As Label
    Friend WithEvents btnList_excel As Button
    Friend WithEvents btnAvg_excel As Button
    Friend WithEvents treeView_m As TreeView
    Friend WithEvents txtCmt As TextBox
End Class
