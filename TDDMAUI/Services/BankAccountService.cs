using TDDMAUI.Exceptions;
using TDDMAUI.Models;
using TDDMAUI.Services.Interfaces;

namespace TDDMAUI.Services;

public class BankAccountService : IBankAccountService
{
    private BankAccount _currentAccount;
    public BankAccount CreateAccount(string accountHolder, double initAmount)
    {
        if (string.IsNullOrEmpty(accountHolder) || initAmount < 0)
        {
            throw new ArgumentInvalidException("invalid arguments");
        }

        _currentAccount = new BankAccount
        {
            AccountName = accountHolder,
            Balance = initAmount,
            AccountNumber = "082143",
            BSBNumber = "54321234"
        };

        return _currentAccount;
    }

    public double Deposit(double amount)
    {
        /* Requirements
            1.  Throw AccountNotFoundException if your current account doesn't exist
            2.  Add your balance by the amount passed over
         */
        if (_currentAccount == null)
        {
            throw new AccountNotFoundException("account not found");
        }

        _currentAccount.Balance += amount;
        return _currentAccount.Balance;
    }

    public double Withdraw(double amount)
    {
        /* Requirements
            1.  Throw AccountNotFoundException if your current account doesn't exist
            2.  Throw AmountExceedException if amount to withdraw is greater than the current balance
            3.  Subtract the amount from your current balance
         */
        if (_currentAccount == null)
        {
            throw new AccountNotFoundException("account not found");
        }
            
        if (_currentAccount.Balance < amount)
        {
            throw new AmountExceedException("too much");
        }

        _currentAccount.Balance -= amount;
        return _currentAccount.Balance;
    }
}