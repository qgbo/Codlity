using System;
using System.Collections;
using System.Linq;

namespace Dominator
{
    class Solution
    {

        public static int solution(int[] A)
        {
            if (A == null)
                return -1;

            if (A.Length == 1)
                return 0;

            var a = A.GroupBy(t => t).FirstOrDefault(t => t.Count() > A.Length / 2);
            if (a==null)
                return -1;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == a.Key)
                    return i;
            }

            return -1;
        }

        public static void Test()
        {
            var s = solution(new int[] { 1,5,3, 4, 3, 2, 3, 3, 3, 3} );
            Console.WriteLine(s);



        }
    }
}
