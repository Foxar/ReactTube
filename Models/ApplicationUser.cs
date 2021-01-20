using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace ReactTube.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Video> Videos { get; set; }
    }
}