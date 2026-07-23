using AI.DocumentAnalyzer.Api.Interfaces;
using AI.DocumentAnalyzer.Api.Services;
using AI.DocumentAnalyzer.Api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DocumentService>();
builder.Services.AddSingleton<IStorageService, LocalStorageService>();

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

app.MapControllers();

app.Run();
