Imports System.Data.SqlClient
Imports Microsoft.Win32

Public Class Form2
    Public Shared SQLServerApp As String = ""
    Public Shared SQLServerSAP As String = ""
    Public Shared SQLServerCatalogApp As String = ""
    Public Shared SQLServerCatalogSAP As String = ""
    Public Shared SQLServerConnectStringApp As String = ""
    Public Shared SQLServerConnectStringSAP As String = ""



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub



    Private Sub BTN_retrieveIDs_Click(sender As Object, e As EventArgs) Handles BTN_retrieveIDs.Click
        retrieveIDs()
        'mod_Retrieve_from_databases.retrieveOpdrGever_and_ProjInfo()
    End Sub
    Sub retrieveIDs()



        Dim selectstring As String = ""
        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true;"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)

            'sqltext = "Exec SP_APII_Extra_InsertFilename 'Calgary',1"
            'sqltext = "SP_APII_Extra_VersionsFilename"
            selectstring = "select * from ADocReg_DocId order by DisplayID desc"



            MsgBox(selectstring)
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DataGridView5.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub



    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        retrieveDocID(SQLServerApp, SQLServerSAP)
        mod_Retrieve_from_databases.retrieveOpdrGever_and_ProjInfo(Me.TextBox2.Text, SQLServerApp, SQLServerCatalogApp, SQLServerConnectStringApp)
    End Sub

    Private Sub DataGridView5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellContentClick

    End Sub





    Sub retrieveDocID(sqlserverAPP As String, sqlserverSAP As String)
        'MsgBox("hhhh")
        Dim projectID As Integer = 1

        Dim i As Integer = DataGridView5.CurrentRow.Index
        'Dim contents As String = DataGridView2.Item(0, i).Value
        Dim contents As String = DataGridView5.Item("ApiiwbsID", i).Value
        Dim contentsDID As String = DataGridView5.Item("DisplayID", i).Value
        '.MsgBox(i.ToString())
        'MsgBox(contents.ToString())D:\DEVELOP\MydocsVS\Visual Studio 2015\Projects\ArcadisReadFromApiiDatabase\ArcadisReadFromApiiDatabase\Form1.vb

        Me.TextBox1.Text = contents.ToString
        Me.TextBox2.Text = contentsDID.ToString

        Dim sql As String = ""
        sql = "select * from SAP_WBS where SAP_MANDT=400 and SAP_WBSID = " & contents
        retrieveInfo(DataGridView1, sql, SQLServerCatalogSAP, sqlserverSAP, SQLServerConnectStringSAP)



        sql = "select * from ADocReg_Versions where docid like '" & contentsDID.ToString & "'"
        retrieveInfo(DataGridView2, sql, SQLServerCatalogApp, sqlserverAPP, SQLServerConnectStringApp)


    End Sub





    Sub retrieveInfo(dgv As DataGridView, sql As String, Catalog As String, SQLSERV As String, Connectstring As String)
        Dim selectstring As String = ""
        'Dim constring As String = "Data Source=" & SQLSERV & ";Initial Catalog=" & Catalog & ";Integrated Security=True;"
        Dim constring As String = Connectstring
        Using con As New SqlConnection(constring)

            'sqltext = "Exec SP_APII_Extra_InsertFilename 'Calgary',1"
            'sqltext = "SP_APII_Extra_VersionsFilename"
            selectstring = sql

            'MsgBox("hoi")

            MsgBox(selectstring)
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        dgv.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


End Class