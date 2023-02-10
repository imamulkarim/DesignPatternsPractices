using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Structural.Flyweight
{
    internal class ImageDisplay
    {
        public ImageFlywight Image;

        public ImageDisplay(string imagePath)
        {
            Image= ImageFlywight.GetFlywight(imagePath);
        }

        public void Display()
        {
            Console.WriteLine("Displaying Image:" + Image.ImagePath);
        }
    }
}
