using System.Collections.Generic;

namespace ShoppingBasket
{
    /// <summary>
    ///  DiscountStrategy abstract class necessary for Strategy Design Pattern.
    ///  Extending this class can create customized SpecialPrice for each Cart Item.
    /// </summary>
    public abstract class DiscountStrategy
    {
        public abstract void CreateSpecialPrice(CartItem item, List<CartItem> cartItems);
    }
}