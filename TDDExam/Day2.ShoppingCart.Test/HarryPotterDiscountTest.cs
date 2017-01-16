using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.ShoppingCart.Test
{
    [TestClass]
    public class HarryPotterDiscountTest
    {

        [TestMethod]
        public void Buy_One_Book()
        {
            // arrange
            var target = new HarryPotterDiscount();
            var shoppingItems = new SaleBook[] {
                new SaleBook { ISBN="9573317249", Name="哈利波特(1)：神秘的魔法石", Price=100, Count=1 }
            };

            var expected = 100m;

            // act
            var actual = target.CaculateByDiscount(shoppingItems);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
