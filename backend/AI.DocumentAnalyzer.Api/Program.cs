using AI.DocumentAnalyzer.Api.Interfaces;
using AI.DocumentAnalyzer.Api.Services;
using AI.DocumentAnalyzer.Api.Storage;
using AI.DocumentAnalyzer.Api.Repositories;
using AI.DocumentAnalyzer.Api.Middleware;
using AI.DocumentAnalyzer.Api.Models;


var builder = WebApplication.CreateBuilder(args);
var mode =
    builder.Configuration["ApplicationMode"];

builder.Services.AddScoped<DocumentService>();

Console.WriteLine($"Running Mode: {mode}");

if (mode == "Azure")
{
    builder.Services.AddSingleton<IStorageService, AzureBlobStorageService>();

    builder.Services.AddScoped<IPdfTextExtractor, AzureDocumentIntelligenceService>();

    builder.Services.AddScoped<IDocumentAnalysisService, OpenAiDocumentAnalysisService>();
}
else
{
    builder.Services.AddSingleton<IStorageService, LocalStorageService>();

    builder.Services.AddScoped<IPdfTextExtractor, PdfTextExtractorService>();

    builder.Services.AddScoped<IDocumentAnalysisService, LocalAiDocumentAnalysisService>();
}

builder.Services.AddSingleton<DocumentRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("frontend");

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
