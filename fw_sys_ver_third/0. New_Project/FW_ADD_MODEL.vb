
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class FW_ADD_MODEL
    Public Mysql As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class()
    Public Sub New()
        InitializeComponent()

        ' 1. Select * From aaa Where dddd=ddd and ccc=ccc
        ' 2. listbox에 뿌림.
        ' 3. class에 함수 만들어서 연결 
        ' 4. 테스트 
        GetProject()
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

    Private Property _dt As DataTable
    Private Sub GetProject()
        Dim sql As String = Nothing


        Dim lsts() As ListBox = New ListBox() {ListBox1, ListBox2, ListBox3, ListBox4}
        For Each lb As ListBox In lsts
            lb.Items.Clear()
        Next

        sql = "SELECT * FROM td_defect.project WHERE `GroupName` IS NOT NULL AND Model IS NOT NULL AND step IS NOT NULL ORDER BY Project,`GroupName`,Model, 
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

        _dt = Mysql.Mysql_to_datatable(sql)
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

        'lsb.ClickNextItem_One_Depth(ListBox1, ListBox2, _dt, 1)
        lsb.ClickItems(New Windows.Forms.ListBox() {ListBox1, ListBox2}, _dt)

    End Sub

    Private Sub Click_NextItem_Num2(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        lsb.ClickItems(New Windows.Forms.ListBox() {ListBox1, ListBox2, ListBox3}, _dt)

    End Sub
    Private Sub Click_NextItem_Num3(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        lsb.ClickItems(New Windows.Forms.ListBox() {ListBox1, ListBox2, ListBox3, ListBox4}, _dt)

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
                '// 20191224 수정 함 (Major급)
                sql = String.Format("insert into td_defect.`Project` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `랭킹`) 
                                    Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', (SELECT MAX(랭킹)+1 FROM td_defect.`Project` a WHERE Project = '{0}' AND GroupName = '{1}' AND Model = '{2}')) on Duplicate key update StartDate='{4}', EndDate = '{5}' ",
                lst(0).SelectedItem.ToString,
                lst(1).SelectedItem.ToString,
                lst(2).SelectedItem.ToString,
                lst(3).SelectedItem.ToString,
                StartDate.Value.ToString("yyyy-MM-dd 08:00:00"),
                EndDate.Value.ToString("yyyy-MM-dd 20:00:00"))
            Else

                sql = String.Format("insert into td_defect.`Project` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `랭킹`) 
                                    Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}) on Duplicate key update StartDate='{4}', EndDate = '{5}' ",
                lst(0).SelectedItem.ToString,
                lst(1).SelectedItem.ToString,
                lst(2).SelectedItem.ToString,
                lst(3).SelectedItem.ToString,
                StartDate.Value.ToString("yyyy-MM-dd 08:00:00"),
                EndDate.Value.ToString("yyyy-MM-dd 20:00:00"),
                1)


            End If



            Dim errCheck As Boolean = Mysql.Query_to_Mysql(Sql)

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
            GetProject()

            Qportals.Debugging.Show("정상적으로 모델이 등록되었습니다." & vbCrLf & "이제 프레임워크를 등록해주세요.")

        Else

        End If

        Me.Close()



    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        ' 만약 tc_result에 할당 된 Model이 있으면 지워지지 않도록 
        Dim lst() As ListBox = New ListBox() {ListBox1, ListBox2, ListBox3, ListBox4}
        Dim strNames As List(Of String) = New List(Of String)

        For Each lb As ListBox In lst
            If lb.SelectedItems.Count = 0 Then
                Select Case lb.Name
                    Case "ListBox2"
                        strNames.Add("그룹(ex내수)")
                    Case "ListBox3"
                        strNames.Add("모델")
                    Case "ListBox4"
                        strNames.Add("차수(step)")
                End Select

            End If
        Next

        Dim strCommnet As String = Nothing
        If strNames.Count > 0 Then
            For Each x As String In strNames
                strCommnet += x & ", "
            Next
            strCommnet = Trim(strCommnet)
            strCommnet = strCommnet.Substring(0, Len(strCommnet) - 1)
            Qportals.Debugging.Show(strCommnet & "를 모두 선택 후 삭제 해주세요.", "lee.sunbae@lgepartner.com", 0, 16)
            Exit Sub
        End If


        Dim sql As String = Nothing
        sql = String.Format("select count(*) from td_defect.`result_testcase` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}'",
                            ListBox1.SelectedItem.ToString, ListBox2.SelectedItem.ToString, ListBox3.SelectedItem.ToString, ListBox4.SelectedItem.ToString)

        ' 결과가 없다면~?! 
        If (Mysql.GetQueryResult(sql) = "0") Then

            If (MessageBox.Show("삭제할 수 있습니다. 정말 삭제 하시겠습니까?", "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                '지우자 !!
                sql = String.Format("delete from td_defect.`project` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}'",
                                ListBox1.SelectedItem.ToString, ListBox2.SelectedItem.ToString, ListBox3.SelectedItem.ToString, ListBox4.SelectedItem.ToString)
                Mysql.Query_to_Mysql(sql)
                GetProject() ' refresh
            Else
                Qportals.Debugging.Show("삭제할 없는 프로젝트 입니다.", "lee.sunbae@lgepartner.com", 0, 16)

            End If


        End If





    End Sub
End Class