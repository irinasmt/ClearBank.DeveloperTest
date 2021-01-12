using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    public class ChapsPaymentValidatorTests
    {

        private ChapsPaymentValidator chapsPaymentValidator;

        [SetUp]
        public void SetUp()
        {
            chapsPaymentValidator = new ChapsPaymentValidator();
        }


        [Test]
        public void Account_Bacs_PaymentScheme_Chaps_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
            };
            var makePaymentResult = chapsPaymentValidator.IsAccountAllowedToMakePayment(account,  0);
            Assert.False(makePaymentResult);
        }

        [Test]
        public void Account_Chaps_Live_PaymentScheme_Chaps_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Live
            };
            var makePaymentResult = chapsPaymentValidator.IsAccountAllowedToMakePayment(account,  0);
            Assert.True(makePaymentResult);
        }

        [Test]
        public void Account_Chaps_Disabled_PaymentScheme_Chaps_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Disabled
            };
            var makePaymentResult = chapsPaymentValidator.IsAccountAllowedToMakePayment(account,  0);
            Assert.False(makePaymentResult);
        }
    }
}
