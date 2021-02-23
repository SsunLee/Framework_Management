<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_r_plan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_r_plan))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtProin = New System.Windows.Forms.TextBox()
        Me.txtGroupin = New System.Windows.Forms.TextBox()
        Me.txtStepin = New System.Windows.Forms.TextBox()
        Me.txtModelin = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New MetroFramework.Controls.MetroCheckBox()
        Me.cbItemList = New System.Windows.Forms.ComboBox()
        Me.txttype2 = New System.Windows.Forms.TextBox()
        Me.txttype = New System.Windows.Forms.TextBox()
        Me.txtApp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.txtWriteResult = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TreeListView1 = New WinControls.ListView.TreeListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pic_Refresh = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Refresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.pic_Refresh)
        Me.Panel2.Controls.Add(Me.txtProin)
        Me.Panel2.Controls.Add(Me.txtGroupin)
        Me.Panel2.Controls.Add(Me.txtStepin)
        Me.Panel2.Controls.Add(Me.txtModelin)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.cbItemList)
        Me.Panel2.Controls.Add(Me.txttype2)
        Me.Panel2.Controls.Add(Me.txttype)
        Me.Panel2.Controls.Add(Me.txtApp)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtDes)
        Me.Panel2.Controls.Add(Me.txtWriteResult)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TreeListView1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.btn_add)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(873, 557)
        Me.Panel2.TabIndex = 194
        '
        'txtProin
        '
        Me.txtProin.BackColor = System.Drawing.Color.White
        Me.txtProin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtProin.ForeColor = System.Drawing.Color.Gray
        Me.txtProin.Location = New System.Drawing.Point(16, 48)
        Me.txtProin.Name = "txtProin"
        Me.txtProin.Size = New System.Drawing.Size(130, 22)
        Me.txtProin.TabIndex = 199
        '
        'txtGroupin
        '
        Me.txtGroupin.BackColor = System.Drawing.Color.White
        Me.txtGroupin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGroupin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtGroupin.ForeColor = System.Drawing.Color.Gray
        Me.txtGroupin.Location = New System.Drawing.Point(153, 48)
        Me.txtGroupin.Name = "txtGroupin"
        Me.txtGroupin.Size = New System.Drawing.Size(123, 22)
        Me.txtGroupin.TabIndex = 197
        '
        'txtStepin
        '
        Me.txtStepin.BackColor = System.Drawing.Color.White
        Me.txtStepin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStepin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStepin.ForeColor = System.Drawing.Color.Gray
        Me.txtStepin.Location = New System.Drawing.Point(420, 48)
        Me.txtStepin.Name = "txtStepin"
        Me.txtStepin.Size = New System.Drawing.Size(84, 22)
        Me.txtStepin.TabIndex = 196
        '
        'txtModelin
        '
        Me.txtModelin.BackColor = System.Drawing.Color.White
        Me.txtModelin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModelin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtModelin.ForeColor = System.Drawing.Color.Gray
        Me.txtModelin.Location = New System.Drawing.Point(283, 48)
        Me.txtModelin.Name = "txtModelin"
        Me.txtModelin.Size = New System.Drawing.Size(130, 22)
        Me.txtModelin.TabIndex = 198
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(729, 28)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(125, 15)
        Me.CheckBox1.TabIndex = 195
        Me.CheckBox1.Text = "오늘 데이터만 보기"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cbItemList
        '
        Me.cbItemList.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbItemList.FormattingEnabled = True
        Me.cbItemList.Location = New System.Drawing.Point(522, 49)
        Me.cbItemList.Name = "cbItemList"
        Me.cbItemList.Size = New System.Drawing.Size(332, 21)
        Me.cbItemList.TabIndex = 194
        '
        'txttype2
        '
        Me.txttype2.BackColor = System.Drawing.Color.White
        Me.txttype2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttype2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txttype2.ForeColor = System.Drawing.Color.Gray
        Me.txttype2.Location = New System.Drawing.Point(341, 118)
        Me.txttype2.Name = "txttype2"
        Me.txttype2.Size = New System.Drawing.Size(130, 22)
        Me.txttype2.TabIndex = 193
        Me.txttype2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txttype
        '
        Me.txttype.BackColor = System.Drawing.Color.White
        Me.txttype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttype.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txttype.ForeColor = System.Drawing.Color.Gray
        Me.txttype.Location = New System.Drawing.Point(158, 118)
        Me.txttype.Name = "txttype"
        Me.txttype.Size = New System.Drawing.Size(177, 22)
        Me.txttype.TabIndex = 193
        Me.txttype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtApp
        '
        Me.txtApp.BackColor = System.Drawing.Color.White
        Me.txtApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtApp.ForeColor = System.Drawing.Color.Gray
        Me.txtApp.Location = New System.Drawing.Point(20, 118)
        Me.txtApp.Name = "txtApp"
        Me.txtApp.Size = New System.Drawing.Size(132, 22)
        Me.txtApp.TabIndex = 193
        Me.txtApp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(42, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 12)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "랜덤 자가체크"
        '
        'txtDes
        '
        Me.txtDes.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDes.Location = New System.Drawing.Point(20, 445)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(451, 89)
        Me.txtDes.TabIndex = 192
        '
        'txtWriteResult
        '
        Me.txtWriteResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWriteResult.Location = New System.Drawing.Point(480, 147)
        Me.txtWriteResult.Multiline = True
        Me.txtWriteResult.Name = "txtWriteResult"
        Me.txtWriteResult.Size = New System.Drawing.Size(335, 148)
        Me.txtWriteResult.TabIndex = 192
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "▩"
        '
        'TreeListView1
        '
        Me.TreeListView1.Enabled = False
        Me.TreeListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TreeListView1.Location = New System.Drawing.Point(20, 146)
        Me.TreeListView1.Name = "TreeListView1"
        Me.TreeListView1.Size = New System.Drawing.Size(451, 293)
        Me.TreeListView1.TabIndex = 185
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(477, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "검증방법 작성"
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.SteelBlue
        Me.btn_add.FlatAppearance.BorderSize = 0
        Me.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_add.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_add.ForeColor = System.Drawing.Color.White
        Me.btn_add.Location = New System.Drawing.Point(740, 301)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_add.TabIndex = 182
        Me.btn_add.Text = "DB Up"
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 557)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(873, 3)
        Me.Splitter1.TabIndex = 196
        Me.Splitter1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.DataGridView1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 560)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(873, 100)
        Me.Panel4.TabIndex = 197
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(873, 100)
        Me.DataGridView1.TabIndex = 192
        '
        'pic_Refresh
        '
        Me.pic_Refresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pic_Refresh.Image = CType(resources.GetObject("pic_Refresh.Image"), System.Drawing.Image)
        Me.pic_Refresh.Location = New System.Drawing.Point(20, 17)
        Me.pic_Refresh.Name = "pic_Refresh"
        Me.pic_Refresh.Size = New System.Drawing.Size(16, 16)
        Me.pic_Refresh.TabIndex = 200
        Me.pic_Refresh.TabStop = False
        '
        'uc_Random_Main_Plan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "uc_Random_Main_Plan"
        Me.Size = New System.Drawing.Size(873, 660)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Refresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents TreeListView1 As WinControls.ListView.TreeListView
    Friend WithEvents btn_add As Windows.Forms.Button
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents txtWriteResult As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txttype2 As Windows.Forms.TextBox
    Friend WithEvents txttype As Windows.Forms.TextBox
    Friend WithEvents txtApp As Windows.Forms.TextBox
    Friend WithEvents txtDes As Windows.Forms.TextBox
    Friend WithEvents txtProin As Windows.Forms.TextBox
    Friend WithEvents txtGroupin As Windows.Forms.TextBox
    Friend WithEvents txtStepin As Windows.Forms.TextBox
    Friend WithEvents txtModelin As Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents cbItemList As Windows.Forms.ComboBox
    Friend WithEvents pic_Refresh As Windows.Forms.PictureBox
End Class
