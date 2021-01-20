using System.Collections.Generic;
using ReactTube.Models;

namespace ReactTube.Data
{
    public interface IApplicationUserRepo
    {
        bool SaveChanges();

        //IEnumerable<Video> GetAllCommands();
        ApplicationUser GetApplicationUserById(string id);
        void CreateApplicationUser(ApplicationUser user);
        //void CreateCommand(Command cmd);
        //void UpdateCommand(Command cmd);
        //void DeleteCommand(Command cmd);

    }
}