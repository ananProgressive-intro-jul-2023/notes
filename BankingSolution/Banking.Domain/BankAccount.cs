namespace Banking.Domain;

public class BankAccount
{

    private decimal _balance = 5000;
    public void Deposit(decimal amountToDeposit)
    {

        GuardCorrectTransactionAmount(amountToDeposit);
        _balance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdrawal)
    {
        GuardCorrectTransactionAmount(amountToWithdrawal);
        GuardHasSufficentBalance(amountToWithdrawal);
        _balance -= amountToWithdrawal;
    }

    private void GuardHasSufficentBalance(decimal amountToWithdrawal)
    {
        if (amountToWithdrawal > _balance)
        {
            throw new AccountOverdraftException();
        }
    }

    private void GuardCorrectTransactionAmount(decimal amountToWithdrawal)
    {
        if (amountToWithdrawal <= 0)
        {
            throw new InvalidBankAccountTransactionAmountException();
        }
    }
}
