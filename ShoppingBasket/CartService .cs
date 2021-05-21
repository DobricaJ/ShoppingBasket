using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShoppingBasket
{
    public class CartService : ICartService
    {
        private List<CartItem> cartItems = new();
        private decimal total = 0;

        public void AddToCart(CartItem cartItem)
        {
            cartItems.Add(cartItem);
        }

        public decimal GetTotal()
        {
            CreateSpecialPrice();

            total = cartItems.Sum(x => x.SpecialPrice);

            LogCartDetails();

            return total;
        }

        private void CreateSpecialPrice()
        {
            foreach (var item in cartItems)
            {
                var productDependency = cartItems.FirstOrDefault(x =>
                item.Discount != null
                && x.Product == item.Discount.ProductDependency
                && x.Quantitiy >= item.Discount.QuantityForDependency);

                if (productDependency != null)
                {
                    decimal affectedProducts = Decimal.Floor(
                        Decimal.Divide(productDependency.Quantitiy, item.Discount.QuantityForDependency));

                    decimal RegularPice = item.Product.Price;

                    decimal sumOfRegularPrices = (item.Quantitiy - affectedProducts) * RegularPice;

                    decimal sumOfAffectedPrices = item.Discount.DiscountFactor * affectedProducts * RegularPice;

                    item.SpecialPrice = sumOfRegularPrices + sumOfAffectedPrices;
                }
                else
                {
                    item.SpecialPrice = item.Product.Price * item.Quantitiy;
                }
            }
        }

        public void LogCartDetails()
        {
            Cart cart = new()
            {
                CartItems = cartItems,
                Total = total
            };

            Trace.WriteLine(cart.ToString());
        }
    }
}
