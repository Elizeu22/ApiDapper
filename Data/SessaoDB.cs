using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using Microsoft.Data.SqlClient;




namespace App_Corretora.Data
{
    public class SessaoDB:IDisposable
    {
        public IDbConnection Connection { get; }

        public SessaoDB(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("ConexaoSQl"));

            Connection.Open();
        }

        public void Dispose() => Connection.Close();

    }
}
