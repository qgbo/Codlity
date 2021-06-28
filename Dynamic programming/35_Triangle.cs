namespace Dynamic.Triangle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Solution
    {
        public int solution(int[][] A)
        {
            var data = new List<List<int>>();
            foreach (var item in A)
            {
                data.Add(new List<int>());
            }

            data[A.Length - 1] = A[A.Length - 1].ToList();

            for (int i = A.Length - 2; i >= 0; i--)
            {  
                for (int j = 0; j < A[i].Length; j++)
                {
                    var m = data[i + 1][j] > data[i + 1][j+1] ? data[i + 1][j] : data[i + 1][j+1];
                    data[i].Add(A[i][j]+ m);
                }
            }
            return data[0][0];
        }

        public int solution2(int[][] A)
        {
            if (A.Length == 2)
            {
                return A[0][0] + (A[1][0] > A[1][1] ? A[1][0] : A[1][1]);
            }

            var left = A.Skip(1).Select(t => t.SkipLast(1).ToArray()).ToArray();
            var right = A.Skip(1).Select(t => t.Skip(1).ToArray()).ToArray();


            var l = solution(left);
            var r = solution(right);

            return A[0][0] + (l > r ? l : r);
        }


        public static void Test()
        {
            var s2 = 0;
            s2 = new Solution().solution(new int[][] {
                new int[]{ 7},
                new int[]{ 3,8},
                new int[]{ 8,1,0},
                new int[]{ 2,7,4,4},
                new int[]{ 4,5,2,6,5}
            });
            Console.WriteLine(s2);


            var   s3 = new Solution().solution(new int[][] {
                new int[]{ 7},
                new int[]{ 3,8},
            });
            Console.WriteLine(s3);


            s2 = new Solution().solution(new int[][] {
                new int[]{ 7},
                new int[]{ 3,8},
                new int[]{ 8,1,0},
            });
            Console.WriteLine(s2);

        }
    }
}