using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class userProfile
    {
        [Key]
        public int profileId { get; set; }
        
        [Display(Name ="First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime dateOfBirth { get; set; }
        [Required]
        [Display(Name = "Occupation")]
        public string occupation { get; set; }
        [Required]
        [Display(Name = "Annual Income")]
        public double income { get; set; }
        [Required]
        [Display(Name = "Adhaar Card Number")]
        public string idProof { get; set; }
        [Required]
        [Display(Name = "Loan Amount")]
        public double loanAmount { get; set; }
        [Required]
        [Display(Name = "Loan Type")]
        public int loanId { get; set; }

        [ForeignKey("loanId")]
        public virtual loans Loans { get; set; }
        [Required]
        [Display(Name = "Months")]
        public int tenureId { get; set; }

        [ForeignKey("tenureId")]
        public virtual Tenures Tenure { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int statusId { get; set; }

        [ForeignKey("statusId")]
        public virtual Status Status { get; set; }

        public string loginId { get; set; }
    }
}
