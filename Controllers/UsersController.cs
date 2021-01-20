using System.Threading;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactTube.Data;
using ReactTube.Models;

namespace ReactTube.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userrepo;
        public UsersController(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }



        //[HttpGet("{id}")]
        [HttpGet("{id}", Name = "GetUserById")]
        //[HttpGet]
        public ActionResult<User> GetUserById(int id)
        {
            var useritem = _userrepo.GetUserById(id);
            return Ok(useritem);
        }






    }
}