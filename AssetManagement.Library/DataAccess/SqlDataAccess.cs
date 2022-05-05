using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AssetManagement.Library.DataAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName)
        {
            string connectionString  = _config.GetConnectionString(connectionStringName);

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<T> rows = await connection.QueryAsync<T>(sqlStatement, parameters, commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.ExecuteAsync(sqlStatement, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
