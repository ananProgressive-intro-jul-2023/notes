﻿namespace Banking.Domain;

public class BankAccount
{

    private readonly ICanCalculateBonusesForBankAccountDeposits _bonusCalculator;

    public BankAccount(ICanCalculateBonusesForBankAccountDeposits bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    private decimal _balance = 5000;
    public void Deposit(decimal amountToDeposit)
    {

        GuardCorrectTransactionAmount(amountToDeposit);
        
        var bonus = _bonusCalculator.CalculateBonusForDeposit(_balance, amountToDeposit);
        _balance += amountToDeposit + bonus;
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
