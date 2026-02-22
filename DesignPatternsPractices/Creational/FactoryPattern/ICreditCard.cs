
namespace DesignPatternsPractices.Creational.FactoryPattern;

internal interface ICreditCard
{
    string GetCardType();
    int GetCreditLimit();
    int GetAnnualCharge();
}
