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
    [Route("api/v1/appusers")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IApplicationUserRepo _userrepo;
        private readonly IMapper _mapper;
        public AppUsersController(IApplicationUserRepo userrepo, IMapper mapper)
        {
            _userrepo = userrepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ApplicationUser>> GetAllAppUsers()
        {
            return Ok(_userrepo.GetApplicationUsers());
        }

        //[HttpGet("{id}")]
        [HttpGet("{id}", Name = "GetAppUserById")]
        //[HttpGet]
        public ActionResult<ApplicationUser> GetAppUserById(string id)
        {
            var useritem = _userrepo.GetApplicationUserById(id);
            return Ok(useritem);
        }

        [HttpPost]
        public ActionResult<AppUserReadDto> CreateAppUser(AppUserCreateDto appUserCreateDto)
        {
            var appUserModel = _mapper.Map<ApplicationUser>(appUserCreateDto);
            appUserModel.HashPassword(appUserCreateDto.Password);
            _userrepo.CreateApplicationUser(appUserModel);
            return Ok(appUserModel);
        }

    }
}