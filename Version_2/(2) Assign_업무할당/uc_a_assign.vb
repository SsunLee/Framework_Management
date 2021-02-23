Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Threading
Imports System.Windows
Imports System.Windows.Forms
Imports WinControls.ListView
Imports WinControls.ListView.Collections
Imports WinControls.ListView.EventArgClasses
Imports MessageBox = System.Windows.MessageBox
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports MySql.Data
Imports MetroFramework.Controls
Imports MySql.Data.MySqlClient

Public Class uc_a_assign

    Public dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class

#Region "Property - Set Property"
    Private __maindt As DataTable
    Property _maindt As DataTable
        Get
            Return __maindt
        End Get
        Set(value As DataTable)
            __maindt = value
        End Set
    End Property

    Private __dtGrid As DataGridView
    Property _dtGrid As DataGridView
        Get
            Return __dtGrid
        End Get
        Set(value As DataGridView)
            __dtGrid = value
        End Set
    End Property
    Private __dtable As DataTable
    Property _dtable As DataTable
        Get
            Return __dtable
        End Get
        Set(value As DataTable)
            __dtable = value
        End Set
    End Property
    Private __contacts As DataTable
    Public Property _contacts As DataTable
        Get
            Return __contacts
        End Get
        Set(value As DataTable)
            __contacts = value
        End Set

    End Property
    Private _exportTrv As DataTable = New DataTable
    Private _dtlevel As DataTable = New DataTable
    Private _cht_dt As DataTable = New DataTable
    Private _dtPre As DataTable = New DataTable
    Private _dsmain As DataSet = New DataSet
    Public f1 As New Form
    Public _la As Label = New Label
    Private trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker
    Private _preStep As String

    Private lst As Qportals.Controls.ListViewMaker = New Qportals.Controls.ListViewMaker
    Property _dtScore As DataTable
    Private _user As String
    Property _DuplNames As List(Of String)

    Private _trvAssign As TreeListView
    Private _trvAvg As TreeListView
    Private _dgv As DataGridView

#End Region

    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        '// DataGridView 기본 설정
        __datagridView__()

        '// TreeListView 기본 설정
        __init_treeListView__()

        '// 그 외 다른 control 기본 설정
        __init_otherControl__()


        Dim get_user As Qportals.ComputerInfo = New Qportals.ComputerInfo
        _user = get_user.getUserName()


        _mainuser = NotUesFAS_System.f._user
        _company = NotUesFAS_System.f._company

        _trvAssign = TreeListView1
        _trvAvg = TreeListView2
        _dgv = DataGridView1

        ImportCht_backdata()    '// 초기에 Mem

    End Sub

#Region "DataGridView - Default Setting "

    Private Sub __datagridView__()
        '// DataGridView 기본 설정
        _dtGrid = DataGridView1

        'Dim testGrid As New CustomDataGridView
        'GetType(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.SetProperty, Nothing, DataGridView1, New Object() {True})

        With _dtGrid
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AllowUserToOrderColumns = True ' 유저가 맘대로 바꾸고 싶을 때
            .DefaultCellStyle.SelectionBackColor = Color.White  ' 선택 했을 때 back color
            .DefaultCellStyle.SelectionForeColor = Color.Black   ' 선택 했을 때 글씨 color
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(190, 216, 242) ' 열의 색상 지정
            '열과 행의 경계선 스타일 지정
            .EnableHeadersVisualStyles = False
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            '열에 보여지는 문자열을 여러행으로 보여주고 싶을 때
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True

            ' 행 사이즈 자동 조절 
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            '열 사이즈 자동 조절
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            '----------DataGridView--Font------------
            .DefaultCellStyle.Font = New Font("맑은 고딕", 7)
            .ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 7)
        End With

        '------------------------------------------
        Dim strcolumns() As String = New String() {"ID", "Category", "TCType", "TCName", "Tester", "PartName", "주특기", "Level", "memo"}
        '** DataGridView(하단)에 자료를 넣기 위해 DataTable을 만들었습니다.
        '** 이하 dgv 
        _dtable = New DataTable()

        '** Column을 만듭니다.---------------------
        For Each c As String In strcolumns
            _dtable.Columns.Add(New DataColumn(c))
        Next
        '** dgv에 자료를 넣어 줍니다.
        If Not (_dtable Is Nothing) Then
            _dtGrid.DataSource = _dtable
        End If
        '------------------------------------------

        DataGridView1.DataSource = _dtable
        DataGridView1.AllowDrop = True

    End Sub

    Public Shadows Sub DoubleBuffered(ByVal dgv As DataGridView, ByVal setting As Boolean)
        Dim dgvType As Type = dgv.GetType
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.SetProperty)
        pi.SetValue(dgv, setting, Nothing)
    End Sub
    Private Sub SetdgvStyle(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        ' * DataGridView 스타일을 엑셀 처럼
        Dim dgvstyle As Qportals.Controls.dgvStyle = New Qportals.Controls.dgvStyle
        dgvstyle.Grid_RowPostPaint(DataGridView1, e)
    End Sub
#End Region

#Region "TreeListView - Default Setting"
    Private Sub __init_treeListView__()
        ' TreeListView ---------------------
        With TreeListView1
            .MultiSelect = False
            .FullRowSelect = True
            .Columns.Item(0).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).ForeColor = Color.Blue
            .Columns.Item(2).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(3).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            '.Columns.Item(0).Width = 300
            '.Columns.Item(2).Width = 150
            '.Columns.Item(3).Width = 100
        End With
        With TreeListView2
            .MultiSelect = False
            .FullRowSelect = True
            .Columns.Item(0).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).ForeColor = Color.Blue
            .Columns.Item(2).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(0).Width = 280
            '.Columns.Item(0).Width = 500
            '.Columns.Item(2).Width = 150
            '.Columns.Item(3).Width = 100
        End With

    End Sub
#End Region

