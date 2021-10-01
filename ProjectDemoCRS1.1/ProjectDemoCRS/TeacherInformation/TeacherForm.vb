Public Class TeacherForm
    Dim myTeacher As New Teacher
    ' Dim theTeacherGroupRecord As TeacherGroupRecord
    Dim OldTeacherRec As TeacherRecord


    Friend Sub prepareToUpdateTeacher(teacherId As String)
        MessageBox.Show("to update studnet with id" & teacherId)
        With Me
            .AddUpdateButton.Text = "Update"
        End With
        displayExistingTeacherInfo(teacherId)
    End Sub

    Private Sub displayExistingTeacherInfo(teacherId As String)
        Try
            OldTeacherRec = myTeacher.getTeacherRecord(teacherId)
            With Me
                .icNumberTextBox.Text = OldTeacherRec.ic
                .IdTextBox.Text = OldTeacherRec.id
                .nameTextBox.Text = OldTeacherRec.name
                MessageBox.Show(OldTeacherRec.dob.Date.ToString)
                'displayLevel(OldTeacherGroupRec.groupLevel) 'to check suitable radio button
                '.dobDateTimePicker1.CustomFormat = "dd-MM-yyyy"
                .dobDateTimePicker1.Value = OldTeacherRec.dob.Date
                .PhoneNumberTextBox.Text = OldTeacherRec.phone
                .classComboBox.Text = OldTeacherRec.classGroup

            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Friend Sub prepareToAddNewTeacher()
        clearTeacherForm()
        With Me
            .AddUpdateButton.Text = "Add"
        End With
    End Sub
    Private Sub AddUpdateButton_Click(sender As Object, e As EventArgs) Handles AddUpdateButton.Click
        If AddUpdateButton.Text = "Add" Then
            addThisTeacher() 'add new teacher 
        Else 'update
            updateThisTeacher(OldTeacherRec)
        End If
    End Sub
    Private Sub addThisTeacher()
        Dim theNewTeacherRec As New TeacherRecord
        Dim addOk As Boolean
        Dim messageString As String
        With theNewTeacherRec
            .ic = icNumberTextBox.Text
            .id = IdTextBox.Text
            .name = nameTextBox.Text
            .dob = dobDateTimePicker1.Value
            .classGroup = classComboBox.Text
        End With

        addOk = myTeacher.addTeacher(theNewTeacherRec)
        If addOk Then
            messageString = "New teacher with id : " & theNewTeacherRec.id & " has been added"
            MessageBox.Show(messageString, "Add New Teacher ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
    Private Sub clearTeacherForm()
        With Me
            .IdTextBox.Clear()
            .icNumberTextBox.Clear()
            .nameTextBox.Clear()

            .classComboBox.Text = ""
        End With
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub
    Private Sub updateThisTeacher(oldTeacherRec As TeacherRecord)
        Dim theNewTeacherRec As New TeacherRecord
        Dim updateOk As Boolean
        Dim messageString As String
        theNewTeacherRec.id = IdTextBox.Text
        theNewTeacherRec.name = nameTextBox.Text
        theNewTeacherRec.dob = dobDateTimePicker1.Value
        theNewTeacherRec.classGroup = classComboBox.Text
        updateOk = myTeacher.updateThisTeacher(oldTeacherRec, theNewTeacherRec)
        If updateOk Then
            messageString = "Teacher with id : " & theNewTeacherRec.id & " has been updated"
            MessageBox.Show(messageString, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

End Class