using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Dal.Abstract;
using Jant.Entities;

namespace Jant.Bll
{
    public class UyeManager
    {
        private IUyeDal uyeDal;
        public UyeManager(IUyeDal _uyeDal) 
        {
            uyeDal = _uyeDal;
        }

        public bool MemberRegister(Uye yeniUye) 
        {
            return uyeDal.MemberRegister(yeniUye);
        }

        public Uye MemberLogin(string Mail, string Parola)
        {
            return uyeDal.MemberLogin(Mail, Parola);
        }


    }
}
