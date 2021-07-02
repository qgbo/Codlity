
namespace FullPermutation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    // 全排列
    class Solution
    {

        public string[] solution(string A)
        {
            if (1 == A.Length)
                return new string[] { A };

            var li = new List<string>();
            for (int i = 0; i < A.Length; i++)
            {
                var s = solution(A.Substring(0, i) + A.Substring(i + 1)).ToList().Select(t => A[i] + t);
                li.AddRange(s);
                //Console.WriteLine(s);
            }

            return li.ToArray();
        }

        public static void Test()
        {
            var s = new Solution().solution("ABCDEF");

            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
