using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.BussinessLogic
{
    public class EmployeeProcessor
    {
        public static int CreateEmployee(string firstName, string lastName)
        {
            EmployeeModel data = new EmployeeModel
            {
                FirstName = firstName,
                LastName = lastName
            };

            string sql = @"INSERT INTO dbo.Employees (FirstName, LastName)
                           VALUES (@FirstName, @LastName);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"SELECT Id, FirstName, LastName
                           FROM dbo.Employees;";
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
