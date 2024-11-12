Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class alumnos

    ' Método para cargar datos desde la base de datos y mostrar en el DataGridView
    Private Sub LoadData()


        Dim connectionString As String = "server=104.243.38.5;database=Escuela;uid=root;pwd=insuco2024;"
        Dim query As String = "SELECT * FROM Alumnos"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()
                    DataGridView1.DataSource = reader
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub alumnos_load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menuPrincipal.Show()
        Me.Hide()
    End Sub
End Class