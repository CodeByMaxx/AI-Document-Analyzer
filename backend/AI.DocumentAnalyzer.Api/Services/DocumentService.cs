using AI.DocumentAnalyzer.Api.Storage;

namespace AI.DocumentAnalyzer.Api.Services;
using AI.DocumentAnalyzer.Api.Interfaces;

public class DocumentService
{
    private readonly IStorageService _storage;

    public DocumentService(
        LocalStorageService storage)
    {
        _storage = storage;
    }


    public async Task<string> UploadAsync(
        IFormFile file)
    {
        return await _storage.SaveFileAsync(file);
    }
}
