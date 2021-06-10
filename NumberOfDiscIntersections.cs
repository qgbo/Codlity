using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfDiscIntersections
{
	public class Bar
	{
		public long Left;
		public long Right;
		public long index;
		public Bar(long l, long r,long i)
		{
			Left = l;
			Right = r;
			index = i;
		}

	}
	public class Solution
	{
		public int? Id = 0;
		public  int solution2(int[] A)
		{
			var data = new List<Bar>();
			for (int i = 0; i < A.Length; i++)
			{
				data.Add(new Bar(i - A[i], i + A[i],i));
			}

			var result = 0;
			for (int i = 0; i < data.Count; i++)
			{
				var item = data[i];
				var s= data.Count(t => t.index!= i &&
										 ((item.Left <= t.Right && t.Right <= item.Right) ||

										  (item.Left <= t.Left && t.Left <= item.Right) ||

										  (t.Left <= item.Left && item.Left <= t.Right) ||

										  (t.Left <= item.Right && item.Right <= t.Right)));
				result += s;
			}
			return result / 2;
		}

		public int solution3(int[] A)
		{
			var data = new List<Bar>();
			for (int i = 0; i < A.Length; i++)
			{
				data.Add(new Bar(i - A[i], i + A[i], i));
			}

			data = data.OrderBy(t => t.Left).ToList();
			var result = 0;
			for (int i = 0; i < data.Count; i++)
			{
				var item = data[i];

				for (int j = i + 1; j < data.Count; j++)
				{
					var t = data[j];
					if ((item.Left <= t.Right && t.Right <= item.Right) ||
						(item.Left <= t.Left && t.Left <= item.Right) ||
						(t.Left <= item.Left && item.Left <= t.Right) ||
						(t.Left <= item.Right && item.Right <= t.Right))
						result++;
					else
						break;
				}
			}
			return result;
		}

		public int solution(int[] A)
		{
			var data = new List<Bar>();
			for (int i = 0; i < A.Length; i++)
			{
				data.Add(new Bar((long)i -A[i], (long)i + A[i], i));
			}

			data = data.OrderBy(t => t.Left).ToList();
			var result = 0;
			for (int i = 0; i < data.Count; i++)
			{
				var item = data[i];

				for (int j = i + 1; j < data.Count; j++)
				{
					var t = data[j];
					if (item.Left <= t.Left && t.Left <= item.Right)
						result++;
					else
						break;
				}
			}

			if (result > 10000000)
				return -1;
			return result;
		}
		public static void Test()
		{
			var s =new Solution().solution(new int[] { 1, 5, 2, 1, 4, 0 });
			Console.WriteLine(s);
		}
	}
}
