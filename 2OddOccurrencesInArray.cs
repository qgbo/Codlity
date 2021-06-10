using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_positive_value
{
	class OddOccurrencesInArray
	{
		public static int solution(int[] A)
		{
			var B = A.GroupBy(t => t).Where(t=>t.Count()==1);

			return B.FirstOrDefault().Key;
		}

		public static void Test()
		{
			var s=new int[] { 9,3, 9,3, 9, 7, 9 };

		
			var result=solution(s);
			Console.WriteLine(result);
			
		}
	}
}
