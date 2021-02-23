Public Class FAS_select_project
    Public Shared f As FAS_select_project
    Private dbc As Qportals.DbConnection.Mysql_Class
    Private _yearDT As DataTable
    Private _pjtDT As DataTable

    Public _pjt As String
    Public _grp As String
    Public _model As String
    Public _step As String

    Public _startdate As String
    Public _enddate As String

    Public _seq As String

    Public _user As String
    Public _company As String

    Private _flag As Boolean
    ''' <summary>
    ''' 연도와 프로젝트를 선택하여 그 정보를 SQL 서버에 넘기는 기능을 합니다.
    ''' </summary>
    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        f = Me

        dbc = New Qportals.DbConnection.Mysql_Class
        btn_Save.BackColor = Color.FromArgb(3, 72, 167)

        ' import a Year & pjt information
        Load_year_project()
        Fill_combobox(cb_year, _yearDT)

        cb_year.SelectedIndex = 0
        pn_grp.Visible = False
        pn_model.Visible = False
        pn_step.Visible = False
        _cbbox = cb_pjt

        ' _user 정보 및 _compnay 정보 저장 하기
        Get_user_company()


        _flag = False
    End Sub

    Private Sub SaveButtonClick(sender As Object, e As EventArgs) Handles btn_Save.Click



        _pjt = cb_pjt.Text
        _grp = cbGrp.Text
        _model = cbModel.Text
        _step = cbStep.Text



        Dim sql As String

        sql = String.Format(
            "SELECT * 
             FROM 
                td_defect.`project` 
             WHERE
                Project = '{0}' AND GroupName = '{1}' AND Model = '{2}' AND Step = '{3}' ;",
               _pjt, _grp, _model, _step)
        Dim temp_dt As DataTable = dbc.Mysql_to_datatable(sql)

        If (temp_dt.Rows.Count > 0) Then
            _startdate = temp_dt.Rows(0)("StartDate").ToString
            _enddate = temp_dt.Rows(0)("StartDate").ToString
            _seq = temp_dt.Rows(0)("랭킹").ToString
        End If

        Dim ml As Model_Leader_Form
        Dim f1 As New Form

        ml = New Model_Leader_Form With {.Owner = f1}
        With ml
            .la_pjt.Text = _pjt
            .la_grp.Text = _grp
            .la_model.Text = _model
            .la_step.Text = _step

        End With


        ml.Show()
        menu_frame.f.Hide()

    End Sub


#Region "사용자정보"
    Private Sub Get_user_company()

        Dim getInfos As Qportals.ComputerInfo = New Qportals.ComputerInfo
        Dim com_dt As DataTable = New DataTable
        _user = If(getInfos.getUserName.ToString() = "", "미등록사용자", getInfos.getUserName)
        If _user <> "" Then
            com_dt = getInfos.GetContact(_user)

            If (com_dt.Rows.Count > 0) Then
                _company = If(com_dt.Rows(0)("업체명").ToString = "", "미등록사용자", com_dt.Rows(0)("업체명").ToString)
            Else
                _company = "미등록사용자"
            End If

        End If

    End Sub

#End Region



#Region "콤보박스 "
    Private Sub Selected_Year(sender As Object, e As EventArgs) Handles cb_year.SelectedValueChanged
        Dim sql As String = String.Format _
            (
                "SELECT DISTINCT `Project`, `GroupName`, `Model`, `Step` 
                         FROM td_defect.`project`
                         WHERE DATE_FORMAT(StartDate, '%Y') = '{0}'
                         ORDER BY `Project`;" _
            , cb_year.Text
            )
        _pjtDT = dbc.Mysql_to_datatable(sql)
        Dim pjt_only As DataTable = _pjtDT.DefaultView.ToTable(True, "Project")

        Fill_combobox(cb_pjt, pjt_only)

    End Sub


    Private Sub Select_Changed_Project(sender As Object, e As EventArgs) Handles cb_pjt.SelectedValueChanged
        If (_flag = False) Then
            pn_grp.Visible = True
            pn_model.Visible = True
            pn_step.Visible = True
            If menu_frame.f.Height = 402 Then
                menu_frame.f.Height += 250
            Else
                menu_frame.f.Height = 402
            End If
        End If

        '------------------------------------------

        ClickItems(New ComboBox() {cb_pjt, cbGrp}, _pjtDT)
        _flag = True
    End Sub

    Private Sub Click_NextItem_Num(sender As Object, e As EventArgs) Handles cbGrp.SelectedValueChanged

        ClickItems(New Windows.Forms.ComboBox() {cb_pjt, cbGrp, cbModel}, _pjtDT)

    End Sub
    Private Sub Click_NextItem_Num2(sender As Object, e As EventArgs) Handles cbModel.SelectedValueChanged

        'lsb.ClickNextItem_One_Depth(ListBox1, ListBox2, _dt, 1)
        ClickItems(New Windows.Forms.ComboBox() {cb_pjt, cbGrp, cbModel, cbStep}, _pjtDT)

    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Me.Hide()
    End Sub
    Private _cbbox As ComboBox
    Public Sub AddcbBox(ByRef _dt As DataTable, ByRef _columnName As String)
        Dim temp_dt As DataTable = _dt

        If Not (temp_dt Is Nothing) And Not (temp_dt.Rows.Count = 0) Then
            temp_dt = temp_dt.DefaultView.ToTable(True, _columnName)
            For i As Integer = 0 To temp_dt.Rows.Count - 1
                _cbbox.Items.Add(temp_dt.Rows(i)(_columnName).ToString())
            Next
        End If

    End Sub

    Public Sub ClickItems(ByRef cbBoxs() As ComboBox, ByRef _dt As DataTable)

        Select Case cbBoxs.Length
            Case 2
                _cbbox = cbBoxs(1)
                _cbbox.Items.Clear()
                For Each dr As DataRow In _dt.Rows
                    If cbBoxs(0).Text.ToString = dr.Item(0).ToString Then
                        If Not (_cbbox.Items.Contains(dr.Item(1).ToString)) Then
                            _cbbox.Items.Add(dr.Item(1).ToString)
                        End If
                    End If
                Next
                _cbbox.SelectedIndex = 0

            Case 3
                '// if 컬럼 존재 하면 
                _cbbox = cbBoxs(2)
                _cbbox.Items.Clear()


                For Each dr As DataRow In _dt.Rows

                    If (cbBoxs(0).Text.ToString = dr.Item(0).ToString) And
                    (cbBoxs(1).Text.ToString = dr.Item(1).ToString) Then
                        If Not (_cbbox.Items.Contains(dr.Item(2).ToString)) Then
                            _cbbox.Items.Add(dr.Item(2).ToString)
                        End If
                    End If

                Next
                _cbbox.SelectedIndex = 0


            Case 4

                _cbbox = cbBoxs(3)
                _cbbox.Items.Clear()
                For Each dr As DataRow In _dt.Rows
                    If (cbBoxs(0).Text.ToString = dr.Item(0).ToString) And
                                (cbBoxs(1).Text.ToString = dr.Item(1).ToString) And
                                (cbBoxs(2).Text.ToString = dr.Item(2).ToString) Then
                        If Not (_cbbox.Items.Contains(dr.Item(3).ToString)) Then
                            _cbbox.Items.Add(dr.Item(3).ToString)
                        End If
                    End If
                Next
                _cbbox.SelectedIndex = 0
        End Select


    End Sub


#End Region

#Region "Combobox에 연도 및 프로젝트 정보 넣기 "
    Private Sub Load_year_project()
        Dim dts As List(Of DataTable) = New List(Of DataTable)
        Dim sql As String

        ' 연도 추출 
        sql = String.Format _
            (
                "SELECT DISTINCT DATE_FORMAT(StartDate, '%Y') AS Years
                 FROM td_defect.`project` 
                 ORDER BY Years;"
            )
        _yearDT = dbc.Mysql_to_datatable(sql)
        dts.Add(_yearDT)



    End Sub

    Private Sub Fill_combobox(ByVal cb As ComboBox, ByRef dt As DataTable)

        cb.Items.Clear()
        For Each dr As DataRow In dt.Rows
            Dim s As String = If(dr(0) Is Nothing Or dr(0).ToString = "", "", dr(0).ToString())
            cb.Items.Add(s)
        Next

    End Sub

#End Region

End Class
