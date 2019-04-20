using Task.DontChange;

namespace Task
{
    public class ZooFactory : IZooFactory
    {
        public IZoo CreateZoo()
        {
            var animals = new[] {new Lazybones()};
            return new Zoo(animals);
        }
    }
}