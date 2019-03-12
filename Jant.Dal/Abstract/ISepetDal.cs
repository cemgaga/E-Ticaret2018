using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Entities;

namespace Jant.Dal.Abstract
{
    public interface ISepetDal
    {
        List<SepettekiUrunler> GetItemsOnBasketByMemberId(int Id);

        void AddBasket(SepettekiUrunler sepet,int UyeId);

        SepetSession Sepettekiler(List<SepettekiUrunler> Urunler);

        void DeleteItem(int UyeId,int UrunId);

        void ClearBasket(int UyeId);
        
    }
}
