using Azure;
using Azure.AI.DocumentIntelligence;
using AI.DocumentAnalyzer.Api.Interfaces;

namespace AI.DocumentAnalyzer.Api.Services;

public class AzureDocumentIntelligenceService : IPdfTextExtractor
{
    private readonly DocumentIntelligenceClient _client;


    public AzureDocumentIntelligenceService(
        IConfiguration configuration)
    {
        var endpoint =
            configuration["DocumentIntelligence:Endpoint"];

        var apiKey =
            configuration["DocumentIntelligence:ApiKey"];


        _client = new DocumentIntelligenceClient(
            new Uri(endpoint!),
            new AzureKeyCredential(apiKey!)
        );
    }


    public async Task<string> ExtractTextAsync(Stream stream)
    {
        stream.Position = 0;


        var operation =
            await _client.AnalyzeDocumentAsync(
                WaitUntil.Completed,
                "prebuilt-read",
                BinaryData.FromStream(stream)
            );


        var result = operation.Value;


        var text = new System.Text.StringBuilder();


        foreach (var page in result.Pages)
        {
            foreach (var line in page.Lines)
            {
                text.AppendLine(line.Content);
            }
        }


        return text.ToString();
    }
}
