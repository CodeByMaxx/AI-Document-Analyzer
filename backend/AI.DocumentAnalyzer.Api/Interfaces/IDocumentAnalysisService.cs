using AI.DocumentAnalyzer.Api.Models;

namespace AI.DocumentAnalyzer.Api.Interfaces;

public interface IDocumentAnalysisService
{
    Task<string> AnalyzeAsync(string text);
}
