using escolaNC.Modelos;
using System.Collections.Generic;

namespace escolaNC.Interfaces
{
    public interface IContratacaoService
    {

        public List<detalhes> RetornaContratados();
        public List<detalhes> ContratadoCpf(string cpf);
        public List<Servico> RetornaServicos();
        public bool ContrataServicos(List<Contratados> lista);

        public bool RemoverServico(int id);

    }
}
