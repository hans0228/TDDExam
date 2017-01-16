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
            var books = shoppingItems.Where(x => harryPotters.Contains(x.ISBN) && x.Count > 0);

            var TotalAmount = 0m;

            while (books.SumByColumn(x => x.Count) > 0)
            {
                // 有買的書籍
                var buyBooks = books.Where(x => x.Count > 0).Select(x => x);
                // 書籍種類個數
                var bookKinds = buyBooks.Count();
                if (bookKinds == 5)
                {
                    TotalAmount += buyBooks.SumByColumn(x => x.Price) * 0.75m;
                }

                if (bookKinds == 4)
                {
                    TotalAmount += buyBooks.SumByColumn(x => x.Price) * 0.8m;
                }

                if (bookKinds == 3)
                {
                    TotalAmount += buyBooks.SumByColumn(x => x.Price) * 0.9m;
                }

                if (bookKinds == 2)
                {
                    TotalAmount += buyBooks.SumByColumn(x => x.Price) * 0.95m;
                }

                if (bookKinds == 1)
                {
                    TotalAmount += buyBooks.SumByColumn(x => x.Price);
                }

                foreach (var book in books)
                {
                    book.Count--;
                }

                books = books.Where(x => x.Count > 0);
            }

            return TotalAmount;
        }
    }
}