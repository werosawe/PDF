Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System
Imports System.IO

Public Class ListPDF

    Public Sub New()

    End Sub

    Public Function Fileinfo_To_DataTable(ByVal directory As String) As DataTable
        Try
            'Create a new data table
            Dim dt As DataTable = New DataTable

            'Add the following columns:
            '                          Name
            '                          Length
            '                          Last Write Time
            ''                         Creation Time
            dt.Columns.AddRange({New DataColumn("Expediente O.P"), _
                                 New DataColumn("Size MB"), _
                                 New DataColumn("Last Write Time"), _
                                 New DataColumn("Num. Páginas")})

            'Loop through each file in the directory
            For Each file As System.IO.FileInfo In New System.IO.DirectoryInfo(directory).GetFiles

                If file.Extension.ToUpper = ".PDF" Then
                    'Create a new row
                    Dim dr As DataRow = dt.NewRow

                    'Set the data
                    dr(0) = file.Name
                    dr(1) = (file.Length / 1024 / 1024).ToString("N2")

                    dr(2) = file.LastWriteTime
                    dr(3) = Num_Paginas(file.FullName)

                    'Add the row to the data table
                    dt.Rows.Add(dr)                    

                End If                
            Next

            'Return the data table
            Return dt

        Catch ex As Exception
            Console.WriteLine(ex.ToString)

            'Return nothing if something fails
            Return Nothing
        End Try
    End Function

    Private Function Num_Paginas(ByVal pdfFileName As String) As Integer

        Dim reader As New PdfReader(pdfFileName)
        Return reader.NumberOfPages

    End Function

End Class
