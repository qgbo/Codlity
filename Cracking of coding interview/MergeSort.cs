using System;
using System.Collections.Generic;

namespace Sort
{
    class MergeSort
    {
        public static void solutionRecursion(int[] A, int start, int length)
        {
            if (length < 1)
            {
                return;
            }

            if (length == 2)
            {
                Swap(A, start, start + 1);
                return;
            }

            var half = length / 2;
            solutionRecursion(A, start, half);
            solutionRecursion(A, half, half + length % 2);

            while (start < half)
            {
                for (int i = start; i < half; i++)
                {
                      Swap(A, i, i + half);
                }
                start++;
            }


        }
        private static void Swap(int[] A, int i, int j)
        {
            if (A[i] > A[j])
            {
                int m = A[i];
                A[i] = A[j];
                A[i] = m;
            }
        }


        public static void Test()
        {
            var a = new List<int>();
            var answer = new List<int>();
            Random rd = new Random();
            for (int i = 0; i < 16; i++)
            {
                a.Add(rd.Next(0, 100));
                answer.Add(a[i]);
            }
            var arr = a.ToArray();

            answer.Sort();
            Console.WriteLine("anser:" + answer.ToArray().Join());

            solutionRecursion(arr, 0, arr.Length);
            Console.WriteLine(arr.Join());


        }
    }
}
