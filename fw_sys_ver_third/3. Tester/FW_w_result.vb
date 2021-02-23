Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Public Class FW_w_result
    Private cdb As c_db.assign_mem = New c_db.assign_mem
    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Public Shared f As FW_w_result
    Property _dtable As DataTable
    Private _dgv As DataGridView
    Private _laCompany As Label
    Private _laPart As Label
    Private _laUser As Label
    Private _cbItemLists As ComboBox

    Public Sub New()

        InitializeComponent()

        '// Dgb 및 control 설정
        __Init__()

    End Sub

    Private Sub __Init__()

        _dgv = DataGridView1
        _laCompany = laComp
        _laUser = laName
        _cbItemLists = cbItemList

        __SetDgv__()

        __OtherControlSet__()

        __load_testcase__()

    End Sub

#Region "Initionalize Methods"
    Private Sub __SetDgv__()

        With _dgv

            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 23
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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

            '----------DataGridView--Font------------
            .DefaultCellStyle.Font = New Font("맑은 고딕", 8)
            .ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 8)


        End With

        '// 컬럼에 들어갈 항목들을 배열에 저장 합니다.
        Dim strcolumns() As String = New String() {"Category", " 구분", " Framework", "검증원", "MD", " 진행율", " TOTAL", " OK", " NG", " NT", " 미구현", " 사업자", " T/C error", " Network", " 장비미보유", " 환경ETC", " ETC"}
        _dtable = New DataTable()

        '// 데이터 테이블에 컬럼을 추가합니다.
        For Each c As String In strcolumns
            _dtable.Columns.Add(New DataColumn(c))
        Next




        '_dtable.Columns("진행율").DataType = GetType(Double)

        '// DataGridView DataSource에 넣습니다.
        _dgv.DataSource = _dtable

        For i As Integer = 0 To _dgv.Columns.Count - 1
            If i >= 0 And i <= 3 And Not i = 2 Then
                _dgv.Columns(i).Width = 70
            ElseIf i = 2 Then
                _dgv.Columns(i).Width = 250
            Else
                _dgv.Columns(i).Width = 40
            End If
        Next

    End Sub

    Private Sub __OtherControlSet__()

        _cbItemLists.ForeColor = Color.DimGray

        CheckBox1.Checked = True

    End Sub
