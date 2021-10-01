Public Class CrsMainForm
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        End
    End Sub

    Private Sub CrsMainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub TeacherInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeacherInformationToolStripMenuItem.Click
        StudentGroupListForm.ShowDialog()
    End Sub

    Private Sub StudentListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentListToolStripMenuItem.Click
        StudentListForm.ShowDialog()
    End Sub
    Private Sub TeacherListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TeacherListToolStripMenuItem1.Click
        TeacherListForm.ShowDialog()
    End Sub

    Private Sub SubjectListToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SubjectListToolStripMenuItem.Click
        SubjectListForm.ShowDialog()
    End Sub


    Private Sub AddTeacherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTeacherToolStripMenuItem.Click
        TeacherForm.ShowDialog()
    End Sub
End Class
