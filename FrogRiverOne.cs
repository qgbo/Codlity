

namespace FrogRiverOne
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    class Solution
    {
        public int solution(int X, int[] A)
        {
            var data = new List<bool>(X);
            for (int i = 1; i < X+1; i++)
            {
                data.Add(false);
            }

            var r = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= X && data[A[i] - 1]==false)
                {
                    r++;
                    data[A[i]-1] = true;
                    if (r==X)
                        return i;
                }
            }

            return -1; 
        }

        public static void Test()
        {
            var s = new Solution().solution(5,new int[] {1,3,1,4,2,3,3,5,4} );
            Console.WriteLine(s);


        }
    }
}
