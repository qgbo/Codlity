
namespace PermCheck
{
    using System;
    using System.Linq;
    class Solution
    {

        public int solution2(int[] A)
        {
            return A.Any(t => t > A.Length) ? 0 : 1;
        }

        public int solution(int[] A)
        {

            var B = new int[A.Length];
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = -1;
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > A.Length)
                    return 0;


                var v = A[i] - 1;

                if (B[v] == -1)
                {
                    B[v] = v;
                    continue;
                }

                return 0;
            }

            return 1;
        }

        public static void Test()
        {
            var s = new Solution().solution(new int[] {1,1});
            Console.WriteLine(s);

             s = new Solution().solution(new int[] { 5, 4, 2, 3, 1 });
            Console.WriteLine(s);
        }
    }
}
