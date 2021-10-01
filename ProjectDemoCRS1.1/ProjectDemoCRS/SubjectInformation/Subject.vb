Imports System.Data.OleDb
Friend Structure SubjectRecord
    Dim subjectCode, name, credit, email, phone, classGroup As String
    ' Dim dob As Date
End Structure
Public Class Subject

    Private con As New OleDb.OleDbConnection
    Friend Function getSubjectRecord(subjectCode) As SubjectRecord
        Dim dr As OleDbDataReader
        Dim subjectRec As New SubjectRecord
        Try
            Dim sql As String
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()
            sql = "select * FROM subject WHERE (subjectCodeNumber = '" & subjectCode & "')"

            MessageBox.Show(sql)
            Debug.WriteLine(sql)
            Dim cmd As New OleDbCommand(sql, con)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                subjectRec.subjectCode = dr("subjectCodeNumber").ToString
                subjectRec.name = dr("name").ToString
                subjectRec.classGroup = dr("groupId").ToString
                subjectRec.credit = dr("credit")
                con.Close()
                Return subjectRec
            End If
        Catch
            MessageBox.Show("Error accessing subject record for subject with subjectCode :" & subjectCode)
            con.Close()
            Return subjectRec
        End Try
        Return subjectRec
    End Function
    Friend Function addSubject(newSubjectRec As SubjectRecord) As Boolean
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
            sql = "insert into subject(subjectCodeNumber,name,credit,groupId)"
            sql = sql & " values('" & newSubjectRec.subjectCode & "','" & newSubjectRec.name & "','" & newSubjectRec.credit & "','" & newSubjectRec.classGroup & "')"
            'insert into subject(subjectCodeNumber,name,credit,groupId) values('M1002','','Ahmad','1/9/2021 4:29:14 PM','P1_MERAH')
            MessageBox.Show(sql)
            Debug.WriteLine(sql)
            Dim cmd As New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception

            MessageBox.Show("Error adding new subject record. Message:" & ex.ToString)
            con.Close()
            Return False
        End Try
        Return True

    End Function
    Friend Function updateThisSubject(oldSubjectRec As SubjectRecord, newSubjectRec As SubjectRecord) As Boolean
        Try
            Dim sql As String
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()

            sql = "update subject set subjectCodeNumber ='" & newSubjectRec.subjectCode & "',"
            sql = sql & " name ='" & newSubjectRec.name & "',"
            sql = sql & " credit ='" & newSubjectRec.credit & "',"
            sql = sql & " groupId ='" & newSubjectRec.classGroup & "'"
            sql = sql & " where subjectCodeNumber ='" & oldSubjectRec.subjectCode & "'"
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
    Friend Function deleteSubjectRecord(subjectCode As String) As Boolean
        Try
            Dim sql As String
            con.ConnectionString = My.Resources.databaseConnectionPath & Application.StartupPath & My.Resources.databaseName
            con.Open()
            sql = "DELETE FROM subject WHERE (subjectCodeNumber = '" & subjectCode & "')"
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
