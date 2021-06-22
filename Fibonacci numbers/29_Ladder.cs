

namespace Ladder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    class Solution
    {
        static double[] list = Fab();
        static double[] Fab()
        {
            var r = new double[200];
            r[0] = 1;
            r[1] = 1;
            for (int i = 2; i < 200; i++)
            {
                r[i] = r[i - 1] + r[i - 2];
                Console.WriteLine(r[i]+"-----"+ r[i]/1000);
            }
            return r;
        }

        static long Fab2(int a, int b)
        {
            var r = new List<long>();
            r[0] = 1;
            r[1] = 1;
            for (int i = 2; i < a - b; i++)
            {
                r[i] = r[i - 1] + r[i - 2];
            }
            return r[a - b - 1];
        }

        static double liq(int b)
        {
            return Math.Pow(2, b);
        }

        public int[] solution(int[] A, int[] B)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                //if (A[i] < 90)
                    result.Add((int)(list[A[i]] % liq(B[i])));
                //else
                //    result.Add((int)Fab2(A[i], B[i]));
            }

            return result.ToArray(); ;
        }


        public static void Test()
        {

            var s2 = new Solution().solution(new int[] { 4, 4, 5, 5, 1 }, new int[] { 3, 2, 4, 3, 1 });
            Console.WriteLine(s2.Join());

        }
    }
}