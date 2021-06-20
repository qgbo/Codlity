using BinaryGap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace codeLity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var s = solution(new int[] { 1, 3, 2, 1, 2, 1, 5, 3, 3, 4, 2 });
            // FloodDepth.Test();
            //var s = solution("tww45q33");

            // Banlance.Test();
            //FishCount.Solution.Test();
            //Tesla.Solution.Test();

            //Dominator.Solution.Test();
            //EquiLeader.Solution.Test();
            // Triangle.Solution.Test();

            //MaxProductOfThree.Solution.Test();
            // PermCheck.Solution.Test();
            // FrogRiverOne.Solution.Test();

            //DiamondsCount_NoEfiency6.Solution.Test();
            //  Test.Solution.Test();

            //   MaxProfit.Solution.Test();
            // MaxSliceSum.Solution.Test();

            //Test.Aggregate.Solution.Test();

            // MaxDoubleSliceSum2.Solution.Test();

            //CountFactors.Solution.Test();
            //  MinPerimeterRectangle.Solution.Test();
            //  Semiprime.Solution.Test();

            //ChocolatesByNumbers.Solution.Test();

            // CommonPrimeDivisors.Solution.Test();
          //  Test();
         //   FibFrog.Solution.Test();

            Ladder.Solution.Test();
            Console.ReadLine();

        }


        public static void Test()
        {
            int[] data =  { 4, 4, 4, 1,2,3,4,5,6,7,8,9};
      
            var m= data.SkipWhile(t => t<5);

            Console.WriteLine(string.Join(",,,",m));

            int[] arr = { 20,24,44, 35,22, 55,34, };
            Console.WriteLine("Initial array...");
            foreach (int value in arr)
            {
                Console.WriteLine(value);
            }
            // skipping even elements
            var res = arr.SkipWhile(ele => ele == 44);
            Console.WriteLine("New array after skipping even elements..."+ string.Join(",", res));
            foreach (int val in res)
            {
                Console.WriteLine(val);
            }
        }
        public static int solution(string S)
        {
            var s=S.Split(' ');
            
            var ss=  s.Where(t=> Regex.Match(t, @"^[A-Za-z0-9]+$").Success);
            var sss = new List<int>();
            foreach (var item in ss)
            {
                var n = 0;
                foreach (Match t in Regex.Matches(item, @"[0-9]+"))
                {
                    n += t.Value.Length;
                }

                var str = 0;
                foreach (Match t in Regex.Matches(item, @"[A-Za-z]+"))
                {
                    str+= t.Value.Length;
                }
                
                if ((n % 2 == 1) &&  str % 2 == 0)
                    sss.Add(item.Length);
            }

            if (!sss.Any())
                return -1;

            return sss.Max();
        }
        


        //public static int solution2(int[] A)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)

        //    if (A.Length < 2)
        //        return 0;

        //    var AIndex = new List<(int a, int index)>();
        //    AIndex.Add((A[0], 0));

        //    for (int i = 1; i < A.Length-1; i++)
        //    {
                
        //        if (A[i - 1] <= A[i] && A[i] <= A[i + 1])
        //            continue;

        //        if (A[i - 1] >= A[i] && A[i] >= A[i + 1])
        //            continue;

        //        if (A[i - 1] == A[i])
        //            continue;

        //        AIndex.Add((A[i], i));
        //    }

        //    AIndex.Add((A[A.Length - 1], A.Length - 1));

        //    var deeps = new List<int>();

        //    for (int i = 1; i < AIndex.Count-1; i++)
        //    {

        //        if (A[i - 1] >= A[i] && A[i] <= A[i + 1])
        //            deeps.Add((A[i - 1] < A[i + 1] ? A[i - 1] : A[i + 1])- A[i]);
        //    }

        //    if (!deeps.Any())
        //        return 0;


        //    return deeps.Max();
        //}
    }
}
