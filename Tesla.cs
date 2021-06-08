using System;
using System.Collections;

namespace Tesla
{
    class Solution
    {

        public static int solution(string A)
        {
            return 55;

        }

        public static void Test()
        {
            var s = solution("{[()()]}");
            Console.WriteLine(s);

            s = solution("((({}){)})");
            Console.WriteLine(s);

            s = solution("");
            Console.WriteLine(s);


        }
    }
}
