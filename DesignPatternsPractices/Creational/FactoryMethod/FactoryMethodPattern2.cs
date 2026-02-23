using DesignPatternsPractices.Creational.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.FactoryMethod;

public abstract class CreditCardFactory
{
    public abstract ICreditCard CreateCard();
}

public class MoneyBackFactory : CreditCardFactory
{
    public override ICreditCard CreateCard() => new MoneyBack();
}

public class PlatinumFactory : CreditCardFactory
{
    public override ICreditCard CreateCard() => new Platinum();
}

// Usage
//CreditCardFactory factory = new MoneyBackFactory();
//    CreditCard card = factory.CreateCard();
//Console.WriteLine(card.GetCardType());
