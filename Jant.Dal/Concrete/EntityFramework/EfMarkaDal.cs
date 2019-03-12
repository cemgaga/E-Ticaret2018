using Jant.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Entities;


namespace Jant.Dal.Concrete.EntityFramework
{
    public class EfMarkaDal:IMarkaDal
    {
        public List<Marka> GetAll()
        {
            using (JantDataContext context = new JantDataContext())
            {
                return context.Markas.ToList();
            }
        }

    }
}
