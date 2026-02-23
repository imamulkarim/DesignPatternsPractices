using DesignPatternsPractices.Creational.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.AbstractFactoryPattern2;

// 1. Abstract Products
public interface IButton
{
    void Paint();
}

public interface ICheckbox
{
    void Paint();
}

// 2. Concrete Products
// (Windows variant)
public class WindowsButton : IButton
{
    public void Paint() => Console.WriteLine("Rendering a button in a Windows style.");
}

public class WindowsCheckbox : ICheckbox
{
    public void Paint() => Console.WriteLine("Rendering a checkbox in a Windows style.");
}

// MacOS Products
public class MacOSButton : IButton
{
    public void Paint() => Console.WriteLine("Rendering a button in macOS style.");
}
public class MacOSCheckbox : ICheckbox
{
    public void Paint() => Console.WriteLine("Rendering a checkbox in macOS style.");
}

// 3. Abstract Factory
public interface IUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// 4. Concrete Factory (Windows variant)
public class WindowsFactory : IUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}
public class MacOSFactory : IUIFactory
{
    public IButton CreateButton() => new MacOSButton();
    public ICheckbox CreateCheckbox() => new MacOSCheckbox();
}


public class Application
{
    private readonly IUIFactory _factory;
    private IButton _button = null!;
    private ICheckbox _checkbox = null!;

    public Application(IUIFactory factory)
    {
        _factory = factory;
    }

    public void CreateUI()
    {
        _button = _factory.CreateButton();
        _checkbox = _factory.CreateCheckbox();
    }

    public void PaintUI()
    {
        _button.Paint();
        _checkbox.Paint();
    }
}

// Usage in Main
internal class UIFactory
{
    // Dictionary mapping card type strings to their corresponding class types
    private static readonly Dictionary<string, Type> uiComponentRegistry = new Dictionary<string, Type>
    {
        { "windows", typeof(WindowsFactory) },
        { "macos", typeof(MacOSFactory) }
    };

    public static IUIFactory GetInstance(string osname)
    {
        if (uiComponentRegistry.ContainsKey(osname))
        {
            return (IUIFactory)Activator.CreateInstance(uiComponentRegistry[osname])!;
        }

        throw new ArgumentException($"Invalid osname :{osname}");
    }

}
