using escolaNC.Modelos;
using System.Collections.Generic;

namespace escolaNC.Interfaces
{
    public interface IServicoService
    {

        public List<Servico> RetornaServico();
        public Servico InsereServico(Servico servico);
        public Servico AtualizaServico(Servico servico);

        public bool RemoveServico(int id);


    }
}
