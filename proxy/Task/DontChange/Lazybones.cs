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

    public class Elephant : Animal
    {
        public override string SpendTime(int milliseconds)
        {
            Thread.Sleep(milliseconds * 10);
            return "A lot of shit";
        }
    }

    public class Monkey : Animal
    {
        public override string SpendTime(int milliseconds)
        {
            Thread.Sleep((int)(milliseconds * 0.5));
            return "Noize";
        }
    }
}