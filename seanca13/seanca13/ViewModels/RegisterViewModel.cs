using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace seanca13.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Emri sduhet te jete bosh  !")]
        [MaxLength(10)]
        [RegularExpression(@"(\S\D)+", ErrorMessage = " Hapesirat dhe numrat nuk lejohen te vendosen !")]
        public string name { get; set; }
        [Required(ErrorMessage = "Fusha usernami sduhet te jete bosh !")]
        public string username { get; set; }
        [Required(ErrorMessage = "Fusha pasuordi sduhet te jete bosh !")]
        public string password { get; set; }
        [Required(ErrorMessage = "Fusha konfirmim pasuord sduhet te jete bosh!")]
        [Compare("password", ErrorMessage = "Fusha pasuord nuk perputhet me fushen cconfirmpassword! ")]
        public string confirmpassword { get; set; }
        [Required(ErrorMessage = "Fusha e emailit sduhet te jete bosh !")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}