using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Faktura ID")]
        public int InvoiceId { get; set; }

        [Display(Name = "Popis faktury")]
        public string Description { get; set; }

        [Display(Name = "Hodnota")]
        public int Value { get; set; }

        [Display(Name = "Přidáno")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Upraveno")]
        public DateTime UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fakturováno dne")]
        public DateTime Date { get; set; }

    }
}
