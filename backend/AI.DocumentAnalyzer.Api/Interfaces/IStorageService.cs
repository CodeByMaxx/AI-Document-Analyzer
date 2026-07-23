using Microsoft.AspNetCore.Http;

namespace AI.DocumentAnalyzer.Api.Interfaces;

public interface IStorageService
{
    Task<string> SaveFileAsync(IFormFile file);
}
