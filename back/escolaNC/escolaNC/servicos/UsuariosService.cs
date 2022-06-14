using escolaNC.Data;
using escolaNC.excecoes;
using escolaNC.Interfaces;
using escolaNC.Modelo;
using System.Collections.Generic;
using System.Linq;

namespace escolaNC.servicos
{
    public class UsuariosService : IUsuariosService
    {

        private EscolaContext _context;

        public UsuariosService(EscolaContext context)
        {
            _context = context;
        }

        public Usuario AtualizaUsuario(Usuario usuario)
        {

            if (!_context.USUARIOS.Any(u => u.cpf == usuario.cpf))
                throw new Excecoe("Usuário não encontrado no banco de dados");
            try
            {
                _context.USUARIOS.Update(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (System.Exception)
            {

                throw new Excecoe("Não foi possível atualizar o usuário na base de dados");
            }
        }

        public Usuario InsereUsuario(Usuario usuario)
        {
            try
            {
                _context.USUARIOS.Add(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (System.Exception)
            {
                throw new Excecoe($"O usuário com CPF {usuario.cpf} já existe na base de dados ");
            }
        }

        public bool RemoveUsuario(string cpf)
        {
            if (!_context.USUARIOS.Any(u => u.cpf == cpf))
                throw new Excecoe("Usuário não encontrado no banco de dados");
            try
            {
                var usuario = _context.USUARIOS.Find(cpf);
                _context.USUARIOS.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                
                throw new Excecoe($"Não foi possível remover o usuário de cpf: {cpf} da base de dados");
            }
        }

        public List<Usuario> RetornaUsuarios()
        {
            try
            {
                return _context.USUARIOS.ToList();
            }
            catch (System.Exception)
            {
                throw new Excecoe("return _context.USUARIOS.ToList();");
            }
        }
    }
}
