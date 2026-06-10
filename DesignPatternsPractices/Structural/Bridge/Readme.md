# Bridge Design Pattern
https://dotnettutorials.net/lesson/bridge-design-pattern/


The Bridge Design Pattern Decouples an abstraction from its implementation so that the two can vary independently. This pattern involves an interface that acts as a bridge between the abstraction class and implementer classes.

In the Bridge Design Pattern, there are 2 parts. 
- The first part is the <b>Abstraction, </b>
- and the second part is the <b>Implementation. </b>

The Bridge Design Pattern allows both <b>Abstraction</b> and <b>Implementation</b> to be developed independently, and the client code can only access the <b>Abstraction</b> part without being concerned about the <b>Implementation</b> part.

## Example of Bridge Design Pattern in C#
### Implementation
```````
public interface ILEDTV
    {
        void SwitchOn();
        void SwitchOff();
        void SetChannel(int channelNumber);
    }

public class SamsungLedTv : ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Samsung TV");
        }
        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Samsung TV");
        }
        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Samsung TV");
        }
    }

 public class SonyLedTv : ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Sony TV");
        }
        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Sony TV");
        }
        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Sony TV");
        }
    }
```````

### Abstraction

```````
public abstract class AbstractRemoteControl
    {
        protected ILEDTV ledTv;
        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(int channelNumber);
    }

public class SamsungRemoteControl : AbstractRemoteControl
    {
        public SamsungRemoteControl(ILEDTV ledTv) 
        {
            this.ledTv = ledTv;
        }
        public override void SwitchOn()
        {
            ledTv.SwitchOn();
        }
        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }
        public override void SetChannel(int channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }

public class SonyRemoteControl : AbstractRemoteControl
    {
        public SonyRemoteControl(ILEDTV ledTv)
        {
            this.ledTv = ledTv;
        }
        public override void SwitchOn()
        {
            ledTv.SwitchOn();
        }
        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }
        public override void SetChannel(int channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }

```````

### Client Code
```````

class Program
    {
        static void Main(string[] args)
        {
            ILEDTV samsungLedTv = new SamsungLedTv();
            AbstractRemoteControl samsungRemoteControl = new SamsungRemoteControl(samsungLedTv);
            samsungRemoteControl.SwitchOn();
            samsungRemoteControl.SetChannel(5);
            samsungRemoteControl.SwitchOff();
            ILEDTV sonyLedTv = new SonyLedTv();
            AbstractRemoteControl sonyRemoteControl = new SonyRemoteControl(sonyLedTv);
            sonyRemoteControl.SwitchOn();
            sonyRemoteControl.SetChannel(10);
            sonyRemoteControl.SwitchOff();
            Console.ReadKey();
        }
    }
```````


## Advantages of Bridge Design Pattern:
- Decoupling: It decouples an abstraction from its implementation, allowing them to vary independently.
- Single Responsibility Principle: It promotes the principle by separating an abstraction from its implementation.
- Flexibility: Increases the flexibility in terms of the framework and its implementation.
- Extensibility: Both the abstractions and implementations can be extended independently.
- Prevents Cartelization: Avoids the ‘cartesian product’ complexity explosion. For example, if you have N abstractions and M implementations, you don’t need N*M classes.

## When to Use Bridge Design Pattern in C# Real-Time Applications?
The Bridge Design Pattern in C# is particularly useful in scenarios where:

- <b>Abstraction and Implementation Can Vary Independently:</b> When you want to decouple an abstraction from its implementation so that the two can vary independently. This is useful in cases where, for instance, the core functionality and the platform-specific details need to be developed and extended separately.
- <b>Changing Implementation at Runtime:</b> If your application needs to switch between different implementations at runtime. The Bridge pattern allows you to change the implementation dynamically without altering the abstraction.
- <b>Extending Classes in Separate Dimensions:</b> When you have multiple dimensions in your class hierarchy that need to be extended independently. For example, if you have a UI framework, you might want to extend UI controls independently from operating system-specific behaviors.
- <b>Avoiding a Permanent Binding to Implementation:</b> In scenarios where a permanent binding between the abstraction and its implementation might limit the flexibility and future scalability of the code.
- <b>Sharing an Implementation Among Multiple Objects:</b> When you need to share an implementation among multiple objects. The Bridge pattern allows multiple abstractions to use the same implementation, which can be more efficient.
- <b>Platform Independence:</b> It’s particularly useful in cross-platform applications where you want to hide the platform-specific code from the high-level logic.
- <b>Preventing Exponential Class Explosion:</b> In cases where a class hierarchy would result in an exponential number of combinations due to the various dimensions that can be extended. The Bridge pattern prevents this by separating the hierarchies.
- <b>Long-term Stability of Abstraction and Implementation:</b> When the parts of a system that represent high-level logic (abstraction) and low-level platform details or back-end logic (implementation) are subject to different rates of change or different types of change.