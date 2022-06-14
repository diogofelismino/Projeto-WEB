using escolaNC.Modelos;
using System.Collections.Generic;

namespace escolaNC.Interfaces
{
    public interface ILoginService
    {

        public bool acessarConta(Login login);

        public bool criarConta(Login lista);
    }
}
