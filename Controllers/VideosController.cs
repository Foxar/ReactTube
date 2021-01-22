using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ReactTube.Data;
using ReactTube.Dtos;
using ReactTube.Models;

namespace ReactTube.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/v1/videos")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoRepo _videorepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public VideosController(IVideoRepo videoRepo, IMapper mapper, IWebHostEnvironment env)
        {
            _videorepo = videoRepo;
            _mapper = mapper;
            _env = env;

        }

        //Create video
        [HttpPost]
        public ActionResult<VideoReadDto> CreateVideo([FromForm] VideoCreateDto videoCreateDto)
        {
            var videoModel = _mapper.Map<Video>(videoCreateDto);
            videoModel.Initialize();
            Console.WriteLine("Creating video...");
            _videorepo.CreateVideo(videoModel);
            if (_videorepo.SaveChanges())
                Console.Write("Successfully updated.");
            else
                Console.Write("Failed to update.");
            return Ok(videoModel);
        }

        [HttpGet]
        public ActionResult<IEnumerable<VideoReadDto>> GetVideos()
        {
            IEnumerable<Video> videoList = _videorepo.GetRandomVideos(10);
            List<VideoReadDto> videoDtoList = new List<VideoReadDto>();
            foreach (Video v in videoList)
            {
                //Weird bug here, investigate later
                var videoDto = _mapper.Map<VideoReadDto>(v);
                Console.WriteLine("VideoDto authorname0:");
                Console.WriteLine(videoDto.AuthorName);
                videoDto.id = GuidToBase64(v.VideoId);
                if (System.IO.File.Exists(_env.ContentRootPath + "/Javascript/react-tube-app/public" + (videoDto.path)))
                    videoDtoList.Add(videoDto);
                Console.WriteLine("VideoDto authorname:");
                Console.WriteLine(videoDto.AuthorName);
            }

            return Ok(videoDtoList);
        }

        //Get video by base64
        [HttpGet("{id}", Name = "GetVideoByBase64")]
        public ActionResult<VideoReadDto> GetVideoByBase64(string id)
        {
            id.ToLower();
            //Conversion of base64 to Guid
            Guid guid = Base64ToGuid(id);


            var videoitem = _videorepo.GetVideoByGuid(guid);
            if (videoitem == null)
            {
                Console.WriteLine("Video " + id + " not found!");
                return NotFound();
            }
            else
            {

                var mapped = _mapper.Map<VideoReadDto>(videoitem);
                Console.WriteLine("VideoDto authorname:");
                Console.WriteLine(mapped.AuthorName);

                return Ok(mapped);
            }

        }
        /*public ActionResult<Video> GetVideoByBase64(string id)
        {
            //Conversion of base64 to Guid
            Guid guid = Base64ToGuid(id);

            var videoitem = _videorepo.GetVideoByGuid(guid);
            return Ok(videoitem);
        }*/

        //Get video by guid
        //[HttpGet("{id}", Name = "GetVideoByGuid")]
        public ActionResult<Video> GetVideoByGuid(Guid id)
        {
            //Conversion of base64 to Guid

            var videoitem = _videorepo.GetVideoByGuid(id);
            return Ok(videoitem);
        }

        //Get video by id
        //[HttpGet("{id}", Name = "GetVideoById")]
        public ActionResult<Video> GetVideoById(int id)
        {
            var videoitem = _videorepo.GetVideoById(id);
            return Ok(videoitem);
        }

        public string GuidToBase64(Guid id)
        {
            return Convert.ToBase64String(id.ToByteArray()).Replace("/", "-").Replace("+", "_").Replace("=", "");
        }

        public Guid Base64ToGuid(string id)
        {
            id = id.Replace("-", "/").Replace("_", "+") + "==";
            Guid guid = default(Guid);
            try
            {
                guid = new Guid(Convert.FromBase64String(id));
            }
            catch (Exception ex)
            {
                throw new Exception("Bad Base64 conversion to GUID", ex);
            }
            return guid;

        }


    }
}