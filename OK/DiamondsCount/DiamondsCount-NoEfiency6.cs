namespace DiamondsCount_NoEfiency5
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

            var xGroup = points.GroupBy(t => t.x).OrderBy(t => t.Key).ToArray();
            var yGroup = points.GroupBy(t => t.y).OrderBy(t => t.Key).ToArray();

            if (xGroup.Length < 3 || yGroup.Length < 3)
                return 0;

            points = points.OrderBy(t => t.x).ToList();

            var result = 0;

            if (xGroup.Length > yGroup.Length)
            {
                var leftCollection = points.Where(t => t.y != Y.Max() || t.y != Y.Min() || t.x != X.Max() || t.x != xGroup[xGroup.Length - 2].Key);

                foreach (var p0 in leftCollection)
                {
                    var line = yGroup.First(g => g.Key == p0.y);

                    foreach (var p1 in line.Where(p1 => p1.x > p0.x + 1))
                    {
                        var c = p0.x + p1.x;
                        if (c % 2 == 0)
                        {
                            var vertical = xGroup.FirstOrDefault(g => g.Key * 2 == c)?.ToArray();
                            if (vertical != null)
                                result += vertical.Count(p2 => p2.y > p0.y && vertical.Any(p3 => p3.y + p2.y == 2 * p1.y));
                        }
                    }
                }
            }

           else 
            {
                var downCollection = points.Where(t => t.x != X.Max() || t.x != X.Min() || t.y != Y.Max() || t.y != yGroup[yGroup.Length - 2].Key);

                foreach (var p0 in downCollection)
                {
                    var line = xGroup.First(g => g.Key == p0.x);

                    foreach (var p1 in line.Where(p1 => p1.y > p0.y + 1))
                    {
                        var c = p0.y + p1.y;
                        if (c % 2 == 0)
                        {
                            var vertical = xGroup.FirstOrDefault(g => g.Key * 2 == c)?.ToArray();
                            if (vertical != null)
                                result += vertical.Count(p2 => p2.x > p0.x && vertical.Any(p3 => p3.x + p2.x == 2 * p1.x));
                        }
                    }
                }
            }
            return result;
        }

        public static void Test()
        {
            var s = new Solution().solution(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
            Console.WriteLine(s);

        }
    }
}
