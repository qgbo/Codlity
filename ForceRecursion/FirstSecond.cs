
namespace FirstSecond
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Solution
    {
        int r = 0;
        /// <summary>
        /// 两个人，交替拿数组头尾的数，看最后谁拿的数字和大，返回这个比较大的数
        /// Greedy 不行：每次去头尾较大的那个数：1，0，3，2. 很显然，应该拿1，3. 而不是第一次拿2
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solution(int[] A)
        {
            var s = f(A);
            var t = A.Sum() - s;

            return s > t ? s : t;
        }

        public int f(IEnumerable<int> A)
        {
            if (A.Count() == 1)
            {
                Console.WriteLine("f Select last:" + A.First());
                return A.First();
            }

            var t = A.First() + this.s(A.Skip(1));
            var s = A.Last() + this.s(A.SkipLast(1));
            
            var m= s > t ? s : t;
            Console.WriteLine("f Select:" + m);
            return m;

        }

        public int s(IEnumerable<int> A)
        {
            if (A.Count() == 1)
            { 
            return 0;
            }
                

            var t = f(A.Skip(1));
            var s = f(A.SkipLast(1));
            
            var m= s > t ? t : s;
           // Console.WriteLine("s Select:" + m);
            return m;
        }


        public static void Test()
        {
            var s = new Solution().solution(new int[] { 1, 0,3,2 });

            Console.WriteLine("result:"+s);
        }
    }
}
