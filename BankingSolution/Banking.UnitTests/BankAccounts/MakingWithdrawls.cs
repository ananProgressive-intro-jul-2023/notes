

using Banking.Domain;

namespace Banking.UnitTests.BankAccounts;

public class MakingWithdrawls
{
    [Fact]
    public void MakingAWithdrawalDecreasesTheBalance()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToWithdrawal = 1.01M;

        account.Withdraw(amountToWithdrawal);

        Assert.Equal(openingBalance - amountToWithdrawal, account.GetBalance());    


    }

    [Fact]

    public void CanTakeEntireBalance()
    {
        var account = new BankAccount();
        account.Withdraw(account.GetBalance()); 

        Assert.Equal(0, account.GetBalance());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.1)]

    public void InvalidAmountsAreNotAllowed(decimal amount)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        Assert.Throws<InvalidBankAccountTransactionAmountException>(() =>
        {
            account.Withdraw(amount);
        });

        Assert.Equal(openingBalance, account.GetBalance());
    }


}
