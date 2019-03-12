using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Dal.Abstract;
using Jant.Entities;
 
namespace Jant.Dal.Concrete.EntityFramework
{
    public class EfUyeDal:IUyeDal
    {
        public bool MemberRegister(Uye YeniUye)
        {
            using (JantDataContext context = new JantDataContext())
            {
               Uye uyeVarMi= context.Uyes.FirstOrDefault(p => p.Mail == YeniUye.Mail);
               if (uyeVarMi==null)
               {
                   context.Uyes.Add(YeniUye);
                   Sepet sepet = new Sepet();
                   sepet.Uye = YeniUye;
                   context.Sepets.Add(sepet);
                   context.SaveChanges();
                   return true;
               }
               return false;
            }
        }


        public Uye MemberLogin(string Mail, string Parola)
        {
            using (JantDataContext context = new JantDataContext())
            {
                Uye uyeVarMi = context.Uyes.FirstOrDefault(p => p.Mail == Mail && p.Parola==Parola);

                return uyeVarMi;
            }
        }
    }
}
