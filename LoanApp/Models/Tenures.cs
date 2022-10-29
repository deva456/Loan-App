using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Tenures
    {
        [Key]
        public int tenureId { get; set; }

        public int months { get; set; }

     

    }
}
