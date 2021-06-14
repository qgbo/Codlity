

namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class P
    {
        public int x;
        public int y;
        public int i;

        public P(int x, int y, int i)
        {
            this.x = x;
            this.y = y;
            this.i = i;
        }
    }

    public class P3
    {
        public int i1;
        public int i2;
        public int not;
        public bool line;

        public P3(int i1, int i2, int not, bool line = false)
        {
            this.i1 = i1;
            this.i2 = i2;
            this.not = not;
            this.line = line;
        }
    }


    public class Solution
    {
        public int solution()
        {
            var points = new List<int>();
            for (int i = 0; i <20; i++)
            {
                    points.Add(i);
            }

            var used = new List<int>();
            foreach (var p0 in points)
            {
                used.Add(p0);
                var pp = points.Where(t => !used.Contains(t)).ToArray();
                foreach (var p1 in pp)
                {
                    foreach (var p2 in pp)
                    {
                        Console.WriteLine($"{ p0},{ p1}");
                    }
                }
            }

            
            return 0;
        }

        public static void Test()
        {
            //var s = new Solution().solution(new int[] {  1, 3, 2, 2, 2, 1, 3 }, new int[] {  3, 3, 1, 3, 5, 4, 4 });
            //Console.WriteLine(s);

            var s = new Solution().solution();
            Console.WriteLine(s);

            // hang the air
            //var s = solution2(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
            //Console.WriteLine(s);

        }
    }
}
