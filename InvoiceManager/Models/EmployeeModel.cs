using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Zaměstnanec ID")]
        public int Id { get; set; }

        [Display(Name = "Křestní jméno")]
        [Required(ErrorMessage = "Musíte zadat křestní jméno zaměstnance")]
        public string FirstName { get; set; }

        [Display(Name = "Příjmení")]
        [Required(ErrorMessage = "Musíte zadat křestní příjmení zaměstnance")]
        public string LastName { get; set; }
    }
}
