Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports OfficeOpenXml

Public Class uc_m_manage

    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Private fa As Assign_System_for_Assign
    Private c_admin As Addmin_System


    Private _dt As DataTable
    Private _dgv As DataGridView

    Private _date_info_dt As DataTable


    Public Sub New()

        '// 인원 투입 현황 관리
        InitializeComponent()

        _dgv = DataGridView1
        _dgv.EnableHeadersVisualStyles = False
        panel_drag.AllowDrop = True

        fa = New Assign_System_for_Assign()

    End Sub

    Private Sub Main_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 맨 처음 Database에 있는 데이터를 조회하여 현황표를 출력 한다. 
        Dim strcmt As String = ""
        c_admin = New Addmin_System(
                _dgv, New TextBox() {
                        TextBox1, TextBox2,
                        TextBox3, TextBox4,
                        TextBox5, TextBox6,
                        TextBox7
                        })
        strcmt = c_admin.m_mem_Load_model_list_forSearch(DateTimePicker1.Value)
        txtCmt.Text = strcmt

    End Sub

    Private Sub member_result(sender As Object, e As EventArgs) Handles pic_Refresh.Click
        Dim strcmt As String
        'Dim date_time As String = DateTimePicker1.Value.ToString("yyyy-mm-dd")
        ' DateTimePicker 기준으로  DataBase에서 조회를 함.
        strcmt = c_admin.m_mem_Load_model_list_forSearch(DateTimePicker1.Value)

        txtCmt.Text = strcmt


    End Sub


    ''' <summary>
    ''' 캘린더에서 날짜 선택 시 현황 가져오도록 하는 이벤트
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DateTimePicker_CloseUp_Event(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp

        Dim strcmt As String
        strcmt = c_admin.m_mem_Load_model_list_forSearch(DateTimePicker1.Value)
        txtCmt.Text = strcmt

    End Sub
    Private Sub DragDrop_File_DragEnter(sender As Object, e As DragEventArgs) Handles panel_drag.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Dragdrop_file_DragDrop(sender As Object, e As DragEventArgs) Handles panel_drag.DragDrop
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

        c_admin.m_mem_Load_model_list_forDragDrop(path)

    End Sub


    ''' <summary>
    ''' DataBase 업데이트 하는 부분
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DBUpdateButton(sender As Object, e As EventArgs) Handles btn_upload.Click

        Dim btns() As TextBox = New TextBox() {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5}
        Dim cnt As Integer = btns.Where(Function(x) x.Text = "").Count
        If (cnt > 0) Then
            Qportals.Debugging.Show("총원 및 MD 부분이 비어있습니다. 확인 후 다시시도해주세요.")
            Exit Sub
        End If

        Dim dic As Dictionary(Of String, String) = New Dictionary(Of String, String)
        dic.Add("총원", TextBox1.Text)
        dic.Add("투입MD", TextBox2.Text)
        dic.Add("휴가", TextBox3.Text)
        dic.Add("유휴MD", TextBox4.Text)
        dic.Add("교육", TextBox5.Text)
        dic.Add("예비인원", TextBox6.Text)
        dic.Add("날짜", DateTimePicker1.Value.ToString("yyyy-MM-dd"))

        c_admin.Insert_Or_Update(dic)

    End Sub

    Private Sub Mapping_to_Model()
        ' DB 버튼 누른다. 
        ' Project Form 을 띄운다. 
        ' 더블 클릭한다. 
        ' 클릭한 항목을 td_defect.`Project` 테이블에 update table set 한다.


        'Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        'Dim f1 As New Form
        'Dim mppjt As Mapping_project =
        '        New Mapping_project With
        '            {
        '              .Owner = f1
        '            }
        'mppjt.P_dt = dt
        'mppjt.ShowDialog()

    End Sub




#Region "엑셀 다운로드"
    Private export As Qportals.FileControl = New Qportals.FileControl
    Private Sub Export_ExcelButtonClick(sender As Object, e As EventArgs) Handles btn_down.Click
        '// Test 
        Export_ExcelFile()


    End Sub
    Private Sub Export_ExcelFile()

        Dim fileio As Qportals.FileControl = New Qportals.FileControl
        Dim realFile As String = fileio.GetLastModifyFile("\\10.169.88.40\Q-Portal\resource\", "모델진행현황_양식")
        Try
            export.SaveFileDialog_sun_custom(realFile)
        Catch ex As Exception
            MessageBox.Show("Server Migration이 완료되지 않았습니다.")
        End Try


    End Sub






#End Region





End Class
