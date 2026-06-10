The Decorator Design Pattern in C# is a structural design pattern that allows you to dynamically add new behaviors or responsibilities to an object at runtime without altering its existing structure. It acts as a wrapper wrapper around a core class, adhering strictly to the <b> Open/Closed Principle </b> (classes should be open for extension but closed for modification).

# Structure of the Pattern
Rather than relying on deep, complex inheritance trees that cause a "class explosion," 
the pattern favors composition. It consists of four distinct architectural elements:

- [ ] Component Interface: The common base interface or abstract class defining the operations that can be altered dynamically
- [ ] Concrete Component: The underlying object that contains the baseline, core functionality
- [ ] Base Decorator: An abstract class implementing the component interface while holding an internal, constructor-injected reference to a component instance
- [ ] Concrete Decorators: The specific classes extending the base decorator that execute extra custom behaviors either before or after forwarding the call to the original object



## Usage
The following code snippet demostratres an example of the Decorator Design Pattern in C#. 
Where it defines an abstract class `OrderBase` with a method `CalculateTotalOrderPrice()`, 
and the `RegularOrder` class is the concrete component that implements the method to calculate 
the total price of a regular order, while the `Preorder` class is a concrete decorator that applies a discount to the total price for preorders.

But this example is <b>not recommended</b> to be used in real-world applications 
as it does not fully utilize the benefits of the Decorator pattern.

if a new feature needs to be added, such as a discount for pre orders, it would require modifying the `Preorder` class, which violates the <b>Open/Closed Principle.</b>

````````
public abstract class OrderBase
{
    protected List<Product> products = new List<Product>
    {
        new Product {Name = "Phone", Price = 587},
        new Product {Name = "Tablet", Price = 800},
        new Product {Name = "PC", Price = 1200}
    };

    public abstract double CalculateTotalOrderPrice();
}

public class RegularOrder : OrderBase
{
    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine("Calculating the total price of a regular order");
        return products.Sum(x => x.Price);
    }
}

public class Preorder : OrderBase
{
    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine("Calculating the total price of a preorder.");
        return products.Sum(x => x.Price) * 0.9;
    }
}

````````

# Recommended

````````
namespace DecoratorPatternExample
{
    // 1. Component Interface
    public interface IMessageService
    {
        void Send(string message);
    }

    // 2. Concrete Component
    public class SimpleMessageService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending message: '{message}'");
        }
    }

    // 3. Base Decorator 
    public abstract class MessageServiceDecorator : IMessageService
    {
        protected readonly IMessageService _innerService;

        protected MessageServiceDecorator(IMessageService service)
        {
            _innerService = service;
        }

        public virtual void Send(string message)
        {
            _innerService.Send(message); // Delegating execution
        }
    }

    // 4. Concrete Decorator A: Adds Logging Behavior
    public class LoggingDecorator : MessageServiceDecorator
    {
        public LoggingDecorator(IMessageService service) : base(service) { }

        public override void Send(string message)
        {
            Console.WriteLine($"[LOG - BEFORE]: Executing Send with message: '{message}'");
            base.Send(message);
            Console.WriteLine("[LOG - AFTER]: Send operation complete.");
        }
    }

    // 4. Concrete Decorator B: Adds Validation Behavior
    public class ValidationDecorator : MessageServiceDecorator
    {
        public ValidationDecorator(IMessageService service) : base(service) { }

        public override void Send(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("[VALIDATION ERROR]: Cannot send an empty message.");
                return;
            }

            base.Send(message);
        }
    }


    // Create the simple baseline service
    IMessageService service = new SimpleMessageService();

    // Stack behavior cleanly at runtime by wrapping components
    IMessageService secureAndLoggedService = new LoggingDecorator(
        new ValidationDecorator(service)
    );

    // Execute workflows transparently
    Console.WriteLine("--- Test 1: Valid Message ---");
    secureAndLoggedService.Send("Hello World!");

    Console.WriteLine("\n--- Test 2: Invalid Message ---");
    secureAndLoggedService.Send(""); 

````````

## When to Use vs. When to Avoid

👍 Best Scenarios for Use
- Adding responsibilities to single object instances without altering the underlying codebase
- Stacking dynamic permutations of behaviors at runtime (e.g., encryption + compression + buffering).
- Avoiding subclassing due to rigid multiple-inheritance restrictions in C#.

👎 Scenarios to Avoid
- Modifying the fundamental type's public API surface or adding completely separate public methods.
- Environments where lightweight memory usage is highly critical (highly nested wrapper graphs complicate allocation diagnostics).
- Complex scenarios where the internal ordering of wrapped behaviors fluctuates unreliably.