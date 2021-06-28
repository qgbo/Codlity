namespace LongestCommonSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Solution
    {

        public int[] solution(int[] A, int[] B)
        {
            var data = new List<List<int>>();

            for (int i = 0; i < A.Length; i++)
            {
                data.Add(new List<int>() { A[i] == B[0] ? 1 : 0 });
            }

            for (int i = 1; i < B.Length; i++)
            {
                data[0].Add(A[0] == B[i] ? 1 : 0);
            }

            for (int i = 1; i < A.Length; i++)
            {
                for (int j = 1; j < B.Length; j++)
                {
                    if (A[i] == B[j])
                        data[i].Add(data[i - 1][j - 1] + 1);
                    else
                        data[i].Add(data[i][j - 1] > data[i - 1][j] ? data[i][j - 1] : data[i - 1][j]);
                }
            }
             
            Console.WriteLine("   "+B.Join(" , "));
            int c = 0;
            foreach (var item in data)
            {
                Console.WriteLine(A[c++]+"  " + item.ToArray().Join(" , "));
            }
            Console.WriteLine();
            return data.Last().ToArray();
        }



        public static void Test()
        {

            var s2 = new Solution().solution(new int[] { 1, 5, 2, 8, 9, 3, 6 }, new int[] { 5, 6, 8, 9, 3, 7 });
            Console.WriteLine(s2.Join());

        }
    }
}