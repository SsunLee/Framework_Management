





Public Class Addmin_System

    Private _dt As DataTable
    Private _date_info_dt As DataTable
    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Private cdb As c_db.assign_mem = New c_db.assign_mem

    Private _dgv As DataGridView
    Public Sub New()

    End Sub
    Private _company As String
    Private _user As String

    Protected Friend _txtBoxs As List(Of TextBox) = New List(Of TextBox)
    ''' <summary>
    ''' 투입 현황 전용 
    ''' </summary>
    ''' <param name="dgv"> 모델현황을 가져오는 dgv </param>
    ''' <param name="txtboxs"> 총원/투입MD/휴가/../../ </param>
    Public Sub New(ByRef dgv As DataGridView, ByRef txtboxs() As TextBox)

        _user = Main_index.f._user
        _company = Main_index.f._company

        For Each txtBox As TextBox In txtboxs
            _txtBoxs.Add(txtBox)
        Next
        _dgv = dgv

    End Sub






#Region "투입 현황"
    ''' <summary>
    ''' 투입 현황을 가져오는 메서드입니다.
    ''' </summary>
    ''' <param name="_date">특정 날짜기준으로 쿼리 하도록 되어있음.</param>
    Public Function m_mem_Load_model_list_forSearch(ByRef _date As String) As String
        Dim cmt As String
        Dim currentMethodName As String = NameOf(m_mem_Load_model_list_forSearch)
        Dim errChk As Boolean = False

        Dim sql As String = String.Format(
            "SELECT 
                t_pjt AS Project, 
                t_model AS Model, 
                t_Step AS Step, 
                t_mem AS `member`
            FROM " & cdb.get_manage_model & "
            WHERE 
                company = '{1}' AND 
                `t_date` = '{0}'",
            CDate(_date.ToString).ToString("yyyy-MM-dd"), _company)
        _dt = New DataTable
        _dt = dbc.Mysql_to_datatable(sql)


        If (_dt.Rows.Count > 0) Then
            '// 투입 현황 뿌리기
            m_mem_makeList(_dt, currentMethodName)

            '// 투입 MD 뿌리기
            '// 하단 투입현황(모델현황) 불러오기
            sql = String.Format("select * from assign_mem.`manage_date` where t_date = '{0}'", CDate(_date.ToString).ToString("yyyyMMdd"))
            _date_info_dt = dbc.Mysql_to_datatable(sql)
            m_mem_makeMD(_date_info_dt, currentMethodName)
            cmt = String.Format("{0} 일자 기준 Successfull", _date)
        Else
            cmt = String.Format(
"{0} 일자로 등록 된 투입 현황이 없습니다. 
            ▶ 투입 현황에서 등록 해주세요. ", _date)

        End If

        Return cmt

    End Function
    ''' <summary>
    ''' 엑셀로 드래그 했을 때 진입 점
    ''' </summary>
    ''' <param name="strPath"> 드래그한 엑셀 파일 주소 </param>
    Public Sub m_mem_Load_model_list_forDragDrop(strPath As String)
        Dim currentMethodName As String = NameOf(m_mem_Load_model_list_forDragDrop)
        Dim strExtension As String = Nothing
        Dim fi As New IO.FileInfo(strPath)

        '# 확장자 알아내기
        strExtension = fi.Extension

        If strExtension <> ".xlsx" Then
            MessageBox.Show("확장자가 ""xlsx"" 인 엑셀 파일만 올려주세요. ", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '# 2. [Excel File to DataGridView]
        Dim ds_set As DataSet = Excel_File_to_DataGridView(strPath, "C11:AA100")

        m_mem_makeList(ds_set.Tables("Models"), currentMethodName)
        m_mem_makeMD(ds_set.Tables("Info"), currentMethodName)


    End Sub

    ''' <summary>
    ''' 데이터 테이블을 가지고 데이터그리드뷰에 현황표를 띄워주는 메서드
    ''' </summary>
    ''' <param name="_dt"> 현황표 데이터 </param>
    ''' <param name="_strMethodName"> 어떤 메서드로 들어왔는지 Check </param>
    Private Sub m_mem_makeList(_dt As DataTable, _strMethodName As String)
        Dim errChk As Boolean = False
        Dim outTable As DataTable

        '// 예외 처리 : 할당 된 모델 리스트가 없으면 나가기
        If Not (_dt Is Nothing) And (_dt.Rows.Count > 0) Then
            _dgv.Refresh()
            If (_strMethodName <> "m_mem_Load_model_list_forDragDrop") Then
                outTable = GenerateTransposedTable_WithoutModel(_dt)
            Else
                outTable = _dt
            End If

            _dgv.DataSource = outTable
            _dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White
            _dgv.EnableHeadersVisualStyles = False
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            _dgv.ColumnHeadersVisible = False

            Dim num As Integer = 1

            _dgv.RowHeadersWidth = 80
            For Each dr As DataGridViewRow In _dgv.Rows

                'dr.HeaderCell.
                dr.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                dr.HeaderCell.Style.Font = New Font("맑은 고딕", 9.0F, FontStyle.Bold)
                If dr.Index = 0 Then
                    dr.HeaderCell.Value = "PJT"
                    Set_DataGridViewColor(dr, "DarkGray")
                ElseIf dr.Index = 1 Then
                    dr.HeaderCell.Value = "모델"
                    Set_DataGridViewColor(dr, "DarkGray")
                ElseIf dr.Index = 2 Then
                    dr.HeaderCell.Value = "차수"
                    Set_DataGridViewColor(dr, "DarkGray")
                Else
                    dr.HeaderCell.Value = String.Format("{0}", num)
                    dr.HeaderCell.Style.BackColor = Color.White
                    num += 1
                End If
            Next

            For Each dc As DataGridViewColumn In _dgv.Columns
                dc.SortMode = DataGridViewColumnSortMode.NotSortable
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            errChk = True

        Else
            errChk = False

        End If
        _dgv.Refresh()
        Debug.Print(_strMethodName)




    End Sub
    Private Function m_mem_makeMD(ByRef _date_info_dt As DataTable, _strMethodName As String) As Boolean
        Dim errChk As Boolean = False

        If Not (_date_info_dt Is Nothing) And (_date_info_dt.Rows.Count > 0) Then

            If (_strMethodName <> "m_mem_Load_model_list_forDragDrop") Then

                _txtBoxs(0).Text = _date_info_dt.Rows(0)("tt")
                _txtBoxs(1).Text = _date_info_dt.Rows(0)("t_md")
                _txtBoxs(2).Text = _date_info_dt.Rows(0)("t_md_vac")
                _txtBoxs(3).Text = _date_info_dt.Rows(0)("t_md_buf")
                _txtBoxs(4).Text = _date_info_dt.Rows(0)("t_md_empty")
                _txtBoxs(5).Text = _date_info_dt.Rows(0)("t_md_edu")
                errChk = True

            Else
                _txtBoxs(0).Text = _date_info_dt.Rows(0)("총원").ToString
                _txtBoxs(1).Text = _date_info_dt.Rows(0)("투입MD").ToString
                _txtBoxs(2).Text = _date_info_dt.Rows(0)("휴가").ToString
                _txtBoxs(3).Text = _date_info_dt.Rows(0)("유휴MD").ToString
                _txtBoxs(4).Text = _date_info_dt.Rows(0)("예비인원").ToString
                _txtBoxs(5).Text = _date_info_dt.Rows(0)("교육").ToString
                errChk = True
            End If



        Else
            errChk = False
        End If

        Return errChk

    End Function


    ''' <summary>
    ''' Color 색상을 넣으면 DataGridView의 색상을 변경 해주는 코드
    ''' </summary>
    ''' <param name="dr"> 색상을 바꿀 Row </param>
    ''' <param name="colorName"> 색상을 바꿀 Column </param>
    Private Sub Set_DataGridViewColor(ByRef dr As DataGridViewRow, ByRef colorName As String)
        With dr.DefaultCellStyle
            .BackColor = Color.FromName(colorName)
            .Font = New Font("맑은 고딕", 9.0F, FontStyle.Bold)
            .ForeColor = Color.White
        End With
    End Sub

#Region "DataTable - Transpose(행/열 전환)"
    ''' <summary>
    ''' DataTable을 넣으면 세로로 되어있는 Table을 가로로 변경 하게 됨.
    ''' 즉, Column 기준으로 쪼개서 가로로 변환
    ''' </summary>
    ''' <param name="inputTable"></param>
    ''' <returns></returns>
    Private Function GenerateTransposedTable_WithoutModel(ByRef inputTable As DataTable) As DataTable
        Dim _inputdt As DataTable = inputTable

        Dim outputTable As DataTable = New DataTable()
        Dim rowcnt As Integer = 0
        Dim colum_table As DataTable = New DataTable()

        Dim row_list As List(Of String) = New List(Of String)
        'Using LINQ
        Dim subTables As List(Of DataTable) = _inputdt.AsEnumerable().GroupBy(
                Function(p) New With {Key .pjt = p.Field(Of String)("Project"), Key .model = p.Field(Of String)("Model")}) _
                .[Select](Function(p) p.CopyToDataTable()).ToList()

        Dim tempdts() As DataTable
        ReDim tempdts(0 To subTables.Count)

        Dim c As Integer = 0
        For Each dt As DataTable In subTables

            Dim tempdt As DataTable = New DataTable
            tempdt.Columns.Add(New DataColumn("col" & c + 1))

            For i As Integer = 0 To dt.Rows.Count - 1

                If i = 0 Then
                    tempdt.Rows.Add(If(dt.Rows(i)("Project") Is Nothing, "", dt.Rows(i)("Project").ToString))
                    tempdt.Rows.Add(If(dt.Rows(i)("Model") Is Nothing, "", dt.Rows(i)("Model").ToString))
                    tempdt.Rows.Add(If(dt.Rows(i)("Step") Is Nothing, "", dt.Rows(i)("Step").ToString))
                    tempdt.Rows.Add(dt.Rows(i)("member").ToString)
                Else
                    tempdt.Rows.Add(dt.Rows(i)("member").ToString)
                End If

            Next i
            tempdts(c) = tempdt
            c += 1

        Next

        '// 여기 부터는 tables가 완성 된 이후 
        Dim result_dt As DataTable
        result_dt = Merge(tempdts)


        Return If(result_dt Is Nothing, Nothing, result_dt)

    End Function

    Private Function GenerateTransposedTable(ByRef inputTable As DataTable) As DataTable
        Dim _inputdt As DataTable = inputTable
        Dim outputTable As DataTable = New DataTable()
        Dim rowcnt As Integer = 0
        Dim colum_table As DataTable = New DataTable()

        Dim row_list As List(Of String) = New List(Of String)
        'Using LINQ
        Dim subTables As List(Of DataTable) = _inputdt.AsEnumerable().GroupBy(
                Function(p) p.Field(Of String)("Model")) _
                .[Select](Function(p) p.CopyToDataTable()).ToList()

        Dim tempdts() As DataTable
        ReDim tempdts(0 To subTables.Count)

        Dim c As Integer = 0
        For Each dt As DataTable In subTables

            Dim tempdt As DataTable = New DataTable
            tempdt.Columns.Add(dt.Rows(0)("Model").ToString)

            For i As Integer = 0 To dt.Rows.Count - 1

                If i = 0 Then
                    tempdt.Rows.Add(If(dt.Rows(i)("Step") Is Nothing, "", dt.Rows(i)("Step").ToString))
                    tempdt.Rows.Add(dt.Rows(i)("member").ToString)
                Else
                    tempdt.Rows.Add(dt.Rows(i)("member").ToString)
                End If

            Next i
            tempdts(c) = tempdt
            c += 1

        Next

        '// 여기 부터는 tables가 완성 된 이후 
        Dim result_dt As DataTable
        result_dt = Merge(tempdts)

        Return result_dt

    End Function

    Private Function Merge(dataTables() As DataTable) As DataTable

        Dim oList As List(Of Integer) = New List(Of Integer)
        Dim mergedDataTable As DataTable = New DataTable

        For Each dt As DataTable In dataTables
            If (Not (dt Is Nothing)) Then
                oList.Add(dt.Rows.Count)
                For Each dc As DataColumn In dt.Columns
                    mergedDataTable.Columns.Add(dc.ColumnName, dc.DataType)
                Next
            End If
        Next

        Dim maxRow As Integer = oList.Max()
        For o As Integer = 0 To maxRow
            Dim newRow As DataRow = mergedDataTable.NewRow()
            Dim mergedDataTableColumn = 0
            For Each dt As DataTable In dataTables

                If Not (dt Is Nothing) Then
                    '// 자료가 없다면
                    If (dt.Rows.Count > o) Then

                        For k As Integer = 0 To dt.Columns.Count - 1
                            newRow(mergedDataTableColumn) = dt.Rows(o)(k)
                            mergedDataTableColumn += 1
                        Next
                    Else
                        For k As Integer = 0 To dt.Columns.Count - 1
                            newRow(mergedDataTableColumn) = DBNull.Value
                            mergedDataTableColumn += 1
                        Next
                    End If
                End If

            Next

            mergedDataTable.Rows.Add(newRow)

        Next

        Return mergedDataTable

    End Function


#Region "# 2. [File to DataGridView]"

    Private Function Excel_File_to_DataGridView(ByRef path As String, ByRef range As String, Optional ByRef titleRange As String = "B9:H10") As DataSet

        Dim vConn As System.Data.OleDb.OleDbConnection
        Dim vConn_INFO As System.Data.OleDb.OleDbConnection
        Dim DS As DataSet
        Dim myCmd As System.Data.OleDb.OleDbDataAdapter
        Dim myCmd2 As System.Data.OleDb.OleDbDataAdapter
        Dim temp_dt As DataTable = New DataTable
        Dim temp_dt2 As DataTable = New DataTable
        '# Excel 을 Database로 인식하도록 Connection String 생성
        vConn = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")
        vConn_INFO = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=YES;""")
        Try
            vConn.Open()
            vConn_INFO.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Open 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '# Connection 
        Dim dt As DataTable = New DataTable
        '# Get Sheet Name 
        dt = vConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

        Dim table_name As String = Nothing

        Try '# Sheet명 꺼내기
            table_name = dt.Rows(0).Item("Table_Name")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - 시트가 없습니다.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try '# Conn Close
            vConn.Close()
            vConn_INFO.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "(Sunbae) - DB Close 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '# Excel 을 Database로 인식하도록 Connection String 생성
        vConn = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=NO;""")
        myCmd = New System.Data.OleDb.OleDbDataAdapter("Select * FROM [" & table_name & range & "]", vConn)


        myCmd2 = New System.Data.OleDb.OleDbDataAdapter("Select * FROM [" & table_name & titleRange & "]", vConn_INFO)
        Try
            DS = New DataSet
            myCmd.Fill(DS, "Models")      '# DataSet에 엑셀에 있는 내용 모두 담음(조회 된 Query)
            myCmd2.Fill(DS, "Info")

            '# DataGridView에 Dataset Table 내용을 바인딩하여 넣음
            'temp_dt = DS.Tables(0)
            'temp_dt2

        Catch ex As Exception
            Debug.Print(ex.Message)
        Finally
            vConn.Close()
            vConn_INFO.Close()
        End Try

        Return DS

    End Function

#End Region


#End Region

    Private Function Reverse_GenerateTransposedTable_Without_Model(ByRef inputTable As DataTable) As DataTable

        Dim _inTable As DataTable = inputTable
        Dim outTable As DataTable = New DataTable
        outTable.Columns.Add("Project")
        outTable.Columns.Add("Model")
        outTable.Columns.Add("Step")
        outTable.Columns.Add("Member")
        For i As Integer = 0 To _inTable.Columns.Count - 1
            Dim strPjt As String = If(_inTable.Rows(0)(i) Is Nothing, "", _inTable.Rows(0)(i).ToString())
            Dim strModel As String = If(_inTable.Rows(1)(i) Is Nothing, "", _inTable.Rows(1)(i).ToString())
            Dim strStep As String = If(_inTable.Rows(2)(i) Is Nothing, "", _inTable.Rows(2)(i).ToString())

            For j As Integer = 3 To _inTable.Rows.Count - 1
                If Not (_inTable.Rows(j)(i) Is Nothing) And (_inTable.Rows(j)(i).ToString <> "") Then
                    'outTable.Rows.Add(strModel, strStep, _inTable.Rows(j)(i).ToString())
                    Dim rows As DataRow = outTable.NewRow()
                    rows("Project") = strPjt
                    rows("Model") = strModel
                    rows("Step") = strStep
                    rows("Member") = _inTable.Rows(j)(i).ToString()
                    outTable.Rows.Add(rows)
                End If
            Next
        Next
        Return outTable


    End Function

    Private Function Reverse_GenerateTransposedTable(ByRef inputTable As DataTable) As DataTable
        Dim _inTable As DataTable = inputTable
        Dim outTable As DataTable = New DataTable
        outTable.Columns.Add("Model")
        outTable.Columns.Add("Step")
        outTable.Columns.Add("Member")
        For i As Integer = 0 To _inTable.Columns.Count - 1
            Dim strModel As String = _inTable.Columns(i).ColumnName.ToString()
            Dim strStep As String = _inTable.Rows(0)(i).ToString()
            Dim rows As DataRow = outTable.NewRow()
            For j As Integer = 1 To _inTable.Rows.Count - 1
                If Not (_inTable.Rows(j)(i) Is Nothing) And (_inTable.Rows(j)(i).ToString <> "") Then
                    outTable.Rows.Add(strModel, strStep, _inTable.Rows(j)(i).ToString())
                End If
            Next
        Next
        Return outTable
    End Function

    Public Sub Insert_Or_Update(ByRef MDs As Dictionary(Of String, String))
        '// DUAL 키워드를 활용 예정
        Dim dbChk As Boolean = False        '// Model 투입 현황 결과를 Return 하는 bool
        Dim model_ins_cnt As Integer = 0
        Dim model_del_cnt As Integer = 0
        Dim ins_cnt As Integer = 0


        Dim _dt As DataTable = _dgv.DataSource
        If (_dt Is Nothing) Then Exit Sub
        Dim _outdt As DataTable = New DataTable
        '_outdt = Reverse_GenerateTransposedTable(_dt)
        _outdt = Reverse_GenerateTransposedTable_Without_Model(_dt)
        If (_outdt Is Nothing) Then Exit Sub


        '// manage_date : 인원 투입 정보
        Dim date_sql As String


        Dim tt As Int32, t_md As Double, t_md_vac As Double, t_md_buf As Double, t_md_edu As Double, t_md_empty As Double, t_date As String

        t_date = MDs("날짜")

        tt = Convert.ToInt32(If(MDs("총원") = "", 0, CInt(MDs("총원"))))
        t_md = Convert.ToDouble(If(MDs("투입MD").ToString = "", 0.0, CInt(MDs("투입MD").ToString)))
        t_md_vac = Convert.ToDouble(If(MDs("휴가").ToString = "", 0.0, CInt(MDs("휴가").ToString)))
        t_md_buf = Convert.ToDouble(If(MDs("유휴MD").ToString = "", 0.0, CInt(MDs("유휴MD").ToString)))
        t_md_edu = Convert.ToDouble(If(MDs("교육").ToString = "", 0.0, CInt(MDs("예비인원").ToString)))
        t_md_empty = Convert.ToDouble(If(MDs("예비인원").ToString = "", 0.0, CInt(MDs("예비인원").ToString)))

        '[MD 및 투입 현황]
        date_sql = String.Format(
            "INSERT INTO assign_mem.manage_date (company, tt,t_md, t_md_vac, t_md_buf, t_md_empty, t_md_edu, t_date) 
	                    SELECT '{0}',{1},{2},{3},{4},{5},{6},'{7}' FROM DUAL
             WHERE NOT EXISTS
	                   (SELECT * FROM assign_mem.manage_date 
                        WHERE company = '{0}'  AND t_date = '{7}');
             UPDATE assign_mem.manage_date SET tt = {1} , t_md = {2} , t_md_vac = {3} , t_md_buf = {4} , t_md_empty = {5} , t_md_edu = {6}
             where company = '{0}'  AND t_date = '{7}'",
            _company, tt, t_md, t_md_vac, t_md_buf, t_md_edu, t_md_edu, t_date)


        Dim ErrChk_Info As Boolean = False
        Dim ErrChk_model As Boolean = False


        ' 1) DB에 있는 테이블 가져오기 : Model 값도 같이 비교 해주어야 함 
        Dim sql As String = String.Format(
            "SELECT 
                t_pjt as Project, t_model as Model, t_step as Step, t_mem as Member
            FROM " & cdb.get_manage_model & " 
            WHERE company = '{0}' and t_date = '{1}'", _company, t_date)
        Dim OneBon_dt As DataTable = _outdt.Clone
        OneBon_dt = dbc.Mysql_to_datatable(sql)

        If Not (OneBon_dt Is Nothing) AndAlso ((OneBon_dt.Rows.Count > 0)) Then

            '// [원본 _dt1]  [_outdt _dt2]
            Dim rowcnt As Integer = 0

            Dim query_del = OneBon_dt.AsEnumerable().
                Where(
                    Function(_dt1)
                        Return Not _outdt.AsEnumerable().Any(
                        Function(_new)
                            Return _dt1.Field(Of String)("Project") = _new.Field(Of String)("Project") AndAlso _dt1.Field(Of String)("Model") = _new.Field(Of String)("Model") AndAlso _dt1.Field(Of String)("Step") = _new.Field(Of String)("Step") AndAlso _dt1.Field(Of String)("Member") = _new.Field(Of String)("Member")
                        End Function)
                    End Function)
            rowcnt = query_del.Count
            Dim del_dt As DataTable = New DataTable
            If rowcnt > 0 Then
                'now delete 
                del_dt = query_del.CopyToDataTable()

                For Each dr As DataRow In del_dt.Rows
                    sql = String.Format(
                        "delete 
                            from FROM " & cdb.get_manage_model & " 
                            Where company = '{0}' and t_pjt = '{1}' and t_model = '{2}' and t_mem = '{3}' and t_date = '{4}'",
                         _company, If(dr("Project") Is Nothing, "", dr("Project").ToString), dr("Model").ToString, dr("Member").ToString, t_date)

                    dbChk = dbc.Query_to_Mysql(sql)

                    model_del_cnt += 1
                Next

            End If

            ' 2) insert
            'RIGHT JOIN
            Dim query_R = _outdt.AsEnumerable().
                Where(
                Function(dt2)
                    Return Not OneBon_dt.AsEnumerable().Any(
                        Function(_new)
                            Return dt2.Field(Of String)("Project") = _new.Field(Of String)("Project") AndAlso dt2.Field(Of String)("Model") = _new.Field(Of String)("Model") AndAlso dt2.Field(Of String)("Step") = _new.Field(Of String)("Step") AndAlso dt2.Field(Of String)("Member") = _new.Field(Of String)("Member")
                        End Function)
                End Function)

            rowcnt = query_R.Count
            Dim ins_dt As DataTable = New DataTable
            If rowcnt > 0 Then
                ins_dt = query_R.CopyToDataTable()
                For Each dr As DataRow In ins_dt.Rows
                    sql = String.Format(
                        "insert into 
                                FROM " & cdb.get_manage_model & " (company, t_pjt, t_model, t_step, t_mem, t_date) 
                                Values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                        _company, If(dr("Project") Is Nothing, "", dr("Project").ToString), dr("Model").ToString, dr("Step").ToString, dr("Member").ToString, t_date)
                    dbChk = dbc.Query_to_Mysql(sql)

                    model_ins_cnt += 1
                Next

            End If

        Else

            '' [모델 현황]
            Dim model_sql As String = "INSERT INTO FROM " & cdb.get_manage_model & " (company, t_pjt, t_model, t_step, t_mem, t_date) VALUES "
            Dim model_sql_sum As String = ""
            ins_cnt = 0
            For Each dr As DataRow In _outdt.Rows
                Dim strCompany As String = If(_company = "", "", _company)
                Dim strPjt As String = remove_quarter(If(dr.Item("Project") Is Nothing, "", dr.Item("Project").ToString()))
                Dim strModel As String = remove_quarter(If(dr.Item("Model") Is Nothing, "", dr.Item("Model").ToString()))
                Dim strStep As String = remove_quarter(If(dr.Item("Step") Is Nothing, "", dr.Item("Step").ToString()))
                Dim strMem As String = remove_quarter(If(dr.Item("Member") Is Nothing, "", dr.Item("Member").ToString()))

                model_sql_sum += String.Format(
                    "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'),",
                    strCompany, strPjt, strModel, strStep, strMem, t_date)
                ins_cnt += 1

            Next

            model_sql_sum = model_sql_sum.Substring(0, Len(model_sql_sum) - 1)  '// 맨 뒤 ',' 를 지워주기 위함
            model_sql += model_sql_sum

            '// 모델정보 Insert
            ErrChk_model = dbc.Query_to_Mysql(model_sql)

        End If


        'model_sql_sum = model_sql_sum.Substring(0, Len(model_sql_sum) - 1)  '// 맨 뒤 ',' 를 지워주기 위함
        'model_sql += model_sql_sum

        '// 모델정보 Insert
        'ErrChk_model = dbc.Query_to_Mysql(model_sql)

        ErrChk_Info = dbc.Query_to_Mysql(date_sql)
        Dim cmt As String

        If (ErrChk_model) Then
            cmt = String.Format("
성공적으로 추가 되었습니다. 
정보 : {0}", ins_cnt)
            Qportals.Debugging.Show(cmt & Environment.NewLine & Now())


        Else
            If (dbChk) And (ErrChk_Info) Then
                cmt = String.Format("
성공적으로 업데이트 되었습니다. 
정보 : {0}", model_ins_cnt)
                Qportals.Debugging.Show(cmt & Environment.NewLine & Now())
            Else
                Qportals.Debugging.Show("업데이트 할 데이터가 없습니다." & Environment.NewLine & Now())
            End If
        End If



    End Sub
    Private Function remove_quarter(ByRef strText As String)
        strText = Replace(strText, "'", "")
        Return strText
    End Function


#End Region


#Region "인원 관리"
    Private m_trv_List As WinControls.ListView.TreeListView
    Private m_trv_mem As WinControls.ListView.TreeListView
    Public Property _trv_list As WinControls.ListView.TreeListView
        Get
            Return m_trv_List
        End Get
        Set(value As WinControls.ListView.TreeListView)
            m_trv_List = value
        End Set
    End Property
    ''' <summary>
    ''' 인원 관리 전용 Class 생성자
    ''' </summary>
    ''' <param name="m_trv_List"> 투입현황을 TreeListView 뿌리는 용도 </param>
    ''' <param name="m_trv_mem"> 업체 명단을 TreeListView 뿌리는 용도 </param>
    Public Sub New(
                    ByRef m_trv_List As WinControls.ListView.TreeListView,
                    ByRef m_trv_mem As WinControls.ListView.TreeListView
                  )
        Me.m_trv_List = m_trv_List
        Me.m_trv_mem = m_trv_mem

        _user = Main_index.f._user
        _company = Main_index.f._company

    End Sub
    ''' <summary>
    ''' TreeListView의 기본 컬럼 추가 및 스타일 설정 입니다.
    ''' </summary>
    Public Sub TreeListViews_Settings()
        With m_trv_List.Columns
            .Add("Model Name", 200, Windows.Forms.HorizontalAlignment.Center)
            .Add("level", 45, Windows.Forms.HorizontalAlignment.Center)
            '.Add("주특기", 110, Windows.Forms.HorizontalAlignment.Center)
            .Item(0).Font = New Font("맑은 고딕", 8.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Item(1).Font = New Font("맑은 고딕", 8.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Item(1).TextAlign = HorizontalAlignment.Center
            .Item(0).ForeColor = Color.Blue
        End With
        With m_trv_mem.Columns
            .Add("업체명", 150, Windows.Forms.HorizontalAlignment.Center)
            .Add("주특기", 110, Windows.Forms.HorizontalAlignment.Center)
            .Add("level", 45, Windows.Forms.HorizontalAlignment.Center)
            .Item(0).Font = New Font("맑은 고딕", 8.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Item(1).Font = New Font("맑은 고딕", 8.25, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold)
            .Item(0).ForeColor = Color.Blue
        End With
        With m_trv_List
            .MultiSelect = False
            .FullRowSelect = True
            .AllowDrop = True
        End With
    End Sub

    ''' <summary>
    ''' 지정한 날짜를 기준으로 인원현황을 조회하는 코드
    ''' </summary>
    ''' <param name="startDate"> 시작날짜를 입력 합니다. </param>
    ''' <param name="EndDate"> 끝나는 날짜를 입력 합니다. </param>
    ''' <returns></returns>
    Public Function Running_Model_Search(ByRef startDate As String, ByRef EndDate As String) As String
        Dim cmt As String
        Dim _startDate As String = startDate
        Dim _endDate As String = EndDate

        Dim sql = String.Format("
                SELECT 
                    mem.t_pjt AS Project,
	                mem.t_model AS Model,
	                mem.t_Step AS Step,
	                mem.t_mem AS name,
	                IF((SELECT lv.`역량` FROM " & cdb.get_manage_memlevel & " lv WHERE lv.`name` = mem.t_mem limit 1) IS NULL,0.0,
                            (SELECT lv.`역량` FROM " & cdb.get_manage_memlevel & " lv WHERE lv.`name` = mem.t_mem limit 1)) AS level,
	                IF((SELECT 주특기 FROM " & cdb.get_manage_meminfo & " jt WHERE mem.t_mem = jt.`이름`) IS NULL,'데이터 없음',
                            (SELECT 주특기 FROM " & cdb.get_manage_meminfo & " jt WHERE mem.t_mem = jt.`이름`)) AS 주특기
                FROM 
                    " & cdb.get_manage_model & " mem
                WHERE 
                    mem.company = '{0}' and mem.t_date >= '{1}' AND  mem.t_date <= '{2}'
                ORDER BY 
                    mem.t_pjt DESC, mem.t_model DESC, mem.t_step DESC, mem.t_mem DESC",
                _company, startDate, EndDate)


        Dim _model_list As DataTable = dbc.Mysql_to_datatable(sql)

        Dim templst As List(Of String) = New List(Of String)
        templst.Add("Application")
        templst.Add("Device")
        templst.Add("Telephony")
        templst.Add("Multimedia")

        Dim _newdt As DataTable = New DataTable
        Dim _columns = New String() {"Project", "Model", "Step", "name", "주특기", "level"}
        For Each s As String In _columns
            _newdt.Columns.Add(s)
        Next
        For Each dr As DataRow In _model_list.Rows
            For i As Integer = 0 To templst.Count - 1
                Dim rows As DataRow = _newdt.NewRow()
                rows("Project") = dr("Project").ToString()
                rows("Model") = dr("Model").ToString()
                rows("Step") = dr("Step").ToString()
                rows("name") = dr("name").ToString()
                rows("주특기") = templst(i).ToString()
                rows("level") = 0.0
                _newdt.Rows.Add(rows)
            Next
        Next

        ' _dt2
        sql = String.Format(
            "SELECT 
                `name`, `주특기` as 주특기, `역량` as `level`
            FROM " & cdb.get_manage_memlevel & "
            WHERE company = '{0}';", _company)
        Dim _leveldt As DataTable = dbc.Mysql_to_datatable(sql)

        For Each dr As DataRow In _newdt.Rows

            For Each dr2 As DataRow In _leveldt.Rows

                If dr("name") = dr2("name") AndAlso dr("주특기") = dr2("주특기") Then
                    dr("level") = dr2("level")
                End If
            Next
        Next

        If Not (_model_list Is Nothing) AndAlso (_model_list.Rows.Count > 0) Then
            Fill_Empty(_newdt)

            Dim after_filter_dt = _newdt.AsEnumerable().[Select](
                Function(x) New With {
                    Key .Project = x.Field(Of String)("Project"),
                    Key .Model = x.Field(Of String)("Model"),
                    Key .Step = x.Field(Of String)("Step")
            }).Where(Function(s) s.Project <> "" AndAlso s.Model <> "" AndAlso s.Step <> "").FirstOrDefault()






            make_level_Treelistview(m_trv_List, _newdt, True)
            SetColor_level_forAVG(m_trv_List.Nodes)
            cmt = String.Format("{0} ~ {1} 일자 기준 Successfull", _startDate, _endDate)
        Else
            cmt = String.Format(
            "{0} ~ {1}일자로 등록 된 투입 현황이 없습니다. 
            ▶ 투입 현황에서 등록 해주세요. ", _startDate, _endDate)
        End If

        Return cmt

    End Function
    Private Sub SetColor_level_forAVG(nodes As WinControls.ListView.Collections.TreeListNodeCollection)
        Dim trvFullPath() As String

        For Each node As WinControls.ListView.TreeListNode In nodes
            trvFullPath = node.FullPath.Split("\")

            If (trvFullPath.Length = 4) Or (trvFullPath.Length = 5) Then
                '// Fun) Application

                If node.SubItems.Count > 0 Then
                    '// Function / Fun) Application / GMS_Chrome / 5 
                    node.SubItems.Item(0).ForeColor = Color.Red

                    Select Case Convert.ToDouble(node.SubItems.Item(0).ToString)
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

    Private Sub SetCalculate_level(nodes As WinControls.ListView.Collections.TreeListNodeCollection)
        Dim trvFullPath() As String

        For Each node As WinControls.ListView.TreeListNode In nodes
            trvFullPath = node.FullPath.Split("\")

            If trvFullPath.Length > 0 And trvFullPath.Length < 2 Then

                If node.SubItems.Count > 0 Then

                    node.SubItems.Item(0).ForeColor = Color.Red


                    Select Case Convert.ToDouble(node.SubItems.Item(0).ToString)
                        Case Is >= 4   '// Green
                            node.BackColor = Color.FromArgb(179, 255, 179)
                        Case Is >= 3    '// Yello
                            node.BackColor = Color.FromArgb(255, 231, 155)
                        Case < 3    '// 
                            node.BackColor = Color.FromArgb(255, 159, 159)
                            node.Collapse()
                    End Select

                End If

                SetCalculate_level(node.Nodes)

            End If
            SetCalculate_level(node.Nodes)
        Next
    End Sub


    Private Function Fill_Empty(ByRef dt As DataTable) As DataTable
        For Each dr As DataRow In dt.Rows
            If dr("Step").ToString = "" Then
                dr("Step") = dr("Model").ToString()
            End If
        Next
        Return dt
    End Function



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

            ' 1 Depth
            If Not IsDBNull(row.Item(0)) Then
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


            ' 2 Depth
            If Not IsDBNull(row.Item(1)) Then
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
            If Not IsDBNull(row.Item(2)) Then
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
            If Not IsDBNull(row.Item(3)) Then
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
            If Not IsDBNull(row.Item(3)) Then
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


        Next row

        _trvM.EndUpdate()
        If Collab = True Then
            _trvM.ExpandAll()
        End If



    End Sub

    Private a_dt As DataTable = New DataTable
    ''' <summary>
    ''' TreeListView 에 평균역량을 보여주는 코드
    ''' </summary>
    Public Sub main_trvToDataTable()
        a_dt = New DataTable
        a_dt.Columns.Add("Project")
        a_dt.Columns.Add("Model")
        a_dt.Columns.Add("Step")
        a_dt.Columns.Add("이름")
        a_dt.Columns.Add("주특기")
        a_dt.Columns.Add("level")


        TreeListViewToDataTable(a_dt, m_trv_List.Nodes)

        ' m_trv_List.ExpandAll()

        TreeListView_GetAvg(m_trv_List.Nodes)

    End Sub
    Private Sub TreeListViewToDataTable(dt As DataTable, ByRef nodes As WinControls.ListView.Collections.TreeListNodeCollection)
        For Each node As WinControls.ListView.TreeListNode In nodes
            If node.Level = 3 Then
                Dim fullPath As String = node.FullPath
                Dim strNodes() As String = fullPath.Split("\")
                Debug.Print(node.Nodes.Item(0).ToString)
                For Each s As WinControls.ListView.TreeListNode In node.Nodes
                    dt.Rows.Add(strNodes(0), strNodes(1), strNodes(2), strNodes(3),
                        s.ToString, s.SubItems.Item(0))
                Next
            End If
            TreeListViewToDataTable(dt, node.Nodes)
        Next
    End Sub
    Private Sub TreeListView_GetAvg(ByRef Trv As WinControls.ListView.Collections.TreeListNodeCollection)

        Dim avgValue As Double
        Dim row As DataRow()
        Dim strQuery As String

        Dim strDepth0 As String : Dim strDepth1 As String : Dim strDepth2 As String : Dim strDepth3 As String

        For Each p_node As WinControls.ListView.TreeListNode In Trv

            If p_node.Nodes.Count > 0 Then
                strDepth0 = p_node.Text
                strDepth1 = p_node.Nodes.Item(0).Text
                strDepth2 = p_node.Nodes.Item(0).Nodes.Item(0).Text
                strDepth3 = p_node.Nodes.Item(0).Nodes.Item(0).Nodes.Item(0).Text

                strQuery = String.Format(
                    "[Project] = '{0}'",
                     strDepth0)
                row = a_dt.Select(strQuery)

                If row.Count > 0 Then
                    avgValue = row.AsEnumerable().Average(Function(x) x.Field(Of String)("level"))
                Else
                    avgValue = CDbl(0.0)
                End If

                p_node.SubItems.Add(avgValue.ToString("F1"))

            End If

            For Each m_node As WinControls.ListView.TreeListNode In p_node.Nodes

                If m_node.Nodes.Count > 0 Then


                    strDepth0 = m_node.ParentNode.Text
                    strDepth1 = m_node.Text


                    strQuery = String.Format(
                    "[Project] = '{0}' AND
                     [Model] = '{1}'",
                     strDepth0, strDepth1)

                    row = a_dt.Select(strQuery)
                    If row.Count > 0 Then
                        avgValue = CDbl(row.AsEnumerable().Average(Function(x) x.Field(Of String)("level"))).ToString("F1")
                    Else
                        avgValue = CDbl(0.0)
                    End If

                    m_node.SubItems.Add(avgValue.ToString("F1"))
                End If

                For Each s_node As WinControls.ListView.TreeListNode In m_node.Nodes
                    strDepth0 = s_node.ParentNode.ParentNode.Text
                    strDepth1 = s_node.ParentNode.Text
                    strDepth2 = s_node.Text

                    strQuery = String.Format(
                    "[Project] = '{0}' AND 
                     [Model] = '{1}' AND 
                     [Step] = '{2}' ",
                    strDepth0, strDepth1, strDepth2)

                    row = a_dt.Select(strQuery)
                    If row.Count > 0 Then
                        avgValue = CDbl(row.AsEnumerable().Average(Function(x) x.Field(Of String)("level"))).ToString("F1")
                    Else
                        avgValue = CDbl(0.0)
                    End If

                    s_node.SubItems.Add(avgValue.ToString("F1"))


                    For Each n_node As WinControls.ListView.TreeListNode In s_node.Nodes
                        strDepth0 = n_node.ParentNode.ParentNode.ParentNode.Text
                        strDepth1 = n_node.ParentNode.ParentNode.Text
                        strDepth2 = n_node.ParentNode.Text
                        strDepth3 = n_node.Text

                        strQuery = String.Format(
                        "[Project] = '{0}' AND 
                         [Model] = '{1}' AND 
                         [Step] = '{2}' AND 
                         [이름] = '{3}' ",
                        strDepth0, strDepth1, strDepth2, strDepth3)

                        row = a_dt.Select(strQuery)
                        If row.Count > 0 Then
                            avgValue = CDbl(row.AsEnumerable().Average(Function(x) x.Field(Of String)("level")))
                        Else
                            avgValue = CDbl(0.0)
                        End If

                        ' 점수 추가
                        n_node.SubItems.Add(avgValue.ToString("F1"))


                    Next '// Name

                Next '// Step

            Next '// Model

        Next '// Project

    End Sub

    Private _upload_dt As DataTable = New DataTable
    Public Sub DB_Save(ByRef _dt As DataTable)


        Dim ins_cnt As Integer = 0
        Dim sql As String

        Dim strpjt As String
        Dim strmod As String
        Dim strstep As String
        Dim strname As String
        Dim strMajor As String
        Dim strlevel As String


        For Each dr As DataRow In _dt.Rows
            strpjt = remove_quarter(dr.Item("Project").ToString)
            strmod = remove_quarter(dr.Item("Model").ToString)
            strstep = remove_quarter(dr.Item("Step").ToString)
            strname = remove_quarter(dr.Item("이름").ToString)
            strMajor = remove_quarter(dr.Item("주특기").ToString)
            strlevel = remove_quarter(dr.Item("level").ToString)


            sql = String.Format(
                "UPDATE 
                    FROM " & cdb.get_manage_model & "
                SET 
                    company = '{0}',
                    t_pjt = '{1}',
                    t_model = '{2}', 
                    t_step = '{3}',  
                    t_mem = '{4}'
                 WHERE 
                    company = '{0}' AND
                    t_mem = '{4}'", _company, strpjt, strmod, strstep, strname)
            Dim errChk As Boolean = False

            errChk = dbc.Query_to_Mysql(sql)
            Debug.Print(errChk)
            ins_cnt += 1


        Next

    End Sub






#End Region





End Class
