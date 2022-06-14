using escolaNC.Interfaces;
using escolaNC.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace escolaNC.Controllers
{
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost, Route("login")]
        public IActionResult acessaConta([FromBody] Login login)
        {
            try
            {
                return Ok(_loginService.acessarConta(login));
            }
            catch (System.Exception r)
            {

                return BadRequest(r.Message);
            }
        }


        [HttpPost, Route("cadastro")]
        public IActionResult criaConta([FromBody] Login lista)
        {
            try
            {
                return Ok(_loginService.criarConta(lista));
            }
            catch (System.Exception r)
            {

                return BadRequest(r.Message);
            }
        }


    }
}
