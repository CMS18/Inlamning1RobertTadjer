using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBankRobertT.App.Models.ViewModels
{
    public class TransferViewModel
    {
        [Required]
        [Display(Name = "Summa")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Kontot du för över pengar från")]
        public int TransferFromId { get; set; }

        [Required]
        [Display(Name = "Kontot du för över pengar till")]
        public int TransferToId { get; set; }

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }
    }
}
