using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seanca13.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Fusha username sduhet te jete bosh !")]
        public string username { get; set; }

        [Required(ErrorMessage = "Fusha e pasuordit sduhet te jete bosh !")]
        public string password { get; set; }
    }
}