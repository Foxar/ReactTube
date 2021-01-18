using System.Collections.Generic;
using ReactTube.Models;

namespace ReactTube.Data
{
    public class MockUsersRepo : IUserRepo
    {
        public User GetUserById(int id)
        {
            if (id == 0)
                return new User { UserId = 0, name = "jake" };
            else if (id == 1)
                return new User { UserId = 1, name = "Sample user" };
            else
                return new User { UserId = 2, name = "xxx_rippen_xxx" };

        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}