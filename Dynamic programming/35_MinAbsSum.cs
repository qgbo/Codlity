

namespace MinAbsSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    class Solution
    {
       
        public int solution(int[] A)
        {
            List<int> result = new List<int>();

            A = A.OrderBy(t => Math.Abs(t)).ToArray();
            var s = A.Sum(t=>Math.Abs(t));
            int i = 1;
            var y = 0;
            while (true)
            {
               y = s - Math.Abs(A[A.Length - 1 - i]);
                if (y > 0)
                { 
                
                }

            }

            return result.Min();
        }

        public int get(int[][] A)
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
                    var m = data[i + 1][j] > data[i + 1][j + 1] ? data[i + 1][j] : data[i + 1][j + 1];
                    data[i].Add(A[i][j] + m);
                }
            }
            return data[0][0];
        }

        public static void Test()
        {


        }
    }
}