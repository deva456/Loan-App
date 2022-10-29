using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class loans
    {
        [Key]
        public int loanId { get; set; }
        public string loanType { get; set; }
        public decimal interestRate { get; set; }
    }
}