#Region "Controls - ToolTip, TextBox, Panel "
    Private Sub __init_otherControl__()
        ' 기본 모델 정보
        txtProin.Text = "[프로젝트 선택]"
        txtGroupin.Text = "[그룹 선택]"
        txtModelin.Text = "[모델 선택]"
        txtStepin.Text = "[차수 선택]"

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
        ToggleSwitch1.Checked = True

        '2019-08-22 추가 : Contacts DB를 초기에 불러옴 
        Dim sql As String = "select * from rs2.`contact`"
        Dim dt As DataTable = New DataTable

        dt = dbc.Mysql_to_datatable(sql)
        _contacts = dt

        ' ToolTip
        Dim toolTip1 As New ToolTip

        With toolTip1
            .SetToolTip(btn_addrow, "상위 행 복사 삽입" & vbCrLf & "* 좌측 행 전체 선택 시")
            .SetToolTip(btnMDSave, "내용 저장")
            .SetToolTip(btnS1, "검색")
            .SetToolTip(btnS2, "검색")
            .SetToolTip(btnS3, "검색")
            .SetToolTip(btnS4, "검색")
            .SetToolTip(rdoLeft, "이전 투입 이력 추출하기")
            .SetToolTip(rdoRight, "이전 투입 평균 역량 추출하기")
            .InitialDelay = 500
            .AutoPopDelay = 2000
            .ReshowDelay = 500
        End With

        tggl_Prechk.Checked = True

    End Sub

    Private Sub settingsVisible(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Setting_pnael.Visible = False Then
            Setting_pnael.Visible = True
        Else
            Setting_pnael.Visible = False
        End If
    End Sub

#End Region

#Region "차트 그리기 관련"
    Private _mainuser As String
    Private _company As String
    ''' <summary>
    ''' Make_ChartScreen() : 차트를 그리는 함수
    ''' Sender 의 control name을 기준으로 기능을 분기하여 동적으로 처리 함
    ''' </summary>
    Private Sub Make_ChartScreen(sender As Object, e As EventArgs) Handles TreeListView1.Click, TreeListView2.Click, DataGridView1.Click
        Dim nowUser As String
        Dim dt As DataTable = New DataTable
        Dim dv As DataView

        ' 토글옵션 ( 항상띄우기가 꺼져있으면 ) 
        If ToggleSwitch1.Checked = True Then

            If TryCast(sender, Control).Name = "TreeListView1" Then
                '// Assign TreeView

                If Not (_trvAssign.Nodes.Count = 0) And (_trvAssign.SelectedItems.Count > 0) Then
                    If _trvAssign.SelectedItems.Item(0).SubItems.Count > 0 Then
                        nowUser = _trvAssign.SelectedItems.Item(0).SubItems(0).ToString()
                        '// 필터 걸기 
                        dt = _dsmain.Tables("아이템횟수")
                        dt.DefaultView.RowFilter = "[Tester] = '" & nowUser & "'"
                        dv = dt.DefaultView

                        '// 차트 뿌리기
                        Dim temp_dt As DataTable = dv.ToTable()
                        If temp_dt.Rows.Count > 0 Then
                            Show_chart("진행횟수", temp_dt)
                        End If
                    End If
                End If


            ElseIf TryCast(sender, Control).Name = "TreeListView2" Then
                '// Avg. TreeView
                If Not (_trvAvg.Nodes.Count = 0) And (_trvAvg.SelectedItems.Count > 0) Then
                    If _trvAvg.SelectedItems.Item(0).SubItems.Count > 0 Then
                        nowUser = _trvAvg.SelectedItems.Item(0).ToString()
                        dt = _dsmain.Tables("검증원횟수")
                        nowUser = remove_quarter(nowUser)
                        '// 필터 걸기 
                        dt.DefaultView.RowFilter = "[TestItem] LIKE '%" & nowUser & "%'"
                        dv = dt.DefaultView

                        Dim quert = From r In dt.AsEnumerable()
                                    Group r By Item = New With {
                                        Key .Category = r.Field(Of String)("Category"),
                                        Key .TCtype = r.Field(Of String)("TCtype"),
                                        Key .TestItem = r.Field(Of String)("TestItem"),
                                        Key .Tester = r.Field(Of String)("Tester")
                        } Into grp = Group
                                    Let r = grp.First
                                    Select New With {
                        .Category = r("Category"),
                                        .TCtype = r("TCtype"),
                                        .TestItem = r("TestItem"),
                                        .Tester = r("Tester"),
                                        .Value = r("진행횟수")
                        }
                        Dim temp_dt As DataTable = dv.ToTable()
                        temp_dt = dt.Clone
                        For Each item In quert
                            Dim rows As DataRow = temp_dt.NewRow()
                            rows("Category") = item.Category
                            rows("TCtype") = item.TCtype
                            rows("TestItem") = item.TestItem
                            rows("Tester") = item.Tester
                            rows("진행횟수") = item.Value
                            'temp_dt.Rows.Add(item.TCtype, item.TestItem, item.Tester, item.Value)
                            temp_dt.Rows.Add(rows)
                        Next


                        '// 차트 뿌리기
                        If temp_dt.Rows.Count > 0 Then
                            Show_chart("Tester", temp_dt)
                        End If
                    End If
                End If


            ElseIf TryCast(sender, Control).Name = "DataGridView1" Then
                '// Assign DataGridView 

                If Not (_dgv.RowCount = 0) Then
                    '// 이름을 선택 한 경우 
                    If (_dgv.CurrentCell.ColumnIndex = 4) Then
                        nowUser = _dgv("Tester", _dgv.CurrentCell.RowIndex).Value.ToString()

                        If (_dgv("Tester", _dgv.CurrentCell.RowIndex).Value Is Nothing) Or nowUser = "" Then Exit Sub

                        '// 필터 걸기 
                        dt = _dsmain.Tables("아이템횟수")
                        dt.DefaultView.RowFilter = "[Tester] = '" & nowUser & "'"
                        dv = dt.DefaultView

                        '// 차트 뿌리기
                        Dim temp_dt As DataTable = dv.ToTable()
                        If temp_dt.Rows.Count > 0 Then
                            Show_chart("TestItem", temp_dt)
                        End If

                    ElseIf (_dgv.CurrentCell.ColumnIndex = 3) Then
                        '// 아이템을 선택 한 경우
                        nowUser = _dgv("TestItem", _dgv.CurrentCell.RowIndex).Value.ToString()
                        dt = _dsmain.Tables("검증원횟수")
                        '// 필터 걸기 
                        dt.DefaultView.RowFilter = "[TestItem] LIKE '%" & nowUser & "%'"
                        dv = dt.DefaultView
                        Dim temp_dt As DataTable = dv.ToTable()
                        '// 차트 뿌리기
                        If temp_dt.Rows.Count > 0 Then
                            Show_chart("Tester", temp_dt)
                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private _byUserdt As DataTable
    Private _byItemdt As DataTable

    Private strSQLCon As String = "Server=10.169.88.40;Uid=rs_user;Pwd=lge1234;Database=td_defect"
    Private mySQLCon As New MySqlConnection(strSQLCon)
    ''' <summary>
    ''' 차트 데이터를 미리 구성하여 잦은 DB Connection을 방지하기 위함
    ''' </summary>
    Private Function ImportCht_backdata() As DataSet
        Dim sql_byTester As String
        Dim sql_byItem As String
        Dim DA As MySqlDataAdapter = New MySqlDataAdapter


        '// 어떤 T/C를 진행 했는지 표현하고자 할 때
        sql_byItem = String.Format("
                    SELECT `Category`, `TCType`, `TestItem`, `Tester`, Count(*) as `진행횟수` 
                    FROM td_defect.`assign_testcase` 
                    GROUP BY `Category`, `TCType`, `TestItem`
                    ORDER BY `진행횟수` DESC")


        '// 누가 이 T/C를 진행 했는지 표현하고자 할 때
        sql_byTester = String.Format("
                    SELECT `Category`, `TCType`,TestItem, Tester,  COUNT(*) AS `진행횟수` FROM td_defect.`assign_testcase` 
                    GROUP BY Tester
                    ORDER BY `진행횟수` DESC")

        DA = New MySqlDataAdapter(sql_byItem, mySQLCon)
        DA.Fill(_dsmain, "아이템횟수")
        DA = New MySqlDataAdapter(sql_byTester, mySQLCon)
        DA.Fill(_dsmain, "검증원횟수")

        Return _dsmain


    End Function
#End Region



    Private Sub SelectChangeToggle_PreStep(sender As Object, e As EventArgs) Handles tggl_Prechk.CheckedChanged
        '// 이전차수 구해서 저장하기.
        Dim pre_Step As String

        '// TreeListView1 
        pre_Step = la_NowSteps.Text.ToString
        If pre_Step.Contains(":") Then
            pre_Step = pre_Step.Split(":")(1)
            pre_Step = pre_Step.Trim
            _preStep = pre_Step
            PreOrNow()
            looptest(TreeListView1.Nodes)

            pre_Step = la_NowSteps.Text.ToString
            pre_Step = pre_Step.Split(":")(1)
            pre_Step = pre_Step.Trim
            _preStep = pre_Step

            '// TreeListView2
            Load_AverageScore_PreStep()

        End If


        Qportals.Debugging.Log(_preStep)

    End Sub '// 이전차수 보기 버튼 눌렀을 때


#Region "<모델 선택>"
    '** 모델 검색 버튼 눌렀을 때
    Private Sub SearchButtonClick(sender As Object, e As EventArgs) _
        Handles btnS1.Click, btnS2.Click, btnS3.Click, btnS4.Click

        Dim srch As New Qportals.Level.SelectModeltoOtherForm
        Dim lst As New Qportals.Controls.ListViewMaker
        Dim trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker

        Dim f1 As New Form
        Dim openPopup As New FW_SELECT_MODEL With {
        .Owner = f1
        }

        '  검색 눌렀을 때 DB에서 프로젝트 정보를 조회 합니다.
        Dim strPro As String, strGrp As String, strMod As String, strStep As String

        strPro = If(txtPro.Text.ToString = "", "", "and `Project` Like '%" & Replace(txtPro.Text.ToString.ToUpper, "'", "''") & "%' ")
        strGrp = If(txtGrp.Text.ToString = "", "", "and `GroupName` = '" & Replace(txtGrp.Text.ToString.ToUpper, "'", "''") & "' ")
        strMod = If(txtModel.Text.ToString = "", "", "and `Model` = '" & Replace(txtModel.Text.ToString.ToUpper, "'", "''") & "' ")
        strStep = If(txtStep.Text.ToString = "", "", "and `Step` = '" & Replace(txtStep.Text.ToString.ToUpper, "'", "''") & "' ")


        Dim sql As String
        Dim schemaName As String = "td_defect"
        sql = "SELECT DISTINCT Project, GroupName, Model, Step, StartDate, EndDate, 랭킹 FROM " & schemaName
        sql += ".`project`" & " WHERE ID > 0 and " & "GroupName is not Null and Model is not null and Step is not null "
        sql += strPro & strGrp & strMod & strStep
        sql += " order by Project, StartDate"


        Dim dt As DataTable = New DataTable
        dt = dbc.Mysql_to_datatable(sql)


        ' ** 기존 리스트 지우고 ListView를 만든 다음 새로운 Form에 자료를 띄웁니다.
        If Not (dt Is Nothing) Then
            openPopup.ListView1.Items.Clear()
            lst.BuildList(openPopup.ListView1, dt, New Integer() {0, 1, 2, 3, 4, 5, 6})
            openPopup.TopMost = True
            openPopup.ShowDialog()
        End If

        If openPopup.ListView1.CheckedItems.Count > 0 Then
            ' 현재 선택한 아이템이 몇 번째 인지 구해서 lstRow에 저장 합니다.
            Dim lstRow As Integer = openPopup.ListView1.Items.IndexOf(openPopup.ListView1.CheckedItems.Item(0))

            ' 선택 한 값들을 프로젝트, 그룹, 모델, 차수 텍스트 상자에 값을 넣습니다.
            With openPopup.ListView1.Items.Item(lstRow)
                txtProin.Text = .SubItems(0).Text.ToString
                txtGroupin.Text = .SubItems(1).Text.ToString
                txtModelin.Text = .SubItems(2).Text.ToString
                txtStepin.Text = .SubItems(3).Text.ToString
                txtStartin.Text = .SubItems(4).Text.ToString
                txtEndin.Text = .SubItems(5).Text.ToString
                txtseq.Text = .SubItems(6).Text.ToString
            End With

            '// DataGridView에 뿌려 줄 할당정보를 뿌립니다.
            'sql = String.Format("select ID, `Category`, `TCtype`, `TestItem`, `Tester`, `company`, `scorelevel` from td_defect.`assign_testcase` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}' ",
            '             txtProin.Text.ToString, txtGroupin.Text.ToString, txtModelin.Text.ToString, txtStepin.Text.ToString)
            sql = String.Format("SELECT 
	                                tct.ID, tct.Category, tct.TCtype, tct.TestItem, tct.Tester, 
	                                (SELECT mem.주특기 FROM td_defect.assign_member mem WHERE tct.Tester = mem.Tester)  AS 주특기,
	                                (SELECT 역량 FROM td_defect.leveldb lvdb WHERE tct.Tester = lvdb.이름) AS scorelevel
                                FROM td_defect.`assign_testcase` tct
                                WHERE Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}'", txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)
            '// DataGridView에 할당 정보 가져오기
            dt = dbc.Mysql_to_datatable(sql)
            If Not (dt Is Nothing) And (dt.Rows.Count > 0) Then

                '역량레벨넣기(dt, "Tester")

                DataGridView1.DataSource = dt
                DataGridView1.Columns(3).Width = 300
                DataGridView1.Columns("ID").Visible = False

            End If

            '// 이전차수 또는 현차수 조회
            '// TreeView에 정보 가져오기
            PreOrNow()


            If la_NowSteps.Text = "" Then
                Dim emptyDt As DataTable = New DataTable
                emptyDt = dt.Clone
                trv.Make_Node_Project(emptyDt, TreeListView1)

                trv.BuildTree(emptyDt, New Integer() {0, 1, 2})   '// 새로운 방식

                Exit Sub
            End If
            '// 이전차수 구해서 저장하기.
            Dim pre_Step As String
            pre_Step = la_NowSteps.Text.ToString
            pre_Step = pre_Step.Split(":")(1)
            pre_Step = pre_Step.Trim
            _preStep = pre_Step

            '// 이전차수의 평균 역량을 구하여 TreeListView2에 출력 해주는 부분
            Load_AverageScore_PreStep()

            TreeListView2.FullRowSelect = False

            import_assignMember()   '// 할당 멤버 보여주기

        End If


    End Sub


    Private Sub WhenEnterKeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtPro.KeyDown, txtModel.KeyDown, txtStep.KeyDown, txtGrp.KeyDown
        ' * 엔터 키 쳤을 때
        If (e.KeyCode = Keys.Enter) Then
            SearchButtonClick(sender, e)
        End If

    End Sub



    Private Sub PreOrNow()
        '// 지금 선택 된 모델이 이전차수가 있는지 또는 이전차수가 없는지 확인해서 
        '// TreeListView1 에 데이터를 채우는 함수
        ' 이전차수를 구하는 코드 
        Dim sql As String
        Dim trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker
        Dim dt As DataTable = New DataTable
        Dim dtPre As DataTable = New DataTable

        ' 이 모델에 testcase 가 등록되어있는지 확인을 합니다.
        sql = "select count(*) from td_defect.`assign_testcase` "
        sql += String.Format("WHERE `Project` = '{0}' AND `GroupName`='{1}' AND `Model`='{2}' AND `Step`='{3}';",
                            txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)

        ' 위의 쿼리를 실행 합니다.
        Dim strResult As String = dbc.GetQueryResult(sql)
        Dim chk As Boolean = False

        chk = If(strResult = "0", False, True)

        If chk = True Then

            ' 이전차수가 보여지도록 되어있는 경우
            If (tggl_Prechk.Checked = True) Then
                sql = String.Format("
                    select * from (
                                    select `Project`, `GroupName`, `Model`, `Step`, ROW_NUMBER() OVER(ORDER BY STEP) AS 랭킹
                                    from td_defect.`assign_testcase`
                                    where Project = '{0}' and GroupName = '{1}' and Model = '{2}'
                                    order by Step
                                    ) T1
                    WHERE 랭킹 = (
                                    select 랭킹 from (
                                                        select `Project`, `GroupName`, `Model`, `Step`, ROW_NUMBER() OVER(ORDER BY Step) as 랭킹
                                                        from td_defect.`assign_testcase` 
                                                        where Project = '{0}' and GroupName = '{1}' and Model = '{2}'
                                                        order by Step
                                                    ) T2
                                    where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step ='{3}'
                                    LIMIT 1
                                    ) -1
                        ", txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)
                dtPre = dbc.Mysql_to_datatable(sql)
                Dim _Step As String

                If dtPre.Rows.Count > 0 Then
                    '// 이전 차수가 있다면
                    _Step = dtPre.Rows(0)("Step").ToString
                    sql = String.Format("select ID, `Category`, `TCtype`, `TestItem`, `Tester`, `company`, `scorelevel`  from td_defect.`assign_testcase` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}'",
                        txtProin.Text, txtGroupin.Text, txtModelin.Text, _Step)

                    la_NowSteps.Text = "이 전 차수 데이터 : " & _Step
                    dtPre = dbc.Mysql_to_datatable(sql)
                    dtPre = dtPre.DefaultView.ToTable(False, "Category", "TCType", "TestItem", "Tester", "scorelevel")
                    '역량레벨넣기(dtPre, "Tester")
                    dtPre.DefaultView.Sort = "[Category], [TCtype] asc"
                    dtPre = dtPre.DefaultView.ToTable

                    trv.Make_Node_Project(dtPre, TreeListView1)
                    SetFont(TreeListView1.Nodes, 8)
                    TreeListView1.ExpandAll()
                    looptest(TreeListView1.Nodes)

                Else
                    '// 이전 차수가 없다면 
                    '// 현재 차수 
                    sql = String.Format("select ID, `Category`, `TCtype`, `TestItem`, `Tester`, `company`, `scorelevel` from td_defect.`assign_testcase` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}' ",
                             txtProin.Text.ToString, txtGroupin.Text.ToString, txtModelin.Text.ToString, txtStepin.Text.ToString)
                    la_NowSteps.Text = "현재 차수 : " & txtStepin.Text
                    dt = dbc.Mysql_to_datatable(sql)
                    dt = dt.DefaultView.ToTable(False, "Category", "TCType", "TestItem", "Tester", "scorelevel")
                    '역량레벨넣기(dt, "Tester")
                    dt.DefaultView.Sort = "[Category], [TCtype] asc"
                    dt = dt.DefaultView.ToTable

                    trv.Make_Node_Project(dt, TreeListView1)
                    SetFont(TreeListView1.Nodes, 8)
                    TreeListView1.ExpandAll()
                    looptest(TreeListView1.Nodes)

                    tggl_Prechk.Checked = False

                End If


            Else
                '// 현재 차수 
                sql = String.Format("select ID, `Category`, `TCtype`, `TestItem`, `Tester`, `company`, `scorelevel` from td_defect.`assign_testcase` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}' ",
                         txtProin.Text.ToString, txtGroupin.Text.ToString, txtModelin.Text.ToString, txtStepin.Text.ToString)
                la_NowSteps.Text = "현재 차수 : " & txtStepin.Text
                dt = dbc.Mysql_to_datatable(sql)
                dt = dt.DefaultView.ToTable(False, "Category", "TCType", "TestItem", "Tester", "scorelevel")
                '역량레벨넣기(dt, "Tester")
                dt.DefaultView.Sort = "[Category], [TCtype] asc"
                dt = dt.DefaultView.ToTable

                trv.Make_Node_Project(dt, TreeListView1)
                SetFont(TreeListView1.Nodes, 8)
                TreeListView1.ExpandAll()
                looptest(TreeListView1.Nodes)

            End If ' 이 전 차수가 없다면
        Else
            Qportals.Debugging.Show("등록 된 내용이 없습니다." & "등록 화면에서 다시 확인 해주세요. ")
            la_NowSteps.Text = ""
        End If

    End Sub '// 이전차수를 구하는 코드 

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PreOrNow()
    End Sub '// Refresh 버튼 눌렀을 때

    Private Sub btnExportClick(sender As Object, e As EventArgs) Handles btn_export.Click
        '// 역량 및 진행 아이템 엑셀 Export 기능
        Dim dttest As DataTable = New DataTable
        Dim _columns() As String '= New String() {"Category", "TCtype", "TestItem", "Score"}
        Dim _tempdt As DataTable = New DataTable
        _exportTrv = New DataTable

        If (rdoLeft.Checked) Then
            _columns = New String() {"Category", "TCtype", "TestItem", "Tester"}
            For Each s As String In _columns
                _exportTrv.Columns.Add(s)
            Next
            TreeListViewToDataTable(TreeListView1.Nodes)
        Else
            _columns = New String() {"Category", "TCtype", "TestItem", "Score"}
            For Each s As String In _columns
                _exportTrv.Columns.Add(s)
            Next
            TreeListViewToDataTable(TreeListView2.Nodes)

        End If

        '// 엑셀 추출 시작 
        downloadExcel()

    End Sub

    Private Sub downloadExcel()

        Dim ep As Qportals.External_library.EPPlus = New Qportals.External_library.EPPlus
        Dim fi As Qportals.FileControl = New Qportals.FileControl

        If Not (_exportTrv Is Nothing) Then
            Dim makeFileName As String

            makeFileName = String.Format("{0}_{1}_{2}_{3}",
                        txtProin.Text, txtGroupin.Text, txtModelin.Text, _preStep)
            ep.datatable_to_excel(_exportTrv, makeFileName)

        End If


    End Sub

    Private Sub TreeListViewToDataTable(nodes As TreeListNodeCollection)
        Dim __trvPath() As String

        For Each node As TreeListNode In nodes
            __trvPath = node.FullPath.Split("\")
            If node.SubItems.Count > 0 Then
                Dim temp = node.SubItems.Item(0).ToString
                _exportTrv.Rows.Add(__trvPath(0), __trvPath(1), __trvPath(2), temp)
            End If

            TreeListViewToDataTable(node.Nodes)
        Next '2515923

    End Sub

    Public Sub SetFont(nodes As TreeListNodeCollection, sizeindex As Integer)
        For Each node As TreeListNode In nodes

            If (node.Nodes.Count > 0) Then
                node.Font = New Font("맑은 고딕", sizeindex)
                SetFont(node.Nodes, sizeindex)
            End If

        Next
    End Sub

    Public Sub SetColor(nodes As TreeListNodeCollection)
        Dim trvFullPath() As String

        For Each node As TreeListNode In nodes
            trvFullPath = node.FullPath.Split("\")

            If (trvFullPath.Length = 3) Then
                '// Fun) Application

                If node.SubItems.Count > 0 Then
                    '// Function / Fun) Application / GMS_Chrome / 5 
                    node.SubItems.Item(0).ForeColor = Color.Red

                    Select Case Convert.ToInt32(node.SubItems.Item(0).ToString)
                        Case Is >= 4   '// Green
                            node.BackColor = Color.FromArgb(179, 255, 179)
                        Case Is >= 3    '// Yello
                            node.BackColor = Color.FromArgb(255, 231, 155)
                        Case < 3    '// 
                            node.BackColor = Color.FromArgb(255, 159, 159)
                    End Select

                End If

                SetColor(node.Nodes)

            End If
            SetColor(node.Nodes)
        Next
    End Sub

#End Region

    Private Sub SelectIndexChange_TreeListView22(sender As Object, e As EventArgs) 'Handles TreeListView2.Click ', TreeListView2.Click
        '// 트리뷰에서 검증원 클릭 시 검증원의 정보를 보여줌
        Dim _user As String
        Dim sql As String

        If Not (TreeListView2.Nodes.Count = 0) And (TreeListView2.SelectedItems.Count > 0) Then

            If (TreeListView2.SelectedItems.Item("Tester").SubItems.Count > 0) Then
                _user = TreeListView2.SelectedItems.Item(0).ToString

                Dim dt_comp As DataTable = dbc.GetContacts(_user)

                sql = "select `Category`, `TCType`, `TestItem`, Count(*) as `진행횟수` from td_defect.`assign_testcase` where Tester = '" & _user & "'"
                sql += " Group by `Category`, `TCType`, `TestItem`"
                sql += " Order by `진행횟수` desc"


                sql = String.Format("
                    SELECT TestItem, Tester, company,  COUNT(*) AS `진행횟수` FROM td_defect.`assign_testcase` 
                    WHERE TestItem LIKE '%{0}%' AND Tester IS NOT NULL AND NOT Tester = ''
                    GROUP BY Tester
                    ORDER BY `진행횟수` DESC", _user)


                _cht_dt = dbc.Mysql_to_datatable(sql)

                If _cht_dt.Rows.Count > 0 Then
                    Show_chart("Tester", _cht_dt)
                End If

            End If
        End If

    End Sub


    Private Sub SelectIndexChange_TreeListView(sender As Object, e As EventArgs) 'Handles TreeListView1.Click ', TreeListView2.Click
        '// 트리뷰에서 검증원 클릭 시 검증원의 정보를 보여줌
        Dim _user As String
        Dim sql As String

        If Not (TreeListView1.Nodes.Count = 0) And (TreeListView1.SelectedItems.Count > 0) Then

            If (TreeListView1.SelectedItems.Item(0).SubItems.Count > 0) Then
                _user = TreeListView1.SelectedItems.Item(0).SubItems.Item(0).ToString()
                If (_user = "") Then
                    Exit Sub
                End If

                Dim dt_comp As DataTable = dbc.GetContacts(_user)

                sql = "select `Category`, `TCType`, `TestItem`, Count(*) as `진행횟수` from td_defect.`assign_testcase` where Tester = '" & _user & "'"
                sql += " Group by `Category`, `TCType`, `TestItem`"
                sql += " Order by `진행횟수` desc"

                _cht_dt = dbc.Mysql_to_datatable(sql)

                If _cht_dt.Rows.Count > 0 Then
                    Show_chart("진행횟수", dt_comp)
                End If

            End If
        End If

    End Sub



#Region "DataGridView 내용 입력 될 때"

    Private Sub DataGridView_내용입력(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        '2019-09-03 : rs2.`contacts` Database로 접근 하도록 수정
        Dim cinfo As Qportals.ComputerInfo = New Qportals.ComputerInfo

        ' 만약 잘 못된 이름이 들어간다면 
        If DataGridView1.RowCount > 1 Then
            Dim _user As String = DataGridView1.Item(4, e.RowIndex).Value.ToString()

            'Dim dt_comp As DataTable = cinfo.GetContact(_user)

            'Dim dt_comp As DataTable = dbc.GetContacts(_user)
            ' 역량
            '역량레벨넣기(_contacts)
            Dim dt_comp As DataTable = getAccid(_user)

            Dim Comments As String
            Dim expression As String
            'expression = "[협력사] LIKE '%" & _user & "%'"
            'expression = "역량 asc"
            expression = "역량 = max(역량)"
            Dim foundRows() As DataRow

            foundRows = dt_comp.Select(expression)

            If foundRows.Length = 0 Then
                If (e.ColumnIndex = 4) Then
                    Comments = "등록 되지 않은 인원이거나, 잘못 된 이름입니다." & " * 만약 이 팝업이 발생 한다면, 모델리더 및 Qportal 관리자에게 문의하세요."
                    'MessageBox.Show(Comments, "lee.sunbae@lgepartner.com", MessageBoxButton.OK, MessageBoxIcon.Error)
                    Qportals.Debugging.Show(Comments, 0, 64)
                    RemoveHandler DataGridView1.CellValueChanged, AddressOf DataGridView_내용입력
                    DataGridView1.Item(4, e.RowIndex).Value = ""
                    AddHandler DataGridView1.CellValueChanged, AddressOf DataGridView_내용입력
                    Exit Sub
                End If

            Else

                If (foundRows.Length > 1) Then
                    '한 명 이상이면 선택 하는 창 띄울 것임.
                Else
                    RemoveHandler DataGridView1.CellValueChanged, AddressOf DataGridView_내용입력

                    ' * 이름 및 업체명 입력 되는 부분 
                    DataGridView1.Item(5, e.RowIndex).Value = foundRows(0).Item("주특기").ToString
                    DataGridView1.Item(6, e.RowIndex).Value = foundRows(0).Item("역량").ToString

                    AddHandler DataGridView1.CellValueChanged, AddressOf DataGridView_내용입력

                End If

            End If

        End If

    End Sub

    Private Function getAccid(ByRef name As String) As DataTable

        Dim sql As String

        sql = String.Format("SELECT 
                                `name`, `company`, 주특기, 역량
                            FROM assign_mem.`manage_memlevel` a
                            WHERE company = '{0}' and `name` = '{1}';",
                            NotUesFAS_System.f._company, name)
        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)

        Return IIf(dt Is Nothing, Nothing, dt)

    End Function



#End Region

#Region "붙여넣어서 할당하기"

    Private Sub CtrlCV_to_Dgv(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Dim clp As Qportals.Clipboards = New Qportals.Clipboards
        Dim a As DataTable
        ' Control 키 + v 키 눌렀을 때
        If (e.Control = True And e.KeyCode = Keys.V) Then
            a = clp.Clipboard_to_DataTable(Forms.Clipboard.GetText())
            If (a.Rows.Count > 0) Then
                Input_Tester(a)
            End If
        End If

    End Sub

    Private Sub Input_Tester(ByRef _dt As DataTable)
        Dim rowcnt As Integer = _dt.Rows.Count
        Dim start_row As Integer = DataGridView1.CurrentCell.RowIndex

        Dim j As Integer = 0
        Try
            For i As Integer = start_row To start_row + rowcnt - 1
                DataGridView1.Item("Tester", i).Value = _dt.Rows.Item(j)(0)
                j += 1
            Next
        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try

    End Sub



#End Region


#Region "할당내용DB에 올리기!"

    Private Sub Upload_data(sender As Object, e As EventArgs) Handles btnMDSave.Click

        ' * DB 업로드 부분
        ' ** DataGridView에 Data를 올리는 부분입니다.
        Dim DB As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class

        ' * DataGridView => DataTable 
        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        'dt.AcceptChanges()

        If Windows.Forms.MessageBox.Show("정말 업로드 하시겠습니까?", "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        ' * [Assign Database] 
        Dim getName As Qportals.ComputerInfo = New Qportals.ComputerInfo
        Dim strCompany As String, strPjt As String, strGrp As String
        Dim strMod As String, strStep As String, strLeader As String
        Dim delcnt As Integer = 0
        Dim addcnt As Integer = 0
        Dim modicnt As Integer = 0

        '* 이름을 가지고 회사명을 가져옵니다.
        strLeader = getName.getUserName()
        'Dim dt_comp As DataTable = dbc.GetContacts(strLeader)

        strCompany = NotUesFAS_System.f._company  ' 업체
        strPjt = If(txtProin.Text = "", "", txtProin.Text) : strPjt = remove_quarter(strPjt)
        strGrp = If(txtGroupin.Text = "", "", txtGroupin.Text) : strGrp = remove_quarter(strGrp)
        strMod = If(txtModelin.Text = "", "", txtModelin.Text) : strMod = remove_quarter(strMod)
        strStep = If(txtStepin.Text = "", "", txtStepin.Text) : strStep = remove_quarter(strStep)


        ' * 실제 DB에 올리는 코드입니다.
        Dim chkErrA As Boolean = False

        ' 각 각 상태에 따라 Datatable에 담음.
        Dim dtDel As DataTable = dt.GetChanges(DataRowState.Deleted)
        Dim dtAdd As DataTable = dt.GetChanges(DataRowState.Added)
        Dim dtModi As DataTable = dt.GetChanges(DataRowState.Modified)

        If Not (dtDel Is Nothing) Then
            For Each dr As DataRow In dtDel.Rows
                ' 삭제 된 행이라면?
                If (dr.RowState = DataRowState.Deleted) Then
                    Dim beforeValue As Object = Nothing
                    beforeValue = dr(0, DataRowVersion.Original)
                    ' DELETE 구문
                    Dim sql_del As String = "delete from td_defect.`assign_testcase` where id = " & beforeValue
                    chkErrA = dbc.Query_to_Mysql(sql_del)
                    delcnt += 1
                End If
            Next
        End If

        If Not (dtAdd Is Nothing) Then
            For Each dr As DataRow In dtAdd.Rows
                ' 추가 된 행이라면?
                If (dr.RowState = DataRowState.Added) Then
                    Dim strCate As String = remove_quarter(dr.Item("Category").ToString)
                    Dim strType As String = remove_quarter(dr.Item("TCType").ToString)
                    Dim strItem As String = remove_quarter(dr.Item("TestItem").ToString)

                    Dim strTester As String = remove_quarter(dr.Item("Tester").ToString)
                    Dim intLevel As Integer = remove_quarter(Convert.ToInt32(dr.Item("scorelevel").ToString))
                    Dim strCom As String = NotUesFAS_System.f._company
                    Dim strMajor As String = remove_quarter(dr.Item("주특기").ToString)

                    ' insert 구문
                    Dim sql_add As String
                    Dim seq As Integer = If(txtseq.Text.ToString = "", 0, txtseq.Text.ToString)
                    sql_add = "insert into td_defect.`assign_testcase` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `Tester`, `주특기`, `scorelevel`, `company`, `랭킹`) values "
                    sql_add += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', {10}, '{11}', '{12}' , {13})",
                    strPjt, strGrp, strMod, strStep, CDate(txtStartin.Text.ToString()).ToString("yyyy-MM-dd HH:mm:ss"), CDate(txtEndin.Text.ToString).ToString("yyyy-MM-dd HH:mm:ss"), strCate, strType, strItem, strTester, strMajor, intLevel, strCom, seq)

                    chkErrA = dbc.Query_to_Mysql(sql_add)
                    addcnt += 1

                End If
            Next
        End If

        If Not (dtModi Is Nothing) Then

            For Each dr As DataRow In dtModi.Rows
                ' 수정 된 행이라면?
                If (dr.RowState = DataRowState.Modified) Then
                    Dim strCate As String = remove_quarter(dr.Item("Category").ToString)
                    Dim strType As String = remove_quarter(dr.Item("TCType").ToString)
                    Dim strItem As String = remove_quarter(dr.Item("TestItem").ToString)

                    Dim strTester As String = remove_quarter(dr.Item("Tester").ToString)
                    Dim strCom As String = NotUesFAS_System.f._company
                    Dim strMajor As String = remove_quarter(dr.Item("주특기").ToString)

                    Dim intLevel As Integer = remove_quarter(Convert.ToInt32(dr.Item("scorelevel").ToString))

                    ' update 구문
                    Dim sql_modi As String
                    sql_modi = String.Format("update td_defect.`assign_testcase` set `Category` = '{0}', `TCtype` = '{1}', `TestItem` = '{2}', `Tester` = '{3}', `주특기` = '{6}', `company` = '{4}', `scorelevel` = {6} where id = {5}",
                                        strCate, strType, strItem, strTester, strCom, dr.Item("ID"), intLevel, strMajor)

                    chkErrA = dbc.Query_to_Mysql(sql_modi)
                    modicnt += 1
                End If
            Next

        End If

        'Dim cmment As String = String.Format(
        '"정상적으로 F/W가 수정되었습니다.
        '추가 : {0} 건
        '수정 : {1} 건
        '삭제 : {2} 건
        '---------------------------------
        '{3} 기준", addcnt, modicnt, delcnt, Now())
        Dim cmment As String = String.Format(
        "정상적으로 F/W가 수정되었습니다.
        ---------------------------------
        {0} 기준", Now())

        Qportals.Debugging.Show(cmment)
        refresh_table()
        PictureBox2_Click(sender, e)

        dt.AcceptChanges()


    End Sub
    Private Sub refresh_table()

        Dim sql As String
        Dim dt As DataTable = New DataTable
        ' 테스트케이스들을 불러옴.
        sql = String.Format("select ID, `Category`, `TCtype`, `TestItem`, `Tester`, `주특기`, `scorelevel` from td_defect.`assign_testcase` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}' ",
                         txtProin.Text.ToString, txtGroupin.Text.ToString, txtModelin.Text.ToString, txtStepin.Text.ToString)

        dt = dbc.Mysql_to_datatable(sql)
        If Not (dt Is Nothing) And (dt.Rows.Count > 0) Then

            '역량레벨넣기(dt, "Tester")
            DataGridView1.DataSource = dt
            DataGridView1.Columns(3).Width = 300
            DataGridView1.Columns("ID").Visible = False

        End If

    End Sub


    Private Sub Load_AverageScore_PreStep()
        '// 이전차수의 평균 역량을 구하여 TreeListView2에 출력 해주는 부분
        Dim sql As String
        If (_preStep <> "") Then
            sql = String.Format("select Category, TCtype, TestItem, round(avg(scorelevel)) as average from td_defect.`assign_testcase` _
                                    where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}'
                                        Group by Project, GroupName, Model, Step, Category, TCtype, TestItem ",
                        txtProin.Text, txtGroupin.Text, txtModelin.Text, _preStep)
            _dtPre = dbc.Mysql_to_datatable(sql)
            If Not _dtPre Is Nothing Then
                trv.Make_Node_Project(_dtPre, TreeListView2, True)
                looptest_AvgColor(TreeListView2.Nodes)
            End If
        End If
    End Sub

#End Region





#Region "차트 만들기 코드"
    '// 차트 만들기 관련 코드

    Private Sub 차트만들기(sender As Object, e As DataGridViewCellEventArgs) ' Handles DataGridView1.CellClick

        Try  '// 예외처리 : 빈공간 눌렀을 때 이벤트 발생 하지 않도록.
            '// TestItem이 없거나
            '// 했을 때는 프로그램을 빠져나간다.
            '// 그리고 TCtype부분이 만약 Random이면 Combobox로 바꿔주어야 한다.
            If (DataGridView1.Item(4, e.RowIndex).Value.ToString() = "") Or (DataGridView1.Item(3, e.RowIndex).Value.ToString() = "") Then

                Exit Sub
            End If
        Catch ex As Exception

        End Try

        '// 이름이 없으면 띄워주지 않게 함
        Dim _User As String = DataGridView1.Item(4, e.RowIndex).Value.ToString()
        If (_User = "") Then Exit Sub


        Dim lst As Qportals.Controls.ListViewMaker = New Qportals.Controls.ListViewMaker

        Dim dt_comp As DataTable = New DataTable
        Try
            dt_comp = dbc.GetContacts(_User)
        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try
        Dim sql As String, _Item As String
        Dim openPopup As New FW_CHART

        ' 토글옵션 ( 항상띄우기가 꺼져있으면 ) 
        If ToggleSwitch1.Checked = True Then

            If Not (DataGridView1.RowCount = 0) Then

                ' 이름을 선택 했다면 
                If e.ColumnIndex = 4 Then

                    _User = DataGridView1.Item(4, e.RowIndex).Value.ToString()

                    sql = "select `Category`, `TCType`, `TestItem`, Count(*) as `진행횟수` from td_defect.`assign_testcase` where Tester = '" & _User & "'"
                    sql += " Group by `Category`, `TCType`, `TestItem`"
                    sql += " Order by `Category`, `TCType`, `TestItem`, `진행횟수` desc"

                    _cht_dt = dbc.Mysql_to_datatable(sql)


                    If _cht_dt.Rows.Count > 0 Then
                        Show_chart("진행횟수", dt_comp)
                        'show_pre_score(e)
                    End If

                    ' 아이템을 선택 했다면
                ElseIf e.ColumnIndex = 3 Then

                    _User = DataGridView1.Item(4, e.RowIndex).Value.ToString()
                    _Item = DataGridView1.Item(3, e.RowIndex).Value.ToString()

                    sql = String.Format("
                    SELECT TestItem, Tester, company,  COUNT(*) AS `진행횟수` FROM td_defect.`assign_testcase` 
                    WHERE TestItem LIKE '{0}%' AND Tester IS NOT NULL AND NOT Tester = ''
                    GROUP BY Tester
                    ORDER BY `진행횟수` DESC", _Item)
                    _cht_dt = dbc.Mysql_to_datatable(sql)

                    If _cht_dt.Rows.Count > 0 Then
                        Show_chart("Tester", _cht_dt)
                    End If

                End If

            End If

        End If

    End Sub
    ''' <summary>
    ''' 컬럼명과 함께 Chart Data를 넣어주면
    ''' 자동으로 Chart를 띄워주는 폼을 띄우는 코드
    ''' </summary>
    ''' <param name="_column"></param>
    ''' <param name="_dt_comp"></param>
    ''' <returns></returns>
    Public Function Show_chart(ByRef _column As String, _dt_comp As DataTable) As FW_CHART
        Show_chart = New FW_CHART With {._cht_data = _dt_comp}

        If (_column = "Tester") Then
            Show_chart.GroupBox1.Visible = False
        Else
            Show_chart.GroupBox1.Visible = True
        End If

        If (_dt_comp.Rows.Count > 0) Then
            Show_chart.txtCnt.Text = 3
            Show_chart.Label1.Text = "검증원 : " & If(_dt_comp.Rows(0)("Tester").ToString = "", "", _dt_comp.Rows(0)("Tester").ToString)
            Show_chart.Label2.Text = "업체명 : " & If(_company = "Test E&C", "Test E&&C", _company)
            Show_chart.Label3.Text = "QM 경력 : " & "-"
            Show_chart.Label4.Text = "역량 : " & "-"

            ' ListView 생성 및 설정
            'Dim vList As List(Of Integer) = New List(Of Integer)

            lst.BuildList(Show_chart.ListView1, Show_chart._cht_data, New Integer() {0, 1, 2, 3, 4})
            Show_chart.ListView1.FullRowSelect = True
            Show_chart.ListView1.View = View.Details
            Show_chart.ListView1.Columns(0).Width = 100
            Show_chart.ListView1.Columns(1).Width = 100
            Show_chart.ListView1.Columns(2).Width = 300
            Show_chart.ListView1.Columns(3).Width = 80



            Dim cht As Chart = Show_chart.Chart1
            cht.DataSource = Show_chart._cht_data
            '.Chart1.DataSource = dt
            Dim ch As System.Collections.Generic.List(Of Series) = New System.Collections.Generic.List(Of Series)

            ' 값이 0인거는 표시 안해줄려고
            If Show_chart.Chart1.Series.Count > 0 Then
                For i As Integer = 0 To Show_chart.Chart1.Series.Count - 1
                    Show_chart.Chart1.Series.RemoveAt(0)
                Next
            End If

            makeChartMan(cht, _column, CInt(Show_chart.txtCnt.Text))

            cht.Width = 631
            Show_chart.TopMost = True

            '// 중복실행 방지
            Dim isitDup As Boolean = False
            For Each frm As Form In Forms.Application.OpenForms
                If frm.Name = "MemberDialog1" Then
                    frm.Activate()
                    isitDup = True
                End If
            Next
            If isitDup = False Then Show_chart.Show()

        Else
            ' ListView 생성 및 설정
            lst.BuildList(Show_chart.ListView1, Show_chart._cht_data, New Integer() {0, 1, 2, 3, 4})
            Show_chart.ListView1.FullRowSelect = True
            Show_chart.ListView1.View = View.Details
            Show_chart.ListView1.Columns(0).Width = 300
            Show_chart.ListView1.Columns(1).Width = 100
            Show_chart.ListView1.Columns(2).Width = 100
            Show_chart.ListView1.Columns(3).Width = 100

            Dim cht As Chart = Show_chart.Chart1
            cht.DataSource = Show_chart._cht_data
            '.Chart1.DataSource = dt
            Dim ch As System.Collections.Generic.List(Of Series) = New System.Collections.Generic.List(Of Series)

            ' 값이 0인거는 표시 안해줄려고
            If Show_chart.Chart1.Series.Count > 0 Then
                For i As Integer = 0 To Show_chart.Chart1.Series.Count - 1
                    Show_chart.Chart1.Series.RemoveAt(0)
                Next
            End If

            makeChartMan(cht, _column, CInt(If(Show_chart.txtCnt.Text = "", 0, Show_chart.txtCnt.Text)))

            cht.Width = 631
            Show_chart.TopMost = True

            '// 중복실행 방지
            Dim isitDup As Boolean = False
            For Each frm As Form In Forms.Application.OpenForms
                If frm.Name = "MemberDialog1" Then
                    frm.Activate()
                    isitDup = True
                End If
            Next
            If isitDup = False Then Show_chart.Show()



        End If



    End Function
    Private Sub makeChartMan(ByRef Chart1 As Chart, ByRef SeriesName As String, ByRef SeriesCount As Integer)

        Dim cht As Chart = Chart1
        'cht.DataSource = _cht_data
        'Chart1.DataSource = dt
        Dim ch As System.Collections.Generic.List(Of Series) = New System.Collections.Generic.List(Of Series)

        ' 값이 0인거는 표시 안해줄려고
        If cht.Series.Count > 0 Then
            For i As Integer = 0 To cht.Series.Count - 1
                cht.Series.RemoveAt(0)
            Next
        End If

        ' 하단 범례 추가
        With cht.Series
            ch.Add(.Add(SeriesName))
        End With

        cht.Width = 631

        ' 차트영역을 지정합니다.
        Dim ca1 As ChartArea = Chart1.ChartAreas(0)
        Dim sr0 As Series = cht.Series(SeriesName)

        ' 차트 영역에 Grid 모눈을 해제 합니다.
        ca1.AxisX.MajorGrid.Enabled = False
        ca1.AxisY.MajorGrid.Enabled = False

        ' 표 간격을 조정 할 값
        Dim interval As Double = 1D

        ' 표 간격 지정
        ca1.AxisX.Interval = 1

        ' 차트의 타입을 막대 타입으로 바꿉니다.
        cht.Series(SeriesName).ChartType = SeriesChartType.StackedColumn
        cht.Series(SeriesName).IsValueShownAsLabel = True

        ' x축의 Font를 바꿉니다.
        ca1.AxisX.LabelStyle.Font = New Font("맑은 고딕", 7)
        ca1.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont
        ca1.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont

        'ca1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 2.25F, System.Drawing.FontStyle.Bold)
        ca1.AxisY.LabelStyle.Font = New System.Drawing.Font("맑은 고딕", 7, System.Drawing.FontStyle.Bold)

        ' 차트 데이터 값을 넣어줍니다.
        ' 차트 보여주기 갯수가 3개보다 작을 때는 원래 data갯수 대로 표기하고
        ' 차트 데이터가 차트 보여주기 갯수보다 작을 때는 차트 보여주기 갯수로 보여준다.
        If CInt(SeriesCount) > TryCast(cht.DataSource, DataTable).Rows.Count - 1 Then

            If (SeriesName = "Tester") Then
                For i As Integer = 0 To TryCast(cht.DataSource, DataTable).Rows.Count - 1
                    cht.Series(SeriesName).Points.AddXY(CStr(TryCast(cht.DataSource, DataTable).Rows(i)("Tester").ToString), CInt(TryCast(cht.DataSource, DataTable).Rows(i)("진행횟수").ToString))
                Next
            Else
                For i As Integer = 0 To TryCast(cht.DataSource, DataTable).Rows.Count - 1
                    cht.Series(SeriesName).Points.AddXY(CStr(TryCast(cht.DataSource, DataTable).Rows(i)("TestItem").ToString), CInt(TryCast(cht.DataSource, DataTable).Rows(i)("진행횟수").ToString))
                Next
            End If


        Else
            If (SeriesName = "Tester") Then
                '// Tester 기준의 차트이므로 Tester 기준으로 Data 뿌림
                For i As Integer = 0 To CInt(SeriesCount) - 1
                    cht.Series(SeriesName).Points.AddXY(CStr(TryCast(cht.DataSource, DataTable).Rows(i)("Tester").ToString), CInt(TryCast(cht.DataSource, DataTable).Rows(i)("진행횟수").ToString))
                Next
            Else
                '// TestItem 기준의 차트이므로 TestItem 기준으로 Data 뿌림
                For i As Integer = 0 To CInt(SeriesCount) - 1
                    cht.Series(SeriesName).Points.AddXY(CStr(TryCast(cht.DataSource, DataTable).Rows(i)("TestItem").ToString), CInt(TryCast(cht.DataSource, DataTable).Rows(i)("진행횟수").ToString))
                Next
            End If


        End If





        cht.Width = 631

    End Sub
#End Region


    Private Function remove_quarter(ByRef strText As String)
        strText = Replace(strText, "'", "")
        Return strText
    End Function

    Private Function CheckFillInfo() As Boolean
        Dim chkExit As Boolean = False
        Dim chkLists As List(Of Control) = New List(Of Control) From {
            txtProin, txtGroupin, txtModelin, txtStepin, txtStartin, txtEndin
        }
        Dim cnt As Integer = chkLists.Where(Function(x) x.Text = "").Count

        Return If(cnt > 0, True, False)

    End Function


#Region "역량 관련 코드"
    Private Function 역량(ByRef 이름 As String) As Double
        Dim dvalue As Double = 0.0

        Try
            For Each dr As DataRow In _dtlevel.Rows
                ' COUNT 해보기
                Dim temp_name As String = 이름.Split("(")(0).Trim
                If dr.Item("이름").ToString = temp_name And Not 이름 = "" Then
                    dvalue = CDbl(dr.Item("역량"))
                    Exit For
                Else
                    dvalue = 0.0
                End If
            Next
        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try

        Return If(dvalue = 0.0, 0.0, dvalue)
    End Function

    Private Function 역량가져오기() As DataTable
        Dim dc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
        Dim sql As String = "select * from td_defect.`leveldb` "
        Try
            _dtlevel = dc.Mysql_to_datatable(sql)
        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try
        Return If(_dtlevel Is Nothing, Nothing, _dtlevel)
    End Function

    Private Sub 역량레벨넣기(ByRef dt As DataTable, Optional ByRef columnName As String = "협력사")
        Dim fndText As String = ""
        Dim dvalue As Double = 0.0

        If dt.Columns.Contains("역량") = False Then
            dt.Columns.Add("역량", GetType(Double))
        End If

        _dtlevel = 역량가져오기()

        If Not (_dtlevel Is Nothing) And Not (dt Is Nothing) AndAlso (dt.Rows.Count > 0) Then

            Try
                For Each dr As DataRow In dt.Rows   ' 역량칸이 비워져있는 메인
                    ' 동일한 이름이 있는 경우 역량 값 넣어줍니다.

                    dvalue = 역량(dr.Item(columnName).ToString) ' 이름


                    dr.Item("역량") = dvalue
                Next
            Catch ex As Exception
                Qportals.Debugging.Show(ex.Message)
            End Try

        Else

        End If

    End Sub
#End Region

#Region "텍스트박스에 숫자만입력 되도록"
    Private Sub txtBoxOnlyNumeric(sender As Object, e As KeyPressEventArgs) Handles txtHigh.KeyPress, txtMiddle.KeyPress, txtLow.KeyPress
        ' IsDisit : 숫자 인지? 
        ' e.Handled = True (Handeled가 True이면 이벤트가 처리 되었다는 표시이므로, 아래 키 외에는 넘긴다.)
        '실수만 입력받기 
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back) Or e.KeyChar = ".") Then
            e.Handled = True

        End If
    End Sub
