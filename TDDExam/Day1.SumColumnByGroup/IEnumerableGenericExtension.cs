using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.GroupSumByColumn
{
    public static class IEnumerableGenericExtension
    {
        public static IEnumerable<int> SumByColumn<T>(this IEnumerable<T> collection, int groupRows, Func<T, int> func)
        {
            var count = collection.Count();
            int skip = 0;

            if (groupRows < 0 )
                throw new ArgumentOutOfRangeException("groupRows shouldn be bigger than zero");


            int sum;
            while (skip < count)
            {
                sum = collection.Skip(skip).Take(groupRows).Sum(func);
                yield return sum;
                skip += groupRows;
            }

        }

        public static int SumByColumn<T>(this IEnumerable<T> collection, Func<T, int> func)
        {
            var count = collection.Count();
            return collection.Take(count).Sum(func);
        }
    }
}
