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
                LastName = lastName,
                CreatedAt = DateTime.Now
            };

            string sql = @"INSERT INTO dbo.Employees (FirstName, LastName, CreatedAt)
                           VALUES (@FirstName, @LastName, @CreatedAt);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"SELECT Id, FirstName, LastName
                           FROM dbo.Employees;";
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static EmployeeModel LoadOneEmployee(int employeeId)
        {
            string sql = @"SELECT Id, FirstName, LastName
                           FROM dbo.Employees
                           WHERE Id = @Id;";
            return SqlDataAccess.GetOneEmployee(sql, employeeId);
        }

        public static int EditEmployee(EmployeeModel model)
        {
            EmployeeModel data = new EmployeeModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            string sql = @"UPDATE dbo.Employees
                           SET FirstName = @FirstName,
                               LastName = @LastName,
                               UpdatedAt = GETDATE()
                           WHERE Id = @Id";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteOneEmployee(int employeeId)
        {
            EmployeeModel data = new EmployeeModel
            {
                Id = employeeId
            };

            string sql = @"DELETE FROM dbo.Employees
                           WHERE Id = @Id;";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
