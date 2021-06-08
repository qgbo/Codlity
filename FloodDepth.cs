using System;
using System.Collections.Generic;
using System.Linq;

namespace FloodDepth3
{
    class Tup
    {

        public int a;
        public int index;
        public bool ismin;

        public Tup(int a1, int index1, bool ismin1)
        {
            a = a1;
            index = index1;
            ismin = ismin1;
        }

    }
    class Solution
    {

        static  List<int>  deeps = new List<int>();
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length <= 2)
                return 0;

            var AIndex = new List<Tup>();

            if (A[0] >= A[1])
                AIndex.Add(new Tup(A[0], AIndex.Count, false));

            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i - 1] <= A[i] && A[i] <= A[i + 1])
                    continue;

                if (A[i - 1] >= A[i] && A[i] >= A[i + 1])
                    continue;

                if (A[i - 1] == A[i] && i != A.Length - 1)
                    continue;

                AIndex.Add(new Tup(A[i], AIndex.Count, A[i - 1] >= A[i] && A[i] <= A[i + 1]));

            }

            if (A.Last() >= A[A.Length - 2])
                AIndex.Add(new Tup(A.Last(), AIndex.Count, false));

            if (AIndex.Count <= 2)
                return 0;

            var max = AIndex.Max(t => t.a);
            var g=AIndex.GroupBy(t => t.a).OrderByDescending(t=>t.Key).ToArray();

            for (int i = 0; i < g.Count(); i++)
            {
                if (g[i].Count() > 0)
                {
                    var xx=g[i].OrderBy(t => t.index).ToArray();
                    for (int j = 0; j < xx.Length-1; j++)
                    {
                        deeps.Add(g[i].Key-  AIndex.Skip(xx[j].index).Take(xx[j+1].index- xx[j].index).Min(t=>t.a));
                    } 
                }
            }

            var max2 = AIndex.OrderBy(t=>t.a).FirstOrDefault();

            if (!deeps.Any())
                return 0;


            return deeps.Max();
        }


    }


    class FloodDepth
    {
        public static void Test()
        {
            var s = new Solution().solution(new int[] { 1, 3, 2, 1, 2, 1, 5, 3, 3, 4, 2 });
            Console.WriteLine($"Result:{s}");
        }
    }

}
