using escolaNC.Modelo;
using System.Collections.Generic;

namespace escolaNC.Interfaces
{
    public interface IUsuariosService
    {

        public List<Usuario> RetornaUsuarios();
        public Usuario InsereUsuario(Usuario usuario);
        public Usuario AtualizaUsuario(Usuario usuario);

        public bool RemoveUsuario(string cpf);
        

    }
}
