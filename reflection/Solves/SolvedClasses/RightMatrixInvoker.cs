using System;
using System.Globalization;
using System.Reflection;
using Invoking;

namespace Solves
{
    public class RightMatrixInvoker : IMatrixInvoker
    {
        public string Invoke(string command)
        {
            var thisType = GetType();
            var theMethod = thisType.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            if (theMethod == null)
            {
                return string.Empty;
            }

            var result = theMethod.Invoke(this, null);
            return result is string ? result.ToString() : string.Empty;
        }

        public string Hello()
        {
            return "Hello operator";
        }
        
        private string GetTime()
        {
            return DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}