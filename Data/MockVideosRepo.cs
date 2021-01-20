using System;
using System.Collections.Generic;
using ReactTube.Models;

namespace ReactTube.Data
{
    public class MockVideosRepo : IVideoRepo
    {
        public Video GetVideoById(int id)
        {
            if (id == 1)
            {
                return new Video
                { views = 25367, VideoId = new Guid("ba03c172-23b3-4a17-aca2-d1c22c198650"), UserId = 1, name = "Cool earth", path = "/videos/test/videofile.mp4", thumbnailPath = "/videos/test/thumb.jpg", desc = "hey guyz i found a cool video of earth! like and subscribe :)" };
            }
            else if (id == 2)
            {
                return new Video { views = 3, VideoId = new Guid("d1181bf7-1e25-4853-b4d9-34781a3a2345"), UserId = 2, name = "Videotitle", path = "/videos/test2/videofile.mp4", thumbnailPath = "/videos/test2/thumb.jpg" };
            }
            else
            {
                return new Video { views = 123, VideoId = new Guid("f6c6b91c-d9bc-40f1-b8af-b1239e9a2bd1"), UserId = 3, name = "haha funny rabbit", path = "/videos/test3/videofile.mp4", thumbnailPath = "/videos/test3/thumb.jpg", desc = "XDDD THIS DUDE AHAHAH YO GUYS THIS IS THE FUNNIEST VIDEO ON THE INTERNET THIS RABBIT DUDE JUST WALKS OUTTA HIS HOUSE AND STRETCHES JSUT LOOK AT THIS BIG CHUNGUS LOOKING DUDE AHAH" };
            }
        }

        public Video GetVideoByGuid(Guid id)
        {
            if (id == new Guid("ba03c172-23b3-4a17-aca2-d1c22c198650"))
            {
                return new Video { views = 25367, VideoId = new Guid("ba03c172-23b3-4a17-aca2-d1c22c198650"), UserId = 1, name = "Cool earth", path = "/videos/test/videofile.mp4", thumbnailPath = "/videos/test/thumb.jpg", desc = "hey guyz i found a cool video of earth! like and subscribe :)" };
            }
            else if (id == new Guid("d1181bf7-1e25-4853-b4d9-34781a3a2345"))
            {
                return new Video { views = 3, VideoId = new Guid("d1181bf7-1e25-4853-b4d9-34781a3a2345"), UserId = 2, name = "Videotitle", path = "/videos/test2/videofile.mp4", thumbnailPath = "/videos/test2/thumb.jpg" };
            }
            else
            {
                return new Video { views = 123, VideoId = new Guid("f6c6b91c-d9bc-40f1-b8af-b1239e9a2bd1"), UserId = 3, name = "haha funny rabbit", path = "/videos/test3/videofile.mp4", thumbnailPath = "/videos/test3/thumb.jpg", desc = "XDDD THIS DUDE AHAHAH YO GUYS THIS IS THE FUNNIEST VIDEO ON THE INTERNET THIS RABBIT DUDE JUST WALKS OUTTA HIS HOUSE AND STRETCHES JSUT LOOK AT THIS BIG CHUNGUS LOOKING DUDE AHAH" };
            }
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void CreateVideo(Video video)
        {
            throw new NotImplementedException();
        }
    }
}