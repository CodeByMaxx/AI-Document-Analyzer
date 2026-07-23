using Microsoft.AspNetCore.Http;

namespace AI.DocumentAnalyzer.Api.Storage;

public class LocalStorageService
{
    private readonly string _uploadPath;


    public LocalStorageService()
    {
        _uploadPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Uploads"
        );

        Directory.CreateDirectory(_uploadPath);
    }


    public async Task<string> SaveFileAsync(IFormFile file)
    {
        var fileName = Path.GetFileName(file.FileName);

        var filePath = Path.Combine(
            _uploadPath,
            fileName
        );


        using var stream = new FileStream(
            filePath,
            FileMode.Create
        );


        await file.CopyToAsync(stream);


        return fileName;
    }
}
