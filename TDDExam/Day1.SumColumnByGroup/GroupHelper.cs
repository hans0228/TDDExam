using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.GroupSumByColumn
{
    public class GroupHelper
    {
        public static int[] SumByColumn<T>(T[] collection, int groupRows, Func<T, int> func)
        {
            var count = collection.Length;
            int skip = 0;

            if (groupRows < 0 )
                throw new ArgumentOutOfRangeException("groupRows shouldn be bigger than zero");


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
    }
}
