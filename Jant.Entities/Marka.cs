using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jant.Entities
{
    public class Marka
    {
        public int MarkaId { get; set; }

        [Required(ErrorMessage = "Marka Girmeniz Gerekmektedir!")]
        [StringLength(30, ErrorMessage = "Başlık En Fazla 30 Karakter Olmak Zorundadır!")]
        public string MarkaAdi { get; set; }

        public virtual List<Urun> Urunler { get; set; }
    }
}
