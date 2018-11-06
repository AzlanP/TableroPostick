Public Class Nota

    Dim da As New Datos

    
    Private Sub btnGuardarNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarNota.Click
        Dim oPostick As New plantillaPostick
        oPostick.Titulo = txtTitulo.Text
        oPostick.Descripcion = txtDescripcion.Text
        oPostick.Fecha = CDate(dtpFecha.Text).ToShortDateString
        da.NuevoPostick(oPostick)
    End Sub
    Public Sub AbrirPostick(ByVal id As Integer)
        Dim oPostick As New plantillaPostick
        oPostick = da.BuscarPostick(id)
        lblID.Text = oPostick.IDPostick
        txtTitulo.Text = oPostick.Titulo
        dtpFecha.Text = oPostick.Fecha
        txtDescripcion.Text = oPostick.Descripcion
    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Nota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class