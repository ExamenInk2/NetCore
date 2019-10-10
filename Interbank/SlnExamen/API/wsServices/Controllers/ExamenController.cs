using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlnExamen.Domain;
using SlnExamen.Beans;

namespace wsServices.Controllers
{
    [Route("Examen/")]
    [ApiController]
    [Produces("application/json")]
    public class ExamenController : ControllerBase
    {
        private readonly IUnitOfWork services;
        public ExamenController(IUnitOfWork _services)
        {
            this.services = _services;
        }

        [HttpPost]
        [Route("creacliente/")]
        public IActionResult Listar([FromBody] BeansPersonaR oData)
        {
            return Ok(services.PersonaDomain.InsPersonaDomain(oData));
        }

        [HttpGet]
        [Route("listclientes/")]
        public IActionResult Listar()
        {
            return Ok(services.PersonaDomain.GetListPersonaDomain());
        }

        [HttpGet]
        [Route("kpideclientes/")]
        public IActionResult KPI()
        {
            return Ok(services.PersonaDomain.GetKPIDomain());
        }
    }
}