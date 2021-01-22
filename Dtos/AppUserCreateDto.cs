using ReactTube.Models;

namespace ReactTube.Dtos
{
    public class AppUserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}