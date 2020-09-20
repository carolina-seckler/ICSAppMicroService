using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;

namespace ICSApp.IncidentService.WebClient.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly ILogger<IncidentController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IIncidentService service;

        public IncidentController(ILogger<IncidentController> logger, IHttpClientFactory httpClientFactory, IIncidentService service)
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
        public IActionResult Insert([FromBody] IncidentModel model) 
        {
            var notifications = service.Insert(model);
            if (notifications != null)
                return BadRequest(notifications);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] IncidentModel model) 
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

        [HttpGet("activity")]
        public IActionResult GetActivity()
        {
            var client = httpClientFactory.CreateClient("Activity Microservice");
            var result = client.GetAsync(client.BaseAddress + "Activity/helloworld").Result;
            if (!result.IsSuccessStatusCode)
                throw new System.Exception("");

            return Ok(result.Content.ReadAsStringAsync().Result);
        }
    }
}
