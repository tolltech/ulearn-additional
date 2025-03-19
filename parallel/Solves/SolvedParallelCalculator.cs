using ParallelTask;

namespace ParallelSolves
{
    public class SolvedParallelCalculator : IParallelCalculator
    {
        public int SumMono(int[] numbers)
        {
            var result = 0;

            foreach (var number in numbers)
            {
                result += number;
            }

            return result;
        }

        public int SumMonoLinq(int[] numbers)
        {
            return numbers.Sum();
        }

        public int SumParallelPLinq(int[] numbers)
        {
            return numbers.AsParallel().Sum();
        }

        public int SumParallelTaskWhenAll(int[] numbers)
        {
            var tasksCount = 4;
            var page = numbers.Length / tasksCount;

            var tasks = new Task<int>[tasksCount + 1];
            for (var i = 0; i <= tasksCount; i++)
            {
                var leftIndex = i * page;
                var rightIndex = leftIndex + page;

                tasks[i] = Task.Run(() => SumMono(leftIndex, rightIndex, numbers));
            }

            return Task.WhenAll(tasks).GetAwaiter().GetResult().Sum();
        }

        private static int SumMono(int leftIndex, int rightIndex, int[] numbers)
        {
            var result = 0;

            for (var i = leftIndex; i < rightIndex && i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            return result;
        }

        public int SumParallel3(int[] numbers)
        {
            var funcCount = 4;
            var page = numbers.Length / funcCount;

            var funcs = new Func<int>[funcCount + 1];
            for (var i = 0; i <= funcCount; i++)
            {
                var leftIndex = i * page;
                var rightIndex = leftIndex + page;

                funcs[i] = () => SumMono(leftIndex, rightIndex, numbers);
            }

            var result = 0;
            
            Parallel.ForEach(funcs, func => Interlocked.Add(ref result, func()));
            
            return result;
        }
    }
}