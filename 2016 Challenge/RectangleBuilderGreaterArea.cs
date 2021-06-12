using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_positive_value
{
	public class P
	{
		public int m;
		public int n;

		public P(int x, int y)
		{
			this.m = x;
			this.n = y;
		}
	}

	class RectangleBuilderGreaterArea
	{

		public static int solution(int[] A, int X)
		{
			var result = 0;
			var pp = new List<P>();

			for (int i = 0; i < A.Length; i++)
			{
				for (int i1 = 0; i1 < A.Length; i1++)
				{
					if (i == i1)
						continue;
					for (int i2 = 0; i2 < A.Length; i2++)
					{
						if (i == i2 || i1 == i2)
							continue;

						for (int i3 = 0; i3 < A.Length; i3++)
						{
							if (i == i3 || i1 == i3 || i2 == i3)
								continue;

							var bars = new int[] { A[i], A[i1], A[i2], A[i3] };

							var max=bars.Max();
							var min = bars.Min();
							

							if (bars.Count(t => t == max) == bars.Count(t => t == min))
							{
								if (X <= max * min)
								{
									if (!pp.Any(t => t.m == max && t.n == min))
									{
										Console.WriteLine($"{max},{min}");
										result++;
										pp.Add(new P(max, min));
										continue;
									}
								}
							}

						}
					}
				}
			}

			return result;
		}

		public static void Test()
		{
			var s=solution(new int[]{1,2,5,1,1,2,3,5,1 },5);
			Console.WriteLine(s);
		}
	}
}
