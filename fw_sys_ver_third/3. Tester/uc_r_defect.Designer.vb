<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_r_defect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_r_defect))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pic_Refresh = New System.Windows.Forms.PictureBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.txtProin = New System.Windows.Forms.TextBox()
        Me.txtGroupin = New System.Windows.Forms.TextBox()
        Me.txtStepin = New System.Windows.Forms.TextBox()
        Me.txtModelin = New System.Windows.Forms.TextBox()
        Me.cbItemList = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_upload = New System.Windows.Forms.Button()
        Me.txtDefect = New System.Windows.Forms.TextBox()
        Me.cbDomain = New System.Windows.Forms.ComboBox()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.pic_Refresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btn_upload)
        Me.Panel2.Controls.Add(Me.txtDefect)
        Me.Panel2.Controls.Add(Me.cbDomain)
        Me.Panel2.Controls.Add(Me.txtResult)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtProin)
        Me.Panel2.Controls.Add(Me.txtGroupin)
        Me.Panel2.Controls.Add(Me.txtStepin)
        Me.Panel2.Controls.Add(Me.txtModelin)
        Me.Panel2.Controls.Add(Me.cbItemList)
        Me.Panel2.Controls.Add(Me.pic_Refresh)
        Me.Panel2.Controls.Add(Me.DataGridView2)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(929, 621)
        Me.Panel2.TabIndex = 198
        '
        'pic_Refresh
        '
        Me.pic_Refresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pic_Refresh.Image = CType(resources.GetObject("pic_Refresh.Image"), System.Drawing.Image)
        Me.pic_Refresh.Location = New System.Drawing.Point(18, 28)
        Me.pic_Refresh.Name = "pic_Refresh"
        Me.pic_Refresh.Size = New System.Drawing.Size(16, 16)
        Me.pic_Refresh.TabIndex = 200
        Me.pic_Refresh.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(17, 87)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.Size = New System.Drawing.Size(531, 513)
        Me.DataGridView2.TabIndex = 192
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 12)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "랜덤 자가체크"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "▩"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(929, 3)
        Me.Splitter1.TabIndex = 200
        Me.Splitter1.TabStop = False
        '
        'txtProin
        '
        Me.txtProin.BackColor = System.Drawing.Color.White
        Me.txtProin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtProin.ForeColor = System.Drawing.Color.Gray
        Me.txtProin.Location = New System.Drawing.Point(69, 26)
        Me.txtProin.Name = "txtProin"
        Me.txtProin.Size = New System.Drawing.Size(130, 22)
        Me.txtProin.TabIndex = 205
        '
        'txtGroupin
        '
        Me.txtGroupin.BackColor = System.Drawing.Color.White
        Me.txtGroupin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGroupin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtGroupin.ForeColor = System.Drawing.Color.Gray
        Me.txtGroupin.Location = New System.Drawing.Point(206, 26)
        Me.txtGroupin.Name = "txtGroupin"
        Me.txtGroupin.Size = New System.Drawing.Size(123, 22)
        Me.txtGroupin.TabIndex = 203
        '
        'txtStepin
        '
        Me.txtStepin.BackColor = System.Drawing.Color.White
        Me.txtStepin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStepin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtStepin.ForeColor = System.Drawing.Color.Gray
        Me.txtStepin.Location = New System.Drawing.Point(473, 26)
        Me.txtStepin.Name = "txtStepin"
        Me.txtStepin.Size = New System.Drawing.Size(84, 22)
        Me.txtStepin.TabIndex = 202
        '
        'txtModelin
        '
        Me.txtModelin.BackColor = System.Drawing.Color.White
        Me.txtModelin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModelin.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtModelin.ForeColor = System.Drawing.Color.Gray
        Me.txtModelin.Location = New System.Drawing.Point(336, 26)
        Me.txtModelin.Name = "txtModelin"
        Me.txtModelin.Size = New System.Drawing.Size(130, 22)
        Me.txtModelin.TabIndex = 204
        '
        'cbItemList
        '
        Me.cbItemList.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbItemList.FormattingEnabled = True
        Me.cbItemList.Location = New System.Drawing.Point(575, 27)
        Me.cbItemList.Name = "cbItemList"
        Me.cbItemList.Size = New System.Drawing.Size(332, 21)
        Me.cbItemList.TabIndex = 201
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(573, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 211
        Me.Label3.Text = "▩"
        '
        'btn_upload
        '
        Me.btn_upload.BackColor = System.Drawing.Color.SteelBlue
        Me.btn_upload.FlatAppearance.BorderSize = 0
        Me.btn_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_upload.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_upload.ForeColor = System.Drawing.Color.White
        Me.btn_upload.Location = New System.Drawing.Point(746, 401)
        Me.btn_upload.Name = "btn_upload"
        Me.btn_upload.Size = New System.Drawing.Size(75, 23)
        Me.btn_upload.TabIndex = 206
        Me.btn_upload.Text = "Upload"
        Me.btn_upload.UseVisualStyleBackColor = False
        '
        'txtDefect
        '
        Me.txtDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDefect.Location = New System.Drawing.Point(573, 175)
        Me.txtDefect.Name = "txtDefect"
        Me.txtDefect.Size = New System.Drawing.Size(248, 21)
        Me.txtDefect.TabIndex = 209
        '
        'cbDomain
        '
        Me.cbDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbDomain.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbDomain.FormattingEnabled = True
        Me.cbDomain.Location = New System.Drawing.Point(573, 146)
        Me.cbDomain.Name = "cbDomain"
        Me.cbDomain.Size = New System.Drawing.Size(248, 23)
        Me.cbDomain.TabIndex = 208
        '
        'txtResult
        '
        Me.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult.Location = New System.Drawing.Point(570, 270)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(251, 110)
        Me.txtResult.TabIndex = 210
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(571, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 213
        Me.Label1.Text = "검증결과 작성"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(572, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 15)
        Me.Label2.TabIndex = 207
        Me.Label2.Text = "Defect (TD 번호만 기입)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(596, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 12)
        Me.Label6.TabIndex = 212
        Me.Label6.Text = "Defect"
        '
        'uc_Random_Main_Write
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Name = "uc_Random_Main_Write"
        Me.Size = New System.Drawing.Size(929, 624)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pic_Refresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents DataGridView2 As Windows.Forms.DataGridView
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents pic_Refresh As Windows.Forms.PictureBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btn_upload As Windows.Forms.Button
    Friend WithEvents txtDefect As Windows.Forms.TextBox
    Friend WithEvents cbDomain As Windows.Forms.ComboBox
    Friend WithEvents txtResult As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txtProin As Windows.Forms.TextBox
    Friend WithEvents txtGroupin As Windows.Forms.TextBox
    Friend WithEvents txtStepin As Windows.Forms.TextBox
    Friend WithEvents txtModelin As Windows.Forms.TextBox
    Friend WithEvents cbItemList As Windows.Forms.ComboBox
End Class
