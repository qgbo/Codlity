
namespace TapeEquilibrium
{
    using System;
    using System.Linq;
    class Solution
    {

        public int solution(int[] A)
        {
            var result = long.MaxValue;
            long sum = A.Sum();

            long c = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                c += A[i];
                if (result > Math.Abs((long)(sum - 2 * c)))
                    result = Math.Abs((long)(sum - 2 * c));

                if (result == 0)
                    return 0;
            }


            return (int)result;
        }

        public static void Test()
        {
            var s = new Solution().solution(new int[] {-8,7});
            Console.WriteLine(s);
        }
    }
}
