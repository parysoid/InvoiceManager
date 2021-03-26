using System;

namespace DataLibrary.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime Date { get; set; }
    }
}
