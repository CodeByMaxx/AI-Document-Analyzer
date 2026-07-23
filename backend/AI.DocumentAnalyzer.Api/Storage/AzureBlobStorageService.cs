using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using AI.DocumentAnalyzer.Api.Interfaces;

namespace AI.DocumentAnalyzer.Api.Storage;


public class AzureBlobStorageService : IStorageService
{
    private readonly BlobContainerClient _container;


    public AzureBlobStorageService(
        IConfiguration configuration)
    {
        var connectionString =
            configuration["AzureStorage:ConnectionString"];

        var containerName =
            configuration["AzureStorage:ContainerName"];


        _container =
            new BlobContainerClient(
                connectionString,
                containerName
            );
    }


    public async Task<string> SaveFileAsync(IFormFile file)
    {
        var blobClient =
            _container.GetBlobClient(file.FileName);


        await blobClient.UploadAsync(
            file.OpenReadStream(),
            true
        );


        return file.FileName;
    }
}
