using escolaNC.Interfaces;
using escolaNC.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escolaNC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuariosService _usuariosService;
        

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuariosService.RetornaUsuarios());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }

        [HttpPost, Route("inserir")]
        public IActionResult InserirUsuario([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(_usuariosService.InsereUsuario(usuario));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost, Route("atualizar")]
        public IActionResult AtualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(_usuariosService.AtualizaUsuario(usuario));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{cpf}")]
        public IActionResult RemoveUsuario(String cpf)
        {
            try
            {
                return Ok(_usuariosService.RemoveUsuario(cpf));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
