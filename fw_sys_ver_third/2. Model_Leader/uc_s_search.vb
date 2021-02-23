Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Reflection
Imports System.Windows.Forms
Imports MetroFramework.Controls

Public Class uc_s_search
    Private cdb As c_db.assign_mem = New c_db.assign_mem
    Public dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Private _dtColumn As DataTable

    'DataGridView의 소스를 바인딩데이터로 넣자. 
    Private source1 As BindingSource

    Private Property _source1 As BindingSource
        Get
            Return source1
        End Get
        Set(value As BindingSource)
            source1 = value
        End Set
    End Property

    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        Setting_pnael.Visible = False


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

        '// DataGridView 기본 생성
        __set_datagridivew__()

        '// 콤보박스 기본 값 
        __comboboxStyle__()


        getProject()


        '2019-09-09 : 최초 load될 때 전체 Filter 조건으로 Default Set
        rdo_all.Checked = True

        ' 2019-09-09 : md 저장할 때만 저장버튼 생기도록 
        btnMDSave.Visible = False

    End Sub
    Private Sub __comboboxStyle__()

        cbPro.Text = "[프로젝트 선택]"
        cbGrp.Text = "[그룹 선택]"
        cbMod.Text = "[모델 선택]"
        cbStep.Text = "[차수 선택]"

    End Sub

    Private Sub __set_datagridivew__()
        '// DataGridView 기본 설정
        Dim dgvDouble As Qportals.DataGridViewDoubleBuffer = New Qportals.DataGridViewDoubleBuffer(DataGridView1)
        dgvDouble.EnableDoubleBuffered()

        Panel4.BackColor = Color.FromArgb(55, 207, 221, 232)
        Panel8.BackColor = Color.FromArgb(55, 207, 221, 232)

        '246, 249, 252
        With DataGridView1
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AllowUserToOrderColumns = True                                          ' 유저가 맘대로 바꾸고 싶을 때
            .DefaultCellStyle.SelectionBackColor = Color.White                       ' 선택 했을 때 back color
            .DefaultCellStyle.SelectionForeColor = Color.Black                       ' 선택 했을 때 글씨 color
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240) ' 열의 색상 지정
            .EnableHeadersVisualStyles = False                                       ' 열과 행의 경계선 스타일 지정
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True                   ' 열에 보여지는 문자열을 여러행으로 보여주고 싶을 때
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None                    ' 행 사이즈 자동 조절 
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells '열 사이즈 자동 조절

            '----------DataGridView--Font------------
            .DefaultCellStyle.Font = New Font("맑은 고딕", 8)
            .DefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 8)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        End With

        Dim strcolumns() As String = New String() {"Category", "TCType", "진행율", "TOTAL", "OK", "NG", "NT", "미구현", "사업자", "T/C error", "Network", "장비미보유", "환경ETC", "ETC", "Memo"}
        '** DataGridView(하단)에 자료를 넣기 위해 DataTable을 만들었습니다.
        '** 이하 dgv 
        _dtColumn = New DataTable()

        '** Column을 만듭니다.---------------------
        For Each c As String In strcolumns
            _dtColumn.Columns.Add(New DataColumn(c))
        Next

        '** dgv에 자료를 넣어 줍니다.
        If Not (_dtColumn Is Nothing) Then
            DataGridView1.DataSource = _dtColumn
        End If

    End Sub



    Private Sub FilterCheckChange(sender As Object, e As EventArgs) Handles rdo_all.CheckedChanged, rdoCate.CheckedChanged, rdoTCt.CheckedChanged
        '// 카테고리 선택할 때 아이템을 콤보박스에 추가 해주는 것
        ' Filter Change 했을 때 
        Dim _dt As DataTable = New DataTable

        If Not (_source1 Is Nothing) Then
            '// DGV에 Binding된 Data를 Datatable로 가져온다.
            _dt = TryCast(_source1.DataSource, DataTable)
        Else
            Exit Sub
        End If


        If (_dt.Rows.Count > 0) And Not (_dt Is Nothing) Then
            '// 전체 를 선택하면 Filter를 풀고
            If rdo_all.Checked = True Then
                _source1.Filter = ""

                '// Category를 누르면 Category부분을 콤보박스에 넣어주고, 필터실행 한다.
            ElseIf rdoCate.Checked = True Then
                _source1.Filter = ""

                '// DefaultView.ToTable 메서드를 이용하여 중복 제거 후 table에 담음
                Dim tmpdt As DataTable = _dt.DefaultView.ToTable(True, "Category")
                With cbFilter
                    .DataSource = tmpdt
                    .DisplayMember = "Category"
                    .ValueMember = "Category"
                    .SelectedIndex = 0
                End With

                '// Filter 실행
                FilterValueChange(cbFilter.Text)




            ElseIf rdoTCt.Checked = True Then

                _source1.Filter = ""
                Dim tmpdt As DataTable = _dt.DefaultView.ToTable(True, "TCtype")
                With cbFilter
                    .DataSource = tmpdt
                    .DisplayMember = "TCtype"
                    .ValueMember = "TCtype"
                    .SelectedIndex = 0
                End With

                FilterValueChange(cbFilter.Text)

            End If

            ' 색상 글꼴 지정
            calColor()

        End If

    End Sub

    Private _Recover As DataTable = New DataTable
    Private Sub ClickSearch_Level(sender As Object, e As EventArgs) Handles rd_level_all.CheckedChanged, rd_level_cate.CheckedChanged, rd_level_Tct.CheckedChanged

        If Not (_source1 Is Nothing) Then
            '// DGV에 Binding된 Data를 Datatable로 가져온다.
            _Recover = TryCast(_source1.DataSource, DataTable)
        Else
            Exit Sub
        End If
        If _Recover Is Nothing Then Exit Sub

        If (_Recover.Rows.Count > 0) And Not (_Recover Is Nothing) Then
            '// 전체 를 선택하면 Filter를 풀고
            If rd_level_all.Checked = True Then
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = _Recover
                DataGridView1.Columns(0).Visible = False
                ' 색상 글꼴 지정
                calColor()

            ElseIf rd_level_cate.Checked = True Then

                '// 카테고리 별
                Dim _new As DataTable = Category_Avg()
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = _new
                ' 색상 글꼴 지정
                calColor()


            ElseIf rd_level_Tct.Checked = True Then

                '// TC타입 별
                Dim _new As DataTable = TCtype_Avg()
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = _new
                ' 색상 글꼴 지정
                calColor()


            End If


        End If


    End Sub

    Private Function Category_Avg() As DataTable
        Dim _dt As DataTable = TryCast(source1.DataSource, DataTable)
        Dim query = From r In _dt.AsEnumerable()
                    Group r By item = New With
                        {
                            Key .Step = r.Field(Of String)("Step"),
                            Key .Category = r.Field(Of String)("Category")
                        } Into grp = Group
                    Let r = grp.First
                    Select New With
                        {
                            .Step = r("Step"),
                            .Category = r("Category"),
                            .Value = grp.Average(Function(x) x("Level"))
                        }

        Dim _new As DataTable

        _new = New DataTable

        _new.Columns.AddRange(New DataColumn() _
            {New DataColumn("Step"), New DataColumn("Category"), New DataColumn("Level")})

        For Each r In query
            '// F1 소수점 
            _new.Rows.Add(r.Step, r.Category, r.Value.ToString("F1"))
        Next

        Return If(_new.Rows.Count < 0, Nothing, _new)

    End Function
    Private Function TCtype_Avg() As DataTable
        Dim _dt As DataTable = TryCast(source1.DataSource, DataTable)
        Dim query = From r In _dt.AsEnumerable()
                    Group r By item = New With
                        {
                            Key .Step = r.Field(Of String)("Step"),
                            Key .Category = r.Field(Of String)("Category"),
                            Key .TCtype = r.Field(Of String)("TCtype")
                        } Into grp = Group
                    Let r = grp.First
                    Select New With
                        {
                            .Step = r("Step"),
                            .Category = r("Category"),
                            .TCtype = r("TCtype"),
                            .Value = grp.Average(Function(x) x("Level"))
                        }

        Dim _new As DataTable

        _new = New DataTable

        _new.Columns.AddRange(New DataColumn() _
            {New DataColumn("Step"), New DataColumn("Category"), New DataColumn("TCtype"), New DataColumn("Level")})

        For Each r In query
            _new.Rows.Add(r.Step, r.Category, r.TCtype, r.Value.ToString("F1"))
        Next

        Return If(_new.Rows.Count < 0, Nothing, _new)

    End Function


    Private Sub FilterValueChangeEvent(sender As Object, e As EventArgs) Handles cbFilter.SelectedIndexChanged

        '// 필터 옵션 선택 시 필터 동작 하도록 
        FilterValueChange(cbFilter.Text)


    End Sub '// 필터 콤보박스 선택 이벤트 

    Private Sub FilterValueChange(ByRef strText As String)
        ' Filter Change 했을 때 
        Dim _dt As DataTable = New DataTable
        _dt = TryCast(_source1.DataSource, DataTable)

        Dim _dv As DataView = New DataView
        If (_dt.Rows.Count > 0) And Not (_dt Is Nothing) Then
            If Not (rdo_all.Checked = True) Then
                If rdoCate.Checked = True Then
                    _source1.Filter = String.Format("Category = '{0}'", strText)
                ElseIf rdoTCt.Checked = True Then
                    _source1.Filter = String.Format("TCtype = '{0}'", strText)
                End If
            Else
                _source1.Filter = ""
            End If
            calColor()

        End If

    End Sub

    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint, Panel7.Paint, Panel11.Paint, Panel13.Paint, Panel15.Paint
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel7.BorderStyle = BorderStyle.FixedSingle
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(55, 246, 249, 252), 1), Panel3.ClientRectangle)
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(55, 246, 249, 252), 1), Panel7.ClientRectangle)

    End Sub '// Panel 색 칠하기

    Private Sub EnterKeyPress(sender As Object, e As KeyEventArgs) Handles txtTester.KeyDown
        ' * 엔터 키 쳤을 때
        If (e.KeyCode = Keys.Enter) Then
            Search_Database()
        End If
    End Sub '// 엔터쳤을 때 검색 되도록 하기

    Private Sub SetdgvStyle(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim dgvstyle As Qportals.Controls.dgvStyle = New Qportals.Controls.dgvStyle
        dgvstyle.Grid_RowPostPaint(DataGridView1, e)
    End Sub '// DataGridView 선택 했을 때 엑셀 처럼 스타일 나오도록
    Property _dt As DataTable

    Private Sub getProject()
        Dim sql As String
        sql = "SELECT * FROM as.project WHERE `GroupName` IS NOT NULL AND Model IS NOT NULL AND step IS NOT NULL ORDER BY Project,`GroupName`,Model, 
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

        sql = "select distinct Project, GroupName, Model, Step from " & cdb.get_assign_testcase & " "

        _dt = dbc.Mysql_to_datatable(sql)
        If Not (_dt Is Nothing) And Not (_dt.Rows.Count = 0) Then
            ' dt
            Qportals.Debugging.Print("data 조회 됨")

            _cbBox = cbPro
            _cbBox.DataSource = Nothing
            AddListBox(_dt, "Project")
        Else
            Qportals.Debugging.Print("data 조회 안 됨")
        End If
    End Sub '// 프로젝트 정도 가져오기 콤보박스에 뿌려주기 위함.

    Private Sub ClicktheRefresh_button(sender As Object, e As EventArgs) Handles btnRefresh.Click

        getProject()

    End Sub

    Public Sub AddListBox(ByRef _dt As DataTable, ByRef _columnName As String)
        Dim temp_dt As DataTable = _dt
        _cbBox.Items.Clear()

        If Not (temp_dt Is Nothing) And Not (_dt.Rows.Count = 0) Then
            temp_dt = temp_dt.DefaultView.ToTable(True, _columnName)
            For i As Integer = 0 To temp_dt.Rows.Count - 1
                _cbBox.Items.Add(temp_dt.Rows(i)(0).ToString())
            Next
        End If

    End Sub '// 콤보박스에 항목 추가하는 것
    Private Sub Click_NextItem_Num(sender As Object, e As EventArgs) Handles cbPro.SelectedIndexChanged
        ClickItems(New Windows.Forms.ComboBox() {cbPro, cbGrp}, _dt)
    End Sub '// 콤보박스 선택할 때 다음 아이템 보여주는 코드
    Private Sub Click_NextItem_Num2(sender As Object, e As EventArgs) Handles cbGrp.SelectedIndexChanged
        ClickItems(New Windows.Forms.ComboBox() {cbPro, cbGrp, cbMod}, _dt)
    End Sub
    Private Sub Click_NextItem_Num3(sender As Object, e As EventArgs) Handles cbMod.SelectedIndexChanged
        ClickItems(New Windows.Forms.ComboBox() {cbPro, cbGrp, cbMod, cbStep}, _dt)
    End Sub
    Property cbBox As ComboBox
    Public Sub ClickItems(ByRef ComboBoxs() As ComboBox, ByRef _dt As DataTable)
        Dim COL As Integer = 0
        Select Case ComboBoxs.Length
            Case 2
                cbBox = ComboBoxs(1)
                cbBox.Items.Clear()
                For Each dr As DataRow In _dt.Rows
                    If ComboBoxs(0).SelectedItem.ToString = dr.Item(COL).ToString Then
                        If Not (cbBox.Items.Contains(dr.Item(COL + 1).ToString)) Then
                            cbBox.Items.Add(dr.Item(+1).ToString)
                        End If
                    End If
                Next
            Case 3
                cbBox = ComboBoxs(2)
                cbBox.Items.Clear()
                For Each dr As DataRow In _dt.Rows
                    If (ComboBoxs(0).SelectedItem.ToString = dr.Item(COL).ToString) And
                        (ComboBoxs(1).SelectedItem.ToString = dr.Item(COL + 1).ToString) Then
                        If Not (cbBox.Items.Contains(dr.Item(COL + 2).ToString)) Then
                            cbBox.Items.Add(dr.Item(COL + 2).ToString)
                        End If
                    End If
                Next
            Case 4
                cbBox = ComboBoxs(3)
                cbBox.Items.Clear()
                For Each dr As DataRow In _dt.Rows
                    If (ComboBoxs(0).SelectedItem.ToString = dr.Item(COL).ToString) And
                        (ComboBoxs(1).SelectedItem.ToString = dr.Item(COL + 1).ToString) And
                        (ComboBoxs(2).SelectedItem.ToString = dr.Item(COL + 2).ToString) Then
                        If Not (cbBox.Items.Contains(dr.Item(COL + 3).ToString)) Then
                            cbBox.Items.Add(dr.Item(COL + 3).ToString)
                        End If
                    End If
                Next
        End Select


    End Sub

    Private Sub Search_Database1(sender As Object, e As EventArgs) Handles btn_DB.Click

        btnMDSave.Visible = False
        Search_Database()

    End Sub '// 할당한 Test Case 조회하기.

    Private Sub Search_Database()

        ' 검색 버튼 눌렀을 때 동작 합니다.
        Dim addP As String = If(cbPro.Text.ToUpper() = "", "", " And Project like '%" & Replace(cbPro.Text.ToUpper, "'", "''") & "%' ")
        Dim addG As String = If(cbGrp.Text.ToUpper = "", "", " And GroupName = '" & Replace(cbGrp.Text.ToUpper, "'", "''") & "' ")
        Dim addM As String = If(cbMod.Text.ToUpper = "", "", " And Model = '" & Replace(cbMod.Text.ToUpper, "'", "''") & "' ")
        Dim addS As String = If(cbStep.Text.ToUpper = "", "", " And Step = '" & Replace(cbStep.Text.ToUpper, "'", "''") & "' ")
        Dim addN As String = If(txtTester.Text.ToUpper = "", "", " And `Tester` = '" & Replace(txtTester.Text.ToUpper, "'", "''") & "' ")

        Dim addD As String
        ' 날짜를 조회하고 싶을 때만 동작 하도록
        If (ToggleSwitch1.Checked = True) Then
            addD = String.Format("And insert_date between '{0}' and '{1}' ", date_start.Value.ToString("yyyyMMdd"), date_End.Value.ToString("yyyyMMdd"))
        Else
            addD = ""
        End If

        Dim sql As String
        sql = "select Model, Step, Category, TCtype, TestItem, DATE_FORMAT(insert_date,'%Y-%m-%d') as 할당일, `Tester`,`진행율`, `TOTAL`, `OK`, `NG`, `NT`, `미구현`, `사업자`, `T/C error`, `Network`, `장비미보유`, `환경ETC`, `ETC`, `TC_Comment` "
        sql += " from " & cdb.get_assign_testcase & " where ID > 0 "
        sql += addP & addG & addM & addS & addN & addD
        sql += " order by `Model`, `Step`, `Category`, `TCtype`, `TestItem`"


        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)

        If Not (dt Is Nothing) Then
            Dim tempSource As BindingSource = New BindingSource
            _source1 = Nothing
            _source1 = tempSource ' Set Property 
            _source1.DataSource = dt
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = _source1

            'dt.AcceptChanges()
            'DataGridView1.Columns("Model").Visible = False

            calColor()
        Else
            Qportals.Debugging.Show("검색 결과가 없습니다.")
        End If

    End Sub


    Private Sub calColor()


        '* 100%가 넘으면 녹색으로 칠합니다.
        For Each row As DataGridViewRow In DataGridView1.Rows

            If Not DataGridView1.Columns("진행율") Is Nothing Then
                '// 진행율 관련
                DataGridView1.Columns("진행율").DefaultCellStyle.Format = "#0.0.'%'"
                If Not (row.Cells("진행율").Value Is Nothing) Then
                    row.Cells("진행율").Value = If(row.Cells("진행율").Value.ToString = "", 0, row.Cells("진행율").Value)

                    Select Case CDbl(row.Cells("진행율").Value)
                        Case 100
                            row.Cells("진행율").Style.BackColor = Color.PaleGreen
                        Case Is >= 80, Is < 100
                            row.Cells("진행율").Style.BackColor = Color.Yellow
                        Case Is >= 50, Is < 80
                            row.Cells("진행율").Style.BackColor = Color.DarkOrange
                        Case Else
                            row.Cells("진행율").Style.BackColor = Color.Red
                    End Select
                End If
                If Not (row.Cells("NG").Value Is Nothing) Then
                    row.Cells("NG").Value = If(row.Cells("NG").Value.ToString = "", 0, row.Cells("NG").Value)
                    If CInt(row.Cells("NG").Value) > 0 Then
                        row.Cells("NG").Style.BackColor = Color.Red
                    End If
                End If
            End If

            '// =============================================================================================
            '// Score View 관련
            '// =============================================================================================
            Try
                If (txtHigh.Text <> "") And (txtMiddle.Text <> "") And (txtLow.Text <> "") Then

                    If (CDbl(Val(row.Cells("Level").Value)) >= CDbl(txtHigh.Text)) Then '// 4 <= 4
                        ' 녹색 계열
                        row.Cells("Level").Style.BackColor = Color.FromArgb(179, 255, 179)

                    ElseIf (CDbl(Val(row.Cells("Level").Value)) >= CDbl(txtMiddle.Text)) Then '// 4 <= 3
                        '노란 계열
                        row.Cells("Level").Style.BackColor = Color.FromArgb(255, 231, 155)
                    ElseIf (CDbl(Val(row.Cells("Level").Value)) < CDbl(txtLow.Text)) Then  '// 4 > 2
                        ' 레드 계열
                        row.Cells("Level").Style.BackColor = Color.FromArgb(255, 159, 159)
                    Else
                        row.Cells("Level").Style.BackColor = Color.FromArgb(255, 159, 159)
                    End If

                End If
            Catch ex As Exception

            End Try


        Next




    End Sub
    Private Sub settingsVisible(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Setting_pnael.Visible = False Then
            Setting_pnael.Visible = True
        Else
            Setting_pnael.Visible = False
        End If
    End Sub

    Private Sub Change_ScoreValue(sender As Object, e As EventArgs) Handles txtHigh.TextChanged, txtMiddle.TextChanged, txtLow.TextChanged
        calColor()

    End Sub

    Private Sub BtnMD_Click(sender As Object, e As EventArgs) Handles btnMD.Click

        If btnMDSave.Visible = True Then
            btnMDSave.Visible = False
            DataGridView1.DataSource = Nothing
            Search_Database()
            Exit Sub
        Else
            btnMDSave.Visible = True
        End If


        Dim ListInputChk As List(Of String) = New List(Of String) From {
            cbPro.Text, cbGrp.Text, cbMod.Text, cbStep.Text
        }

        Dim cnt As Integer = ListInputChk.Where(Function(x) x = "" Or x.Contains("선택") = True).Count
        If (cnt > 0) Then
            Qportals.Debugging.Show("모델 정보를 다 입력 후 눌러주세요.")
            btnMDSave.Visible = False
            Exit Sub
        End If

        Dim sql As String
        sql = String.Format(
           "SELECT DISTINCT Step, Category, TCtype, MD FROM " & cdb.get_assign_testcase & " 
            WHERE Category = 'Function' AND Project = '{0}' And GroupName = '{1}' And Model = '{2}' And Step = '{3}'
            UNION ALL
            SELECT DISTINCT Step, Category, TestItem, MD FROM " & cdb.get_assign_testcase & " 
            WHERE NOT Category = 'Function' AND Project = '{0}' And GroupName = '{1}' And Model = '{2}' And Step = '{3}'",
        cbPro.Text, cbGrp.Text, cbMod.Text, cbStep.Text)

        Dim dt As DataTable = dbc.Mysql_to_datatable(sql)
        DataGridView1.DataSource = dt

    End Sub '// MD 입력하기 버튼을 눌렀을 때

    Private Sub MDUpdate(sender As Object, e As EventArgs) Handles btnMDSave.Click

        Dim isNum As Boolean = False
        Dim chk_list As List(Of Boolean) = New List(Of Boolean)
        Dim sql As String, whereSQL As String
        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        ' C#     datatable dt = (datatable) datagridview1.datasource
        ' vb.net Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)

        ' MD Row 반복
        For Each dr As DataRow In dt.Rows

            ' MD 부분에 숫자가 들어가면 안되니까 예외 처리 함
            If (Char.IsDigit(dr.Item("MD").ToString)) Then

                ' Function TC는 ex) Application 부분에 통으로 MD를 넣어주기 위함.
                If dr.Item("Category") Like "Fun*" Then
                    whereSQL = String.Format("Where TCtype = '{0}' And Project = '{1}' AND GroupName = '{2}' AND Model = '{3}' AND Step = '{4}'",
                                        dr.Item("TCtype"), cbPro.Text, cbGrp.Text, cbMod.Text, cbStep.Text)
                Else
                    whereSQL = String.Format("Where  TestItem = '{0}' And Project = '{1}' AND GroupName = '{2}' AND Model = '{3}' AND Step = '{4}'",
                                        dr.Item("TCtype"), cbPro.Text, cbGrp.Text, cbMod.Text, cbStep.Text)
                End If

                sql = String.Format("UPDATE " & cdb.get_assign_testcase & "  SET MD = {0} ", dr.Item("MD"))
                sql += whereSQL

                Dim chk As Boolean = dbc.Query_to_Mysql(sql)
                chk_list.Add(chk)

            ElseIf Not dr.Item("MD").ToString = "" And Not (Char.IsDigit(dr.Item("MD").ToString)) Then
                ' 빈칸은 경고를 띄우지 않도록
                isNum = True
            End If

        Next


        Dim cnt As Integer = chk_list.Where(Function(x) x = False).Count

        If (cnt > 0) Then
            Qportals.Debugging.Show("올바르게 저장되지 않았습니다. 다시 시도해주세요.")
        Else
            Qportals.Debugging.Show("성공적으로 저장되었습니다.")
        End If


        ' 만약 문자를 입력했다면? 
        If (isNum = True) Then
            Qportals.Debugging.Show("숫자만 입력 하세요.")
        End If

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint
        '// Setting Panel 보여주기.
        Setting_pnael.Visible = False
    End Sub
End Class
