

namespace PermCheck
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    // 解决完了很简单。
    // 怎么在循环中避免遍历集合，是性能瓶颈
    class Solution
    {
        public int solution(int[] A)
        {
            return A.Any(t=>t> A.Length)?0:1;
        }

        public static void Test()
        {
            var s = new Solution().solution(new int[] {4,1,3,2} );
            Console.WriteLine(s);

             s = new Solution().solution(new int[] { 4, 1, 3});
            Console.WriteLine(s);
        }
    }
}
