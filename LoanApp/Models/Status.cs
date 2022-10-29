using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Status
    {
        [Key]
        public int statusId { get; set; }

        public string loanStatus { get; set; }

      
    }
}
