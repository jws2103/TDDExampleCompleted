using Bogus;
using TDDMAUI.Models;

namespace TDDMAUI.UnitTests.ModelFactories;

public static class BankAccountFactory
{
    public static BankAccount GenerateBankAccount()
    {
        var testStrings = new[] {"Jay", "Liam", "Gokul", "Mihai"};
        var testNumbers = new[] { 1234, 5231, 1231 };
        var testDoubles = new[] { 12.0, 3.0, 100.0 };
        var bankAcct = new Faker<BankAccount>()
            .RuleFor(l => l.AccountName, f => f.PickRandom(testStrings))
            .RuleFor(l => l.AccountNumber, f => f.PickRandom(testNumbers.ToString()))
            .RuleFor(l => l.BSBNumber, f => f.PickRandom(testNumbers.ToString()))
            .RuleFor(l => l.AccountNumber, f => f.PickRandom(testNumbers.ToString()))
            .RuleFor(l => l.Balance, f => f.PickRandom(testDoubles));
        return bankAcct.Generate();
    }
}