using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iStartWebAPI.ViewModel
{
    public class UserLoginVM
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid pattern.")]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}