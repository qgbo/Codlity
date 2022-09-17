using System;
// you can also use other imports, for example:
// using System.Collections.Generic;
using System.Text;
// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public string solution(string S) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

       
    var str = new StringBuilder(S);

    for (int i = 0; i < str.Length-1; )
    {
        if (str[i] == str[i + 1])
        {
            str.Remove(i, 2);
            if (i > 0)
                i--;
        }
        else
            i++;
    }

        return str.ToString();
    }
}
