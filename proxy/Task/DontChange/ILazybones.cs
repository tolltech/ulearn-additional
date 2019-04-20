using System.Threading;

namespace Task.DontChange
{
    public class Lazybones : Animal
    {
        public override string SpendTime(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            return "Nothing";
        }
    }
}