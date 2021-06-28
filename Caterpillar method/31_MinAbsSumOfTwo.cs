using System;
using System.Collections.Generic;
using System.Linq;

namespace MinAbsSumOfTwo
{
    class Solution
    {
        public int solution(int[] A)
        {
            if (A.Length == 1)
                return Math.Abs(A[0] * 2);

            var minlist = new List<int>();

             A = A.OrderBy(t =>Math.Abs(t)).ToArray();

            var min = Math.Abs(A[0])*2;

            for (int i = 0; i < A.Length-1; i++)
            {
                if ((A[i] > 0 && A[i + 1] < 0) || (A[i] < 0 && A[i + 1] > 0))
                {
                    if (Math.Abs(A[i] + A[i + 1]) < min)
                    { 
                        min = Math.Abs(A[i] + A[i + 1]);
                    }
                }
            }
            return min;
        }
        public int solution4(int[] A)
        {
            if (A.Length == 1)
                return Math.Abs(A[0] * 2);

            var minlist = new List<int>();

            var data = A.OrderBy(t => t).ToList();



            var datap = data.SkipWhile(t => t <= 0).ToList();
            if (datap.Any())
                minlist.Add(datap.Min() * 2);
            else
                return -data.TakeWhile(t => t < 0).ToList().Max() * 2;

            var datan = data.TakeWhile(t => t < 0).ToList();
            if (datan.Any())
                minlist.Add(-datan.Max() * 2);
            else
                return datap[0] * 2;

            var min = minlist.Min();

            foreach (var n in datan.ToArray().Reverse())
            {
                if (datap[0] > -n && Math.Abs(datap[0] + n) > min)
                    return min;
                foreach (var p in datap)
                {
                    var t = Math.Abs(p + n);

                    if (t == 0)
                        return 0;

                    if (min > t)
                    {
                        min = t;
                    }

                    if (p > -n)
                    {
                        break;
                    }
                }
            }
            return min;
        }


        public int solution3(int[] A)
        {
            var minlist = new List<int>();

            var data = A.OrderBy(t => t).ToList();

            var datan = data.TakeWhile(t => t < 0).ToList();
            if (datan.Any())
                minlist.Add(-datan.Max() * 2);

            var datap = data.SkipWhile(t => t < 0).ToList();
            if (datap.Any())
                minlist.Add(datap.Min() * 2);

            var min = minlist.Min();

            foreach (var n in datan.ToArray().Reverse())
            {
                foreach (var p in datap)
                {
                    var t = Math.Abs(p + n);

                    if (t == 0)
                        return 0;

                    if (min > t)
                    {
                        min = t;
                    }

                    if (p > -n)
                    {
                        break;
                    }
                }
            }
            return min;
        }

        public int solution2(int[] A)
        {
            var min = Math.Abs(A[0] + A[0]);


            for (int i = 0; i < A.Length; i++)
            {
                for (int k = i; k < A.Length; k++)
                {
                    var t = Math.Abs(A[i] + A[k]);
                    if (min > t)
                        min = t;

                }
            }

            return min;
        }


        public static void Test()
        {
            var s2 = 0;
            //s2 = new Solution().solution(new int[] { 1, 4, -3 });
            //Console.WriteLine(s2);

            s2 = new Solution().solution(new int[] { -8, 4, 5, -10, 3 });
            Console.WriteLine(s2);

            s2 = new Solution().solution(new int[] { -8 });
            Console.WriteLine(s2);

            s2 = new Solution().solution(new int[] { 12 });
            Console.WriteLine(s2);

            s2 = new Solution().solution(new int[] { -12,-41 });
            Console.WriteLine(s2);

            s2 = new Solution().solution(new int[] { 5, 10 });
            Console.WriteLine(s2);

        }

    }
}
