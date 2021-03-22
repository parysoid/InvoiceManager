using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Models;

namespace DataLibrary.BussinessLogic
{
    public class PaymentProcessor
    {
        public static int CreatePayment(int employeeId, double value, string description, DateTime date)
        {
            PaymentModel data = new PaymentModel
            {
                EmployeeId = employeeId,
                Value = value,
                Description = description,
                Date = date,
                CreatedAt = DateTime.Now
            };

            string sql = @"INSERT INTO dbo.Payments (EmployeeId, Value, Description, Date, CreatedAt)
                           VALUES (@EmployeeId, @Value, @Description, @Date, @CreatedAt);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<PaymentModel> LoadPayments()
        {
            string sql = @"SELECT Payments.Id, Payments.EmployeeId, Payments.Description, Payments.Value, Payments.CreatedAt, Payments.UpdatedAt, Payments.Date,
                                  CONCAT(Employees.FirstName, ' ' ,Employees.LastName) AS EmployeeName            
                           FROM dbo.Payments
                           INNER JOIN Employees ON Payments.EmployeeId = Employees.Id;";
            return SqlDataAccess.LoadData<PaymentModel>(sql);
        }

        public static PaymentModel LoadOnePayment(int paymentId)
        {
            string sql = @"SELECT Payments.Id, Payments.EmployeeId, Payments.Description, Payments.Value, Payments.CreatedAt, Payments.UpdatedAt, Payments.Date,
                                  CONCAT(Employees.FirstName, ' ' ,Employees.LastName) AS EmployeeName 
                           FROM dbo.Payments
                           INNER JOIN Employees ON Payments.EmployeeId = Employees.Id
                           WHERE Payments.Id = @Id;";
            return SqlDataAccess.GetOnePayment(sql, paymentId);
        }

        public static int EditPayment(PaymentModel model)
        {
            PaymentModel data = new PaymentModel
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                Value = model.Value,
                Date = model.Date,
                Description = model.Description    
            };

            string sql = @"UPDATE dbo.Payments
                           SET EmployeeId = @EmployeeId,
                               Value = @Value,
                               Date = @Date,
                               Description = @Description,
                               UpdatedAt = GETDATE()
                           WHERE Id = @Id";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteOnePayment(int paymentId)
        {
            EmployeeModel data = new EmployeeModel
            {
                Id = paymentId
            };

            string sql = @"DELETE FROM dbo.Payments
                           WHERE Id = @Id;";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
