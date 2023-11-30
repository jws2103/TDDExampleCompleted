using TDDMAUI.Models;

namespace TDDMAUI.Services.Interfaces;

public interface IBankAccountService
{
    /// <summary>
    /// This will create your bank account
    /// </summary>
    /// <param name="accountHolder">holder name</param>
    /// <param name="depositAmount">initial deposit amount</param>
    /// <returns>account created</returns>
    BankAccount CreateAccount(string accountHolder, double initAmount);

    /// <summary>
    /// Deposit the money into my account
    /// </summary>
    /// <param name="amount">money to put</param>
    double Deposit(double amount);

    /// <summary>
    /// Withdraw the money from my account
    /// </summary>
    /// <param name="amount">amount to withdraw</param>
    double Withdraw(double amount);
}