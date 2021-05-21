using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShoppingBasket
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> cartItems = new();
        private decimal total = 0;

        public void AddToCart(CartItem cartItem)
        {
            cartItems.Add(cartItem);
        }

        /// <summary>
        /// Total is sum of SpecialPrices created by CartItems Quantity and Discounts
        /// </summary>
        public decimal GetTotal()
        {
            CreateSpecialPrice();

            total = cartItems.Sum(x => x.SpecialPrice);

            LogCartDetails();

            return total;
        }

        /// <summary>
        /// Special Price could be ProductPrice multiplied by ProductQuantity
        /// with or without applied discount
        /// </summary>
        private void CreateSpecialPrice()
        {
            foreach (var item in cartItems)
            {
                item.SpecialPrice = item.Product.Price * item.Quantitiy;

                if (item.Discount != null)
                {
                    var productDependency = cartItems
                         .FirstOrDefault(x =>
                         x.Product == item.Discount.ProductDependency
                         && x.Quantitiy >= item.Discount.QuantityForDependency);

                    if (productDependency != null)
                    {
                        item.SpecialPrice = CalcualteDiscountedPrice(item, productDependency);
                    }
                }
            }
        }

        /// <summary>
        /// Calculate discounted price based on product Quantity and Quantity of product for dependency
        /// </summary>
        /// <returns></returns>
        private decimal CalcualteDiscountedPrice(CartItem item, CartItem productDependency)
        {
            var affectedProducts = Decimal.Floor(
                Decimal.Divide(productDependency.Quantitiy, item.Discount.QuantityForDependency));

            var regularPice = item.Product.Price;

            var sumOfRegularPrices = (item.Quantitiy - affectedProducts) * regularPice;

            var sumOfAffectedPrices = item.Discount.DiscountFactor * affectedProducts * regularPice;

            return sumOfRegularPrices + sumOfAffectedPrices;
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
