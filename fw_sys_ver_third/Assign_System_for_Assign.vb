Public Class Assign_System_for_Assign
    Private cdb As c_db.assign_mem = New c_db.assign_mem

    Private main_pjtinfo As FAS_select_project
    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class

    Private _pjt As String : Private _grp As String : Private _mod As String : Private _step As String
    Private _startdate As String : Private _enddate As String

    Private _seq As String
    Private _company As String

    Private _dgv As DataGridView
    Private _trv As WinControls.ListView.TreeListView
    Private _trv2 As WinControls.ListView.TreeListView
    Private _trv_level As WinControls.ListView.TreeListView

    Property _getDGV As DataGridView
        Get
            Return _dgv
        End Get
        Set(value As DataGridView)
            value = _dgv
        End Set
    End Property

    Public Sub New()

    End Sub

    ''' <summary>
    ''' FW Assign 기능에 필요한 기본 pjt정보 담기, 
    ''' </summary>
    ''' <param name="_dgv">DataGridView는 반드시 할당을 해야 합니다. </param>
    Public Sub New(ByRef _dgv As DataGridView)
        'main_pjtinfo = New FAS_select_project

        _pjt = FAS_select_project.f._pjt
        _grp = FAS_select_project.f._grp
        _mod = FAS_select_project.f._model
        _step = FAS_select_project.f._step

        _startdate = FAS_select_project.f._startdate
        _enddate = FAS_select_project.f._enddate
        _seq = FAS_select_project.f._seq

        _company = FAS_select_project.f._company

        Me._dgv = _dgv

    End Sub
    Public Sub New(ByRef _dgv As DataGridView, ByRef _trv() As WinControls.ListView.TreeListView)

        _pjt = FAS_select_project.f._pjt
        _grp = FAS_select_project.f._grp
        _mod = FAS_select_project.f._model
        _step = FAS_select_project.f._step

        _startdate = FAS_select_project.f._startdate
        _enddate = FAS_select_project.f._enddate
        _seq = FAS_select_project.f._seq

        _company = FAS_select_project.f._company

        Me._dgv = _dgv
        Me._trv = _trv(0)
        Me._trv2 = _trv(1)
        Me._trv_level = _trv(2)

    End Sub




#Region "FW 등록"
    Private _toolTip1 As ToolTip
    Public Property tooltip As ToolTip
    ''' <summary>
    ''' control에 원하는 문자열 툴팁을 만드는 함수 입니다.
    ''' 사용 전 tooltip 이라는 멤버변수를 해당 클래스에 데이터를 넣었는지 확인 후 사용 바랍니다.
    ''' </summary>
    ''' <param name="control"> 툴팁 컨트롤을 넣습니다. </param>
    ''' <param name="cmt">멘트를 넣습니다.</param>
    Public Sub ToolTipSetting(ByRef control As Control, ByRef cmt As String)
        _toolTip1 = New ToolTip
        With _toolTip1
            .SetToolTip(control, cmt)
            .InitialDelay = 500 : .AutoPopDelay = 2000 : .ReshowDelay = 500
        End With

    End Sub
    ''' <summary>
    ''' DataGridView Settings
    ''' 
    ''' </summary>
    Public Sub main()

        With _dgv
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AllowUserToOrderColumns = True ' 유저가 맘대로 바꾸고 싶을 때
            .DefaultCellStyle.SelectionBackColor = Color.White  ' 선택 했을 때 back color
            .DefaultCellStyle.SelectionForeColor = Color.Black   ' 선택 했을 때 글씨 color
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255) ' 열의 색상 지정
            '열과 행의 경계선 스타일 지정
            .EnableHeadersVisualStyles = False
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            '열에 보여지는 문자열을 여러행으로 보여주고 싶을 때
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True

            ' 행 사이즈 자동 조절 
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            '열 사이즈 자동 조절
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            '----------DataGridView--Font------------
            .DefaultCellStyle.Font = New Font("맑은 고딕", 7)
            .ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 7)
        End With

        refresh_table()




    End Sub

#Region "맨 처음 자료가 있으면 로드, 아니면 빈칸"

    Private Sub refresh_table()

        Dim sql As String
        ' 테스트케이스들을 불러옴.
        sql = "select ID,`Category`, `TCtype`, `TestItem` from " & cdb.get_assign_testcase & " "
        sql += String.Format("WHERE `Project` = '{0}' AND `GroupName`='{1}' AND `Model`='{2}' AND `Step`='{3}';",
                            _pjt, _grp, _mod, _step)
        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)
        If Not (dt Is Nothing) And (dt.Rows.Count > 0) Then
            _dgv.DataSource = dt
            _dgv.Columns("ID").Visible = False
            'Label1.Text = String.Format("총 : {0}건", DataGridView1.RowCount)
            'Qportals.Debugging.Show(String.Format("총 {0}건을 성공적으로 가져왔습니다.", DataGridView1.RowCount))
        Else
            '// 등록 된 프레임워크가 없다면
            datagridview_settings()

        End If

    End Sub

