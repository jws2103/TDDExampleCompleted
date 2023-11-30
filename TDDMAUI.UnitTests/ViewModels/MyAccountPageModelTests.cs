using FluentAssertions;
using Moq;
using TDDMAUI.Exceptions;
using TDDMAUI.Models;
using TDDMAUI.Services.Interfaces;
using TDDMAUI.ViewModels;

namespace TDDMAUI.UnitTests.ViewModels;

public class MyAccountPageModelTests : UnitTestBase<MyAccountPageModel>
{
    [Fact]
    public void OnAppearing_ShouldSetMyAccount_WhenCreateAccountSucceed()
    {
        // Arrange
        var mockedBankAcctSvc = Mocker.GetMock<IBankAccountService>();
        mockedBankAcctSvc.Setup(b => b.CreateAccount(It.IsAny<string>(), It.IsAny<double>()))
            .Returns(new BankAccount());
        
        // Act
        Sut.OnAppearing();
        
        // Assert
        Sut.MyAccount.Should().NotBeNull();
    }
    
    [Fact]
    public void DepositCommand_ShouldLogError_WhenBankAccountThrowsArgumentInvalidException()
    {
        // Arrange
        var accountNotFoundException = new AccountNotFoundException("invalid");
        var mockedLogger = Mocker.GetMock<TDDMAUI.Services.Interfaces.ILogger>();
        var mockedBankAcctSvc = Mocker.GetMock<IBankAccountService>();
        mockedBankAcctSvc.Setup(b => b.Deposit(It.IsAny<double>())).Throws(accountNotFoundException);
        
        // Act
        Sut.DepositCommand.Execute(null);
        
        // Assert
        mockedLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
    }
    
    [Fact]
    public void DepositCommand_ShouldUpdateBalanceAndResetDepositAmount_WhenDepositSucceeds()
    {
        // Arrange
        double initialBalance = 10;
        double depositAmount = 20;
        var mockedBankAcctSvc = Mocker.GetMock<IBankAccountService>();
        mockedBankAcctSvc.Setup(b => b.CreateAccount(It.IsAny<string>(), It.IsAny<double>()))
            .Returns(new BankAccount
            {
                Balance = initialBalance
            });
        mockedBankAcctSvc.Setup(b => b.Deposit(depositAmount)).Returns(initialBalance + depositAmount);
        Sut.OnAppearing();
        Sut.DepositAmount = depositAmount;
        
        // Act
        Sut.DepositCommand.Execute(null);
        
        // Assert
        Sut.MyAccount.Balance.Should().Be(initialBalance + depositAmount);
        Sut.DepositAmount.Should().Be(0);
    }
    
    [Fact]
    public void WithdrawCommand_ShouldLogError_WhenBankAccountThrowsArgumentInvalidException()
    {
        // Arrange
        var accountNotFoundException = new AccountNotFoundException("invalid");
        var mockedLogger = Mocker.GetMock<TDDMAUI.Services.Interfaces.ILogger>();
        var mockedBankAcctSvc = Mocker.GetMock<IBankAccountService>();
        mockedBankAcctSvc.Setup(b => b.Withdraw(It.IsAny<double>())).Throws(accountNotFoundException);
        
        // Act
        Sut.WithdrawCommand.Execute(null);
        
        // Assert
        mockedLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
    }
    
    [Fact]
    public void WithdrawCommand_ShouldUpdateBalanceAndResetWithdrawAmount_WhenWithdrawalSucceeds()
    {
        // Arrange
        double initialBalance = 30;
        double withdrawAmount = 20;
        var mockedBankAcctSvc = Mocker.GetMock<IBankAccountService>();
        mockedBankAcctSvc.Setup(b => b.CreateAccount(It.IsAny<string>(), It.IsAny<double>()))
            .Returns(new BankAccount
            {
                Balance = initialBalance
            });
        mockedBankAcctSvc.Setup(b => b.Withdraw(withdrawAmount)).Returns(initialBalance - withdrawAmount);
        Sut.OnAppearing();
        Sut.WithdrawAmount = withdrawAmount;
        
        // Act
        Sut.WithdrawCommand.Execute(null);
        
        // Assert
        Sut.MyAccount.Balance.Should().Be(initialBalance - withdrawAmount);
        Sut.WithdrawAmount.Should().Be(0);
    }
}