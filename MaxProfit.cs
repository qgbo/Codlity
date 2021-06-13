namespace MaxProfit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");
    // 小题，竟然用到了递归！
    public class P
    {
        public int v;
        public int i;

        public P(int v, int i)
        {
            this.v = v;
            this.i = i;
        }
    }
    class Solution
    {
        static List<int> profit = new List<int>();
        public int solution(int[] A)
        {
            if (A?.Length <=1 )
            {
                return 0;
            }

            if (A.Length == 2)
            {
                if (A[0] <= A[1])
                    return A[1] - A[0];
                else
                    return 0;
            }

            var data = new List<int>();

            int k = 0;
            for (k = 0; k < A.Length - 1; k++)
            {
                if (A[k] < A[k + 1])
                    break;
            }


            data.Add((A[k]));
            for (int i = k+1; i < A.Length - 1; i++)
            {
                if (A[i - 1] <= A[i] && A[i] <= A[i + 1])
                    continue;

                if (A[i - 1] >= A[i] && A[i] >= A[i + 1])
                    continue;

                data.Add((A[i]));
            }
            data.Add((A[A.Length - 1]));

            Get(data.ToArray());
            if (profit.Count == 0)
                return 0;
            return profit.Max();
        }



        public void Get(int[] A)
        {
            var max = 0;
            var min = 2000000;

            var maxI = 0;
            var minI = 0;


            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < min)
                {
                    min = A[i];
                    minI = i;
                }

                if (A[i] > max)
                {
                    max = A[i];
                    maxI = i;
                }
            }


            if (maxI > minI)
            {
                profit.Add(max - min);
            }
            else
            {
                if (maxI > 0)
                {
                    min = A.Take(maxI).Min();
                    profit.Add(max - min);
                }


                A = A.Skip(maxI + 1).ToArray();

                if (A.Length > 2)
                    Get(A);

                else if (A.Length == 2)
                {
                    if (A[0] < A[1])
                        profit.Add(A[1] - A[0]);
                }



            }
        }

        public static void Test()
        {

            var s = new Solution().solution(new int[] {             23171
,21011
,21123
,21366
,21013
,21367 });
            Console.WriteLine(s);

        }
    }
}
