using escolaNC.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace escolaNC.Data
{
    public class AcessoBD : IAcessoBD
    {
        private readonly IConfiguration _config;

        public AcessoBD(IConfiguration config)
        {
            _config = config;
        }

        public DataTable ExecutaProc(string Procedure)
        {

			var conexao = new SqlConnection(_config.GetConnectionString("Default"));
			var consulta = conexao.CreateCommand();
			consulta.CommandType = System.Data.CommandType.StoredProcedure;
			consulta.CommandText = Procedure;

			conexao.Open();

			var dr = consulta.ExecuteReader();

			var dt = new DataTable();
			var dtSchema = dr.GetSchemaTable();

			foreach (DataRow row in dtSchema.Rows)
			{
				DataColumn col = new DataColumn()
				{
					ColumnName = row["ColumnName"].ToString(),
					Unique = Convert.ToBoolean(row["IsUnique"]),
					AllowDBNull = Convert.ToBoolean(row["AllowDBNull"]),
					ReadOnly = Convert.ToBoolean(row["IsReadOnly"])
				};
				dt.Columns.Add(col);
			}

			try
			{
				while (dr.Read())
				{
					DataRow linha = dt.NewRow();
					for (int i = 0; i < dt.Columns.Count; i++)
					{
						linha[i] = dr.GetValue(i);
					}
					dt.Rows.Add(linha);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				conexao.Close();
			}

			return dt;

			
        }

        public DataTable ExecutaProc(string Procedure, SqlParameter Parametros)
        {
			var conexao = new SqlConnection(_config.GetConnectionString("Default"));
			var consulta = conexao.CreateCommand();
			consulta.CommandType = System.Data.CommandType.StoredProcedure;
			consulta.CommandText = Procedure;

			consulta.Parameters.Add(Parametros);

			conexao.Open();

			var dr = consulta.ExecuteReader();

			var dt = new DataTable();
			var dtSchema = dr.GetSchemaTable();

			foreach (DataRow row in dtSchema.Rows)
			{
				DataColumn col = new DataColumn()
				{
					ColumnName = row["ColumnName"].ToString(),
					Unique = Convert.ToBoolean(row["IsUnique"]),
					AllowDBNull = Convert.ToBoolean(row["AllowDBNull"]),
					ReadOnly = Convert.ToBoolean(row["IsReadOnly"])
				};
				dt.Columns.Add(col);
			}

			try
			{
				while (dr.Read())
				{
					DataRow linha = dt.NewRow();
					for (int i = 0; i < dt.Columns.Count; i++)
					{
						linha[i] = dr.GetValue(i);
					}
					dt.Rows.Add(linha);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				conexao.Close();
			}

			return dt;
		}
    }
}
