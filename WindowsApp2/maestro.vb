Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class maestro
    Private connectionString As String = "server=104.243.38.5;database=Escuela;uid=root;pwd=insuco2024;"

    ' Cargar datos al iniciar el formulario
    Private Sub maestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        LlenarComboBox1()
        Button3.Enabled = False
        Button2.Enabled = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Botón para regresar al menú principal
        menuPrincipal.Show()
        Me.Hide()
    End Sub

    ' Método para cargar datos en el DataGridView
    Private Sub LoadData()
        Dim query As String = "SELECT * FROM maestros"
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim table As New DataTable()
                    connection.Open()
                    adapter.Fill(table)
                    DataGridView1.DataSource = table
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message)
        End Try
    End Sub

    ' Método para limpiar todos los cuadros de texto y el CheckedListBox
    Private Sub ClearTextBoxes()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        CheckedListBox1.Items.Clear()
        Button3.Enabled = False
        Button2.Enabled = True
    End Sub

    ' Validar que todos los campos estén llenos
    Private Function ValidarCampos() As Boolean
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("El campo Nombre es obligatorio.")
            TextBox2.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("El campo Carrera es obligatorio.")
            TextBox3.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("El campo Turno es obligatorio.")
            TextBox4.Focus()
            Return False
        End If

        Return True
    End Function

    ' Llenar ComboBox1 con la lista de carreras
    Private Sub LlenarComboBox1()
        Dim query As String = "SELECT id, carrera FROM Carreras"
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        ComboBox1.Items.Clear()
                        While reader.Read()
                            ComboBox1.Items.Add(New KeyValuePair(Of String, String)(reader("id").ToString(), reader("carrera").ToString()))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar carreras: " & ex.Message)
        End Try
        ComboBox1.DisplayMember = "Value"
        ComboBox1.ValueMember = "Key"
    End Sub

    ' Manejar selección en ComboBox1 y cargar materias en CheckedListBox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim carreraId As String = CType(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
            LlenarCheckedListBox(carreraId)
        End If
    End Sub

    ' Llenar CheckedListBox con materias filtradas por carrera
    Private Sub LlenarCheckedListBox(carreraId As String)
        Dim query As String = "SELECT id, nombre FROM Materias WHERE carrera = @carreraId"
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@carreraId", carreraId)
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        CheckedListBox1.Items.Clear()
                        While reader.Read()
                            CheckedListBox1.Items.Add(reader("nombre").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar materias: " & ex.Message)
        End Try
    End Sub

    ' Obtener IDs de materias seleccionadas
    Private Function ObtenerMateriasSeleccionadas() As String
        Dim seleccionados As New List(Of String)
        For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
            seleccionados.Add((i + 1).ToString()) ' Asumiendo que el ID es el índice + 1
        Next
        Return String.Join(",", seleccionados)
    End Function

    ' Cargar materias seleccionadas en CheckedListBox
    Private Sub CargarMateriasSeleccionadas(compatibilidad As String)
        Dim idsSeleccionados As String() = compatibilidad.Split(","c)
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, idsSeleccionados.Contains((i + 1).ToString()))
        Next
    End Sub

    ' Manejar selección en el DataGridView
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("id").Value.ToString()
            TextBox2.Text = row.Cells("nombre").Value.ToString()
            TextBox3.Text = row.Cells("carrera").Value.ToString()
            TextBox4.Text = row.Cells("turno").Value.ToString()
            Dim compatibilidad As String = If(row.Cells("compatibilidad").Value IsNot Nothing, row.Cells("compatibilidad").Value.ToString(), "")
            CargarMateriasSeleccionadas(compatibilidad)
            Button3.Enabled = True
            Button5.Enabled = True
            Button2.Enabled = False
        End If
    End Sub

    ' Insertar nuevo maestro
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not ValidarCampos() Then Exit Sub
        Dim compatibilidad As String = ObtenerMateriasSeleccionadas()
        Dim query As String = "INSERT INTO maestros (nombre, carrera, turno, compatibilidad) VALUES (@nombre, @carrera, @turno, @compatibilidad)"
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    connection.Open()
                    command.Parameters.AddWithValue("@nombre", TextBox2.Text)
                    command.Parameters.AddWithValue("@carrera", TextBox3.Text)
                    command.Parameters.AddWithValue("@turno", TextBox4.Text)
                    command.Parameters.AddWithValue("@compatibilidad", compatibilidad)
                    command.ExecuteNonQuery()
                    MessageBox.Show("Registro insertado correctamente")
                    LoadData()
                    ClearTextBoxes()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al insertar: " & ex.Message)
        End Try
    End Sub

    ' Actualizar maestro
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Seleccione un registro para actualizar.")
            Exit Sub
        End If
        Dim compatibilidad As String = ObtenerMateriasSeleccionadas()
        Dim query As String = "UPDATE maestros SET nombre = @nombre, carrera = @carrera, turno = @turno, compatibilidad = @compatibilidad WHERE id = @id"
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    connection.Open()
                    command.Parameters.AddWithValue("@id", TextBox1.Text)
                    command.Parameters.AddWithValue("@nombre", TextBox2.Text)
                    command.Parameters.AddWithValue("@carrera", TextBox3.Text)
                    command.Parameters.AddWithValue("@turno", TextBox4.Text)
                    command.Parameters.AddWithValue("@compatibilidad", compatibilidad)
                    command.ExecuteNonQuery()
                    MessageBox.Show("Registro actualizado correctamente")
                    LoadData()
                    ClearTextBoxes()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message)
        End Try
    End Sub

    ' Botón para refrescar datos
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LoadData()
        ClearTextBoxes()
    End Sub
End Class
