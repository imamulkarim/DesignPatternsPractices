namespace DesignPatternsPractices.Creational.AbstractFactoryPattern
{
    public abstract class Harvivour
    {
        public abstract void Eat(Carnivour h);

    }

    public class Wolf : Harvivour
    {
        public override void Eat(Carnivour h)
        {
            Console.WriteLine($"{this.GetType().Name} Eat {h.GetType().Name}");
        }
    }

    public class Lion : Harvivour
    {
        public override void Eat(Carnivour h)
        {
            Console.WriteLine($"{this.GetType().Name} Eat {h.GetType().Name}");
        }
    }

}