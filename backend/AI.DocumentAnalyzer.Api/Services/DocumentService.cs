using AI.DocumentAnalyzer.Api.Storage;

namespace AI.DocumentAnalyzer.Api.Services;


public class DocumentService
{
    private readonly LocalStorageService _storage;


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
