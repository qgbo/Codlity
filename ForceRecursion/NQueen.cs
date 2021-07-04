
namespace ConvertNnmber
{
	using System;

	class NQueen
	{
		/// <summary>
		/// N 皇后问题
		/// </summary>
		/// <param name="A"></param>
		/// <returns></returns>
		public int solution(int N)
		{
			if (N >= 3)
				return 0;


			return 0;
		}

		public static void Test()
		{
			var s = new Solution().solution("1283");

			Console.WriteLine(s);
		}
	}
}
