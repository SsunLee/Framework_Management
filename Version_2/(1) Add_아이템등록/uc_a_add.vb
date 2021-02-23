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
Imports MessageBox = System.Windows.Forms.MessageBox

Public Class uc_a_add
    Public lc As Qportals.Controls.TreeViewMaker = New Qportals.Controls.TreeViewMaker
    Public lviMaker As Qportals.Controls.LviClass = New Qportals.Controls.LviClass
    Public dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class

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
    Private _dgv As DataGridView
    Private _memdgv As DataGridView
    Private _memtrv As TreeListView
    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()
        InitSetting()

        _dgv = DataGridView1
        _memdgv = DataGridView2
        _memtrv = TreeListView1

        ' ToolTip
        Dim toolTip1 As New ToolTip
        With toolTip1
            .SetToolTip(btn_addrow, "상위 행 복사 삽입" & vbCrLf & "* 좌측 행 전체 선택 시")
            .SetToolTip(btnS1, "프로젝트")
            .SetToolTip(btnS2, "모델")
            .SetToolTip(btnS3, "차수")
            .SetToolTip(btnS4, "그룹(ex. 내수, 북미, 유럽)")
            .InitialDelay = 500 : .AutoPopDelay = 2000 : .ReshowDelay = 500
        End With

        _comDT = import_Member()    '// Contact 정보를 테이블에 담아 _comDT에 저장

        _dgv.Width = 834
        _dgv.Left = 16
        _memtrv.Visible = False
        _memdgv.Visible = False



        _trv = TreeListView1
        _trv.Columns.Add("업체명", 150, Windows.Forms.HorizontalAlignment.Center)
        _trv.Columns.Add("주특기", 110, Windows.Forms.HorizontalAlignment.Center)
        With _trv
            .MultiSelect = False
            .FullRowSelect = True
            .Columns.Item(0).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(1).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Columns.Item(0).ForeColor = Color.Blue
            '.Columns.Item(2).Font = New Font("맑은 고딕", 7.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            '.Columns.Item(0).Width = 300
            '.Columns.Item(2).Width = 150
            '.Columns.Item(3).Width = 100
        End With
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
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            '----------DataGridView--Font------------
            .DefaultCellStyle.Font = New Font("맑은 고딕", 7)
            .ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 7)
        End With

        mem_dt = New DataTable
        mem_dt.Columns.AddRange(New DataColumn() {
                                New DataColumn("업체명"),
                                New DataColumn("Part"),
                                New DataColumn("이름"),
                                New DataColumn("주특기")})

        _memdgv.DataSource = mem_dt
        With _memdgv
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
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            '----------DataGridView--Font------------
            .DefaultCellStyle.Font = New Font("맑은 고딕", 7)
            .ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 7)
            .RowHeadersVisible = False
        End With


        _company = Main_index.f._company
        _user = Main_index.f._user

    End Sub
    Private mem_dt As DataTable

