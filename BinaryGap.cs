using System;
using System.Linq;
using System.Text;

namespace BinaryGap
{
    class BinaryGap
    {
        public static int solution(int A)
        { if (A == 0)
                return 0;
            //StringBuilder s = new StringBuilder();
           


            //while (true)
            //{
            //    s.Insert(0, A % 2);
            //    A = A / 2;
            //    if (A == 1)
            //    {
            //        s.Insert(0, A % 2);
            //        break;
            //    }
            //}

            var zero = Convert.ToString(A, 2).ToString().Split('1').Select(t => t.Length).ToList();
            if (zero.Count() <= 2)
                return 0;

            zero.RemoveAt(zero.Count-1);

            return zero.SkipLast(1).Max();
        }

        public static void Test()
        {
            var s = solution(529);
            Console.WriteLine(s);

            s = solution(1041);
            Console.WriteLine(s);

            s = solution(32);
            Console.WriteLine(s);
        }
    }
}
