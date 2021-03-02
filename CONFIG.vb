Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports MadMilkman.Ini
Public Class CONFIG
    Dim Filename As String = "configuracoes.ini"
    Dim SavePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, Filename) 'combines the saveDirectory and the filename to get a fully qualified path.

    Public Sub criarArquivoConfiguracao()

        If System.IO.File.Exists(SavePath) = False Then
            'The file exists

            Dim file As New IniFile()

            Dim section As IniSection = file.Sections.Add("Config")

            section.Keys.Add("token", "")
            section.Keys.Add("intervaloExecucaoAutomatica", 60000)

            file.Save(SavePath)

        End If

    End Sub

    Function valorSalvoAtual(chave As String) As String

        Dim options As New IniOptions()
        Dim iniFile As New IniFile(options)

        ' Load file from path.
        iniFile.Load(SavePath)

        ' Load file from stream.
        Using stream As Stream = File.OpenRead(SavePath)
            iniFile.Load(stream)
        End Using

        ' Read file's content.
        For Each section In iniFile.Sections
            For Each key In section.Keys
                If key.Name = chave Then
                    Return key.Value
                End If
            Next
        Next
        Return ""
    End Function


    Public Sub alterarValorSalvo(chave As String, valor As String)

        Dim options As New IniOptions()
        Dim iniFile As New IniFile(options)

        iniFile.Load(SavePath)

        For Each section In iniFile.Sections
            For Each key In section.Keys
                If key.Name = chave Then
                    key.Value = valor
                    iniFile.Save(SavePath)
                    Exit Sub
                End If
            Next
        Next

    End Sub


End Class
