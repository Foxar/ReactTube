using Microsoft.AspNetCore.Http;

namespace ReactTube.Dtos
{
    public class VideoFileUploadDto
    {
        public IFormFile file { get; set; }
        public string path { get; set; }
    }
}