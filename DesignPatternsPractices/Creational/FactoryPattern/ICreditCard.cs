
namespace DesignPatternsPractices.Creational.FactoryPattern;

public interface ICreditCard
{
    string GetCardType();
    int GetCreditLimit();
    int GetAnnualCharge();
}
