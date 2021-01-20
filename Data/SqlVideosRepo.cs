using System;
using System.Linq;
using ReactTube.Models;

namespace ReactTube.Data
{
    class SqlVideosRepo : IVideoRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlVideosRepo(ApplicationDbContext context)
        {
            _context = context;

        }

        public void CreateVideo(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video));
            }
            _context.Add(video);
        }

        public Video GetVideoByGuid(Guid guid)
        {
            return _context.Videos.FirstOrDefault(p => p.VideoId == guid);
        }

        public Video GetVideoById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}