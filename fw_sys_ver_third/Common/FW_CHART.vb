Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FW_CHART
    Public Sub New()

        InitializeComponent()

        _cht = Chart1
        _cht.DataSource = _cht_data
    End Sub

    Public dt As DataTable = New DataTable
    Public Property _cht_data As DataTable
    Private _cht As Chart
    Private Sub CheckBoxChecked(sender As Object, e As EventArgs) Handles rdoTestItem.CheckedChanged, rdoCategory.CheckedChanged, rdoTctype.CheckedChanged

        SelectedChangeRadio()

    End Sub
    Private Sub ChartChanged(sender As Object, e As EventArgs) Handles txtCnt.TextChanged

        _cht.DataSource = _cht_data
        'Chart1.DataSource = dt
        Dim ch As System.Collections.Generic.List(Of Series) = New System.Collections.Generic.List(Of Series)

        ' 값이 0인거는 표시 안해줄려고
        If _cht.Series.Count > 0 Then
            For i As Integer = 0 To _cht.Series.Count - 1
                _cht.Series.RemoveAt(0)
            Next
        End If

        If (_cht_data.TableName.Contains("검증원")) Then

            makeChartMan(_cht, "Tester", CInt(If(txtCnt.Text = "", 0, txtCnt.Text)))
        Else

            makeChartMan(_cht, "진행횟수", CInt(If(txtCnt.Text = "", 0, txtCnt.Text)))
        End If

    End Sub
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

            If (SeriesName = SeriesName) Then
                For i As Integer = 0 To TryCast(cht.DataSource, DataTable).Rows.Count - 1
                    cht.Series(SeriesName).Points.AddXY(CStr(TryCast(cht.DataSource, DataTable).Rows(i)("Tester").ToString), CInt(TryCast(cht.DataSource, DataTable).Rows(i)("진행횟수").ToString))
                Next
            Else
                For i As Integer = 0 To TryCast(cht.DataSource, DataTable).Rows.Count - 1
                    cht.Series(SeriesName).Points.AddXY(CStr(TryCast(cht.DataSource, DataTable).Rows(i)("TestItem").ToString), CInt(TryCast(cht.DataSource, DataTable).Rows(i)("진행횟수").ToString))
                Next
            End If


        Else

            If (SeriesName = SeriesName) Then
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



    Private Sub SelectedChangeRadio()
        Dim dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
        Dim _User As String
        If Label1.Text.Length > 6 Then
            _User = Label1.Text.Substring("검증원 : ".Length)
        Else
            _User = ""
            Exit Sub
        End If


        Dim sql As String = ""
        'Dim dt As DataTable
        If (rdoCategory.Checked = True) Then
            sql = "select `Category`, Count(Category) as `진행횟수` from td_defect.`assign_testcase` where Tester = '" & _User & "'"
            sql += " Group by `Category`"
            sql += " Order by `진행횟수` desc"
            dt = dbc.Mysql_to_datatable(sql)
            makeChart(0, 1)


        ElseIf (rdoTctype.Checked = True) Then
            sql = "select `Category`, `TCType`, Count(TCType) as `진행횟수` from td_defect.`assign_testcase` where Tester = '" & _User & "'"
            sql += " Group by `Category`, `TCType`"
            sql += " Order by `진행횟수` desc"
            dt = dbc.Mysql_to_datatable(sql)
            makeChart(1, 2)

        ElseIf (rdoTestItem.Checked = True) Then
            sql = "select `Category`, `TCType`, `TestItem`, Count(*) as `진행횟수` from td_defect.`assign_testcase` where Tester = '" & _User & "'"
            sql += " Group by `Category`, `TCType`, `TestItem`"
            sql += " Order by `진행횟수` desc"
            dt = dbc.Mysql_to_datatable(sql)
            makeChart(2, 3)

        End If

    End Sub


    Private Sub makeChart(ByRef x As Integer, ByRef y As Integer)
        Dim cht As Chart = Chart1
        _cht_data.DefaultView.Sort = "Category, TCtype, TestItem, [진행횟수] asc"

        Dim tmp_dv As DataView
        tmp_dv = _cht_data.DefaultView
        tmp_dv.Sort = "Category, TCtype, TestItem, [진행횟수] asc"
        _cht_data = tmp_dv.ToTable()



        cht.DataSource = _cht_data
        'Chart1.DataSource = dt
        Dim ch As System.Collections.Generic.List(Of Series) = New System.Collections.Generic.List(Of Series)

        ' 값이 0인거는 표시 안해줄려고
        If Chart1.Series.Count > 0 Then
            For i As Integer = 0 To Chart1.Series.Count - 1
                Chart1.Series.RemoveAt(0)
            Next
        End If

        ' 하단 범례 추가
        With cht.Series
            ch.Add(.Add(dt.Columns(x).ColumnName))
        End With


        cht.Width = 631


        ' 차트영역을 지정합니다.
        Dim ca1 As ChartArea = Chart1.ChartAreas(0)
        Dim sr0 As Series = cht.Series(dt.Columns(x).ColumnName)

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
        cht.Series(dt.Columns(x).ColumnName).ChartType = SeriesChartType.StackedColumn
        cht.Series(dt.Columns(x).ColumnName).IsValueShownAsLabel = True


        ' x축의 Font를 바꿉니다.
        ca1.AxisX.LabelStyle.Font = New Font("맑은 고딕", 7)
        ca1.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont
        ca1.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont

        'ca1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 2.25F, System.Drawing.FontStyle.Bold)
        ca1.AxisY.LabelStyle.Font = New System.Drawing.Font("맑은 고딕", 7, System.Drawing.FontStyle.Bold)

        Try
            If CInt(txtCnt.Text) > 0 AndAlso Not txtCnt.Text = "" Then
                ' 차트 데이터 값을 넣어줍니다.
                If CInt(txtCnt.Text) > dt.Rows.Count - 1 Then
                    For i As Integer = 0 To dt.Rows.Count - 1   '         [카테고리]                 [횟수]
                        Chart1.Series(dt.Columns(x).ColumnName).Points.AddXY(CStr(dt.Rows(i)(x).ToString), CInt(dt.Rows(i)(y).ToString))
                    Next
                Else
                    For i As Integer = 0 To CInt(txtCnt.Text) - 1
                        Chart1.Series(dt.Columns(x).ColumnName).Points.AddXY(CStr(dt.Rows(i)(x).ToString), CInt(dt.Rows(i)(y).ToString))
                    Next
                End If
            End If
        Catch ex As System.InvalidCastException
            Qportals.Debugging.Print(ex.Message)
        End Try

    End Sub

    Private Sub CloseForm(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, Chart1.KeyDown, ListView1.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

    End Sub






End Class