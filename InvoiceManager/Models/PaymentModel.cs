using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class PaymentModel
    {
        [Display(Name = "Výplata ID")]
        public int Id { get; set; }

        [Display(Name = "Zaměstnanec ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "Hodnota")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Musíte zadat hodnotu výplaty")]
        public double Value { get; set; }

        [Display(Name = "Datum")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Musíte zadat hodnotu výplaty")]
        public DateTime Date { get; set; }

        [Display(Name = "Popis")]
        public string Description { get; set; }

        [Display(Name = "Vytvořeno")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Upraveno")]
        public DateTime UpdatedAt { get; set; }

        [Display(Name = "Jméno zaměstnance")]
        public string EmployeeName { get; set; }
    }
}
