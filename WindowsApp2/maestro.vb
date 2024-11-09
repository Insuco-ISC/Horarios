Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class maestro
    Private Sub LoadData()

        Dim connectionString As String = "Server=DESKTOP-P26QFTT\SQLEXPRESS;Database=Escuela;Trusted_Connection=True;"
        Dim query As String = "SELECT * FROM Maestros" ' Cambia "NombreDeLaTabla" por el nombre de tu tabla

        Using connection As New SqlConnection(connectionString)
            ' Crear un adaptador de datos y una tabla
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()

            Try
                ' Abrir la conexión
                connection.Open()

                ' Llenar la tabla con los datos de la consulta
                adapter.Fill(table)

                ' Llenar el DataGridView con los datos de la tabla
                DataGridView1.DataSource = table

            Catch ex As Exception
                MessageBox.Show("Error al cargar los datos: " & ex.Message)
            Finally
                ' Cerrar la conexión (se cierra automáticamente con Using, pero este es un ejemplo explícito)
                connection.Close()
            End Try
        End Using
    End Sub

    Private Sub maestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FUNCION QUE SE CARGA AL CARGAR LA VENTANA Y SE CONECTA AUTOMATICAMENTE A LA BASE DE DATOS
        LoadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'BUTON PARA REGRESAR AL MENU PRINCIPAL
        menuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub ClearTextBoxes()
        'LIMPIAR TODOS LOS CUADROS DE TEXTO
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Function ValidarCampos() As Boolean
        ' Verificar cada campo, si alguno está vacío, devuelve False
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("El campo Nombre es obligatorio.")
            TextBox1.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("El campo Apellidos es obligatorio.")
            TextBox2.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("El campo Correo Electrónico es obligatorio.")
            TextBox3.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("El campo Teléfono es obligatorio.")
            TextBox4.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBox5.Text) Then
            MessageBox.Show("El campo Fecha de Nacimiento es obligatorio.")
            TextBox5.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'OBTENER INFORMACION DE LA FILA SELECCIONADA Y PONER LA INFORMACION EN LOS CUADROS DE TEXTO
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionString As String = "Server=DESKTOP-P26QFTT\SQLEXPRESS;Database=Escuela;Trusted_Connection=True;"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand("INSERT INTO maestros ( nombre, carrera, turno, compatibilidad) VALUES ( @nombre, @carrera, @turno, @compatibilidad)", connection)
                Try
                    connection.Open()

                    command.Parameters.AddWithValue("@nombre", TextBox2.Text)
                    command.Parameters.AddWithValue("@carrera", TextBox3.Text)
                    command.Parameters.AddWithValue("@turno", TextBox4.Text)
                    command.Parameters.AddWithValue("@compatibilidad", TextBox5.Text)

                    command.ExecuteNonQuery()
                    MessageBox.Show("Registro agregado correctamente")
                Catch ex As Exception
                    MessageBox.Show("Error al registrar: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub
End Class