using AI.DocumentAnalyzer.Api.Interfaces;
using AI.DocumentAnalyzer.Api.Models;
using Microsoft.AspNetCore.Http;
using AI.DocumentAnalyzer.Api.Repositories;

namespace AI.DocumentAnalyzer.Api.Services;

public class DocumentService
{
    private readonly IStorageService _storage;
    private readonly IPdfTextExtractor _extractor;
    private readonly DocumentRepository _repository;

    public DocumentService(
    IStorageService storage,
    IPdfTextExtractor extractor,
    DocumentRepository repository)
    {
     _storage = storage;
     _extractor = extractor;
     _repository = repository;
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

        _repository.Add(document);

        return document;
    }
}
