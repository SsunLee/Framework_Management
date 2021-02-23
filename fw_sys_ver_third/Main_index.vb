Imports System.Threading

Public Class Main_index
    Public Shared f As Main_index
    Private main_menu As menu_frame
    Public Sub New()

        InitializeComponent()
        f = Me
        Get_user_company()

        laName.Text = String.Format("{0} 님 환영합니다.", _user)

        Dim c As c_db = New c_db
















    End Sub

    Private Sub FW_Connection(sender As Object, e As EventArgs) Handles btn_connect_fw.Click

        main_menu = New menu_frame
        main_menu.Show()

    End Sub


    Private Sub NewProject_Connection(sender As Object, e As EventArgs) Handles btn_pjt.Click
        Dim FW_ADD_MODEL As New FW_ADD_MODEL
        FW_ADD_MODEL.Show()



    End Sub




#Region "사용자정보"
    Public _user As String
    Public _company As String
    Private Sub Get_user_company()

        Dim getInfos As Qportals.ComputerInfo = New Qportals.ComputerInfo
        Dim com_dt As DataTable = New DataTable
        _user = If(getInfos.getUserName.ToString() = "", "이순배", getInfos.getUserName)
        If _user <> "" Then
            Try
                com_dt = getInfos.GetContact(_user)

                If (com_dt.Rows.Count > 0) Then
                    _company = If(com_dt.Rows(0)("업체명").ToString = "", "미등록사용자", com_dt.Rows(0)("업체명").ToString)
                Else
                    _company = "TEST E&C"
                End If
                com_dt = getInfos.GetContact(_user)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally

            End Try




        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TEST As New TEST
        TEST.Show()
    End Sub

#End Region
End Class