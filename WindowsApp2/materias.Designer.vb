<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class materias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WindowsApp2.My.Resources.Resources.universidad_insuco_logo_landingpage
        Me.PictureBox1.ImageLocation = ""
        Me.PictureBox1.Location = New System.Drawing.Point(932, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(147, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(19, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "<--"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 59)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1243, 257)
        Me.DataGridView1.TabIndex = 14
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(8, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(41, 24)
        Me.TextBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 18)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(536, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 18)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Carrera"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 18)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Turno"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Gray
        Me.Button5.Enabled = False
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(6, 111)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(134, 25)
        Me.Button5.TabIndex = 23
        Me.Button5.Text = "Quitar Seleccion"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(209, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 18)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Tipo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(315, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 18)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Oferta Educativa"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Matutino ", "Nocturno"})
        Me.ComboBox1.Location = New System.Drawing.Point(74, 41)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(92, 26)
        Me.ComboBox1.TabIndex = 32
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Bachillerato", "Universidad"})
        Me.ComboBox2.Location = New System.Drawing.Point(193, 41)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(104, 26)
        Me.ComboBox2.TabIndex = 33
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Bachillerato General", "Bachillerato Tecnico", "Bachillerato doble Titulacion"})
        Me.ComboBox3.Location = New System.Drawing.Point(318, 41)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(114, 26)
        Me.ComboBox3.TabIndex = 34
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"Maestría en Educación" & Global.Microsoft.VisualBasic.ChrW(9), "Ingeniería Industrial Administrador" & Global.Microsoft.VisualBasic.ChrW(9), "Ingeniería Civil" & Global.Microsoft.VisualBasic.ChrW(9), "Ingeniería en Sistemas Computacionales" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Ciencias Jurídicas" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Criminología" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Contador Público" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Comercio Internacional" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Administración de Empresas" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Mercadotecnia" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Ciencias de la Comunicación" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Diseño Gráfico" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Psicología" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Educación y Administración Educati..." & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Arquitectura" & Global.Microsoft.VisualBasic.ChrW(9), "Licenciatura en Educación Física y Deportes" & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato Técnico con Acentuación en Analista P..." & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato Técnico con Acentuación en Mantenimie..." & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato Técnico con Acentuación en Contabilid..." & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato Técnico con Acentuación en Asistente ..." & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato General + Carrera Técnica en Sistemas" & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato General + Carrera Técnica en Asistent..." & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato General + Carrera Técnica en Asistent..." & Global.Microsoft.VisualBasic.ChrW(9), "Bachillerato General" & Global.Microsoft.VisualBasic.ChrW(9)})
        Me.ComboBox4.Location = New System.Drawing.Point(438, 41)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(310, 26)
        Me.ComboBox4.TabIndex = 35
        '
        'ComboBox7
        '
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Items.AddRange(New Object() {"Informática Básica I" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9), "Lengua Extranjera ", "Introducción al Derecho", "Administración I", "Metodología e Investigación", "Taller de Comunicación Oral", "Contabilidad I", "Análisis del Entorno Profesional y Laboral", "Informática Básica II", "Matemáticas I", "Lengua Extranjera II", "Derecho del Trabajo y Seguridad Social", "Administración II", "Contabilidad II", "Análisis del Entorno Profesional y Laboral II", "Informática I", "Fundamentos de Desarrollo de Sistemas", "Dibujo", "Matemáticas II", "Redes de Computadoras", "Lengua Extranjera III", "Mercadotecnia I", "Psicología Organizacional", "Informática II", "Matemáticas III"})
        Me.ComboBox7.Location = New System.Drawing.Point(763, 41)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(154, 26)
        Me.ComboBox7.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(797, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 18)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Materias"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.ComboBox7)
        Me.GroupBox1.Controls.Add(Me.ComboBox4)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 322)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1243, 161)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta de Materias"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.ForestGreen
        Me.Button3.Enabled = False
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(763, 111)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 25)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "Modificar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(917, 111)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 25)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Registrar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'materias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1281, 495)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "materias"
        Me.Text = "materias"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents ComboBox7 As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
End Class
