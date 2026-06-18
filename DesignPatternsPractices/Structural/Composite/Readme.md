# Composite Design Pattern in C#
https://dotnettutorials.net/lesson/composite-design-pattern/
Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly. 

It’s useful for representing hierarchical structures such as file systems, UI components, or organizational structures.


Here we want to assemble a computer. As we know, a computer comprises several parts or elements integrated together
So, here, a Computer, Cabinet, Peripherals, Hard Disk, Motherboard, Mouse, Keyboard, CPU, RAM, etc. all are objects.



````````

                              Computer
                                 |
                    ______________|______________
                   |              |              |
                Cabinet       Motherboard    Peripherals
                   |              |              |
        ___________|___      _____|_____    _____|_____
       |           |  |    |     |     |   |     |     |
      CPU         RAM HDD  BIOS CMOS Power Mouse Keyboard Monitor

````````
A composite object is an object which contains other objects. You need to remember that a composite object may also contain other composite objects. The object that does not contain other objects is treated as a leaf object.

The Composite Design Pattern Consists of the following components:

- <b>Component Interface:</b> Define an interface or abstract class for implementing the composites and leaf nodes.
- <b>Leaf:</b> Implement the component interface for the leaf nodes with no children.
- <b>Composite:</b> Implement the component interface and also include a collection of components. The composite object can add, remove, and access the child components.
- <b>Client Code:</b> The client works with all elements through the component interface.

````````
//Step1: Creating IComponent Interface
public interface IComponent
    {
        void DisplayPrice();
    }
//Step2: Creating Leaf Class
 public class Leaf : IComponent
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public Leaf(string name, int price)
        {
            this.Price = price;
            this.Name = name;
        }
        public void DisplayPrice()
        {
            Console.WriteLine($"\tComponent Name: {Name} and Price: {Price}");
        }
    }
//Step3: Creating Composite Class
public class Composite : IComponent
    {
        public string Name { get; set; }
        private List<IComponent> _components = new List<IComponent>();
        public Composite(string name)
        {
            this.Name = name;
        }
        public void Add(IComponent component)
        {
            _components.Add(component);
        }
        public void Remove(IComponent component)
        {
            _components.Remove(component);
        }
        public void DisplayPrice()
        {
            Console.WriteLine($"Composite Name: {Name}");
            foreach (var component in _components)
            {
                component.DisplayPrice();
            }
        }
    }
//Step4: Client Program
class Program
    {
        static void Main(string[] args)
        {
            //Creating Leaf Objects
            Leaf cpu = new Leaf("CPU", 250);
            Leaf ram = new Leaf("RAM", 150);
            Leaf hdd = new Leaf("HDD", 100);
            Leaf bios = new Leaf("BIOS", 50);
            Leaf cmos = new Leaf("CMOS", 30);
            Leaf power = new Leaf("Power Supply", 80);
            Leaf mouse = new Leaf("Mouse", 20);
            Leaf keyboard = new Leaf("Keyboard", 40);
            Leaf monitor = new Leaf("Monitor", 200);
            //Creating Composite Object
            Composite motherboard = new Composite("Motherboard");
            motherboard.Add(cpu);
            motherboard.Add(ram);
            motherboard.Add(hdd);
            motherboard.Add(bios);
            motherboard.Add(cmos);
            Composite peripherals = new Composite("Peripherals");
            peripherals.Add(mouse);
            peripherals.Add(keyboard);
            peripherals.Add(monitor);
            Composite computer = new Composite("Computer");
            computer.Add(motherboard);
            computer.Add(peripherals);
            computer.Add(power);
            //Displaying the price of all components in the computer
            computer.DisplayPrice();
        }
    }
````````

## Advantages of Composite Design Pattern:
- <b>Simplified Client Code</b>: Clients can treat composite structures and individual objects uniformly, simplifying client code.
- <b>Clear Structure</b>: Clearly defines the hierarchy or tree structure of complex objects.
- <b>Ease of Modification</b>: Adding new kinds of components is easy as long as they support the same interface.
- <b>Flexibility in Design</b>: The pattern provides flexibility to compose objects into tree structures to represent part-whole hierarchies.

## The Composite Design Pattern in C# is particularly useful in scenarios where:

- <b>Hierarchical Tree Structures</b>: When you need to represent a part-whole hierarchy. The pattern is ideal for situations where you are dealing with a tree structure with individual objects and compositions of objects treated uniformly.
- <b>Treating Individual and Composite Objects Uniformly</b>: If you want to treat both individual objects and their compositions in the same way. This is useful when you want to ignore the difference between compositions of objects and individual objects.
- <b>Simplifying Client Code</b>: It’s useful for simplifying client code, as it can treat composite structures and individual objects similarly, simplifying the client’s interaction with the structure.
- <b>Dynamic Configuration</b>: When the configuration of the object structure can change at runtime, the Composite pattern allows for the dynamic addition or removal of components in the tree structure.
- <b>Graphic User Interfaces</b>: In GUI development, you might have complex widgets composed of simpler components but want to treat them all as part of a uniform interface.
- <b>File System Representations</b>: Representing file and directory structures, where directories can contain files and other directories, and you want to treat them all as a single file system entity.