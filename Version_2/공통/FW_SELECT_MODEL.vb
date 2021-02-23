Imports System.Windows.Forms

Public Class FW_SELECT_MODEL
    Public Shared f As FW_SELECT_MODEL
    Private __ListView As ListView
    Property _ListView As ListView
        Get
            Return __ListView
        End Get
        Set(value As ListView)
            __ListView = value
        End Set
    End Property


    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent() : f = Me
        _ListView = ListView1

        ' init control
        With _ListView
            .FullRowSelect = True
            .View = View.Details
            .CheckBoxes = True
        End With

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ** 조회 된 데이터를 확인 하여 예외 처리를 합니다.
        If Not (ListView1.Items.Count > 0) Then
            Qportals.Debugging.Show("조회 된 결과가 없습니다.", "lee.sunbae@lgepartner.com", 0, 16)
            Me.Close()
        Else
            ' ** 열의 사이즈를 셀의 내용에 따라 늘어나도록 설정 합니다.
            For i As Integer = 0 To ListView1.Columns.Count - 1
                ListView1.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent)
            Next
            ' ** 검색 결과를 표시 해줍니다.
            la_resutl.Text = String.Format("총 : {0} 건 조회되었습니다.", ListView1.Items.Count)

        End If

    End Sub

    '** 모델을 검색해서 확인 버튼을 눌러 저장합니다.
    Private Sub ClickSaveButton(sender As Object, e As EventArgs) Handles btnSave.Click

        ListView1.MultiSelect = False
        If Not (ListView1.SelectedItems.Count > 1) And Not (ListView1.SelectedItems Is Nothing) And Not ListView1.CheckedItems.Count = 0 Then
            ' ** 선택한 열을 다른 폼으로 보냅니다.
            Dim lstRow As Integer = ListView1.Items.IndexOf(ListView1.CheckedItems.Item(0))

            With ListView1.Items.Item(lstRow)

                'Assign_Ver_two.m.txtProin.Text = .SubItems(0).Text.ToString
                'Assign_Ver_two.m.txtGroupin.Text = .SubItems(1).Text.ToString
                'Assign_Ver_two.m.txtModelin.Text = .SubItems(2).Text.ToString
                'Assign_Ver_two.m.txtStepin.Text = .SubItems(3).Text.ToString
                'Assign_Ver_two.m.txtStartin.Text = .SubItems(4).Text.ToString
                'Assign_Ver_two.m.txtEndin.Text = .SubItems(5).Text.ToString

                'Assign_Ver_three.m.txtProin.Text = .SubItems(0).Text.ToString
                'Assign_Ver_three.m.txtGroupin.Text = .SubItems(1).Text.ToString
                'Assign_Ver_three.m.txtModelin.Text = .SubItems(2).Text.ToString
                'Assign_Ver_three.m.txtStepin.Text = .SubItems(3).Text.ToString
                'Assign_Ver_three.m.txtStartin.Text = .SubItems(4).Text.ToString
                'Assign_Ver_three.m.txtEndin.Text = .SubItems(5).Text.ToString

                Qportals.Debugging.Print(.SubItems(0).Text.ToString)
                Qportals.Debugging.Print(.SubItems(1).Text.ToString)
                Qportals.Debugging.Print(.SubItems(2).Text.ToString)
                Qportals.Debugging.Print(.SubItems(0).Text.ToString)

            End With
            Qportals.Debugging.Show("모델 정보 입력 완료 되었습니다." & Environment.NewLine & "이제 할당을 하세요.", "lee.sunbae@lgepartner.com", 0, 64)
            'Assign_Ver_two.m.SlidePanel(sender, e)
            'Assign_Ver_three.m.SlidePanel(sender, e)

            Me.Close()

        Else
            Qportals.Debugging.Show("모델을 선택해주세요.", "lee.sunbae@lgepartner.com", 0, 16)
            Exit Sub
        End If


    End Sub


End Class