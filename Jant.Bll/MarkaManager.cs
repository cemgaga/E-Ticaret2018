using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Entities;
using Jant.Dal.Abstract;

namespace Jant.Bll
{
    public class MarkaManager
    {
        private IMarkaDal markaDal;
        public MarkaManager(IMarkaDal _markaDal)
        {
            markaDal = _markaDal;
        }

        public List<Marka> GetAll()
        {
            return markaDal.GetAll();
        }

    }
}
