namespace ForceRecursion.CoinsExample
{
    using System;
    using System.Linq;

    /// <summary>
    ///  一些面值的货币，兑换K元 的方法数
    /// </summary>
    class Solution
    {
        public int solution(int[] A, int K)
        {
            if (K == 0)
            {
                Console.WriteLine("K is 0 :1");
                return 1;
            }


            if (!A.Any())
            {
                Console.WriteLine("A empty :0");
                return 0;
            }


            A = A.OrderByDescending(t => t).ToArray();

            if (K < A.Max() && !A.Any(t=> K%t==0))
            {
                Console.WriteLine("not :0");
                return 0;
            }


            if (A.Length == 1 && K % A[0] == 0)
            {
                Console.WriteLine("only :1");
                return 1;
            }


            var r = 0;

            var a = A.Skip(1).ToArray();
            // use A[i] t
            for (int t = 0; K - A[0] * t >= 0; t++)
            {
                var m = solution(a, K - A[0] * t);
                Console.WriteLine($"面额{A[0]}，数量{t}, m:{m}, K:{K}  remaining:{ K - A[0] * t}, A:{a.Join()}");

                r += m;
            }
            return r;
        }


        public static void Test()
        {

            var s1 = new Solution().solution(new int[] { 1, 4 },3);
            Console.WriteLine("-------------result:" + s1);


            var s2 = new Solution().solution(new int[] { 1, 4, 5 }, 13);
            Console.WriteLine("result:" + s2);

        }
    }
}