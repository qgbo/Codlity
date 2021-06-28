using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace MaxNonoverlappingSegments
{
    class Segment
    {
        public int a;
        public int b;
        public int i;
    }

    class Solution
    {
        /// <summary>
        ///  100 score https://app.codility.com/demo/results/training5274AB-ABA/
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int solution(int[] A, int[] B)
        {
            if (A.Length == 0)
                return 0;

            var result = 1;
            var c = 0;

            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > B[c])
                {
                    result++;
                    c = i;
                }
            }

            return result;
        }


        public int solution2(int[] A, int[] B)
        {
            var data = new List<Segment>();
            for (int i = 0; i < A.Length; i++)
            {
                data.Add(new Segment() { a = A[i], b = B[i] });
            }

            data = data.OrderBy(t => t.a).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                data[i].i = i;
            }

            var c = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                if (c.Contains(i))
                    continue;
                var item = data[i];

                var d = data.Where(t => t.a >= item.a && t.b <= item.b && t.i != i && !c.Contains(t.i));
                if (d.Count() > 0)
                {
                    c.Add(i);
                }
            }

            data.RemoveAll(t => c.Contains(t.i));

            for (int i = 0; i < data.Count; i++)
            {
                data[i].i = i;
            }

            var result = 0;
            data = data.OrderBy(t => t.a).ToList();
            for (int i = 0; i < data.Count;)
            {
                result++;

                var e = data.Skip(i).FirstOrDefault(t => t.a > data[i].b);
                if (e == null)
                    return result;
                else
                    i = e.i;
            }

            return result;
        }

        public static void Test()
        {
            var s = new Solution().solution2(new int[] { 1, 3, 7, 9, 9,0 }, new int[] { 5, 6, 8, 9, 10,20 });
            Console.WriteLine(s);

            var s2 = new Solution().solution(new int[] { 1, 3, 6, 9, 9 }, new int[] { 5, 6, 9, 9, 10 });
            Console.WriteLine(s2);

            Random randNum = new Random();

            for (int i = 0; i < 10; i++)
            {
                var data = new List<Segment>();
                for (int j = 0; j < 19; j++)
                {
                    var w = randNum.Next(0, 50);
                    var w2 = randNum.Next(0, 50);

                    data.Add(new Segment() { a = w >= w2 ? w2 : w, b = w > w2 ? w : w2, i = j });
                }
                data = data.OrderBy(t => t.b).ToList();

                var t1 = data.Select(t => t.a).ToArray();

                var t2 = data.Select(t => t.b).ToArray();

                s =new Solution().solution(t1, t2);
            

                 s2 = new Solution().solution2(t1, t2);
              

                if (s != s2) {
                    Console.WriteLine(t1.Join()+"=="+s);
                    Console.WriteLine(t2.Join() + "==" + s2);
                    Console.WriteLine();
                }

            }
            Console.WriteLine("over");
        }
    }
}
