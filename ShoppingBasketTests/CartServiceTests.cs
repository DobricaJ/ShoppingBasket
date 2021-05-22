using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket.DiscountStrategies;

namespace ShoppingBasket.Tests
{
    [TestClass()]
    public class CartServiceTests
    {
        private CartService cart;
        private Product butter;
        private Product milk;
        private Product bread;
        private QuantityDiscountStrategy milkDiscount;
        private QuantityDiscountStrategy breadDiscount;


        [TestInitialize]
        public void Initialize()
        {
            cart = new CartService();

            ///Products:
            ///    Product   Price
            ///    Butter    0.80
            ///    Milk      1.15
            ///    Bread     1.00
            butter = new() { Name = "Butter", Price = (decimal)0.80 };

            milk = new() { Name = "Milk", Price = (decimal)1.15 };

            bread = new() { Name = "Bread", Price = (decimal)1.00 };

            /// Discounts:
            ///  • Buy 2 butters and get one bread at 50% off
            ///  • Buy 3 milks and get the 4th milk for free
            milkDiscount = new QuantityDiscountStrategy((decimal)0, milk, 3);

            breadDiscount = new QuantityDiscountStrategy((decimal)0.5, butter, 2);
        }

        [TestMethod]
        public void AddToCart_TryToAdd()
        {
            try
            {
                cart.AddToCart(new CartItem { Product = butter, Quantitiy = 1 });
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetTotal_OfEmptyCart()
        {
            decimal total = cart.GetTotal();

            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void GetTotal_OneProductInCart()
        {
            cart.AddToCart(new CartItem { Product = butter, Quantitiy = 1 });

            decimal total = cart.GetTotal();

            Assert.AreEqual(butter.Price, total);
        }

        /// Scenario 1:
        ///  • Given the basket has 1 bread, 1 butter and 1 milk. Total should be $2.95
        /// </summary>
        [TestMethod]
        public void GetTotal_WithDiscount_ScenarioOne()
        {
            decimal expected = (decimal)2.95;

            cart.AddToCart(new CartItem { Product = butter, Quantitiy = 1 });
            cart.AddToCart(new CartItem { Product = milk, Quantitiy = 1, Discount = milkDiscount });
            cart.AddToCart(new CartItem { Product = bread, Quantitiy = 1, Discount = breadDiscount });

            decimal total = cart.GetTotal();

            Assert.AreEqual(expected, total);
        }

        /// Scenario 2:
        ///  • Given the basket has 2 butters and 2 breads. Total should be $3.10
        /// </summary>
        [TestMethod]
        public void GetTotal_WithDiscount_ScenarioTwo()
        {
            decimal expected = (decimal)3.10;

            cart.AddToCart(new CartItem { Product = butter, Quantitiy = 2 });
            cart.AddToCart(new CartItem { Product = bread, Quantitiy = 2, Discount = breadDiscount });

            decimal total = cart.GetTotal();

            Assert.AreEqual(expected, total);
        }

        /// Scenario 3:
        ///  • Given the basket has 4 milks. Total should be $3.45
        /// </summary>
        [TestMethod]
        public void GetTotal_WithDiscount_ScenarioThree()
        {
            decimal expected = (decimal)3.45;

            cart.AddToCart(new CartItem { Product = milk, Quantitiy = 4, Discount = milkDiscount });

            decimal total = cart.GetTotal();

            Assert.AreEqual(expected, total);
        }

        /// Scenario 4:
        ///  • Given the basket has 2 butters, 1 bread, and 8 milks. Total should be $9.00
        /// </summary>
        [TestMethod]
        public void GetTotal_WithDiscount_ScenarioFour()
        {
            decimal expected = (decimal)9.00;

            cart.AddToCart(new CartItem { Product = butter, Quantitiy = 2 });
            cart.AddToCart(new CartItem { Product = milk, Quantitiy = 8, Discount = milkDiscount });
            cart.AddToCart(new CartItem { Product = bread, Quantitiy = 1, Discount = breadDiscount });

            decimal total = cart.GetTotal();

            Assert.AreEqual(expected, total);
        }

        /// Scenario 5:
        ///  • Given the basket has 2 butters, 1 bread, and 8 milks. Total should be $.00
        ///    Butter have basic discount 50%. Total should be $8.00
        /// </summary>
        [TestMethod]
        public void GetTotal_WithDiscount_ScenarioFive()
        {
            decimal expected = (decimal)8.20;

            cart.AddToCart(new CartItem { Product = butter, Quantitiy = 2, Discount = new BasicDiscountStrategy((decimal)0.5)});
            cart.AddToCart(new CartItem { Product = milk, Quantitiy = 8, Discount = milkDiscount });
            cart.AddToCart(new CartItem { Product = bread, Quantitiy = 1, Discount = breadDiscount });

            decimal total = cart.GetTotal();

            Assert.AreEqual(expected, total);
        }
    }
}