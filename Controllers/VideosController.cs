using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
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
        public VideosController(IVideoRepo videoRepo, IMapper mapper)
        {
            _videorepo = videoRepo;
            _mapper = mapper;

        }

        //Create video
        [HttpPost]
        public ActionResult<VideoReadDto> CreateVideo(VideoCreateDto videoCreateDto)
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
            return Ok(_videorepo.GetRandomVideos(10));
        }

        //Get video by base64
        [HttpGet("{id}", Name = "GetVideoByBase64")]
        public ActionResult<VideoReadDto> GetVideoByBase64(string id)
        {
            //Conversion of base64 to Guid
            Guid guid = Base64ToGuid(id);


            var videoitem = _videorepo.GetVideoByGuid(guid);
            if (videoitem == null)
            {
                return NotFound();
            }
            else
            {

                var mapped = _mapper.Map<VideoReadDto>(videoitem);

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