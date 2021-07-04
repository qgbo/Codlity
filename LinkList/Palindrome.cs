
namespace Palindrome
{
    using System;
    using System.Collections.Generic;

    class Solution
    {

        public bool solution(LinkedList<int> vs)
        {
            var quick = vs.First;
            var reverse= vs.Last;

            var c = 0;
            while (true)
            {
                if (quick.Value != reverse.Value)
                    return false;


                if (c>=vs.Count)
                    return true;

                c += 2;

                quick = quick.Next;
                reverse = reverse.Previous;
            }
         
        }

        public static void Test()
        {
            var s = new Solution().solution(new LinkedList<int> (new int[] { 1, 2, 3, 4, 3, 2, 3 }));
            Console.WriteLine(s);

           var  s2 = new Solution().solution(new LinkedList<int>(new int[] { 1, 2, 3, 4, 3, 2, 1 }));
            Console.WriteLine(s2);
           

            s = new Solution().solution(new LinkedList<int>(new int[] { 2, 3, 4, 3, 2 }));
            Console.WriteLine(s);

            s = new Solution().solution(new LinkedList<int>(new int[] { 2, 3, 4, 3, 3 }));
            Console.WriteLine(s);
        }
    }
}
