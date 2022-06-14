using System.Collections.Generic;
using escolaNC.Modelos;

namespace escolaNC.Interfaces
{
    public interface IRelatorioService
    {

        public List<RelFaturamento> ServicosContratados();

        public string InadimplentesCpf(string cpf);
        public string Inadimplentes(string cpf);

    }
}
