using AI.DocumentAnalyzer.Api.Interfaces;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace AI.DocumentAnalyzer.Api.Services;

public class PdfTextExtractorService : IPdfTextExtractor
{
    public async Task<string> ExtractTextAsync(string filePath)
    {
        try
        {
            return await Task.Run(() =>
            {
                using var reader = new PdfReader(filePath);
                using var pdf = new PdfDocument(reader);

                var text = "";

                for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
                {
                    text += PdfTextExtractor.GetTextFromPage(
                        pdf.GetPage(i)
                    );
                }

                return text;
            });
        }
        catch (BadPasswordException)
        {
            throw new Exception(
                "PDF ist passwortgeschützt und kann nicht analysiert werden."
            );
        }
    }
}
