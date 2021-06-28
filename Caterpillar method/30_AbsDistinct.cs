using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsDistinct
{
    class Solution
    {
        public int solution(int[] A)
        {

            A = A.OrderBy(t => Math.Abs((long)t)).ToArray();

            var a = new List<long>() { Math.Abs((long)A[0]) };
            for (int i = 1; i < A.Length; i++)
            {
                var s = Math.Abs((long)A[i]);
                if (s != a.Last())
                    a.Add(s);
            }

            return a.Count;
        }

        public int solution2(int[] A)
        {
            var a = new List<long>();
            for (int i = 0; i < A.Length; i++)
            {
                if (!a.Contains(Math.Abs((long)A[i])))
                {
                    a.Add(Math.Abs((long)A[i]));
                }
            }

            return a.Count;
        }

        public static void Test()
        {
            var s2 = new Solution().solution(new int[] { -5, -3, -1, 0, 3, 6 });
            Console.WriteLine(s2);

            s2 = new Solution().solution(new int[] { -2147483648, 0 });
            Console.WriteLine(s2);
        }

    }
}
