Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MsgBox("hoi1")
        CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "DocID", "")
        Dim CoordX As String = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "FormCoordinatesX")
        Dim CoordY As String = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "FormCoordinatesY")
        Dim CoordXInt As Integer = 0
        Dim CoordyInt As Integer = 0
        Try
            If CoordX <> "" Then
                CoordXInt = CInt(CoordX)
                If CoordY <> "" Then
                    CoordyInt = CInt(CoordY)
                    Me.Location = New Point(CoordXInt, CoordyInt)
                End If

            End If
        Catch ex As Exception
        End Try
        txt_sap_projectNummer.Text = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "ProjectNumberFilter")
        txt_sap_projectOmschrijving.Text = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "ProjectnameFilter")

        Check_SQL_Registry()
        Me.Txt_AppVersion.Text = "Version: " & Retrieve_ApplicationVersion()
        fillrecords()
        'Dim earlierused As String = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem")
        'If earlierused <> "" Then
        '    txt_earlierUsed.Text = earlierused
        'End If
        Dim recentused_list As List(Of String)

        recentused_list = func_recentUsed()
        For Each it In recentused_list
            lb_recentused.Items.Add(it)
        Next





    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gogogo()
    End Sub


    Sub gogogo()
        'Dim connectionString As String = "Data Source=FINTAN;Initial Catalog=APII;Integrated Security=true"
        'Dim connectionString As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true"
        Dim connectionString As String = get_SQLServerConnectStringApp()
        Dim conn As New SqlConnection(connectionString)
        conn.Open()
        '''// Create New DataAdapter
        Dim a As New SqlDataAdapter("SELECT SAP_OPDRACHTGEVER FROM vw_ADocReg_ProjInfoX order by SAP_OPDRACHTGEVER", conn)

        'myCmd = myConn.CreateCommand
        'myCmd.CommandText = "SELECT FirstName, LastName FROM Employees"


        ''' // Use DataAdapter to fill DataTable
        Dim dt As New DataTable()
        a.Fill(dt)
        ''ListBox1.DataSource = dt
        ''ListBox1.DisplayMember = "APII_opdrachtgever"


        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "SAP_OPDRACHTGEVER"



        conn.Close()
    End Sub
    Private Sub BindGrid()
        Txt_selectbox.Text = ""
        Dim whereclause As String = MakeSQLText1()


        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)
            'Dim selectstring As String = "SELECT * FROM APII_wbs" & whereclause
            Dim selectstring As String = "SELECT distinct SAP_ProjectID, SAP_ProjectnummerX,SAP_ProjectOmschrijving  FROM vw_ADocReg_ProjInfoX" & whereclause & " order by SAP_ProjectnummerX"
            Txt_selectbox.Text = selectstring
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DataGridView1.DataSource = dt
                    End Using



                End Using
            End Using
        End Using
    End Sub
    Private Sub BindGrid_BIM360()
        Txt_selectbox.Text = ""
        Dim whereclause As String = MakeSQLText1()


        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)
            'Dim selectstring As String = "SELECT * FROM APII_wbs" & whereclause
            Dim selectstring As String = "SELECT distinct SAP_ProjectID, SAP_ProjectnummerX,SAP_ProjectOmschrijving  FROM vw_ADocReg_ProjInfoX" & whereclause & " order by SAP_ProjectnummerX"
            Txt_selectbox.Text = selectstring
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DataGridView1.DataSource = dt
                    End Using



                End Using
            End Using
        End Using
    End Sub
    Function MakeSQLText1() As String
        Dim whereclause As String = ""
        Dim wherex As New List(Of String)

        Dim filter As Boolean = True
        If Me.txt_sap_projectNummer.Text <> "" Then
            wherex.Add("SAP_projectnummer Like '%" & Me.txt_sap_projectNummer.Text & "%'")
            filter = True
        End If
        If Me.txt_sap_projectOmschrijving.Text <> "" Then
            wherex.Add("SAP_projectomschrijving Like '%" & Me.txt_sap_projectOmschrijving.Text & "%'")
            filter = True
        End If
        'If Me.txt_sap_projectNummer.Text <> "" Then
        wherex.Add("SAP_projectnummer Like '" & "%'")
        filter = True
        'End If

        If filter = True Then
            For Each itx As String In wherex
                If whereclause = "" Then
                    whereclause = whereclause & " " & itx
                Else
                    whereclause = whereclause & " and " & itx
                End If
            Next

            whereclause = " where SAP_MANDT=400 and " & whereclause
        End If
        MakeSQLText1 = whereclause
    End Function

    Function MakeSQLText2() As String
        Dim whereclause As String = ""
        Dim wherex As New List(Of String)

        Dim filter As Boolean = True
        If Me.txt_sap_projectNummer.Text <> "" Then
            wherex.Add("SAP_projectnummer Like '%" & Me.txt_sap_projectNummer.Text & "%'")
            filter = True
        End If
        If Me.txt_sap_projectOmschrijving.Text <> "" Then
            wherex.Add("SAP_projectomschrijving Like '%" & Me.txt_sap_projectOmschrijving.Text & "%'")
            filter = True
        End If
        'If Me.txt_sap_projectNummer.Text <> "" Then
        wherex.Add("SAP_projectnummer Like '" & "%'")
        filter = True
        'End If

        If filter = True Then
            For Each itx As String In wherex
                If whereclause = "" Then
                    whereclause = whereclause & " " & itx
                Else
                    whereclause = whereclause & " and " & itx
                End If
            Next

            whereclause = " where " & whereclause
        End If
        MakeSQLText2 = whereclause
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "DocID", "")

        CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "ProjectNumberFilter", txt_sap_projectNummer.Text)
        CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "ProjectnameFilter", txt_sap_projectOmschrijving.Text)

        BindGrid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'BindGridwbs(130)
    End Sub
    Private Sub BindGridwbs(projID As Integer)
        'Dim SQLString As String = "SELECT SAP_WBSID,substring (SAP_WBSELEMENT,2,20) as SAP_WBSELEMENTX,SAP_OPDRACHTGEVER,SAP_WBS_OMSCHRIJVING,SAP_VEANTWOORDELIJKE,* FROM SAP_wbs" & " where SAP_MANDT=400 and SAP_PROJECTID="
        Dim SQLString As String = "SELECT distinct SAP_WBSID,SAP_WBSELEMENT,SAP_OPDRACHTGEVER,SAP_WBS_OMSCHRIJVING,SAP_VEANTWOORDELIJKE FROM vw_ADocReg_ProjInfoX" & " where SAP_PROJECTID="
        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand(SQLString & projID, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DataGridView2.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub BindGridwbsBIM360()
        Dim whereclause As String = MakeSQLText2()
        whereclause = whereclause & "order by SAP_PROJECTNUMMER"
        'Dim SQLString As String = "SELECT SAP_WBSID,substring (SAP_WBSELEMENT,2,20) as SAP_WBSELEMENTX,SAP_OPDRACHTGEVER,SAP_WBS_OMSCHRIJVING,SAP_VEANTWOORDELIJKE,* FROM SAP_wbs" & " where SAP_MANDT=400 and SAP_PROJECTID="
        Dim SQLString As String = "SELECT distinct SAP_WBSID,SAP_PROJECTNUMMER,SAP_PROJECTOMSCHRIJVING,SAP_OPDRACHTGEVER FROM vw_ADocReg_BIM360_Join_ProjectinfoDOT_READ_ZZZZZZZZ" & whereclause
        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true"
        Dim constring As String = SQLServerConnectStringApp
        'MsgBox(SQLString)
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand(SQLString, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        Try
                            sda.Fill(dt)
                            DataGridView5.DataSource = dt
                            Me.DataGridView5.Columns(0).Width = 2
                            Dim dgv_width As Integer = Me.DataGridView5.Width
                            Dim column_width As Integer = dgv_width / 3.5
                            Me.DataGridView5.Columns(0).Width = 2
                            Me.DataGridView5.Columns(1).Width = CInt(column_width) - 10
                            Me.DataGridView5.Columns(3).Width = CInt(column_width) - 10
                            Me.DataGridView5.Columns(2).Width = dgv_width - (Me.DataGridView5.Columns(0).Width + Me.DataGridView5.Columns(1).Width + Me.DataGridView5.Columns(3).Width)

                        Catch ex As exception
                        End Try
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' MsgBox("voorbeeld insert item in ")
        'INSERT INTO RolandTest2 (Filename,apiiwbsid) OUTPUT 'M' + RIGHT('0000000000000' + CAST(INSERTED.ID AS varchar(5)) , 8)  VALUES ('testx',1)
        If Me.txt_apiiwbsId.Text = "" Or Me.txt_apiiwbsId.Text = "0" Then
            MsgBox("No value for filename / No Wbs selected")
        Else
            Dim cont As String = Me.txt_apiiwbsId.Text
            Dim sap_n As String = Trim(Me.Txt_api_Projnumber.Text)
            Dim sap_name As String = Trim(Me.Txt_Projectname.Text)
            Dim earlierusedstring As String = cont & " ____ " & sap_n & "----" & sap_name
            sub_recentUsed(earlierusedstring)

            BindGridInsert()
            closeForm()
        End If


        'Me.txt_apiiwbsId.Text = contents.ToString
        ' Me.Txt_api_Projnumber.Text = SAP_Number.ToString
        ' Dim earlierusedstring As String = contents & " ____ " & SAP_Number.ToString
        'CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem", earlierusedstring)
        'sub_recentUsed(earlierusedstring)
        ' Me.txt_earlierUsed.Text = earlierusedstring
        ' Me.txt_earlierUsed.Refresh()




    End Sub




    Private Sub BindGridInsert()

        If Me.txt_apiiwbsId.Text <> "" Then
            'If Me.Txt_filename.Text <> "" Then
            ' https://social.msdn.microsoft.com/Forums/en-US/792a31da-7033-4a90-8df5-35d260d204af/how-to-get-id-number-before-insert-data-use-vbnet-and-sql-server-?forum=vbgeneral



            Dim sqltext As String = ""
            'Dim constring As String = "Data Source=SQLVSRV01;Initial Catalog=SYSINFO;User Id=edit_sysinfo;Password=jenever;"
            'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true;"
            Dim constring As String = SQLServerConnectStringApp
            Using con As New SqlConnection(constring)

                'sqltext = "Exec SP_APII_Extra_InsertFilename 'Calgary',1"
                'sqltext = "SP_APII_Extra_InsertFilename"
                sqltext = "sp_ADocReg_InsertFilename"

                Using cmd As New SqlCommand(sqltext, con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("TypeCharacter", "M")
                    cmd.Parameters.AddWithValue("filename", "----")
                    'cmd.Parameters.AddWithValue("ApiiWbsID", 1)
                    cmd.Parameters.AddWithValue("ApiiWbsID", Convert.ToInt32(Me.txt_apiiwbsId.Text))
                    cmd.Parameters.AddWithValue("Username", Environment.UserName)
                    cmd.Parameters.AddWithValue("Datetime", DateTimeSpecial)



                    Using sda As New SqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            DataGridView3.DataSource = dt
                        End Using
                    End Using
                End Using
            End Using
        Else
                MsgBox("No value for filename / No Wbs selected")
            End If
        'Else
        'MsgBox("No value for WbsID / No Wbs selected")
        'End If
    End Sub
    Function DateTimeSpecial() As String
        Dim nowx As DateTime
        nowx = Now()
        DateTimeSpecial = ""
        DateTimeSpecial = nowx.Year.ToString & "-" & nn(nowx.Month.ToString) & "-" & nn(nowx.Day.ToString) & "_" & nn(nowx.Hour.ToString) & ":" & nn(nowx.Minute.ToString) & ":" & nn(nowx.Second.ToString)
    End Function

    Function nn(x As String) As String
        nn = "00" & x
        nn = nn.Substring(nn.Length - 2)
    End Function

    'Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    '    ' MsgBox("hhhh")
    '    Dim projectID As Integer = 1

    '    Dim i As Integer = DataGridView1.CurrentRow.Index
    '    'Dim contents As String = DataGridView1.Item(0, i).Value
    '    Dim contents As Integer = DataGridView1.Item("apii_projectID", i).Value
    '    '.MsgBox(i.ToString())
    '    'MsgBox(contents.ToString())
    '    BindGridwbs(contents)
    'End Sub

    'Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
    '    'MsgBox("hhhh")
    '    Dim projectID As Integer = 1

    '    Dim i As Integer = DataGridView2.CurrentRow.Index
    '    'Dim contents As String = DataGridView2.Item(0, i).Value
    '    Dim contents As Integer = DataGridView2.Item("apii_wbsID", i).Value
    '    '.MsgBox(i.ToString())
    '    'MsgBox(contents.ToString())
    '    BindGridwbs(contents)
    '    Me.txt_apiiwbsId.Text = contents.ToString



    'End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        retrieve_projectID()

    End Sub
    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        retrieve_projectID()
    End Sub
    Sub retrieve_projectID()
        ' MsgBox("hhhh")
        Dim projectID As Integer = 1
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            'Dim contents As String = DataGridView1.Item(0, i).Value
            Dim contents As Integer = DataGridView1.Item("SAP_projectID", i).Value
            '.MsgBox(i.ToString())
            'MsgBox(contents.ToString())
            BindGridwbs(contents)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        retrieveWbsID(DataGridView2)
    End Sub
    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        retrieveWbsID(DataGridView5)
    End Sub
    Sub retrieveWbsID(DGV As DataGridView)
        'MsgBox("hhhh")
        Dim projectID As Integer = 1

        Dim i As Integer = DGV.CurrentRow.Index
        'Dim contents As String = DataGridView2.Item(0, i).Value
        Me.txt_apiiwbsId.Text = ""
        Try
            Dim contents As Integer = DGV.Item("SAP_wbsID", i).Value

            Dim SAP_Number As String = DGV.Item("SAP_PROJECTNUMMER", i).Value
            Dim SAP_ProjectName As String = DGV.Item("SAP_PROJECTOMSCHRIJVING", i).Value
            '.MsgBox(i.ToString())
            'MsgBox(contents.ToString())

            Me.txt_apiiwbsId.Text = contents.ToString
            Me.Txt_api_Projnumber.Text = SAP_Number.ToString
            Me.Txt_Projectname.Text = SAP_ProjectName
            ' Dim earlierusedstring As String = contents & " ____ " & SAP_Number.ToString
            'CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem", earlierusedstring)
            'sub_recentUsed(earlierusedstring)
            ' Me.txt_earlierUsed.Text = earlierusedstring
            ' Me.txt_earlierUsed.Refresh()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub DataGridView2_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView2.DataBindingComplete
        retrieveWbsID(DataGridView2)
    End Sub

    Private Sub BTN_addversion_Click(sender As Object, e As EventArgs) Handles BTN_addversion.Click
        'retrieve docid from textbox
        Dim DocID As String = txt_DocID.Text
        Dim Version As String = txt_version.Text
        Try
            If DocID <> "" Then
                If Version <> "" Then
                    Dim iversion As Integer
                    iversion = CInt(Version)
                    BindGridInsertVersion(DocID, iversion)
                    txt_version.Text = Version + 1
                Else
                    MsgBox("No value in counter_box")
                End If
            End If
        Catch ex As exception
        End Try
    End Sub


    Private Sub BindGridInsertVersion(DocId As String, Version As Integer)



        Dim sqltext As String = ""
        'Dim constring As String = "Data Source=SQLVSRV01;Initial Catalog=SYSINFO;User Id=edit_sysinfo;Password=jenever;"
        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true;"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)

            'sqltext = "Exec SP_APII_Extra_InsertFilename 'Calgary',1"
            'sqltext = "SP_APII_Extra_VersionsFilename"
            sqltext = "sp_ADocReg_VersionsFilename"

            Using cmd As New SqlCommand(sqltext, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("DocID", DocId)
                cmd.Parameters.AddWithValue("Docversion", Version)
                cmd.Parameters.AddWithValue("Username", Environment.UserName)
                cmd.Parameters.AddWithValue("Datetime", DateTimeSpecial)
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DataGridView4.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView3_DataSourceChanged(sender As Object, e As EventArgs) Handles DataGridView3.DataSourceChanged
        retrieveDocID()
    End Sub


    Sub retrieveDocID()
        'MsgBox("hhhh")
        Dim projectID As Integer = 1

        Dim i As Integer = DataGridView3.CurrentRow.Index
        'Dim contents As String = DataGridView2.Item(0, i).Value
        Dim contents As String = DataGridView3.Item("DisplayID", i).Value
        '.MsgBox(i.ToString())
        'MsgBox(contents.ToString())

        Me.txt_DocID.Text = contents.ToString
        CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "DocID", contents.ToString)
        CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "DocID_ProjNumber", Me.Txt_api_Projnumber.Text)

        ''call ReadUsrRegistry("SOFTWARE\Arcadis\Cadapp", "CadappSyncFailed" "yes")

        DataGridView4.DataSource = ""
        ' DataGridView4.Rows.Clear()
        ' DataGridView4.Refresh()



        txt_version.Text = "1"

    End Sub





    Private Sub BTN_retrieveIDs_Click(sender As Object, e As EventArgs)
        ' retrieveIDs()
    End Sub



    Private Sub BTN_open_DOCIDs_Click(sender As Object, e As EventArgs) Handles BTN_open_DOCIDs.Click
        Dim Form2x As New Form2
        Form2x.Show()
        'Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        closeForm()
    End Sub



    Private Sub txt_sap_projectOmschrijving_TextChanged(sender As Object, e As EventArgs) Handles txt_sap_projectOmschrijving.TextChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        roltestToListbox()
    End Sub

    Sub roltestToListbox()
        Txt_selectbox.Text = ""
        Dim whereclause As String = MakeSQLText1()


        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)
            'Dim selectstring As String = "SELECT * FROM APII_wbs" & whereclause
            Dim selectstring As String = "SELECT distinct SAP_ProjectID, SAP_ProjectnummerX,SAP_ProjectOmschrijving  FROM vw_ADocReg_ProjInfoX" & whereclause
            Txt_selectbox.Text = selectstring
            'Using cmd As New SqlCommand(selectstring, con)
            'cmd.CommandType = CommandType.Text
            Using sda As New SqlDataAdapter("SELECT distinct SAP_ProjectID, SAP_ProjectnummerX,SAP_ProjectOmschrijving  FROM vw_ADocReg_ProjInfoX", con)
                'Using dt As New DataTable()

                Dim ds As DataSet = New DataSet()
                sda.Fill(ds)
                Dim dt As DataTable = ds.Tables(0)
                'ListBox3.DisplayMember = dt.Columns(0).ColumnName
                'ListBox3.ValueMember = dt.Columns(1).ColumnName
                'ListBox3.DataSource = dt

                ' ListBox3.Refresh()


                ComboBox2.DisplayMember = dt.Columns(0).ColumnName
                ComboBox2.ValueMember = dt.Columns(1).ColumnName
                ComboBox2.DataSource = dt

                ComboBox2.Refresh()





                'sda.Fill(dt)
                'ListBox1.DataSource = dt
                '   ListBox1.DisplayMember = "SAP_PROJECTNUMMERX"
                'End Using



            End Using
        End Using
        'End Using

    End Sub

    Sub closeForm()
        Dim Docid As String = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "DocID")
        If Docid = "" Then
            MsgBox("No DocID created yet !! please use the right buttons")
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' MsgBox("voorbeeld insert item in ")
        'INSERT INTO RolandTest2 (Filename,apiiwbsid) OUTPUT 'M' + RIGHT('0000000000000' + CAST(INSERTED.ID AS varchar(5)) , 8)  VALUES ('testx',1)

        If Me.txt_apiiwbsId.Text = "" Or Me.txt_apiiwbsId.Text = "0" Then
            MsgBox("No value for filename / No Wbs selected")
        Else
            BindGridInsert()
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Dim xx As TreeNode
        'MsgBox(e.Node.Name)
        'MsgBox("Tag=" & e.Node.Tag)
        ' MsgBox("Text=" & e.Node.Text)
        If e.Node.Nodes.Count = 0 Then
            retrieveOpdrGeversX(e.Node, e.Node.Tag)
            ' "Select SAP_PROJECTNUMMERX from vw_ADocReg_ProjInfoX where SAP_PROJECTNUMMERXX='" & e.Node.Text & "'"
            retrieveWBSsen(e.Node, e.Node.Tag)
        End If
    End Sub



    Private Sub BTN_RetrieveTreeview_Click(sender As Object, e As EventArgs) Handles BTN_RetrieveTreeview.Click
        Dim nodx As TreeNode
        nodx = createtreebase()

        createtreeX(nodx)
        retrieveOpdrGevers(nodx)

    End Sub
    Function createtreebase() As TreeNode
        TreeView1.BeginUpdate()
        createtreebase = TreeView1.Nodes.Add("Projects")
        createtreebase.Tag = "Projects"
        TreeView1.EndUpdate()
    End Function

    Sub createtreeX(xdnode As TreeNode)

        Dim xlist As New List(Of String)
        'xlist.Add("1")

        'xlist.Add("2")
        'xlist.Add("3")
        'xlist.Add("4")

        For Each it As String In xlist
            Dim NewNode As TreeNode = xdnode.Nodes.Add(it)
            NewNode.Tag = it

        Next




    End Sub

    Sub retrieveOpdrGevers(xdnode As TreeNode)
        Dim whereclause As String = " order by SAP_PROJECTNUMMERXX"
        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true;"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)
            Dim selectstring As String = "SELECT SAP_PROJECTNUMMERXX FROM vw_ADocReg_ProjNrs_x6" & whereclause
            'Dim selectstring As String = "SELECT * FROM APII_wbs" & whereclause
            '''MsgBox(selectstring)
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        'DataGridView1.DataSource = dt
                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                ''Dim DataType() As String = myTableData.Rows(i).Item(1)
                                'ListBox2.Items.Add(dt.Rows(i)(0))
                                Dim NewNode As TreeNode = xdnode.Nodes.Add(dt.Rows(i)(0))
                                NewNode.Tag = dt.Rows(i)(0)
                            Next
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub


    Sub retrieveOpdrGeversX(xdnode As TreeNode, P6Nummer As String)
        Dim whereclause As String = " order by SAP_PROJECTNUMMERX"
        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true;"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)
            Dim selectstring As String = "Select distinct SAP_PROJECTNUMMERX,SAP_PROJECTOMSCHRIJVING from vw_ADocReg_ProjInfoX where SAP_PROJECTNUMMERXX='" & P6Nummer & "'" & " order by SAP_PROJECTNUMMERX"
            'Dim selectstring As String = "SELECT * FROM APII_wbs" & whereclause
            '''MsgBox(selectstring)
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        'DataGridView1.DataSource = dt



                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                ''Dim DataType() As String = myTableData.Rows(i).Item(1)
                                'ListBox2.Items.Add(dt.Rows(i)(0))
                                Dim NewNode As TreeNode = xdnode.Nodes.Add(dt.Rows(i)(0))
                                NewNode.Tag = dt.Rows(i)(0)
                                NewNode.Text = dt.Rows(i)(0) & "   " & dt.Rows(i)(1)
                            Next
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Sub retrieveWBSsen(xdnode As TreeNode, P12Nummer As String)
        Dim whereclause As String = " order by SAP_PROJECTNUMMERX"
        'Dim constring As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true;"
        Dim constring As String = SQLServerConnectStringApp
        Using con As New SqlConnection(constring)
            Dim selectstring As String = "Select distinct SAP_WBSELEMENT,SAP_WBS_OMSCHRIJVING from vw_ADocReg_ProjInfoX where SAP_PROJECTNUMMERX='" & P12Nummer & "'" & " order by SAP_WBSELEMENT"
            'Dim selectstring As String = "SELECT * FROM APII_wbs" & whereclause
            '''MsgBox(selectstring)
            Using cmd As New SqlCommand(selectstring, con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        'DataGridView1.DataSource = dt



                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                ''Dim DataType() As String = myTableData.Rows(i).Item(1)
                                'ListBox2.Items.Add(dt.Rows(i)(0))
                                Dim NewNode As TreeNode = xdnode.Nodes.Add(dt.Rows(i)(0))
                                NewNode.Tag = dt.Rows(i)(0)
                                NewNode.Text = dt.Rows(i)(0) & "   " & dt.Rows(i)(1)
                            Next
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub BTN_RetrieveProjectsBIM360_Click(sender As Object, e As EventArgs) Handles BTN_RetrieveProjectsBIM360.Click

        FillRecords


    End Sub
    Sub fillrecords()
        Try
            CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "DocID", "")
            CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "DocID_ProjNumber", "")

            CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "ProjectNumberFilter", txt_sap_projectNummer.Text)
            CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "ProjectnameFilter", txt_sap_projectOmschrijving.Text)

            BindGridwbsBIM360()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub Button8_Click(sender As Object, e As EventArgs)
    '    If Me.txt_earlierUsed.Text <> "" Then
    '        Dim earlierused As String = Me.txt_earlierUsed.Text
    '        If InStr(earlierused, " ____ ") Then
    '            Dim erlierusedarr() As String = Split(earlierused, " ____ ")
    '            Dim contents As String = erlierusedarr(0)
    '            Dim SAP_Number As String = erlierusedarr(1)

    '            Me.txt_apiiwbsId.Text = contents.ToString
    '            Me.Txt_api_Projnumber.Text = SAP_Number.ToString
    '        End If
    '    End If
    'End Sub

    Function func_recentUsed() As List(Of String)
        Dim usedlist As New List(Of String)
        Dim i As Integer = 0
        While i < 6
            Dim earlierused As String = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem" & i)
            If earlierused <> "" Then
                Dim temp As String = Mid(earlierused, InStr(earlierused, " ____ ") + 6)
                usedlist.Add(UCase(temp & "                                           #*#*#" & earlierused))   'trick to have only projectnumber in view
            End If
            i = i + 1
        End While

        'CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem", earlierusedstring)
        'Dim earlierused As String = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem")
        'If earlierused <> "" Then
        '    txt_earlierUsed.Text = earlierused
        'End If
        Return usedlist
    End Function


    Sub sub_recentUsed(lu As String)
        lu = Trim(UCase(lu))
        Dim usedlist As New List(Of String)
        Dim i As Integer = 0
        While i < 6
            Dim earlierused As String = ReadUsrRegistry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem" & i)
            If earlierused <> "" Then
                usedlist.Add(UCase(Trim(earlierused)))
            End If
            i = i + 1
        End While

        usedlist.Remove(lu)
        usedlist.Insert(0, lu)

        Dim ii As Integer = 0
        For Each it In usedlist
            CreateUsrRegKey("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SelectedItem" & ii, it)
            ii = ii + 1
        Next







    End Sub

    Private Sub lb_recentused_Click(sender As Object, e As EventArgs) Handles lb_recentused.Click
        Dim Selected As String = lb_recentused.Text
        'Me.txt_earlierUsed.Text = Selected


        If InStr(Selected, "#*#*#") Then
            Dim temp As String = Mid(Selected, InStr(Selected, "#*#*#") + 5)

            Dim erlierusedarr() As String = Split(temp, " ____ ")
            Dim contents As String = erlierusedarr(0)
            Dim SAP_Numberx As String = erlierusedarr(1)
            Dim SAP_Number As String = ""
            Dim SAP_name As String = ""
            If InStr(SAP_Numberx, "----") Then
                SAP_Number = Mid(SAP_Numberx, 1, InStr(SAP_Numberx, "----") - 1)
                SAP_name = Trim(Mid(SAP_Numberx, InStr(SAP_Numberx, "----") + 4))
            Else
                SAP_Number = Trim(SAP_Numberx)
            End If

            Me.txt_apiiwbsId.Text = contents.ToString
            Me.Txt_api_Projnumber.Text = SAP_Number.ToString
            Me.Txt_Projectname.Text = SAP_name

        End If


    End Sub
End Class
