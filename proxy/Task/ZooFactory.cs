using System.Linq;
using Task.DontChange;

namespace Task
{
    public class ZooFactory : IZooFactory
    {
        public IZoo CreateZoo()
        {
            var animals = new Animal[] {new Lazybones(), new Elephant(), new Monkey()}.ToArray();
            return new Zoo(animals);
        }
    }
}