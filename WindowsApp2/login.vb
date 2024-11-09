Public Class login
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        maestro.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "roman" And TextBox2.Text = "roman" Then
            menuPrincipal.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
