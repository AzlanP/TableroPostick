Imports System.Globalization

Public Class Form1
    Dim c As New CultureInfo("es-ES")
    Dim dias As String()
    Dim fecha As Date
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Rellenar(DateTime.Now)

    End Sub
    'Public Sub diaActual()

    '    nombredia = DateTime.Today.DayOfWeek
    '    Dim nombre As String() = nombredia.Split(",")
    '    nombredia = nombre(0)
    '    Dim format As DateTimeFormatInfo = New CultureInfo("es-ES").DateTimeFormat
    '    hoy = Date.Today
    '    Dim fecha As Date = Date.Now.Date
    '    mes = fecha.Month
    '    año = fecha.Year
    '    dia = fecha.Day
    '    Dim pos As Integer
    '    Dim numeros As Integer = 0
    '    Dim con As Boolean = False
    '    Dim Posicion As Integer = Weekday(fecha, FirstDayOfWeek.Monday)
    '    MsgBox(Posicion)
    '    'For i = dia To dia + 7
    '    '    While nombredia = dias(numeros) And con = False

    '    '        lvDias.Items.Add(nombredia)
    '    '        pos = numeros
    '    '        con = True



    '    '    End While
    '    '    numeros = numeros + 1
    '    '    lvFecha.Items.Add(dia)
    '    '    dia = dia + 1
    '    '    If pos > 0 Then
    '    '        lvDias.Items.Add(dias(pos))
    '    '        lvFecha.Items.Add(dia)
    '    '        dia = dia + 1
    '    '        pos = pos + 1
    '    '    End If

    '    'Next
    '    'hacer que el dia de hoy sea de entremedio  en el panel
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    diaActual()


    '    'lblsabado2.Text = nombredia
    '    'Dim fechas() As String
    '    'fechas = nombredia.Split(",")
    '    'hoyNombre = fechas(0)
    '    'fechas = nombredia.Split(" ")
    '    'hoyNumero = CInt(fechas(1))
    '    'acomodarlas()

    'End Sub
    ''Public Sub acomodarlas()

    ''    Select Case hoyNombre
    ''        Case "lunes"
    ''            For i = 0 To MaxDias - 1
    ''                lbllunes.Text = hoy
    ''                lblmartes.Text = hoy.AddDays(1)
    ''                lblmiercoles.Text = hoy.AddDays(2)
    ''                lbljueves.Text = hoy.AddDays(3)
    ''                lblviernes.Text = hoy.AddDays(4)
    ''                lblsabado2.Text = hoy.AddDays(5)
    ''                lbldomingo.Text = hoy.AddDays(6)
    ''            Next
    ''        Case "martes"

    ''            For i = 0 To MaxDias - 1
    ''                lbllunes.Text = hoy.AddDays(-1)
    ''                lblmartes.Text = hoy
    ''                lblmiercoles.Text = hoy.AddDays(1)
    ''                lbljueves.Text = hoy.AddDays(2)
    ''                lblviernes.Text = hoy.AddDays(3)
    ''                lblsabado2.Text = hoy.AddDays(4)
    ''                lbldomingo.Text = hoy.AddDays(5)
    ''            Next
    ''        Case "miercoles"

    ''            For i = 0 To MaxDias - 1
    ''                lbllunes.Text = hoy.AddDays(-2)
    ''                lblmartes.Text = hoy.AddDays(-1)
    ''                lblmiercoles.Text = hoy
    ''                lbljueves.Text = hoy.AddDays(1)
    ''                lblviernes.Text = hoy.AddDays(2)
    ''                lblsabado2.Text = hoy.AddDays(3)
    ''                lbldomingo.Text = hoy.AddDays(4)
    ''            Next
    ''        Case "jueves"

    ''            For i = 0 To MaxDias - 1
    ''                lbllunes.Text = hoy.AddDays(-3)
    ''                lblmartes.Text = hoy.AddDays(-2)
    ''                lblmiercoles.Text = hoy.AddDays(-1)
    ''                lbljueves.Text = hoy
    ''                lblviernes.Text = hoy.AddDays(1)
    ''                lblsabado2.Text = hoy.AddDays(2)
    ''                lbldomingo.Text = hoy.AddDays(3)
    ''            Next
    ''        Case "viernes"

    ''            For i = 0 To MaxDias - 1
    ''                lbllunes.Text = hoy.AddDays(1)
    ''                lblmartes.Text = hoy.AddDays(1)
    ''                lblmiercoles.Text = hoy.AddDays(1)
    ''                lbljueves.Text = hoy.AddDays(1)
    ''                lblviernes.Text = hoy
    ''                lblsabado2.Text = hoy.AddDays(1)
    ''                lbldomingo.Text = hoy.AddDays(1)
    ''            Next
    ''        Case "sabado"
    ''            lblsabado.Text = hoyNumero
    ''        Case "domingo"
    ''            lbldomingo.Text = hoyNumero
    ''    End Select

    ''End Sub
    ''Public Sub ValidarDia()



    ''    Try
    ''        Dim fechacompleta As DateTime = Convert.ToDateTime(diastring)


    ''        MsgBox(fechacompleta)

    ''    Catch ex As Exception
    ''        MsgBox("Dia invalido")
    ''    End Try


    ''End Sub

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
        Dim arraylabels(6) As Label
        Dim i As Integer = 0
        For Each Label In SemanaDias.Controls
            arraylabels(i) = Label
            i += 1
        Next

        'para agregar los valores a los labels
        Dim NumSemana As Integer = fecha.DayOfWeek
        'Array.Reverse(arraylabels)
        Dim x As Integer = 0
        For i = NumSemana - 1 To arraylabels.Length - 1
            arraylabels(i).Text = ArrayFechasSiguientes(x).ToString("dddd", New CultureInfo("ES-es")) & " " & ArrayFechasSiguientes(x).Day
            x += 1
        Next
        'relleno labels fechas anteriores
        x = 0
        For i = NumSemana - 2 To 0 Step -1
            arraylabels(i).Text = ArrayFechasAnteriores(x).ToString("dddd", New CultureInfo("ES-es")) & " " & ArrayFechasAnteriores(x).Day
            x += 1
        Next


    End Sub

    Private Sub btnPosteriorSemana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPosteriorSemana.Click
        Dim nuevafecha As Date = fecha.AddDays(7)
        Rellenar(nuevafecha)
    End Sub

    Private Sub btnAnteriorSemana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorSemana.Click
        'Dim fecha As Date = Format(#10/5/2018#, "dd/MM/yyyy")
        Dim nuevafecha As Date = fecha.AddDays(-7)
        Rellenar(nuevafecha)
    End Sub
    Dim arrayPanels(6) As Panel
    Dim Postick() As ListBox

    Public Sub llenarArrayPanels()
        If arrayPanels(0) Is Nothing Then
            Dim i As Integer = 0
            For Each contenedor In panelPostick.Controls
                arrayPanels(i) = contenedor
                i += 1
            Next
        Else
            AgregarPostick(arrayPanels(6))
        End If
        
    End Sub
    Dim PosY As Integer = -100 + 3
    Public Sub AgregarPostick(ByVal cont As Panel)

        If Postick Is Nothing Then
            ReDim Preserve Postick(0)
        Else
            ReDim Preserve Postick(Postick.Length)
        End If

        Postick(Postick.Length - 1) = New ListBox


        ''posicion x,y

        Postick(Postick.Length - 1).Size = New Point(135, 100)

        PosY = PosY + Postick(Postick.Length - 1).Location.Y + 101
        Postick(Postick.Length - 1).Location = New Point(3, posy)
        MsgBox(Postick(Postick.Length - 1).Location.X & " , " & Postick(Postick.Length - 1).Location.Y)
        Postick(Postick.Length - 1).BackColor = Color.Yellow
        If PosY > cont.Size.Height Then
            cont.Size = New Point(135, PosY)
        End If
        cont.Controls.Add(Postick(Postick.Length - 1))
        Postick(Postick.Length - 1).Items.Add(PosY)
        AddHandler Postick(Postick.Length - 1).Click, AddressOf list_click
    End Sub

    Private Sub list_click(ByVal sender As Object, ByVal e As EventArgs)
        'metodo para poder usar el evento click en todo el array
        Dim OpenPostick As New Nota
        OpenPostick.Show()
    End Sub


  
    Private Sub btnNuevaTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaTarea.Click
        llenarArrayPanels()
    End Sub
End Class
