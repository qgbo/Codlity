

namespace DiamondsCount
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
            var s = index.OrderBy(t => t).ToArray();
            this.i0 = s[0];
            this.i1 = s[1];
            this.i2 = s[2];
            this.i3 = s[3];
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var p = obj as point4;
            return p.i0 == i0 && p.i1 == i1 && p.i2 == i2 && p.i3 == i3;
            // TODO: write your implementation of Equals() here
            throw new NotImplementedException();
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
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


            var result = 0;
            var used = new List<int>();
            var zh = new List<P>();

            for (int i = 0; i < points.Count; i++)
            {
                var p0 = points[i]; 
                used.Add(p0.i);
                var ppp = points.Where(t => true);
                foreach (var p1 in ppp.Where(p1 => (p1.x == p0.x) && Math.Abs(p1.y - p0.y) % 2 == 0))
                {
                    foreach (var p2 in ppp.Where(p2 => (2 * p2.y == p0.y + p1.y) && p2.x > p0.x))
                    {
                        if (ppp.Any(p3 => (p3.y == p2.y) && (p3.x + p2.x == 2 * p1.x)))
                        {
                            result++;
                            Console.WriteLine($"{p0.i},{p1.i},{p2.i}");
                            break;
                        }
                    }
                }

                foreach (var p1 in ppp.Where(p1 => (p1.y == p0.y) && Math.Abs(p1.x - p0.x) % 2 == 0))
                {
                    foreach (var p2 in ppp.Where(p2 => (2 * p2.x == p0.x + p1.x) && (p2.y > p0.y)))
                    {
                        if (ppp.Any(p3 => (p3.x == p2.x) && (p3.y + p2.y == 2 * p1.y)))
                        {
                            result++;
                            Console.WriteLine($"{p0.i},{p1.i},{p2.i}");
                            break;
                        }

                    }
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


             s = new Solution().solution(new int[] { 1, 1, 2,  2, 3, 3 }, new int[] { 3, 4, 1,  5, 3, 4 });
            Console.WriteLine(s);



            // hang the air
            //var s = solution2(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
            //Console.WriteLine(s);

        }
    }
}
