using System.Linq;
using ReactTube.Models;

namespace ReactTube.Data
{
    class SqlUsersRepo : IUserRepo
    {
        private readonly ReactTubeContext _context;

        public SqlUsersRepo(ReactTubeContext context)
        {
            _context = context;

        }
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.UserId == id);
        }

        public bool ValidateUserPassword(int id, string password)
        {
            User _user = _context.Users.FirstOrDefault(p => p.UserId == id);
            if (_user.temppassword == password)
                return true;
            else
                return false;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}