namespace ShoppingBasket
{
    public class CartItem
    {
        public Product Product { get; set; }

        public decimal Quantitiy { get; set; }

        public decimal SpecialPrice { get; set; }

        public DiscountStrategy Discount { get; set; }
    }
}