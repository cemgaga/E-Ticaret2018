using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Entities
{
    public class Uye
    {
        public int UyeId { get; set; }

        [Required(ErrorMessage = "Ad Girmeniz Gerekmektedir!")]
        [StringLength(15, ErrorMessage = "Ad En Fazla 25 Karakter Olmak Zorundadır!")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad Girmeniz Gerekmektedir!")]
        [StringLength(15, ErrorMessage = "Soyad En Fazla 25 Karakter Olmak Zorundadır!")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Mail Girmeniz Gerekmektedir!")]
        [EmailAddress(ErrorMessage = "Gerçek Bir Mail Adresi Girmelisiniz!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Parola Girmeniz Gerekmektedir!")]
        [StringLength(10, ErrorMessage = "Parola En Fazla 10 Karakter Olmak Zorundadır!")]
        public string Parola { get; set; }

        [Required(ErrorMessage = "Telefon Girmeniz Gerekmektedir!")]
        [StringLength(11, ErrorMessage = "Parola En Fazla 10 Karakter Olmak Zorundadır!")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Doğum Tarihi Girmeniz Gerekmektedir!")]
        public DateTime DogumTarih { get; set; }

        [Required(ErrorMessage = "Adres Girmeniz Gerekmektedir!")]
        [StringLength(250, ErrorMessage = "Adres En Fazla 250 Karakter Olabilir!")]
        public string Adres { get; set; }

        public string AracResim { get; set; }


    }
}
