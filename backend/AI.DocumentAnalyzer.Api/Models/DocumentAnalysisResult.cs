namespace AI.DocumentAnalyzer.Api.Models;

public class DocumentAnalysisResult
{
    public string DocumentType { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;
   
    public string AiAnalysis { get; set; } = string.Empty;
}
