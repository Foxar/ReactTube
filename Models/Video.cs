using System;
using System.ComponentModel.DataAnnotations;

namespace ReactTube.Models
{
    public class Video
    {
        [Key]
        public Guid VideoId { get; set; }
        //public int VideoId { get; set; }
        [Required]
        [MaxLength(255)]
        public string name { get; set; }
        [MaxLength(1024)]
        public string desc { get; set; }
        [Required]
        [MaxLength(255)]
        public string path { get; set; }

        public int views { get; set; }
        [MaxLength(255)]
        public string thumbnailPath { get; set; }
        [Required]
        //public int UserId { get; set; }
        public string UserId { get; set; }
        [Required]
        public ApplicationUser AppUser { get; set; }
        [Required]
        public int Likes { get; set; }
        [Required]
        public int Dislikes { get; set; }
        public void Initialize()
        {
            this.Likes = 0;
            this.Dislikes = 0;
            this.UserId = "test";
            GeneratePath();
        }
        public void GeneratePath()
        {
            this.path = "/videos/" + this.AppUser.Id + "/"
            + DateTime.Now.ToString("s").Replace("-", "").Replace(":", "")
            + "/videofile.mp4";
        }

    }
}