using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            _context.Videos.Add(video);
        }

        public Video GetVideoByGuid(Guid guid)
        {
            //return _context.Videos.FirstOrDefault(p => p.VideoId == guid);
            return _context.Videos
                    .Include(vid => vid.AppUser)
                    .FirstOrDefault(p => p.VideoId == guid);
        }

        public Video GetVideoById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Video> GetRandomVideos(int count)
        {
            return (_context.Videos.OrderBy(r => Guid.NewGuid()).Take(count).ToList());
        }

        public bool SaveChanges()
        {
            Console.WriteLine("Saving changes.");
            return (_context.SaveChanges() >= 0);
        }
    }
}