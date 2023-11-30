using MiniBankingApp;
using NSubstitute;

namespace MiniBankingApp.Tests
{
    public class BankAccountTests
    {

        // Test naming convention:
        // MethodName_ScenarioToTest_ExpectedOutcome()

        #region Test cases for DepositFunds

        [Fact]
        public void DepositFunds_NegativeAmount_ShouldNotProcessTransaction()
        {
            // Arrange
            //var demoAccount = new BankAccount("Alao", "Ola", 1000, "Savings");
            var substituteAccount = Substitute.For<BankAccount>("Alao", "Ola", 1000, "Savings");

            // Act
            //demoAccount.DepositFunds(-5000);
            substituteAccount.DepositFunds(-5000);

            // Assert
            //Assert.Equal(1000, demoAccount.CurrentBalance);
            Assert.Equal(1000, substituteAccount.CurrentBalance);
            substituteAccount.Received().DisplayBalance();
        }

        [Fact]
        public void DepositFunds_ZeroAsAmount_ShouldNotProcessTransaction()
        {
            // Arrange
            var demoAccount = new BankAccount("Alao", "Ola", 1000, "Savings");

            // Act
            demoAccount.DepositFunds(0);

            // Assert
            Assert.Equal(1000, demoAccount.CurrentBalance);
        }


        [Theory]
        [InlineData(-5000)]
        [InlineData(-1000)]
        [InlineData(0)]
        public void DepositFunds_InvalidAmount_ShouldNotProcessTransaction(double amount)
        {
            // Arrange
            var demoAccount = new BankAccount("Alao", "Ola", 1000, "Savings");

            // Act
            demoAccount.DepositFunds(amount);

            // Assert
            Assert.Equal(1000, demoAccount.CurrentBalance);
        }


        [Fact]
        public void DepositFunds_ValidAmount_ShouldProcessTransaction()
        {
            // Arrange
            //var demoAccount = new BankAccount("Alao", "Ola", 1000, "Savings");
            var substituteAccount = Substitute.For<BankAccount>("Alao", "Ola", 1000, "Savings");

            // Act
            //demoAccount.DepositFunds(2500);
            substituteAccount.DepositFunds(2500);

            // Assert
            //Assert.Equal(3500, demoAccount.CurrentBalance);
            Assert.Equal(3500, substituteAccount.CurrentBalance);
            substituteAccount.Received(0).DisplayBalance(); // TODO: Fix this assertion
        }

        #endregion


        #region Test cases for WithdrawFunds

        [Theory]
        [InlineData(5100)]
        [InlineData(7500)]
        [InlineData(15000)]
        public void WithdrawFunds_AmountGreaterThanBalance_ShouldNotProcessTransaction(double amount)
        {
            // Arrange
            var demoAccount = new BankAccount("Alao", "Ola", 5000, "Savings");

            // Act
            demoAccount.WithdrawFunds(amount);

            // Assert
            Assert.Equal(5000, demoAccount.CurrentBalance);
        }


        [Theory]
        [InlineData(5000, 1000, 4000)]
        [InlineData(50000, 5000, 45000)]
        [InlineData(10000, 10000, 0)]
        [InlineData(0, 10000, 0)]
        public void WithdrawFunds_AmountLessThanBalance_ShouldProcessTransaction(double openingBalance, double amount, double expectedBalance)
        {
            // Arrange
            var demoAccount = new BankAccount("Alao", "Ola", openingBalance, "Savings");

            // Act
            demoAccount.WithdrawFunds(amount);

            // Assert
            Assert.Equal(expectedBalance, demoAccount.CurrentBalance);
        }

        #endregion

    }
}