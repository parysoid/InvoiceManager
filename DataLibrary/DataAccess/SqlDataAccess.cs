using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataLibrary.DataContext;
using DataLibrary.Models;

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

        public static InvoiceModel LoadOne(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.QuerySingle<InvoiceModel>(sql, new { Id = id });
            }
        }
        
        public static EmployeeModel GetOneEmployee(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<EmployeeModel>(sql, new { Id = id }).FirstOrDefault();
            }
        }
        
        public static PaymentModel GetOnePayment(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<PaymentModel>(sql, new { Id = id }).FirstOrDefault();
            }
        }
        

        public static List<T> LoadMonth<T>(string sql, DateTime start, DateTime end)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                 return cnn.Query<T>(sql,new { Start = start, End = end}).ToList();
            }
        }
    }
}
