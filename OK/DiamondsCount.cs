

namespace DiamondsCount
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class P
	{
		public int x;
		public int y;
		public int i;

		public P(int x, int y, int i)
		{
			this.x = x;
			this.y = y;
			this.i = i;
		}
	}

	public class point4
	{


		public point4()
		{
		}

		public bool isDemond(P[] points)
		{
			P right = Singal(points, t => t.x == points.Max(m => m.x));
			if (right == null)
				return false;

			P left = Singal(points, t => t.x == points.Min(m => m.x));
			if (left == null)
				return false;

			P up = Singal(points, t => t.y == points.Max(m => m.y));
			if (up == null)
				return false;

			P down = Singal(points, t => t.y == points.Min(m => m.y));
			if (down == null)
				return false;


			if (right.y != left.y || up.x != down.x)
				return false;


			if (right.x + left.x != 2 * up.x || up.y + down.y != 2 * left.y)
				return false;

			return true;
		}





		public static P Singal(P[] points, Func<P, bool> func)
		{
			var m = points.Max(func);
			if (points.Count(func) != 1)
				return null;

			return points.Single(func);
		}
	}
	public class Solution
	{
		public int solution(int[] X, int[] Y)
		{
			var points = new List<P>();
			for (int i = 0; i < X.Length; i++)
			{
				if (!points.Any(t => t.x == X[i] && t.y == Y[i]))
					points.Add(new P(X[i], Y[i], points.Count()));
			}

			var result = 0;

			for (int i0 = 0; i0 < points.Count; i0++)
			{
				for (int i1 = i0+1; i1 < points.Count; i1++)
				{
					for (int i2 = i1 + 1; i2 < points.Count; i2++)
					{
						for (int i3 = i2 + 1; i3 < points.Count; i3++)
						{
							Console.WriteLine(points[i0].x + "," + points[i0].y);
							Console.WriteLine(points[i1].x + "," + points[i1].y);
							Console.WriteLine(points[i2].x + "," + points[i2].y);
							Console.WriteLine(points[i3].x + "," + points[i3].y);
							Console.WriteLine($"{i0},{i1},{i2},{i3}");
							var iss = JudgeDimond(new[] { points[i0], points[i1], points[i2], points[i3] });
							if (iss)
							{
								result++;

							}
						}
					}
				}
			}
			return result;
		}




		public static bool JudgeDimond(P[] points)
		{
			point4 s = new point4();

			if (!s.isDemond(points))
			{
				return false;
			}

			return true;
		}

		public static void Test()
		{
			var s = new Solution().solution(new int[] { 1, 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 3, 4, 1, 3, 5, 3, 4 });
			Console.WriteLine(s);

			// hang the air
			//var s = solution2(new int[] { 1, 1, 2, 2, 2, 3, 3 }, new int[] { 3, 4, 1, 3, 5, 3, 4 });
			//Console.WriteLine(s);

		}
	}
}
