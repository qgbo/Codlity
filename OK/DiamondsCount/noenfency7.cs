using System;
// you can also use other imports, for example:
 using System.Collections.Generic;
using System.Linq;
// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Point{

  public  int X;
  public  int Y;
  bool enable = true;
}

class Solution {
    public int solution(int[] X, int[] Y) {

        int result =0;
        // write your code in C# 6.0 with .NET 4.5 (Mono)

         List<Point> points = new List<Point>();
         for (int i = 0; i < X.Length; i++)
            {

                if(!X.Skip(i).Contains(X[i]))
                break;

                if(!Y.Skip(i).Contains(Y[i]))
                break;

                points.Add(new Point(){X=X[i], Y=Y[i]});
            }

         points = points.OrderBy(t=>t.X).ThenBy(t=>t.Y).ToList(); 

         for (int i = 0; i < points.Count; i++)
            {

               for (int j = i+1; j < points.Count; j++)
                {
                    if(points[i].X==points[j].X)
                           continue;                     
                                           
                    for (int k = j+1; k < points.Count; k++)
                          {
                             if(points[k].X!=points[j].X)
                                  continue;   

                             if(points[k].Y + points[j].Y != points[i].Y*2)
                                  continue;  

                             for (int m = j+1; m < points.Count; m++)
                             {
                                if(points[m].Y != points[i].Y)
                                    continue;

                                if(points[m].X + points[i].X==points[k].X*2)
                                    result++;

                             } 
                          }
                }
            }

       return result;
    }
}
