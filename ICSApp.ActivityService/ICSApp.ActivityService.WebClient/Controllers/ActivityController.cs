using ICSApp.ActivityService.Application.Interfaces;
using ICSApp.ActivityService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ICSApp.ActivityService.WebClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IActivityService service;

        public ActivityController(ILogger<ActivityController> logger, IHttpClientFactory httpClientFactory, IActivityService service)
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
        public IActionResult GetById(int id) => Ok(service.GetById(id));

        [HttpPost]
        public IActionResult Insert([FromBody] ActivityModel model)
        {
            var notifications = service.Insert(model);
            if (notifications != null)
                return BadRequest(notifications);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ActivityModel model)
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

        [HttpGet("incident")]
        public IActionResult GetIncident()
        {
            var client = httpClientFactory.CreateClient("Incident Microservice");
            var result = client.GetAsync(client.BaseAddress + "Incident").Result;
            if (!result.IsSuccessStatusCode)
                throw new Exception("");

            return Ok(result);
        }

        [HttpGet("incident/{id}")]
        public IActionResult GetByIncident(int id)
        {
            var all = service.GetByIncident(id);

            if (!all.Any())
                return new NotFoundObjectResult("Nenhum item encontrado.");

            return Ok(all);
        }

        [HttpPost("section/{id}")]
        public IActionResult FilterBySection([FromBody] IEnumerable<ActivityModel> models, int id)
        {
            var all = service.FilterBySection(models, id);

            if (!all.Any())
                return new NotFoundObjectResult("Nenhum item encontrado.");

            return Ok(all);
        }

        [HttpPost("status/{id}")]
        public IActionResult FilterByStatus([FromBody] IEnumerable<ActivityModel> models, int id)
        {
            var all = service.FilterByStatus(models, id);

            if (!all.Any())
                return new NotFoundObjectResult("Nenhum item encontrado.");

            return Ok(all);
        }

        [HttpPut("{id}")]
        public IActionResult CloseActivity(int id)
        {
            service.CloseActivity(id);
            return Ok();
        }
    }
}
