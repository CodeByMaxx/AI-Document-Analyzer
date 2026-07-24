namespace AI.DocumentAnalyzer.Api.Interfaces;

public interface IPdfTextExtractor
{
    Task<string> ExtractTextAsync(Stream stream);
}
