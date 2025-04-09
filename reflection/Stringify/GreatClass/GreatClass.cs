namespace Stringify
{
    public class GreatClass : IGreatClass
    {
        private int count;
        public static int number = 42;
        public static string version = "Version: 1.0";
        public string Record { get; set; }
        public int MagicNumber { get; set; }

        public GreatClass()
        {

        }

        public GreatClass(string record, int magicNumber)
        {
            Record = record;
            MagicNumber = magicNumber;
        }

        public GreatClass(int count, bool flag)
        {
            this.count = count;
        }

        public GreatClass(int count, bool flag, string record, int magicNumber)
        {
            this.count = count;
            Record = record;
            MagicNumber = magicNumber;
        }

        public void SetIntField(int number)
        {
            count = number;
        }

        private void ResetRecord()
        {
            Record = null;
        }

        public void SetCountField(int number)
        {
            throw new System.NotImplementedException();
        }
    }
}