#Region "인원관리"
    Private _trv As TreeListView

    Private Sub setCompanyInfo()
        Dim trv As Qportals.Controls.TreeListViewMaker = New Qportals.Controls.TreeListViewMaker
        '// 트리뷰에 추가 되는 부분
        If Not (_comDT Is Nothing) Then
            trv._trv = _trv
            'trv.BuildTree(_comDT, New Integer() {0, 1, 2}, True)
            '// 이부분 다시 
            trv.Make_Node_Member_node(_comDT, _trv, True)

        End If


    End Sub

    Private Sub Manage_Member(sender As Object, e As EventArgs) Handles btn_member.Click

        If (_dgv.Width = 834) Then
            _dgv.Width = 196 : _dgv.Left = 654
            _memtrv.Visible = True
            _memdgv.Visible = True
            setCompanyInfo()

        Else
            _dgv.Width = 834 : _dgv.Left = 16
            _memtrv.Visible = False
            _memdgv.Visible = False

        End If
    End Sub
    Private UserName As String
    Private _user As String
    Private _company As String
    '20200108 : 불필요한 DB 접속 제거 
    'Private Sub import_company()
    '    '// 소속회사 검증원 가져오기
    '    Dim getUser As Qportals.ComputerInfo = New Qportals.ComputerInfo
    '    UserName = getUser.getUserName
    '    Dim UserCompany As String = Nothing, UserPart As String = Nothing

    '    '* 2019-09-03 검증원 정보 수정
    '    '* 이름을 가지고 회사명을 가져옵니다.
    '    Dim dt_comp As DataTable = getUser.GetContact(UserName)
    '    Try
    '        UserCompany = dt_comp.Rows(0).Item(2).ToString   ' 업체
    '        UserPart = dt_comp.Rows(0).Item(3).ToString ' 부서
    '    Catch ex As Exception
    '        Qportals.Debugging.Show("등록되지 않은 인원 입니다. " & vbCrLf & "관리자에게 문의하여 인원 등록 바랍니다.")
    '    End Try

    '    If (UserCompany.Contains(">")) Then
    '        UserCompany = UserCompany.Split(">")(1)
    '        UserCompany = Trim(UserCompany)
    '    End If

    '    ' ** 조회 된 정보를 Label에 저장 합니다.
    '    If Not (UserCompany Is Nothing) Then
    '        _user = UserName
    '        _company = UserCompany
    '    End If
    'End Sub
    Private _comDT As DataTable
    Private Function import_Member() As DataTable

        Try
            'import_company()

            Dim sql As String
            If Not (_company = "") Then
                'sql = String.Format("select 업체명, Part, 이름, 직급, 주특기 from td_defect.mem_info where 업체명 = '{0}'", _company)
                sql = String.Format("SELECT 
	                        mem.업체명 AS 업체명, 
	                        mem.Part AS Part, 
	                        mem.이름 AS 이름, 
	                        mem.직급 AS 직급, 
	                        mem.주특기 AS 주특기,                         
                        IF((SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.이름) IS NULL,0,
                            (SELECT lv.`역량` FROM td_defect.`leveldb` lv WHERE lv.이름 = mem.이름)) AS LEVEL 
                        FROM td_defect.`mem_info` mem")
                _comDT = New DataTable

                _comDT = dbc.Mysql_to_datatable(sql)
            End If

        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try

        Return If(_comDT Is Nothing, Nothing, _comDT)

    End Function
    Private Sub treeviewDoubleClick_Event(sender As Object, e As EventArgs) Handles TreeListView1.DoubleClick


        DoubleClick_TreeListView()





    End Sub



    Private Sub DoubleClick_TreeListView()

        Dim strFullPath As String, strNodes() As String
        Dim tempdt As DataTable = _comDT.Clone
        Dim main_table As DataTable = TryCast(_memdgv.DataSource, DataTable)

        Dim 주특기 As String

        '// 더블 클릭 시 아이템 넘겨주기
        If (_trv.SelectedItems.Count > 0) Then

            If Not (_trv.SelectedItems.Item(0) Is Nothing) Then
                strFullPath = TryCast(_trv.SelectedItems(0), TreeListNode).FullPath
                주특기 = _trv.SelectedItems(0).SubItems(0).ToString()
                strNodes = strFullPath.Split("\")

                If (strNodes.Length = 3) Then
                    'tempdt.Rows.Add(strNodes(0).ToString, strNodes(1).ToString)
                    Dim rowsT As DataRow = tempdt.NewRow
                    rowsT("업체명") = strNodes(0).ToString
                    rowsT("Part") = strNodes(1).ToString
                    rowsT("이름") = strNodes(2).ToString
                    rowsT("주특기") = 주특기
                    tempdt.Rows.Add(rowsT)

                    Dim query = tempdt.AsEnumerable().Where(
                        Function(dt1) _
                            Not main_table.AsEnumerable().Any(
                                Function(dt2) _
                                    dt1("업체명") = dt2("업체명") AndAlso
                                        dt1("Part") = dt2("Part") AndAlso
                                            dt1("이름") = dt2("이름") AndAlso
                                                dt1("주특기") = dt2("주특기")))
                    For Each r In query
                        Dim rows As DataRow = main_table.NewRow
                        rows("업체명") = r(0)
                        rows("Part") = r(1)
                        rows("이름") = r(2)
                        rows("주특기") = r(4)
                        mem_dt.Rows.Add(rows)
                    Next

                End If

            End If


        End If


    End Sub

    Private Sub Btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim checkValue As List(Of String) = New List(Of String) From {txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text}

        Dim cnt As Integer = checkValue.Where(Function(x) x = "" Or x Like "*선택*").Count

        If (cnt > 0) Then
            Qportals.Debugging.Show("필수 입력 모델 정보를 입력하지 않았습니다." & Environment.NewLine & "모델 선택 후 다시 시도해주세요")
            Exit Sub
        End If

        Dim chkErr As Boolean = False


        If (_memdgv.RowCount > 0) Then

            Dim temp_dt As DataTable = TryCast(_memdgv.DataSource, DataTable)
            역량레벨넣기(temp_dt, "이름")
            For Each dr As DataRow In temp_dt.Rows

                Dim sql As String = String.Format("insert into td_defect.`assign_member` 
                                            (`Project`, `GroupName`, `Model`, `Step`, 
                                            `Part`, `Tester`, `Company`, `주특기`, level) 
                                            Values ('{0}', '{1}', '{2}', '{3}', '{4}', 
                                            '{5}','{6}','{7}', {8})",
                                            txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text,
                                            dr("Part").ToString, dr("이름").ToString, dr("업체명").ToString, dr("주특기").ToString,
                                            dr("역량"))

                chkErr = dbc.Query_to_Mysql(sql)

            Next


            If chkErr = False Then
                Qportals.Debugging.Show("DB에 데이터가 제대로 올라가지 않았을 수 있습니다.")
            Else
                Qportals.Debugging.Show("데이터가 성공적으로 저장 되었습니다.")
            End If


        End If


    End Sub
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
    Private _dtlevel As DataTable
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


#End Region




    Private Sub InitSetting()
        '----------DataGridView----------------
        _dtGrid = DataGridView1
        _dtGrid.DefaultCellStyle.Font = New Font("맑은 고딕", 7)
        _dtGrid.ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 7)
        '---------------------------------------
        Dim strcolumns() As String = New String() {"Category", "TCType", "TCName"}
        _dtable = New DataTable()

        '** Column을 만듭니다.-------------------
        For Each c As String In strcolumns
            _dtable.Columns.Add(New DataColumn(c))
        Next
        '** dgv에 자료를 넣어 줍니다.
        If Not (_dtable Is Nothing) Then
            _dtGrid.DataSource = _dtable
        End If


        '-------------------------------------------------
        Dim cm As ContextMenuStrip = New ContextMenuStrip
        cm.Items.Add("수정(Edit)...")
        cm.Items.Add("미구현")
        cm.Font = New Font("맑은 고딕", 7)

        'TreeListView1.ContextMenuStrip = cm
        DataGridView1.DataSource = _dtable
        DataGridView1.AllowDrop = True

        ' 기본 모델 정보
        txtProin.Text = "[프로젝트 선택]"
        txtGroupin.Text = "[그룹 선택]"
        txtModelin.Text = "[모델 선택]"
        txtStepin.Text = "[차수 선택]"
    End Sub

    '** Enter 키 눌렀을 때
    Private Sub WhenEnterKeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtPro.KeyDown, txtModel.KeyDown, txtStep.KeyDown, cbCompany.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SearchButtonClick(sender, e)
        End If
    End Sub

    Public _la As Label = New Label

    '** 검색 버튼 눌렀을 때
    Private Sub SearchButtonClick(sender As Object, e As EventArgs) _
        Handles btnS1.Click, btnS2.Click, btnS3.Click, btnS4.Click

        Dim srch As New Qportals.Level.SelectModeltoOtherForm
        Dim lst As New Qportals.Controls.ListViewMaker

        Dim f1 As New Form
        Dim openPopup As New FW_SELECT_MODEL With {
        .Owner = f1
        }

        '  검색 눌렀을 때 DB에서 프로젝트 정보를 조회 합니다.
        Dim strPro As String, strGrp As String, strMod As String, strStep As String

        strPro = If(txtPro.Text.ToString = "", "", "and `Project` Like '%" & Replace(txtPro.Text.ToString.ToUpper, "'", "''") & "%' ")
        strGrp = If(cbCompany.Text.ToString = "", "", "and `GroupName` = '" & Replace(cbCompany.Text.ToString.ToUpper, "'", "''") & "' ")
        strMod = If(txtModel.Text.ToString = "", "", "and `Model` = '" & Replace(txtModel.Text.ToString.ToUpper, "'", "''") & "' ")
        strStep = If(txtStep.Text.ToString = "", "", "and `Step` = '" & Replace(txtStep.Text.ToString.ToUpper, "'", "''") & "' ")


        Dim sql As String
        Dim schemaName As String = "td_defect"
        sql = "SELECT DISTINCT Project, GroupName, Model, Step, StartDate, EndDate, `랭킹` FROM " & schemaName
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

            ' 이 모델에 testcase 가 등록되어있는지 확인을 합니다.
            sql = "select count(*) from td_defect.`assign_testcase` "
            sql += String.Format("WHERE `Project` = '{0}' AND `GroupName`='{1}' AND `Model`='{2}' AND `Step`='{3}';",
                                txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)

            ' 위의 쿼리를 실행 합니다.
            Dim strResult As String = dbc.GetQueryResult(sql)
            Dim chk As Boolean = False

            ' 결과가 0이면 testcase가 없다는 것.
            chk = If(strResult = "0", False, True)
            If chk = True Then

                ' 테스트케이스들을 불러옴.
                sql = "select ID,`Category`, `TCtype`, `TestItem` from td_defect.`assign_testcase` "
                sql += String.Format("WHERE `Project` = '{0}' AND `GroupName`='{1}' AND `Model`='{2}' AND `Step`='{3}';",
                                    txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)
                dt = dbc.Mysql_to_datatable(sql)
                If Not (dt Is Nothing) And (dt.Rows.Count > 0) Then
                    DataGridView1.DataSource = dt
                    DataGridView1.Columns("ID").Visible = False
                    'Label1.Text = String.Format("총 : {0}건", DataGridView1.RowCount)
                    Qportals.Debugging.Show(String.Format("총 {0}건을 성공적으로 가져왔습니다.", DataGridView1.RowCount))
                End If



            Else ' 등록 된 프레임워크가 없다. 

                ' 팝업 띄워주기.
                Qportals.Debugging.Show("프레임워크가 등록되어있지 않습니다. " & vbCrLf & "우측 상단의 'Tempalte 기능으로 새로 작성해서 업로드 해주세요.")

                Button3.PerformClick()
            End If

        End If

    End Sub

#Region "드래그 앤 드랍"
    Private Sub DragOver_OnPanel(sender As Object, e As Windows.Forms.DragEventArgs) Handles DataGridView1.DragOver

        If (e.Data.GetDataPresent(Forms.DataFormats.FileDrop)) Then
            e.Effect = Forms.DragDropEffects.Copy
        Else
            e.Effect = Forms.DragDropEffects.None
        End If
    End Sub
    Private Sub DragEnter_OnPanel(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView1.DragDrop

        Dim blCheck As Boolean = False       '# DragDrop 시 DragEventArgs를 통해 Data를 받아 온다. 
        Dim files() As String = e.Data.GetData(Forms.DataFormats.FileDrop)      '# Array 형식으로 저장 된 것을 난 파일 하나만 허용 할 거기 때문에 

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
                        lc._dtable = dt
                        dv = dt.DefaultView
                        dv.Sort = "[Category], [T/C Type] ASC"
                        dt = dv.ToTable("")

                        DataGridView1.DataSource = dt

                        _la.Visible = False

                        ' ** 검색 결과를 표시 해줍니다.
                        'Label1.Text = String.Format("총 : {0} 건", DataGridView1.RowCount)


                    Catch ex As Exception
                        Qportals.Debugging.Show(ex.Message)
                    End Try

                Else
                    Qportals.Debugging.Show("자료를 올릴 엑셀문서의 시트 이름은 [Sheet1] 이어야 합니다." & vbCrLf & "Sheet이름이 맞는지 확인 하고 수정해서 올려주세요.",,, 16)
                End If

            Case Else
                Qportals.Debugging.Show("1개의 파일만 지원 합니다.", "(lee.sunbae@lgepartner.com)", MessageBoxButton.OK, Forms.MessageBoxIcon.Error)
        End Select

    End Sub
#End Region

#Region "템플릿 다운로드"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Template Download
        Dim iofile As Qportals.FileControl = New Qportals.FileControl
        Try
            iofile.SaveFileDialog_sun_custom("\\10.169.88.40\Q-Portal\resource\Assign_Template.xlsx")
        Catch ex As Exception
            MessageBox.Show("테스트 중")
        End Try


    End Sub
#End Region

#Region "할당내용DB에 올리기!"
    Property _DuplNames As List(Of String)
    ' "안씀!"
    Private Sub Upload_data(sender As Object, e As EventArgs) Handles Button7.Click
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
        Dim dt_comp As DataTable = dbc.GetContacts(strLeader)
        strCompany = If(dt_comp.Rows(0).Item(2).ToString = "", "업체정보없음", dt_comp.Rows(0).Item(2).ToString)  ' 업체
        strPjt = If(txtProin.Text = "", "", txtProin.Text) : strPjt = remove_quarter(strPjt)
        strGrp = If(txtGroupin.Text = "", "", txtGroupin.Text) : strGrp = remove_quarter(strGrp)
        strMod = If(txtModelin.Text = "", "", txtModelin.Text) : strMod = remove_quarter(strMod)
        strStep = If(txtStepin.Text = "", "", txtStepin.Text) : strStep = remove_quarter(strStep)


        ' 이미 있는지 카운트 할려고.
        Dim sql As String = String.Format("select * from td_defect.`assign_testcase` where `Project` = '{0}' and `GroupName` = '{1}' and `Model` = '{2}' and `Step` = '{3}'",
                                            strPjt, strGrp, strMod, strStep)

        ' 위의 쿼리를 실행 합니다.
        Dim strResult As String = dbc.GetQueryResult(sql)
        Dim chkExist As Boolean = False

        ' 결과가 0이면 testcase가 없다는 것.
        chkExist = If(strResult = "0" Or strResult Is Nothing, False, True)
        If (chkExist = False) Then
            Dim assignsql As String = "insert into td_defect.`assign_testcase` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `랭킹`) values "

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
                                    strPjt, strGrp, strMod, strStep, CDate(txtStartin.Text.ToString()).ToString("yyyy-MM-dd HH:mm:ss"), CDate(txtEndin.Text.ToString).ToString("yyyy-MM-dd HH:mm:ss"), strCate, strType, strItem, CInt(txtseq.Text.ToString))

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
                        Dim sql_del As String = "delete from td_defect.`assign_testcase` where id = " & beforeValue
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
                        sql_add = "insert into td_defect.`assign_testcase` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `랭킹`) values "
                        sql_add += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9} )",
                        strPjt, strGrp, strMod, strStep, CDate(txtStartin.Text.ToString()).ToString("yyyy-MM-dd HH:mm:ss"), CDate(txtEndin.Text.ToString).ToString("yyyy-MM-dd HH:mm:ss"), strCate, strType, strItem, CInt(txtseq.Text.ToString))

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
                        sql_modi = String.Format("update td_defect.`assign_testcase` set `Category` = '{0}', `TCtype` = '{1}', `TestItem` = '{2}' where id = {3}",
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
        refresh_table()
    End Sub
    Private Sub refresh_table()

        Dim sql As String
        ' 테스트케이스들을 불러옴.
        sql = "select ID,`Category`, `TCtype`, `TestItem` from td_defect.`assign_testcase` "
        sql += String.Format("WHERE `Project` = '{0}' AND `GroupName`='{1}' AND `Model`='{2}' AND `Step`='{3}';",
                            txtProin.Text, txtGroupin.Text, txtModelin.Text, txtStepin.Text)
        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)
        If Not (dt Is Nothing) And (dt.Rows.Count > 0) Then
            DataGridView1.DataSource = dt
            DataGridView1.Columns("ID").Visible = False
            'Label1.Text = String.Format("총 : {0}건", DataGridView1.RowCount)
            'Qportals.Debugging.Show(String.Format("총 {0}건을 성공적으로 가져왔습니다.", DataGridView1.RowCount))
        Else
            '// 등록 된 프레임워크가 없다면

            If MessageBox.Show("등록되어 있는 Framework가 없습니다.", "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Button3.PerformClick()
            End If
        End If

    End Sub
    Private Sub db_thread()

        ' 모델 필수 정보가 입력되어 있는지 체크를 합니다.
        If (CheckFillInfo() = True) Then
            Qportals.Debugging.Show("모델정보가 입력되지 않았습니다." & vbCrLf & "모델을 선택 하거나 등록 후 다시 시도하세요",,, 16)
            Exit Sub
        End If

        ' * DB 를 사용하기 위해 mysql libaray를 선언 합니다.
        Dim mysqlcl As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class

        ' * DataGridView 의 Data를 DB에 올리기 위해 Datatable에 담습니다.
        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        'dt.AcceptChanges()
        Dim sql As String, sum_sql As String, delsql As String, assignsql As String, sum_sql_assign As String
        Dim insert_count As Integer, update_count As Integer

        Dim getName As Qportals.ComputerInfo = New Qportals.ComputerInfo

        insert_count = 0
        update_count = 0

        Dim strPjt As String
        Dim strGrp As String
        Dim strMod As String
        Dim strStep As String
        Dim strCate As String
        Dim strType As String
        Dim strItem As String
        Dim strLeader As String
        Dim strCompany As String


        strLeader = getName.getUserName()

        '* 이름을 가지고 회사명을 가져옵니다.
        Dim dt_comp As DataTable = mysqlcl.GetContacts(strLeader)
        strCompany = If(dt_comp.Rows(0).Item(2).ToString = "", "업체정보없음", dt_comp.Rows(0).Item(2).ToString)  ' 업체
        ' strCompany = If(strCompany.Contains("Test E&C"), "Test E&&C", strCompany)

        strPjt = If(txtProin.Text = "", "", txtProin.Text) : strPjt = remove_quarter(strPjt)
        strGrp = If(txtGroupin.Text = "", "", txtGroupin.Text) : strGrp = remove_quarter(strGrp)
        strMod = If(txtModelin.Text = "", "", txtModelin.Text) : strMod = remove_quarter(strMod)
        strStep = If(txtStepin.Text = "", "", txtStepin.Text) : strStep = remove_quarter(strStep)

        ' testcasedb 등록
        delsql = "delete from td_defect.`testcasedb` where "
        delsql += "`Project` = '" & strPjt & "' and `GroupName` = '" & strGrp & "' and `Model` = '" & strMod & "' and `Step` = '" & strStep & "' and "
        delsql += " `Leader` = '" & strLeader & "' and `company` = '" & strCompany & "' "

        ' 쿼리를 실행 합니다.
        'dbc.Query_to_Mysql(delsql)


        ' assign_testcase
        delsql = "delete from td_defect.`assign_testcase` where "
        delsql += "`Project` = '" & strPjt & "' and `GroupName` = '" & strGrp & "' and `Model` = '" & strMod & "' and `Step` = '" & strStep & "' and "
        delsql += " `Tester` is Null "

        ' 쿼리를 실행 합니다.
        dbc.Query_to_Mysql(delsql)

        Dim chkErr As Boolean = True
        ' * 실제 DB에 올리는 코드입니다.

        sql = "insert into td_defect.`testcasedb` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `Leader`, `company`, `랭킹`) values "
        assignsql = "insert into td_defect.`assign_testcase` (`Project`, `GroupName`, `Model`, `Step`, `StartDate`, `EndDate`, `Category`, `TCtype`, `TestItem`, `랭킹`) values "

        For Each dr As DataRow In dt.Rows
            ' Category, TC Type, Test Item 
            strCate = remove_quarter(dr.Item(0).ToString)
            strType = remove_quarter(dr.Item(1).ToString)
            strItem = remove_quarter(dr.Item(2).ToString)

            sum_sql += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11} ),",
                                strPjt, strGrp, strMod, strStep, CDate(txtStartin.Text.ToString()).ToString("yyyy-MM-dd HH:mm:ss"), CDate(txtEndin.Text.ToString).ToString("yyyy-MM-dd HH:mm:ss"), strCate, strType, strItem, strLeader, strCompany, CInt(txtseq.Text.ToString))
            insert_count += 1

            sum_sql_assign += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9} ),",
                                strPjt, strGrp, strMod, strStep, CDate(txtStartin.Text.ToString()).ToString("yyyy-MM-dd HH:mm:ss"), CDate(txtEndin.Text.ToString).ToString("yyyy-MM-dd HH:mm:ss"), strCate, strType, strItem, CInt(txtseq.Text.ToString))

        Next

        ' 쿼리를 실행 합니다.
        sum_sql = sum_sql.Substring(0, Len(sum_sql) - 1)
        sql += sum_sql

        chkErr = dbc.Query_to_Mysql(sql)

        ' 쿼리를 실행 합니다.
        sum_sql_assign = sum_sql_assign.Substring(0, Len(sum_sql_assign) - 1)
        assignsql += sum_sql_assign
        Dim chkErrA As Boolean = False
        chkErrA = dbc.Query_to_Mysql(assignsql)


        If (chkErr = True) And (chkErrA = True) Then
            Qportals.Debugging.Show("정상적으로 F/W가 수정되었습니다." & vbCrLf & insert_count & "건")
        Else
            Qportals.Debugging.Show("올바르게 올라가지 않았을 수 있습니다.")
        End If

    End Sub

    'Private Sub 프레임워크올리기(sender As Object, e As EventArgs) Handles Button7.Click, DataGridView1.CellValueChanged
    'Dim trd As Thread = New Thread(AddressOf db_thread)
    'trd.Start()
    'End Sub

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

    Private Sub Upload_DB2(sender As Object, e As EventArgs) 'Handles Button7.Click
        ' ** DataGridView에 Data를 올리는 부분입니다.
        Dim mysqlcn As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class

        ' * DataGridView => DataTable 
        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        Dim sql As String
        Dim insert_count As Integer, update_count As Integer

        insert_count = 0
        update_count = 0

        ' * 실제 DB에 올리는 코드입니다.
        For Each dr As DataRow In dt.Rows

            ' 추가 할 건지 아닌지 
            sql = String.Format("select count(*) from td_defect.`assign_testcase` where 
            `Project` = '{0}' AND  
            `GroupName`= '{1}' AND  
            `Model`= '{2}' AND  
            `Step`= '{3}' AND  
            `Category`= '{4}' AND  
            `TCtype`= '{5}' AND  
            `TestItem` LIKE '{6}%' AND 
            `Tester`= '{7}' ",
            dr.Item(0).ToString, ' <-- Project 
            dr.Item(1).ToString, ' <-- Group Name
            dr.Item(2).ToString, ' <-- Model
            dr.Item(3).ToString, ' <-- Step
            dr.Item(4).ToString, ' <-- Category
            dr.Item(5).ToString, ' <--  TC Type
            dr.Item(6).ToString, ' <-- TC Name(Test Item)
            dr.Item(7).ToString) ' <-- Tester

            Dim result As String = mysqlcn.GetQueryResult(sql)

            If (CInt(result) > 0) Then
                ' 덮어스기 ( Update )
                Try
                    sql = "UPDATE td_defect.`assign_testcase` SET "
                    sql = sql & " `PartName` = '" & dr.Item(0).ToString() & "', "
                    sql = sql & " `company` = '" & dr.Item(1).ToString() & "', "
                    sql = sql & " `Comments` = '" & dr.Item(2).ToString() & "' "

                    sql = sql & " WHERE  "
                    sql = sql & " `Project` = '" & dr.Item(0).ToString() & "' AND "
                    sql = sql & " `GroupName` = '" & dr.Item(1).ToString() & "' AND "
                    sql = sql & " `Model` = '" & dr.Item(2).ToString() & "' AND  "
                    sql = sql & " `Step` = '" & dr.Item(3).ToString() & "' AND  "
                    sql = sql & " `Category` = '" & dr.Item(4).ToString() & "' AND  "
                    sql = sql & " `TCtype` = '" & dr.Item(5).ToString() & "' AND  "
                    sql = sql & " `TestItem` LIKE '" & dr.Item(6).ToString() & "%' AND  "
                    sql = sql & " `Tester` = '" & dr.Item(7).ToString() & "' "
                    update_count += 1

                    mysqlcn.Query_to_Mysql(sql)

                Catch ex As Exception
                    Qportals.Debugging.Show(ex.Message)
                End Try

            Else

                Try ' 없다면 새로 추가
                    sql = String.Format("insert into td_defect.`{0}` (`Project`, `GroupName`, `Model`, `Step`, `Category`, `TCtype`, `TestItem`,`Tester`, `PartName`, `company`,`StartDate`, `EndDate`) 
                                    Values('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
                    "assign_testcase",    ' <-- table 이름
                    dr.Item(0).ToString, ' <-- Project 
                    dr.Item(1).ToString, ' <-- Group Name
                    dr.Item(2).ToString, ' <-- Model
                    dr.Item(3).ToString, ' <-- Step
                    dr.Item(4).ToString, ' <-- Category
                    dr.Item(5).ToString, ' <--  TC Type
                    dr.Item(6).ToString, ' <-- TC Name(Test Item)
                    dr.Item(7).ToString, ' <-- Tester
                    dr.Item(8).ToString, ' <-- Part
                    dr.Item(9).ToString, ' <-- company
                    dr.Item(10).ToString, ' <-- Start Date
                    dr.Item(11).ToString) ' <-- End Date
                    insert_count += 1

                    mysqlcn.Query_to_Mysql(sql)

                Catch ex As Exception

                End Try

            End If

        Next

        Dim comment As String

        comment = String.Format(
            "---result----------
            {0}건 추가되었습니다.
             {1}건 수정되었습니다.", insert_count, update_count)
        Qportals.Debugging.Show(comment)


    End Sub


    Private Sub Btn_addProject_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '// 모델 추가
        Dim f1 As New Form
        Dim lv_add As New FW_ADD_MODEL With {
            .Owner = f1
        }
        lv_add.ShowDialog()
        txtProin.Text = lv_add.strPjt
        txtGroupin.Text = lv_add.strGrp
        txtModelin.Text = lv_add.strMod
        txtStepin.Text = lv_add.strStep

        txtStartin.Text = lv_add.date_start
        txtEndin.Text = lv_add.date_end
        'txtseq.Text = lv_add.seq


        refresh_table()

        'Qportals.Debugging.Show(lv_add.strPjt)

    End Sub



#End Region
    ' 2019-09-03 : 행 삽입 기능 추가
    Private Sub Btn_addrow_Click(sender As Object, e As EventArgs) Handles btn_addrow.Click
        DataGridViewAddRow(DataGridView1)
    End Sub
    Private Sub DataGridViewAddRow(ByRef dgv As DataGridView)
        Dim rowValues As List(Of Object) = New List(Of Object)

        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)

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


    End Sub


End Class
