

namespace Test.Aggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class User
    {
        public int Id;
        public string Name;
    }
    public class Solution
    {
        public int solution()
        {
            List<User> Users = new List<User> {
                new User { Id = 1, Name = "张三" },
                new User { Id = 2, Name = "李四" },
                new User { Id = -3, Name = "李四" },
                new User { Id = -2, Name = "李四" },
                new User { Id = 5, Name = "李四" },
                new User { Id = 6, Name = "李四" },
                new User { Id = -4, Name = "李四" }
            };

            var sums = new List<int>();
            var s = Users.Skip(1).Aggregate(1, (a, b) =>
            {
                Console.WriteLine($"{a}={b.Id}");
                if (a * b.Id<0)
                {
                    sums.Add(a);
                    Console.WriteLine($"{a},{b.Id}={b.Id}");
                    return  b.Id;
                }
                else
                {
                    Console.WriteLine($"{a},{b.Id}={a + b.Id}");
                    return a+b.Id;
                }

            });

            Console.WriteLine(s);


            var invalidFileName = new char[] { '<', '>' };
            var replaceResult = invalidFileName.Aggregate("study<Aggregate>first", (accmulate, result) =>
            {
                Console.WriteLine(accmulate);
                return accmulate.Replace(result, '-');
            });
            Console.WriteLine(replaceResult);

            var ints = new int[] { 1, 2, 3, -1, 4, -2, };
            var r = ints.Aggregate(0, (a, b) => a + b);
            Console.WriteLine(r);

            IEnumerable<int> list = Enumerable.Range(2, 10);
            int all = list.Aggregate((sxx, index) => sxx + index);
            Console.WriteLine(all);
            return 0;
        }

        public static void Test()
        {
            //var s = new Solution().solution(new int[] {  1, 3, 2, 2, 2, 1, 3 }, new int[] {  3, 3, 1, 3, 5, 4, 4 });
            //Console.WriteLine(s);

            var s = new Solution().solution();
            // Console.WriteLine(s);

            // hang the air
            //var s = solution2(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
            //Console.WriteLine(s);

        }
    }
}
