Imports System.Windows

Public Class uc_a_add_fw

    Private fa As Assign_System_for_Assign

    Public Sub New()

        InitializeComponent()

        fa = New Assign_System_for_Assign(DataGridView1)


        ' 기본 툴팁 컨트롤 사용 
        Dim tooltip As New ToolTip
        fa.ToolTipSetting(btn_down, "양식을 다운로드하여, 내용을 채운 후 드래그 드랍하세요.")
        fa.main()




    End Sub


#Region "드래그 앤 드랍"

    Private Sub DragOver_OnPanel(sender As Object, e As Windows.Forms.DragEventArgs) Handles DataGridView1.DragOver

        If (e.Data.GetDataPresent(Forms.DataFormats.FileDrop)) Then
            e.Effect = Forms.DragDropEffects.Copy
        Else
            e.Effect = Forms.DragDropEffects.None
        End If
    End Sub
    Private Sub DragEnter_OnPanel(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView1.DragDrop

        Dim blCheck As Boolean = False       '# DragDrop 시 DragEventArgs를 통해 Data를 받아 온다. 
        Dim files() As String = e.Data.GetData(Forms.DataFormats.FileDrop)      '# Array 형식으로 저장 된 것을 난 파일 하나만 허용 할 거기 때문에 


        fa.DragAfter_ExcelFiles(files)



    End Sub

#End Region
#Region "템플릿 다운로드"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_down.Click
        ' Template Download
        Dim iofile As Qportals.FileControl = New Qportals.FileControl
        Try
            iofile.SaveFileDialog_sun_custom("\\10.169.88.40\Q-Portal\resource\Assign_Template.xlsx")
        Catch ex As Exception
            MessageBox.Show("서버가 최적화되지 않았습니다.")
        End Try


    End Sub
#End Region

#Region "데이터 업로드"
    Private Sub database_upload(sender As Object, e As EventArgs) Handles btn_upload.Click

        If DataGridView1.Rows.Count > 0 Then

            fa.database_upload()

        End If








    End Sub

#End Region




End Class
