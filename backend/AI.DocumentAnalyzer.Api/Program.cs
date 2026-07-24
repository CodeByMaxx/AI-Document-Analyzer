using AI.DocumentAnalyzer.Api.Interfaces;
using AI.DocumentAnalyzer.Api.Services;
using AI.DocumentAnalyzer.Api.Storage;
using AI.DocumentAnalyzer.Api.Repositories;
using AI.DocumentAnalyzer.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DocumentService>();
builder.Services.AddSingleton<IStorageService, AzureBlobStorageService>();
builder.Services.AddSingleton<DocumentRepository>();

builder.Services.AddControllers();

builder.Services.AddScoped<IPdfTextExtractor, AzureDocumentIntelligenceService>();
builder.Services.AddScoped<IDocumentAnalysisService, OpenAiDocumentAnalysisService>();

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
