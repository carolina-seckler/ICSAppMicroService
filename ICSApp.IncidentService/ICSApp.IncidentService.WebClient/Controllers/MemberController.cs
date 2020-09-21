using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;

namespace ICSApp.IncidentService.WebClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMemberService service;

        public MemberController(ILogger<MemberController> logger, IHttpClientFactory httpClientFactory, IMemberService service)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var all = service.GetAll();

            if (!all.Any())
                return new NotFoundObjectResult("Nenhum item encontrado.");

            return Ok(all);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var obj = service.GetById(id);

            if (obj == null)
                return new NotFoundObjectResult("Nenhum item encontrado.");

            return Ok(obj);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] MemberModel model)
        {
            model.IdUser = Guid.Parse(User.FindFirst("sub")?.Value);
            var notifications = service.Insert(model);
            if (notifications != null)
                return BadRequest(notifications);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] MemberModel model)
        {
            var notifications = service.Update(model);
            if (notifications != null)
                return BadRequest(notifications);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }

        [HttpGet("section")]
        public IActionResult GetSection()
        {
            var client = httpClientFactory.CreateClient("Activity Microservice");
            var result = client.GetAsync(client.BaseAddress + "section").Result;
            if (!result.IsSuccessStatusCode)
                throw new System.Exception("");

            return Ok(result.Content.ReadAsStringAsync().Result);
        }

        [HttpGet("incident/{id}")]
        public IActionResult GetByIncident(int id)
        {
            var all = service.GetByIncident(id);

            if (!all.Any())
                return new NotFoundObjectResult("Nenhum item encontrado.");

            return Ok(all);
        }
    }
}
