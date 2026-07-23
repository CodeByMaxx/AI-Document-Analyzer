using AI.DocumentAnalyzer.Api.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AI.DocumentAnalyzer.Api.Services;

public class DocumentService
{
    private readonly IStorageService _storage;

    public DocumentService(IStorageService storage)
    {
        _storage = storage;
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        return await _storage.SaveFileAsync(file);
    }
}
