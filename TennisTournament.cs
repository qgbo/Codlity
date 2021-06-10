using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_positive_value
{
	class TennisTournament
	{
		public static int solution(int P, int C)
		{

			var result = 0;

			while(true)
			{
				if (P >= 2 && C >= 1)
					result++;
				else
					break;

				P -= 2;
				C -= 1;
			}

			return result;
		}

		public static void Test()
		{
			var s=solution(10,3);
			Console.WriteLine(s);
		}
	}
}
