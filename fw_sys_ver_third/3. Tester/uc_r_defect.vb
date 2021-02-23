Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports WinControls.ListView

Public Class uc_r_defect
    Public Shared uc_write As uc_r_defect
    Private trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker
    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Private _user As String
    Private _company As String

    Private _pjt As String
    Private _grp As String
    Private _mod As String
    Private _step As String

    Private _trlv As TreeListView

    Private _dgv As DataGridView

    Public Sub New()

        InitializeComponent()

        uc_write = Me

        set_project()

        _dgv = DataGridView2

        txtDefect.MaxLength = 10

        cbDomain.Items.Add("OFFICIAL_Mobile_19")
        cbDomain.Items.Add("OFFICIAL_Mobile_18")
        cbDomain.Items.Add("OFFICIAL_Mobile_17")
        cbDomain.Font = New Drawing.Font("맑은 고딕", 9, Drawing.FontStyle.Bold Or Drawing.FontStyle.Italic)
        cbDomain.SelectedIndex = 0  '// 첫번째 아이템으로 보여지도록


        cbDomain.Enabled = False
        txtDefect.Enabled = False
        txtResult.Enabled = False
        uc_Load()

    End Sub

    Public Sub set_project()
        _pjt = txtProin.Text
        _grp = txtGroupin.Text
        _mod = txtModelin.Text
        _step = txtStepin.Text
        _user = _user
        _company = _company
    End Sub

    Private Sub uc_Load()

        '// 0 Parent Form에서 가져온 정보 저장
        'With uc_Random_Main.f
        '    _pjt = txtProin.Text : _grp = txtGroupin.Text
        '    _mod = txtModelin.Text : _step = txtStepin.Text
        '    _user = _user : _company = _company
        'End With

    End Sub

    Private Sub click_Refresh(sender As Object, e As EventArgs) Handles pic_Refresh.Click
        '// 리프레시 선택 하면 데이터 불러오도록
        uc_Load()
        load_database()

    End Sub

    Private Sub load_database()

        '// 예외처리 Check 하기 위함.
        Dim tmp As List(Of String) =
            New List(Of String) From {_pjt, _grp, _mod, _step}
        Dim cnt As Integer = tmp.Where(Function(x) x = "").Count

        If cnt > 0 Then
            Qportals.Debugging.Show("모델 정보가 입력 되지 않았습니다.")
            Exit Sub
        End If


        Dim sql As String

        sql = String.Format(
            "select ID,Apps, type, Detailed_type, rd_plan_write as `랜덤기획`, rd_plan_result as `랜덤결과`, Domain, Defect from td_defect.`individual_random` 
        where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}' and 
        Tester = '{4}' and Company = '{5}'", _pjt, _grp, _mod, _step, _user, _company)

        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)

        If Not (dt Is Nothing) Then
            DataGridView2.DataSource = dt
            DataGridView2.Columns(0).Visible = False

        End If

    End Sub

    '// DataGridView에서 셀 선택 시 내용 입력 할 수 있도록
    Private Sub dgv_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick

        DataGridVieCell_Click(e)

    End Sub
    Private Sub DataGridVieCell_Click(e As DataGridViewCellEventArgs)

        If Not _dgv.SelectedRows Is Nothing Then
            'txtChange.Enabled = True    '// 텍스트 박스를 활성화 한다.
            'txtChange.Text = _dgv(3, _dgv.CurrentCell.RowIndex).Value.ToString
            Try
                cbDomain.Enabled = True
                txtDefect.Enabled = True

                txtResult.Enabled = True    '// 텍스트 박스를 활성화 한다.
                txtResult.Text = _dgv(5, _dgv.CurrentCell.RowIndex).Value.ToString
                'cbDomain.Text = _dgv(6, _dgv.CurrentCell.RowIndex).Value.ToString
                txtDefect.Text = _dgv(7, _dgv.CurrentCell.RowIndex).Value.ToString
            Catch ex As Exception
                Qportals.Debugging.Print(ex.Message)
            End Try

        End If


    End Sub
    Private Sub textboxTodgv_Des(sender As Object, e As KeyEventArgs)
        '// 텍스트 박스에서 입력 시 바로 입력 되도록
        '// 중점 검증 내용 작성 

        If TryCast(sender, Control).Name = "txtDefect" Then

            _dgv(6, _dgv.CurrentCell.RowIndex).Value = cbDomain.Text
            _dgv(7, _dgv.CurrentCell.RowIndex).Value = txtDefect.Text

        ElseIf TryCast(sender, Control).Name = "txtResult" Then
            _dgv(5, _dgv.CurrentCell.RowIndex).Value = txtResult.Text

        End If

    End Sub

    Private Sub Except_NumberInput(sender As Object, e As KeyPressEventArgs)

        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back)) Then

            e.Handled = True

        End If

    End Sub

    Private Sub UploadButtonClick(sender As Object, e As EventArgs)
        DBUpload()




    End Sub


    Private Sub DBUpload()

        Dim chkErr As Boolean = False               '// DB Update 시 오류 판단할 변수

        Dim insert_count As Integer = 0 '// Insert 되는 항목 갯수를 세기 위한 변수
        Dim modicnt As Integer = 0
        Dim dt As DataTable = TryCast(_dgv.DataSource, DataTable)  '// DataGrid의 데이터 DataTable로 변환

        Dim spjt As String, sgrp As String, smod As String, sstep As String
        Dim strRandomResult As String, strDomain As String, strDefect As String
        Dim user As String, company As String

        spjt = _pjt : sgrp = _grp : smod = _mod : sstep = _step
        user = _user : company = _company

        If Windows.Forms.MessageBox.Show("정말 업로드 하시겠습니까?", "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If



        For Each dr As DataRow In dt.Rows

            strRandomResult = rm_quarter(dr.Item("랜덤결과").ToString)
            strDomain = rm_quarter(dr.Item("Domain").ToString)
            strDefect = rm_quarter(dr.Item("Defect").ToString)

            ' update 구문
            Dim sql_modi As String
            sql_modi = String.Format("update td_defect.`individual_random` set `rd_plan_result` = '{0}', `Domain` = '{1}', `Defect` = '{2}' where id = {3}",
                                    strRandomResult, strDomain, strDefect, dr.Item("ID"))

            chkErr = dbc.Query_to_Mysql(sql_modi)
            modicnt += 1

        Next

        Dim cmment As String = String.Format(
"정상적으로 F/W가 수정되었습니다.
        ---------------------------------
        {0} 기준", Now())

        Qportals.Debugging.Show(cmment)

    End Sub

    Private Function rm_quarter(ByRef strText As String)
        strText = Replace(strText, "'", "")
        Return strText
    End Function





End Class
