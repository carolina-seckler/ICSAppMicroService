using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using ICSApp.IncidentService.Notification.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;
using System;

namespace ICSApp.IncidentService.WebClient.Controllers
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
            return Ok(new {service.Name});
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignIn([FromBody]UserLoginModel model)
        {
            var result = service.SignIn(model.Name, model.Password);
            if (result == null)
            {
                return BadRequest("Usuário ou senha inválida, digite novamente!");
            }
            return Ok(new AccessToken
            {
                Access_Token = result,
                Created = ToUnixEpochDate(DateTime.Now),
                Expires_In = 3600,
                Token_Type = "Bearer"
            });
        }

        static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() -
                           new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                          .TotalSeconds);

        public class AccessToken
        {
            public long Created { get; set; }
            public long Expires_In { get; set; }
            [JsonProperty("access_token")]
            public string Access_Token { get; set; }
            public string Token_Type { get; set; }
        }
    }
}
