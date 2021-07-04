
namespace One_area
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  给定一个由 0 和 1 组成的矩阵, 找出1 组成的岛的个数.下面的矩阵有3个岛
    ///  001010
    ///  111010
    ///  100100
    ///  000000
    /// </summary>
    class Solution
    {

        public int solution(int[][] A)
        {
            var d = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                {
                    if (A[i][j] == 1)
                    {
                        get(A, i, j);
                        d++;
                    }

                }
            }

            return d;
        }

        void get(int[][] A, int m, int n)
        {
            A[m][n] = 2;

            if (n + 1 < A[m].Length && A[m][n + 1] == 1)
                get(A, m, n + 1);

            if (m + 1 < A.Length && A[m + 1][n] == 1)
                get(A, m + 1, n);


            if (m - 1 >= 0 && A[m - 1][n] == 1)
                get(A, m - 1, n);

            if (n - 1 >= 0 && A[m][n-1] == 1)
                get(A, m, n-1);
        }

        public static void Test()
        {
            var s = new Solution().solution(new int[][] {
                new int[] {0,0,1,0,1,0 },
                new int[] {1,1,1,0,1,0 },
                new int[] {1,0,0,1,0,0 },
                new int[] {0,0,0,0,0,1 },
            });
            Console.WriteLine(s);


        }
    }
}
