Imports System.Data
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Public Class uc_d_share
    Public ntc As Drill_Wide = New Drill_Wide()

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

        InitializeComponent()

        With cbContents
            .Items.Add("Action")
            .Items.Add("주관")
            .Items.Add("담당자")
            .SelectedIndex = 0
        End With

        '// DataGridView 에 내용 조회할 쿼리
        Dim connstring As String = "Server=10.169.88.40;Uid=rs_user;Pwd=lge1234;Database=" & "td_defect"
        Dim sql As String = "Select `Nom`, `구분`, `회의체`, `Status`, `협의날짜`, `Action`, `주관`, `시행일자`, `파일명` from td_defect.`abcd`"
        sql = "SELECT * FROM td_defect.`abcd` "

        ntc = New Drill_Wide()

        '// 수평전개 Class
        ntc._dt_tables = New DataTable
        ntc._dt_tables = ntc.Mysql_to_datatable(sql)
        ntc._dt_tables.Columns.Add(ntc.addColumn_datatable("첨부"))
        ntc.__cbCategory = cbCategory
        ntc.__btnUnCheck = btnUnCheck
        ntc.__laResult = Label_result
        ntc.__chkAttached = chkAttached
        ntc.__cbContents = cbContents
        ntc.__txtSearch = txtSearch
        ntc.__dgv = DataGridView1

        ntc.main_process()


    End Sub

    Private Sub reset_filter(sender As Object, e As EventArgs) Handles btnUnCheck.Click
        ntc.reset_Filter(sender, e)
    End Sub

    Private Sub SearchOption(sender As Object, e As EventArgs) Handles Button1.Click
        ntc.SearchOption(sender, e)
    End Sub

    Private Sub Attacth_Filter(sender As Object, e As EventArgs) Handles chkAttached.CheckedChanged
        ntc.Attached_Filter(sender, e)
    End Sub

    Private Sub changeCategory(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged
        ntc.Change_Category(sender, e)
    End Sub

    Private Sub KeyPressEnter(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ntc.SearchOption(sender, e)
        End If
    End Sub

    Private Sub DatagirdMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If e.RowIndex <> -1 And e.ColumnIndex <> -1 Then
            If e.Button = MouseButtons.Right Then
                Dim clickCell As DataGridViewCell = sender.Rows(e.RowIndex).Cells(e.ColumnIndex)
                clickCell.ContextMenuStrip = ntc._contextmenu
            End If
        End If
    End Sub
    Private Sub contextmenu_click(sender As Object, e As ToolStripItemClickedEventArgs)
        Dim clickCell As DataGridViewCell = DataGridView1.SelectedCells(0)
        Select Case e.ClickedItem.Text
            Case "열기"
                Qportals.Debugging.Show(clickCell.ToString(), "", 0, 64)
            Case "저장(미구현)"
                ' 추가 구현 사항
        End Select
    End Sub


    Private Sub myGrid_rowPaint(sender As Object, e As EventArgs) Handles DataGridView1.RowPostPaint
        ntc.myGrid_RowPostPaint(sender, e)
    End Sub


End Class


Public Class Drill_Wide
    Inherits Qportals.DbConnection.Mysql_Class

    Property _dt_tables As DataTable
    Private _dgv As DataGridView
    Private _bind As BindingSource
    Public Shadows _contextmenu As ContextMenuStrip
    Private cm As ContextMenuStrip
    Public Property __dgv As DataGridView   '// DataGridView 외부 컨트롤
        Get
            Return _dgv
        End Get
        Set(value As DataGridView)
            _dgv = value
        End Set
    End Property



    Property __cbCategory As ComboBox
        Get
            Return _cbCategory
        End Get
        Set(value As ComboBox)
            _cbCategory = value
        End Set
    End Property
    Property __btnUnCheck As Button
        Get
            Return _btnUnCheck
        End Get
        Set(value As Button)
            _btnUnCheck = value
        End Set
    End Property

    Property __laResult As Label
        Get
            Return _laResult
        End Get
        Set(value As Label)
            _laResult = value
        End Set
    End Property

    Property __chkAttached As CheckBox
        Get
            Return _chkAttached
        End Get
        Set(value As CheckBox)
            _chkAttached = value
        End Set
    End Property
    Property __cbContents As ComboBox
        Get
            Return _cbContents
        End Get
        Set(value As ComboBox)
            _cbContents = value
        End Set
    End Property

    Property __txtSearch As TextBox
        Get
            Return _txtSearch
        End Get
        Set(value As TextBox)
            _txtSearch = value
        End Set
    End Property


    Private _cbCategory As ComboBox
    Private _btnUnCheck As Button
    Private _laResult As Label
    Private _chkAttached As CheckBox
    Private _cbContents As ComboBox
    Private _txtSearch As TextBox

    Public Sub New()

    End Sub

    Public Function addColumn_datatable(ByRef ColName As String) As DataColumn
        Dim dCol As DataColumn = Nothing
        dCol = New DataColumn()
        dCol.DataType = GetType(Image)
        dCol.ColumnName = ColName
        Return dCol
    End Function

    Public Sub main_process()

        init_dgv()


    End Sub

    Public Sub reset_Filter(sender As Object, e As EventArgs)
        '// 필터해제 버튼
        If _cbCategory.Text = "전체" Then
            _bind.Filter = ""
        Else
            _bind.Filter = "구분 = '" & _cbCategory.Text & "'"
        End If
        _laResult.Text = "총 : " & CInt(_bind.Count)
    End Sub
    Public Sub SearchOption(sender As Object, e As EventArgs)
        Select Case _cbContents.Text
            Case "내용"
                _bind.Filter += " and 내용 LIKE '%" & _txtSearch.Text & "%'"
            Case "전달처"
                _bind.Filter += " and 전달처 LIKE '%" & _txtSearch.Text & "%'"
            Case "전달자"
                _bind.Filter += " and 전달자 LIKE '%" & _txtSearch.Text & "%'"
            Case Else
                _bind.Filter = ""
        End Select
        _laResult.Text = "총 : " & CInt(_bind.Count)
    End Sub
    Public Sub Attached_Filter(sender As Object, e As EventArgs)
        If _cbCategory.Text = "전체" Then

            If _chkAttached.Checked = True Then
                _bind.Filter = "첨부 is not null "
            Else
                _bind.Filter = "첨부 is null"
            End If

        Else

            If _chkAttached.Checked = True Then
                _bind.Filter = "구분 = '" & _cbCategory.Text & "' and 첨부 is not null "
            Else
                _bind.Filter = "구분 = '" & _cbCategory.Text & "' and 첨부 is null"
            End If

        End If

        _laResult.Text = "총 : " & CInt(_bind.Count)
    End Sub
    Public Sub Change_Category(sender As Object, e As EventArgs)
        If _cbCategory.Text = "전체" Then

            If _chkAttached.Checked = True Then
                _bind.Filter = "첨부 is not null "
            Else
                _bind.Filter = "첨부 is null"
            End If

        Else

            If _chkAttached.Checked = True Then
                _bind.Filter = "구분 = '" & _cbCategory.Text & "' and 첨부 is not null "
            Else
                _bind.Filter = "구분 = '" & _cbCategory.Text & "' and 첨부 is null"
            End If

        End If

        _laResult.Text = "총 : " & CInt(_bind.Count)
    End Sub

    Private Sub init_dgv()
        '// DataGridView 세팅
        'doubleBuffered()
        Appear_Attachment_image()
        Dim tempSource As BindingSource = New BindingSource
        If Not (_dt_tables Is Nothing) Then
            With _dgv
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                .AllowUserToOrderColumns = True ' 유저가 맘대로 바꾸고 싶을 때
                _bind = tempSource
                _bind.DataSource = _dt_tables
                .DataSource = _bind
                '홀수행을 다른 색으로 보여주고 싶을 때
                '.AlternatingRowsDefaultCellStyle.BackColor = Color.Aqua
                ' 선택 했을 때 back color
                .DefaultCellStyle.SelectionBackColor = Color.White
                ' 선택 했을 때 글씨 color
                .DefaultCellStyle.SelectionForeColor = Color.Black
                ' 열의 색상 지정
                .ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
                '열과 행의 경계선 스타일 지정
                .EnableHeadersVisualStyles = False
                '.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                '열에 보여지는 문자열을 여러행으로 보여주고 싶을 때
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells

                For i As Integer = 0 To 4
                    If i = 2 Or i = 4 Or i = 1 Then
                        .Columns(i).Width = 80
                    Else
                        .Columns(i).Width = 60
                    End If
                Next

                '.Columns(5).Frozen = True
                .Columns(6).Width = 500

                .Columns("첨부").DefaultCellStyle.NullValue = Nothing
                .Columns("파일명").Visible = False
            End With

            Dim new_dt As DataTable = New DataTable
            new_dt = _dt_tables.DefaultView.ToTable(True, "구분")
            _cbCategory.Items.Add("전체")
            If Not (new_dt Is Nothing) Then
                For Each dr As DataRow In new_dt.Rows
                    _cbCategory.Items.Add(dr.Item(0).ToString())
                Next
            End If
            _cbCategory.SelectedIndex = 0

        Else
            Qportals.Debugging.Show("DataTable is Nothing!", "lee.sunbae", 0, 16)
        End If

        cm = New ContextMenuStrip
        cm.Items.Add("열기")
        cm.Items.Add("저장(미구현)")
        _contextmenu = cm
        AddHandler _contextmenu.ItemClicked, AddressOf init_dgv
        For Each rw As DataGridViewRow In _dgv.Rows
            For Each c As DataGridViewCell In rw.Cells
                c.ContextMenuStrip = _contextmenu
            Next
        Next


    End Sub
    Private Sub Appear_Attachment_image()
        Dim tempPath As String = "\\10.169.88.40\Q-Portal\1.검증정보\통합업무관리\업무공지자료"
        For Each dr As DataRow In _dt_tables.Rows
            If Not (dr.Item("파일명").ToString() = "") Then
                dr.Item("첨부") = Image.FromFile("\\10.169.88.40\Q-Portal\4.etc\attached.png")
            Else
                dr.Item("첨부") = Nothing
            End If
        Next
    End Sub

    Public Sub myGrid_RowPostPaint(ByVal sender As Object,
    ByVal e As DataGridViewRowPostPaintEventArgs)
        Try
            If _dgv.CurrentCell Is Nothing Then
                Exit Sub
            End If


            If e.RowIndex = _dgv.CurrentCell.RowIndex Then
                ' Calculate the bounds of the row 
                Dim rowHeaderWidth As Integer =
                    If(_dgv.RowHeadersVisible,
                       _dgv.RowHeadersWidth, 0)
                Dim rowBounds As New Rectangle(
                rowHeaderWidth,
                e.RowBounds.Top,
                _dgv.Columns.GetColumnsWidth(
                        DataGridViewElementStates.Visible) -
                        _dgv.HorizontalScrollingOffset + 1,
                e.RowBounds.Height)

                ' Paint the border 
                ControlPaint.DrawBorder(e.Graphics, rowBounds,
                             Color.Green, ButtonBorderStyle.Solid)

                ' Paint the background color 
                _dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor =
                                            Color.LightGray
            Else
                ' 선택 해제 했을 때
                Dim rowHeaderWidth As Integer = If(_dgv.RowHeadersVisible, _dgv.RowHeadersWidth, 0)
                Dim rowBounds As New Rectangle(rowHeaderWidth, e.RowBounds.Top, _dgv.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) -
                        _dgv.HorizontalScrollingOffset + 1, e.RowBounds.Height)

                ' Paint the border 
                ControlPaint.DrawBorder(e.Graphics, rowBounds, Color.DarkGray, ButtonBorderStyle.Solid)

                ' Paint the background color 
                _dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try



    End Sub





End Class