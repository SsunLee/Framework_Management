Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Class uc_m_model
    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Private _lists() As ListBox
    Private _dt As DataTable
    Public Sub New()

        InitializeComponent()

        _lists = New ListBox() {ListBox1, ListBox2, ListBox3, ListBox4}
        _dt = New DataTable

        'Panel11.BackColor = Color.FromArgb(226, 239, 218)
        'Panel17.BackColor = Color.FromArgb(226, 239, 218)
        get_Projects()

    End Sub

#Region "Project_Function"
    Private Sub get_Projects()

        Dim sql As String = Nothing



        For Each lb As ListBox In _lists
            lb.Items.Clear()
        Next

        sql = "SELECT * FROM td_defect.test_project WHERE `GroupName` IS NOT NULL AND Model IS NOT NULL AND step IS NOT NULL ORDER BY Project,`GroupName`,Model, 
                CASE 
                WHEN (Step IS NULL) THEN 6 
                WHEN (Step LIKE 'OT%') THEN 5 
                WHEN (Step LIKE 'PRE%') THEN 4 
                WHEN (Step LIKE 'VP%') THEN 3 
                WHEN (Step LIKE 'QP%') THEN 2 
                WHEN (Step LIKE 'MR%') THEN 1 
                ELSE 0 
                END 
                DESC"

        _dt = dbc.Mysql_to_datatable(sql)
        Dim lstbox As Qportals.Controls.ListBoxClass = New Qportals.Controls.ListBoxClass

        If Not (_dt Is Nothing) And Not (_dt.Rows.Count = 0) Then
            ' dt
            Qportals.Debugging.Print("data 조회 됨")
            lstbox._ListBox = ListBox1
            lstbox.AddListBox(_dt, "Project")

        Else
            Qportals.Debugging.Print("data 조회 안 됨")
        End If

    End Sub
    Private lsb As Qportals.Controls.ListBoxClass = New Qportals.Controls.ListBoxClass

    Private Sub Click_NextItem_Num(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        txtML.Text = ""
        txtMM.Text = ""
        txtPL.Text = ""
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        ClickItems(New ListBox() {
                                        ListBox1, ListBox2
                                     }, _dt)


    End Sub

    Private Sub Click_NextItem_Num2(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        txtML.Text = ""
        txtMM.Text = ""
        txtPL.Text = ""
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ClickItems(New ListBox() {
                                       ListBox1, ListBox2, ListBox3
                                     }, _dt)
    End Sub
    Private Sub Click_NextItem_Num3(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        txtML.Text = ""
        txtMM.Text = ""
        txtPL.Text = ""
        ListBox4.Items.Clear()
        ClickItems(New ListBox() {
                                       ListBox1, ListBox2, ListBox3, ListBox4
                                     }, _dt)
    End Sub
    Private Sub Click_NextItem_Num4(sender As Object, e As EventArgs) Handles ListBox4.SelectedValueChanged
        txtML.Text = ""
        txtMM.Text = ""
        txtPL.Text = ""
        ClickItems(New ListBox() {
                                       ListBox1, ListBox2, ListBox3, ListBox4, ListBox4
                                     }, _dt)
    End Sub

    Private Property _ListBox As ListBox
    Private Property _textboxs() As TextBox

    Private Sub AddListBox(ByRef _dt As DataTable, ByRef _columnName As String)
        Dim temp_dt As DataTable = _dt
        '// 맨 처음 load 됐을 때 불러오는 부분
        If Not (temp_dt Is Nothing) And Not (_dt.Rows.Count = 0) Then
            temp_dt = temp_dt.DefaultView.ToTable(True, _columnName)
            For i As Integer = 0 To temp_dt.Rows.Count - 1
                _ListBox.Items.Add(temp_dt.Rows(i)(0).ToString())
            Next
        End If

    End Sub

    Private Sub ClickItems(ByRef lstBoxs() As ListBox, ByRef _dt As DataTable)
        '// 프로젝트 정보 클릭 시 다음 항목 보여주는 함수
        Select Case lstBoxs.Length
            Case 2
                _ListBox = lstBoxs(1)
                _ListBox.Items.Clear()
                For Each dr As DataRow In _dt.Rows
                    If lstBoxs(0).SelectedItem.ToString = dr.Item(1).ToString Then
                        If Not (_ListBox.Items.Contains(dr.Item(2).ToString)) Then
                            _ListBox.Items.Add(dr.Item(2).ToString)
                        End If
                    End If
                Next
            Case 3
                '// if 컬럼 존재 하면 
                _ListBox = lstBoxs(2)
                _ListBox.Items.Clear()

                For Each dr As DataRow In _dt.Rows
                    If (lstBoxs(0).SelectedItem.ToString = dr.Item(1).ToString) And
                            (lstBoxs(1).SelectedItem.ToString = dr.Item(2).ToString) Then
                        If Not (_ListBox.Items.Contains(dr.Item(3).ToString)) Then
                            _ListBox.Items.Add(dr.Item(3).ToString)
                        End If
                    End If
                Next

            Case 4

                _ListBox = lstBoxs(3)
                _ListBox.Items.Clear()
                For Each dr As DataRow In _dt.Rows
                    If (lstBoxs(0).SelectedItem.ToString = dr.Item(1).ToString) And
                        (lstBoxs(1).SelectedItem.ToString = dr.Item(2).ToString) And
                        (lstBoxs(2).SelectedItem.ToString = dr.Item(3).ToString) Then
                        If Not (_ListBox.Items.Contains(dr.Item(4).ToString)) Then
                            _ListBox.Items.Add(dr.Item(4).ToString)
                        End If
                    End If
                Next

            Case 5

                _ListBox = lstBoxs(4)
                For Each dr As DataRow In _dt.Rows
                    If (lstBoxs(0).SelectedItem.ToString = dr.Item(1).ToString) AndAlso
                        (lstBoxs(1).SelectedItem.ToString = dr.Item(2).ToString) AndAlso
                        (lstBoxs(2).SelectedItem.ToString = dr.Item(3).ToString) AndAlso
                        (lstBoxs(3).SelectedItem.ToString = dr.Item(4).ToString) Then

                        txtML.Text = If(dr.Item("모델리더") Is Nothing Or dr.Item("모델리더").ToString = "", "미등록", dr.Item("모델리더").ToString)
                        txtMM.Text = If(dr.Item("PL개발실") Is Nothing Or dr.Item("PL개발실").ToString = "", "미등록", dr.Item("PL개발실").ToString)
                        txtPL.Text = If(dr.Item("MM Part") Is Nothing Or dr.Item("MM Part").ToString = "", "미등록", dr.Item("MM Part").ToString)

                    End If
                Next

        End Select


    End Sub
    Public strPjt As String
    Public strGrp As String
    Public strMod As String
    Public strStep As String
    Public date_start As String
    Public date_end As String
    Public seq As Integer
    Private Sub BtnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click

        ' Commit Button 눌렀을 때

        Dim lst() As ListBox = New ListBox() {ListBox1, ListBox2, ListBox3, ListBox4}
        Dim num As Integer = 0

        Dim dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class


        If (lst(0).SelectedItems.Count > 0) Then

            Dim sql As String

            ' 모델 조회를 해서 차수가 없다면 
            sql = String.Format("select count(Step) from td_defect.`Project` where `Project` = '{0}' and `GroupName` = '{1}' and `Model` = '{2}'",
                            lst(0).SelectedItem.ToString,
                            lst(1).SelectedItem.ToString,
                            lst(2).SelectedItem.ToString)
            Dim result As String = dbc.GetQueryResult(sql)

            ' 결과가 있다면 이 전 값에 더해 주어야 함.
            If (CInt(result) > 0) Then
                sql = String.Format("insert into td_defect.`test_Project` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `랭킹`, 모델리더, `MM Part`, `PL개발실`) 
                                    Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', (select max(랭킹)+1 from td_defect.`Project` a),'{6}', '{7}', '{8}' ) on Duplicate key update StartDate='{4}', EndDate = '{5}'",
                lst(0).SelectedItem.ToString,
                lst(1).SelectedItem.ToString,
                lst(2).SelectedItem.ToString,
                lst(3).SelectedItem.ToString,
                StartDate.Value.ToString("yyyy-MM-dd 08:00:00"),
                EndDate.Value.ToString("yyyy-MM-dd 20:00:00"),
                txtML.Text, txtMM.Text, txtPL.Text)
            Else

                sql = String.Format(
                    "insert into td_defect.`test_Project` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `랭킹`, 모델리더, `MM Part`, `PL개발실`) 
                                    Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6},'{7}', '{8}', '{9}') on Duplicate key update StartDate='{4}', EndDate = '{5}')",
                lst(0).SelectedItem.ToString,
                lst(1).SelectedItem.ToString,
                lst(2).SelectedItem.ToString,
                lst(3).SelectedItem.ToString,
                StartDate.Value.ToString("yyyy-MM-dd 08:00:00"),
                EndDate.Value.ToString("yyyy-MM-dd 20:00:00"),
                1, txtML.Text, txtMM.Text, txtPL.Text)


            End If



            Dim errCheck As Boolean = dbc.Query_to_Mysql(sql)

            If (errCheck = False) Then
                Qportals.Debugging.Show("Database 올리는 중 문제가 생겼습니다." & vbCrLf & "다시 시도해주세요.",,, 16)
                Exit Sub
            End If

            ' 추가를 했으니 프로젝트 정보를 넣어준다.
            Dim u As New UserControl
            Dim p As New uc_a_add

            strPjt = lst(0).SelectedItem.ToString()
            strGrp = lst(1).SelectedItem.ToString()
            strMod = lst(2).SelectedItem.ToString()
            strStep = lst(3).SelectedItem.ToString()
            date_start = StartDate.Value.ToString("yyyy-MM-dd 08:00:00")
            date_end = EndDate.Value.ToString("yyyy-MM-dd 20:00:00")
            '
            ' 리프레시 합니다.
            get_Projects()

            Qportals.Debugging.Show("정상적으로 모델이 등록되었습니다." & vbCrLf & "이제 프레임워크를 등록해주세요.")

        Else

        End If





    End Sub


