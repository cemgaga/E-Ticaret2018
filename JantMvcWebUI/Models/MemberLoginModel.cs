using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JantMvcWebUI.Models
{
    public class MemberLoginModel
    {
        public int UyeId { get; set; }
        [Required(ErrorMessage = "Email Girmeniz Gerekmektedir!")]
        [EmailAddress(ErrorMessage = "Gerçek Bir Mail Adresi Girmelisiniz!")]

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Parola Girmeniz Gerekmektedir!")]
        [StringLength(10, ErrorMessage = "Parola En Fazla 10 Karakter Olabilir!")]
        public string Parola { get; set; }
    }
}