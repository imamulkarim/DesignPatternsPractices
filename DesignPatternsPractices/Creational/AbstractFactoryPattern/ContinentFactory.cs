using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.AbstractFactoryPattern
{
    public abstract class ContinentFactory
    {
        public abstract Harvivour CreateHarvivour();
        public abstract Carnivour CreateCarnivour();
    }


    public class AfricaContinent : ContinentFactory
    {
        public override Carnivour CreateCarnivour()
        {
           return new WildBeast();
        }

        public override Harvivour CreateHarvivour()
        {
            return new Wolf();
        }
    }

    public class AmericaContinent : ContinentFactory
    {
        public override Carnivour CreateCarnivour()
        {
            return new Bison();
        }

        public override Harvivour CreateHarvivour()
        {
            return new Lion();
        }
    }
}
