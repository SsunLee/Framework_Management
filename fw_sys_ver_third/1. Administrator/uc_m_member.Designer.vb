<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class uc_m_member
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_m_member))
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.trv_Member = New WinControls.ListView.TreeListView()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.btn_Settings = New System.Windows.Forms.Button()
        Me.trv_Model = New WinControls.ListView.TreeListView()
        Me.txtCmt = New System.Windows.Forms.TextBox()
        Me.Setting_pnael = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_count = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToggleSwitch1 = New JCS.ToggleSwitch()
        Me.panel_chart = New System.Windows.Forms.Panel()
        Me.cht_non = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cht_func = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cht_rand = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1.SuspendLayout()
        Me.Setting_pnael.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.panel_chart.SuspendLayout()
        CType(Me.cht_non, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cht_func, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cht_rand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(14, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Member List"
        '
        'trv_Member
        '
        Me.trv_Member.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trv_Member.BorderStyle = WinControls.ListView.Enums.BorderStyleType.FixedSingle
        Me.trv_Member.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.trv_Member.Location = New System.Drawing.Point(1256, 70)
        Me.trv_Member.Name = "trv_Member"
        Me.trv_Member.Size = New System.Drawing.Size(15, 585)
        Me.trv_Member.TabIndex = 9
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(45, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(171, 22)
        Me.DateTimePicker1.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_save)
        Me.Panel1.Controls.Add(Me.btn_search)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Panel1.Location = New System.Drawing.Point(17, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1210, 30)
        Me.Panel1.TabIndex = 8
        '
        'btn_save
        '
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_save.FlatAppearance.BorderSize = 0
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_save.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_save.Image = CType(resources.GetObject("btn_save.Image"), System.Drawing.Image)
        Me.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_save.Location = New System.Drawing.Point(509, 4)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(33, 22)
        Me.btn_save.TabIndex = 9
        Me.btn_save.Text = "    Search"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_search
        '
        Me.btn_search.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_search.FlatAppearance.BorderSize = 0
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_search.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_search.Image = CType(resources.GetObject("btn_search.Image"), System.Drawing.Image)
        Me.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_search.Location = New System.Drawing.Point(470, 5)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(33, 22)
        Me.btn_search.TabIndex = 9
        Me.btn_search.Text = "    Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(433, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "까지"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "날짜 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(221, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "에서"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(256, 4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(171, 22)
        Me.DateTimePicker2.TabIndex = 6
        '
        'btn_Settings
        '
        Me.btn_Settings.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_Settings.FlatAppearance.BorderSize = 0
        Me.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Settings.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_Settings.Image = CType(resources.GetObject("btn_Settings.Image"), System.Drawing.Image)
        Me.btn_Settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Settings.Location = New System.Drawing.Point(942, 6)
        Me.btn_Settings.Name = "btn_Settings"
        Me.btn_Settings.Size = New System.Drawing.Size(33, 22)
        Me.btn_Settings.TabIndex = 9
        Me.btn_Settings.Text = "    Search"
        Me.btn_Settings.UseVisualStyleBackColor = True
        '
        'trv_Model
        '
        Me.trv_Model.BorderStyle = WinControls.ListView.Enums.BorderStyleType.FixedSingle
        Me.trv_Model.DefaultImageIndex = -1
        Me.trv_Model.DefaultSelectedImageIndex = -1
        Me.trv_Model.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.trv_Model.IndentSize = 18
        Me.trv_Model.Location = New System.Drawing.Point(17, 70)
        Me.trv_Model.Name = "trv_Model"
        Me.trv_Model.Size = New System.Drawing.Size(287, 545)
        Me.trv_Model.TabIndex = 16
        '
        'txtCmt
        '
        Me.txtCmt.BackColor = System.Drawing.SystemColors.Info
        Me.txtCmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCmt.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtCmt.Location = New System.Drawing.Point(17, 615)
        Me.txtCmt.Multiline = True
        Me.txtCmt.Name = "txtCmt"
        Me.txtCmt.Size = New System.Drawing.Size(1210, 40)
        Me.txtCmt.TabIndex = 17
        '
        'Setting_pnael
        '
        Me.Setting_pnael.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Setting_pnael.Controls.Add(Me.GroupBox2)
        Me.Setting_pnael.Controls.Add(Me.GroupBox1)
        Me.Setting_pnael.Location = New System.Drawing.Point(593, 18)
        Me.Setting_pnael.Name = "Setting_pnael"
        Me.Setting_pnael.Size = New System.Drawing.Size(362, 457)
        Me.Setting_pnael.TabIndex = 76
        '
        'GroupBox2
        '
        Me.GroupBox2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 362)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "역량 관리"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_count)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ToggleSwitch1)
        Me.GroupBox1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 52)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chart"
        '
        'txt_count
        '
        Me.txt_count.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txt_count.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_count.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_count.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txt_count.Location = New System.Drawing.Point(254, 23)
        Me.txt_count.MaxLength = 100
        Me.txt_count.Name = "txt_count"
        Me.txt_count.Size = New System.Drawing.Size(49, 16)
        Me.txt_count.TabIndex = 67
        Me.txt_count.Text = "0"
        Me.txt_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(178, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "차트 표현 수"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "차트정보 띄우기"
        '
        'ToggleSwitch1
        '
        Me.ToggleSwitch1.Location = New System.Drawing.Point(104, 21)
        Me.ToggleSwitch1.Name = "ToggleSwitch1"
        Me.ToggleSwitch1.OffFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleSwitch1.OnFont = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToggleSwitch1.Size = New System.Drawing.Size(50, 19)
        Me.ToggleSwitch1.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone
        Me.ToggleSwitch1.TabIndex = 44
        '
        'panel_chart
        '
        Me.panel_chart.Controls.Add(Me.cht_func)
        Me.panel_chart.Controls.Add(Me.cht_rand)
        Me.panel_chart.Controls.Add(Me.cht_non)
        Me.panel_chart.Location = New System.Drawing.Point(310, 70)
        Me.panel_chart.Name = "panel_chart"
        Me.panel_chart.Size = New System.Drawing.Size(732, 539)
        Me.panel_chart.TabIndex = 77
        '
        'cht_non
        '
        Me.cht_non.BackSecondaryColor = System.Drawing.Color.White
        Me.cht_non.BorderlineColor = System.Drawing.SystemColors.Highlight
        ChartArea3.Name = "ChartArea1"
        Me.cht_non.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.cht_non.Legends.Add(Legend3)
        Me.cht_non.Location = New System.Drawing.Point(22, 183)
        Me.cht_non.Name = "cht_non"
        Me.cht_non.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.cht_non.Series.Add(Series3)
        Me.cht_non.Size = New System.Drawing.Size(674, 143)
        Me.cht_non.TabIndex = 18
        Me.cht_non.Text = "Chart1"
        Title3.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Title3.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title3.ForeColor = System.Drawing.Color.DarkBlue
        Title3.Name = "Title1"
        Title3.Text = "Non-Function) Test Case"
        Me.cht_non.Titles.Add(Title3)
        '
        'cht_func
        '
        Me.cht_func.BorderlineColor = System.Drawing.SystemColors.MenuHighlight
        ChartArea1.Name = "ChartArea1"
        Me.cht_func.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.cht_func.Legends.Add(Legend1)
        Me.cht_func.Location = New System.Drawing.Point(22, 22)
        Me.cht_func.Name = "cht_func"
        Me.cht_func.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.cht_func.Series.Add(Series1)
        Me.cht_func.Size = New System.Drawing.Size(674, 155)
        Me.cht_func.TabIndex = 18
        Me.cht_func.Text = "Chart1"
        Title1.Alignment = System.Drawing.ContentAlignment.TopLeft
        Title1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Title1.ForeColor = System.Drawing.Color.DarkBlue
        Title1.Name = "Title2"
        Title1.Text = "Function) Test Case"
        Me.cht_func.Titles.Add(Title1)
        '
        'cht_rand
        '
        Me.cht_rand.BackSecondaryColor = System.Drawing.Color.White
        Me.cht_rand.BorderlineColor = System.Drawing.SystemColors.Highlight
        ChartArea2.Name = "ChartArea1"
        Me.cht_rand.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.cht_rand.Legends.Add(Legend2)
        Me.cht_rand.Location = New System.Drawing.Point(22, 332)
        Me.cht_rand.Name = "cht_rand"
        Me.cht_rand.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.cht_rand.Series.Add(Series2)
        Me.cht_rand.Size = New System.Drawing.Size(674, 143)
        Me.cht_rand.TabIndex = 18
        Me.cht_rand.Text = "Chart1"
        Title2.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Title2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title2.ForeColor = System.Drawing.Color.DarkBlue
        Title2.Name = "Title1"
        Title2.Text = "Random-Test"
        Me.cht_rand.Titles.Add(Title2)
        '
        'uc_m_member
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Setting_pnael)
        Me.Controls.Add(Me.panel_chart)
        Me.Controls.Add(Me.btn_Settings)
        Me.Controls.Add(Me.txtCmt)
        Me.Controls.Add(Me.trv_Model)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.trv_Member)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "uc_m_member"
        Me.Size = New System.Drawing.Size(1045, 700)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Setting_pnael.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panel_chart.ResumeLayout(False)
        CType(Me.cht_non, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cht_func, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cht_rand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents trv_Member As WinControls.ListView.TreeListView
    Friend WithEvents btn_search As Windows.Forms.Button
    Friend WithEvents trv_Model As WinControls.ListView.TreeListView
    Friend WithEvents txtCmt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_Settings As Button
    Friend WithEvents Setting_pnael As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ToggleSwitch1 As JCS.ToggleSwitch
    Friend WithEvents txt_count As TextBox
    Friend WithEvents btn_save As Button
    Friend WithEvents panel_chart As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cht_func As DataVisualization.Charting.Chart
    Friend WithEvents cht_non As DataVisualization.Charting.Chart
    Friend WithEvents cht_rand As DataVisualization.Charting.Chart
End Class
