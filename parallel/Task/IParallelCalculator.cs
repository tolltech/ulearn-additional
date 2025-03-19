namespace ParallelTask
{
    public interface IParallelCalculator
    {
        int SumMono(int[] numbers);
        int SumMonoLinq(int[] numbers);
        int SumParallelPLinq(int[] numbers);
        int SumParallelTaskWhenAll(int[] numbers);
        int SumParallel3(int[] numbers);
    }
}