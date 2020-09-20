using ICSApp.IncidentService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ICSApp.IncidentService.WebClient.Controllers
{
    [Authorize]
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
