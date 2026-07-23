using AI.DocumentAnalyzer.Api.Models;
using AI.DocumentAnalyzer.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AI.DocumentAnalyzer.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly DocumentService _service;


    public DocumentsController(DocumentService service)
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


        var document = await _service.UploadAsync(file);


        return Ok(document);
    }
}
