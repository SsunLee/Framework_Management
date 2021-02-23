Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Threading
Imports System.Windows.Forms
Imports WinControls.ListView
Imports WinControls.ListView.Collections
Imports WinControls.ListView.EventArgClasses

Public Class uc_r_plan
    Public Shared uc_plan As uc_r_plan
    '//
    Private trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker
    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class


    Public _pjt As String
    Public _grp As String
    Public _mod As String
    Public _step As String
    Public _user As String
    Public _company As String

    Private temp_dt As DataTable = New DataTable

    '// 멤버 변수
    Private _txtChg As TextBox
    Private _tDes As TextBox
    Private _tWrite As TextBox
    Private _trlv As TreeListView

    Private _dgv As DataGridView

    '// App List 를 담아둔 공용 db
    Private _Apps_dt As DataTable = New DataTable
    Private _cbitemLists As ComboBox




    Public Sub New()

        InitializeComponent()
        uc_plan = Me
        txtApp.Text = "APP 선택"
        txttype.Text = "유형 선택"
        txttype2.Text = "새부내용 선택"

        Dim tmpTxts() As TextBox = New TextBox() {txtApp, txttype, txttype2}
        For Each t As TextBox In tmpTxts
            t.ForeColor = Color.Red
        Next

        '// Control Set 
        _trlv = TreeListView1           '// 앱 선택 TreeListView
        _dgv = DataGridView1            '// Data 추가 할 DataGridView
        _tDes = txtWriteResult          '// 
        _tWrite = txtWriteResult        '// 내용 입력하는 TextBox
        _cbitemLists = cbItemList

        trvListMaker._trv = TreeListView1

        __TrvSet__()        '// 트리뷰 컬럼 추가.
        __TreeViewData__()  '// 트리뷰 실제 데이터 넣기 
        __Set_textbox__(False)   '// 검증 내용 비활성화
        '_dgv_style_random() '// datagridview의 column style을 맞춰 준다.

        datagridview_setttings()
        '// 처음 trv control을 막아준다.
        TreeListView1.Enabled = False

        '// 처음 Load 될 때 할당 된 project 정보를 보여준다.
        load_modelinfo()


    End Sub
    Private Sub __Set_textbox__(ByRef bool As Boolean)
        '// 검증 내용 비활성화
        _tDes.Enabled = bool
        _tDes.Font = New Font("맑은 고딕", 8)
    End Sub

#Region "Combobox - 프로젝트 정보 채우기"

    Private Sub SelectChange_Combobx(sender As Object, e As EventArgs) Handles cbItemList.SelectedIndexChanged
        SplitModel() '// 콤보박스에 refresh data를 쿼리하여  combobox에 넣어준다. 
    End Sub

    Private Sub ProjectInfo_load(sender As Object, e As EventArgs) Handles pic_Refresh.Click
        load_modelinfo()
    End Sub

    ''' <summary>
    ''' Random Test를 할당 받은 경우 콤보박스에 Data 넣음
    ''' td_defect.assign_testcase DB에서 가져옴.
    ''' </summary>
    Private Sub load_modelinfo()
        ' * 할당 내역이 있는지 조회 해서 콤보박스에 뿌려줍니다.
        Dim sql As String, dt_temp As DataTable = New DataTable
        Dim var As String
        sql = "SELECT DISTINCT Project, GroupName, Model, Step FROM td_defect.`assign_testcase` "
        sql += If(CheckBox1.Checked = False, " where ", " where DATE_FORMAT(insert_date, ""%Y-%m-%d"") = CURDATE() and")
        sql += String.Format(" Tester = '{0}' ", Main_index.f._user)
        dt_temp = dbc.Mysql_to_datatable(sql)

        Dim remove_duplicate_dt As DataTable = New DataTable
        '// 오늘날짜 Date Query가 들어가므로 중복제거가 풀리는 현상 발생
        '// 원본 테이블을 복사해서 중복을 제거하고 combobox에 
        remove_duplicate_dt = dt_temp.Copy
        remove_duplicate_dt.DefaultView.ToTable(True, "Project", "GroupName", "Model", "Step")

        If Not (remove_duplicate_dt Is Nothing) AndAlso (remove_duplicate_dt.Rows.Count > 0) Then
            _cbitemLists.Items.Clear()
            For Each dr As DataRow In remove_duplicate_dt.Rows
                var = String.Format("{0},{1},{2},{3}",
                dr.Item(0).ToString, dr.Item(1).ToString,
                dr.Item(2).ToString, dr.Item(3).ToString)
                _cbitemLists.Items.Add(var)
            Next
            _cbitemLists.Text = "여기를 눌러 할당 된 모델을 선택하세요."

        Else
            _cbitemLists.Text = "할당 된 모델이 없습니다."
        End If

    End Sub

    ''' <summary>
    ''' 이 함수는 프로젝트 콤보박스를 선택 시
    ''' 프로젝트 및 모델을 나누어 각 각의 TextBox에 넣어줍니다.
    ''' </summary>
    Private Sub SplitModel()
        Dim sPjt As String = Nothing, sGrp As String = Nothing, sMod As String = Nothing, sStep As String = Nothing
        If Not (_cbitemLists.Text.ToString.Contains("여기를 눌러")) And Not (_cbitemLists.Text = "") And Not (_cbitemLists.Text.ToString.Contains("할당 된 모델이")) Then
            ' 프로젝트 / 그룹 / 모델 / 차수 
            For i As Integer = 0 To Split(_cbitemLists.Text, ",").Length
                Select Case i
                    Case 0
                        sPjt = Split(_cbitemLists.Text, ",")(i) : sPjt = LTrim(sPjt)
                    Case 1
                        sGrp = Split(_cbitemLists.Text, ",")(i) : sGrp = LTrim(sGrp)
                    Case 2
                        sMod = Split(_cbitemLists.Text, ",")(i) : sMod = LTrim(sMod)
                    Case 3
                        sStep = Split(_cbitemLists.Text, ",")(i) : sStep = LTrim(sStep)
                End Select
            Next
            txtProin.Text = sPjt
            txtGroupin.Text = sGrp
            txtModelin.Text = sMod
            txtStepin.Text = sStep

            TreeListView1.Enabled = True



        End If
    End Sub
#End Region

