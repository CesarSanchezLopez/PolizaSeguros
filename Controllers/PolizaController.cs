using ApiPolizaSeguros.Models;
using ApiPolizaSeguros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ExceptionServices;

namespace ApiPolizaSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PolizaController : ControllerBase
    {
        public PolizaService _polizaService { get; set; }

        public PolizaController(PolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpGet(Name = "GetPolizas")]
        public ActionResult<List<Poliza>> Get()
        {
            return _polizaService.Get();
        }

        //[HttpGet(("{placaAuto}"))]
        [HttpGet]
        [Route("GetPlaca/{placaAuto}")]
        public ActionResult<List<Poliza>> GetPlaca(string placaAuto)
        {
            return _polizaService.GetPlaca(placaAuto);
        }

        //[HttpGet(("{nrPoliza}"))]
        [HttpGet]
        [Route("GetNoPoliza/{nrPoliza}")]
        public ActionResult<List<Poliza>> GetNoPoliza(int nrPoliza)
        {
            return _polizaService.GetNoPoliza(nrPoliza);
        }

        [HttpPost]
        public ActionResult<Poliza> Create(Poliza poliza)
        {
            _polizaService.Create(poliza);
            return Ok(poliza);
        }
        [HttpPut]
        public ActionResult Update(Poliza poliza)
        {
            _polizaService.Update(poliza.Id, poliza);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(string  id)
        {
            _polizaService.Delete(id);
            return Ok();
        }
    }
}
