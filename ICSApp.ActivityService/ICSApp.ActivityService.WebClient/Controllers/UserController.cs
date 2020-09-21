using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICSApp.ActivityService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICSApp.ActivityService.WebClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            service.IdUser = Guid.Parse(User.FindFirst("sub")?.Value);
            service.Name = User.Identity.Name;
            return Ok();
        }
    }
}
