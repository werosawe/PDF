
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
''Imports iTextSharp.xtra.iTextSharp.text.pdf.pdfcleanup
Imports iTextSharp.text.pdf.parser

Imports Dotnet = System.Drawing.Image


Public Class ReadPDF

    Private PaginasCortar As Integer = 1000
    Public tipoEncoder As String = ""

    Public Sub New()

    End Sub

    Public Function GetTextFromPDF(PdfFileName As String) As String
        Dim oReader As New iTextSharp.text.pdf.PdfReader(PdfFileName)

        Dim sOut = ""

        For i = 1 To oReader.NumberOfPages
            Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy

            sOut = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)

            Extraer_DNI(sOut)

        Next

        Return sOut
    End Function

    Private Sub Extraer_DNI(Cadena As String)

        Dim Letra As String = ""
        Dim DNI As String = ""
        For i = 1 To Cadena.Length - 1

            Letra = Cadena.Substring(i, 1)

            If "1234567890".Contains(Letra) Then
                DNI &= Letra
                If DNI.Length = 8 Then
                    Escribir_DNI_En_TXT(DNI)
                    DNI = ""
                End If
            Else
                DNI = ""
            End If

        Next

    End Sub

    Private Sub Escribir_DNI_En_TXT(ByVal DNI As String)
        Dim Path = "C:\DNI.txt"
        Using sw As StreamWriter = File.AppendText(Path)
            sw.WriteLine(DNI)
        End Using

    End Sub

    Public Sub Split_Rango_Paginas(ByVal Ruta As String, ByVal pdfFileName As String, nPagIni As Integer, nPagFin As Integer)

        Using reader As New PdfReader(Ruta + pdfFileName)

            Dim filename As String = pdfFileName.Replace(".pdf", "") + "_output" + ".pdf"

            Dim document As New iTextSharp.text.Document()
            Dim pdfCopy As New PdfCopy(document, New FileStream(Convert.ToString(Ruta) & filename, FileMode.Create))

            document.Open()

            For pagenumber As Integer = nPagIni To nPagFin

                pdfCopy.AddPage(pdfCopy.GetImportedPage(reader, pagenumber))

            Next

            document.Close()

        End Using
    End Sub

    Public Sub Split_x_Lotes(ByVal Ruta As String, ByVal pdfFileName As String, Paginas_Cortar As Integer)
        PaginasCortar = Paginas_Cortar

        Using reader As New PdfReader(Ruta + pdfFileName)

            Dim TotLotes As Integer = Num_Total_Lotes(reader.NumberOfPages)

            For lote As Integer = 1 To (TotLotes)

                Dim N_Ini_Pag As Integer = (PaginasCortar * (lote - 1) + 1)
                Dim N_Final_Pag As Integer = Num_Final_Pag(lote, reader.NumberOfPages)

                If N_Final_Pag >= N_Ini_Pag Then

                    Dim filename As String = pdfFileName.Replace(".pdf", "") + "_Parte" + lote.ToString() + ".pdf"

                    Dim document As New iTextSharp.text.Document()
                    Dim pdfCopy As New PdfCopy(document, New FileStream(Convert.ToString(Ruta) & filename, FileMode.Create))

                    document.Open()

                    For pagenumber As Integer = N_Ini_Pag To N_Final_Pag

                        pdfCopy.AddPage(pdfCopy.GetImportedPage(reader, pagenumber))
                    Next

                    document.Close()
                End If

            Next
        End Using
    End Sub

    Public Sub Split_Page_by_Page(ByVal Ruta As String, ByVal pdfFileName As String, param_PagIni As Integer, Optional ByVal nPag_Cortar As Integer = 1)
        PaginasCortar = nPag_Cortar

        Using reader As New PdfReader(Ruta + pdfFileName)

            Dim TotLotes As Integer = Num_Total_Lotes(reader.NumberOfPages)

            For lote As Integer = 1 To (TotLotes)

                Dim N_Ini_Pag As Integer = 0
                Dim N_Final_Pag As Integer = 0
                N_Ini_Pag = (PaginasCortar * (lote - 1) + 1)
                N_Final_Pag = Num_Final_Pag(lote, reader.NumberOfPages)

                If N_Final_Pag >= N_Ini_Pag Then

                    Dim filename As String = ""
                    If param_PagIni > 0 Then
                        filename = pdfFileName.Replace(".pdf", "") + "_Page_" + (param_PagIni).ToString.PadLeft(4, "0") + ".pdf"
                        param_PagIni = param_PagIni + 1
                    Else
                        filename = pdfFileName.Replace(".pdf", "") + "_Page_" + (lote - 1).ToString.PadLeft(4, "0") + ".pdf"
                    End If

                    Dim document As New iTextSharp.text.Document()
                    Dim pdfCopy As New PdfCopy(document, New FileStream(Convert.ToString(Ruta) & filename, FileMode.Create))

                    document.Open()

                    For pagenumber As Integer = N_Ini_Pag To N_Final_Pag

                        pdfCopy.AddPage(pdfCopy.GetImportedPage(reader, pagenumber))
                    Next

                    document.Close()
                End If

            Next
        End Using
    End Sub

    Private Function Num_Final_Pag(lote As Integer, TotPag As Integer) As Integer

        Dim LastLote As Integer = Num_Total_Lotes(TotPag)
        If lote < LastLote Then

            Num_Final_Pag = lote * PaginasCortar

        Else
            Num_Final_Pag = TotPag
        End If

    End Function

    Private Function Num_Total_Lotes(TotPag As Integer) As Integer

        Return ((TotPag - (TotPag Mod PaginasCortar)) / PaginasCortar + 1)
    End Function

    Public Sub MergePDF(files As String(), targetPDF As String)
        Using stream As New FileStream(targetPDF, FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A4)
            Dim pdf As New PdfCopy(pdfDoc, stream)
            pdfDoc.Open()


            Dim i As Integer = 0
            For Each file As String In files

                Dim test As PdfReader = New PdfReader(file)
                pdf.AddDocument(test)
                test.Dispose()


                System.IO.File.Delete(file)


                i += 1
            Next

            If pdfDoc IsNot Nothing Then

                pdfDoc.Close()
                pdf.Close()
            End If


        End Using
    End Sub

    Public Sub DeletePages(ByVal Ruta As String, ByVal pdfFileName As String, aPaginas_Delete As List(Of Integer), ByVal replace_original As Boolean)

        Dim filename As String = ""
        Using reader As New PdfReader(Ruta + pdfFileName)

            filename = pdfFileName.Replace(".pdf", "") + "_output" + ".pdf"

            Dim document As New iTextSharp.text.Document()
            Dim pdfCopy As New PdfCopy(document, New FileStream(Convert.ToString(Ruta) & filename, FileMode.Create))

            document.Open()

            Dim N_Final_Pag As Integer = reader.NumberOfPages

            For pagenumber As Integer = 1 To N_Final_Pag

                'If (System.Array.IndexOf(aPaginas_Delete, pagenumber) >= 0) Then
                'Else
                '    pdfCopy.AddPage(pdfCopy.GetImportedPage(reader, pagenumber))
                'End If

                If (aPaginas_Delete.Contains(pagenumber)) Then
                Else
                    pdfCopy.AddPage(pdfCopy.GetImportedPage(reader, pagenumber))
                End If
            Next

            document.Close()

        End Using

        If replace_original = True Then
            System.IO.File.Delete(Ruta + pdfFileName)
            System.IO.File.Move(Ruta + filename, Ruta + pdfFileName)
        End If
    End Sub


    Public Sub PonerPassword(ByVal Ruta As String, ByVal pdfFileName As String)

        Using input As Stream = New FileStream(Ruta + pdfFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
            Using output As Stream = New FileStream(Ruta + pdfFileName + "_encrypted.pdf", FileMode.Create, FileAccess.Write, FileShare.None)
                Dim reader As New PdfReader(input)
                PdfEncryptor.Encrypt(reader, output, True, "secret", "secret", PdfWriter.ALLOW_PRINTING)
            End Using
        End Using
    End Sub


    Public Sub removeAnnotations(inputPath As String, outputPath As String)
        Dim pdfReader As New PdfReader(inputPath)
        Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(outputPath, FileMode.Create))

        ''pdfReader.RemoveAnnotations()
        pdfReader.RemoveUnusedObjects()
        pdfStamper.Close()
    End Sub

    'Public Sub Remove_HyperLinks(ByVal largePDF As String)


    '    Dim smallPDF As String = "C:\x\jorge\otro.pdf"
    '    'Bind a reader to our large PDF
    '    Dim reader As New PdfReader(largePDF)

    '    Using fs As New FileStream(smallPDF, FileMode.Create, FileAccess.Write, FileShare.None)
    '        Using stamper As New PdfStamper(reader, fs)
    '            Dim page As PdfDictionary = reader.GetPageN(1) '1st page is 1
    '            page.Remove(PdfName.ANNOTS)

    '        End Using
    '    End Using


    'End Sub



    Public Sub ComprimirPDF(ByVal largePDF As String, ByVal smallPDF As String, porcReducc As Single, porcCompress As Integer, _tipoEncoder As String)

        tipoEncoder = _tipoEncoder

        'Bind a reader to our large PDF
        Dim reader As New PdfReader(largePDF)
        'Create our output PDF
        Using fs As New FileStream(smallPDF, FileMode.Create, FileAccess.Write, FileShare.None)
            'Bind a stamper to the file and our reader
            Using stamper As New PdfStamper(reader, fs)

                Dim numberOfPages As Integer = reader.NumberOfPages

                For i = 1 To numberOfPages

                    'NOTE: This code only deals with page 1, you'd want to loop more for your code
                    'Get page 1
                    Dim page As PdfDictionary = reader.GetPageN(i)
                    'Get the xobject structure
                    Dim resources As PdfDictionary = DirectCast(PdfReader.GetPdfObject(page.[Get](PdfName.RESOURCES)), PdfDictionary)
                    Dim xobject As PdfDictionary = DirectCast(PdfReader.GetPdfObject(resources.[Get](PdfName.XOBJECT)), PdfDictionary)
                    If xobject IsNot Nothing Then
                        Dim obj As PdfObject
                        'Loop through each key
                        For Each name As PdfName In xobject.Keys
                            obj = xobject.[Get](name)

                            If obj.IsIndirect() Then
                                Dim tg As PdfDictionary = DirectCast(PdfReader.GetPdfObject(obj), PdfDictionary)
                                Dim width As String = tg.[Get](PdfName.WIDTH).ToString()
                                Dim height As String = tg.[Get](PdfName.HEIGHT).ToString()
                                Dim imgRI As ImageRenderInfo = ImageRenderInfo.CreateForXObject(New Matrix(Single.Parse(width), Single.Parse(height)), DirectCast(obj, PRIndirectReference), tg)
                                Dim newBytes As Byte()

                                Using oldImage As System.Drawing.Image = RenderImage(imgRI)
                                    'Shrink the image to 30% of the original
                                    Using newImage As System.Drawing.Image = ShrinkImage(oldImage, Convert.ToDecimal(porcReducc))  ''0.9F
                                        'Convert the image to bytes using JPG at 30%
                                        newBytes = ConvertImageToBytes(newImage, porcCompress)

                                    End Using
                                End Using

                                'Create a new iTextSharp image from our bytes
                                Dim compressedImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(newBytes)

                                'Kill off the old image
                                PdfReader.KillIndirect(obj)
                                'Add our image in its place
                                stamper.Writer.AddDirectImageSimple(compressedImage, DirectCast(obj, PRIndirectReference))


                            End If

                        Next
                    End If


                Next

                stamper.Close()
            End Using

        End Using
        reader.Close()

    End Sub

    'GIF
    'Reduccion: 0.4
    'Compress: 1

    'Antes:
    'JPEG
    'Reduccion: 0.7
    'Compress: 50

    'Standard image save code from MSDN, returns a byte array
    Private Function ConvertImageToBytes(image As System.Drawing.Image, compressionLevel As Long) As Byte()
        If compressionLevel < 0 Then
            compressionLevel = 0
        ElseIf compressionLevel > 100 Then
            compressionLevel = 100
        End If

        Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

        If tipoEncoder = "Jpeg" Then
            jgpEncoder = GetEncoder(ImageFormat.Jpeg)
        ElseIf tipoEncoder = "Gif" Then
            jgpEncoder = GetEncoder(ImageFormat.Gif)
        Else
            jgpEncoder = GetEncoder(ImageFormat.Jpeg)
        End If

        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        Dim myEncoderParameters As New EncoderParameters(1)
        Dim myEncoderParameter As New EncoderParameter(myEncoder, compressionLevel)

        myEncoderParameters.Param(0) = myEncoderParameter
        Using ms As New MemoryStream()
            image.Save(ms, jgpEncoder, myEncoderParameters)
            Return ms.ToArray()
        End Using

    End Function
    'standard code from MSDN
    Private Shared Function GetEncoder(format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()
        For Each codec As ImageCodecInfo In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next
        Return Nothing
    End Function

    'Standard high quality thumbnail generation from http://weblogs.asp.net/gunnarpeipman/archive/2009/04/02/resizing-images-without-loss-of-quality.aspx
    Private Shared Function ShrinkImage(sourceImage As System.Drawing.Image, scaleFactor As Single) As System.Drawing.Image

        Dim newWidth As Integer = Convert.ToInt32(sourceImage.Width * scaleFactor)
        Dim newHeight As Integer = Convert.ToInt32(sourceImage.Height * scaleFactor)

        Dim thumbnailBitmap = New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(thumbnailBitmap)
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            Dim imageRectangle As New System.Drawing.Rectangle(0, 0, newWidth, newHeight)
            g.DrawImage(sourceImage, imageRectangle)
        End Using

        ''thumbnailBitmap.Save("C:\temporal\miimagen.jpg", ImageFormat.Jpeg)

        Return thumbnailBitmap
    End Function

    Private Function RenderImage(renderInfo As ImageRenderInfo) As System.Drawing.Image
        Dim image As PdfImageObject = renderInfo.GetImage()
        Dim dotnetImg As Dotnet = image.GetDrawingImage()
        Return dotnetImg
    End Function

    Public Sub RotatePdf(src As String, dest As String)

        '' rota 90° a la derecha

        Dim reader As New PdfReader(src)
        Dim n As Integer = reader.NumberOfPages()
        Dim page As PdfDictionary
        Dim rotate As PdfNumber

        For p As Integer = 1 To n
            page = reader.GetPageN(p)
            rotate = page.GetAsNumber(PdfName.ROTATE)
            If rotate Is Nothing Then
                page.Put(PdfName.ROTATE, New PdfNumber(90))
            Else
                page.Put(PdfName.ROTATE, New PdfNumber((rotate.IntValue() + 90) Mod 360))
            End If
        Next

        Dim stamper As New PdfStamper(reader, New FileStream(dest, FileMode.Create))
        stamper.Close()
        reader.Close()
    End Sub

    Public Sub CropPdf(src As String, dest As String)


        Dim fX As Integer = 700  'From Left
        Dim fY As Integer = 230  'From Bottom
        Dim fWidth As Integer = 670
        Dim fHeight As Integer = 150

        'Dim fX As Integer = 700  'From Left
        'Dim fY As Integer = 340  'From Bottom
        'Dim fWidth As Integer = 670
        'Dim fHeight As Integer = 50

        
        'width = 841.68
        'height = 595.2

        Dim reader As New PdfReader(src)
        Dim n As Integer = reader.NumberOfPages()
        Dim page As PdfDictionary

        For p As Integer = 1 To n
            page = reader.GetPageN(p)

            Dim rect As New PdfRectangle(fX, fY, fWidth, fHeight)
            page.Put(PdfName.CROPBOX, rect)

        Next

        Dim stamper As New PdfStamper(reader, New FileStream(dest, FileMode.Create))
        stamper.Close()
        reader.Close()

        
    End Sub

    'Public Sub AddPageNumber(ByVal Ruta As String, ByVal fileIn As String, ByVal fileOut As String)

    '    Dim bytes As Byte() = File.ReadAllBytes(Ruta + fileIn)
    '    Dim blackFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
    '    Using stream As MemoryStream = New MemoryStream()
    '        Dim reader As PdfReader = New PdfReader(bytes)
    '        Using stamper As PdfStamper = New PdfStamper(reader, stream)
    '            Dim pages As Integer = reader.NumberOfPages
    '            For i As Integer = 1 To pages
    '                'ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, New Phrase(i.ToString(), blackFont), 568.0F, 15.0F, 0)
    '                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_BOTTOM, New Phrase(i.ToString(), blackFont), 568.0F, 15.0F, 0)
    '            Next
    '        End Using

    '        bytes = stream.ToArray()
    '    End Using

    '    File.WriteAllBytes(Ruta + fileOut, bytes)
    'End Sub

    Public Sub AddPageNumber(ByVal Ruta As String, ByVal fileIn As String, ByVal fileOut As String)

        ''Dim numpag As Integer = 126
        Dim bytes As Byte() = File.ReadAllBytes(Ruta + fileIn)
        Dim blackFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Using stream As New MemoryStream()
            Dim reader As New PdfReader(bytes)
            Using stamper As New PdfStamper(reader, stream)
                Dim pages As Integer = reader.NumberOfPages

                For i As Integer = 1 To pages

                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT, New Phrase(i.ToString(), blackFont), 568.0F, 15.0F, 0)
                    ''numpag = numpag + 1
                    ''ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT, New Phrase(numpag.ToString(), blackFont), 568.0F, 15.0F, 0)
                Next

            End Using
            bytes = stream.ToArray()
        End Using
        File.WriteAllBytes(Ruta + fileOut, bytes)
    End Sub

    Public Sub AddPageNumber_DobleHoja(ByVal Ruta As String, ByVal fileIn As String, ByVal fileOut As String)
        Dim numpag As Integer = 1
        Dim bytes As Byte() = File.ReadAllBytes(Ruta + fileIn)
        Dim blackFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Using stream As New MemoryStream()
            Dim reader As New PdfReader(bytes)
            Using stamper As New PdfStamper(reader, stream)
                Dim pages As Integer = reader.NumberOfPages

                For i As Integer = 1 To pages

                    If (i Mod 2) = 0 Then
                        ' pagina par
                    Else
                        ' pagina impar
                        If i = 1 Then
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT, New Phrase(numpag.ToString(), blackFont), 568.0F, 15.0F, 0)
                        End If
                        If i > 1 Then
                            numpag = numpag + 1
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT, New Phrase(numpag.ToString(), blackFont), 568.0F, 15.0F, 0)
                        End If
                    End If

                Next

            End Using
            bytes = stream.ToArray()
        End Using
        File.WriteAllBytes(Ruta + fileOut, bytes)
    End Sub


End Class
