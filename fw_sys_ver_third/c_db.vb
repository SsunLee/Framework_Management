


Public Class c_db

    Public _rs2 As String = "rs2"
    Public _td_defect As String = "td_defect"
    ''' <summary>
    ''' 큐포탈에 들어가는 Schema 및 Table명이 저장 되어있다.
    ''' </summary>
    Public Sub New()

    End Sub

    Public Shared ReadOnly _server_address As String = "Server=59.16.241.6;Uid=sunbae89;Pwd=sunbae;Database=td_defect"



    ''' <summary>
    '''  assign_mem 스키마에 대한 클래스
    ''' </summary>
    Public Class assign_mem
        Public Sub New()

        End Sub
        Protected Const _schema As String = "`assign_mem`."

        Private f_project As String = _schema & "`f_project`"
        Private manage_date As String = _schema & "`manage_date`"
        Private manage_meminfo As String = _schema & "`manage_meminfo`"
        Private manage_memlevel As String = _schema & "`manage_memlevel`"
        Private manage_model As String = _schema & "`manage_model`"

        Private assign_testcase As String = _schema & "`assign_testcase`"

        Public ReadOnly Property get_f_project As String
            Get
                Return f_project
            End Get
        End Property
        Public ReadOnly Property get_manage_date As String
            Get
                Return manage_date
            End Get
        End Property
        Public ReadOnly Property get_manage_meminfo As String
            Get
                Return manage_meminfo
            End Get
        End Property
        Public ReadOnly Property get_manage_memlevel As String
            Get
                Return manage_memlevel
            End Get
        End Property
        Public ReadOnly Property get_manage_model As String
            Get
                Return manage_model
            End Get
        End Property
        Public ReadOnly Property get_assign_testcase As String
            Get
                Return assign_testcase
            End Get
        End Property



    End Class

    Public Class td_defect


    End Class

End Class

