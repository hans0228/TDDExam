using System;
using Day2.ShoppingCart.Test;
using Day1.GroupSumByColumn;
using System.Linq;

namespace Day2.ShoppingCart
{
    public class HarryPotterDiscount
    {
        private SaleBook[] harryPotters =
            new SaleBook[] {
                new SaleBook { ISBN="9573317249", Name="哈利波特(1)：神秘的魔法石", Price=0, Count=0 },
                new SaleBook { ISBN="9573317583", Name="哈利波特(2)：消失的密室", Price=0, Count=0 },
                new SaleBook { ISBN="9573318008", Name="哈利波特(3)：阿茲卡班的逃犯", Price=0, Count=0 },
                new SaleBook { ISBN="9573318318", Name="哈利波特(4)：火盃的考驗", Price=0, Count=0 },
                new SaleBook { ISBN="9573319861", Name="哈利波特(5)：鳳凰會的密令", Price=0, Count=0 }
            };

        public HarryPotterDiscount()
        {
        }

        public decimal CaculateDiscount(SaleBook[] shoppingItems)
        {
            // 找出 HarryPotter 系列書籍，並取得售價、購買數量，產生一個新的集合
            var books = harryPotters.Select(y =>
            {
                var book = shoppingItems.FirstOrDefault(x => x.ISBN == y.ISBN);
                if (book == null)
                    return y;

                y.Price = book.Price;
                y.Count = book.Count;
                return y;

            });

            var TotalAmount = 0m;

            while (books.Where(x => x.Count > 0).SumByColumn(x => x.Count) > 0)
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

                books = books.Select(x =>
                {
                    x.Count = x.Count - 1;
                    return x;
                });
            }

            return TotalAmount;
        }
    }
}