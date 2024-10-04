using Domain.Entities;
using FluentAssertions;

namespace BankV2.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Debited_Negative_Amount_Should_Throw_An_Exception()
        {
            //Arrange
            var accountId = Guid.NewGuid();
            decimal balance = 1000;
            Account account = new Account(accountId, balance);
           
            //Act
            Action action = () => account.Debit(-1);
            
            //Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Balance_Should_Be_Recalculated_After_Debit()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000; 
            Account account = new Account(accountId, balance);
           
            //Act
            account.Debit(100);
            
            //Assert
            account.Balance.Should().Be(900);
        }

        [Fact]
        public void Balance_Should_Be_Recalculated_After_Credit()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000;
            Account account = new Account(accountId, balance);

            //act
            account.Credit(100);

            //Assert
            account.Balance.Should().Be(1100);
        }

        [Fact]
        public void Credited_Negative_Amount_Should_Throw_An_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            decimal balance = 1000;
            Account account = new Account(accountId, balance);

            //Act
            Action action =()=> account.Credit(-1);

            //Assert
            action.Should().Throw<Exception>();
        }
    }
}