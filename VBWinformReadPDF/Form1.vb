Imports System.IO
Imports Microsoft.Office.Interop
Imports Spire.Pdf
Imports Spire.Pdf.Texts
Public Class Form1
    Dim extractedText As String
    Private Sub extractPDFText()
        ListBox1.Items.Add("Launching Spire PDF")
        Dim doc As New PdfDocument()

        'Load a PDF file
        doc.LoadFromFile("C:\Users\jd310\Documents\DDU Guide_Tutorial_Wagnardsoft.pdf")

        ListBox1.Items.Add("Opened PDF File")
        'Get the second page
        Dim page As PdfPageBase = doc.Pages(1)

        'Create a PdfTextExtractot object
        Dim textExtractor As New PdfTextExtractor(page)

        ListBox1.Items.Add("Page aquired")

        'Create a PdfTextExtractOptions object
        Dim extractOptions As New PdfTextExtractOptions()

        'Set isExtractAllText to true
        extractOptions.IsExtractAllText = True

        'Extract text from the page
        extractedText = textExtractor.ExtractText(extractOptions)

        ListBox1.Items.Add($"Text Extracted - length: {extractedText.Length}")

        doc.Close()
        doc.Dispose()

    End Sub

    Private Sub writeToExcelFile()

        ListBox1.Items.Add("Launching Excel")
        Dim xlApp As Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        xlApp = CreateObject("Excel.Application")
        xlBook = xlApp.Workbooks.Open("C:\Users\jd310\Documents\Book1.xlsm")
        xlSheet = xlBook.Sheets(2)

        ListBox1.Items.Add($"Selected {xlSheet.Name}")
        Try
            ' Write data to Excel sheet
            xlSheet.Range("A27").Value = extractedText
            ListBox1.Items.Add("Placed values in Excel")
        Catch ex As Exception
            ListBox1.Items.Add($"Unable to complete, Error: {ex.Message}")
        End Try

        ' Save and close Excel file
        ListBox1.Items.Add("Saving closing")
        xlBook.Save()
        xlBook.Close()
        xlApp.Quit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        extractPDFText()
        writeToExcelFile()

        ListBox1.Items.Add("Complete")
    End Sub




End Class
