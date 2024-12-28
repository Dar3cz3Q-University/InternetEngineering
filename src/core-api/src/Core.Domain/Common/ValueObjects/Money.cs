﻿using Core.Domain.Common.Models;

namespace Core.Domain.Common.ValueObjects
{
    public sealed class Money : ValueObject
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money(
            decimal amount,
            string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Create(
            decimal amount,
            string currency) 
        {
            return new(amount, currency);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
