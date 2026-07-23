namespace AI.DocumentAnalyzer.Api.Models;

public class DocumentUploadResponse
{
    public string FileName { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string Message { get; set; } = string.Empty;
}
