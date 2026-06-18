# Flyweight Design Pattern in C #
https://dotnettutorials.net/lesson/flyweight-design-pattern/

The Flyweight Design Pattern reduces the number of objects created, decreases memory footprint, and increases performance. It’s especially useful when many objects share some common properties.

That means the Flyweight Design Pattern is used when there is a need to create many objects of almost similar nature. A large number of objects means it consumes a large amount of memory, and the Flyweight Design Pattern provides a solution for reducing the load on memory by sharing objects.

## Example to Understand Flyweight Design Pattern in C# ##

Please look at the following image to better understand the Flyweight Design Pattern. As you can see in the following image, we created and stored one circle object in the Cache. Here, the circle object we stored in the cache has no color. Suppose, let’s say, we have to create 90000 circle objects in green and 90000 circle objects in blue. Again, we must create 80000 circle objects, which are orange, and 70000 circle objects in black. If you notice, all the circle object shapes are the same, only the color changes.

╔════════════════════════════════════════════════════════════════════════════╗
║                    FLYWEIGHT PATTERN - VISUAL OVERVIEW                     ║
╚════════════════════════════════════════════════════════════════════════════╝

┌──────────────────────────────────────────────────────────────────────────┐
│ PROBLEM: Creating 340,000 Circle Objects (Without Flyweight)            │
├──────────────────────────────────────────────────────────────────────────┤
│                                                                          │
│  90,000 Green    90,000 Blue     80,000 Orange    70,000 Black           │
│  Circles         Circles         Circles          Circles                │
│     │                │               │                │                  │
│     ▼                ▼               ▼                ▼                  │
│  [O○o] (Green)  [O●o] (Blue)   [O◆o] (Orange)  [O■o] (Black)             │
│  [O○o] (Green)  [O●o] (Blue)   [O◆o] (Orange)  [O■o] (Black)             │
│  [O○o] (Green)  [O●o] (Blue)   [O◆o] (Orange)  [O■o] (Black)             │
│  ...             ...            ...              ...                     │
│                                                                          │
│  MEMORY: 340,000 separate objects × size per object = HIGH MEMORY        │
└──────────────────────────────────────────────────────────────────────────┘

As per the Flyweight Design Pattern, we can improve the performance by creating the circle object only once time and reusing that circle object many times to create different types of colors. Suppose you want to create 90000 circle objects with green color, then what you can do is. Instead of creating new circle objects every time and filling them with green color, you can get the circle object from the Cache and fill it with green color. In the same way, you can create 90000 circle objects with green color. So, in this way, we can improve the application’s performance using the Flyweight Design Pattern in C#.

## In Flyweight Design Pattern, there are two states, i.e., Intrinsic and Extrinsic.


┌──────────────────────────────────────────────────────────────────────────┐
│ SOLUTION: Flyweight Factory + Shared Shape Object                        │
├──────────────────────────────────────────────────────────────────────────┤
│                                                                          │
│     ┌─────────────────────────┐                                        │
│     │ FlyweightFactory        │   ◄── Manages Cache                   │
│     │ Cache: <Key, Flyweight> │                                        │
│     └───────────┬─────────────┘                                        │
│                 │                                                       │
│    ┌────────────┴────────────┐                                        │
│    │                         │                                        │
│    ▼                         ▼                                        │
│ ┌──────────────┐         ┌──────────────┐                            │
│ │ Circle Shape │         │ Circle Shape │      (INTRINSIC STATE)     │
│ │ (Flyweight)  │         │ (Flyweight)  │      Shared, immutable     │
│ │              │         │              │      • Radius              │
│ │ Radius: 5    │         │ Radius: 10   │      • Shape              │
│ └────────┬─────┘         └────────┬─────┘      • Design             │
│          │                       │                                    │
│ ┌────────┴───────────────────────┴────────┐                         │
│ │ draw(x, y, color) - EXTRINSIC STATE    │                         │
│ │ Called 340,000 times with different:   │                         │
│ │ • color (Green, Blue, Orange, Black)  │                         │
│ │ • x, y coordinates                    │                         │
│ │ • z-order, rotation, scale (optional) │                         │
│ └────────────────────────────────────────┘                         │
│                                                                          │
│  MEMORY: ~2 Flyweight objects + 340,000 lightweight context calls     │
│  RESULT: Dramatic memory reduction & performance improvement         │
└──────────────────────────────────────────────────────────────────────┘

