namespace CoinsExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Solution
    {
        public int[] solution(int[] A, int K)
        {
            if (K <= A.Last())
                return new int[] { 1};

            var data = new List<List<int>>();
            for (int i = 0; i < A.Length; i++)
            {
                data.Add(new List<int>());
            }

            for (int i = 0; i < A.Length; i++)
            {
                for (int k = 0; k < K; k++)
                {
                    
                }
            }


            for (int k = 0; k < K; k++)
            {
                for (int i = A.Length - 1; i >= 0; i--)
                {
                    
                }
                
            }

            return null ;
        }


        public static void Test()
        {

            var s2 = new Solution().solution(new int[] { 1, 4, 5 }, 13);
            Console.WriteLine(s2.Join());

        }
    }
}