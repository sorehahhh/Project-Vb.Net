Public Class SubjectListForm
    Public conn As New OleDb.OleDbConnection
    Dim ds As New DataSet
    Dim dataAdapter As New OleDb.OleDbDataAdapter

    Dim sqlString As String
    Dim mSubjectCodeString As String
    Dim subjectMdl As New Subject

    Private Sub SubjectListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disableButton()

        'you can use multiple option in connecting to the database - the following are 3 example to set the connection string
        ' conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\ihsanTuitionCenterDb.accdb"
        conn.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
        ' conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\UTM\SEM I20212022\DDWC2653 VBNetLabDemo
        '\DemoProject\ProjectDemoCRS\ProjectDemoCRS\bin\Debug\ihsanTuitionCenterDb.accdb"

        Try
            'opens the connection
            conn.Open()
            If conn.State = ConnectionState.Open Then
                MsgBox("MS Database Connected!")
                displayAllSubject()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'close the connection
        conn.Close()
    End Sub
    Private Sub displayAllSubject()
        clearSubjectGrid()
        sqlString = "Select * from subject"
        dataAdapter = New OleDb.OleDbDataAdapter(sqlString, conn)
        dataAdapter.Fill(ds, "ihsanTuitionCenterDb")
        Me.SubjectDataGridView.DataMember = "ihsanTuitionCenterDb"
        SubjectDataGridView.DataSource = ds
    End Sub
    Private Sub clearSubjectGrid()
        Me.ds.Clear() 'clear the original data
    End Sub
    Private Sub disableButton()
        With Me
            .AddSubjectButton.Enabled = False
            .updateSubjectButton.Enabled = False
            .DeleteSubjectButton.Enabled = False
        End With
    End Sub
    Private Sub enableButton()
        With Me
            .AddSubjectButton.Enabled = True
            .updateSubjectButton.Enabled = True
            .DeleteSubjectButton.Enabled = True
        End With
    End Sub
    Private Sub AddSubjectButton_Click(sender As Object, e As EventArgs) Handles AddSubjectButton.Click
        SubjectForm.prepareToAddNewSubject()
        SubjectForm.ShowDialog()
        'Me.SubjectGroupDataGridView.Refresh()
        displayAllSubject()
    End Sub

    Private Sub SubjectDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SubjectDataGridView.CellClick
        Dim cb As New OleDb.OleDbCommandBuilder(dataAdapter)
        Dim col, inc As Integer
        ' MessageBox.Show(SubjectGroupDataGridView.CurrentCell.ColumnIndex)
        Try
            col = SubjectDataGridView.CurrentCell.ColumnIndex
            If col <> 0 Then 'ignore if not click on primary key - groupId
                disableButton()
                Exit Sub
            End If
            inc = SubjectDataGridView.CurrentCell.RowIndex
            'store the selected subjectGroupId from the cell selection
            mSubjectCodeString = SubjectDataGridView.CurrentCell.Value
            If (mSubjectCodeString <> "") Then
                enableButton()
            Else
                disableButton()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub updateSubjectButton_Click(sender As Object, e As EventArgs) Handles updateSubjectButton.Click
        If mSubjectCodeString <> "" Then
            SubjectForm.prepareToUpdateSubject(mSubjectCodeString)
            SubjectForm.ShowDialog()
            displayAllSubject()
        End If
    End Sub

    Private Sub DeleteSubjectButton_Click(sender As Object, e As EventArgs) Handles DeleteSubjectButton.Click
        Dim dialogResult As MsgBoxResult
        Dim deletedOK As Boolean
        Dim messageString = "Delete Subject  :" & mSubjectCodeString
        If mSubjectCodeString <> "" Then
            dialogResult = MessageBox.Show(messageString, "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If dialogResult = MsgBoxResult.Ok Then
                deletedOK = subjectMdl.deleteSubjectRecord(mSubjectCodeString)
                displayAllSubject()
            End If
        End If
    End Sub

    Private Sub nameButton_Click(sender As Object, e As EventArgs) Handles nameButton.Click
        clearSubjectGrid()

        sqlString = "Select * from subject where name like '%" & searchTextBox.Text & "%'"
        Debug.WriteLine(sqlString)
        dataAdapter = New OleDb.OleDbDataAdapter(sqlString, conn)
        dataAdapter.Fill(ds, "ihsanTuitionCenterDb")
        Me.SubjectDataGridView.DataMember = "ihsanTuitionCenterDb"
        SubjectDataGridView.DataSource = ds
    End Sub

    Private Sub displayAllButton_Click(sender As Object, e As EventArgs) Handles displayAllButton.Click
        displayAllSubject()
    End Sub
End Class