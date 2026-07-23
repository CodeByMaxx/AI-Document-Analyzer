namespace AI.DocumentAnalyzer.Api.Models;

public class Document
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public DateTime UploadedAt { get; set; }

    public DocumentStatus Status { get; set; }

    public string ExtractedText { get; set; } = string.Empty;
}
