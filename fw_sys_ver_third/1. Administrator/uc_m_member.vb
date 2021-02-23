Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Imports WinControls.ListView
Imports WinControls.ListView.Collections

Public Class uc_m_member
    Public dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Public cdb As c_db.assign_mem = New c_db.assign_mem

    Private _company As String = Main_index.f._company
    Private _user As String = Main_index.f._user

    Private c_mem As Addmin_System = New Addmin_System()

    Private c_cht_TestItem As sun_chart_class
    Private c_cht_tctype As sun_chart_class
    Private c_cht_simple As sun_chart_class

    Public Sub New()
        InitializeComponent()

        ' 인원 관리 전용 Class 생성자로 생성
        c_mem = New Addmin_System(trv_Model, trv_Member)
        trv_Member.Visible = False  ' 펼치기 버튼을 누르기 전에는 업체 멤버를 보여주지 않음.

        trv_Model.AllowDrop = True
        trv_Model.AllowDefaultDragDrop = True

        c_cht_TestItem = New sun_chart_class(cht_non)
        c_cht_tctype = New sun_chart_class(cht_func)

        c_cht_simple = New sun_chart_class()


        '--------------
        panel_chart.Visible = False

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmt As String = ""

        Dim _start_date As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim _end_date As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")



        If Not (c_mem Is Nothing) Then

            panel_chart.Visible = False

            ' Running Model 을 조회하는 코드   
            c_mem.TreeListViews_Settings()
            cmt = c_mem.Running_Model_Search(_start_date, _end_date)

            txtCmt.Text = cmt

            c_mem.main_trvToDataTable()

            txt_count.Text = 5  ' 차트 보여줄 개수
            'non_func.Width = 631    ' 차트 넓이 지정

            Setting_pnael.Visible = False   ' setting panel 조정

            ' Upload 하는 panel screen container
            Dim uclevel As uc_m_level_upload = New uc_m_level_upload
            GroupBox2.Controls.Clear()
            GroupBox2.Controls.Add(uclevel)
            uclevel.Dock = DockStyle.Fill

            panel_chart.Visible = True
        Else

            panel_chart.Visible = False
        End If

    End Sub
    Private Sub PanelOnOff(sender As Object, e As EventArgs) Handles btn_Settings.Click
        ShowHidePanel()
    End Sub
    ''' <summary>
    ''' 설정 패널을 보여주거나 Hide하는 함수입니다.
    ''' </summary>
    Private Sub ShowHidePanel()
        With Setting_pnael
            If .Visible Then
                .Visible = False
            Else
                .Visible = True
            End If
        End With
    End Sub

    Private Sub LostFocus_fromSetting(sender As Object, e As EventArgs) Handles Me.MouseClick
        Setting_pnael.Visible = False
    End Sub
    ''' <summary>
    ''' 조회 날짜를 선택한 범위에 맞는 현황을 가져옵니다.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Click_the_SearchButton(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim cmt As String
        If Not (c_mem Is Nothing) Then
            Dim _start_date As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            Dim _end_date As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
            cmt = c_mem.Running_Model_Search(_start_date, _end_date)
            txtCmt.Text = cmt
            c_mem.main_trvToDataTable()

        End If

    End Sub
    ''' <summary>
    ''' TreeListView(투입인원) 선택 시 선택한 인원의 정보를 차트로 보여주는 부분
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TreeViewClick(sender As Object, e As WinControls.ListView.EventArgClasses.ContainerListViewEventArgs) Handles trv_Model.AfterSelect
        Dim sql As String

        If c_cht_TestItem Is Nothing AndAlso c_cht_tctype Is Nothing Then Exit Sub
        Dim nowUser As String
        If Not (trv_Model.Nodes.Count = 0) And (trv_Model.SelectedItems.Count > 0) Then
            If trv_Model.SelectedItems.Item(0).SubItems.Count > 0 Then
                nowUser = trv_Model.SelectedItems.Item(0).ToString()

                ' Function) Test Case
                Dim _dt1 As DataTable = c_cht_tctype.dataset_cht.Tables("아이템횟수")
                sql = String.Format(
                    "SELECT 
                        `Category`, 
                        `TestItem`,
                        Count(TestItem) as `진행횟수` 
                    from " & cdb.get_assign_testcase & " 
                    where 
                        Tester = '{0}' and
                        Category Like 'Function%'
                    Group by 
                        `Category`, `TestItem` 
                    Order by 
                        `진행횟수` desc
                    ", nowUser)

                _dt1 = dbc.Mysql_to_datatable(sql)
                If Not (_dt1 Is Nothing) Then

                    _dt1 = Return_output_datatable(_dt1)


                    c_cht_simple.makeChartMan(cht_func, _dt1, "TestItem", txt_count.Text)
                End If


                ' Non-Function) Test Case
                Dim _dt2 As DataTable = New DataTable
                sql = String.Format(
                    "SELECT 
                        `Category`, 
                        `TestItem`,
                        Count(Category) as `진행횟수` 
                    from " & cdb.get_assign_testcase & " 
                    where 
                        Tester = '{0}' and
                        Category Like 'Non%Function'
                    Group by 
                        `Category`, `TestItem` 
                    Order by 
                        `진행횟수` desc
                    ", nowUser)

                _dt2 = dbc.Mysql_to_datatable(sql)
                If Not _dt2 Is Nothing Then

                    _dt2 = Return_output_datatable(_dt2)

                    c_cht_simple.makeChartMan(cht_non, _dt2, "TestItem", txt_count.Text)
                End If


                ' Random Test Case (랜덤현황 데이터 가져오기)
                Dim dt3 As DataTable = New DataTable
                sql = String.Format(
                    "SELECT 
                        `Category`, 
                        `TestItem`,
                        Count(Category) as `진행횟수` 
                    from " & cdb.get_assign_testcase & " 
                    where 
                        Tester = '{0}' and
                        Category Like 'Non%Function' AND Tctype = '%Random%' and or
                        TestItem Like '%Random%'                         
                    Group by 
                        `Category`, `TestItem` 
                    Order by 
                        `진행횟수` desc
                    ", nowUser)

                dt3 = dbc.Mysql_to_datatable(sql)
                If Not dt3 Is Nothing Then
                    dt3 = Return_output_datatable(dt3)

                    Dim random_sql As String = makeQuery_forRandom(nowUser)
                    dt3 = dbc.Mysql_to_datatable(sql)
                    c_cht_simple.makeChartMan(cht_rand, dt3, "TestItem", txt_count.Text)
                End If

                panel_chart.Visible = True

            End If
        End If

    End Sub
    ''' <summary>
    ''' 합계 질의 된 테이블을 기존 테이블에 추가 하는 함수.
    ''' </summary>
    ''' <param name="inputTable"> 합계 질의 할 테이블을 넣으세요. </param>
    ''' <returns></returns>
    Private Function Return_output_datatable(ByRef inputTable As DataTable) As DataTable
        Dim _out_table As DataTable = inputTable
        Dim calTot =
            From r In inputTable.AsEnumerable()
            Group r By ItemActivation = New With
            {
                Key .Category = r.Field(Of String)("Category")
            }
            Into grp = Group
            Let r = grp.FirstOrDefault
            Select New With
            {
                .Category = r("Category"),
                .TestItem = "Total",
                .진행횟수 = grp.Sum(Function(x) x("진행횟수"))
            }
        For Each r In calTot
            Dim rows As DataRow = _out_table.NewRow()
            rows("Category") = r.Category
            rows("TestItem") = r.TestItem
            rows("진행횟수") = r.진행횟수

            _out_table.Rows.InsertAt(rows, 0)
        Next

        Return _out_table
    End Function

    Private Function makeQuery_forRandom(ByVal _user As String) As String
        Dim out_sql As String = ""
        Dim sql As String
        Dim dt As DataTable
        ' ) rs2 schema 내부의 모든 table을 list화 함.
        sql =
            "SELECT 
              `TABLE_NAME` AS `rs_Names`
            FROM  
                information_schema.tables
            WHERE 
                TABLE_TYPE = 'BASE TABLE' AND 
                ROW_FORMAT = 'Dynamic' AND 
                ENGINE = 'InnoDB' AND 
                TABLE_SCHEMA = 'rs2' AND
                `TABLE_NAME` LIKE '%_db' AND
                NOT `TABLE_NAME` LIKE 'random%'    
            ORDER BY TABLE_SCHEMA;"
        dt = dbc.Mysql_to_datatable(sql)


        Dim sql2 As String = ""
        If Not (dt Is Nothing) Then
            ' {0} : Alphabet 으로 지정

            For Each dr As DataRow In dt.Rows
                Dim table_name As String = IIf(dr(0).ToString = "", "", dr(0).ToString)
                sql2 += String.Format("SELECT Item1, Upload_User FROM `rs2`.`{0}` UNION ALL ", table_name)

            Next

            sql2 = sql2.Substring(0, sql2.Length - " UNION ALL".Length)

            out_sql = "
                SELECT 
                    aa.Item1, 
                    COUNT(aa.Upload_User) AS 진행횟수
                FROM 
                ("

            out_sql += sql2

            out_sql += ") aa
                WHERE 
                  aa.Upload_User LIKE '최윤진%'
                GROUP BY Item1
                ORDER BY 진행횟수 DESC"

        End If




        Return out_sql

    End Function


    ''' <summary>
    ''' Drag n Drop 을 하여 인원정보를 변경하는 프로세스
    ''' </summary>
    ''' <param name="sender"> Sender </param>
    ''' <param name="e"> ItemDragEventArgs : ItemDrop </param>
    Private Sub Drag_n_Drop_Functions(sender As Object, e As ItemDragEventArgs) Handles trv_Model.ItemDrop
        trv_Model.BeginUpdate()
        Dim targetPoint As Point = DirectCast(e, WinControls.ListView.EventArgClasses.TreeListViewItemDropEventArgs).MousePosition
        Dim targetNode As TreeListNode = DirectCast(e, WinControls.ListView.EventArgClasses.TreeListViewItemDropEventArgs).TargetNode
        targetNode = trv_Model.GetItemAt(targetPoint)

        Dim draggedNode As TreeListNode = DirectCast(e, EventArgClasses.TreeListViewItemDropEventArgs).Item(0)

        Debug.Print(String.Format("Origin({2}) Rowindex : {0} ||| Index : {1}", draggedNode.RowIndex, draggedNode.Index, draggedNode.Text))
        Debug.Print(String.Format("target({2}) Rowindex : {0} ||| Index : {1}", targetNode.RowIndex, targetNode.Index, targetNode.Text))

        If draggedNode Is Nothing Or draggedNode Is Nothing Then Exit Sub

        If Not (draggedNode.Equals(targetNode)) AndAlso Not ContainsNode(draggedNode, targetNode) Then

            If draggedNode.Level = 3 AndAlso targetNode.Level = 3 Then
                draggedNode.Remove()
                targetNode.ParentNode.Nodes.Insert(draggedNode, targetNode.Index)
                'draggedNode.Expand()
                trv_Model.EndUpdate()
            End If
            _upload_dt = New DataTable
            With _upload_dt.Columns
                .Add("Project") : .Add("Model") : .Add("Step")
                .Add("이름") : .Add("주특기") : .Add("level")
            End With
            TreeListViewToDataTable(_upload_dt, trv_Model.Nodes)
        End If
    End Sub
    ''' <summary>
    ''' TreeListNode를 Drag 했을 때 DoDragDrop을 동작 시킨다.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"> TreeListView의 ItemDragEvent를 사용한다. </param>
    Private Sub treeView_ItemDarag(sender As Object, e As ItemDragEventArgs) Handles trv_Model.ItemDrag
        If e.Button = MouseButtons.Left Then
            DoDragDrop(e.Item, DragDropEffects.Move)
        End If
    End Sub
    ''' <summary>
    ''' 두 TreeListView를 비교하여 True / False 를 Return 한다.
    ''' </summary>
    ''' <param name="node1"></param>
    ''' <param name="node2"></param>
    ''' <returns></returns>
    Private Function ContainsNode(node1 As TreeListNode, node2 As TreeListNode) As Boolean
        If (node2.ParentNode Is Nothing) Then Return False
        If (node2.ParentNode.Equals(node1)) Then Return True

        Return ContainsNode(node1, node2.ParentNode)
    End Function

    ''' <summary>
    ''' 차트를 갯수를 변경하면 차트가 뿌려진다.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Change_cnt(sender As Object, e As EventArgs) Handles txt_count.TextChanged

        If c_cht_TestItem Is Nothing Then Exit Sub
        Dim nowUser As String
        If Not (trv_Model.Nodes.Count = 0) And (trv_Model.SelectedItems.Count > 0) Then
            If trv_Model.SelectedItems.Item(0).SubItems.Count > 0 Then
                nowUser = trv_Model.SelectedItems.Item(0).ToString()

                Dim _dt1 As DataTable = c_cht_tctype.dataset_cht.Tables("아이템횟수")
                Dim dv1 As DataView = New DataView
                dv1 = _dt1.DefaultView
                dv1.RowFilter = "[Tester] = '" & nowUser & "'"
                dv1.Sort = "[TCtype] asc"
                '_dt1 = dv1.ToTable(True, "TCtype", "진행횟수")
                c_cht_tctype.makeChartMan(_dt1, "TCtype", txt_count.Text)
                c_cht_TestItem.Click_name_chart(nowUser, CInt(If(txt_count.Text = "", 0, txt_count.Text)))

                Dim _dt As DataTable = c_cht_tctype.dataset_cht.Tables("아이템횟수")
                Dim dv As DataView = New DataView
                dv = _dt.DefaultView
                dv.RowFilter = "[Tester] = '" & nowUser & "'"
                dv.Sort = "[TCtype] asc"
                _dt = dv.ToTable(True, "TCtype", "진행횟수")
                c_cht_tctype.makeChartMan(_dt, "TCtype", txt_count.Text)

                panel_chart.Visible = True
            End If
        End If

    End Sub




#Region "역량 업로드 기능 - TreeListView에 직접 드래그"
    Private Sub DragDrop_File_DragEnter(sender As Object, e As DragEventArgs) Handles trv_Model.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Dragdrop_file_DragDrop(sender As Object, e As DragEventArgs) Handles trv_Model.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        Dim blCheck As Boolean = False

        If (files.Length > 1) Then
            Qportals.Debugging.Show("하나의 파일만 올려주세요.") : Exit Sub
        End If

        Dim path As String = files(0)
        Dim strExtension As String = Nothing
        Dim fi As New IO.FileInfo(path)

        '# 확장자 알아내기
        strExtension = fi.Extension

        If strExtension <> ".xlsx" Then
            MessageBox.Show("확장자가 ""xlsx"" 인 엑셀 파일만 올려주세요. ", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub DataBase_Upload(ByRef dt As DataTable)
        Dim ErrChk As Boolean = False
        Dim ups_sql As String
        Dim ups_sum_sql As String = ""
        Dim ups_cnt As Integer = 0
        ups_sql = String.Format(
            "update 
                assign_mem.manage_model 
            set 
                compnay = '{0}',
                t_model = '{1}', 
                t_step = '{2}', 
                t_step = '{3}', 
                t_mem = '{4}'")

        'ups_sql


        'For Each dr As DataRow In dt.Rows

        '    ins_sum_sql += String.Format("{0}, {1}, {2}, {3}, {4}),",
        '         dr("name"), dr("accid"), dr("company"), dr("주특기"), dr("역량"))
        '    ins_cnt += 1

        'Next

        'ins_sum_sql = ins_sum_sql.Substring(0, Len(ins_sum_sql) - 1)  '// 맨 뒤 ',' 를 지워주기 위함
        'ins_sql += ins_sum_sql

        '// 모델정보 Insert
        'ErrChk = dbc.Query_to_Mysql(ins_sql)


    End Sub

#End Region



#Region "DB 업로드 기능"
    Private _upload_dt As DataTable = New DataTable
    Private Sub btn_SaveButton_Event(sender As Object, e As EventArgs) Handles btn_save.Click

        If DateTimePicker1.Value = DateTimePicker2.Value Then

            If _upload_dt Is Nothing Then Exit Sub
            c_mem.DB_Save(_upload_dt)
        Else
            Dim cmt As String
            cmt = String.Format(
                "범위 조회를 했을 경우에는 
                DB 업데이트 기능 및 현황 변경 기능은
                사용할 수 없습니다."
                )
            MessageBox.Show(cmt)

        End If

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

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles cht_non.Click, cht_rand.Click

    End Sub




#End Region












End Class
