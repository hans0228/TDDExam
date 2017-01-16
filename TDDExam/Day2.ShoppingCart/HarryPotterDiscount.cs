using System;
using Day2.ShoppingCart.Test;
using Day1.GroupSumByColumn;
using System.Linq;

namespace Day2.ShoppingCart
{
    public class HarryPotterDiscount
    {
        private string[] harryPotterISBNs = { "9573317249", "9573317583" };
        public HarryPotterDiscount()
        {
        }

        public decimal CaculateDiscount(SaleBook[] shoppingItems)
        {
            var count = shoppingItems.SumByColumn<SaleBook>(shoppingItems.Length, x => x.Count).First();
            if (count == 1)
            {
                return count * 100;
            }

            if (count == 2 && shoppingItems.All(x => x.Count == 1))
            {
                return count * 100 * 0.95m;
            }

            throw new InvalidOperationException();
        }
    }
}