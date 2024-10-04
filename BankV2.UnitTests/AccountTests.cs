using Domain.Entities;
using FluentAssertions;

namespace BankV2.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Account_Debited_Negative_Amount_Should_Throw_An_Exception()
        {
            //Arrange
            var accountId = Guid.NewGuid();
            decimal balance = 1000;
            decimal overdraft = -500;
            decimal maxCreditAmount = 5000;
            Account accountA = new CurrentAccount(accountId, balance, overdraft);
            Account accountB = new SavingAccount(accountId, balance, maxCreditAmount);

            //Act
            Action actionA = () => accountA.Debit(-1);
            Action actionB = () => accountB.Debit(-1);
            
            //Assert
            actionA.Should().Throw<Exception>();
            actionB.Should().Throw<Exception>();
        }
        

        [Fact]
        public void Balance_Should_Be_Updated_After_Debit()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000;
            decimal overdraft = -500;
            decimal maxCreditAmount = 5000;
            Account accountA = new CurrentAccount(accountId, balance, overdraft);
            Account accountB = new SavingAccount(accountId, balance, maxCreditAmount);

            //Act
            accountA.Debit(100);
            accountB.Debit(100);
            
            //Assert
            accountA.Balance.Should().Be(900);
            accountB.Balance.Should().Be(900);
        }

        [Fact]
        public void Balance_Less_Than_Overdraft_After_Debit_Should_Throw_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000;
            decimal overdraft = -500;
            Account account = new CurrentAccount(accountId, balance, overdraft);

            //Act
            Action action = () => account.Debit(-600);

            //Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Balance_Should_Be_Updated_After_Credit()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000;
            decimal overdraft = -500;
            decimal maxCreditAmount = 5000;
            Account accountA = new CurrentAccount(accountId, balance, overdraft);
            Account accountB = new SavingAccount(accountId, balance, maxCreditAmount);

            //act
            accountA.Credit(100);
            accountB.Credit(100);

            //Assert
            accountA.Balance.Should().Be(1100);
            accountB.Balance.Should().Be(1100);
        }

        [Fact]
        public void Credited_Negative_Amount_Should_Throw_An_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000;
            decimal overdraft = -500;
            Account account = new CurrentAccount(accountId, balance, overdraft);

            //Act
            Action action =()=> account.Credit(-1);

            //Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Amount_Credit_Bigger_Than_Maximum_Amount_Credit_Allowed_For_Saving_Account_Should_Throw_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000;
            decimal overdraft = -500;
            decimal maxDeposit = 5000;
            Account account = new SavingAccount(accountId, balance, maxDeposit);

            //Act
            Action action = () => account.Credit(6000);

            //Assert
            action.Should().Throw<Exception>();
        }

    }
}