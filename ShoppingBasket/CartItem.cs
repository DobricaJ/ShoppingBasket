using System.Collections.Generic;

namespace ShoppingBasket
{
    public class CartItem
    {
        public Product Product { get; set; }

        public decimal Quantitiy { get; set; }

        public decimal SpecialPrice { get; set; }
        public List<DiscountStrategy> Discounts { get; set; }
    }
}