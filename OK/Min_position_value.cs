using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_positive_value
{
	class Min_position_value
	{
		public static int solution(int[] A)
		{
			var positiveA = A.Where(t => t > 0).OrderBy(t => t).ToArray();


			if (positiveA.Length == 0 || positiveA[0] > 1)
			{
				return 1;
			}

			for (int i = 0; i < positiveA.Length; i++)
			{
				if (i + 1 == positiveA.Length)
					return positiveA[i] + 1;

				if (positiveA[i + 1] - positiveA[i] > 1)
				{
					return positiveA[i] + 1;
				}
			}

			throw new Exception("this should not exec");
		}
	}
}