#End Region

#Region "트리뷰 관련 반복 코드"
    Public Sub looptest(nodes As TreeListNodeCollection)
        '// TreeListView1
        For Each node As TreeListNode In nodes
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


                    'If (node.SubItems.Count > 1) Then
                    '    If (level >= CDbl(txtHigh.Text)) Then ' 역량이 4.0 이상이면?
                    '        ' 녹색 계열
                    '        node.BackColor = Color.FromArgb(179, 255, 179)
                    '    ElseIf (CDbl(Val(node.SubItems.Item(1).Text)) >= CDbl(txtMiddle.Text)) Then
                    '        '노란 계열
                    '        node.BackColor = Color.FromArgb(255, 231, 155)
                    '    ElseIf (CDbl(Val(node.SubItems.Item(1).Text)) >= CDbl(txtLow.Text)) Then
                    '        ' 레드 계열
                    '        node.BackColor = Color.FromArgb(255, 159, 159)
                    '    Else
                    '        node.BackColor = Color.White
                    '    End If
                    'End If
                End If
            End If
            looptest(node.Nodes)
        Next
    End Sub

    Public Sub looptest_AvgColor(nodes As TreeListNodeCollection)
        'TreeListView2
        For Each node As TreeListNode In nodes
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


                        'If (CDbl(Val(node.SubItems.Item(0).Text)) >= CDbl(txtHigh.Text)) Then ' 역량이 4.0 이상이면?
                        '    ' 녹색 계열
                        '    node.BackColor = Color.FromArgb(179, 255, 179)
                        'ElseIf (CDbl(Val(node.SubItems.Item(0).Text)) >= CDbl(txtMiddle.Text)) Then
                        '    '노란 계열
                        '    node.BackColor = Color.FromArgb(255, 231, 155)
                        'ElseIf (CDbl(Val(node.SubItems.Item(0).Text)) >= CDbl(txtLow.Text)) Then
                        '    ' 레드 계열
                        '    node.BackColor = Color.FromArgb(255, 159, 159)
                        'Else
                        '    node.BackColor = Color.White
                        'End If
                    End If
                End If
            End If
            looptest_AvgColor(node.Nodes)
        Next
    End Sub
