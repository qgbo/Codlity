using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int[][] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        int result = 0;
        var B = new int[A.Length, A[0].Length];

        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < A[i].Length; j++)
            {
                if (Search(A, B, i, j))
                {
                    result++;
                }
            }
        }

        return result;
    }


    bool Search(int[][] A, int[,] B, int y, int x)
    {
        if (B[y, x] == -1)
            return false;

        B[y, x] = -1;

        if (x + 1 < A[0].Length && A[y][x] == A[y][x + 1])
        {
            Search(A, B, y, x + 1);
        }

        if (x > 0 && A[y][x] == A[y][x - 1])
        {
            Search(A, B, y, x - 1);
        }

        if (y + 1 < A.Length && A[y][x] == A[y + 1][x])
        {
            Search(A, B, y + 1, x);
        }

        if (y > 0 && A[y][x] == A[y - 1][x])
        {
            Search(A, B, y - 1, x);
        }

        return true;
    }

}
