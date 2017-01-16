using System;
using Day2.ShoppingCart.Test;
using Day1.GroupSumByColumn;
using System.Linq;

namespace Day2.ShoppingCart
{
    public class HarryPotterDiscount
    {
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

            throw new InvalidOperationException();
        }
    }
}