using escolaNC.Data;
using escolaNC.excecoes;
using escolaNC.Interfaces;
using escolaNC.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace escolaNC.servicos
{
    public class ServicoService : IServicoService
    {

        private EscolaContext _context;

        public ServicoService(EscolaContext context)
        {
            _context = context;
        }

        public Servico AtualizaServico(Servico servico)
        {

            if (!_context.SERVICOS.Any(u => u.id == servico.id))
                throw new Excecoe("Serviço não encontrado no banco de dados ");

            try
            {
                _context.SERVICOS.Update(servico);
                _context.SaveChanges();
                return servico;

            }
            catch (System.Exception)
            {

                throw new  Excecoe($"Não foi possivel alterar o serviço: {servico}");
            }


        }

        public Servico InsereServico(Servico servico)
        {
            try
            {
                
                _context.SERVICOS.Add(servico);
                _context.SaveChanges();
                return servico;
            }
            catch (System.Exception)
            {
                throw new Excecoe($"O usuário com SERICOS {servico.descricao} já existe na base de dados ");
            }
        }

        public bool RemoveServico(int id)
        {
            if (!_context.SERVICOS.Any(u => u.id == id))
                throw new Excecoe("Serviço não encontrado no banco de dados ");
            try
            {

                var servico = _context.SERVICOS.Find(id);
                _context.SERVICOS.Remove(servico);
                _context.SaveChanges();
                return true;

            }
            catch (System.Exception)
            {

                throw new Excecoe($"Não possivel remover o servico: {id}");
            }
        }

        public List<Servico> RetornaServico()
        {
            try
            {
                return _context.SERVICOS.ToList();
            }
            catch (System.Exception)
            {
                throw new Excecoe("return _context.SERVICOS.ToList();");
            }
        }
    }
}
