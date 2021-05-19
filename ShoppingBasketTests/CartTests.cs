using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Tests
{
    [TestClass()]
    public class CartTests
    {
        private List<Product> products = new()
        {
            new Product
            {
                Name = "Butter",
                Price = (decimal)0.80
            },
            new Product
            {
                Name = "Milk",
                Price = (decimal)1.15
            },
            new Product
            {
                Name = "Bread",
                Price = (decimal)1.00
            }
        };

        public void AddToCartTest()
        {
            Assert.Fail();
        }
    }
}