#End Region
    Private Sub Pic_Refresh_Click(sender As Object, e As EventArgs) Handles pic_Refresh.Click
        '// 리프레시 버튼 선택하기
        __load_testcase__()
    End Sub

    Private UserName As String
    Private Sub import_company()
        '// 소속회사 검증원 가져오기
        'Dim getUser As Qportals.ComputerInfo = New Qportals.ComputerInfo
        'UserName = getUser.getUserName
        'Dim UserCompany As String = Nothing, UserPart As String = Nothing

        ''* 2019-09-03 검증원 정보 수정
        ''* 이름을 가지고 회사명을 가져옵니다.
        'Dim dt_comp As DataTable = getUser.GetContact(UserName)
        'Try
        '    UserCompany = dt_comp.Rows(0).Item(2).ToString   ' 업체
        '    UserPart = dt_comp.Rows(0).Item(3).ToString ' 부서
        'Catch ex As Exception
        '    Qportals.Debugging.Show("등록되지 않은 인원 입니다. " & vbCrLf & "관리자에게 문의하여 인원 등록 바랍니다.")
        'End Try

        'If (UserCompany.Contains(">")) Then
        '    UserCompany = UserCompany.Split(">")(1)
        '    UserCompany = Trim(UserCompany)
        'End If

        ' ** 조회 된 정보를 Label에 저장 합니다.
        _laUser.Text = "검증원 : " & Main_index.f._user
        _laCompany.Text = "소속 회사 : " & Main_index.f._company
    End Sub

    Private Sub __load_testcase__()
        '// 할당된 티씨 불러오기

        import_company()    '// 소속회사 가져오기


        ' * 할당 내역이 있는지 조회 해서 콤보박스에 뿌려줍니다.
        Dim sql As String, dt_temp As DataTable = New DataTable
        Dim var As String
        sql = "SELECT DISTINCT Project, GroupName, Model, Step FROM " & cdb.get_assign_testcase & " "
        sql += If(CheckBox1.Checked = False, " where ", " where DATE_FORMAT(insert_date, ""%Y-%m-%d"") = CURDATE() and")
        sql += String.Format(" Tester = '{0}' ", UserName)
        dt_temp = dbc.Mysql_to_datatable(sql)

        Dim remove_duplicate_dt As DataTable = New DataTable
        '// 오늘날짜 Date Query가 들어가므로 중복제거가 풀리는 현상 발생
        '// 원본 테이블을 복사해서 중복을 제거하고 combobox에 
        remove_duplicate_dt = dt_temp.Copy
        remove_duplicate_dt.DefaultView.ToTable(True, "Project", "GroupName", "Model", "Step")

        If Not (remove_duplicate_dt Is Nothing) AndAlso (remove_duplicate_dt.Rows.Count > 0) Then
            _cbItemLists.Items.Clear()
            For Each dr As DataRow In remove_duplicate_dt.Rows
                var = String.Format("{0},{1},{2},{3}",
                dr.Item(0).ToString, dr.Item(1).ToString,
                dr.Item(2).ToString, dr.Item(3).ToString)
                _cbItemLists.Items.Add(var)
            Next
            _cbItemLists.Text = "여기를 눌러 할당 된 모델을 선택하세요."
        Else
            _cbItemLists.Text = "할당 된 모델이 없습니다."
        End If

    End Sub

    Private Sub CheckToday(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        '// 오늘데이터만 보기 체크/해제
        __load_testcase__()

    End Sub
    Private Sub ClickTestCase(sender As Object, e As EventArgs) Handles cbItemList.SelectedIndexChanged

        '// 클릭 시 기본 Font Color 변경되도록 
        _cbItemLists.ForeColor = Color.Black

        '// 콤보 박스 선택 시 동작 되는 Code
        __Click_Combobox__()

    End Sub

    Public Sub DataGridViewChange(sender As Object, e As EventArgs) Handles DataGridView1.CellValueChanged

        '// 셀 내용이 바뀌면 점수 계산을 합니다.
        __setCalScore()

    End Sub


    Private Function Get_RandomTable(ByRef dt As DataTable) As DataTable
        Dim tempdt As DataTable = New DataTable

        With tempdt.Columns
            .Add("Category")
            .Add("TCtype")
            .Add("TestItem")
        End With

        Try

            Dim query = From r In dt.AsEnumerable()
                        Where r.Field(Of String)("Category") Like "*Random*"
                        Select New With
                            {
                                .Category = r.Field(Of String)("Category"),
                                .TCtype = r.Field(Of String)("TCtype"),
                                .TestItem = r.Field(Of String)("TestItem")
                            }

            For Each item In query
                tempdt.Rows.Add(item.Category, item.TCtype, item.TestItem)
            Next

        Catch ex As Exception
            Qportals.Debugging.Show(ex.Message)
        End Try

        Return tempdt

    End Function


    '// DataGridView 클릭 했을 때 랜덤 입력화면 띄워줍니다.
    Public Sub Random_TestClick(sender As Object, e As EventArgs) Handles DataGridView1.Click
        'Dim rd_click As Random_Write_Form
        'Dim tf As New Form

        'Dim tempdt As DataTable = TryCast(DataGridView1.DataSource, DataTable)

        'Try
        '    If (_dgv.Item("TCtype", _dgv.CurrentCell.RowIndex).Value Like "*Random*") Then

        '        tempdt = Get_RandomTable(tempdt)

        '        rd_click = New Random_Write_Form With {.Owner = tf}
        '        rd_click.__cblist = cbItemList
        '        rd_click.la_Tester.Text = laName.Text
        '        rd_click.la_company.Text = laComp.Text
        '        rd_click.__TCDatatable = tempdt
        '        rd_click.Show()

        '    End If
        'Catch ex As Exception
        '    Qportals.Debugging.Print(ex.Message)
        'End Try

    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        '// 콤보 박스 선택 시 동작 되는 Code
        __Click_Combobox__()
    End Sub


#Region "Click_Combobox Methods"
    Private Sub __Click_Combobox__()

        ' 할당 된 아이템 선택 했을 때
        Dim sPjt As String = Nothing, sGrp As String = Nothing, sMod As String = Nothing, sStep As String = Nothing
        Dim sql As String, user As String, company As String
        Dim sPjtsql As String, sGrpsql As String, sModsql As String, sStepsql As String


        If Not (_cbItemLists.Text.ToString.Contains("여기를 눌러")) And Not (_cbItemLists.Text = "") And Not (_cbItemLists.Text.ToString.Contains("할당 된 모델이")) Then

            ' 프로젝트 / 그룹 / 모델 / 차수 
            For i As Integer = 0 To Split(_cbItemLists.Text, ",").Length
                Select Case i
                    Case 0
                        sPjt = Split(_cbItemLists.Text, ",")(i) : sPjt = LTrim(sPjt)
                    Case 1
                        sGrp = Split(_cbItemLists.Text, ",")(i) : sGrp = LTrim(sGrp)
                    Case 2
                        sMod = Split(_cbItemLists.Text, ",")(i) : sMod = LTrim(sMod)
                    Case 3
                        sStep = Split(_cbItemLists.Text, ",")(i) : sStep = LTrim(sStep)
                End Select

            Next

            user = _laUser.Text.Substring(CInt("검증원 : ".Length))
            company = _laCompany.Text.Substring(CInt("소속 회사 : ".Length))
            company = company.Replace("Test E&&C", "Test E&C")

            '# make Query
            sPjtsql = String.Format(" Project = '{0}' and ", sPjt)
            sGrpsql = String.Format(" GroupName = '{0}' and ", sGrp)
            sModsql = String.Format(" Model = '{0}' and ", sMod)
            sStepsql = String.Format(" Step = '{0}' and ", sStep)


            sql = "select id, Category, TCtype, TestItem, `진행율`, `TOTAL`, OK, NG, NT, `미구현`, `사업자`, `T/C error`, `Network`, `장비미보유`, `환경ETC`, `ETC`, `TC_Comment`"
            sql += " FROM " & cdb.get_assign_testcase & " "
            sql += If(CheckBox1.Checked = False, " where ", " where DATE_FORMAT(insert_date, ""%Y-%m-%d"") = CURDATE() and")
            Dim Userchk As String = String.Format(" `Tester` = '{0}' and `company` = '{1}' ", user, company)
            sql += " " & sPjtsql & sGrpsql & sModsql & sStepsql & Userchk


            _dtable = New DataTable
            _dtable = If(sql = "", Nothing, dbc.Mysql_to_datatable(sql))


            '// 복사 할 DataTable 만들고 
            Dim dtCloned As DataTable = _dtable.Clone
            dtCloned.Columns("진행율").DataType = GetType(Double)

            For Each dr As DataRow In _dtable.Rows
                dtCloned.ImportRow(dr)
            Next

            _dtable = dtCloned


            __setPercentage()  ' 진행율을 Percentage(%) 형식으로 변경 하고, DataGridView에 DataSource를 넣습니다.

            __setCalScore()     ' 진행 결과를 계산합니다. (ex. OK, NT, NG) 

            __setColor()       ' 진행율에 맞게 Back Color 를 지정 합니다.


        End If

    End Sub

    Public Sub __setPercentage()

        If Not (_dtable Is Nothing) AndAlso (_dtable.Rows.Count > 0) Then
            With DataGridView1
                .DataSource = Nothing
                .DataSource = _dtable
                ' * 특정 ColumnHeaer 색상 칠하기.
                DataGridView1.Columns("ID").Visible = False
                For i As Integer = 0 To DataGridView1.ColumnCount - 1
                    If i >= 0 And i <= 4 And Not i = 3 Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.White
                    ElseIf i = 3 Then
                        .Columns(i).Width = 200
                        .Columns(i).HeaderCell.Style.BackColor = Color.White
                    ElseIf i >= 5 And i <= 9 Then
                        .Columns(i).Width = 50
                        .Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                    Else
                        .Columns(i).Width = 50

                    End If
                Next
                .Columns("진행율").DefaultCellStyle.Format = "#0.0.'%'"
            End With
        Else
            DataGridView1.DataSource = Nothing
        End If

    End Sub

    Private Sub __setColor()

        '* 100%가 넘으면 녹색으로 칠합니다.
        For Each row As DataGridViewRow In DataGridView1.Rows
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

        Next


    End Sub

    Private Sub __setCalScore()

        Dim OK As Integer = 0, NT As Integer = 0, NG As Integer = 0, MD As Double = 0.0
        Dim sumResult As Integer = 0, Total As Integer = 0
        Dim TCpercent As Double = 0.0

        If Not (_dtable Is Nothing) AndAlso (_dtable.Rows.Count > 0) Then

            For Each dr As DataRow In _dtable.Rows

                'MD = Val(If(dr.Item("MD").ToString = "", 0.0, dr.Item("MD").ToString))

                OK = Val(dr.Item("OK").ToString)
                NG = Val(dr.Item("NG").ToString)
                NT = Val(dr.Item("NT").ToString)

                sumResult = OK + NG + NT
                Total = Val(dr.Item("TOTAL").ToString)
                TCpercent = If(Total = 0, 0.0, (sumResult / Total) * 100)
                If Double.IsNaN(TCpercent) Then
                    TCpercent = 0.0
                End If

                If Total < sumResult Then
                    dr.Item("진행율") = dr.Item("진행율")
                    Qportals.Debugging.Show("Total 갯수보다 많습니다. 다시 확인해주세요.")
                Else
                    dr.Item("진행율") = TCpercent
                End If

            Next
            __setColor()

        End If

    End Sub


    Private Sub Check_Overflow(e As DataGridViewCellEventArgs)
        '// 별도로 높은 수치를 입력하게 되면 팝업을 띄우기 위함.
        If _dgv(3, e.RowIndex).Value < _dgv(4, e.RowIndex).Value Then

        End If

    End Sub



#End Region


    Private Sub __OpenRandomPanel__()







    End Sub




    Private Sub SetdgvStyle(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim dgvstyle As Qportals.Controls.dgvStyle = New Qportals.Controls.dgvStyle
        dgvstyle.Grid_RowPostPaint(DataGridView1, e)
    End Sub

#Region "DB업로드하기"

    Private Sub DBUP(sender As Object, e As EventArgs) Handles btnUpload.Click

        ' 정말 업로드 할 것인지 체크를 합니다.
        Dim result As DialogResult = MessageBox.Show("정말 업로드 하시겠습니까?" & Environment.NewLine & Environment.NewLine & Now().ToString, "lee.sunbae@lgepartner.com", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Exit Sub
        End If

        ' * DataGridView => DataTable 
        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        'dt.AcceptChanges()

        Dim intID As Integer = 0
        Dim strPjt As String
        Dim strGrp As String
        Dim strMod As String
        Dim strStep As String
        Dim strTester As String
        Dim strCompany As String


        ' 프로젝트 / 그룹 / 모델 / 차수 
        For i As Integer = 0 To Split(cbItemList.Text, ",").Length
            Select Case i
                Case 0
                    strPjt = Split(cbItemList.Text, ",")(i) : strPjt = LTrim(strPjt)
                Case 1
                    strGrp = Split(cbItemList.Text, ",")(i) : strGrp = LTrim(strGrp)
                Case 2
                    strMod = Split(cbItemList.Text, ",")(i) : strMod = LTrim(strMod)
                Case 3
                    strStep = Split(cbItemList.Text, ",")(i) : strStep = LTrim(strStep)
            End Select

        Next

        strTester = laName.Text.Substring(CInt("검증원 : ".Length))
        strCompany = laComp.Text.Substring(CInt("소속 회사 : ".Length))

        '# make Query
        'strPjt = String.Format(" a.Project = '{0}' and ", Split(cbItemList.Text, ",")(0))
        'strGrp = String.Format(" a.GroupName = '{0}' and ", Split(cbItemList.Text, ",")(1))
        'strMod = String.Format(" a.Model = '{0}' and ", Split(cbItemList.Text, ",")(2))
        'strStep = String.Format(" a.Step = '{0}' and ", Split(cbItemList.Text, ",")(3))


        ' Project 정보를 Single Quaty 문자 제거 및 값 할당.
        strPjt = remove_quarter(strPjt)
        strGrp = remove_quarter(strGrp)
        strMod = remove_quarter(strMod)
        strStep = remove_quarter(strStep)

        Dim sumsql As String = "", delsql As String
        Dim insert_count As Integer = 0
        Dim sql As String

        Dim strCate As String
        Dim strType As String
        Dim strItem As String


        Dim MD As Double
        Dim 진행율 As Double
        Dim TOTAL As Integer
        Dim OK As Integer
        Dim NG As Integer
        Dim NT As Integer
        Dim 미구현 As Integer
        Dim 사업자 As Integer
        Dim TCERROR As Integer
        Dim NETWORK As Integer
        Dim 장비미보유 As Integer
        Dim 환경ETC As Integer
        Dim ETC As Integer
        Dim comment As String

        Dim chkErr As Boolean
        Dim log1 As String, log2 As String


        ' * 실제 DB에 올리는 코드입니다.
        For Each dr As DataRow In dt.Rows

            ' DB에 들어갈 기본 정보들을 만듭니다.

            intID = If(dr.Item(0).ToString = "", 0, CInt(dr.Item(0)))           ' ID   

            strCate = remove_quarter(dr.Item(1).ToString)   ' Category
            strType = remove_quarter(dr.Item(2).ToString)   ' TC type   
            strItem = remove_quarter(dr.Item(3).ToString)   ' Test item                
            strTester = remove_quarter(dr.Item(4).ToString) ' Tester
            strCompany = remove_quarter(dr.Item(5).ToString) ' Company

            'MD = Val(dr.Item("MD").ToString)
            진행율 = Val(dr.Item("진행율").ToString)
            TOTAL = Val(dr.Item("TOTAL").ToString)
            OK = Val(dr.Item("OK").ToString)
            NG = Val(dr.Item("NG").ToString)
            NT = Val(dr.Item("NT").ToString)
            미구현 = Val(dr.Item("미구현").ToString)
            사업자 = Val(dr.Item("사업자").ToString)
            TCERROR = Val(dr.Item("T/C error").ToString)
            NETWORK = Val(dr.Item("NETWORK").ToString)
            장비미보유 = Val(dr.Item("장비미보유").ToString)
            환경ETC = Val(dr.Item("환경ETC").ToString)
            ETC = Val(dr.Item("ETC").ToString)

            comment = remove_quarter(dr.Item("TC_Comment").ToString)

            sql = "update FROM " & cdb.get_assign_testcase & " set "
            ' sql += "`MD` = " & MD & " , "
            sql += "`진행율` = " & 진행율 & " , "
            sql += "`TOTAL` = " & TOTAL & " , "
            sql += "`OK` = " & OK & " , "
            sql += "`NG` = " & NG & " , "
            sql += "`NT` = " & NT & " , "
            sql += "`미구현` = " & 미구현 & " , "
            sql += "`사업자` = " & 사업자 & " , "
            sql += "`T/C error` = " & TCERROR & " , "
            sql += "`Network` = " & NETWORK & " , "
            sql += "`장비미보유` = " & 장비미보유 & " , "
            sql += "`환경ETC` = " & 환경ETC & " , "
            sql += "`ETC` = " & ETC & " , "
            sql += "`TC_Comment` = '" & comment & "' "
            sql += " where ID = " & intID

            chkErr = dbc.Query_to_Mysql(sql)

            insert_count += 1

        Next


        If (chkErr = True) Then
            Qportals.Debugging.Show("정상적으로 F/W가 수정되었습니다." & vbCrLf & insert_count & "건")
        Else
            Qportals.Debugging.Show("올바르게 올라가지 않았을 수 있습니다.")
        End If


    End Sub
    Private Function remove_quarter(ByRef strText As String)
        strText = Replace(strText, "'", "")
        Return strText
    End Function

#End Region

#Region "엑셀 추출하기"

    Private Sub DownloadExcels()

        Dim ep As Qportals.External_library.EPPlus = New Qportals.External_library.EPPlus
        Dim fi As Qportals.FileControl = New Qportals.FileControl
        Dim _dt As DataTable = New DataTable

        _dt = TryCast(DataGridView1.DataSource, DataTable)

        If Not (_dt Is Nothing) Then

            Dim makeFileName As String
            Dim files() As String = Split(cbItemList.Text, ",")

            makeFileName = String.Format("{0}_{1}_{2}_{3}", files(0), files(1), files(2), files(3))

            ep.datatable_to_excel(_dt, makeFileName)


        End If

    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        DownloadExcels()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub






#End Region



End Class
