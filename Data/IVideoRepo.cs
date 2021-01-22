using System;
using System.Collections.Generic;
using ReactTube.Models;

namespace ReactTube.Data
{
    public interface IVideoRepo
    {
        bool SaveChanges();

        //IEnumerable<Video> GetAllCommands();
        Video GetVideoById(int id);
        Video GetVideoByGuid(Guid id);
        IEnumerable<Video> GetRandomVideos(int count);
        void CreateVideo(Video video);
        //void CreateCommand(Command cmd);
        //void UpdateCommand(Command cmd);
        //void DeleteCommand(Command cmd);

    }
}