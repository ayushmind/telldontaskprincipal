using System;

namespace MortgageService.Domain
{
    public class Customer
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal Balance { get; private set; }

        public byte BadCreditHistoryCount { get; private set; }

        public Customer(int id, string firstName, string lastName, decimal balance, byte badCreditHistoryCount = 0)
        {
            Id = id > 0 ? id : throw new ArgumentException(nameof(id));
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
            Balance = balance;
            BadCreditHistoryCount = badCreditHistoryCount;
        }

        public void UpdateBalance(decimal amount)
        {
            Balance = Balance + amount;
        }

        public bool IsEligibleForMortgage(decimal amountRequested)
        {
            bool isEligibleForMortgage = false;

            if (BadCreditHistoryCount == 0 && Balance > 0)
            {
                isEligibleForMortgage = Balance * 2 >= amountRequested;
            }
            return isEligibleForMortgage;
        }

    }
}
