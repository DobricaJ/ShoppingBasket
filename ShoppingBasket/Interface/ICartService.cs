namespace ShoppingBasket
{
    public interface ICartService
    {
        public void AddToCart(CartItem cartItem);

        public decimal GetTotal();

        public void LogCartDetails();

    }
}
