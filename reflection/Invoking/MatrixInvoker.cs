using System;
using System.Globalization;

namespace Invoking
{
    public class MatrixInvoker : IMatrixInvoker
    {
        public string Invoke(string command)
        {
            throw new System.NotImplementedException();
        }

        public string Hello()
        {
            return "Hello opperator";
        }
        
        private string GetTime()
        {
            return DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}