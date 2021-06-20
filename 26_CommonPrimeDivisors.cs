

namespace CommonPrimeDivisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Data
    {
        public int v;
        public int i;
        public bool isPrime;
    }
    class Solution
    {
        private int max(int a, int b)
        {
            while (true)
            {
                if (a % b == 0)
                    return b;
                else
                {
                    var t = b;
                    b = a % b;
                    a = t;
                }
            }
        }

        public int solution(int[] A, int[] B)
        {
            var result =0;
            for (int i = 0; i < A.Length; i++)
            {
                if (isOk(A[i], B[i]))
                    result++;
            }
            
            return result;
        }

        private bool isOk(int a, int b)
        {
            a = a >= b ? a : b;
            b = a <= b ? a : b;

            if (a % b == 0  && b%(a/b)==0)
                return true;


            var m = max(a,b);
            if (m == 1)
                return true;

          
            return true;
        }



        public static bool isPrime(int n)
        {
            if (n <= 3)
            {
                return n > 1;
            }
            // 只有6x-1和6x+1的数才有可能是质数
            if (n % 6 != 1 && n % 6 != 5)
            {
                return false;
            }
            // 判断这些数能否被小于sqrt(n)的奇数整除
            int sqrt = (int)Math.Sqrt(n);
            for (int i = 5; i <= sqrt; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

            private bool isOk2(int a, int b)
        {
            var n = a > b ? a : b;
            var primes = new List<Data>();

            for (int i = 0; i <= n + 1; i++)
            {
                primes.Add(new Data() { v = i, isPrime = true, i = primes.Count });
            }


            for (int i = 2; i * i <= n + 1; i++)
            {
                if (primes[i].isPrime)
                {
                    for (int j = i; i * j < n + 1; j++)
                    {
                        primes[i * j].isPrime = false;
                    }
                }
            }

            primes.RemoveAll(t => t.isPrime == false || t.i == 0 || t.i == 1);
            var s1 =string.Join(',', primes.Where(t => a % t.v == 0 && a >= t.v).Select(t => t.v));
            
            var s2= string.Join(',', primes.Where(t => b % t.v == 0 && b >= t.v).Select(t => t.v));
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;

            return s1 == s2;
        }
        public static void Test()
        {
           
            var s2 = new Solution().solution(new int[] { 15,10,3}, new int[] { 75, 30, 5 });
            Console.WriteLine(s2);

           
        }
    }
}