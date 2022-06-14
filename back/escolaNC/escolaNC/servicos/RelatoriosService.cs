using escolaNC.Interfaces;
using escolaNC.Modelos;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace escolaNC.servicos
{
    public class RelatoriosService : IRelatorioService
    {

        private readonly IAcessoBD _acesso;

        public RelatoriosService(IAcessoBD acesso)
        {
            _acesso = acesso;
        }

        public string Inadimplentes(string cpf)
        {


            SqlParameter Parametros = new SqlParameter();
            Parametros.ParameterName = "@CPF";
            Parametros.Value = cpf;
            Parametros.SqlDbType = SqlDbType.NVarChar;

            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(cpf))
                dt = _acesso.ExecutaProc("dbo.RETORNA_INADIMPLENTES");
            else
                dt = _acesso.ExecutaProc("dbo.RETORNA_INADIMPLENTES", Parametros);

            string JSONString = string.Empty;

            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }

        public string InadimplentesCpf(string cpf)
        {
            SqlParameter Parametros = new SqlParameter();
            Parametros.ParameterName = "@CPF";
            Parametros.Value = cpf;
            Parametros.SqlDbType = SqlDbType.NVarChar;

            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(cpf))
                dt = _acesso.ExecutaProc("dbo.RETORNA_INADIMPLENTES");
            else
                dt = _acesso.ExecutaProc("dbo.RETORNA_INADIMPLENTES", Parametros);

            string JSONString = string.Empty;

            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }

        public List<RelFaturamento> ServicosContratados()
        {
            var retorno = new List<RelFaturamento>();

            DataTable dt = _acesso.ExecutaProc("dbo.REL_SERVICOS_CONTRATADOS");

            foreach (DataRow r in dt.Rows)
            {
                retorno.Add(new RelFaturamento
                {
                    ID_SERVICO = int.Parse(r.ItemArray[0].ToString()),
                    DESCRICAO = r.ItemArray[1].ToString(),
                    ASSINANTES = int.Parse(r.ItemArray[2].ToString()),
                    VALOR = decimal.Parse(r.ItemArray[3].ToString()),
                    FATURAMENTO = decimal.Parse(r.ItemArray[4].ToString()),
                });
            }

            return retorno;
        }
    }

      
    
}
