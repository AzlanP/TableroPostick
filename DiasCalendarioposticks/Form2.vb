Imports System.Globalization

Public Class Form2
    Dim arrayPanels(6) As Panel
    Dim arraylabels(6) As Label
    Dim Postick() As ListBox
    Dim PosY As Integer = 0
    Dim fecha As Date
    Dim c As New CultureInfo("es-ES")
    Dim dias() As String
    Dim arrayFechasLabels(6) As Date
    Dim BD As New Datos
    '---------------------------------------------------------------------------------------------------------------------------------------------------
    ' -----------ESTE GUARDA LOS PANELS INTERIORES EN UN ARRAY // NO MOVER NI UN PANEL NI LOS VALORES DEL FOR-------------------------------------------------------------------------------------------
    ' ---------------------------------------------------------------------------------------------------------------------

    Public Sub llenarArrayPanels()
        If arrayPanels(0) Is Nothing Then
            Dim i As Integer = 6
            For Each contenedor In panelPostick.Controls
                arrayPanels(i) = contenedor
                i -= 1
            Next
        Else
            MsgBox("el array ya esta lleno")
        End If

    End Sub


    '---------------------------------------------------------------------------------------------------------------------------------------------------
    '    -----------------------ESTOS METODOS SON PARA EL PANEL DE FECHAS SUPERIOR-------------------------------------------------------------------------------------------
    '            ---------------------------------------------------------------------------------------------------------------------------------------------------

    Public Sub Rellenar(ByVal valor As Date)
        Dim meses() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
        fecha = valor
        Dim m As Integer = fecha.Month
        MesesCalendario.Text = meses(m - 1) & "  " & fecha.Year
        Dim ArrayFechasSiguientes(6) As Date
        Dim ArrayFechasAnteriores(6) As Date
        ' esto obtiene el nombre de todos los dias
        dias = c.DateTimeFormat.DayNames
        Dim j As Integer = 0
        'para los dias siguientes
        For j = 0 To 6
            ArrayFechasSiguientes(j) = fecha.AddDays(j)
        Next
        'para los dias anteriores
        For j = 6 To 0 Step -1
            ArrayFechasAnteriores(j) = fecha.AddDays(-j - 1)
        Next
        'Dim Hoy As Date = DateTime.Today


        'agregar los labels al array

        Dim i As Integer = 0
        For Each Label In SemanaDias.Controls
            arraylabels(i) = Label
            i += 1
        Next

        'para agregar los valores a los labels
        Dim NumSemana As Integer = fecha.DayOfWeek
        'Array.Reverse(arraylabels)
        Dim x As Integer = 0
        For i = NumSemana To arraylabels.Length - 1
            arraylabels(i).Text = ArrayFechasSiguientes(x).ToString("dddd", New CultureInfo("ES-es")) & " " & ArrayFechasSiguientes(x).Day
            arrayFechasLabels(i) = ArrayFechasSiguientes(x).Date

            x += 1
        Next
        'relleno labels fechas anteriores
        x = 0
        For i = NumSemana - 1 To 0 Step -1
            arraylabels(i).Text = ArrayFechasAnteriores(x).ToString("dddd", New CultureInfo("ES-es")) & " " & ArrayFechasAnteriores(x).Day
            arrayFechasLabels(i) = ArrayFechasAnteriores(x).Date
            x += 1
        Next


    End Sub

    Private Sub btnPosteriorSemana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPosteriorSemana.Click
        Dim nuevafecha As Date = fecha.AddDays(7)

        Rellenar(nuevafecha)
        LimpiarPosticksEnPanels()
        AcomodarPostickEnPanels()
    End Sub

    Private Sub btnAnteriorSemana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorSemana.Click
        'Dim fecha As Date = Format(#10/5/2018#, "dd/MM/yyyy")
        Dim nuevafecha As Date = fecha.AddDays(-7)
        Rellenar(nuevafecha)
        LimpiarPosticksEnPanels()
        AcomodarPostickEnPanels()
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------
    '    ---------------------------------------------------------------------------------------------------------------------------------------------------
    '            ---------------------------------------------------------------------------------------------------------------------------------------------------


    Public Sub AcomodarPostickEnPanels()
        Dim ArrayDeDiasPostick(6) As Array
        Dim x As Integer = 0
        For Each dia In arrayFechasLabels
            ArrayDeDiasPostick(x) = BD.TraerPosticksDelDia(dia)
            x += 1
        Next
        x = 0
        For Each cont In arrayPanels
            PosicionarPosticks(cont, ArrayDeDiasPostick(x))
            x += 1
        Next


    End Sub
    Public Sub PosicionarPosticks(ByVal pcont As Panel, ByVal parrayposticks As Array)
        ' en posicionar vamos a tener que pasar el objeto de postick asi podemos agregar el titulo y descripcion
        ' de su postick respectivo

        For i = 0 To parrayposticks.Length - 1
            'limpiar el array de postick
            If Postick Is Nothing Then
                ReDim Preserve Postick(0)
            Else
                ReDim Preserve Postick(Postick.Length)
            End If
            Postick(i) = New ListBox

            Postick(i).Size = New Point(135, 100)

            PosY = i * 101
            Postick(i).Location = New Point(3, PosY)
            'MsgBox(Postick(i).Location.X & " , " & Postick(i).Location.Y)
            Postick(i).BackColor = Color.Yellow
            If PosY > pcont.Size.Height Then
                pcont.Size = New Point(135, PosY)
            End If
            pcont.Controls.Add(Postick(i))
            Dim opostick As New plantillaPostick
            opostick = parrayposticks(i)
            Postick(i).Items.Add("Titulo:" & opostick.Titulo)
            Postick(i).Items.Add("Descripcion:" & opostick.Descripcion)
            PosY = 0
            AddHandler Postick(i).Click, AddressOf list_click


        Next

    End Sub

    Public Sub LimpiarPosticksEnPanels()

        Array.Clear(Postick, 0, Postick.Length)
        Dim x As Integer = 0
        For Each cont As Panel In arrayPanels
            For Each post In cont.Controls
                If TypeOf post Is ListBox Then
                    cont.Controls.Clear()



                End If
            Next
        Next
    End Sub





















    Private Sub list_click(ByVal sender As Object, ByVal e As EventArgs)
        'metodo para poder usar el evento click en todo el array
        'este metodo se debe cambiar para que pueda abrir las modificaciones
        Dim OpenPostick As New Nota
        OpenPostick.Show()
    End Sub






    Private Sub btnNuevaTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaTarea.Click
        Dim frmPostick As New Nota
        frmPostick.Show()
    End Sub


    Private Sub btnEliminarTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTarea.Click

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Rellenar(DateTime.Now)
        llenarArrayPanels()
        AcomodarPostickEnPanels()
    End Sub

End Class