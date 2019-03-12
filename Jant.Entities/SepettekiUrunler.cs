using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Entities
{
    public class SepettekiUrunler
    {
        public int Id { get; set; }

        public int UrunId { get; set; }

        public int Miktar { get; set; }

    }
}
