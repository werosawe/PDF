<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LeerPDF = New System.Windows.Forms.Button()
        Me.btn_Split_Page_by_Page = New System.Windows.Forms.Button()
        Me.PegarPDF = New System.Windows.Forms.Button()
        Me.Delete_Pages = New System.Windows.Forms.Button()
        Me.btn_Split_Rango_Paginas = New System.Windows.Forms.Button()
        Me.btnPasswordProtect = New System.Windows.Forms.Button()
        Me.btn_Split_LotesPDF = New System.Windows.Forms.Button()
        Me.txtPagIni = New System.Windows.Forms.TextBox()
        Me.txtPagFin = New System.Windows.Forms.TextBox()
        Me.lblPagIni = New System.Windows.Forms.Label()
        Me.lblPagFin = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNomArc = New System.Windows.Forms.TextBox()
        Me.btnComprimirPDF = New System.Windows.Forms.Button()
        Me.txtPorcCompress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtporcReducc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoEncoder = New System.Windows.Forms.ComboBox()
        Me.btn_Borrar_2daPagina = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumPagCortar = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnFinalCompressPDF = New System.Windows.Forms.Button()
        Me.btnNeevia = New System.Windows.Forms.Button()
        Me.btn_RotarPDF = New System.Windows.Forms.Button()
        Me.btn_CropPDF = New System.Windows.Forms.Button()
        Me.Foliar_PDF = New System.Windows.Forms.Button()
        Me.btnFoliarDobleHoja = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFolderOutput = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LeerPDF
        '
        Me.LeerPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LeerPDF.Location = New System.Drawing.Point(361, 112)
        Me.LeerPDF.Name = "LeerPDF"
        Me.LeerPDF.Size = New System.Drawing.Size(120, 53)
        Me.LeerPDF.TabIndex = 0
        Me.LeerPDF.Text = "Extraer DNI de Padron en PDF"
        Me.LeerPDF.UseVisualStyleBackColor = True
        '
        'btn_Split_Page_by_Page
        '
        Me.btn_Split_Page_by_Page.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_Split_Page_by_Page.Location = New System.Drawing.Point(12, 110)
        Me.btn_Split_Page_by_Page.Name = "btn_Split_Page_by_Page"
        Me.btn_Split_Page_by_Page.Size = New System.Drawing.Size(119, 55)
        Me.btn_Split_Page_by_Page.TabIndex = 1
        Me.btn_Split_Page_by_Page.Text = "Cortar PDF Página A Página"
        Me.btn_Split_Page_by_Page.UseVisualStyleBackColor = True
        '
        'PegarPDF
        '
        Me.PegarPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PegarPDF.Location = New System.Drawing.Point(12, 287)
        Me.PegarPDF.Name = "PegarPDF"
        Me.PegarPDF.Size = New System.Drawing.Size(119, 55)
        Me.PegarPDF.TabIndex = 2
        Me.PegarPDF.Text = "Unir PDF"
        Me.PegarPDF.UseVisualStyleBackColor = True
        '
        'Delete_Pages
        '
        Me.Delete_Pages.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Delete_Pages.Location = New System.Drawing.Point(174, 287)
        Me.Delete_Pages.Name = "Delete_Pages"
        Me.Delete_Pages.Size = New System.Drawing.Size(119, 55)
        Me.Delete_Pages.TabIndex = 3
        Me.Delete_Pages.Text = "Borrar Páginas "
        Me.Delete_Pages.UseVisualStyleBackColor = True
        '
        'btn_Split_Rango_Paginas
        '
        Me.btn_Split_Rango_Paginas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_Split_Rango_Paginas.Location = New System.Drawing.Point(174, 110)
        Me.btn_Split_Rango_Paginas.Name = "btn_Split_Rango_Paginas"
        Me.btn_Split_Rango_Paginas.Size = New System.Drawing.Size(119, 55)
        Me.btn_Split_Rango_Paginas.TabIndex = 4
        Me.btn_Split_Rango_Paginas.Text = "Extraer Rango de Páginas de PDF"
        Me.btn_Split_Rango_Paginas.UseVisualStyleBackColor = True
        '
        'btnPasswordProtect
        '
        Me.btnPasswordProtect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasswordProtect.Location = New System.Drawing.Point(12, 373)
        Me.btnPasswordProtect.Name = "btnPasswordProtect"
        Me.btnPasswordProtect.Size = New System.Drawing.Size(119, 55)
        Me.btnPasswordProtect.TabIndex = 8
        Me.btnPasswordProtect.Text = "Poner Password"
        Me.btnPasswordProtect.UseVisualStyleBackColor = True
        '
        'btn_Split_LotesPDF
        '
        Me.btn_Split_LotesPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_Split_LotesPDF.Location = New System.Drawing.Point(12, 203)
        Me.btn_Split_LotesPDF.Name = "btn_Split_LotesPDF"
        Me.btn_Split_LotesPDF.Size = New System.Drawing.Size(119, 55)
        Me.btn_Split_LotesPDF.TabIndex = 9
        Me.btn_Split_LotesPDF.Text = "Cortar PDF Por Lotes 1000 pag"
        Me.btn_Split_LotesPDF.UseVisualStyleBackColor = True
        '
        'txtPagIni
        '
        Me.txtPagIni.Location = New System.Drawing.Point(86, 79)
        Me.txtPagIni.Name = "txtPagIni"
        Me.txtPagIni.Size = New System.Drawing.Size(40, 20)
        Me.txtPagIni.TabIndex = 10
        Me.txtPagIni.Text = "1"
        '
        'txtPagFin
        '
        Me.txtPagFin.Location = New System.Drawing.Point(196, 79)
        Me.txtPagFin.Name = "txtPagFin"
        Me.txtPagFin.Size = New System.Drawing.Size(40, 20)
        Me.txtPagFin.TabIndex = 11
        '
        'lblPagIni
        '
        Me.lblPagIni.AutoSize = True
        Me.lblPagIni.Location = New System.Drawing.Point(38, 83)
        Me.lblPagIni.Name = "lblPagIni"
        Me.lblPagIni.Size = New System.Drawing.Size(46, 13)
        Me.lblPagIni.TabIndex = 12
        Me.lblPagIni.Text = "Pag. Ini:"
        '
        'lblPagFin
        '
        Me.lblPagFin.AutoSize = True
        Me.lblPagFin.Location = New System.Drawing.Point(145, 82)
        Me.lblPagFin.Name = "lblPagFin"
        Me.lblPagFin.Size = New System.Drawing.Size(49, 13)
        Me.lblPagFin.TabIndex = 13
        Me.lblPagFin.Text = "Pag. Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nombre de Archivo:"
        '
        'txtNomArc
        '
        Me.txtNomArc.Location = New System.Drawing.Point(126, 49)
        Me.txtNomArc.Name = "txtNomArc"
        Me.txtNomArc.Size = New System.Drawing.Size(235, 20)
        Me.txtNomArc.TabIndex = 15
        '
        'btnComprimirPDF
        '
        Me.btnComprimirPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComprimirPDF.Location = New System.Drawing.Point(174, 373)
        Me.btnComprimirPDF.Name = "btnComprimirPDF"
        Me.btnComprimirPDF.Size = New System.Drawing.Size(119, 55)
        Me.btnComprimirPDF.TabIndex = 16
        Me.btnComprimirPDF.Text = "Comprimir PDF"
        Me.btnComprimirPDF.UseVisualStyleBackColor = True
        '
        'txtPorcCompress
        '
        Me.txtPorcCompress.Location = New System.Drawing.Point(387, 423)
        Me.txtPorcCompress.Name = "txtPorcCompress"
        Me.txtPorcCompress.Size = New System.Drawing.Size(40, 20)
        Me.txtPorcCompress.TabIndex = 17
        Me.txtPorcCompress.Text = "50"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(305, 426)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "% Compresión:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(308, 397)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "% Reducción:"
        '
        'txtporcReducc
        '
        Me.txtporcReducc.Location = New System.Drawing.Point(387, 394)
        Me.txtporcReducc.Name = "txtporcReducc"
        Me.txtporcReducc.Size = New System.Drawing.Size(40, 20)
        Me.txtporcReducc.TabIndex = 20
        Me.txtporcReducc.Text = "0.7"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(307, 369)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Tipo Encoder:"
        '
        'cmbTipoEncoder
        '
        Me.cmbTipoEncoder.FormattingEnabled = True
        Me.cmbTipoEncoder.Items.AddRange(New Object() {"Jpeg", "Gif"})
        Me.cmbTipoEncoder.Location = New System.Drawing.Point(387, 366)
        Me.cmbTipoEncoder.Name = "cmbTipoEncoder"
        Me.cmbTipoEncoder.Size = New System.Drawing.Size(46, 21)
        Me.cmbTipoEncoder.TabIndex = 22
        '
        'btn_Borrar_2daPagina
        '
        Me.btn_Borrar_2daPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_Borrar_2daPagina.Location = New System.Drawing.Point(174, 203)
        Me.btn_Borrar_2daPagina.Name = "btn_Borrar_2daPagina"
        Me.btn_Borrar_2daPagina.Size = New System.Drawing.Size(119, 55)
        Me.btn_Borrar_2daPagina.TabIndex = 23
        Me.btn_Borrar_2daPagina.Text = "Borrar 2da Pagina de PDF"
        Me.btn_Borrar_2daPagina.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Cortar Cada:"
        '
        'txtNumPagCortar
        '
        Me.txtNumPagCortar.Location = New System.Drawing.Point(80, 165)
        Me.txtNumPagCortar.Name = "txtNumPagCortar"
        Me.txtNumPagCortar.Size = New System.Drawing.Size(20, 20)
        Me.txtNumPagCortar.TabIndex = 25
        Me.txtNumPagCortar.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(101, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Página"
        '
        'btnFinalCompressPDF
        '
        Me.btnFinalCompressPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnFinalCompressPDF.Location = New System.Drawing.Point(13, 451)
        Me.btnFinalCompressPDF.Name = "btnFinalCompressPDF"
        Me.btnFinalCompressPDF.Size = New System.Drawing.Size(119, 55)
        Me.btnFinalCompressPDF.TabIndex = 27
        Me.btnFinalCompressPDF.Text = "Compara PDF comprimidos"
        Me.btnFinalCompressPDF.UseVisualStyleBackColor = True
        '
        'btnNeevia
        '
        Me.btnNeevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNeevia.Location = New System.Drawing.Point(361, 453)
        Me.btnNeevia.Name = "btnNeevia"
        Me.btnNeevia.Size = New System.Drawing.Size(119, 55)
        Me.btnNeevia.TabIndex = 28
        Me.btnNeevia.Text = "Compress Neevia"
        Me.btnNeevia.UseVisualStyleBackColor = True
        '
        'btn_RotarPDF
        '
        Me.btn_RotarPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_RotarPDF.Location = New System.Drawing.Point(174, 451)
        Me.btn_RotarPDF.Name = "btn_RotarPDF"
        Me.btn_RotarPDF.Size = New System.Drawing.Size(119, 55)
        Me.btn_RotarPDF.TabIndex = 29
        Me.btn_RotarPDF.Text = "Rotar PDF (90° derecha)"
        Me.btn_RotarPDF.UseVisualStyleBackColor = True
        '
        'btn_CropPDF
        '
        Me.btn_CropPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_CropPDF.Location = New System.Drawing.Point(362, 526)
        Me.btn_CropPDF.Name = "btn_CropPDF"
        Me.btn_CropPDF.Size = New System.Drawing.Size(119, 55)
        Me.btn_CropPDF.TabIndex = 30
        Me.btn_CropPDF.Text = "Crop PDF"
        Me.btn_CropPDF.UseVisualStyleBackColor = True
        '
        'Foliar_PDF
        '
        Me.Foliar_PDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Foliar_PDF.Location = New System.Drawing.Point(12, 526)
        Me.Foliar_PDF.Name = "Foliar_PDF"
        Me.Foliar_PDF.Size = New System.Drawing.Size(119, 55)
        Me.Foliar_PDF.TabIndex = 31
        Me.Foliar_PDF.Text = "Foliar PDF"
        Me.Foliar_PDF.UseVisualStyleBackColor = True
        '
        'btnFoliarDobleHoja
        '
        Me.btnFoliarDobleHoja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnFoliarDobleHoja.Location = New System.Drawing.Point(174, 526)
        Me.btnFoliarDobleHoja.Name = "btnFoliarDobleHoja"
        Me.btnFoliarDobleHoja.Size = New System.Drawing.Size(119, 55)
        Me.btnFoliarDobleHoja.TabIndex = 32
        Me.btnFoliarDobleHoja.Text = "Foliar PDF Doble Cara"
        Me.btnFoliarDobleHoja.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Folder de Salida:"
        '
        'txtFolderOutput
        '
        Me.txtFolderOutput.Location = New System.Drawing.Point(126, 16)
        Me.txtFolderOutput.Name = "txtFolderOutput"
        Me.txtFolderOutput.Size = New System.Drawing.Size(235, 20)
        Me.txtFolderOutput.TabIndex = 34
        Me.txtFolderOutput.Text = "C:\Desarrollo\VS2010\PDF\LeePDF\Output"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 601)
        Me.Controls.Add(Me.txtFolderOutput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFoliarDobleHoja)
        Me.Controls.Add(Me.Foliar_PDF)
        Me.Controls.Add(Me.btn_CropPDF)
        Me.Controls.Add(Me.btn_RotarPDF)
        Me.Controls.Add(Me.btnNeevia)
        Me.Controls.Add(Me.btnFinalCompressPDF)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtNumPagCortar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btn_Borrar_2daPagina)
        Me.Controls.Add(Me.cmbTipoEncoder)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtporcReducc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPorcCompress)
        Me.Controls.Add(Me.btnComprimirPDF)
        Me.Controls.Add(Me.txtNomArc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPagFin)
        Me.Controls.Add(Me.lblPagIni)
        Me.Controls.Add(Me.txtPagFin)
        Me.Controls.Add(Me.txtPagIni)
        Me.Controls.Add(Me.btn_Split_LotesPDF)
        Me.Controls.Add(Me.btnPasswordProtect)
        Me.Controls.Add(Me.btn_Split_Rango_Paginas)
        Me.Controls.Add(Me.Delete_Pages)
        Me.Controls.Add(Me.PegarPDF)
        Me.Controls.Add(Me.btn_Split_Page_by_Page)
        Me.Controls.Add(Me.LeerPDF)
        Me.Name = "Form1"
        Me.Text = "PDF Modificar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LeerPDF As System.Windows.Forms.Button
    Friend WithEvents btn_Split_Page_by_Page As System.Windows.Forms.Button
    Friend WithEvents PegarPDF As System.Windows.Forms.Button
    Friend WithEvents Delete_Pages As System.Windows.Forms.Button
    Friend WithEvents btn_Split_Rango_Paginas As System.Windows.Forms.Button
    Friend WithEvents btnPasswordProtect As System.Windows.Forms.Button
    Friend WithEvents btn_Split_LotesPDF As System.Windows.Forms.Button
    Friend WithEvents txtPagIni As System.Windows.Forms.TextBox
    Friend WithEvents txtPagFin As System.Windows.Forms.TextBox
    Friend WithEvents lblPagIni As System.Windows.Forms.Label
    Friend WithEvents lblPagFin As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNomArc As System.Windows.Forms.TextBox
    Friend WithEvents btnComprimirPDF As System.Windows.Forms.Button
    Friend WithEvents txtPorcCompress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtporcReducc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEncoder As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Borrar_2daPagina As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumPagCortar As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnFinalCompressPDF As System.Windows.Forms.Button
    Friend WithEvents btnNeevia As System.Windows.Forms.Button
    Friend WithEvents btn_RotarPDF As System.Windows.Forms.Button
    Friend WithEvents btn_CropPDF As System.Windows.Forms.Button
    Friend WithEvents Foliar_PDF As Button
    Friend WithEvents btnFoliarDobleHoja As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFolderOutput As TextBox
End Class
