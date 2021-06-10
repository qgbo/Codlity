using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_positive_value
{
	class SocketsLaundering
	{
		public static int solution(int K, int[] C, int[] D)
		{
			var cg= C.GroupBy(t => t);
			var result= cg.Sum(t => t.Count() / 2);

			var C_left= cg.Where(t => t.Count() % 2 == 1).Select(t=>t.Key).ToList();

			var dlist = D.ToList();
		
			var d1= D.GroupBy(t => t).Where(t => t.Count() % 2 == 1).Select(t => t.Key).ToList();
			foreach (var item in d1)
			{
				if (C_left.Contains(item))
				{
					if (K > 0)
					{
						C_left.Remove(item);
						dlist.Remove(item);
						result++;
						K--;
					}
				}
			}


			var rd1 = dlist.GroupBy(t => t).Sum(t => t.Count() / 2);

			if(K>= rd1*2)
				result +=rd1;
			else
				result += K/2;

			return result;
		}

		public static void Test()
		{
			var s=solution(2,new int[] { 1, 2, 1, 1 }, new int[] { 1, 4, 3, 2, 4 });
			Console.WriteLine(s);
		}
	}
}
