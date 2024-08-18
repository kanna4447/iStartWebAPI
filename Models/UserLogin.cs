using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iStartWebAPI.Models
{
    public class UserLogin
    {
        
        [Key]
        public int LoginId { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
    }
}