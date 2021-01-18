using System.Collections.Generic;
using ReactTube.Models;

namespace ReactTube.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();

        //IEnumerable<Video> GetAllCommands();
        User GetUserById(int id);
        //void CreateCommand(Command cmd);
        //void UpdateCommand(Command cmd);
        //void DeleteCommand(Command cmd);

    }
}