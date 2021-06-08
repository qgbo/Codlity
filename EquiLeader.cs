using System;
using System.Collections;
using System.Linq;

namespace EquiLeader
{
    class Solution
    {

        public static int solution(int[] A)
        {
          

            if (A.Length == 1)
                return 0;

            var a = A.GroupBy(t => t).FirstOrDefault(t => t.Count() > A.Length / 2);
            if (a==null)
                return 0;

            var result = 0;
            var all=a.Count();
            var c = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == a.Key)
                    c++;

                if ((c > (i + 1) / 2) && (all - c) > (A.Length - i-1)  / 2)
                    result++;

            }

            return result;
        }

        public static void Test()
        {
            var s = solution(new int[] {4, 3, 4, 4, 4, 2} );
            Console.WriteLine(s);



        }
    }
}
