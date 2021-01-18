using System;
using System.Linq;
using ReactTube.Models;

namespace ReactTube.Data
{
    class SqlVideosRepo : IVideoRepo
    {
        private readonly ReactTubeContext _context;

        public SqlVideosRepo(ReactTubeContext context)
        {
            _context = context;

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