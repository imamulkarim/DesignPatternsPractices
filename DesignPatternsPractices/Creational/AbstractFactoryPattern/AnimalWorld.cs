using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.AbstractFactoryPattern
{
    internal class AnimalWorld
    {
        ContinentFactory _continentFactory;
        Carnivour carnivour;
        Harvivour harvivour;
        public AnimalWorld(ContinentFactory continentFactory)
        {
            _continentFactory = continentFactory;

            carnivour= _continentFactory.CreateCarnivour();
            harvivour = _continentFactory.CreateHarvivour();

        }

        public void RunFoodChain()
        {
            carnivour.Eat();
            harvivour.Eat(carnivour);
        }

    }
}
