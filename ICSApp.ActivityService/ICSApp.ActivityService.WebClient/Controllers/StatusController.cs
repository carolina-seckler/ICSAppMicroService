using ICSApp.ActivityService.Application.Interfaces;
using ICSApp.ActivityService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;

namespace ICSApp.ActivityService.WebClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IStatusService service;

        public StatusController(ILogger<StatusController> logger, IHttpClientFactory httpClientFactory, IStatusService service)
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
        public IActionResult Insert([FromBody] StatusModel model)
        {
            service.Insert(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] StatusModel model)
        {
            service.Update(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
