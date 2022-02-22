Imports System.Text
Imports System.Net.Mime.MediaTypeNames

Module Module1
    Sub killProcess()
        Dim procName() As Process

        procName = Process.GetProcessesByName("normext")

        If procName.Count > 0 Then
            For Each norm In procName
                norm.Kill()
                norm.WaitForExit()
            Next
        End If
    End Sub

    Sub Main()
        killProcess()

        Console.WriteLine("Checking for update....")

        Dim myVersion As String = My.Computer.FileSystem.ReadAllText("\\savfils03\softwareupdate$\NormExtUpdater\version.txt", Encoding.UTF8)

        If IO.Directory.Exists("\\savfils03\softwareupdate$\NormExtUpdater\" + myVersion) = True Then
            Console.WriteLine("Updating Norming Extension....")

            My.Computer.FileSystem.CopyDirectory("\\savfils03\softwareupdate$\NormExtUpdater\" + myVersion, ".\", True)

        End If

        Console.WriteLine("Executing " + My.Application.Info.DirectoryPath + "\NormExt.exe .....")

        Process.Start(My.Application.Info.DirectoryPath + "\NormExt.exe")



    End Sub

End Module
