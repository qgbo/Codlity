using System;
using System.Collections;
using System.Linq;

namespace MaxProductOfThree
{
    class Solution
    {
        public int solution(int[] A)
        {
            if (A.Length == 3)
                return A[0] * A[1] * A[2];

            var data= A.OrderBy(t => t).ToArray();


            if (data[0] >= 0 || data[data.Length - 1] <= 0)
            {
                return data[data.Length - 3] * data[data.Length - 2] * data[data.Length - 1];
            }

            if (data.Count(t => t > 0) == 1 || data.Count(t => t > 0) == 2)
            {
                return data[0] * data[1] * data[data.Length - 1];
            }
            else
            {
                var s=  data[data.Length - 3] * data[data.Length - 2] * data[data.Length - 1];
                var t= data[0] * data[1] * data[data.Length - 1];

                return s > t ? s : t;
            }
        }

        public static void Test()
        {
            var s = new Solution().solution(new int[] {-3, 1, 2, -2, 5, 6} );
            Console.WriteLine(s);


             s = new Solution().solution(new int[] {  5, 6,4,7,12 });
            Console.WriteLine(s);

            s = new Solution().solution(new int[] { 5, -6, -4, 7, 12,-34 });
            Console.WriteLine(s);

            s = new Solution().solution(new int[] { 5, -6, -4, -7, -12, -34 });
            Console.WriteLine(s);
        }
    }
}