#End Region

    Private Sub textboxChange(sender As Object, e As EventArgs) Handles txtHigh.TextChanged, txtMiddle.TextChanged, txtLow.TextChanged
        '// 역량 표를 점수에 맞게 변경 하도록
        looptest(TreeListView1.Nodes)

    End Sub

    Private Sub Assign_Main_Panel_Click(sender As Object, e As EventArgs) Handles Panel4.MouseClick
        '// Setting Panel 보여주기.
        Setting_pnael.Visible = False

    End Sub

    Private Sub Btn_addrow_Click(sender As Object, e As EventArgs) Handles btn_addrow.Click
        '// 행 삽입 버튼 클릭 시 행 삽입 되도록 
        DataGridViewAddRow(DataGridView1)

    End Sub

    Private Sub DataGridViewAddRow(ByRef dgv As DataGridView)
        '// 행 삽입하는 기능
        Dim rowValues As List(Of Object) = New List(Of Object)  '// 행을 담을 Object 형 List를 선언

        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)  '// 아래 데이터뷰의 내용을 가져 와 dt에 담음

        Try
            ' 삭제할 로우를 선택 했을 때만
            If (dgv.SelectedRows.Count > 0) Then

                For i As Integer = 0 To dgv.ColumnCount - 1
                    If i = 0 Then
                        rowValues.Add(CInt(dgv.Item(i, dgv.CurrentCell.RowIndex).Value))
                    Else
                        rowValues.Add(dgv.Item(i, dgv.CurrentCell.RowIndex).Value)
                    End If

                Next

                Dim dr As DataRow = dt.NewRow

                dr.ItemArray = rowValues.ToArray

                dt.Rows.InsertAt(dr, dgv.CurrentCell.RowIndex)
                'dt.Rows.Add(rowValues.ToArray)
                'dt.Rows.InsertAt(, dgv.CurrentCell.RowIndex)
                'dgv.Rows.Insert(dgv.CurrentCell.RowIndex, rowValues.ToArray)

            End If

            dgv.DataSource = dt

        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try



    End Sub

