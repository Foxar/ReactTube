using Microsoft.EntityFrameworkCore;
using ReactTube.Models;

namespace ReactTube.Data
{
    public class ReactTubeContext : DbContext
    {
        public ReactTubeContext(DbContextOptions<ReactTubeContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}