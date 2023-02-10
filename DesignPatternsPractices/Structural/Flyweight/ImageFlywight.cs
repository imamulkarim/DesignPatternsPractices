using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Structural.Flyweight
{
    internal class ImageFlywight
    {
        private static Dictionary<string, ImageFlywight> flywights = new Dictionary<string, ImageFlywight>();
        public string ImagePath { get; set; }
        public static ImageFlywight GetFlywight(string imagePath) {
            if (!flywights.ContainsKey(imagePath))
            {
                flywights[imagePath] = new ImageFlywight { ImagePath= imagePath };
            }

            return flywights[imagePath];
        }
    }
}