╔════════════════════════════════════════════════════════════════════════════╗
║                          CODE STRUCTURE PATTERN                            ║
╠════════════════════════════════════════════════════════════════════════════╣
║                                                                            ║
║  public interface IFlyweight {                                            ║
║      void Draw(int x, int y, Color color);  // Extrinsic params         ║
║  }                                                                        ║
║                                                                            ║
║  public class Concreteflyweight : IFlyweight {                           ║
║      private readonly int radius;  // Intrinsic (shared) state          ║
║      public ConcreteCircle(int r) => radius = r;                        ║
║      public void Draw(int x, int y, Color color)                        ║
║          => Console.WriteLine($"Circle at {x},{y} Color:{color}");      ║
║  }                                                                        ║
║                                                                            ║
║  public class FlyweightFactory {                                         ║
║      private Dictionary<string, IFlyweight> cache = new();              ║
║      public IFlyweight GetCircle(int radius) {                          ║
║          string key = radius.ToString();                                ║
║          if (!cache.ContainsKey(key))                                   ║
║              cache[key] = new ConcreteCircle(radius);                   ║
║          return cache[key];  // Return cached instance                 ║
║      }                                                                    ║
║  }                                                                        ║
║                                                                            ║
╚════════════════════════════════════════════════════════════════════════════╝

## The following are the three components involved in the Flyweight Design Pattern.

- <b>Flyweight:</b> The Flyweight interface enables sharing but does not enforce it. The concrete objects that implement this interface can either be shared or unshared. This will be an interface that defines the members of the flyweight objects.
- <b>ConcreteFlyweight:</b> The ConcreteFlyweight class implements the Flyweight interface and adds storage for the intrinsic state. It must be shareable; any state we store in this object should be intrinsic.
- <b>FlyweightFacory:</b> The FlyweightFacory has the GetFlyweight method, and you must pass the key to this method. Based on the key, it will check whether the flyweight object is in the cache. If it is there, then it will return that existing flyweight object. If it is not there, then it will create a new flyweight object, add that object to the cache, and return that flyweight object.

````````
//Step 1: Creating Flyweight Interface
namespace FlyweightDesignPattern
{
    // Flyweight Interface
    // This is an interface that defines the members of the flyweight objects.
    public interface IShape
    {
        void Draw();
    }
}
//Step 2: Creating ConcreteFlyweight
using System;
namespace FlyweightDesignPattern
{
    // ConcreteFlyweight
    // This is a class which is Inherits from the Flyweight Interface.
    public class Circle : IShape
    {
        public string Color { get; set; }

        //The following Properties Values are going to be the same for all Circle Shape Object
        private readonly int XCor = 10;
        private readonly int YCor = 20;
        private readonly int Radius = 30;

        //For Each Circle Object, we need to call the Following Method to set the Color
        public void SetColor(string Color)
        {
            this.Color = Color;
        }

        public void Draw()
        {
            Console.WriteLine(" Circle: Draw() [Color : " + Color + ", X Cor : " + XCor + ", YCor :" + YCor + ", Radius :" + Radius);
        }
    }
}

//Step 3: Creating FlyweightFactory
using System;
using System.Collections.Generic;
namespace FlyweightDesignPattern
{
    // FlyweightFacory
    // This is a factory class used to create concrete objects of the ConcreteFlyweight type
    public class ShapeFactory
    {
        //The Following Dictionary is going to act as our Cache Memory
        private static Dictionary<string, IShape> shapeMap = new Dictionary<string, IShape>();

        //The following Method is going to return the Shape Object
        public static IShape GetShape(string shapeType)
        {
            IShape shape = null;
            if (shapeType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
            {
                //If the key shapeType i.e. circle is stored in the Cache, then return the value of the key
                //else create circle object, store it in the Cache, and return the object
                if (shapeMap.TryGetValue("circle", out shape))
                {
                }
                else
                {
                    shape = new Circle();
                    shapeMap.Add("circle", shape);
                    Console.WriteLine(" Creating circle object with out any color in shapefactory \n");
                }
            }
            return shape;
        }
    }
}

//Step4: Client
using System;
namespace FlyweightDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating Circle Objects with Red Color
            Console.WriteLine("\n Red color Circles ");
            for (int i = 0; i < 3; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Red");
                circle.Draw();
            }

            //Creating Circle Objects with Green Color
            Console.WriteLine("\n Green color Circles ");
            for (int i = 0; i < 3; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }

            //Creating Circle Objects with Blue Color
            Console.WriteLine("\n Blue color Circles");
            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }

            //Creating Circle Objects with Orange Color
            Console.WriteLine("\n Orange color Circles");
            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Orange");
                circle.Draw();
            }

            //Creating Circle Objects with Black Color
            Console.WriteLine("\n Black color Circles");
            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Black");
                circle.Draw();
            }

            Console.ReadKey();
        }
    }
}

````````