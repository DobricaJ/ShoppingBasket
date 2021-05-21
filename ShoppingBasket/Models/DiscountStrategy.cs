namespace ShoppingBasket
{
    public class DiscountStrategy
    {
        /// <summary>
        ///   0 is 100% discount, 0.5 is 50% discount, 1 is 0% discount,...etc
        /// </summary>
        public decimal DiscountFactor { get; set; }

        public Product Product { get; set; }

    }

    public class QuantityDiscountStrategy : DiscountStrategy
    {
        public Product ProductDependency { get; set; }

        public int QuantityForDependency { get; set; }

    }
}