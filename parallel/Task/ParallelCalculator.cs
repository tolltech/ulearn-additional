namespace ParallelTask
{
    public class ParallelCalculator : IParallelCalculator
    {
        //попробуйте реализовать разными способами вычисление суммы элементов в массиве
        //умножение использовать нельзя!
        //После реализации запустите тест TestBenchmark, чтобы померить скорость
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
            return 0;
        }

        public int SumParallelPLinq(int[] numbers)
        {
            return 0;
        }

        public int SumParallelTaskWhenAll(int[] numbers)
        {
            return 0;
        }

        public int SumParallel3(int[] numbers)
        {
            return 0;
        }
    }
}