using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using AI.DocumentAnalyzer.Api.Interfaces;
using AI.DocumentAnalyzer.Api.Models;

namespace AI.DocumentAnalyzer.Api.Services;

public class OpenAiDocumentAnalysisService : IDocumentAnalysisService
{
    private readonly ChatClient _client;


    public OpenAiDocumentAnalysisService(
        IConfiguration configuration)
    {
        var endpoint =
            configuration["AzureOpenAI:Endpoint"];

        var apiKey =
            configuration["AzureOpenAI:ApiKey"];

        var deployment =
            configuration["AzureOpenAI:DeploymentName"];


        var azureClient =
            new AzureOpenAIClient(
                new Uri(endpoint!),
                new AzureKeyCredential(apiKey!)
            );


        _client =
            azureClient.GetChatClient(deployment!);
    }


    public async Task<string> AnalyzeAsync(
        string text)
    {

        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(
            """
            Du bist ein Dokumenten-Analyse-System.
            Analysiere den Inhalt und antworte nur als JSON.
            
            Erstelle:
            - documentType
            - summary
            - skills
            - experienceYears
            """
            ),

            new UserChatMessage(text)
        };


        var response =
            await _client.CompleteChatAsync(messages);


        var json =
            response.Value.Content[0].Text;
        Console.WriteLine("===== Azure OpenAI =====");
        Console.WriteLine(json);
        Console.WriteLine("========================");

        return response.Value.Content[0].Text;  
    }
}
