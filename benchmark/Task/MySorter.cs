using System;

namespace Task
{
    public static class MySorter
    {
        public static void CountingSort(int[] collection, int minValue, int maxValue)
        {
            var count = new int[maxValue - minValue + 1];

            foreach (var element in collection)
            {
                count[element - minValue]++;
            }

            for (int i = minValue, k = 0; i <= maxValue; i++)
            {
                while (count[i - minValue]-- > 0)
                {
                    collection[k] = i;
                    k++;
                }
            }
        }

        public static void BubbleSort<T>(T[] collection)
            where T : IComparable
        {
            for (var i = 0; i < collection.Length; i++)
            {
                for (var j = 0; j < collection.Length - 1 - i; j++)
                {
                    if (collection[j].CompareTo(collection[j + 1]) == 1)
                    {
                        Swap(ref collection[j], ref collection[j + 1]);
                    }
                }
            }
        }

        private static void Swap<T>(ref T firstElement, ref T secondElement)
        {
            (firstElement, secondElement) = (secondElement, firstElement);
        }
    }
}