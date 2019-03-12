using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Entities
{
    public class Sepet
    {
        public int SepetId { get; set; }

        public  virtual Uye Uye { get; set; }

        public  virtual List<SepettekiUrunler> Urunler { get; set; }

        
    }

}
