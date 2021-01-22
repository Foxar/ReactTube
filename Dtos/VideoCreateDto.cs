using ReactTube.Models;

namespace ReactTube.Dtos
{
    public class VideoCreateDto
    {
        public string name { get; set; }
        public string desc { get; set; }
        //public ApplicationUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}