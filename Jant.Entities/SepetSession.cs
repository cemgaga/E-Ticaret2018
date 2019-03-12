using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jant.Entities
{
    public class SepetSession
    {
        public List<CartLine> cartLine = new List<CartLine>();

        public void AddToCart(Urun product, int quantity)
        {
            CartLine line = cartLine.FirstOrDefault(p => p.Product.UrunId == product.UrunId);
            if (line == null)
            {
                cartLine.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public void RemoveItem(int productId)
        {
            cartLine.RemoveAll(p => p.Product.UrunId == productId);
        }

        public decimal Total
        {
            get { return cartLine.Sum(p => p.Product.Fiyat * p.Quantity); }
        }

        public List<CartLine> GetCart
        {
            get { return cartLine; }
        }

        public void Clear()
        {
            cartLine.Clear();
        }
    }

    public class CartLine
    {
        public Urun Product { get; set; }
        public int Quantity { get; set; }
    }
}

