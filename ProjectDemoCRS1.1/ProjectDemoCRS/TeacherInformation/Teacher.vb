Imports System.Data.OleDb
Friend Structure TeacherRecord
    Dim id, ic, name, email, phone, classGroup As String
    Dim dob As Date
End Structure
Public Class Teacher

    Private con As New OleDb.OleDbConnection
    Friend Function getTeacherRecord(id) As TeacherRecord
        Dim dr As OleDbDataReader
        Dim teacherRec As New TeacherRecord
        Try
            Dim sql As String
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()
            sql = "select * FROM teacher WHERE (idNumber = '" & id & "')"

            MessageBox.Show(sql)
            Debug.WriteLine(sql)
            Dim cmd As New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                teacherRec.ic = dr("icNumber").ToString
                teacherRec.id = dr("idNumber").ToString
                teacherRec.name = dr("name").ToString
                teacherRec.classGroup = dr("groupId").ToString
                teacherRec.dob = dr("dateOfBirth")
                con.Close()
                Return teacherRec
            End If
        Catch
            MessageBox.Show("Error accessing teacher record for teacher with id :" & id)
            con.Close()
            Return teacherRec
        End Try
        Return teacherRec
    End Function
    Friend Function addTeacher(newTeacherRec As TeacherRecord) As Boolean
        Try
            Dim sql As String
            ''Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\registrationdb.accdb")
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()
            If con.State = ConnectionState.Open Then
                MsgBox("MS Database Connected!")
            Else
                MsgBox("error connecting to database")
                Exit Function
            End If
            sql = "insert into teacher(idNumber,icNumber,name,dateOfBirth,groupId)"
            sql = sql & " values('" & newTeacherRec.id & "','" & newTeacherRec.ic & "','" & newTeacherRec.name & "','" & newTeacherRec.dob & "','" & newTeacherRec.classGroup & "')"
            'insert into teacher(idNumber,icNumber,name,dateOfBirth,groupId) values('M1002','','Ahmad','1/9/2021 4:29:14 PM','P1_MERAH')
            MessageBox.Show(sql)
            Debug.WriteLine(sql)
            Dim cmd As New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception

            MessageBox.Show("Error adding new teacher record. Message:" & ex.ToString)
            con.Close()
            Return False
        End Try
        Return True

    End Function
    Friend Function updateThisTeacher(oldTeacherRec As TeacherRecord, newTeacherRec As TeacherRecord) As Boolean
        Try
            Dim sql As String
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()

            sql = "update teacher set idNumber ='" & newTeacherRec.id & "',"
            sql = sql & " icNumber ='" & newTeacherRec.ic & "',"
            sql = sql & " name ='" & newTeacherRec.name & "',"
            sql = sql & " dateOfBirth ='" & newTeacherRec.dob & "',"
            sql = sql & " groupId ='" & newTeacherRec.classGroup & "'"
            sql = sql & " where idNumber ='" & oldTeacherRec.id & "'"
            MessageBox.Show(sql)
            Dim cmd As New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show("Error updating group record. Message:" & ex.ToString)
            Return False
        End Try


    End Function
    Friend Function deleteTeacherRecord(id As String) As Boolean
        Try
            Dim sql As String
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()
            sql = "DELETE FROM teacher WHERE (idNumber = '" & id & "')"
            MessageBox.Show(sql)
            Dim cmd As New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch e As Exception
            MessageBox.Show(e.ToString) 'data integrity error
            Return False
        End Try

    End Function
End Class