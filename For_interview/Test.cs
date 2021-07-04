using System;
using System.Linq;

namespace ArgsProblem.Tests
{
    public class ValidateArguments
    {
        public int Validate(string[] args)
        {

            // Console.WriteLine("Sample debug output");
            // throw new System.ArgumentException("Not yet implemented");
            if (args == null || args.Length == 0)
                return -1;

            if (args.Length > 5)
                return -1;

            args = args.Select(t => t.ToLower()).ToArray();

            var data = args.Select(t => t.ToLower()).ToList();

           


            if (data.Contains("--name"))
            {
               var i= data.FindIndex(0,t=>t=="--name");

                if (i <= data.Count-2)
                {
                    var r = data[i + 1].Length;
                    if (!(r <= 10 && r >= 3))
                        return -1;

                    data.RemoveAt(i);
                    data.RemoveAt(i);
                }
                else 
                    return -1;
            }

          

            if (data.Contains("--count"))
            {
                var i = data.FindIndex(0, t => t == "--count");

                if (i <= data.Count - 2)
                {
                    try
                    {
                        var r = int.Parse(data[i + 1]);

                        if (!(r <= 100 && r >= 10))
                            return -1;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }

                    data.RemoveAt(i);
                    data.RemoveAt(i);
                }
                else
                    return -1;
            }

            bool ishelp = data.Contains("--help");
            if (ishelp)
            {
                data.Remove("--help");
            }

            if (data.Count > 0)
                return -1;

            if (ishelp)
                return 1;

            return 0;

        }


        public static void Test()
        {

            var r1 = new ValidateArguments().Validate(new string[] { "--name","--help" ,"108"});

            Console.WriteLine(r1);

            var r = new ValidateArguments().Validate(new string[] { "--name", "SOME_NAME", "--count", "100000" });

            Console.WriteLine(r);
        }
    
    }
}
