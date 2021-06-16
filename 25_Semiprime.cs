

namespace Semiprime
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
        public int[] solution(int N, int[] P, int[] Q)
        {
            var primes = new List<Data>();


            for (int i = 0; i < N; i++)
            {
                primes.Add(new Data() { v = i , isPrime = true,i= i }) ;
            }

            for (int i = 2; i * i < N; i++) 
            {
                if (primes[i].isPrime)
                {
                    for (int j = i; i * j < N; j++)
                    {
                        primes[i * j].isPrime = false;
                    }
                }
            }


            primes.RemoveAll(t=>t.isPrime==false || t.i==0 || t.i==1);
            var ss = primes.Select(t=>t.v);

            var semiprime = new HashSet<int>();

            foreach (var item in ss)
            {
                foreach (var s in ss)
                {
                    semiprime.Add(item*s);
                }
            }

            var result = new List<int>();
            for (int i = 0; i < P.Length; i++)
            {
                result.Add(semiprime.Count(t => t >= P[i] && t <= Q[i]));

            }

            return result.ToArray();
        }


        public static void Test()
        {
            var s = new Solution().solution(26, new int[] { 1, 4, 16 }, new int[] { 26, 10, 20 });
            Console.WriteLine(string.Join(",", s));
        }
    }
}
