Public Class Form1
    Private mainPath As String = ""

    Public Sub New()
        InitializeComponent()

        mainPath = txtFolderOutput.Text

        ''Load_Grid_PDF()
    End Sub

    'Private Sub Load_Grid_PDF()

    '    Dim oListPDF As New ListPDF

    '    dgrPDF.DataSource = oListPDF.Fileinfo_To_DataTable("C:\Info_Sistemas\OROP\Proyectos SROP 2015\Escaneo Exp\Exp OP Scaneados (Res 208-2016-JNE)")

    '    Formatea_GridView()

    'End Sub

    'Private Sub Formatea_GridView()

    '    dgrPDF.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    dgrPDF.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    dgrPDF.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '    dgrPDF.Refresh()
    'End Sub

    Private Sub LeerPDF_Click(sender As System.Object, e As System.EventArgs) Handles LeerPDF.Click

        Dim oReadPDF As New ReadPDF

        Dim PdfFileName As String = "C:\" + NombreArchivo() + ".pdf"
        oReadPDF.GetTextFromPDF(PdfFileName)

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btn_Split_Page_by_Page_Click(sender As System.Object, e As System.EventArgs) Handles btn_Split_Page_by_Page.Click

        Dim Ruta As String = mainPath
        Dim pdfFileName As String = "\" + NombreArchivo() + ".pdf"

        Dim oReadPDF As New ReadPDF
        oReadPDF.Split_Page_by_Page(Ruta, pdfFileName, txtPagIni.Text, txtNumPagCortar.Text)

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btn_Split_Rango_Paginas_Click(sender As System.Object, e As System.EventArgs) Handles btn_Split_Rango_Paginas.Click
        Dim Ruta As String = mainPath
        Dim pdfFileName As String = "\" + NombreArchivo() + ".pdf"

        Dim oReadPDF As New ReadPDF
        oReadPDF.Split_Rango_Paginas(Ruta, pdfFileName, txtPagIni.Text, txtPagFin.Text)

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btn_Split_LotesPDF_Click(sender As System.Object, e As System.EventArgs) Handles btn_Split_LotesPDF.Click
        Dim Ruta As String = mainPath
        Dim pdfFileName As String = "\" + NombreArchivo() + ".pdf"

        Dim oReadPDF As New ReadPDF
        oReadPDF.Split_x_Lotes(Ruta, pdfFileName, 1000)

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub PegarPDF_Click(sender As System.Object, e As System.EventArgs) Handles PegarPDF.Click

        Dim pdfFiles() As String = Get_PDF_files(mainPath)

        Dim outputPath As String = mainPath & "\" + NombreArchivo() + ".pdf"
        Dim oReadPDF As New ReadPDF
        oReadPDF.MergePDF(pdfFiles, outputPath)

        '' Ini Temporal
        '' Pegas folios de dos en dos
        'Dim newPdfFiles() As String
        'Dim i As Integer = 0
        'Dim j As Integer = 0
        'For Each file As String In pdfFiles

        '    If System.IO.File.Exists(file) = True Then
        '        newPdfFiles = New String(1) {}

        '        Array.Copy(pdfFiles, i, newPdfFiles, 0, 2)
        '        oReadPDF.MergePDF(newPdfFiles, outputPath)

        '        System.IO.File.Move(outputPath, mainPath & "\" & NombreArchivo() & "_Page_" & (j + Integer.Parse(txtPagIni.Text)).ToString() & ".pdf")
        '        j += 1
        '    End If
        '    i += 1


        'Next
        ''' Fin Temporal

        oReadPDF = Nothing
        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Function Get_PDF_files(ByVal _path As String) As String()

        Dim ArrFiles As New List(Of String)

        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(_path)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
        Dim fi As IO.FileInfo
        For Each fi In aryFi

            'Console.WriteLine("File Full Name: {0}", fi.FullName)
            ArrFiles.Add(fi.FullName)

        Next


        Dim pdfFiles() As String = ArrFiles.ToArray()

        System.Array.Sort(Of String)(pdfFiles)

        Return pdfFiles
    End Function

    Private Sub Delete_Pages_Click(sender As System.Object, e As System.EventArgs) Handles Delete_Pages.Click
        Dim Ruta As String = mainPath
        Dim pdfFileName As String = "\" + NombreArchivo() + ".pdf"

        Dim numbers As New List(Of Integer)
        Dim i As Integer
        Dim Ini As Integer = If(String.IsNullOrEmpty(txtPagIni.Text), 0, txtPagIni.Text)
        Dim Fin As Integer = If(String.IsNullOrEmpty(txtPagFin.Text), 0, txtPagFin.Text)
        For i = Ini To Fin
            numbers.Add(i)
        Next

        Dim oReadPDF As New ReadPDF
        ''oReadPDF.DeletePages(Ruta, pdfFileName, {2, 3, 4, 5}, False)
        oReadPDF.DeletePages(Ruta, pdfFileName, numbers, False)

        MessageBox.Show("Fin del Proceso!")
    End Sub

    Private Sub btn_Borrar_2daPagina_Click(sender As System.Object, e As System.EventArgs) Handles btn_Borrar_2daPagina.Click

        Dim Ruta As String = mainPath

        Dim oReadPDF As New ReadPDF

        Dim numbers As New List(Of Integer)
        numbers.Add(2)

        Dim pdfFiles() As String = Get_PDF_files(mainPath)

        For Each file As String In pdfFiles


            oReadPDF.DeletePages(Ruta & "\", System.IO.Path.GetFileNameWithoutExtension(file) & ".pdf", numbers, True)

        Next

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btnPasswordProtect_Click(sender As System.Object, e As System.EventArgs) Handles btnPasswordProtect.Click

        Dim Ruta As String = mainPath
        Dim pdfFileName As String = "\" + NombreArchivo() + ".pdf"

        Dim oReadPDF As New ReadPDF
        oReadPDF.PonerPassword(Ruta, pdfFileName)

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btnComprimirPDF_Click(sender As System.Object, e As System.EventArgs) Handles btnComprimirPDF.Click

        Dim largePDF As String
        Dim smallPDF As String

        Dim oReadPDF As New ReadPDF


        Dim pdfFiles() As String = Get_PDF_files(mainPath + "\big\")

        For Each file As String In pdfFiles

            largePDF = file
            'smallPDF = mainPath + "\" + System.IO.Path.GetFileNameWithoutExtension(file) + ".pdf"
            smallPDF = mainPath + "\c2\" + System.IO.Path.GetFileNameWithoutExtension(file) + ".pdf"

            oReadPDF.ComprimirPDF(largePDF, smallPDF, txtporcReducc.Text, CInt(txtPorcCompress.Text), cmbTipoEncoder.SelectedItem)

        Next


        MessageBox.Show("Fin del Proceso!")
    End Sub

    Private Function NombreArchivo() As String
        NombreArchivo = txtNomArc.Text.Replace(".pdf", "")

    End Function



    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_Tool_Tips()
        Set_Combo_Default_Value()
    End Sub

    Private Sub Load_Tool_Tips()
        Dim toolTip1 As ToolTip = New ToolTip()
        toolTip1.SetToolTip(btn_Split_LotesPDF, "Corta PDF en partes de 1000 páginas cada una.")
        toolTip1.SetToolTip(btn_Split_Rango_Paginas, "Del PDF principal, extrae un PDF de la página Ini a la página Fin.")
    End Sub

    Private Sub Set_Combo_Default_Value()
        If cmbTipoEncoder.Items.Count > 0 Then
            cmbTipoEncoder.SelectedIndex = 1    ' The first item has index 0 '            
            txtporcReducc.Text = 0.4
            txtPorcCompress.Text = 1
        End If
    End Sub


    Private Sub btnFinalCompressPDF_Click(sender As System.Object, e As System.EventArgs) Handles btnFinalCompressPDF.Click

        Dim pdfFilesC1() As String = Get_PDF_files(mainPath + "\c1\")
        Dim pdfFilesC2() As String = Get_PDF_files(mainPath + "\c2\")
        Dim i As Integer = 0

        For Each file As String In pdfFilesC1

            Dim sizeC1 As Long = New System.IO.FileInfo(file).Length
            Dim sizeC2 As Long = New System.IO.FileInfo(pdfFilesC2(i)).Length

            ' Compara pdf del folder c1 con pdf del folder c2
            If sizeC1 > sizeC2 Then
                System.IO.File.Copy(pdfFilesC2(i), mainPath + "\final\" + System.IO.Path.GetFileNameWithoutExtension(pdfFilesC2(i)) + ".pdf", True)
            Else
                System.IO.File.Copy(pdfFilesC1(i), mainPath + "\final\" + System.IO.Path.GetFileNameWithoutExtension(pdfFilesC1(i)) + ".pdf", True)
            End If
            
            i = i + 1
        Next

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btnNeevia_Click(sender As System.Object, e As System.EventArgs) Handles btnNeevia.Click
        Dim NVcomp : NVcomp = CreateObject("Neevia.PDFcompress")

        NVcomp.CI = "jpx"
        NVcomp.CQ = 75

        NVcomp.GI = "jpx"
        NVcomp.GQ = 75

        NVcomp.MI = "jbig2l"
        NVcomp.MQ = 5

        'For better compression uncomment the line below
        NVcomp.CreateObjectStreams = True

        Dim retVal : retVal = NVcomp.CompressPDF("c:\x\jorge\Exp_OP_2668_Page_702.pdf", "c:\x\jorge\Exp_OP_2668_Page_702.c.pdf")

        NVcomp = Nothing

        If retVal <> 0 Then
            MsgBox("Error code=" & CStr(retVal))
        Else
            MsgBox("Done")
        End If

        'Dim oReadPDF As New ReadPDF
        'oReadPDF.removeAnnotations("c:\x\jorge\Exp_OP_2668_Page_702.c.pdf", "c:\x\jorge\Exp_OP_2668_Page_702.x.pdf")

        MessageBox.Show("Fin del Proceso!")
    End Sub

    Private Sub cmbTipoEncoder_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTipoEncoder.SelectedIndexChanged
        If cmbTipoEncoder.Items.Count = 1 Then
            txtporcReducc.Text = 0.4
            txtPorcCompress.Text = 1
        End If
    End Sub

    Private Sub btn_RotarPDF_Click(sender As System.Object, e As System.EventArgs) Handles btn_RotarPDF.Click

        Dim oReadPDF As New ReadPDF

        Dim pdfFiles() As String = Get_PDF_files(mainPath)

        For Each file As String In pdfFiles

            Dim source As String = file
            Dim dest As String = mainPath & "\" & System.IO.Path.GetFileNameWithoutExtension(file) & ".r.pdf"

            '' rota 90° a la derecha
            oReadPDF.RotatePdf_90d(file, dest)

        Next

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btn_CropPDF_Click(sender As System.Object, e As System.EventArgs) Handles btn_CropPDF.Click

        Dim oReadPDF As New ReadPDF

        Dim pdfFiles() As String = Get_PDF_files(mainPath)

        For Each file As String In pdfFiles

            Dim source As String = file
            Dim dest As String = mainPath & "\" & System.IO.Path.GetFileNameWithoutExtension(file) & ".c.pdf"

            oReadPDF.CropPdf(file, dest)
        Next

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub Foliar_PDF_Click(sender As Object, e As EventArgs) Handles Foliar_PDF.Click

        Dim Ruta As String = mainPath
        Dim pdfInput As String = "\" + NombreArchivo() + ".pdf"
        Dim pdfOutput As String = "\" + NombreArchivo() + "_foliado.pdf"

        Dim oReadPDF As New ReadPDF

        oReadPDF.AddPageNumber(Ruta, pdfInput, pdfOutput)

        MessageBox.Show("Fin del Proceso!")

    End Sub

    Private Sub btnFoliarDobleHoja_Click(sender As Object, e As EventArgs) Handles btnFoliarDobleHoja.Click

        Dim Ruta As String = mainPath
        Dim pdfInput As String = "\" + NombreArchivo() + ".pdf"
        Dim pdfOutput As String = "\" + NombreArchivo() + "_foliado.pdf"

        Dim oReadPDF As New ReadPDF

        oReadPDF.AddPageNumber_DobleHoja(Ruta, pdfInput, pdfOutput)

        MessageBox.Show("Fin del Proceso!")

    End Sub


End Class

