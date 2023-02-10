// See https://aka.ms/new-console-template for more information
//using System;

using DesignPatternsPractices.Creational.AbstractFactoryPattern;
using DesignPatternsPractices.Creational.Builder;
using DesignPatternsPractices.Creational.FactoryMethod.Creator;
using DesignPatternsPractices.Creational.FactoryMethod.Product;
using DesignPatternsPractices.Creational.ObjectPool;
using DesignPatternsPractices.Creational.Prototype;
using DesignPatternsPractices.Structural.Flyweight;
using System.Buffers;

#region builder pattern practice
//https://dotnettutorials.net/lesson/builder-design-pattern-real-time-example/
//https://stackoverflow.com/questions/38480410/builder-pattern-with-nested-objects/38480829#38480829
//https://www.dotnettricks.com/learn/designpatterns/builder-design-pattern-dotnet

//Console.WriteLine("Builder Pattern !");

//var rb = new ReceiptBuilder();
//var receipt = rb.WithName("Name")
//    .WithDate(DateTime.Now)
//    .WithItem("Item1", i => i.WithIngredients("Ingredients1"))
//    .WithItem("Item2", i => i.WithIngredients("Ingredients1"))
//    .Build();
//Console.WriteLine(receipt);
//Console.WriteLine("End Builder Pattern !");


////testa t = new testa().AddData("test a").AddData("test b").Build();

//VehicleBuilder builder;

//builder = new CarBuilder();
//builder.BuildEngine();
//builder.BuildFrame();
//builder.BuildOutDoors();
//builder.BuildWheels();
//builder.Vehicle.Show();


#endregion

#region prototype

//ColorManager colormanager = new ColorManager();
//// Initialize with standard colors
//colormanager["red"] = new Color(255, 0, 0);
//colormanager["green"] = new Color(0, 255, 0);
//colormanager["blue"] = new Color(0, 0, 255);
//// User adds personalized colors
//colormanager["angry"] = new Color(255, 54, 0);
//colormanager["peace"] = new Color(128, 211, 128);
//colormanager["flame"] = new Color(211, 34, 20);
//// User clones selected colors
//Color color1 = colormanager["red"].Clone() as Color;
//Color color2 = colormanager["peace"].Clone() as Color;
//Color color3 = colormanager["flame"].Clone() as Color;
//// Wait for user
//Console.ReadKey();

#endregion

#region abastract factory pattern
////https://www.dofactory.com/net/abstract-factory-design-pattern

//ContinentFactory america = new AmericaContinent();
//AnimalWorld world = new AnimalWorld(america);
//world.RunFoodChain();


//ContinentFactory africa = new AfricaContinent();
//world = new AnimalWorld(africa);
//world.RunFoodChain();

#endregion

#region factory method
https://www.dofactory.com/net/factory-method-design-pattern
      //Document[] documents = new Document[2];
      //documents[0] = new Resume();
      //documents[1] = new Report();
      //// Display document pages
      //foreach (Document document in documents)
      //{
      //    Console.WriteLine("\n" + document.GetType().Name + "--");
      //    foreach (Pages page in document.Pages)
      //    {
      //        Console.WriteLine(" " + page.GetType().Name);
      //    }
      //}
      //// Wait for user
      //Console.ReadKey();
#endregion

#region object pool

//Factory fa = new Factory();
//Student myStu = fa.GetStudent();
//Console.WriteLine("First object");
//Student myStu1 = fa.GetStudent();
//Console.WriteLine("Second object");
//Student myStu2 = fa.GetStudent();
//Console.WriteLine("Third object");
//Console.Read();


//ArrayPool
#endregion



// structural pattern ***********************************



ImageDisplay imageDisplay1 = new ImageDisplay("image1.jpg");
ImageDisplay imageDisplay2 = new ImageDisplay("image1.jpg");
ImageDisplay imageDisplay3 = new ImageDisplay("image2.jpg");

Console.WriteLine(ReferenceEquals(imageDisplay1.Image, imageDisplay2.Image)); // True
Console.WriteLine(ReferenceEquals(imageDisplay1.Image, imageDisplay3.Image)); // False


Console.Read();
