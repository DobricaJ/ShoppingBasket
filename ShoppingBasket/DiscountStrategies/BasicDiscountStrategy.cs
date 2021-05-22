using System.Collections.Generic;

namespace ShoppingBasket.DiscountStrategies
{
    public class BasicDiscountStrategy : DiscountStrategy
    {
        public decimal discountFactor;


        /// <param name="discountFactor"> 0 is 100% discount, 0.5 is 50% discount, 1 is 0% discount,...etc </param>
        public BasicDiscountStrategy(decimal discountFactor)
        {
            this.discountFactor = discountFactor;
        }

        public override void CreateSpecialPrice(CartItem item, List<CartItem> cartItems)
        {
            item.SpecialPrice = item.SpecialPrice * discountFactor;
        }
    }
}
