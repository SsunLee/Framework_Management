Imports System.Threading

Public Class uc_m_level_upload
    Private lst As ListBox
    Private counter As Integer = 0

    Private dbc As Qportals.DbConnection.Mysql_Class = New Qportals.DbConnection.Mysql_Class
    Private cdb As c_db.assign_mem = New c_db.assign_mem
    Public Sub New()

        InitializeComponent()

        lst = lst_up
        lst_up.AllowDrop = True
        btn_ex_up.BackColor = Color.White

        Timer1.Interval = 600
        counter = 0

        ProgressBar1.BackColor = Color.White
        ProgressBar1.ForeColor = Color.FromName("highlight")


    End Sub

    Private Sub DragDrop_File_DragEnter(sender As Object, e As DragEventArgs) Handles lst_up.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Dragdrop_file_DragDrop(sender As Object, e As DragEventArgs) Handles lst_up.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        Dim blCheck As Boolean = False

        If (files.Length > 100) Then
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

        Dim strFileName As String = IO.Path.GetFileName(path)
        If Not strFileName.Contains("역량_업로드") Then
            MessageBox.Show("역량_업로드 양식이 아닙니다. " & vbCrLf &
                            "파일 이름에 ""역량_업로드"" 인지 확인하세요.", "lee.sunbae@lgepartner.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        lst.Items.Clear()
        lst.Items.Add(path)



    End Sub

    Private Sub when_lstbox_addeditem(sender As Object, e As EventArgs) Handles lst_up.MouseHover

        If lst.Items.Count > 0 Then ' ListBox에 아이템이 있으면 깜빡거리기
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If btn_ex_up.BackColor = Color.White Then
            btn_ex_up.BackColor = Color.HotPink
        Else
            btn_ex_up.BackColor = Color.White
        End If

        If lst.Items.Count > 0 Then
            Timer1.Enabled = True
        Else
            ' 추가 된 아이템이 없다면 Timer를 Enable = False 한다.
            Timer1.Enabled = False
            btn_ex_up.BackColor = Color.White
        End If

    End Sub



    Private Sub DB_UpButtonClick(sender As Object, e As EventArgs) Handles btn_ex_up.Click
        If lst.Items(0) Is Nothing Then Exit Sub
        Dim strFilePath As String = lst.Items(0).ToString
        Dim dt As DataTable = New DataTable
        Dim OLE As Qportals.DbConnection.Excel_Class = New Qportals.DbConnection.Excel_Class
        dt = OLE.Excel_to_datatable(strFilePath, "C10:H1000")



        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Dim trd As Thread = New Thread(Sub() DB_Upload(dt))
            trd.Start()

        End If

    End Sub

    Private Sub DB_Upload(ByRef _dt As DataTable)
        ' 역량 레벨 업데이트 및 추가
        Dim strname As String, straccid As String, strcom As String, strmajor As String, strLevel As String
        Dim q As Qportals.QPortal = New Qportals.QPortal
        Dim scnt As Integer = 0, fcnt As Integer = 0
        Dim dt As DataTable = _dt

        Dim pg As ProgressBar = ProgressBar1
        pg.Invoke(Sub() pg.Maximum = dt.Rows.Count)
        pg.Invoke(Sub() pg.Value = 0)

        For Each dr As DataRow In dt.Rows
            strname = q.remove_quarter(IIf(dr("name").ToString = "", "", dr("name").ToString))
            straccid = q.remove_quarter(IIf(dr("accid").ToString = "", "", dr("accid").ToString))
            strcom = q.remove_quarter(IIf(dr("company").ToString = "", "", dr("company").ToString))
            strmajor = q.remove_quarter(IIf(dr("주특기").ToString = "", "", dr("주특기").ToString))
            strLevel = q.remove_quarter(IIf(dr("역량").ToString = "", "", dr("역량").ToString))


            Dim sql = String.Format(
                "INSERT INTO 
                    assign_mem.manage_memlevel
                    (`name`, `accid`, `company`, `주특기`, 역량) 
                    select '{0}','{1}','{2}','{3}','{4}'
                FROM DUAL WHERE NOT EXISTS 
                    (SELECT 
                        * 
                     FROM 
                        " & cdb.get_manage_model & "
                     WHERE 
                        `name` = '{0}' AND
                        `accid` = '{1}' AND 
                        `company` = '{2}' AND 
                        `주특기` = '{3}');
                UPDATE 
                    assign_mem.manage_memlevel 
                SET 
                    `name` = '{0}' ,
                    `accid` = '{1}' ,
                    `company` = '{2}' ,
                    `주특기` = '{3}' , 
                    `역량` = {4}
                WHERE 
                    `name` = '{0}' AND
                    `accid` = '{1}' AND 
                    `company` = '{2}' AND 
                    `주특기` = '{3}'",
                strname, straccid, strcom, strmajor, CDbl(strLevel))
            Debug.Print("{0}, {1}, {2}, {3}, {4}", strname, straccid, strcom, strmajor, CDbl(strLevel))
            Dim err As Boolean = dbc.Query_to_Mysql(sql)
            Dim pg_val As Integer
            Dim pg_max As Integer

            If pg.InvokeRequired Then
                pg.Invoke(Sub() pg.Value += 1)
                pg.Invoke(Sub() pg_val = pg.Value)
                pg.Invoke(Sub() pg_max = pg.Maximum)
            Else
                pg.Value += 1
                pg_val = pg.Value
                pg_max = pg.Maximum
            End If

            If Label1.InvokeRequired Then
                Label1.Invoke(Sub() Label1.Text = "(" & pg_val & "/" & pg_max & ")")
            Else
                Label1.Text = "(" & pg_val & "/" & pg_max & ")"
            End If

            If err Then
                scnt += 1
            Else
                fcnt += 1
            End If

        Next

        MessageBox.Show("성공 : " & scnt & "건" & vbCrLf & "실패 : " & fcnt & "건" & vbCrLf & Now() & " 기준 ")

    End Sub



End Class
