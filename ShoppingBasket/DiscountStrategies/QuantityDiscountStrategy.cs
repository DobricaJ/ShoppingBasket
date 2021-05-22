using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.DiscountStrategies
{
    public class QuantityDiscountStrategy : DiscountStrategy
    {

        public decimal discountFactor;
        public Product dependantProduct;
        public decimal dependantQuantity;


        /// <param name="discountFactor"> 0 is 100% discount, 0.5 is 50% discount, 1 is 0% discount,...etc </param>
        /// <param name="dependantProduct">This product is a prerequisite for a discount</param>
        /// <param name="dependantQuantity">Minimum quantity of dependantProduct necessary for discount</param>
        public QuantityDiscountStrategy(decimal discountFactor, Product dependantProduct, decimal dependantQuantity)
        {
            this.discountFactor = discountFactor;
            this.dependantProduct = dependantProduct;
            this.dependantQuantity = dependantQuantity;
        }

        /// <summary>
        /// Special Price could be ProductPrice multiplied by ProductQuantity
        /// with or without applied discount
        /// </summary>
        public override void CreateSpecialPrice(CartItem item, List<CartItem> cartItems)
        {

            var dependantProductInCart = cartItems
                .FirstOrDefault(x => x.Product.Equals(dependantProduct) && x.Quantitiy >= dependantQuantity);

            if (dependantProductInCart != null)
            {
                item.SpecialPrice = CalcualteDiscountedPrice(item, dependantProductInCart.Quantitiy);
            }
        }

        /// <summary>
        /// Calculate discounted price based on product Quantity and Quantity of product for dependency
        /// </summary>
        /// <returns></returns>
        private decimal CalcualteDiscountedPrice(CartItem item, decimal dependantProductsInCart)
        {
            var affectedProducts = Decimal.Floor(
                Decimal.Divide(dependantProductsInCart, dependantQuantity));

            var regularPice = item.Product.Price;

            var sumOfRegularPrices = (item.Quantitiy - affectedProducts) * regularPice;

            var sumOfAffectedPrices = discountFactor * affectedProducts * regularPice;

            return sumOfRegularPrices + sumOfAffectedPrices;
        }
    }
}
