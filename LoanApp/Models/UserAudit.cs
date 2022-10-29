using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class UserAudit
    {
        [Key]
        public int auditId { get; set; }

        public string auditData { get; set; }
    }
}
