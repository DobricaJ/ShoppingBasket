using System.Collections.Generic;

namespace ShoppingBasket
{
    public class Cart
    {
        public List<CartItem> CartItems;
        public decimal Total;

        public Cart(List<CartItem> cartItems, decimal total)
        {
            CartItems = cartItems;
            Total = total;
        }


        // For logging
        public override string ToString()
        {
            string items = string.Empty;

            foreach (var item in CartItems)
            {
                items +=
                    $"\r\rName: {item.Product.Name}, " +
                    $"\rPrice: {item.Product.Price}, " +
                    $"\rQuantity: {item.Quantitiy}, " +
                    $"\rSpecialPrice: {item.SpecialPrice} ";
            }
            return $"\rTotal: {Total} \r\rCartItems: {items}";
        }
    }
}
