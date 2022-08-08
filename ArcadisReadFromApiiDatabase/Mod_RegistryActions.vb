Imports Microsoft.Win32

Module Mod_RegistryActions
    Sub CreateUsrRegKey(Key As String, name As String, value As String)
        'call ReadUsrRegistry("SOFTWARE\Arcadis\Cadapp", "CadappSyncFailed" "yes")

        Try
            Dim regKey As RegistryKey

            Dim keys() As String = Split(Key, "\")
            Dim strKey As String = "SOFTWARE"

            regKey = Registry.CurrentUser.OpenSubKey(strKey, True)

            For i As Integer = 1 To keys.Length - 1   'be aware counting from 1 , skipping the software part
                regKey.CreateSubKey(keys(i))
                strKey = strKey & "\" & keys(i)
                regKey = Registry.CurrentUser.OpenSubKey(strKey, True)
            Next
            regKey.SetValue(name, value)
            regKey.Close()
        Catch ex As Exception
        End Try
    End Sub

    Sub CreateUsrRegKeyXXX(ArcadisProgname As String, name As String, value As String)
        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", True)
        regKey.CreateSubKey("Arcadis")
        regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Arcadis", True)
        regKey.CreateSubKey(ArcadisProgname)
        regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Arcadis\" & ArcadisProgname, True)
        regKey.SetValue(name, value)
        regKey.Close()
    End Sub
    Function ReadUsrRegistry(Rkey As String, Rval As String) As String
        'call ReadUsrRegistry("SOFTWARE\Arcadis\Cadapp", "CadappSyncFailed")
        Dim KeyValue As String = ""
        Dim baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
        Dim regkey = baseKey.OpenSubKey(Rkey)
        If regkey IsNot Nothing Then KeyValue = CStr(regkey.GetValue(Rval))

        Return KeyValue
    End Function
    Function Read_LM_Registry(Rkey As String, Rval As String) As String
        'MsgBox("hoi23")
        Dim KeyValue As String = ""
        Dim baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
        Dim regkey = baseKey.OpenSubKey(Rkey)
        If regkey IsNot Nothing Then KeyValue = CStr(regkey.GetValue(Rval))

        Return KeyValue
    End Function
End Module
