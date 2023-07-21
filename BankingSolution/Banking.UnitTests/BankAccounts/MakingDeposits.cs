

using Banking.Domain;

namespace Banking.UnitTests.BankAccounts;

public class MakingDeposits
{

    [Fact]
    public void DepositsIncreaseTheBalance()
    {
        // Given - Arrange
        var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.23M;

        // When - Act
        account.Deposit(amountToDeposit);

        // Then - Assert
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }

    public class DummyBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
    {
        public decimal CalculateBonusForDeposit(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}

