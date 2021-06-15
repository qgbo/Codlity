

namespace CountFactors
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    // 解决完了很简单。
    // 怎么在循环中避免遍历集合，是性能瓶颈
    class Solution
    {
        
        
        public int solution(int N)
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(N);
            for (int i = 2; i <= N / 2; i++)
            {
                if (N % i == 0)
                {
                    set.Add(i);
                }

            }

            return set.Count;
        }

        public static void Test()
        {
            var s = new Solution().solution(24);
            Console.WriteLine(s);
            Console.WriteLine();

            s = new Solution().solution(16);
            Console.WriteLine(s);

            s = new Solution().solution(18);
            Console.WriteLine(s);
        }
    }
}
