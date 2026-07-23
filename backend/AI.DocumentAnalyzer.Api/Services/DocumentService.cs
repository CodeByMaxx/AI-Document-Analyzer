using AI.DocumentAnalyzer.Api.Interfaces;
using AI.DocumentAnalyzer.Api.Models;
using Microsoft.AspNetCore.Http;


namespace AI.DocumentAnalyzer.Api.Services;

public class DocumentService
{
    private readonly IStorageService _storage;
    private readonly IPdfTextExtractor _extractor;


    public DocumentService(
        IStorageService storage,
        IPdfTextExtractor extractor)
    {
        _storage = storage;
        _extractor = extractor;
    }


    public async Task<Document> UploadAsync(IFormFile file)
    {
        var filePath =
            await _storage.SaveFileAsync(file);


        var document = new Document
        {
            Id = Guid.NewGuid(),
            FileName = file.FileName,
            FileSize = file.Length,
            UploadedAt = DateTime.UtcNow,
            Status = DocumentStatus.Processing
        };


        document.ExtractedText =
            await _extractor.ExtractTextAsync(filePath);


        document.Status =
            DocumentStatus.Analyzed;


        return document;
    }
}
