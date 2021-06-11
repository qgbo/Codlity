

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

	public class P3
	{
		public int i1;
		public int i2;
		public int not;
		public bool line;

		public P3(int i1, int i2, int not, bool line = false)
		{
			this.i1 = i1;
			this.i2 = i2;
			this.not = not;
			this.line = line;
		}
	}

	public class point4
	{

		public readonly int i0;
		public readonly int i1;
		public readonly int i2;
		public readonly int i3;


		public point4(params int[] index)
		{
			var s = index.OrderBy(t => t).ToArray();
			this.i0 = s[0];
			this.i1 = s[1];
			this.i2 = s[2];
			this.i3 = s[3];
		}

		// override object.Equals
		public override bool Equals(object obj)
		{
			//       
			// See the full list of guidelines at
			//   http://go.microsoft.com/fwlink/?LinkID=85237  
			// and also the guidance for operator== at
			//   http://go.microsoft.com/fwlink/?LinkId=85238
			//

			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			var p = obj as point4;
			return p.i0 == i0 && p.i1 == i1 && p.i2 == i2 && p.i3 == i3;
			// TODO: write your implementation of Equals() here
			throw new NotImplementedException();
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			// TODO: write your implementation of GetHashCode() here
			throw new NotImplementedException();
			return base.GetHashCode();
		}
	}
	public class Solution
	{

		public int solution(int[] X, int[] Y)
		{
			var usedPoints = new List<point4>();

			var points = new List<P>();
			for (int i = 0; i < X.Length; i++)
			{
				if (!points.Any(t => t.x == X[i] && t.y == Y[i]))
					points.Add(new P(X[i], Y[i], points.Count));
			}


			foreach (var p0 in points)
			{
				foreach (var p1 in points.Where(p1 => p1.x == p0.x && p1.i != p0.i))
				{
					foreach (var p2 in points.Where(p2 => 2 * p2.y == p0.y + p1.y && p2.i != p0.i && p2.i != p1.i))
					{
						var p3 = points.FirstOrDefault(pp3 => (pp3.y == p2.y) && (pp3.x + p2.x == 2 * p1.x)
														&& pp3.i != p2.i && pp3.i != p1.i && pp3.i != p0.i);
						if (p3 != null)
						{
							var p = new point4(p0.i, p1.i, p2.i, p3.i);
							if (!usedPoints.Any(t => t.i0 == p.i0 && t.i1 == p.i1 && t.i2 == p.i2 && t.i3 == p.i3))
							{
								usedPoints.Add(new point4(p0.i, p1.i, p2.i, p3.i));
							}
						}
					}
				}

				foreach (var p1 in points.Where(p1 => p1.y == p0.y && p1.i != p0.i))
				{
					foreach (var p2 in points.Where(p2 => 2 * p2.x == p0.x + p1.x && p2.i != p0.i && p2.i != p1.i))
					{
						var p3 = points.FirstOrDefault(pp3 => (pp3.x == p2.x) && (pp3.y + p2.y == 2 * p1.y)
													   && pp3.i != p2.i && pp3.i != p1.i && pp3.i != p0.i);
						if (p3 != null)
						{
							var p = new point4(p0.i, p1.i, p2.i, p3.i);
							if (!usedPoints.Any(t => t.i0 == p.i0 && t.i1 == p.i1 && t.i2 == p.i2 && t.i3 == p.i3))
							{
								usedPoints.Add(new point4(p0.i, p1.i, p2.i, p3.i));
							}
						}
					}
				}
			}

			return usedPoints.Count;
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
