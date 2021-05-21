using System.Collections.Generic;

namespace ShoppingBasket
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        public decimal Total { get; set; }

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
