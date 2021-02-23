Imports System.Windows.Forms.DataVisualization.Charting

Public Class sun_chart_class
    Private _cht As Chart
    Private _cht_data As DataTable

    Private _byUserdt As DataTable
    Private _byItemdt As DataTable
    Private _dsmain As DataSet = New DataSet
    Private strSQLCon As String = c_db._server_address
    Private mySQLCon As New MySql.Data.MySqlClient.MySqlConnection(strSQLCon)
    Private cdb As c_db.assign_mem = New c_db.assign_mem
    ''' <summary>
    ''' Chart를 별도로 멤버변수로 할당하지 않고도 사용할 수 있게 선언합니다.
    ''' </summary>
    Public Sub New()

    End Sub

    Public Sub New(ByRef _cht As Chart)
        Me._cht = _cht
        ImportCht_backdata()
    End Sub

    Public Sub New(ByRef _cht As Chart, ByRef _cht_data As DataTable)
        Me._cht = _cht
        Me._cht_data = _cht_data



    End Sub

    Public Sub makeChart(ByRef x As Integer, ByRef y As Integer, Optional ByRef cnt As Integer = 10, Optional ByRef _user As String = "")
        Dim cht As Chart = _cht
        Dim col_names As List(Of String) = New List(Of String)
        Dim filter_string As String = ""
        For Each dc As DataColumn In _cht_data.Columns
            filter_string += String.Format("[{0}] asc ,", dc.ColumnName)
        Next

        filter_string = filter_string.Substring(0, filter_string.Length - 1)
        If Not _user = "" Then
            _cht_data.DefaultView.RowFilter = String.Format("[Tester] = '{0}'", _user)
        End If

        _cht_data.DefaultView.Sort = filter_string


        cht.DataSource = _cht_data
        '_cht.DataSource = dt
        Dim ch As System.Collections.Generic.List(Of Series) = New System.Collections.Generic.List(Of Series)

        ' 값이 0인거는 표시 안해줄려고
        If _cht.Series.Count > 0 Then
            For i As Integer = 0 To _cht.Series.Count - 1
                _cht.Series.RemoveAt(0)
            Next
        End If

        ' 하단 범례 추가
        With cht.Series
            ch.Add(.Add(_cht_data.Columns(x).ColumnName))
        End With


        cht.Width = 631


        ' 차트영역을 지정합니다.
        Dim ca1 As ChartArea = _cht.ChartAreas(0)
        Dim sr0 As Series = cht.Series(_cht_data.Columns(x).ColumnName)

        'cht.Width = 631


        ' 차트 영역에 Grid 모눈을 해제 합니다.
        ca1.AxisX.MajorGrid.Enabled = False
        ca1.AxisY.MajorGrid.Enabled = False

        ' 표 간격을 조정 할 값
        Dim interval As Double = 1D

        ' 표 간격 지정
        'ca1.AxisX.MajorTickMark.Interval = interval
        'ca1.AxisX.Minimum = interval / 2D
        'ca1.AxisX.MajorTickMark.IntervalOffset = interval / 2D
        ca1.AxisX.Interval = 1


        ' 차트의 타입을 막대 타입으로 바꿉니다.
        cht.Series(_cht_data.Columns(x).ColumnName).ChartType = SeriesChartType.StackedColumn
        cht.Series(_cht_data.Columns(x).ColumnName).IsValueShownAsLabel = True


        ' x축의 Font를 바꿉니다.
        ca1.AxisX.LabelStyle.Font = New Font("맑은 고딕", 7)
        ca1.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont
        ca1.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont

        'ca1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 2.25F, System.Drawing.FontStyle.Bold)
        ca1.AxisY.LabelStyle.Font = New System.Drawing.Font("맑은 고딕", 7, System.Drawing.FontStyle.Bold)

        Try
            If CInt(cnt) > 0 Then
                ' 차트 데이터 값을 넣어줍니다.
                If CInt(cnt) > _cht_data.Rows.Count - 1 Then
                    For i As Integer = 0 To _cht_data.Rows.Count - 1   '         [카테고리]                 [횟수]
                        cht.Series(_cht_data.Columns(x).ColumnName).Points.AddXY(CStr(_cht_data.Rows(i)(x).ToString), CInt(_cht_data.Rows(i)(y).ToString))
                    Next
                Else
                    For i As Integer = 0 To CInt(cnt) - 1
                        cht.Series(_cht_data.Columns(x).ColumnName).Points.AddXY(CStr(_cht_data.Rows(i)(x).ToString), CInt(_cht_data.Rows(i)(y).ToString))
                    Next
                End If
            End If
        Catch ex As System.InvalidCastException
            Qportals.Debugging.Print(ex.Message)
        End Try

    End Sub

    Public Sub makeChartMan(ByRef _cht As Chart, ByRef _dt As DataTable, ByRef SeriesName As String, ByRef SeriesCount As Integer)

        Dim cht As DataVisualization.Charting.Chart = _cht
        cht.DataSource = _dt

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



        ' 차트영역을 지정합니다.
        Dim ca1 As DataVisualization.Charting.ChartArea = cht.ChartAreas(0)
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


            For i As Integer = 0 To TryCast(cht.DataSource, DataTable).Rows.Count - 1
                cht.Series(SeriesName).Points.AddXY(CStr(_dt.Rows(i)(SeriesName).ToString), CInt(_dt.Rows(i)("진행횟수").ToString))
            Next



        Else

            '// Tester 기준의 차트이므로 Tester 기준으로 Data 뿌림
            For i As Integer = 0 To CInt(SeriesCount) - 1
                cht.Series(SeriesName).Points.AddXY(CStr(_dt.Rows(i)(SeriesName).ToString), CInt(_dt.Rows(i)("진행횟수").ToString))
            Next



        End If


        cht.Width = 681

    End Sub
    Public Sub makeChartMan(ByRef _dt As DataTable, ByRef SeriesName As String, ByRef SeriesCount As Integer)

        Dim cht As DataVisualization.Charting.Chart = _cht
        cht.DataSource = _dt

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



        ' 차트영역을 지정합니다.
        Dim ca1 As DataVisualization.Charting.ChartArea = cht.ChartAreas(0)
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


            For i As Integer = 0 To TryCast(cht.DataSource, DataTable).Rows.Count - 1
                cht.Series(SeriesName).Points.AddXY(CStr(_dt.Rows(i)(SeriesName).ToString), CInt(_dt.Rows(i)("진행횟수").ToString))
            Next



        Else

            '// Tester 기준의 차트이므로 Tester 기준으로 Data 뿌림
            For i As Integer = 0 To CInt(SeriesCount) - 1
                cht.Series(SeriesName).Points.AddXY(CStr(_dt.Rows(i)(SeriesName).ToString), CInt(_dt.Rows(i)("진행횟수").ToString))
            Next



        End If


        cht.Width = 681

    End Sub
    '-------------------------------------------------------------------------------------------
    ''' <summary>
    ''' 이름을 가지고 진행 횟수 차트를 뿌려준다.
    ''' </summary>
    ''' <param name="nowUser"> 사람이름 입력 </param>
    Public Sub Click_name_chart(ByRef nowUser As String, ByRef cnt As Integer)
        _select_user = nowUser
        Dim dt As DataTable : Dim dv As DataView
        '// 필터 걸기 
        dt = _dsmain.Tables("아이템횟수")
        dt.DefaultView.RowFilter = "[Tester] = '" & nowUser & "'"
        dv = dt.DefaultView

        '// 차트 뿌리기
        Dim temp_dt As DataTable = dv.ToTable()
        If temp_dt.Rows.Count > 0 Then
            makeChartMan(temp_dt, "진행횟수", cnt)
        Else
            makeChartMan(temp_dt, "진행횟수", cnt)
        End If


    End Sub
    Private _select_user As String

    '''' <summary>
    ''''  _dsmain.Tables("아이템횟수") 메인 테이블임
    '''' </summary>
    '''' <param name="cnt"></param>
    'Public Sub ChartChanged(ByRef cnt As Integer)

    '    If Not _cht Is Nothing Then
    '        Dim dt As DataTable : Dim dv As DataView
    '        '// 필터 걸기 
    '        dt = _dsmain.Tables("아이템횟수")
    '        dt.DefaultView.RowFilter = "[Tester] = '" & _select_user & "'"
    '        dv = dt.DefaultView

    '        '// 차트 뿌리기
    '        Dim temp_dt As DataTable = dv.ToTable()
    '        If temp_dt.Rows.Count > 0 Then
    '            makeChartMan(temp_dt, "진행횟수", cnt)
    '        End If


    '    End If

    'End Sub

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

    Public Property dataset_cht As DataSet
        Get
            Return _dsmain
        End Get
        Set(value As DataSet)
            _dsmain = value
        End Set
    End Property
End Class
