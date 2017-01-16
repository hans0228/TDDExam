using System;
using Day2.ShoppingCart.Test;
using Day1.GroupSumByColumn;
using System.Linq;

namespace Day2.ShoppingCart
{
    public class HarryPotterDiscount
    {
        private string[] harryPotters ={
            "9573317249",
            "9573317583",
            "9573318008",
            "9573318318",
            "9573319861"};

        public HarryPotterDiscount()
        {
        }

        public decimal CaculateDiscount(SaleBook[] shoppingItems)
        {
            // 找出 HarryPotter 系列書籍，產生一個新的集合
            var books = shoppingItems.Where(x => harryPotters.Contains(x.ISBN) 
                                                 && x.Count > 0).ToArray();

            var totalAmount = 0m;

            while (books.SumByColumn(x => x.Count) > 0)
            {
                // 書籍種類個數
                var bookTypes = books.Count();
                if (bookTypes == 5)
                {
                    totalAmount += books.SumByColumn(x => x.Price) * 0.75m;
                }

                if (bookTypes == 4)
                {
                    totalAmount += books.SumByColumn(x => x.Price) * 0.8m;
                }

                if (bookTypes == 3)
                {
                    totalAmount += books.SumByColumn(x => x.Price) * 0.9m;
                }

                if (bookTypes == 2)
                {
                    totalAmount += books.SumByColumn(x => x.Price) * 0.95m;
                }

                if (bookTypes == 1)
                {
                    totalAmount += books.SumByColumn(x => x.Price);
                }

                // 避免有 multiple enumraton 的問題，補上 ToArray()
                // 行號 25、64，不加上 ToArray()，測試案例就會有錯
                books = books.Select(x =>
                {
                    x.Count--;
                    return x;
                }).Where(x => x.Count > 0).ToArray();

            }

            return totalAmount;
        }
    }
}