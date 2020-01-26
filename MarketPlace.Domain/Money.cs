using System;
using MarketPlace.Framework;

namespace MarketPlace.Domain {
    public class Money : Value<Money> {

        private const string DefaultCurrency = "EUR";

        public static Money FromDecimal (decimal amount, string currency = DefaultCurrency) => new Money (amount, currency);

        public static Money FromString (string amount, string currency = DefaultCurrency) => new Money (decimal.Parse (amount), currency);
        public decimal Amount { get; }
        public string CurrencyCode { get; }
        public Money (decimal amount, string currencyCode = DefaultCurrency) {
            if (decimal.Round (amount, 2) != amount) {
                throw new ArgumentException ("Amount cannot have more than 2 decimals", nameof (amount));
            }
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public Money Add (Money summand) {
            if (CurrencyCode != summand.CurrencyCode) {
                throw new CurrencyMismatchException ("Cannot sum amounts with different currencies");
            }
            return new Money (Amount + summand.Amount);
        }
        public Money Subtract (Money subtrahend) {
            if (CurrencyCode != subtrahend.CurrencyCode) {
                throw new CurrencyMismatchException ("Cannot subtract amounts with different currencies");
            }
            return new Money (Amount + subtrahend.Amount);
        }

        public static Money operator + (Money summand1, Money summand2) => summand1.Add (summand2);

        public static Money operator - (Money subtrahend1, Money subtrahend2) => subtrahend1.Subtract (subtrahend2);
    }

    public class CurrencyMismatchException : Exception {
        public CurrencyMismatchException (string message) : base (message) { }
    }
}