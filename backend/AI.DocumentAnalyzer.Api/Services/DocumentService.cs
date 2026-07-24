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
    private readonly IDocumentAnalysisService _analysisService;

    public DocumentService(
    IStorageService storage,
    IPdfTextExtractor extractor,
    DocumentRepository repository,
    IDocumentAnalysisService analysisService)
{
    _storage = storage;
    _extractor = extractor;
    _repository = repository;
    _analysisService = analysisService;
}

    public async Task<Document> UploadAsync(IFormFile file)
    {
    var document = new Document
    {
        Id = Guid.NewGuid(),
        FileName = file.FileName,
        FileSize = file.Length,
        UploadedAt = DateTime.UtcNow,
        Status = DocumentStatus.Processing
    };

    using var stream = file.OpenReadStream();

    var extractedText =
        await _extractor.ExtractTextAsync(stream);

    var storageLocation =
        await _storage.SaveFileAsync(file);

    var aiAnalysis =
    await _analysisService.AnalyzeAsync(extractedText);

    document.ExtractedText = extractedText;
    document.AiAnalysis = aiAnalysis;
    
    _repository.Add(document);

    return document;
   }    
}
