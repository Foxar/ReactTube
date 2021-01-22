using System;
using System.Collections.Generic;
using System.Linq;
using ReactTube.Models;

namespace ReactTube.Data
{
    class SqlApplicationUserRepo : IApplicationUserRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlApplicationUserRepo(ApplicationDbContext context)
        {
            _context = context;

        }

        public void CreateApplicationUser(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            //Might not work yet, test out first something simpler
            _context.Users.Add(user);
        }

        public IEnumerable<ApplicationUser> GetApplicationUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetApplicationUserById(string id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}