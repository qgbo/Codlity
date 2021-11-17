using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryGap
{
    class Anagram
    {
        public static (int,int) solution(string A,string B)
        {
           var a= A.GroupBy(t => t).Select(t => (t.Key, t.Count()));
           var b= B.GroupBy(t => t).Select(t => (t.Key, t.Count()));

           var ac= a.Sum(t =>
            {
                if (b.Any(m => m.Key == t.Key))
                {
                    var r = t.Item2 - b.FirstOrDefault(m => m.Key == t.Key).Item2;
                    Console.WriteLine($"{t.Key},{(r < 0 ? 0 : r)}");
                    return r < 0 ? 0 : r;
                }
                Console.WriteLine($"{t.Key},{t.Item2}");
                return t.Item2;
            });

            Console.WriteLine();
            var bc = b.Sum(t =>
            {
                if (a.Any(m => m.Key == t.Key))
                {
                    var r = t.Item2 - a.FirstOrDefault(m => m.Key == t.Key).Item2;
                    Console.WriteLine($"{t.Key},{(r < 0 ? 0 : r)}");
                    return r < 0?0:r;
                }
                Console.WriteLine($"{t.Key},{t.Item2}");
                return t.Item2;
            });
            Console.WriteLine();
            return (ac, bc);
        }

        public static (int, int) solution2(string A, string B)
        {
            var a = A.GroupBy(t => t).Select(t => (t.Key, t.Count()));
            var b = B.GroupBy(t => t).Select(t => (t.Key, t.Count()));

            var fun = new Func<(char Key, int count), IEnumerable<(char Key, int count)>, int>((t, s) =>
            {
                if (s.Any(m => m.Key == t.Key))
                {
                    var r = t.count - s.FirstOrDefault(m => m.Key == t.Key).count;
                    Console.WriteLine($"{t.Key},{(r < 0 ? 0 : r)}");
                    return r < 0 ? 0 : r;
                }
                Console.WriteLine($"{t.Key},{t.count}");
                return t.count;
            });

            var ac = a.Sum(t=>fun(t,b));
            Console.WriteLine();

            var bc = b.Sum(t => fun(t, a));
            Console.WriteLine();
            return (ac, bc);
        }



        public static void Test()
        {
            var s = solution("hello","billon");
            Console.WriteLine($"{s.Item1},{s.Item2}");


             s = solution2("hello", "billon");
            Console.WriteLine($"{s.Item1},{s.Item2}");


            s = solution("sdfsddwe", "dsfrc");
            Console.WriteLine($"{s.Item1},{s.Item2}");

            s = solution2("sdfsddwe", "dsfrc");
            Console.WriteLine($"{s.Item1},{s.Item2}");
        }
    }
}
