using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Dal.Abstract
{
    public interface IUyeDal
    {
        bool MemberRegister(Uye YeniUye);

        Uye MemberLogin(string Mail, string Parola);
    }
}
