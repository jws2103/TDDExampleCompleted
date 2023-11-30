using System.Windows.Input;
using PropertyChanged;
using TDDMAUI.Exceptions;
using TDDMAUI.Models;
using TDDMAUI.Services.Interfaces;

namespace TDDMAUI.ViewModels;

[AddINotifyPropertyChangedInterface]
public class MyAccountPageModel
{
    private readonly IBankAccountService _bankAccountService;
    private readonly ILogger _logger;
    public MyAccountPageModel(IBankAccountService bankAccountService, Services.Interfaces.ILogger logger)
    {
        _bankAccountService = bankAccountService;
        _logger = logger;
    }

    public BankAccount MyAccount { get; set; }

    public double DepositAmount { get; set; }

    public double WithdrawAmount { get; set; }

    public ICommand DepositCommand => new Command(DoDeposit);

    public ICommand WithdrawCommand => new Command(DoWithDraw);

    public void OnAppearing()
    {
        CreateAccount();
    }

    private void CreateAccount()
    {
        /* Requirements
            1.  Create the account with your name and initial deposit when the page is initiated
            2.  Set MyAccount
         */
        MyAccount = _bankAccountService.CreateAccount("test", 10);
    }

    private void DoDeposit()
    {
        /* Requirements
            1.  Call the Deposit method from IBankAccountService when DepositAmount is greater than 0
            2.  Update the Balance property of MyAccount
            3.  Reset DepositAmount to 0
            4.  Wrap with try & catch statement in case the exception is thrown
            4.1.Log the exception in catch
         */
        try
        {
            MyAccount.Balance = _bankAccountService.Deposit(DepositAmount);
            DepositAmount = 0;
        }
        catch (AccountNotFoundException ex)
        {
            _logger.Log(ex.Message);
        }
    }

    private void DoWithDraw()
    {
        /* Requirements
            1.  Call the Withdraw method from IBankAccountService when WithdrawAmount is greater than 0
            2.  Update the Balance property of MyAccount
            3.  Reset WithdrawAmount to 0
            4.  Wrap with try & catch statement in case the exception is thrown
            4.1.Log the exception in catch
         */
        try
        {
            MyAccount.Balance = _bankAccountService.Withdraw(WithdrawAmount);
            WithdrawAmount = 0;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.Message);
        }
    }
}