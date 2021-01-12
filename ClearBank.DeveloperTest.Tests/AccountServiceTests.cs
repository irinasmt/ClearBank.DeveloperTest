using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private IAccountService accountService;
        private Mock<IDataStoreFactory> mockDataStoreFactory;
        private Mock<IPaymentValidatorFactory> mockPaymentValidatorFactory;


        [SetUp]
        public void SetUp()
        {
            mockDataStoreFactory = new Mock<IDataStoreFactory>();
            mockPaymentValidatorFactory = new Mock<IPaymentValidatorFactory>();

            accountService = new AccountService(mockDataStoreFactory.Object, mockPaymentValidatorFactory.Object);
        }
      
        [Test]
        public void AccountNull_Returns_MakePayment_False()
        {
            var makePaymentResult = accountService.CheckAccountStatus(null, Types.PaymentScheme.Bacs, 0);
            Assert.False(makePaymentResult);
        }

    }
}
