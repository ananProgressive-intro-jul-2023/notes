

using Banking.Domain;

namespace Banking.UnitTests.BankAccounts;

public class GoldAccountScratch
{
    [Fact]
    public void GoldAccountsGetBonousOnDeposit()
    {
        var account = new GoldBankAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        

        account.Deposit(amountToDeposit);

        Assert.Equal(amountToDeposit + 10M + openingBalance, account.GetBalance());

    }
}
