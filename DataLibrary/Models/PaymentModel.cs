using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EmployeeModel Employee { get; set; }

        public string EmployeeName { get; set; }
    }
}
