using Stringify;

namespace Solves.SolvedClasses
{
    public class RightGreatClass : IGreatClass
    {
        private int count;
        public static int number = 42;
        public static string version = "Version: 1.0";
        public string Record { get; set; }
        public int MagicNumber { get; set; }

        public RightGreatClass()
        {

        }

        public RightGreatClass(string record, int magicNumber)
        {
            Record = record;
            MagicNumber = magicNumber;
        }

        public RightGreatClass(int count, bool flag)
        {
            this.count = count;
        }

        public RightGreatClass(int count, bool flag, string record, int magicNumber)
        {
            this.count = count;
            Record = record;
            MagicNumber = magicNumber;
        }

        public void SetCountField(int number)
        {
            count = number;
        }

        private void ResetRecord()
        {
            Record = null;
        }
    }
}