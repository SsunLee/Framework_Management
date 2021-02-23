Public Class Administrator_Form

    Public _start_date As String
    Public _end_date As String
    Public _seq As String

    Dim m_manage As uc_m_manage '// F/W 등록
    Dim m_member As uc_m_member   '// F/W 할당

    Const MANAGE_SIZE As Integer = 700
    Const MEMBER_SIZE As Integer = 750
    Public Sub New()

        InitializeComponent()
        Default_Design()

        m_manage = New uc_m_manage
        Contain_control(m_manage, Main_Area_Panel)
        Dim default_size As Integer = m_manage.Height
        Size = New Size(Width, MANAGE_SIZE)

    End Sub

    Private Sub main_load(sender As Object, e As EventArgs) Handles MyBase.Load

        m_manage = New uc_m_manage

    End Sub


    ''' <summary>
    ''' UserControl을 쉽게 추가할 수 있습니다.
    ''' _uc : 추가할 User Control
    ''' _panel : _uc를 붙힐 Panel
    ''' </summary>
    ''' <param name="_uc"></param>
    ''' <param name="_pnael"></param>
    Private Sub Contain_control( _uc As UserControl, _pnael As Panel)
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

        Dim default_size As Integer = m_manage.Height
        Debug.Print(String.Format("m_manage.height : {0}", default_size))
        Contain_control(m_manage, Main_Area_Panel)

        Size = New Size(Width, MANAGE_SIZE)

    End Sub

    ''' <summary>
    ''' F/W 할당
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Click_FWAssign(sender As Object, e As EventArgs) Handles btn_Random.Click
        m_member = New uc_m_member
        Contain_control(m_member, Main_Area_Panel)
        Size = New Size(Width, MEMBER_SIZE)


    End Sub


End Class