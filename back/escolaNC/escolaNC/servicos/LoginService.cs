using escolaNC.Data;
using escolaNC.excecoes;
using escolaNC.Interfaces;
using escolaNC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace escolaNC.servicos
{
    public class LoginService : ILoginService
    {


        private readonly EscolaContext _context;

        public LoginService(EscolaContext context)
        {
            _context = context;
        }



        public bool acessarConta(Login login)
        {
            try
            {







                login.hash_senha = criptografa(login.hash_senha);
                string cfSenha = "";

                var consulta = from l in _context.USER_LOGIN
                               where l.cpf == login.cpf
                               select new
                               {
                                   l.hash_senha
                               };

                foreach (var d in consulta)
                {

                    cfSenha = d.hash_senha;


                }


                    if (cfSenha != login.hash_senha)
                {
                    throw new Exception("Cpf ou senha invalidas.");
                }
                return true;




            }
            catch (Exception)
            {

                throw new Exception("Cpf ou senha invalidas.");
            }
        }

        public bool criarConta(Login lista)
        {

           


            try
            {

                //bool nome = lista.nome == null || lista.nome == "";
                //bool cpf = lista.cpf == null || lista.cpf == "";
                //bool senha = lista.hash_senha == null || lista.hash_senha == "";
                

                 if (_context.USER_LOGIN.Any(u => u.cpf == lista.cpf))
                    throw new Exception("Cpf ja possui uma conta");


          

                lista.hash_senha = criptografa(lista.hash_senha);
                 _context.USER_LOGIN.Add(lista);
                   
               
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw new Excecoe("Erro ao tentar ao tentar criar conta");
            }
        }

        public string criptografa(string senha)
        {

            var _senha = "";

            try
            {
                UnicodeEncoding _encod = new UnicodeEncoding();
                byte[] _hashBytes, _menssagemByte = _encod.GetBytes(senha);

                SHA256Managed sHA256Managed = new SHA256Managed();

                _hashBytes = sHA256Managed.ComputeHash(_menssagemByte);

                foreach (byte b in _hashBytes)
                {
                    _senha += string.Format("{0:x2}", b);
                }


            }
            catch (System.Exception)
            {

                throw new Excecoe("Erro eu fazer criptografia");
            }



            return _senha;
        }



    }



      

    
}
