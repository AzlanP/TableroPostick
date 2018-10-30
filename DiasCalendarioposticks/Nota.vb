Public Class Nota

    Dim da As New Datos

    
    Private Sub btnGuardarNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarNota.Click
        Dim oPostick As New plantillaPostick
        oPostick.Titulo = txtTitulo.Text
        oPostick.Descripcion = txtDescripcion.Text
        oPostick.Fecha = CDate(dtpFecha.Text).ToShortDateString
        da.NuevoPostick(oPostick)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class