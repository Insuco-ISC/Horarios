Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundedButton
    Inherits Button

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim graphics As Graphics = e.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Define el radio de redondeo
        Dim cornerRadius As Integer = 20
        Dim buttonPath As New GraphicsPath()

        ' Crea la forma redondeada
        buttonPath.StartFigure()
        buttonPath.AddArc(New Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90)
        buttonPath.AddArc(New Rectangle(Width - cornerRadius, 0, cornerRadius, cornerRadius), 270, 90)
        buttonPath.AddArc(New Rectangle(Width - cornerRadius, Height - cornerRadius, cornerRadius, cornerRadius), 0, 90)
        buttonPath.AddArc(New Rectangle(0, Height - cornerRadius, cornerRadius, cornerRadius), 90, 90)
        buttonPath.CloseFigure()

        ' Aplica la forma redondeada al botón
        Me.Region = New Region(buttonPath)

        ' Dibuja el fondo del botón con degradado
        Dim brush As New LinearGradientBrush(ClientRectangle, Color.DarkRed, Color.Black, LinearGradientMode.Vertical)
        graphics.FillPath(brush, buttonPath)

        ' Dibuja el texto del botón
        TextRenderer.DrawText(graphics, Me.Text, Me.Font, Me.ClientRectangle, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
End Class
