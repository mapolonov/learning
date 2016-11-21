using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAuthMvc.Models
{
    public class MyAccount
    {
        //[Required(ErrorMessage = "Please enter user name")]
        //[Display(Name = "User Name", Description = "Enter user name")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Please enter password")]
        //[Display(Name = "Password", Description = "Enter password")]
        public string Password { get; set; }
        
        //[Display(Name = "Remember me?", Description = "Remember me?")]
        //public bool RememberMe { get; set; }

        public string[] Roles { get; set; }
    }
}