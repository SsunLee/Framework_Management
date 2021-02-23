Public Class Tester_Form

    Public _start_date As String
    Public _end_date As String
    Public _seq As String

    Dim m_TCwrite As FW_w_result   '// F/W 등록
    Dim uc_r_plan As uc_r_plan   '// F/W 할당

    Public Sub New()
        InitializeComponent()
        Default_Design()

        m_TCwrite = New FW_w_result
        Contain_control(m_TCwrite, Main_Area_Panel)
        Size = New Size(Width, m_TCwrite.Height + 150)



    End Sub
    ''' <summary>
    ''' UserControl을 쉽게 추가할 수 있습니다.
    ''' </summary>
    ''' <param name="_uc">_uc : 추가할 User Control</param>
    ''' <param name="_pnael"> _panel : _uc를 붙힐 Panel</param>
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
        Dim flag As Boolean = False
        m_TCwrite = New FW_w_result
        Dim default_size As Integer = m_TCwrite.Height
        Contain_control(m_TCwrite, Main_Area_Panel)

        Size = New Size(Width, default_size + 150)

    End Sub

    ''' <summary>
    ''' F/W 할당
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Click_FWAssign(sender As Object, e As EventArgs) 
        uc_r_plan = New uc_r_plan
        Dim default_size As Integer = uc_r_plan.Height
        Contain_control(uc_r_plan, Main_Area_Panel)
        Size = New Size(Width, default_size + 160)
        'Debug.Print(Height + 160)


    End Sub


End Class