using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace ReactTube.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public User UserProfile { get; set; }
    }
}