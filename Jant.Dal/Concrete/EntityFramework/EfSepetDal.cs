using Jant.Dal.Abstract;
using Jant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Dal.Concrete.EntityFramework
{
    public class EfSepetDal : ISepetDal
    {
        public List<SepettekiUrunler> GetItemsOnBasketByMemberId(int Id)
        {
            List<SepettekiUrunler> a = null;
            using (JantDataContext context = new JantDataContext())
            {

                return a = context.Sepets.Where(x => x.Uye.UyeId == Id).FirstOrDefault().Urunler;




                //List<SepettekiUrunler> sepettekiler=null;
                //sepettekiler = (from a in context.Sepets
                //                where a.Uye.UyeId == Id
                //                select  a.Urunler);

                //                           //select new SepettekiUrunler
                //                           //{
                //                           //   Id= a.Urunler[0].Id,
                //                           //   Miktar = a.Urunler[0].Miktar,
                //                           //   UrunId = a.Urunler[0].UrunId
                //                           //}
                //                           //).ToList();


                //return sepettekiler;
            }
        }


        public void AddBasket(SepettekiUrunler urun, int UyeId)
        {
            Sepet sepet;
            JantDataContext context = new JantDataContext();

            sepet = context.Sepets.Include("Urunler").Include("Uye").Where(x => x.Uye.UyeId == UyeId).FirstOrDefault();
            SepettekiUrunler urunVarmi = sepet.Urunler.Where(x => x.UrunId == urun.UrunId).FirstOrDefault();
            if (urunVarmi == null)
            {
                sepet.Urunler.Add(urun);
                context.SaveChanges();
            }
            else
            {
                urunVarmi.Miktar += 1;
                context.SaveChanges();
            }
        }

        public SepetSession Sepettekiler(List<SepettekiUrunler> Urunler)
        {
            SepetSession sepet = new SepetSession();

            Urun urun = null;
            int urunId = 0;

            JantDataContext context = new JantDataContext();

            for (int i = 0; i < Urunler.Count; i++)
            {
                CartLine line = new CartLine();
                urunId = Urunler[i].UrunId;
                urun = context.Uruns.Where(x => x.UrunId == urunId).FirstOrDefault();
                line.Product = urun;
                line.Quantity = Urunler[i].Miktar;
                sepet.cartLine.Add(line);
            }
            return sepet;

        }


        public void DeleteItem(int UyeId, int UrunId)
        {
            using (JantDataContext context = new JantDataContext())
            {
                SepettekiUrunler urun = context.Sepets.Where(x => x.Uye.UyeId == UyeId).FirstOrDefault().Urunler.Single(x => x.UrunId == UrunId);
                context.SepettekiUrunler.Remove(urun);
                context.SaveChanges();
            }
        }


        public void ClearBasket(int UyeId)
        {
            using (JantDataContext context = new JantDataContext())
            {
                List<SepettekiUrunler> urunler = context.Sepets.Where(x => x.Uye.UyeId == UyeId).FirstOrDefault().Urunler.ToList();
                context.SepettekiUrunler.RemoveRange(urunler);
                context.SaveChanges();
            }
        }
    }
}
