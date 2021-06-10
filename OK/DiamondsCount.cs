using System;
using System.Collections.Generic;
using System.Linq;

namespace Min_positive_value
{
	public class point4
	{
		(int x, int y) left;
		(int x, int y) right;
		(int x, int y) up;
		(int x, int y) down;

		public point4() { }
		public point4((int x, int y)[] points) 
		{
			right = Singal(points, t => t.x == points.Max(m=>m.x)).Value;
			left =  Singal(points, t => t.x == points.Min(m => m.x)).Value;

			up = Singal(points, t => t.y == points.Max(m => m.y)).Value;
			down = Singal(points, t => t.y == points.Min(m => m.y)).Value;
		}

		public bool isDemond()
		{
			if (right.y != left.y || up.x != down.x)
				return false;


			if (right.x + left.x != 2 * up.x || up.y + down.y != 2 * left.y)
				return false;

			return true;
		}

		public bool equal(point4 p4)
		{
			return left.x == p4.left.x && left.y == p4.left.y &&
				   right.x == p4.right.x && right.y == p4.right.y &&
				   up.x == p4.up.x && up.y == p4.up.y &&
					down.x == p4.down.x && down.y == p4.down.y;
		}

		

		public static (int x, int y)? Singal((int x, int y)[] points, Func<(int x, int y), bool> func)
		{
			var m = points.Max(func);
			if (points.Count(func) != 1)
				return null;

			return points.Single(func);
		}
	}
	static class DiamondsCount
	{
		static List<point4> dimonds = new List<point4>();
		public static int solution(int[] X, int[] Y)
		{
			var points = new List<(int x, int y)>();
			for (int i = 0; i < X.Length; i++)
			{
				points.Add(new(X[i], Y[i]));
			}

			var result = 0;

			for (int i = 0; i < points.Count; i++)
			{
				for (int i1 = 0; i1 < points.Count; i1++)
				{
					if (i == i1)
						continue;
					for (int i2 = 0; i2 < points.Count; i2++)
					{
						if (i == i2 || i1 == i2)
							continue;

						for (int i3 = 0; i3 < points.Count; i3++)
						{
							if (i == i3 || i1 == i3 || i2 == i3)
								continue;

							var iss= JudgeDimond(new [] { points[i], points[i1], points[i2], points[i3] });
							if (iss)
							{
								result++;
								Console.WriteLine(points[i].x+","+ points[i].y);
								Console.WriteLine(points[i1].x + "," + points[i1].y);
								Console.WriteLine(points[i2].x + "," + points[i2].y);
								Console.WriteLine(points[i3].x + "," + points[i3].y);
								Console.WriteLine();
							}
						}
					}
				}
			}
			return result;
		}


		public static int solution2(int[] X, int[] Y)
		{
			var points = new List<(int x, int y)>();
			for (int i = 0; i < X.Length; i++)
			{
				points.Add(new(X[i], Y[i]));
			}

			var result = 0;

			recuse(points, new List<int>());
			return result;
		}

		static void recuse(List<(int x, int y)> points, List<int> exclude)
		{
			for (int i = 0; i < points.Count; i++)
			{
				if (!exclude.Contains(i))
				{
					if (exclude.Count == 3)
					{
						var iss = JudgeDimond(new[] { points[exclude[0]], points[exclude[1]], points[exclude[2]], points[i] });
						if (iss)
						{
							Console.WriteLine(points[exclude[0]].x + "," + points[exclude[0]].y);
							Console.WriteLine(points[exclude[1]].x + "," + points[exclude[1]].y);
							Console.WriteLine(points[exclude[2]].x + "," + points[exclude[2]].y);
							Console.WriteLine(points[i].x + "," + points[i].y);
							Console.WriteLine();
						}
					}
					if (exclude.Count < 3)
					{
						exclude.Add(i);
						recuse(points, exclude);
					}
				}
			}
		}

		public static bool JudgeDimond((int x, int y)[] points)
		{

			point4 s;
			try
			{
				s=new point4(points);
			}
			catch (Exception)
			{
				return false;
			}
				
				
			if (!s.isDemond())
			{
				return false;
			}

			if (dimonds.Any(t=> t.equal(s)))
			{
				return false;
			}

			dimonds.Add(s);

			return true;
		}

		public static void Test()
		{
			var s = solution(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
			Console.WriteLine(s);

			// hang the air
			//var s = solution2(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
			//Console.WriteLine(s);

		}
	}
}
