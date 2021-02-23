Imports System.Threading

Public Class menu_frame

    Public Shared f As menu_frame

    Public Sub New()

        InitializeComponent()

        f = Me

        Add_userSelect()    ' 처음 로드 될 때 모드 선택

    End Sub

    Private _uc_modeSelect As New menu_select_screen   ' 관리자/모델리더/검증원 선택하는 메뉴

    Private Sub Add_userSelect()

        main_panel.Controls.Add(_uc_modeSelect)
        _uc_modeSelect.Dock = DockStyle.Fill


    End Sub








End Class