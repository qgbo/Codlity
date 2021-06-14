namespace MaxSliceSum2
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
            if (A.Length == 1)
                return A[0];

            if (A.Length == 2)
            {
                if (A[0] > 0 && A[1] > 0)
                    return A[0] + A[1];
                else
                    return A[0] > A[1] ? A[0] : A[1];
            }


            if (A.All(t => t <= 0))
            {
                return A.Max();
            }

            if (A.All(t => t >= 0))
            {
                return A.Sum();
            }

            var data = A.ToList();
            data.RemoveAll(t => t == 0);
            if (data.Last() > 0)
                data.Add(-1);

            A = data.ToArray();

            int k = 0;
            var s = 0;
            for (k = 0; k < A.Length - 1; k++)
            {
                s += A[k];

                if ((A[k] < 0 && 0 < A[k + 1]) ||
                    (A[k] > 0 && 0 > A[k + 1]))
                {
                    sums.Add(s);
                    s = 0;
                }
            }

            if (sums[0] < 0)
                sums.RemoveAt(0);

            if (sums[sums.Count - 1] < 0)
                sums.RemoveAt(sums.Count - 1);

            if (sums.Count == 2)
            {
                if (sums[0] > 0 && sums[1] > 0)
                    return sums[0] + sums[1];
                else
                    return sums[0] > sums[1] ? sums[0] : sums[1];
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

            s = new Solution().solution(new int[] { -3, 4, -6,45 });
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
