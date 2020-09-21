using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;

namespace ICSApp.IncidentService.WebClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FunctionController : ControllerBase
    {
        private readonly ILogger<FunctionController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IFunctionService service;

        public FunctionController(ILogger<FunctionController> logger, IHttpClientFactory httpClientFactory, IFunctionService service)
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
        public IActionResult Insert([FromBody] FunctionModel model)
        {
            service.Insert(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] FunctionModel model)
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
