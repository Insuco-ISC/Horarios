Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class maestro
    ' Método para cargar datos desde la base de datos y mostrar en el DataGridView
    Private Sub LoadData()
        Dim connectionString As String = "server=104.243.38.5;database=Escuela;uid=root;pwd=insuco2024;"
        Dim query As String = "SELECT * FROM maestros"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()

                Try
                    connection.Open()
                    ' Llenar el DataTable con los datos de la consulta
                    adapter.Fill(table)
                    ' Asignar el DataTable al DataGridView
                    DataGridView1.DataSource = table
                Catch ex As Exception
                    MessageBox.Show("Error al cargar los datos: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub maestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar datos al iniciar la ventana
        LoadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Botón para regresar al menú principal
        menuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub ClearTextBoxes()
        ' Limpiar todos los cuadros de texto
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Function ValidarCampos() As Boolean
        ' Validar que todos los campos estén llenos
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

        If String.IsNullOrWhiteSpace(TextBox5.Text) Then
            MessageBox.Show("El campo Compatibilidad es obligatorio.")
            TextBox5.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Obtener información de la fila seleccionada y colocarla en los cuadros de texto
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("id").Value.ToString()
            TextBox2.Text = row.Cells("nombre").Value.ToString()
            TextBox3.Text = row.Cells("carrera").Value.ToString()
            TextBox4.Text = row.Cells("turno").Value.ToString()
            TextBox5.Text = row.Cells("compatibilidad").Value.ToString()
            Button3.Enabled = True
            Button2.Enabled = False
        End If
    End Sub
    Public Sub SetDoubleBuffered(control As Control, enabled As Boolean)
        Dim doubleBufferPropertyInfo = control.[GetType]().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        If doubleBufferPropertyInfo IsNot Nothing Then
            doubleBufferPropertyInfo.SetValue(control, enabled, Nothing)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Método para agregar un nuevo registro a la base de datos
        Dim connectionString As String = "server=104.243.38.5;database=Escuela;uid=root;pwd=insuco2024;"

        If Not ValidarCampos() Then
            Exit Sub
        End If

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand("INSERT INTO maestros (nombre, carrera, turno, compatibilidad) VALUES (@nombre, @carrera, @turno, @compatibilidad)", connection)
                Try
                    connection.Open()

                    command.Parameters.AddWithValue("@nombre", TextBox2.Text)
                    command.Parameters.AddWithValue("@carrera", TextBox3.Text)
                    command.Parameters.AddWithValue("@turno", TextBox4.Text)
                    command.Parameters.AddWithValue("@compatibilidad", TextBox5.Text)

                    command.ExecuteNonQuery()
                    MessageBox.Show("Registro agregado correctamente")
                    LoadData() ' Recargar los datos después de insertar
                    ClearTextBoxes()
                Catch ex As Exception
                    MessageBox.Show("Error al registrar: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Método para editar un registro en la base de datos
        Dim connectionString As String = "server=104.243.38.5;database=Escuela;uid=root;pwd=insuco2024;"

        ' Validar campos obligatorios
        If Not ValidarCampos() Then
            Exit Sub
        End If

        ' Verificar que el ID esté presente
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("No se ha seleccionado ningún registro para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand("UPDATE maestros SET nombre = @nombre, carrera = @carrera, turno = @turno, compatibilidad = @compatibilidad WHERE id = @id", connection)
                Try
                    connection.Open()

                    ' Agregar parámetros
                    command.Parameters.AddWithValue("@id", TextBox1.Text)
                    command.Parameters.AddWithValue("@nombre", TextBox2.Text)
                    command.Parameters.AddWithValue("@carrera", TextBox3.Text)
                    command.Parameters.AddWithValue("@turno", TextBox4.Text)
                    command.Parameters.AddWithValue("@compatibilidad", TextBox5.Text)

                    ' Ejecutar la actualización
                    command.ExecuteNonQuery()
                    MessageBox.Show("Registro actualizado correctamente")
                    DataGridView1.Refresh()

                    ' Recargar los datos después de actualizar y limpiar los cuadros de texto
                    ClearTextBoxes()
                    LoadData()

                    ' Restaurar el estado de los botones
                    Button3.Enabled = False
                    Button2.Enabled = True

                    ' Desmarcar cualquier selección en el DataGridView
                    DataGridView1.ClearSelection()
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub


End Class
