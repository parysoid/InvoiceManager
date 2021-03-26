using DataLibrary.Models;
using System;
using System.Collections.Generic;
namespace DataLibrary.BussinessLogic
{
    public static class InvoiceProcessor
    {
        public static int CreateInvoice(string description, int value, DateTime date)
        {
            InvoiceModel data = new InvoiceModel
            {
                InvoiceId = new Random().Next(100000, 999999),
                Description = description,
                Value = value,
                Date = date,
                CreatedAt = DateTime.Now
            };

            string sql = @"INSERT INTO dbo.Invoices (InvoiceId, Description, Value, CreatedAt, Date)
                           VALUES (@InvoiceId, @Description, @Value, @CreatedAt, @Date);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<InvoiceModel> LoadInvoices()
        {
            string sql = @"SELECT Id, InvoiceId, Description, Value, CreatedAt, UpdatedAt, Date
                           FROM dbo.Invoices;";
            return SqlDataAccess.LoadData<InvoiceModel>(sql);
        }

        public static InvoiceModel LoadOneInvoice(int invoiceId)
        {

            string sql = @"SELECT Id, InvoiceId, Description, Value, CreatedAt, UpdatedAt, Date
                           FROM dbo.Invoices
                           WHERE Id = @Id;";
            return SqlDataAccess.LoadOne(sql, invoiceId);
        }

        public static List<InvoiceModel> LoadMonth(DateTime start, DateTime end)
        {

            string sql = @"SELECT Id, InvoiceId, Description, Value, CreatedAt, UpdatedAt, Date
                           FROM dbo.Invoices
                           WHERE Date BETWEEN @Start AND @End;";
            return SqlDataAccess.LoadMonth<InvoiceModel>(sql, start, end);
        }

        public static int EditInvoice(InvoiceModel model)
        {
            InvoiceModel data = new InvoiceModel
            {
                Id = model.Id,
                Description = model.Description,
                Value = model.Value,
                Date = model.Date
            };

            string sql = @"UPDATE dbo.Invoices
                           SET Description = @Description,
                               Value = @Value,
                               Date = @Date,
                               UpdatedAt = GETDATE()
                           WHERE Id = @Id";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteOneInvoice(int invoiceId)
        {
            InvoiceModel data = new InvoiceModel
            {
                Id = invoiceId
            };

            string sql = @"DELETE FROM dbo.Invoices
                           WHERE Id = @Id;";

            return SqlDataAccess.SaveData(sql, data);
        }


    }
}
