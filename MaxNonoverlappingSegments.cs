using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
   //     public int solution(int[] A, int[] B)
   //     {
   //         var data = new List<Segment>();
			//for (int i = 0; i < A.Length; i++)
			//{
   //             data.Add(new Segment() { a=A[i],b=B[i],i=i});
			//}
            


   //         var c = new List<int>();
			//for (int i = 0; i < data.Count; i++)
			//{
   //             var d = data.Where(t => t.a >= data[i].a && t.b <= data[i].b && t.i != i);
   //             if (d.Count()>0)
   //             { 
   //                 c.AddRange(d.Select(t => t.i));
                    
   //                 i = c.Last()+1;
   //                 if (i == data.Count - 1)
   //                     break;
   //             }
                   
   //         }

   //         data.RemoveAll(t=>c.Contains(t.i));

   //         for (int i = 0; i < data.Count; i++)
   //         {
   //             data[i].i = i;
   //         }

   //         var result = 0;
   //         data = data.OrderBy(t => t.a).ToList();
   //         for (int i = 0; i < data.Count;)
   //         {
   //             result++;

   //            var e= data.FirstOrDefault(t=>t.a> data[i].b);
   //             if (e == null)
   //                 return result;
   //             else
   //                 i=e.i;
   //         }

   //         return result;
   //     }

        public int solution(int[] A, int[] B)
        {
            var data = new List<Segment>();
            for (int i = 0; i < A.Length; i++)
            {
                data.Add(new Segment() { a = A[i], b = B[i], i = i });
            }

            data = data.OrderBy(t => t.a).ToList();

            var c = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                if (c.Contains(i))
                    continue;
                var item = data[i];

                var d = data.Where(t => t.a >= item.a && t.b <= item.b && t.i != i);
                if (d.Count() > 0)
                {
                    c.AddRange(d.Select(t=>t.i));
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

                var e = data.FirstOrDefault(t => t.a > data[i].b);
                if (e == null)
                    return result;
                else
                    i = e.i;
            }

            return result;
        }

        public static void Test()
        {
            var s = new Solution().solution(new int[] { 1,3,7,9,9}, new int[] {5,6,8,9,10 });
            Console.WriteLine(s);

           var  s2 = new Solution().solution(new int[] { 1, 3, 6, 9, 9 }, new int[] { 5, 6, 9, 9, 10 });
            Console.WriteLine(s2);

            s = new Solution().solution(new int[] { 1, 2, 5, 7, 9 }, new int[] { 2, 4, 6, 8, 10 });
            Console.WriteLine(s);
        }
    }
}
