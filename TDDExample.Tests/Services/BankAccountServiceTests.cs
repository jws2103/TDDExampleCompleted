using System;
using FluentAssertions;
using Xunit;

namespace TDDExample.Tests.Services
{
    public class BankAccountServiceTests : UnitTestBase<BankAccountService>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateAccount_ShouldThrowArgumentInvalidException_WhenAccountHolderIsNullOrEmpty(string accountName)
        {
            // Arrange && act
            Action exception = () => Sut.CreateAccount(accountName, 10);

            // Assert
            exception.Should().Throw<ArgumentInvalidException>();
        }

        [Fact]
        public void CreateAccount_ShouldThrowArgumentInvalidException_WhenInitAmountIsNegative()
        {
            // Arrange
            Action exception = () => Sut.CreateAccount("test", -1);

            // Assert
            exception.Should().Throw<ArgumentInvalidException>();
        }

        [Fact]
        public void CreateAccount_ShouldReturnBankAccount_WhenArgumentsAllValid()
        {
            // Arrange
            var accountHolder = "test";
            double initAmount = 10;

            // Act
            var createdAccount = Sut.CreateAccount(accountHolder, initAmount);

            // Assert
            createdAccount.AccountName.Should().Be(accountHolder);
            createdAccount.Balance.Should().Be(initAmount);
            createdAccount.BSBNumber.Should().NotBeNullOrEmpty();
            createdAccount.AccountNumber.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public void Deposit_ShouldThrowAccountNotFoundException_WhenCurrentAccountDoesNotExist()
        {
            // Arrange && act
            Action balanceAction = () =>  Sut.Deposit(10);
            
            // Assert
            balanceAction.Should().Throw<AccountNotFoundException>();
        }
        
        [Fact]
        public void Deposit_ShouldReturnUpdatedBalance_WhenCurrentAccountExists()
        {
            // Arrange
            var accountCreated = Sut.CreateAccount("test", 10);
            
            // Act
            var balance = Sut.Deposit(10);
            
            // Assert
            balance.Should().Be(accountCreated.Balance);
        }
        
        [Fact]
        public void Withdraw_ShouldThrowAccountNotFoundException_WhenCurrentAccountDoesNotExist()
        {
            // Arrange && act
            Action balanceAction = () =>  Sut.Withdraw(10);
            
            // Assert
            balanceAction.Should().Throw<AccountNotFoundException>();
        }
        
        [Fact]
        public void Withdraw_ShouldThrowAmountExceedException_WhenCurrentBalanceLessThanWithdrawalAmount()
        {
            // Arrange
            Sut.CreateAccount("test", 10);
            
            // Act
            Action balanceAction = () =>  Sut.Withdraw(20);
            
            // Assert
            balanceAction.Should().Throw<AmountExceedException>();
        }
        
        [Fact]
        public void Withdraw_ShouldReturnUpdatedBalance_WhenCurrentAccountExists()
        {
            // Arrange
            var accountCreated = Sut.CreateAccount("test", 10);
            
            // Act
            var balance = Sut.Withdraw(10);
            
            // Assert
            balance.Should().Be(accountCreated.Balance);
        }
    }
}
