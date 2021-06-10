using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_positive_value
{
	class CyclicRotation
	{
		public static int[] solution(int[] A, int K)
		{
			if (A==null || !A.Any())
			{
				return A;
			}


			K = K% A.Length;

			for (int i = 0; i < K; i++)
			{
				var tmp = A.Last();
				
				for (int j = A.Length - 1; j >= 1; j--)
				{
					A[j] = A[j-1];
				}
				A[0] = tmp;
			}
			
			return A;
		}

		public static int[] solution2(int[] A, int K)
		{

			K = K % A.Length;

			var B = Array.AsReadOnly(A);
			for (int i = 0; i < A.Length; i++)
			{
				var c = (A.Length * 2 - 1 - K) / A.Length;
				A[i] = B[c];
			}
			// hang in the air

			return A;
		}

		public static void Test()
		{
			
			var s=solution(new int[] { 3, 8, 9, 7, 6 },3);
			Console.WriteLine(string.Join(",",s));

			 s = solution(new int[] { 1, 2, 3, 4 }, 4);
			Console.WriteLine(string.Join(",", s));

			s = solution(new int[] { 3, 8, 9, 7, 6 }, 30);
			Console.WriteLine(string.Join(",", s));
		}
	}
}
