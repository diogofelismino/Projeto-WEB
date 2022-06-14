using escolaNC.excecoes;
using escolaNC.Interfaces;
using escolaNC.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace escolaNC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratacaoController : ControllerBase
    {

        private readonly IContratacaoService _contratacaoService;

        public ContratacaoController(IContratacaoService contratacaoService)
        {
            _contratacaoService = contratacaoService;
        }

        [HttpGet, Route("contratados")]
        public IActionResult RetornaContratados()
        {

            try
            {
                return Ok(_contratacaoService.RetornaContratados());
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("{cpf}")]
        public IActionResult ContratadoCpf(string cpf)
        {
            try
            {
                return Ok(_contratacaoService.ContratadoCpf(cpf));
            }
            catch (System.Exception e )
            {

               return BadRequest(e.Message);
            }
           
        }


        [HttpGet, Route("servicos")]
        public IActionResult RetornarServicos()
        {
            try
            {
                return Ok(_contratacaoService.RetornaServicos());
            }
            catch (System.Exception e )
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult ContratarServico([FromBody] List<Contratados> lista)
        {
            try
            {
                return Ok(_contratacaoService.ContrataServicos(lista));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult RemoverServico(int id)
        {
            try
            {
                return Ok(_contratacaoService.RemoverServico(id));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }



    }
}
