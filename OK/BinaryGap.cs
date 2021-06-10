using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_positive_value
{
	class BinaryGap
	{
		public static int solution(int A)
		{
			StringBuilder s = new StringBuilder();
			while (true)
			{
				s.Insert(0,A%2);
				A = A / 2;
				if (A == 1)
				{
					s.Insert(0, A % 2);
					break;
				}
			}

			var zero=s.ToString().Split('1').Select(t => t.Length);
			if (zero.Count() == 1)
				return 0;

			return zero.SkipLast(1).Max();
		}

		public static void Test()
		{
			var s=solution(529);
			Console.WriteLine(s);

			 s = solution(1041);
			Console.WriteLine(s);

			s = solution(32);
			Console.WriteLine(s);
		}
	}
}
