using ReactTube.Models;

namespace ReactTube.Dtos
{
    public class VideoReadDto
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string path { get; set; }
        public string thumbnailPath { get; set; }
        public int views { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public string AuthorName { get; set; }
        public string id { get; set; }
    }
}