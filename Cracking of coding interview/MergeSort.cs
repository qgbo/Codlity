
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

            Merge(A, start, half, length);
        }

        private static void Merge(int[] A, int start, int half, int length)
        {
            var a = new List<int>();
            var s = start;

            for (int i = 0; i < length; i++)
            {
                if (A[start] > A[half + 1] && half != s + length)
                {
                    a.Add(A[half + 1]);
                    half++;
                }
                else
                {
                    a.Add(A[start]);
                    start++;
                }
            }

            for (int i = 0; i < length; i++)
            {
                A[s+i] = a[i];
            }
            
        }

     

        private static void Swap(int[] A, int i, int j)
        {
            
            if (A[i] > A[j])
            {
                int m = A[i];
                A[i] = A[j];
                A[j] = m;
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

 answer.Sort();

            Console.WriteLine();


            Console.WriteLine("anser5:" + answer.ToArray().Join());
            var arr = answer.ToArray();
            solutionRecursion(arr, 0, arr.Length);
            Console.WriteLine("====="+arr.Join());


        }
    }
}
