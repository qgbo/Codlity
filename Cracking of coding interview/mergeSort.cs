
namespace codeLity.Cracking_codig_interview
{
	using System;
	using System.Collections.Generic;
	class MergeSort
	{
		public static void solutionRecursion(int[] A)
		{
			for (int i = 0; i < A.Length/2; i++)
			{
				Swap(A, 2*i, 2*i + 1);
			}

			var n = 4;
			while (true)
			{
				for (int i = 0; i < A.Length/n; i++)
				{
					Merge(A, n*i, n);
				}

				Merge(A, n * i, n);

				n = n * 2;
				if (n > A.Length)
					break;
			}

			Merge(A, n * i, n);

		}
		public static void solutionRecursion(int[] A, int start, int length)
		{
			//Console.WriteLine(A[start..(length + start)].Join() + $"==={start},{length}");

			if (length == 1 || length == 0)
			{
				return;
			}

			if (length == 2)
			{
				Swap(A, start, start + 1);
				return;
			}

			var half = length / 2;
			solutionRecursion(A, start, half);
			solutionRecursion(A, start + half,  length- half);

			Merge(A, start, length);
		}

		public static void Merge(int[] A, int start, int length,int rightStart=-1)
		{
			if(rightStart == -1)
				rightStart = start + length / 2;

			var tmp = new int[length];

			var left = start;
			var right = rightStart;

			for (int i = 0; i < length; i++)
			{
				if (left < rightStart && (right == start + length || A[left] <= A[right]))
				{
					tmp[i] = A[left];
					left++;
				}
				else
				{
					tmp[i] = A[right];
					right++;
				}
			}

			for (int i = 0; i < length; i++)
			{
				A[i + start] = tmp[i];
			}
		}


		public static void Swap(int[] A, int j, int i)
		{
			if (A[j] > A[i])
			{
				Console.WriteLine($"swap{i}:{A[i]} ,{j}:{A[j]} ");
				int m = A[j];
				A[j] = A[i];
				A[i] = m;
			}
		}

		public static void Test()
		{
			var a = new List<int>() { 16, 44, 48, 19, 33, 96, 60, 73, 80, 0, 34, 46, 83, 85, 60, 99 };
			var b = new List<int>() { 51, 70, 54, 24, 96, 23 };


			for (int m = 0; m< 5; m++)
			{
				a.Clear();
				b.Clear();
				for (int i = 0; i < 57; i++)
				{
					Random rd = new Random();
					a.Add(rd.Next(0, 100));
					b.Add(a[i]);
				}
				Console.WriteLine(b.ToArray().Join());
				b.Sort();
				Console.WriteLine(b.ToArray().Join());

				var A = a.ToArray();
				solutionRecursion(A, 0, a.Count);
				Console.WriteLine(A.Join());


				Console.WriteLine(A.Join()== b.ToArray().Join());

				Console.WriteLine();
			}

			
		}
	}
}
