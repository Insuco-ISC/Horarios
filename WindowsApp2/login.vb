Imports MySql.Data.MySqlClient

Public Class login
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Conexión a la base de datos
        Dim connectionString As String = "server=104.243.38.5;database=Escuela;uid=root;pwd=insuco2024;"
        Dim query As String = "SELECT * FROM usuarios WHERE user = @user AND password = @password"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    ' Agregar parámetros
                    command.Parameters.AddWithValue("@user", TextBox1.Text)
                    command.Parameters.AddWithValue("@password", TextBox2.Text)

                    ' Ejecutar la consulta
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    ' Verificar si se encontró el usuario
                    If reader.HasRows Then
                        'MessageBox.Show("Acceso concedido", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        menuPrincipal.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Usuario o contraseña incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    ' Manejar el evento KeyDown para TextBox1 (usuario) y TextBox2 (contraseña)
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick() ' Ejecutar el clic del botón iniciar sesión
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick() ' Ejecutar el clic del botón iniciar sesión
        End If
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class