

namespace DiamondsCount_NoEfiency3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

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

    public class point4
    {

        public readonly int i0;
        public readonly int i1;
        public readonly int i2;
        public readonly int i3;


        public point4(params int[] index)
        {
            // index = index.OrderBy(t => t).ToArray() ;
            this.i0 = index[0];
            this.i1 = index[1];
            this.i2 = index[2];
            this.i3 = index[3];
        }
    }
    public class Solution
    {

        public int solution(int[] X, int[] Y)
        {
            var points = new List<P>();
            for (int i = 0; i < X.Length; i++)
            {
                if (!points.Any(t => t.x == X[i] && t.y == Y[i]))
                    points.Add(new P(X[i], Y[i], points.Count));
            }



            points = points.OrderBy(t => t.x).ToList();

            var point4s = new List<point4>();

            var result = 0;
            var used = new List<int>();

            var leftCollection = points.Where(t=> t.y!=Y.Max() || t.y != Y.Min() || t.x !=X.Max() );
            foreach (var p0 in leftCollection)
            {
                used.Add(p0.i);
                var ppp = points.Where(t => !used.Contains(t.i));

                foreach (var p1 in ppp.Where(p1 => (p1.y == p0.y) && (p1.x - p0.x) % 2 == 0))
                {
                    var vertical = ppp.Where(t => 2 * t.x == p0.x + p1.x).ToArray();
                    // 这样也行，比较意外。语法而已，性能仍然没解决
                    result+= vertical.Count(p2 => p2.y > p0.y && vertical.Any(p3 => p3.y + p2.y == 2 * p1.y));
                }
            }


            return result;
        }

        public static void Test()
        {
            //var s = new Solution().solution(new int[] {  1, 3, 2, 2, 2, 1, 3 }, new int[] {  3, 3, 1, 3, 5, 4, 4 });
            //Console.WriteLine(s);

            var s = new Solution().solution(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
            Console.WriteLine(s);




            // hang the air
            //var s = solution2(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
            //Console.WriteLine(s);

        }
    }
}
