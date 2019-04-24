using System;

namespace EncapsulationTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = spiralNumbers(3);
            Console.ReadKey();
        }

        static int[][] spiralNumbers(int n)
        {
            var upMax = n - 1;
            var downMax = n - 1;
            var rightMax = n - 1;
            var leftMax = n - 1;
            var upMin = 0;
            var downMin = 0;
            var rightMin = 0;
            var leftMin = 0;
            var outputArray = new int[n][];

            for (var i = 0; i < n; i++)
            {
                outputArray[i] = new int[n];
            }

            for (var i = 0; i < n * n;)
            {
                for (var k = leftMin; k <= rightMax; k++)
                {
                    outputArray[upMin][k] = i++;
                }

                upMin++;
                for (var k = upMin; k <= downMax; k++)
                {
                    outputArray[k][rightMax] = i++;
                }

                rightMax--;
                for (var k = rightMax; k >= leftMin; k--)
                {
                    outputArray[downMax][k] = i++;
                }

                downMax--;
                for (var k = downMax; k >= upMin; k--)
                {
                    outputArray[k][leftMin] = i++;
                }

                upMax--;
                leftMax--;
                rightMin++;
                leftMin++;
                downMin++;
            }

            return outputArray;
        }
    }


}
