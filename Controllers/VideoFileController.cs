using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactTube.Data;

namespace ReactTube.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/v1/videofile")]
    [ApiController]
    public class VideoFileController : ControllerBase
    {

        private readonly IVideoRepo _repo;
        private readonly IWebHostEnvironment _env;
        private readonly string _projectRootPath;
        public VideoFileController(IVideoRepo repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }
        [HttpGet]
        public ActionResult Test()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> UploadVideoFile(IFormFile file)
        {
            var pathToVideoFolder = _env.ContentRootPath + "/Javascript/react-tube-app/public/videos/" + "asdf";
            Directory.CreateDirectory(pathToVideoFolder);
            var filePath = pathToVideoFolder + "/" + Path.GetFileName(file.FileName);
            Console.WriteLine(filePath);

            if (file.Length > 0)
            {
                //What's this do? Look it up
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }


            return Ok(new { fileLength = file.Length, filePath });
        }
    }
}