
namespace TieRopes
{
    using System;
    class Solution
    {

        public int solution(int K, int[] A)
        {
            var result = 0;
            var sum = 0;
			foreach (var item in A)
			{
                sum += item;
                if (sum >= K)
                {
                    sum = 0;
                    result++;
                }
			}

            return result;
        }

        public static void Test()
        {
            var s = new Solution().solution(4,new int[] {1,2,3,4,1,1,3});
            Console.WriteLine(s);
        }
    }
}
