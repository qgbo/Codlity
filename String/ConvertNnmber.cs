
namespace ConvertNnmber
{
	using System;

	class Solution
	{
		/// <summary>
		/// 比如1对应a，2对应b，以此类推，一直到26对应z。 数组字符串有多少种？ 111 有3种，AAA，AK，KA
		/// </summary>
		/// <param name="A"></param>
		/// <returns></returns>
		public int solution(string str)
		{
			if (str.Length == 0)
			{
				Console.WriteLine(str + ":" + 1);
				return 1;
			}

			if (str.Length == 1)
			{
				
				Console.WriteLine(str+":"+ 1);
				return 1;
			}


			var n = str[0] - '0';
			var n1 = str[1] - '0';

			var num = solution(str.Substring(2));

			if (n * 10 + n1 <= 26)
				num += solution(str.Substring(1));

			Console.WriteLine(str + ":" + num);
			return num;
		}

		public static void Test()
		{
			var s = new Solution().solution("1283");

			Console.WriteLine(s);
		}
	}
}
