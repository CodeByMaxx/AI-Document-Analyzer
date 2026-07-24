using AI.DocumentAnalyzer.Api.Interfaces;
using AI.DocumentAnalyzer.Api.Models;

namespace AI.DocumentAnalyzer.Api.Services;

public class LocalAiDocumentAnalysisService : IDocumentAnalysisService
{
    public LocalAiDocumentAnalysisService(
        IConfiguration configuration)
    {
    }


    public Task<string> AnalyzeAsync(string text)
    {
        var result = """
        {
          "documentType": "unknown",
          "summary": "Local AI provider is not configured yet.",
        }
        """;

        return Task.FromResult(result);
    }
}
