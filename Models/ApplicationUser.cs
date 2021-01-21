using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace ReactTube.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Video> Videos { get; set; }
        public void HashPassword(string plaintext)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var hashed = hasher.HashPassword(this, plaintext);
            this.PasswordHash = hashed;


        }
    }
}