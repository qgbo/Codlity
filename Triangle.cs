using System;
using System.Collections;
using System.Linq;

namespace Triangle
{
    class Solution
    {

        public static int solution(int[] A)
        {
            if (A.Length <= 2)
                return 0;

            var order = A.OrderBy(t => t).ToArray(); ;


            for (int i = 0; i < A.Length-2; i++)
            {
                if (order[i] + order[i + 1] > order[i + 2])
                    return 1;
            }
            return 0;
        }

        public static void Test()
        {
            var s = solution(new int[] {10,50,5} );
            Console.WriteLine(s);

            s = solution(new int[] { 2147483647, 2147483647, 5 });
            Console.WriteLine(s);
            


        }
    }
}
