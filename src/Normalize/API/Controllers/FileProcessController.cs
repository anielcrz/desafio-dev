using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class FileProcessController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var result = new List<FileUpload>();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", file.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                result.Add(new FileUpload() { Name = file.FileName, Length = file.Length });
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
