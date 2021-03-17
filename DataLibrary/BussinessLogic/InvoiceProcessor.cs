using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        public static int EditInvoice(/*int invoiceId,*/ InvoiceModel model)
        {
            InvoiceModel data = new InvoiceModel
            {
                Id = model.Id,
                Description = model.Description,
                Value = model.Value,
                CreatedAt = model.CreatedAt                
            };

            string sql = @"UPDATE dbo.Invoices
                           SET Description = @Description,
                               Value = @Value,
                               CreatedAt = @CreatedAt,
                               UpdatedAt = GETDATE()
                           WHERE Id = @Id";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<InvoiceModel> LoadOneInvoice(int invoiceId)
        {
            InvoiceModel data = new InvoiceModel
            {
                Id = invoiceId
            };

            string sql = @"SELECT Id, InvoiceId, Description, Value, CreatedAt
                           FROM dbo.Invoices
                           WHERE Id = @Id;";
            return SqlDataAccess.LoadOne<InvoiceModel>(sql,invoiceId);
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
