using System;

namespace Invoking
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixInvoker = new MatrixInvoker();
            string command;
            do
            {
                Console.WriteLine("Enter command:");
                command = Console.ReadLine();

                var result = matrixInvoker.Invoke(command);
                Console.WriteLine(result);

            } while (command != "end");
        }
    }
}
