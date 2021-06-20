

namespace ChocolatesByNumbers
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        private int max(int a, int b)
        {
            a = a > b ? a : b;
            b = a < b ? a : b;

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

        public int solution(int N, int M)
        {
            var c = N % M;

            var round = max(c , M-c);
            Console.WriteLine(round); 
            return (int)(((long)N * round) / M);
        }

        public int solution4(int N, int M)
        {
            var round = 1;
            while (true)
            {
                if (((long)N * round) % M == 0)
                {
                    return (int)(((long)N * round) / M);
                }
                round++;
            }
        }
        public int solution3(int N, int M)
        {
            if (M == N)
                return 1;

            if (N % M == 0)
                return N / M;

            if (M > N / 2 && N > M)
            {
                M = N - M - 1;
            }

            if (M > N)
                M = M % N;

            if (M == 0)
                return N;


            var start = 0;

            var eta = new List<int>(M) { 0 };
            var end = N - (N - start) % M + 1;
            start = (end + M + 1) % N;

            while (true)
            {
                if (eta.Contains(start))
                {
                    return (eta.Count * (N / M)) + 1;
                }

                end = N - (N - start) % M + 1;
                start = (end + M + 1) % N;

                eta.Add(start);
            }
        }


        public int solution2(int N, int M)
        {
            var eta = new List<int>();
            var i = 0;
            while (true)
            {
                if (eta.Contains(i))
                {
                    return eta.Count;
                }

                eta.Add(i);

                i += M;
                if (i >= N)
                {
                    i = i % N;
                }
            }
        }

        public static void Test()
        {
            var s332 = new Solution().solution(83854, 76178);//54507,95939=
            Console.WriteLine(s332);

            for (int i = 0; i < 5; i++)
            {

                Random randNum = new Random();
                var s = randNum.Next(2, 100000);
                var t = randNum.Next(2, 100000);

                var t1 = new Solution().solution2(s, t);


                var t2 = new Solution().solution(s, t);
                Console.WriteLine("=======T=======" + t1);
                if (t1 != t2)
                {
                    Console.WriteLine(s + "," + t + "=======Corrct=======" + t1);
                    Console.WriteLine(s + "," + t + "=====Error==========" + t2);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("over");
            return;

            var s2 = new Solution().solution(9, 7);
            Console.WriteLine(s2);

            s2 = new Solution().solution2(9, 7);
            Console.WriteLine(s2);

            return;

            var s3 = new Solution().solution(1000000000, 400);
            Console.WriteLine(s3);
        }
    }
}