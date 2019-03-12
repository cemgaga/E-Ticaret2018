using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Jant.Entities
{
    public class Resim
    {
        public int ResimId { get; set; }

        [Required(ErrorMessage = "Resim Seçmeniz Gerekmektedir!")]
        public string ResimUrl { get; set; }

        public bool AnaResim { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
