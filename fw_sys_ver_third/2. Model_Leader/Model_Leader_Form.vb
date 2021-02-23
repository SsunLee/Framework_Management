Public Class Model_Leader_Form

    Public _start_date As String
    Public _end_date As String
    Public _seq As String

    Dim FW_Add As uc_a_add_fw   '// F/W 등록
    Dim FW_Ass As uc_a_assign_fw   '// F/W 할당'
    Dim FW_View As uc_s_search  '// F/W 뷰어

    Public Sub New()
        InitializeComponent()
        Default_Design()


        FW_Add = New uc_a_add_fw
        Dim default_size As Integer = FW_Add.Height
        Contain_control(FW_Add, Main_Area_Panel)
        Size = New Size(Width, default_size + 150)

    End Sub
    ''' <summary>
    ''' UserControl을 쉽게 추가할 수 있습니다.
    ''' _uc : 추가할 User Control
    ''' _panel : _uc를 붙힐 Panel
    ''' </summary>
    ''' <param name="_uc"></param>
    ''' <param name="_pnael"></param>
    Private Sub Contain_control(ByRef _uc As UserControl, _pnael As Panel)
        _pnael.Controls.Clear()
        _pnael.Controls.Add(_uc)
        _uc.Dock = DockStyle.Fill

    End Sub

    Private Sub Default_Design()
        Left_Menu_Panel.BackColor = Color.SteelBlue
        Title_area_panel.BackColor = Color.White
    End Sub

    ''' <summary>
    ''' F/W 등록
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Click_FWAdd(sender As Object, e As EventArgs) Handles btn_Add.Click
        FW_Add = New uc_a_add_fw
        Dim default_size As Integer = FW_Add.Height
        Contain_control(FW_Add, Main_Area_Panel)
        Size = New Size(Width, default_size + 150)

    End Sub

    ''' <summary>
    ''' F/W 할당
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Click_FWAssign(sender As Object, e As EventArgs) Handles btn_Ass.Click
        FW_Ass = New uc_a_assign_fw
        Dim default_size As Integer = FW_Ass.Height
        Contain_control(FW_Ass, Main_Area_Panel)
        Size = New Size(Width, default_size + 150)
        'Debug.Print(Height + 160)


    End Sub


    ''' <summary>
    ''' VIEW
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Click_View(sender As Object, e As EventArgs) Handles btn_view.Click
        FW_View = New uc_s_search
        Dim default_size As Integer = FW_View.Height
        Contain_control(FW_View, Main_Area_Panel)
        Size = New Size(Width, default_size + 150)
        'Debug.Print(Height + 160)


    End Sub


End Class