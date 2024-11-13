Imports MySql.Data.MySqlClient

Public Class alumnos
    ' Cadena de conexión a la base de datos
    Private connectionString As String = "server=104.243.38.5;database=Escuela;uid=root;pwd=insuco2024;"

    ' Cargar datos al iniciar el formulario
    Private Sub alumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboBox1()
        LlenarComboBox2()
        LlenarComboBox5()
        CargarListaAlumnos()
        Button3.Enabled = False
        Button2.Enabled = True
    End Sub

    ' Método para cargar todos los alumnos en el DataGridView
    Private Sub CargarListaAlumnos()
        Dim query As String = "SELECT a.id, a.nombre, a.matricula, a.tetra, t.turno, tp.tipo, oe.oferta, c.carrera, a.fechaNacimiento, a.fechaInscripcion, a.status " &
                              "FROM Alumnos a " &
                              "LEFT JOIN Turno t ON a.turno = t.id " &
                              "LEFT JOIN Tipo tp ON a.tipo = tp.id " &
                              "LEFT JOIN oferta_educativa oe ON a.oferta_educativa = oe.id " &
                              "LEFT JOIN Carreras c ON a.carrera = c.id"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    Dim dataTable As New DataTable()
                    Dim adapter As New MySqlDataAdapter(command)

                    connection.Open()
                    adapter.Fill(dataTable)

                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar la lista de alumnos: " & ex.Message)
        End Try
    End Sub

    ' Método para llenar ComboBox de Turno
    Private Sub LlenarComboBox1()
        LlenarComboBox(ComboBox1, "SELECT id, turno FROM Turno", "id", "turno")
    End Sub

    ' Método para llenar ComboBox de Tipo
    Private Sub LlenarComboBox2()
        LlenarComboBox(ComboBox2, "SELECT id, tipo FROM Tipo", "id", "tipo")
    End Sub

    ' Método para llenar ComboBox de Oferta Educativa
    Private Sub LlenarComboBox3(tipoId As String)
        Dim query As String = "SELECT id, oferta FROM oferta_educativa WHERE tipo = @tipo ORDER BY orden"
        LlenarComboBox(ComboBox3, query, "id", "oferta", tipoId)
    End Sub

    ' Método para llenar ComboBox de Carreras
    Private Sub LlenarComboBox4(ofertaId As String)
        Dim query As String = "SELECT id, carrera FROM Carreras WHERE oferta_educativa = @oferta"
        LlenarComboBox(ComboBox4, query, "id", "carrera", ofertaId)
    End Sub

    ' Método para llenar ComboBox de Tetra
    Private Sub LlenarComboBox5()
        ComboBox5.Items.Clear()
        For i As Integer = 1 To 10
            ComboBox5.Items.Add(New KeyValuePair(Of Integer, String)(i, i.ToString()))
        Next
        ComboBox5.DisplayMember = "Value"
        ComboBox5.ValueMember = "Key"
    End Sub

    ' Método genérico para llenar ComboBox
    Private Sub LlenarComboBox(comboBox As ComboBox, query As String, valueMember As String, displayMember As String, Optional parameterValue As String = "")
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    If parameterValue <> "" Then
                        command.Parameters.AddWithValue("@tipo", parameterValue)
                        command.Parameters.AddWithValue("@oferta", parameterValue)
                    End If

                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        comboBox.Items.Clear()
                        While reader.Read()
                            comboBox.Items.Add(New KeyValuePair(Of String, String)(reader(valueMember).ToString(), reader(displayMember).ToString()))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message)
        End Try

        comboBox.DisplayMember = "Value"
        comboBox.ValueMember = "Key"
    End Sub

    ' Evento para manejar la selección en el DataGridView
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            TextBox1.Text = row.Cells("id").Value.ToString()
            TextBox2.Text = row.Cells("nombre").Value.ToString()
            TextBox8.Text = row.Cells("matricula").Value.ToString()
            TextBox5.Text = row.Cells("fechaNacimiento").Value.ToString()

            ComboBox5.SelectedIndex = ComboBox5.FindStringExact(row.Cells("tetra").Value.ToString())
            ComboBox1.SelectedIndex = ComboBox1.FindStringExact(row.Cells("turno").Value.ToString())
            ComboBox2.SelectedIndex = ComboBox2.FindStringExact(row.Cells("tipo").Value.ToString())

            Dim tipoId As String = CType(ComboBox2.SelectedItem, KeyValuePair(Of String, String)).Key
            LlenarComboBox3(tipoId)
            ComboBox3.SelectedIndex = ComboBox3.FindStringExact(row.Cells("oferta").Value.ToString())

            Dim ofertaId As String = CType(ComboBox3.SelectedItem, KeyValuePair(Of String, String)).Key
            LlenarComboBox4(ofertaId)
            ComboBox4.SelectedIndex = ComboBox4.FindStringExact(row.Cells("carrera").Value.ToString())

            Button3.Enabled = True
            Button2.Enabled = False
        Else
            Button3.Enabled = False
            Button2.Enabled = True
        End If
    End Sub

    ' Método para insertar un nuevo alumno
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(TextBox2.Text) Or String.IsNullOrWhiteSpace(TextBox5.Text) Or String.IsNullOrWhiteSpace(TextBox8.Text) Then
            MessageBox.Show("Por favor, complete todos los campos obligatorios.")
            Exit Sub
        End If

        Dim query = "INSERT INTO Alumnos (nombre, matricula, tetra, turno, tipo, oferta_educativa, carrera, fechaNacimiento, fechaInscripcion, status) " &
                    "VALUES (@nombre, @matricula, @tetra, @turno, @tipo, @oferta, @carrera, @fechaNacimiento, NOW(), '1')"

        EjecutarConsulta(query, True)
    End Sub

    ' Método para actualizar el alumno seleccionado
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione un alumno para actualizar.")
            Exit Sub
        End If

        Dim id As String = TextBox1.Text
        Dim query = "UPDATE Alumnos SET nombre = @nombre, matricula = @matricula, tetra = @tetra, turno = @turno, " &
                    "tipo = @tipo, oferta_educativa = @oferta, carrera = @carrera, fechaNacimiento = @fechaNacimiento " &
                    "WHERE id = @id"

        EjecutarConsulta(query, False, id)
    End Sub

    ' Método para ejecutar consulta SQL
    Private Sub EjecutarConsulta(query As String, insertar As Boolean, Optional id As String = "")
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@nombre", TextBox2.Text)
                    command.Parameters.AddWithValue("@matricula", TextBox8.Text)
                    command.Parameters.AddWithValue("@tetra", CType(ComboBox5.SelectedItem, KeyValuePair(Of Integer, String)).Key)
                    command.Parameters.AddWithValue("@turno", CType(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key)
                    command.Parameters.AddWithValue("@tipo", CType(ComboBox2.SelectedItem, KeyValuePair(Of String, String)).Key)
                    command.Parameters.AddWithValue("@oferta", CType(ComboBox3.SelectedItem, KeyValuePair(Of String, String)).Key)
                    command.Parameters.AddWithValue("@carrera", If(ComboBox4.SelectedItem IsNot Nothing, CType(ComboBox4.SelectedItem, KeyValuePair(Of String, String)).Key, "0"))
                    command.Parameters.AddWithValue("@fechaNacimiento", DateTime.Parse(TextBox5.Text).ToString("yyyy-MM-dd"))
                    If Not insertar Then command.Parameters.AddWithValue("@id", id)

                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show(If(insertar, "Alumno insertado exitosamente.", "Alumno actualizado exitosamente."))
                    LimpiarCampos()
                    CargarListaAlumnos()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Botón para regresar al menú principal
        menuPrincipal.Show()
        Me.Hide()
    End Sub
    ' Método para limpiar los campos del formulario
    Private Sub LimpiarCampos()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox8.Clear()
        TextBox5.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox5.SelectedIndex = -1
        Button3.Enabled = False
        Button2.Enabled = True
    End Sub
End Class

