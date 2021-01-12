using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    public class BacsPaymentValidatorTests
    {

        private BacsPaymentValidator bacsPaymentValidator;

        [SetUp]
        public void SetUp()
        {
            bacsPaymentValidator = new BacsPaymentValidator();
        }

        [Test]
        public void Account_FasterPayments_PaymentScheme_Bacs_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments
            };
            var makePaymentResult = bacsPaymentValidator.IsAccountAllowedToMakePayment(account, 0);
            Assert.False(makePaymentResult);
        }


        [Test]
        public void Account_Bacs_PaymentScheme_Bacs_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };
            var makePaymentResult = bacsPaymentValidator.IsAccountAllowedToMakePayment(account, 0);
            Assert.True(makePaymentResult);
        }
    }
}
