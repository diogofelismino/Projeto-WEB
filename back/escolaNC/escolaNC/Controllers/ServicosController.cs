using escolaNC.Interfaces;
using escolaNC.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace escolaNC.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServicosController : ControllerBase

    {

        

        private readonly IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {

            _servicoService = servicoService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_servicoService.RetornaServico());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPost, Route("inserir")]
        public IActionResult InserirUsuario([FromBody] Servico servico)
        {
            try
            {
                return Ok(_servicoService.InsereServico(servico));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost, Route("atualizar")]
        public IActionResult AtualizarUsuario([FromBody] Servico servico)
        {
            try
            {
                return Ok(_servicoService.AtualizaServico(servico));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUsuario(int id)
        {
            try
            {
                return Ok(_servicoService.RemoveServico(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }





    }
}
