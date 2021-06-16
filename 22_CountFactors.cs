

namespace MinPerimeterRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");
    // https://app.codility.com/demo/results/training5EXCM2-TFH/
    // 解决完了很简单。
    // 怎么在循环中避免遍历集合，是性能瓶颈
    class Solution
    {
        public int solution(int N)
        {
            var q = (int)Math.Ceiling( Math.Sqrt(N));
            int i;
            for ( i = q; i >= 0; i--)
            {
                if (N % i == 0)
                {
                    break;
                }
            }

            Console.WriteLine($" {N}={ i}，{N / i}");
            return (i+ N / i)*2;
        }

        public static void Test()
        {
            //var s = new Solution().solution(30);
           
            //s = new Solution().solution(40);
         

             new Solution().solution(48);
          
            new Solution().solution(25);
          

        }
    }
}
