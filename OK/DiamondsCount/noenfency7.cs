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

        // write your code in C# 6.0 with .NET 4.5 (Mono)

         bool break2=false;

         Point[] points = new Point[X.Length];
         for (int i = 0; i < X.Length; i++)
            {
                points[i]= new Point(){X=X[i],Y=Y[i]};
            }

         points = points.OrderBy(t=>t.X).ThenBy(t=>t.Y).ToArray(); 

         for (int i = 0; i < points.Length-3; i++)
            {
               for (int j = i+1; j < points.Length-2; j++)
                {
                   

                    if(points[i].X==points[j].X)
                           continue;  

                    if(points[i].Y > points[j].Y)     
                    {
                        for (int k = j+1; k < points.Length-1; k++)
                        {
                            if(points[k].X!=points[j].X) ////////////
                            {
                                break2 = true;
                                break;
                            }
                                

                            if(points[i].Y >= points[k].Y)
                                continue;   

                            if(points[k].Y + points[j].Y == points[i].Y*2)
                            {
                                for (int m = k+1; m < points.Length; m++)
                                {
                                    if(points[m].Y == points[i].Y && (points[m].X + points[i].X==points[k].X*2))
                                    {
                                        result++;
                                        break;
                                    }

                                    if(points[m].Y >= points[i].Y && (points[m].X + points[i].X > points[k].X*2))
                                    {
                                        break;
                                    }
                                } 
                            }

                             if(points[k].Y + points[j].Y > points[i].Y*2)
                                break;
                        }

                        if(break2)
                        {
                            break2 = false;
                            continue;
                        }
                    }

                    if(points[i].Y<=points[j].Y)
                            continue; 
                }
            }

       return result;
    }
}
