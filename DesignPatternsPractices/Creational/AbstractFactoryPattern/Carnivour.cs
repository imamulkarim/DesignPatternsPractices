namespace DesignPatternsPractices.Creational.AbstractFactoryPattern
{
    public abstract class Carnivour
    {
        public abstract void Eat();
    }

    public class Bison : Carnivour
    {
        public override void Eat()
        {
            Console.WriteLine(this.GetType().Name + " Eat Grass");
        }
    }

    public class WildBeast : Carnivour
    {
        public override void Eat()
        {
            Console.WriteLine(this.GetType().Name + " Eat Grass");
        }
    }

}