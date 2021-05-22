using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShoppingBasket
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> cartItems;
        private decimal total;

        public CartService()
        {
            this.cartItems = new();
        }

        public void AddToCart(CartItem cartItem)
        {
            cartItems.Add(cartItem);
        }

        /// <summary>
        /// Total is sum of SpecialPrices created by CartItems Quantity and Discounts
        /// </summary>
        public decimal GetTotal()
        {
            foreach (var item in cartItems)
            {
                item.SpecialPrice = item.Product.Price * item.Quantitiy;

                if (item.Discount != null)
                {
                    item.Discount.CreateSpecialPrice(item, cartItems);
                }
            }

            total = cartItems.Sum(x => x.SpecialPrice);

            LogCartDetails();

            return total;
        }

        /// <summary>
        /// Log details are in TestExplorer > Open additional output for this result
        /// </summary>
        public void LogCartDetails()
        {
            Cart cart = new(cartItems, total);

            Trace.WriteLine(cart.ToString());
        }
    }
}
