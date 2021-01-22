using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactTube.Data;
using ReactTube.Dtos;

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

        /*
        Before uploading a videofile ensure you've created a row in the video database, including a generated
        filepath to the video in question, specifying it in the body. Body requires file and path parameters.
        */
        [HttpPost]
        public async Task<ActionResult> UploadVideoFile([FromForm] VideoFileUploadDto fileUploadDto)
        {
            if (fileUploadDto == null || fileUploadDto.file == null)
                return BadRequest("No file uploaded.");
            if (fileUploadDto.path == null)
                return BadRequest("No filepath provided");


            var pathToVideofolder = _env.ContentRootPath + "/Javascript/react-tube-app/public";
            var filePath = pathToVideofolder + fileUploadDto.path;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            Console.WriteLine("Model-Generated path:" + filePath);

            //What's this do? Look it up
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileUploadDto.file.CopyToAsync(stream);
            }

            return Ok(new { fileLength = fileUploadDto.file.Length, filePath });
        }
    }
}