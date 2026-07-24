using AI.DocumentAnalyzer.Api.Interfaces;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace AI.DocumentAnalyzer.Api.Services;

public class PdfTextExtractorService : IPdfTextExtractor
{
    public async Task<string> ExtractTextAsync(Stream stream)
    {
        return await Task.Run(() =>
        {
            stream.Position = 0;

            using var reader = new PdfReader(stream);
            using var pdf = new PdfDocument(reader);

            var text = new System.Text.StringBuilder();

            for (int page = 1; page <= pdf.GetNumberOfPages(); page++)
            {
                text.AppendLine(
                    PdfTextExtractor.GetTextFromPage(pdf.GetPage(page))
                );
            }

            return text.ToString();
        });
    }
}
