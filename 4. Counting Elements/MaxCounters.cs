
namespace MaxCounters
{
    class Solution
    {
        public int[] solution(int N, int[] A)
        {
            var result = new int[N];
            var max = 0;

            var index = -1;


            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] == 1 + N)
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] >= 1 && A[i] <= N)
                    {
                        result[A[i] - 1]++;
                    }
                }

                return result;
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= 1 && A[i] <= N)
                {
                    result[A[i] - 1]++;
                    max=result[A[i] - 1] > max ? result[A[i] - 1] : max;
                }

                if (i== index)
                {
                    for (int k = 0; k < N; k++)
                    {
                        result[k] = max;
                    }
                }

            }
            return result;
        }


        public int[] solution2(int N, int[] A)
        {
            var result = new int[N];
            var max = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= 1 && A[i] <= N)
                {
                    result[A[i] - 1]++;
                    max = result[A[i] - 1];
                }

                if (A[i] == 1 + N)
                {
                    for (int k = 0; k < N; k++)
                    {
                        result[k] = max;
                    }
                }
            }
            return result;
        }

        public static void Test()
        {
            var A = new int[7];
            A[0] = 3;
            A[1] = 4;
            A[2] = 4;
            A[3] = 6;
            A[4] = 1;
            A[5] = 4;
            A[6] = 4;
            var s = new Solution().solution(5, A);

            foreach (var item in s)
            {
                System.Console.WriteLine(item);
            }

        }
    }
}
