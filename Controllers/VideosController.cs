using System;
using System.Threading;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactTube.Data;
using ReactTube.Models;

namespace ReactTube.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/v1/videos")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoRepo _videorepo;
        public VideosController(IVideoRepo videoRepo)
        {
            _videorepo = videoRepo;

        }

        //Create video
        //public ActionResult<OkResult> CreateVideo(Video)

        //Get video by base64
        [HttpGet("{id}", Name = "GetVideoByBase64")]
        public ActionResult<Video> GetVideoByBase64(string id)
        {
            //Conversion of base64 to Guid
            Guid guid = Base64ToGuid(id);

            var videoitem = _videorepo.GetVideoByGuid(guid);
            return Ok(videoitem);
        }

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