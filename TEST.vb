Public Class TEST
    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.


        DataGridView1.Columns.Add("test", "test")
        DataGridView1.Rows.Add("")



    End Sub

    Private Sub sdsd(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim arrImage() As Byte
        If DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString = "" Or
            DataGridView1.Rows(e.RowIndex).Cells(0) Is Nothing Then
            Exit Sub
        End If

        arrImage = DataGridView1.Rows(e.RowIndex).Cells(12).Value
        ' arrImage = IIf(IsDBNull(DataGridView1.Rows(e.RowIndex).Cells(12)), "", DataGridView1.Rows(e.RowIndex).Cells(12))
        Dim mstream As New System.IO.MemoryStream(arrImage)
        PictureBox1.Image = Image.FromStream(mstream)
    End Sub

End Class