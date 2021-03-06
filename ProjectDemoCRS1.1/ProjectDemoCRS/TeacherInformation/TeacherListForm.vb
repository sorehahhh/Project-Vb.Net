Public Class TeacherListForm
    Public conn As New OleDb.OleDbConnection
    Dim ds As New DataSet
    Dim dataAdapter As New OleDb.OleDbDataAdapter

    Dim sqlString As String
    Dim mIdString As String
    Dim teacherMdl As New Teacher

    Private Sub TeacherListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                displayAllTeacher()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'close the connection
        conn.Close()
    End Sub
    Private Sub displayAllTeacher()
        clearTeacherGrid()
        sqlString = "Select * from teacher"
        dataAdapter = New OleDb.OleDbDataAdapter(sqlString, conn)
        dataAdapter.Fill(ds, "ihsanTuitionCenterDb")
        Me.TeacherDataGridView.DataMember = "ihsanTuitionCenterDb"
        TeacherDataGridView.DataSource = ds
    End Sub
    Private Sub clearTeacherGrid()
        Me.ds.Clear() 'clear the original data
    End Sub
    Private Sub disableButton()
        With Me
            .AddTeacherButton.Enabled = False
            .updateTeacherButton.Enabled = False
            .DeleteTeacherButton.Enabled = False
        End With
    End Sub
    Private Sub enableButton()
        With Me
            .AddTeacherButton.Enabled = True
            .updateTeacherButton.Enabled = True
            .DeleteTeacherButton.Enabled = True
        End With
    End Sub
    Private Sub AddTeacherButton_Click(sender As Object, e As EventArgs) Handles AddTeacherButton.Click
        TeacherForm.prepareToAddNewTeacher()
        TeacherForm.ShowDialog()
        'Me.TeacherGroupDataGridView.Refresh()
        displayAllTeacher()
    End Sub

    Private Sub TeacherDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles TeacherDataGridView.CellClick
        Dim cb As New OleDb.OleDbCommandBuilder(dataAdapter)
        Dim col, inc As Integer
        ' MessageBox.Show(TeacherGroupDataGridView.CurrentCell.ColumnIndex)
        Try
            col = TeacherDataGridView.CurrentCell.ColumnIndex
            If col <> 0 Then 'ignore if not click on primary key - groupId
                disableButton()
                Exit Sub
            End If
            inc = TeacherDataGridView.CurrentCell.RowIndex
            'store the selected teacherGroupId from the cell selection
            mIdString = TeacherDataGridView.CurrentCell.Value
            If (mIdString <> "") Then
                enableButton()
            Else
                disableButton()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub updateTeacherButton_Click(sender As Object, e As EventArgs) Handles updateTeacherButton.Click
        If mIdString <> "" Then
            TeacherForm.prepareToUpdateTeacher(mIdString)
            TeacherForm.ShowDialog()
            displayAllTeacher()
        End If
    End Sub

    Private Sub DeleteTeacherButton_Click(sender As Object, e As EventArgs) Handles DeleteTeacherButton.Click
        Dim dialogResult As MsgBoxResult
        Dim deletedOK As Boolean
        Dim messageString = "Delete Teacher  :" & mIdString
        If mIdString <> "" Then
            dialogResult = MessageBox.Show(messageString, "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If dialogResult = MsgBoxResult.Ok Then
                deletedOK = teacherMdl.deleteTeacherRecord(mIdString)
                displayAllTeacher()
            End If
        End If
    End Sub

    Private Sub nameButton_Click(sender As Object, e As EventArgs) Handles nameButton.Click
        clearTeacherGrid()

        sqlString = "Select * from teacher where name like '%" & searchTextBox.Text & "%'"
        Debug.WriteLine(sqlString)
        dataAdapter = New OleDb.OleDbDataAdapter(sqlString, conn)
        dataAdapter.Fill(ds, "ihsanTuitionCenterDb")
        Me.TeacherDataGridView.DataMember = "ihsanTuitionCenterDb"
        TeacherDataGridView.DataSource = ds
    End Sub

    Private Sub displayAllButton_Click(sender As Object, e As EventArgs) Handles displayAllButton.Click
        displayAllTeacher()
    End Sub


End Class