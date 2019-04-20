using Stringify.GreatClass;

namespace Stringify
{
    public class Task
    {
        public class GreatClass : IGreatClass
        {
            private int count;
            public bool flag;
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
                this.flag = flag;
            }

            public GreatClass(int count, bool flag, string record, int magicNumber)
            {
                this.count = count;
                this.flag = flag;
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

            public void SetFlagField(bool flag)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}