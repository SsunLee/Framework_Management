<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_a_add_fw
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_a_add_fw))
        Me.btn_upload = New System.Windows.Forms.Button()
        Me.btn_down = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btn_upload.Location = New System.Drawing.Point(962, 65)
        Me.btn_upload.Name = "btn_upload"
        Me.btn_upload.Size = New System.Drawing.Size(33, 24)
        Me.btn_upload.TabIndex = 615
        Me.btn_upload.UseVisualStyleBackColor = True
        '
        'btn_down
        '
        Me.btn_down.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_down.FlatAppearance.BorderSize = 0
        Me.btn_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_down.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_down.ForeColor = System.Drawing.Color.Gray
        Me.btn_down.Image = CType(resources.GetObject("btn_down.Image"), System.Drawing.Image)
        Me.btn_down.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_down.Location = New System.Drawing.Point(14, 63)
        Me.btn_down.Name = "btn_down"
        Me.btn_down.Size = New System.Drawing.Size(29, 24)
        Me.btn_down.TabIndex = 616
        Me.btn_down.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(14, 93)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(972, 513)
        Me.DataGridView1.TabIndex = 617
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 15)
        Me.Label1.TabIndex = 618
        Me.Label1.Text = "Framework Item 등록 화면입니다."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(448, 13)
        Me.Label2.TabIndex = 618
        Me.Label2.Text = "Excel Button을 이용하여 Sample 파일에 내용을 입력 후 Drag & Drop 업데이트 해주세요"
        '
        'uc_a_add_fw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_upload)
        Me.Controls.Add(Me.btn_down)
        Me.Name = "uc_a_add_fw"
        Me.Size = New System.Drawing.Size(1007, 682)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_upload As Button
    Friend WithEvents btn_down As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
