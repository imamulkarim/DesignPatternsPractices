# Flyweight Design 
[Flyweight Design Pattern in C# with Examples - Dot Net Tutorials](https://dotnettutorials.net/lesson/flyweight-design-pattern/)

The Flyweight Design Pattern reduces the number of objects created, decreases memory footprint, and increases performance. It’s especially useful when many objects share some common properties.

That means the Flyweight Design Pattern is used when there is a need to create many objects of almost similar nature. A large number of objects means it consumes a large amount of memory, and the Flyweight Design Pattern provides a solution for reducing the load on memory by sharing objects.

For example, you have one image, and you want thousands of copies of that image. There are two ways to achieve that. In the first approach, we can get the printouts 1000 times that image. In the second approach, we can get a printout of that image, then we can use that printout, and then we can take 999 xeroxes of that image. Suppose the printout for one image is 2 USD. Then the total amount required is 1000*2=2000USD. If the Xerox price is 1 USD, then the total amount required is 999*1=999 USD, and one printout is 2 USD, so a total of 1001 USD. So, we can save much amount if we follow the second approach. This is also the same in programming. We can achieve this by using the Flyweight Design Pattern in C#.
