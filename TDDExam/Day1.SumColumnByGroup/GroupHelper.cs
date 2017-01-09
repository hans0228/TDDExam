using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.GroupSumByColumn
{
    public class GroupHelper
    {
        public static int[] SumByColumn<T>(T[] collection, int groupRows, Func<T,int> func)
        {
            var count = collection.Length;
            int skip = 0;

            if (groupRows > count)
                throw new ArgumentOutOfRangeException("groupRows shouldn't bigger than Collection Length");


            List<int> result = new List<int>();
            int sum;
            while (count - skip > 0)
            {
                sum = collection.Skip(skip).Take(groupRows).Sum(func);
                result.Add(sum);
                skip += groupRows;
            }

            return result.ToArray();
        }

        //public static int[] SumByCost(Book[] books, int groupRows)
        //{
        //    var count = books.Length;
        //    int skip = 0;

        //    List<int> result = new List<int>();
        //    int sum;
        //    while (count - skip > 0)
        //    {
        //        sum = books.Skip(skip).Take(groupRows).Sum(x => x.Cost);
        //        result.Add(sum);
        //        skip += groupRows;
        //    }

        //    return result.ToArray();
        //}

        //public static int[] SumByRevenu(Book[] books,int groupRows)
        //{
        //    var count = books.Length;
        //    int skip = 0;

        //    List<int> result = new List<int>();
        //    int sum;
        //    while (count - skip > 0)
        //    {
        //        sum = books.Skip(skip).Take(groupRows).Sum(x => x.Revenu);
        //        result.Add(sum);
        //        skip += groupRows;
        //    }

        //    return result.ToArray();
        //}
    }
}
