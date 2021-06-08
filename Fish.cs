using System;
using System.Collections.Generic;
using System.Linq;

namespace FishCount
{
    public class Fish
    {
        public int Size;
        public int Index;
        public bool Dir;
        public Fish(int size, int i, bool ud)
        {
            Size = size;
            Index = i;
            Dir = ud;
        }

    }
    public class Solution
    {
        public static int solution2(int[] A, int[] B)
        {

            var result = A.Length;

            var fishes = new List<Fish>();

            for (int i = 0; i < A.Length; i++)
            {
                fishes.Add(new Fish(A[i], i, B[i] == 0));
            }

            if (fishes.All(t => t.Dir == true))
                return A.Length;

            if (fishes.All(t => t.Dir == false))
                return A.Length;

            var f = fishes.First(t => !t.Dir);
            var l = fishes.First(t => t.Dir);

            if (f.Index > l.Index)
                return A.Length;

            for (int i = l.Index; i < f.Index; i++)
            {

            }

            return 0;
        }

        public static int solution(int[] A, int[] B)
        {

            var result = A.Length;

            var fishes = new List<Fish>();

            for (int i = 0; i < A.Length; i++)
            {
                fishes.Add(new Fish(A[i], i, B[i] == 0));
            }


            //while (true)
            //{
            //    var d = fishes.SkipLast(1).Where(t => !t.Dir && fishes[t.Index + 1].Dir).Select(t => t.Size < fishes[t.Index + 1].Size ? t.Index : fishes[t.Index + 1].Index);
            //    if (d.Count() > 0)
            //    { 
            //        fishes.RemoveAll(t => d.Contains(t.Index));
            //        var i = 0;
            //        foreach (var item in fishes)
            //        {
            //            item.Index = i;
            //            i++;
            //        }
            //    }
            //    else
            //        return fishes.Count();
            //}

            //while (true)
            //{
            //    var ids=new List<int>();
            //    for (int i = 0; i < fishes.Count - 1; i++)
            //    {
            //        if (!fishes[i].Dir && fishes[i + 1].Dir)
            //        {
            //            ids.Add(i);
            //            if (fishes[i].Size < fishes[i + 1].Size)
            //            {
            //                i++;
            //            }
            //            else
            //                i++;
            //        }

            //        var d = fishes.SkipLast(1).Where(t => !t.Dir && fishes[t.Index + 1].Dir).Select(t => t.Size < fishes[t.Index + 1].Size ? t.Index : fishes[t.Index + 1].Index);
            //        if (d.Count() > 0)
            //        {
            //            fishes.RemoveAll(t => d.Contains(t.Index));
            //            var i = 0;
            //            foreach (var item in fishes)
            //            {
            //                item.Index = i;
            //                i++;
            //            }
            //        }
            //        else
            //            return fishes.Count();
            //    }

            //}
            return 0;
        }

        public static void Test()
        {
            var s = solution(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 });
            Console.WriteLine(s);



        }
    }
}
