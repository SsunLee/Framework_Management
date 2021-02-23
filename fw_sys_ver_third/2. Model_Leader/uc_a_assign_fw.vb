Imports System.Reflection
Imports MetroFramework


Public Class uc_a_assign_fw

    Private m_dgv As DataGridView

    Private c_for_assign As Assign_System_for_Assign

    Public Sub New()
        InitializeComponent()
        m_dgv = DataGridView1
        With txtHigh
            .BackColor = Color.FromArgb(179, 255, 179)
            .Text = String.Format("{0:0.0}", 4.0)
        End With
        With txtMiddle
            .BackColor = Color.FromArgb(255, 231, 155)
            .Text = String.Format("{0:0.0}", 3.0)
            .ImeMode = ImeMode.Disable
        End With
        With txtLow
            .BackColor = Color.FromArgb(255, 159, 159)
            .Text = String.Format("{0:0.0}", 2.0)
            .ImeMode = ImeMode.Disable
        End With

        Setting_pnael.Visible = False
        'm_dgv.Size = New Size(960, 272)
        'TreeListView3.Visible = False
        'TreeListView3.Visible = False
        'la_member.Visible = False
        'btn_upload.Visible = False

        treeView_m.BorderStyle = BorderStyle.FixedSingle


    End Sub
    Private Sub treeView_selectedITem(seder As Object, e As TreeViewEventArgs) Handles treeView_m.AfterSelect

        c_for_assign.TreeView_SelectEvent(e)

    End Sub
    Private Sub Main_load(sender As Object, e As EventArgs) Handles MyBase.Load

        '// 기본 설정
        c_for_assign = New Assign_System_for_Assign(DataGridView1, New WinControls.ListView.TreeListView() {TreeListView1, TreeListView2, TreeListView3})
        c_for_assign.__datagridView__() '// 디자인 설정
        c_for_assign.__TreeListView__() '// 디자인 설정

        c_for_assign._init_Assign_data()   '// TreeListView / DataGridView 데이터 불러오기

        looptest(TreeListView1.Nodes)               '// TreeListView 색상 Marking
        looptest_AvgColor(TreeListView2.Nodes)      '// TreeListView 색상 Marking


        c_for_assign.ImportCht_backdata()

        ' treeview 할당 하기
        c_for_assign._treeview = treeView_m

        Dim cmt As String = c_for_assign.load_Project_fromAssign()

        If Not cmt = "" Then
            txtCmt.Text = cmt
        End If

    End Sub

    Private Sub Select_trvs_dgvs(sender As Object, e As EventArgs) Handles TreeListView1.Click, TreeListView2.Click, DataGridView1.Click

        If ToggleSwitch1.Checked = True Then

            If TryCast(sender, Control).Name = "TreeListView1" Then
                c_for_assign.Make_ChartScreen(sender, TreeListView1)
            ElseIf TryCast(sender, Control).Name = "TreeListView2" Then
                c_for_assign.Make_ChartScreen(sender, TreeListView2)
            ElseIf TryCast(sender, Control).Name = "DataGridView1" Then
                c_for_assign.Make_ChartScreen(sender, DataGridView1)
            End If

        End If

    End Sub

    Private Sub UploadData_toDatabase(sender As Object, e As EventArgs) Handles btn_upload.Click
        c_for_assign.DB_Upload_for_FWAssign()
    End Sub
    ''' <summary>
    ''' 펼치기 버튼을 눌렀을 때 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Member_ShowHide(sender As Object, e As EventArgs) Handles btn_Expand.Click
        If (m_dgv.Width = 960) Then
            m_dgv.Size = New Size(495, 272)
            TreeListView3.Visible = True
            TreeListView3.Visible = True
            la_member.Visible = True
            btn_upload.Visible = True

        Else
            m_dgv.Size = New Size(960, 272)
            TreeListView3.Visible = False
            TreeListView3.Visible = False
            la_member.Visible = False
            btn_upload.Visible = False
        End If
    End Sub

    Private Sub Treeview_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles treeView_m.Paint
        '// Panel의 Border Style 지정 
        treeView_m.BorderStyle = BorderStyle.FixedSingle
        '// treeView_m의 BorderStyle을 Pen으로 직접 그림. 
        '// RGB Color인데 (0,0,0,0) 인 이유는 맨 앞 0은 Opacity 
        '// Pen(color, x) x는 펜의 굵기. 
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(100, 135, 173, 241), 5), treeView_m.ClientRectangle)
    End Sub

    Private Sub btnListOrbtnAvg(sender As Object, e As EventArgs) Handles btnAvg_excel.Click, btnList_excel.Click

        If TryCast(sender, Control).Name = "btnList_excel" Then
            c_for_assign.downloadExcel(TreeListView1, "투입현황")
        ElseIf TryCast(sender, Control).Name = "btnList_excel" Then
            c_for_assign.downloadExcel(TreeListView2, "평균역량")
        End If

    End Sub


    ''' <summary>
    ''' Setting Panel 보이기/가리기
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PanelOnOff(sender As Object, e As EventArgs) Handles btnSetting.Click
        ShowHidePanel()
    End Sub
    Private Sub LostFocus_fromSetting(sender As Object, e As EventArgs) Handles Me.MouseClick
        Setting_pnael.Visible = False
    End Sub

    ''' <summary>
    ''' 설정 패널을 보여주거나 Hide하는 함수입니다.
    ''' </summary>
    Private Sub ShowHidePanel()
        With Setting_pnael
            If .Visible Then
                .Visible = False
            Else
                .Visible = True
            End If
        End With
    End Sub

    ''' <summary>
    ''' IsDisit : 숫자 인지? e.Handled = True : Handeled True이면 이벤트가 처리 되었다는 표시이므로, 아래 키 외에는 넘긴다
    ''' 실수만 입력받기 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TxtBoxOnlyNumeric(sender As Object, e As KeyPressEventArgs) Handles txtHigh.KeyPress, txtMiddle.KeyPress, txtLow.KeyPress
        ' IsDisit : 숫자 인지? 
        ' e.Handled = True (Handeled가 True이면 이벤트가 처리 되었다는 표시이므로, 아래 키 외에는 넘긴다.)
        '실수만 입력받기 
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back) Or e.KeyChar = ".") Then
            e.Handled = True

        End If
    End Sub

    Private Sub SetdgvStyle(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        ' * DataGridView 스타일을 엑셀 처럼
        Dim dgvstyle As Qportals.Controls.dgvStyle = New Qportals.Controls.dgvStyle
        dgvstyle.Grid_RowPostPaint(DataGridView1, e)
    End Sub

    Private Sub looptest(nodes As WinControls.ListView.Collections.TreeListNodeCollection)
        '// TreeListView1
        For Each node As WinControls.ListView.TreeListNode In nodes
            If (node.Level = 2) Then
                If (txtHigh.Text <> "") And (txtMiddle.Text <> "") And (txtLow.Text <> "") Then

                    Dim level As Double = CDbl(Val(node.SubItems.Item(1).Text))

                    Dim high As Double = CDbl(txtHigh.Text) : Dim Mid As Double = CDbl(txtMiddle.Text)
                    Dim low As Double = CDbl(txtLow.Text)

                    Select Case level
                        Case Is >= high
                            ' 녹색 계열
                            node.BackColor = Color.FromArgb(179, 255, 179)
                        Case Is >= Mid
                            '노란 계열
                            node.BackColor = Color.FromArgb(255, 231, 155)
                        Case Is <= low
                            ' 레드 계열
                            node.BackColor = Color.FromArgb(255, 159, 159)
                    End Select

                End If
            End If
            looptest(node.Nodes)
        Next
    End Sub
    Private Sub looptest_AvgColor(nodes As WinControls.ListView.Collections.TreeListNodeCollection)
        'TreeListView2
        For Each node As WinControls.ListView.TreeListNode In nodes
            If (node.Level = 2) Then
                If (txtHigh.Text <> "") And (txtMiddle.Text <> "") And (txtLow.Text <> "") Then
                    If (node.SubItems.Count >= 1) Then

                        Dim level As Double = CDbl(Val(node.SubItems.Item(0).Text))
                        Dim high As Double = CDbl(txtHigh.Text) : Dim Mid As Double = CDbl(txtMiddle.Text)
                        Dim low As Double = CDbl(txtLow.Text)

                        Select Case level
                            Case Is >= high
                                ' 녹색 계열
                                node.BackColor = Color.FromArgb(179, 255, 179)
                            Case Is >= Mid
                                '노란 계열
                                node.BackColor = Color.FromArgb(255, 231, 155)
                            Case Is <= low
                                ' 레드 계열
                                node.BackColor = Color.FromArgb(255, 159, 159)
                        End Select

                    End If
                End If
            End If
            looptest_AvgColor(node.Nodes)
        Next
    End Sub


    Private Sub Get_Model_TreeView()


    End Sub





End Class
