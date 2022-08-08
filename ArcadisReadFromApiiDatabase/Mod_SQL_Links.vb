Module Mod_SQL_Links
    Public SQLServerApp As String = Mod_RegistryActions.Read_LM_Registry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SQLServerApp")
    Public SQLServerSAP As String = Mod_RegistryActions.Read_LM_Registry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SQLServerSAP")
    Public SQLServerCatalogApp As String = Mod_RegistryActions.Read_LM_Registry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SQLServerCatalogApp")
    Public SQLServerCatalogSAP As String = Mod_RegistryActions.Read_LM_Registry("SOFTWARE\Arcadis\Autodesk\BIM360\DocsRegistration", "SQLServerCatalogSAP")
    Public SQLServerConnectStringApp As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";User Id=ADocRegUser;Password=69Jk25Yq"
    Public SQLServerConnectStringSAP As String = "Data Source=" & SQLServerSAP & ";Initial Catalog=" & SQLServerCatalogSAP & ";User Id=ADocRegUser;Password=69Jk25Yq"
    ' Public SQLServerConnectStringApp As String = "Data Source=" & SQLServerApp & ";Initial Catalog=" & SQLServerCatalogApp & ";Integrated Security=true"
    ' Public SQLServerConnectStringSAP As String = "Data Source=" & SQLServerSAP & ";Initial Catalog=" & SQLServerCatalogSAP & ";Integrated Security=true"









    Public Function get_SQLServerConnectStringApp() As String
        Return SQLServerConnectStringApp
    End Function
    Public Function get_SQLServerConnectStringSAP() As String
        Return SQLServerConnectStringSAP
    End Function
    Public Function get_SQLServerApp() As String
        Return SQLServerApp
    End Function
    Public Function get_SQLServerSAP() As String
        Return SQLServerSAP
    End Function

    Public Function get_SQLServerCatalogApp() As String
        Return SQLServerCatalogApp
    End Function
    Public Function get_SQLServerCatalogSAP() As String
        Return SQLServerCatalogSAP
    End Function
    Public Sub Check_SQL_Registry()
        If (SQLServerApp = "") Or (SQLServerSAP = "") Or (SQLServerCatalogApp = "") Or (SQLServerCatalogSAP = "") Then
            MsgBox("No SQLserver found in Registry !!, please exit now !!")
        End If

    End Sub

    Public Function Retrieve_ApplicationVersion() As String
        Dim fileName$ = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim fvi As FileVersionInfo = FileVersionInfo.GetVersionInfo(fileName)
        Return fvi.FileVersion.ToString

    End Function

End Module
