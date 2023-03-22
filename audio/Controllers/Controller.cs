using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace audio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Controller(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("[action]")]
        public IActionResult uploadfiles(List<IFormFile>files)
        {
            if (files.Count == 0)
                return BadRequest();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "uploadfiles");
            foreach(var file in files)
            {
                string filepath = Path.Combine(directoryPath, file.FileName);
                using(var stream =new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Ok("upload successfully");
        }
    }
}
