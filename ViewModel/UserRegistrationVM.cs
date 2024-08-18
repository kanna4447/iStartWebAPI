using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iStartWebAPI.ViewModel
{
    public class UserRegistrationVM
    {
        [Required]
        [StringLength(75, ErrorMessage = "Name should have only alphabets Max length of {0} and Min length of {1}", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid pattern.")]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Re Enter Password")]
        [Compare("Password")]
        public string ReEnterPassword { get; set; }
    }
}