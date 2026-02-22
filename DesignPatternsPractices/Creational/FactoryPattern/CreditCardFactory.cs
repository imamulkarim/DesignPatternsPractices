using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.FactoryPattern;

internal class CreditCardFactory
{
    // Dictionary mapping card type strings to their corresponding class types
    private static readonly Dictionary<string, Type> cardRegistry = new Dictionary<string, Type>
    {
        { "MoneyBack", typeof(MoneyBack) },
        { "Titanium", typeof(Titanium) },
        { "Platinum", typeof(Platinum) }
    };

    public static ICreditCard GetCreditCard(string cardType)
    {
        if (cardRegistry.ContainsKey(cardType))
        {
            return (ICreditCard)Activator.CreateInstance(cardRegistry[cardType])!;
        }

        throw new ArgumentException("Invalid card type");
    }


}


/*
* 
* 
* Using Activator with Interfaces
If you have multiple classes implementing the same interface:
public interface IMyService { void DoWork(); }
public class ServiceA : IMyService { public void DoWork() => Console.WriteLine("A"); }
public class ServiceB : IMyService { public void DoWork() => Console.WriteLine("B"); }


You can instantiate dynamically:
Type type = typeof(ServiceA); // or typeof(ServiceB)
IMyService service = (IMyService)Activator.CreateInstance(type);
service.DoWork();

1. Create Instance by Type
Type type = typeof(MyClass);
object obj = Activator.CreateInstance(type);

MyClass myObj = (MyClass)obj;


Create Instance by Type Name
object obj = Activator.CreateInstance("MyAssemblyName", "MyNamespace.MyClass").Unwrap();


Create Instance with Constructor Parameters
public class MyClass
{
public MyClass(string name, int age)
{
    Console.WriteLine($"Name: {name}, Age: {age}");
}
}

Type type = typeof(MyClass);
object obj = Activator.CreateInstance(type, "Imamul", 35);

Generic Version
MyClass myObj = Activator.CreateInstance<MyClass>();


*/