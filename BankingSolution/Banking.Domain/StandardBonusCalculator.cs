using System.Data;

namespace Banking.Domain
{
    public class StandardBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
    {

        private readonly IProvideTheBusinessClock _businessClock;

        public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }

        public decimal CalculateBonusForDeposit(decimal balanceOnAccount, decimal amountOfDeposit)
        {
            decimal bonusMultiplier = _businessClock.IsDuringBusinessHours() ? .10M : 0;
            return  balanceOnAccount >= 6000M ? amountOfDeposit * bonusMultiplier : 0;
        }
    }
}