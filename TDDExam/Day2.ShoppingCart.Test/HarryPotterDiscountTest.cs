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
            var actual = target.CaculateDiscount(shoppingItems);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_First_One_Second_Two()
        {
            // arrange
            var target = new HarryPotterDiscount();
            var shoppingItems = new SaleBook[] {
                new SaleBook { ISBN="9573317249", Name="哈利波特(1)：神秘的魔法石", Price=100, Count=1 },
                new SaleBook { ISBN="9573317583", Name="哈利波特(2)：消失的密室", Price=100, Count=1 }
            };

            var expected = 190m;

            // act
            var actual = target.CaculateDiscount(shoppingItems);

            // assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Buy_First_To_Third_Each_One_Book()
        {
            // arrange
            var target = new HarryPotterDiscount();
            var shoppingItems = new SaleBook[] {
                new SaleBook { ISBN="9573317249", Name="哈利波特(1)：神秘的魔法石", Price=100, Count=1 },
                new SaleBook { ISBN="9573317583", Name="哈利波特(2)：消失的密室", Price=100, Count=1 },
                new SaleBook { ISBN="9573318008", Name="哈利波特(3)：阿茲卡班的逃犯", Price=100, Count=1 }
            };

            var expected = 270m;

            // act
            var actual = target.CaculateDiscount(shoppingItems);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_First_To_Fourth_Each_One_Book()
        {
            // arrange
            var target = new HarryPotterDiscount();
            var shoppingItems = new SaleBook[] {
                new SaleBook { ISBN="9573317249", Name="哈利波特(1)：神秘的魔法石", Price=100, Count=1 },
                new SaleBook { ISBN="9573317583", Name="哈利波特(2)：消失的密室", Price=100, Count=1 },
                new SaleBook { ISBN="9573318008", Name="哈利波特(3)：阿茲卡班的逃犯", Price=100, Count=1 },
                new SaleBook { ISBN="9573318318", Name="哈利波特(4)：火盃的考驗", Price=100, Count=1 }
            };

            var expected = 320m;

            // act
            var actual = target.CaculateDiscount(shoppingItems);

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Buy_First_To_Fifth_Each_One_Book()
        {
            // arrange
            var target = new HarryPotterDiscount();
            var shoppingItems = new SaleBook[] {
                new SaleBook { ISBN="9573317249", Name="哈利波特(1)：神秘的魔法石", Price=100, Count=1 },
                new SaleBook { ISBN="9573317583", Name="哈利波特(2)：消失的密室", Price=100, Count=1 },
                new SaleBook { ISBN="9573318008", Name="哈利波特(3)：阿茲卡班的逃犯", Price=100, Count=1 },
                new SaleBook { ISBN="9573318318", Name="哈利波特(4)：火盃的考驗", Price=100, Count=1 },
                new SaleBook { ISBN="9573319861", Name="哈利波特(5)：鳳凰會的密令", Price=100, Count=1 }
            };

            var expected = 375m;

            // act
            var actual = target.CaculateDiscount(shoppingItems);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_First_To_Second_Each_One_And_Buy_Third_Two_Book()
        {
            // arrange
            var target = new HarryPotterDiscount();
            var shoppingItems = new SaleBook[] {
                new SaleBook { ISBN="9573317249", Name="哈利波特(1)：神秘的魔法石", Price=100, Count=1 },
                new SaleBook { ISBN="9573317583", Name="哈利波特(2)：消失的密室", Price=100, Count=1 },
                new SaleBook { ISBN="9573318008", Name="哈利波特(3)：阿茲卡班的逃犯", Price=100, Count=2 },
                new SaleBook { ISBN="9573318318", Name="哈利波特(4)：火盃的考驗", Price=100, Count=0 },
                new SaleBook { ISBN="9573319861", Name="哈利波特(5)：鳳凰會的密令", Price=100, Count=0 }
            };

            var expected = 375m;

            // act
            var actual = target.CaculateDiscount(shoppingItems);

            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}
