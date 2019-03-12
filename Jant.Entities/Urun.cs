using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Jant.Entities
{
    public class Urun
    {
        public int UrunId { get; set; }

        [Required(ErrorMessage = "Kategori Girmeniz Gerekmektedir!")]
        public int KategoriId { get; set; }

        public virtual Marka Marka { get; set; }

        [Required(ErrorMessage = "Ürün Kodu Girmeniz Gerekmektedir!")]
        [StringLength(20,ErrorMessage="Ürün Kodu en fazla 20 Karakter Olmalıdır")]
        public string UrunKodu { get; set; }

        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Çap Girmeniz Gerekmektedir!")]
        public byte Cap { get; set; }

        [Required(ErrorMessage = "Fiyat Girmeniz Gerekmektedir!")]
        public decimal Fiyat { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public virtual List<Resim> Resimler { get; set; }

        [DefaultValue("false")]
        public bool HaftaninUrunu { get; set; }

        [DefaultValue("false")]
        public bool AyinUrunu { get; set; }

        //[ForeignKey("UrunId")]
        //public List<Sepet> Sepets { get; set; }

    }
}
