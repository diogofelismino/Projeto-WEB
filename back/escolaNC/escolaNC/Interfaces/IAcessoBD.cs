using Microsoft.Data.SqlClient;
using System.Data;

namespace escolaNC.Interfaces
{
    public interface IAcessoBD
    {

        public DataTable ExecutaProc(string Procedure);
        public DataTable ExecutaProc(string Procedure, SqlParameter paramentros);

    }
}
