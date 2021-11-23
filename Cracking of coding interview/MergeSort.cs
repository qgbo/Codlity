using System;

namespace Sort
{
    class MergeSort
    {
        public static void solutionRecursion(int[] A, int start, int length)
        {
            if (A.Length == 1)
            {
                return;
            }

            if (A.Length == 2)
            {
                if (A[start] > A[start + 1])
                {
                    int m = A[start];
                    A[start + 1] = A[start];
                    A[start] = m;
                }
                return;
            }

            var half = length / 2;
            solutionRecursion(A, start, half);
            solutionRecursion(A, half, half + length % 2);

            while (start < )
            {
                for (int i = start; i < half; i++)
                {
                    if (A[i] > A[i + half])
                    {
                        int m = A[i];
                        A[i + half] = A[i];
                        A[i] = m;
                    }
                }
                start++;
            }

        }

        public static void Test()
        {

            var s = solution();
            Console.WriteLine(s);

            s = solution("((({}){)})");
            Console.WriteLine(s);

            s = solution("");
            Console.WriteLine(s);


        }
    }
}
