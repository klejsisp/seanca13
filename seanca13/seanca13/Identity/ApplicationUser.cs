using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace seanca13.Identity
{
    public class ApplicationUser : IdentityUser
    {
       
        [MaxLength(10)]
        [RegularExpression(@"(\S\D)+", ErrorMessage = " Hapesirat dhe numrat nuk lejohen te vendosen !")]
        public string emri { get; set; }
        
        public string mbiemri { get; set; }
        public string adresa { get; set; }
        public int telefon { get; set; }
       
    }
}