#Region "TreeListView"
    Private Sub __TrvSet__()

        _trlv = TreeListView1

        _trlv.Columns.Add("Apps", 300, Windows.Forms.HorizontalAlignment.Center)

        With _trlv
            .MultiSelect = False
            .FullRowSelect = True
            .Columns.Item(0).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
        End With

        Enable_Checkbox_TreeListView()

    End Sub


    ''' <summary>
    '''  Apps 랜덤 자가체크 불러오는 것 
    ''' </summary>
    Private Sub __TreeViewData__()
        '// TreeListView에 App Name 채워주기
        'im sql As String = "select `Apptype`, `TCtype`, `AppName` from td_defect.`td_ota_app` order by `AppName`"
        'Dim sql As String = "SELECT DISTINCT ID, `TE_Function`, `QM_Function`, `Depth2`, `Depth2_des`, `Depth2_expect` FROM td_defect.`add_random`"
        Dim sql As String = "SELECT `TE_Function` AS depth1, `QM_Function` AS depth2, `Depth2` AS depth3, Depth2_des AS `Description` 
                             FROM td_defect.`add_random`
                             WHERE NOT QM_Function IS NULL AND NOT Depth2 IS NULL "
        Dim dt As DataTable = New DataTable

        dt = dbc.Mysql_to_datatable(sql)

        If Not (dt Is Nothing) Then
            '// TreeListView를 0, 1, 2 Column에 생성해줌
            trv._trv = _trlv
            trv.BuildTree(dt, New Integer() {0, 1, 2})

            '// 메인 전역 Property 변수에 AppName들을 담아줍니다.
            _Apps_dt = dt


        End If

    End Sub

    Private Sub Enable_Checkbox_TreeListView()
        '// TreeList 에서 체크박스 한 번 클릭했을 때 동작하도록
        _trlv.CheckBoxes = True
        _trlv.CheckBoxSelection = ItemActivation.OneClick
    End Sub

    Private trvListMaker As New Qportals.Controls.TreeListViewMaker


    ''' <summary>
    '''  TreeListView 아이템 선택 시 Description 보여지는 기능 구현
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub selectTreeItem(sender As Object, e As EventArgs) Handles TreeListView1.Click
        Dim strFullPath As String
        Dim strNodes() As String
        If (TreeListView1.SelectedItems.Count > 0) Then

            If Not (TreeListView1.SelectedItems.Item(0) Is Nothing) Then
                strFullPath = TryCast(TreeListView1.SelectedItems(0), TreeListNode).FullPath
                strNodes = strFullPath.Split("\")

                If strNodes.Length = 3 Then
                    Dim cnt As Integer = strNodes.Where(Function(x) x = "").Count

                    If cnt > 0 Then
                        Exit Sub
                    End If

                    Dim query2 = _Apps_dt.AsEnumerable().Where(Function(x) x("depth1").ToString = strNodes(0).ToString And x("depth2").ToString = strNodes(1).ToString And x("depth3").ToString = strNodes(2).ToString).CopyToDataTable

                    If (query2.Rows.Count > 0) Then
                        txtDes.Text = query2.Rows(0)("Description").ToString
                    End If

                End If
            End If

        End If

    End Sub


#End Region

#Region "미사용 묶음 - TreeListView 관련 코드"
    '// TreeListView Cancel Event 로 e 이벤트 받음

    Private Sub TreeListView2_AfterCheckStateChanged(sender As Object, e As ContainerListViewEventArgs) ' Handles TreeListView1.AfterCheckStateChanged
        '// 예외 처리 모든 항목이 입력 되어야만 함.
        Dim txtBoxs As List(Of Control) = New List(Of Control) From {txtProin, txtGroupin, txtModelin, txtStepin}
        Dim cnt As Integer = txtBoxs.Where(Function(x) x.Text = "").Count
        If (cnt > 0) Then
            Qportals.Debugging.Show("필수 정보가 모두 입력되지 않았습니다.")
            Exit Sub
        End If

        'temp_dt = New DataTable
        'Dim _columns() As String = New String() {"Columns1", "Columns2", "Columns3"} '// 임시 데이터 담을 컬럼 추가
        'For Each s As String In _columns    '// 컬럼 반영
        '    temp_dt.Columns.Add(s)
        'Next
        RemoveHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView2_AfterCheckStateChanged


        Dim node As TreeListNode = e.Item
        trvListMaker.CheckBoxAll(node, node.Checked)


        If e.Item.Checked = False Then
            '// 체크 해제 했을 때
            'RemoveHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView2_AfterCheckStateChanged
            'returnLists(node)

            'Dim tempdt As DataTable = GetTrvTable()
            'Del_returnList(tempdt)
            'AddHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView2_AfterCheckStateChanged

        Else
            '// 체크 했을 때
            'RemoveHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView2_AfterCheckStateChanged
            'returnLists(node)
            'Dim tempdt As DataTable = GetTrvTable()
            'Add_returnList(tempdt)
            'AddHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView2_AfterCheckStateChanged



        End If
        AddHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView2_AfterCheckStateChanged

        TreeListView1.Refresh()

    End Sub

    Private Sub UnCheck_Trv_CancelEvent(sender As Object, e As ContainerListViewCancelEventArgs) ' Handles TreeListView1.BeforeCheckStateChanged



        RemoveHandler TreeListView1.BeforeCheckStateChanged, AddressOf UnCheck_Trv_CancelEvent
        '// 예외 처리 모든 항목이 입력 되어야만 함.
        Dim txtBoxs As List(Of Control) = New List(Of Control) From {txtProin, txtGroupin, txtModelin, txtStepin}
        Dim cnt As Integer = txtBoxs.Where(Function(x) x.Text = "").Count
        If (cnt > 0) Then
            Qportals.Debugging.Show("필수 정보가 모두 입력되지 않았습니다.")
            Exit Sub
        End If

        Dim node As TreeListNode = e.Item
        trvListMaker.CheckBoxAll(node, node.Checked)
        TreeListView1.Refresh()


        If e.Item.Checked = True Then
            '// 체크 해제 했을 때
            Dim tempdt As DataTable = GetTrvTable(True)

            Del_returnList(tempdt)

        Else
            Dim tempdt As DataTable = GetTrvTable(False)
            Add_returnList(tempdt)

        End If
        AddHandler TreeListView1.BeforeCheckStateChanged, AddressOf UnCheck_Trv_CancelEvent
        ' 
    End Sub

    Private Property Lists As List(Of List(Of String))

    Public drows As List(Of List(Of String)) = New List(Of List(Of String))
    Private Sub TreeViewToTable2(nodes As TreeListNodeCollection)
        Dim drow As List(Of String) = New List(Of String)
        Dim temp() As String : Dim temps() As String

        '// 재귀 함수
        For Each node As TreeListNode In nodes
            If (node.Checked = True) And Not (node.ParentNode Is Nothing) And (node.Level = 2) Then
                'If Not (node.ParentNode Is Nothing) And (node.Level = 1) Then

                If node.Checked = True Then
                    Dim fullpath As String = node.FullPath
                    Dim strNodes() As String = fullpath.Split("\")

                    With drow
                        .Add(strNodes(0))   ' LG
                        .Add(strNodes(1))   ' App Name
                    End With

                End If
                drows.Add(drow)
                drow = New List(Of String)

            End If

            TreeViewToTable2(node.Nodes)
        Next
    End Sub

    Private Sub TreeViewToTable(nodes As TreeListNodeCollection)
        Dim uniqID = System.Guid.NewGuid().ToString()

        '// 재귀 함수
        For Each node As TreeListNode In nodes
            If node.Level = 2 Then
                If node.Checked = True Then
                    Dim fullpath As String = node.FullPath
                    Dim strNodes() As String = fullpath.Split("\")
                    temp_dt.Rows.Add(strNodes(0), strNodes(1), strNodes(2))  '// 기존 1, 2 -> 0, 1
                End If
            End If
            TreeViewToTable(node.Nodes)
        Next
    End Sub

#Region "TreeListView - DataGridView "
    '// getDatatable
    Private Function GetTrvTable(ByRef RemoveFlags As Boolean) As DataTable

        Dim temp As DataTable = New DataTable
        Dim drows As List(Of List(Of String)) = New List(Of List(Of String))
        Dim i As Integer = 0

        TrvToList(drows, TreeListView1.Nodes, RemoveFlags)

        For i = 1 To 3
            temp.Columns.Add("Columns" & i)
        Next

        If drows.Count > 0 Then
            For Each rr In drows
                Dim rows As DataRow = temp.NewRow()
                rows("Columns1") = rr(0)
                rows("Columns2") = rr(1)
                rows("Columns3") = rr(2)
                temp.Rows.Add(rows)
            Next
        End If

        Return temp
    End Function
    Private Sub TrvToList(ByRef drows As List(Of List(Of String)), Nodes As TreeListNodeCollection, ByRef RemoveFlags As Boolean)
        Dim drow As List(Of String) = New List(Of String)
        Dim temp() As String : Dim temps() As String

        '// 재귀 함수
        For Each node As TreeListNode In Nodes
            'Debug.Print(node.Text)
            If RemoveFlags = True Then

                If (node.Checked = False) And (node.Level = 2) Then
                    'Debug.Print(node.Text)

                    Dim fullpath As String = node.FullPath
                    Dim strValues() As String = fullpath.Split("\")

                    If strValues.Length > 0 Then
                        For i As Integer = 0 To strValues.Length - 1
                            drow.Add(strValues(i).ToString)
                        Next
                    End If

                    drows.Add(drow)
                    drow = New List(Of String)

                End If

            Else

                If (node.Checked = True) And (node.Level = 2) Then
                    Dim fullpath As String = node.FullPath
                    Dim strValues() As String = fullpath.Split("\")
                    If strValues.Length > 0 Then
                        For i As Integer = 0 To strValues.Length - 1
                            drow.Add(strValues(i).ToString)
                        Next
                    End If

                    drows.Add(drow)
                    drow = New List(Of String)

                End If

            End If

            TrvToList(drows, node.Nodes, RemoveFlags)
        Next
    End Sub

    Private Sub Add_returnList(ByRef temp As DataTable)
        Dim main_table As DataTable = TryCast(_dgv.DataSource, DataTable)

        For Each dr As DataRow In temp.Rows
            '// TreeView 전환 한 DataTable

            '// TreeListView에서 Check 한 항목의 설명을 dgv에 보여주는 부분
            Dim query2 = _Apps_dt.AsEnumerable().Where(Function(x) x("depth1") = dr(0).ToString And x("depth2") = dr(1).ToString And x("depth3") = dr(2).ToString).CopyToDataTable
            If (query2.Rows.Count > 0) Then
                txtDes.Text = query2.Rows(0)("Description").ToString
            End If

            '// 상단 앱 정보 넣기
            txtApp.Text = dr(0).ToString
            txttype.Text = dr(1).ToString
            txttype2.Text = dr(2).ToString

            Dim dt As DataTable = temp   '// TreeList의 데이터

            '//temp_dt : 트리뷰
            '//main_table : 데이터그리드뷰
            Dim query = dt.AsEnumerable.Where(
                        Function(dt1) Not main_table.AsEnumerable.Any(
                            Function(dt2) _
                                dt1("Columns1") = dt2("Apps") AndAlso
                                dt1("Columns2") = dt2("type") AndAlso
                                dt1("Columns3") = dt2("Detailed_type")))
            For Each r In query
                Dim rows As DataRow = main_table.NewRow
                rows("Project") = _pjt
                rows("GroupName") = _grp
                rows("Model") = _mod
                rows("Step") = _step
                rows("Apps") = r(0)
                rows("type") = r(1)
                rows("Detailed_type") = r(2)
                main_table.Rows.Add(rows)
            Next

        Next

    End Sub

    Private Sub Del_returnList(ByRef temp As DataTable)
        Dim dgvdt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        Dim str1 As String, str2 As String

        For Each li As DataRow In temp.Rows
            str1 = ""
            For i As Integer = 0 To temp.Columns.Count - 1
                str1 += li(i)
            Next


            For j As Integer = dgvdt.Rows.Count - 1 To 0 Step -1

                str2 = ""
                'For i As Integer = 0 To li.Count - 1
                For i As Integer = 5 To 7
                    str2 += dgvdt.Rows(j)(i).ToString()
                Next
                Debug.Print("TreeListView : " & str1)
                Debug.Print("DataGridView : " & str2)
                If (str1 = str2) Then
                    dgvdt.Rows(j).Delete()
                    dgvdt.AcceptChanges()
                    Exit For
                End If
                str2 = ""
            Next
            str2 = ""
        Next

    End Sub

    Private Sub trvCheck_trvUnCheck(sender As Object, e As ContainerListViewEventArgs) 'Handles TreeListView1.AfterCheckStateChanged

        If e.Item.Checked = True Then
            '// 체크 해제 했을 때
            trvCheck(e.Item)
        Else

        End If


    End Sub

    Private Sub trvCheck(node As TreeListNode)
        '// DataGridView -> DataTable   
        Dim dgvTable As DataTable = TryCast(_dgv.DataSource, DataTable)

        '// 반드시 Selected 
        If Not node Is Nothing Then

            If node.Level = 2 Then

                Dim fullpath As String = node.FullPath
                Dim strNodes() As String = fullpath.Split("\")

                Dim query = dgvTable.AsEnumerable().Where(
                            Function(dt1) _
                                dt1.Field(Of String)("Detailed_type") = strNodes(0))

                If (query Is Nothing) Then




                End If







            End If

        End If



    End Sub

#End Region

#End Region

#Region "DataGridView - 처리"
    Private Sub _dgv_style_random()

        '// DataGridView 기본 설정
        Dim dgvDouble As Qportals.DataGridViewDoubleBuffer = New Qportals.DataGridViewDoubleBuffer(_dgv)
        dgvDouble.EnableDoubleBuffered()

        If _dgv.Columns.Count = 0 Then
            '// DataTable Columns 
            Dim strColumns() As String = {"ID", "Project", "GroupName", "Model", "Step", "Apps", "type", "Detailed_type", "검증내역", "검증결과", "Domain", "Defect"}
            Dim _initdt As DataTable = New DataTable

            '** Column을 만듭니다.---------------------
            For Each c As String In strColumns
                _initdt.Columns.Add(New DataColumn(c))
            Next

            _dgv.DataSource = _initdt

        End If

        '// DataGridView 헤더 컬럼 색상
        _dgv.Columns(0).Visible = False '// ID 컬럼 숨김
        _dgv.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True   '// 줄넘김
        '_dgv.RowHeadersVisible = False  '// DataGridView 맨 왼쪽 헤더 지우기

        _dgv.DefaultCellStyle.SelectionBackColor = Color.White  ' 선택 했을 때 back color
        _dgv.DefaultCellStyle.SelectionForeColor = Color.Black   ' 선택 했을 때 글씨 color
        _dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255) ' 열의 색상 지정

        '----------DataGridView--Font------------
        _dgv.DefaultCellStyle.Font = New Font("맑은 고딕", 8)
        _dgv.ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 8)


        For i As Integer = 0 To _dgv.ColumnCount - 1
            _dgv.Columns(i).HeaderCell.Style.BackColor = Color.White
            _dgv.Columns(i).HeaderCell.Style.ForeColor = Color.DarkGray
            _dgv.Columns(i).HeaderCell.Style.Font = New Font("맑은 고딕", 8, FontStyle.Bold)
            _dgv.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            If i = 1 Then
                _dgv.Columns(i).Width = 131
            ElseIf i = 2 Then
                _dgv.Columns(i).Width = 131
            ElseIf i = 3 Then
                _dgv.Columns(i).Width = 131
            Else
                _dgv.Columns(i).Width = 131
            End If

        Next

    End Sub
    'Private Sub PanelClickEvent(sender As Object, e As EventArgs)
    '    _tDes.Enabled = False : _txtChg.Enabled = False
    'End Sub
    'Private Sub LeaveFocusText_des(sender As Object, e As EventArgs) Handles txtWriteResult.LostFocus, txtDes.LostFocus
    '    _tDes.Enabled = False
    'End Sub
    'Private Sub LeaveFocusText_chg(sender As Object, e As EventArgs)
    '    _txtChg.Enabled = False
    'End Sub

    Private Sub DataGridSelectCell(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        '// DataGrid의 마지막 셀 선택하면 디펙 입력 부분 살려주는 부분

        dgv2_clicks(e)


    End Sub
    Private Sub dgv2_clicks(e As DataGridViewCellEventArgs)
        '// dgv를 클릭하면 입력 상자를 활성화 하는 부분

        If Not _dgv.SelectedRows Is Nothing Then
            'Dim result As String = If(_dgv.Rows(_dgv.CurrentCell.RowIndex).Cells("검증내역").Value Is Nothing, "", _dgv.Rows(_dgv.CurrentCell.RowIndex).Cells("검증내역").Value.ToString())
            _dgv.Rows(_dgv.CurrentCell.RowIndex).Cells("검증내역").Value = txtWriteResult.Text
        End If

    End Sub

    Private Sub textboxTodgv_Des(sender As Object, e As KeyEventArgs) Handles txtWriteResult.KeyDown ', txtDes.KeyDown
        '// 텍스트 박스에서 입력 시 바로 입력 되도록
        '// 중점 검증 내용 작성 
        '_dgv.Rows(_dgv.CurrentCell.RowIndex).Cells("검증내역").Value = _tDes.Text
        textbox_To_dgv_test()
        'GET_Checked(TreeListView1.Nodes)
    End Sub
    ''' <summary>
    ''' TextBox에서 데이터 입력 시 하단 DataGridView에 같은 항목에 같은 내용 입력 됨.
    ''' </summary>`     
    Private Sub textbox_To_dgv_test()

        If TreeListView1.SelectedItems.Count > 0 Then

            Dim node As TreeListNode = TryCast(TreeListView1.SelectedItems.Item(0), TreeListNode)

            If node.Level = 1 Then '// 알람/시계 라면

                For Each n As TreeListNode In node.Nodes

                    If n.FullPath.Split("\").Length = 3 Then
                        Dim strNodes() As String = n.FullPath.Split("\")

                        For Each d As DataGridViewRow In DataGridView1.Rows
                            Dim dApps As String = If(d.Cells("Apps").Value Is Nothing, "", d.Cells("Apps").Value.ToString)
                            Dim dtype As String = If(d.Cells("type").Value Is Nothing, "", d.Cells("type").Value.ToString)
                            Dim ddetype As String = If(d.Cells("Detailed_type").Value Is Nothing, "", d.Cells("Detailed_type").Value.ToString)

                            If strNodes(0) = dApps AndAlso strNodes(1) = dtype AndAlso strNodes(2) = ddetype Then
                                d.Cells("검증내역").Value = txtWriteResult.Text
                                Exit For
                            End If

                        Next

                    End If

                Next
            Else

                _dgv.Rows(_dgv.CurrentCell.RowIndex).Cells("검증내역").Value = _tDes.Text

            End If




        End If

    End Sub
    Public Sub GET_Checked(nodes As TreeListNodeCollection)
        For Each node As TreeListNode In nodes

            If (node.Nodes.Count > 0) Then

                If node.Level = 1 Then

                    If node.Checked Then

                        Debug.Print(node.Text)

                    End If

                End If

            End If
            GET_Checked(node.Nodes)
        Next
    End Sub

#End Region


    Private Sub Click_TreeListView(sender As Object, e As EventArgs) Handles TreeListView1.Click

        If TreeListView1.SelectedItems.Count > 0 Then
            Dim node As TreeListNode = TryCast(TreeListView1.SelectedItems.Item(0), TreeListNode)

            If node.FullPath.Split("\").Length = 3 Then

                Dim strNodes() As String = node.FullPath.Split("\")

                For Each d As DataGridViewRow In DataGridView1.Rows
                    Dim dApps As String = If(d.Cells("Apps").Value Is Nothing, "", d.Cells("Apps").Value.ToString)
                    Dim dtype As String = If(d.Cells("type").Value Is Nothing, "", d.Cells("type").Value.ToString)
                    Dim ddetype As String = If(d.Cells("Detailed_type").Value Is Nothing, "", d.Cells("Detailed_type").Value.ToString)


                    If strNodes(0) = dApps AndAlso strNodes(1) = dtype AndAlso strNodes(2) = ddetype Then
                        'd.Cells("검증내역").Value = txtWriteResult.Text
                        Dim cellQty As DataGridViewCell = d.Cells("검증내역")
                        _dgv.CurrentCell = cellQty
                        _dgv.CurrentRow.Cells(1).Selected = True
                        _dgv.BeginEdit(True)
                        txtWriteResult.Enabled = True
                        txtWriteResult.Text = cellQty.Value
                        Exit For
                    End If

                Next

            End If


        End If





    End Sub


#Region "DB - Upload"

    Private Sub btn_add_click(sender As Object, e As EventArgs) Handles btn_add.Click


        db_Upload()

    End Sub
    Private Sub db_Upload()
        '// DataGridView에 본인 Random 기획 올라가도록 하는 코드
        '// ID(int), Apps(varchar), 중점내용(long text), Result(longtext)
        '// table : td_defect.`individual_random`
        Dim chkErr As Boolean = False               '// DB Update 시 오류 판단할 변수

        Dim insert_count As Integer = 0 '// Insert 되는 항목 갯수를 세기 위한 변수




        Dim spjt As String, sgrp As String, smod As String, sstep As String
        Dim strApps As String, strtype As String, strdtype As String, strwrite As String, strresult As String
        Dim strDomain As String, strDefect As String
        Dim user As String, company As String

        'Dim ins_sql As String = "insert into td_defect.`individual_random`" &
        '   "(Project, GroupName, Model, Step, Apps, `type`, `Detailed_type`, `rd_plan_write`, `rd_plan_result`, `Domain`, `Defect`, `Tester`, `Company`) Values"
        '//     0        1         2     3     4       5         6                7                 8              9         10        11         12                   
        Dim ins_sum_sql As String = ""  '// insert 하기 위해 생성한 변수 

        spjt = txtProin.Text : sgrp = txtGroupin.Text : smod = txtModelin.Text : sstep = txtStepin.Text
        user = Main_index.f._user : company = Main_index.f._company

        Dim ins_sql As String = "insert into td_defect.`individual_random`" &
           "(Project, GroupName, Model, Step, Apps, `type`, `Detailed_type`, `rd_plan_write`, `Tester`, `Company`) Values"
        '//     0        1         2     3     4       5         6                7              8          9       


        For Each dr As DataGridViewRow In _dgv.Rows

            strApps = If(dr.Cells("Apps").Value Is Nothing, "", dr.Cells("Apps").Value.ToString)
            strtype = If(dr.Cells("type").Value Is Nothing, "", dr.Cells("type").Value.ToString)
            strdtype = If(dr.Cells("Detailed_type").Value Is Nothing, "", dr.Cells("Detailed_type").Value.ToString)
            strwrite = If(dr.Cells("검증내역").Value Is Nothing, "", dr.Cells("검증내역").Value)

            strApps = rm_quarter(strApps) : strtype = rm_quarter(strtype)
            strdtype = rm_quarter(strdtype) : strwrite = rm_quarter(strwrite)

            ins_sum_sql += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'),",
                       spjt, sgrp, smod, sstep, strApps, strtype, strdtype, strwrite, user, company)
            insert_count += 1

        Next

        ins_sum_sql = ins_sum_sql.Substring(0, Len(ins_sum_sql) - 1)    '// 마지막 콤마(,) 제거
        ins_sql += ins_sum_sql  '// 쿼리 합침


        chkErr = dbc.Query_to_Mysql(ins_sql)

        If (chkErr = True) Then
            Qportals.Debugging.Show("정상적으로 추가되었습니다." & vbCrLf & insert_count & "건")
        Else
            Qportals.Debugging.Show("올바르게 올라가지 않았을 수 있습니다.")

        End If



    End Sub
    Private Function rm_quarter(ByRef strText As String)
        strText = Replace(strText, "'", "")
        Return strText
    End Function
#End Region


    Public Shared Selected_Data(22) As String


#Region "DataGridView - 막 욱여 넣기 방식"

    Private Sub datagridview_setttings()

        '// DataGridView 기본 설정
        Dim dgvDouble As Qportals.DataGridViewDoubleBuffer = New Qportals.DataGridViewDoubleBuffer(_dgv)
        dgvDouble.EnableDoubleBuffered()


        Dim strcolumns = {"Project", "GroupName", "Model", "Step", "Apps", "type", "Detailed_type", "검증내역", "검증결과", "Domain", "Defect"}
        'Dim counter As Byte = 0
        For Each a As String In strcolumns
            _dgv.Columns.Add(a, a)

        Next


        '// DataGridView 헤더 컬럼 색상
        '_dgv.Columns(0).Visible = False '// ID 컬럼 숨김
        _dgv.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True   '// 줄넘김
        '_dgv.RowHeadersVisible = False  '// DataGridView 맨 왼쪽 헤더 지우기

        _dgv.DefaultCellStyle.SelectionBackColor = Color.White  ' 선택 했을 때 back color
        _dgv.DefaultCellStyle.SelectionForeColor = Color.Black   ' 선택 했을 때 글씨 color
        _dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255) ' 열의 색상 지정

        '----------DataGridView--Font------------
        _dgv.DefaultCellStyle.Font = New Font("맑은 고딕", 8)
        _dgv.ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 8)


        For i As Integer = 0 To _dgv.ColumnCount - 1
            _dgv.Columns(i).HeaderCell.Style.BackColor = Color.White
            _dgv.Columns(i).HeaderCell.Style.ForeColor = Color.DarkGray
            _dgv.Columns(i).HeaderCell.Style.Font = New Font("맑은 고딕", 8, FontStyle.Bold)
            _dgv.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            If i = 1 Then
                _dgv.Columns(i).Width = 131
            ElseIf i = 2 Then
                _dgv.Columns(i).Width = 131
            ElseIf i = 3 Then
                _dgv.Columns(i).Width = 131
            Else
                _dgv.Columns(i).Width = 131
            End If

        Next

    End Sub


#End Region

#Region "[Sub][TreeListView1_AfterCheckStateChanged.Handles]"

    Private Sub TreeListview_Check_Depth2_test(sender As Object, e As ContainerListViewEventArgs) Handles TreeListView1.AfterCheckStateChanged



    End Sub


    '# [AppTree - AfterCheck]
    ''' <summary>
    '''  트리뷰 체크체크체크체크체크체크체크체크체크체크체크체크체크체크체크
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TreeListView1_AfterCheckStateChanged(sender As Object, e As ContainerListViewEventArgs) Handles TreeListView1.AfterCheckStateChanged
        Debug.Print("TreeListView1_AfterCheckStateChanged 동작중")
        RemoveHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView1_AfterCheckStateChanged

        Dim project_3depth_bool As Boolean = False
        e.Item.Selected = True

        For Each node As TreeListNode In TreeListView1.SelectedItems

            Selected_Data(0) = txtProin.Text
            Selected_Data(1) = txtGroupin.Text
            Selected_Data(2) = txtModelin.Text
            Selected_Data(3) = txtStepin.Text

            If node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(node, node.Checked)
            End If

            If node.Checked = False Then
                Debug.Print(Split(node.FullPath, "\").Length)
                If Split(node.FullPath, "\").Length = 4 Then
                    node.ParentNode.Checked = False
                ElseIf Split(node.FullPath, "\").Length = 5 Then
                    node.ParentNode.Checked = False
                    node.ParentNode.ParentNode.Checked = False
                ElseIf Split(node.FullPath, "\").Length = 6 Then
                    node.ParentNode.Checked = False
                    node.ParentNode.ParentNode.Checked = False
                    node.ParentNode.ParentNode.ParentNode.Checked = False
                ElseIf Split(node.FullPath, "\").Length = 7 Then
                    node.ParentNode.Checked = False
                    node.ParentNode.ParentNode.Checked = False
                    node.ParentNode.ParentNode.ParentNode.Checked = False
                    node.ParentNode.ParentNode.ParentNode.ParentNode.Checked = False
                End If
            End If



            If node.Nodes.Count = 0 Then
                If node.Checked = False Then
                    '// 텍스트 박스 및 비활성화 하는 부분
                    __Set_textbox__(False)
                Else
                    '// 텍스트 박스 및 활성화 하는 부분
                    __Set_textbox__(True)
                End If
            Else
                '// 텍스트 박스 및 비활성화 하는 부분
            End If

            If Split(node.FullPath, "\").Length = 3 Then

                Selected_Data(4) = node.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.Text
                Selected_Data(6) = node.Text

                If node.Nodes.Count = 0 Then
                    Selected_Data(7) = Nothing
                    Selected_Data(8) = Nothing
                    Selected_Data(9) = Nothing
                    Selected_Data(10) = Nothing

                    If node.Checked = True Then
                        If exist_dgv() = 0 Then
                            _dgv.Rows.Add(Selected_Data)
                            '// 셀 강제 클릭하도록 
                            Dim last_row As Integer = _dgv.Rows.Count - 1 - 1
                            Dim cellQty As DataGridViewCell = _dgv(5, last_row)
                            _dgv.CurrentCell = cellQty
                            _dgv.CurrentRow.Cells(1).Selected = True
                            _dgv.BeginEdit(True)
                            txtWriteResult.Enabled = True

                        End If
                    Else
                        If Search_dgv() IsNot Nothing Then
                            _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                        End If
                    End If


                Else
                    For Each childNode As TreeListNode In node.Nodes
                        Selected_Data(7) = childNode.Text

                        If childNode.Nodes.Count = 0 Then
                            Selected_Data(8) = Nothing
                            Selected_Data(9) = Nothing
                            Selected_Data(10) = Nothing

                            If node.Checked = True Then
                                If exist_dgv() = 0 Then
                                    _dgv.Rows.Add(Selected_Data)
                                End If
                            Else
                                If Search_dgv() IsNot Nothing Then
                                    _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                End If
                            End If

                        Else
                            For Each childNode2 As TreeListNode In childNode.Nodes
                                Selected_Data(8) = childNode2.Text

                                If childNode2.Nodes.Count = 0 Then
                                    Debug.Print("feature5 = nothing")

                                    Selected_Data(9) = Nothing
                                    Selected_Data(10) = Nothing

                                    If node.Checked = True Then
                                        If exist_dgv() = 0 Then
                                            _dgv.Rows.Add(Selected_Data)
                                        End If
                                    Else
                                        If Search_dgv() IsNot Nothing Then
                                            _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                        End If
                                    End If

                                Else
                                    For Each childNode3 As TreeListNode In childNode2.Nodes
                                        Selected_Data(9) = childNode3.Text
                                        Debug.Print("feature5 = " + Selected_Data(9))

                                        If childNode3.Nodes.Count = 0 Then
                                            Debug.Print("feature6 = nothing")

                                            Selected_Data(10) = Nothing

                                            If node.Checked = True Then
                                                If exist_dgv() = 0 Then
                                                    _dgv.Rows.Add(Selected_Data)
                                                End If
                                            Else
                                                If Search_dgv() IsNot Nothing Then
                                                    _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                                End If
                                            End If
                                        Else

                                            For Each childNode4 As TreeListNode In childNode3.Nodes
                                                Selected_Data(10) = childNode4.Text
                                                Debug.Print("feature7 = " + Selected_Data(10))

                                                If node.Checked = True Then
                                                    If exist_dgv() = 0 Then
                                                        _dgv.Rows.Add(Selected_Data)
                                                    End If
                                                Else
                                                    If Search_dgv() IsNot Nothing Then
                                                        _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                                    End If
                                                End If
                                            Next
                                            Selected_Data(10) = Nothing
                                        End If
                                    Next
                                    Selected_Data(9) = Nothing
                                End If
                            Next
                            Selected_Data(8) = Nothing
                        End If
                    Next
                    Selected_Data(7) = Nothing

                End If

            ElseIf Split(node.FullPath, "\").Length = 4 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.Text
                Selected_Data(7) = node.Text

                If node.Nodes.Count = 0 Then
                    Selected_Data(8) = Nothing
                    Selected_Data(9) = Nothing
                    Selected_Data(10) = Nothing

                    If node.Checked = True Then
                        If exist_dgv() = 0 Then
                            _dgv.Rows.Add(Selected_Data)
                        End If
                    Else
                        If Search_dgv() IsNot Nothing Then
                            _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                        End If
                    End If

                Else
                    For Each childNode As TreeListNode In node.Nodes
                        Selected_Data(8) = childNode.Text

                        If childNode.Nodes.Count = 0 Then
                            Selected_Data(9) = Nothing
                            Selected_Data(10) = Nothing

                            If node.Checked = True Then
                                If exist_dgv() = 0 Then
                                    _dgv.Rows.Add(Selected_Data)
                                End If
                            Else
                                If Search_dgv() IsNot Nothing Then
                                    _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                End If
                            End If

                        Else
                            For Each childNode2 As TreeListNode In childNode.Nodes
                                Selected_Data(9) = childNode2.Text

                                If childNode2.Nodes.Count = 0 Then
                                    Selected_Data(10) = Nothing

                                    If node.Checked = True Then
                                        If exist_dgv() = 0 Then
                                            _dgv.Rows.Add(Selected_Data)
                                        End If
                                    Else
                                        If Search_dgv() IsNot Nothing Then
                                            _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                        End If
                                    End If

                                Else
                                    For Each childNode3 As TreeListNode In childNode2.Nodes
                                        Selected_Data(10) = childNode3.Text

                                        If node.Checked = True Then
                                            If exist_dgv() = 0 Then
                                                _dgv.Rows.Add(Selected_Data)
                                            End If
                                        Else
                                            If Search_dgv() IsNot Nothing Then
                                                _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                            End If
                                        End If
                                    Next
                                    Selected_Data(10) = Nothing
                                End If
                            Next
                            Selected_Data(9) = Nothing
                        End If
                    Next
                    Selected_Data(8) = Nothing

                End If

            ElseIf Split(node.FullPath, "\").Length = 5 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.ParentNode.Text
                Selected_Data(7) = node.ParentNode.Text
                Selected_Data(8) = node.Text

                If node.Nodes.Count = 0 Then
                    Selected_Data(9) = Nothing
                    Selected_Data(10) = Nothing

                    If node.Checked = True Then
                        If exist_dgv() = 0 Then
                            _dgv.Rows.Add(Selected_Data)
                        End If
                    Else
                        Debug.Print(Search_dgv())
                        If Search_dgv() IsNot Nothing Then
                            _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                        End If
                    End If

                Else
                    For Each childNode As TreeListNode In node.Nodes
                        Selected_Data(9) = childNode.Text

                        If childNode.Nodes.Count = 0 Then
                            Selected_Data(10) = Nothing

                            If node.Checked = True Then
                                If exist_dgv() = 0 Then
                                    _dgv.Rows.Add(Selected_Data)
                                End If
                            Else
                                If Search_dgv() IsNot Nothing Then
                                    _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                End If
                            End If

                        Else
                            For Each childNode2 As TreeListNode In childNode.Nodes
                                Selected_Data(10) = childNode2.Text

                                If node.Checked = True Then
                                    If exist_dgv() = 0 Then
                                        _dgv.Rows.Add(Selected_Data)
                                    End If
                                Else
                                    If Search_dgv() IsNot Nothing Then
                                        _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                                    End If
                                End If
                            Next
                        End If
                        Selected_Data(10) = Nothing
                    Next
                    Selected_Data(9) = Nothing
                End If

            ElseIf Split(node.FullPath, "\").Length = 6 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(7) = node.ParentNode.ParentNode.Text
                Selected_Data(8) = node.ParentNode.Text
                Selected_Data(9) = node.Text

                If node.Nodes.Count = 0 Then
                    Selected_Data(10) = Nothing

                    If node.Checked = True Then
                        If exist_dgv() = 0 Then
                            _dgv.Rows.Add(Selected_Data)
                        End If
                    Else
                        Debug.Print(Search_dgv())
                        If Search_dgv() IsNot Nothing Then
                            _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                        End If
                    End If

                Else
                    For Each childNode As TreeListNode In node.Nodes
                        Selected_Data(10) = childNode.Text

                        If node.Checked = True Then
                            If exist_dgv() = 0 Then
                                _dgv.Rows.Add(Selected_Data)
                            End If
                        Else
                            If Search_dgv() IsNot Nothing Then
                                _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                            End If
                        End If
                    Next
                    Selected_Data(10) = Nothing
                End If

            ElseIf Split(node.FullPath, "\").Length = 7 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(7) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(8) = node.ParentNode.ParentNode.Text
                Selected_Data(9) = node.ParentNode.Text
                Selected_Data(10) = node.Text

                If node.Checked = True Then
                    If exist_dgv() = 0 Then
                        _dgv.Rows.Add(Selected_Data)
                    End If
                Else
                    If Search_dgv() IsNot Nothing Then
                        _dgv.Rows.Remove(_dgv.Rows(Search_dgv()))
                    End If
                End If
            End If


            _dgv.FirstDisplayedScrollingRowIndex = _dgv.RowCount - 1
            Exit For
        Next


        'AddHandler TreeListView1.BeforeCheckStateChanged, AddressOf TreeListView1_BeforeCheckStateChanged
        AddHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView1_AfterCheckStateChanged
    End Sub

#Region "[Sub] - [TreeView Checked] parent node 와 동일한 checked값으로 뿌리기"
    '# [TreeView Checked] parent node 와 동일한 checked값으로 뿌리기
    Private Sub CheckAllChildNodes(treeNode As TreeListNode, nodeChecked As Boolean)
        For Each node As TreeListNode In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub
#End Region

#End Region

#Region "[Function] - DataGridView Search Row Return (new)"
    'DataGridView Search Row Return
    Private Function Search_dgv()

        Dim qry1 = (From theRow As DataGridViewRow In _dgv.Rows
                    Where theRow.Cells(0).Value = Selected_Data(0) And
                       theRow.Cells(1).Value = Selected_Data(1) And
                       theRow.Cells(2).Value = Selected_Data(2) And
                       theRow.Cells(3).Value = Selected_Data(3) And
                       theRow.Cells(4).Value = Selected_Data(4) And
                       theRow.Cells(5).Value = Selected_Data(5) And
                       theRow.Cells(6).Value = Selected_Data(6) And
                       theRow.Cells(7).Value = Selected_Data(7) And
                       theRow.Cells(8).Value = Selected_Data(8) And
                       theRow.Cells(9).Value = Selected_Data(9) And
                       theRow.Cells(10).Value = Selected_Data(10)
                    Select theRow.Index).ToList

        If qry1.Count > 0 Then
            Return qry1.Last
        Else
            Return Nothing
        End If

    End Function
#End Region

#Region "[Function] - DataGridView 중복 조회"
    '# DataGridView 중복 조회
    '# Project(0),Operator(1),ModelName(2),Step(3),Type(4),App(5),Feature(6),Action1(7),Action2(8),Action3(9),Checked_Change(10),Checked_Plan(11),Defect(12),Around(13)
    Private Function exist_dgv() As Integer

        Dim qry1 = From theRow As DataGridViewRow In _dgv.Rows
                   Where theRow.Cells(0).Value = Selected_Data(0) And
                       theRow.Cells(1).Value = Selected_Data(1) And
                       theRow.Cells(2).Value = Selected_Data(2) And
                       theRow.Cells(3).Value = Selected_Data(3) And
                       theRow.Cells(4).Value = Selected_Data(4) And
                       theRow.Cells(5).Value = Selected_Data(5) And
                       theRow.Cells(6).Value = Selected_Data(6) And
                       theRow.Cells(7).Value = Selected_Data(7) And
                       theRow.Cells(8).Value = Selected_Data(8) And
                       theRow.Cells(9).Value = Selected_Data(9) And
                       theRow.Cells(10).Value = Selected_Data(10)
                   Select theRow

        Dim qryCount = Aggregate theRow As DataGridViewRow In qry1
                                Into Count()
        Return qryCount

    End Function
#End Region

#Region "[Sub][TreeListView1_AfterSelect.Handles]"
    '# [AppTree - AfterSelect]
    Public Sub TreeListView1_AfterSelect(sender As Object, e As ContainerListViewEventArgs) Handles TreeListView1.AfterSelect
        RemoveHandler TreeListView1.AfterSelect, AddressOf TreeListView1_AfterSelect
        'RemoveHandler TreeListView1.BeforeCheckStateChanged, AddressOf TreeListView1_BeforeCheckStateChanged
        RemoveHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView1_AfterCheckStateChanged



        Dim App_path() As String = Nothing

        For Each node As TreeListNode In TreeListView1.SelectedItems
            App_path = Split(node.FullPath, "\")

            If node.Nodes.Count = 0 And e.Item.Checked = True Then
                '// 활성화
                __Set_textbox__(True)
            Else
                __Set_textbox__(True)
                '// 비활성화
            End If

            For tmp_counter = 4 To 10
                Selected_Data(tmp_counter) = Nothing    '// 기본값 비움
            Next

            If App_path.Length = 1 Then
                Selected_Data(4) = node.Text
            ElseIf App_path.Length = 2 Then
                Selected_Data(4) = node.ParentNode.Text
                Selected_Data(5) = node.Text
            ElseIf App_path.Length = 3 Then
                Selected_Data(4) = node.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.Text
                Selected_Data(6) = node.Text
            ElseIf App_path.Length = 4 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.Text
                Selected_Data(7) = node.Text
            ElseIf App_path.Length = 5 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.ParentNode.Text
                Selected_Data(7) = node.ParentNode.Text
                Selected_Data(8) = node.Text
            ElseIf App_path.Length = 6 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(7) = node.ParentNode.ParentNode.Text
                Selected_Data(8) = node.ParentNode.Text
                Selected_Data(9) = node.Text
            ElseIf App_path.Length = 7 Then
                Selected_Data(4) = node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(5) = node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(6) = node.ParentNode.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(7) = node.ParentNode.ParentNode.ParentNode.Text
                Selected_Data(8) = node.ParentNode.ParentNode.Text
                Selected_Data(9) = node.ParentNode.Text
                Selected_Data(10) = node.Text
            End If
            If App_path.Length = 1 And App_path(0) = "3rd Party" Or App_path(0) = "Buyer App" Then
                'Call TxtBox_Config(TxtBox_AppName, App_path(0), Drawing.Color.DarkBlue)
                'Call TxtBox_Config(TxtBox_Item2, "유형 선택", Drawing.Color.Red)
                'Call TxtBox_Config(TxtBox_FeatureName, "세부내용 선택", Drawing.Color.Red)

            ElseIf App_path.Length >= 1 Then
                If node.Nodes.Count = 0 Then
                    'Call TxtBox_Config(TxtBox_AppName, App_path(0), Drawing.Color.DarkBlue)
                    'Call TxtBox_Config(TxtBox_Item2, App_path(1), Drawing.Color.DarkBlue)
                    'Call TxtBox_Config(TxtBox_FeatureName, App_path(2), Drawing.Color.DarkBlue)

                    If Search_dgv() IsNot Nothing Then
                        _dgv.Rows(Search_dgv()).Selected = True
                        _dgv.FirstDisplayedScrollingRowIndex = Search_dgv()

                        'If _dgv.Rows(Search_dgv()).Cells("11").Value = "O" Then
                        '    CheckBox_Changed.Checked = True
                        'Else
                        '    CheckBox_Changed.Checked = False
                        'End If

                        'If _dgv.Rows(Search_dgv()).Cells("12").Value = "O" Then
                        '    CheckBox_Plan.Checked = True
                        'Else
                        '    CheckBox_Plan.Checked = False
                        'End If

                        'If _dgv.Rows(Search_dgv()).Cells("13").Value = "O" Then
                        '    CheckBox_Side.Checked = True
                        'Else
                        '    CheckBox_Side.Checked = False
                        'End If

                        'If _dgv.Rows(Search_dgv()).Cells("14").Value = "1회성" Then
                        '    CheckBox_Reproducible.Checked = True
                        'Else
                        '    CheckBox_Reproducible.Checked = False
                        'End If

                        'TxtBox_Defect.Text = _dgv.Rows(Search_dgv()).Cells("16").Value
                        'TxtBox_Around.Text = _dgv.Rows(Search_dgv()).Cells("17").Value
                    Else
                        If _dgv.RowCount > 1 Then
                            _dgv.Rows(_dgv.RowCount - 1).Selected = True
                        End If
                        _dgv.FirstDisplayedScrollingRowIndex = _dgv.RowCount - 1
                        'CheckBox_Changed.Checked = False
                        'CheckBox_Plan.Checked = False
                        'CheckBox_Side.Checked = False
                        'CheckBox_Reproducible.Checked = False
                        'TxtBox_Defect.Text = Nothing
                        'TxtBox_Around.Text = Nothing
                    End If

                Else
                    'Call TxtBox_Config(TxtBox_AppName, App_path(0), Drawing.Color.DarkBlue)
                    'If App_path.Length >= 3 Then
                    '    Call TxtBox_Config(TxtBox_Item2, App_path(1), Drawing.Color.DarkBlue)
                    '    Call TxtBox_Config(TxtBox_FeatureName, App_path(2), Drawing.Color.DarkBlue)
                    'Else
                    '    If App_path.Length = 1 Then
                    '        Call TxtBox_Config(TxtBox_Item2, "유형 선택", Drawing.Color.Red)
                    '    Else
                    '        Call TxtBox_Config(TxtBox_Item2, App_path(1), Drawing.Color.DarkBlue)
                    '    End If

                    '    Call TxtBox_Config(TxtBox_FeatureName, "세부내용 선택", Drawing.Color.Red)
                    'End If

                    If _dgv.RowCount > 1 Then
                        _dgv.Rows(_dgv.RowCount - 1).Selected = True
                    End If

                    If _dgv.RowCount < 1 Then
                        _dgv.FirstDisplayedScrollingRowIndex = _dgv.RowCount - 1
                    Else
                        _dgv.FirstDisplayedScrollingRowIndex = _dgv.RowCount - 1
                    End If


                End If

            Else
                'Call TxtBox_Config(TxtBox_AppName, "APP 또는 HW 선택", Drawing.Color.Red)
                'Call TxtBox_Config(TxtBox_Item2, "유형 선택", Drawing.Color.Red)
                'Call TxtBox_Config(TxtBox_FeatureName, "세부내용 선택", Drawing.Color.Red)
            End If
            Exit For
        Next

        'If Project3DepthSelected_LastChildNode IsNot Nothing And project_3depth_bool = True Then
        '    Selected_Data(3) = Nothing
        '    project_3depth_bool = False
        'End If

        'Try
        '    Send_Description()
        'Catch ex As Exception
        '    TxtBox_Description.Text = Nothing
        'End Try
        'MakeChangeNoteView()   '// 변경점 View



        'If TDConnected = True Then
        'If Application.OpenForms().OfType(Of RS_Search_Defect).Any Then
        'Else
        '    RS_Search_Defect = New RS_Search_Defect
        '    RS_Search_Defect.Show()
        'End If
        'RS_Search_Defect.WebBrowser1.DocumentText = ""
        'RS_Search_Defect.WebBrowser2.DocumentText = ""
        'RS_Search_Defect.Label1.Text = "Total 0 건입니다."
        'Make_DefectID_List()
        'End If

        AddHandler TreeListView1.AfterSelect, AddressOf TreeListView1_AfterSelect
        'AddHandler TreeListView1.BeforeCheckStateChanged, AddressOf TreeListView1_BeforeCheckStateChanged
        AddHandler TreeListView1.AfterCheckStateChanged, AddressOf TreeListView1_AfterCheckStateChanged
    End Sub
#End Region




End Class
