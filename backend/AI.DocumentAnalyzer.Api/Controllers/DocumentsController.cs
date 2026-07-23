using AI.DocumentAnalyzer.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AI.DocumentAnalyzer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public DocumentsController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }


    [HttpPost("upload")]
    public async Task<ActionResult<DocumentUploadResponse>> Upload(
        IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Keine Datei ausgewählt.");
        }


        if (!file.FileName.EndsWith(".pdf"))
        {
            return BadRequest("Nur PDF Dateien erlaubt.");
        }


        var uploadFolder = Path.Combine(
            _environment.ContentRootPath,
            "Uploads");


        Directory.CreateDirectory(uploadFolder);


        var filePath = Path.Combine(
            uploadFolder,
            file.FileName);


        using var stream = new FileStream(
            filePath,
            FileMode.Create);


        await file.CopyToAsync(stream);


        return Ok(new DocumentUploadResponse
        {
            FileName = file.FileName,
            FileSize = file.Length,
            Message = "Upload erfolgreich"
        });
    }
}