#End Region


    ''' <summary>
    ''' DataGridView의 폰트 및 컬럼 설정 지정
    ''' </summary>
    Private Sub datagridview_settings()


        '----------DataGridView----------------

        _dgv.DefaultCellStyle.Font = New Font("맑은 고딕", 7)
        _dgv.ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 7)
        '---------------------------------------
        Dim strcolumns() As String = New String() {"Category", "TCType", "TCName"}
        Dim _dtable As DataTable = New DataTable()

        '** Column을 만듭니다.-------------------
        For Each c As String In strcolumns
            _dtable.Columns.Add(New DataColumn(c))
        Next
        '** dgv에 자료를 넣어 줍니다.
        If Not (_dtable Is Nothing) Then
            _dgv.DataSource = _dtable
        End If


    End Sub

    ''' <summary>
    ''' Drag Drop 하여 얻은 Files를 입력받아 DataGridView에 올립니다.
    ''' </summary>
    ''' <param name="files"></param>
    Public Sub DragAfter_ExcelFiles(ByRef files() As String)
        Dim dtExcel As Qportals.External_library.EPPlus = New Qportals.External_library.EPPlus
        Dim dt As DataTable = New DataTable

        Select Case files.Length

            Case 1
                Dim file_extention As String = IO.Path.GetExtension(files(0))
                Dim filename As String = IO.Path.GetFileName(files(0))

                ' 파일을 드래그해서 올렸을 때 올바른 파일인지 파악 합니다.
                If Not (file_extention Like ".xl*") And Not (filename.Contains("Assign")) Then
                    Qportals.Debugging.Show("다른파일로 인식" & vbCrLf & file_extention)
                    Exit Sub
                End If

                ' 엑셀을 읽습니다.
                dt = dtExcel.ReadAllxlsm_set_datatable(files(0), "Sheet1")


                If Not (dt Is Nothing) Then
                    Dim dv As DataView
                    Try

                        dv = dt.DefaultView
                        dv.Sort = "[Category], [T/C Type] ASC"
                        dt = dv.ToTable("")

                        _dgv.DataSource = dt


                        ' ** 검색 결과를 표시 해줍니다.
                        'Label1.Text = String.Format("총 : {0} 건", DataGridView1.RowCount)


                    Catch ex As Exception
                        Qportals.Debugging.Show(ex.Message)
                    End Try

                Else
                    Qportals.Debugging.Show("자료를 올릴 엑셀문서의 시트 이름은 [Sheet1] 이어야 합니다." & vbCrLf & "Sheet이름이 맞는지 확인 하고 수정해서 올려주세요.",,, 16)
                End If

            Case Else
                Qportals.Debugging.Show("1개의 파일만 지원 합니다.", "(lee.sunbae@lgepartner.com)", Windows.MessageBoxButton.OK, Windows.Forms.MessageBoxIcon.Error)
        End Select



    End Sub

    ''' <summary>
    ''' F/W 아이템 DB UPLOAD 합니다.
    ''' </summary>
    Public Sub database_upload()
        ' ** DataGridView에 Data를 올리는 부분입니다.
        Dim DB As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class

        ' * DataGridView => DataTable 
        Dim dt As DataTable = TryCast(_dgv.DataSource, DataTable)
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
        Dim dt_comp As DataTable = dbc.GetContacts(strLeader)
        strCompany = If(dt_comp.Rows(0).Item(2).ToString = "", "업체정보없음", dt_comp.Rows(0).Item(2).ToString)  ' 업체
        strPjt = If(_pjt = "", "", _pjt) : strPjt = remove_quarter(strPjt)
        strGrp = If(_grp = "", "", _grp) : strGrp = remove_quarter(strGrp)
        strMod = If(_mod = "", "", _mod) : strMod = remove_quarter(strMod)
        strStep = If(_step = "", "", _step) : strStep = remove_quarter(strStep)


        ' 이미 있는지 카운트 할려고.
        Dim sql As String = String.Format("select * from " & cdb.get_assign_testcase & " where `Project` = '{0}' and `GroupName` = '{1}' and `Model` = '{2}' and `Step` = '{3}'",
                                            strPjt, strGrp, strMod, strStep)

        ' 위의 쿼리를 실행 합니다.
        Dim strResult As String = dbc.GetQueryResult(sql)
        Dim chkExist As Boolean = False

        ' 결과가 0이면 testcase가 없다는 것.
        chkExist = If(strResult = "0" Or strResult Is Nothing, False, True)
        If (chkExist = False) Then
            Dim assignsql As String = "insert into " & cdb.get_assign_testcase & " (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `랭킹`) values "

            Dim chk As Boolean = False
            Dim sum_sql_assign As String
            Dim strCate As String
            Dim strType As String
            Dim strItem As String
            Dim insert_count As Integer = 0
            Dim chkErrA As Boolean = False
            For Each dr As DataRow In dt.Rows
                strCate = remove_quarter(dr.Item(0).ToString)
                strType = remove_quarter(dr.Item(1).ToString)
                strItem = remove_quarter(dr.Item(2).ToString)

                insert_count += 1

                sum_sql_assign += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9} ),",
                    strPjt, strGrp, strMod, strStep, CDate(_startdate.ToString("yyyy-MM-dd HH:mm:ss")), CDate(_enddate.ToString("yyyy-MM-dd HH:mm:ss")), strCate, strType, strItem, CInt(_seq))

            Next

            ' * 추가할 게 있다면 추가쿼리 진행
            If (insert_count > 0) Then
                sum_sql_assign = sum_sql_assign.Substring(0, Len(sum_sql_assign) - 1)
                assignsql += sum_sql_assign
                chkErrA = dbc.Query_to_Mysql(assignsql)
                ' * 추가할 게 없으면 수정?  
            ElseIf (insert_count = 0) Then
                chkErrA = True
            End If


            If (chkErrA = True) Then
                Qportals.Debugging.Show("정상적으로 F/W가 수정되었습니다." & vbCrLf & insert_count & "건")
            Else
                Qportals.Debugging.Show("올바르게 올라가지 않았을 수 있습니다.")
            End If



        Else


            ' * 실제 DB에 올리는 코드입니다.

            Dim chkErrA As Boolean = False
            Dim dtDel As DataTable = dt.GetChanges(DataRowState.Deleted)
            Dim dtAdd As DataTable = dt.GetChanges(DataRowState.Added)
            Dim dtModi As DataTable = dt.GetChanges(DataRowState.Modified)

            If Not (dtDel Is Nothing) Then
                ' 삭제 한 건 DELETE
                For Each dr As DataRow In dtDel.Rows
                    If (dr.RowState = DataRowState.Deleted) Then
                        Dim beforeValue As Object = Nothing
                        beforeValue = dr(0, DataRowVersion.Original)
                        ' DELETE 구문
                        Dim sql_del As String = "delete from " & cdb.get_assign_testcase & " where id = " & beforeValue
                        chkErrA = dbc.Query_to_Mysql(sql_del)
                        delcnt += 1
                    End If
                Next
            ElseIf Not (dtAdd Is Nothing) Then
                For Each dr As DataRow In dtAdd.Rows
                    If (dr.RowState = DataRowState.Added) Then
                        Dim strCate As String = remove_quarter(dr.Item("Category").ToString)
                        Dim strType As String = remove_quarter(dr.Item("TCType").ToString)
                        Dim strItem As String = remove_quarter(dr.Item("TestItem").ToString)

                        ' insert 구문
                        Dim sql_add As String
                        sql_add = "insert into " & cdb.get_assign_testcase & " (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `랭킹`) values "
                        sql_add += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9} )",
                        strPjt, strGrp, strMod, strStep, CDate(_startdate.ToString("yyyy-MM-dd HH:mm:ss")), CDate(_enddate.ToString("yyyy-MM-dd HH:mm:ss")), strCate, strType, strItem, CInt(_seq))

                        chkErrA = dbc.Query_to_Mysql(sql_add)
                        addcnt += 1

                    End If
                Next

            ElseIf Not (dtModi Is Nothing) Then

                For Each dr As DataRow In dtModi.Rows
                    If (dr.RowState = DataRowState.Modified) Then
                        Dim strCate As String = remove_quarter(dr.Item("Category").ToString)
                        Dim strType As String = remove_quarter(dr.Item("TCType").ToString)
                        Dim strItem As String = remove_quarter(dr.Item("TestItem").ToString)

                        ' insert 구문
                        Dim sql_modi As String
                        sql_modi = String.Format("update " & cdb.get_assign_testcase & " set `Category` = '{0}', `TCtype` = '{1}', `TestItem` = '{2}' where id = {3}",
                                                strCate, strType, strItem, dr.Item("ID"))


                        chkErrA = dbc.Query_to_Mysql(sql_modi)
                        modicnt += 1
                    End If
                Next


            End If



        End If

        dt.AcceptChanges()

        Dim cmment As String = String.Format(
            "정상적으로 F/W가 수정되었습니다.
            추가 : {0} 건
            수정 : {1} 건
            삭제 : {2} 건
            ---------------------------------
            {3} 기준", addcnt, modicnt, delcnt, Now())

        Qportals.Debugging.Show(cmment)


    End Sub
    Private Function remove_quarter(ByRef strText As String)
        strText = Replace(strText, "'", "")
        Return strText
    End Function

#End Region

#Region "FW 할당"

    Public Sub __TreeListView__()
        With _trv
            .MultiSelect = False
            .FullRowSelect = True
            .Columns.Item(0).Width = 300
            .Columns.Item(0).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).ForeColor = Color.Blue
            .Columns.Item(1).TextAlign = HorizontalAlignment.Left
            .Columns.Item(2).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(3).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
        End With
        With _trv2
            .MultiSelect = False
            .FullRowSelect = True
            .Columns.Item(0).Width = 300
            .Columns.Item(0).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).ForeColor = Color.Blue
            .Columns.Item(1).TextAlign = HorizontalAlignment.Left
            .Columns.Item(2).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
        End With
        With _trv_level
            .Columns.Add("Model Name", 300, Windows.Forms.HorizontalAlignment.Center)
            .Columns.Add("level", 45, Windows.Forms.HorizontalAlignment.Center)
            .Columns.Item(0).Font = New Font("맑은 고딕", 8.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).Font = New Font("맑은 고딕", 8.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(0).ForeColor = Color.Blue
            .MultiSelect = False
            .FullRowSelect = True
        End With


    End Sub
    Public Sub __datagridView__()
        '// DataGridView 기본 설정
        With _dgv
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AllowUserToOrderColumns = True ' 유저가 맘대로 바꾸고 싶을 때
            .DefaultCellStyle.SelectionBackColor = Color.LightGray  ' 선택 했을 때 back color
            .DefaultCellStyle.SelectionForeColor = Color.Black   ' 선택 했을 때 글씨 color
            '.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(190, 216, 242) ' 열의 색상 지정
            .ColumnHeadersDefaultCellStyle.BackColor = Color.White ' 열의 색상 지정
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
            .ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 7, FontStyle.Bold Or FontStyle.Italic)
        End With

        '------------------------------------------
        Dim strcolumns() As String = New String() {"ID", "Category", "TCType", "TCName", "Tester", "PartName", "주특기", "Level", "memo"}
        '** DataGridView(하단)에 자료를 넣기 위해 DataTable을 만들었습니다.
        '** 이하 dgv 
        Dim _dtable As DataTable = New DataTable()

        '** Column을 만듭니다.---------------------
        For Each c As String In strcolumns
            _dtable.Columns.Add(New DataColumn(c))
        Next
        '** dgv에 자료를 넣어 줍니다.
        If Not (_dtable Is Nothing) Then
            _dgv.DataSource = _dtable
        End If
        '------------------------------------------

        _dgv.DataSource = _dtable
        _dgv.AllowDrop = True

    End Sub
    ''' <summary>
    ''' DataGridView의 DubbleBuffer를 켜는 Method 입니다.
    ''' dgv = 대상 dgv, setting : DoubleBuffer on/off 기준
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="setting"></param>
    Public Shadows Sub DoubleBuffered(ByVal dgv As DataGridView, ByVal setting As Boolean)
        Dim dgvType As Type = dgv.GetType
        Dim pi As Reflection.PropertyInfo =
            dgvType.GetProperty(
                "DoubleBuffered",
                    Reflection.BindingFlags.Instance Or
                    Reflection.BindingFlags.NonPublic Or
                    Reflection.BindingFlags.SetProperty)
        pi.SetValue(dgv, setting, Nothing)
    End Sub
    ''' <summary>
    ''' Load_Assign_DataGridViewData() / Load_Assign_Tlv_Fisrt_Data()
    ''' </summary>
    Public Sub _init_Assign_data()

        Load_Assign_DataGridViewData()

        Load_Assign_Tlv_Fisrt_Data()

        Load_Assign_Tlv_Second_Data()

    End Sub
    ''' <summary>
    ''' DataGridView에 Assign 내용 뿌리는 메서드
    ''' </summary>
    Private Sub Load_Assign_DataGridViewData()
        Dim sql As String

        sql = String.Format(
            "SELECT 
	            tct.ID, 
	            tct.Category, 
	            tct.TCtype, 
	            tct.TestItem, 
	            tct.Tester, 
	            (SELECT mem.주특기 FROM " & cdb.get_manage_meminfo & " mem WHERE tct.Tester = mem.이름)  AS 주특기,
	            (SELECT AVG(역량) FROM assign_mem.manage_memlevel lvdb WHERE tct.Tester = lvdb.name) AS scorelevel
            FROM " & cdb.get_assign_testcase & " tct
            WHERE 
                Project = '{0}' and 
                GroupName = '{1}' and 
                Model = '{2}' and 
                Step = '{3}';",
            _pjt, _grp, _mod, _step)
        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)

        If dt.Rows.Count > 0 Then
            _dgv.DataSource = dt
            If Not (_dgv.Columns("ID") Is Nothing) Then
                _dgv.Columns("ID").Visible = False
                _dgv.Columns("Category").Visible = False
                _dgv.Columns("TCtype").Visible = False
                _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells                '열 사이즈 자동 조절
            End If

        End If

    End Sub

    ''' <summary>
    ''' TreeListView1에 [검증원 별 역량] 내용 뿌리는 메서드
    ''' </summary>
    Private Sub Load_Assign_Tlv_Fisrt_Data()
        Dim sql As String
        Dim trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker
        ' 이 모델에 testcase 가 등록되어있는지 확인을 합니다.
        sql = "select count(*) from " & cdb.get_assign_testcase & " "
        sql += String.Format("WHERE `Project` = '{0}' AND `GroupName`='{1}' AND `Model`='{2}' AND `Step`='{3}';",
                            _pjt, _grp, _mod, _step)
        ' 위의 쿼리를 실행 합니다.
        Dim strResult As String = dbc.GetQueryResult(sql)
        Dim chk As Boolean = If(strResult = "0", False, True)

        If chk = True Then
            '// 현재 차수 
            sql = String.Format(
                "select 
                    ID, 
                    `Category`, 
                    `TCtype`, 
                    `TestItem`, 
                    `Tester`, 
                    `company`, 
                    `scorelevel` 
                from " & cdb.get_assign_testcase & " 
                where 
                    Project = '{0}' and
                    GroupName = '{1}' and 
                    Model = '{2}' and 
                    Step = '{3}' ",
                     _pjt, _grp, _mod, _step)
            Dim dtPre = dbc.Mysql_to_datatable(sql)
            dtPre = dtPre.DefaultView.ToTable(False, "Category", "TCType", "TestItem", "Tester", "scorelevel")
            dtPre.DefaultView.Sort = "[Category], [TCtype] asc"
            dtPre = dtPre.DefaultView.ToTable
            trv.Make_Node_Project(dtPre, _trv)
            _trv.ExpandAll()

        End If

    End Sub

    ''' <summary>
    ''' TreeListView1에 [아이템 별 평균역량] 내용 뿌리는 메서드
    ''' </summary>
    Private Sub Load_Assign_Tlv_Second_Data()
        Dim sql As String
        Dim trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker
        ' 이 모델에 testcase 가 등록되어있는지 확인을 합니다.
        sql = "select count(*) from " & cdb.get_assign_testcase & " "
        sql += String.Format("WHERE `Project` = '{0}' AND `GroupName`='{1}' AND `Model`='{2}' AND `Step`='{3}';",
                            _pjt, _grp, _mod, _step)
        ' 위의 쿼리를 실행 합니다.
        Dim strResult As String = dbc.GetQueryResult(sql)
        Dim chk As Boolean = If(strResult = "0", False, True)

        If chk = True Then
            sql = String.Format(
                "SELECT 
                    Category, 
                    TCtype, 
                    TestItem, 
                    ROUND(AVG(scorelevel)) AS average 
                FROM " & cdb.get_assign_testcase & " _
                WHERE 
                    Project = '{0}' AND 
                    GroupName = '{1}' AND 
                    Model = '{2}' AND 
                    Step = '{3}'
                GROUP BY 
                    Project, 
                    GroupName, 
                    Model, 
                    Step, 
                    Category, 
                    TCtype, 
                    TestItem ",
            _pjt, _grp, _mod, _step)
            Dim _dtPre As DataTable = dbc.Mysql_to_datatable(sql)
            If Not _dtPre Is Nothing Then
                trv.Make_Node_Project(_dtPre, _trv2, True)

            End If
        End If

    End Sub

    Public Sub DB_Upload_for_FWAssign()

        Dim dt As DataTable = TryCast(_dgv.DataSource, DataTable)

        Dim cmt As String = "정말 업로드 하시겠습니까?"
        If Windows.Forms.MessageBox.Show(
                cmt,
                "lee.sunbae@lgepartner.com",
                MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        Dim delcnt As Integer = 0 : Dim addcnt As Integer = 0 : Dim modicnt As Integer = 0
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
                    Dim sql_del As String = "delete from " & cdb.get_assign_testcase & " where id = " & beforeValue
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
                    Dim strCom As String = _company
                    Dim strMajor As String = remove_quarter(dr.Item("주특기").ToString)

                    ' insert 구문
                    Dim sql_add As String
                    Dim seq As Integer = If(_seq = "", 0, _seq)
                    sql_add = "insert into " & cdb.get_assign_testcase & " (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `Tester`, `주특기`, `scorelevel`, `company`, `랭킹`) values "
                    sql_add += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', {10}, '{11}', '{12}' , {13})",
                    _pjt, _grp, _mod, _step, CDate(_startdate).ToString("yyyy-MM-dd HH:mm:ss"), CDate(_enddate).ToString("yyyy-MM-dd HH:mm:ss"), strCate, strType, strItem, strTester, strMajor, intLevel, strCom, seq)

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
                    Dim strCom As String = _company
                    Dim strMajor As String = remove_quarter(dr.Item("주특기").ToString)

                    Dim intLevel As Integer = IIf(dr.Item("scorelevel").ToString = "", 0, dr.Item("scorelevel").ToString)


                    ' update 구문
                    Dim sql_modi As String
                    sql_modi = String.Format("update " & cdb.get_assign_testcase & " set `Category` = '{0}', `TCtype` = '{1}', `TestItem` = '{2}', `Tester` = '{3}', `주특기` = '{6}', `company` = '{4}', `scorelevel` = {6} where id = {5}",
                                        strCate, strType, strItem, strTester, strCom, dr.Item("ID"), intLevel, strMajor)

                    chkErrA = dbc.Query_to_Mysql(sql_modi)
                    modicnt += 1
                End If
            Next
        End If

        Dim cmment As String = String.Format(
        "정상적으로 F/W가 수정되었습니다.
        ---------------------------------
        {0} 기준", Now())

        Qportals.Debugging.Show(cmment)
        Load_Assign_DataGridViewData()


        dt.AcceptChanges()

    End Sub
    ''' <summary>
    ''' 트리뷰 데이터를 출력 하는 함수
    ''' </summary>
    ''' <param name="_trv"> TreeListview </param>
    ''' <param name="strKey"> 투입현황 or 평균역량 </param>
    Public Sub downloadExcel(ByRef _trv As WinControls.ListView.TreeListView, ByRef strKey As String)

        '// 역량 및 진행 아이템 엑셀 Export 기능
        Dim dttest As DataTable = New DataTable
        Dim _columns() As String
        Dim _tempdt As DataTable = New DataTable
        Dim _exportTrv As DataTable = New DataTable

        If (strKey = "투입현황") Then
            _columns = New String() {"Category", "TCtype", "TestItem", "Tester"}
            For Each s As String In _columns
                _exportTrv.Columns.Add(s)
            Next
            _exportTrv = TreeListViewToDataTable(_exportTrv, _trv.Nodes)
        ElseIf (strKey = "평균역량") Then
            _columns = New String() {"Category", "TCtype", "TestItem", "Score"}
            For Each s As String In _columns
                _exportTrv.Columns.Add(s)
            Next
            _exportTrv = TreeListViewToDataTable(_exportTrv, _trv.Nodes)

        End If

        '// 엑셀 추출 시작 
        downloadExcel(_exportTrv)

    End Sub

    Private Function TreeListViewToDataTable(ByRef _tempDT As DataTable, nodes As WinControls.ListView.Collections.TreeListNodeCollection) As DataTable
        Dim __trvPath() As String

        For Each node As WinControls.ListView.TreeListNode In nodes
            __trvPath = node.FullPath.Split("\")
            If node.SubItems.Count > 0 Then
                Dim temp = node.SubItems.Item(0).ToString
                _tempDT.Rows.Add(__trvPath(0), __trvPath(1), __trvPath(2), temp)
            End If

            TreeListViewToDataTable(_tempDT, node.Nodes)
        Next '2515923

        Return _tempDT

    End Function
    ''' <summary>
    ''' TreeListVeiw에 있는 Data를 Excel로 변환합니다.
    ''' </summary>
    ''' <param name="_exportTrv"></param>
    Private Sub downloadExcel(ByRef _exportTrv As DataTable)
        Dim ep As Qportals.External_library.EPPlus = New Qportals.External_library.EPPlus
        Dim fi As Qportals.FileControl = New Qportals.FileControl
        Dim makeFileName As String

        makeFileName = String.Format("{0}_{1}_{2}_{3}",
                        _pjt, _grp, _mod, _step)
        ep.datatable_to_excel(_exportTrv, makeFileName)
    End Sub

#Region "차트 그리기 관련"
    Private _mainuser As String
    ''' <summary>
    ''' Make_ChartScreen() : 차트를 그리는 함수
    ''' Sender 의 control name을 기준으로 기능을 분기하여 동적으로 처리 함
    ''' </summary>
    ''' <param name="sender"> 컨트롤의 sender를 넣으세요. </param>
    ''' <param name="trv"> 해당하는 TreeListView를 넣으세요. </param>
    Public Sub Make_ChartScreen(sender As Object, ctr As Control)

        Dim nowUser As String
        Dim dt As DataTable = New DataTable
        Dim dv As DataView
        Dim trv As WinControls.ListView.TreeListView
        Dim dgv As DataGridView
        If ctr.GetType() = GetType(WinControls.ListView.TreeListView) Then
            trv = ctr
        ElseIf ctr.GetType() = GetType(DataGridView) Then
            dgv = ctr
        End If

        If TryCast(sender, Control).Name = "TreeListView1" Then
            '// Assign TreeView

            If Not (trv.Nodes.Count = 0) And (trv.SelectedItems.Count > 0) Then
                If trv.SelectedItems.Item(0).SubItems.Count > 0 Then
                    nowUser = trv.SelectedItems.Item(0).SubItems(0).ToString()
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
            If Not (trv.Nodes.Count = 0) And (trv.SelectedItems.Count > 0) Then
                If trv.SelectedItems.Item(0).SubItems.Count > 0 Then
                    nowUser = trv.SelectedItems.Item(0).ToString()
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


    End Sub
    Private lst As Qportals.Controls.ListViewMaker = New Qportals.Controls.ListViewMaker
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



            Dim cht As DataVisualization.Charting.Chart = Show_chart.Chart1
            cht.DataSource = Show_chart._cht_data
            '.Chart1.DataSource = dt
            Dim ch As System.Collections.Generic.List(Of DataVisualization.Charting.Series) = New System.Collections.Generic.List(Of DataVisualization.Charting.Series)

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
            For Each frm As Form In Windows.Forms.Application.OpenForms
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

            Dim cht As DataVisualization.Charting.Chart = Show_chart.Chart1
            cht.DataSource = Show_chart._cht_data
            '.Chart1.DataSource = dt
            Dim ch As System.Collections.Generic.List(Of DataVisualization.Charting.Series) = New System.Collections.Generic.List(Of DataVisualization.Charting.Series)

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
            For Each frm As Form In Windows.Forms.Application.OpenForms
                If frm.Name = "MemberDialog1" Then
                    frm.Activate()
                    isitDup = True
                End If
            Next
            If isitDup = False Then Show_chart.Show()



        End If



    End Function
    Private Sub makeChartMan(ByRef Chart1 As DataVisualization.Charting.Chart, ByRef SeriesName As String, ByRef SeriesCount As Integer)

        Dim cht As DataVisualization.Charting.Chart = Chart1
        'cht.DataSource = _cht_data
        'Chart1.DataSource = dt
        Dim ch As System.Collections.Generic.List(Of DataVisualization.Charting.Series) = New System.Collections.Generic.List(Of DataVisualization.Charting.Series)

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
        Dim ca1 As DataVisualization.Charting.ChartArea = Chart1.ChartAreas(0)
        Dim sr0 As DataVisualization.Charting.Series = cht.Series(SeriesName)

        ' 차트 영역에 Grid 모눈을 해제 합니다.
        ca1.AxisX.MajorGrid.Enabled = False
        ca1.AxisY.MajorGrid.Enabled = False

        ' 표 간격을 조정 할 값
        Dim interval As Double = 1D

        ' 표 간격 지정
        ca1.AxisX.Interval = 1

        ' 차트의 타입을 막대 타입으로 바꿉니다.
        cht.Series(SeriesName).ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
        cht.Series(SeriesName).IsValueShownAsLabel = True

        ' x축의 Font를 바꿉니다.
        ca1.AxisX.LabelStyle.Font = New Font("맑은 고딕", 7)
        ca1.AxisY.LabelAutoFitStyle = DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont
        ca1.AxisX.LabelAutoFitStyle = DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont

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
    Private _byUserdt As DataTable
    Private _byItemdt As DataTable
    Private _dsmain As DataSet = New DataSet
    Private strSQLCon As String = c_db._server_address
    Private mySQLCon As New MySql.Data.MySqlClient.MySqlConnection(strSQLCon)
    ''' <summary>
    ''' 차트 데이터를 미리 구성하여 잦은 DB Connection을 방지하기 위함
    ''' 반드시 사용해야 함
    ''' </summary>
    Public Function ImportCht_backdata() As DataSet
        Dim sql_byTester As String
        Dim sql_byItem As String
        Dim DA As MySql.Data.MySqlClient.MySqlDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter


        '// 어떤 T/C를 진행 했는지 표현하고자 할 때
        sql_byItem = String.Format("
                    SELECT `Category`, `TCType`, `TestItem`, `Tester`, Count(*) as `진행횟수` 
                    FROM " & cdb.get_assign_testcase & " 
                    GROUP BY `Category`, `TCType`, `TestItem`
                    ORDER BY `진행횟수` DESC")


        '// 누가 이 T/C를 진행 했는지 표현하고자 할 때
        sql_byTester = String.Format("
                    SELECT `Category`, `TCType`,TestItem, Tester,  COUNT(*) AS `진행횟수` FROM " & cdb.get_assign_testcase & " 
                    GROUP BY Tester
                    ORDER BY `진행횟수` DESC")

        DA = New MySql.Data.MySqlClient.MySqlDataAdapter(sql_byItem, mySQLCon)
        DA.Fill(_dsmain, "아이템횟수")
        DA = New MySql.Data.MySqlClient.MySqlDataAdapter(sql_byTester, mySQLCon)
        DA.Fill(_dsmain, "검증원횟수")

        Return _dsmain


    End Function

    Private treeview As TreeView
    Property _treeview As TreeView

    Public Function load_Project_fromAssign() As String
        Dim cmt As String = ""
        Dim sql As String
        sql = "SELECT DISTINCT Project, GroupName, Model, Step "
        sql += "from " & cdb.get_assign_testcase & " "
        sql += "where Project = '" & _pjt & "' "
        sql += "ORDER BY Project DESC"


        sql = String.Format(
            "SELECT DISTINCT 
                t_pjt AS `Project`, 
                `t_model` AS `Model`, 
                t_step AS `Step` 
            FROM 
                " & cdb.get_manage_model & "
            WHERE 
                company = '{0}' and DATE_FORMAT(insert_date, ""%Y-%m-%d"") = CURDATE()
            ORDER BY 
                t_pjt DESC;", _company)

        sql = String.Format(
            "SELECT DISTINCT 
                t_pjt AS `Project`, 
                `t_model` AS `Model`, 
                t_step AS `Step`,
                DATE_FORMAT(insert_date, ""%Y-%m-%d"") as 일자
            FROM 
                " & cdb.get_manage_model & "
            WHERE 
                company = '{0}' 
            ORDER BY 
                t_pjt DESC;", _company)
        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)

        If dt.Rows.Count > 0 AndAlso Not dt Is Nothing Then
            Dim c_trv As Qportals.Controls.TreeViewMaker = New Qportals.Controls.TreeViewMaker
            c_trv.TView = _treeview
            c_trv.BuildTree(dt, _treeview, New Integer() {0, 1, 2, 3})
            _treeview.Font = New Font("맑은 고딕", 8)
            '_treeview.ExpandAll()
        Else
            cmt = String.Format(
"{0} 일자로 등록 된 투입 현황이 없습니다. 
            ▶ 투입 현황에서 등록 해주세요. ", Now())

        End If

        Return cmt

    End Function
    Public Sub TreeView_SelectEvent(e As TreeViewEventArgs)

        If e.Node.Level = 3 Then
            Dim select_nodes() As String = _treeview.SelectedNode.FullPath.Split("\")
            Dim _t_pjt As String = select_nodes(0)
            Dim _t_mod As String = select_nodes(1)
            Dim _t_step As String = select_nodes(2)
            Dim _t_date As String = select_nodes(3)

            preSet_dt_tables(_t_pjt, _t_mod, _t_step, _t_date)


        End If


        'preSet_dt_tables()

    End Sub

#End Region



#End Region

#Region "배정표 불러오기"
    Private _pjtdt As DataTable
    Private _leveldt As DataTable
    Private _newPjtleveldt As DataTable
    ''' <summary>
    ''' TreeListView3에 검증 할당한 내용을 띄워준다.
    ''' </summary>
    Public Sub preSet_dt_tables(ByRef strpjt As String, ByRef strmod As String, ByRef strstep As String, ByRef _date As String)

        Dim sql As String = String.Format(
            "SELECT                     
                    t_pjt AS pjt, 
                    IF(t_model IS NULL OR t_model ='', 'etc',t_model) AS model, 
                    IF(t_step IS NULL OR t_step = '', 'etc', t_step) AS step,
                    t_mem AS `name`
             FROM " & cdb.get_manage_model & " 
             WHERE 
	            t_pjt = '{0}' AND 
	            t_model = '{1}' AND 
	            t_step = '{2}' AND
             DATE_FORMAT(insert_date, ""%Y-%m-%d"") = '{3}'",
            strpjt, strmod, strstep, _date)
        _pjtdt = dbc.Mysql_to_datatable(sql)

        If _pjtdt Is Nothing Then
            Exit Sub
        End If

        Dim templst As List(Of String) = New List(Of String)
        templst.Add("Application")
        templst.Add("Device")
        templst.Add("Telephony")
        templst.Add("Multimedia")

        Dim _newdt As DataTable = New DataTable
        Dim _columns = New String() {"pjt", "model", "step", "name", "item", "level"}
        For Each s As String In _columns
            _newdt.Columns.Add(s)
        Next
        For Each dr As DataRow In _pjtdt.Rows
            For i As Integer = 0 To templst.Count - 1
                Dim rows As DataRow = _newdt.NewRow()
                rows("pjt") = dr("pjt").ToString()
                rows("model") = dr("model").ToString()
                rows("step") = dr("step").ToString()
                rows("name") = dr("name").ToString()
                rows("item") = templst(i).ToString()
                rows("level") = 0
                _newdt.Rows.Add(rows)
            Next
        Next


        ' _dt2
        sql = String.Format(
            "SELECT 
                `name`, `주특기` as item, `역량` as `level`
            FROM  " & cdb.get_manage_memlevel & " 
            WHERE company = '{0}';", _company)
        _leveldt = dbc.Mysql_to_datatable(sql)


        Dim out_dt As DataTable = _newdt.Clone()

        For Each dr As DataRow In _newdt.Rows

            For Each dr2 As DataRow In _leveldt.Rows

                If dr("name") = dr2("name") AndAlso dr("item") = dr2("item") Then
                    dr("level") = dr2("level")
                End If
            Next
        Next

        If _newdt.Rows.Count > 0 Then
            make_level_Treelistview(_trv_level, _newdt, True)
            SetColor_level_forAVG(_trv_level.Nodes)

        End If





    End Sub

    Private Sub make_level_Treelistview(ByVal _trvM As WinControls.ListView.TreeListView, ByRef _dt As DataTable, Optional ByRef Collab As Boolean = False)

        _trvM.Nodes.Clear()
        Dim node_1 As WinControls.ListView.TreeListNode = Nothing
        Dim node_2 As WinControls.ListView.TreeListNode = Nothing
        Dim node_3 As WinControls.ListView.TreeListNode = Nothing
        Dim node_4 As WinControls.ListView.TreeListNode = Nothing
        Dim node_5 As WinControls.ListView.TreeListNode = Nothing


        Dim nodeName_1 As String = ""
        Dim nodeName_2 As String = ""
        Dim nodeName_3 As String = ""
        Dim nodeName_4 As String = ""
        Dim nodeName_5 As String = ""

        Dim ProjectTableName As String = ""

        Dim change_depth1 As Boolean = False

        _trvM.BeginUpdate()

        For Each row As DataRow In _dt.Rows

            'If row.Item(0).ToString = "" Or row.Item(0).ToString = "교육" Or row.Item(0).ToString = "휴가" Then

            ' 1 Depth
            If Not row.Item(0) = "" Then
                    If row.Item(0).ToString <> nodeName_1 Then
                        node_1 = New WinControls.ListView.TreeListNode(row.Item(0))
                        _trvM.Font = New Font("맑은 고딕", 8.25)
                        _trvM.Nodes.Add(node_1)
                        _trvM.Nodes.Item(_trvM.Nodes.Count - 1).Font = New Font("맑은 고딕", 8.25)
                        nodeName_1 = row.Item(0).ToString
                        nodeName_2 = Nothing
                        nodeName_3 = Nothing
                        nodeName_4 = Nothing
                        nodeName_5 = Nothing
                    End If
                End If

                'If row.Item(1).ToString = "" Then
                '    Qportals.Debugging.Print(row.Item(1).ToString)
                'End If

                ' 2 Depth
                If Not row.Item(1) = "" Then
                    If row.Item(1).ToString <> nodeName_2 Then
                        node_2 = New WinControls.ListView.TreeListNode(If(row.Item(1).ToString() = "", " ", row.Item(1).ToString()))
                        node_1.Nodes.Add(node_2)
                        node_1.Nodes.Item(node_1.Nodes.Count - 1).Font = New Font("맑은 고딕", 8.25)
                        'node_1.Nodes.Item(node_1.Nodes.Count - 1).SubItems.Add(row.Item(2).ToString)

                        'node_1.Nodes.Item(node_1.Nodes.Count - 1).SubItems.Add(row.Item(3).ToString)
                        'node_1.Nodes.Item(node_1.Nodes.Count - 1).SubItems.Add(row.Item(10).ToString)
                        'node_1.Nodes.Item(node_1.Nodes.Count - 1).SubItems.Add(row.Item(11).ToString)
                        'node_1.Nodes.Item(node_1.Nodes.Count - 1).SubItems.Add(row.Item(12).ToString)
                        nodeName_2 = If(row.Item(1).ToString() = "", " ", row.Item(1).ToString())
                        nodeName_3 = Nothing
                        nodeName_4 = Nothing
                        nodeName_5 = Nothing
                    End If
                End If



                If row.Item(2).ToString = "선다운" Then
                    Qportals.Debugging.Print(row.Item(2).ToString)
                End If


                ' 3 Depth
                If Not row.Item(2) = "" Then
                    If row.Item(2).ToString <> nodeName_3 Then
                        node_3 = New WinControls.ListView.TreeListNode(row.Item(2))
                        node_2.Nodes.Add(node_3)
                        node_2.Nodes.Item(node_2.Nodes.Count - 1).Font = New Font("맑은 고딕", 8.25)
                        'node_2.Nodes.Item(node_2.Nodes.Count - 1).SubItems.Add(row.Item("level").ToString)
                        'node_2.Nodes.Item(node_2.Nodes.Count - 1).SubItems.Add(row.Item("주특기").ToString)
                        nodeName_3 = row.Item(2).ToString
                        nodeName_4 = Nothing
                        nodeName_5 = Nothing
                    End If
                End If

                '4 Depth
                If Not row.Item(3) = "" Then
                    If row.Item(3).ToString <> nodeName_4 Then
                        node_4 = New WinControls.ListView.TreeListNode(row.Item(3))
                        node_3.Nodes.Add(node_4)
                        node_3.Nodes.Item(node_3.Nodes.Count - 1).Font = New Font("맑은 고딕", 8.25)
                        node_3.Nodes.Item(node_3.Nodes.Count - 1).SubItems.Add(row.Item("level").ToString)
                        'node_3.Nodes.Item(node_3.Nodes.Count - 1).SubItems.Add(row.Item("item").ToString)
                        'node_3.Nodes.Item(node_3.Nodes.Count - 1).SubItems.Add(row.Item("MM Part").ToString)

                        nodeName_4 = row.Item(3).ToString
                        nodeName_5 = Nothing
                    End If
                End If

                '5 Depth
                If Not IsDBNull(If(row.Item(4).ToString() = "", " ", row.Item(4).ToString())) Then
                    If row.Item(4).ToString <> nodeName_5 Then
                        node_5 = New WinControls.ListView.TreeListNode(row.Item(4))
                        node_4.Nodes.Add(node_5)
                        node_4.Nodes.Item(node_4.Nodes.Count - 1).Font = New Font("맑은 고딕", 8.25)

                        node_4.Nodes.Item(node_4.Nodes.Count - 1).SubItems.Add(row.Item("level").ToString)
                        'node_4.Nodes.Item(node_4.Nodes.Count - 1).SubItems.Add(row.Item("item").ToString)
                        'node_3.Nodes.Item(node_3.Nodes.Count - 1).SubItems.Add(row.Item("MM Part").ToString)

                        nodeName_5 = row.Item(4).ToString
                    End If
                End If
            'End If

        Next row

        _trvM.EndUpdate()
        If Collab = True Then
            _trvM.ExpandAll()
        End If



    End Sub
    Public Sub SetColor_level_forAVG(nodes As WinControls.ListView.Collections.TreeListNodeCollection)
        Dim trvFullPath() As String

        For Each node As WinControls.ListView.TreeListNode In nodes
            trvFullPath = node.FullPath.Split("\")

            If (trvFullPath.Length = 4) Or (trvFullPath.Length = 5) Then
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
                            node.Collapse()
                    End Select

                End If

                SetColor_level_forAVG(node.Nodes)

            End If
            SetColor_level_forAVG(node.Nodes)
        Next
    End Sub




#End Region







End Class