#Region "플러스, 마이너스 버튼 눌렀을 때 예외처리"

    Private Sub AddPjt(sender As Object, e As EventArgs) Handles btnAddPjt.Click
        Dim inbox As Qportals.Level.AddPjtInfo = New Qportals.Level.AddPjtInfo
        Dim msg As List(Of String) = New List(Of String)

        msg.Add(String.Format(
        "프로젝트를 아래와 같이 작성하세요. 
           예시) ALPHA_POS, FLASH_POS
           (대문자,프로젝트명_OS 형태)"))
        msg.Add("Project 입력")
        msg.Add("ALPHA_POS")

        Dim rec As Rectangle = New Rectangle
        rec = Me.RectangleToScreen(Me.ClientRectangle)
        inbox._r = rec

        Dim lst As List(Of ListBox) = New List(Of ListBox)
        lst.AddRange(New ListBox() {ListBox2, ListBox3, ListBox4})

        inbox.PjtInfo(msg.ToArray, ListBox1, lst)

    End Sub
    Private Sub AddGrp(sender As Object, e As EventArgs) Handles btnAddGrp.Click
        Dim inbox As Qportals.Level.AddPjtInfo = New Qportals.Level.AddPjtInfo
        Dim msg As List(Of String) = New List(Of String)

        If (ListBox1.SelectedItems.Count > 0) Then
            msg.Add(String.Format(
            "그룹을 아래와 같이 작성하세요. 
             예시) 내수, 북미, Global"))
            msg.Add("Group 입력")
            msg.Add("내수")

            Dim rec As Rectangle = New Rectangle
            rec = Me.RectangleToScreen(Me.ClientRectangle)
            inbox._r = rec

            Dim lst As List(Of ListBox) = New List(Of ListBox)
            lst.AddRange(New ListBox() {ListBox3, ListBox4})
            inbox.PjtInfo(msg.ToArray, ListBox2, lst)
        Else
            Qportals.Debugging.Show("먼저 프로젝트를 선택하세요.", "lee.sunbae@lgepartner.com", 0, 16)
        End If


    End Sub
    Private Sub AddMod(sender As Object, e As EventArgs) Handles btnAddMod.Click
        Dim inbox As Qportals.Level.AddPjtInfo = New Qportals.Level.AddPjtInfo
        Dim msg As List(Of String) = New List(Of String)

        If (ListBox1.SelectedItems.Count > 0) And (ListBox2.SelectedItems.Count > 0) Then
            msg.Add(String.Format(
            "모델을 아래와 같이 작성하세요. 
             예시) LM-G820N_LGT, LM-G820UM_VZW ..
             (대문자_모델명_서픽스)"))
            msg.Add("모델 입력")
            msg.Add("LM-G820N_LGT")

            Dim rec As Rectangle = New Rectangle
            rec = Me.RectangleToScreen(Me.ClientRectangle)
            inbox._r = rec

            Dim lst As List(Of ListBox) = New List(Of ListBox)
            lst.AddRange(New ListBox() {ListBox4})
            inbox.PjtInfo(msg.ToArray, ListBox3, lst)
        Else
            Qportals.Debugging.Show("먼저 프로젝트와 그룹을 선택하세요.", "lee.sunbae@lgepartner.com", 0, 16)
        End If

    End Sub
    Private Sub AddStep(sender As Object, e As EventArgs) Handles btn_AddStep.Click
        Dim inbox As Qportals.Level.AddPjtInfo = New Qportals.Level.AddPjtInfo
        Dim msg As List(Of String) = New List(Of String)

        If (ListBox1.SelectedItems.Count > 0) And (ListBox2.SelectedItems.Count > 0) And
            (ListBox3.SelectedItems.Count > 0) Then
            msg.Add(String.Format(
            "차수를 아래와 같이 작성하세요. 
             예시) OT01, VP01, QP01, MR01 .."))
            msg.Add("차수 입력")
            msg.Add("VP01")

            Dim rec As Rectangle = New Rectangle
            rec = Me.RectangleToScreen(Me.ClientRectangle)
            inbox._r = rec


            inbox.PjtInfo(msg.ToArray, ListBox4)
        Else
            Qportals.Debugging.Show("먼저 프로젝트와 그룹, 모델을 선택하세요.", "lee.sunbae@lgepartner.com", 0, 16)
        End If
    End Sub
#End Region
#End Region



End Class

