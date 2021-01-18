using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReactTube.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(255)]
        public string name { get; set; }
        [Required]
        [MaxLength(64)]
        public string temppassword { get; set; }
        public string passwordHash { get; set; }
        public List<Video> Videos { get; set; }

    }
}