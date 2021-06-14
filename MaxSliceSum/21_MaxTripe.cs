namespace MaxTripe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");
    // https://app.codility.com/programmers/lessons/9-maximum_slice_problem/max_profit/

    class Solution
    {
        static List<int> sums = new List<int>();
        public int solution(int[] A)
        {
            sums.Clear();
            if (A.Length <= 3)
                return 0;


            var data = A.ToList();
            data.RemoveAll(t => t == 0);
            data.RemoveAt(0);
            data.RemoveAt(data.Count-1);
            A =data.ToArray();

            int k = 0;
            var s = 0;

            for (k = 0; k < A.Length-1; k++)
            {
                if (0 < A[k] && 0 < A[k+1])
                {
                    s += A[k];
                }
                else
                {
                    sums.Add(A[k]);
                    s = 0;
                }
            }

            if (A.Last() > 0)
            {
                if (sums[sums.Count - 1] > 0)
                    sums[sums.Count - 1] += data.Last() + s;
                else
                    sums.Add(data.Last());
            }



            int sum = sums[0];
            int c = sums.Count;

            for (int i = 0; i < c - 2; i += 2)
            {
                if (sum + sums[i + 1] > 0)
                {
                    sum = sum + sums[i + 1] + sums[i + 2];
                    sums.Add(sum);
                }
                else
                    sum = sums[i + 2];

            }

            return sums.Max();
        }


        public static void Test()
        {
            var s = 0;
            //var s = new Solution().solution(new int[] { 3, 2, -6, 4, 0 });
            //Console.WriteLine(s);

            //s = new Solution().solution(new int[] { 3, 2, -6 });
            //Console.WriteLine(s);

            //var ss = new Solution().solution(new int[] { 3, -9, 6 });
            //Console.WriteLine(ss);

            //s = new Solution().solution(new int[] { -3, -2, -6 });
            //Console.WriteLine(s);

            s = new Solution().solution(new int[] { -3, 7, 6 });
            Console.WriteLine(s);

            //s = new Solution().solution(new int[] { -3, 6,-2 });
            //Console.WriteLine(s);

            //s = new Solution().solution(new int[] { -3, 6, -2,8 });
            //Console.WriteLine(s);

            //s = new Solution().solution(new int[] { -3, 6, -2, 8,9,4,3,-4,7 });
            //Console.WriteLine(s);

            s = new Solution().solution(new int[] { -3, 6, -2, 8, 9, 4, 3, -4, 7 });
            Console.WriteLine(s);

            var st = new Solution().solution(new int[] { 3, 2, -6 });
            Console.WriteLine(st);
        }
    }
}
