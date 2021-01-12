using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class PaymentServiceTests
    {
        private IPaymentService paymentService;
        private Mock<IAccountService> mockAccountService;

        [SetUp]
        public void SetUp()
        {
            mockAccountService = new Mock<IAccountService>();
            paymentService = new PaymentService(mockAccountService.Object);
        }

        [Test]
        public void AccountStatus_False_Returns_MakePayment_False()
        {
            mockAccountService.Setup(f => f.GetAccount(It.IsAny<string>())).Returns(new Account());
            mockAccountService.Setup(f => f.CheckAccountStatus(It.IsAny<Account>(), PaymentScheme.Bacs, 2)).Returns(false);

            var request = new MakePaymentRequest
            {
                PaymentScheme = PaymentScheme.Bacs,
                Amount = 1
            };
            var makePaymentReult = paymentService.MakePayment(request);

            Assert.False(makePaymentReult.Success);
        }

        [Test]
        public void AccountStatus_True_Returns_MakePayment_True()
        {
            var debtorAccountNumber = "123";
            var account = new Account() { Balance = 3 };

            mockAccountService.Setup(f => f.GetAccount(It.IsAny<string>())).Returns(account);
            mockAccountService.Setup(f => f.CheckAccountStatus(It.IsAny<Account>(), PaymentScheme.Bacs, 2)).Returns(true);


            var request = new MakePaymentRequest
            {
                PaymentScheme = PaymentScheme.Bacs,
                Amount = 2,
                DebtorAccountNumber = debtorAccountNumber
            };
            var makePaymentReult = paymentService.MakePayment(request);

            Assert.True(makePaymentReult.Success);
            Assert.AreEqual(1, account.Balance);
        }

    }
}
