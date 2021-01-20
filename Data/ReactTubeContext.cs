using Microsoft.EntityFrameworkCore;
using ReactTube.Models;

namespace ReactTube.Data
{
    //Deprecated? consider deleting this inf avor of applicationdbcontext
    public class ReactTubeContext : DbContext
    {
        public ReactTubeContext(DbContextOptions<ReactTubeContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}