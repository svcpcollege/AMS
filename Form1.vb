Imports System.IO

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = TextBox1.Text
        Dim rollNumber As Integer = CInt(TextBox2.Text)

        Dim student As New Student(name, rollNumber, "Present")

        ' Add the student to the list of students
        ListBox1.Items.Add(student)

        ' Clear the name textbox for the next entry
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Create a new save file dialog
        Dim saveFileDialog1 As New SaveFileDialog()

        ' Set the file filter to text files only
        saveFileDialog1.Filter = "Text files (*.txt)|*.txt"

        ' Show the save file dialog
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Open the file for writing
            Dim fileWriter As New StreamWriter(saveFileDialog1.FileName)

            ' Loop through the items in the listbox
            For Each item In ListBox1.Items
                ' Write each student's data to the file
                fileWriter.WriteLine(item.ToString())
            Next

            ' Close the file
            fileWriter.Close()

            ' Show a message box to confirm the file was saved
            MessageBox.Show("File saved successfully!")
        End If
    End Sub
End Class

Public Class Student
    Public Property Name As String
    Public Property RollNumber As Integer
    Public Property AttendanceStatus As String

    Public Sub New(name As String, rollnumber As Integer, attendanceStatus As String)
        Me.Name = name
        Me.RollNumber = rollnumber
        Me.AttendanceStatus = attendanceStatus
    End Sub

    Public Overrides Function ToString() As String
        Return RollNumber & " - " & Name & " - " & AttendanceStatus
    End Function
End Class
