namespace Task.DontChange
{
    public class Zoo : IZoo
    {
       private readonly Animal[] animals;

        public Zoo(Animal[] animals)
        {
            this.animals = animals;
        }

        public void SpendTime()
        {
            foreach (var animal in animals)
            {
                animal.SpendTime(100);
            }            
        }
    }
}