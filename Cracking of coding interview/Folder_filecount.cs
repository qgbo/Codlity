using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryGap
{
    class Folder_filecount
    {
        public static int solution(string A)
        {
            DirectoryInfo root = new DirectoryInfo(A);

            
            var c = root.GetFiles().Count(t=>t.FullName.EndsWith(".cs"));

            //var dics = root.GetDirectories();
            //foreach (var item in dics)
            //{
            //   c+= solution(item.FullName);
            //}
             c += root.GetDirectories().Sum(t => solution(t.FullName));

            return c;
        }


        public static int solution_iterator(string A)
        {
            var s = new Stack<string>();
            s.Push(A);

            var c = 0;
            while (s.TryPop(out string folder))
            {  
                DirectoryInfo root = new DirectoryInfo(folder);
                c += root.GetFiles().Count(t => t.FullName.EndsWith(".cs"));
                foreach (var item in root.GetDirectories().Select(t => t.FullName))
                {
                    s.Push(item);
                }
            }

            return c;
        }


        public static void Test()
        {
            var s = solution(@"D:\Work\Test\codeLity");
            Console.WriteLine(s);

            s = solution_iterator(@"D:\Work\Test\codeLity");
            Console.WriteLine(s);

        }
    }
}
