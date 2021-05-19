using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } 

        public decimal Total { get; set; }
    }
}
