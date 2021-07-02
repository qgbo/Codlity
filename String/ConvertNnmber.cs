
namespace ConvertNnmber
{
    using System;

    class Solution
    {
        int num = 0;
        /// <summary>
        /// 比如1对应a，2对应b，以此类推，一直到26对应z。 数组字符串有多少种？ 111 有3种，AAA，AK，KA
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solution(string str)
        {
            if (str.Length == 0)
                return 0;

            if (str.Length == 1)
            {
                num = 1;
                return 1;
            }


            var n = str[0] - '0';
            var n1 = str[1] - '0';

            if (n * 10 + n1 > 26)
                num+=  1+solution(str.Substring(2));
            else
                num += 1+ solution(str.Substring(1)) +1+ solution(str.Substring(2));

            return num;
        }

        public static void Test()
        {
           var s= new Solution().solution("12");

            Console.WriteLine(s);
        }
    }
}
