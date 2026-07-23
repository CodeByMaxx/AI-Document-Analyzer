using Microsoft.AspNetCore.Mvc;
using AI.DocumentAnalyzer.Api.Services;
using AI.DocumentAnalyzer.Api.Models;

namespace AI.DocumentAnalyzer.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{

    private readonly DocumentService _service;


    public DocumentsController(
        DocumentService service)
    {
        _service = service;
    }

   
   [HttpPost("upload")]
   public async Task<IActionResult> Upload(IFormFile file)
   {
    if (file == null)
    {
        return BadRequest("Keine Datei erhalten");
    }


    var fileName = await _service.UploadAsync(file);


    var response = new DocumentUploadResponse
    {
        FileName = fileName,
        FileSize = file.Length,
        Message = "Upload erfolgreich"
    };


    return Ok(response);
}

}
