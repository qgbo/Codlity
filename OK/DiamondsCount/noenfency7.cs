using System;
// you can also use other imports, for example:
 using System.Collections.Generic;
using System.Linq;
// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Point{

  public  int X;
  public  int Y;
}

class Solution {
    public int solution(int[] X, int[] Y) {

        int result =0;

        bool ok = false;
        // write your code in C# 6.0 with .NET 4.5 (Mono)

         List<Point> points = new List<Point>();
         for (int i = 0; i < X.Length; i++)
            {
                points.Add(new Point(){X=X[i], Y=Y[i]});
            }

         points = points.OrderBy(t=>t.X).ThenBy(t=>t.Y).ToList(); 

         for (int i = 0; i < points.Count; i++)
            {

               for (int j = i+1; j < points.Count; j++)
                {
                     if(ok)
                           break;
                           
                    if(points[i].X==points[j].X)
                           continue;  

                    if(points[i].Y<=points[j].Y)
                           break;                     
                                           
                    for (int k = j+1; k < points.Count; k++)
                    {
                        if(ok)
                           break;
                        if(points[k].X!=points[j].X)
                            break;   

                        if(points[i].Y >= points[k].Y)
                        continue;

                        if(points[k].Y + points[j].Y > points[i].Y*2)
                            break;       

                        if(points[k].Y + points[j].Y == points[i].Y*2)
                        {
                            for (int m = k+1; m < points.Count; m++)
                            {
                                if(points[m].Y == points[i].Y && (points[m].X + points[i].X==points[k].X*2))
                                {
                                    ok = false;
                                    result++;
                                    break;
                                }

                                if(points[m].Y > points[i].Y && (points[m].X > points[i].X))
                                {
                                    ok = false;
                                    break;
                                }
                            } 
                        }
                    }
                }
            }

       return result;
    }
}
