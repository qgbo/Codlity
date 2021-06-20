

namespace FibFrog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Data
    {
        public bool v;
        public int i;
    }
    class Solution
    {
        static int[] list = Fab();
        static int[] Fab()
        {
            var r = new int[40];
            r[0] = 1;
            r[1] = 1;
            for (int i = 2; i < 40; i++)
            {
                r[i] = r[i - 1] + r[i - 2];
            }
            return r;
        }

        public bool Isfab(int a)
        {
            return list.Contains(a);
        }

        int target = 0;
        List<List<int>> resultData = new List<List<int>>();
        List<int> data = new List<int>() { -1 };
        public int solution(int[] A)
        {
            if (A == null || A.All(t => t == 0))
                return -1;



            Fab();
            target = A.Length;

            for (int j = 0; j < A.Length; j++)
            {
                if (A[j] == 1)
                    data.Add(j);

            }

          

            var li = data.Skip(1).Where(t => Isfab(t - data[0]));
            foreach (var d in li)
                exe(d, new List<int>() { d });

            if (!resultData.Any(t => t.Last() == -1))
                return -1;

            return resultData.Where(t => t.Last() == -1).Select(t => t.Count()).Min();
        }

        private void exe(int d, List<int> result)
        {
            if (data.Last() == d)
            {
                if (Isfab(target - d))
                {
                    result.Add(-1);
                    resultData.Add(result);
                }
                return;
            }

            var li = data.SkipWhile(t => t <= d);
            foreach (var da in li)
            {
                result.Add(da);
                exe(da, new List<int>(result));
            }

        }

        public int solution2(int[] A)
        {
            var result = 0;


            return result;
        }



        public static void Test()
        {
            var s2 = 0;
            //s2 = new Solution().solution(new int[] { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 });
            //Console.WriteLine(s2);


            //s2 = new Solution().solution(new int[] { 0, 0, 0, 0, 0 });
            //Console.WriteLine(s2);

            s2 = new Solution().solution(new int[] { 1, 1, 1 });
            Console.WriteLine(s2);

        }
    }
}