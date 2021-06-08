using System;
using System.Collections.Generic;
using System.Linq;

namespace FloodDepth2
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
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            var AIndex = new List<Tup>();
            for (int i = 0; i < A.Length; i++)
            {
                AIndex.Add(new Tup(A[i], i,false));
            }

            var deeps = new List<int>();

            foreach (var item in AIndex)
            {
                var right = AIndex.Where(t => t.index > item.index && t.a > item.a);
                var left = AIndex.Where(t => t.index < item.index && t.a > item.a);


                if (left.Any() && right.Any())
                {
                    var r = right.Max(t => t.a);
                    var l = left.Max(t => t.a);

                    deeps.Add((r > l ? l : r) - item.a);
                }
            }
            if (!deeps.Any())
                return 0;
            return deeps.Max();
        }

    }


    class FloodDepth
    {
        public static void Test()
        {
            var s =  Solution.solution(new int[] { 1, 3, 2, 1, 2, 1, 5, 3, 3, 4, 2 });
            Console.WriteLine($"Result:{s}");
        }
    }

}
