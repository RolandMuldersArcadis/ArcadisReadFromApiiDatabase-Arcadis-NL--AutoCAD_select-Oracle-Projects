Imports System.Data.SqlClient








Public Class mod_Retrieve_from_databases



    Shared Sub retrieveOpdrGever_and_ProjInfo(DocID As String, SQLServerAppX As String, SQLServerCatalogAppX As String, SQLServerConnectStringAppX As String)
        Dim whereclause As String = " where DisplayID like '" & DocID & "'"
        'Dim constring As String = "Data Source=" & SQLServerAppX & ";Initial Catalog=" & SQLServerCatalogAppX & ";Integrated Security=true;"
        Dim constring As String = SQLServerConnectStringAppX
        Using con As New SqlConnection(constring)
            Dim selectstring As String = "SELECT SAP_PROJECTNUMMER,SAP_PROJECTOMSCHRIJVING,SAP_OPDRACHTGEVER FROM vw_ADocReg_ProjInfo_DocID" & whereclause
            'Dim selectstring As String = "SELECT * FROM APII_wbs" & whereclause
            MsgBox(selectstring)
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        'DataGridView1.DataSource = dt



                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                ''Dim DataType() As String = myTableData.Rows(i).Item(1)
                                MsgBox(dt.Rows(i)(0) & "       " & dt.Rows(i)(1) & "       " & dt.Rows(i)(2))
                                'xdnode.Nodes.Add(dt.Rows(i)(0))
                            Next
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class
