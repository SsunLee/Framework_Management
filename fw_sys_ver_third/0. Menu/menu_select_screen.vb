Public Class menu_select_screen
    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        'If Not (menu_frame.f Is Nothing) Then
        '    menu_frame.f.main_panel.Controls.Add(select_project)
        '    select_project.Hide()
        'End If


    End Sub
    ''' <summary>
    '''  Administrator 버튼을 눌렀을 때 Administrator(관리자) Form을 띄워 줍니다.
    ''' </summary>
    Private Sub Administrator(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Dim admin_form As New Administrator_Form
        '        menu_frame.f.main_panel.Controls.Add(admin_form)
        admin_form.Show()
        'admin_form.BringToFront()
    End Sub




    ''' <summary>
    ''' ML 버튼을 눌렀을 때 Model Leader Form을 띄워줍니다.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ModelLeader(sender As Object, e As EventArgs) Handles btn_ML.Click
        Dim select_project As New FAS_select_project
        menu_frame.f.main_panel.Controls.Add(select_project)
        select_project.Dock = DockStyle.Fill
        select_project.Show()
        select_project.BringToFront()

    End Sub

    ''' <summary>
    ''' Tester 버튼을 눌렀을 때 Tester Form을 띄워줍니다.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Tester(sender As Object, e As EventArgs) Handles btn_Tester.Click
        Dim admin_form As New Tester_Form
        admin_form.Show()
        admin_form.BringToFront()

    End Sub




End Class
