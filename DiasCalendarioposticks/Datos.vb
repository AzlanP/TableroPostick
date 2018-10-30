Imports System.Data.SQLite
Public Class Datos
    Dim oPostick As New plantillaPostick

    Dim CadenaConexion As String = "Data Source=C:\Users\Admin\Desktop\DiasCalendarioposticks\Ejemplo.db ; Version=3"
    Dim con As New SQLiteConnection(CadenaConexion)
    Public Sub conectar()

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If



    End Sub
    Public Sub Desconectar()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If


    End Sub
    Public Function TablaPostick() As DataTable
        Dim sql As String = "Select * From TablaPostick"
        conectar()
        Dim comando As New SQLiteCommand(sql, con)

        Dim da As New SQLiteDataAdapter
        Dim dt As New DataTable
        da.SelectCommand = comando
        da.Fill(dt)
        Return dt
        Desconectar()
    End Function
    Public Sub NuevoPostick(ByVal obj As plantillaPostick)
        conectar()
        Dim sql As String = "insert into TablaPostick(IDPostick, Titulo, Descripcion, Fecha) values (@IDPostick, @Titulo, @Descripcion, @Fecha)"

        Dim comando As New SQLiteCommand(sql, con)
        With comando.Parameters
            .Add("@IDPostick", SqlDbType.Int).Value = ConsultarUltimoID()
            .Add("@Titulo", SqlDbType.VarChar).Value = obj.Titulo
            .Add("@Descripcion", SqlDbType.VarChar).Value = obj.Descripcion
            .Add("@Fecha", SqlDbType.Date).Value = obj.Fecha

        End With
        comando.ExecuteNonQuery()
        Desconectar()

    End Sub
    Public Function ConsultarUltimoID() As Integer
        conectar()
        Try
            'la sentencia retorna el id del ultimo registro agregado guardado en la tabla de configuracion sequence del autoincrementar.
            Dim sql As String = "Select seq from sqlite_sequence where name='TablaPostick'"
            Dim cmd As New SQLiteCommand(sql, con)
            'el executescalar devuelve la primera columna de la primera fila
            Dim UltimoID As Integer = CInt(cmd.ExecuteScalar())
            Return UltimoID + 1
        Catch ex As Exception
            Throw New Exception("ERROR La consulta de ultimo ID fallo. Descripcion:" & ex.Message)
        End Try
        Desconectar()

    End Function

    Public Function TraerPosticksDelDia(ByVal pfecha As Date) As Array
        ' Este metodo al ingresar una fecha como parametro, consulta con la base de datos
        ' y esta retorna todos los posticks que se encuentren ese dia , estos son guardados en 
        ' un array el cual es devuelto por medio del return
        conectar()
        Dim sql As String = "select * from TablaPostick where (Fecha= '" & pfecha & "')"
        Dim comando As New SQLiteCommand(sql, con)
        'With comando.Parameters

        '    .Add(@Fecha, SqlDbType.VarChar).Value = pfecha

        'End With
        Dim da As New SQLiteDataAdapter
        Dim dt As New DataTable
        da.SelectCommand = comando
        da.Fill(dt)


        Dim total As Integer = dt.Rows.Count - 1
        Dim arraypostick(total) As plantillaPostick

        For i = 0 To total
            Dim oPostick As New plantillaPostick
            oPostick.IDPostick = dt.Rows(i)(0)
            oPostick.Titulo = dt.Rows(i)(1)
            oPostick.Descripcion = dt.Rows(i)(2)
            oPostick.Fecha = dt.Rows(i)(3)
            arraypostick(i) = oPostick
        Next
        Desconectar()
        Return arraypostick

    End Function
End Class
