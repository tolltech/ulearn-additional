using System.Linq;
using Task.DontChange;

namespace Task
{
    public class ZooFactory : IZooFactory
    {
        //ни в коем случае нельзя менять код в папке DontChange!!!
        //сначала попробуйте изменить этот метод, не исопльзуясторонних библиотек
        //потом попробуйте использовать библиотеку SexyProxy и сравните колиечство кода решения в обоих случаях
        //https://github.com/kswoll/sexy-proxy
        public IZoo CreateZoo()
        {
            var animals = new Animal[] {new Lazybones(), new Elephant(), new Monkey()}.ToArray();
            return new Zoo(animals);
        }
    }
}