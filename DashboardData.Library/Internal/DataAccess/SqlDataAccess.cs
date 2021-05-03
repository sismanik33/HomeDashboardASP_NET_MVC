using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DashboardData.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        //Code within this class is taken from YouTube tutorial by Tim Corey
        //https://www.youtube.com/user/IAmTimCorey 
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public async Task<List<T>> LoadDataStoredProc<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                //List<T> rows = connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).Result.ToList();
                var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public async Task SaveDataStoredProc<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
