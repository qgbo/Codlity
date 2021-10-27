using System;

namespace BinaryGap
{
    class Fib_queue
    {
        public static int solution(int A)
        {
            if (A == 0 || A == 1)
                return A;
            return solution(A - 1) + solution(A - 2);
        }

        public static int solution_iterator(int A)
        {
            int c1 = 0;
            int c2 = 1;
            for (int i = 0; i < A; i++)
            {
                c1 += c2;
                c2 = c1 - c2;
            }

            return c1;
        }

        public static int solution_DP(int A)
        {
            var a = new int[A+1];
            a[0] = 0;
            a[1] = 1;
            for (int i = 2; i < a.Length; i++)
            {
                a[i] = a[i - 1] + a[i - 2];
            }

            return a[A];
        }

        public static int solution_DP2(int init1,int init2,  int A)
        {
            if (A == 0)
            {
                return init1;
            }

            if (A == 1)
            {
                return init1 + init2;
            }

            return solution_DP2(init2, init1+ init2, A - 1);
        }

        public static void Test()
        {
            var s = solution(10);
            Console.WriteLine(s);

            s = solution_iterator(10);
            Console.WriteLine(s);

            s = solution_DP(10);
            Console.WriteLine(s);
            s = solution_DP2(0,1,9);
            Console.WriteLine(s);

            Console.WriteLine();

            s = solution(15);
            Console.WriteLine(s);

            s = solution_iterator(15);
            Console.WriteLine(s);

            s = solution_DP(15);
            Console.WriteLine(s);
            s = solution_DP2(0, 1, 14);
            Console.WriteLine(s);
        }
    }
}
