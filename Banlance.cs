using System;
using System.Collections;

namespace BinaryGap
{
    class Banlance
    {

        public static bool solution(string A)
        {
            Stack s = new Stack();
            for (int i = 0; i < A.Length; i++)
            {

                //if ((A[i] == '(' && A[i + 1] == ')') ||
                //    (A[i] == '[' && A[i + 1] == ']') ||
                //    (A[i] == '{' && A[i + 1] == '}'))
                //{
                //    i++;
                //    continue;
                //}

                if (A[i] == '(' || A[i] == '[' || A[i] == '{')
                {
                    s.Push(A[i]);
                }
                else
                {
                    var z = s.Peek();
                    if (((char)z == '(' && A[i] == ')') ||
                        ((char)z == '[' && A[i] == ']') ||
                        ((char)z == '{' && A[i] == '}'))
                    {
                        s.Pop();
                    }
                    else
                        return false;
                }
            }
            return s.Count == 0? true:false;

        }

        public static void Test()
        {
            var s = solution("{[()()]}");
            Console.WriteLine(s);

            s = solution("((({}){)})");
            Console.WriteLine(s);

            s = solution("");
            Console.WriteLine(s);


        }
    }
}
