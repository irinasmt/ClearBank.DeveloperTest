using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    public class FasterPaymentsPaymentValidatorTests
    {

        private FasterPaymentsPaymentValidator fasterPaymentsPaymentValidator;

        [SetUp]
        public void SetUp()
        {
            fasterPaymentsPaymentValidator = new FasterPaymentsPaymentValidator();
        }

        [Test]
        public void Account_Bacs_PaymentScheme_FasterPayments_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };
            var makePaymentResult = fasterPaymentsPaymentValidator.IsAccountAllowedToMakePayment(account, 0);
            Assert.False(makePaymentResult);
        }

        [Test]
        public void Account_FasterPayments_Balance_0_RequestedAmount_1_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 0
            };
            var makePaymentResult = fasterPaymentsPaymentValidator.IsAccountAllowedToMakePayment(account, 1);
            Assert.False(makePaymentResult);
        }

        [Test]
        public void Account_FasterPayments_Balance_2_RequestedAmount_1_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 2
            };
            var makePaymentResult = fasterPaymentsPaymentValidator.IsAccountAllowedToMakePayment(account, 1);
            Assert.True(makePaymentResult);
        }
    }
}
