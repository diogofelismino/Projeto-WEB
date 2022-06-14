using escolaNC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace escolaNC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosController : ControllerBase
    {

        private readonly IRelatorioService _relService;

        public RelatoriosController(IRelatorioService relService)
        {
            _relService = relService;
        }


        [HttpGet, Route("faturamento")]
        public IActionResult Faturamento()
        {
            return Ok(_relService.ServicosContratados());
        }

        [HttpGet, Route("inadimplentes/{cpf=}")]
        public IActionResult InadiplentesCpf(string cpf)
        {
            return Ok(_relService.InadimplentesCpf(cpf));
        }

        //[HttpGet, Route("inadimplentes/")]
        //public IActionResult Inadiplentes(string cpf)
        //{
        //    return Ok(_relService.InadimplentesCpf(cpf));
        //}



    }
}
