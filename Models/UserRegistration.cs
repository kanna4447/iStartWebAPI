using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace iStartWebAPI.Models
{
    public class UserRegistration
    {
        [Key]
        public int RegisterId { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Re-enter password")]

        [Required]
        public string ReEnterPassword { get; set; }
    }
}