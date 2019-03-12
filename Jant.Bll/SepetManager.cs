using Jant.Dal.Abstract;
using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Bll
{
    public class SepetManager
    {
        private ISepetDal sepetDal;
        public SepetManager(ISepetDal _sepetDal)
        {
            sepetDal = _sepetDal;
        }

        public List<SepettekiUrunler> GetItemsOnBasketByMemberId(int Id)
        {
            return sepetDal.GetItemsOnBasketByMemberId(Id);
        }

        public void AddBasket(SepettekiUrunler urun, int UyeId)
        {
            sepetDal.AddBasket(urun, UyeId);
        }

        public SepetSession Sepettekiler(List<SepettekiUrunler> urunler)
        {
            return sepetDal.Sepettekiler(urunler);
        }

        public void RemoveItem(int UyeId,int UrunId)
        {
            sepetDal.DeleteItem(UyeId, UrunId);
        }

        public void ClearBasket(int UyeId)
        {
            sepetDal.ClearBasket(UyeId);
        }
    }
}
