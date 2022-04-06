Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Dim type As String
    Dim sides As Integer
    Dim radius As Integer
    Dim t As Integer
    Dim h As Integer
    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            Dim d As Object

            If type = "Line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
            End If
            If type = "Rectangle" Then
                d = New Rect(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
            End If
            If type = "Arch" Then
                d = New arch(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
            End If
            If type = "polygon" Then
                d = New poly(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
            End If
            If type = "engon" Then
                d = New engon(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.sides = sides
                d.radius = radius
            End If
            If type = "Picture" Then
                d = New pbox(PictureBox1.Image, m_Previous, e.Location)
                d.picture = PictureBox2.Image
                d.h = h
                d.w = w
            End If
            m_shapes.Add(d)
                PictureBox1.Invalidate()
                m_Previous = e.Location
            End If
    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        Button1.BackColor = c

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        c = sender.backcolor
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        c = sender.backcolor
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        t = TrackBar1.Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        type = "Line"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        type = "Rectangle"
    End Sub

    Private Sub Arch_Click(sender As Object, e As EventArgs) Handles Arch.Click
        type = "Arch"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        type = "polygon"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        type = "engon"
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        radius = TrackBar2.Value
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        sides = TrackBar3.Value
    End Sub

    Private Sub lengthBar_Scroll(sender As Object, e As EventArgs) Handles lengthBar.Scroll
        w = lengthBar.Value
    End Sub

    Private Sub widthBar_Scroll(sender As Object, e As EventArgs) Handles widthBar.Scroll
        h = widthBar.Value
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        type = "Picture"
    End Sub
End Class