#Region "사용 안함"
    Private Sub makeSeries(ByRef cht As Chart, ByRef dt As DataTable)
        ' 차트 데이터 값을 넣어줍니다.
        For i As Integer = 0 To dt.Rows.Count - 1
            cht.Series("진행횟수").Points.AddXY(CStr(dt.Rows(i)(2).ToString), CInt(dt.Rows(i)(3).ToString))
        Next
    End Sub

    Private Function getPreStep_returnDt() As DataTable
        Dim sql As String
        sql = String.Format("
                    select * from (
                                    select `Project`, `GroupName`, `Model`, `Step`, ROW_NUMBER() OVER(ORDER BY STEP) AS 랭킹
                                    from td_defect.`assign_testcase`
                                    where Project = '{0}' and GroupName = '{1}' and Model = '{2}'
                                    order by Step
                                    ) T1
                    WHERE 랭킹 = (
                                    select 랭킹 from (
                                                        select `Project`, `GroupName`, `Model`, `Step`, ROW_NUMBER() OVER(ORDER BY Step) as 랭킹
                                                        from td_defect.`assign_testcase` 
                                                        where Project = '{0}' and GroupName = '{1}' and Model = '{2}'
                                                        order by Step
                                                    ) T2
                                    where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step ='{3}'
                                    LIMIT 1
                                    ) -1
                        ", txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)
        Dim dtPre As DataTable = New DataTable
        dtPre = dbc.Mysql_to_datatable(sql)

        Return If(dtPre Is Nothing, Nothing, dtPre)

    End Function
    Private Sub ChangeCellasCombobox()
        '// DataGridView
        '// 할당 리스트를 반복하여 랜덤인 경우에는 무조건
        '// Comobox를 선택하도록 하는 코드

        Dim i As Integer

        Dim _dgv As DataGridView = DataGridView1
        For Each dgRow As DataGridViewRow In _dgv.Rows

            If Not dgRow.Cells("TCType").Value Is Nothing Then

                '// 기존 combobox 셀이 아닌 것만 
                If dgRow.Cells("TestItem").GetType() <> GetType(DataGridViewComboBoxCell) Then

                    If dgRow.Cells("TCType").Value.ToString Like "*Random*" And dgRow.Cells("TestItem").Value.ToString = "" Then
                        Dim dgCell As New DataGridViewComboBoxCell
                        If Not dgCell Is Nothing Then
                            dgCell.Items.Add("Application")
                            dgCell.Items.Add("Device")
                            dgCell.Items.Add("Multimedia")
                            dgCell.Items.Add("Telephony")

                            dgRow.Cells("TestItem") = dgCell

                        End If

                    End If

                End If

            End If

        Next

    End Sub



    Private Sub Btn_open_Click(sender As Object, e As EventArgs) Handles btn_open.Click

        Dim point As Drawing.Point

        'With Framework_Assign_System.f

        '    'If (.Width) = 1249 Then
        '    '    point = New Drawing.Point(916, .Height)
        '    'Else
        '    '    point = New Drawing.Point(1249, .Height)
        '    'End If

        '    '.Size = point

        'End With

    End Sub
    Private _trv As TreeListView
    Private Sub import_assignMember()
        '// 매번 하지 않도록 아예 처음 프로젝트 선택 시 불러오도록 할 예정
        Dim checkValue As List(Of String) = New List(Of String) From {txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text}
        Dim cnt As Integer = checkValue.Where(Function(x) x = "" Or x Like "*선택*").Count

        If (cnt > 0) Then
            Exit Sub
        End If

        Dim sql As String, sql2 As String
        'sql = String.Format("select Company, Tester, (select level from td_defect.`assign_member` where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}'  ",
        'txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)
        Dim com_dt As DataTable
        com_dt = import_Member("조지훈")


        sql = String.Format(
            "SELECT 
	            mem.Company AS 업체명, 
	            mem.Part AS Part, 
	            mem.Tester AS 이름, 	            
	            mem.주특기 AS 주특기,                         
            IF((SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.Tester) IS NULL,0,
                (SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.Tester)) AS LEVEL 
            FROM td_defect.`assign_member` mem
            where Project = '{0}' and GroupName = '{1}' and Model = '{2}' and Step = '{3}'  ",
            txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)

        Dim dt As DataTable
        dt = dbc.Mysql_to_datatable(sql)

        '        Dim temp1 As DataTable
        '        Dim temp2 As DataTable
        '        temp1 = com_dt
        '        temp2 = dt

        '        If Not temp1 Is Nothing AndAlso Not temp2 Is Nothing Then

        '            If temp1.Rows.Count > 0 And temp2.Rows.Count > 0 Then
        '                Dim query = temp1.AsEnumerable.Where(
        '    Function(dt1) temp2.AsEnumerable().Any(
        '                                         Function(dt2) _
        '                                             dt1("Part") = dt2("Part")
        ')).CopyToDataTable()
        '            End If

        '        End If



        'Dim query2 = com_dt.AsEnumerable.Where(
        '    Function(dt1) Not dt.AsEnumerable().Any(
        '                                         Function(dt2) _
        '                                             dt1("Part") = dt2("Part")
        ')).CopyToDataTable()




        If Not (dt Is Nothing) Then
            _trv = trv_member
            _trv.Columns.Clear()
            _trv.Columns.Add("업체명", 100, Windows.Forms.HorizontalAlignment.Center)
            _trv.Columns.Add("주특기", 100, Windows.Forms.HorizontalAlignment.Center)
            _trv.Columns.Add("level", 60, Windows.Forms.HorizontalAlignment.Left)
            With _trv
                .MultiSelect = False
                .FullRowSelect = True
                .Columns.Item(0).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
                .Columns.Item(0).ForeColor = Color.Blue
                '.Columns.Item(0).Width = 200
                .Columns.Item(1).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
                .Columns.Item(1).ForeColor = Color.Black


            End With
            _trv.CheckBoxes = True
            trv._trv = _trv
            trv.Make_Node_Member(dt, _trv, True)
            SetColor_level(_trv.Nodes)

            If _trv.Nodes.Count <= 0 Then
                btn_open.PerformClick()
            Else
                btn_open.PerformClick()
            End If


        End If

    End Sub
    Private Function import_Member(ByRef _user As String) As DataTable
        Dim _tempDt As DataTable = New DataTable
        Dim _comDT As DataTable
        Dim sql As String
        Try
            If Not (_user = "") Then
                sql = String.Format("SELECT 
	                        mem.업체명 AS 업체명, 
	                        mem.Part AS Part, 
	                        mem.이름 AS 이름, 
	                        mem.직급 AS 직급, 
	                        mem.주특기 AS 주특기,                         
                        IF((SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.이름) IS NULL,0,
                            (SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.이름)) AS LEVEL 
                        FROM td_defect.`mem_info` mem
                        WHERE 
                            mem.이름 = '{0}'", _user)
                _tempDt = New DataTable
                _tempDt = dbc.Mysql_to_datatable(sql)

                If Not (_tempDt Is Nothing) And (_tempDt.Rows.Count > 0) Then

                    Dim part As String = _tempDt.Rows(0)("Part").ToString()
                    sql = String.Format("SELECT 
	                        mem.업체명 AS 업체명, 
	                        mem.Part AS Part, 
	                        mem.이름 AS 이름, 
	                        mem.직급 AS 직급, 
	                        mem.주특기 AS 주특기,                         
                        IF((SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.이름) IS NULL,0,
                            (SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.이름)) AS LEVEL 
                        FROM td_defect.`mem_info` mem
                        WHERE 
                            mem.Part = '{0}'", part)
                    _tempDt = New DataTable
                    _tempDt = dbc.Mysql_to_datatable(sql)


                End If
            End If
        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try

        _comDT = _tempDt

        Return If(_comDT, Nothing)
    End Function
    Public Sub SetColor_level(nodes As TreeListNodeCollection)
        Dim trvFullPath() As String

        For Each node As TreeListNode In nodes
            trvFullPath = node.FullPath.Split("\")

            If (trvFullPath.Length = 3) Then
                '// Fun) Application

                If node.SubItems.Count > 0 Then
                    '// Function / Fun) Application / GMS_Chrome / 5 
                    node.SubItems.Item(0).ForeColor = Color.Red


                    Select Case Convert.ToInt32(node.SubItems.Item(1).ToString)
                        Case Is >= 4   '// Green
                            node.BackColor = Color.FromArgb(179, 255, 179)
                        Case Is >= 3    '// Yello
                            node.BackColor = Color.FromArgb(255, 231, 155)
                        Case < 3    '// 
                            node.BackColor = Color.FromArgb(255, 159, 159)
                    End Select

                End If

                SetColor_level(node.Nodes)

            End If
            SetColor_level(node.Nodes)
        Next
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        import_assignMember()
    End Sub

    Private Sub TreeListView2_BeforeSelect(sender As Object, e As ContainerListViewCancelEventArgs) Handles TreeListView2.BeforeSelect
    End Sub




#End Region




End Class

