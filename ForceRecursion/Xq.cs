
namespace Xq
{
    using System;

    class Solution
    {
        /// <summary>
        /// 象棋棋盘，马在 角落（0，0），用step 步 跳到（X，Y）处，有多少种跳法
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solution(int x, int y, int step)
        {

            return go(x,y,step); ;
        }

        public int go(int x, int y, int step)
        {
            if (x < 0 || x > 8 || y < 0 || y > 9 || step <0)
                return 0;

            if (x==0 &&  y==0 && step==0)
                return 1;

            if ((x == 1 &&y == 2) ||(x == 2 && y== 1))
            {
                return 1;
            }

            Console.WriteLine(x+","+y+","+step);
            step--;

            return
            go(x - 1, y + 2, step) +
            go(x + 1, y + 2, step) +
            go(x - 1, y - 2, step) +
            go(x + 1, y - 2, step) +
            go(x - 2, y + 1, step) +
            go(x + 2, y + 1, step) +
            go(x - 2, y - 1, step) +
            go(x + 2, y - 1, step);
        }


        public static void Test()
        {
            var s = new Solution().solution(0, 1, 3);

            Console.WriteLine("result:" + s);
        }
    }
}
