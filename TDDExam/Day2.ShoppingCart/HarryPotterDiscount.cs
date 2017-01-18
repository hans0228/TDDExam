using System;
using System.Collections.Generic;
using Day2.ShoppingCart.Test;
using System.Linq;

namespace Day2.ShoppingCart
{
    public class HarryPotterDiscount
    {
        // 哈利波特書籍編號
        private readonly string[] _harryPotters ={
            "9573317249",
            "9573317583",
            "9573318008",
            "9573318318",
            "9573319861"};

        // 書籍種類與折扣 mapping 
        private readonly Dictionary<int, decimal> _discountByBookTypes =
            new Dictionary<int, decimal>
        {
            {1,1 },
            {2,0.95m },
            {3,0.9m },
            {4,0.8m },
            {5,0.75m }
        };

        public HarryPotterDiscount()
        {
        }

        public decimal CaculateDiscount(SaleBook[] shoppingItems)
        {
            // 找出 HarryPotter 系列書籍，產生一個新的集合
            var books = shoppingItems.Where(x => _harryPotters.Contains(x.ISBN)
                                                 && x.Count > 0).ToArray();

            var totalAmount = 0m;

            while (books.Sum(x => x.Count) > 0)
            {
                // 書籍種類個數
                var bookTypes = books.Count();

                // 依據書籍種類個數的價格加總，即每個種類取 1 本價格加總，再乘上相對應種類的折扣數
                totalAmount += books.Sum(x => x.Price) * _discountByBookTypes[bookTypes];


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