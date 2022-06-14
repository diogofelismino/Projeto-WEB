using escolaNC.Data;
using escolaNC.excecoes;
using escolaNC.Interfaces;
using escolaNC.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace escolaNC.servicos
{
    public class ContratacaoService : IContratacaoService
    {


        private readonly EscolaContext _context;

        public ContratacaoService(EscolaContext context)
        {
            _context = context;
        }


        public List<detalhes> ContratadoCpf(string cpf)
        {

            if(!_context.USUARIOS.Any(u => u.cpf == cpf))
            {
                throw new Excecoe($"CPF {cpf} não encontrado");
            }

            List<detalhes> detalhe = new List<detalhes>();

            var consulta = from c in _context.SERVICOS_CONTRATADOS
                           join u in _context.USUARIOS
                           on c.cpf_usuario equals u.cpf
                           join s in _context.SERVICOS
                           on c.id_servico equals s.id
                           where c.cpf_usuario == cpf
                           select new
                           {
                               
                               u.nome,
                               u.cpf,
                               s.descricao,
                               s.preco,
                               c.dt_contratacao,
                               c.id_servicos_contratados
                           };


            foreach (var d in consulta)
            {
                detalhe.Add(new detalhes
                {
                    nome = d.nome,
                    cpf_usuario = d.cpf,
                    descricao = d.descricao,
                    preco = d.preco,
                    dt_contratacao = d.dt_contratacao,
                    id_servicos_contratados = d.id_servicos_contratados

                });
            }


            if (detalhe.Count == 0)
            {
                var cliente = _context.USUARIOS.FirstOrDefault(u => u.cpf == cpf);
                detalhe.Add(new detalhes
                {
                    nome = cliente.nome,
                    cpf_usuario = cliente.cpf,
                    descricao = "VAZIO"
                    
                });
            }
            
            return detalhe;


        }

        public bool ContrataServicos(List<Contratados> lista)
        {
            try
            {
                foreach(var contratado in lista)
                {
                    _context.SERVICOS_CONTRATADOS.Add(contratado);
                    
                }
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

               throw new Excecoe("Não foi possivel contratar o serviço");
            }
        }

        public bool RemoverServico(int id)
        {
            if (!_context.SERVICOS_CONTRATADOS.Any(u => u.id_servicos_contratados == id))
                throw new Excecoe("contrato não encontrado no banco de dados");
            try
            {
                var contrato = _context.SERVICOS_CONTRATADOS.Find(id);
                _context.SERVICOS_CONTRATADOS.Remove(contrato);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw new Excecoe($"Não foi possível remover o usuário de cpf:  da base de dados");
            }
        }

        public List<detalhes> RetornaContratados()
        {
            
            List<detalhes> detalhe = new List<detalhes>();

            var consulta = from c in _context.SERVICOS_CONTRATADOS
                           join u in _context.USUARIOS
                           on c.cpf_usuario equals u.cpf
                           join s in _context.SERVICOS
                           on c.id_servico equals s.id
                           select new
                           {
                               u.nome,
                               u.cpf,
                               s.descricao,
                               s.preco,
                               c.dt_contratacao
                           };

            foreach(var d in consulta)
            {
                detalhe.Add(new detalhes
                {
                    nome = d.nome,
                    cpf_usuario = d.cpf,
                    descricao = d.descricao,
                    preco = d.preco,    
                    dt_contratacao = d.dt_contratacao
                });
            }

            return detalhe;

        }


        public List<Servico> RetornaServicos()
        {


            return _context.SERVICOS.ToList();
        }
    }
}
