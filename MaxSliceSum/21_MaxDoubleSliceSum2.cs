namespace MaxDoubleSliceSum2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");
    // https://app.codility.com/programmers/lessons/9-maximum_slice_problem/max_profit/

    class Data
    {
        public int v;
        public int i;
    }

    class Solution
    {
        static List<int> sums = new List<int>();

        /// <summary>
        /// A length is larger than 3
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int get(int[] A)
        {
            return A.Sum() - A.Min();
        }
        public int solution(int[] A)
        {
            sums.Clear();
            if (A.Length <= 3)
                return 0;

            var data = new List<Data>();

            for (int i = 0; i < A.Length; i++)
            {
                data.Add(new Data() {i=i,v=A[i] });
            }

            data.RemoveAt(0);
            data.RemoveAt(data.Count - 1);

            if (data.Count == 2)
                return data[0].i > data[1].i ? data[0].i : data[1].i;

            for (int i = 0; i < data.Count - 1; i++)
            {
                if (data[i].v >= 0 && data[i + 1].v >= 0)
                {
                    var d= data.Skip(i).TakeWhile(t=>t.v>=0).ToArray();
                    data[i].v = d.Select(t=>t.v).Min();
                    data[i + 1].v = d.Sum(t=>t.v) - data[i].v;

                    foreach (var item in d.Skip(2))
                    {
                        item.i = -1;
                    }
                    i += d.Length-1;
                }
            }

            A = data.Where(t => t.i != -1).Select(t => t.v).ToArray();

            for (int i = 0; i < A.Length - 1; i++)
            {

                if ((A[0] > 0 && i==0) || (i>0 && A[i-1]<=0 && A[i]>=0))
                    for (int k = 2; k < A.Length + 1; k++)
                    {
                        if (i + k + 1 <= A.Length - 1 && A[i + k + 1] >= 0)
                            continue;
                        
                        var ss = A.Skip(i).Take(k).Sum() - A.Skip(i).Take(k).Min();
                        if (ss < 0)
                            break;

                        sums.Add(ss);
                    }
            }

            if (sums.Count == 0)
                return 0;

            var s = sums.Max();
            if (s < 0)
                return 0;

            return sums.Max();
        }


        public static void Test()
        {
            var s = 0;
            //s = new Solution().solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 });
            //Console.WriteLine(s);

            //s = new Solution().solution(new int[] { 3, 2, 6, 4,2,3 });
            //Console.WriteLine(s);

            s = new Solution().solution(new int[] { 3, 2, 6,3,11,-3,-4,2,3,7,11,23, 4});
            Console.WriteLine(s);


            s = new Solution().solution(new int[] { 3, 2, -6, -1, 8, 9 });
            Console.WriteLine(s);


        }
    }
}
