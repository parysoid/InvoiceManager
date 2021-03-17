using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataLibrary.DataContext;

namespace DataLibrary
{
    
    public class SqlDataAccess
    {
        private static AppConfiguration settings = new AppConfiguration();
       
        public static string GetConnectionString()
        {
            //return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            //var settings = new AppConfiguration();
            
            return settings.sqlConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static List<T> LoadOne<T>(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, new { Id = id }).ToList();
            }
        }
    }
}
