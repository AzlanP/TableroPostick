Public Class plantillaPostick
    Public IDPostick As Integer
    Public Titulo As String
    Public Descripcion As String
    Public Fecha As Date
    Public Sub NuevoPostick(ByVal pTitulo As String, ByVal pDescripcion As String, ByVal pFecha As Date)
        Titulo = pTitulo
        Descripcion = pDescripcion
        Fecha = pFecha

    End Sub
    Public Sub EliminarPostick(ByVal IDpostick As Integer)

    End Sub
End Class
